using System.IO;
using System.Text.RegularExpressions;
using HackBulgaria_3_Query_Language_Over_CSV.Common;
using HackBulgaria_3_Query_Language_Over_CSV.Exceptions;
using HackBulgaria_3_Query_Language_Over_CSV.Settings;
using FileNotFoundException = HackBulgaria_3_Query_Language_Over_CSV.Exceptions.FileNotFoundException;

namespace HackBulgaria_3_Query_Language_Over_CSV.Providers
{
    abstract public class BaseSourceProvider
    {
        private const string FileNamePatternConst = @".*\..*$"; 
        public string FileNamePattern { get { return FileNamePatternConst; } }

        private string _filePath;
        public string FilePath
        {
            get { return _filePath; }
            set
            {
                ValidateFile(value);
                _filePath = value;
            }
        }

        public abstract SourceData GetSourceData();

        protected void ValidateFile(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new EmptyFileNameException(MessageConstants.ErrorEmptyFileName);
            }

            var regex = new Regex(FileNamePattern, RegexOptions.IgnoreCase);
            if (!regex.IsMatch(filePath))
            {
                throw new WrongFileExtensionException(MessageConstants.ErrorWrongFileExtension);
            }

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException(MessageConstants.ErrorFileNotFound);
            }
        }
    }
}
