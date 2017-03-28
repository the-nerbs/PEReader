using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaModelSchemaGenerator
{
    public partial class MetaModelCodeGen
    {
        public bool IsPublic { get; set; }
        public ClrMetaModelSchema Schema { get; set; }


        private static string TypeString(ItemType type)
        {
            switch (type)
            {
                case ItemType.SHORT:
                    return "short";

                case ItemType.USHORT:
                    return "ushort";

                case ItemType.LONG:
                    return "int";

                case ItemType.ULONG:
                    return "uint";

                case ItemType.BYTE:
                    return "byte";

                case ItemType.RidMax:
                case ItemType.CodedToken:
                case ItemType.CodedTokenMax:
                case ItemType.STRING:
                case ItemType.GUID:
                case ItemType.BLOB:
                    throw new ArgumentException($"#error {type} is not a fixed type field.");

                default:
                    throw new ArgumentException($"#error Unrecognized type {type}");
            }
        }

        private static string FullRecordTypeString(ColumnBase column)
        {
            if (column is ItemColumn)
            {
                return TypeString(((ItemColumn)column).ItemType);
            }

            // The rest all include indexes typed as either USHORT or ULONG32 (per assembly) in CoreCLR.
            return "uint";
        }

        private string ColumnTypeAttrParams(int field, ColumnBase column)
        {
            if (column is CodedTokenColumn)
            {
                var col = (CodedTokenColumn)column;
                return $"{field}, ColumnType.CodedToken, SubType = {(int)col.Token}";
            }
            else if (column is RidColumn)
            {
                var col = (RidColumn)column;
                return $"{field}, ColumnType.Rid, SubType = {Schema.IndexOfTable(col.Table)}";
            }
            else if (column is ItemColumn)
            {
                var col = (ItemColumn)column;
                return $"{field}, ColumnType.{col.ItemType}";
            }
            else
            {
                return $"{field}, ColumnType.{column.Type}";
            }
        }


        private static int TypeSize(ItemType type)
        {
            if (type <= ItemType.CodedTokenMax)
            {
                type = 0;
            }

            switch (type)
            {
                case ItemType.SHORT:
                case ItemType.USHORT:
                    return 2;

                case ItemType.LONG:
                case ItemType.ULONG:
                    return 4;

                case ItemType.BYTE:
                    return 1;

                case 0:
                case ItemType.STRING:
                case ItemType.GUID:
                case ItemType.BLOB:
                    throw new ArgumentException($"#error {type} is not a fixed type field.");

                default:
                    throw new ArgumentException($"#error Unrecognized type {type}");
            }
        }
    }
}
