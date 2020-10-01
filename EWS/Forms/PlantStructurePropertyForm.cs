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
    public partial class PlantStructurePropertyForm : Form
    {
        public string name
        {
            get
            {
                return textBoxName.Text;
            }
            set
            {
                textBoxName.Text = value;
            }
        }
        public string description
        {
            get
            {
                return textBoxDescription.Text;
            }
            set
            {
                textBoxDescription.Text = value;
            }
        }
        public int type
        {
            get
            {
                foreach (tblPlantStructureProperty tblplantstructureproperty in tblSolution.m_tblSolution().m_tblPlantStructurePropertyCollection)
                {
                    if ((string)comboBoxPropertyType.SelectedItem == tblplantstructureproperty.Name)
                    {
                        return tblplantstructureproperty.Type;
                    }
                }
                return 0;
            }
            set
            {
                int _type = value;
                foreach (tblPlantStructureProperty tblplantstructureproperty in tblSolution.m_tblSolution().m_tblPlantStructurePropertyCollection)
                {
                    if (_type == tblplantstructureproperty.Type)
                    {
                        comboBoxPropertyType.SelectedIndex = comboBoxPropertyType.FindString(tblplantstructureproperty.Name);
                        break;
                    }
                }
            }
        }
        public string filename
        {
            get
            {
                return textBoxFile.Text;
            }
            set
            {
                textBoxFile.Text = value;
            }
        }

        string _argument;
        public string argument
        {
            get
            {
                return _argument;
            }
            set
            {
                _argument = value;
            }
        }
        public PlantStructurePropertyForm()
        {
            InitializeComponent();
            argument = "";
            FillCombo(); 
        }

        private void buttonAddNewObjectType_Click(object sender, EventArgs e)
        {
            PlantStructurePropertyTypeForm plantstructurepropertytypeform = new PlantStructurePropertyTypeForm();
            if (plantstructurepropertytypeform.ShowDialog() == DialogResult.OK)
            {
                FillCombo();
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            name = textBoxName.Text;
            description = textBoxDescription.Text;
            filename = textBoxFile.Text;
            //foreach (tblPlantStructureProperty tblplantstructureproperty in tblSolution.m_tblSolution().m_tblPlantStructurePropertyCollection)
            //{
            //    if ((string)comboBoxPropertyType.SelectedItem == tblplantstructureproperty.Name)
            //    {
            //        type = tblplantstructureproperty.Type;
            //        break;
            //    }
            //}
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
            //FillCombo();
            
        }

        private void FillCombo()
        {
            comboBoxPropertyType.Items.Clear();
            foreach (tblPlantStructureProperty tblplantstructureproperty in tblSolution.m_tblSolution().m_tblPlantStructurePropertyCollection)
            {
                comboBoxPropertyType.Items.Add(tblplantstructureproperty.Name);
            }
            
        }

        


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfiledialog = new OpenFileDialog();
            
            openfiledialog.Title = "Select File";
            //openfiledialog.Filter = "txt file (*.csv)|*.csv|batch file (*.bat)|*.bat";
            //openfiledialog.InitialDirectory = Environment.SpecialFolder.MyPictures.ToString();
            if (openfiledialog.ShowDialog() == DialogResult.OK)
            {
                textBoxFile.Text = openfiledialog.FileName;
                filename = openfiledialog.FileName;
            }
        }
    }
}
