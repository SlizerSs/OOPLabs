using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Lab10
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задание 1");
            Book<int, string> book1 = new Book<int, string>(12,"Война и мир");
            Book<int, string> book2 = new Book<int, string>(56,"Преступление и наказание");
            Book<int, string> book3 = new Book<int, string>(73,"Мёртвые души");
            Book<int, string> book4 = new Book<int, string>(44,"Отцы и дети");
            
            List<Book<int, string>> list1 = new List<Book<int, string>>() { book1, book2, book3 };
            
            foreach (Book<int, string> book in list1)
            {
                Console.WriteLine($"Книга: {book.Title}");
            }
            Console.WriteLine();

            list1.Add(book4);
            Console.WriteLine($"Добавили {book4.Title}");
            foreach (Book<int, string> book in list1)
            {
                Console.WriteLine($"Книга: {book.Title}");
            }
            Console.WriteLine();

            list1.RemoveAt(2);
            Console.WriteLine($"Удалили {book3.Title}");
            foreach (Book<int, string> book in list1)
            {
                Console.WriteLine($"Книга: {book.Title}");
            }
            Console.WriteLine();
            Console.WriteLine($"Книга {book2.Title} в списке под номером {list1.BinarySearch(book2)+1}");
            
            Console.WriteLine("\nЗадание 2");

            List<char> list2 = new List<char>() { 'd','u','n','g','e','o','n' };
            foreach (char ch in list2)
            {
                Console.Write($"{ch} ");
            }
            Console.WriteLine();
            Console.WriteLine("Сколько удалить элементов?");
            int n = Convert.ToInt32(Console.ReadLine());
            for (int i=0;i<n;i++ )
            {
                list2.RemoveAt(0);
            }

            foreach (char ch in list2)
            {
                Console.Write($"{ch} ");
            }
            Console.WriteLine();
            list2.Add('f');
            char[] arr = { 'a', 'b', 'c' };
            list2.AddRange(arr);
            foreach (char ch in list2)
            {
                Console.Write($"{ch} ");
            }
            Console.WriteLine();
            Console.WriteLine();

            ArrayList arrList = new ArrayList();
            arrList.AddRange(list2);

            foreach (char ch in arrList)
            {
                Console.Write($"{ch} ");
            }
            Console.WriteLine();
            Console.WriteLine("Какой элемент ищем?");
            char search = Convert.ToChar(Console.Read());
            if (arrList.Contains(search))
            {
                Console.WriteLine("Такой элемент есть");
            }
            else
            {
                Console.WriteLine("Такого элемента нет");
            }

            Console.WriteLine("\nЗадание 3");
            ObservableCollection<Book<int,string>> books = new ObservableCollection<Book<int, string>>{book1,book2,book3};
            books.CollectionChanged += Books_CollectionChanged;
            foreach (Book<int, string> book in books)
            {
                Console.WriteLine($"Книга: {book.Title}");
            }
            Console.WriteLine();
            books.Add(book4);
            foreach (Book<int, string> book in books)
            {
                Console.WriteLine($"Книга: {book.Title}");
            }
            Console.WriteLine();
            books.RemoveAt(1);

            foreach (Book<int, string> book in books)
            {
                Console.WriteLine($"Книга: {book.Title}");
            }
        }

        private static void Books_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add: // если добавление
                    Console.WriteLine($"Добавлена новая книга");
                    break;
                case NotifyCollectionChangedAction.Remove: // если удаление
                    Console.WriteLine($"Удалена книга");
                    break;
                default:
                    Console.WriteLine($"Коллекция была изменена");
                    break;
            }
        }
    }
}
