using System;

namespace DSLib
{
    public interface IPrintMenu
    {
        void ShowEnumBasedTabularMenu(Type enumType, string[] columns);
    }
}