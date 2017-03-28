using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace PEReader.ClrMetadata.CoreCLR
{
    //=========================================================================
    // Note: Definitions in this file are used by the schema generator!
    //       Modify with care!
    //=========================================================================


    internal enum CorTokenType : uint
    {
        mdtModule                 = 0x00000000,       //
        mdtTypeRef                = 0x01000000,       //
        mdtTypeDef                = 0x02000000,       //
        mdtFieldDef               = 0x04000000,       //
        mdtMethodDef              = 0x06000000,       //
        mdtParamDef               = 0x08000000,       //
        mdtInterfaceImpl          = 0x09000000,       //
        mdtMemberRef              = 0x0a000000,       //
        mdtCustomAttribute        = 0x0c000000,       //
        mdtPermission             = 0x0e000000,       //
        mdtSignature              = 0x11000000,       //
        mdtEvent                  = 0x14000000,       //
        mdtProperty               = 0x17000000,       //
        mdtMethodImpl             = 0x19000000,       //
        mdtModuleRef              = 0x1a000000,       //
        mdtTypeSpec               = 0x1b000000,       //
        mdtAssembly               = 0x20000000,       //
        mdtAssemblyRef            = 0x23000000,       //
        mdtFile                   = 0x26000000,       //
        mdtExportedType           = 0x27000000,       //
        mdtManifestResource       = 0x28000000,       //
        mdtGenericParam           = 0x2a000000,       //
        mdtMethodSpec             = 0x2b000000,       //
        mdtGenericParamConstraint = 0x2c000000,

        mdtString                 = 0x70000000,       //
        mdtName                   = 0x71000000,       //
        mdtBaseType               = 0x72000000,       // Leave this on the high end value. This does not correspond to metadata table
    }

    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    internal sealed class CCodedTokenDef
    {
        public readonly CorTokenType[] m_pTokens;
        public readonly string m_pName;

        public CCodedTokenDef(CorTokenType[] tokens, string name)
        {
            m_pTokens = tokens;
            m_pName = name;
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    internal struct CMiniColDef
    {
        public readonly byte m_Type;                 // Type of the column.
        public readonly byte m_oColumn;              // Offset of the column.
        public readonly byte m_cbColumn;             // Size of the column.


        public CMiniColDef(byte type)
            : this(type, 0, 0)
        { }

        public CMiniColDef(byte type, byte offset, byte size)
        {
            m_Type = type;
            m_oColumn = offset;
            m_cbColumn = size;
        }


        public CMiniColDef Clone()
        {
            return new CMiniColDef(m_Type, m_oColumn, m_cbColumn);
        }
    };

    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    internal struct CMiniTableDef
    {
        public readonly CMiniColDef[] m_pColDefs;

        public readonly byte m_iKey;
        public readonly ushort m_cbRec;

        //NerbsCode: keep the record types around
        public readonly Type m_RecordType;

        public byte m_cCols
        {
            get { return (byte)(m_pColDefs.Length & 0xFF); }
        }


        public CMiniTableDef(CMiniColDef[] columns, int keyField, int cbRec, Type recordType)
        {
            m_pColDefs = columns;
            m_iKey = checked((byte)keyField);
            m_cbRec = checked((ushort)cbRec);

            m_RecordType = recordType;
        }


        public CMiniTableDef Clone()
        {
            var columnClone = new CMiniColDef[m_pColDefs.Length];
            for (int i = 0; i < m_pColDefs.Length; i++)
            {
                columnClone[i] = m_pColDefs[i].Clone();
            }

            return new CMiniTableDef(columnClone, m_iKey, m_cbRec, m_RecordType);
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    internal sealed class CMiniTableDefEx
    {
        public readonly CMiniTableDef m_Def;
        public readonly string[] m_pColNames;
        public readonly string m_pName;


        public CMiniTableDefEx(CMiniColDef[] columns, int keyField, int cbRec, string[] colNames, string name, Type recordType)
            : this(new CMiniTableDef(columns, keyField, cbRec, recordType), colNames, name)
        { }

        public CMiniTableDefEx(CMiniTableDef def, string[] colNames, string name)
        {
            m_Def = def;
            m_pColNames = colNames;
            m_pName = name;
        }


        public CMiniTableDefEx Clone()
        {
            return new CMiniTableDefEx(m_Def.Clone(), m_pColNames, m_pName);
        }
    }


    internal enum ColumnType
    {
        Rid        = 0,
        CodedToken = MetaModel.iCodedToken,
        SHORT      = MetaModel.iSHORT,
        USHORT     = MetaModel.iUSHORT,
        LONG       = MetaModel.iLONG,
        ULONG      = MetaModel.iULONG,
        BYTE       = MetaModel.iBYTE,
        String     = MetaModel.iSTRING,
        Guid       = MetaModel.iGUID,
        Blob       = MetaModel.iBLOB,
    }

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    internal sealed class ColumnIndexAttribute : Attribute
    {
        public int Index { get; }
        public ColumnType Type { get; }

        public int SubType { get; set; }

        public ColumnIndexAttribute(int index, ColumnType type)
        {
            Index = index;
        }
    }


    internal interface IMetadataRecord
    {
        long Key { get; }
    }
}
