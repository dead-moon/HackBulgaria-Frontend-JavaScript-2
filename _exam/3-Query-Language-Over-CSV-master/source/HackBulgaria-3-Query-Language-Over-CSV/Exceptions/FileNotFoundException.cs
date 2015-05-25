using System;

namespace HackBulgaria_3_Query_Language_Over_CSV.Exceptions
{
    
    public class FileNotFoundException : Exception
    {
        public FileNotFoundException()
        {
        }

        public FileNotFoundException(string message)
            : base(message)
        {
        }

        public FileNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
