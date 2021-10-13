using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace VinSolutions
{
    /*----------------------------------------------------------INSTRUCTIONS---------------------------------------------------------------------
    In C#, write a program that parses a sentence and replaces each word with the following: first letter, number of distinct characters 
    between first and last character, and last letter. For example, Smooth would become S3h. Words are separated by spaces or non-alphabetic 
    characters and these separators should be maintained in their original form and location in the answer. The code must be syntactically correct 
    and build in visual studio, either as a console or winforms application.
     ------------------------------------------------------------------------------------------------------------------------------------------*/
    public class Program
    {
        #region Constants
        //split words separated by anything other then aplhanumeric characters
        const string _pattern = "[^A-Za-z0-9$]";
        #endregion

        #region Methods
        static void Main()
        {
            while (true)
            {

                Console.WriteLine("Enter Sentence:");               

                Console.WriteLine($"Parsed Output: { ParseInput(Console.ReadLine()) } \n");

            };
        }

        public static string ParseInput(string v)
        {            
            StringBuilder parsedWord = new StringBuilder();
            parsedWord.Append(v);
            
            if (string.IsNullOrEmpty(v.Trim()))
                return "Cannot Parse Empty String";
            
            Words = Regex.Split(v, _pattern, RegexOptions.IgnoreCase).Where(w => !string.IsNullOrEmpty(w));
            List<Mapping> mappings = new List<Mapping>();
            foreach (string w in Words)
            {
                Alphabets = w.ToCharArray();

                mappings.Add(new Mapping
                {
                    //cannot use distinct with OrdinalIgnoreCase on character enumerable so creating a new string enumerable
                    NewValue = $"{Alphabets.First()}{Alphabets.Skip(1).SkipLast(1).Select(s => s.ToString()).Distinct(StringComparer.OrdinalIgnoreCase).Count()}{Alphabets.Last()}",
                    OldValue = w
                });
            }
            //Replace the orginal word with the new parsed word and maintian the separation between words
            foreach (Mapping m in mappings)
                parsedWord.Replace(m.OldValue, m.NewValue);

            return parsedWord.ToString();
        }
        #endregion

        #region Properties
        static IEnumerable<string> Words { get; set; }
        static IEnumerable<char> Alphabets { get; set; }
        #endregion
    }


}
