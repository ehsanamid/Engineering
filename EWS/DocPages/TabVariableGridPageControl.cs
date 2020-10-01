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
    public delegate void TabVariableGridPageControlSetDirty(object sender, EventArgs e);

    public partial class TabVariableGridPageControl : TabPageControl
    {
        public event TabVariableGridPageControlSetDirty TabVariableGridPageControlSetDirtyChanged;
        private DataTable _dataTable = null;
        private DataSet _dataSet = null;
        private Zuby.ADGV.AdvancedDataGridView advancedDataGridView_main;
        private BindingSource bindingSource_main;
        private IContainer components;
        //public DrawArea drawarea;
        private bool Loaded = false;
        List<VariableGrid> tempList = new List<VariableGrid>();
        public Panel panelTabPage;
        private VariableGrid Selectedvariablegrid;
        private int selectedIndex = -1;
        public TabVariableGridPageControl(EXTabControl _parent, long id)
            : base(_parent, id)
        {

            InitializeComponent();
            TabPageType = TABPAGETYPE.VARIABLE;
            _dataTable = new DataTable();
            _dataSet = new DataSet();

            //initialize bindingsource
            bindingSource_main.DataSource = _dataSet;

            //initialize datagridview
            advancedDataGridView_main.DataSource = bindingSource_main;

            _dataTable = _dataSet.Tables.Add("Variables");
            _dataTable.Columns.Add("Name", typeof(string));
            _dataTable.Columns.Add("Description", typeof(string));
            _dataTable.Columns.Add("POU", typeof(string));
            _dataTable.Columns.Add("Type", typeof(string));
            _dataTable.Columns.Add("InitialVal", typeof(string));
            _dataTable.Columns.Add("GroupID", typeof(string));

            
            bindingSource_main.DataMember = _dataTable.TableName;
            
            
            
            


        }

        protected virtual void OnTabVariableGridPageControlSetDirty(EventArgs e)
        {
            if (TabVariableGridPageControlSetDirtyChanged != null)
            {
                this.TabVariableGridPageControlSetDirtyChanged(this, e);
            }
        }

        //private ImageList imageList1;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelTabPage = new System.Windows.Forms.Panel();
            this.advancedDataGridView_main = new Zuby.ADGV.AdvancedDataGridView();
            this.bindingSource_main = new System.Windows.Forms.BindingSource(this.components);
            this.panelTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView_main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_main)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTabPage
            // 
            this.panelTabPage.AutoScroll = true;
            this.panelTabPage.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelTabPage.Controls.Add(this.advancedDataGridView_main);
            this.panelTabPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTabPage.Location = new System.Drawing.Point(0, 0);
            this.panelTabPage.Name = "panelTabPage";
            this.panelTabPage.Size = new System.Drawing.Size(550, 187);
            this.panelTabPage.TabIndex = 0;
            // 
            // advancedDataGridView_main
            // 
            this.advancedDataGridView_main.AllowUserToResizeRows = false;
            this.advancedDataGridView_main.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advancedDataGridView_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advancedDataGridView_main.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.advancedDataGridView_main.FilterAndSortEnabled = true;
            this.advancedDataGridView_main.Location = new System.Drawing.Point(0, 0);
            this.advancedDataGridView_main.Name = "advancedDataGridView_main";
            this.advancedDataGridView_main.RowHeadersVisible = false;
            this.advancedDataGridView_main.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.advancedDataGridView_main.Size = new System.Drawing.Size(550, 187);
            this.advancedDataGridView_main.TabIndex = 0;
            this.advancedDataGridView_main.SortStringChanged += new System.EventHandler(this.advancedDataGridView_main_SortStringChanged);
            this.advancedDataGridView_main.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.advancedDataGridView_main_CellClick);
            this.advancedDataGridView_main.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.advancedDataGridView_main_CellDoubleClick);
            this.advancedDataGridView_main.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.advancedDataGridView_main_ColumnWidthChanged);
            // 
            // TabVariableGridPageControl
            // 
            this.Controls.Add(this.panelTabPage);
            this.panelTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView_main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_main)).EndInit();
            this.ResumeLayout(false);

        }

        private void advancedDataGridView_main_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            if (Loaded)
            {
                    Common.TabVariableGridPageControl_NameColWidth          = advancedDataGridView_main.Columns[0].Width ; 
                    Common.TabVariableGridPageControl_DescriptionColWidth   = advancedDataGridView_main.Columns[1].Width ; 
                    Common.TabVariableGridPageControl_POUColWidth           = advancedDataGridView_main.Columns[2].Width ; 
                    Common.TabVariableGridPageControl_TypeColWidth          = advancedDataGridView_main.Columns[3].Width ; 
                    Common.TabVariableGridPageControl_InitialValColWidth    = advancedDataGridView_main.Columns[4].Width ;
                    Common.TabVariableGridPageControl_GroupColWidth         = advancedDataGridView_main.Columns[5].Width; 
            
                
            }
        }
        
        private void advancedDataGridView_main_SortStringChanged(object sender, EventArgs e)
        {
            bindingSource_main.Sort = advancedDataGridView_main.SortString;

        }

        private void advancedDataGridView_main_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1)
                {

                }
                else
                {
                    selectedIndex = e.RowIndex;
                    string str1 = (string)this.advancedDataGridView_main.Rows[e.RowIndex].Cells[0].Value;
                    str1 = str1.ToLower();
                    foreach (VariableGrid variablegrid in tempList)
                    {

                        if (variablegrid.VarName.ToLower() == str1)
                        {
                            Selectedvariablegrid = variablegrid;
                            EXParent.mainEWSForm.propertyWindowControl.propertyGridComponemt.SelectedObject = Selectedvariablegrid;
                        }
                           
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void advancedDataGridView_main_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            

        }


        //private string titletext = "title";

        public void ClearSelection()
        {
            advancedDataGridView_main.ClearSelection();
        }



        public override void CloseTabPage()
        {
            base.CloseTabPage();

            

            //initialize bindingsource
            bindingSource_main.DataSource = _dataSet;

            advancedDataGridView_main.DataSource = null;
            advancedDataGridView_main.Rows.Clear();
            GC.Collect();
            _dataSet = null;
            
            //components.Dispose();
            //_dataTable.Columns.Clear();
            //_dataTable.Dispose();
            //_dataSet.Dispose();
            

            //bindingSource_main.Dispose();
            panelTabPage.Dispose();
            this.Controls.Clear();

        }


        #region Load
        public override bool LoadTabPage()
        {
            bool ret = false;
            try
            {
                VariableGrid variablegrid;
                tblController tblcontroller = Global.EWS.m_tblSolution.GetControllerFromID(ID);
                foreach (tblPou tblpou in tblcontroller.m_tblPouCollection)
                {
                    foreach (tblVariable tblvariable in tblpou.m_tblVariableCollection)
                    {
                        if ((!Common.IsFunctionType(tblvariable.Type)) && (tblvariable.Class & (int)VarClass.FunctionInstanse) == 0)
                        {
                            switch ((VarType)tblvariable.Type)
                            {
                                case VarType.BOOL:
                                    variablegrid = new BoolVariableGrid(tblvariable);
                                    break;
                                case VarType.REAL:
                                    variablegrid = new RealVariableGrid(tblvariable);
                                    break;
                                default:
                                    variablegrid = new VariableGrid(tblvariable);
                                    break;
                            }
                            tempList.Add(variablegrid);
                        }

                    }
                }
                foreach (VariableGrid _variablegrid in tempList)
                {
                    object[] newrow = new object[] { _variablegrid.VarName, 
                                                     _variablegrid.Description,
                                                     _variablegrid.pouName,
                                                     _variablegrid.TypeName, 
                                                     _variablegrid.InitialVal,
                                                     _variablegrid.PlantStructureName };
                    _dataTable.Rows.Add(newrow);
                }
                advancedDataGridView_main.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return ret;
        }


        #endregion

        #region Save
        public override bool SaveTabPage()
        {
            tblVariable tblvariable;
            bool ret = true;
            tblPou tblpou = null;
            foreach (VariableGrid variablegrid in tempList)
            {
                if (variablegrid.Modified)
                {
                    if ((tblpou == null) || (tblpou.pouID != variablegrid.pouID))
                    {
                        tblpou = Global.EWS.m_tblSolution.GetPouFromID(variablegrid.pouID);
                    }
                    tblvariable = tblpou.GetVariableFromID(variablegrid.VarNameID);
                    if (tblvariable != null)
                    {
                        tblvariable.CopyVariableGrid(variablegrid);
                        if (tblvariable.Update() != 0)
                        {
                            ret = false;
                            break;
                        }
                        variablegrid.Modified = false;
                    }

                }
            }
            if (ret)
            {
                base.SaveTabPage();
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

        public override bool UpdateTabPage()
        {
            bool ret = true;
            //advancedDataGridView_main.Refresh();
            Dirty = true;
            int index = selectedIndex;
            int index1 = advancedDataGridView_main.SelectedRows[0].Index;
            object ss = _dataTable.Rows[index];


            _dataTable.Rows[selectedIndex]["Name"] = Selectedvariablegrid.VarName;
            _dataTable.Rows[selectedIndex]["Description"] = Selectedvariablegrid.Description;
            _dataTable.Rows[selectedIndex]["POU"] = Selectedvariablegrid.pouName;
            _dataTable.Rows[selectedIndex]["Type"] = Selectedvariablegrid.TypeName;
            _dataTable.Rows[selectedIndex]["InitialVal"] = Selectedvariablegrid.InitialVal;
            _dataTable.Rows[selectedIndex]["GroupID"] = Selectedvariablegrid.PlantStructureName;
            Selectedvariablegrid.Modified = true;

            return ret;
        }


        #endregion


        public void SetColumns()
        {
            try
            {
                if (Common.TabVariableGridPageControl_NameColWidth > 0)
                {
                    advancedDataGridView_main.Columns[0].Width = Common.TabVariableGridPageControl_NameColWidth;
                }
                if (Common.TabVariableGridPageControl_DescriptionColWidth > 0)
                {
                    advancedDataGridView_main.Columns[1].Width = Common.TabVariableGridPageControl_DescriptionColWidth;
                }
                if (Common.TabVariableGridPageControl_POUColWidth > 0)
                {
                    advancedDataGridView_main.Columns[2].Width = Common.TabVariableGridPageControl_POUColWidth;
                }
                if (Common.TabVariableGridPageControl_TypeColWidth > 0)
                {
                    advancedDataGridView_main.Columns[3].Width = Common.TabVariableGridPageControl_TypeColWidth;
                }
                if (Common.TabVariableGridPageControl_InitialValColWidth > 0)
                {
                    advancedDataGridView_main.Columns[4].Width = Common.TabVariableGridPageControl_InitialValColWidth;
                }
                if (Common.TabVariableGridPageControl_GroupColWidth > 0)
                {
                    advancedDataGridView_main.Columns[5].Width = Common.TabVariableGridPageControl_GroupColWidth;
                }
            }
            catch (Exception ex)
            {

            }
            Loaded = true;
        }


    }
}


