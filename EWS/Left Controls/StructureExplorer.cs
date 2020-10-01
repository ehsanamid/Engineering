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
    public partial class StructureExplorer : ToolWindow
    {
        protected System.Windows.Forms.TreeNode tmpSelectedNode;
        protected string SelectedNodeString;
        public TabPlantStructurePageControl tabplantstructurepagecontrol;
        EWSTreeNode SelectedForCopynode = null;
        //MainForm mainform;
        //public StructureExplorer(MainForm _parent)
        //{
        //    mainform = _parent;
        //    InitializeComponent();
        //    Initialize();
        //}
        public StructureExplorer()
        {
            InitializeComponent();
            Initialize();
        }

        public void updateChangeEventhandler()
        {
            this.treeViewControl.Nodes.Clear();
            Initialize();
        }

        bool Initialize()
        {
            bool ret = true;
            EWSTreeNode rootnode;
            EWSTreeNode childnode;
            rootnode = new EWSTreeNode(Common.DatabaseName);

            rootnode.ImageIndex = 0;
            rootnode.SelectedImageIndex = 0;
            rootnode.Nodetype = TREE_NODE_TYPE.Root;
            rootnode.sqlobject = tblSolution.m_tblSolution();
            rootnode.ContextMenuStrip = contextMenuStripStructure;
            treeViewControl.Nodes.Add(rootnode);
            long _parentid = -1;
            List<tblPlantStructure> nodes = tblSolution.m_tblSolution().GetPlantStructure(_parentid);


            foreach (tblPlantStructure tblplantstructure in nodes)
            {
                if (!tblplantstructure.Visible)
                {
                    continue;
                }
                childnode = new EWSTreeNode(tblplantstructure.Name);
                childnode.NodeID = tblplantstructure.ID;
                childnode.sqlobject = tblplantstructure;
                childnode.ContextMenuStrip = contextMenuStripStructure;
                if (tblplantstructure.IsFolder)
                {
                    
                    if (tblplantstructure.IsObject)
                    {
                        childnode.ImageIndex = 1;
                        childnode.SelectedImageIndex = 1;
                        childnode.Nodetype = TREE_NODE_TYPE.ObjectFollder;
                    }
                    else
                    {
                        childnode.ImageIndex = 4;
                        childnode.SelectedImageIndex = 4;
                        childnode.Nodetype = TREE_NODE_TYPE.PropertyFolder;
                    }
                }
                else
                {
                    
                    if (tblplantstructure.IsObject)
                    {
                        childnode.ImageIndex = 2;
                        childnode.SelectedImageIndex = 2;
                        childnode.Nodetype = (TREE_NODE_TYPE)tblplantstructure.Type;
                    }
                    else
                    {
                        childnode.ImageIndex = 3;
                        childnode.SelectedImageIndex = 3;
                        childnode.Nodetype = (TREE_NODE_TYPE)tblplantstructure.Type;
                    }
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
                if (!tblplantstructure.Visible)
                {
                    continue;
                }
                childnode = new EWSTreeNode(tblplantstructure.Name);
                childnode.NodeID = tblplantstructure.ID;
                childnode.sqlobject = tblplantstructure;
                childnode.ContextMenuStrip = contextMenuStripStructure;
                if (tblplantstructure.IsFolder)
                {
                    childnode.ImageIndex = 1;
                    childnode.SelectedImageIndex = 1;
                    if (tblplantstructure.IsObject)
                    {
                        childnode.Nodetype = TREE_NODE_TYPE.ObjectFollder;
                    }
                    else
                    {
                        childnode.Nodetype = TREE_NODE_TYPE.PropertyFolder;
                    }
                }
                else
                {

                    if (tblplantstructure.IsObject)
                    {
                        childnode.ImageIndex = 2;
                        childnode.SelectedImageIndex = 2;
                        childnode.Nodetype = (TREE_NODE_TYPE)tblplantstructure.Type;
                    }
                    else
                    {
                        childnode.ImageIndex = 3;
                        childnode.SelectedImageIndex = 3;
                        childnode.Nodetype = (TREE_NODE_TYPE)tblplantstructure.Type;
                    }
                }
                
                parentnode.Nodes.Add(childnode);
                AddNodeToPlantStructureTree(childnode, childnode.NodeID);
            }

        }


        private void treeViewControl_Click(object sender, EventArgs e)
        {
            
        }

        private void treeViewControl_DoubleClick(object sender, EventArgs e)
        {
            UpdateTabPage();
        }

        private void UpdateTabPage()
        {
            long ID = -1;
            EWSTreeNode node = (EWSTreeNode)treeViewControl.SelectedNode;
            if (node.sqlobject is tblSolution)
            {
                ID = -1;
            }
            else
            {
                ID = node.NodeID;
            }
            //if (((tblPlantStructure)node.sqlobject).IsObject)
            //{
            if (!MainForm.Instance().CheckDocIsOpen(TABPAGETYPE.PLANT_STRUCTURE, tblSolution.m_tblSolution().SolutionID))
            {
                tabplantstructurepagecontrol = new TabPlantStructurePageControl(tblSolution.m_tblSolution().SolutionID);
                MainForm.Instance().ShowTabPage(tabplantstructurepagecontrol);
            }

            tabplantstructurepagecontrol.plantstructurelistview.Items.Clear();


            foreach (tblPlantStructure tblplantstructure in tblSolution.m_tblSolution().m_tblPlantStructureCollection)
            {
                if (ID == tblplantstructure.ParentID)
                {
                    ListViewItem lvi = new ListViewItem(tblplantstructure.ID.ToString());
                    lvi.SubItems.Add(tblplantstructure.Name);
                    lvi.SubItems.Add(tblplantstructure.Description);
                    if (tblplantstructure.IsObject)
                    {
                        if (!tblplantstructure.IsFolder)
                        {
                            int type = tblplantstructure.Type;
                            lvi.SubItems.Add(tblSolution.m_tblSolution().PlantStructureObject[type].Name);
                            lvi.ImageIndex = 1;
                        }
                        else
                        {
                            lvi.SubItems.Add("");
                            lvi.ImageIndex = 0;
                        }
                    }
                    else
                    {
                        if (!tblplantstructure.IsFolder)
                        {
                            int type = tblplantstructure.Type;
                            lvi.SubItems.Add(tblSolution.m_tblSolution().PlantStructureProperty[type].Name);
                            lvi.SubItems.Add(tblplantstructure.PropertyPath);
                            lvi.ImageIndex = 2;
                        }
                        else
                        {
                            lvi.SubItems.Add("");
                            lvi.ImageIndex = 3;
                        }
                    }

                    tabplantstructurepagecontrol.plantstructurelistview.Items.Add(lvi);
                }
            }

            //}
        }



        #region Menu
        private void ToolStripMenuItemAddObject_Click(object sender, EventArgs e)
        {
            EWSTreeNode node = (EWSTreeNode)treeViewControl.SelectedNode;
            PlantStructureObjectForm plantstructureobjectform = new PlantStructureObjectForm();
            //plantstructureobjectform.isfolder = false;
            //plantstructureobjectform.title = "Plant Structure Object Folder";
            if (plantstructureobjectform.ShowDialog() == DialogResult.OK)
            {
                tblPlantStructure tblplantstructure = new tblPlantStructure();
                tblplantstructure.Name = plantstructureobjectform.name;
                tblplantstructure.Description = plantstructureobjectform.description;
                tblplantstructure.Type = plantstructureobjectform.type;
                tblplantstructure.ParentID = node.NodeID;
                tblplantstructure.SolutionID = tblSolution.m_tblSolution().SolutionID;
                tblplantstructure.IsFolder = false;
                tblplantstructure.IsObject = true;
                tblplantstructure.Visible = true;
                int ret = tblplantstructure.Insert();
                if (ret == 0)
                {
                    EWSTreeNode childnode = new EWSTreeNode(tblplantstructure.Name);
                    childnode.NodeID = tblplantstructure.ID;
                    childnode.sqlobject = tblplantstructure;
                    childnode.ContextMenuStrip = contextMenuStripStructure;
                    childnode.ImageIndex = 2;
                    childnode.SelectedImageIndex = 2;
                    childnode.Nodetype = (TREE_NODE_TYPE)tblplantstructure.Type;
                    node.Nodes.Add(childnode);
                }

                UpdateTabPage();
            }
        }

        //private void ToolStripMenuItemAddObjectFolder_Click(object sender, EventArgs e)
        //{
        //    EWSTreeNode node = (EWSTreeNode)treeViewControl.SelectedNode;
        //    PlantStructureFolderForm plantstructurefolderform = new PlantStructureFolderForm();
        //    //plantstructureobjectform.isfolder = true;
        //    //plantstructureobjectform.title = "Plant Structure Object Folder";
        //    if (plantstructurefolderform.ShowDialog() == DialogResult.OK)
        //    {
        //        tblPlantStructure tblplantstructure = new tblPlantStructure();
        //        tblplantstructure.Name = plantstructurefolderform.name;
        //        tblplantstructure.Description = plantstructurefolderform.description;
        //        tblplantstructure.Type = (int)TREE_NODE_TYPE.ObjectFollder;
        //        tblplantstructure.ParentID = node.NodeID;
        //        tblplantstructure.SolutionID = tblSolution.m_tblSolution().SolutionID;
        //        tblplantstructure.IsFolder = true;
        //        tblplantstructure.IsObject = true;
        //        tblplantstructure.Visible = true;
        //        int ret = tblplantstructure.Insert();
        //        if (ret == 0)
        //        {
        //            EWSTreeNode childnode = new EWSTreeNode(tblplantstructure.Name);
        //            childnode.NodeID = tblplantstructure.ID;
        //            childnode.sqlobject = tblplantstructure;
        //            childnode.ContextMenuStrip = contextMenuStripStructure;
        //            childnode.ImageIndex = 1;
        //            childnode.SelectedImageIndex = 1;
        //            childnode.Nodetype = (TREE_NODE_TYPE)tblplantstructure.Type;
        //            node.Nodes.Add(childnode);
        //        }
        //        UpdateTabPage();
        //    }
        //}

        private void ToolStripMenuItemAddProperty_Click(object sender, EventArgs e)
        {
            EWSTreeNode node = (EWSTreeNode)treeViewControl.SelectedNode;
            PlantStructurePropertyForm plantstructureobjectform = new PlantStructurePropertyForm();
            
            if (plantstructureobjectform.ShowDialog() == DialogResult.OK)
            {
                tblPlantStructure tblplantstructure = new tblPlantStructure();
                tblplantstructure.Name = plantstructureobjectform.name;
                tblplantstructure.Description = plantstructureobjectform.description;
                tblplantstructure.Type = plantstructureobjectform.type;
                tblplantstructure.ParentID = node.NodeID;
                tblplantstructure.SolutionID = tblSolution.m_tblSolution().SolutionID;
                tblplantstructure.IsFolder = false;
                tblplantstructure.IsObject = false;
                tblplantstructure.PropertyPath = plantstructureobjectform.filename;
                tblplantstructure.Argument = plantstructureobjectform.argument;
                tblplantstructure.Visible = true;
                int ret = tblplantstructure.Insert();
                if (ret == 0)
                {
                    EWSTreeNode childnode = new EWSTreeNode(tblplantstructure.Name);
                    childnode.NodeID = tblplantstructure.ID;
                    childnode.sqlobject = tblplantstructure;
                    childnode.ContextMenuStrip = contextMenuStripStructure;
                    childnode.ImageIndex = 3;
                    childnode.SelectedImageIndex = 3;
                    childnode.Nodetype = (TREE_NODE_TYPE)tblplantstructure.Type;
                    node.Nodes.Add(childnode);
                }
                UpdateTabPage();
            }
        }

        private void ToolStripMenuItemAddPropertyFolder_Click(object sender, EventArgs e)
        {
            EWSTreeNode node = (EWSTreeNode)treeViewControl.SelectedNode;
            PlantStructureFolderForm plantstructurefolderform = new PlantStructureFolderForm();
            //plantstructureobjectform.isfolder = true;
            //plantstructureobjectform.title = "Plant Structure Object Folder";
            if (plantstructurefolderform.ShowDialog() == DialogResult.OK)
            {
                tblPlantStructure tblplantstructure = new tblPlantStructure();
                tblplantstructure.Name = plantstructurefolderform.name;
                tblplantstructure.Description = plantstructurefolderform.description;
                tblplantstructure.Type = (int)TREE_NODE_TYPE.PropertyFolder;
                tblplantstructure.ParentID = node.NodeID;
                tblplantstructure.SolutionID = tblSolution.m_tblSolution().SolutionID;
                tblplantstructure.IsFolder = true;
                tblplantstructure.IsObject = false;
                tblplantstructure.Visible = true;
                int ret = tblplantstructure.Insert();
                if (ret == 0)
                {
                    EWSTreeNode childnode = new EWSTreeNode(tblplantstructure.Name);
                    childnode.NodeID = tblplantstructure.ID;
                    childnode.sqlobject = tblplantstructure;
                    childnode.ContextMenuStrip = contextMenuStripStructure;
                    childnode.ImageIndex = 1;
                    childnode.SelectedImageIndex = 1;
                    childnode.Nodetype = (TREE_NODE_TYPE)tblplantstructure.Type;
                    node.Nodes.Add(childnode);
                }
                UpdateTabPage();
            }
        }

        private void contextMenuStripStructure_Opening(object sender, CancelEventArgs e)
        {
            if ((MainForm.Instance().CurrentUser.PlantStructureExplorer == (int)EXPLORER_ACCESS.NoAccess) ||
                (MainForm.Instance().CurrentUser.PlantStructureExplorer == (int)EXPLORER_ACCESS.ViewOnly))
            {
                ToolStripMenuItemAddObject.Enabled = false;
                //ToolStripMenuItemAddObjectFolder.Enabled = false;
                ToolStripMenuItemAddProperty.Enabled = false;
                ToolStripMenuItemAddPropertyFolder.Enabled = false;
                ToolStripMenuItemDelete.Enabled = false;
                ToolStripMenuItemEdit.Enabled = false;
                ToolStripMenuItemCopy.Enabled = false;
                ToolStripMenuItemPaste.Enabled = false;
                return;
            }
            EWSTreeNode node = (EWSTreeNode)treeViewControl.SelectedNode;
            if (node.sqlobject is tblSolution)
            {
                ToolStripMenuItemAddObject.Enabled = true;
               // ToolStripMenuItemAddObjectFolder.Enabled = true;
                ToolStripMenuItemAddProperty.Enabled = false;
                ToolStripMenuItemAddPropertyFolder.Enabled = false;
                ToolStripMenuItemDelete.Enabled = false;
                ToolStripMenuItemCopy.Enabled = false;
                ToolStripMenuItemPaste.Enabled = false;
            }
            else
            {
                if (((tblPlantStructure)node.sqlobject).IsObject)
                {
                    ToolStripMenuItemAddObject.Enabled = true;
                   // ToolStripMenuItemAddObjectFolder.Enabled = true;
                    ToolStripMenuItemAddProperty.Enabled = true;
                    ToolStripMenuItemAddPropertyFolder.Enabled = true;
                    ToolStripMenuItemDelete.Enabled = true;
                    ToolStripMenuItemCopy.Enabled = false;
                    if (SelectedForCopynode == null)
                    {
                        ToolStripMenuItemPaste.Enabled = false;
                    }
                    else
                    {
                        if ((((tblPlantStructure)SelectedForCopynode.sqlobject).IsObject) &&
                            (((tblPlantStructure)node.sqlobject).IsFolder == ((tblPlantStructure)SelectedForCopynode.sqlobject).IsFolder))
                        {
                            ToolStripMenuItemPaste.Enabled = true;
                        }
                        else
                        {
                            ToolStripMenuItemPaste.Enabled = false;
                        }
                    }

                }
                else
                {
                    ToolStripMenuItemAddObject.Enabled = false;
                   // ToolStripMenuItemAddObjectFolder.Enabled = false;
                    ToolStripMenuItemAddProperty.Enabled = true;
                    ToolStripMenuItemAddPropertyFolder.Enabled = true;
                    ToolStripMenuItemDelete.Enabled = true;
                    ToolStripMenuItemCopy.Enabled = false;
                    ToolStripMenuItemPaste.Enabled = false;
                }
            }
        }

        private void ToolStripMenuItemDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure?", "Warning", MessageBoxButtons.YesNo);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                EWSTreeNode node = (EWSTreeNode)treeViewControl.SelectedNode;
                treeViewControl.SelectedNode = (EWSTreeNode)node.Parent;
                DeleteNodeFromDatabase(node);
                ((tblPlantStructure)node.sqlobject).Delete();
                treeViewControl.Nodes.Remove(treeViewControl.SelectedNode);
                UpdateTabPage();
            }
        }

        private void ToolStripMenuItemCopy_Click(object sender, EventArgs e)
        {
            SelectedForCopynode = (EWSTreeNode)treeViewControl.SelectedNode;
        }

        private void ToolStripMenuItemPaste_Click(object sender, EventArgs e)
        {

        }

        #endregion
        void DeleteNodeFromDatabase(EWSTreeNode treenode)
        {
            if (treenode.Nodes.Count == 0)
            {
                ((tblPlantStructure)treenode.sqlobject).Delete();
                return;
            }
            else
            {
                foreach (EWSTreeNode node in treenode.Nodes)
                {
                    DeleteNodeFromDatabase(node);
                }
            }
        }

        private void ToolStripMenuItemEdit_Click(object sender, EventArgs e)
        {
            EWSTreeNode node = (EWSTreeNode)treeViewControl.SelectedNode;
            if (((tblPlantStructure)node.sqlobject).IsObject)
            {

            }
            else
            {
                if (((tblPlantStructure)node.sqlobject).IsFolder)
                {
                    EditFolder();
                }
                else
                {
                    EditProperty();
                }
            }

        }

        private void EditObject()
        {
            EWSTreeNode node = (EWSTreeNode)treeViewControl.SelectedNode;
            PlantStructureObjectForm plantstructureobjectform = new PlantStructureObjectForm();
            tblPlantStructure _tblplantstructure = (tblPlantStructure)node.sqlobject;
            plantstructureobjectform.name = _tblplantstructure.Name;
            plantstructureobjectform.description = _tblplantstructure.Description;
            plantstructureobjectform.type = _tblplantstructure.Type;
            
            if (plantstructureobjectform.ShowDialog() == DialogResult.OK)
            {
                _tblplantstructure.Name = plantstructureobjectform.name;
                _tblplantstructure.Description = plantstructureobjectform.description;
                _tblplantstructure.Type = plantstructureobjectform.type;

                foreach (tblPlantStructure tblplantstructure in tblSolution.m_tblSolution().m_tblPlantStructureCollection)
                {
                    if ((tblplantstructure.Name.ToUpper() == _tblplantstructure.Name.ToUpper()) &&
                        (tblplantstructure.ParentID == _tblplantstructure.ParentID) &&
                        (tblplantstructure.ID != _tblplantstructure.ID))
                    {
                        return;
                    }
                }
                int ret = _tblplantstructure.Update();
                UpdateTabPage();
            }
        }


        
        private void EditProperty()
        {
            EWSTreeNode node = (EWSTreeNode)treeViewControl.SelectedNode;
            PlantStructurePropertyForm plantstructurepropertyform = new PlantStructurePropertyForm();
            tblPlantStructure _tblplantstructure = (tblPlantStructure)node.sqlobject;
            plantstructurepropertyform.name = _tblplantstructure.Name;
            plantstructurepropertyform.description = _tblplantstructure.Description;
            plantstructurepropertyform.type = _tblplantstructure.Type;
            plantstructurepropertyform.filename = _tblplantstructure.PropertyPath;
            plantstructurepropertyform.argument = _tblplantstructure.Argument;
            if (plantstructurepropertyform.ShowDialog() == DialogResult.OK)
            {
                _tblplantstructure.Name = plantstructurepropertyform.name;
                _tblplantstructure.Description = plantstructurepropertyform.description;
                _tblplantstructure.Type = plantstructurepropertyform.type;
                _tblplantstructure.PropertyPath = plantstructurepropertyform.filename;
                _tblplantstructure.Argument = plantstructurepropertyform.argument;
                foreach (tblPlantStructure tblplantstructure in tblSolution.m_tblSolution().m_tblPlantStructureCollection)
                {
                    if ((tblplantstructure.Name.ToUpper() == _tblplantstructure.Name.ToUpper()) &&
                        (tblplantstructure.ParentID == _tblplantstructure.ParentID) &&
                        (tblplantstructure.ID != _tblplantstructure.ID))
                    {
                        return;
                    }
                }
                int ret = _tblplantstructure.Update();
                UpdateTabPage();
            }
        }

        private void EditFolder()
        {
            EWSTreeNode node = (EWSTreeNode)treeViewControl.SelectedNode;
            PlantStructureFolderForm plantstructurefolderform = new PlantStructureFolderForm();
            tblPlantStructure _tblplantstructure = (tblPlantStructure)node.sqlobject;
            plantstructurefolderform.name = _tblplantstructure.Name;
            plantstructurefolderform.description = _tblplantstructure.Description;
            if (plantstructurefolderform.ShowDialog() == DialogResult.OK)
            {
                _tblplantstructure.Name = plantstructurefolderform.name;
                _tblplantstructure.Description = plantstructurefolderform.description;
                foreach (tblPlantStructure tblplantstructure in tblSolution.m_tblSolution().m_tblPlantStructureCollection)
                {
                    if ((tblplantstructure.Name.ToUpper() == _tblplantstructure.Name.ToUpper()) &&
                        (tblplantstructure.ParentID == _tblplantstructure.ParentID) &&
                        (tblplantstructure.ID != _tblplantstructure.ID))
                    {
                        return;
                    }
                }
                int ret = _tblplantstructure.Update();
                UpdateTabPage();
            }
        }


    }
}
