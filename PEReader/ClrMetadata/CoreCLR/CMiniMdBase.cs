using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;

#pragma warning disable 0649

namespace PEReader.ClrMetadata.CoreCLR
{
    internal class CMiniMdBase
    {
        internal const int MetaModelMajorVer = 2;
        internal const int MetaModelMinorVer = 0;

        internal const int MetaModelV1MajorVer = 1;
        internal const int MetaModelV1MinorVer = 0;

        internal const int MetaModelVB1MajorVer = 1;
        internal const int MetaModelVB1MinorVer = 1;


        protected readonly CMiniMdSchema m_Schema;
        protected readonly CMiniTableDef[] m_TableDefs;
        protected uint m_TblCount;


        protected uint m_iStringsMask;
        protected uint m_iGuidsMask;
        protected uint m_iBlobsMask;


        public CMiniMdSchema Schema
        {
            get { return m_Schema; }
        }

        public uint TableCount
        {
            get { return m_TblCount; }
        }


        public CMiniTableDef this[ClrTable table]
        {
            get { return m_TableDefs[(int)table]; }
        }


        public CMiniMdBase(Stream stream)
        {
            m_TblCount = MetaModel.TBL_COUNT;
            m_TableDefs = new CMiniTableDef[MetaModel.TBL_COUNT];

            for (int i = 0; i < m_TableDefs.Length; i++)
            {
                m_TableDefs[i] = MetaModel.g_Tables[i].m_Def.Clone();
            }


            m_Schema = new CMiniMdSchema(stream);
            SchemaPopulate();
        }


        private CMiniMdSchema SchemaPopulate()
        {
            if (m_Schema.MajorVersion != MetaModelMajorVer ||
                m_Schema.MinorVersion != MetaModelMinorVer)
            {
                // does not match this version.
            
                if (m_Schema.MajorVersion == MetaModelV1MajorVer &&
                    m_Schema.MinorVersion == MetaModelV1MinorVer)
                {
                    // older version just has fewer tables.
                    m_TblCount = MetaModel.TBL_COUNT_V1;
                }
                else if (m_Schema.MajorVersion  == MetaModelVB1MajorVer &&
                         m_Schema.MinorVersion == MetaModelVB1MinorVer)
                {
                    // 1.1 had a different type of GenericParam table.
                    m_TableDefs[MetaModel.TBL_GenericParam] = MetaModel.g_Table_GenericParamV1_1.m_Def;
                }
                else
                {
                    //TODO: better exceptions
                    throw new Exception("Unsupported version of Metadata.");
                }
            }

            // CoreClr: CMiniMdBase::SchemaPopulate2
            m_iStringsMask = (m_Schema.StringIndexSize == 4) ? 0xFFFFFFFF : 0xFFFF;
            m_iGuidsMask = (m_Schema.GuidIndexSize == 4) ? 0xFFFFFFFF : 0xFFFF;
            m_iBlobsMask = (m_Schema.BlobIndexSize == 4) ? 0xFFFFFFFF : 0xFFFF;

            uint nTables = m_TblCount;
            for (uint i = 0; i < nTables; i++)
            {
                InitColsForTable(i);
            }

            for (uint i = m_TblCount; i < m_TableDefs.LongLength; i++)
            {
                if (m_Schema.RowCount[i] != 0)
                {
                    //TODO: better exceptions
                    throw new Exception("Invalid table present.");
                }
            }

            return m_Schema;
        }

        private void InitColsForTable(uint tableIdx)
        {
            int prevSize = 0;

            CMiniColDef[] columns = m_TableDefs[tableIdx].m_pColDefs;
            int nColumns = columns.Length;

            // update sizes + offsets
            for (int i = 0; i < nColumns; i++)
            {
                int colType = columns[i].m_Type;
                int fieldSize = ColumnTypeSize(colType);

                columns[i] = new CMiniColDef((byte)colType, (byte)prevSize, (byte)fieldSize);

                // align to 2 byte boundary
                fieldSize += (fieldSize & 1);

                prevSize += fieldSize;
            }

            byte key = m_TableDefs[tableIdx].m_iKey;

            if (key >= nColumns)
            {
                key = unchecked((byte)(~0u));
            }

            // update key and total size
            m_TableDefs[tableIdx] = new CMiniTableDef(
                m_TableDefs[tableIdx].m_pColDefs,
                key,
                prevSize,
                m_TableDefs[tableIdx].m_RecordType
            );
        }

        private int ColumnTypeSize(int type)
        {
            if (0 <= type && type <= MetaModel.iRidMax)
            {
                ClrTable table = (ClrTable)type;
                long rowCount = m_Schema.RowCount[table];
                return (rowCount > 0xFFFF) ? 4 : 2;
            }
            else if (MetaModel.iCodedToken <= type && type <= MetaModel.iCodedTokenMax)
            {
                ClrCodedToken cdtkn = (ClrCodedToken)(type - MetaModel.iCodedToken);
                return SizeOfCodedToken(cdtkn);
            }
            else if (type == MetaModel.iBYTE)
            {
                return 1;
            }
            else if (type == MetaModel.iSHORT || type == MetaModel.iUSHORT)
            {
                return 2;
            }
            else if (type == MetaModel.iLONG || type == MetaModel.iULONG)
            {
                return 4;
            }
            else if (type == MetaModel.iSTRING)
            {
                return m_Schema.StringIndexSize;
            }
            else if (type == MetaModel.iGUID)
            {
                return m_Schema.GuidIndexSize;
            }
            else if (type == MetaModel.iBLOB)
            {
                return m_Schema.BlobIndexSize;
            }

            throw new ArgumentException("Unexpected metadata field type.");
        }

        private int SizeOfCodedToken(ClrCodedToken token)
        {
            CCodedTokenDef def = MetaModel.g_CodedTokens[(int)token];

            int tagSize = CountBits(def.m_pTokens.Length - 1);

            foreach (var tableMdt in def.m_pTokens)
            {
                ClrTable table = tableMdt.GetTable();

                int rowIdxSize = CountBits(Math.Max(m_Schema.RowCount[table], 1) - 1);
                if (tagSize + rowIdxSize > 16)
                {
                    // one of the possible tables needs the 4 byte token.
                    return 4;
                }
            }

            // we can index all possible tables with a 2-byte token.
            return 2;
        }

        private static int CountBits(long value)
        {
            int nBits = 0;

            while (value > 0)
            {
                nBits++;
                value >>= 1;
            }

            return nBits;
        }
    }
}
