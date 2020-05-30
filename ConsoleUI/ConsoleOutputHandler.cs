using System;
using DSLib;

namespace ConsoleUI
{
    internal sealed class ConsoleOutputHandler : IHandleOutput
    {
        public void HandleOutput(DataStructureTypes selectedDataStructure, dynamic operation, dynamic output)
        {
            switch (selectedDataStructure)
            {
                case DataStructureTypes.Array:
                    break;
                case DataStructureTypes.SinglyLinkedList:
                case DataStructureTypes.DoublyLinkedList:
                case DataStructureTypes.CircularLinkedList:
                    HandleLinkedList(selectedDataStructure, operation, output);
                    break;
                case DataStructureTypes.Stack:
                    break;
                case DataStructureTypes.Queue:
                    break;
                case DataStructureTypes.Tree:
                    break;
                case DataStructureTypes.Graph:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private static void HandleLinkedList(DataStructureTypes dataStructure, dynamic operation, dynamic output)
        {
            var op = (LinkedListOperations)Enum.Parse(typeof(LinkedListOperations),
                        Enum.GetName(typeof(LinkedListOperations), operation) ?? throw new InvalidOperationException());
            switch (op)
            {
                case LinkedListOperations.Create:
                    PromptMessage(output, "Linked List created successfully.", "Creation Failed.");
                    break;
                case LinkedListOperations.Traversal:
                    foreach (string item in output)
                    {
                        Console.Write($"{item}-->");
                    }

                    Console.Write("NULL\n\n\n");
                    break;
                case LinkedListOperations.Find:
                    PromptMessage(output, "Found.", "Not Found.");
                    break;
                case LinkedListOperations.InsertAtFront:
                    PromptMessage(output, "Inserted.", "Insertion Failed.");
                    break;
                case LinkedListOperations.InsertAtLast:
                    PromptMessage(output, "Inserted.", "Insertion Failed.");
                    break;
                case LinkedListOperations.InsertAfter:
                    PromptMessage(output, "Inserted.", "Insertion Failed.");
                    break;
                case LinkedListOperations.InsertBefore:
                    if (dataStructure == DataStructureTypes.SinglyLinkedList)
                    {
                        Console.WriteLine(output);
                    }
                    else
                    {
                        PromptMessage(output, "Inserted.", "Insertion Failed.");
                    }

                    break;
                case LinkedListOperations.DeleteFirst:
                    PromptMessage(output, "Deleted.", "Deletion Failed.");
                    break;
                case LinkedListOperations.DeleteLast:
                    PromptMessage(output, "Deleted.", "Deletion Failed.");
                    break;
                case LinkedListOperations.DeleteSpecific:
                    PromptMessage(output, "Deleted.", "Deletion Failed.");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private static void PromptMessage(dynamic output, string msg1, string msg2)
        {
            Console.WriteLine(output == true ? msg1 : msg2);
        }
    }
}