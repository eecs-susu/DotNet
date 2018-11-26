using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Formatting = Newtonsoft.Json.Formatting;

namespace TankConstruction.Models.Utils
{
    public class XmlSerializer : Serializer<XmlContainer>
    {
        public override XmlContainer Create()
        {
            return new XmlContainer();
        }
    }

    public class XmlContainer : SerializerContainer
    {
        public override string Serialize()
        {
            var json =  JsonConvert.SerializeObject(Container, Formatting.Indented);
            var doc = (XmlDocument)JsonConvert.DeserializeXmlNode($@"{{""root"": {json}}}");
            return doc.InnerXml;
        }

        public override void Deserialize(string data)
        {
            var doc = new XmlDocument();
            doc.LoadXml(data);
            var json = JsonConvert.SerializeXmlNode(doc);
            var handled = (JObject) JObject.Parse(json)["root"];
            Container = handled.ToObject<Dictionary<string, object>>();

        }
    }
}
