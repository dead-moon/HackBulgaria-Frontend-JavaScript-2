using System;
using HackBulgaria_3_Query_Language_Over_CSV.Exceptions;
using HackBulgaria_3_Query_Language_Over_CSV.Helpers;
using HackBulgaria_3_Query_Language_Over_CSV.Loggers;
using HackBulgaria_3_Query_Language_Over_CSV.Providers;
using HackBulgaria_3_Query_Language_Over_CSV.QueryLang;
using HackBulgaria_3_Query_Language_Over_CSV.Settings;

namespace HackBulgaria_3_Query_Language_Over_CSV
{
    class Program
    {
        static void Main(string[] args)
        {
            var provider = new CsvProvider();
            var fileHelper = new FileHelper();
            var source = fileHelper.LoadSourceData(provider);
            var query = new QueryLanguage(source);

            PrintHeaderSection();

            while (true)
            {
                Console.WriteLine();
                Console.Write("query>");
                var command = Console.ReadLine();

                var quitCommand = command != null && command.Equals("quit", StringComparison.InvariantCultureIgnoreCase);
                if (quitCommand)
                    break;

                try
                {
                    query.ReadCommand(command);
                }
                catch (InvalidQueryCommandException ex)
                {
                    Logger.Log(ex.Message);
                }
                catch (InvalidQueryFormatException ex)
                {
                    Logger.Log(ex.Message);
                }
            }
        }

        private static void PrintHeaderSection()
        {
            Console.WriteLine();
            Console.WriteLine(new string('-', 66));
            Console.WriteLine(MessageConstants.ApplicationTitle);
            Console.WriteLine(MessageConstants.HelpText);
            Console.WriteLine(new string('-', 66));
        }
    }
}
