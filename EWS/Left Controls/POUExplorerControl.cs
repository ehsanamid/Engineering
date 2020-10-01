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
using ENG.Compiler;
using EWS.TabPages;

namespace EWS.LeftControls
{
    public partial class POUExplorerControl : ExplorerControl
    {
        public POUExplorerControl(MainForm _parent)
            : base(_parent)
        {
            InitializeComponent();
        }

        public POUExplorerControl()
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
            EWSTreeNode node;
            EWSTreeNode node2;
            EWSTreeNode node4;

            node = new EWSTreeNode(Global.EWS.m_tblSolution.SolutionName);
            //node.ContextMenuStrip = m_treeviewManagerProgram.contextMenuStripController;
            node.ImageIndex = 0;
            node.SelectedImageIndex = 1;
            AddRoot(node);



            foreach (tblController tblcontroller in Global.EWS.m_tblSolution.m_tblControllerCollection)
            {

                node2 = new EWSTreeNode(tblcontroller.ControllerName);
                node2.ContextMenuStrip = contextMenuStripController;
                node2.ImageIndex = 16;
                node2.NodeID = tblcontroller.ControllerID;
                node2.Nodetype = TREE_NODE_TYPE.CONTROLLER;
                node2.SelectedImageIndex = 16;
                node.Nodes.Add(node2);

                foreach (tblPou tblpou in tblcontroller.m_tblPouCollection)
                {
                    if ("GLOBAL" != tblpou.pouName)
                    {
                        node4 = new EWSTreeNode(tblpou.pouName);
                        node4.NodeID = tblpou.pouID;
                        node4.Nodetype = TREE_NODE_TYPE.PROGRAM;
                        node4.ContextMenuStrip = contextMenuStripPOU;
                        switch ((PROGRAM_LANGUAGE)tblpou.Language)
                        {
                            case PROGRAM_LANGUAGE.ENUM_PROGRAM_LANGUAGE_FBD:
                                node4.ImageIndex = 10;
                                node4.SelectedImageIndex = 10;
                                break;
                            case PROGRAM_LANGUAGE.ENUM_PROGRAM_LANGUAGE_IL:
                                node4.ImageIndex = 11;
                                node4.SelectedImageIndex = 11;
                                break;
                            case PROGRAM_LANGUAGE.ENUM_PROGRAM_LANGUAGE_LD:
                                node4.ImageIndex = 12;
                                node4.SelectedImageIndex = 12;
                                break;
                            case PROGRAM_LANGUAGE.ENUM_PROGRAM_LANGUAGE_SFC:
                                node4.ImageIndex = 14;
                                node4.SelectedImageIndex = 14;
                                break;
                            case PROGRAM_LANGUAGE.ENUM_PROGRAM_LANGUAGE_ST:
                                node4.ImageIndex = 15;
                                node4.SelectedImageIndex = 15;
                                break;
                        }
                        node2.Nodes.Add(node4);
                    }




                }
            }
            return ret;
        }

        private void treeViewControl_DoubleClick(object sender, EventArgs e)
        {
            //TabPageControl tabpagecontrol;
            EWSTreeNode node = (EWSTreeNode)treeViewControl.SelectedNode;
            EWSTreeNode parentnode;
            if (node != null)
            {
                if (node.Nodetype == TREE_NODE_TYPE.PROGRAM)
                {
                    do
                    {
                        parentnode = (EWSTreeNode)node.Parent;
                        node = parentnode;

                    } while (parentnode.Nodetype != TREE_NODE_TYPE.CONTROLLER);
                    node = (EWSTreeNode)treeViewControl.SelectedNode;
                    foreach (tblController tblcontroller in Global.EWS.m_tblSolution.m_tblControllerCollection)
                    {
                        foreach (tblPou tblpou in tblcontroller.m_tblPouCollection)
                        {
                            if (tblpou.pouID == node.NodeID)
                            {
                                switch ((PROGRAM_LANGUAGE)tblpou.Language)
                                {
                                    case PROGRAM_LANGUAGE.ENUM_PROGRAM_LANGUAGE_FBD:
                                        TabFBDPageControl tabfbdpagecontrol = new TabFBDPageControl(mainEWSFrom, tblpou.pouID);

                                       // tabfbdpagecontrol.ImageIndex = 0;
                                        tabfbdpagecontrol.TitleText = node.Text;

                                        //tabpagecontrol.ID = node.NodeID;
                                        //((TabFBDPageControl)tabpagecontrol).ID = tblpou.pouID;
                                        //tabpagecontrol.ControllerID = tblcontroller.ControllerID;

                                        //tabpagecontrol.PageType = TabPageType.FBD;
                                        tabfbdpagecontrol.LoadTabPage();
                                        mainEWSFrom.m_propertyGrid.SelectedObject = tabfbdpagecontrol.drawarea;// tbldisplay;
                                        //mainEWSForm.m_propertyGrid.HiddenProperties = o.PropertyGridFilterH();
                                        //mainEWSForm.m_propertyGrid.BrowsableProperties = o.PropertyGridFilterS();
                                        //mainEWSForm.m_propertyGrid.Refresh();

                                        // 
                                        tabfbdpagecontrol.drawarea.ID = tblpou.pouID;
                                        //tblpou.InitPOU(tabpagecontrol.drawarea.graphicsList);

                                        //tabpagecontrol.drawarea.Size = new System.Drawing.Size(1654,1169);
                                        tabfbdpagecontrol.drawarea.Size = new System.Drawing.Size(1454, 969);
                                        tabfbdpagecontrol.drawarea.Invalidate();
                                        //tbldisplay.InitGraphic(ref graphicslist);
                                        mainEWSFrom.addPanel(tabfbdpagecontrol);
                                        break;
                                    case PROGRAM_LANGUAGE.ENUM_PROGRAM_LANGUAGE_SFC:
                                        TabSFCPageControl tabsfcpagecontrol = new TabSFCPageControl(mainEWSFrom, tblpou.pouID);
                                        //tabpagecontrol.PageType = TabPageType.SFC;
                                        mainEWSFrom.addPanel(tabsfcpagecontrol);
                                        break;
                                    case PROGRAM_LANGUAGE.ENUM_PROGRAM_LANGUAGE_ST:
                                        TabSTPageControl tabstpagecontrol = new TabSTPageControl(mainEWSFrom, tblpou.pouID);
                                      //  tabstpagecontrol.ImageIndex = 0;
                                        tabstpagecontrol.TitleText = node.Text;
                                        tabstpagecontrol.LoadTabPage();
                                        mainEWSFrom.addPanel(tabstpagecontrol);
                                        break;
                                }


                                return;
                                //break;
                            }
                        }
                    }

                    //mainEWSFrom.addPanel(tabpagecontrol);
                    //_drawingdoc.Text = node.Text;

                    //frm.ShowDocumnet(_drawingdoc);
                }
            }
        }

