using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;
using System.Security.Permissions;
using System.Threading;
using System.IO;

namespace _15_lab_oop
{
    class Program
    {
        static Mutex mutexObj = new Mutex();
        static void Main(string[] args)
        {
            Console.WriteLine("Task1");
            foreach (Process process in Process.GetProcesses())
            {
                
                Console.WriteLine($"ID: {process.Id}  Name: {process.ProcessName}");
            }
            Console.ReadKey();
            Process proc = Process.GetProcessesByName("chrome")[0];
            ProcessThreadCollection processThreads = proc.Threads;

            foreach (ProcessThread thread in processThreads)
            {
                Console.WriteLine($"ThreadId: {thread.Id} StartTime: {thread.StartTime}");
            }

            Console.ReadKey();

            Console.WriteLine("\nTask2");
            Console.WriteLine("Информация о домене:");
            AppDomain domain = AppDomain.CurrentDomain;
            InfoAboutDomain(domain);
            Console.WriteLine();
            Assembly[] assemblies = domain.GetAssemblies();
            Console.WriteLine("Сборки:");
            foreach (Assembly asm in assemblies)
                Console.WriteLine(asm.GetName().Name);

            // новый домен приложения
            AppDomain domain2 = AppDomain.CreateDomain("domain2");
            string longName = "system, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089";
            Assembly assem = Assembly.Load(longName);

            Console.WriteLine("\nИнформация о новом домене: ");
            InfoAboutDomain(domain2);
            // Уничтожение домена приложения
            AppDomain.Unload(domain2);

            Console.ReadKey();
            Console.WriteLine("\nTask3");
            Console.Write("n=");
            int n = Convert.ToInt32(Console.ReadLine());

            Thread second = new Thread(new ParameterizedThreadStart(Thread));
            second.Start(n);
            second.Suspend();
            Console.WriteLine("Приостановили поток");
            Console.ReadKey();
            second.Resume();

            Console.ReadKey();
            Console.WriteLine("\nTask4");
            Console.WriteLine("Синхронизация двух потоков:");
            
            Thread thread1 = new Thread(new ParameterizedThreadStart(Thread1));
            thread1.Start(0);
            Thread thread2 = new Thread(new ParameterizedThreadStart(Thread1));
            thread2.Start(1);
            thread1.Priority = ThreadPriority.AboveNormal;

            Console.ReadKey();
            Console.WriteLine();

            Thread thread3 = new Thread(new ParameterizedThreadStart(Thread2));
            thread3.Start(0);
            Thread thread4 = new Thread(new ParameterizedThreadStart(Thread2));
            thread4.Start(1);

            Console.ReadKey();
            Console.WriteLine("\nTask5");
            
            TimerCallback tm = new TimerCallback(Thread3);
            Timer timer = new Timer(tm, null, 0, 1000);
            Console.ReadKey();
        }

        public static void Thread(object n)
        {
            int m = Convert.ToInt32(n);
            for (int i = 1; i <= m; i++)
            {
                Console.WriteLine(i);
                System.Threading.Thread.Sleep(400);
            }
            Thread t = System.Threading.Thread.CurrentThread;
            t.Name = "поток 0";
            Console.WriteLine($"Имя потока: {t.Name}");
            Console.WriteLine($"Запущен ли поток: {t.IsAlive}");
            Console.WriteLine($"Приоритет потока: {t.Priority}");
            Console.WriteLine($"Статус потока: {t.ThreadState}");

        }
        public static void Thread1(object n)
        {
            int nn = (int)n;

            mutexObj.WaitOne();
            for (int i = nn; i <= 10; i+=2)
            {
                Console.WriteLine(i);
                System.Threading.Thread.Sleep(400);
            }
            mutexObj.ReleaseMutex();
        }
        public static void Thread2(object n)
        {
            int nn = (int)n;
            for (int i = nn; i <= 10; i += 2)
            {
                mutexObj.WaitOne();
                Console.WriteLine(i);
                System.Threading.Thread.Sleep(500);
                mutexObj.ReleaseMutex();
            }

        }

        public static void Thread3(object obj)
        {
            string[] strmas = new string[3];
            strmas[0] = "таймер)";
            strmas[1] = "ждём....";
            strmas[2] = "~~ ждём ~~";

            Random rnd = new Random();
            Console.WriteLine(strmas[rnd.Next(0, 3)]);

        }

        static void InfoAboutDomain(AppDomain domain)
        {
            Console.WriteLine($"Name: {domain.FriendlyName}");
            Console.WriteLine($"Base Directory: {domain.BaseDirectory}");
            Console.WriteLine($"SetupInformation: {domain.SetupInformation}");
            Console.WriteLine($"IsDefault: {domain.IsDefaultAppDomain()}");
            Console.WriteLine($"ID: {domain.Id}");

        }
    }
}