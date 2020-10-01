namespace EWS.LeftControls
{
    partial class DisplayExplorerControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DisplayExplorerControl));
            this.contextMenuStripFolder = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStripDisplay = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStripDomain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panelControl.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeViewControl
            // 
            this.treeViewControl.ImageIndex = 0;
            this.treeViewControl.ImageList = this.imageListControl;
            this.treeViewControl.LineColor = System.Drawing.Color.Black;
            this.treeViewControl.SelectedImageIndex = 0;
            this.treeViewControl.ShowRootLines = false;
            this.treeViewControl.DoubleClick += new System.EventHandler(this.treeViewControl_DoubleClick);
            // 
            // imageListControl
            // 
            this.imageListControl.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListControl.ImageStream")));
            this.imageListControl.Images.SetKeyName(0, "Display-add.png");
            this.imageListControl.Images.SetKeyName(1, "Display-delete.png");
            this.imageListControl.Images.SetKeyName(2, "FolderListIcon.png");
            this.imageListControl.Images.SetKeyName(3, "openHS.png");
            this.imageListControl.Images.SetKeyName(4, "Factory.png");
            this.imageListControl.Images.SetKeyName(5, "FactoryD.png");
            this.imageListControl.Images.SetKeyName(6, "FactoryH.png");
            this.imageListControl.Images.SetKeyName(7, "Warehouse.png");
            this.imageListControl.Images.SetKeyName(8, "WarehouseD.png");
            this.imageListControl.Images.SetKeyName(9, "WarehouseH.png");
            this.imageListControl.Images.SetKeyName(10, "Display-edit.png");
            this.imageListControl.Images.SetKeyName(11, "DISPSel.png");
            this.imageListControl.Images.SetKeyName(12, "DISP.PNG");
            // 
            // contextMenuStripFolder
            // 
            this.contextMenuStripFolder.Name = "contextMenuStripFolder";
            this.contextMenuStripFolder.Size = new System.Drawing.Size(61, 4);
            // 
            // contextMenuStripDisplay
            // 
            this.contextMenuStripDisplay.Name = "contextMenuStripDisplay";
            this.contextMenuStripDisplay.Size = new System.Drawing.Size(61, 4);
            // 
            // contextMenuStripDomain
            // 
            this.contextMenuStripDomain.Name = "contextMenuStripDomain";
            this.contextMenuStripDomain.Size = new System.Drawing.Size(61, 4);
            // 
            // DisplayExplorerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "DisplayExplorerControl";
            this.Controls.SetChildIndex(this.panelControl, 0);
            this.panelControl.ResumeLayout(false);
            this.panelControl.PerformLayout();
            this.panelContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStripFolder;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripDisplay;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripDomain;

        
       

    }
}
