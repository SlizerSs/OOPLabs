using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Lab8
{

    class Program
    {
        static void Main(string[] args)
        {

                Mass<int> A = new Mass<int>(1, 2, 3, 7, 3, 20, 72);
                Mass<char> B = new Mass<char>('a', 'b', 'c', 'd');
                ControlElement ce1 = new ControlElement(true);
                ControlElement ce2 = new ControlElement(false);
                Mass<ControlElement> D = new Mass<ControlElement>(ce1, ce2);
            try
            {
                A.Display();
                Console.WriteLine("Удаляем последний элемент");
                Mass<int> C = A - 1;
                C.Display();
                Console.WriteLine();

                B.Display();
                Console.WriteLine("Добавили элемент в конец");
                Mass<char> E = B + 'e';
                E.Display();
                Console.WriteLine();

                Mass<float> fl = new Mass<float>(4.56f, 1.3f, 12.34f, 1.7f, 3.21f);
                fl.Display();
                Mass<string> str = new Mass<string>("dgdfg", "ewt", "sdv", "sdvs", "ads", "vd");
                str.Display();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
            finally
            {
                Console.WriteLine($"Finally");
            }

            Mass<int>.Owner Owner1 = new Mass<int>.Owner(11, "Pavel", "BelSTU");
            Mass<int>.Date Date1 = new Mass<int>.Date(2020, "October", 6);

            Console.WriteLine("Запись в файл");
            string rwPath = @"D:\info.txt";
            // запись в файл
            StreamWriter sw = new StreamWriter(rwPath, false);
            foreach (int a in A.Arr)
            {
                sw.Write(a);
            }

            foreach (char a in B.Arr)
            {
                sw.Write(a);
            }

            sw.Write(ce1.isActive);
            sw.Close();

            Console.WriteLine("Чтение из файла");
            // чтение
            StreamReader sr = new StreamReader(rwPath);
            Console.WriteLine(sr.ReadToEnd());
            sr.Close();

            Mass1<ControlElement> mass1 = new Mass1<ControlElement>(ce1, ce2);
        }
    } 
}
