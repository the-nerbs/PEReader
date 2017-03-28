using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MetaModelSchemaGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var ser = new XmlSerializer(typeof(ClrMetaModelSchema));
            var schema = (ClrMetaModelSchema)ser.Deserialize(new FileStream("MMSchema.xml", FileMode.Open, FileAccess.Read, FileShare.None));

            var xform = new MetaModelCodeGen();
            xform.IsPublic = false;
            xform.Schema = schema;

            string code = xform.TransformText();

        }
    }
}
