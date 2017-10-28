using System;
using System.Drawing;
using System.Linq;
using MathNet.Numerics.LinearAlgebra;

namespace GeometryManager
{
    
    public class Ray2D
    {
        // PROPERTIES
        public Vector<double> Origin
        {
            get { return doubleRay.Origin; }
            set { doubleRay.Origin = value; }
        }
        public Vector<double> Direction
        {
            get { return doubleRay.Direction; }
            set { doubleRay.Direction = value; }
        }

        // FIELDS
        private readonly DoubleRay2D doubleRay;

        // CONSTRUCTORS
        public Ray2D(Vector<double> origin, Vector<double> direction)
        {
            doubleRay = new DoubleRay2D()
            {
                Origin = origin,
                Direction = direction,
            };
        }

        public bool IntersectsWith(Ray2D ray, out Vector<double> intersectionPoint)
        {
            DoubleRay2D doubleRay2 = ray.GetDoubleRay();
            bool thereIsIntersection = doubleRay2.IntersectsWith(doubleRay, out intersectionPoint);

            return thereIsIntersection
                   && GetDistanceAtPoint(intersectionPoint) >= 0
                   && ray.GetDistanceAtPoint(intersectionPoint) >= 0;
        }

        public bool ContainsPoint(Vector<double> p)
        {
            return doubleRay.ContainsPoint(p)
                   && GetDistanceAtPoint(p) >= 0;
        }

        public double GetDistanceAtPoint(Vector<double> p)
        {
            return doubleRay.GetDistanceAtPoint(p);
        }

        public double[] GetLineCoeficients()
        {
            return doubleRay.GetLineCoeficients();
        }

        public DoubleRay2D GetDoubleRay()
        {
            return doubleRay;
        }
    }

    
}
