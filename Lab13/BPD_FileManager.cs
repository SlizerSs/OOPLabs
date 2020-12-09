using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab13._1
{
    static class BPD_FileManager
    {
        public static void FileManager()
        {
            BPD_Log.WriteLog("FileManager");
            //Удаляем старые каталоги 
            Directory.Delete(@"D:/BPD_Inspect", true);

            DriveInfo[] drives = DriveInfo.GetDrives();
            DirectoryInfo dir = new DirectoryInfo(drives[1].Name);
            //Вывод информации по директорию
            Console.WriteLine("Список каталогов: ");
            foreach (DirectoryInfo di in dir.GetDirectories())
            {
                Console.WriteLine(di);
            }
            Console.WriteLine("Список файлов: ");
            foreach (FileInfo di in dir.GetFiles())
            {
                Console.WriteLine(di);
            }
            //Создание директория
            string dirPath = @"D:/BPD_Inspect";
            DirectoryInfo pathDir = new DirectoryInfo(dirPath);
            pathDir.Create();
            //Создание файла
            string path = @"D:/BPD_Inspect/BPD_Dirinfo.txt";
            FileInfo fileInf = new FileInfo(path);
            //Запись информации в файл
            using (StreamWriter st = new StreamWriter(path, true))
            {
                foreach (DirectoryInfo di in dir.GetDirectories())
                {
                    st.WriteLine(di);
                }
                foreach (FileInfo di in dir.GetFiles())
                {
                    Console.WriteLine(di);
                }
            }
            //копирование и удаление файла
            string newPath = @"D:/BPD_Inspect/BPD_Dirinfo_Copy.txt";
            fileInf.CopyTo(newPath, true);
            fileInf.Delete();

            
            DirectoryInfo sourceDir = new DirectoryInfo(@"D:/");
            sourceDir.Create();
            DirectoryInfo newPathDir = new DirectoryInfo(@"D:/BPD_Files");
            newPathDir.Create();
            //получение txt файлов из директория
            foreach (FileInfo f in sourceDir.GetFiles())
            {
                if (f.Extension == ".txt")
                    f.CopyTo(@"D:/BPD_Files/"+f.Name+".txt",true);
            }
            //Перемещение директория
            newPathDir.MoveTo(@"D:/BPD_Inspect/BPD_Files");

            //делаем архив 
            ZipFile.CreateFromDirectory(@"D:/BPD_Inspect/BPD_Files", @"D:\BPD_Inspect\files.zip");
            ZipFile.ExtractToDirectory(@"D:\BPD_Inspect\files.zip", @"D:/BPD_Inspect");

           
        }
        public static void LogInfo()
        {
            BPD_Log.WriteLog("LogInfo");
            string[] s = File.ReadAllLines(@"D:\BPDlogfile.txt");
            for (int i = 0; i < s.Length; i++)
            {
                Console.WriteLine(s[i]);
            }
            Console.WriteLine(s.Length + " Записей");//колво записей влогфайле
            Console.WriteLine("По дате");
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i].Contains(DateTime.Now.Day.ToString()))
                    Console.WriteLine(s[i]);
            }
            Console.WriteLine("По времени");
            string pr = Console.ReadLine();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i].Contains(pr))
                    Console.WriteLine(s[i]);
            }
            Console.WriteLine("По ключевому слову");
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i].Contains("LogInfo"))
                    Console.WriteLine(s[i]);
            }
            FileInfo fi = new FileInfo(@"D:\BPDlogfile.txt");
            fi.Delete();
        }
    }
}
