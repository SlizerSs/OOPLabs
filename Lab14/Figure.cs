using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab14
{
    [Serializable]
    public abstract class Figure
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
        public Figure()
        {
        }
        public override string ToString()
        {
            return $"Объект типа {this.GetType()}";
        }

    }
}
