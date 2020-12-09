using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class Mass
    {
        public int[] Arr { get; set; }
        public Mass(params int[] arr)
        {
            this.Arr = arr;
        }
        public static Mass operator -(Mass M1, int a)
        {
            int[] newArr = new int[M1.Arr.Length];
            for (int i = 0; i < M1.Arr.Length; i++)
            {
                newArr[i] = M1.Arr[i] - a;
            }
            return new Mass(newArr);
        }
        public static bool operator >(int a, Mass M1)
        {
            for (int i = 0; i < M1.Arr.Length; i++)
            {
                if (M1.Arr[i] == a)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool operator <(int a, Mass M1)
        {
            for (int i = 0; i < M1.Arr.Length; i++)
            {
                if (M1.Arr[i] == a)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool operator !=(Mass M1, Mass M2)
        {
            if (M1.Arr.Length != M2.Arr.Length)
            {
                throw new Exception("Massives have different lengths");
            }
            for (int i = 0; i < M1.Arr.Length; i++)
            {
                if (M1.Arr[i] == M2.Arr[i])
                {
                    return false;
                }
            }
            return true;
        }
        public static bool operator ==(Mass M1, Mass M2)
        {
            if (M1.Arr.Length != M2.Arr.Length)
            {
                throw new Exception("Massives have different lengths");
            }
            for (int i = 0; i < M1.Arr.Length; i++)
            {
                if (M1.Arr[i] != M2.Arr[i])
                {
                    return false;
                }
            }
            return true;
        }
        public static Mass operator +(Mass M1, Mass M2)
        {
            int[] newArr = new int[M1.Arr.Length + M2.Arr.Length];
            for (int i = 0; i < M1.Arr.Length; i++)
            {
                newArr[i] = M1.Arr[i];
            }
            int j = 0;
            for (int i = M1.Arr.Length; i < M1.Arr.Length + M2.Arr.Length; i++)
            {
                newArr[i] = M2.Arr[j];
                j++;
            }
            return new Mass(newArr);
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
            Mass parent;
            public int Year { get; set; }
            public string Month { get; set; }
            public int Day { get; set; }
            public Date(int year, string month, int day)
            {
                this.Year = year;
                this.Month = month;
                this.Day = day;
            }
            public Date(Mass parent)
            {
                this.parent = parent;
            }
            
        }
    }
}
