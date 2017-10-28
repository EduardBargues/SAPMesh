using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace GeometryManager
{
    public static class GeometrySolver
    {
        public static bool IsPointInside(Vector<double> point, List<Vector<double>> vertices)
        {
            DenseVector direction = new DenseVector(2) { [0] = 1, [1] = 0 };
            Ray2D ray = new Ray2D(point, direction);

            int numberOfIntersections = 0;
            List<Vector<double>> boundary = vertices.ToList();
            boundary.Add(vertices.First());
            for (int index = 0; index < boundary.Count - 1; index++)
            {
                Line2D line = new Line2D(boundary[index], boundary[index + 1]);
                Vector<double> intersection;
                if (line.IntersectsWith(ray, out intersection))
                    numberOfIntersections++;
            }

            return numberOfIntersections % 2 != 0;
        }
    }
}
