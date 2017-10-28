using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using SAP2000v19;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP2000_model
{
    public static class SAPmodelGenerator
    {
        public static void ImportModel(List<int[]> elements, Dictionary<int, double[]> points)

        {

            int ret;

            SAP2000v19.cOAPI SAPObject = null;
            SAP2000v19.cHelper myHelper = new SAP2000v19.Helper();

            SAPObject = myHelper.GetObject("CSI.SAP2000.API.SapObject");

            //Get a reference to cSapModel to access all OAPI classes and functions
            SAP2000v19.cSapModel SapModel = SAPObject.SapModel;
            int contadorFrame = 1;
            int contadorShell = 1;

            foreach (int[] element in elements)
            {
                double[] firstNode = points[element[0]];
                double[] secondNode = points[element[1]];

                if (element.Length == 2) // LINE
                {
                    string nameFrame = $"Frame-{contadorFrame++}";
                    ret = SapModel.FrameObj.AddByCoord(firstNode[0], firstNode[1], firstNode[2], secondNode[0], secondNode[1], secondNode[2], ref nameFrame);
                }
                else
                {
                    double[] thirdNode = points[element[2]];
                    double[] xCoords = new double[element.Length];
                    double[] yCoords = new double[element.Length];
                    double[] zCoords = new double[element.Length];

                    for (int i = 0; i < element.Length; i++)
                    {
                        xCoords[i] = points[element[i]][0];
                        yCoords[i] = points[element[i]][1];
                        zCoords[i] = points[element[i]][2];

                    }
                    string nameShell = $"Shell-{contadorShell++}";
                    ret = SapModel.AreaObj.AddByCoord(element.Length, ref xCoords, ref yCoords, ref zCoords, ref nameShell);
                }
            }

            SapModel.View.RefreshView();

        }
    }
}
