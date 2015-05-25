using System;

namespace HackBulgaria_2_A_Simple_Logger.Loggers
{
    class ConsoleLogger: BaseLogger
    {
        public override void Log(int level, string message)
        {
            var log = GenerateLogMessageString(level, message);
            Console.WriteLine(log);
        }
    }
}
