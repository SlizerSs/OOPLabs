using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//3 4 32 вопросы
namespace Lab3
{
    class Program{
        static void Main(string[] args)
        {
            
            Airline Airplane1 = new Airline("Minsk", 1, "Airliner", "10:10", "monday", 92);
            Airline Airplane2 = new Airline("Minsk", "monday");
            Airline Airplane3 = new Airline();
            Console.WriteLine("Airplane1.ToString() = " + Airplane1.ToString());
            Console.WriteLine("Airplane2.Equals(Airplane1) = " + Airplane2.Equals(Airplane1));
            Console.WriteLine("Airplane3.GetHashCode() = " + Airplane3.GetHashCode());

            Console.WriteLine("Airplane1.Destination = " + Airplane1.Destination);
            Airplane1.NotOccupied(ref Airplane1.numOfSits, ref Airplane1.occupiedSits, out Airplane1.notOccupiedSits);
            Console.WriteLine("Airplane1.notOccupiedSits = " + Airplane1.notOccupiedSits);
            Console.WriteLine(Airplane1.GetType());
            Console.WriteLine();
            
            var AnonAirplane = new { Destination = "Minsk", DayOfWeek = "monday", NumberOfFlight = 10, TypeOfPlane = "Airliner", Time = "10:00"};

            Console.WriteLine("Сколько будет рейсов?");
            int count = Convert.ToInt32(Console.ReadLine());
            Airline[] Airplane = new Airline[count];

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"Создаём {i + 1} рейс:");
                Airplane[i] = new Airline();
                Airplane[i].NumberOfFlight = i+1;
                Console.WriteLine("Введите пункт назначения:");
                Airplane[i].Destination = Console.ReadLine();
                Console.WriteLine("Введите день недели отправки:");
                Airplane[i].DayOfWeek = Console.ReadLine();
                Console.WriteLine("Введите время отправки:");
                Airplane[i].Time = Console.ReadLine();
                Console.WriteLine("Введите количество занятых мест(0-100):");
                Airplane[i].OccupiedSits = Convert.ToInt32(Console.ReadLine());

            }
            Console.WriteLine("Поиск по пункту назначения: ");
            string destinationSearch = Console.ReadLine();
            foreach (Airline AirplaneSearch in Airplane)
            {
                if(AirplaneSearch.Destination == destinationSearch)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Пункт назначения рейса - {AirplaneSearch.Destination}");
                    Console.WriteLine($"День недели отправки - {AirplaneSearch.DayOfWeek}");
                    Console.WriteLine($"Время отправки - {AirplaneSearch.Time}");
                    Console.WriteLine($"Количество занятых мест - {AirplaneSearch.OccupiedSits}");
                    Console.WriteLine($"Номер рейса - {AirplaneSearch.NumberOfFlight}");
                    Console.WriteLine();
                }
            }

            Console.WriteLine("Поиск по дню недели: ");
            string dayOfWeekSearch = Console.ReadLine();
            foreach (Airline AirplaneSearch in Airplane)
            {
                if (AirplaneSearch.DayOfWeek == dayOfWeekSearch)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Пункт назначения рейса - {AirplaneSearch.Destination}");
                    Console.WriteLine($"День недели отправки - {AirplaneSearch.DayOfWeek}");
                    Console.WriteLine($"Время отправки - {AirplaneSearch.Time}");
                    Console.WriteLine($"Количество занятых мест - {AirplaneSearch.OccupiedSits}");
                    Console.WriteLine($"Номер рейса - {AirplaneSearch.NumberOfFlight}");
                    Console.WriteLine();
                }
            }


        }
    }

    public partial class Airline
    {

        string destination;//доступ по умолчанию private
        int numberOfFlight { get; set; }
        readonly string typeOfPlane;
        string time;
        string dayOfWeek;
        const string timeOfFlight = "03:00";//в скольких экземплярах константа (одно для всех экземпляров)
        public int numOfSits = 100;
        public int occupiedSits = 100;
        public int notOccupiedSits = 0;
        static int numOfAirplanes = 0;

        public Airline()
        {
            numOfAirplanes++;
        }
        static Airline()//статический конструктор --- вызывается перед вызовом первого конструктора
        {
            Console.WriteLine("Вызван статический конструктор");
        }
        public Airline(string dest, int numOfFl, string typeOfPl, string time, string dayOfWeek, int occSits) 
        {
            numOfAirplanes++;
            this.destination = dest;
            this.numberOfFlight = numOfFl;
            this.typeOfPlane = typeOfPl;
            this.time = time;
            this.dayOfWeek = dayOfWeek;
            this.occupiedSits = occSits;
        }
        //нет типа
        public Airline(string dest, string dayOfWeek, int numOfFl = 1, string typeOfPl = "Airliner", string time = "0:0", int occSits = 0) 
        {
            numOfAirplanes++;
            this.destination = dest;
            this.numberOfFlight = numOfFl;
            this.typeOfPlane = typeOfPl;
            this.time = time;   
            this.dayOfWeek = dayOfWeek;
            this.occupiedSits = occSits;
        }

        public string Destination
        {
            get
            {
                return destination;
            }
            set
            {
                destination = value;
            }
        }
        public string Time
        {
            get
            {
                return time;
            }
            set
            {
                time = value;
            }
        }
        public string DayOfWeek
        {
            get
            {
                return dayOfWeek;
            }
            set
            {
                dayOfWeek = value;
            }
        }
        public int OccupiedSits
        {
            get
            {
                return occupiedSits;
            }
            set
            {
                occupiedSits = value;
            }
        }
        public int NotOccupiedSits
        {
            get
            {
                return notOccupiedSits;
            }
            set
            {
                notOccupiedSits = value;
            }
        }
        public int NumOfSits
        {
            get
            {
                return numOfSits;
            }
            set
            {
                numOfSits = value;
            }
        }
        public int NumberOfFlight
        {
            get
            {
                return numberOfFlight;
            }
            set
            {
                numberOfFlight = value;
            }
        }
        public void NotOccupied(ref int numOfSits, ref int occupiedSits, out int notOccupiedSits)
        {
            notOccupiedSits = numOfSits - occupiedSits;
        }
        static void info()
        {
            Console.WriteLine("This class saves some info about airplanes");
        }

    }
}
