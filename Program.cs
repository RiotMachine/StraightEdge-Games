using System;

namespace Games
{
    public class Program
    {
        
        /*
        public static void Play(Game game)
        {
            Console.WriteLine("Welcome to .");
            game.Play();
            if (game.won)
                Console.WriteLine("You win!");
            else
                Console.WriteLine("You lose.");
        }*/
        
        public static void Main(string[] args)
        {
            //Play( );
            Hangman hangman = new Hangman();
            hangman.Play();
        }
    }
}