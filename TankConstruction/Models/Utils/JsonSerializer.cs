using System.Collections.Generic;
using Newtonsoft.Json;

namespace TankConstruction.Models.Utils
{

    public class JsonObject : SerializerContainer
    {
        public override string Serialize()
        {
            return JsonConvert.SerializeObject(Container, Formatting.Indented);
        }

        public override void Deserialize(string data)
        {
            
            Container = JsonConvert.DeserializeObject<Dictionary<string, object>>(data);      
        }
    }
    
    public class JsonSerializer : Serializer<JsonObject>
    {
        public override JsonObject Create()
        {
            return new JsonObject();
        }
        
        
    }
}
