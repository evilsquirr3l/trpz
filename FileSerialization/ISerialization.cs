using System;

namespace FileSerialization
{
    public interface ISerialization
    {
        void Serialization(Object obj, string path);
        Object Deserialization(string path);
    }
}