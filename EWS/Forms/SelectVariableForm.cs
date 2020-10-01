using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EWSTools;
using EWS.DCSTables;
using System.Data.SQLite;
using EWS.TagAutocomplete;

namespace EWS.Forms
{
    public partial class SelectVariableForm : Form
    {

        int TagType = 0;
        List<string> list = new List<string>();
        private DataTable _dataTable = null;
        private DataSet _dataSet = null;
        private bool _isobject = false;
        public string stringproperty;
        public bool IsObject
        {
            get
            {
                return _isobject;
            }
        }

        private bool _isconstant = false;
        public bool IsConstant
        {
            get
            {
                return _isconstant;
            }
        }

        private bool _isextendedproperty = false;
        public bool IsExtendedProperty
        {
            get
            {
                return _isextendedproperty;
            }
        }

        //private TemporayVariable tempvar;
        //public TemporayVariable TempVar;
        private tblVariable _tblvariable = new tblVariable();
        public tblVariable tblvariable
        {
            get
            {
                return _tblvariable;
            }
            set
            {
                _tblvariable = value;
            }
        }
        private tblFormalParameter _tblformalparameter = new tblFormalParameter();
        public tblFormalParameter tblformalparameter
        {
            get
            {
                return _tblformalparameter;
            }
            set
            {
                _tblformalparameter = value;
            }
        }
        public tblPou globalPOU;
        public tblPou localPOU;


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

        public SelectVariableForm()
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
            //_dataTable.Columns.Add("Class", typeof(string));
            _dataTable.Columns.Add("ID", typeof(long));


            bindingSource_main.DataMember = _dataTable.TableName;

            //advancedDataGridViewSearchToolBar_main.SetColumns(advancedDataGridView_main.Columns);
        }

