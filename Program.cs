using StraightEdge.Games;
using System;

namespace StraightEdge
{
    public class Program
    {
        public static void Play(Game game)
        {
            game.PrintWelcome();
            game.Play();
            game.PrintResult();
        }    
        
        public static void Main(string[] args)
        {
            Game.Option option = Game.GetOption();
            Console.WriteLine("");
            Play(Game.Init(option));
        }
    }
}