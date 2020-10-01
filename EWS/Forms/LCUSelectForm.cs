using DCS.DCSTables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DCS.Forms
{
    public partial class LCUSelectForm : Form
    {
        public List<long> lcuList = new List<long>();
        public LCUSelectForm()
        {
            InitializeComponent();
        }

        private void LCUSelectForm_Load(object sender, EventArgs e)
        {
            EWSTreeNode node;
            EWSTreeNode node2;

            node = new EWSTreeNode(tblSolution.m_tblSolution().SolutionName);
            
            node.ImageIndex = 0;
            node.SelectedImageIndex = 1;
            node.Nodetype = TREE_NODE_TYPE.ROOT;
            treeViewControl.Nodes.Add(node);


            foreach (tblController tblcontroller in tblSolution.m_tblSolution().m_tblControllerCollection)
            {
                if (tblcontroller.type == 0)
                {
                    node2 = new EWSTreeNode(tblcontroller.ControllerName);
                    node2.ImageIndex = 16;
                    node2.NodeID = tblcontroller.ControllerID;
                    node2.Nodetype = TREE_NODE_TYPE.CONTROLLER;
                    node.Nodes.Add(node2);  
                }
            }
        }

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            EWSTreeNode node = (EWSTreeNode)treeViewControl.SelectedNode;
            if (node != null)
            {
                if (node.Nodetype == TREE_NODE_TYPE.ROOT)
                {
                   
                }

                if (node.Nodetype == TREE_NODE_TYPE.CONTROLLER)
                {

                }
                    
                
            }
        }
    }
}
