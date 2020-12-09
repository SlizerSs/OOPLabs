using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class Rectangle : Figure, IControl
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public void show()
        {
            Console.WriteLine("Width = " + Width);
            Console.WriteLine("Height = " + Height);
        }
        public override void resize()
        {
            Width++;
            Height++;
            this.show();
        }
        void IControl.resize()
        {
            Width--;
            Height--;
            this.show();
        }
        public void resizing()
        {
            if (Width+Height >= 0)
            {
                ((IControl)this).resize();
            }
            else
            {
                resize();
            }

        }
        public void input(int a)
        {
            Width = a;
            Height = a;
            this.show();
        }

        public Rectangle(string color, int width, int height) : base(color)
        {
            this.Width = width;
            this.Height = height;
            this.Color = color;

        }
    }
}
