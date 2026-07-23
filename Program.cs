using System;

namespace Games
{
    public class Program
    {
        public static void Play(Game game)
        {
            Console.WriteLine($"Welcome to {game.Name}.\n");
            game.Play();
            game.PrintResult();
        }    
        
        public static void Main(string[] args)
        {
            Game game = OptionClass.GetOption().Init();
            Console.WriteLine("");
            Play(game);
        }
    }
}