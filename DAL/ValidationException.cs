using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class ValidationException : System.Exception
    {
        public ValidationException(string message) : base(message) { }
    }
}
