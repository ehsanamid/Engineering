namespace DCS.LeftControls
{
    partial class ReportExplorer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportExplorer));
            this.treeViewControl = new System.Windows.Forms.TreeView();
            this.imageListControl = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // treeViewControl
            // 
            this.treeViewControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewControl.ImageIndex = 0;
            this.treeViewControl.ImageList = this.imageListControl;
            this.treeViewControl.Location = new System.Drawing.Point(0, 0);
            this.treeViewControl.Name = "treeViewControl";
            this.treeViewControl.SelectedImageIndex = 0;
            this.treeViewControl.Size = new System.Drawing.Size(292, 266);
            this.treeViewControl.TabIndex = 0;
            // 
            // imageListControl
            // 
            this.imageListControl.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListControl.ImageStream")));
            this.imageListControl.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListControl.Images.SetKeyName(0, "Factory.png");
            this.imageListControl.Images.SetKeyName(1, "FactoryD.png");
            this.imageListControl.Images.SetKeyName(2, "FactoryH.png");
            this.imageListControl.Images.SetKeyName(3, "DISP.PNG");
            this.imageListControl.Images.SetKeyName(4, "Display-add.png");
            this.imageListControl.Images.SetKeyName(5, "Display-delete.png");
            this.imageListControl.Images.SetKeyName(6, "Domain.png");
            this.imageListControl.Images.SetKeyName(7, "Project.png");
            this.imageListControl.Images.SetKeyName(8, "FB.png");
            this.imageListControl.Images.SetKeyName(9, "FBD.png");
            this.imageListControl.Images.SetKeyName(10, "FUNCTIONBLOCK.png");
            this.imageListControl.Images.SetKeyName(11, "IL.png");
            this.imageListControl.Images.SetKeyName(12, "LD.png");
            this.imageListControl.Images.SetKeyName(13, "PROGRAM.png");
            this.imageListControl.Images.SetKeyName(14, "SFC.png");
            this.imageListControl.Images.SetKeyName(15, "ST.png");
            this.imageListControl.Images.SetKeyName(16, "prjcls.PNG");
            // 
            // DisplayExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.treeViewControl);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ReportExplorer";
            this.TabText = "Report";
            this.Text = "ReportExplorer";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewControl;
        private System.Windows.Forms.ImageList imageListControl;
    }
}