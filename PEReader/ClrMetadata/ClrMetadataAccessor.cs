using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using PEReader.ClrMetadata.CoreCLR;
using PEReader.ClrMetadata.Native;

namespace PEReader.ClrMetadata
{
    /// <summary>
    /// Provides access to CLR metadata.
    /// </summary>
    public sealed partial class ClrMetadataAccessor
    {
        private readonly PeDotNetInformation _mdParent;
        private readonly CMiniMdBase _md;
        private readonly MetadataTableBase[] _tables;


        internal ClrMetadataAccessor(PeDotNetInformation mdParent, Stream peStream, STORAGESTREAM streamInfo, long baseOffset)
        {
            _mdParent = mdParent;

            long offset = baseOffset + streamInfo.iOffset;
            long end = offset + streamInfo.iSize;

            peStream.Seek(offset, SeekOrigin.Begin);

            _md = new CMiniMdBase(peStream);
            _tables = new MetadataTableBase[_md.TableCount];

            peStream.AlignToBytes(4);

            for (int i = 0; i < _tables.Length; i++)
            {
                ClrTable table = (ClrTable)i;

                Type recordType = _md[table].m_RecordType;
                Type tableType = typeof(MetadataTable<>).MakeGenericType(recordType);

                long startPosition = peStream.Position;
                long tableSize = _md[table].m_cbRec * _md.Schema.RowCount[table];
                long expectedEnd = startPosition + tableSize;

                _tables[i] = (MetadataTableBase)Activator.CreateInstance(tableType, _md, table, peStream);


                Debug.Assert(peStream.Position == expectedEnd);
            }

            long diff = peStream.Position - end;
            Debug.Assert(diff == 0 || diff == -2 || diff == -4);


            ulong validBits = _md.Schema.TableValidityBits;

            for (int i = 0;
                 i < _tables.Length;
                 i++, validBits >>= 1)
            {
                if ((validBits & 1) != 0)
                {
                    Debug.Assert(_tables[i].RowCount > 0, "used table has no rows.");
                }
                else
                {
                    Debug.Assert(_tables[i].RowCount == 0, "unused table has rows.");
                }
            }
        }
    }
}
