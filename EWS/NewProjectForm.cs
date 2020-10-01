using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DocToolkit.Forms
{
    public enum New_Open_Project_Form
    {
        New_Project_Form,
        Open_Project_Form
    };
    public partial class NewProjectForm : Form
    {
        private New_Open_Project_Form m_NewOROpen = New_Open_Project_Form.New_Project_Form;
        public NewProjectForm(New_Open_Project_Form _neworopen)
        {
            InitializeComponent();
            
            m_NewOROpen = _neworopen;
            if (m_NewOROpen == New_Open_Project_Form.New_Project_Form)
            {
                this.Text = "New Project";
                textboxProjectName.Enabled = true;
                textboxProjectPath.Enabled = true;
                textboxConfiguratorName.Enabled = true;
                textboxDescription.Enabled = true;
            }
            else
            {
                this.Text = "Open Project";
                textboxProjectName.Enabled = false;
                textboxProjectPath.Enabled = false;
                textboxConfiguratorName.Enabled = false;
                textboxDescription.Enabled = false;
            }
        }

        private void FolderBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog browser = new FolderBrowserDialog();

            if (browser.ShowDialog() == DialogResult.OK)
            {
                textboxProjectPath.Text = browser.SelectedPath;
                if (m_NewOROpen == New_Open_Project_Form.Open_Project_Form)
                {
                    string str = textboxProjectPath.Text;
                    string str1;
                    int len = 0;
                    int i;
                    str1 = "";
                    string[] words = str.Split(new char[] { '\x005c', ':' }, StringSplitOptions.RemoveEmptyEntries);

                    len = words.Length;

                    for (i = 0; i < len - 1; i++)
                    {
                        str1 += words[i];
                        if (i != len - 2)
                        {
                            str1 += '\x005c';
                        }
                    }
                    textboxProjectPath.Text = str;
                    textboxProjectName.Text = words[i];
                }
            }
        }

        private void OK_Click(object sender, EventArgs e)
        {
            
            if (m_NewOROpen == New_Open_Project_Form.Open_Project_Form)
            {
                if (textboxProjectName.Text != "" && textboxProjectPath.Text != "" )
                {
                    string dir = textboxProjectPath.Text + "\\" + textboxProjectName.Text;
                    if (Directory.Exists(dir))
                    {
                        MessageBox.Show("This project already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        returnStatus = true;
                        Close();
                    }
                }
                else
                {
                    MessageBox.Show("Information is not completed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (textboxProjectName.Text != "" && textboxProjectPath.Text != "" && textboxConfiguratorName.Text != "")
                {
                    string dir = textboxProjectPath.Text + "\\" + textboxProjectName.Text;
                    if (Directory.Exists(dir))
                    {
                        MessageBox.Show("This project already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        returnStatus = true;
                        Close();
                    }
                }
                else
                {
                    MessageBox.Show("Information is not completed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            returnStatus = false;
            Close();
        }
    }
}