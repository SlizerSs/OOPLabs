using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    class Checkbox : ControlElement
    {
        public Checkbox(bool isAct, int id, int color) : base(isAct, id, color)
        {
            this.isActive = isAct;
            this.ID = id;
            this.Size = color;
        }
    }
}
