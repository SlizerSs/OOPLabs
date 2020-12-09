using System;
using System.Text;

namespace Lab22
{
    class Program
    {
        static void Main(string[] args)
        {
            int k = 1;
            while (k!=0)
            {
                Console.WriteLine("\nНомер задания(от 1 до 6):");
                k = Convert.ToInt32(Console.ReadLine());
                switch (k)
                {
                    case 1:
                        FirstTask();
                        break;
                    case 2:
                        SecondTask();
                        break;
                    case 3:
                        ThirdTask();
                        break;
                    case 4:
                        FourthTask();
                        break;
                    case 5:
                        int[] Arrai= { 2, 3, 4, 5};
                        Console.WriteLine(FifthTask(Arrai, "abcd"));
                        break;
                    case 6:
                        SixOne();
                        SixTwo();
                        break;
                    default: return;
                }
            }

            (int, int, int, char) FifthTask(int[] arrA, string strA)
            {
                int max, min, sum=0;
                min = max = arrA[0];
                foreach(int i in arrA)
                {
                    if (i < min)
                    {
                        min = i;
                    }
                }
                foreach (int i in arrA)
                {
                    if (i > max)
                    {
                        max = i;
                    }
                }
                foreach (int i in arrA)
                {
                    sum += i;
                }
                (int, int, int, char) TupleB = (min, max, sum, strA[0]);
                return TupleB;
            }
            void SixOne()
            {
                unchecked
                {
                    int A = 2_147_483_647;
                    A++;
                    Console.WriteLine(A);
                }
            }
            void SixTwo()
            {
                unchecked
                {
                    int A = 2_147_483_647;
                    A++;
                    Console.WriteLine(A);
                }
            }

        }

        static void FirstTask()
        {
            //1a,b tasks
            bool boolA = true;
            Console.WriteLine("Переменная типа bool = {0}\n Новое значение:", boolA);
            boolA = Convert.ToBoolean(Console.ReadLine());

            int intA = 1;
            Console.WriteLine("Переменная типа int = {0}\n Новое значение:", intA);
            intA = Convert.ToInt32(Console.ReadLine());

            float flA;
            flA = 1.1f;
            Console.WriteLine("Переменная типа float = {0}\n Новое значение:", flA);
            flA = (float)Convert.ToDouble(Console.ReadLine());

            char charA = 'a';
            Console.WriteLine("Переменная типа char = {0}\n Новое значение:", charA);
            charA = Convert.ToChar(Console.ReadLine());

            decimal decA = 1E3m;
            Console.WriteLine("Переменная типа decimal = {0}\n Новое значение:", decA);
            decA = Convert.ToDecimal(Console.ReadLine());

            double doubA = flA;
            byte byteA = 1;
            sbyte sbyteA = (sbyte)byteA;
            uint uiA = (uint)intA;
            long longA = intA;
            ulong ulA = (ulong)longA;
            ushort ushA = 1;
            short shA = (short)ushA;

            //1c,d tasks
            Console.WriteLine();
            Object objA = intA;
            Console.WriteLine("objA = {0} ({1})\nintA = {2} ({3})", objA, objA.GetType(), intA, intA.GetType());
            intA = (int)objA;
            Object objB = charA;
            Console.WriteLine("objB = {0} ({1})\ncharB = {2} ({3})", objB, objB.GetType(), charA, charA.GetType());
            charA = (char)objB;

            var varA = 10;
            var varB = 'A';
            var varC = "String";

            //1e,f tasks
            int? A = null;
            Nullable<int> B = 6;
            B = null;
            //int C = null;

            var varD = 'A';
            //varD = 5;
        }
        static void SecondTask()
        {
            String str1 = "first string";
            String str2 = "second string";
            String str3 = "third string";

            str1 = String.Concat(str1, str2);
            Console.WriteLine(str1);
            str1 = String.Copy(str2);
            Console.WriteLine(str1);
            str1 = str1.Substring(3,5);
            Console.WriteLine(str1);
            String[] splitStr = str3.Split(' ');
            foreach (String str in splitStr)
            {
                Console.WriteLine(str);
            }

            str3 = str3.Insert(5, " ----");
            Console.WriteLine(str3);
            str3 = str3.Remove(5, 5);
            Console.WriteLine(str3);
            String str0 = "строк";
            Console.WriteLine($"Интерполирование {str0}");

            String testString1 = " ";
            String testString2 = null;
            Console.WriteLine("' '   IsNullOrEmpty - " + String.IsNullOrEmpty(testString1));
            Console.WriteLine("null  IsNullOrEmpty - " + String.IsNullOrEmpty(testString2));

            Console.WriteLine("' '   IsNullOrWhiteSpace - " + String.IsNullOrWhiteSpace(testString1));
            Console.WriteLine("null  IsNullOrWhiteSpace - " + String.IsNullOrWhiteSpace(testString2));

            StringBuilder string1 = new StringBuilder("Строка на основе StringBuilder");
            string1.Remove(0, 3);
            string1.Remove(22, 5);
            Console.WriteLine(string1);
            string1.Insert(0, "AAA");
            string1.Insert(25, "AAA");
            Console.WriteLine(string1);
        }
        static void ThirdTask()
        {
            //Создание объекта для генерации чисел
            Random rnd = new Random();
            int[,] arrA = new int[2,2];
            Console.WriteLine("\nПервое задание:");
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    arrA[i, j] = rnd.Next(1, 10);
                    Console.Write("{0}  ", arrA[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("\nВторое задание:");
            String[] arrB = { "AAA", "BBB", "CCC" };
            foreach (String newstr in arrB)
            {
                Console.WriteLine(newstr);
            }
            Console.WriteLine("Длина массива - {0}", arrB.Length);
            Console.WriteLine("Номер изменяемого элемента: ");
            int index = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Новый элемент: ");
            String newContent = Console.ReadLine();
            arrB[index-1] = newContent;
            Console.WriteLine("Новый массив: ");
            foreach (String newstr in arrB)
            {
                Console.WriteLine(newstr);
            }
            Console.WriteLine("\nТретье задание:");
            int[][] arrC = new int[3][];
            arrC[0] = new int[2];
            arrC[1] = new int[3];
            arrC[2] = new int[4];
            
            for (int i = 0; i < 3; i++)
            {
                int j = 0;
                foreach(int tmp in arrC[i])
                {
                    arrC[i][j] = Convert.ToInt32(Console.ReadLine());
                    j++;
                }
            }
            for (int i = 0; i < 3; i++)
            {
                int j = 0;
                foreach (int tmp in arrC[i])
                {
                    Console.Write("  " + arrC[i][j]);
                    j++;
                }
                Console.WriteLine();
            }

            var vmas = new int[5];
            var vstr = "aaaa";

        }
        static void FourthTask()
        {
            (int, string, char, string, ulong) TupleA = (1, "aa", 'b', "cc", 23);
            Console.WriteLine(TupleA);
            Console.WriteLine(TupleA.Item1);
            Console.WriteLine(TupleA.Item3);
            Console.WriteLine(TupleA.Item4);

            var (first, _, _, fourth, fifth) = TupleA;
        }


    }
}
