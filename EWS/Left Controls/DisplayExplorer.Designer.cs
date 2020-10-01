namespace DCS.LeftControls
{
    partial class DisplayExplorer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DisplayExplorer));
            this.treeViewControl = new System.Windows.Forms.TreeView();
            this.imageListControl = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStripFolder = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStripDisplay = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStripDomain = new System.Windows.Forms.ContextMenuStrip(this.components);
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
            this.treeViewControl.DoubleClick += new System.EventHandler(this.treeViewControl_DoubleClick);
            // 
            // imageListControl
            // 
            this.imageListControl.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListControl.ImageStream")));
            this.imageListControl.TransparentColor = System.Drawing.Color.Transparent;
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
            this.imageListControl.Images.SetKeyName(13, "");
            this.imageListControl.Images.SetKeyName(14, "");
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
            // DisplayExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.treeViewControl);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "DisplayExplorer";
            this.TabText = "Display";
            this.Text = "Display";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewControl;
        private System.Windows.Forms.ImageList imageListControl;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripFolder;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripDisplay;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripDomain;
    }
}