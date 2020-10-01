using DCS.DCSTables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DCS.Forms
{
    public partial class UDFPinForm : Form
    {
        bool loaded = false;
        bool Dirty = false;
        //bool _IsFunction;
        tblFunction _tblfunction;
        tblPou _tblpou;
        List<tblFormalParameter> varlist = new List<tblFormalParameter>();
        public UDFPinForm(bool _isfunction,string _pouname) 
        {
            InitializeComponent();
            foreach (tblPou tblpou in tblSolution.m_tblSolution().Dummytblcontroller.m_tblPouCollection)
            {
                if (tblpou.pouName.ToUpper() == _pouname.ToUpper())
                {
                    _tblpou = tblpou;
                    break;
                }
            }
            foreach (tblFunction tblfunction in tblSolution.m_tblSolution().m_tblFunctionCollection)
            {
                if (tblfunction.FunctionName.ToUpper() == _pouname.ToUpper())
                {
                    _tblfunction = tblfunction;
                    break;
                }
            }
        }

        private void UDFPinForm_Load(object sender, EventArgs e)
        {
            foreach (tblFunction tblfunction in tblSolution.m_tblSolution().m_tblFunctionCollection)
            {
                if (tblfunction.FunctionGroup == (int)FunctionGroup.BASIC_TYPES)
                {
                    ((DataGridViewComboBoxColumn)dataGridViewInput.Columns[2]).Items.Add(tblfunction.FunctionName.ToUpper());
                    ((DataGridViewComboBoxColumn)dataGridViewOutput.Columns[2]).Items.Add(tblfunction.FunctionName.ToUpper());
                    ((DataGridViewComboBoxColumn)dataGridViewLocal.Columns[2]).Items.Add(tblfunction.FunctionName.ToUpper());
                }
            }
            foreach (tblFormalParameter tblformalparameter in _tblfunction.m_tblFormalParameterCollection)
            {
                varlist.Add(tblformalparameter);
            }
            foreach (tblFormalParameter tblformalparameter in varlist.OrderBy(x => x.oIndex))
            {
                switch((VarClass)tblformalparameter.Class)
                {
                    case VarClass.Input:
                        {
                            int rowId = dataGridViewInput.Rows.Add();
                            dataGridViewInput.Rows[rowId].Cells[0].Value = tblformalparameter.PinName;
                            dataGridViewInput.Rows[rowId].Cells[1].Value = tblformalparameter.Description;
                            dataGridViewInput.Rows[rowId].Cells[2].Value = tblSolution.m_tblSolution().functionbyType[ tblformalparameter.Type].FunctionName.ToUpper();
                            if (tblformalparameter.Reference)
                            {
                                dataGridViewInput.Rows[rowId].Cells[3].Value = "Reference";
                            }
                            else
                            {
                                dataGridViewInput.Rows[rowId].Cells[3].Value = "Input";
                            }
                            dataGridViewInput.Rows[rowId].Cells[4].Value = tblformalparameter.InitializeValue;

                            //DataGridViewRow row = dataGridViewInput.Rows[rowId];
                            
                        }
                        break;
                    case VarClass.InOut:
                        {
                            int rowId = dataGridViewInput.Rows.Add();
                            dataGridViewInput.Rows[rowId].Cells[0].Value = tblformalparameter.PinName;
                            dataGridViewInput.Rows[rowId].Cells[1].Value = tblformalparameter.Description;
                            dataGridViewInput.Rows[rowId].Cells[2].Value = tblSolution.m_tblSolution().functionbyType[tblformalparameter.Type].FunctionName.ToUpper();
                            dataGridViewInput.Rows[rowId].Cells[3].Value = "InOut";
                            dataGridViewInput.Rows[rowId].Cells[4].Value = tblformalparameter.InitializeValue;

                            //DataGridViewRow row = dataGridViewInput.Rows[rowId];

                        }
                        break;
                    case VarClass.Output:
                        {
                            int rowId = dataGridViewOutput.Rows.Add();
                            dataGridViewOutput.Rows[rowId].Cells[0].Value = tblformalparameter.PinName;
                            dataGridViewOutput.Rows[rowId].Cells[1].Value = tblformalparameter.Description;
                            dataGridViewOutput.Rows[rowId].Cells[2].Value = tblSolution.m_tblSolution().functionbyType[tblformalparameter.Type].FunctionName.ToUpper();
                            dataGridViewOutput.Rows[rowId].Cells[3].Value = "Output";
                            dataGridViewOutput.Rows[rowId].Cells[4].Value = tblformalparameter.InitializeValue;

                           // DataGridViewRow row = dataGridViewOutput.Rows[rowId];

                        }
                        break;
                    case VarClass.Local:
                        {
                            int rowId = dataGridViewLocal.Rows.Add();
                            dataGridViewLocal.Rows[rowId].Cells[0].Value = tblformalparameter.PinName;
                            dataGridViewLocal.Rows[rowId].Cells[1].Value = tblformalparameter.Description;
                            dataGridViewLocal.Rows[rowId].Cells[2].Value = tblSolution.m_tblSolution().functionbyType[tblformalparameter.Type].FunctionName.ToUpper();
                            dataGridViewLocal.Rows[rowId].Cells[3].Value = "Local";
                            dataGridViewLocal.Rows[rowId].Cells[4].Value = tblformalparameter.InitializeValue;

                            //DataGridViewRow row = dataGridViewLocal.Rows[rowId];

                        }
                        break;
                    

                }

                
            }
            loaded = true;   
        }

        #region Input
        private void moveInputDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            moveDown(dataGridViewInput);
        }

        private void moveInputUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            moveUp(dataGridViewInput);
        }

        private void deleteInputToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dataGridViewInput.SelectedRows)
            {
                dataGridViewInput.Rows.RemoveAt(item.Index);
            }
            Dirty = true;
        }

        private void addInputToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //int index = dataGridViewInput.Rows.Count;

                int rowId = dataGridViewInput.Rows.Add();
                dataGridViewInput.Rows[rowId].Cells[0].Value = string.Empty;
                dataGridViewInput.Rows[rowId].Cells[1].Value = string.Empty;
                dataGridViewInput.Rows[rowId].Cells[4].Value = string.Empty;
                


                Dirty = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void contextMenuStripInput_Opening(object sender, CancelEventArgs e)
        {

            UpdateInputContexMenu();


        }
        void UpdateInputContexMenu()
        {
            int count = dataGridViewInput.Rows.Count;
            int selectedrow = -1;
            if (dataGridViewInput.SelectedRows.Count > 0)
            {
                selectedrow = dataGridViewInput.SelectedRows[0].Index;
            }

            addInputToolStripMenuItem.Enabled = true;

            if ((count > 0) && (selectedrow >= 0))
            {
                deleteInputToolStripMenuItem.Enabled = true;
            }
            else
            {
                deleteInputToolStripMenuItem.Enabled = false;
            }

            if ((count > 1) && (selectedrow != -1))
            {
                if (selectedrow > 0)
                {
                    moveInputUpToolStripMenuItem.Enabled = true;
                }
                else
                {
                    moveInputUpToolStripMenuItem.Enabled = false;
                }
            }
            else
            {
                moveInputUpToolStripMenuItem.Enabled = false;
            }
            if ((count > 1) && (selectedrow != -1))
            {
                if (selectedrow < (count - 1))
                {
                    moveInputDownToolStripMenuItem.Enabled = true;
                }
                else
                {
                    moveInputDownToolStripMenuItem.Enabled = false;
                }
            }
            else
            {
                moveInputDownToolStripMenuItem.Enabled = false;
            }


        }

        #endregion

        #region Output
        private void moveOutputDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            moveDown(dataGridViewOutput);
        }

        private void moveOutputUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            moveUp(dataGridViewOutput);
        }

        private void deleteOutputToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dataGridViewOutput.SelectedRows)
            {
                dataGridViewOutput.Rows.RemoveAt(item.Index);
            }
            Dirty = true;
        }

        private void addOutputToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //int index = dataGridViewOutput.Rows.Count;

                int rowId = dataGridViewOutput.Rows.Add();
                dataGridViewOutput.Rows[rowId].Cells[0].Value = string.Empty;
                dataGridViewOutput.Rows[rowId].Cells[1].Value = string.Empty;
                dataGridViewOutput.Rows[rowId].Cells[4].Value = string.Empty;
                


                Dirty = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void contextMenuStripOutput_Opening(object sender, CancelEventArgs e)
        {

            UpdateOutputContexMenu();


        }
        void UpdateOutputContexMenu()
        {
            int count = dataGridViewOutput.Rows.Count;
            int selectedrow = -1;
            if (dataGridViewOutput.SelectedRows.Count > 0)
            {
                selectedrow = dataGridViewOutput.SelectedRows[0].Index;
            }
            if (_tblfunction.IsFunction)
            {
                if (count == 0)
                {

                    addOutputToolStripMenuItem.Enabled = true;
                }
                else
                {
                    addOutputToolStripMenuItem.Enabled = false;
                }
                deleteOutputToolStripMenuItem.Enabled = false;
                moveOutputUpToolStripMenuItem.Enabled = false;
                moveOutputDownToolStripMenuItem.Enabled = false;
            }
            else
            {
                addOutputToolStripMenuItem.Enabled = true;

                if ((count > 0) && (selectedrow >= 0))
                {
                    deleteOutputToolStripMenuItem.Enabled = true;
                }
                else
                {
                    deleteOutputToolStripMenuItem.Enabled = false;
                }

                if ((count > 1) && (selectedrow != -1))
                {
                    if (selectedrow > 0)
                    {
                        moveOutputUpToolStripMenuItem.Enabled = true;
                    }
                    else
                    {
                        moveOutputUpToolStripMenuItem.Enabled = false;
                    }
                }
                else
                {
                    moveOutputUpToolStripMenuItem.Enabled = false;
                }
                if (count > 1)
                {
                    if (selectedrow < (count - 1))
                    {
                        moveOutputDownToolStripMenuItem.Enabled = true;
                    }
                    else
                    {
                        moveOutputDownToolStripMenuItem.Enabled = false;
                    }
                }
                else
                {
                    moveOutputDownToolStripMenuItem.Enabled = false;
                }

            }
        }

        #endregion

        #region Local
        private void moveLocalDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //UpdateLocalContexMenu();
        }

        private void moveLocalUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //UpdateLocalContexMenu();
        }

        private void deleteLocalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dataGridViewLocal.SelectedRows)
            {
                dataGridViewLocal.Rows.RemoveAt(item.Index);
            }
            Dirty = true;
        }

        private void addLocalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //int index = dataGridViewLocal.Rows.Count;

                int rowId = dataGridViewLocal.Rows.Add();
                dataGridViewLocal.Rows[rowId].Cells[0].Value = string.Empty;
                dataGridViewLocal.Rows[rowId].Cells[1].Value = string.Empty;
                dataGridViewLocal.Rows[rowId].Cells[4].Value = string.Empty;
                


                Dirty = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void contextMenuStripLocal_Opening(object sender, CancelEventArgs e)
        {

            UpdateLocalContexMenu();


        }
        void UpdateLocalContexMenu()
        {
            int count = dataGridViewLocal.Rows.Count;
            int selectedrow = -1;
            if (dataGridViewLocal.SelectedRows.Count > 0)
            {
                selectedrow = dataGridViewLocal.SelectedRows[0].Index;
            }

            addLocalToolStripMenuItem.Enabled = true;

            if ((count > 0) && (selectedrow >= 0))
            {
                deleteLocalToolStripMenuItem.Enabled = true;
            }
            else
            {
                deleteLocalToolStripMenuItem.Enabled = false;
            }

            


        }

        #endregion

        private void moveDown(DataGridView dg1)
        {
            int selectedrow = -1;
            if (dg1.SelectedRows.Count > 0)
            {
                selectedrow = dg1.SelectedRows[0].Index;
            }
            if (selectedrow < dg1.Rows.Count - 1)
            {
                string str;

                for (int i = 0; i < 5; i++)
                {
                    str = (string)dg1.Rows[selectedrow].Cells[i].Value;
                    dg1.Rows[selectedrow].Cells[i].Value = (string)dg1.Rows[selectedrow + 1].Cells[i].Value;
                    dg1.Rows[selectedrow + 1].Cells[i].Value = str;
                }

                //UpdateInputContexMenu();
            }
            Dirty = true;
        }

        private  void moveUp(DataGridView dg1)
        {
            int selectedrow = -1;
            if (dg1.SelectedRows.Count > 0)
            {
                selectedrow = dg1.SelectedRows[0].Index;
            }
            if (selectedrow > 0)
            {
                string str;
                for (int i = 0; i < 5; i++)
                {
                    str = (string)dg1.Rows[selectedrow].Cells[i].Value;
                    dg1.Rows[selectedrow].Cells[i].Value = (string)dg1.Rows[selectedrow - 1].Cells[i].Value;
                    dg1.Rows[selectedrow - 1].Cells[i].Value = str;
                }

                //UpdateInputContexMenu();
            }
            Dirty = true;
        }

        bool CheckDataisValid()
        {
            if (!GridIsBlank(dataGridViewInput))
            {
                MessageBox.Show("Block needs at least one input Pin");
                return false;
            }
            if (!GridIsBlank(dataGridViewOutput))
            {
                MessageBox.Show("Block needs at least one output Pin");
                return false;
            }

            if (!CheckDataIsBlank(dataGridViewInput))
            {
                MessageBox.Show("Input Pin cannot be blank");
                return false;
            }

            if (!CheckDataIsBlank(dataGridViewOutput))
            {
                MessageBox.Show("Output Pin cannot be blank");
                return false;
            }

            if (!CheckDataIsBlank(dataGridViewLocal,true))
            {
                MessageBox.Show("Local Pin cannot be blank");
                return false;
            }

            if (!CheckSameNameinGrid(dataGridViewInput))
            {
                MessageBox.Show("Input Pins cannot have same name");
                return false;
            }

            if (!CheckSameNameinGrid(dataGridViewOutput))
            {
                MessageBox.Show("Input Pins cannot have same name");
                return false;
            }

            if (!CheckSameNameinGrid(dataGridViewLocal))
            {
                MessageBox.Show("Local Pins cannot have same name");
                return false;
            }

            if (!CompareDataGrids(dataGridViewInput, dataGridViewOutput))
            {
                MessageBox.Show("Input Pin and Output Pin cannot have same name");
                return false;
            }

            if (!CompareDataGrids(dataGridViewInput, dataGridViewLocal))
            {
                MessageBox.Show("Input Pin and Local Pin cannot have same name");
                return false;
            }

            if (!CompareDataGrids(dataGridViewLocal, dataGridViewOutput))
            {
                MessageBox.Show("Output Pin and Local Pin cannot have same name");
                return false;
            }

            return true;
        }

        bool GridIsBlank(DataGridView dg1)
        {
            int count;


            if ((count = dg1.Rows.Count) == 0)
            {
                return false;
            }
            return true;
        }

        bool CheckSameNameinGrid(DataGridView dg1)
        {
            int count;

            if ((count = dg1.Rows.Count) > 1)
            {
                for (int i = 0; i < count - 1; i++)
                {
                    for (int j = i+1; j < count; j++)
                    {
                        if (((string)(dg1.Rows[i].Cells[0].Value)).ToUpper() == ((string)(dg1.Rows[j].Cells[0].Value)).ToUpper())
                        {
                            MessageBox.Show("Names cannot be same");
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        bool CheckDataIsBlank(DataGridView dg1,bool canbenull = false )
        {
            int count;

            if (!canbenull)
            {
                if ((count = dg1.Rows.Count) == 0)
                {
                    return false;
                }

            }
            if ((count = dg1.Rows.Count) > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    if ((string)dg1.Rows[i].Cells[0].Value == "")
                    {
                        
                        return false;
                    }
                }
            }

           
            return true;
        }

        bool CompareDataGrids(DataGridView dg1, DataGridView dg2)
        {
            int count1 = dg1.Rows.Count;
            int count2 = dg2.Rows.Count;

            for (int i = 0; i < count1 ; i++)
            {
                for (int j = 0; j < count2; j++)
                {
                    if (((string)(dg1.Rows[i].Cells[0].Value)).ToUpper() == ((string)(dg2.Rows[j].Cells[0].Value)).ToUpper())
                    {
                        
                        return false;
                    }
                }
            }
            return true;

        }

        void RowExistIntblFormalparamter(string pinname, string pindescription, string pintype, string pinclass, string pininitialvalue, ref int oIndex)
        {
            foreach (tblFormalParameter tblformalparameter in _tblfunction.m_tblFormalParameterCollection)
            {
                if (tblformalparameter.PinName.ToUpper() == pinname.ToUpper())
                {
                    tblformalparameter.Description = pindescription;
                    tblformalparameter.Type = (int)tblSolution.m_tblSolution().functionbyName[pintype.ToUpper()].Type;
                    if (pinclass == "Input")
                    {
                        tblformalparameter.Class = (int)VarClass.Input;
                        tblformalparameter.Reference = false;
                    }
                    if (pinclass == "InOut")
                    {
                        tblformalparameter.Class = (int)VarClass.InOut;
                        tblformalparameter.Reference = false;
                    }
                    if (pinclass == "Reference")
                    {
                        tblformalparameter.Class = (int)VarClass.Input;
                        tblformalparameter.Reference = true;
                    }
                    if (pinclass == "Output")
                    {
                        tblformalparameter.Class = (int)VarClass.Output;
                        tblformalparameter.Reference = false;
                    }
                    if (pinclass == "Local")
                    {
                        tblformalparameter.Class = (int)VarClass.Local;
                        tblformalparameter.Reference = false;
                    }
                    tblformalparameter.InitializeValue = pininitialvalue;
                    tblformalparameter.oIndex = oIndex++;
                    tblformalparameter.Update();

                    return;
                }
            }

            {
                tblFormalParameter tblformalparameter = new tblFormalParameter();
                tblformalparameter.FunctionID = _tblfunction.FunctionID;
                tblformalparameter.PinName = pinname.ToUpper();

                tblformalparameter.Description = pindescription;
                tblformalparameter.Type = (int)tblSolution.m_tblSolution().functionbyName[pintype.ToUpper()].Type;
                if (pinclass == "Input")
                {
                    tblformalparameter.Class = (int)VarClass.Input;
                    tblformalparameter.Reference = false;
                }
                if (pinclass == "InOut")
                {
                    tblformalparameter.Class = (int)VarClass.InOut;
                    tblformalparameter.Reference = false;
                }
                if (pinclass == "Reference")
                {
                    tblformalparameter.Class = (int)VarClass.Input;
                    tblformalparameter.Reference = true;
                }
                if (pinclass == "Output")
                {
                    tblformalparameter.Class = (int)VarClass.Output;
                    tblformalparameter.Reference = false;
                }
                if (pinclass == "Local")
                {
                    tblformalparameter.Class = (int)VarClass.Local;
                    tblformalparameter.Reference = false;
                }
                tblformalparameter.InitializeValue = pininitialvalue;
                tblformalparameter.oIndex = oIndex++;
                tblformalparameter.Insert();
            }
            _tblfunction.m_tblFormalParameterCollection = null;
        }

        void RowExistIntblVariable(string pinname, string pindescription, string pintype, string pinclass, string pininitialvalue, ref int oIndex)
        {
            foreach (tblVariable tblvariable in _tblpou.m_tblVariableCollection)
            {

                if (tblvariable.VarName.ToUpper() == pinname.ToUpper())
                {
                    tblvariable.Description = pindescription;
                    tblvariable.Type = (int)tblSolution.m_tblSolution().functionbyName[pintype.ToUpper()].Type;
                    if (pinclass == "Input")
                    {
                        tblvariable.Class = (int)VarClass.Input;
                    }
                    if (pinclass == "InOut")
                    {
                        tblvariable.Class = (int)VarClass.InOut;
                    }
                    if (pinclass == "Reference")
                    {
                        tblvariable.Class = (int)VarClass.Input;
                    }
                    if (pinclass == "Output")
                    {
                        tblvariable.Class = (int)VarClass.Output;
                    }
                    if (pinclass == "Local")
                    {
                        tblvariable.Class = (int)VarClass.Local;
                    }
                    tblvariable.InitialVal = pininitialvalue;
                    tblvariable.PlantStructureID = tblSolution.m_tblSolution().Dummytblcontroller.PlantStructureID;
                    
                    tblvariable.Update();

                    return;
                }
            }

            {
                tblVariable tblvariable = new tblVariable();
                tblvariable.pouID = _tblpou.pouID;
                tblvariable.VarName = pinname.ToUpper();

                tblvariable.Description = pindescription;
                tblvariable.Type = (int)tblSolution.m_tblSolution().functionbyName[pintype.ToUpper()].Type;
                if (pinclass == "Input")
                {
                    tblvariable.Class = (int)VarClass.Input;
                }
                if (pinclass == "InOut")
                {
                    tblvariable.Class = (int)VarClass.InOut;
                }
                if (pinclass == "Reference")
                {
                    tblvariable.Class = (int)VarClass.Input;
                }
                if (pinclass == "Output")
                {
                    tblvariable.Class = (int)VarClass.Output;
                }
                if (pinclass == "Local")
                {
                    tblvariable.Class = (int)VarClass.Local;
                }
                tblvariable.InitialVal = pininitialvalue;
                tblvariable.PlantStructureID = tblSolution.m_tblSolution().Dummytblcontroller.PlantStructureID;
                tblvariable.Insert();
                _tblpou.VariablesByName.Add(tblvariable.VarName.ToLower(), tblvariable);
                _tblpou.VariablesByName.Remove(tblvariable.VarName);
            }
            _tblpou.m_tblVariableCollection = null;
        }

        void RowExistInSQLDB(string pinname, string pindescription, string pintype, string pinclass, string pininitialvalue, ref int oIndex)
        {
            RowExistIntblFormalparamter(pinname, pindescription, pintype, pinclass, pininitialvalue, ref  oIndex);
            RowExistIntblVariable(pinname, pindescription, pintype, pinclass, pininitialvalue, ref  oIndex);
        }



        bool ExistinGrid(string tblformalparameter_pinname, DataGridView dg1)
        {
            int count = dg1.Rows.Count;
            string pinname;
            for (int i = 0; i < count; i++)
            {
                pinname = (string)dg1.Rows[i].Cells[0].Value;
                if (tblformalparameter_pinname.ToUpper() == pinname.ToUpper())
                {
                    return true;
                }
            }
            return false;
        }
        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (CheckDataisValid())
            {
              //  if (Dirty)
                {
                    int oIndex = 0;
                    int count;
                    string pinname;
                    string pindescription;
                    string pintype;
                    string pinclass;
                    string pininitialvalue;

                    count = dataGridViewInput.Rows.Count;
                    for (int i = 0; i < count; i++)
                    {
                        pinname = (string)dataGridViewInput.Rows[i].Cells[0].Value;
                        pindescription = (string)dataGridViewInput.Rows[i].Cells[1].Value;
                        pintype = Convert.ToString(dataGridViewInput.Rows[i].Cells[2].FormattedValue.ToString());
                        pinclass = Convert.ToString(dataGridViewInput.Rows[i].Cells[3].FormattedValue.ToString());
                        pininitialvalue = (string)dataGridViewInput.Rows[i].Cells[4].Value;
                        RowExistInSQLDB(pinname, pindescription, pintype, pinclass, pininitialvalue, ref  oIndex);
                    }

                    count = dataGridViewOutput.Rows.Count;
                    for (int i = 0; i < count; i++)
                    {
                        pinname = (string)dataGridViewOutput.Rows[i].Cells[0].Value;
                        pindescription = (string)dataGridViewOutput.Rows[i].Cells[1].Value;
                        pintype = Convert.ToString(dataGridViewOutput.Rows[i].Cells[2].FormattedValue.ToString());
                        pinclass = Convert.ToString(dataGridViewOutput.Rows[i].Cells[3].FormattedValue.ToString());
                        pininitialvalue = (string)dataGridViewOutput.Rows[i].Cells[4].Value;
                        RowExistInSQLDB(pinname, pindescription, pintype, pinclass, pininitialvalue, ref  oIndex);
                    }

                    count = dataGridViewLocal.Rows.Count;
                    for (int i = 0; i < count; i++)
                    {
                        pinname = (string)dataGridViewLocal.Rows[i].Cells[0].Value;
                        pindescription = (string)dataGridViewLocal.Rows[i].Cells[1].Value;
                        pintype = Convert.ToString(dataGridViewLocal.Rows[i].Cells[2].FormattedValue.ToString());
                        pinclass = Convert.ToString(dataGridViewLocal.Rows[i].Cells[3].FormattedValue.ToString());
                        pininitialvalue = (string)dataGridViewLocal.Rows[i].Cells[4].Value;
                        RowExistInSQLDB(pinname, pindescription, pintype, pinclass, pininitialvalue, ref  oIndex);
                    }

                    foreach (tblFormalParameter tblformalparameter in _tblfunction.m_tblFormalParameterCollection)
                    {
                        if (!ExistinGrid(tblformalparameter.PinName, dataGridViewInput))
                        {
                            if (!ExistinGrid(tblformalparameter.PinName, dataGridViewOutput))
                            {
                                if (!ExistinGrid(tblformalparameter.PinName, dataGridViewLocal))
                                {
                        
                                    _tblfunction.m_tblFormalParameterCollection.Remove(tblformalparameter);
                                    tblformalparameter.Delete();
                                }
                            }
                        }
                    }


                    foreach (tblVariable tblvariable in _tblpou.m_tblVariableCollection)
                    {
                        if ((tblvariable.Class == (int)VarClass.Input) ||
                            (tblvariable.Class == (int)VarClass.InOut) ||
                            (tblvariable.Class == (int)VarClass.Output) ||
                            (tblvariable.Class == (int)VarClass.Local))
                        {
                            if (!ExistinGrid(tblvariable.VarName, dataGridViewInput))
                            {
                                if (!ExistinGrid(tblvariable.VarName, dataGridViewOutput))
                                {
                                    if (!ExistinGrid(tblvariable.VarName, dataGridViewLocal))
                                    {
                                        _tblpou.m_tblVariableCollection.Remove(tblvariable);
                                        tblvariable.Delete();
                                        _tblpou.VariablesByName.Remove(tblvariable.VarName);
                                    }
                                }
                            }
                        }
                    }
                    //        found = false;
                    //        foreach (tblFormalParameter tblformalparameter in _tblfunction.m_tblFormalParameterCollection)
                    //        {
                    //            if (tblvariable.VarName.ToUpper() == tblformalparameter.PinName.ToUpper())
                    //            {
                    //                tblvariable.Description = tblformalparameter.Description;
                    //                tblvariable.Type = tblformalparameter.Type;
                    //                tblvariable.InitialVal = tblformalparameter.InitializeValue;
                    //                tblvariable.Update();
                    //                found = true;
                    //                break;
                    //            }
                    //        }
                    //        if (!found)
                    //        {
                    //            tblvariable.Delete();
                    //            tblvariable.VarNameID = -1;
                    //            _tblpou.VariablesByName.Remove(tblvariable.VarName);
                    //        }

                    //    }
                    //}

                    //foreach (tblFormalParameter tblformalparameter in _tblfunction.m_tblFormalParameterCollection)
                    //{

                    //    found = false;
                    //    foreach (tblVariable tblvariable in _tblpou.m_tblVariableCollection)
                    //    {
                    //        if (tblvariable.VarName.ToUpper() == tblformalparameter.PinName.ToUpper())
                    //        {
                    //            found = true;
                    //            break;
                    //        }
                    //    }
                    //    if (!found)
                    //    {
                    //        tblVariable _tblvariable = new tblVariable();
                    //        _tblvariable.pouID = _tblpou.pouID;
                    //        _tblvariable.VarName = tblformalparameter.PinName;
                    //        _tblvariable.Description = tblformalparameter.Description;
                    //        _tblvariable.Type = tblformalparameter.Type;
                    //        _tblvariable.Class = tblformalparameter.Class;
                    //        _tblvariable.InitialVal = tblformalparameter.InitializeValue;
                    //        _tblvariable.Insert();
                    //        _tblpou.m_tblVariableCollection.Add(_tblvariable);
                    //        _tblpou.VariablesByName[_tblvariable.VarName] = _tblvariable;

                    //    }
                    //}

                }
                tblSolution.m_tblSolution().Dummytblcontroller.SaveVariable();
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void dataGridViewInput_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (loaded)
            {
                Dirty = true;
            }
        }

        private void dataGridViewOutput_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (loaded)
            {
                Dirty = true;
            }
        }

        private void dataGridViewLocal_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (loaded)
            {
                Dirty = true;
            }
        }
        
    }
}
