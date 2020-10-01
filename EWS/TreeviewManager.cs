using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DocToolkit.Forms;
using System.Windows.Forms;

namespace DocToolkit
{
   


    public class TreeviewManager 
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected  void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
         
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Explorer));
            //this.tree = new System.Windows.Forms.TreeView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
           // this.SuspendLayout();
            // 
            // tree
            // 
            m_tree.BackColor = System.Drawing.SystemColors.Window;
            //this.tree.Dock = System.Windows.Forms.DockStyle.Fill;
            m_tree.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            m_tree.ImageIndex = 0;
            m_tree.ImageList = this.imageList;
            m_tree.Indent = 19;
           // m_tree.Location = new System.Drawing.Point(0, 24);
            m_tree.Name = "tree";
            m_tree.SelectedImageIndex = 0;
         //   m_tree.Size = new System.Drawing.Size(245, 297);
            m_tree.TabIndex = 0;
            m_tree.DoubleClick += new System.EventHandler(this.Tree_DoubleClick);
            m_tree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.ProjectTree_AfterSelect);
            m_tree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.Tree_NodeMouseClick);
            // 
            // imageList
            // 
            imageList.Images.Add(Image.FromFile(imageToLoad));
            listBox1.BeginUpdate();
            listBox1.Items.Add(imageToLoad);
            listBox1.EndUpdate();
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "");
            this.imageList.Images.SetKeyName(1, "");
            this.imageList.Images.SetKeyName(2, "");
            this.imageList.Images.SetKeyName(3, "");
            this.imageList.Images.SetKeyName(4, "");
            this.imageList.Images.SetKeyName(5, "");
            this.imageList.Images.SetKeyName(6, "");
            this.imageList.Images.SetKeyName(7, "");
            this.imageList.Images.SetKeyName(8, "");
            this.imageList.Images.SetKeyName(9, "");
            this.imageList.Images.SetKeyName(10, "");
            this.imageList.Images.SetKeyName(11, "");
            this.imageList.Images.SetKeyName(12, "");
            this.imageList.Images.SetKeyName(13, "");
            this.imageList.Images.SetKeyName(14, "");
            this.imageList.Images.SetKeyName(15, "");
            this.imageList.Images.SetKeyName(16, "");
            this.imageList.Images.SetKeyName(17, "");
            this.imageList.Images.SetKeyName(18, "");
            this.imageList.Images.SetKeyName(19, "");
            this.imageList.Images.SetKeyName(20, "");
            this.imageList.Images.SetKeyName(21, "");
            this.imageList.Images.SetKeyName(22, "");
            this.imageList.Images.SetKeyName(23, "");
            this.imageList.Images.SetKeyName(24, "");
            this.imageList.Images.SetKeyName(25, "");
            this.imageList.Images.SetKeyName(26, "");
            this.imageList.Images.SetKeyName(27, "");
            this.imageList.Images.SetKeyName(28, "");
            this.imageList.Images.SetKeyName(29, "");
            this.imageList.Images.SetKeyName(30, "");
            // 
            // Explorer
            // 
           // this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
           // this.ClientSize = new System.Drawing.Size(245, 322);
          //  this.Controls.Add(this.tree);
           // this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)((((WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft | WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight)
           //             | WeifenLuo.WinFormsUI.Docking.DockAreas.DockTop)
           //             | WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom)));
            //this.DoubleBuffered = true;
            //this.HideOnClose = true;
            //this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            //this.Name = "Explorer";
            //this.Padding = new System.Windows.Forms.Padding(0, 24, 0, 1);
            //this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockLeftAutoHide;
            //this.TabText = "Explorer";
            //this.Text = "Explorer";
            //this.ResumeLayout(false);

        }

        #endregion

        //public System.Windows.Forms.TreeView tree;
        public System.Windows.Forms.ImageList imageList;

        protected TreeView m_tree = null;
        protected string m_rootName;
    
       // public MainForm mainform;

        public TreeviewManager(ref TreeView _tree, string rootname)
        {
            m_tree = _tree;
            m_rootName = rootname;
            InitializeComponent();
        }

       

        

        //protected override void OnRightToLeftLayoutChanged(EventArgs e)
        //{
        //    tree.RightToLeftLayout = RightToLeftLayout;
        //}

        //public IDockContent FindDocument(string text)
        //{
        //    if (MainFrame.dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
        //    {
        //        foreach (Form form in MdiChildren)
        //            if (form.Text == text)
        //                return form as IDockContent;

        //        return null;
        //    }
        //    else
        //    {
        //        foreach (IDockContent content in MainFrame.dockPanel.Documents)
        //            if (content.DockHandler.TabText == text)
        //                return content;

        //        return null;
        //    }
        //}

        public TreeNode AddNode(string name, int type, ContextMenuStrip menu)
        {
            TreeNode treeNode = new TreeNode(name);

            treeNode.ImageIndex = type;
            treeNode.SelectedImageIndex = type;
            treeNode.ContextMenuStrip = menu;
            treeNode.Name = name;
            treeNode.Text = name;

            if (m_tree.SelectedNode == null)
            {
                m_tree.SelectedNode = m_tree.Nodes[0];
            }

            m_tree.SelectedNode.Nodes.Add(treeNode);

            return (treeNode);
        }
        public TreeNode AddNode(string name, int type, ContextMenuStrip menu, int Index)
        {
            TreeNode treeNode = new TreeNode(name);

            treeNode.ImageIndex = type;
            treeNode.SelectedImageIndex = type;
            treeNode.ContextMenuStrip = menu;
            treeNode.Name = name;
            treeNode.Text = name;

            if (m_tree.SelectedNode == null)
            {
                m_tree.SelectedNode = m_tree.Nodes[0];
            }

            m_tree.SelectedNode.Nodes.Insert(Index, treeNode);

            return (treeNode);
        }

        public virtual void AddRoot(string rootname, int imageindex, ContextMenuStrip rootMenu)
        {
            TreeNode node = new TreeNode(rootname);

            node.ContextMenuStrip = rootMenu;
            node.ImageIndex = imageindex;
            node.SelectedImageIndex = imageindex;

            m_tree.Nodes.Add(node);
        }

        virtual public void ProjectTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
        }

        virtual public void Tree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                m_tree.SelectedNode = e.Node;
            }
        }

        virtual public void Tree_DoubleClick(object sender, System.EventArgs e)
        {
        }

    }
}
