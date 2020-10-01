namespace DCS.LeftControls
{
    partial class SystemExplorer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SystemExplorer));
            this.treeViewControl = new System.Windows.Forms.TreeView();
            this.imageListControl = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStripProject = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStripVariable = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripController = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStripIOCard = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip5 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStripVariable.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeViewControl
            // 
            this.treeViewControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewControl.Location = new System.Drawing.Point(0, 0);
            this.treeViewControl.Name = "treeViewControl";
            this.treeViewControl.Size = new System.Drawing.Size(292, 266);
            this.treeViewControl.TabIndex = 5;
            this.treeViewControl.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeViewControl_AfterLabelEdit);
            this.treeViewControl.DoubleClick += new System.EventHandler(this.treeViewControl_DoubleClick);
            // 
            // imageListControl
            // 
            this.imageListControl.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListControl.ImageStream")));
            this.imageListControl.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListControl.Images.SetKeyName(0, "Factory.png");
            this.imageListControl.Images.SetKeyName(1, "prjcls.PNG");
            this.imageListControl.Images.SetKeyName(2, "PCIOCard.PNG");
            this.imageListControl.Images.SetKeyName(3, "SINEWAVE(Small(16x16)).bmp");
            this.imageListControl.Images.SetKeyName(4, "");
            this.imageListControl.Images.SetKeyName(5, "");
            this.imageListControl.Images.SetKeyName(6, "");
            this.imageListControl.Images.SetKeyName(7, "");
            this.imageListControl.Images.SetKeyName(8, "");
            this.imageListControl.Images.SetKeyName(9, "");
            this.imageListControl.Images.SetKeyName(10, "");
            this.imageListControl.Images.SetKeyName(11, "");
            this.imageListControl.Images.SetKeyName(12, "");
            this.imageListControl.Images.SetKeyName(13, "");
            this.imageListControl.Images.SetKeyName(14, "");
            this.imageListControl.Images.SetKeyName(15, "");
            this.imageListControl.Images.SetKeyName(16, "");
            // 
            // contextMenuStripProject
            // 
            this.contextMenuStripProject.Name = "contextMenuStripProject";
            this.contextMenuStripProject.Size = new System.Drawing.Size(61, 4);
            // 
            // contextMenuStripVariable
            // 
            this.contextMenuStripVariable.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem});
            this.contextMenuStripVariable.Name = "contextMenuStripDomain";
            this.contextMenuStripVariable.Size = new System.Drawing.Size(97, 26);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.addToolStripMenuItem.Text = "Add";
            // 
            // contextMenuStripController
            // 
            this.contextMenuStripController.Name = "contextMenuStripController";
            this.contextMenuStripController.Size = new System.Drawing.Size(61, 4);
            // 
            // contextMenuStripIOCard
            // 
            this.contextMenuStripIOCard.Name = "contextMenuStripIOCard";
            this.contextMenuStripIOCard.Size = new System.Drawing.Size(61, 4);
            // 
            // contextMenuStrip5
            // 
            this.contextMenuStrip5.Name = "contextMenuStrip5";
            this.contextMenuStrip5.Size = new System.Drawing.Size(61, 4);
            // 
            // SystemExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.treeViewControl);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "SystemExplorer";
            this.TabText = "System";
            this.Text = "SystemExplorer";
            this.contextMenuStripVariable.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewControl;
        private System.Windows.Forms.ImageList imageListControl;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripProject;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripVariable;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripController;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripIOCard;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip5;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        //private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}