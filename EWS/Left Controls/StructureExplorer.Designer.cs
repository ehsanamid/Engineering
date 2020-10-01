namespace DCS.LeftControls
{
    partial class StructureExplorer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StructureExplorer));
            this.treeViewControl = new System.Windows.Forms.TreeView();
            this.imageListControl = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStripStructure = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItemAddObject = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemAddProperty = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemAddPropertyFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItemCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripStructure.SuspendLayout();
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
            this.treeViewControl.Click += new System.EventHandler(this.treeViewControl_Click);
            this.treeViewControl.DoubleClick += new System.EventHandler(this.treeViewControl_DoubleClick);
            // 
            // imageListControl
            // 
            this.imageListControl.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListControl.ImageStream")));
            this.imageListControl.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListControl.Images.SetKeyName(0, "Factory.png");
            this.imageListControl.Images.SetKeyName(1, "FolderListIcon.png");
            this.imageListControl.Images.SetKeyName(2, "OWS.png");
            this.imageListControl.Images.SetKeyName(3, "Package.png");
            this.imageListControl.Images.SetKeyName(4, "46.png");
            // 
            // contextMenuStripStructure
            // 
            this.contextMenuStripStructure.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemAddObject,
            this.ToolStripMenuItemAddProperty,
            this.ToolStripMenuItemAddPropertyFolder,
            this.toolStripSeparator1,
            this.ToolStripMenuItemDelete,
            this.ToolStripMenuItemEdit,
            this.toolStripSeparator2,
            this.ToolStripMenuItemCopy,
            this.ToolStripMenuItemPaste});
            this.contextMenuStripStructure.Name = "contextMenuStripFolder";
            this.contextMenuStripStructure.Size = new System.Drawing.Size(181, 192);
            this.contextMenuStripStructure.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripStructure_Opening);
            // 
            // ToolStripMenuItemAddObject
            // 
            this.ToolStripMenuItemAddObject.Name = "ToolStripMenuItemAddObject";
            this.ToolStripMenuItemAddObject.Size = new System.Drawing.Size(180, 22);
            this.ToolStripMenuItemAddObject.Text = "Add Object";
            this.ToolStripMenuItemAddObject.Click += new System.EventHandler(this.ToolStripMenuItemAddObject_Click);
            // 
            // ToolStripMenuItemAddProperty
            // 
            this.ToolStripMenuItemAddProperty.Name = "ToolStripMenuItemAddProperty";
            this.ToolStripMenuItemAddProperty.Size = new System.Drawing.Size(180, 22);
            this.ToolStripMenuItemAddProperty.Text = "Add Property";
            this.ToolStripMenuItemAddProperty.Click += new System.EventHandler(this.ToolStripMenuItemAddProperty_Click);
            // 
            // ToolStripMenuItemAddPropertyFolder
            // 
            this.ToolStripMenuItemAddPropertyFolder.Name = "ToolStripMenuItemAddPropertyFolder";
            this.ToolStripMenuItemAddPropertyFolder.Size = new System.Drawing.Size(180, 22);
            this.ToolStripMenuItemAddPropertyFolder.Text = "Add Property Folder";
            this.ToolStripMenuItemAddPropertyFolder.Click += new System.EventHandler(this.ToolStripMenuItemAddPropertyFolder_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // ToolStripMenuItemDelete
            // 
            this.ToolStripMenuItemDelete.Name = "ToolStripMenuItemDelete";
            this.ToolStripMenuItemDelete.Size = new System.Drawing.Size(180, 22);
            this.ToolStripMenuItemDelete.Text = "Delete";
            this.ToolStripMenuItemDelete.Click += new System.EventHandler(this.ToolStripMenuItemDelete_Click);
            // 
            // ToolStripMenuItemEdit
            // 
            this.ToolStripMenuItemEdit.Name = "ToolStripMenuItemEdit";
            this.ToolStripMenuItemEdit.Size = new System.Drawing.Size(180, 22);
            this.ToolStripMenuItemEdit.Text = "Edit";
            this.ToolStripMenuItemEdit.Click += new System.EventHandler(this.ToolStripMenuItemEdit_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // ToolStripMenuItemCopy
            // 
            this.ToolStripMenuItemCopy.Name = "ToolStripMenuItemCopy";
            this.ToolStripMenuItemCopy.Size = new System.Drawing.Size(180, 22);
            this.ToolStripMenuItemCopy.Text = "Copy";
            this.ToolStripMenuItemCopy.Click += new System.EventHandler(this.ToolStripMenuItemCopy_Click);
            // 
            // ToolStripMenuItemPaste
            // 
            this.ToolStripMenuItemPaste.Name = "ToolStripMenuItemPaste";
            this.ToolStripMenuItemPaste.Size = new System.Drawing.Size(180, 22);
            this.ToolStripMenuItemPaste.Text = "Paste";
            this.ToolStripMenuItemPaste.Click += new System.EventHandler(this.ToolStripMenuItemPaste_Click);
            // 
            // StructureExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.treeViewControl);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "StructureExplorer";
            this.TabText = "Plant";
            this.Text = "PlantExplorer";
            this.contextMenuStripStructure.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewControl;
        private System.Windows.Forms.ImageList imageListControl;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripStructure;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemAddObject;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemAddProperty;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemAddPropertyFolder;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemCopy;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemPaste;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemEdit;
        //private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}