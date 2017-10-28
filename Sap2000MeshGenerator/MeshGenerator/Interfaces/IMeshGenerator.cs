namespace MeshGenerator.Interfaces
{
    public interface IMeshGenerator
    {
        Mesh GenerateMesh(IPhysicalModel model, MeshProperties props);
    }
}
