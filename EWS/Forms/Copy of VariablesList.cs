using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DCS.Tools;
using DCS.DCSTables;
using System.Data.SQLite;


namespace DCS.Forms
{
    public partial class VariablesListCopy : Form
    {
        
        
        private DataTable _dataTable = null;
        private DataSet _dataSet = null;
        //private bool Loaded = false;

        //private TemporayVariable tempvar;
        //public TemporayVariable TempVar;

        public tblVariable tblvariable = new tblVariable();
        public tblFormalParameter tblformalparameter = new tblFormalParameter();
        
        public bool DomainEnable
        {
            set
            {
                comboBoxDomain.Enabled = value;
            }
        }

        private long _DomainID;
        public long DomainID
        {
            get
            {
                return _DomainID;
            }
            set
            {
                _DomainID = value;
            }
        }

        public bool ControllerEnable
        {
            set
            {
                comboBoxController.Enabled = value;
            }
        }
        private long _ControllerID;
        public long ControllerID
        {
            get
            {
                return _ControllerID;
            }
            set
            {
                _ControllerID = value;
            }
        }

        public bool pouEnable
        {
            set
            {
                comboBoxPOU.Enabled = value;
            }
        }
        private long _pouID;
        public long pouID
        {
            get
            {
                return _pouID;
            }
            set
            {
                _pouID = value;
            }
        }

        private List<long> _pouIDList = new List<long>();
        public List<long> pouIDList
        {
            get
            {
                return _pouIDList;
            }
            set
            {
                _pouIDList = value;
            }
        }

        public VariablesListCopy()
        {
            InitializeComponent();

            _dataTable = new DataTable();
            _dataSet = new DataSet();

            //initialize bindingsource
            bindingSource_main.DataSource = _dataSet;

            //initialize datagridview
            advancedDataGridView_main.DataSource = bindingSource_main;
            
            SetTestData();
            advancedDataGridView_main.Columns["ID"].Visible = false;
        }

        private void SetTestData()
        {
            _dataTable = _dataSet.Tables.Add("Variables");
            _dataTable.Columns.Add("Name", typeof(string));
            _dataTable.Columns.Add("Description", typeof(string));
            _dataTable.Columns.Add("Type", typeof(string));
            _dataTable.Columns.Add("Class", typeof(string));
            _dataTable.Columns.Add("ID", typeof(string));
            
            
            bindingSource_main.DataMember = _dataTable.TableName;

            //advancedDataGridViewSearchToolBar_main.SetColumns(advancedDataGridView_main.Columns);
        }

        private void FillDataset()
        {
            tblController tblcontroller = tblSolution.m_tblSolution().GetControllerFromID(ControllerID);


            foreach (tblPou tblpou in tblcontroller.m_tblPouCollection)
            {
                if (tblpou.pouID == (long)comboBoxPOU.SelectedValue)
                {
                    foreach (tblVariable tblvariable in tblpou.m_tblVariableCollection)
                    {
                        object[] newrow = new object[] { 
                                                                        tblvariable.VarName, 
                                                                            tblvariable.Description,
                                                                            tblSolution.m_tblSolution().VarTypeStringList[tblvariable.Type], 
                                                                            ((VarClass)tblvariable.Class).ToString(),
                                                                            ((long)tblvariable.VarNameID).ToString()
                                                                        };
                        _dataTable.Rows.Add(newrow);

                    }
                    break;
                }
            }



        }

        private void advancedDataGridView_main_FilterStringChanged(object sender, EventArgs e)
        {
            bindingSource_main.Filter = advancedDataGridView_main.FilterString;
            
        }

        private void advancedDataGridView_main_SortStringChanged(object sender, EventArgs e)
        {
            bindingSource_main.Sort = advancedDataGridView_main.SortString;
           
        }
        


