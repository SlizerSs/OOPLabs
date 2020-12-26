using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab16
{
    class Program
    {
        private const int SIZE = 10_000_000;
        private static CancellationTokenSource source = new CancellationTokenSource();

        private static CancellationToken token = source.Token;  
                                                                
        static void Main(string[] args)
        {
            Console.WriteLine("Task1");
            Task1();
            Console.WriteLine("-------------------");
            Console.ReadKey();

            Console.WriteLine("Task2");
            Task2();
            Console.WriteLine("-------------------");
            Console.ReadKey();

            Console.WriteLine("Task3");
            Task3();
            Console.WriteLine("-------------------");
            Console.ReadKey();

            Console.WriteLine("\nTask4");
            Task4();
            Console.WriteLine("-------------------");
            Console.ReadKey();

            Console.WriteLine("\nTask5");
            Task5();
            Console.WriteLine("-------------------");
            Console.ReadKey();

            Console.WriteLine("\nTask8");
            Task8();
            Console.WriteLine("-------------------");
            Console.ReadKey();

            Console.WriteLine("\nTask6");
            Task6();
            Console.WriteLine("-------------------");
            Console.ReadKey();

            Console.WriteLine("\nTask7");
            Task7();
            Console.WriteLine("-------------------");
            Console.ReadKey();

        }
        public static void Task1()
        {
            int itaration = 3;

            Stopwatch stopwatch = new Stopwatch();
            while (itaration > 0)
            {
                stopwatch.Start();
                Task task = new Task(SimpleNumbers);
                task.Start();
                Console.WriteLine($"Task {itaration} id: {task.Id}");  
                Console.WriteLine($"Task {itaration} status: {task.Status}");

                if (Console.ReadKey().KeyChar == 'q')
                {
                    source.Cancel();
                }

                task.Wait();
                stopwatch.Stop(); 
                Console.WriteLine($"Time for task {itaration}: {stopwatch.Elapsed.TotalMilliseconds}\n");
                stopwatch.Reset();
                itaration--;
                Console.WriteLine();
            }

        }
        public static void Task2()
        {

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            Task task = new Task(SimpleNumbers);
            task.Start();
            Console.WriteLine($"Task id: {task.Id}");
            Console.WriteLine($"Task status: {task.Status}");

            Console.WriteLine("Press q to exit from task"); 

            if (Console.ReadKey().KeyChar == 'q')
            {
                source.Cancel();
            }
            

            task.Wait();
            stopwatch.Stop(); 
            Console.WriteLine($"Time for task: {stopwatch.Elapsed.TotalMilliseconds}\n");
            stopwatch.Reset();
            Console.WriteLine();
            

        }
        public static void Task3()
        {
            Task<int> task1 = new Task<int>(() => Factorial(5));
            Task<int> task2 = new Task<int>(() => Factorial(4));
            Task<int> task3 = new Task<int>(() => Factorial(3));
            task1.Start();
            task2.Start();
            task3.Start();
            task1.Wait();
            task2.Wait();
            task3.Wait();

            Task task = new Task(() =>
            {
                Console.WriteLine(task1.Result* task2.Result* task3.Result);
            });
            task.Start();
            task.Wait();
        }
        public static void Task4()
        {
            Task<int> task1 = new Task<int>(() => Sum(4, 5));
            Task<int> task2 = new Task<int>(() => Sum(2, 6));
            Task<int> task3 = new Task<int>(() => Sum(5, 8));
            // задача продолжения
            Task task01 = task1.ContinueWith(t => Display(t.Result));
            Task task02 = task2.ContinueWith(t => Display(t.Result));
            Task task03 = task3.ContinueWith(t => Display(t.Result));
            task1.Start();
            task2.Start();
            task3.Start();
            task01.Wait();
            task02.Wait();
            task03.Wait();
            Console.WriteLine("С применением методов GetAwaiter и GetResult");
            
            task3.ContinueWith(t => Display(t.Result)).GetAwaiter();
            task2.ContinueWith(t => Display(t.Result)).GetAwaiter().GetResult();

        }
        public static void Task5()
        {

            Random rnd1 = new Random();

            int[] mass1 = new int[SIZE];
            int[] mass2 = new int[SIZE];

            Console.WriteLine("\n\tЗаполняем массивы с помощью Parallel\n");

            Stopwatch stopWatch = Stopwatch.StartNew();
            Parallel.For(0, 9, (Count) =>
            {
                Parallel.ForEach(mass1, (el) =>
                {
                    el = 10 * 10;
                });
            });
            stopWatch.Stop();
            double sec1 = stopWatch.Elapsed.Milliseconds;
            Console.WriteLine($"Parallel - {sec1} msec");
            Console.WriteLine("\n\tЗаполняем массивы с помощью обычных циклов\n");

            stopWatch.Restart();
            for (int j = 0; j < 10; j++) {
                for (int i = 0; i < SIZE; i++)
                {
                    mass2[i] = 10 * 10;
                }
            }
            stopWatch.Stop();
            double sec2 = stopWatch.Elapsed.Milliseconds;
            Console.WriteLine($"For - {sec2} msec");


        }
        public static void Task6()
        {
            Parallel.Invoke(Factorial2, Factorial2, Factorial2);
        }

        public static void Task7()
        {
            Random rnd1 = new Random();
            BlockingCollection<int> sklad = new BlockingCollection<int>();
            int x = 0, t = 0;
            for (int producer = 0; producer < 5; producer++)
            {

                Task.Factory.StartNew(() => {
                    Task.Delay(1000);
                    x++;
                    for (int ii = 0; ii < 3; ii++)
                    {
                        x++;
                        Thread.Sleep(1000); 
                        int id = x;
                        sklad.Add(id);
                        Console.WriteLine($"\nПоставлен товар с номером: {id}");
                    }
                });
            }
            for (int con = 0; con < 10; con++)
            {
                Task consumer = Task.Factory.StartNew(() =>
                {
                    Task.Delay(1000);
                    int w;

                    while (!sklad.IsCompleted)
                    {
                        Thread.Sleep(1000);
                        if (sklad.TryTake(out w))
                            Console.WriteLine($"\nКуплен товар с номером: {w}");
                    }
                });
            }
            Console.ReadKey();
            Console.ReadKey();
        }
        public static async void Task8()
        {
            await Task.Run(() => Factorial2());
            Console.WriteLine("Task8 закончило работу");
        }
        public static void SimpleNumbers()
        {
            var numbers = new List<uint>();
            //заполнение списка числами
            for (var i = 2u; i < 10000; i++)
            {
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("Операция прервана");
                    return;
                }
                numbers.Add(i);
            }

            for (var i = 0; i < numbers.Count; i++)
            {
                for (var j = 2u; j < 10000; j++)
                {
                    if (token.IsCancellationRequested)
                    {
                        Console.WriteLine("Операция прервана");
                        return;
                    }
                    //удаляем кратные числа из списка
                    numbers.Remove(numbers[i] * j);

                }
            }
        }

        static int Factorial(int x)
        {
            int result = 1;

            for (int i = 1; i <= x; i++)
            {
                result *= i;
            }

            return result;
        }
        static void Factorial2()
        {
            int result = 1;

            for (int i = 1; i <= 100_000; i++)
            {
                result *= i;
            }
            Thread.Sleep(4000);
            Console.WriteLine("Факториал посчитан");
        }

        static int Sum(int a, int b) => a + b;
        static void Display(int sum)
        {
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
