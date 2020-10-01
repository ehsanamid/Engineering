namespace EWS.LeftControls
{
    partial class SystemExplorerControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SystemExplorerControl));
            this.contextMenuStripProject = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStripVariable = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStripController = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStripIOCard = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip5 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelControl.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.contextMenuStripVariable.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeViewControl
            // 
            this.treeViewControl.LineColor = System.Drawing.Color.Black;
            this.treeViewControl.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeViewControl_AfterLabelEdit);
            this.treeViewControl.DoubleClick += new System.EventHandler(this.treeViewControl_DoubleClick);
            // 
            // imageListControl
            // 
            this.imageListControl.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListControl.ImageStream")));
            this.imageListControl.Images.SetKeyName(0, "Factory.png");
            this.imageListControl.Images.SetKeyName(1, "prjcls.PNG");
            this.imageListControl.Images.SetKeyName(2, "PCIOCard.PNG");
            this.imageListControl.Images.SetKeyName(3, "SINEWAVE(Small(16x16)).bmp");
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
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.addToolStripMenuItem.Text = "Add";
            // 
            // SystemExplorerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "SystemExplorerControl";
            this.Controls.SetChildIndex(this.panelControl, 0);
            this.panelControl.ResumeLayout(false);
            this.panelControl.PerformLayout();
            this.panelContent.ResumeLayout(false);
            this.contextMenuStripVariable.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        
        private System.Windows.Forms.ContextMenuStrip contextMenuStripProject;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripVariable;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripController;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripIOCard;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip5;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;

    }
}
