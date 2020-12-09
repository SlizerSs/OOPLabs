using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    interface IMass<T>
    {
        void Add(T value);
        void Remove();
        void Display();

    }
}
