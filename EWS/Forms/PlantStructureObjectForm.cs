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
    public partial class PlantStructureObjectForm : Form
    {
        public string name;
        public string description;
        public int type;
        //public bool isfolder = false;
        //public string title;
        public PlantStructureObjectForm()
        {
            InitializeComponent();
        }

        private void buttonAddNewObjectType_Click(object sender, EventArgs e)
        {
            PlantStructureObjectTypeForm plantstructureobjecttypeform = new PlantStructureObjectTypeForm();
            if (plantstructureobjecttypeform.ShowDialog() == DialogResult.OK)
            {
                FillCombo();
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            name = textBoxName.Text;
            description = textBoxDescription.Text;
            foreach (tblPlantStructureObject tblplantstructureobject in tblSolution.m_tblSolution().m_tblPlantStructureObjectCollection)
            {
                if((string)comboBoxObjectType.SelectedItem == tblplantstructureobject.Name)
                {
                    type = tblplantstructureobject.Type;
                    break;
                }
            }
            if (Common.CheckNameIsValid(name))
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void PlantStructureObject_Load(object sender, EventArgs e)
        {
            FillCombo(); 
        }

        private void FillCombo()
        {
            comboBoxObjectType.Items.Clear();
            foreach (tblPlantStructureObject tblplantstructureobject in tblSolution.m_tblSolution().m_tblPlantStructureObjectCollection)
            {
                comboBoxObjectType.Items.Add(tblplantstructureobject.Name);
            }
        }

        
    }
}
