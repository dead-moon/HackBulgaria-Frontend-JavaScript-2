using System;
using System.Collections.Generic;

namespace HackBulgaria_3_Query_Language_Over_CSV.Helpers
{
    public class ConsoleTable
    {
        private int _columnNumber;
        private int[] _columnWidths;
        private const int AdditionalChars = 2;
        private List<string> _headers;
        private List<List<string>> _data;

        public ConsoleTable(List<string> headers, List<List<string>> data)
        {
            _headers = headers;
            _data = data;
            SetColumnNumber();
            SetColumnWidths();
        }

        public void Print()
        {
            PrintLine();
            PrintHeaders();
            PrintLine();
            PrintRows();
            PrintLine();
        }

        private void PrintRows()
        {
            foreach (var row in _data)
            {
                PrintRow(row);
            }
        }

        private void PrintLine()
        {
            var cross = "+";
            Console.Write(cross);
            for (var i = 0; i < _columnNumber; i++)
            {
                Console.Write(new string('-', _columnWidths[i]+AdditionalChars));
                Console.Write(cross);
            }
            Console.WriteLine();
        }

        private void PrintRow(List<string> row)
        {
            var pipe = "|";
            Console.Write(pipe);
            for (var i = 0; i < _columnNumber; i++)
            {
                var formatStringPattern = " {0, -" + _columnWidths[i] + "} {1}";
                Console.Write(formatStringPattern, row[i], pipe);
            }
            Console.WriteLine();
        }

        private void PrintHeaders()
        {
            PrintRow(_headers);
        }

        private void SetColumnNumber()
        {
            _columnNumber = _headers.Count;
        }

        private void SetColumnWidths()
        {
            var columnWidths = new int[_columnNumber];
            for (var col = 0; col < _columnNumber; col++)
            {
                columnWidths[col] = _headers[col].Length + AdditionalChars;
                foreach (List<string> row in _data)
                {
                    var dataLength = row[col].Length;
                    if (columnWidths[col] < dataLength)
                    {
                        columnWidths[col] = dataLength + AdditionalChars;
                    }
                }
            }
            _columnWidths = columnWidths;
        }

    }
}
