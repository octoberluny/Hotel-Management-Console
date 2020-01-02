using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace DAL
{
    public static class Serialization
    {
        
        public static void Serialize(object x, string file)
        {
            Stream TestFileStream = File.OpenWrite(file);
            BinaryFormatter serializer = new BinaryFormatter(); // Construct a BinaryFormatter and use it to serialize the data to the stream.
            serializer.Serialize(TestFileStream, x);
            TestFileStream.Close();                            
        }
        public static object Deserialize(string fileName)
        { 
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream("price.txt", FileMode.Open);
            // Deserialize the obj from the file and 
            // assign the reference to the local variable.
            object obj =bf.Deserialize(fs);
            fs.Close();
            return obj;
        }
    }
}
