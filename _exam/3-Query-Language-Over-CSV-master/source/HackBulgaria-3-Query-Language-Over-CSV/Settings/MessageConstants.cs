namespace HackBulgaria_3_Query_Language_Over_CSV.Settings
{
    public static class MessageConstants
    {
        public const string ErrorFileNotFound = "Error: File does not exist!";
        public const string ErrorEmptyFileName = "Error: Please select csv file path";
        public const string ErrorWrongFileExtension = "Error: The file is not csv";
        public const string ErrorCouldnotReadFile = "Error: The file could not be read";
        public const string ErrorInvalidFileFormat = "Error: The file is not in corect format";
        public const string ErrorInvalidQueryCommand = "Error: The command is not supported. Type 'help' to display all supported commands";
        public const string ErrorInvalidQueryFormat = "Error: The query format is not supported. Type 'help' to display all supported commands";
        public const string ErrorInvalidColumnNameFormat = "Error: Column \"{0}\" doesn't exist";
        public const string ErrorColumnValueNotDigits = "Error: Column values are not digits";
        public const string ErrorInvalidLimitNumberParam = "Error: Limit number is not corect";

        public const string SetCsvFilePath = "Set csv source file: ";
        public const string ApplicationTitle = "Query language over a CSV file v.0.0.1";
        public const string HelpText = "Type 'help' to display all supported commands and 'quit' to exit";
        public const string NoResults = "There are no results that match your search criteria";

        public const string HelpCommandTitle = "Supported queries:";
        public const string HelpCommandSelect = "SELECT [columns] LIMIT X - where you can SELECT without giving the LIMIT. This fetchs all or limited rows.";
        public const string HelpCommandSum = "SUM [column] - returns the sum of all integers in the given column.";
        public const string HelpCommandShow = "SHOW - returns a list of all column names in source data.";
        public const string HelpCommandFind = "FIND X - returns all rows, that has X in some of their cells. If X is a string, search for every string, that contains X as a substring.";   
    }
}
