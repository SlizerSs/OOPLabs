using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n Task1");
            UIElements el1;
            el1 = UIElements.button;
            Console.WriteLine(el1 +" = "+ (byte)el1);

            UIElements el2;
            el2 = UIElements.checkbox;
            Console.WriteLine(el2 + " = " + (byte)el2);
            UIElements el3;
            el3 = UIElements.radiobutton;
            Console.WriteLine(el3 + " = " + (byte)el3);

            Console.WriteLine("\n Task3");
            Button but1 = new Button(true, 1, 43);
            Button but2 = new Button(false, 2, 15);
            Checkbox check1 = new Checkbox(true, 3, 23);
            Checkbox check2 = new Checkbox(true, 4, 27);
            UI UI1 = new UI(but1);
            UI1.Add(but2);
            UI1.Add(check1);
            UI1.Add(check2);
            UI1.Show();

            Console.WriteLine();
            UI1.DeleteLast();
            UI1.Show();

            Console.WriteLine();
            UI1.Delete(1);
            UI1.Show();

            Console.WriteLine("\n Task4");
            UI UI2 = new UI(but1, but2, check1, check2);
            UI2.Show();

            Console.WriteLine();
            UIController.AllButtons(UI2);
            
            Console.WriteLine();
            UIController.NumberOfElements(UI2);

            Console.WriteLine();
            UIController.SizeOfUI(UI2);
        }
    }
}
