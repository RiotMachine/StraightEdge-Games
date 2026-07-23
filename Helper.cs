using System;

namespace StraightEdge
{
    public class Helper
    {
        public static string GetLine(string msg="")
        {
            string? input;
            while (true)
            {
                Console.Write(msg);
                input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                    Console.WriteLine("You did not input anything.");
                else
                    break;
            }
            return input;
        }

        public static char GetChar(string msg="")
        {
            return GetLine(msg)[0];
        }

        public static int GetInt(String msg="")
        {
            int x;
            while (!int.TryParse(GetLine(msg), out x))
                Console.WriteLine("That is not an integer.");
            return x;
        }
    }
}