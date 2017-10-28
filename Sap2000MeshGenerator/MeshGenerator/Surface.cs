using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics.LinearAlgebra;
using MeshGenerator.Interfaces;

namespace MeshGenerator
{
    public class Surface : IHasNodes, IHasLines
    {
        public List<Surface> Holes { get; set; } = new List<Surface>();

        public int MaterialTag { get; set; }

        public PolyLine Boundary { get; set; }

        public bool IsAHole => MaterialTag == -1;

        public IEnumerable<Vector<double>> Nodes
        {
            get
            {
                List<Vector<double>> nodes = new List<Vector<double>>();
                foreach (Line line in Boundary.Lines)
                    nodes.AddRange(line.Nodes);
                foreach (Surface surface in Holes)
                    nodes.AddRange(surface.Nodes);
                return nodes.Distinct();
            }
        }

        public List<Line> Lines
        {
            get
            {
                List<Line> lines = Boundary.Lines;
                foreach (Surface surface in Holes)
                    lines.AddRange(surface.Lines);
                return lines
                    .Distinct()
                    .ToList();
            }
        }
    }
}