        private void SaveController_Click(object sender, EventArgs e)
        {
            EWSTreeNode node = (EWSTreeNode)treeViewControl.SelectedNode;
            //EWSTreeNode parentnode;
            if (node != null)
            {
                if (node.Nodetype == TREE_NODE_TYPE.CONTROLLER)
                {

                    foreach (tblController tblcontroller in Global.EWS.m_tblSolution.m_tblControllerCollection)
                    {
                        if (tblcontroller.ControllerID == node.NodeID)
                        {
                            mainEWSFrom.SaveControllerOpenItems(tblcontroller.ControllerID);
                            tblcontroller.SaveDB();
                            Compiler compiler = new Compiler(mainEWSFrom);
                            foreach (tblPou tblpou in tblcontroller.m_tblPouCollection)
                            {
                                if (tblpou.pouName != "GLOBAL")
                                {
                                    compiler.CompilePOU(tblcontroller, tblpou);
                                }
                            }
                            break;
                        }
                    }
                }
            }
        }

        private void AddPOU(EWSTreeNode node, PROGRAM_IMAGELIST program_imagelist, int imageindex)
        {
            long ID = ((EWSTreeNode)node).NodeID;
            tblPou tblpou = new tblPou();
            tblpou.pouName = Global.EWS.m_tblSolution.GetControllerFromID(ID).GetNewPOUName();
            tblpou.Language = (PouLanguageType)program_imagelist;
            tblpou.ControllerID = ID;
            tblpou.oIndex = 0xffffff;
            tblpou.Insert();
            EWSTreeNode newnode = new EWSTreeNode(tblpou.pouName);
            newnode.NodeID = tblpou.pouID;
            newnode.ImageIndex = imageindex;
            newnode.SelectedImageIndex = imageindex;
            newnode.ContextMenuStrip = contextMenuStripPOU;
            node.Nodes.Add(newnode);
            Global.EWS.m_tblSolution.GetControllerFromID(ID).ResetCollection();
            Global.EWS.m_tblSolution.GetControllerFromID(ID).m_tblPouCollection = null;
            Global.EWS.m_tblSolution.GetControllerFromID(ID).ReindexPOUs();

        }

        private void AddSTPOU_Click(object sender, EventArgs e)
        {
            EWSTreeNode node = (EWSTreeNode)treeViewControl.SelectedNode;
            AddPOU(node, PROGRAM_IMAGELIST.ST, 15);
        }

        private void AddFBDPOU_Click(object sender, EventArgs e)
        {
            EWSTreeNode node = (EWSTreeNode)treeViewControl.SelectedNode;
            AddPOU(node, PROGRAM_IMAGELIST.FBD, 10);
        }

        private void AddSFCPOU_Click(object sender, EventArgs e)
        {
            EWSTreeNode node = (EWSTreeNode)treeViewControl.SelectedNode;
            AddPOU(node, PROGRAM_IMAGELIST.SFC, 14);
        }

        private void PasteController_Click(object sender, EventArgs e)
        {

        }

        private void CopyController_Click(object sender, EventArgs e)
        {

        }

        private void DeleteController_Click(object sender, EventArgs e)
        {

        }

