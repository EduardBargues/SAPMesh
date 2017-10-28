using netDxf;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using MeshGenerator;
using netDxf.Entities;
using netDxf.Header;
using netDxf.Tables;
using Sap2000MeshGenerator;
using Line = netDxf.Entities.Line;
using System.IO;

namespace FileManager
{
    public class DxfManager
    {
        public static DxfModel GetDxfModel(DxfDocument doc, string framesLayer, string shellsLayer)
        {
            return new DxfModel
            {
                Lines = doc.Lines
                    .Where(line => line.Layer.Name == framesLayer)
                    .Select(l => new MeshGenerator.Line(new DenseVector(2) { [0] = l.StartPoint.X, [1] = l.StartPoint.Y },
                        new DenseVector(2) { [0] = l.EndPoint.X, [1] = l.EndPoint.Y }))
                    .ToList(),
                Polylines = doc.LwPolylines
                    .Where(lwPol => lwPol.Layer.Name == shellsLayer)
                    .Select(lwPol => new PolyLine(lwPol.Vertexes
                        .Select(t => new DenseVector(2) { [0] = t.Position.X, [1] = t.Position.Y })
                        .Cast<Vector<double>>()
                        .ToList()))
                    .ToList()
            };
        }

        public static void CreateDxfFile(string path, List<int[]> elements, Dictionary<int, double[]> points)
        {
            DxfDocument doc = new DxfDocument(DxfVersion.AutoCad2010);
            Layer layerShells = new Layer("SHELLS");
            Layer layerFrames = new Layer("FRAMES");

            foreach (int[] element in elements)
            {
                double[] firstNode = points[element[0]];
                double[] secondNode = points[element[1]];
                Vector3 firstVertex = new Vector3(firstNode[0], firstNode[1], firstNode[2]);
                Vector3 secondVertex = new Vector3(secondNode[0], secondNode[1], secondNode[2]);

                if (element.Length == 2) // LINE
                {
                    Line line = new Line(firstVertex, secondVertex)
                    {
                        Layer = layerFrames
                    };
                    doc.AddEntity(line);
                }
                else
                {
                    double[] thirdNode = points[element[2]];
                    double[] fourthNode = element.Length == 4
                        ? points[element[3]]
                        : points[element[0]];

                    Face3d face = new Face3d
                    {
                        FirstVertex = firstVertex,
                        SecondVertex = secondVertex,
                        ThirdVertex = new Vector3(thirdNode[0], thirdNode[1], thirdNode[2]),
                        FourthVertex = new Vector3(fourthNode[0], fourthNode[1], fourthNode[2]),
                        Layer = layerShells,
                    };

                    doc.AddEntity(face);
                }
            }

            File.Delete(path);
            doc.Save(path);
        }
    }
}
