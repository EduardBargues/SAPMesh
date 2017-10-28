using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using MeshGenerator;
using netDxf;
using netDxf.Entities;
using Line = MeshGenerator.Line;

namespace FileManager
{
    public class DxfModel
    {
        public List<PolyLine> Polylines { get; set; } = new List<PolyLine>();
        public List<Line> Lines { get; set; } = new List<Line>();
        public string PolylineLayer { get; set; }
        public string LineLayer { get; set; }
        public string PathModel { get; set; }
        public string NameModel { get; set; }
    }
}
