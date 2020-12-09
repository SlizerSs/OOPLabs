using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab13._1
{
    static class BPD_FileInfo
    {
        public static void AboutFile(string file)
        {
            BPD_Log.WriteLog("AboutFile");
            FileInfo fi = new FileInfo(file);
            Console.WriteLine($"Путь - {fi.DirectoryName}, рзмер - {fi.Length}, имя - {fi.Name}, расширение - {fi.Extension}, дата создания - {fi.CreationTime}, дата изменения - {fi.LastWriteTime}");
        }
    }
}
