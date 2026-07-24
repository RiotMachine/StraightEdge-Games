using StraightEdge.Games.Library;
using System.Collections.Generic;
using System.Linq;

// limited to single words without underscores

namespace StraightEdge.Games
{
    public class Hangman : Game
    {
        private const char Underscore = '_';
        public const int DefaultGuesses = 8;


        private readonly string _word;


        public Hangman(string word, int guesses=DefaultGuesses)
            : base("Hangman")
        {
            _word = word;
            GuessesRemaining = guesses;
            WrongGuesses = new List<char>();
            UncoveredWord = new char[word.Length];
            Array.Fill(UncoveredWord, Underscore);
        }
        public Hangman(int guesses) : this(GetWord(), guesses) {}
        public Hangman()            : this(GetWord()) {}
            
            
        public List<char> WrongGuesses { get; private set; }
        public char[] UncoveredWord    { get; private set; }
        public int GuessesRemaining    { get; private set; }


        public override void PrintWelcome()
        {
            Console.WriteLine($"Welcome to {Name}.\n");
        }

        public override void Play()
        {
            while (GuessesRemaining > 0)
            {
                char guess = GetGuess();
                Console.WriteLine("");
                if (Check(guess))
                {
                    if (UncoveredWord.Contains(Underscore))
                        continue;
                    Won = true;
                    break;
                }
                --GuessesRemaining;
            }
        }

        public override void PrintResult()
        {
            if (Won)
                Console.Write("You win! ");
            else
                Console.Write("You lose. ");
            Console.WriteLine($"The word was {_word}.");
        }
 
       
        private static string GetWord()
        {
            Dictionary.Theme theme = Dictionary.PickTheme();
            Console.WriteLine("");
            return Dictionary.GetWord(theme);
        }

        private char GetGuess()
        {
            Console.WriteLine(
                "Word: " + string.Join(" ", UncoveredWord) +
                    "\t\tGuesses: " + new string(WrongGuesses.ToArray()) + 
                    new string('*', GuessesRemaining-1)
            );
            return Helper.GetChar("Enter a guess: ");
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