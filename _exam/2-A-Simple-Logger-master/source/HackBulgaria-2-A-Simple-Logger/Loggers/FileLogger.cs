using System.IO;

namespace HackBulgaria_2_A_Simple_Logger.Loggers
{
    class FileLogger : BaseLogger
    {
        private const string LogFile = "log.txt";

        public FileLogger() 
        {
            if (!File.Exists(LogFile))
            {
                File.Create(LogFile).Dispose();
            }
        }
        public override void Log(int level, string message)
        {
            var logMessage = GenerateLogMessageString(level, message);
            using (StreamWriter w = File.AppendText(LogFile))
            {
                w.WriteLine(logMessage);
            }
        }
    }
}
