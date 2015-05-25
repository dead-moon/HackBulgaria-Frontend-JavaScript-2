using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using HackBulgaria_3_Query_Language_Over_CSV.Exceptions;
using HackBulgaria_3_Query_Language_Over_CSV.Helpers;
using HackBulgaria_3_Query_Language_Over_CSV.Loggers;
using HackBulgaria_3_Query_Language_Over_CSV.Settings;

namespace HackBulgaria_3_Query_Language_Over_CSV.QueryLang
{
    public class SelectCommand : Command
    {
        private readonly Regex _rgx;
        private List<int> _columnIndexes;
        private List<string> _columnNames;
        private int _limitNumber = -1;

        public SelectCommand()
        {
            CommandPattern = @"^SELECT\s+(?<ColumnsGroup>(\s*\w+\s*,)*\s*\w+)(\s+LIMIT\s+(?<LimitNumberGroup>\d+))?\s*$";
            _rgx = new Regex(CommandPattern, RegexOptions.IgnoreCase);
            _columnIndexes = new List<int>();
            _columnNames = new List<string>();
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
            for (var i = 0; i < _limitNumber; i++)
            {
                var rowData = new List<string>();
                foreach (var columnIndex in _columnIndexes)
                {
                    rowData.Add(Source.RowsData[i][columnIndex]);
                }
                result.Add(rowData);
            }
            return result;
        }

        private void SetArguments(string commandLine)
        {
            var match = _rgx.Match(commandLine);

            try
            {
                var limitNumberString = match.Groups["LimitNumberGroup"].Value;
                SetLimitNumber(limitNumberString);

                var columnsString = match.Groups["ColumnsGroup"].Value;
                SetColumnParams(columnsString);
            }
            catch (InvalidValueTypeException ex)
            {
                Logger.Log(ex.Message);
            }
            catch (InvalidColumnNameException ex)
            {
                Logger.Log(ex.Message);
            }
        }

        private void SetColumnParams(string columnsString)
        {
            var rgxColumns = new Regex(@"\w+", RegexOptions.IgnoreCase);
            var matches = rgxColumns.Matches(columnsString);
            foreach (var match in matches)
            {
                var columnName = match.ToString();
                var columnIndex = GetColumnIndex(columnName);

                _columnIndexes.Add(columnIndex);
                _columnNames.Add(columnName.ToLower());
            }

        }

        private void SetLimitNumber(string limitNumberString)
        {
            if (!string.IsNullOrEmpty(limitNumberString))
            {
                bool res = int.TryParse(limitNumberString, out _limitNumber);
                if (res == false)
                {
                    throw new InvalidValueTypeException(MessageConstants.ErrorInvalidLimitNumberParam);
                }
            }

            var sourceRowNumbers = Source.RowsData.Count();
            if (_limitNumber == -1 || _limitNumber > sourceRowNumbers)
            {
                _limitNumber = sourceRowNumbers;
            }
        }

        private void FormatResult(List<List<string>> result)
        {
            if (result.Count == 0)
            {
                Logger.Log(MessageConstants.NoResults);
            }
            else
            {
                var table = new ConsoleTable(_columnNames, result);
                table.Print();
            }
        }
    }
}
