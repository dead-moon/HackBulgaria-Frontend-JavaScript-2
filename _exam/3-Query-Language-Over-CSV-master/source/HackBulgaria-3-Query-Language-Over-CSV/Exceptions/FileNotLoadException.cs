using System;

namespace HackBulgaria_3_Query_Language_Over_CSV.Exceptions
{
    
    public class FileNotLoadException : Exception
    {
        public FileNotLoadException()
        {
        }

        public FileNotLoadException(string message)
            : base(message)
        {
        }

        public FileNotLoadException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
