using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class Printer
    {
        virtual public void IAmPrinting(object obj)
        {
                Console.WriteLine(obj.ToString()); ;
        }
    }
}
