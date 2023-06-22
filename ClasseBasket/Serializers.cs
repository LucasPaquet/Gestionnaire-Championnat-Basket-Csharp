using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Linq;
using System;

namespace ClasseBasket
{
    public class Serializers
    {
        public static void Serialize(AWBB data, String filename)
        {
            System.IO.Stream ms = File.OpenWrite(filename);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(ms, data);
            ms.Flush();
            ms.Close();
            ms.Dispose();
        }

        public static void Serialize(Joueur data, String filename)
        {
            System.IO.Stream ms = File.OpenWrite(filename);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(ms, data);
            ms.Flush();
            ms.Close();
            ms.Dispose();
        }

        public static AWBB Deserialize(String filename)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fs = File.Open(filename, FileMode.Open);
            object obj = formatter.Deserialize(fs);
            AWBB data = (AWBB)obj;
            fs.Flush();
            fs.Close();
            fs.Dispose();

            return data;
        }
    }
}