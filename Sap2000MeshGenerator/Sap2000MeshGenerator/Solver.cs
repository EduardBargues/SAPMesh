using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManager;
using GeometryManager;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using MeshGenerator;

namespace Sap2000MeshGenerator
{
    public static class Solver
    {
        public static Model GetMeshModel(DxfModel model)
        {
            Model output = new Model();

            
            List<PolyLine> polylinesOutside = model.Polylines
                .Where(pol => pol.Nodes
                              .Any(node => model.Polylines
                                          .Where(polyline => polyline != pol)
                                          .All(polyline => !GeometrySolver.IsPointInside(node, polyline.Nodes.ToList()))))
                .ToList();

            foreach (PolyLine polyLine in polylinesOutside)
            {
                Surface surface = new Surface();

                List<Vector<double>> nodes = polyLine.Nodes
                    .Select(node => new DenseVector(3) { [0] = node[0], [1] = node[1] })
                    .Cast<Vector<double>>()
                    .ToList();
                nodes.Add(nodes.First());
                PolyLine boundary = new PolyLine(nodes);

                surface.Boundary = boundary;

                List<PolyLine> polyLinesHoles = model.Polylines
                    .Where(pol => pol != polyLine &&
                                  pol.Nodes.Any(node => GeometrySolver.IsPointInside(node, polyLine.Nodes.ToList())))
                    .ToList();

                foreach (PolyLine pol in polyLinesHoles)
                {
                    List<Vector<double>> holeNodes = pol.Nodes
                        .Select(node => new DenseVector(3) { [0] = node[0], [1] = node[1] })
                        .Cast<Vector<double>>()
                        .ToList();
                    holeNodes.Add(holeNodes.First());
                    Surface hole = new Surface { Boundary = new PolyLine(holeNodes) };
                    surface.Holes.Add(hole);
                }

                output.Surfaces.Add(surface);
            }

            return output;
        }
    }
}
