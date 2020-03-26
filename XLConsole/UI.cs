using System;
using System.Text.Json;

namespace XLConsole
{
    public static class UI
    {
        public static string Prompt(string msg, string defaultReturn = "")
        {
            string userInput = "";
            Console.WriteLine(msg);
            userInput = Console.ReadLine().Trim();
            if (userInput == "")
            {
                Console.WriteLine(defaultReturn);
                userInput = defaultReturn;
            }
            return userInput;
        }

        public static void Notify(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
