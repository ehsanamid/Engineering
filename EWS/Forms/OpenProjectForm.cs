using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DCS.DCSTables;
using System.Data.SQLite;

namespace DCS.Forms
{
    
    public partial class OpenProjectForm : Form
    {
        
        public OpenProjectForm()
        {
            InitializeComponent();

            buttonOK.Enabled = false;
            
        }

        private void FolderBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog browser = new FolderBrowserDialog();

            //if (browser.ShowDialog() == DialogResult.OK)
            //{
            //    textbox.Text = browser.SelectedPath;
            //    if (m_NewOROpen == New_Open_Project_Form.Open_Project_Form)
            //    {
            //        string str = textboxServerName.Text;
            //        string str1;
            //        int len = 0;
            //        int i;
            //        str1 = "";
            //        string[] words = str.Split(new char[] { '\x005c', ':' }, StringSplitOptions.RemoveEmptyEntries);

            //        len = words.Length;

            //        for (i = 0; i < len - 1; i++)
            //        {
            //            str1 += words[i];
            //            if (i != len - 2)
            //            {
            //                str1 += '\x005c';
            //            }
            //        }
            //        textboxServerName.Text = str;
            //        textboxProjectName.Text = words[i];
            //    }
            //}
        }
        // Sqlite
        

        private void buttonOpenDialog_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Sqlite files (*.Sqlite)|*.Sqlite|All files (*.Sqlite)|*.Sqlite";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string ProjectPath = openFileDialog1.FileName;
                textBoxProjectName.Text = openFileDialog1.FileName;
                ProjectPath = ProjectPath.Replace(openFileDialog1.SafeFileName, "");
                Common.ProjectPath = ProjectPath;
                Common.DatabaseName = openFileDialog1.SafeFileName.Replace(".Sqlite", "");
                labelName.Text = Common.DatabaseName;
                labelPath.Text = Common.ProjectPath;
                buttonOK.Enabled = true;
                
            }
            
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            SQLiteConnectionStringBuilder connectionbuilder = new SQLiteConnectionStringBuilder();
            connectionbuilder.Password = "12345678";
            //connectionbuilder.Provider = "Microsoft.Jet.OLEDB.4.0";
            connectionbuilder.DataSource = Common.DatabaseFullName;
            Common.ConnectionString = connectionbuilder.ConnectionString;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        

        
    }
}