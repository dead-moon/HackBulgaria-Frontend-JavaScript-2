using System;
using HackBulgaria_3_Query_Language_Over_CSV.Common;
using HackBulgaria_3_Query_Language_Over_CSV.Exceptions;
using HackBulgaria_3_Query_Language_Over_CSV.Loggers;
using HackBulgaria_3_Query_Language_Over_CSV.Providers;
using HackBulgaria_3_Query_Language_Over_CSV.Settings;

namespace HackBulgaria_3_Query_Language_Over_CSV.Helpers
{
    public  class FileHelper
    {
        public SourceData LoadSourceData(BaseSourceProvider provider)
        {
            var source = new SourceData();
            var isFileValid = false;
            do
            {
                Console.WriteLine();
                Console.Write(MessageConstants.SetCsvFilePath);
                var filePath = Console.ReadLine();

                try
                {
                    provider.FilePath = filePath;
                    source = provider.GetSourceData();
                    isFileValid = true;
                }
                catch (EmptyFileNameException ex)
                {
                    Logger.Log(ex.Message);
                }
                catch (WrongFileExtensionException ex)
                {
                    Logger.Log(ex.Message);
                }
                catch (FileNotFoundException ex)
                {
                    Logger.Log(ex.Message);
                }
                catch (Exception ex) 
                {
                    Logger.Log(ex.Message);
                }
            } while (!isFileValid);

            return source;
        }
    }
}
