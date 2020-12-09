using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;


namespace Lab12
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nTask1");
            Passenger pass1 = new Passenger("Mark", "Moscow") { };
            Type type1 = pass1.GetType();
            Console.WriteLine($"\nТип: {type1}");

            Console.WriteLine($"\n{type1} Сборка :");
            Reflector.AssemblyName(pass1);

            Console.WriteLine($"\n{type1} Конструкторы:");
            Reflector.PublicConstructors(pass1);

            Console.WriteLine($"\n{type1} Методы:");
            Reflector.Methods(pass1);

            Console.WriteLine($"\n{type1} Свойства:");
            Reflector.Properties(pass1);

            Console.WriteLine($"\n{type1} Поля:");
            Reflector.Fields(pass1);
            
            Console.WriteLine($"\n{type1} Интерфейсы:");
            Reflector.Interfaces(pass1);

            string p = "String";
            Console.WriteLine($"\n{type1} Методы с параметром {p}:");
            Reflector.MethodsByParametr(pass1, p);

            Console.WriteLine($"\nВызывыем метод:");
            Reflector.Invoke(pass1,"Remake", Reflector.ParamsGenerater("Lab12.Passenger", "Remake"));
            
            Console.WriteLine($"\nВызывыем метод:");
            Reflector.Invoke(pass1,"Remake", Reflector.FileRead("Lab12.Passenger", "Remake"));

            Book<int,string> book1 = new Book<int, string>(2, "book1");
            Type type2 = book1.GetType();
            Console.WriteLine($"\nТип: {type2}");

            Console.WriteLine($"\n{type2} Сборка :");
            Reflector.AssemblyName(book1);

            Console.WriteLine($"\n{type2} Конструкторы:");
            Reflector.PublicConstructors(book1);

            Console.WriteLine($"\n{type2} Методы:");
            Reflector.Methods(book1);

            Console.WriteLine($"\n{type2} Свойства:");
            Reflector.Properties(book1);

            Console.WriteLine($"\n{type2} Поля:");
            Reflector.Fields(book1);

            Console.WriteLine($"\n{type2} Интерфейсы:");
            Reflector.Interfaces(book1);

            string p2 = "Int32";
            Console.WriteLine($"\n{type2} Методы с параметром {p2}:");
            Reflector.MethodsByParametr(book1, p2);

            Console.WriteLine($"\nВызывыем метод:");
            Reflector.Invoke(book1, "BookRename", Reflector.ParamsGenerater("Lab12.Book`2[System.Int32,System.String]", "BookRename"));

            Console.WriteLine($"\nВызывыем метод:");
            Reflector.Invoke(book1, "BookRename", Reflector.FileRead("Lab12.Book`2[System.Int32,System.String]", "BookRename"));

            Assembly.LoadFrom(@"C:\z\Visual Studio Projects\OOP\LibraryAirline\LibraryAirline\obj\Debug\LibraryAirline.dll");

            Console.WriteLine("\nTask2");
            Console.WriteLine($"Создаём объект:");
            Type type3 = pass1.GetType();
            Reflector.Create(type3);
            

        }
    }
}
