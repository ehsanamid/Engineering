namespace EWS.LeftControls
{
    partial class StructureExplorerControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StructureExplorerControl));
            this.contextMenuStripStructure = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panelControl.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeViewControl
            // 
            this.treeViewControl.LineColor = System.Drawing.Color.Black;
            this.treeViewControl.ShowRootLines = false;
            this.treeViewControl.DoubleClick += new System.EventHandler(this.treeViewControl_DoubleClick);
            // 
            // imageListControl
            // 
            this.imageListControl.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListControl.ImageStream")));
            this.imageListControl.Images.SetKeyName(0, "Compass.png");
            this.imageListControl.Images.SetKeyName(1, "Area.png");
            this.imageListControl.Images.SetKeyName(2, "Zone.png");
            this.imageListControl.Images.SetKeyName(3, "Unit.png");
            this.imageListControl.Images.SetKeyName(4, "Package.png");
            this.imageListControl.Images.SetKeyName(5, "LCU.png");
            this.imageListControl.Images.SetKeyName(6, "OWS.png");
            // 
            // contextMenuStripStructure
            // 
            this.contextMenuStripStructure.Name = "contextMenuStripFolder";
            this.contextMenuStripStructure.Size = new System.Drawing.Size(153, 26);
            // 
            // StructureExplorerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "StructureExplorerControl";
            this.Controls.SetChildIndex(this.panelControl, 0);
            this.panelControl.ResumeLayout(false);
            this.panelControl.PerformLayout();
            this.panelContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStripStructure;

        
       

    }
}
