using System.Collections.Generic;

namespace DSLib
{
    public interface IMapDsAndOperations
    {
        IEnumerable<dynamic> GetOperations(DataStructureTypes dataStructure);
    }
}