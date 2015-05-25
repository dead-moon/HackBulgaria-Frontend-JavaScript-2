using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using HackBulgaria_3_Query_Language_Over_CSV.Common;
using HackBulgaria_3_Query_Language_Over_CSV.Exceptions;
using HackBulgaria_3_Query_Language_Over_CSV.Settings;

namespace HackBulgaria_3_Query_Language_Over_CSV.QueryLang
{
    public class QueryLanguage
    {
        private readonly List<string> _supportedCommands = new List<string>
        {
            "Help", "Select", "Sum", "Show", "Find"
        };

        private SourceData Source { get; set; }

        public QueryLanguage(SourceData source)
        {
            Source = source;
        }

        public void ReadCommand(string command)
        {
            var cmdLine = command.Trim();
            var cmd = ExtractCommand(cmdLine);
            var supportedCommandName = GetSupportedCommand(cmd);

            var cmdObjectName = supportedCommandName + "Command";
            var cmdObject = (Command)GetInstance(cmdObjectName);
            if (cmdObject.IsCommandFormatValid(cmdLine))
            {
                cmdObject.Source = Source;
                cmdObject.Execute(cmdLine);
            }
        }

        private object GetInstance(string strCommandClassName)
        {
            Type t = Type.GetType(typeof(QueryLanguage).Namespace + "." + strCommandClassName);
            return Activator.CreateInstance(t);
        }

        private string ExtractCommand(string cmd)
        {
            string firstWordInCommandLine = Regex.Match(cmd, @"^\w+", RegexOptions.IgnoreCase).Value;
            return firstWordInCommandLine;
        }

        private string GetSupportedCommand(string command)
        {
            if (string.IsNullOrEmpty(command))
            {
                throw new InvalidQueryCommandException(MessageConstants.ErrorInvalidQueryCommand);
            }

            var supportedCommand = _supportedCommands.Find(s => s.Equals(command, StringComparison.OrdinalIgnoreCase));
            if (string.IsNullOrEmpty(supportedCommand))
            {
                throw new InvalidQueryCommandException(MessageConstants.ErrorInvalidQueryCommand);
            }
            return supportedCommand;
        }
    }
}
