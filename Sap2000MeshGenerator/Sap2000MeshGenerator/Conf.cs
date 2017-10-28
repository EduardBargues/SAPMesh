using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Sap2000MeshGenerator
{
    public class Conf
    {
        private static string configurationFileName = "Configuration.xml";
        public string GmshPath { get; set; }
        public string FramesLayer { get; set; }
        public string ShellsLayer { get; set; }
        public double MeshDimension { get; set; }
        public bool DoDxfFile { get; set; }
        public bool DoSapModel { get; set; }
        public MeshType MeshType { get; set; }

        public static Conf Load()
        {
            Conf configuration = new Conf();
            string executionPath = System.Reflection.Assembly.GetEntryAssembly().Location;
            if (executionPath != null)
            {
                FileInfo file = new FileInfo(executionPath);
                if (file.Exists &&
                    file.DirectoryName != null)
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(Conf));
                    string path = Path.Combine(file.DirectoryName, configurationFileName);
                    if (File.Exists(path))
                        using (FileStream fileStream = File.Open(path, FileMode.Open))
                        {
                            configuration = (Conf)xmlSerializer.Deserialize(fileStream);
                            fileStream.Close();
                        }
                }
            }

            return configuration;
        }
        public static void Save(Conf conf)
        {
            string executionPath = System.Reflection.Assembly.GetEntryAssembly().Location;
            if (executionPath != null)
            {
                FileInfo file = new FileInfo(executionPath);
                if (file.Exists &&
                    file.DirectoryName != null)
                {
                    string path = Path.Combine(file.DirectoryName, configurationFileName);
                    using (FileStream fileStream = File.Open(path, FileMode.Create))
                    {
                        XmlSerializer xmlSerializer = new XmlSerializer(typeof(Conf));
                        xmlSerializer.Serialize(fileStream, conf);
                        fileStream.Close();
                    }
                }
            }
        }
    }
}
