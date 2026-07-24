using System.Collections.Frozen;
using System.Collections.Immutable;

namespace StraightEdge.Games.Library
{
    using Wordbank = ImmutableArray<string>;
    using TableOfContents = FrozenDictionary<Dictionary.Theme, ImmutableArray<string>>;

    public static class Dictionary
    {
        public static readonly Wordbank Fruits = [
            "apple",
            "avocado",
            "banana",
            "blueberry",
            "grape",
            "mango",
            "peach",
            "pineapple",
            "strawberry",
            "watermelon"
        ];

        public static readonly Wordbank Vegetables = [
            "broccoli",
            "carrot",
            "cucumber",
            "garlic",
            "lettuce",
            "onion",
            "potato",
            "spinach"
        ];

        private static readonly TableOfContents TOC = new[] {
            KeyValuePair.Create(Theme.Fruit, Fruits),
            KeyValuePair.Create(Theme.Vegetable, Vegetables)
        }.ToFrozenDictionary();

        private static readonly ImmutableArray<Theme> Themes = (
            Enum.GetValues<Theme>().ToImmutableArray()
        );

        internal enum Theme
        {
            Fruit,
            Vegetable
        }

        internal static string GetWord(Theme t)
        {
            Wordbank w = TOC[t];
            return w[Random.Shared.Next(w.Length)];
        }

        internal static Theme PickTheme()
        {
            Console.WriteLine("Themes:");
            for (int i=0; i < Themes.Length; ++i)
                Console.WriteLine($"{i+1}: {Themes[i]}");

            while (true)
            {
                int choice = Helper.GetInt("Enter a selection: ") - 1;
                if (choice < 0 || choice >= Themes.Length)
                    Console.WriteLine("Invalid selection.");
                else
                    return Themes[choice];
            }
        }
    }
}