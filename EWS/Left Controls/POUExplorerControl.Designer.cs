namespace EWS.LeftControls
{
    partial class POUExplorerControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(POUExplorerControl));
            this.SaveControllerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripPOU = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deletePOUToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renamePOUToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyPOUToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.savePOUToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compilePOUToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.onlinePOUDownloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveUpPOUToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveDownPOUToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripController = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addProgramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddFBDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddSTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddSFCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pastePOUToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadControllerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.onlineControllerDownloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.offlineControllerDownloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compileControllerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelControl.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.contextMenuStripPOU.SuspendLayout();
            this.contextMenuStripController.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeViewControl
            // 
            this.treeViewControl.LineColor = System.Drawing.Color.Black;
            this.treeViewControl.ShowRootLines = false;
            this.treeViewControl.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeViewControl_AfterLabelEdit);
            this.treeViewControl.DoubleClick += new System.EventHandler(this.treeViewControl_DoubleClick);
            // 
            // imageListControl
            // 
            this.imageListControl.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListControl.ImageStream")));
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
            // SaveControllerToolStripMenuItem
            // 
            this.SaveControllerToolStripMenuItem.Name = "SaveControllerToolStripMenuItem";
            this.SaveControllerToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.SaveControllerToolStripMenuItem.Text = "Save";
            this.SaveControllerToolStripMenuItem.Click += new System.EventHandler(this.SaveController_Click);
            // 
            // contextMenuStripPOU
            // 
            this.contextMenuStripPOU.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deletePOUToolStripMenuItem,
            this.renamePOUToolStripMenuItem,
            this.copyPOUToolStripMenuItem,
            this.savePOUToolStripMenuItem,
            this.compilePOUToolStripMenuItem,
            this.onlinePOUDownloadToolStripMenuItem,
            this.moveUpPOUToolStripMenuItem,
            this.moveDownPOUToolStripMenuItem});
            this.contextMenuStripPOU.Name = "contextMenuStripFunctionblock";
            this.contextMenuStripPOU.Size = new System.Drawing.Size(167, 202);
            // 
            // deletePOUToolStripMenuItem
            // 
            this.deletePOUToolStripMenuItem.Name = "deletePOUToolStripMenuItem";
            this.deletePOUToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.deletePOUToolStripMenuItem.Text = "Delete";
            this.deletePOUToolStripMenuItem.Click += new System.EventHandler(this.DeletePOU_Click);
            // 
            // renamePOUToolStripMenuItem
            // 
            this.renamePOUToolStripMenuItem.Name = "renamePOUToolStripMenuItem";
            this.renamePOUToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.renamePOUToolStripMenuItem.Text = "Rename";
            this.renamePOUToolStripMenuItem.Click += new System.EventHandler(this.RenamePOU_Click);
            // 
            // copyPOUToolStripMenuItem
            // 
            this.copyPOUToolStripMenuItem.Name = "copyPOUToolStripMenuItem";
            this.copyPOUToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.copyPOUToolStripMenuItem.Text = "Copy";
            this.copyPOUToolStripMenuItem.Click += new System.EventHandler(this.CopyPOU_Click);
            // 
            // savePOUToolStripMenuItem
            // 
            this.savePOUToolStripMenuItem.Name = "savePOUToolStripMenuItem";
            this.savePOUToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.savePOUToolStripMenuItem.Text = "Save";
            // 
            // compilePOUToolStripMenuItem
            // 
            this.compilePOUToolStripMenuItem.Name = "compilePOUToolStripMenuItem";
            this.compilePOUToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.compilePOUToolStripMenuItem.Text = "Compile";
            this.compilePOUToolStripMenuItem.Click += new System.EventHandler(this.compilePOUToolStripMenuItem_Click);
            // 
            // onlinePOUDownloadToolStripMenuItem
            // 
            this.onlinePOUDownloadToolStripMenuItem.Name = "onlinePOUDownloadToolStripMenuItem";
            this.onlinePOUDownloadToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.onlinePOUDownloadToolStripMenuItem.Text = "Online Download";
            this.onlinePOUDownloadToolStripMenuItem.Click += new System.EventHandler(this.onlinePOUDownloadToolStripMenuItem_Click);
            // 
            // moveUpPOUToolStripMenuItem
            // 
            this.moveUpPOUToolStripMenuItem.Name = "moveUpPOUToolStripMenuItem";
            this.moveUpPOUToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.moveUpPOUToolStripMenuItem.Text = "Move Up";
            this.moveUpPOUToolStripMenuItem.Click += new System.EventHandler(this.moveUpPOU_Click);
            // 
            // moveDownPOUToolStripMenuItem
            // 
            this.moveDownPOUToolStripMenuItem.Name = "moveDownPOUToolStripMenuItem";
            this.moveDownPOUToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.moveDownPOUToolStripMenuItem.Text = "Move Down";
            this.moveDownPOUToolStripMenuItem.Click += new System.EventHandler(this.moveDownPOU_Click);
            // 
            // contextMenuStripController
            // 
            this.contextMenuStripController.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addProgramToolStripMenuItem,
            this.SaveControllerToolStripMenuItem,
            this.pastePOUToolStripMenuItem1,
            this.downloadControllerToolStripMenuItem,
            this.compileControllerToolStripMenuItem});
            this.contextMenuStripController.Name = "contextMenuStrip2";
            this.contextMenuStripController.Size = new System.Drawing.Size(129, 114);
            // 
            // addProgramToolStripMenuItem
            // 
            this.addProgramToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddFBDToolStripMenuItem,
            this.AddSTToolStripMenuItem,
            this.AddSFCToolStripMenuItem});
            this.addProgramToolStripMenuItem.Name = "addProgramToolStripMenuItem";
            this.addProgramToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.addProgramToolStripMenuItem.Text = "Add POU";
            // 
            // AddFBDToolStripMenuItem
            // 
            this.AddFBDToolStripMenuItem.Name = "AddFBDToolStripMenuItem";
            this.AddFBDToolStripMenuItem.Size = new System.Drawing.Size(95, 22);
            this.AddFBDToolStripMenuItem.Text = "FBD";
            this.AddFBDToolStripMenuItem.Click += new System.EventHandler(this.AddFBDPOU_Click);
            // 
            // AddSTToolStripMenuItem
            // 
            this.AddSTToolStripMenuItem.Name = "AddSTToolStripMenuItem";
            this.AddSTToolStripMenuItem.Size = new System.Drawing.Size(95, 22);
            this.AddSTToolStripMenuItem.Text = "ST";
            this.AddSTToolStripMenuItem.Click += new System.EventHandler(this.AddSTPOU_Click);
            // 
            // AddSFCToolStripMenuItem
            // 
            this.AddSFCToolStripMenuItem.Name = "AddSFCToolStripMenuItem";
            this.AddSFCToolStripMenuItem.Size = new System.Drawing.Size(95, 22);
            this.AddSFCToolStripMenuItem.Text = "SFC";
            this.AddSFCToolStripMenuItem.Click += new System.EventHandler(this.AddSFCPOU_Click);
            // 
            // pastePOUToolStripMenuItem1
            // 
            this.pastePOUToolStripMenuItem1.Name = "pastePOUToolStripMenuItem1";
            this.pastePOUToolStripMenuItem1.Size = new System.Drawing.Size(128, 22);
            this.pastePOUToolStripMenuItem1.Text = "Paste";
            this.pastePOUToolStripMenuItem1.Click += new System.EventHandler(this.PasteController_Click);
            // 
            // downloadControllerToolStripMenuItem
            // 
            this.downloadControllerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.onlineControllerDownloadToolStripMenuItem,
            this.offlineControllerDownloadToolStripMenuItem});
            this.downloadControllerToolStripMenuItem.Name = "downloadControllerToolStripMenuItem";
            this.downloadControllerToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.downloadControllerToolStripMenuItem.Text = "Download";
            // 
            // onlineControllerDownloadToolStripMenuItem
            // 
            this.onlineControllerDownloadToolStripMenuItem.Name = "onlineControllerDownloadToolStripMenuItem";
            this.onlineControllerDownloadToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.onlineControllerDownloadToolStripMenuItem.Text = "Online";
            this.onlineControllerDownloadToolStripMenuItem.Click += new System.EventHandler(this.onlineControllerDownloadToolStripMenuItem_Click);
            // 
            // offlineControllerDownloadToolStripMenuItem
            // 
            this.offlineControllerDownloadToolStripMenuItem.Name = "offlineControllerDownloadToolStripMenuItem";
            this.offlineControllerDownloadToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.offlineControllerDownloadToolStripMenuItem.Text = "Offline";
            this.offlineControllerDownloadToolStripMenuItem.Click += new System.EventHandler(this.offlineControllerDownloadToolStripMenuItem_Click);
            // 
            // compileControllerToolStripMenuItem
            // 
            this.compileControllerToolStripMenuItem.Name = "compileControllerToolStripMenuItem";
            this.compileControllerToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.compileControllerToolStripMenuItem.Text = "Compile";
            this.compileControllerToolStripMenuItem.Click += new System.EventHandler(this.CompileController_Click);
            // 
            // POUExplorerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "POUExplorerControl";
            this.Controls.SetChildIndex(this.panelControl, 0);
            this.panelControl.ResumeLayout(false);
            this.panelControl.PerformLayout();
            this.panelContent.ResumeLayout(false);
            this.contextMenuStripPOU.ResumeLayout(false);
            this.contextMenuStripController.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem SaveControllerToolStripMenuItem;
        public System.Windows.Forms.ContextMenuStrip contextMenuStripPOU;
        private System.Windows.Forms.ToolStripMenuItem deletePOUToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renamePOUToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyPOUToolStripMenuItem;
        public System.Windows.Forms.ContextMenuStrip contextMenuStripController;
        private System.Windows.Forms.ToolStripMenuItem addProgramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddFBDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddSTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddSFCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pastePOUToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem savePOUToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compilePOUToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downloadControllerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem onlineControllerDownloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem offlineControllerDownloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem onlinePOUDownloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveUpPOUToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveDownPOUToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compileControllerToolStripMenuItem;

        
    }
}
