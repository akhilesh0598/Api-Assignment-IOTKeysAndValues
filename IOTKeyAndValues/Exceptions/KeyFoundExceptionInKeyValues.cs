using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDB_API_Project.Exceptions
{
    public class KeyMatchExceptionInKeyValues : Exception
    {
        public KeyMatchExceptionInKeyValues(string s) : base(s)
        {
        }
    }
}