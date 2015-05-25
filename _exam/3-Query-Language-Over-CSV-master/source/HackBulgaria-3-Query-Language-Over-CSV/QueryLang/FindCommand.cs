using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using HackBulgaria_3_Query_Language_Over_CSV.Helpers;
using HackBulgaria_3_Query_Language_Over_CSV.Loggers;
using HackBulgaria_3_Query_Language_Over_CSV.Settings;

namespace HackBulgaria_3_Query_Language_Over_CSV.QueryLang
{
    public class FindCommand : Command
    {
        private readonly Regex _rgx;
        private string _exactMatchCriteria = "";
        private string _substringMatchCriteria = "";

        public FindCommand()
        {
            CommandPattern = @"^FIND\s+((?<SearchExactMatchGroup>\w+)|(""(?<SearchSubstringGroup>.+)""))\s*$";
            _rgx = new Regex(CommandPattern, RegexOptions.IgnoreCase);
        }

        public override void Execute(string commandLine)
        {
            SetArguments(commandLine);
            var result = GetResult();
            FormatResult(result);

        }

        private List<List<string>> GetResult()
        {
            var result = new List<List<string>>();
            var isExactMatchSearch = !string.IsNullOrEmpty(_exactMatchCriteria);

            foreach (var row in Source.RowsData)
            {
                if (IsMatchExists(row, isExactMatchSearch))
                {
                    result.Add(row.ToList());
                }
            }

            return result;
        }

        private bool IsMatchExists(string[] row, bool isExactMatchSearch = false)
        {
            var result = false;
            foreach (var el in row)
            {
                var criteria = (isExactMatchSearch)
                    ? el.Equals(_exactMatchCriteria, StringComparison.OrdinalIgnoreCase)
                    : el.ToUpperInvariant().Contains(_substringMatchCriteria.ToUpperInvariant());
                if (criteria)
                {
                    result = true;
                    break;
                }
            }

            return result;
        }

        private void SetArguments(string commandLine)
        {
            var match = _rgx.Match(commandLine);

            _exactMatchCriteria = match.Groups["SearchExactMatchGroup"].Value;
            _substringMatchCriteria = match.Groups["SearchSubstringGroup"].Value;
        }

        private void FormatResult(List<List<string>> result)
        {
            if (result.Count == 0)
            {
                Logger.Log(MessageConstants.NoResults);
            }
            else
            {
                var table = new ConsoleTable(Source.Headers.ToList(), result);
                table.Print();
            }
        }
    }
}
