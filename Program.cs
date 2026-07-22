using System;

namespace Games
{
    public class Program
    {
        public enum Option
        {
            Hangman,
            HiLo
        }

        public static Game InitGame(Option o)
        

        private static Option ChooseGame()
        {
            for (int
            
            return
            {


            }
        }

        public static void Play(Game game)
        {
            Console.WriteLine($"Welcome to {game.Name}.\n");
            game.Play();
            game.PrintResult();
        }    
        
        public static void Main(string[] args)
        {
            Play(ChooseGame());
        }
    }
}