using System;

namespace HackBulgaria_3_Query_Language_Over_CSV.Exceptions
{
    
    public class WrongFileExtensionException : Exception
    {
        public WrongFileExtensionException()
        {
        }

        public WrongFileExtensionException(string message)
            : base(message)
        {
        }

        public WrongFileExtensionException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
