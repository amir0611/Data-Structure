namespace DSLib.DataStructures
{
    public abstract class BaseNode<TDataType>
    {
        public TDataType Data { get; }

        protected BaseNode(TDataType data)
        {
            Data = data;
        }
    }
}