        private void VariablesList_Load(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxDomain.Enabled == true)
                {
                    FillDomainCombo(DomainID);
                }
                if (comboBoxController.Enabled == true)
                {
                    FillControllerCombo(DomainID, ControllerID);
                }
                if (comboBoxPOU.Enabled == true)
                {
                    FillPOUCombo(DomainID, ControllerID, pouID);
                }
                FillDataset();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void buttonOK_Click(object sender, EventArgs e)
        {
            //bool closeCondition = false;

            //TempVar.PropertyType = (int)comboBoxProperty.SelectedValue;
            //TempVar.PropertyName = ((tblFormalParameter)(comboBoxProperty.SelectedItem)).PinName;
            //TempVar.PropertyNo = ((tblFormalParameter)(comboBoxProperty.SelectedItem)).oIndex;
            tblformalparameter = (tblFormalParameter)comboBoxProperty.SelectedItem;

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
           
            
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            //returnStatus = false;
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void textBoxInstanceName_TextChanged(object sender, EventArgs e)
        {
            if (textBoxInstanceName.Text != "")
            {
                buttonOK.Enabled = true;
            }
        }

        private void comboBoxFunctionGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        //private void listBoxFunctions_MouseDoubleClick(object sender, MouseEventArgs e)
        //{

        //}

        //private void listBoxFunctions_MouseClick(object sender, MouseEventArgs e)
        //{
        //    try
        //    {
                
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        private void comboBoxDomain_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBoxController_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBoxPOU_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                _dataTable.Clear();
                FillDataset();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void FillDomainCombo(long _domainid)
        {
            try
            {
                //comboBoxDomain.Items.Clear();
                //BindingList<tblDomain> _combo = new BindingList<tblDomain>();

                //foreach (tblDomain tbldomain in tblSolution.m_tblSolution().m_tblDomainCollection)
                //{
                //    _combo.Add(tbldomain);

                //}
                //comboBoxDomain.DataSource = _combo;
                //comboBoxDomain.DisplayMember = "DomainName";
                //comboBoxDomain.ValueMember = "DomainID";
                //foreach (tblDomain tbldomain in _combo)
                //{
                //    if (tbldomain.DomainID == _domainid)
                //    {
                //        //comboBoxDomain.SelectedText = tbldomain.DomainName;
                //        comboBoxDomain.SelectedValue = _domainid;
                //        break;
                //    }
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void FillControllerCombo(long _domainid, long _controllerid = -1)
        {
            try
            {
                //BindingList<tblController> _combo = new BindingList<tblController>();
                //tblDomain tbldomain = tblSolution.m_tblSolution().m_tblDomainCollection.GetObjectFromID(DomainID);
                //comboBoxController.DataSource = _combo;
                ////if (-1 != ControllerID)
                //{
                //    foreach (tblController tblcontroller in tbldomain.m_tblControllerCollection)
                //    {
                //        _combo.Add(tblcontroller);
                //    }
                //    //comboBoxController.DataSource = _combo;
                //    comboBoxController.DisplayMember = "ControllerName";
                //    comboBoxController.ValueMember = "ControllerID";

                //    foreach (tblController tblcontroller in _combo)
                //    {
                //        if (tblcontroller.ControllerID == _controllerid)
                //        {
                //            comboBoxController.SelectedValue = _controllerid;
                //            break;
                //            //UpdatePOUCombo();
                //        }
                //    }
                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void FillPOUCombo(long _domainid, long _controllerid, long _pouid)
        {
            try
            {
                BindingList<tblPou> _combo = new BindingList<tblPou>();
                tblController tblcontroller = tblSolution.m_tblSolution().GetControllerFromID(_controllerid);

                comboBoxPOU.DataSource = _combo;
                comboBoxPOU.DisplayMember = "pouName";
                comboBoxPOU.ValueMember = "pouID";
                foreach (tblPou tblpou in tblcontroller.m_tblPouCollection)
                {
                    if (tblpou.pouName == "GLOBAL")
                    {
                        _combo.Add(tblpou);
                        comboBoxPOU.SelectedValue = tblpou.pouID;
                    }
                    if (tblpou.pouID == _pouid)
                    {
                        _combo.Add(tblpou);
                    }
                }   
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void buttonAdvance_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBoxInstanceName_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void textBoxInstanceName_KeyUp(object sender, KeyEventArgs e)
        {
            string str = "([Name] LIKE '" + textBoxInstanceName.Text  + "%')";
            bindingSource_main.Filter = str;
            if (advancedDataGridView_main.RowCount == 1)
            {
                tblvariable.VarName = (string)this.advancedDataGridView_main.Rows[0].Cells[0].Value;
                tblvariable.Description = (string)this.advancedDataGridView_main.Rows[0].Cells[1].Value;
                string str1 = (string)this.advancedDataGridView_main.Rows[0].Cells[2].Value;
                //int i = Int32.Parse(str1);
                tblvariable.Type = tblSolution.m_tblSolution().StringVarTypeList[str1];
                //SelectedVarClass = (VarClass)this.advancedDataGridView_main.Rows[0].Cells[3].Value;
                tblvariable.VarNameID = (long)this.advancedDataGridView_main.Rows[0].Cells[4].Value;
                buttonOK.Enabled = true;
            }
        }

        private void advancedDataGridView_main_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
            try
            {
                
                
                
                buttonOK.Enabled = true;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBoxPOU_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _dataTable.Clear();
                FillDataset();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

                    string str1 = (string)this.advancedDataGridView_main.Rows[e.RowIndex].Cells[2].Value;
                    tblvariable.Type = tblSolution.m_tblSolution().StringVarTypeList[str1];

                    BindingList<tblFormalParameter> _combo = new BindingList<tblFormalParameter>();
                    comboBoxProperty.DataSource = _combo;
                    comboBoxProperty.DisplayMember = "PinName";
                    comboBoxProperty.ValueMember = "Type";
                    tblFunction tblfunction = tblSolution.m_tblSolution().GetFunctionbyType(tblvariable.Type);
                    for (int i = 0; i < tblfunction.m_tblFormalParameterCollection.Count; i++)
                    {
                        _combo.Add(tblfunction.m_tblFormalParameterCollection[i]);

                    }

                    tblvariable.VarName = (string)this.advancedDataGridView_main.Rows[e.RowIndex].Cells[0].Value;
                    tblvariable.Description  = (string)this.advancedDataGridView_main.Rows[e.RowIndex].Cells[1].Value;
                    
                    //SelectedVarClass = (VarClass)this.advancedDataGridView_main.Rows[e.RowIndex].Cells[3].Value;
                    //TempVar.domainid = DomainID;
                    //TempVar.controllerid = ControllerID;
                    tblvariable.pouID = (long)comboBoxPOU.SelectedValue;
                    tblformalparameter = (tblFormalParameter)comboBoxProperty.SelectedItem;
                    //TempVar.PropertyType = (int)comboBoxProperty.SelectedValue;
                    //tblformalparameter.PinName = ((tblFormalParameter)(comboBoxProperty.SelectedItem)).PinName;
                    //TempVar.PropertyNo = ((tblFormalParameter)(comboBoxProperty.SelectedItem)).oIndex;
                    str1 = (string)this.advancedDataGridView_main.Rows[e.RowIndex].Cells[4].Value;
                    tblvariable.VarNameID = long.Parse(str1);
                    buttonOK.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
                
        }

        private void comboBoxProperty_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

    }
}
