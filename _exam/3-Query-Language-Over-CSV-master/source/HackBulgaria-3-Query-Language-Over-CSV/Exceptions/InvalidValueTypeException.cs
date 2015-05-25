using System;

namespace HackBulgaria_3_Query_Language_Over_CSV.Exceptions
{
    
    public class InvalidValueTypeException : Exception
    {
        public InvalidValueTypeException()
        {
        }

        public InvalidValueTypeException(string message)
            : base(message)
        {
        }

        public InvalidValueTypeException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
