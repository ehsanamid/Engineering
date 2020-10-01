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
    public partial class StructureExplorerControl : ExplorerControl
    {

        public StructureExplorerControl(MainForm _parent)
            : base(_parent)
        {
            InitializeComponent();
        }
        public StructureExplorerControl()
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
            Global.EWS.m_tblSolution.m_tblPlantStructureCollection.Clear();
            Global.EWS.m_tblSolution.m_tblPlantStructureCollection = null;
            Initialize();
        }
        public override bool Initialize()
        {
            bool ret = true;
            EWSTreeNode rootnode;
            EWSTreeNode childnode;
            rootnode = new EWSTreeNode(Common.DatabaseName);

            rootnode.ImageIndex = 0;
            rootnode.SelectedImageIndex = 0;
            rootnode.Nodetype = TREE_NODE_TYPE.Root;
            AddRoot(rootnode);
			long _parentid = -1;
			List<tblPlantStructure> nodes = Global.EWS.m_tblSolution.GetPlantStructure(_parentid);
			

            foreach (tblPlantStructure tblplantstructure in nodes)
            {
                childnode = new EWSTreeNode( tblplantstructure.Name);
                childnode.NodeID = tblplantstructure.ID;
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
                
                childnode.ContextMenuStrip = contextMenuStripStructure;
                
                rootnode.Nodes.Add(childnode);
                AddNodeToPlantStructureTree(childnode,childnode.NodeID);
            }
            return ret;
        }
		 void AddNodeToPlantStructureTree(EWSTreeNode parentnode, long id)
		 {
		    EWSTreeNode childnode;
            List<tblPlantStructure> nodes = Global.EWS.m_tblSolution.GetPlantStructure(id);
			foreach (tblPlantStructure tblplantstructure in nodes)
            {
                childnode = new EWSTreeNode(tblplantstructure.Name);
                childnode.NodeID = tblplantstructure.ID;
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
                
                
                childnode.ContextMenuStrip = contextMenuStripStructure;
                
                parentnode.Nodes.Add(childnode);
                AddNodeToPlantStructureTree(childnode,childnode.NodeID);
            }
		 
		 }

         //protected override void toolStripButtonRefresh_Click(object sender, EventArgs e)
         //{

         //}

         //protected override void toolStripButtonSearch_Click(object sender, EventArgs e)
         //{

         //}

        // void AddNodeToPlantStructureTree(tblPlantStructure tblplantstructure, long _parentid, EWSTreeNode parentewstreenode)
        //{
        //    if (_parentid > 0)
        //    {
        //        List<tblDisplay> currentDisplays = Global.EWS.m_tblSolution.GetDisplays(_parentid);

        //        for (int i = 0; i < currentDisplays.Count; i++)
        //            if (currentDisplays[i].oIndex != i)
        //            {
        //                currentDisplays[i].oIndex = i;
        //                currentDisplays[i].Update();
        //            }

        //        foreach (tblDisplay tbldisplay in currentDisplays)
        //        {
        //            if (tbldisplay.IsDisplay)
        //            {
        //                EWSTreeNode node0 = new EWSTreeNode(tbldisplay.DisplayName);
        //                node0.NodeID = tbldisplay.DisplayID;

        //                node0.Nodetype = TREE_NODE_TYPE.DISPLAY;
        //                node0.ContextMenuStrip = contextMenuStripStructure;
        //                node0.ImageIndex = 3;
        //                node0.SelectedImageIndex = 4;

        //                parentewstreenode.Nodes.Add(node0);
        //            }

        //            else
        //            {
        //                EWSTreeNode node0 = new EWSTreeNode(tbldisplay.DisplayName);
        //                node0.NodeID = tbldisplay.DisplayID;

        //                node0.Nodetype = TREE_NODE_TYPE.DISPALYGROUP;
        //                node0.ContextMenuStrip = contextMenuStripStructure;
        //                node0.ImageIndex = 2;
        //                node0.SelectedImageIndex = 3;

        //                parentewstreenode.Nodes.Add(node0);
        //                //AddNodeToDisplayTree(_domain, tbldisplay.DisplayID, node0);
        //            }
        //        }
        //    }
        //}

        private void treeViewControl_DoubleClick(object sender, EventArgs e)
        {
            //EWSTreeNode node = (EWSTreeNode)treeViewControl.SelectedNode;
            ////EWSTreeNode parentnode;
            //if (node.Nodetype == TREE_NODE_TYPE.DISPLAY)
            //{
            //    //do
            //    //{
            //    //    parentnode = (EWSTreeNode)node.Parent;
            //    //    node = parentnode;

            //    //} while (parentnode.Nodetype != TREE_NODE_TYPE.DOMAIN);

                

            //    node = (EWSTreeNode)treeViewControl.SelectedNode;


            //    //DrawingDoc _drawingdoc = new DrawingDoc(frm);
            //    TabDisplayPageControl tabpagecontrol = new TabDisplayPageControl(mainEWSFrom.TabControlMain, node.NodeID);
            //    tabpagecontrol.ImageIndex = 0;
            //    tabpagecontrol.TitleText = node.Text;
            //    tabpagecontrol.PageType = TabPageType.DISPLAY;
            //    //tabpagecontrol.ID = node.NodeID;
            //    //_drawingdoc.DrawAreaType = DrawAreaType.DISPLAY;
            //    //GraphicsList graphicslist = new GraphicsList();
            //    //DrawArea DrawArea = new DrawArea(_drawingdoc);
            //    foreach (tblDisplay tbldisplay in Global.EWS.m_tblSolution.m_tblDisplayCollection)
            //    {

            //        if (tbldisplay.DisplayID == node.NodeID)
            //        {
            //            mainEWSFrom.m_propertyGrid.SelectedObject = tabpagecontrol.drawarea;// tbldisplay;
            //            //mainEWSForm.m_propertyGrid.HiddenProperties = o.PropertyGridFilterH();
            //            //mainEWSForm.m_propertyGrid.BrowsableProperties = o.PropertyGridFilterS();
            //            //mainEWSForm.m_propertyGrid.Refresh();

            //            // 
            //            tabpagecontrol.drawarea.ID = tbldisplay.DisplayID;
            //            tbldisplay.InitGraphic(tabpagecontrol.drawarea.Pages.GraphicPagesList[0]);
            //            tabpagecontrol.drawarea.BackColor = tbldisplay.BackColor;
            //            tabpagecontrol.drawarea.Size = new System.Drawing.Size(1280, 830);
            //            //tbldisplay.InitGraphic(ref graphicslist);
            //            break;
            //        }

            //    }

            //    mainEWSFrom.addPanel(tabpagecontrol);
            //    //_drawingdoc.Text = node.Text;

            //    //frm.ShowDocumnet(_drawingdoc);
            //}
        }
        

    }
}
