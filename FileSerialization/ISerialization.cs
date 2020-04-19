using System;

namespace FileSerialization
{
    interface ISerialization
    {
        void Serialization(Object obj, string path);
        Object Deserialization(string path);
    }
}