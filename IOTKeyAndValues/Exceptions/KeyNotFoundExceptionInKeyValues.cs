using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDB_API_Project.Exceptions
{
    public class KeyNotFoundExceptionInKeyValues : Exception
    {
        public KeyNotFoundExceptionInKeyValues(string s) : base(s)
        {
        }
    }
}