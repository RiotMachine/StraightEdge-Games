using System;

namespace StraightEdge.Games
{
    public class HiLo : Game
    {
        public const int DefaultMin = 1;
        public const int DefaultMax = 100;
        public const int DefaultGuesses = 7;

        private readonly int _target;

        public HiLo(int min, int max, int guesses) : base("Hi-Lo")
        {
            Min = min;
            Max = max;
            GuessesRemaining = guesses;
            _target = Random.Shared.Next(min, max+1);
        }
        public HiLo(int guesses) : this(DefaultMin, DefaultMax, guesses) {}
        public HiLo()            : this(DefaultMin, DefaultMax, DefaultGuesses) {}

        public int Min              { get; init; }
        public int Max              { get; init; }
        public int GuessesRemaining { get; private set; }


        public override void PrintWelcome()
        {
            Console.WriteLine(
                $"Welcome to {Name}. Guess the number between {Min} and {Max}.\n"
            );
        }

        public override void Play()
        {
            while (GuessesRemaining > 0)
            {
                Console.Write($"You have {GuessesRemaining} guesses left. ");
                int guess = Helper.GetInt("Input a number: ");
                if (guess > _target)
                    Console.WriteLine("Too high.");
                else if (guess < _target)
                    Console.WriteLine("Too low.");
                else
                {
                    Won = true;
                    break;
                }
                --GuessesRemaining;
            }
            Console.WriteLine("");
        }

        public override void PrintResult()
        {
            if (Won)
                Console.Write("You win! ");
            else
                Console.Write("You lose. ");
            Console.WriteLine($"The number was {_target}.");
        }
    }
}