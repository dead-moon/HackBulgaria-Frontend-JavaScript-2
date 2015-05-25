using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using HackBulgaria_3_Query_Language_Over_CSV.Common;
using HackBulgaria_3_Query_Language_Over_CSV.Exceptions;
using HackBulgaria_3_Query_Language_Over_CSV.Settings;

namespace HackBulgaria_3_Query_Language_Over_CSV.Providers
{
    public class CsvProvider : BaseSourceProvider
    {
        private const string CsvFileNamePattern = @".*\.csv$"; 
        public new string FileNamePattern
        {
            get { return CsvFileNamePattern; }
        }

        private const string Delimiter = ",";
        private static readonly string DelimiterRow = Environment.NewLine;

       
        public CsvProvider() { }

        public CsvProvider(string filePath)
        {
            FilePath = filePath;
            
        }
        public override SourceData GetSourceData()
        {
            var source = new SourceData();
            var csvFileStringData = GetCsvFileData();
            
            var rowsSource = GetCsvRows(csvFileStringData);
            if (rowsSource.Length <= 1)
            {
                throw new InvalidFileFormatException(MessageConstants.ErrorInvalidFileFormat);
            }
            source.Headers = GetCsvRowElements(rowsSource[0]);
            source.ColumnNumber = source.Headers.Length;
            source.RowsData = ExtactElementsFromRow(rowsSource, source.ColumnNumber);
            
            return source;
        }

        private string[][] ExtactElementsFromRow(string[] rowsSource, int columnNumber)
        {
            var elementList = new List<string[]>();
            for (int i = 1; i < rowsSource.Length; i++)
            {
                var rowElements = GetCsvRowElements(rowsSource[i]);
                if (rowElements.Count() != columnNumber)
                {
                    throw new InvalidFileFormatException(MessageConstants.ErrorInvalidFileFormat);
                }
                elementList.Add(rowElements);
            }
            return elementList.ToArray();
        }

        private string GetCsvFileData()
        {
            string csvStringData;
            try
            {
                csvStringData = File.ReadAllText(FilePath);
            }
            catch (Exception ex)
            {
                throw new FileNotLoadException(MessageConstants.ErrorCouldnotReadFile, ex);
            }

            return csvStringData;
        }

        private string[] GetCsvRows(string row)
        {
            var rowsSource = SplitAndTrim(DelimiterRow, row);
            return rowsSource.ToArray();
        }

        private string[] GetCsvRowElements(string row)
        {
            var rowsSource = SplitAndTrim(Delimiter, row);
            return rowsSource.ToArray();
        }

        private string[] SplitAndTrim(string delimiter, string str)
        {
            var splitedString = new List<string>();
            if (!string.IsNullOrEmpty(str) && str.Contains(delimiter))
            {
                foreach (var item in str.Split(new[] { delimiter }, StringSplitOptions.RemoveEmptyEntries))
                {
                    splitedString.Add(item.Trim());
                }
            }
            return splitedString.ToArray();
        }
    }
}
