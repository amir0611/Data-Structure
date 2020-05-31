using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace ConsoleUI.ConsoleIOInterface
{
    /// <summary>
    /// Provides utility methods to format the console output display.
    /// </summary>
    [ExcludeFromCodeCoverage]
    internal static class ConsoleDisplayFormatter
    {
        private const int TableWidth = 77;

        public static void PrintLine()
        {
            Console.WriteLine(new string('-', TableWidth));
        }

        public static void PrintRow(params string[] columns)
        {
            int width = (TableWidth - columns.Length) / columns.Length;
            string row = columns.Aggregate("|", (current, column) => current + (AlignCentre(column, width) + "|"));

            Console.WriteLine(row);
        }

        private static string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            return string.IsNullOrEmpty(text)
                ? new string(' ', width)
                : text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
        }
    }
}