using System;
using System.Collections.Generic;

namespace DSLib
{
    public interface IUserInterface
    {
        object GetEnumBasedInputByUser(Type enumType);

        IEnumerable<string> GetListOfStringsByUser(string message);

        IEnumerable<string> GetFixedLengthListOfStringsByUser(ushort fixedLength, params string[] messages);

        string GetSingleStringByUser(string message);

        void DisplaySinglyListTraverse(dynamic output);

        void DisplayResultMessage(bool output, string msg1, string msg2);

        void ShowMessage(string message);
    }
}