        private void DeletePOU_Click(object sender, EventArgs e)
        {
            EWSTreeNode node = (EWSTreeNode)treeViewControl.SelectedNode;

            if (node != null)
            {
                if (node.Nodetype == TREE_NODE_TYPE.PROGRAM)
                {
                    tblPou tblpou = new tblPou();
                    tblpou.pouID = node.NodeID;
                    tblpou.Delete();
                }
            }
        }

        private void RenamePOU_Click(object sender, EventArgs e)
        {
            if (tmpSelectedNode != null && tmpSelectedNode.Parent != null)
            {
                treeViewControl.SelectedNode = tmpSelectedNode;
                treeViewControl.LabelEdit = true;
                if (!tmpSelectedNode.IsEditing)
                {
                    tmpSelectedNode.BeginEdit();
                }
            }

        }

        private void CopyPOU_Click(object sender, EventArgs e)
        {

        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void onlineControllerDownloadToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void offlineControllerDownloadToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void onlinePOUDownloadToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void treeViewControl_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Label != null)
            {
                if (e.Label.Length > 0)
                {
                    if (e.Label.IndexOfAny(new char[] { '@', '.', ',', '!' }) == -1)
                    {
                        long ID = ((EWSTreeNode)e.Node.Parent).NodeID;
                        if (!Global.EWS.m_tblSolution.GetControllerFromID(ID).CheckPOUNameExist(e.Label))
                        {
                            tblPou tblpou = Global.EWS.m_tblSolution.GetControllerFromID(ID).GetPouFromID(((EWSTreeNode)e.Node).NodeID);
                            tblpou.pouName = e.Label;
                            tblpou.Update();
                        }
                        e.Node.EndEdit(false);
                    }
                    else
                    {
                        /* Cancel the label edit action, inform the user, and 
                           place the node in edit mode again. */
                        e.CancelEdit = true;

                        e.Node.BeginEdit();
                    }
                }
                else
                {
                    /* Cancel the label edit action, inform the user, and 
                       place the node in edit mode again. */
                    e.CancelEdit = true;
                    MessageBox.Show("Invalid tree node label.\nThe label cannot be blank",
                       "Node Label Edit");
                    e.Node.BeginEdit();
                }
                treeViewControl.LabelEdit = false;
            }
        }

        private void moveUpPOU_Click(object sender, EventArgs e)
        {
            EWSTreeNode node = (EWSTreeNode)treeViewControl.SelectedNode;
            long pouid = ((EWSTreeNode)node).NodeID;
            long controllerid = ((EWSTreeNode)node.Parent).NodeID;
            tblPou tblpou = Global.EWS.m_tblSolution.GetControllerFromID(controllerid).GetPouFromID(pouid);
            if (tblpou.oIndex > 1)
            {
                Global.EWS.m_tblSolution.GetControllerFromID(controllerid).MoveUpPOU(tblpou.oIndex);
                TreeNode parent = node.Parent;
                if (parent != null)
                {
                    int index = parent.Nodes.IndexOf(node);
                    if (index > 0)
                    {
                        parent.Nodes.RemoveAt(index);
                        parent.Nodes.Insert(index - 1, node);
                    }
                }
            }
        }

        private void moveDownPOU_Click(object sender, EventArgs e)
        {
            EWSTreeNode node = (EWSTreeNode)treeViewControl.SelectedNode;
            long pouid = ((EWSTreeNode)node).NodeID;
            long controllerid = ((EWSTreeNode)node.Parent).NodeID;
            tblPou tblpou = Global.EWS.m_tblSolution.GetControllerFromID(controllerid).GetPouFromID(pouid);
            if (tblpou.oIndex != (Global.EWS.m_tblSolution.GetControllerFromID(controllerid).m_tblPouCollection.Count - 1))
            {
                Global.EWS.m_tblSolution.GetControllerFromID(controllerid).MoveDownPOU(tblpou.oIndex);
                TreeNode parent = node.Parent;
                if (parent != null)
                {
                    int index = parent.Nodes.IndexOf(node);
                    if (index < parent.Nodes.Count - 1)
                    {
                        parent.Nodes.RemoveAt(index);
                        parent.Nodes.Insert(index + 1, node);
                    }
                }
            }
        }

        private void CompileController_Click(object sender, EventArgs e)
        {
            EWSTreeNode node = (EWSTreeNode)treeViewControl.SelectedNode;
            if (node != null)
            {
                if (node.Nodetype == TREE_NODE_TYPE.CONTROLLER)
                {
                    mainEWSFrom.CompileController(Global.EWS.m_tblSolution.GetControllerFromID(node.NodeID));
                }
            }
        }

        private void compilePOUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EWSTreeNode node = (EWSTreeNode)treeViewControl.SelectedNode;
            long pouid = ((EWSTreeNode)node).NodeID;
            //bool ret = false;
            Compiler compiler = new Compiler(mainEWSFrom);
            compiler.CompilePOU(Global.EWS.m_tblSolution.GetPouFromID(pouid));

        }

    }
}
