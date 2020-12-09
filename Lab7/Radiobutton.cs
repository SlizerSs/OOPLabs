using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    class Radiobutton : ControlElement
    {
        public Radiobutton(bool isAct, int id, int size) : base(isAct, id, size)
        {
            this.isActive = isAct;
            this.ID = id;
            this.Size = size;
        }
    }
}
