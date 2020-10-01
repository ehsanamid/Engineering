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
    public partial class PlantStructureFolderForm : Form
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
       
        public PlantStructureFolderForm()
        {
            InitializeComponent();
        }

       

        private void buttonOk_Click(object sender, EventArgs e)
        {
            //name = textBoxName.Text;
            //description = textBoxDescription.Text;
            
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
            
            
        }
    }
}
