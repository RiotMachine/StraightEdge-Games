using System;
using System.Collections.Immutable;

namespace StraightEdge.Games
{
    public abstract class Game
    {
        public string Name { get; }
        public bool Won    { get; protected set; }
        
        protected Game(string name)
        {
            Name = name;
            Won = false;
        }

        public abstract void PrintWelcome();
        public abstract void Play();
        public abstract void PrintResult();
    }

    static class Inventory
    {
        internal enum Option
        {
            Hangman,
            HiLo
        }

        internal static readonly ImmutableArray<Option> Options = (
            Enum.GetValues<Option>().ToImmutableArray()
        );

        internal static Game Init(this Option o) => o switch
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
    }
}