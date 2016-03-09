using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Collections;  //array
using System.IO;  //input and output
using System.Runtime.Serialization.Formatters.Binary;  //binary files

namespace HandIn3CS
{
    public class FileUtility
    {
        public static void WriteFile(ArrayList a, string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None); //connection to file
            BinaryFormatter bf = new BinaryFormatter();  // prepare to binary file
            bf.Serialize(fs, a);  // put data in 1 0 series
            fs.Close();
        }

        public static ArrayList ReadFile(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.None); //connection to file
            BinaryFormatter bf = new BinaryFormatter();  // prepare to binary file
            ArrayList a = (ArrayList)bf.Deserialize(fs);  //convert from binary to arraylist
            fs.Close();
            return a;
        }
    }
}