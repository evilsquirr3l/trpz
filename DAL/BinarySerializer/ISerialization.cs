using System;

namespace DAL.BinarySerializer
{
    interface ISerialization
    {
        void Serialization(Object obj, string path);
        Object Deserialization(string path);
    }
}