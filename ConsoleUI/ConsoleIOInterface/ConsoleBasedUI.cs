using System;
using System.Collections.Generic;
using DSLib;

namespace ConsoleUI.ConsoleIOInterface
{
    internal sealed class ConsoleBasedUI : IUserInterface
    {
        public object GetEnumBasedInputByUser(Type enumType)
        {
            var maxAllowedValue = Enum.GetNames(enumType).Length;

            int userInput = GetIntegerUserInput(maxAllowedValue);

            return Enum.Parse(enumType, Enum.GetName(enumType, userInput) ?? throw new InvalidOperationException());
        }

        public IEnumerable<string> GetListOfStringsByUser(string message)
        {
            var userInputs = new List<string>();
            char more;

            do
            {
                userInputs.Add(GetSingleStringByUser(message));

                Console.WriteLine("Do you want to provide more data? Y/N");
                more = Convert.ToChar(Console.ReadLine() ?? throw new InvalidOperationException());

            } while (more == 'y' || more == 'Y');

            return userInputs;
        }

        public string GetSingleStringByUser(string message)
        {
            string input;
            do
            {
                Console.Write(message);
                input = Console.ReadLine();

                if (!IsValidStringInput(input))
                {
                    Console.WriteLine("\nPlease enter a valid value.");
                }
            } while (!IsValidStringInput(input));

            return input;
        }

        public IEnumerable<string> GetFixedLengthListOfStringsByUser(ushort fixedLength,
            params string[] messages)
        {
            var userInputs = new List<string>();

            for (int i = 0; i < fixedLength; i++)
            {
                userInputs.Add(GetSingleStringByUser(messages[i]));
            }

            return userInputs;
        }

        public void DisplayResultMessage(bool output, string msg1, string msg2)
        {
            Console.WriteLine(output ? msg1 : msg2);
        }

        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void DisplaySinglyListTraverse(dynamic output)
        {
            foreach (string item in output)
            {
                Console.Write($"{item}-->");
            }

            Console.Write("NULL\n\n\n");
        }

        private static int GetIntegerUserInput(int maxAllowedValue)
        {
            int userInput = 0;

            do
            {
                Console.Write("Enter : ");
                try
                {
                    userInput = Convert.ToUInt16(Console.ReadLine());
                }
                catch (FormatException)
                {
                    PromptErrorMessage("Input in Wrong format.");
                    continue;
                }
                catch (OverflowException)
                {
                    PromptErrorMessage("Input out of range.");
                    continue;
                }

                if (IsValidEnumInput(userInput, maxAllowedValue))
                {
                    PromptErrorMessage("Only above options are valid.");
                }
            } while (IsValidEnumInput(userInput, maxAllowedValue));

            return userInput;
        }

        private static bool IsValidEnumInput(int input, int range) => input <= 0 || input > range;

        private static bool IsValidStringInput(string input) => !string.IsNullOrEmpty(input);

        private static void PromptErrorMessage(string extraMessage) =>
            Console.WriteLine($"{extraMessage}\nPlease enter correct choice!");
    }
}