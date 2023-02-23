using System.Globalization;
using System.Text.RegularExpressions;

namespace StringConsoleAppLibrary
{
    public class StringConsoleApp
    {
        public StringConsoleApp()
        {
        }

        public void Operation(string option)
        {
            Console.WriteLine("Type a string, and then press Enter! ");
            string s = ReadString();
            SwitchOption(option, s); 
        }

        void SwitchOption(string option, string s)
        {
            switch (option)
            {
                case "a":
                    Console.WriteLine("The given string to uppercase is: " + s.ToUpper());
                    break;
                case "b":
                    Console.WriteLine("The given string reversed is: " + ReverseAString(s));
                    break;
                case "c":
                    Console.WriteLine("The given string has: " + NumberOfVowels(s) + " vowels.");
                    break;
                case "d":
                    Console.WriteLine("The given string has "+ ArrayOfWords(s).Length + " words.");
                    break;
                case "e":
                    Console.WriteLine("The string in title case is: " + (new CultureInfo("en-US", false).TextInfo).ToTitleCase(s));
                    break;
                case "f":
                    bool palindrome = IsPalindrome(s);
                    if (palindrome)
                    {
                        Console.WriteLine("The given string is a palindrome");
                    }
                    else Console.WriteLine("The given string is NOT a palindrome");

                    break;
                case "g":
                    string[] r = LongestAndShortestWord(s);
                    Console.WriteLine(String.Format("The longest word in the string is: {0}, and the shorter is: {1} ", r[0],  r[1]));
                    break;
                case "h":
                    Console.WriteLine("The most frequent word in the string is: " + MostFrequentWord(s));
                    break;
                case "z":
                    Console.WriteLine("Enter the operations you want to perform: ");
                    string operations = ReadString();
                    
                    foreach (var item in operations.Trim())
                    {
                        SwitchOption(item.ToString(), s);
                    }

                    break;
                case "q":
                    bool valid = IsValidName(s);
                    if (valid)
                    {
                        Console.WriteLine("The given string is a valid name");
                    }
                    else Console.WriteLine("The given string is NOT a valid name");

                    break;
                case "x":
                    break;

                default:
                    break;
            }
        }

        /*checks if a string has the format for a valid name
         * returns: bool
         */
        private static bool IsValidName(string s)
        {
            bool valid = false;
            try
            {
                valid = Regex.IsMatch(s, (@"^([A-Z][a-z]{1,29}$"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return valid;
            
        }

        public string ReadString()
        {
            string s = "";
            try
            {
                while (true)
                {
                    s = Console.ReadLine();
                    if (s != null) break;
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            return s;
        }

        /* reverse a given string
         * string s - the given string
         * return: - the string reversed
         */
        private static string ReverseAString(string s)
        {
            string reversedString = String.Empty;
            try
            {
                char[] array = s.ToCharArray();
                for (int i = array.Length - 1; i >= 0; i--)
                {
                    reversedString += array[i];
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return reversedString;
        }

        /*counts the number of vowels in a given string
         * string s - the given string
         * return: - the number of vowels
         */
        private static int NumberOfVowels(string s)
        {
            int numberOfVowels = 0;
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
            try
            {
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
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);     
            }
       
            return numberOfVowels;
        }

        /* counts the number of words in a given string
         * string s - the given string
         * return: - the number of vowels
         */
        static int NumberOfWords(string s)
        {
            int numberOfWords = 0;
            try
            {
                for (int i = 0; i < s.Length - 1; i++)
                {
                    if ((s[i] == ' ') & (s[i + 1] == ' '))
                    {
                        i++;
                    }
                    else if ((i != 0) & (s[i] == ' '))
                    {
                        numberOfWords++;
                    }
                }
                numberOfWords++;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            return numberOfWords;
        }

        static bool IsPalindrome2(string s)
        {
            //string s = ReadString();
            bool palindrome = true;
            int j = s.Length - 1;
            for (int i = 0; i < s.Length / 2;  i++)
            {
                if (s[i] != s[j])
                {
                    palindrome = false;
                }
                j--;
            }
            
            return palindrome;
        }

        /*checks if a given string is a palindrome or not
         * returns: bool (true or false)
         */
        private static bool IsPalindrome(string s)
        {
            string[] words = s.Trim().Split(' ');
            string str = String.Empty;
            string reversed = String.Empty;
            bool palindrome = true;
            try
            {
                for (int i = 0; i < words.Length; i++)
                {
                    str = str + words[i];
                }
                reversed = ReverseAString(str);

                if (str != reversed)
                {
                    palindrome = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            return palindrome;
        }

        /*determines the longest and the shortest word in a given string
         * string s: the given string
         * returns: an array with two values: [longest word, shortest word]
         */
        private static string[] LongestAndShortestWord(string s)
        {
            string[] words = ArrayOfWords(s);
            string longest = String.Empty;
            string shortest = s;
            try
            {
                foreach (var item in words)
                {
                    if (item.Length > longest.Length)
                    {
                        longest = item;
                    }
                    if (item.Length < shortest.Length)
                    {
                        shortest = item;
                    }
                }   
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            string[] result = { longest, shortest };
            return result;
        }

        /*creates an array with the words from the given string
         * string s: the given string
         * return: an array with the words
         */
        private static string[] ArrayOfWords(string s)
        {
            string[] words = s.Split(' ');
            
            return words;
        }

        /*determines the most frequent word in a given string
         * string s: the given string
         * returns: string 
         */
        private string MostFrequentWord(string s)
        {
            var results = s.Split(' ')
                              .GroupBy(x => x)
                              .Select(x => new { Count = x.Count(), Word = x.Key })
                              .OrderByDescending(x => x.Count);
            return results.First().Word;
        }
    }
}