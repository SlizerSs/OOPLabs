using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
{
    class Program
    {
        public delegate string StringHandler(ref string message);
        public delegate User CoVariance(UserLow us);
        
        static void Main(string[] args)
        {
            Console.WriteLine("1 задание");
            User user1 = new User(0, 0, 50);
            user1.MoveEvent += Message => Console.WriteLine(Message);  
            user1.CompressEvent += Message => Console.WriteLine(Message);
            user1.Move(2, -3);
            user1.Compress(30);
            Console.WriteLine($"user1: X = {user1.X}, Y = {user1.Y}, Compress = {user1.CompressionRatio}%");
            
            User user2 = new User(0, 0, 50);
            user2.MoveEvent += Message => Console.WriteLine(Message); 
            user2.Move(5, 3);
            user2.Compress(10);
            Console.WriteLine($"user2: X = {user2.X}, Y = {user2.Y}, Compress = {user2.CompressionRatio}%");

            User user3 = new User(0, 0, 50);
            user3.CompressEvent += Message => Console.WriteLine(Message);   
            user3.Move(-5, 3);
            user3.Compress(-10);
            Console.WriteLine($"user3: X = {user3.X}, Y = {user3.Y}, Compress = {user3.CompressionRatio}%");

            User user4 = new User(0, 0, 50);
            user4.Move(1, 2);
            user4.Compress(40);
            Console.WriteLine($"user4: X = {user4.X}, Y = {user4.Y}, Compress = {user4.CompressionRatio}%");

            Console.WriteLine("\n2 задание");
            Console.Write("Введите строку: ");
            string str1 = Console.ReadLine();

            StringHandler strh; 
            strh = DeletePunctuation;
            strh += DeleteSymbol;
            strh += AddSymbol;
            strh += ToUpperCase;
            strh += DeleteSpaces;
            str1 = strh(ref str1);

            // Пример ковариантности
            // Можно использовать метод, возвращаемым типом параметра которого 
            // является производный класс
            CoVariance var1 = Cov;

            // Пример контравариантности
            // Можно использовать метод, аргументом которого является
            // базовый класс
            var1 = Contra;
        }
        public static UserLow Cov(UserLow us)
        {
            return us;
        }
        public static User Contra(User us)
        {
            return us;
        }

        public static string DeletePunctuation(ref string str)
        {
            char[] punct = new char[]{ '.', ',', ':', ';', '?', '!' };
            char[] arr = str.ToCharArray();
            string result = "";
            for (int i = 0; i < arr.Length; i++)
            {
                if (!punct.Contains(arr[i])) result += arr[i];
            }
            Console.WriteLine(result);
            return str = result;
        }

        public static string DeleteSymbol(ref string str)
        {
            char[] arr = str.ToCharArray();
            string result = "";
            for (int i = 0; i < arr.Length - 1; i++)
            {
                result += arr[i];
            }
            Console.WriteLine(result);
            return str = result;
        }

        public static string AddSymbol(ref string str)
        {
            Console.WriteLine($"Введите символ");
            char newch = Convert.ToChar(Console.Read());
            str += newch;
            Console.WriteLine(str);
            return str;
        }

        public static string ToUpperCase(ref string str)
        {
            Console.WriteLine(str.ToUpper());
            return str=str.ToUpper();
        }

        public static string DeleteSpaces(ref string str)
        {
            char space = ' ';
            char[] arr = str.ToCharArray();
            string result = "";
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != space) result += arr[i];
            }
            Console.WriteLine(result);
            return result;
        }
    }
}
