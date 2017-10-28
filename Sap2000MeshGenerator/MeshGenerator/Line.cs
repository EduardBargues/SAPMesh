using System.Collections.Generic;
using MathNet.Numerics.LinearAlgebra;
using MeshGenerator.Interfaces;

namespace MeshGenerator
{
    public class Line : IHasNodes
    {
        public Vector<double> StartNode { get; set; }
        public Vector<double> EndNode { get; set; }

        public IEnumerable<Vector<double>> Nodes => new Vector<double>[2] {StartNode, EndNode};

        public Line()
        {
            
        }

        public Line(Vector<double> startPoint, Vector<double> endPoint)
        {
            StartNode = startPoint;
            EndNode = endPoint;
        }
    }
}
