using DCS.DCSTables;
using DCS.Forms;
//using DocToolkit.Project_Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DCS.TabPages
{
    public partial class TabGridPageControl : TabPageControl
    {
        private DataTable _dataTable = null;
        private DataSet _dataSet = null;
        private Zuby.ADGV.AdvancedDataGridView advancedDataGridView_main;
        private BindingSource bindingSource_main;
        private IContainer components;
        //public DrawArea drawarea;
        

        public Panel panelTabPage;
        public TabGridPageControl( long id)
            : base(id)
        {

            InitializeComponent();
            _dataTable = new DataTable();
            _dataSet = new DataSet();

            //initialize bindingsource
            bindingSource_main.DataSource = _dataSet;

            //initialize datagridview
            advancedDataGridView_main.DataSource = bindingSource_main;

            SetTestData();
            //advancedDataGridView_main.Columns["ID"].Visible = false;


        }
        private void SetTestData()
        {    
            _dataTable = _dataSet.Tables.Add("Variables");
            _dataTable.Columns.Add("Name", typeof(string));
            _dataTable.Columns.Add("Description", typeof(string));
            _dataTable.Columns.Add("POU", typeof(string));
            _dataTable.Columns.Add("Type", typeof(string));
            _dataTable.Columns.Add("InitialVal", typeof(string));
            _dataTable.Columns.Add("GroupID", typeof(string));

            
            bindingSource_main.DataMember = _dataTable.TableName;

            //advancedDataGridViewSearchToolBar_main.SetColumns(advancedDataGridView_main.Columns);
        }


        //private ImageList imageList1;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelTabPage = new System.Windows.Forms.Panel();
            this.advancedDataGridView_main = new Zuby.ADGV.AdvancedDataGridView();
            this.bindingSource_main = new System.Windows.Forms.BindingSource(this.components);
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
            this.advancedDataGridView_main.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advancedDataGridView_main.FilterAndSortEnabled = true;
            this.advancedDataGridView_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advancedDataGridView_main.Location = new System.Drawing.Point(0, 0);
            this.advancedDataGridView_main.Name = "advancedDataGridView_main";
            this.advancedDataGridView_main.Size = new System.Drawing.Size(240, 150);
            this.advancedDataGridView_main.TabIndex = 0;
            this.advancedDataGridView_main.SortStringChanged += new System.EventHandler(this.advancedDataGridView_main_SortStringChanged);
            this.advancedDataGridView_main.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.advancedDataGridView_main_CellClick);
            this.advancedDataGridView_main.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.advancedDataGridView_main_CellDoubleClick);
           
            // 
            // TabGridPageControl
            // 
            this.Controls.Add(this.panelTabPage);
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView_main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_main)).EndInit();
            this.ResumeLayout(false);

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
                    tblController tblcontroller = tblSolution.m_tblSolution().GetControllerFromID(ID);
                    
                    string str = (string)this.advancedDataGridView_main.Rows[e.RowIndex].Cells[2].Value;
                    str = str.ToLower();
                    string str1 = (string)this.advancedDataGridView_main.Rows[e.RowIndex].Cells[0].Value;
                    str1 = str1.ToLower();
                    foreach (tblPou tblpou in tblcontroller.m_tblPouCollection)
                    {
                        if (str == tblpou.pouName.ToLower())
                        {
                            foreach (tblVariable tblvariable in tblpou.m_tblVariableCollection)
                            {
                                if (tblvariable.VarName.ToLower() == str1)
                                {
                                    MainForm.Instance().m_propertyGrid.SelectedObject = tblvariable;
                                }
                            }
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





        public override void CloseTabPage()
        {
            base.CloseTabPage();
            _dataTable.Clear();
            _dataSet.Clear();
            advancedDataGridView_main.Dispose();
            bindingSource_main.Dispose();
            components.Dispose();
            //public DrawArea drawarea;


            panelTabPage.Dispose();
        }


        #region Load
        public override bool LoadTabPage()
        {
            bool ret = false;
            try
            {
                tblController tblcontroller = tblSolution.m_tblSolution().GetControllerFromID(ID);
                foreach (tblPou tblpou in tblcontroller.m_tblPouCollection)
                {
                    foreach (tblVariable tblvariable in tblpou.m_tblVariableCollection)
                    {
                        if ( (!Common.IsFunctionType(tblvariable.Type)) && (tblvariable.Class & (int)VarClass.FunctionInstanse ) == 0 )
                        {
                            object[] newrow = new object[] { tblvariable.VarName, 
                                                     tblvariable.Description,
                                                     tblpou.pouName,
                                                     tblSolution.m_tblSolution().VarTypeStringList[tblvariable.Type], 
                                                     tblvariable.InitialVal,
                                                     tblSolution.m_tblSolution().AreaStringList[tblvariable.PlantStructureID]
                                                                        };
                            _dataTable.Rows.Add(newrow);
                        }

                    }


                }
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
            bool ret = false;

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


