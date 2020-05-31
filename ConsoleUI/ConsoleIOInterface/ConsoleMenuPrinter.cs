using System;
using DSLib;

namespace ConsoleUI.ConsoleIOInterface
{
    internal sealed class ConsoleMenuPrinter : IPrintMenu
    {
        public void ShowEnumBasedTabularMenu(Type enumType, string[] columns)
        {
            Array enumValues = Enum.GetValues(enumType);
            string[] enumNames = Enum.GetNames(enumType);

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            ConsoleDisplayFormatter.PrintLine();
            ConsoleDisplayFormatter.PrintRow(columns);
            ConsoleDisplayFormatter.PrintLine();

            var index = 0;
            foreach (ushort item in enumValues)
            {
                ConsoleDisplayFormatter.PrintRow(item.ToString(), enumNames[index++]);
            }

            ConsoleDisplayFormatter.PrintLine();
            Console.WriteLine("\nPlease select an option of your choice.\n");

            Console.ResetColor();
        }
    }
}