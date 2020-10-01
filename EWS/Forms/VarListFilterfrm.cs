using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DockSample;

namespace DCS.Forms
{
    public partial class VarListFilterfrm : Form
    {
        //public VarColumCollection arr;
        public VarListFilterfrm(/*ref VarColumCollection _arr*/)
        {
            //arr = _arr;
            InitializeComponent();

        }

        private void triStateTreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            //FunctionGroup fg;
            //foreach (TreeNode tn in this.triStateTreeViewFunctionFilter.Nodes)
            //{
            //    foreach (TreeNode tn1 in tn.Nodes)
            //    {
            //        if (tn1.Text != "Select All")
            //        {
            //            fg = (FunctionGroup)Enum.Parse(typeof(FunctionGroup), tn1.Text);
            //            filter[(int)fg] = tn1.Checked;
            //        }
            //    }
            //}
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void VarListFilterfrm_Load(object sender, EventArgs e)
        {
            //TreeNode node = new TreeNode("Select All");
            //node.Expand();
            //TreeNode node1;
            //triStateTreeView1.Nodes.Add(node);
            //for (int i = 0; i < arr.Count ; i++)
            //{
            //    node1 = new TreeNode((string) arr[i].Name);
            //    node1.Checked = true;
            //    node.Nodes.Add(node1);
            //}
        }

        private void buttonTextFilter_Click(object sender, EventArgs e)
        {
            CustomTextFilter frm = new CustomTextFilter();

        }

        private void buttonClearFilter_Click(object sender, EventArgs e)
        {

        }
    }
}
