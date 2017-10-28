namespace Sap2000MeshGenerator
{
    partial class Formulario
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Formulario));
            this.bChooseMainFolder = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lTypeOfFE = new System.Windows.Forms.Label();
            this.gpInput = new System.Windows.Forms.GroupBox();
            this.tbFrameLayer = new System.Windows.Forms.TextBox();
            this.lFrameLayer = new System.Windows.Forms.Label();
            this.tbShellLayer = new System.Windows.Forms.TextBox();
            this.lShellLayer = new System.Windows.Forms.Label();
            this.tbDimensionFE = new System.Windows.Forms.TextBox();
            this.lDimensionFE = new System.Windows.Forms.Label();
            this.cbTypeOfFE = new System.Windows.Forms.ComboBox();
            this.gbOutput = new System.Windows.Forms.GroupBox();
            this.lNumberOfHoles = new System.Windows.Forms.Label();
            this.lHoles = new System.Windows.Forms.Label();
            this.lNumberOfSurfaces = new System.Windows.Forms.Label();
            this.lSurfaces = new System.Windows.Forms.Label();
            this.lNumberOfFrames = new System.Windows.Forms.Label();
            this.lFrames = new System.Windows.Forms.Label();
            this.lNumberOfShells = new System.Windows.Forms.Label();
            this.lShells = new System.Windows.Forms.Label();
            this.bMesh = new System.Windows.Forms.Button();
            this.cbGenerateDXF = new System.Windows.Forms.CheckBox();
            this.cbImportSAP2000 = new System.Windows.Forms.CheckBox();
            this.gpInput.SuspendLayout();
            this.gbOutput.SuspendLayout();
            this.SuspendLayout();
            // 
            // bChooseMainFolder
            // 
            this.bChooseMainFolder.Image = ((System.Drawing.Image)(resources.GetObject("bChooseMainFolder.Image")));
            this.bChooseMainFolder.Location = new System.Drawing.Point(6, 19);
            this.bChooseMainFolder.Name = "bChooseMainFolder";
            this.bChooseMainFolder.Size = new System.Drawing.Size(42, 42);
            this.bChooseMainFolder.TabIndex = 0;
            this.bChooseMainFolder.UseVisualStyleBackColor = true;
            this.bChooseMainFolder.Click += new System.EventHandler(this.bChooseMainFolder_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // lTypeOfFE
            // 
            this.lTypeOfFE.AutoSize = true;
            this.lTypeOfFE.Location = new System.Drawing.Point(54, 19);
            this.lTypeOfFE.Name = "lTypeOfFE";
            this.lTypeOfFE.Size = new System.Drawing.Size(23, 13);
            this.lTypeOfFE.TabIndex = 5;
            this.lTypeOfFE.Text = "FE:";
            // 
            // gpInput
            // 
            this.gpInput.Controls.Add(this.tbFrameLayer);
            this.gpInput.Controls.Add(this.lFrameLayer);
            this.gpInput.Controls.Add(this.tbShellLayer);
            this.gpInput.Controls.Add(this.lShellLayer);
            this.gpInput.Controls.Add(this.tbDimensionFE);
            this.gpInput.Controls.Add(this.lDimensionFE);
            this.gpInput.Controls.Add(this.cbTypeOfFE);
            this.gpInput.Controls.Add(this.lTypeOfFE);
            this.gpInput.Controls.Add(this.bChooseMainFolder);
            this.gpInput.Location = new System.Drawing.Point(3, 2);
            this.gpInput.Name = "gpInput";
            this.gpInput.Size = new System.Drawing.Size(363, 68);
            this.gpInput.TabIndex = 6;
            this.gpInput.TabStop = false;
            this.gpInput.Text = "Input";
            // 
            // tbFrameLayer
            // 
            this.tbFrameLayer.Location = new System.Drawing.Point(270, 41);
            this.tbFrameLayer.Name = "tbFrameLayer";
            this.tbFrameLayer.Size = new System.Drawing.Size(82, 20);
            this.tbFrameLayer.TabIndex = 12;
            this.tbFrameLayer.Text = "Frames";
            // 
            // lFrameLayer
            // 
            this.lFrameLayer.AutoSize = true;
            this.lFrameLayer.Location = new System.Drawing.Point(202, 44);
            this.lFrameLayer.Name = "lFrameLayer";
            this.lFrameLayer.Size = new System.Drawing.Size(64, 13);
            this.lFrameLayer.TabIndex = 11;
            this.lFrameLayer.Text = "Frame layer:";
            // 
            // tbShellLayer
            // 
            this.tbShellLayer.Location = new System.Drawing.Point(270, 16);
            this.tbShellLayer.Name = "tbShellLayer";
            this.tbShellLayer.Size = new System.Drawing.Size(82, 20);
            this.tbShellLayer.TabIndex = 10;
            this.tbShellLayer.Text = "Shells";
            // 
            // lShellLayer
            // 
            this.lShellLayer.AutoSize = true;
            this.lShellLayer.Location = new System.Drawing.Point(202, 19);
            this.lShellLayer.Name = "lShellLayer";
            this.lShellLayer.Size = new System.Drawing.Size(58, 13);
            this.lShellLayer.TabIndex = 9;
            this.lShellLayer.Text = "Shell layer:";
            // 
            // tbDimensionFE
            // 
            this.tbDimensionFE.Location = new System.Drawing.Point(135, 41);
            this.tbDimensionFE.Name = "tbDimensionFE";
            this.tbDimensionFE.Size = new System.Drawing.Size(51, 20);
            this.tbDimensionFE.TabIndex = 8;
            this.tbDimensionFE.Text = "1";
            // 
            // lDimensionFE
            // 
            this.lDimensionFE.AutoSize = true;
            this.lDimensionFE.Location = new System.Drawing.Point(54, 44);
            this.lDimensionFE.Name = "lDimensionFE";
            this.lDimensionFE.Size = new System.Drawing.Size(75, 13);
            this.lDimensionFE.TabIndex = 7;
            this.lDimensionFE.Text = "Dimension FE:";
            // 
            // cbTypeOfFE
            // 
            this.cbTypeOfFE.FormattingEnabled = true;
            this.cbTypeOfFE.Location = new System.Drawing.Point(83, 16);
            this.cbTypeOfFE.Name = "cbTypeOfFE";
            this.cbTypeOfFE.Size = new System.Drawing.Size(103, 21);
            this.cbTypeOfFE.TabIndex = 6;
            // 
            // gbOutput
            // 
            this.gbOutput.Controls.Add(this.lNumberOfHoles);
            this.gbOutput.Controls.Add(this.lHoles);
            this.gbOutput.Controls.Add(this.lNumberOfSurfaces);
            this.gbOutput.Controls.Add(this.lSurfaces);
            this.gbOutput.Controls.Add(this.lNumberOfFrames);
            this.gbOutput.Controls.Add(this.lFrames);
            this.gbOutput.Controls.Add(this.lNumberOfShells);
            this.gbOutput.Controls.Add(this.lShells);
            this.gbOutput.Location = new System.Drawing.Point(3, 74);
            this.gbOutput.Name = "gbOutput";
            this.gbOutput.Size = new System.Drawing.Size(186, 56);
            this.gbOutput.TabIndex = 7;
            this.gbOutput.TabStop = false;
            this.gbOutput.Text = "Output";
            // 
            // lNumberOfHoles
            // 
            this.lNumberOfHoles.AutoSize = true;
            this.lNumberOfHoles.Location = new System.Drawing.Point(58, 36);
            this.lNumberOfHoles.Name = "lNumberOfHoles";
            this.lNumberOfHoles.Size = new System.Drawing.Size(13, 13);
            this.lNumberOfHoles.TabIndex = 15;
            this.lNumberOfHoles.Text = "0";
            // 
            // lHoles
            // 
            this.lHoles.AutoSize = true;
            this.lHoles.Location = new System.Drawing.Point(7, 36);
            this.lHoles.Name = "lHoles";
            this.lHoles.Size = new System.Drawing.Size(37, 13);
            this.lHoles.TabIndex = 14;
            this.lHoles.Text = "Holes:";
            // 
            // lNumberOfSurfaces
            // 
            this.lNumberOfSurfaces.AutoSize = true;
            this.lNumberOfSurfaces.Location = new System.Drawing.Point(58, 16);
            this.lNumberOfSurfaces.Name = "lNumberOfSurfaces";
            this.lNumberOfSurfaces.Size = new System.Drawing.Size(13, 13);
            this.lNumberOfSurfaces.TabIndex = 13;
            this.lNumberOfSurfaces.Text = "0";
            // 
            // lSurfaces
            // 
            this.lSurfaces.AutoSize = true;
            this.lSurfaces.Location = new System.Drawing.Point(7, 16);
            this.lSurfaces.Name = "lSurfaces";
            this.lSurfaces.Size = new System.Drawing.Size(52, 13);
            this.lSurfaces.TabIndex = 12;
            this.lSurfaces.Text = "Surfaces:";
            // 
            // lNumberOfFrames
            // 
            this.lNumberOfFrames.AutoSize = true;
            this.lNumberOfFrames.Location = new System.Drawing.Point(144, 36);
            this.lNumberOfFrames.Name = "lNumberOfFrames";
            this.lNumberOfFrames.Size = new System.Drawing.Size(13, 13);
            this.lNumberOfFrames.TabIndex = 9;
            this.lNumberOfFrames.Text = "0";
            // 
            // lFrames
            // 
            this.lFrames.AutoSize = true;
            this.lFrames.Location = new System.Drawing.Point(98, 36);
            this.lFrames.Name = "lFrames";
            this.lFrames.Size = new System.Drawing.Size(44, 13);
            this.lFrames.TabIndex = 8;
            this.lFrames.Text = "Frames:";
            // 
            // lNumberOfShells
            // 
            this.lNumberOfShells.AutoSize = true;
            this.lNumberOfShells.Location = new System.Drawing.Point(144, 16);
            this.lNumberOfShells.Name = "lNumberOfShells";
            this.lNumberOfShells.Size = new System.Drawing.Size(13, 13);
            this.lNumberOfShells.TabIndex = 7;
            this.lNumberOfShells.Text = "0";
            // 
            // lShells
            // 
            this.lShells.AutoSize = true;
            this.lShells.Location = new System.Drawing.Point(98, 16);
            this.lShells.Name = "lShells";
            this.lShells.Size = new System.Drawing.Size(38, 13);
            this.lShells.TabIndex = 6;
            this.lShells.Text = "Shells:";
            // 
            // bMesh
            // 
            this.bMesh.Image = ((System.Drawing.Image)(resources.GetObject("bMesh.Image")));
            this.bMesh.Location = new System.Drawing.Point(316, 80);
            this.bMesh.Name = "bMesh";
            this.bMesh.Size = new System.Drawing.Size(50, 50);
            this.bMesh.TabIndex = 8;
            this.bMesh.UseVisualStyleBackColor = true;
            this.bMesh.Click += new System.EventHandler(this.bMesh_Click);
            // 
            // cbGenerateDXF
            // 
            this.cbGenerateDXF.AutoSize = true;
            this.cbGenerateDXF.Location = new System.Drawing.Point(195, 90);
            this.cbGenerateDXF.Name = "cbGenerateDXF";
            this.cbGenerateDXF.Size = new System.Drawing.Size(101, 17);
            this.cbGenerateDXF.TabIndex = 18;
            this.cbGenerateDXF.Text = "Generate DXF\'s";
            this.cbGenerateDXF.UseVisualStyleBackColor = true;
            // 
            // cbImportSAP2000
            // 
            this.cbImportSAP2000.AutoSize = true;
            this.cbImportSAP2000.Location = new System.Drawing.Point(195, 109);
            this.cbImportSAP2000.Name = "cbImportSAP2000";
            this.cbImportSAP2000.Size = new System.Drawing.Size(115, 17);
            this.cbImportSAP2000.TabIndex = 19;
            this.cbImportSAP2000.Text = "Import to SAP2000";
            this.cbImportSAP2000.UseVisualStyleBackColor = true;
            // 
            // Formulario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 130);
            this.Controls.Add(this.cbImportSAP2000);
            this.Controls.Add(this.cbGenerateDXF);
            this.Controls.Add(this.bMesh);
            this.Controls.Add(this.gbOutput);
            this.Controls.Add(this.gpInput);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Formulario";
            this.Text = "SAP2000 - Mesh Generator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Formulario_FormClosing);
            this.Load += new System.EventHandler(this.Formulario_Load);
            this.gpInput.ResumeLayout(false);
            this.gpInput.PerformLayout();
            this.gbOutput.ResumeLayout(false);
            this.gbOutput.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bChooseMainFolder;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label lTypeOfFE;
        private System.Windows.Forms.GroupBox gpInput;
        private System.Windows.Forms.GroupBox gbOutput;
        private System.Windows.Forms.Label lNumberOfFrames;
        private System.Windows.Forms.Label lFrames;
        private System.Windows.Forms.Label lNumberOfShells;
        private System.Windows.Forms.Label lShells;
        private System.Windows.Forms.ComboBox cbTypeOfFE;
        private System.Windows.Forms.Label lDimensionFE;
        private System.Windows.Forms.TextBox tbDimensionFE;
        private System.Windows.Forms.Button bMesh;
        private System.Windows.Forms.TextBox tbFrameLayer;
        private System.Windows.Forms.Label lFrameLayer;
        private System.Windows.Forms.TextBox tbShellLayer;
        private System.Windows.Forms.Label lShellLayer;
        private System.Windows.Forms.Label lNumberOfHoles;
        private System.Windows.Forms.Label lHoles;
        private System.Windows.Forms.Label lNumberOfSurfaces;
        private System.Windows.Forms.Label lSurfaces;
        private System.Windows.Forms.CheckBox cbGenerateDXF;
        private System.Windows.Forms.CheckBox cbImportSAP2000;
    }
}

