using System;
using System.Collections.Immutable;

namespace StraightEdge.Games
{
    public abstract class Game
    {
        private static readonly ImmutableArray<Option> Options = (
            Enum.GetValues<Option>().ToImmutableArray()
        );
        
        protected Game(string name)
        {
            Name = name;
            Won = false;
        }

        internal enum Option
        {
            Hangman,
            HiLo
        }

        protected string Name { get; init; }
        protected bool Won    { get; set; }

        internal static Game Init(Option o) => o switch
        {
            Option.Hangman => new Hangman(),
            Option.HiLo    => new HiLo()
        };

        internal static Option GetOption()
        {
            Console.WriteLine("Options:");
            for(int i=0; i < Options.Length; ++i)
                Console.WriteLine($"{i+1}: {Options[i]}");

            while (true)
            {
                int choice = Helper.GetInt("Enter a selection: ") - 1;
                if (choice < 0 || choice >= Options.Length)
                    Console.WriteLine("Invalid selection.");
                else
                    return Options[choice];
            }
        }

        public abstract void PrintWelcome();
        public abstract void Play();
        public abstract void PrintResult();
    }
}