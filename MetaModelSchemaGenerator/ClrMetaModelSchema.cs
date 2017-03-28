using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MetaModelSchemaGenerator
{
    [XmlRoot("ClrMetaModelSchema")]
    public class ClrMetaModelSchema
    {
        [XmlIgnore]
        private readonly Lazy<Dictionary<string, int>> _tableIndexes;


        [XmlAttribute("major-version")]
        public int MajorVersion { get; set; }

        [XmlAttribute("Minor-version")]
        public int MinorVersion { get; set; }


        [XmlElement("CodedToken")]
        public CodedToken[] CodedTokens { get; set; }

        [XmlElement("Table")]
        public Table[] Tables { get; set; }


        public ClrMetaModelSchema()
        {
            _tableIndexes = new Lazy<Dictionary<string, int>>(IndexTables);
        }


        public int IndexOfTable(string name)
        {
            return _tableIndexes.Value[name];
        }


        private Dictionary<string, int> IndexTables()
        {
            var dict = new Dictionary<string, int>();

            foreach (var tbl in Tables)
            {
                dict[tbl.Name] = dict.Count;
            }

            return dict;
        }
    }
}
