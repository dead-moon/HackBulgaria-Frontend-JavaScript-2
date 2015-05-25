using System;

namespace HackBulgaria_3_Query_Language_Over_CSV.Exceptions
{
    
    public class EmptyFileNameException : Exception
    {
        public EmptyFileNameException()
        {
        }

        public EmptyFileNameException(string message)
            : base(message)
        {
        }

        public EmptyFileNameException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
