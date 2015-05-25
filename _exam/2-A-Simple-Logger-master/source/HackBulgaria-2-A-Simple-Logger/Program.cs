using System;
using HackBulgaria_2_A_Simple_Logger.Loggers;

namespace HackBulgaria_2_A_Simple_Logger
{
    class Program
    {
        static void Main()
        {
           TestLoggers();
           
            Console.ReadLine();
        }

        static void TestLoggers()
        {
            var message = "LOGGING_ON_CONSOLE";
            var consoleLogger = new ConsoleLogger();
            for (int i = 1; i <= 3; i++)
            {
                consoleLogger.Log(i, message+i);
            }

            message = "LOGGING_ON_FILE";
            var fileLogger = new FileLogger();
            for (int i = 1; i <= 3; i++)
            {
                fileLogger.Log(i, message + i);
            }

            message = "LOGGING_ON_HTTP";
            var httpLogger = new HttpLogger("http://valexieva.webege.com/httplogger.php");
            for (int i = 1; i <= 3; i++)
            {
                httpLogger.Log(i, message + i);
            }
        }
    }
}
