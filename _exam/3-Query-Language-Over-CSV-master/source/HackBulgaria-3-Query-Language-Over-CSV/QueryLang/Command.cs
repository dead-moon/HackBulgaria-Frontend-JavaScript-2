using System;
using System.Text.RegularExpressions;
using HackBulgaria_3_Query_Language_Over_CSV.Common;
using HackBulgaria_3_Query_Language_Over_CSV.Exceptions;
using HackBulgaria_3_Query_Language_Over_CSV.Settings;

namespace HackBulgaria_3_Query_Language_Over_CSV.QueryLang
{
    public abstract class Command
    {
        public SourceData Source { get; set; }
        public string CommandPattern;

        public abstract void Execute(string commandLine);

        public bool IsCommandFormatValid(string commandLine)
        {
            var regex = new Regex(CommandPattern, RegexOptions.IgnoreCase);
            var isValidCommand = regex.IsMatch(commandLine);
            if (!isValidCommand)
            {
                throw new InvalidQueryFormatException(MessageConstants.ErrorInvalidQueryFormat);
            }

            return true;
        }

        protected int GetColumnIndex(string columnName)
        {
            var sourceColumnIndex = Array.FindIndex(Source.Headers, h => h.Equals(columnName, StringComparison.OrdinalIgnoreCase));
            if (sourceColumnIndex == -1)
            {
                var errorMessage = string.Format(MessageConstants.ErrorInvalidColumnNameFormat, columnName);
                throw new InvalidColumnNameException(errorMessage);
            }

            return sourceColumnIndex;
        }
    }
}
