using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
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
        public ControlElement()
        {

        }
        public ControlElement(bool isAct)
        {
            this.isActive = isAct;
        }

    }
}
