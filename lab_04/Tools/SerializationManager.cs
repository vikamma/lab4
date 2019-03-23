﻿using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace lab_04.Tools
{
    static class SerializationManager
    {
        internal static void Serialize<TObject>(TObject obj, string filePath)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                formatter.Serialize(fs, obj);
            }
        }

        internal static TObject Deserialize<TObject>(string filePath)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                return (TObject)formatter.Deserialize(fs);
            }
        }
    }
}
