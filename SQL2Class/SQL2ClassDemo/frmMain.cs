using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using SQLRead;
using System.CodeDom.Compiler;
using System.CodeDom;
using Microsoft.CSharp;
using Microsoft.VisualBasic;

namespace SQL2ClassDemo
{
    public partial class frmMain : Form
    {
        public bool tablenamewithschema = true;
        

        public frmMain()
        {
            InitializeComponent();
        }

        #region Event receivers

        private void SqlSrv_Finished()
        {
            if (prgDatabasesBar.InvokeRequired)
                prgDatabasesBar.Invoke(new FinishedLoading(SqlSrv_Finished));
            else
            {
                lblCurrentDatabase.Text = "";
                lblCurrentObject.Text = "";
                prgDatabasesBar.Value = 0;
                prgEachDatabaseBar.Value = 0;
            }
        }

        private void SqlSrv_LoadingDatabases(byte TotalObjects, byte CurrentObject, string ObjectName)
        {
            if (prgDatabasesBar.InvokeRequired)
                prgDatabasesBar.Invoke(new LoadingAssociatedObjects(SqlSrv_LoadingDatabases), new object[] { TotalObjects, CurrentObject, ObjectName });
            else
            {
                prgDatabasesBar.Maximum = TotalObjects;
                prgDatabasesBar.Value = CurrentObject;
                lblCurrentDatabase.Text = ObjectName;
                lblCurrentDatabase.Refresh();
            }
        }

        private void SqlSrv_LoadingDatabase(byte TotalObjects, byte CurrentObject, string ObjectName)
        {
            if (prgEachDatabaseBar.InvokeRequired)
                prgEachDatabaseBar.Invoke(new LoadingAssociatedObjects(SqlSrv_LoadingDatabase), new object[] { TotalObjects, CurrentObject, ObjectName });
            else
            {
                prgEachDatabaseBar.Maximum = TotalObjects;
                prgEachDatabaseBar.Value = CurrentObject;
                lblCurrentObject.Text = ObjectName;
                lblCurrentObject.Refresh();
                if (lwLoadingOperation.Groups[lblCurrentDatabase.Text] == null)
                    lwLoadingOperation.Groups.Add(lblCurrentDatabase.Text, lblCurrentDatabase.Text + " Database");
                ListViewItem lvi = new ListViewItem(DateTime.Now.ToLongTimeString(),35,lwLoadingOperation.Groups[lblCurrentDatabase.Text]);
                lvi.SubItems.Add("Loading");
                lvi.SubItems.Add(lblCurrentObject.Text);
                lwLoadingOperation.Items.Add(lvi);
                lwLoadingOperation.Refresh();
            }
        }

        #endregion
        
        #region GUI Object Events

        private void bntConnect_Click(object sender, EventArgs e)
        {
            lwLoadingOperation.Items.Clear();
            lwLoadingOperation.Groups.Clear();
            SqlSrv = new SQLServer();
            SqlSrv.ConnectionSetting.DataSource = txtServerBox.Text;
            //SqlSrv.ConnectionSetting.IntegratedSecurity = chkIntegratedSecurityBox.Checked;
            //SqlSrv.ConnectionSetting.UserID = txtUsernameBox.Text;
            //SqlSrv.ConnectionSetting.Password = txtPasswordBox.Text;
            //SqlSrv.LoadingDatabase += new LoadingAssociatedObjects(SqlSrv_LoadingDatabase);
           // SqlSrv.LoadingDatabases += new LoadingAssociatedObjects(SqlSrv_LoadingDatabases);
           // SqlSrv.Finished += new FinishedLoading(SqlSrv_Finished);
            //if (chkOnlyoneCatelogBox.Checked)
            //    SqlSrv.LoadDatabases(txtCatelogBox.Text);
            //else
                SqlSrv.LoadDatabases();
            propSQLServer.SelectedObject = SqlSrv;
        }

        private void chkIntegratedSecurityBox_CheckedChanged(object sender, EventArgs e)
        {
            txtUsernameBox.Enabled = !chkIntegratedSecurityBox.Checked;
            txtPasswordBox.Enabled = !chkIntegratedSecurityBox.Checked;
        }

        private void propSQLServer_SelectedObjectsChanged(object sender, EventArgs e)
        {
            CalculateObjectsToBeCreated();
            tabControl1.SelectedTab = tabControl1.TabPages[2];
            BuildTree();
        }

        private void chkOnlyoneCatelogBox_CheckedChanged(object sender, EventArgs e)
        {
            //txtCatelogBox.Enabled = chkOnlyoneCatelogBox.Checked;
            //if (!chkOnlyoneCatelogBox.Checked)
            //    txtCatelogBox.Text = "";
            //try
            //{
            //    SQLServer SqlSrvDbNames = new SQLServer();
            //    SqlSrvDbNames.ConnectionSetting.DataSource = txtServerBox.Text;
            //    SqlSrvDbNames.ConnectionSetting.IntegratedSecurity = chkIntegratedSecurityBox.Checked;
            //    SqlSrvDbNames.ConnectionSetting.UserID = txtUsernameBox.Text;
            //    SqlSrvDbNames.ConnectionSetting.Password = txtPasswordBox.Text;
            //    txtCatelogBox.Items.Clear();
            //    string[] dbs = SqlSrvDbNames.GetDatabaseNames();
            //    txtCatelogBox.Items.AddRange(dbs);
            //    SqlSrvDbNames = null;
            //    txtCatelogBox.Refresh();
            //}
            //catch
            //{ }
        }

