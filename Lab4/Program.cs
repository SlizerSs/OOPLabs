using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            Mass A = new Mass(1, 2, 3);
            Mass B = new Mass(3, 4, 5);
            Mass D = new Mass(1, 2, 3);
            Mass C = A - 1;
            foreach (int i in C.Arr)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine();
            Console.WriteLine(2 > A);
            Console.WriteLine(A == B);
            Console.WriteLine(A != D);
            Mass E = A + B;
            foreach (int i in E.Arr)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();













            Mass.Owner Owner1 = new Mass.Owner(11, "Pavel", "BelSTU");
            Mass.Date Date1 = new Mass.Date(2020, "October", 6);


        }
    } 
}
