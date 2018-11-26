using System.Collections.Generic;

namespace TankConstruction.Models.Utils
{
    public abstract class Serializer<T> where T: SerializerContainer
    {
   
        public abstract T Create();

        public void Add(T container, string key, object value)
        {
            container.Add(key, value);
        }
        
    }

    public abstract class SerializerContainer
    {
        public Dictionary<string, object> Container = new Dictionary<string, object>();

        public void Add(string key, object value)
        {
            Container.Add(key, value);
        }

        public abstract string Serialize();
        public abstract void Deserialize(string data);
    }
}
