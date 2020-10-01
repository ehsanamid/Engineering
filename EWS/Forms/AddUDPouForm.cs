using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using DocToolkit.Project_Objects;
using DCS.Tools;

using DCS.DCSTables;
//using System.CodeDom.Compiler;


namespace DCS.Forms
{
    public partial class AddUDPouForm : Form
    {
        
       

        //string _pouname = "";
        public string pouname
        {
            get
            {
                return textBoxName.Text.ToUpper();
            }
        }

        public string poudescription
        {
            get
            {
                return textBoxDescription.Text.ToUpper();
            }
        }

        PouLanguageType _poulanguagetype;
        public PouLanguageType pouLanguageType
        {
            get
            {
                return _poulanguagetype;
            }
        }
        public AddUDPouForm()
        {
            InitializeComponent();

            comboBoxProgrammingLanguage.SelectedIndex = 0;
        }
        
        

        private void buttonOK_Click(object sender, EventArgs e)
        {
            

            if (Common.CheckNameIsValid(pouname))
            {
                if (tblSolution.m_tblSolution().functionbyName.ContainsKey(pouname))
                {
                    MessageBox.Show("Function Name Exists");
                }
                else
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Invalid Name");
            }

            

        }

       

        private void VariableForm_Load(object sender, EventArgs e)
        {
            
            
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {

            if (textBoxName.Text.Trim() == "")
            {
                buttonOk.Enabled = false;
            }
            else
            {
                buttonOk.Enabled = true;
            }
        }

        private void comboBoxClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((string)comboBoxProgrammingLanguage.SelectedItem == "FBD")
            {
                _poulanguagetype = PouLanguageType.FBD;
            }
            if ((string)comboBoxProgrammingLanguage.SelectedItem == "ST")
            {
                _poulanguagetype = PouLanguageType.ST;
            }
        }



        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }
    }
}
