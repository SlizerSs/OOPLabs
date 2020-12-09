using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    partial class ControlElement
    {
        private int size;
        public int Size
        {
            get { return size; }
            set
            {
                if (value <= 0 || value >= 100)
                    throw new SizeOfElementException("Значение размера должно быть больше нуля и меньше ста");
                else
                    size = value;
            }
        }
        private int id;
        public int ID
        {
            get { return id; }
            set
            {
                if (value <= 0 || value > 20)
                    throw new NegativeIDException("Значение ИД должно быть от 0 до 20");
                else
                    id = value;
            }
        }

    }
}
