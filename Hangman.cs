using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

// limited to single words without underscores

namespace Games
{
    public class Hangman : Game
    {
        private static readonly ImmutableArray<string> Wordbank = ImmutableArray.Create(
            "broccoli",
            "carrot",
            "cucumber",
            "garlic",
            "lettuce",
            "onion",
            "potato",
            "spinach"
        );
        private const char Underscore = '_';
        public const int DefaultGuesses = 8;


        private readonly string _word;


        public Hangman(string word, int guesses=DefaultGuesses) : base(guesses)
        {
            _word = word;
            WrongGuesses = new List<char>();
            UncoveredWord = new char[word.Length];
            Array.Fill(UncoveredWord, Underscore);
            GuessesRemaining = guesses;
        }
        public Hangman(int guesses) : this(getWord(), guesses) {}
        public Hangman()            : this(getWord()) {}
            
            
        public List<char> WrongGuesses { get; private set; }
        public char[] UncoveredWord    { get; private set; }
        public int GuessesRemaining    { get; private set; }
        
        
        public override void Play()
        {
            while (GuessesRemaining > 0)
            {
                Console.WriteLine("");
                if (Guess())
                {
                    if (UncoveredWord.Contains(Underscore))
                        continue;
                    Won = true;
                    break;
                }
                --GuessesRemaining;
            }
        }
        
        
        private static string getWord()
        {
            return Wordbank[Random.Shared.Next(0, Wordbank.Length)];
        }

        private bool Guess()
        {
            Console.WriteLine(
                $"Word: {string.Join(" ", UncoveredWord)}\t\t" +
                    "Guesses: " + string.Join("", WrongGuesses) + 
                    new string('*', GuessesRemaining)
            );
            return Check(
                Helper.GetChar("Enter a guess: ")
            );
        }

        private bool Check(char c)
        {
            c = char.ToLower(c);
            bool inWord = false;
            for (int i=0; i < _word.Length; ++i)
            {
                if (_word[i] == c)
                {
                    inWord = true;
                    UncoveredWord[i] = c;
                }
            }
            if (!inWord)
                WrongGuesses.Add(c);
            return inWord;
        }
    }
}