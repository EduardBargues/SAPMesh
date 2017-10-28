using System.Collections.Generic;
using MathNet.Numerics.LinearAlgebra;

namespace MeshGenerator.Interfaces
{
    public interface IHasNodes
    {
        IEnumerable<Vector<double>> Nodes { get; } 
    }
}
