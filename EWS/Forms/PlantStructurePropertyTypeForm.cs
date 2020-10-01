using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DCS.DCSTables;

namespace DCS.Forms
{
    public partial class PlantStructurePropertyTypeForm : Form
    {
        public PlantStructurePropertyTypeForm()
        {
            InitializeComponent();
        }

        private void buttonAddNewObjectType_Click(object sender, EventArgs e)
        {

        }

        private void RowExistInSQLDB(string typename, string description, string extension)
        {
            int _type = 1;
            foreach (tblPlantStructureProperty tblplantstructureproperty in tblSolution.m_tblSolution().m_tblPlantStructurePropertyCollection)
            {
                if (tblplantstructureproperty.Type > _type)
                {
                    _type = tblplantstructureproperty.Type;
                }
                if (typename == tblplantstructureproperty.Name)
                {
                    tblplantstructureproperty.Description = description;
                    tblplantstructureproperty.Extension = extension;
                    
                    tblplantstructureproperty.Update();
                    return;
                }
            }
            _type++;
            tblPlantStructureProperty _tblplantstructureproperty = new tblPlantStructureProperty();
            _tblplantstructureproperty.Name = typename;
            _tblplantstructureproperty.Description = description;
            _tblplantstructureproperty.Extension = extension;
            _tblplantstructureproperty.Type = _type;
            _tblplantstructureproperty.SolutionID = tblSolution.m_tblSolution().SolutionID;
            _tblplantstructureproperty.Insert();
        }
        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (CheckDataIsBlank(dataGridView1))
            {
                if (CheckSameNameinGrid(dataGridView1))
                {
                    int count = dataGridView1.Rows.Count;
                    for (int i = 0; i < count; i++)
                    {
                        RowExistInSQLDB((string)dataGridView1.Rows[i].Cells[0].Value, (string)dataGridView1.Rows[i].Cells[1].Value, (string)dataGridView1.Rows[i].Cells[2].Value);
                    }
                    bool found;
                    foreach (tblPlantStructureProperty tblplantstructureproperty in tblSolution.m_tblSolution().m_tblPlantStructurePropertyCollection)
                    {
                        found = false;
                        for (int i = 0; i < count; i++)
                        {
                            if ((string)dataGridView1.Rows[i].Cells[0].Value == tblplantstructureproperty.Name)
                            {
                                found = true;
                                break;
                            }
                        }
                        if (!found)
                        {
                            tblplantstructureproperty.Delete();
                        }
                    }
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    Close();
                }
            }
                
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void PlantStructureObject_Load(object sender, EventArgs e)
        {
            foreach (tblPlantStructureProperty tblplantstructureproperty in tblSolution.m_tblSolution().m_tblPlantStructurePropertyCollection)
            {
                int rowId = dataGridView1.Rows.Add();
                dataGridView1.Rows[rowId].Cells[0].Value = tblplantstructureproperty.Name;
                dataGridView1.Rows[rowId].Cells[1].Value = tblplantstructureproperty.Description;
                dataGridView1.Rows[rowId].Cells[2].Value = tblplantstructureproperty.Extension;

            }
            
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            int count = dataGridView1.Rows.Count;
            if (count > 0)
            {

                ToolStripMenuItemdelete.Enabled = true;
            }
            else
            {
                ToolStripMenuItemdelete.Enabled = false;
            }
        }

        private void ToolStripMenuItemadd_Click(object sender, EventArgs e)
        {
            try
            {
                int rowId = dataGridView1.Rows.Add();
                dataGridView1.Rows[rowId].Cells[0].Value = string.Empty;
                dataGridView1.Rows[rowId].Cells[1].Value = string.Empty;
                dataGridView1.Rows[rowId].Cells[2].Value = string.Empty;
                //Dirty = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ToolStripMenuItemdelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.RemoveAt(item.Index);
            }
        }


        bool CheckSameNameinGrid(DataGridView dg1)
        {
            int count;

            if ((count = dg1.Rows.Count) > 1)
            {
                for (int i = 0; i < count - 1; i++)
                {
                    for (int j = i + 1; j < count; j++)
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

        bool CheckDataIsBlank(DataGridView dg1)
        {
            int count;

            
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

        

        
    }
}
