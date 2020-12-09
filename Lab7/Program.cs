using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Lab7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n Task1");
            Button but0 = new Button(true, 5, 45);
            Button but2 = null;

            UI UI1 = new UI(but0);

                try
                {
                    Button but1 = new Button(true, 1, -3);
                }
                catch (SizeOfElementException ex)
                {
                    Console.WriteLine("Ошибка: " + ex.Message);
                }

                try
                {
                    Button but1 = new Button(true, 1, 101);
                }
                catch (SizeOfElementException ex)
                {
                    Console.WriteLine("Ошибка: " + ex.Message);
                }

                try
                {
                    Button but3 = new Button(true, -1, 23);
                }
                catch (NegativeIDException ex)
                {
                    Console.WriteLine("Ошибка: " + ex.Message);
                }

                try
                {
                    Button but3 = new Button(true, 25, 23);
                }
                catch (NegativeIDException ex)
                {
                    Console.WriteLine("Ошибка: " + ex.Message);
                }

                try
                {
                    UI1.Add(but2);
                }
                catch (NullReferenceException ex)
                {
                    Console.WriteLine("Ошибка: " + ex.Message);
                }
            try
            {
                Button but10 = new Button(true, 5, -2);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Исключение: " + ex.Message);
                Console.WriteLine($"{ex.StackTrace}");
            }
            finally
            {
                int ID;
                ID = -10;
                Debug.Assert(ID > 0, "ID должно быть больше нуля");
                Console.WriteLine($"Выполнение программы завершено");
            }

        }
    }
}
