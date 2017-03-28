using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MetaModelSchemaGenerator
{
    public class CodedToken
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlElement("Table")]
        public string[] Tables { get; set; }
    }
}
