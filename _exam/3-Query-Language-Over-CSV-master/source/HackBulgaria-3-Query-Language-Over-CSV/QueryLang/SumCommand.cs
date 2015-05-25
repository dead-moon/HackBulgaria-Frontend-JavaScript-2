using System;
using System.Text.RegularExpressions;
using HackBulgaria_3_Query_Language_Over_CSV.Exceptions;
using HackBulgaria_3_Query_Language_Over_CSV.Loggers;
using HackBulgaria_3_Query_Language_Over_CSV.Settings;

namespace HackBulgaria_3_Query_Language_Over_CSV.QueryLang
{
    public class SumCommand : Command
    {
        private readonly Regex _rgx;
        private int _sourceColumnIndex;


        public SumCommand()
        {
            CommandPattern = @"^SUM\s+(?<ColumnNameGroup>\w+)\s*$";
            _rgx = new Regex(CommandPattern, RegexOptions.IgnoreCase);
        }

        public override void Execute(string commandLine)
        {
            try
            {
                SetArguments(commandLine);

                var result = CalculateSum();
                FormatResult(result);
            }
            catch (InvalidColumnNameException ex)
            {
                Logger.Log(ex.Message);
            }
            catch (InvalidValueTypeException ex)
            {
                Logger.Log(ex.Message);
            }
        }

        private int CalculateSum()
        {
            var sum = 0;
            foreach (var row in Source.RowsData)
            {
                int number;
                var result = Int32.TryParse(row[_sourceColumnIndex], out number);
                if (!result)
                {
                    throw new InvalidValueTypeException(MessageConstants.ErrorColumnValueNotDigits);
                }
                sum += number;
            }
            return sum;
        }

        private void FormatResult(int result)
        {
            Console.WriteLine(result + Environment.NewLine);
        }

        private void SetArguments(string commandLine)
        {
            var match = _rgx.Match(commandLine);
            var group = match.Groups["ColumnNameGroup"];
            var columnName = group.Value;

            _sourceColumnIndex = GetColumnIndex(columnName);
        }

       
    }
}
