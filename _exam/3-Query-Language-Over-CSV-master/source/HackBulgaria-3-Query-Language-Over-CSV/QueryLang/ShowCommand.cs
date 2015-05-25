using System;
using System.Linq;

namespace HackBulgaria_3_Query_Language_Over_CSV.QueryLang
{
    public class ShowCommand: Command
    {
        public ShowCommand()
        {
            CommandPattern = @"^SHOW\s*$";
        }

        public override void Execute(string commandLine)
        {
            var result = GetResult();
            FormatResult(result);
        }

        private string[] GetResult()
        {
            var result = Source.Headers;
            return result;
        }

        private void FormatResult(string[] data)
        {
            var stringData = string.Join(", ", data.ToList());
            Console.WriteLine(stringData + Environment.NewLine);
        }
    }
}