        private void FillDataset()
        {
            try
            {
                tblPou selectedpou;
                if (globalPOU.pouID == (long)comboBoxPOU.SelectedValue)
                {
                    selectedpou = globalPOU;
                }
                else
                {
                    selectedpou = localPOU;
                }
                //int i = 0;
                foreach (tblVariable _tblvar in selectedpou.m_tblVariableCollection)
                {
                    if (Common.IsSimpleType(_tblvar.Type))
                    {
                        list.Add(_tblvar.VarName);
                        object[] newrow = new object[] { 
                                                                        _tblvar.VarName, 
                                                                            _tblvar.Description,
                                                                            Global.Instance.m_tblSolution.VarTypeStringList[_tblvar.Type],
                                                                           // ((VarClass)tblvariable.Class).ToString(),
                                                                            ((long)_tblvar.VarNameID)
                                                                        };
                        _dataTable.Rows.Add(newrow);
                    }
                }
                autocompleteMenu1.SetAutocompleteItems(list);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                FillPOUCombo();
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
            //tblformalparameter = (tblFormalParameter)comboBoxProperty.SelectedItem;

            string str = textBoxInstanceName.Text;
            string[] words = str.Split('.');
            List<string> tag = new List<string>();
            int len = 0;
            bool hasdot = false;
            len = words.GetLength(0);

            tblPou selectedpou;
            if (globalPOU.pouID == (long)comboBoxPOU.SelectedValue)
            {
                selectedpou = globalPOU;
            }
            else
            {
                selectedpou = localPOU;
            }

            for (int i = 0; i < len; i++)
            {
                if (words[i] != "")
                {
                    tag.Add(words[i]);
                }
                else
                {
                    hasdot = true;
                }
            }
            len = tag.Count;

            if (len == 0)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                Close();
            }
            else
            {
                if ((len == 1))
                {
                    if (hasdot)
                    {
                        TagType = GetTagType(tag[0]);
                    }
                    else
                    {
                        foreach (tblVariable _tblvar in selectedpou.m_tblVariableCollection)
                        {
                            if (_tblvar.VarName == tag[0])
                            {
                                tblvariable = _tblvar;
                                _isobject = true;
                                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                                Close();
                            }
                        }
                    }
                }
                else
                {
                    if ((len == 2))
                    {
                        _isextendedproperty = false;
                        //if (hasdot)
                        {
                            foreach (tblVariable _tblvar in selectedpou.m_tblVariableCollection)
                            {
                                if (_tblvar.VarName.ToUpper() == tag[0].ToUpper())
                                {
                                    tblvariable = _tblvar;
                                    break;
                                }
                            }
                            tblFunction _function = Global.Instance.m_tblSolution.GetFunctionFromType(tblvariable.Type);
                            foreach (tblFormalParameter fp in _function.m_tblFormalParameterCollection)
                            {
                                if (fp.PinName == tag[1])
                                {
                                    tblformalparameter = fp;
                                    _isobject = false;
                                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                                    Close();
                                }
                            }
                        }
                    }
                    else
                    {
                        if (len == 3)
                        {
                            _isobject = false;
                            _isextendedproperty = true;
                            stringproperty = "";
                            foreach (tblVariable _tblvar in selectedpou.m_tblVariableCollection)
                            {
                                if (_tblvar.VarName.ToUpper() == tag[0].ToUpper())
                                {
                                    tblvariable = _tblvar;
                                    break;
                                }
                            }
                            tblFunction _function = Global.Instance.m_tblSolution.GetFunctionFromType(tblvariable.Type);
                            foreach (tblFormalParameter fp in _function.m_tblFormalParameterCollection)
                            {
                                if (fp.PinName.ToUpper() == tag[1].ToUpper())
                                {
                                    tblformalparameter = fp;

                                    if (tag[1].ToUpper() == "MODE")
                                    {
                                        for (int i = 0; i < _function.Modes.Count; i++ )
                                        {
                                            if (tag[2].ToUpper() == _function.Modes[i].ToUpper())
                                            {
                                                stringproperty = tag[2];
                                                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                                                Close();
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if ((tag[1].ToUpper() == "ALS") ||
                                            (tag[1].ToUpper() == "ALA") ||
                                            (tag[1].ToUpper() == "ALB") ||
                                            (tag[1].ToUpper() == "AEB"))
                                        {
                                            for (int i = 0; i < _function.Statuses.Count; i++ )
                                            {
                                                if (tag[2].ToUpper() == _function.Statuses[i].ToUpper())
                                                {
                                                    stringproperty = tag[2];
                                                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                                                    Close();
                                                }
                                            }
                                        }
                                        else
                                        {
                                            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                                            Close();
                                        }
                                    }

                                    _isobject = false;
                                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                                    Close();
                                }
                            }
                        }
                    }
                }
            }


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
            string str = textBoxInstanceName.Text;
            string[] words = str.Split('.');
            List<string> tag = new List<string>();
            int len = 0;
            bool hasdot = false;
            len = words.GetLength(0);

            for (int i = 0; i < len; i++)
            {
                if (words[i] != "")
                {
                    tag.Add(words[i]);
                }
                else
                {
                    hasdot = true;
                }
            }
            len = tag.Count;

            if (len == 0)
            {
                autocompleteMenu1.SetAutocompleteItems(list);
            }
            else
            {
                if ((len == 1))
                {
                    if (hasdot)
                    {
                        TagType = GetTagType(tag[0]);
                        tblFunction _function = Global.Instance.m_tblSolution.GetFunctionFromType(TagType);
                        autocompleteMenu1.AppendMode = true;
                        autocompleteMenu1.ClearAll();
                        for (int k = 0; k < _function.m_tblFormalParameterCollection.Count; k++)
                        {
                            autocompleteMenu1.AddItem(new TagObject(_function.m_tblFormalParameterCollection[k].PinName));
                        }
                    }
                    else
                    {
                        autocompleteMenu1.SetAutocompleteItems(list);
                    }
                }
                else
                {
                    if ((len == 2))
                    {
                        if (hasdot)
                        {
                            tblFunction _function = Global.Instance.m_tblSolution.GetFunctionFromType(TagType);
                            autocompleteMenu1.AppendMode = true;
                            autocompleteMenu1.ClearAll();
                            if (tag[1].ToUpper() == "MODE")
                            {
                                int i = 1;
                                MODE tmode;
                                for (int k = 0; k < 32; k++)
                                {
                                    tmode = (MODE)i;
                                    if ((_function.Mode & i) != 0)
                                    {
                                        autocompleteMenu1.AddItem(new TagObject(tmode.ToString()));
                                    }
                                    i *= 2;
                                }
                            }
                            if ((tag[1].ToUpper() == "ALS") ||
                                (tag[1].ToUpper() == "ALA") ||
                                (tag[1].ToUpper() == "ALB") ||
                                (tag[1].ToUpper() == "AEB"))
                            {
                                int i = 1;
                                AlarmStatus tstatus;
                                for (int k = 0; k < 32; k++)
                                {
                                    tstatus = (AlarmStatus)i;
                                    if ((_function.Status & i) != 0)
                                    {
                                        autocompleteMenu1.AddItem(new TagObject(tstatus.ToString()));
                                    }
                                    i *= 2;
                                }

                            }
                        }
                    }
                    else
                    {
                        autocompleteMenu1.ClearAll();
                    }
                }
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

        int GetTagType(string tagname)
        {
            foreach (DataRow row in _dataTable.Rows)
            {
                if (tagname.ToUpper() == ((string)row[0]).ToUpper())
                {
                    string str = ((string)row[2]).ToUpper();
                    VarType _vartype = (VarType)Enum.Parse(typeof(VarType), str);
                    return ((int)_vartype);
                }
            }

            return 0;
        }


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





        private void FillPOUCombo()
        {
            try
            {
                BindingList<tblPou> _combo = new BindingList<tblPou>();
                comboBoxPOU.DataSource = _combo;
                comboBoxPOU.DisplayMember = "pouName";
                comboBoxPOU.ValueMember = "pouID";
                _combo.Add(globalPOU);
                comboBoxPOU.SelectedValue = globalPOU.pouID;
                _combo.Add(localPOU);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }




        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBoxInstanceName_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBoxInstanceName_KeyUp(object sender, KeyEventArgs e)
        {
            //string str = textBoxInstanceName.Text;
            string[] words = textBoxInstanceName.Text.Split('.');
            //string str = "([Name] LIKE '" + textBoxInstanceName.Text  + "%')";
            string str = "([Name] LIKE '" + words[0] + "%')";
            bindingSource_main.Filter = str;
            if (advancedDataGridView_main.RowCount == 1)
            {
                tblvariable.VarName = (string)this.advancedDataGridView_main.Rows[0].Cells[0].Value;
                tblvariable.Description = (string)this.advancedDataGridView_main.Rows[0].Cells[1].Value;
                string str1 = (string)this.advancedDataGridView_main.Rows[0].Cells[2].Value;
                //int i = Int32.Parse(str1);
                tblvariable.Type = Global.Instance.m_tblSolution.StringVarTypeList[str1];
                //SelectedVarClass = (VarClass)this.advancedDataGridView_main.Rows[0].Cells[3].Value;
                tblvariable.VarNameID = (long)this.advancedDataGridView_main.Rows[0].Cells[3].Value;
                //buttonOK.Enabled = true;
            }
        }

        private void advancedDataGridView_main_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                if (e.RowIndex == -1)
                {

                }
                else
                {
                    textBoxInstanceName.Text = (string)this.advancedDataGridView_main.Rows[e.RowIndex].Cells[0].Value;
                    //string str1 = (string)this.advancedDataGridView_main.Rows[e.RowIndex].Cells[2].Value;
                    //tblvariable.Type = Global.Instance.m_tblSolution.StringVarTypeList[str1];
                    //BindingList<tblFormalParameter> _combo = new BindingList<tblFormalParameter>();
                    //comboBoxProperty.DataSource = _combo;
                    //comboBoxProperty.DisplayMember = "PinName";
                    //comboBoxProperty.ValueMember = "Type";
                    //tblFunction tblfunction = Global.Instance.m_tblSolution.m_tblFunctionCollection.GetFunctionbyType(tblvariable.Type);
                    //for (int i = 0; i < tblfunction.m_tblFormalParameterCollection.Count; i++)
                    //{
                    //    _combo.Add(tblfunction.m_tblFormalParameterCollection[i]);
                    //}
                    //tblvariable.VarName = (string)this.advancedDataGridView_main.Rows[e.RowIndex].Cells[0].Value;
                    //tblvariable.Description = (string)this.advancedDataGridView_main.Rows[e.RowIndex].Cells[1].Value;
                    //tblvariable.pouID = (long)comboBoxPOU.SelectedValue;
                    //tblformalparameter = (tblFormalParameter)comboBoxProperty.SelectedItem;
                    //tblvariable.VarNameID = (long)this.advancedDataGridView_main.Rows[e.RowIndex].Cells[3].Value;
                    //buttonOK.Enabled = true;
                }


                //buttonOK.Enabled = true;
                //this.DialogResult = System.Windows.Forms.DialogResult.OK;
                //Close();
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
                textBoxInstanceName.Text = "";
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
                    textBoxInstanceName.Text = (string)this.advancedDataGridView_main.Rows[e.RowIndex].Cells[0].Value;
                    //string str1 = (string)this.advancedDataGridView_main.Rows[e.RowIndex].Cells[2].Value;
                    //tblvariable.Type = Global.Instance.m_tblSolution.StringVarTypeList[str1];
                    //BindingList<tblFormalParameter> _combo = new BindingList<tblFormalParameter>();
                    //comboBoxProperty.DataSource = _combo;
                    //comboBoxProperty.DisplayMember = "PinName";
                    //comboBoxProperty.ValueMember = "Type";
                    //tblFunction tblfunction = Global.Instance.m_tblSolution.m_tblFunctionCollection.GetFunctionbyType(tblvariable.Type);
                    //for (int i = 0; i < tblfunction.m_tblFormalParameterCollection.Count; i++)
                    //{
                    //    _combo.Add(tblfunction.m_tblFormalParameterCollection[i]);
                    //}
                    //tblvariable.VarName = (string)this.advancedDataGridView_main.Rows[e.RowIndex].Cells[0].Value;
                    //tblvariable.Description  = (string)this.advancedDataGridView_main.Rows[e.RowIndex].Cells[1].Value;
                    //tblvariable.pouID = (long)comboBoxPOU.SelectedValue;
                    //tblformalparameter = (tblFormalParameter)comboBoxProperty.SelectedItem;
                    //tblvariable.VarNameID = (long)this.advancedDataGridView_main.Rows[e.RowIndex].Cells[3].Value;
                    //buttonOK.Enabled = true;
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
