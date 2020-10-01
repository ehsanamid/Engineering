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
using EWS.Forms;
using EWS.OtherControls;
using EWS.TabPages;

namespace EWS.LeftControls
{
    public partial class DisplayExplorerControl : ExplorerControl
    {

        public DisplayExplorerControl(MainForm _parent)
            : base(_parent)
        {
            InitializeComponent();
        }
        public DisplayExplorerControl()
            : base()
        {
            InitializeComponent();
        }
        
        private void updateDomainChangeEventhandler(object sender, EventArgs e)
        {
            this.treeViewControl.Nodes.Clear();
            Initialize();
        }

        protected override void treeView1_MouseDown(object sender, MouseEventArgs e)
        {
            base.treeView1_MouseDown(sender, e);
        }
        

        protected override void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            this.treeViewControl.Nodes.Clear();
            Initialize();
        }


        public override bool Initialize()
        {
            bool ret = true;
            EWSTreeNode rootnode;
            EWSTreeNode displaynode;
            rootnode = new EWSTreeNode(Common.DatabaseName);

            rootnode.ImageIndex = 0;
            rootnode.SelectedImageIndex = 1;
            AddRoot(rootnode);

            List<tblDisplay> currentDisplays = Global.EWS.m_tblSolution.GetDisplays(0);
            AddDisplaytoTree(currentDisplays,0, rootnode);
            //foreach (tblDisplay tbldisplay in Global.EWS.m_tblSolution.m_tblDisplayCollection)
            //{
            //    if (tbldisplay.ParrentDisplay == 0)
            //    {
            //        displaynode = new EWSTreeNode(tbldisplay.DisplayName);
            //        displaynode.NodeID = tbldisplay.DisplayID;
            //        displaynode.Nodetype = TREE_NODE_TYPE.DISPLAY;
            //        displaynode.ContextMenuStrip = contextMenuStripDisplay;
            //        displaynode.ImageIndex = 6;
            //        displaynode.SelectedImageIndex = 7;
            //        rootnode.Nodes.Add(displaynode);
            //    }
            //    else
            //    {
            //        AddNodeToDisplayTree(tbldisplay, 0, displaynode);
            //    }
            //}
            return ret;
        }

        void AddDisplaytoTree(List<tblDisplay> currentDisplays,long ID, EWSTreeNode parentewstreenode)
        {
            foreach (tblDisplay tbldisplay in currentDisplays)
            {
                EWSTreeNode node0 = new EWSTreeNode(tbldisplay.DisplayName);
                node0.NodeID = tbldisplay.DisplayID;

                node0.Nodetype = TREE_NODE_TYPE.DISPLAY;
                node0.ContextMenuStrip = contextMenuStripDisplay;
                node0.ImageIndex = 3;
                node0.SelectedImageIndex = 4;
               // if (tbldisplay.ParrentDisplay != ID)
                {
                    List<tblDisplay> childDisplays = Global.EWS.m_tblSolution.GetDisplays(tbldisplay.DisplayID);
                    if (childDisplays.Count > 0)
                    {
                        AddDisplaytoTree(childDisplays, tbldisplay.DisplayID, node0);
                    }
                }
                parentewstreenode.Nodes.Add(node0);
            }
        }

        void AddNodeToDisplayTree(tblDisplay  _tbldisplay, long _parentid, EWSTreeNode parentewstreenode)
        {
            if (_parentid > 0)
            {
                List<tblDisplay> currentDisplays = Global.EWS.m_tblSolution.GetDisplays(_parentid);

                for (int i = 0; i < currentDisplays.Count; i++)
                    if (currentDisplays[i].oIndex != i)
                    {
                        currentDisplays[i].oIndex = i;
                        currentDisplays[i].Update();
                    }

                foreach (tblDisplay tbldisplay in currentDisplays)
                {
                    if (tbldisplay.IsDisplay)
                    {
                        EWSTreeNode node0 = new EWSTreeNode(tbldisplay.DisplayName);
                        node0.NodeID = tbldisplay.DisplayID;

                        node0.Nodetype = TREE_NODE_TYPE.DISPLAY;
                        node0.ContextMenuStrip = contextMenuStripDisplay;
                        node0.ImageIndex = 3;
                        node0.SelectedImageIndex = 4;

                        parentewstreenode.Nodes.Add(node0);
                    }

                    else
                    {
                        EWSTreeNode node0 = new EWSTreeNode(tbldisplay.DisplayName);
                        node0.NodeID = tbldisplay.DisplayID;

                        node0.Nodetype = TREE_NODE_TYPE.DISPALYGROUP;
                        node0.ContextMenuStrip = contextMenuStripFolder;
                        node0.ImageIndex = 2;
                        node0.SelectedImageIndex = 3;

                        parentewstreenode.Nodes.Add(node0);
                        //AddNodeToDisplayTree(_domain, tbldisplay.DisplayID, node0);
                    }
                }
            }
        }

        private void treeViewControl_DoubleClick(object sender, EventArgs e)
        {
            EWSTreeNode node = (EWSTreeNode)treeViewControl.SelectedNode;
            //EWSTreeNode parentnode;
            if (node.Nodetype == TREE_NODE_TYPE.DISPLAY)
            {
                if (!mainEWSFrom.CheckDocIsOpen(TABPAGETYPE.DISPLAY, node.NodeID))
                {
                    TabDisplayPageControl tabpagecontrol = new TabDisplayPageControl(mainEWSFrom, node.NodeID);
                    tabpagecontrol.TitleText = node.Text;
                    foreach (tblDisplay tbldisplay in Global.EWS.m_tblSolution.m_tblDisplayCollection)
                    {
                        if (tbldisplay.DisplayID == node.NodeID)
                        {
                            mainEWSFrom.m_propertyGrid.SelectedObject = tabpagecontrol.drawarea;// tbldisplay;
                            //mainEWSForm.m_propertyGrid.HiddenProperties = o.PropertyGridFilterH();
                            //mainEWSForm.m_propertyGrid.BrowsableProperties = o.PropertyGridFilterS();
                            //mainEWSForm.m_propertyGrid.Refresh();

                            // 
                            tabpagecontrol.drawarea.ID = tbldisplay.DisplayID;
                            tbldisplay.InitGraphic(tabpagecontrol.drawarea.Pages.GraphicPagesList[0]);
                            tabpagecontrol.drawarea.BackColor = tbldisplay.BackColor;
                            tabpagecontrol.drawarea.Size = new System.Drawing.Size(1280, 830);
                            mainEWSFrom.ShowTabPage(tabpagecontrol);
                            break;
                        }

                    }

                    
                }
            }
        }
    }
}
