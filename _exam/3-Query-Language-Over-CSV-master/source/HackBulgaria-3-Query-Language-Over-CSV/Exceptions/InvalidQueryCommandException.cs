using System;

namespace HackBulgaria_3_Query_Language_Over_CSV.Exceptions
{
    
    public class InvalidQueryCommandException : Exception
    {
        public InvalidQueryCommandException()
        {
        }

        public InvalidQueryCommandException(string message)
            : base(message)
        {
        }

        public InvalidQueryCommandException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
