using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    static class UIController
    {
        public static void AllButtons(UI ui)
        {
            foreach (ControlElement ui1 in ui)
            {
                if (ui1.ToString() == "Объект типа Lab6.Button")
                {
                    ui1.Status();
                }
            }
        }
        public static void NumberOfElements(UI ui)
        {
            int numberOf = 0;
            foreach (ControlElement ui1 in ui)
            {
                numberOf++;
            }
            Console.WriteLine($"Общее кол-во элементов на UI = {numberOf}");
        }
        public static void SizeOfUI(UI ui)
        {
            int size = 0;
            foreach (ControlElement ui1 in ui)
            {
                size += ui1.Size;
            }
            Console.WriteLine($"Размер UI = {size}");
        }
    }
}
