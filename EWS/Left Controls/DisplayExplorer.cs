using DCS.Compile;
using DCS;
using DCS.DCSTables;
using DCS.Forms;
using DCS.TabPages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DCS.LeftControls
{
    public partial class DisplayExplorer : ToolWindow
    {
        protected System.Windows.Forms.TreeNode tmpSelectedNode;
        protected string SelectedNodeString;
        //MainForm mainform;
        //public DisplayExplorer(MainForm _parent)
        //{
        //    mainform = _parent;
        //    InitializeComponent();
        //    Initialize();
        //}
        public DisplayExplorer()
        {
            InitializeComponent();
            Initialize();
        }

        public void updateChangeEventhandler()
        {
            this.treeViewControl.Nodes.Clear();
            Initialize();
        }

        void Initialize()
        {
            //bool ret = true;
            EWSTreeNode rootnode;
            //EWSTreeNode displaynode;
            rootnode = new EWSTreeNode(Common.DatabaseName);

            rootnode.ImageIndex = 0;
            rootnode.SelectedImageIndex = 1;
            treeViewControl.Nodes.Add(rootnode);

            List<tblDisplay> currentDisplays = tblSolution.m_tblSolution().GetDisplays(0);
            AddDisplaytoTree(currentDisplays, 0, rootnode);
            
        }

        void AddDisplaytoTree(List<tblDisplay> currentDisplays, long ID, EWSTreeNode parentewstreenode)
        {
            foreach (tblDisplay tbldisplay in currentDisplays)
            {
                EWSTreeNode node0 = new EWSTreeNode(tbldisplay.DisplayName);
                node0.NodeID = tbldisplay.DisplayID;

                node0.Nodetype = TREE_NODE_TYPE.DISPLAY;
                node0.ContextMenuStrip = contextMenuStripDisplay;
                node0.ImageIndex = 3;
                node0.SelectedImageIndex = 4;
                {
                    List<tblDisplay> childDisplays = tblSolution.m_tblSolution().GetDisplays(tbldisplay.DisplayID);
                    if (childDisplays.Count > 0)
                    {
                        AddDisplaytoTree(childDisplays, tbldisplay.DisplayID, node0);
                    }
                }
                parentewstreenode.Nodes.Add(node0);
            }
        }

        void AddNodeToDisplayTree(tblDisplay _tbldisplay, long _parentid, EWSTreeNode parentewstreenode)
        {
            if (_parentid > 0)
            {
                List<tblDisplay> currentDisplays = tblSolution.m_tblSolution().GetDisplays(_parentid);

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
                    }
                }
            }
        }

        private void treeViewControl_DoubleClick(object sender, EventArgs e)
        {
            EWSTreeNode node = (EWSTreeNode)treeViewControl.SelectedNode;
            if (node.Nodetype == TREE_NODE_TYPE.DISPLAY)
            {
                if (!MainForm.Instance().CheckDocIsOpen(TABPAGETYPE.DISPLAY, node.NodeID))
                {
                    
                    foreach (tblDisplay tbldisplay in tblSolution.m_tblSolution().m_tblDisplayCollection)
                    {
                        if (tbldisplay.DisplayID == node.NodeID)
                        {
                            TabDisplayPageControl tabdisplaypagecontrol = new TabDisplayPageControl( node.NodeID);
                            tabdisplaypagecontrol.TitleText = node.Text;

                            //tabdisplaypagecontrol.ID = tbldisplay.DisplayID;
                            
                            tabdisplaypagecontrol.LoadTabPage();
                            MainForm.Instance().m_propertyGrid.SelectedObject = tabdisplaypagecontrol.Displayobject;// tbldisplay;
                            tabdisplaypagecontrol.drawarea.SnapEnable = false;
                            tabdisplaypagecontrol.drawarea.Size = new System.Drawing.Size(tbldisplay.Width, tbldisplay.Height);
                            tabdisplaypagecontrol.drawarea.Invalidate();

                            MainForm.Instance().ShowTabPage(tabdisplaypagecontrol);
                            tabdisplaypagecontrol.drawarea.Initialize();
                            tabdisplaypagecontrol.drawarea.Refresh();
                            MainForm.Instance().UpdateToolbox();
                            MainForm.Instance().UpdateLayer(tbldisplay);

                            //MainForm.Instance().m_propertyGrid.SelectedObject = tabdisplaypagecontrol.drawarea;// tbldisplay;
                            //mainEWSForm.m_propertyGrid.HiddenProperties = o.PropertyGridFilterH();
                            //mainEWSForm.m_propertyGrid.BrowsableProperties = o.PropertyGridFilterS();
                            //mainEWSForm.m_propertyGrid.Refresh();

                            break;
                        }

                    }


                }
            }
        }

        
    }
}
