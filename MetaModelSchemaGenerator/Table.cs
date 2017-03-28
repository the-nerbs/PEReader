using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MetaModelSchemaGenerator
{
    [DebuggerDisplay("{Name} ({Columns.Length} Columns)")]
    public class Table
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("key")]
        public string Key { get; set; }


        [XmlElement("Item", typeof(ItemColumn))]
        [XmlElement("RidItem", typeof(RidColumn))]
        [XmlElement("StringItem", typeof(StringColumn))]
        [XmlElement("GuidItem", typeof(GuidColumn))]
        [XmlElement("BlobItem", typeof(BlobColumn))]
        [XmlElement("CodedTokenItem", typeof(CodedTokenColumn))]
        public ColumnBase[] Columns { get; set; }


        public bool HasKeyField
        {
            get { return !string.IsNullOrEmpty(Key); }
        }
    }
}
