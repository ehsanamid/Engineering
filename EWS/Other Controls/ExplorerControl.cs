using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DockSample;
//using DocToolkit.Project_Objects;
using EWS.Forms;

namespace EWS.OtherControls
{
    public partial class ExplorerControl : UserControl
    {
        public ExplorerControl()
        {
            InitializeComponent();
        }

        public ExplorerControl(MainForm _parent)
        {
            InitializeComponent();
            mainform = _parent;
        }

        public MainForm mainform;
        //public void SetParent(MainForm _parent)
        //{
        //    mainform = _parent;
        //}

        public virtual bool Initialize()
        {
            bool ret = true;

            return ret;
        }

        public void AddNode(EWSTreeNode node)
        {

            treeViewControl.SelectedNode.Nodes.Add(node);

        }

        public void AddRoot(EWSTreeNode _rootnode)
        {
            //EWSTreeNode node = new EWSTreeNode(rootname);
            treeViewControl.Nodes.Add(_rootnode);

        }

        public virtual string GetNewName(PROJECT_IMAGELIST _Project_Imagelist)
        {
            return "NewName";
        }

        protected virtual void treeView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (treeViewControl.GetNodeAt(e.X, e.Y) != null)
            {
                tmpSelectedNode = treeViewControl.GetNodeAt(e.X, e.Y);
                treeViewControl.SelectedNode = tmpSelectedNode;
                SelectedNodeString = tmpSelectedNode.Text;
                //findselectednodepath(tmpSelectedNode.FullPath);
            }
        }

        protected virtual void treeView1_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
           
        }

        


        

        protected virtual void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {

        }

        protected virtual void toolStripButtonSearch_Click(object sender, EventArgs e)
        {

        }

        private void treeViewControl_Click(object sender, EventArgs e)
        {
            //if (tmpSelectedNode != null && tmpSelectedNode.Parent != null)
            //{
            //    treeViewControl.SelectedNode = tmpSelectedNode;
            //    treeViewControl.LabelEdit = true;
            //    if (!tmpSelectedNode.IsEditing)
            //    {
            //        tmpSelectedNode.BeginEdit();
            //    }
            //}
            
        }

        private void treeViewControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (treeViewControl.GetNodeAt(e.X, e.Y) != null)
            {
                tmpSelectedNode = treeViewControl.GetNodeAt(e.X, e.Y);
                treeViewControl.SelectedNode = tmpSelectedNode;
                SelectedNodeString = tmpSelectedNode.Text;
                //findselectednodepath(tmpSelectedNode.FullPath);
            }
        }

        private void treeViewControl_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            
        }
    }
}
