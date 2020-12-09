using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    abstract class Figure
    {
        public string Color { get; set; }
        public virtual void ColorOf()
        {
            Console.WriteLine("Цвет фигуры - " + Color);
        }
        public abstract void resize();
        public Figure(string color)
        {
            this.Color = color;
        }
        public override string ToString()
        {
            return $"Объект типа {this.GetType()}";
        }

    }
}
