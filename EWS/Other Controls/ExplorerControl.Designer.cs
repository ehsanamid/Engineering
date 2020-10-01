using System.Collections.Generic;
using System.Windows.Forms;
namespace EWS.OtherControls
{
    partial class ExplorerControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExplorerControl));
            this.panelControl = new System.Windows.Forms.Panel();
            this.panelContent = new System.Windows.Forms.Panel();
            this.treeViewControl = new System.Windows.Forms.TreeView();
            this.imageListControl = new System.Windows.Forms.ImageList(this.components);
            this.toolStripControl = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripTextBoxSearch = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButtonSearch = new System.Windows.Forms.ToolStripButton();
            this.panelControl.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.toolStripControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl
            // 
            this.panelControl.Controls.Add(this.panelContent);
            this.panelControl.Controls.Add(this.toolStripControl);
            this.panelControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl.Location = new System.Drawing.Point(0, 0);
            this.panelControl.Name = "panelControl";
            this.panelControl.Size = new System.Drawing.Size(183, 255);
            this.panelControl.TabIndex = 0;
            // 
            // panelContent
            // 
            this.panelContent.AutoScroll = true;
            this.panelContent.Controls.Add(this.treeViewControl);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 25);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(183, 230);
            this.panelContent.TabIndex = 25;
            // 
            // treeViewControl
            // 
            this.treeViewControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewControl.ImageIndex = 0;
            this.treeViewControl.ImageList = this.imageListControl;
            this.treeViewControl.Location = new System.Drawing.Point(0, 0);
            this.treeViewControl.Name = "treeViewControl";
            this.treeViewControl.SelectedImageIndex = 0;
            this.treeViewControl.Size = new System.Drawing.Size(183, 230);
            this.treeViewControl.TabIndex = 0;
            this.treeViewControl.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeViewControl_AfterLabelEdit);
            this.treeViewControl.Click += new System.EventHandler(this.treeViewControl_Click);
            this.treeViewControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeViewControl_MouseDown);
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
            // toolStripControl
            // 
            this.toolStripControl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonRefresh,
            this.toolStripTextBoxSearch,
            this.toolStripButtonSearch});
            this.toolStripControl.Location = new System.Drawing.Point(0, 0);
            this.toolStripControl.Name = "toolStripControl";
            this.toolStripControl.Size = new System.Drawing.Size(183, 25);
            this.toolStripControl.TabIndex = 24;
            this.toolStripControl.Text = "toolStrip1";
            // 
            // toolStripButtonRefresh
            // 
            this.toolStripButtonRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRefresh.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonRefresh.Image")));
            this.toolStripButtonRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRefresh.Name = "toolStripButtonRefresh";
            this.toolStripButtonRefresh.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonRefresh.Text = "toolStripButton1";
            this.toolStripButtonRefresh.ToolTipText = "Refresh";
            this.toolStripButtonRefresh.Click += new System.EventHandler(this.toolStripButtonRefresh_Click);
            // 
            // toolStripTextBoxSearch
            // 
            this.toolStripTextBoxSearch.BackColor = System.Drawing.SystemColors.HighlightText;
            this.toolStripTextBoxSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolStripTextBoxSearch.Name = "toolStripTextBoxSearch";
            this.toolStripTextBoxSearch.Size = new System.Drawing.Size(105, 25);
            // 
            // toolStripButtonSearch
            // 
            this.toolStripButtonSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSearch.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSearch.Image")));
            this.toolStripButtonSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSearch.Name = "toolStripButtonSearch";
            this.toolStripButtonSearch.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonSearch.Text = "toolStripButton2";
            this.toolStripButtonSearch.ToolTipText = "Search";
            this.toolStripButtonSearch.Click += new System.EventHandler(this.toolStripButtonSearch_Click);
            // 
            // ExplorerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl);
            this.Name = "ExplorerControl";
            this.Size = new System.Drawing.Size(183, 255);
            this.panelControl.ResumeLayout(false);
            this.panelControl.PerformLayout();
            this.panelContent.ResumeLayout(false);
            this.toolStripControl.ResumeLayout(false);
            this.toolStripControl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Panel panelControl;
        protected System.Windows.Forms.ToolStrip toolStripControl;
        protected System.Windows.Forms.ToolStripButton toolStripButtonRefresh;
        protected System.Windows.Forms.ToolStripTextBox toolStripTextBoxSearch;
        protected System.Windows.Forms.ToolStripButton toolStripButtonSearch;
        protected System.Windows.Forms.Panel panelContent;
        protected System.Windows.Forms.TreeView treeViewControl;
        protected System.Windows.Forms.ImageList imageListControl;
        protected System.Windows.Forms.TreeNode tmpSelectedNode;
        protected string SelectedNodeString;
        protected Dictionary<long, TreeNode> _treenodesdictionary = new Dictionary<long, TreeNode>();
    }
}
