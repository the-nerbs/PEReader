using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MetaModelSchemaGenerator
{
    internal enum ColumnType
    {
        Fixed,
        Rid,
        String,
        Guid,
        Blob,
        CodedToken,
    }

    // see CoreCLR:
    // https://github.com/dotnet/coreclr/blob/32f0f9721afb584b4a14d69135bea7ddc129f755/src/inc/metamodelpub.h#L1613
    public enum ItemType
    {
        RidMax = 63,
        CodedToken = 64,
        CodedTokenMax = 95,
        SHORT = 96,
        USHORT = 97,
        LONG = 98,
        ULONG = 99,
        BYTE = 100,
        STRING = 101,
        GUID = 102,
        BLOB = 103
    }


    public abstract class ColumnBase
    {
        internal abstract ColumnType Type { get; }

        [XmlAttribute("name")]
        public string Name { get; set; }
    }

    [DebuggerDisplay("Item {Name} : {ItemType}")]
    public class ItemColumn : ColumnBase
    {
        internal override ColumnType Type
        {
            get { return ColumnType.Fixed; }
        }

        [XmlAttribute("type")]
        public ItemType ItemType { get; set; }
    }

    [DebuggerDisplay("RID {Name} references {Table}")]
    public class RidColumn : ColumnBase
    {
        internal override ColumnType Type
        {
            get { return ColumnType.Rid; }
        }

        [XmlAttribute("table")]
        public string Table { get; set; }
    }

    [DebuggerDisplay("String {Name}")]
    public class StringColumn : ColumnBase
    {
        internal override ColumnType Type
        {
            get { return ColumnType.String; }
        }
    }

    [DebuggerDisplay("GUID {Name}")]
    public class GuidColumn : ColumnBase
    {
        internal override ColumnType Type
        {
            get { return ColumnType.Guid; }
        }
    }

    [DebuggerDisplay("Blob {Name}")]
    public class BlobColumn : ColumnBase
    {
        internal override ColumnType Type
        {
            get { return ColumnType.Blob; }
        }
    }

    [DebuggerDisplay("CDTKN {Name} tokens={Token}")]
    public class CodedTokenColumn : ColumnBase
    {
        internal override ColumnType Type
        {
            get { return ColumnType.CodedToken; }
        }

        [XmlAttribute("tokens")]
        public CDTKN Token { get; set; }
    }
}
