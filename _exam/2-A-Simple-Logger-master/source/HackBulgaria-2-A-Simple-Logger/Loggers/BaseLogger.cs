using System;
using System.Collections.Generic;
using HackBulgaria_2_A_Simple_Logger.Interfaces;

namespace HackBulgaria_2_A_Simple_Logger.Loggers
{
    public abstract class BaseLogger : MyLogger
    {
        private readonly Dictionary<int, string> logLevel = new Dictionary<int, string>()
        {
            {1, "INFO"},
            {2, "WARNING"},
            {3, "PLSCHECKFFS"}
        };

        public string GenerateLogMessageString(int level, string message)
        {
            string logLevelString;
            logLevel.TryGetValue(level, out logLevelString);
            var timestamp = DateTime.UtcNow.ToString("O");
            return string.Format("{0}::{1}::{2}", logLevelString, timestamp, message);
        }

        public abstract void Log(int level, string message);
    }
}
