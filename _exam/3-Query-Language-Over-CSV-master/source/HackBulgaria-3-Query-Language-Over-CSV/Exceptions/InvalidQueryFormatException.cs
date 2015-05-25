using System;

namespace HackBulgaria_3_Query_Language_Over_CSV.Exceptions
{
    
    public class InvalidQueryFormatException : Exception
    {
        public InvalidQueryFormatException()
        {
        }

        public InvalidQueryFormatException(string message)
            : base(message)
        {
        }

        public InvalidQueryFormatException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
