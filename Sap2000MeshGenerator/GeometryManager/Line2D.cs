using System.Drawing;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace GeometryManager
{
    public class Line2D
    {
        public Vector<double> StartPoint { get; set; }
        public Vector<double> EndPoint { get; set; }

        public Line2D(Vector<double> sp, Vector<double> ep)
        {
            StartPoint = sp;
            EndPoint = ep;
        }

        public bool IntersectsWith(Ray2D ray, out Vector<double> intersection)
        {
            Ray2D ray1 = new Ray2D(StartPoint, new DenseVector(2)
            {
                [0] = EndPoint[0] - StartPoint[0],
                [1] = EndPoint[1] - StartPoint[1]
            });
            Ray2D ray2 = new Ray2D(EndPoint, new DenseVector(2)
            {
                [0] = StartPoint[0] - EndPoint[0],
                [1] = StartPoint[1] - EndPoint[1]
            });

            return ray1.IntersectsWith(ray, out intersection) && 
                ray2.IntersectsWith(ray, out intersection);
        }
    }
}