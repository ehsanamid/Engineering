using DCS;
using DCS.DCSTables;
using DCS.Draw.FBD;
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
    public partial class FBDProperty : Form
    {
        public DrawFunctionBlock drawfunctionblock;
        //tblVariable tblvariable;
        //tblFunction tblfunction;
        Dictionary<string, int> dictionary = new Dictionary<string, int>();
        List<List<String>> matrixTXT = new List<List<String>>(); //Creates new nested List
        List<List<String>> matrixVAL = new List<List<String>>(); //Creates new nested List
        
        int combocount = 0;
        public FBDProperty()
        {
            InitializeComponent();
            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].Name = "Name";
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].Name = "Description";
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].Name = "InitializeValue";
            dataGridView1.Columns[3].Name = "Type";
            dataGridView1.Columns[3].ReadOnly = true;
            dataGridView1.Columns[4].Name = "Visible";
            //DataGridViewCheckBoxColumn dgvChb = new DataGridViewCheckBoxColumn();
            //dgvChb.HeaderText = "Visible";
            //dgvChb.Name = "chbPass";
            //dgvChb.FlatStyle = FlatStyle.Standard;
            //dgvChb.ThreeState = false;
            //dataGridView1.Columns.Add(dgvChb);

        }

        private bool AddEnumItem(string enumtxt, ref string str1, ref string str2)
        {
            string[] separators = { ";" };
            string[] words = enumtxt.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            str1 = words[0];
            str2 = words[1];
            return true;
        }

        private bool ValueEnum(string _pinname,string enumtxt)
        {
            List<string> StringListTXT = new List<string>();
            List<string> StringListVAL = new List<string>();
            string str1 = "";
            string str2 = "";
            string[] separators = { "(", ")", "/" };
            string[] words = enumtxt.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            dictionary.Add(_pinname, combocount++);
            for (int i = 0; i < words.Length; i++)
            {
                AddEnumItem(words[i], ref str1, ref str2);
                StringListVAL.Add(str1);
                StringListTXT.Add(str2);

            }
            matrixVAL.Add(StringListVAL);
            matrixTXT.Add(StringListTXT);
            return true;
        }
        private void FBDProperty_Load(object sender, EventArgs e)
        {
            try
            {
                DataGridViewCell NameCell;
                DataGridViewCell DesCell;
                //DataGridViewComboBoxCell ValueCell= null;
                DataGridViewCell ValueCelltext = null;
                DataGridViewComboBoxCell ValueCellCombo = null;
                DataGridViewCell TypeCell = null;
                DataGridViewCell VisibleCell;
                DataGridViewRow FormalParameterRow;
                int rowlookup = 0;
                
                for (int i = 0; i < drawfunctionblock.tblfunction.m_tblFormalParameterCollection.Count; i++)
                {
                    if ((drawfunctionblock.tblfunction.m_tblFormalParameterCollection[i].Class == (int)VarClass.Input) ||
                        (drawfunctionblock.tblfunction.m_tblFormalParameterCollection[i].Class == (int)VarClass.InOut) ||
                        (drawfunctionblock.tblfunction.m_tblFormalParameterCollection[i].Class == (int)VarClass.Internal))
                    {
                        FormalParameterRow = new DataGridViewRow();

                        NameCell = new DataGridViewTextBoxCell();
                        NameCell.Value = drawfunctionblock.tblfunction.m_tblFormalParameterCollection[i].PinName;
                        FormalParameterRow.Cells.Add(NameCell);
                        NameCell.ReadOnly = true;

                        DesCell = new DataGridViewTextBoxCell();
                        DesCell.Value = drawfunctionblock.tblfunction.m_tblFormalParameterCollection[i].Description;
                        FormalParameterRow.Cells.Add(DesCell);
                        DesCell.ReadOnly = true;


                        string str = drawfunctionblock.tblfunction.m_tblFormalParameterCollection[i].ENUM_TEXT;
                        if (str == null)
                        {
                            str = "";
                            drawfunctionblock.tblfunction.m_tblFormalParameterCollection[i].ENUM_TEXT = "";
                        }

                        if (str.StartsWith("ENUM"))
                        {
                            string pinname = drawfunctionblock.tblfunction.m_tblFormalParameterCollection[i].PinName;
                            ValueEnum(pinname, drawfunctionblock.tblfunction.m_tblFormalParameterCollection[i].ENUM_TEXT.Substring(4));

                            ValueCellCombo = new DataGridViewComboBoxCell();
                            rowlookup = dictionary[pinname];
                            ValueCellCombo.DataSource = matrixTXT[rowlookup];
                            ValueCellCombo.Value = matrixTXT[rowlookup][0];
                            for (int j = 0; j < matrixTXT[rowlookup].Count; j++)
                            {
                                if (matrixVAL[rowlookup][j].ToUpper() == drawfunctionblock.tblfunction.m_tblFormalParameterCollection[i].InitializeValue.ToUpper())
                                {
                                    ValueCellCombo.Value = matrixTXT[rowlookup][j];
                                }
                            }

                            FormalParameterRow.Cells.Add(ValueCellCombo);

                        }
                        else
                        {
                            if (str.StartsWith("RANGE"))
                            {
                                ValueCelltext = new DataGridViewTextBoxCell();
                                if (drawfunctionblock.tblfunction.m_tblFormalParameterCollection[i].InitializeValue != null)
                                {
                                    ValueCelltext.Value = drawfunctionblock.tblfunction.m_tblFormalParameterCollection[i].InitializeValue;
                                }
                                else
                                {
                                    ValueCelltext.Value = "";
                                }
                                FormalParameterRow.Cells.Add(ValueCelltext);
                            }
                            else
                            {
                                ValueCelltext = new DataGridViewTextBoxCell();
                                if (drawfunctionblock.tblfunction.m_tblFormalParameterCollection[i].InitializeValue != null)
                                {
                                    ValueCelltext.Value = drawfunctionblock.tblfunction.m_tblFormalParameterCollection[i].InitializeValue;
                                }
                                else
                                {
                                    ValueCelltext.Value = "";
                                }
                                FormalParameterRow.Cells.Add(ValueCelltext);
                            }
                        }
                        
                        TypeCell = new DataGridViewTextBoxCell();
                        int typeval = drawfunctionblock.tblfunction.m_tblFormalParameterCollection[i].Type;
                        TypeCell.Value = ((VarType)typeval).ToString();
                        FormalParameterRow.Cells.Add(TypeCell);
                        TypeCell.ReadOnly = true;


                        VisibleCell = new DataGridViewCheckBoxCell();
                        VisibleCell.Value = drawfunctionblock.tblfunction.m_tblFormalParameterCollection[i].Visible;
                        FormalParameterRow.Cells.Add(VisibleCell);
                        for (int j = 0; j < drawfunctionblock.LeftPinsLookup.Count; j++)
                        {
                            if (drawfunctionblock.LeftPinsLookup[j] == i)
                            {
                                if (drawfunctionblock.LeftPins[j].Connected)
                                {
                                    VisibleCell.ReadOnly = true;
                                    VisibleCell.Style.BackColor = Color.Gray;
                                    break;
                                }
                            }
                        }
                        if (drawfunctionblock.tblfunction.m_tblFormalParameterCollection[i].PropertyType)
                        {
                            VisibleCell.ReadOnly = true;
                            VisibleCell.Style.BackColor = Color.LightGray;
                        }


                        dataGridView1.Rows.Add(FormalParameterRow);
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                Close();
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            try
            {
                
                int rowlookup = 0;
                int rowno = 0;
                for (int i = 0; i < drawfunctionblock.tblfunction.m_tblFormalParameterCollection.Count; i++)
                {
                    if ((drawfunctionblock.tblfunction.m_tblFormalParameterCollection[i].Class == (int)VarClass.Input) ||
                        (drawfunctionblock.tblfunction.m_tblFormalParameterCollection[i].Class == (int)VarClass.InOut) ||
                        (drawfunctionblock.tblfunction.m_tblFormalParameterCollection[i].Class == (int)VarClass.Internal))
                    {
                        string str = drawfunctionblock.tblfunction.m_tblFormalParameterCollection[i].ENUM_TEXT;
                        if (str.StartsWith("ENUM"))
                        {
                            string pinname = drawfunctionblock.tblfunction.m_tblFormalParameterCollection[i].PinName;
                            string enumtxt = dataGridView1.Rows[rowno].Cells[2].Value.ToString();

                            rowlookup = dictionary[pinname];

                            for (int j = 0; j < matrixTXT[rowlookup].Count; j++)
                            {
                                if (matrixTXT[rowlookup][j].ToUpper() == enumtxt.ToUpper())
                                {
                                    drawfunctionblock.tblfunction.m_tblFormalParameterCollection[i].InitializeValue = matrixVAL[rowlookup][j];
                                    break;
                                }
                            }
                        }
                        else
                        {
                            drawfunctionblock.tblfunction.m_tblFormalParameterCollection[i].InitializeValue = dataGridView1.Rows[rowno].Cells[2].Value.ToString();
                        }

                        drawfunctionblock.tblfunction.m_tblFormalParameterCollection[i].UVisible = (bool)((DataGridViewCheckBoxCell)dataGridView1.Rows[rowno].Cells[4]).Value;

                     rowno++;   
                    }
                    
                }

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                Close();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }
    }

    
}
