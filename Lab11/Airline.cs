using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11
{
    class Passenger { 
        public string Name { get; set; }
        public string Place { get; set; }
        public Passenger(string name, string place)
        {
            this.Name = name;
            this.Place = place;

        }
    }

    public partial class Airline
    {

        private string destination;
        int numberOfFlight { get; set; }
        readonly string typeOfPlane;
        private string time;
        private string dayOfWeek;
        const string timeOfFlight = "03:00";
        private int numOfSits = 100;
        private int occupiedSits = 100;
        private int notOccupiedSits = 0;
        static int numOfAirplanes = 0;

        public Airline()
        {
            this.numberOfFlight = numOfAirplanes++;
        }
        public Airline(string dest, string typeOfPl, string time, string dayOfWeek, int occSits) 
        {
            this.destination = dest;
            this.numberOfFlight = numOfAirplanes++;
            this.typeOfPlane = typeOfPl;
            this.time = time;
            this.dayOfWeek = dayOfWeek;
            this.occupiedSits = occSits;
        }
        public Airline(string dest, string dayOfWeek, string time = "0:0", int occSits = 0, string typeOfPl = "Airliner") 
        {
            this.destination = dest;
            this.numberOfFlight = numOfAirplanes++;
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
        public void info()
        {
            Console.WriteLine($"Номер рейса - {NumberOfFlight}. Рейс в {Destination}. День недели - {DayOfWeek}. Время вылета - {Time}.");
        }

    }
}
