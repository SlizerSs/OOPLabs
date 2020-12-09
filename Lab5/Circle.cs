using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class Circle : Figure, IControl
    {
        public int Radius { get; set; }
        
        public override void resize()
        {
            Radius++;
            this.show();
        }
        void IControl.resize()
        {
            Radius--;
            this.show();
        }
        public void resizing()
        {
            if (Radius >= 0)
            {
                ((IControl)this).resize();
            }
            else
            {
                resize();
            }

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

    }
}
