using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab14
{
    [Serializable]
    public class Circle : Figure
    {
        public int Radius { get; set; }
       
        public override void resize()
        {
            Radius++;
            this.show();
        }
        public void show()
        {
            Console.WriteLine("Radius = " + Radius);
        }
        public void input(int rad)
        {
            Radius = rad;
            this.show();
        }
        public Circle(string color, int radius) : base(color)
        {
            this.Radius = radius;
            this.Color = color;
        }
        public Circle()
        {
        }
    }
}
