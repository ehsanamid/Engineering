using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DockSample;
using EWS.DCSTables;
//using DocToolkit.Project_Objects;
using EWS.OtherControls;
using EWS.Forms;
using EWS.TabPages;

namespace EWS.LeftControls
{
    public partial class SystemExplorerControl : ExplorerControl
    {
        //private Dictionary<long, TreeNode> _treenodesdictionary = new Dictionary<long, TreeNode>();
        public SystemExplorerControl(MainForm _parent)
            : base(_parent)
        {
            InitializeComponent();
        }
        public SystemExplorerControl()
            : base()
        {
            InitializeComponent();
        }

        protected override void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            this.treeViewControl.Nodes.Clear();
            Initialize();
        }


        
        public override bool Initialize()
        {
            bool ret = true;
            EWSTreeNode node;
            EWSTreeNode node1;
            EWSTreeNode node2;
            EWSTreeNode node3;
            EWSTreeNode node4;


            node = new EWSTreeNode(Global.EWS.m_tblSolution.SolutionName);
            node.ContextMenuStrip = contextMenuStripProject;
            node.ImageIndex = 0;
            node.SelectedImageIndex = 0;
            node.Nodetype = TREE_NODE_TYPE.ROOT;
            AddRoot(node);
            
            node2 = new EWSTreeNode("General");
            node2.ImageIndex = 1;
            node2.SelectedImageIndex = 1;
            node2.NodeID = -1;
            node2.Nodetype = TREE_NODE_TYPE.GENERAL;
            node.Nodes.Add(node2);

            node3 = new EWSTreeNode("Alarm Group");
            node3.ImageIndex = 1;
            node3.SelectedImageIndex = 1;
            node3.NodeID = -1;
            node3.Nodetype = TREE_NODE_TYPE.ALARM_GROUP;
            node2.Nodes.Add(node3);

            node1 = new EWSTreeNode("Controllers");
            node1.ImageIndex = 1;
            node1.SelectedImageIndex = 1;
            node1.NodeID = -1;
            node1.Nodetype = TREE_NODE_TYPE.FCS_Group;
            node.Nodes.Add(node1);

            _treenodesdictionary.Add(-1, node);
            foreach (tblController tblcontroller in Global.EWS.m_tblSolution.m_tblControllerCollection)
            {


                    node2 = new EWSTreeNode(tblcontroller.ControllerName);
                    node2.ContextMenuStrip = contextMenuStripController;
                    node2.ImageIndex = 1;
                    node2.SelectedImageIndex = 1;
                    node2.NodeID = tblcontroller.ControllerID;
                    node2.Nodetype = TREE_NODE_TYPE.CONTROLLER;
                    node1.Nodes.Add(node2);

                    node3 = new EWSTreeNode("Variables");
                    node3.ContextMenuStrip = contextMenuStripVariable;
                    node3.ImageIndex = 2;
                    node3.SelectedImageIndex = 2;
                    node3.Nodetype = TREE_NODE_TYPE.VARIABLE;
                    node3.NodeID = tblcontroller.ControllerID;
                    node2.Nodes.Add(node3);

                    node4 = new EWSTreeNode("IO Boards");
                    node4.ContextMenuStrip = contextMenuStripVariable;
                    node4.ImageIndex = 2;
                    node4.SelectedImageIndex = 2;
                    node4.NodeID = tblcontroller.ControllerID;
                    node4.Nodetype = TREE_NODE_TYPE.IORACK;
                    node2.Nodes.Add(node4);

                    foreach (tblBoard tblboard in tblcontroller.m_tblBoardCollection)
                    {
                        node3 = new EWSTreeNode(tblboard.BoardName);
                        //node3.ContextMenuStrip = contextMenuStripIORack;
                        node3.ImageIndex = 2;
                        node3.SelectedImageIndex = 2;
                        node3.NodeID = tblboard.BoardID;
                        node4.Nodes.Add(node3);
                        
                    }
                
            }
            return ret;
        }

        private void treeViewControl_DoubleClick1(object sender, EventArgs e)
        {
            
        }

        private void treeViewControl_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {

        }

        private void treeViewControl_DoubleClick(object sender, EventArgs e)
        {
            
            EWSTreeNode node = (EWSTreeNode)treeViewControl.SelectedNode;
            EWSTreeNode parentnode;
            if (node != null)
            {
                if (node.Nodetype == TREE_NODE_TYPE.VARIABLE)
                {
                    TabVariableGridPageControl tabpagecontrol;
                    do
                    {
                        parentnode = (EWSTreeNode)node.Parent;
                        node = parentnode;

                    } while (parentnode.Nodetype != TREE_NODE_TYPE.CONTROLLER);
                    node = (EWSTreeNode)treeViewControl.SelectedNode;
                    if (!mainEWSFrom.CheckDocIsOpen(TABPAGETYPE.VARIABLE, node.NodeID))
                    {
                        tabpagecontrol = new TabVariableGridPageControl(mainEWSFrom, node.NodeID);
                        tabpagecontrol.TitleText = node.Parent.Text;//"FCS";
                        tabpagecontrol.LoadTabPage();
                        mainEWSFrom.ShowTabPage(tabpagecontrol);
                        tabpagecontrol.SetColumns();
                        tabpagecontrol.ClearSelection();
                    }
                }
                //if (node.Nodetype == TREE_NODE_TYPE.IORACK)
                //{

                //    do
                //    {
                //        parentnode = (EWSTreeNode)node.Parent;
                //        node = parentnode;

                //    } while (parentnode.Nodetype != TREE_NODE_TYPE.CONTROLLER);
                //    node = (EWSTreeNode)treeViewControl.SelectedNode;
                //    TabPageControl tabpagecontrol1 = new TabPageControl(mainEWSFrom, node.NodeID);
                //    tabpagecontrol1.TitleText = node.Parent.Text;//"FCS";
                //    tabpagecontrol1.LoadTabPage();
                //    mainEWSFrom.addPanel(tabpagecontrol1);
                    

                //}
                if (node.Nodetype == TREE_NODE_TYPE.ALARM_GROUP)
                {
                    if (!mainEWSFrom.CheckDocIsOpen(TABPAGETYPE.ALARM_GROUP, Global.EWS.m_tblSolution.SolutionID))
                    {
                        TabPageGridAlarmGroupControl tabpagecontrol = new TabPageGridAlarmGroupControl(mainEWSFrom, Global.EWS.m_tblSolution.SolutionID);
                        do
                        {
                            parentnode = (EWSTreeNode)node.Parent;
                            node = parentnode;

                        } while (parentnode.Nodetype != TREE_NODE_TYPE.ROOT);
                        node = (EWSTreeNode)treeViewControl.SelectedNode;
                        tabpagecontrol.TitleText = "Alarm Group";
                        //tabpagecontrol.PageType = TabPageType.ALARM_GROUP;
                        //tabpagecontrol.ID = -1;
                        tabpagecontrol.LoadTabPage();
                        mainEWSFrom.ShowTabPage(tabpagecontrol);
                    }
                }
            }
        }
    }
}
