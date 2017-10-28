using System.Collections.Generic;
using MathNet.Numerics.LinearAlgebra;

namespace MeshGenerator
{
	public class Mesh
	{
		public Dictionary<int,Vector<double>> Points { get; set; }
        public Connectivity[] Connectivities { get; set; }
	}
}
