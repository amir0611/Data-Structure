using System;

namespace DSLib.Operators
{
    internal abstract class BaseOperator<TDataType>
    {
        protected readonly IUserInterface userInterface;
        protected readonly IDataStructure<TDataType> dataStructure;

        protected BaseOperator(IUserInterface userInterface, IDataStructure<TDataType> dataStructure)
        {
            this.dataStructure = dataStructure ?? throw new ArgumentNullException(nameof(dataStructure));
            this.userInterface = userInterface ?? throw new ArgumentNullException(nameof(userInterface));
        }
    }
}