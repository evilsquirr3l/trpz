using System;
using System.IO;
using System.Runtime.Serialization;

namespace DAL.BinarySerializer
{
    class XMLSerializator : ISerialization
    {
        DataContractSerializer xmlSerializer;
        
        public XMLSerializator(Type type)
        {
            xmlSerializer = new DataContractSerializer(type);
        }
        public void Serialization(Object obj, string path)
        {
            using (FileStream stream = new FileStream(path, FileMode.OpenOrCreate))
            {
                xmlSerializer.WriteObject(stream, obj);
            }
        }

        public Object Deserialization(string path)
        {
            using (FileStream stream = new FileStream(path, FileMode.OpenOrCreate))
            {
                return xmlSerializer.ReadObject(stream);
            }
        }
    }
}