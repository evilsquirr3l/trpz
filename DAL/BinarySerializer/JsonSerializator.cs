using System;
using System.IO;
using System.Runtime.Serialization.Json;

namespace DAL.BinarySerializer
{
    class JsonSerializator : ISerialization
    {
        DataContractJsonSerializer jsonSerializer;
        public JsonSerializator(Type type)
        {
            jsonSerializer = new DataContractJsonSerializer(type);
        }
        public void Serialization(Object obj, string path)
        {
            using (FileStream stream = new FileStream(path, FileMode.OpenOrCreate))
            {
                jsonSerializer.WriteObject(stream, obj);
            }
        }
        public Object Deserialization(string path)
        {
            using (FileStream stream = new FileStream(path, FileMode.OpenOrCreate))
            {
                return jsonSerializer.ReadObject(stream);
            }
        }

    }
}