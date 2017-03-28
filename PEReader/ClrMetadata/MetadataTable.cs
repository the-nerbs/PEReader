using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using PEReader.ClrMetadata.CoreCLR;

namespace PEReader.ClrMetadata
{
    internal sealed class MetadataTable<TRecord> : MetadataTableBase, IEnumerable<TRecord>
        where TRecord : IMetadataRecord, new()
    {
        private readonly TRecord[] _items;


        public TRecord this[int index]
        {
            get { return _items[index]; }
        }

        public TRecord this[uint index]
        {
            get { return _items[index]; }
        }


        public MetadataTable(CMiniMdBase md, ClrTable table, Stream peStream)
            : base(md, table)
        {
            _items = ReadTable(peStream);
        }


        public bool TryGetRecordByKey(long key, out TRecord record)
        {
            if (!DefinesKey)
            {
                throw new InvalidOperationException("Table does not define a key field.");
            }

            if (RowCount > 0)
            {
                // tables are sorted by key field, so do a binary search.
                int low = 0;
                int high = _items.Length - 1;


                while (low < high)
                {
                    int pivot = (low + high) / 2;

                    long recordKey = _items[pivot].Key;
                    if (recordKey == key)
                    {
                        // we found the key already
                        record = _items[pivot];
                        return true;
                    }

                    if (recordKey < key)
                    {
                        low = pivot + 1;
                    }
                    else
                    {
                        high = pivot - 1;
                    }
                }

                if (_items[low].Key == key)
                {
                    record = _items[low];
                    return true;
                }
            }

            record = default(TRecord);
            return false;
        }

        public IEnumerator<TRecord> GetEnumerator()
        {
            return new TypedArrayEnumerator<TRecord>(_items);
        }


        private TRecord[] ReadTable(Stream peStream)
        {
            var columns = new ColumnIndexAttribute[ColumnCount];
            var fields = new FieldInfo[ColumnCount];

            // map the fields to columns
            foreach (var fld in typeof(TRecord).GetFields())
            {
                var indexAttr = fld
                    .GetCustomAttributes(false)
                    .OfType<ColumnIndexAttribute>()
                    .FirstOrDefault();

                if (indexAttr != null)
                {
                    int index = indexAttr.Index;
                    if (columns[index] != null || fields[index] != null)
                    {
                        throw new InvalidOperationException($"Duplicate field index {index} in record type {typeof(TRecord).FullName}");
                    }

                    columns[index] = indexAttr;
                    fields[index] = fld;
                }
            }

            if (columns.Any(c => c == null) ||
                fields.Any(f => f == null))
            {
                throw new InvalidOperationException($"Could not map all columns of record type {typeof(TRecord).FullName}.");
            }


            // map the stream data to fields.
            var records = new TRecord[RowCount];

            const int MaxFieldSize = 4;
            var fieldBytes = new byte[MaxFieldSize];

            for (int row = 0; row < RowCount; row++)
            {
                // note: in the case that TRecord is a struct, we box + unbox it so we can populate via reflection.
                object rec = new TRecord();

                int recBytes = 0;

                for (int col = 0; col < ColumnCount; col++)
                {
                    CMiniColDef colDef = _tableDef.m_Def.m_pColDefs[col];

                    if (recBytes != colDef.m_oColumn)
                    {
                        // skip past any padding bytes.
                        peStream.Seek(colDef.m_oColumn - recBytes, SeekOrigin.Current);

                        recBytes = colDef.m_oColumn;
                    }

                    peStream.Read(fieldBytes, 0, colDef.m_cbColumn);

                    fields[col].SetValue(rec, ConvertBytes(fieldBytes, colDef));

                    recBytes += colDef.m_cbColumn;
                }

                records[row] = (TRecord)rec;
            }

            return records;
        }

        private object ConvertBytes(byte[] bytes, CMiniColDef column)
        {
            // read RIDs, CodedTokens
            if (column.m_Type < MetaModel.iCodedTokenMax)
            {
                if (column.m_cbColumn == 2)
                {
                    return BitConverter.ToUInt16(bytes, 0);
                }
                else if (column.m_cbColumn == 4)
                {
                    return BitConverter.ToUInt32(bytes, 0);
                }

                throw new ArgumentException($"Unexpected data size for RID or Coded Token: {column.m_cbColumn} bytes");
            }
            else
            {
                // read types with specific values.
                ColumnType type = (ColumnType)column.m_Type;

                switch (type)
                {
                    case ColumnType.String:
                    case ColumnType.Guid:
                    case ColumnType.Blob:
                        if (column.m_cbColumn == 2)
                        {
                            return BitConverter.ToUInt16(bytes, 0);
                        }
                        else if (column.m_cbColumn == 4)
                        {
                            return BitConverter.ToUInt32(bytes, 0);
                        }
                        break;

                    case ColumnType.SHORT:
                        if (column.m_cbColumn == 2)
                        {
                            return BitConverter.ToInt16(bytes, 0);
                        }
                        break;

                    case ColumnType.USHORT:
                        if (column.m_cbColumn == 2)
                        {
                            return BitConverter.ToUInt16(bytes, 0);
                        }
                        break;

                    case ColumnType.LONG:
                        if (column.m_cbColumn == 4)
                        {
                            return BitConverter.ToInt32(bytes, 0);
                        }
                        break;

                    case ColumnType.ULONG:
                        if (column.m_cbColumn == 4)
                        {
                            return BitConverter.ToUInt32(bytes, 0);
                        }
                        break;

                    case ColumnType.BYTE:
                        if (column.m_cbColumn == 1)
                        {
                            return bytes[0];
                        }
                        break;

                    default:
                        throw new ArgumentException($"Unrecognized column type '{type}'.");
                }

                throw new ArgumentException($"Unexpected data size for type {type}: {column.m_cbColumn} bytes");
            }
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