        private void chkCreateOneFilePrClassBox_CheckedChanged(object sender, EventArgs e)
        {
            CalculateObjectsToBeCreated();
        }

        private void bntBrowseOutputDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowNewFolderButton = true;
            fbd.Description = "Please select the output directory, for the source codes";
            if (DialogResult.OK == fbd.ShowDialog(this))
                txtOutputDirectoryBox.Text = fbd.SelectedPath;
        }

        private void treeSQL_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            { proptreeSQL.SelectedObject = treeSQL.SelectedNode.Tag; }
            catch
            { proptreeSQL.SelectedObject = null; }
        }

        private void treeSQL_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if ((e.Action == TreeViewAction.ByMouse | e.Action == TreeViewAction.ByKeyboard) && e.Node.Nodes.Count > 0)
            {
                if (e.Node.Checked)
                {
                    DoChildCheck(e.Node, true);
                    if (e.Node.Parent != null)
                        DoParentCheck(e.Node.Parent);
                }
                else
                    DoChildCheck(e.Node, false);
                CalculateObjectsToBeCreated();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            treeSQL.BeginUpdate();
            foreach (TreeNode tn in treeSQL.Nodes)
                DoChildSchema(tn);
            if (tablenamewithschema)
                tablenamewithschema = false;
            else
                tablenamewithschema = true;
            treeSQL.EndUpdate();
        }

        private void chkDatabaseNameSpaceBox_CheckedChanged(object sender, EventArgs e)
        {
            txtNameSpaceBox.Enabled = !chkDatabaseNameSpaceBox.Checked;
            if (chkDatabaseNameSpaceBox.Checked)
                txtNameSpaceBox.Text = "";
            chkSchemaNamespaceBox.Enabled = chkDatabaseNameSpaceBox.Checked;
            CodeDomGenerator.UseDatabaseNamespace = chkDatabaseNameSpaceBox.Checked;
        }

        private void chkSchemaNamespaceBox_CheckedChanged(object sender, EventArgs e)
        {
            CodeDomGenerator.UseDatabaseSchemaNamespace = chkSchemaNamespaceBox.Checked;
        }

        private void bntGenerate_Click(object sender, EventArgs e)
        {
            pgbCreator.Value = 0;
            CalculateObjectsToBeCreated();
            try
            {
                List<string> S = new List<string>();
                foreach (string s in lstBaseTypesBox.Items)
                    S.Add(s);
                CodeDomGenerator.ClassBaseTypes = S.ToArray();
            }
            catch { CodeDomGenerator.ClassBaseTypes = null; }
            try
            {
                List<string> S = new List<string>();
                foreach (string s in lstImportNSBox.Items)
                    S.Add(s);
                CodeDomGenerator.NamespaceImports = S.ToArray();
            }
            catch { CodeDomGenerator.NamespaceImports = null; }

            if (string.IsNullOrEmpty(txtOutputDirectoryBox.Text))
            {
                MessageBox.Show("No output directory", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tabControl1.SelectedTab = tabControl1.TabPages[3];
                return;
            }
            bool NoTreeNodeSelected = true;
            foreach (TreeNode tn in treeSQL.Nodes)
            {
                if (tn.Checked)
                {
                    NoTreeNodeSelected = false;
                    break;
                }
            }
            if (NoTreeNodeSelected)
            {
                MessageBox.Show("No database Selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tabControl1.SelectedTab = tabControl1.TabPages[2];
                return;
            }
            foreach (TreeNode tn in treeSQL.Nodes)
            {
                if (tn.Checked)
                {
                    if(chkCreateCSharpBox.Checked)
                        generateCode(tn, new CSharpCodeProvider(), lvProgress);
                    if (chkCreateVBBox.Checked)
                        generateCode(tn, new VBCodeProvider(), lvProgress);
                }
            }
            SaveSettings();
            pgbCreator.Value = 0;
            if (DialogResult.Yes == MessageBox.Show("Source Code Files are now created.\nDo you want to open the output folder, now ?", "Done", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                System.Diagnostics.Process.Start(txtOutputDirectoryBox.Text);
        }

        private void bntImportNSAddOk_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtImportNSAdd.Text))
                lstImportNSBox.Items.Add(txtImportNSAdd.Text);
            txtImportNSAdd.Text = "";
            grpAddNamespace.Visible = false;
        }

        private void bntImportNSAddCancel_Click(object sender, EventArgs e)
        {
            grpAddNamespace.Visible = false;
            txtImportNSAdd.Text = "";
        }

        private void bntImportNSAdd_Click(object sender, EventArgs e)
        {
            grpAddNamespace.Visible = true;
            grpAddNamespace.BringToFront();
        }

        private void bntImportNSDel_Click(object sender, EventArgs e)
        {
            if (lstImportNSBox.SelectedItems.Count > 0)
            {
                for (int i = 0; i < lstImportNSBox.SelectedItems.Count; i++)
                    lstImportNSBox.Items.Remove(lstImportNSBox.SelectedItems[i]);
            }
        }

        private void bntImportNSDef_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Do you want to reset Namespace Imports to default?", "Reset to Default", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                lstImportNSBox.Items.Clear();
                lstImportNSBox.Items.Add("System");
                lstImportNSBox.Items.Add("System.Collections");
                lstImportNSBox.Items.Add("System.Collections.Generic");
                lstImportNSBox.Items.Add("System.ComponentModel");
                lstImportNSBox.Items.Add("System.Data");
                lstImportNSBox.Items.Add("System.Data.SQLite");
                lstImportNSBox.Items.Add("System.Text");
            }
        }

        private void bntBaseTypesAddOk_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lstBaseTypesBox.Text))
                lstBaseTypesBox.Items.Add(txtImportNSAdd.Text);
            txtBaseTypesAdd.Text = "";
            grpAddBaseType.Visible = false;
        }

        private void bntBaseTypesAddCancel_Click(object sender, EventArgs e)
        {
            txtBaseTypesAdd.Text = "";
            grpAddBaseType.Visible = false;
        }

        private void bntBaseTypesAdd_Click(object sender, EventArgs e)
        {
            grpAddBaseType.Visible = true;
            grpAddBaseType.BringToFront();
        }

        private void bntBaseTypesDel_Click(object sender, EventArgs e)
        {
            if (lstBaseTypesBox.SelectedItems.Count > 0)
            {
                for (int i = 0; i < lstBaseTypesBox.SelectedItems.Count; i++)
                    lstBaseTypesBox.Items.Remove(lstBaseTypesBox.SelectedItems[i]);
            }
        }

        private void bntBaseTypesDef_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Do you want to reset Basetypes to default?", "Reset to Default", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                lstBaseTypesBox.Items.Clear();
                lstBaseTypesBox.Items.Add("Object");
            }
        }

        private void lvProgress_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start((string)lvProgress.SelectedItems[0].Tag);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void txtNameSpaceBox_TextChanged(object sender, EventArgs e)
        {
            CodeDomGenerator.UseNamespace = txtNameSpaceBox.Text;
        }

        private void AdventureWorksDBLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(@"http://www.codeplex.com/MSFTDBProdSamples/Release/ProjectReleases.aspx?ReleaseId=4004");
        }

        private void CPProfilelink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(@"http://www.codeproject.com/script/Membership/Profiles.aspx?mid=3302918");
        }

        private void Doclink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string docpath = Path.Combine(Path.Combine(Application.StartupPath, "Documentation"), "Index.htm");
            System.Diagnostics.Process.Start(docpath);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            LoadSettings();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 5)
                CalculateObjectsToBeCreated();
        }

        #endregion

        #region Helper methods

        private void CalculateObjectsToBeCreated()
        {
            if (SqlSrv != null)
            {
                int TotalObjectsToBeCreated = 0;
                foreach (TreeNode tndb in treeSQL.Nodes)
                {
                    if (tndb.Checked)
                    {
                        TreeNode[] tnFoundTables = tndb.Nodes.Find(tndb.Name + ".Tables", true);
                        TreeNode tnTables = tnFoundTables[0];
                        foreach (TreeNode tnt in tnTables.Nodes)
                        {
                            if (tndb.Checked)
                                TotalObjectsToBeCreated++;
                        }
                        TreeNode[] tnFoundViews = tndb.Nodes.Find(tndb.Name + ".Views", true);
                        TreeNode tnViews = tnFoundViews[0];
                        foreach (TreeNode tnt in tnViews.Nodes)
                        {
                            if (tndb.Checked)
                                TotalObjectsToBeCreated++;
                        }
                    }
                }
                if (chkCreateCSharpBox.Checked && chkCreateVBBox.Checked)
                {
                    lblTotalFileCount.Text = "Files to create: " + (TotalObjectsToBeCreated * 2).ToString();
                    pgbCreator.Maximum = (TotalObjectsToBeCreated * 2);
                }
                else
                {
                    lblTotalFileCount.Text = "Files to create: " + TotalObjectsToBeCreated.ToString();
                    pgbCreator.Maximum = TotalObjectsToBeCreated;
                }
                pgbCreator.Value = 0;
                lblTotalFileCount.Refresh();
            }
        }

        private void BuildTree()
        {
            treeSQL.Nodes.Clear();
            treeSQL.BeginUpdate();
            foreach(Database db in SqlSrv.Databases.Items)
            {
                TreeNode DBNode = treeSQL.Nodes.Add(db.ObjectName, db.name, 13, 13);
                DBNode.Tag = db;
                DBNode.Checked = true;

                #region Add Security Node and child nodes

                TreeNode DBSecNode = DBNode.Nodes.Add(db.ObjectName + ".Security", "Security", 25, 26);

                #region Add Schemas

                TreeNode DBSchemasNode = DBSecNode.Nodes.Add(db.ObjectName + ".Schema", "Schemas", 25, 26);
                foreach (Schema s in db.Schemas.Items)
                {
                    TreeNode DBSchemaNode = DBSchemasNode.Nodes.Add(s.ObjectName, s.name, 42, 42);
                    DBSchemaNode.Tag = s;
                }
                #endregion

                #region Add Users

                TreeNode DBUsersNode = DBSecNode.Nodes.Add(db.ObjectName + ".Users", "Users", 25, 26);
                foreach (User u in db.Users.Items)
                {
                    TreeNode DBUserNode = DBUsersNode.Nodes.Add(u.ObjectName, u.name);
                    switch (u.UserType)
                    {
                        case UserTypes.SQLRole:
                            DBUserNode.ImageIndex = 66;
                            break;
                        case UserTypes.SQLUser:
                            DBUserNode.ImageIndex = 62;
                            break;
                        case UserTypes.NTGroup:
                            DBUserNode.ImageIndex = 60;
                            break;
                        case UserTypes.NTUser:
                            DBUserNode.ImageIndex = 58;
                            break;
                        default:
                            break;
                    }
                    DBUserNode.SelectedImageIndex = DBUserNode.ImageIndex;
                    DBUserNode.Tag = u;
                }

                #endregion

                #endregion

                #region Add Data Node and child nodes

                TreeNode DBDataNode = DBNode.Nodes.Add(db.ObjectName + ".Data", "Data", 25, 26);
                DBDataNode.Checked = true;

                #region Add Tables

                TreeNode DBTablesNode = DBDataNode.Nodes.Add(db.ObjectName + ".Tables", "Tables", 25, 26);
                DBTablesNode.Checked = true;
                foreach (Table t in db.Tables.Items)
                {
                    TreeNode DBTableNode = DBTablesNode.Nodes.Add(t.ObjectName, t.Schema.name + "." + t.name, 46, 46);
                    DBTableNode.Checked = true;
                    DBTableNode.Tag = t;
                    foreach (Column c in t.Columns.Items)
                    {
                        TreeNode DBColumnNode = DBTableNode.Nodes.Add(c.ObjectName, c.name + " (" + c.system_type.name + ", " + Nullable(c.is_nullable) + ")");
                        if (c.IsForeignKey && c.IsPrimaryKey)
                            DBColumnNode.ImageIndex = 31;
                        else if (!c.IsForeignKey && c.IsPrimaryKey)
                            DBColumnNode.ImageIndex = 39;
                        else if (c.IsForeignKey && !c.IsPrimaryKey)
                            DBColumnNode.ImageIndex = 27;
                        else
                            DBColumnNode.ImageIndex = 6;
                        DBColumnNode.SelectedImageIndex = DBColumnNode.ImageIndex;
                        DBColumnNode.Tag = c;
                        DBColumnNode.Checked = true;
                    }
                }

                #endregion

                #region Add Views

                TreeNode DBViewsNode = DBDataNode.Nodes.Add(db.ObjectName + ".Views", "Views", 25, 26);
                DBViewsNode.Checked = true;
                foreach (SQLRead.View v in db.Views.Items)
                {
                    TreeNode DBViewNode = DBViewsNode.Nodes.Add(v.ObjectName, v.Schema.name + "." + v.name, 46, 46);
                    DBViewNode.Checked = true;
                    DBViewNode.Tag = v;
                    foreach (Column c in v.Columns.Items)
                    {
                        TreeNode DBColumnNode = DBViewNode.Nodes.Add(c.ObjectName, c.name + " (" + c.system_type.name + ", " + Nullable(c.is_nullable) + ")");
                        if (c.IsForeignKey && c.IsPrimaryKey)
                            DBColumnNode.ImageIndex = 31;
                        else if (!c.IsForeignKey && c.IsPrimaryKey)
                            DBColumnNode.ImageIndex = 39;
                        else if (c.IsForeignKey && !c.IsPrimaryKey)
                            DBColumnNode.ImageIndex = 27;
                        else
                            DBColumnNode.ImageIndex = 6;
                        DBColumnNode.SelectedImageIndex = DBColumnNode.ImageIndex;
                        DBColumnNode.Tag = c;
                        DBColumnNode.Checked = true;
                    }
                }

                #endregion

                #region Add Types

                TreeNode DBTypesNode = DBDataNode.Nodes.Add(db.ObjectName + ".Types", "Types", 25, 26);
                foreach (SQL_Type sqlt in db.Types.Items)
                {
                    TreeNode DBTypeNode = DBTypesNode.Nodes.Add(sqlt.ObjectName, sqlt.name);
                    if (sqlt.is_user_defined)
                        DBTypeNode.ImageIndex = 52;
                    else
                        DBTypeNode.ImageIndex = 51;
                    DBTypeNode.SelectedImageIndex = DBTypeNode.ImageIndex;
                    DBTypeNode.Tag = sqlt;
                }

                #endregion

                #endregion
            }
            treeSQL.EndUpdate();
            CalculateObjectsToBeCreated();
        }

        private string Nullable(bool value)
        {
            if (value)
                return "null";
            else
                return "not null";
        }
        private void DoChildCheck(TreeNode tn, bool value)
        {
            if (tn.Nodes.Count > 0)
            {
                foreach (TreeNode stn in tn.Nodes)
                    DoChildCheck(stn, value);
            }
            tn.Checked = value;
        }
        private void DoParentCheck(TreeNode tn)
        {
            if (tn.Parent != null)
                DoParentCheck(tn.Parent);
            tn.Checked = true;
        }
        private void DoChildSchema(TreeNode tn)
        {
            if (tn.Nodes.Count > 0)
            {
                foreach (TreeNode stn in tn.Nodes)
                    DoChildSchema(stn);
            }
            if (tn.Tag is Table)
            {
                if (tablenamewithschema)
                    tn.Text = ((Table)tn.Tag).name;
                else
                    tn.Text = ((Table)tn.Tag).Schema.name + "." + ((Table)tn.Tag).name;
            }
            else if (tn.Tag is SQLRead.View)
            {
                if (tablenamewithschema)
                    tn.Text = ((SQLRead.View)tn.Tag).name;
                else
                    tn.Text = ((SQLRead.View)tn.Tag).Schema.name + "." + ((SQLRead.View)tn.Tag).name;
            }
        }

        private void generateCode(TreeNode tn, CodeDomProvider provider, ListView ProgressList)
        {
            SetOutputGen();
            if (!(tn.Tag is Database))
                return;
            Database db = ((Database)tn.Tag);

            int icon = 1;
            if (provider is VBCodeProvider)
                icon = 4;

            ListViewGroup lvg ;
            if(ProgressList.Groups[db.name] == null)
                lvg = ProgressList.Groups.Add(db.name,db.name);
            else
                lvg = ProgressList.Groups[db.name];

            #region Making the output path

            string outputpath = txtOutputDirectoryBox.Text;
            if (chkCreateNewDirForEachDBBox.Checked)
                outputpath = Path.Combine(outputpath, db.name);
            if (!Directory.Exists(outputpath))
                Directory.CreateDirectory(outputpath);


            #endregion

            #region Generating Table Classes

            TreeNode[] tnFoundTables = tn.Nodes.Find(db.ObjectName + ".Tables", true);
            TreeNode tnTables = tnFoundTables[0];
            foreach (TreeNode tnTable in tnTables.Nodes)
            {
                if (tnTable.Checked)
                {
                    Table t = (Table)tnTable.Tag;

                    ListViewItem lvi = new ListViewItem(DateTime.Now.ToLongTimeString(), icon, lvg);
                    lvi.SubItems.Add(t.name);
                    if (pgbCreator.Value < pgbCreator.Maximum)
                        pgbCreator.Value++;
                    pgbCreator.Refresh();

                    int StartRegion = 1;

                    if (provider is CSharpCodeProvider)
                        lvi.SubItems.Add("CSharp");
                    else
                        lvi.SubItems.Add("Visual Basic .Net");

                    CodeNamespace ns = new NameSpaceDatabaseCreate(t, provider);

                    CodeTypeDeclaration cls = new ClassTableCreate(t, provider);


                    StartRegion = cls.Members.Count;

                    cls.Members.Add(new FieldSQLSelectString(t, provider));

                    cls.Members.Add(new FieldSQLInsertString(t, provider));

                    cls.Members.Add(new FieldSQLUpdateString(t, provider));

                    cls.Members.Add(new FieldSQLDeleteString(t, provider));


                    cls.Members[StartRegion].StartDirectives.Add(new CodeRegionDirective(CodeRegionMode.Start, "Static SQL String Memebers"));
                    cls.Members[cls.Members.Count - 1].EndDirectives.Add(new CodeRegionDirective(CodeRegionMode.End, string.Empty));

                    StartRegion = cls.Members.Count;

                    foreach (TreeNode tnColumn in tnTable.Nodes)
                    {
                        if (tnTable.Checked)
                        {
                            cls.Members.Add(new FieldColumnCreate((Column)tnColumn.Tag, provider));
                            cls.Members.Add(new PropertyColumnCreate((Column)tnColumn.Tag, provider));
                        }
                    }

                    cls.Members[StartRegion].StartDirectives.Add(new CodeRegionDirective(CodeRegionMode.Start, "Tables Memebers"));
                    cls.Members[cls.Members.Count - 1].EndDirectives.Add(new CodeRegionDirective(CodeRegionMode.End, string.Empty));

                    if (CodeDomGenerator.CreateRefObjects)
                    {
                        if (t.HasForeignKey)
                        {
                            StartRegion = cls.Members.Count;
                            foreach (foreign_key fk in t.ForeignKeys.Items)
                            {
                                cls.Members.Add(new FieldRefObjectCreate(fk, provider));
                                cls.Members.Add(new PropertyRefObjectCreate(fk, provider));
                            }
                            cls.Members[StartRegion].StartDirectives.Add(new CodeRegionDirective(CodeRegionMode.Start, "Related Objects"));
                            cls.Members[cls.Members.Count - 1].EndDirectives.Add(new CodeRegionDirective(CodeRegionMode.End, string.Empty));
                        }

                        if (t.ForeignKeyDependency != null)
                        {
                            StartRegion = cls.Members.Count;
                            foreach (foreign_key fk in t.ForeignKeyDependency)
                            {
                                cls.Members.Add(new FieldRefObjectCollectionCreate(fk, provider));
                                cls.Members.Add(new PropertyRefObjectCollectionCreate(fk, provider));
                            }
                            cls.Members[StartRegion].StartDirectives.Add(new CodeRegionDirective(CodeRegionMode.Start, "Related Object Collections"));
                            cls.Members[cls.Members.Count - 1].EndDirectives.Add(new CodeRegionDirective(CodeRegionMode.End, string.Empty));
                        }
                    }

                    StartRegion = cls.Members.Count;

                    cls.Members.Add(new SelectMethod(t, provider));

                    cls.Members.Add(new InsertMethod(t, provider));

                    cls.Members.Add(new UpdateMethod(t, provider));

                    cls.Members.Add(new DeleteMethod(t, provider));

                    cls.Members.Add(new GetSqlCommandStringsMethod(t, provider));

                    cls.Members[StartRegion].StartDirectives.Add(new CodeRegionDirective(CodeRegionMode.Start, "Public Methods"));
                    cls.Members[cls.Members.Count - 1].EndDirectives.Add(new CodeRegionDirective(CodeRegionMode.End, string.Empty));

                    StartRegion = cls.Members.Count;

                    cls.Members.Add(new AddFromRecordSetMethod(t, provider));

                    cls.Members.Add(new GetSqlParameters(t, provider));

                    cls.Members[StartRegion].StartDirectives.Add(new CodeRegionDirective(CodeRegionMode.Start, "Private Methods"));
                    cls.Members[cls.Members.Count - 1].EndDirectives.Add(new CodeRegionDirective(CodeRegionMode.End, string.Empty));


                    ns.Types.Add(cls);

                    ns.Types.Add(new ClassCollection(t, provider));

                    ns.Types.Add(new ClassFieldEnumeration(t, provider));

                    lvi.Tag = (string)Path.Combine(outputpath, t.UniqueObjectName + provider.FileExtension.Replace(".", ""));
                    using (Stream s = File.Open(Path.Combine(outputpath, t.UniqueObjectName + provider.FileExtension.Replace(".", "")), FileMode.Create))
                    {
                        using (StreamWriter sw = new StreamWriter(s, Encoding.Default))
                        {
                            ICodeGenerator cscg = provider.CreateGenerator(sw);
                            CodeGeneratorOptions cop = new CodeGeneratorOptions();
                            cop.BlankLinesBetweenMembers = true;
                            cop.BracingStyle = "C";
                            cop.IndentString = "\t";
                            cop.VerbatimOrder = true;
                            try { cscg.GenerateCodeFromNamespace(ns, sw, cop); }
                            catch { }
                            finally
                            {
                                sw.Close();
                                s.Close();
                            }
                        }
                    }
                    string CodeCorrection = "";
                    using (StreamReader sr = new StreamReader(Path.Combine(outputpath, t.UniqueObjectName + provider.FileExtension.Replace(".", ""))))
                    {
                        CodeCorrection = CodeDomGenerator.CodeDomCorrector(sr.ReadToEnd(), provider);
                    }
                    using (StreamWriter sw2 = new StreamWriter(Path.Combine(outputpath, t.UniqueObjectName + provider.FileExtension.Replace(".", ""))))
                    {
                        sw2.Write(CodeCorrection);
                        sw2.Flush();
                    }
                    ProgressList.Items.Add(lvi);
                    ProgressList.Refresh();
                }

            }

            #endregion

            #region Generating View Classes

            TreeNode[] tnFoundViews = tn.Nodes.Find(db.ObjectName + ".Views", true);
            TreeNode tnViews = tnFoundViews[0];
            foreach (TreeNode tnView in tnViews.Nodes)
            {
                if (tnView.Checked)
                {
                    SQLRead.View v = (SQLRead.View)tnView.Tag;

                    ListViewItem lvi = new ListViewItem(DateTime.Now.ToLongTimeString(), icon, lvg);
                    lvi.SubItems.Add(v.name);
                    if(pgbCreator.Value < pgbCreator.Maximum)
                        pgbCreator.Value++;
                    pgbCreator.Refresh();

                    int StartRegion = 1;

                    if (provider is CSharpCodeProvider)
                        lvi.SubItems.Add("CSharp");
                    else
                        lvi.SubItems.Add("Visual Basic .Net");

                    CodeNamespace ns = new NameSpaceDatabaseCreate(v, provider);

                    CodeTypeDeclaration cls = new ClassViewCreate(v, provider);

                    StartRegion = cls.Members.Count;

                    cls.Members.Add(new FieldSQLSelectString(v, provider));

                    cls.Members[StartRegion].StartDirectives.Add(new CodeRegionDirective(CodeRegionMode.Start, "Static SQL String Memebers"));
                    cls.Members[cls.Members.Count - 1].EndDirectives.Add(new CodeRegionDirective(CodeRegionMode.End, string.Empty));

                    StartRegion = cls.Members.Count;

                    foreach (TreeNode tnColumn in tnView.Nodes)
                    {
                        if (tnColumn.Checked)
                        {
                            cls.Members.Add(new FieldColumnCreate((Column)tnColumn.Tag, provider));
                            cls.Members.Add(new PropertyColumnReadOnlyCreate((Column)tnColumn.Tag, provider));
                        }
                    }

                    cls.Members[StartRegion].StartDirectives.Add(new CodeRegionDirective(CodeRegionMode.Start, "View Memebers"));
                    cls.Members[cls.Members.Count - 1].EndDirectives.Add(new CodeRegionDirective(CodeRegionMode.End, string.Empty));

                    StartRegion = cls.Members.Count;

                    cls.Members.Add(new SelectMethod(v, provider));

                    cls.Members[StartRegion].StartDirectives.Add(new CodeRegionDirective(CodeRegionMode.Start, "Public Methods"));
                    cls.Members[cls.Members.Count - 1].EndDirectives.Add(new CodeRegionDirective(CodeRegionMode.End, string.Empty));

                    StartRegion = cls.Members.Count;

                    cls.Members.Add(new AddFromRecordSetMethod(v, provider));

                    cls.Members.Add(new GetSqlParameters(v, provider));

                    cls.Members[StartRegion].StartDirectives.Add(new CodeRegionDirective(CodeRegionMode.Start, "Private Methods"));
                    cls.Members[cls.Members.Count - 1].EndDirectives.Add(new CodeRegionDirective(CodeRegionMode.End, string.Empty));


                    ns.Types.Add(cls);

                    ns.Types.Add(new ClassViewCollection(v, provider));

                    ns.Types.Add(new ClassFieldEnumeration(v, provider));

                    lvi.Tag = (string)Path.Combine(outputpath, v.UniqueObjectName + provider.FileExtension.Replace(".", ""));
                    using (Stream s = File.Open(Path.Combine(outputpath, v.UniqueObjectName + provider.FileExtension.Replace(".", "")), FileMode.Create))
                    {
                        using (StreamWriter sw = new StreamWriter(s, Encoding.Default))
                        {
                            ICodeGenerator cscg = provider.CreateGenerator(sw);
                            CodeGeneratorOptions cop = new CodeGeneratorOptions();
                            cop.BlankLinesBetweenMembers = true;
                            cop.BracingStyle = "C";
                            cop.IndentString = "\t";
                            cop.VerbatimOrder = true;
                            try { cscg.GenerateCodeFromNamespace(ns, sw, cop); }
                            catch { }
                            finally
                            {
                                sw.Close();
                                s.Close();
                            }
                        }
                    }
                    string CodeCorrection = "";
                    using (StreamReader sr = new StreamReader(Path.Combine(outputpath, v.UniqueObjectName + provider.FileExtension.Replace(".", ""))))
                    {
                        CodeCorrection = CodeDomGenerator.CodeDomCorrector(sr.ReadToEnd(), provider);
                    }
                    using (StreamWriter sw2 = new StreamWriter(Path.Combine(outputpath, v.UniqueObjectName + provider.FileExtension.Replace(".", ""))))
                    {
                        sw2.Write(CodeCorrection);
                        sw2.Flush();
                    }
                    ProgressList.Items.Add(lvi);
                    ProgressList.Refresh();
                }

            }

            #endregion
        }

        private void SaveSettings()
        {
            Application.UserAppDataRegistry.SetValue("txtServerBox", (string)txtServerBox.Text, Microsoft.Win32.RegistryValueKind.String);
            Application.UserAppDataRegistry.SetValue("txtCatelogBox", (string)txtCatelogBox.Text, Microsoft.Win32.RegistryValueKind.String);
            Application.UserAppDataRegistry.SetValue("txtUsernameBox", (string)txtUsernameBox.Text, Microsoft.Win32.RegistryValueKind.String);
            Application.UserAppDataRegistry.SetValue("txtPasswordBox", (string)txtPasswordBox.Text, Microsoft.Win32.RegistryValueKind.String);
            Application.UserAppDataRegistry.SetValue("chkOnlyoneCatelogBox", Convert.ToByte(chkOnlyoneCatelogBox.Checked), Microsoft.Win32.RegistryValueKind.DWord);
            Application.UserAppDataRegistry.SetValue("txtOutputDirectoryBox", (string)txtOutputDirectoryBox.Text, Microsoft.Win32.RegistryValueKind.String);
            Application.UserAppDataRegistry.SetValue("chkCreateNewDirForEachDBBox", Convert.ToByte(chkCreateNewDirForEachDBBox.Checked), Microsoft.Win32.RegistryValueKind.DWord);
            Application.UserAppDataRegistry.SetValue("txtCSpreFieldBox", (string)txtCSpreFieldBox.Text, Microsoft.Win32.RegistryValueKind.String);
            Application.UserAppDataRegistry.SetValue("txtCSpostFieldBox", (string)txtCSpostFieldBox.Text, Microsoft.Win32.RegistryValueKind.String);
            Application.UserAppDataRegistry.SetValue("txtVBpreFieldBox", (string)txtVBpreFieldBox.Text, Microsoft.Win32.RegistryValueKind.String);
            Application.UserAppDataRegistry.SetValue("txtVBpostFieldBox", (string)txtVBpostFieldBox.Text, Microsoft.Win32.RegistryValueKind.String);
            Application.UserAppDataRegistry.SetValue("chkCreateCSharpBox", Convert.ToByte(chkCreateCSharpBox.Checked), Microsoft.Win32.RegistryValueKind.DWord);
            Application.UserAppDataRegistry.SetValue("chkCreateVBBox", Convert.ToByte(chkCreateVBBox.Checked), Microsoft.Win32.RegistryValueKind.DWord);
            Application.UserAppDataRegistry.SetValue("cbFieldModifiersBox", (string)cbFieldModifiersBox.Text, Microsoft.Win32.RegistryValueKind.String);
            Application.UserAppDataRegistry.SetValue("cbPropertyModifiersBox", (string)cbPropertyModifiersBox.Text, Microsoft.Win32.RegistryValueKind.String);
            Application.UserAppDataRegistry.SetValue("chkAddCommentsBox", Convert.ToByte(chkAddCommentsBox.Checked), Microsoft.Win32.RegistryValueKind.DWord);
            Application.UserAppDataRegistry.SetValue("chkAddMSDescriptionBox", Convert.ToByte(chkAddMSDescriptionBox.Checked), Microsoft.Win32.RegistryValueKind.DWord);
            Application.UserAppDataRegistry.SetValue("chkCorrectPropertyNameBox", Convert.ToByte(chkCorrectPropertyNameBox.Checked), Microsoft.Win32.RegistryValueKind.DWord);
            Application.UserAppDataRegistry.SetValue("chkCorrectDisplayAttribBox", Convert.ToByte(chkCorrectDisplayAttribBox.Checked), Microsoft.Win32.RegistryValueKind.DWord);
            Application.UserAppDataRegistry.SetValue("chkCreateRefObjectsBox", Convert.ToByte(chkCreateRefObjectsBox.Checked), Microsoft.Win32.RegistryValueKind.DWord);
            Application.UserAppDataRegistry.SetValue("chkDatabaseNameSpaceBox", Convert.ToByte(chkDatabaseNameSpaceBox.Checked), Microsoft.Win32.RegistryValueKind.DWord);
            Application.UserAppDataRegistry.SetValue("chkSchemaNamespaceBox", Convert.ToByte(chkSchemaNamespaceBox.Checked), Microsoft.Win32.RegistryValueKind.DWord);
        }

        private void LoadSettings()
        {
           // txtServerBox.Text = (string)Application.UserAppDataRegistry.GetValue("txtServerBox", Environment.MachineName);
            txtCatelogBox.Text = (string)Application.UserAppDataRegistry.GetValue("txtCatelogBox", "");
            txtUsernameBox.Text = (string)Application.UserAppDataRegistry.GetValue("txtUsernameBox", "");
            txtPasswordBox.Text = (string)Application.UserAppDataRegistry.GetValue("txtPasswordBox", "");
            chkOnlyoneCatelogBox.Checked = Convert.ToBoolean(Application.UserAppDataRegistry.GetValue("chkOnlyoneCatelogBox", false));
            txtOutputDirectoryBox.Text = (string)Application.UserAppDataRegistry.GetValue("txtOutputDirectoryBox", "");
            chkCreateNewDirForEachDBBox.Checked = Convert.ToBoolean(Application.UserAppDataRegistry.GetValue("chkCreateNewDirForEachDBBox", true));
            txtCSpreFieldBox.Text = (string)Application.UserAppDataRegistry.GetValue("txtCSpreFieldBox", "_");
            txtCSpostFieldBox.Text = (string)Application.UserAppDataRegistry.GetValue("txtCSpostFieldBox", "");
            txtVBpreFieldBox.Text = (string)Application.UserAppDataRegistry.GetValue("txtVBpreFieldBox", "fld_");
            txtVBpostFieldBox.Text = (string)Application.UserAppDataRegistry.GetValue("txtVBpostFieldBox", "");
            chkCreateCSharpBox.Checked = Convert.ToBoolean(Application.UserAppDataRegistry.GetValue("chkCreateCSharpBox", true));
            chkCreateVBBox.Checked = Convert.ToBoolean(Application.UserAppDataRegistry.GetValue("chkCreateVBBox", true));
            cbFieldModifiersBox.Text = (string)Application.UserAppDataRegistry.GetValue("cbFieldModifiersBox", "Private");
            cbPropertyModifiersBox.Text = (string)Application.UserAppDataRegistry.GetValue("cbPropertyModifiersBox", "Public");
            chkAddCommentsBox.Checked = Convert.ToBoolean(Application.UserAppDataRegistry.GetValue("chkAddCommentsBox", true));
            chkAddMSDescriptionBox.Checked = Convert.ToBoolean(Application.UserAppDataRegistry.GetValue("chkAddMSDescriptionBox", true));
            chkCorrectPropertyNameBox.Checked = Convert.ToBoolean(Application.UserAppDataRegistry.GetValue("chkCorrectPropertyNameBox", true));
            chkCorrectDisplayAttribBox.Checked = Convert.ToBoolean(Application.UserAppDataRegistry.GetValue("chkCorrectDisplayAttribBox", true));
            chkCreateRefObjectsBox.Checked = Convert.ToBoolean(Application.UserAppDataRegistry.GetValue("chkCreateRefObjectsBox", true));
            chkDatabaseNameSpaceBox.Checked = Convert.ToBoolean(Application.UserAppDataRegistry.GetValue("chkDatabaseNameSpaceBox", true));
            chkSchemaNamespaceBox.Checked = Convert.ToBoolean(Application.UserAppDataRegistry.GetValue("chkSchemaNamespaceBox", true));
            if (!chkOnlyoneCatelogBox.Checked)
                txtCatelogBox.Text = "";
            txtCatelogBox.Enabled = chkOnlyoneCatelogBox.Checked;

        }

        private void SetOutputGen()
        {
            CodeDomGenerator.AddComments = chkAddCommentsBox.Checked;
            CodeDomGenerator.CreateRefObjects = chkCreateRefObjectsBox.Checked;
            CodeDomGenerator.CSPostFieldname = txtCSpostFieldBox.Text;
            CodeDomGenerator.CSPreFieldname = txtCSpreFieldBox.Text;
            CodeDomGenerator.FieldModifier = cbFieldModifiersBox.Text;
            CodeDomGenerator.MapDescription = chkAddMSDescriptionBox.Checked;
            CodeDomGenerator.PropertyModifier = cbPropertyModifiersBox.Text;
            CodeDomGenerator.TryCorrectDisplayName = chkCorrectDisplayAttribBox.Checked;
            CodeDomGenerator.TryCorrectPropertyName = chkCorrectPropertyNameBox.Checked;
            CodeDomGenerator.UseDatabaseNamespace = chkDatabaseNameSpaceBox.Checked;
            CodeDomGenerator.UseDatabaseSchemaNamespace = chkSchemaNamespaceBox.Checked;
            CodeDomGenerator.UseNamespace = txtNameSpaceBox.Text;
            CodeDomGenerator.VBPostFieldname = txtVBpostFieldBox.Text;
            CodeDomGenerator.VBPreFieldname = txtVBpreFieldBox.Text;
        }

        #endregion

        private void proptreeSQL_Click(object sender, EventArgs e)
        {

        }

        private void txtServerBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}