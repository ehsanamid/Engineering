using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace DCS.Project_Objects
{

    public class NoNamespaceXmlWriter : XmlTextWriter
    {
        //Provide as many contructors as you need
        public NoNamespaceXmlWriter(System.IO.TextWriter output)
            : base(output) { Formatting = System.Xml.Formatting.Indented; }

        public override void WriteStartDocument() { }

        public override void WriteStartElement(string prefix, string localName, string ns)
        {
            base.WriteStartElement("", localName, "");
        }
    }

    public class SerializeDeserialize<T>
    {
        StringBuilder sbData;
        StringWriter swWriter;
        XmlDocument xDoc;
        XmlNodeReader xNodeReader;
        XmlSerializer xmlSerializer;
        public SerializeDeserialize()
        {
            sbData = new StringBuilder();
        }
        public string SerializeData(T data)
        {
            XmlSerializer generalSerializer = new XmlSerializer(typeof(T));
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            
            swWriter = new StringWriter(sbData);
            generalSerializer.Serialize(swWriter, data,ns);
            return sbData.ToString();
        }

        public T DeserializeData(string dataXML)
        {
            xDoc = new XmlDocument();
            xDoc.LoadXml(dataXML);
            xNodeReader = new XmlNodeReader(xDoc.DocumentElement);
            xmlSerializer = new XmlSerializer(typeof(T));
            var generalData = xmlSerializer.Deserialize(xNodeReader);
            T deserializedObject = (T)generalData;
            return deserializedObject;
        }
    }
}
