using System;

namespace HackBulgaria_3_Query_Language_Over_CSV.Exceptions
{
    
    public class InvalidColumnNameException : Exception
    {
        public InvalidColumnNameException()
        {
        }

        public InvalidColumnNameException(string message)
            : base(message)
        {
        }

        public InvalidColumnNameException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
