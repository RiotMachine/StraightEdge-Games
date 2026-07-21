using System;

namespace Games
{
    public class Helper
    {
        public static char GetChar(string msg="")
        {
            Console.Write(msg);
            return Console.ReadLine()[0];
        }
    }
}