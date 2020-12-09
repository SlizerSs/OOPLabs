using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab13._1
{
    class BPD_DirInfo
    {
        public static void AboutDir(string dir)
        {
            BPD_Log.WriteLog("AboutDir");
            DirectoryInfo dirInfo = new DirectoryInfo(dir);
            Console.WriteLine($"Файлы:");
            
            foreach (String di in Directory.GetFiles(dir))
            {
                Console.WriteLine(di);
            }
            Console.WriteLine($"Время создания: {dirInfo.CreationTime}");
            
            Console.WriteLine($"Поддиректории:");
            foreach (String di in Directory.GetDirectories(dir))
            {
                Console.WriteLine(di);
            }
            Console.WriteLine($"Родительский директорий: {dirInfo.Root}");
        }
    }
}
