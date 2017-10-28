using FileManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FileManager;
using MathNet.Numerics.LinearAlgebra;
using MeshGenerator;
using netDxf;
//using SAP2000_model;

namespace Sap2000MeshGenerator
{
    public partial class Formulario : Form
    {
        private Conf configuration;

        public Formulario()
        {
            InitializeComponent();
            FillComboBox();
        }
        private void Formulario_Load(object sender, EventArgs e)
        {
            configuration = Conf.Load();
            FillControls();
        }

        private void FillControls()
        {
            cbTypeOfFE.SelectedItem = configuration.MeshType;
            cbGenerateDXF.Checked = configuration.DoDxfFile;
            cbImportSAP2000.Checked = configuration.DoSapModel;
            tbDimensionFE.Text=configuration.MeshDimension.ToString(CultureInfo.InvariantCulture);
            tbShellLayer.Text = configuration.ShellsLayer;
            tbFrameLayer.Text = configuration.FramesLayer;
        }

        private void bChooseMainFolder_Click(object sender, EventArgs e)
        {
            configuration.GmshPath = ChooseGmshPath();
        }

        private void FillComboBox()
        {
            List<MeshType> datasource = new List<MeshType>
            {
                MeshType.Triangular,
                MeshType.Quadrangular
            };
            cbTypeOfFE.DataSource = datasource;
            cbTypeOfFE.Refresh();

        }
        private string ChooseGmshPath()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            string gmshPath = "";
            ofd.Title = "Select GMSH path";
            ofd.Filter = "EXE files|*.exe";
            if (ofd.ShowDialog() == DialogResult.OK)
                gmshPath = ofd.FileName;

            return gmshPath;
        }
        private void bMesh_Click(object sender, EventArgs e)
        {
            if (ConfigurationIsComplete())
                Do();
            else
                MessageBox.Show("The information is not completed. Please, review the data and select the gmsh path.");
        }

        private void Do()
        {
            GmshMeshGenerator meshGenerator = new GmshMeshGenerator(configuration.GmshPath);
            MeshProperties meshProperties = new MeshProperties
            {
                Size = Convert.ToDouble(tbDimensionFE.Text, CultureInfo.InvariantCulture),
                Type = (MeshType)cbTypeOfFE.SelectedItem,
            };
            List<string> files = ChooseFiles();
            foreach (string file in files.Where(File.Exists))
            {
                FileInfo fileInfo = new FileInfo(file);
                DxfDocument doc = DxfDocument.Load(file);
                DxfModel model = DxfManager.GetDxfModel(doc, tbFrameLayer.Text, tbShellLayer.Text);
                Model meshModel = Solver.GetMeshModel(model);
                Mesh mesh = meshGenerator.GenerateMesh(meshModel, meshProperties);
                List<int[]> elements = mesh.Connectivities
                    .Select(con =>
                    {
                        int[] ints = new int[con.Points.Length];
                        for (int index = 0; index < ints.Length; index++)
                            ints[index] = con.Points[index];
                        return ints;
                    })
                    .ToList();
                Dictionary<int, double[]> points = mesh.Points
                    .ToDictionary(kvp => kvp.Key,
                        kvp =>
                        {
                            double[] point = new double[kvp.Value.Count];
                            for (var index = 0; index < point.Length; index++)
                                point[index] = kvp.Value[index];
                            return point;
                        });

                if (cbGenerateDXF.Checked)
                {
                    if (fileInfo.DirectoryName != null)
                    {
                        string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(file);
                        string destinationPath = Path.Combine(fileInfo.DirectoryName,
                            path2: $"{fileNameWithoutExtension}_IMPORT_TO_SAP.dxf");
                        DxfManager.CreateDxfFile(destinationPath, elements, points);
                    }
                }
                if (cbImportSAP2000.Checked)
                {
                }
                //SAPmodelGenerator.ImportModel(elements, points);
            }
        }

        private bool ConfigurationIsComplete()
        {
            double auxiliar;

            return !string.IsNullOrEmpty(configuration?.GmshPath) &&
                   double.TryParse(tbDimensionFE.Text, out auxiliar) &&
                   !string.IsNullOrEmpty(tbFrameLayer.Text) &&
                   !string.IsNullOrEmpty(tbShellLayer.Text);
        }

        private List<string> ChooseFiles()
        {
            List<string> pathFilesDxf = new List<string>();
            OpenFileDialog ofd = new OpenFileDialog
            {
                Title = "Open DXF File(s)",
                Filter = "DXF files|*.dxf",
                Multiselect = !cbImportSAP2000.Checked
            };

            if (ofd.ShowDialog() == DialogResult.OK)
                for (int i = 0; i < ofd.FileNames.Count(); i++)
                {
                    string filename = ofd.FileNames[i];
                    pathFilesDxf.Add(filename);

                }

            return pathFilesDxf;
        }

        private void Formulario_FormClosing(object sender, FormClosingEventArgs e)
        {
            FillConfiguration();
            Conf.Save(configuration);
        }

        private void FillConfiguration()
        {
            configuration.DoDxfFile = cbGenerateDXF.Checked;
            configuration.DoSapModel = cbImportSAP2000.Checked;
            configuration.FramesLayer = tbFrameLayer.Text;
            configuration.ShellsLayer = tbShellLayer.Text;
            configuration.MeshDimension = Convert.ToDouble(tbDimensionFE.Text, CultureInfo.InvariantCulture);
            configuration.MeshType = (MeshType) cbTypeOfFE.SelectedItem;
        }
    }
}
