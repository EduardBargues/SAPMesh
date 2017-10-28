using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;
using MeshGenerator.Interfaces;

namespace MeshGenerator
{
    public class PolyLine : IHasNodes, IHasLines
    {
        public List<Line> Lines { get; set; } = new List<Line>();
        public IEnumerable<Vector<double>> Nodes
        {
            get
            {
                return Lines
                    .SelectMany(line => line.Nodes)
                    .Distinct();
            }
        }

        public PolyLine(List<Vector<double>> nodes)
        {
            for (int index = 0; index < nodes.Count - 1; index++)
                Lines.Add(new Line
                {
                    StartNode = nodes[index],
                    EndNode = nodes[index + 1]
                });
        }
        public PolyLine(List<Line> lines)
        {
            Lines = lines;
        }
        public PolyLine()
        {
            
        }
    }
}
