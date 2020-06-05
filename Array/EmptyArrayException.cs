using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array
{
    public class EmptyArrayException : Exception
    {
        public EmptyArrayException() {}
        public EmptyArrayException(string message)
            :base(message)  { }
    }
}
