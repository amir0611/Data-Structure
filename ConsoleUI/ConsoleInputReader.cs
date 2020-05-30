using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DSLib;

namespace ConsoleUI
{
    internal sealed class ConsoleInputReader : IReadInput
    {
        private readonly IMapDsAndOperations dsAndOperationsMapper;

        public ConsoleInputReader(IMapDsAndOperations dsAndOperationsMapper)
        {
            this.dsAndOperationsMapper =
                dsAndOperationsMapper ?? throw new ArgumentNullException(nameof(dsAndOperationsMapper));
        }

        public DataStructureTypes GetDataStructureByUser()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            var dataStructuresNames = Enum.GetNames(typeof(DataStructureTypes));

            ShowTabularMenu(Enum.GetValues(typeof(DataStructureTypes)), dataStructuresNames,
                new[] {"Index", "DS Type"});

            ushort selectedDataStructure = GetIntegerUserInput((ushort) dataStructuresNames.Length);

            Console.ResetColor();

            return (DataStructureTypes) Enum.Parse(typeof(DataStructureTypes),
                Enum.GetName(typeof(DataStructureTypes), selectedDataStructure) ??
                throw new InvalidOperationException());
        }

        public ushort GetOperationByUser(DataStructureTypes selectedDataStructure)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkYellow;

            var operations = dsAndOperationsMapper.GetOperations(selectedDataStructure).ToList();

            ShowOperationsMenu(operations);

            ushort selectedOperation = GetIntegerUserInput((ushort) operations.Count);

            Console.ResetColor();

            return selectedOperation;
        }

        public dynamic GetInputDataByUser(DataStructureTypes dataStructure, ushort operation)
        {
            switch (dataStructure)
            {
                case DataStructureTypes.Array:
                    break;
                case DataStructureTypes.SinglyLinkedList:
                case DataStructureTypes.DoublyLinkedList:
                case DataStructureTypes.CircularLinkedList:
                    return GetLinkedListOperationBasedInput(dataStructure, operation);
                case DataStructureTypes.Stack:
                    break;
                case DataStructureTypes.Queue:
                    break;
                case DataStructureTypes.Tree:
                    break;
                case DataStructureTypes.Graph:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(dataStructure), dataStructure, null);
            }

            return null;
        }

        private static dynamic GetLinkedListOperationBasedInput(DataStructureTypes dataStructure, ushort operation)
        {
            var op = (LinkedListOperations) Enum.Parse(typeof(LinkedListOperations),
                Enum.GetName(typeof(LinkedListOperations), operation) ?? throw new InvalidOperationException());
            switch (op)
            {
                case LinkedListOperations.Create:
                    return GetListOfStringsByUser("Enter Data: ");
                case LinkedListOperations.Traversal:
                    break;
                case LinkedListOperations.Find:
                    return GetSingleStringByUser("Enter data to search: ");
                case LinkedListOperations.InsertAtFront:
                case LinkedListOperations.InsertAtLast:
                    return GetSingleStringByUser("Enter new data to add: ");
                case LinkedListOperations.InsertAfter:
                    return GetFixedLengthListOfStringsByUser(2, "Enter new data to add: ",
                        "Enter Data after which new node will be inserted: ");
                case LinkedListOperations.InsertBefore:
                    return dataStructure == DataStructureTypes.SinglyLinkedList
                        ? null
                        : GetFixedLengthListOfStringsByUser(2, "Enter new data to add: ",
                            "Enter Data before which new node will be inserted: ");
                case LinkedListOperations.DeleteFirst:
                    break;
                case LinkedListOperations.DeleteLast:
                    break;
                case LinkedListOperations.DeleteSpecific:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return null;
        }

        private static void ShowTabularMenu(IEnumerable optionValues, IReadOnlyList<string> optionNames,
            string[] columns)
        {
            ConsoleDisplayFormatter.PrintLine();
            ConsoleDisplayFormatter.PrintRow(columns);
            ConsoleDisplayFormatter.PrintLine();

            var index = 0;
            foreach (ushort item in optionValues)
            {
                ConsoleDisplayFormatter.PrintRow(item.ToString(), optionNames[index++]);
            }

            ConsoleDisplayFormatter.PrintLine();
            Console.WriteLine("\nPlease select an option of your choice.\n");
        }

        private static void ShowOperationsMenu(IEnumerable<dynamic> operations)
        {
            Console.WriteLine("\nPossible Operations are:-\n");

            var serialNumber = 1;

            foreach (dynamic item in operations)
            {
                Console.WriteLine($"{serialNumber++}. {item}");
            }

            Console.WriteLine("\nPlease select an operation of your choice.\n");
        }

        private static ushort GetIntegerUserInput(ushort maxAllowedInput)
        {
            ushort userInput = 0;

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

                if (IsInputOutOfRange(userInput, maxAllowedInput))
                {
                    PromptErrorMessage("Only above options are valid.");
                }
            } while (IsInputOutOfRange(userInput, maxAllowedInput));

            return userInput;
        }

        private static IEnumerable<string> GetListOfStringsByUser(string message)
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

        private static IEnumerable<string> GetFixedLengthListOfStringsByUser(ushort fixedLength,
            params string[] messages)
        {
            var userInputs = new List<string>();

            for (int i = 0; i < fixedLength; i++)
            {
                userInputs.Add(GetSingleStringByUser(messages[i]));
            }

            return userInputs;
        }

        private static string GetSingleStringByUser(string message)
        {
            string input;
            do
            {
                Console.Write(message);
                input = Console.ReadLine();

                if (!Valid(input))
                {
                    Console.WriteLine("\nPlease enter a valid value.");
                }
            } while (!Valid(input));

            return input;
        }

        private static bool Valid(string input)
        {
            return !string.IsNullOrEmpty(input);
        }

        private static bool IsInputOutOfRange(int input, int range) => input <= 0 || input > range;

        private static void PromptErrorMessage(string extraMessage) =>
            Console.WriteLine($"{extraMessage}\nPlease enter correct choice!");

    }
}