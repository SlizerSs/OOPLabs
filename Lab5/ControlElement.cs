using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class ControlElement
    {
        public bool isActive { get; set; }
        public void Switch()
        {
            if (isActive)
            {
                isActive = false;
            }
            else
            {
                isActive = true;
            }
        }
        public ControlElement(bool isAct)
        {
            this.isActive = isAct;
        }
        public void Status()
        {
            Console.WriteLine("Element is " + isActive);
        }
        public override string ToString()
        {
            return $"Объект типа {this.GetType()}";
        }
    }
}
