using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Task1");
            string[] Months = { "June", "July", "August", "December", "January","February","March","April","May","September","October","November" };
            Console.WriteLine("\nВыборка месяцев по длине названия n = ");
            int n;
            n = Convert.ToInt32(Console.ReadLine());
            var nLengthMonths = from i in Months
                                where i.Length == n
                                select i;
            Console.WriteLine($"\nМесяца с длиной названия {n} символов");
            foreach (string s in nLengthMonths) 
                Console.WriteLine(s);

            Console.WriteLine("\nЛетние и зимние месяцы:");
            var SummerAndWinter = Months.Take(6);
            foreach (string s in SummerAndWinter)
                Console.WriteLine(s);

            Console.WriteLine("\nВ алфавитном порядке:");
            var AlphabetOrder = from i in Months
                                orderby i
                                select i;
            foreach (string s in AlphabetOrder)
                Console.WriteLine(s);

            Console.WriteLine("\nСодержит 'u' и длина >= 4:");
            var hasU = from i in Months
                       where i.ToLower().Contains("u")
                       where i.Length >= 4
                       select i;
            foreach (string s in hasU)
                Console.WriteLine(s);

            Console.WriteLine("\nTask2,3");
            List<Airline> airlines = new List<Airline> {
                new Airline("Minsk", "monday", "12:00"),
                new Airline("Vitebsk", "tuesday", "09:00"),
                new Airline("Brest", "wednsday", "17:00"),
                new Airline("Minsk", "thursday", "03:00"),
                new Airline("Gomel", "friday", "06:00"),
                new Airline("Grodno", "friday", "11:00"),
                new Airline("Mogilev", "monday", "10:00"),
                new Airline("Minsk", "sunday", "12:00")
            };

            Console.WriteLine("\nПункт назначения:");
            string destination = Console.ReadLine();
            var destinationAirlines = from a in airlines
                                   where a.Destination == destination
                                   select a;
            foreach (Airline ai in destinationAirlines)
                ai.info();

            Console.WriteLine("\nДень недели:");
            string dayOfWeek = Console.ReadLine();
            var dayOfWeekAirlines = from a in airlines
                                    where a.DayOfWeek == dayOfWeek
                                    select a;
            foreach (Airline ai in dayOfWeekAirlines)
                ai.info();

            Console.WriteLine("\nВ понедельник раньше всех вылетает:");
            var mondayEarly = from a in airlines
                              where a.DayOfWeek == "monday"
                              orderby a.Time
                              select a;
            mondayEarly.First().info();

            Console.WriteLine("\nВ среду или пятницу позже всех вылетает:");
            var Last = from a in airlines
                       where a.DayOfWeek == "wednsday" || a.DayOfWeek == "friday"
                       orderby a.Time
                       select a;
            Last.Last().info();

            Console.WriteLine("\nВсе рейсы упорядоченные по времени вылета:");
            var orderedByTime = from a in airlines
                                orderby a.Time
                                select a;
            foreach (Airline ai in orderedByTime)
                ai.info();

            Console.WriteLine("\nTask4");
            Console.WriteLine("Своя выборка:");
            var Own = (from a in airlines where a.DayOfWeek == "monday" || a.DayOfWeek == "friday" orderby a.Time select a).Skip(2);
            foreach (Airline ai in Own)
                ai.info();

            Console.WriteLine("\nTask5");
            List<Passenger> passangers = new List<Passenger> {
                new Passenger("Vlad", "Minsk"),
                new Passenger("Mark", "Brest")
            };

            var result = from ai in airlines
                         join p in passangers on ai.Destination equals p.Place
                         select new { Name = p.Name, Place = p.Place, Time = ai.Time, DayOfWeek = ai.DayOfWeek };

            foreach (var item in result)
                Console.WriteLine($"{item.Name} - {item.Place} {item.DayOfWeek} {item.Time}");
        }
    }
}
