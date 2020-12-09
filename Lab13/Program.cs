using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab13._1
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("Задание 2");
            BPD_DiskInfo.GetDriveInfo();
            Console.WriteLine();

            Console.WriteLine("Задание 3");
            BPD_FileInfo.AboutFile("D:/12lab.txt");
            Console.WriteLine();

            Console.WriteLine("Задание 4");
            BPD_DirInfo.AboutDir("D:/универ");
            Console.WriteLine();

            Console.WriteLine("Задание 5");
            BPD_FileManager.FileManager();
            Console.WriteLine();

            Console.WriteLine("Задание 6");
            BPD_FileManager.LogInfo();
            Console.WriteLine();
        }
    }
}
