using System.Collections.Generic;

namespace MeshGenerator.Interfaces
{
    public interface IPhysicalModel
    {
        List<Surface> GetSurfaces();
    }
}
