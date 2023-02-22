using StringConsoleAppLibrary;

using System;
using System.Collections.Generic;

namespace StringAppProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the StringConsoleApp");
            Console.WriteLine("============================\n");
            StringConsoleApp stringConsoleApp = new StringConsoleApp();
            runMenu();

            void runMenu()
            {
                bool endApp = false;
                while (!endApp)
                {
                    DisplayMenu();
                    Console.WriteLine("==== Select an option: ==== \n");
                    string option = "";
                    option = Console.ReadLine();                  
                    stringConsoleApp.Operation(option);

                    Console.WriteLine("------------------------\n");
                    if (option == "x") endApp = true;

                    Console.WriteLine("\n"); // Friendly linespacing.
                }
            }
            

            static void DisplayMenu()
            {
                
                Console.WriteLine("==== Select an option: ==== \n");
                Console.WriteLine("a - Convert a string to uppercase");
                Console.WriteLine("b - Reverse a string");
                Console.WriteLine("c - Count the number of vowels in a string");
                Console.WriteLine("d - Count the number of words in a string");
                Console.WriteLine("e - Convert a string to title case");

                Console.WriteLine("x - Quit");
            }
		}
    }
}