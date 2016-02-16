using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BelarusianDoor
{
    public static class WriteLogErrorFile
    {
        public static void WriteInLog(string fileName, string NameLog)
        {
            using (StreamWriter sw = new StreamWriter(fileName, true, System.Text.Encoding.GetEncoding(1251)))
            {
                sw.WriteLine("---------------ERROR-------------");
                sw.WriteLine(DateTime.Now.ToShortDateString());
                sw.WriteLine("---------------BODY--------------");
                sw.WriteLine(NameLog);
                sw.WriteLine("------------END    ERROR---------");
                sw.WriteLine();
                sw.WriteLine();
            }
        }
    }
}