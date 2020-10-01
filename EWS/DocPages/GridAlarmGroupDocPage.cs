using EWS.DCSTables;
//using DocToolkit.Project_Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EWS.TabPages
{
    public partial class TabPageGridAlarmGroupControl : TabPageControl
    {
        private int rowIndex = 0;
        List<long> deletedlist = new List<long>();
        private IContainer components;
        bool loaded = false;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameCol;
        private System.Windows.Forms.DataGridViewComboBoxColumn TypeCol;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ArchiveCol;
        private System.Windows.Forms.DataGridViewComboBoxColumn RetriggerCol;
        private System.Windows.Forms.DataGridViewCheckBoxColumn PrintCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDCol;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ReadOnlyCol;
        
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;

        public Panel panelTabPage;
        public TabPageGridAlarmGroupControl(EXTabControl _parent, long id)
            : base(_parent, id)
        {

            InitializeComponent();
            TabPageType = TABPAGETYPE.ALARM_GROUP;
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[6].ReadOnly = true;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].ReadOnly = true;
            dataGridView1.Columns[7].Visible = false;
            if (Common.TabPageGridAlarmGroupControl_RowColWidth > 0)
            {
                dataGridView1.Columns[0].Width = Common.TabPageGridAlarmGroupControl_RowColWidth;
            }
            if (Common.TabPageGridAlarmGroupControl_NameColWidth > 0)
            {
                dataGridView1.Columns[1].Width = Common.TabPageGridAlarmGroupControl_NameColWidth;
            }
            if (Common.TabPageGridAlarmGroupControl_TypeColWidth > 0)
            {
                dataGridView1.Columns[2].Width = Common.TabPageGridAlarmGroupControl_TypeColWidth;
            }
            if (Common.TabPageGridAlarmGroupControl_ArchiveColWidth > 0)
            {
                dataGridView1.Columns[3].Width = Common.TabPageGridAlarmGroupControl_ArchiveColWidth;
            }
            if (Common.TabPageGridAlarmGroupControl_RetriggerColWidth > 0)
            {
                dataGridView1.Columns[4].Width = Common.TabPageGridAlarmGroupControl_RetriggerColWidth;
            }
            if (Common.TabPageGridAlarmGroupControl_PrintColWidth > 0)
            {
                dataGridView1.Columns[5].Width = Common.TabPageGridAlarmGroupControl_PrintColWidth;
            }

        }
        
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.RowCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeCol = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ArchiveCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.RetriggerCol = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.PrintCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IDCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReadOnlyCol = new DataGridViewCheckBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelTabPage = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowCol,
            this.NameCol,
            this.TypeCol,
            this.ArchiveCol,
            this.RetriggerCol,
            this.PrintCol,
            this.IDCol,
            this.ReadOnlyCol });
            //this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(563, 150);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_CellBeginEdit);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dataGridView1_ColumnWidthChanged);
            this.dataGridView1.CellMouseUp += new DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseUp);
            this.dataGridView1.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView1_RowsAdded);
            
            // 
            // RowCol
            // 
            this.RowCol.HeaderText = "Row";
            this.RowCol.Name = "RowCol";
            // 
            // NameCol
            // 
            this.NameCol.HeaderText = "Name";
            this.NameCol.Name = "NameCol";
            // 
            // TypeCol
            // 
            this.TypeCol.HeaderText = "Type";
            this.TypeCol.Items.AddRange(new object[] {
            "Event",
            "Self Acknowledge",
            "Acknowledge on Set",
            "Acknowledge on Set/Reset"});
            this.TypeCol.Name = "TypeCol";
            // 
            // ArchiveCol
            // 
            this.ArchiveCol.HeaderText = "Archive";
            this.ArchiveCol.Name = "ArchiveCol";
            // 
            // RetriggerCol
            // 
            this.RetriggerCol.HeaderText = "Retrigger";
            this.RetriggerCol.Items.AddRange(new object[] {
            "No",
            "1 Minute",
            "10 Minute",
            "1 Hour"});
            this.RetriggerCol.Name = "RetriggerCol";
            this.RetriggerCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // PrintCol
            // 
            this.PrintCol.HeaderText = "Print";
            this.PrintCol.Name = "PrintCol";
            // 
            // IDCol
            // 
            this.IDCol.HeaderText = "ID";
            this.IDCol.Name = "IDCol";
            // 
            // ReadOnlyCol
            // 
            this.ReadOnlyCol.HeaderText = "ReadOnly";
            this.ReadOnlyCol.Name = "ReadOnlyCol";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem,
            this.addToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(102, 26);
            // 
            // delteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // panelTabPage
            // 
            this.panelTabPage.AutoScroll = true;
            this.panelTabPage.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelTabPage.Controls.Add(this.dataGridView1);
            this.panelTabPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTabPage.Location = new System.Drawing.Point(0, 0);
            this.panelTabPage.Name = "panelTabPage";
            this.panelTabPage.Size = new System.Drawing.Size(550, 187);
            this.panelTabPage.TabIndex = 0;
            // 
            // TabGridPageControl
            // 
            this.Controls.Add(this.panelTabPage);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        private void dataGridView1_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            if (loaded)
            {
                Common.TabPageGridAlarmGroupControl_RowColWidth = dataGridView1.Columns[0].Width;
                Common.TabPageGridAlarmGroupControl_NameColWidth = dataGridView1.Columns[1].Width;
                Common.TabPageGridAlarmGroupControl_TypeColWidth = dataGridView1.Columns[2].Width;
                Common.TabPageGridAlarmGroupControl_ArchiveColWidth = dataGridView1.Columns[3].Width;
                Common.TabPageGridAlarmGroupControl_RetriggerColWidth = dataGridView1.Columns[4].Width;
                Common.TabPageGridAlarmGroupControl_PrintColWidth = dataGridView1.Columns[5].Width;
            }
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (loaded)
            {
                this.Dirty = true;
            }

        }
        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[dataGridView1.Rows.Count - 1];
            row.Cells["RowCol"].Value = (dataGridView1.Rows.Count - 1).ToString();
            row.Cells["NameCol"].Value = "";
            row.Cells["TypeCol"].Value = "Event";
            row.Cells["ArchiveCol"].Value = false;
            row.Cells["RetriggerCol"].Value = "No";
            row.Cells["PrintCol"].Value = false;
            row.Cells["IDCol"].Value = (-1).ToString();
            row.Cells["ReadOnlyCol"].Value = false;
        }

        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) 
            {
                this.dataGridView1.Rows[e.RowIndex].Selected = true; 
                this.rowIndex = e.RowIndex;
                this.dataGridView1.CurrentCell = this.dataGridView1.Rows[e.RowIndex].Cells[1];
                if ((bool)this.dataGridView1.Rows[e.RowIndex].Cells["ReadOnlyCol"].Value == true)
                {
                    contextMenuStrip1.Items[0].Enabled = false;
                    contextMenuStrip1.Items[3].Enabled = false;
                }
                else
                {
                    contextMenuStrip1.Items[0].Enabled = true;
                    contextMenuStrip1.Items[3].Enabled = false;
                }

                this.contextMenuStrip1.Show(this.dataGridView1, e.Location);
                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void contextMenuStrip1_Click(object sender, EventArgs e)
        {
            if (!this.dataGridView1.Rows[this.rowIndex].IsNewRow)
            {

                this.dataGridView1.Rows.RemoveAt(this.rowIndex);
            }
        }
    

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string str = (string)dataGridView1.Rows[rowIndex].Cells["IDCol"].Value;
            long id;
            if ((string)dataGridView1.Rows[rowIndex].Cells["IDCol"].Value != "-1")
            {
                id = long.Parse(str);
                deletedlist.Add(id);
            }

            this.dataGridView1.Rows.RemoveAt(this.rowIndex);
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells["RowCol"].Value = i.ToString();
            }
            Dirty = true;

        }
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add();
        }
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (loaded)
            {
                this.Dirty = true;
            }
        }




        public override void CloseTabPage()
        {
            base.CloseTabPage();

            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            GC.Collect();

            panelTabPage.Dispose();
            //components.Dispose();
            //dataGridView1.Dispose();
            foreach (Control control in this.Controls)
            {
                control.Dispose();
            }

            contextMenuStrip1.Dispose();
            deleteToolStripMenuItem.Dispose();
            addToolStripMenuItem.Dispose();
            copyToolStripMenuItem.Dispose();
            pasteToolStripMenuItem.Dispose();
            dataGridView1.Dispose();
            this.Controls.Clear();

        }
        #region Load
        public override bool LoadTabPage()
        {
            bool ret = false;
            int index;
            int counter = 0;
            try
            {
                foreach (tblAlarmGroup tblalarmgroup in Global.EWS.m_tblSolution.m_tblAlarmGroupCollection)
                {
                    if (counter++ < dataGridView1.Rows.Count)
                    {
                        index = counter - 1;
                    }
                    else
                    {
                        index = dataGridView1.Rows.Add();
                    }
                    DataGridViewRow row = dataGridView1.Rows[index];
                    row.Cells["RowCol"].Value = tblalarmgroup.oIndex.ToString();
                    row.Cells["NameCol"].Value      = tblalarmgroup.Name;
                    switch ((AlarmGroupType)tblalarmgroup.Type)
                    {
                        case AlarmGroupType.Event:
                            row.Cells["TypeCol"].Value = "Event";
                            break;
                        case AlarmGroupType.SelfAcknowledge:
                            row.Cells["TypeCol"].Value = "Self Acknowledge";
                            break;
                        case AlarmGroupType.AcknowledgeOnSet:
                            row.Cells["TypeCol"].Value = "Acknowledge on Set";
                            break;
                        case AlarmGroupType.AcknowledgeOnSetReset:
                            row.Cells["TypeCol"].Value = "Acknowledge on Set/Reset";
                            break;
                    }
                
                    row.Cells["ArchiveCol"].Value   = tblalarmgroup.Archive;
                    switch (tblalarmgroup.Retrigger)
                    {
                        case 0:
                            row.Cells["RetriggerCol"].Value = "No";
                            break;
                        case 1:
                            row.Cells["RetriggerCol"].Value = "1 Minute";
                            break;
                        case 2:
                            row.Cells["RetriggerCol"].Value = "10 Minute";
                            break;
                        case 3:
                            row.Cells["RetriggerCol"].Value = "1 Hour";
                            break;
                    }
                    row.Cells["PrintCol"].Value     = tblalarmgroup.Print;
                    row.Cells["IDCol"].Value = tblalarmgroup.ID.ToString() ;
                    row.Cells["ReadOnlyCol"].Value = tblalarmgroup.Readonly;
                    if (tblalarmgroup.Readonly)
                    {
                        row.ReadOnly = true;
                        dataGridView1.Rows[index].ReadOnly = true;
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            loaded = true;
            return ret;
        }


        #endregion

        #region Save
        public override bool SaveTabPage()
        {
            bool ret = false;
            int res = 0;
            tblAlarmGroup tblalarmgroup;
            string str;
            int count = dataGridView1.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                //dataGridView1.Rows[i].Selected = true;
                dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[0];
                if ((string)dataGridView1.Rows[i].Cells["NameCol"].Value != null)
                {
                    tblalarmgroup = new tblAlarmGroup();
                    tblalarmgroup.Name = (string)dataGridView1.Rows[i].Cells["NameCol"].Value;
                    str = (string)dataGridView1.Rows[i].Cells["TypeCol"].Value;
                    if (str == null)
                    {
                        tblalarmgroup.Type = 0;
                    }
                    else
                    {
                        switch (str)
                        {
                            case "Event":
                                tblalarmgroup.Type = 0;
                                break;
                            case "Self Acknowledge":
                                tblalarmgroup.Type = 1;
                                break;
                            case "Acknowledge on Set":
                                tblalarmgroup.Type = 2;
                                break;
                            case "Acknowledge on Set/Reset":
                                tblalarmgroup.Type = 3;
                                break;
                        }
                    }
                    tblalarmgroup.Archive = (bool)dataGridView1.Rows[i].Cells["ArchiveCol"].Value;
                    tblalarmgroup.oIndex = i;

                    str = (string)dataGridView1.Rows[i].Cells["RetriggerCol"].Value;
                    if (str == null)
                    {
                        tblalarmgroup.Retrigger = 0;
                    }
                    else
                    {
                        switch (str)
                        {
                            case "No":
                                tblalarmgroup.Retrigger = 0;
                                break;
                            case "1 Minute":
                                tblalarmgroup.Retrigger = 1;
                                break;
                            case "10 Minute":
                                tblalarmgroup.Retrigger = 2;
                                break;
                            case "1 Hour":
                                tblalarmgroup.Retrigger = 3;
                                break;
                        }
                    }
                    if (dataGridView1.Rows[i].Cells["PrintCol"].Value == null)
                    {
                        tblalarmgroup.Print = false;
                    }
                    else
                    {
                        tblalarmgroup.Print = (bool)dataGridView1.Rows[i].Cells["PrintCol"].Value;
                    }
                    tblalarmgroup.SolutionID = Global.EWS.m_tblSolution.SolutionID;
                    if ((string)dataGridView1.Rows[i].Cells["IDCol"].Value == "-1")
                    {
                        res = tblalarmgroup.Insert();
                        if (res != 0)
                        {
                            dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                            break;
                        }
                        else
                        {
                            dataGridView1.Rows[i].Cells["IDCol"].Value = tblalarmgroup.ID.ToString();
                        }
                    }
                    else
                    {
                        tblalarmgroup.ID = long.Parse((string)dataGridView1.Rows[i].Cells["IDCol"].Value);
                        foreach (tblAlarmGroup _tblalarmgroup in Global.EWS.m_tblSolution.m_tblAlarmGroupCollection)
                        {
                            if (_tblalarmgroup.ID == tblalarmgroup.ID)
                            {
                                if (_tblalarmgroup.Readonly == false)
                                {
                                    if ((tblalarmgroup.Name != _tblalarmgroup.Name) ||
                                        (tblalarmgroup.oIndex != _tblalarmgroup.oIndex) ||
                                        (tblalarmgroup.Type != _tblalarmgroup.Type) ||
                                        (tblalarmgroup.Archive != _tblalarmgroup.Archive) ||
                                        (tblalarmgroup.Retrigger != _tblalarmgroup.Retrigger) ||
                                        (tblalarmgroup.Print != _tblalarmgroup.Print))
                                    {
                                        //tblalarmgroup.ID = long.Parse((string)dataGridView1.Rows[i].Cells["IDCol"].Value);
                                        res = tblalarmgroup.Update();
                                        if (res != 0)
                                        {
                                            dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                                            break;
                                        }
                                    }


                                }
                                break;
                            }
                            else
                            {

                            }
                        }
                        if (res != 0)
                        {
                            break;
                        }
                    }
                    
                }
                //dataGridView1.Rows[i].Cells["RowCol"].Selected = false;
            }
            if (res == 0)
            {
                for (int i = 0; i < deletedlist.Count; i++)
                {
                    tblAlarmGroup tblalarmgroupdelete = new tblAlarmGroup();
                    tblalarmgroupdelete.ID = deletedlist[i];
                    tblalarmgroupdelete.Delete();
                }
                deletedlist.Clear();
                base.SaveTabPage();
                Global.EWS.m_tblSolution.m_tblAlarmGroupCollection = null;
            }
            return ret;
        }



        public override bool PrintTabPage()
        {
            bool ret = false;


            return ret;
        }


        public override bool CompileTabPage()
        {
            bool ret = false;

            return ret;
        }




        #endregion




    }
}


