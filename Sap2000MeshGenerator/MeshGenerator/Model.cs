using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeshGenerator;
using MeshGenerator.Interfaces;

namespace Sap2000MeshGenerator
{
    public class Model : IPhysicalModel
    {
        public List<Surface> Surfaces { get; set; }=new List<Surface>();
        public Model(List<Surface> surfs)
        {
            Surfaces = surfs;
        }
        public Model()
        {
        }
        public List<Surface> GetSurfaces()
        {
            return Surfaces;
        }
    }
}
