﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    class SizeOfElementException : Exception
    {
        public SizeOfElementException(string message)
            : base(message)
        { }
    }
}
