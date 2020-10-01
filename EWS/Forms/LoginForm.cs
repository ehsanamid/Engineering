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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            foreach (tblEWSUser tblewsuser in tblSolution.m_tblSolution().m_tblEWSUserCollection)
            {
                if ((textBoxUserName.Text.ToUpper() == tblewsuser.User_Name.ToUpper()) &&
                    (textBoxPassword.Text == tblewsuser.Pass_word))
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    MainForm.Instance().CurrentUser = tblewsuser;
                    Close();
                    return;
                }
            }
            DialogResult ret = MessageBox.Show("UserName or Password is not correct", "Login Error", MessageBoxButtons.RetryCancel);
            if (ret == System.Windows.Forms.DialogResult.Retry)
            {
                textBoxPassword.Text = "";
            }
            else
            {
                DialogResult = System.Windows.Forms.DialogResult.Cancel;
                Close();
            }

        }

        private void textBoxUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonOk.PerformClick();
            }
        }

        

        private void textBoxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonOk.PerformClick();
            }
        }

        

        
    }
}
