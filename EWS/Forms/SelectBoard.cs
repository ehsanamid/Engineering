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


namespace DCS.Forms
{
    public partial class SelectBoard : Form
    {
        
        public string newboardname;
        public string newboardtype;
        public SelectBoard()
        {
           
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SelectBoard_Load(object sender, EventArgs e)
        {
            this.textBox1.Text = newboardname;
            for (int i = 0; i < (int)tblSolution.m_tblSolution().m_tblBoardtypesCollection.Count; i++)
            {
                comboBoxBoardType.Items.Add(tblSolution.m_tblSolution().m_tblBoardtypesCollection[i].BoardTypeName);
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            newboardtype = comboBoxBoardType.Text;
            Close();
        }

        private void buttonCANCEL_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }
    }
}
