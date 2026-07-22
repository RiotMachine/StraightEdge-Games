using System;

namespace Games
{
    public class Helper
    {
        public static char GetChar(string msg="")
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
            return input[0];
        }
    }
}