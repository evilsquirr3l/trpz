using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace DAL.BinarySerializer
{
    class BinarySerializator : ISerialization
    {
        private readonly BinaryFormatter _formatter = new BinaryFormatter();
        
        public void Serialization(object obj, string path)
        {
            using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate))
            {
                _formatter.Serialize(fileStream, obj);
            }
        }

        public object Deserialization(string path)
        {
            using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate))
            {
                return _formatter.Deserialize(fileStream);
            }
        }
    }
}