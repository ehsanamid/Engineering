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
using DCS.Draw;


namespace DCS.Forms
{
    public partial class InsertFBD : Form
    {

        
        public string Selectedfunction;
        public int NoOfExtension;
        public bool functionusing;
        bool IsFunction;


        public tblFunction _tblfunction;
        public tblVariable _tblvariable = new tblVariable();

        

        
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

        

        List<string> categorylist = new List<string>();
        public InsertFBD(bool _isfunction)
        {
            IsFunction = _isfunction;
            InitializeComponent();
            

            

            categorylist.Add("TYPE CONVERSION");
            categorylist.Add("NUMERICAL");
            categorylist.Add("ARITHMETIC");
            categorylist.Add("BITWISE");
            categorylist.Add("CHARACTER STRING");
            categorylist.Add("TIME");
            categorylist.Add("BIT SHIFT");
            categorylist.Add("COMPARISON");
            categorylist.Add("SELECTION");
            categorylist.Add("ADDITIONAL");
            categorylist.Add("FLIP FLOP");
            categorylist.Add("EDGE DETECTION");
            categorylist.Add("COUNTER");
            categorylist.Add("TIMER");
            categorylist.Add("USER DEFINED");
            categorylist.Add("KTC DEFINED");
            categorylist.Add("All");

            bool catrgoryadded = false;
            comboBoxFunctionGroup.Items.Add("All");
            foreach (tblFunction tblfunction in tblSolution.m_tblSolution().m_tblFunctionCollection)
            {
                if (tblfunction.IsFunction == IsFunction)
                {
                    if ((int)FunctionGroup.BASIC_TYPES != tblfunction.FunctionGroup)
                    {
                        catrgoryadded = false;
                        foreach (string str in comboBoxFunctionGroup.Items)
                        {
                            if (str == categorylist[tblfunction.FunctionGroup])
                            {
                                catrgoryadded = true;
                                break;
                            }
                        }
                        if (!catrgoryadded)
                        {
                            comboBoxFunctionGroup.Items.Add(categorylist[tblfunction.FunctionGroup]);
                        }
                        
                    }
                }
            }
            if (IsFunction)
            {
                comboBoxFunctionGroup.SelectedItem = Common.SelectedFunctionCategory;
            }
            else
            {
                comboBoxFunctionGroup.SelectedItem = Common.SelectedFunctionBlockCategory;
            }
        }
        private void FillFunctionList(string GroupName)
        {
            BindingList<tblFunction> _list = new BindingList<tblFunction>();
            
            string functionname;
            int category;
            listBoxFunctions.Items.Clear();
            foreach (tblFunction tblfunction in tblSolution.m_tblSolution().m_tblFunctionCollection)
            {
                if (tblfunction.IsFunction == IsFunction)
                {
                    functionname = tblfunction.FunctionName;
                    category = tblfunction.FunctionGroup;
                    if ((int)FunctionGroup.BASIC_TYPES != category)
                    {
                        
                        if ("All" == GroupName)
                        {

                            listBoxFunctions.Items.Add(tblfunction);
                            listBoxFunctions.DisplayMember = "FunctionName";
                            listBoxFunctions.ValueMember = "FunctionID";

                        }
                        else
                        {
                            if (GroupName == categorylist[category])
                            {

                                listBoxFunctions.Items.Add(tblfunction);
                                listBoxFunctions.DisplayMember = "FunctionName";
                                listBoxFunctions.ValueMember = "FunctionID";
                            }
                        }
                    }
                }
            }
        }


        private void Block_Properties_Load(object sender, EventArgs e)
        {
            try
            {
                if (IsFunction)
                {
                    textBoxInstanceName.Enabled = false;
                }
                else
                {
                    textBoxInstanceName.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void buttonOK_Click(object sender, EventArgs e)
        {

            OK_Click();

        }

        private void OK_Click()
        {

            if (this.listBoxFunctions.SelectedItem != null)
            {

                _tblvariable.VarNameID = -1;
                _tblvariable.pouID = pouID;
                _tblvariable.Description = textBoxDescription.Text;
                _tblvariable.PlantStructureID = tblSolution.m_tblSolution().GetControllerobjectofPOUID(pouID).PlantStructureID;
                if (IsFunction == true)
                {
                    _tblvariable.Class = (int)VarClass.FunctionInstanse;
                    //10092016
                    //tblvariable.Type = ((tblFunction)listBoxFunctions.SelectedItem).Type;  
                    _tblvariable.Type = ((tblFunction)listBoxFunctions.SelectedItem).GetReturnType();
                    _tblvariable.setInitPinState();
                    _tblvariable.VarName = "";

                    if (_tblfunction.Extensible)
                    {
                        NoOfExtension = (int)numericUpDownNoOfInputs.Value;
                    }
                    else
                    {
                        NoOfExtension = 0;
                    }
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    Close();
                }
                else
                {
                    _tblvariable.Type = ((tblFunction)listBoxFunctions.SelectedItem).Type;
                    _tblvariable.Class = (int)VarClass.FBInstance;
                    _tblvariable.setInitPinState();
                    _tblvariable.VarName = textBoxInstanceName.Text.ToUpper();
                    if (tblVariable.checkVariableName(_tblvariable.VarName, _tblvariable.pouID))
                    {

                        MessageBox.Show("Variable Exists", "Error", MessageBoxButtons.RetryCancel);
                    }
                    else
                    {
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        Close();
                    }
                }
            }
            else
            {

            }

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void textBoxInstanceName_TextChanged(object sender, EventArgs e)
        {
            if ((textBoxInstanceName.Text != "") && (this.listBoxFunctions.SelectedItem != null))
            {
                buttonOK.Enabled = true;
            }
        }

        private void comboBoxFunctionGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (IsFunction)
                {
                    Common.SelectedFunctionCategory = (string)comboBoxFunctionGroup.SelectedItem;
                }
                else
                {
                    Common.SelectedFunctionBlockCategory = (string)comboBoxFunctionGroup.SelectedItem;
                }

                FillFunctionList((string)comboBoxFunctionGroup.SelectedItem);
                richTextBox1.Text = "";
                buttonOK.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void listBoxFunctions_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!IsFunction)
            {
                {
                    if (textBoxInstanceName.Text == "")
                    {
                    }

                }
            }
            else
            {
                OK_Click();
            }
        }

        private void listBoxFunctions_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                _tblfunction = (tblFunction)listBoxFunctions.SelectedItem;
                richTextBox1.Text = _tblfunction.Description;
                if (((tblFunction)listBoxFunctions.SelectedItem).Extensible)
                {
                    numericUpDownNoOfInputs.Visible = true;
                    label2.Visible = true;
                }
                else
                {
                    numericUpDownNoOfInputs.Visible = false;
                    label2.Visible = false;
                }
                if (IsFunction)
                {
                    buttonOK.Enabled = true;
                }
                else
                {
                    if (textBoxInstanceName.Text != "")
                    {
                        buttonOK.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    
        private void textBoxInstanceName_Leave(object sender, EventArgs e)
        {
            textBoxInstanceName.Text = textBoxInstanceName.Text.ToUpper();
        }

    }
}
