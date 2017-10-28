using System.Collections.Generic;

namespace MeshGenerator.Interfaces
{
    public interface IHasLines
    {
        List<Line> Lines { get; } 
    }
}