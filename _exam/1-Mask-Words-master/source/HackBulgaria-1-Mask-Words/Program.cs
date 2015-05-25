using System;
using System.Text.RegularExpressions;

namespace HackBulgaria_1_Mask_Words
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            const string text = "Yesterdogday, I took my dogdog for a walk.\n It was crazy! My dog wanted only food dog.";
            string[] words = { "yesterday", "Dog", "food", "walk" };

            var replacedText = MaskOutWords(words, text);

            Console.WriteLine("original text: {0}", text);
            Console.WriteLine();
            Console.WriteLine("replaced text: {0}", replacedText);
            Console.ReadLine();
        }

        private static string MaskOutWords(string[] words, string text)
        {
            var pattern = string.Format(@"\b({0})\b", string.Join("|", words));
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            var replaced = regex.Replace(text, match => new string('*', match.Value.Length));
            return replaced;
        }
    }
}
