using System.Collections.Immutable;
using Wordbank = ImmutableArray<string>;

namespace StraightEdge.Library
{
    public static class Dictionary
    {
        public enum Theme
        {
            Fruit,
            Vegetable
        }

        internal static readonly ImmutableArray<Theme> Themes = (
            Enum.GetValues<Theme>().ToImmutableArray()
        );

        internal static Theme GetTheme()
        {
            Console.WriteLine("Themes:");
            for(int i=0; i < Options.Length; ++i)
                Console.WriteLine($"{i+1}: {Options[i]}");

            while (true)
            {
                int choice = Helper.GetInt("Enter a selection: ") - 1;
                if (choice < 0 || choice >= Options.Length)
                    Console.WriteLine("Invalid selection.");
                else
                    return Themes[choice];
            }
        }

        internal static Wordbank GetWordbank(Theme t) =>
        {
            Theme.Fruit     => Fruits,
            Theme.Vegetable => Vegetables
        };

        public static string GetWord(this Theme t)
        {
            return GetWordbank(t)[Random.Shared.Next(w.Length)]
        }

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
    }
}