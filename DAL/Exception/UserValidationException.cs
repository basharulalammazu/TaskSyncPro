using System;
using System.Collections.Generic;
using System.Text;


namespace DAL.Exception
{
    public class UserValidationException : System.Exception
    {
        public UserValidationException(string message) : base(message) { }
    }
}
