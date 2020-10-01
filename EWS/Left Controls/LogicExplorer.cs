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
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DCS.LeftControls
{
    public partial class LogicExplorer : ToolWindow
    {
        protected System.Windows.Forms.TreeNode tmpSelectedNode;
        protected string SelectedNodeString;
        //MainForm mainform;
        //public LogicExplorer(MainForm _parent)
        //{
        //    mainform = _parent;
        //    InitializeComponent();
        //    Initialize();
        // //   tblSolution.m_tblSolution().m_tblControllerCollection.tblControllerChanged += new tblControllerChangedEventHandler(updateControllerChangeEventhandler);

        //}
        public LogicExplorer( )
        {
            InitializeComponent();
            Initialize();
        }

        //private void updateControllerChangeEventhandler(object sender, EventArgs e)
        public void updateChangeEventhandler()
        {
            this.treeViewControl.Nodes.Clear();
            Initialize();
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
                        if (!tblSolution.m_tblSolution().GetControllerFromID(ID).CheckPOUNameExist(e.Label))
                        {
                            tblPou tblpou = tblSolution.m_tblSolution().GetControllerFromID(ID).GetPouFromID(((EWSTreeNode)e.Node).NodeID);
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
        private void moveUpPOU_Click(object sender, EventArgs e)
        {
            EWSTreeNode node = (EWSTreeNode)treeViewControl.SelectedNode;
            long pouid = ((EWSTreeNode)node).NodeID;
            long controllerid = ((EWSTreeNode)node.Parent).NodeID;
            tblPou tblpou = tblSolution.m_tblSolution().GetControllerFromID(controllerid).GetPouFromID(pouid);
            if (tblpou.oIndex > 1)
            {
                tblSolution.m_tblSolution().GetControllerFromID(controllerid).MoveUpPOU(tblpou.oIndex);
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
            tblPou tblpou = tblSolution.m_tblSolution().GetControllerFromID(controllerid).GetPouFromID(pouid);
            if (tblpou.oIndex != (tblSolution.m_tblSolution().GetControllerFromID(controllerid).m_tblPouCollection.Count - 1))
            {
                tblSolution.m_tblSolution().GetControllerFromID(controllerid).MoveDownPOU(tblpou.oIndex);
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
                    MainForm.Instance().CompileController(tblSolution.m_tblSolution().GetControllerFromID(node.NodeID));
                }
            }
        }

        private void compilePOUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                EWSTreeNode node = (EWSTreeNode)treeViewControl.SelectedNode;
                long pouid = ((EWSTreeNode)node).NodeID;
                //bool ret = false;
                Compiler compiler = new Compiler(/*mainform*/);
                tblPou tblpou = tblSolution.m_tblSolution().GetPouFromID(pouid);
                string filename;
                if (tblpou.Language == PouLanguageType.ST)
                {
                    filename = Common.ProjectPath + "\\LOGIC";
                    filename += "\\";
                    filename += tblSolution.m_tblSolution().GetControllerobjectofPOUID(tblpou.pouID).ControllerName;
                    filename += "\\";
                    filename += tblpou.pouName + ".st";
                    using (StreamWriter writer = new StreamWriter(filename))
                    {
                        writer.WriteLine(tblpou.STText);
                        writer.Close();
                    }

                }
                compiler.CompilePOU(tblSolution.m_tblSolution().GetPouFromID(pouid));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        bool Initialize()
        {
            bool ret = true;
            EWSTreeNode node;
            EWSTreeNode node2;
            EWSTreeNode node4;

            node = new EWSTreeNode(tblSolution.m_tblSolution().SolutionName);
            node.ContextMenuStrip = contextMenuStripRoot;
            node.ImageIndex = 0;
            node.SelectedImageIndex = 1;
            treeViewControl.Nodes.Add(node);


            foreach (tblController tblcontroller in tblSolution.m_tblSolution().m_tblControllerCollection)
            {
                if (tblcontroller.type == (int)StationType.LCU)
                {
                    node2 = new EWSTreeNode(tblcontroller.ControllerName);
                    node2.ContextMenuStrip = contextMenuStripController;
                    node2.ImageIndex = 16;
                    node2.NodeID = tblcontroller.ControllerID;
                    node2.Nodetype = TREE_NODE_TYPE.CONTROLLER;
                    node2.ImageIndex = 2;
                    node2.SelectedImageIndex = 3;
                    node2.sqlobject = tblcontroller;
                    node.Nodes.Add(node2);

                    foreach (tblPou tblpou in tblcontroller.m_tblPouCollection)
                    {
                        if ("GLOBAL" != tblpou.pouName)
                        {
                            node4 = new EWSTreeNode(tblpou.pouName);
                            node4.NodeID = tblpou.pouID;
                            node2.sqlobject = tblpou;
                            node4.Nodetype = TREE_NODE_TYPE.PROGRAM;
                            node4.ContextMenuStrip = contextMenuStripPOU;
                            switch ((PROGRAM_LANGUAGE)tblpou.Language)
                            {
                                case PROGRAM_LANGUAGE.ENUM_PROGRAM_LANGUAGE_FBD:
                                    node4.ImageIndex = 4;
                                    node4.SelectedImageIndex = 5;
                                    break;
                                case PROGRAM_LANGUAGE.ENUM_PROGRAM_LANGUAGE_IL:
                                    node4.ImageIndex = 6;
                                    node4.SelectedImageIndex = 171;
                                    break;
                                case PROGRAM_LANGUAGE.ENUM_PROGRAM_LANGUAGE_LD:
                                    node4.ImageIndex = 8;
                                    node4.SelectedImageIndex = 9;
                                    break;
                                case PROGRAM_LANGUAGE.ENUM_PROGRAM_LANGUAGE_SFC:
                                    node4.ImageIndex = 10;
                                    node4.SelectedImageIndex = 11;
                                    break;
                                case PROGRAM_LANGUAGE.ENUM_PROGRAM_LANGUAGE_ST:
                                    node4.ImageIndex = 12;
                                    node4.SelectedImageIndex = 13;
                                    break;
                            }
                            node2.Nodes.Add(node4);
                        }
                    }
                }
            }

            foreach (tblController tblcontroller in tblSolution.m_tblSolution().m_tblControllerCollection)
            {
                if (tblcontroller.type == (int)StationType.DUMMY)
                {
                    node2 = new EWSTreeNode("User Defined Function");
                    node2.ContextMenuStrip = contextMenuStripUDFs;
                    node2.ImageIndex = 14;
                    node2.SelectedImageIndex = 15;
                    node2.NodeID = tblcontroller.ControllerID;
                    node2.sqlobject = tblcontroller;
                    node2.Nodetype = TREE_NODE_TYPE.FUNCTIONS;
                    node.Nodes.Add(node2);

                    foreach (tblPou tblpou in tblcontroller.m_tblPouCollection)
                    {
                        if (tblpou.Type == POUTYPE.FUNCTION)
                        {
                            node4 = new EWSTreeNode(tblpou.pouName);
                            node4.NodeID = tblpou.pouID;
                            node2.sqlobject = tblpou;
                            node4.Nodetype = TREE_NODE_TYPE.FUNCTION;
                            node4.ContextMenuStrip = contextMenuStripUDF;
                            switch ((PROGRAM_LANGUAGE)tblpou.Language)
                            {
                                case PROGRAM_LANGUAGE.ENUM_PROGRAM_LANGUAGE_FBD:
                                    node4.ImageIndex = 4;
                                    node4.SelectedImageIndex = 5;
                                    break;

                                case PROGRAM_LANGUAGE.ENUM_PROGRAM_LANGUAGE_ST:
                                    node4.ImageIndex = 12;
                                    node4.SelectedImageIndex = 13;
                                    break;
                            }
                            node2.Nodes.Add(node4);
                        }
                    }
                }
            }

            foreach (tblController tblcontroller in tblSolution.m_tblSolution().m_tblControllerCollection)
            {
                if (tblcontroller.type == (int)StationType.DUMMY)
                {
                    node2 = new EWSTreeNode("User Defined Function Block");
                    node2.ContextMenuStrip = contextMenuStripUDFBs;
                    
                    node2.ImageIndex = 16;
                    node2.SelectedImageIndex = 17;
                    node2.NodeID = tblcontroller.ControllerID;
                    node2.Nodetype = TREE_NODE_TYPE.FUNCTIONS;
                    node2.sqlobject = tblcontroller;
                    node.Nodes.Add(node2);

                    foreach (tblPou tblpou in tblcontroller.m_tblPouCollection)
                    {
                        if (tblpou.Type == POUTYPE.FUNCTIONBLOCK)
                        {
                            node4 = new EWSTreeNode(tblpou.pouName);
                            node4.NodeID = tblpou.pouID;
                            node2.sqlobject = tblpou;
                            node4.Nodetype = TREE_NODE_TYPE.FUNCTION;
                            node4.ContextMenuStrip = contextMenuStripUDF;
                            switch ((PROGRAM_LANGUAGE)tblpou.Language)
                            {
                                case PROGRAM_LANGUAGE.ENUM_PROGRAM_LANGUAGE_FBD:
                                    node4.ImageIndex = 4;
                                    node4.SelectedImageIndex = 5;
                                    break;

                                case PROGRAM_LANGUAGE.ENUM_PROGRAM_LANGUAGE_ST:
                                    node4.ImageIndex = 12;
                                    node4.SelectedImageIndex = 13;
                                    break;
                            }
                            node2.Nodes.Add(node4);
                        }
                    }
                }
            }
            
            //node = new EWSTreeNode("User Defined Function");
            //node.ContextMenuStrip = contextMenuStripUDFs;
            //node.ImageIndex = 0;
            //node.SelectedImageIndex = 1;
            //node.Nodetype = TREE_NODE_TYPE.FUNCTIONS;
            //treeViewControl.Nodes.Add(node);
            //foreach (tblFunction tblfunction in tblSolution.m_tblSolution().m_tblFunctionCollection)
            //{
            //    if (tblfunction.IsFunction && !tblfunction.IsStandard)
            //    {
            //        node4 = new EWSTreeNode(tblfunction.FunctionName);
            //        node4.NodeID = tblfunction.FunctionID;
            //        node4.Nodetype = TREE_NODE_TYPE.FUNCTION;
            //        node4.ContextMenuStrip = contextMenuStripUDF;

            //        node4.ImageIndex = 15;
            //        node4.SelectedImageIndex = 15;

            //        node.Nodes.Add(node4);
            //    }

            //}

            //node = new EWSTreeNode("User Defined Function Block");
            //node.ContextMenuStrip = contextMenuStripUDFBs;
            //node.ImageIndex = 0;
            //node.SelectedImageIndex = 1;
            //node.Nodetype = TREE_NODE_TYPE.FUNCTIONBLOCKS;
            //treeViewControl.Nodes.Add(node);
            //foreach (tblFunction tblfunction in tblSolution.m_tblSolution().m_tblFunctionCollection)
            //{
            //    if (!tblfunction.IsFunction && !tblfunction.IsStandard)
            //    {
            //        node4 = new EWSTreeNode(tblfunction.FunctionName);
            //        node4.NodeID = tblfunction.FunctionID;
            //        node4.Nodetype = TREE_NODE_TYPE.FUNCTIONBLOCK;
            //        node4.ContextMenuStrip = contextMenuStripUDFB;

            //        node4.ImageIndex = 15;
            //        node4.SelectedImageIndex = 15;

            //        node.Nodes.Add(node4);
            //    }

            //}
            return ret;
        }

        private void treeViewControl_DoubleClick(object sender, EventArgs e)
        {
            //TabPageControl tabpagecontrol;
            EWSTreeNode node = (EWSTreeNode)treeViewControl.SelectedNode;
            EWSTreeNode parentnode;
            if (node != null)
            {
                switch(node.Nodetype)
                {
                    case TREE_NODE_TYPE.PROGRAM:
                        #region PROGRAM
                        do
                        {
                            parentnode = (EWSTreeNode)node.Parent;
                            node = parentnode;

                        } while (parentnode.Nodetype != TREE_NODE_TYPE.CONTROLLER);
                        node = (EWSTreeNode)treeViewControl.SelectedNode;
                        foreach (tblController tblcontroller in tblSolution.m_tblSolution().m_tblControllerCollection)
                        {
                            if (tblcontroller.type == (int)StationType.LCU)
                            {
                                foreach (tblPou tblpou in tblcontroller.m_tblPouCollection)
                                {
                                    if (tblpou.pouID == node.NodeID)
                                    {
                                        switch ((PROGRAM_LANGUAGE)tblpou.Language)
                                        {
                                            case PROGRAM_LANGUAGE.ENUM_PROGRAM_LANGUAGE_FBD:

                                                if (!MainForm.Instance().CheckDocIsOpen(TABPAGETYPE.FBD, tblpou.pouID))
                                                {
                                                    TabFBDPageControl tabfbdpagecontrol = new TabFBDPageControl(tblpou.pouID);
                                                    tabfbdpagecontrol.TitleText = node.Text;
                                                    tabfbdpagecontrol.LoadTabPage();
                                                    tabfbdpagecontrol.UpdateToolstripNavigation();
                                                    MainForm.Instance().m_propertyGrid.SelectedObject = tabfbdpagecontrol.PouObject;
                                                    MainForm.Instance().m_propertyGrid.HiddenProperties = tabfbdpagecontrol.PouObject.PropertyGridFilterH();
                                                    MainForm.Instance().m_propertyGrid.BrowsableProperties = tabfbdpagecontrol.PouObject.PropertyGridFilterS();
                                                    //tabfbdpagecontrol.ID = tblpou.pouID;
                                                    tabfbdpagecontrol.drawarea.Size = new System.Drawing.Size(1454, 969);
                                                    tabfbdpagecontrol.drawarea.Invalidate();

                                                    MainForm.Instance().ShowTabPage(tabfbdpagecontrol);
                                                    tabfbdpagecontrol.drawarea.Initialize();
                                                    tabfbdpagecontrol.drawarea.Refresh();
                                                    MainForm.Instance().UpdateToolbox();
                                                }
                                                else
                                                {
                                                    MainForm.Instance().activateDoc(TABPAGETYPE.FBD, tblpou.pouID);
                                                }
                                                break;
                                            case PROGRAM_LANGUAGE.ENUM_PROGRAM_LANGUAGE_SFC:
                                                if (!MainForm.Instance().CheckDocIsOpen(TABPAGETYPE.SFC, tblpou.pouID))
                                                {
                                                    TabSFCPageControl tabsfcpagecontrol = new TabSFCPageControl(tblpou.pouID);
                                                    tabsfcpagecontrol.TitleText = node.Text;
                                                    tabsfcpagecontrol.LoadTabPage();
                                                    tabsfcpagecontrol.UpdateToolstripNavigation();
                                                    MainForm.Instance().m_propertyGrid.SelectedObject = tabsfcpagecontrol.PouObject;
                                                    MainForm.Instance().m_propertyGrid.HiddenProperties = tabsfcpagecontrol.PouObject.PropertyGridFilterH();
                                                    MainForm.Instance().m_propertyGrid.BrowsableProperties = tabsfcpagecontrol.PouObject.PropertyGridFilterS();
                                                    //tabfbdpagecontrol.ID = tblpou.pouID;
                                                    tabsfcpagecontrol.drawarea.Size = new System.Drawing.Size(1454, 969);
                                                    tabsfcpagecontrol.drawarea.Invalidate();

                                                    MainForm.Instance().ShowTabPage(tabsfcpagecontrol);
                                                    tabsfcpagecontrol.drawarea.Initialize();
                                                    tabsfcpagecontrol.drawarea.Refresh();
                                                    MainForm.Instance().UpdateToolbox();
                                                }
                                                break;
                                            case PROGRAM_LANGUAGE.ENUM_PROGRAM_LANGUAGE_ST:
                                                if (!MainForm.Instance().CheckDocIsOpen(TABPAGETYPE.ST, tblpou.pouID))
                                                {
                                                    TabSTPageControl tabstpagecontrol = new TabSTPageControl(tblpou.pouID);
                                                    MainForm.Instance().m_propertyGrid.SelectedObject = tabstpagecontrol.PouObject;
                                                    MainForm.Instance().m_propertyGrid.HiddenProperties = tabstpagecontrol.PouObject.PropertyGridFilterH();
                                                    MainForm.Instance().m_propertyGrid.BrowsableProperties = tabstpagecontrol.PouObject.PropertyGridFilterS();
                                                    
                                                    // tabstpagecontrol.ImageIndex = 0;
                                                    tabstpagecontrol.TitleText = node.Text;
                                                    tabstpagecontrol.LoadTabPage();
                                                    MainForm.Instance().ShowTabPage(tabstpagecontrol);
                                                }
                                                else
                                                {
                                                    MainForm.Instance().activateDoc(TABPAGETYPE.ST, tblpou.pouID);
                                                }
                                                break;
                                        }


                                        return;
                                        //break;
                                    }
                                }
                            }
                        }
                        break; 
                        #endregion
                    case TREE_NODE_TYPE.FUNCTION:
                        #region FUNCTION
                        
                        node = (EWSTreeNode)treeViewControl.SelectedNode;
                        //foreach (tblFunction tblfunction in tblSolution.m_tblSolution().m_tblFunctionCollection)
                        foreach(tblPou tblpou in tblSolution.m_tblSolution().Dummytblcontroller.m_tblPouCollection)
                        {
                            //if (tblfunction.FunctionName.ToUpper() == node.Text.ToUpper())
                            if (tblpou.pouID == node.NodeID)
                            {

                                switch ((PROGRAM_LANGUAGE)tblpou.Language)
                                        {
                                            case PROGRAM_LANGUAGE.ENUM_PROGRAM_LANGUAGE_FBD:

                                                if (!MainForm.Instance().CheckDocIsOpen(TABPAGETYPE.FBD, tblpou.pouID))
                                                {
                                                    TabFBDPageControl tabudfbdpagecontrol = new TabFBDPageControl(tblpou.pouID);
                                                    tabudfbdpagecontrol.TitleText = node.Text;
                                                    tabudfbdpagecontrol.LoadTabPage();
                                                    tabudfbdpagecontrol.UpdateToolstripNavigation();
                                                    MainForm.Instance().m_propertyGrid.SelectedObject = tabudfbdpagecontrol.PouObject;
                                                    MainForm.Instance().m_propertyGrid.HiddenProperties = tabudfbdpagecontrol.PouObject.PropertyGridFilterH();
                                                    MainForm.Instance().m_propertyGrid.BrowsableProperties = tabudfbdpagecontrol.PouObject.PropertyGridFilterS();
                                                    //tabudfbdpagecontrol.ID = tblpou.pouID;
                                                    tabudfbdpagecontrol.drawarea.Size = new System.Drawing.Size(1454, 969);
                                                    tabudfbdpagecontrol.drawarea.Invalidate();

                                                    MainForm.Instance().ShowTabPage(tabudfbdpagecontrol);
                                                    tabudfbdpagecontrol.drawarea.Initialize();
                                                    tabudfbdpagecontrol.drawarea.Refresh();
                                                    MainForm.Instance().UpdateToolbox();
                                                }
                                                else
                                                {
                                                    MainForm.Instance().activateDoc(TABPAGETYPE.FBD, tblpou.pouID);
                                                }
                                                break;
                                            
                                            case PROGRAM_LANGUAGE.ENUM_PROGRAM_LANGUAGE_ST:
                                                if (!MainForm.Instance().CheckDocIsOpen(TABPAGETYPE.ST, tblpou.pouID))
                                                {
                                                    TabSTPageControl tabstpagecontrol = new TabSTPageControl(tblpou.pouID);
                                                    MainForm.Instance().m_propertyGrid.SelectedObject = tabstpagecontrol.PouObject;
                                                    MainForm.Instance().m_propertyGrid.HiddenProperties = tabstpagecontrol.PouObject.PropertyGridFilterH();
                                                    MainForm.Instance().m_propertyGrid.BrowsableProperties = tabstpagecontrol.PouObject.PropertyGridFilterS();
                                                    
                                                    // tabstpagecontrol.ImageIndex = 0;
                                                    tabstpagecontrol.TitleText = node.Text;
                                                    tabstpagecontrol.LoadTabPage();
                                                    MainForm.Instance().ShowTabPage(tabstpagecontrol);
                                                }
                                                else
                                                {
                                                    MainForm.Instance().activateDoc(TABPAGETYPE.ST, tblpou.pouID);
                                                }
                                                break;
                                        }


                                        return;
                                        //break;
                                    }
                                
                        }
                        break;
                        #endregion
                    case TREE_NODE_TYPE.FUNCTIONBLOCK:

                        break;
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

                    foreach (tblController tblcontroller in tblSolution.m_tblSolution().m_tblControllerCollection)
                    {
                        if (tblcontroller.type == 0)
                        {
                            if (tblcontroller.ControllerID == node.NodeID)
                            {
                                MainForm.Instance().SaveControllerOpenItems(tblcontroller.ControllerID);
                                tblcontroller.SaveDB();
                                Compiler compiler = new Compiler(/*mainform*/);
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
        }

        private void AddPOU(EWSTreeNode node, PROGRAM_IMAGELIST program_imagelist, int imageindex)
        {
            long ID = ((EWSTreeNode)node).NodeID;
            tblPou tblpou = new tblPou();
            tblpou.pouName = tblSolution.m_tblSolution().GetControllerFromID(ID).GetNewPOUName();
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
            //tblSolution.m_tblSolution().GetControllerFromID(ID).ResetCollection();
            //tblSolution.m_tblSolution().GetControllerFromID(ID).m_tblPouCollection = null;
            //tblSolution.m_tblSolution().GetControllerFromID(ID).ReindexPOUs();

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

        private void refereshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.treeViewControl.Nodes.Clear();
            Initialize();
        }

        

        private void contextMenuStripUDFBs_Opening(object sender, CancelEventArgs e)
        {

        }

        private void toolStripMenuItemAddUDF_Click(object sender, EventArgs e)
        {
            addUD(true, POUTYPE.FUNCTION, POUEXECUTIONTYPE.UDFunction,"User Defined Function");

        }

        private void toolStripMenuItemAddUDFB_Click(object sender, EventArgs e)
        {
            addUD(false, POUTYPE.FUNCTIONBLOCK, POUEXECUTIONTYPE.UDFunctionBlock, "User Defined Function Block");
            /*
            Mode	762	2048	1	1	0	0	
State	762	2048	1	128	0	1	
ALS	762	2048	1	128	0	2	Alarm Status
ALA	762	2048	1	128	0	3	Alarm Acknowledge
ALB	762	2048	1	128	0	4	Alarm Block
AEB	762	2048	1	128	0	5	Alarm Event Block
OPN	762	2048	1	128	0	6	Operator Note
OPH	762	2048	1	128	0	7	Operator Help
OPM	762	2048	1	128	0	8	Operator Message
MNN	762	2048	1	128	0	9	Maintenance Note
             * */

        }
        private  void addUD(bool _isfunction, POUTYPE _poutype, POUEXECUTIONTYPE _pouexecutiontype,string _nodetreename)
        {
            AddUDPouForm addudpouform = new AddUDPouForm();
            if (DialogResult.OK == addudpouform.ShowDialog())
            {
                int _type = 0;
                if (_isfunction)
                {
                    _type = 0;
                }
                else
                {
                    _type = (int)VarType.USERDEFUNED;
                }
                foreach (tblFunction tblfunction in tblSolution.m_tblSolution().m_tblFunctionCollection)
                {
                    if (tblfunction.IsFunction == _isfunction)
                    {
                        if (tblfunction.Type > _type)
                        {
                            _type = tblfunction.Type;
                        }
                    }
                }
                
                if (CheckUDNameIsValid(addudpouform.pouname))
                {
                    tblPou tblpou = new tblPou();
                    tblpou.pouName = addudpouform.pouname;
                    tblpou.Description = addudpouform.poudescription;
                    tblpou.Type = _poutype;
                    tblpou.Language = addudpouform.pouLanguageType;
                    tblpou.executiontype = _pouexecutiontype;
                    tblpou.ControllerID = tblSolution.m_tblSolution().Dummytblcontroller.ControllerID;
                    tblpou.Insert();
                    tblController tblcontroller = tblSolution.m_tblSolution().GetControllerFromID(tblpou.ControllerID);
                    tblcontroller.m_tblPouCollection.Add(tblpou);
                    tblcontroller.SavePouDB();
                    tblFunction _tblfunction = new tblFunction();
                    _tblfunction.FunctionName = addudpouform.pouname;
                    _tblfunction.Description = addudpouform.poudescription;
                    _tblfunction.Language = (int)addudpouform.pouLanguageType;
                    _tblfunction.SolutionID = tblSolution.m_tblSolution().SolutionID;
                    _tblfunction.FunctionGroup = (int)FunctionGroup.USER_DEFINED;
                    _tblfunction.IsFunction = _isfunction;
                    _tblfunction.IsStandard = false;
                    _tblfunction.Extensible = false;
                    _tblfunction.Overloaded = false;
                    _tblfunction.Width = 4;
                    _tblfunction.Mode = 3;
                    _tblfunction.Type = _type + 1;
                    int ret = _tblfunction.Insert();
                    if (ret == 0)
                    {
                        //tblSolution.m_tblSolution().functionbyType.Add(_tblfunction.Type, _tblfunction);
                        //tblSolution.m_tblSolution().functionbyName.Add(_tblfunction.FunctionName, _tblfunction);
                        //EWSTreeNode _node;
                        foreach (TreeNode rootnode in treeViewControl.Nodes)
                        {
                            foreach (TreeNode _node in rootnode.Nodes)
                            {
                                //_node = (EWSTreeNode)node;
                                //while (_node.NextNode != null)
                                {
                                    if (_node.Text == _nodetreename)
                                    {
                                        EWSTreeNode node4 = new EWSTreeNode(tblpou.pouName);
                                        node4.NodeID = tblpou.pouID;
                                        if (_isfunction)
                                        {
                                            node4.Nodetype = TREE_NODE_TYPE.FUNCTION;
                                            node4.ContextMenuStrip = contextMenuStripUDF;
                                        }
                                        else
                                        {
                                            node4.Nodetype = TREE_NODE_TYPE.FUNCTIONBLOCK;
                                            node4.ContextMenuStrip = contextMenuStripUDFB;
                                        }
                                        switch ((PROGRAM_LANGUAGE)tblpou.Language)
                                        {
                                            case PROGRAM_LANGUAGE.ENUM_PROGRAM_LANGUAGE_FBD:
                                                node4.ImageIndex = 4;
                                                node4.SelectedImageIndex = 5;
                                                break;

                                            case PROGRAM_LANGUAGE.ENUM_PROGRAM_LANGUAGE_ST:
                                                node4.ImageIndex = 12;
                                                node4.SelectedImageIndex = 13;
                                                break;
                                        }


                                        _node.Nodes.Add(node4);
                                        return;
                                    }
                                    //   _node = (EWSTreeNode)_node.NextNode;
                                }
                            }

                        }
                    }
                }
            }
        }


        bool CheckUDNameIsValid(string _name)
        {
            if (tblSolution.m_tblSolution().functionbyName.ContainsKey(_name.ToUpper()))
            {
                return false;
            }
            foreach (tblPou tblpou in tblSolution.m_tblSolution().Dummytblcontroller.m_tblPouCollection)
            {
                if (tblpou.pouName.ToUpper() == _name.ToUpper())
                {
                    return false;
                }
            }
            return true;
        }

        private void toolStripMenuItemPinsUDF_Click(object sender, EventArgs e)
        {
            UDFPinForm udfpinform = new UDFPinForm(true,treeViewControl.SelectedNode.Text.ToUpper());
            if (DialogResult.OK == udfpinform.ShowDialog())
            {

            }
        }

        private void toolStripMenuItemPinsUDFB_Click(object sender, EventArgs e)
        {
            UDFPinForm udfpinform = new UDFPinForm(false, treeViewControl.SelectedNode.Text.ToUpper());
            if (DialogResult.OK == udfpinform.ShowDialog())
            {

            }
        }

        private void toolStripMenuItemDeleteUDF_Click(object sender, EventArgs e)
        {
            DeleteUD(TREE_NODE_TYPE.FUNCTION);
        }

        private void toolStripMenuItemRenameUDF_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItemDeleteUDFB_Click(object sender, EventArgs e)
        {
            DeleteUD(TREE_NODE_TYPE.FUNCTIONBLOCK);
        }

        private void DeleteUD(TREE_NODE_TYPE _tree_node_type)
        {
            EWSTreeNode node = (EWSTreeNode)treeViewControl.SelectedNode;
            string name = node.Text.ToUpper();
            tblFunction _tblfunction = null;
            tblPou _tblpou = null;
            if (node != null)
            {
                if (node.Nodetype == _tree_node_type)
                {
                    
                    
                    foreach (tblFunction tblfunction in tblSolution.m_tblSolution().m_tblFunctionCollection)
                    {
                        if (tblfunction.FunctionName.ToUpper() == name)
                        {
                            _tblfunction = tblfunction;
                            tblSolution.m_tblSolution().functionbyType.Remove(_tblfunction.Type);
                            tblSolution.m_tblSolution().functionbyName.Remove(_tblfunction.FunctionName);
                            break;
                        }
                    }
                    if (_tblfunction != null)
                    {
                        tblSolution.m_tblSolution().m_tblFunctionCollection.Remove(_tblfunction);
                        _tblfunction.Delete();
                    }
                    foreach (tblPou tblpou in tblSolution.m_tblSolution().Dummytblcontroller.m_tblPouCollection)
                    {
                        if (tblpou.pouName.ToUpper() == name)
                        {
                            _tblpou = tblpou;
                            break;
                        }
                    }
                    if (_tblpou != null)
                    {
                        //tblSolution.m_tblSolution().Dummytblcontroller.m_tblPouCollection.Remove(_tblpou);
                        _tblpou.Delete();
                    }

                }
                treeViewControl.Nodes.Remove(treeViewControl.SelectedNode);
            }
        }

        private void toolStripMenuItemRenameUDFB_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItemPaste_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItemPasteUDF_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItemCopyUDF_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItemCopyUDFB_Click(object sender, EventArgs e)
        {

        }

        

        
        

        

        

    }
}
