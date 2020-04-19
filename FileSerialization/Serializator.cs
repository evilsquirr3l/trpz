using System;

namespace FileSerialization
{
    class Serializator
    {
        private readonly ISerialization _serialization;
        
        public Serializator(ISerialization serial)
        {
            _serialization = serial;
        }
        public void Serialize(Object obj, string path)
        {
            _serialization.Serialization(obj, path);
        }

        public Object Deserialize(string path)
        {
            return _serialization.Deserialization(path);
        }
    }
}