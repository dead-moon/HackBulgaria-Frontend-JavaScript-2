using System;
using HackBulgaria_3_Query_Language_Over_CSV.Settings;

namespace HackBulgaria_3_Query_Language_Over_CSV.QueryLang
{
    public class HelpCommand: Command
    {
        public HelpCommand()
        {
            CommandPattern = @"^HELP\s*$";
        }

        public override void Execute(string commandLine)
        {
            Console.WriteLine(); Console.WriteLine(new string('-', 66));
            Console.WriteLine(MessageConstants.HelpCommandTitle); 
            Console.WriteLine(); Console.WriteLine(new string('-', 66));
            Console.WriteLine(MessageConstants.HelpCommandSelect + Environment.NewLine);
            Console.WriteLine(MessageConstants.HelpCommandSum + Environment.NewLine);
            Console.WriteLine(MessageConstants.HelpCommandShow + Environment.NewLine);
            Console.WriteLine(MessageConstants.HelpCommandFind + Environment.NewLine);
        }
    }
}
