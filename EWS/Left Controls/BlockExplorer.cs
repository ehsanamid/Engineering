using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinFormsUI.Docking;
using DocToolkit.Forms;
using DCSTables;


namespace DockSample
{
    public partial class BlockExplorer : Explorer
    {
        //public MainForm frm;
        public BlockExplorer(MainForm _frm)
        {
            frm = _frm;
            InitializeComponent();
        }

        private void BlockExplorer_Load(object sender, EventArgs e)
        {

        }

        private void BlockExplorer_Shown(object sender, EventArgs e)
        {

        }

        #region Derived Methods
        public override bool findselectednodepath(string fullpath)
        {
            string[] names = { "", "", "", "", "", "", "", "", "" };
            int level = 0;

            string[] split = fullpath.Split(new Char[] { '\\' });
            for (int index = 0; index < split.Count(); index++)
            {
                names[index] = split[index];
            }
            level = split.Count();

            PTPI[0] = -1;
            PTPI[1] = -1;
            PTPI[2] = -1;
            PTPI[3] = -1;
            PTPI[4] = -1;
            PTPI[5] = -1;
            PTPI[6] = -1;

            if (names[0] == Global.Instance.m_tblSolution.SolutionName)
            {
                ProjectTreeLevel = 1;
                PTPI[0] = 0;

                PTPI[1] = Global.Instance.m_tblSolution.CheckDomainNameExist(names[1]);
                if (PTPI[1] != -1)
                {
                    ProjectTreeLevel = 2;
                    PTPI[2] = Global.Instance.m_tblSolution.m_tblDomainCollection[PTPI[1]].CheckControllerNameExist(names[2]);
                    if (PTPI[2] != -1)
                    {
                        ProjectTreeLevel = 3;
                        if ("DataTypes" == names[3])
                        {

                        }
                        if ("Functions" == names[3])
                        {

                        }
                        if ("Function Blocks" == names[3])
                        {

                        }
                        if ("Programs" == names[3])
                        {
                            //PTPI[3] = Global.Instance.m_tblSolution.m_tblDomainCollection[PTPI[1]].m_tblControllerCollection[PTPI[2]].CheckPOUNameExist(names[4]);
                            //if (PTPI[3] != -1)
                            //{
                            //    ProjectTreeLevel = 4;
                            //}
                        }
                    }
                }
            }
            if (ProjectTreeLevel == level)
                return true;
            else
                return false;
        }
        protected override void treeView1_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            //bool renameOK = false;
            if (e.Label != null)
            {
                if (e.Label.Length > 0)
                {
                    if (e.Label.IndexOfAny(new char[] { '@', '.', ',', '!' }) == -1)
                    {
                        // Stop editing without canceling the label change.
                        string str = e.Label;

                        if (ProjectTreeLevel == 4)
                        {

                            int dNo = PTPI[1];
                            int cNo = PTPI[2];
                            int iNo = PTPI[3];
                            if (Global.Instance.m_tblSolution.m_tblDomainCollection[dNo].m_tblControllerCollection[cNo].CheckPouName(str))
                            {
                                Global.Instance.m_tblSolution.m_tblDomainCollection[dNo].m_tblControllerCollection[cNo].m_tblPouCollection[iNo].pouName = str;
                                if (Global.Instance.m_tblSolution.m_tblDomainCollection[dNo].m_tblControllerCollection[cNo].m_tblPouCollection[iNo].Update() > 0)
                                {
                                    //frm.m_DCSProject.m_Project.mDomains[dNo].mControllers[cNo].mIORacks[iNo].IORackName = str;
                                    e.Node.Text = str;
                                    tmpSelectedNode.Text = str;
                                }
                                else
                                {
                                    e.CancelEdit = true;
                                    e.Node.Text = SelectedNodeString;
                                    tmpSelectedNode.Text = SelectedNodeString;
                                }

                            }
                            else
                            {
                                e.CancelEdit = true;
                                e.Node.Text = SelectedNodeString;
                                tmpSelectedNode.Text = SelectedNodeString;
                            }



                        }
                        e.Node.EndEdit(false);

                        //{
                        //    e.CancelEdit = true;
                        //    MessageBox.Show("New Domain name already exists in parent");
                        //    e.Node.BeginEdit();
                        //}
                    }
                    else
                    {
                        /* Cancel the label edit action, inform the user, and 
                           place the node in edit mode again. */
                        e.CancelEdit = true;
                        MessageBox.Show("Invalid tree node label.\n" +
                           "The invalid characters are: '@','.', ',', '!'",
                           "Node Label Edit");
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
                treeView1.LabelEdit = false;
            }
        }
        protected override void treeView1_MouseDown(object sender, MouseEventArgs e)
        {
            base.treeView1_MouseDown(sender, e);

            switch (ProjectTreeLevel)
            {
                case 1:
                    frm.m_propertywindow.propertyGridComponemt.SelectedObject = Global.Instance.m_tblSolution;
                    break;
                case 2:
                    if (PTPI[1] != -1)
                        frm.m_propertywindow.propertyGridComponemt.SelectedObject = Global.Instance.m_tblSolution.m_tblDomainCollection[PTPI[1]];
                    else
                        MessageBox.Show("Wrong click");
                    break;
                case 3:
                    break;
                case 4:
                    if ((PTPI[1] != -1) && (PTPI[2] != -1) && (PTPI[3] != -1))
                        frm.m_propertywindow.propertyGridComponemt.SelectedObject = Global.Instance.m_tblSolution.m_tblDomainCollection[PTPI[1]].m_tblControllerCollection[PTPI[2]].m_tblPouCollection[PTPI[3]];
                    else
                        MessageBox.Show("Wrong click");
                    break;
            }

        }
        protected override void toolStripButton1_Click(object sender, EventArgs e)
        {

        }
        public override void Initialize()
        {

        }
        #endregion

        
    }
}