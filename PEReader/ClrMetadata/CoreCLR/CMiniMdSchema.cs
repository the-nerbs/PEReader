using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace PEReader.ClrMetadata.CoreCLR
{
    internal class CMiniMdSchema
    {
        private readonly CMiniMdSchemaBase _base;

        private readonly uint[] m_cRecs = new uint[MetaModel.TBL_COUNT];
        private uint m_ulExtra;


        public int MajorVersion
        {
            get { return _base.m_major; }
        }

        public int MinorVersion
        {
            get { return _base.m_minor; }
        }

        public Version Version
        {
            get { return new Version(MajorVersion, MinorVersion); }
        }


        public int StringIndexSize
        {
            get { return ((_base.m_heaps & HeapFlags.HeapString4) != 0) ? 4 : 2; }
        }

        public int GuidIndexSize
        {
            get { return ((_base.m_heaps & HeapFlags.HeapGuid4) != 0) ? 4 : 2; }
        }

        public int BlobIndexSize
        {
            get { return ((_base.m_heaps & HeapFlags.HeapBlob4) != 0) ? 4 : 2; }
        }

        public ulong TableValidityBits
        {
            get { return _base.m_maskvalid; }
        }

        public TableRowCountAccessor RowCount
        {
            get { return new TableRowCountAccessor(this); }
        }


        public CMiniMdSchema(Stream stream)
        {
            _base = stream.Read<CMiniMdSchemaBase>();

            LoadFrom(stream);
        }


        public uint LoadFrom(Stream stream)
        {
            const uint Failure = ~0u;

            uint ulData = unchecked((uint)Marshal.SizeOf(typeof(CMiniMdSchemaBase)));

            ulong maskvalid = _base.m_maskvalid;

            // read for tables that we know:
            for (int i = 0;
                 i < MetaModel.TBL_COUNT;
                 i++, maskvalid >>= 1)
            {
                if ((maskvalid & 1) != 0)
                {
                    uint dataTemp = unchecked(ulData + sizeof(uint));

                    // check against overflow + early EOF
                    if (dataTemp < ulData ||
                        stream.Length < (stream.Position + sizeof(uint)))
                    {
                        return Failure;
                    }

                    m_cRecs[i] = stream.Read<uint>();
                    ulData += sizeof(uint);
                }
            }

            // read tables that we don't know.
            for (int i = MetaModel.TBL_COUNT;
                 maskvalid != 0 && i < (sizeof(ulong)*8);
                 i++, maskvalid >>= 1)
            {
                if ((maskvalid & 1) != 0)
                {
                    uint dataTemp = ulData + sizeof(uint);

                    // check against overflow + early EOF
                    if (dataTemp < ulData ||
                        stream.Length < (stream.Position + sizeof(uint)))
                    {
                        return Failure;
                    }

                    ulData = dataTemp;
                }
            }

            if ((_base.m_heaps & HeapFlags.ExtraData) != 0)
            {
                uint dataTemp = ulData + sizeof(uint);

                // check against overflow + early EOF
                if (dataTemp < ulData ||
                    stream.Length < (stream.Position + sizeof(uint)))
                {
                    return Failure;
                }

                m_ulExtra = stream.Read<uint>();
                ulData += sizeof(uint);
            }

            return ulData;
        }


        public struct TableRowCountAccessor
        {
            private readonly CMiniMdSchema _schema;


            public uint this[ClrTable table]
            {
                get { return this[(uint)table]; }
            }

            public uint this[uint table]
            {
                get
                {
                    if (table >= MetaModel.TBL_COUNT)
                        throw new ArgumentOutOfRangeException(nameof(table));

                    if (table < _schema.m_cRecs.Length)
                    {
                        return _schema.m_cRecs[table];
                    }

                    return 0;
                }
            }


            internal TableRowCountAccessor(CMiniMdSchema schema)
            {
                _schema = schema;
            }
        }
    }
}
