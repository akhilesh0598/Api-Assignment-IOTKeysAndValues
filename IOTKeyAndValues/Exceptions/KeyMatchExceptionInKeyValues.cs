using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDB_API_Project.Exceptions
{
    public class KeyFoundExceptionInKeyValues : Exception
    {
        public KeyFoundExceptionInKeyValues(string s) : base(s)
        {
        }
    }
}