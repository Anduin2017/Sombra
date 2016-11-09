using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infiltratense.Service
{
    public static class Logger
    {
        public static void Print(string Content)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(Content);
        }
        public static void PrintInfo(string Content)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(Content);
            Console.ForegroundColor = ConsoleColor.Blue;
        }
        public static void PrintWarning(string Content)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(Content);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void PrintError(string Content)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(Content);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void PrintSuccess(string Content)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(Content);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
