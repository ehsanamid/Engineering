using DockSample;
using DCS;
using DCS.DCSTables;
using DCS.Tools;
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
    public partial class AreaSelectForm : Form
    {
        public bool ClearFilter = false;
        public Filter filter = new Filter();
        VariableForm parent;
        public AreaSelectForm(VariableForm _parent)
        {
            parent = _parent;
            InitializeComponent();
            Initialize();
        }
        public  bool Initialize()
        {
            bool ret = true;
            EWSTreeNode rootnode;
            EWSTreeNode childnode;
            rootnode = new EWSTreeNode(Common.DatabaseName);
            rootnode.ForeColor = SystemColors.GrayText;
            rootnode.ImageIndex = 0;
            rootnode.SelectedImageIndex = 0;
            rootnode.Nodetype = TREE_NODE_TYPE.Root;

            treeView1.Nodes.Add(rootnode);
            long _parentid = -1;
            List<tblPlantStructure> nodes = tblSolution.m_tblSolution().GetPlantStructure(_parentid);


            foreach (tblPlantStructure tblplantstructure in nodes)
            {
                childnode = new EWSTreeNode(tblplantstructure.Name);
                childnode.NodeID = tblplantstructure.ID;
                if (!NodeisAvaialble(childnode.NodeID))
                {
                    childnode.ForeColor = SystemColors.GrayText;
                }
                switch (tblplantstructure.Type)
                {
                    case 2:
                        childnode.ImageIndex = 1;
                        childnode.SelectedImageIndex = 1;
                        childnode.Nodetype = TREE_NODE_TYPE.Area;
                        break;
                    case 3:
                        childnode.ImageIndex = 2;
                        childnode.SelectedImageIndex = 2;
                        childnode.Nodetype = TREE_NODE_TYPE.Zone;
                        break;
                    case 4:
                        childnode.ImageIndex = 3;
                        childnode.SelectedImageIndex = 3;
                        childnode.Nodetype = TREE_NODE_TYPE.Unit;
                        break;
                    case 5:
                        childnode.ImageIndex = 4;
                        childnode.SelectedImageIndex = 4;
                        childnode.Nodetype = TREE_NODE_TYPE.Package;
                        break;
                    case 6:
                        childnode.ImageIndex = 5;
                        childnode.SelectedImageIndex = 5;
                        childnode.Nodetype = TREE_NODE_TYPE.LCU;
                        break;
                    case 7:
                        childnode.ImageIndex = 6;
                        childnode.SelectedImageIndex = 6;
                        childnode.Nodetype = TREE_NODE_TYPE.OWS;
                        break;

                }

                rootnode.Nodes.Add(childnode);
                AddNodeToPlantStructureTree(childnode, childnode.NodeID);
            }
            return ret;
        }
        void AddNodeToPlantStructureTree(EWSTreeNode parentnode, long id)
        {
            EWSTreeNode childnode;
            List<tblPlantStructure> nodes = tblSolution.m_tblSolution().GetPlantStructure(id);
            foreach (tblPlantStructure tblplantstructure in nodes)
            {
                childnode = new EWSTreeNode(tblplantstructure.Name);
                childnode.NodeID = tblplantstructure.ID;
                if (!NodeisAvaialble(childnode.NodeID))
                {
                    childnode.ForeColor = SystemColors.GrayText;
                }
                switch (tblplantstructure.Type)
                {
                    case 2:
                        childnode.ImageIndex = 1;
                        childnode.SelectedImageIndex = 1;
                        childnode.Nodetype = TREE_NODE_TYPE.Area;
                        break;
                    case 3:
                        childnode.ImageIndex = 2;
                        childnode.SelectedImageIndex = 2;
                        childnode.Nodetype = TREE_NODE_TYPE.Zone;
                        break;
                    case 4:
                        childnode.ImageIndex = 3;
                        childnode.SelectedImageIndex = 3;
                        childnode.Nodetype = TREE_NODE_TYPE.Unit;
                        break;
                    case 5:
                        childnode.ImageIndex = 4;
                        childnode.SelectedImageIndex = 4;
                        childnode.Nodetype = TREE_NODE_TYPE.Package;
                        break;
                    case 6:
                        childnode.ImageIndex = 5;
                        childnode.SelectedImageIndex = 5;
                        childnode.Nodetype = TREE_NODE_TYPE.LCU;
                        break;
                    case 7:
                        childnode.ImageIndex = 6;
                        childnode.SelectedImageIndex = 6;
                        childnode.Nodetype = TREE_NODE_TYPE.OWS;
                        break;

                }

                parentnode.Nodes.Add(childnode);
                AddNodeToPlantStructureTree(childnode, childnode.NodeID);
            }

        }


        bool NodeisAvaialble(long ID)
        {
            bool ret = false;
            foreach (long l in parent._availableareas)
            {
                if (l == ID)
                {
                    return true;
                }
            }

            return ret;
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

            Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            filter.PropertyName = "GroupID";
            filter.Value = (object)((EWSTreeNode)treeView1.SelectedNode).NodeID;
            filter.Operation = OpEnum.Equals;
            Close();
        }

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {

            if (SystemColors.GrayText != treeView1.SelectedNode.ForeColor)
            {
                this.DialogResult = DialogResult.OK;
                filter.PropertyName = "GroupID";
                filter.Value = (object)((EWSTreeNode)treeView1.SelectedNode).NodeID;
                filter.Operation = OpEnum.Equals;
                Close();
            }
        }

        private void treeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (SystemColors.GrayText == e.Node.ForeColor)
            {
                e.Cancel = true;
            }
            else
            {
                buttonOk.Enabled = true;
            }
        }

        private void treeView1_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                if (SystemColors.GrayText != treeView1.SelectedNode.ForeColor)
                {
                    buttonOk.Enabled = true;
                }
                else
                {
                    buttonOk.Enabled = false;
                }
            }
        }

        private void AreaSelectForm_Load(object sender, EventArgs e)
        {
            buttonOk.Enabled = false;
        }

        private void buttonCleaar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            ClearFilter = true;
            Close();
        }

    }
}
