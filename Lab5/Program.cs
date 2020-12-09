using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            #region task4
            Console.WriteLine("\nTask 4");
            Circle circle1 = new Circle("yellow", 3);
            circle1.input(3);
            circle1.resizing();
            circle1.input(-3);
            circle1.resizing();
            #endregion

            #region task5
            Console.WriteLine("\nTask 5");
            Rectangle rect1 = new Rectangle("red", 5, 8);
            if (rect1 is Figure) 
                Console.WriteLine("Объект rect1 принадлежит классу Figure.");
            else 
                Console.WriteLine("Объект rect1 не принадлежит классу Figure.");

            if (rect1 is IControl)
                Console.WriteLine("Объект rect1 принадлежит интерфейсу IControl.");
            else
                Console.WriteLine("Объект rect1 не принадлежит интерфейсу IControl.");

            Button btn1 = new Button(true);
            if (btn1 is ControlElement)
            {
                ControlElement ce1 = btn1 as ControlElement;
                ce1.Switch();
                ce1.Status();
            }
            #endregion

            #region task6
            Console.WriteLine("\nTask 6");
            Console.WriteLine(circle1.ToString());
            #endregion

            #region task7
            Console.WriteLine("\nTask 7");

            Printer printer = new Printer();
            Figure[] figures = new Figure[] { circle1, rect1 };
            foreach (var item in figures)
            {
                printer.IAmPrinting(item);
            }
            #endregion

        }
    }
}
