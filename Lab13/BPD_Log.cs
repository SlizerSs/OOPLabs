using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab13
{
    static class BPD_Log
    {
        public static void WriteLog(string name, string namef, string dir)
        {
            using (StreamWriter st = new StreamWriter(@"D:/BPDlogfile.txt", true))
            {
                st.WriteLine($"метод -  {name}, файл - {namef}, путь -  {dir}, вызван -  {DateTime.Now}");
            }
        }
        public static void WriteLog(string name, string dir)
        {
            using (StreamWriter st = new StreamWriter(@"D:/BPDlogfile.txt", true))
            {
                st.WriteLine($"метод -  {name}, путь -  {dir}, вызван -  {DateTime.Now}");
            }
        }
        public static void WriteLog(string name)
        {
            using (StreamWriter st = new StreamWriter(@"D:/BPDlogfile.txt", true))
            {
                st.WriteLine($"метод -  {name}  , вызван -  {DateTime.Now}");
            }
        }
    }

}
