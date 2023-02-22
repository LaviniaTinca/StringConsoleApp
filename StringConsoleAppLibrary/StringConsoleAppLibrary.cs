using System.Diagnostics;
using System.Globalization;

namespace StringConsoleAppLibrary
{
    public class StringConsoleApp
    {
        public StringConsoleApp()
        {
            StreamWriter logFile = File.CreateText("stringConsoleApp.log");
            Trace.Listeners.Add(new TextWriterTraceListener(logFile));
            Trace.AutoFlush = true;
            Trace.WriteLine("Starting StringConsoleApp Log");
            Trace.WriteLine(String.Format("Started {0}", System.DateTime.Now.ToString()));
        }

        public string Operation(string option)
        {
            string result = "";
            int res = 0;
            switch (option)
            {
                case "a":
                    result = convertStringToUppercase();
                    Console.WriteLine(result);  
                    break;
                case "b":
                    result = reverseAString();
                    Console.WriteLine(result);
                    break;
                case "c":
                    res = numberOfVowels();
                    Console.WriteLine(res);
                    Trace.WriteLine(String.Format("the given string has {0} vowels!", res));
                    break;
                case "d":
                    //Count the number of words in a string
                    res = numberOfWords();
                    Console.WriteLine(res);
                    Trace.WriteLine(String.Format("the given string has {0} words!", res));
                    break;
                case "e":
                    // Convert a string to title case
                    string s = ReadString();
                    result = convertStringToTitleCase(s);
                    //Trace.WriteLine(String.Format("The string {0} converted to Title Case is: {1} ", s, result));
                    Console.WriteLine(result);
                    break;
                case "x":
                    break;
                // Return text for an incorrect option entry.
                default:
                    Console.WriteLine("Incorrect Option. Please retry!");
                    break;
            }
            return result;
        }

        static string ReadString()
        {
            Console.WriteLine("Type a string, and then press Enter: ");
            string result = "";
            result = Console.ReadLine();
            return result;
        }

        string convertStringToUppercase()
        {
            string s = ReadString();
           
            return s.ToUpper();
        }

        string reverseAString()
        {
            string s = ReadString();
            string reversedString = String.Empty;
            char[] array = s.ToCharArray();
            for (int i = array.Length - 1; i >= 0; i--)
            {
                reversedString += array[i];
            }

            //return (string) s.Reverse();
            return reversedString;
        }

        int numberOfVowels()
        {
            string s = ReadString();
            int numberOfVowels = 0;
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
            for (int i = 0; i < s.Length; i++)
            {
                foreach (var item in vowels)
                {
                    if (s[i] == item)
                    {
                        numberOfVowels++;
                    }
                }
            }
            return numberOfVowels;
        }

        int numberOfWords()
        {
            string s = ReadString();
            int numberOfWords = 0;
            for (int i = 0; i < s.Length-1; i++)
            {
                if ((s[i] == ' ') & (s[i+1] == ' '))
                {
                    i++;
                }
                else if ((i!=0) & (s[i] == ' '))
                {
                    numberOfWords++;
                }                        
            }
            numberOfWords++;
            return numberOfWords;
        }

        string convertStringToTitleCase(string s)
        {
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

            return textInfo.ToTitleCase(s);
        }
    }
}