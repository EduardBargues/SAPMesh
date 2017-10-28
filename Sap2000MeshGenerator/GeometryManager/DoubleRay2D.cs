using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace GeometryManager
{
    public class DoubleRay2D
    {
        public Vector<double> Origin { get; set; }
        private Vector<double> direction;
        public Vector<double> Direction
        {
            get { return direction; }
            set
            {
                double length = value.Norm(2);
                if (length > 0)
                {
                    direction = new DenseVector(2)
                    {
                        [0] = value[0] / length,
                        [1] = value[1] / length
                    };
                }
                else
                    throw new Exception();
            }
        }

        public bool IntersectsWith(DoubleRay2D ray, out Vector<double> intersection)
        {
            bool intersect = false;
            intersection = new DenseVector(2);

            double[] coeffs1 = GetLineCoeficients();
            double[] coeffs2 = ray.GetLineCoeficients();

            double det = coeffs1[0] * coeffs2[1] - coeffs2[0] * coeffs1[1];
            if (Math.Abs(det) >= 1e-6)
            {
                double x = (coeffs2[1] * coeffs1[2] - coeffs1[1] * coeffs2[2]) / det;
                double y = (coeffs1[0] * coeffs2[2] - coeffs2[0] * coeffs1[2]) / det;
                intersection = new DenseVector(2)
                {
                    [0] = x,
                    [1] = y
                };
                intersect = true;
            }

            return intersect;
        }

        public bool ContainsPoint(Vector<double> p)
        {
            double[] c1 = GetLineCoeficients();
            Vector<double> dr = new DenseVector(2);
            dr[0] = p[0] - Origin[0];
            dr[1] = p[1] - Origin[1];
            DoubleRay2D dr2D = new DoubleRay2D()
            {
                Origin = Origin,
                direction = dr,
            };
            double[] c2 = dr2D.GetLineCoeficients();
            double error = c2.Select((t, index) => Math.Pow(c1[index] - t, 2)).Sum();
            error = Math.Sqrt(error);

            return error <= 1e-6;
        }

        public double GetDistanceAtPoint(Vector<double> p)
        {
            Vector<double> vr = new DenseVector(2) { [0] = p[0] - Origin[0], [1] = p[1] - Origin[1] };
            return vr.DotProduct(direction);
        }

        public double[] GetLineCoeficients()
        {
            // it returns the coefficients in the form of a*x+b*y=c, where
            // a = y2-y1; b = x2-x1; c = a*x1+b*y1
            Vector<double> p1 = Origin;
            Vector<double> p2 = GetPointAtDistance(1);

            double a = p2[1] - p1[1];
            double b = p1[0] - p2[0];
            double c = a * p1[0] + b * p1[1];

            double[] coefs = { a, b, c };
            return coefs;
        }

        public Vector<double> GetPointAtDistance(double distance)
        {
            return new DenseVector(2)
            {
                [0] = Origin[0] + Direction[0] * distance,
                [1] = Origin[1] + Direction[1] * distance,
            };
        }
    }
}
