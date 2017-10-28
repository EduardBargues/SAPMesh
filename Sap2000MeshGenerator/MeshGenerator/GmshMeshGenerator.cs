using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using MeshGenerator.Interfaces;
using Sap2000MeshGenerator;

namespace MeshGenerator
{
    public class GmshMeshGenerator : IMeshGenerator
    {
        //FIELDS
        private readonly string gmshExecutionPath;
        private string commentTag = "//";
        private int meshOrder = 2;

        // CONSTRUCTORS
        public GmshMeshGenerator(string path)
        {
            gmshExecutionPath = path;
        }
        
        // METHODS
        public Mesh GenerateMesh(IPhysicalModel model, MeshProperties props)
        {
            Mesh mesh = null;

            FileInfo fileInfo = new FileInfo(gmshExecutionPath);
            if (fileInfo.Exists)
            {
                DateTime now = DateTime.Now;
                string prefix = $"{now.Year}-{now.Month}-{now.Day}--{now.Hour}-{now.Minute}-{now.Second}-{now.Millisecond}";
                string geometryFile = Path.Combine(fileInfo.DirectoryName, $"{prefix}.geo");
                string meshFile = Path.Combine(fileInfo.DirectoryName, $"{prefix}.msh");
                GenerateGeometryFile(geometryFile, model.GetSurfaces(), props);
                ExecuteGmsh(geometryFile, meshFile);
                mesh = ReadMeshFile(meshFile);
            }

            return mesh;
        }

        private void GenerateGeometryFile(string path, List<Surface> surfaces, MeshProperties props)
        {
            int count = 0;
            using (TextWriter tw = File.CreateText(path))
            {
                WriteComment(tw, "NODES");
                Dictionary<Vector<double>, int> nodes = surfaces
                    .SelectMany(s => s.Nodes)
                    .Distinct()
                    .ToDictionary(node => node, node => count++);
                foreach (Vector<double> p in nodes.Keys)
                    WriteLine(tw, GetDefinitionString("Point", nodes[p], new List<string>
                    {
                        Convert.ToString(p[0], CultureInfo.InvariantCulture),
                        Convert.ToString(p[1], CultureInfo.InvariantCulture),
                        Convert.ToString(p[2], CultureInfo.InvariantCulture),
                        Convert.ToString(props.Size, CultureInfo.InvariantCulture)
                    }));

                count = 0;
                WriteComment(tw, "LINES");
                Dictionary<Line, int> lines = surfaces
                .SelectMany(s => s.Lines)
                .ToDictionary(node => node, node => count++);
                foreach (Line line in lines.Keys)
                    WriteLine(tw, GetDefinitionString("Line", lines[line], new List<string>
                    {
                        Convert.ToString(nodes[line.StartNode], CultureInfo.InvariantCulture),
                        Convert.ToString(nodes[line.EndNode], CultureInfo.InvariantCulture)
                    }));

                WriteComment(tw, "SURFACES");
                count = 0;
                foreach (Surface surface in surfaces)
                {
                    List<string> lineTags = new List<string> { Convert.ToString(count, CultureInfo.InvariantCulture) };
                    WriteLine(tw, GetDefinitionString("Line Loop", count, surface.Lines.Select(l => Convert.ToString(lines[l], CultureInfo.InvariantCulture))));
                    WriteLine(tw, GetDefinitionString("Plane Surface", count, lineTags));
                    WriteLine(tw, GetDefinitionString("Physical Surface", count, lineTags));
                    if (props.Type == MeshType.Quadrangular)
                        WriteLine(tw, GetCommandString("Recombine Surface", lineTags));
                    count++;
                }
                tw.Flush();
                tw.Close();
            }
        }

        private void ExecuteGmsh(string geometryFile, string meshFile)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = gmshExecutionPath,
                Arguments = $"\"{gmshExecutionPath}\" \"{geometryFile}\" -{meshOrder} -o \"{meshFile}\""
            });
        }

        private Mesh ReadMeshFile(string path)
        {
            Thread.Sleep(5000); // TODO: improve this. file is read before gmsh has finnished.
            Mesh mesh = new Mesh();
            using (TextReader tr = new StreamReader(path))
            {
                string text = tr.ReadToEnd();
                int label = 1;
                mesh.Points = Read(text, "$Nodes", "$EndNodes")
                    .Select(str => new DenseVector(3)
                    {
                        [0] = Convert.ToDouble(str[1], CultureInfo.InvariantCulture),
                        [1] = Convert.ToDouble(str[2], CultureInfo.InvariantCulture),
                        [2] = Convert.ToDouble(str[3], CultureInfo.InvariantCulture)
                    })
                    .ToDictionary(vector => label++,
                                  vector => (Vector<double>)vector);
                mesh.Connectivities = Read(text, "$Elements", "$EndElements")
                    .Select(str =>
                    {
                        int nodesFirstIndex = 3 + Convert.ToInt32(str[2], CultureInfo.InvariantCulture);
                        return new Connectivity
                        {
                            Points = str.GetRange(nodesFirstIndex, str.Count - nodesFirstIndex)
                            .Select(s => Convert.ToInt32(s, CultureInfo.InvariantCulture))
                            .ToArray(),
                            MaterialTag = Convert.ToInt32(str[3], CultureInfo.InvariantCulture)
                        };
                    })
                    .ToArray();
                tr.Close();
            }

            return mesh;
        }

        private List<List<string>> Read(string text, string keyWord1, string keyWord2)
        {
            List<List<string>> output = null;
            int index1 = text.IndexOf(keyWord1, StringComparison.InvariantCulture) + keyWord1.Length;
            int index2 = text.IndexOf(keyWord2, StringComparison.InvariantCulture);

            string[] strings = text.Substring(index1, index2 - index1)
                .Split(Environment.NewLine.ToCharArray())
                .Where(str => !string.IsNullOrEmpty(str))
                .ToArray();
            int quantity = Convert.ToInt32(strings.First(), CultureInfo.InvariantCulture);
            output = new List<List<string>>(quantity);
            for (int index = 1; index <= quantity; index++)
                output.Add(strings[index].Split(' ').ToList());

            return output;
        }

        // HELPER METHODS
        private string GetDefinitionString(object definitionCommandName, object tag, IEnumerable<string> lineTags)
        {
            return $"{definitionCommandName}({tag}) = {{{string.Join(",", lineTags)}}};";
        }

        private string GetCommandString(object commandName, IEnumerable<string> tags)
        {
            return $"{commandName}{{{string.Join(",", tags)}}};";
        }

        private void WriteComment(TextWriter tw, string comment)
        {
            tw.WriteLine($"{commentTag} {comment}");
        }

        private void WriteLine(TextWriter tw, string comment)
        {
            tw.WriteLine($"{comment}");
        }
    }
}
