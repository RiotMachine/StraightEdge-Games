using System.Collections.Generic
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


        public Game(int guesses, string word=getWord()) : base(guesses)
        {
            _word = word;
            GuessedLetters = new List<char>;
            UncoveredWord = new char[word.length];
            Array.Fill(UncoveredWord, Underscore);
            GuessesRemaining = guesses;
        }
        public Game(string word) : this(DefaultGuesses, word) {}
        public Game()            : this(DefaultGuesses) {}
            
            
        public List<char> GuessedLetters { get; private set; }
        public char[] UncoveredWord      { get; private set; }
        public int GuessesRemaining      { get; private set; }
        
        
        public override void Play()
        {
            while (GuessesRemaining > 0)
            {
                if (Guess())
                {
                    if (UncoveredWord.Contains(Underline))
                        continue;
                    Won = true;
                    break;
                }
                --GuessesRemaining;
            }
        }
        
        
        private static string getWord { return Wordbank[Random.Shared.Next(0, Wordbank.Length)]; }        

        private bool Guess()
        {
            Console.WriteLine(
                $"Word: {new string(UncoveredWord)}\tGuesses: {new string(GuessedLetters)}"
            );
            return Check(Helper.GetChar("Enter a guess: "));
        }

        private void Check(char c)
        {
            bool inWord = false;
            for (int i=0; i < _word.Length; ++i)
            {
                if (in_word[i] == c)
                {
                    inWord = true;
                    UncoveredWord[i] = c;
                }
            }
            if (!inWord)
                wrongGuesses.add(c);
            return inWord;
        }
    }
}