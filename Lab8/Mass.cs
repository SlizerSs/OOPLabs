using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    class Mass<T> : IMass<T>
    {
        public T[] Arr { get; set; }
        public Mass(params T[] arr)
        {
            this.Arr = arr;
        }
        public static Mass<T> operator -(Mass<T> M1, int a)
        {
            T[] newArr = new T[M1.Arr.Length-a];

            for (int i = 0; i < M1.Arr.Length-a; i++)
            {
                newArr[i] = M1.Arr[i];
            }
            return new Mass<T>(newArr);
        }
        public static Mass<T> operator +(Mass<T> M1, T a)
        {
            T[] newArr = new T[M1.Arr.Length + 1];

            for (int i = 0; i < M1.Arr.Length; i++)
            {
                newArr[i] = M1.Arr[i];
            }
            newArr[M1.Arr.Length] = a;
            return new Mass<T>(newArr);
        }

        public class Owner
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Organization { get; set; }
            public Owner(int id, string name, string organization)
            {
                this.ID = id;
                this.Name = name;
                this.Organization = organization;
            }
        }
        public class Date
        {
            public int Year { get; set; }
            public string Month { get; set; }
            public int Day { get; set; }
            public Date(int year, string month, int day)
            {
                this.Year = year;
                this.Month = month;
                this.Day = day;
            }
            
        }

        public void Remove()
        {
            T[] newArr = new T[Arr.Length - 1];

            for (int i = 0; i < Arr.Length - 1; i++)
            {
                newArr[i] = Arr[i];
            }
            this.Arr = newArr;
        }
        public void Add(T value)
        {
            T[] result = new T[Arr.Length + 1];
            result[result.Length - 1] = value;
            for (int i = 0 ; i < Arr.Length + 1; i++)
            {
                result[i] = Arr[i];
            }
            this.Arr = result;

        }
        public void Display()
        {
            if (Arr.Length == 0)
            {
                Console.WriteLine($"Список пуст!");
                return;
            }

            string result = "";
            for (int i = 0; i < Arr.Length; i++)
            {
                if (i == Arr.Length - 1) result += $"{Arr[i]}";
                else result += $"{Arr[i]}, ";

            }
            Console.WriteLine($"Список: {result}");
        }
    }
}
