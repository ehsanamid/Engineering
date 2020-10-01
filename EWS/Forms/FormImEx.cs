using DCS.DCSTables;
using DCS.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DCS.Forms
{
    public partial class FormImEx : Form
    {
        MainForm ParentMainForm;
        string filename;
        string ext = "";
        public bool ImporExportSelected
        {
            get
            {
                return radioButtonAdd.Checked;
            }

        }
        public FormImEx(MainForm _parent)
        {
            ParentMainForm = _parent;
            InitializeComponent();
            radioButtonAdd.Checked = true;
        }

        private void buttonSelectFilename_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select File";
            ofd.Filter = "txt file (*.csv)|*.csv|batch file (*.bat)|*.bat";
            ofd.InitialDirectory = Environment.SpecialFolder.MyPictures.ToString();
            //int al = drawArea.TheLayers.ActiveLayerIndex;


            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filename = ofd.FileName;
                textBoxEXfimename.Text = filename;
                ext = Path.GetExtension(ofd.FileName);
            }
            ofd.Dispose();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            
            if (radioButtonAdd.Checked)
            {
                if (ext.ToLower() == ".csv")
                {
                    buttonImportCSV();
                }
                if (ext.ToLower() == ".bat")
                {
                    buttonImportBATCH();
                }

            }
            else
            {

            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            ParentMainForm.InitializeLeftTree();
            Close();
        }

        private void buttonImportBATCH()
        {
            if (!File.Exists(filename))
            {
                ParentMainForm.WriteToOutputWindows("File " + filename + " does not exist");
                return;
            }
            string str;
            int count = 0;
            using (StreamReader reader = new StreamReader(filename))
            {
                while ((str = reader.ReadLine()) != null)
                {
                    str = str.ToLower();
                    string[] _strs = str.Split(new Char[] { ',','(',')'});
                    count = _strs.Count();
                    if ((count >= 2) && (_strs[0] == "addcontrollers")  )
                    {
                        ImportExport importexport = new ImportExport(ParentMainForm);
                        importexport.AddControllers(_strs[1]);
                        continue;
                    }
                    if ((count >= 3) && (_strs[0] == "addpou") )
                    {
                        ImportExport importexport = new ImportExport(ParentMainForm);
                        importexport.AddPOU(_strs[1], _strs[2]);
                        continue;
                    }
                    if ((count >= 4) && (_strs[0] == "addvariable") )
                    {
                        ImportExport importexport = new ImportExport(ParentMainForm);
                        importexport.AddVariable(_strs[1], _strs[2], _strs[3]);
                        continue;
                    }
                    if ((count >= 4) && (_strs[0] == "addbool") )
                    {
                        ImportExport importexport = new ImportExport(ParentMainForm);
                        importexport.AddBOOL(_strs[1], _strs[2], _strs[3]);
                        continue;
                    }
                    if ((count >= 4) && (_strs[0] == "addreal") )
                    {
                        ImportExport importexport = new ImportExport(ParentMainForm);
                        importexport.AddREAL(_strs[1], _strs[2], _strs[3]);
                        continue;
                    }
                    if ((count >= 2) && (_strs[0] == "addformalparameter"))
                    {
                        ImportExport importexport = new ImportExport(ParentMainForm);
                        importexport.AddFormalParameter(_strs[1]);
                        continue;
                    }
                }
                reader.Close();
            }

        }

        private void buttonImportCSV()
        {
            ImportExport importexport = new ImportExport(ParentMainForm);
            string str = (string)comboBoxseletedTable.SelectedItem;
            string str1 = "";
            string str2 = "";

            switch (str)
            {
                case "Controller":
                    importexport.AddControllers(filename);
                    break;
                case "POU":
                    str1 = (string)comboBoxSelect1.SelectedItem;
                    importexport.AddPOU(filename, str1.ToLower());
                    break;
                case "Board":
                    break;
                case "Channel":

                    break;
                case "Variable":
                    str1 = (string)comboBoxSelect1.SelectedItem;
                    str2 = (string)comboBoxSelect2.SelectedItem;
                    importexport.AddVariable(filename, str1.ToLower(), str2.ToLower());
                    break;
                case "BOOL":
                    str1 = (string)comboBoxSelect1.SelectedItem;
                    str2 = (string)comboBoxSelect2.SelectedItem;
                    importexport.AddBOOL(filename, str1.ToLower(), str2.ToLower());
                    break;
                case "REAL":
                    str1 = (string)comboBoxSelect1.SelectedItem;
                    str2 = (string)comboBoxSelect2.SelectedItem;
                    importexport.AddREAL(filename, str1.ToLower(), str2.ToLower());
                    break;
                case "HMI":

                    break;
                case "Alarm":
                    break;
                case "FormalParameter":
                    importexport.AddFormalParameter(filename);
                    break;

            }


            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void comboBoxseletedTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = (string)comboBoxseletedTable.SelectedItem;
            switch (str)
            {
                case "Controller":
                    comboBoxSelect1.Items.Clear();
                    comboBoxSelect2.Items.Clear();
                    comboBoxSelect1.Visible = false;
                    comboBoxSelect2.Visible = false;
                    label2.Visible = false;
                    label3.Visible = false;
                    break;
                case "POU":
                    comboBoxSelect1.Items.Clear();
                    comboBoxSelect2.Items.Clear();
                    comboBoxSelect1.Visible = true;
                    comboBoxSelect2.Visible = false;
                    label2.Visible = true;
                    label2.Text = "Controller Name";
                    label3.Visible = false;
                    foreach (tblController tblcontroller in tblSolution.m_tblSolution().m_tblControllerCollection)
                    {
                        comboBoxSelect1.Items.Add(tblcontroller.ControllerName);
                    }
                    comboBoxSelect1.SelectedIndex = 0;
                    break;
                case "Board":
                    comboBoxSelect1.Items.Clear();
                    comboBoxSelect2.Items.Clear();
                    comboBoxSelect1.Visible = true;
                    comboBoxSelect2.Visible = false;
                    label2.Visible = true;
                    label2.Text = "Controller Name";
                    label3.Visible = false;
                    foreach (tblController tblcontroller in tblSolution.m_tblSolution().m_tblControllerCollection)
                    {
                        comboBoxSelect1.Items.Add(tblcontroller.ControllerName);
                    }
                    comboBoxSelect1.SelectedIndex = 0;
                    break;
                case "Channel":
                    comboBoxSelect1.Items.Clear();
                    comboBoxSelect2.Items.Clear();
                    comboBoxSelect1.Visible = true;
                    comboBoxSelect2.Visible = true;
                    label2.Visible = true;
                    label2.Text = "Controller Name";
                    label3.Visible = true;
                    label3.Text = "Board Name";
                    foreach (tblController tblcontroller in tblSolution.m_tblSolution().m_tblControllerCollection)
                    {
                        comboBoxSelect1.Items.Add(tblcontroller.ControllerName);
                    }
                    comboBoxSelect1.SelectedIndex = 0;
                    break;
                case "Variable":
                    comboBoxSelect1.Items.Clear();
                    comboBoxSelect2.Items.Clear();
                    comboBoxSelect1.Visible = true;
                    comboBoxSelect2.Visible = true;
                    label2.Visible = true;
                    label2.Text = "Controller Name";
                    label3.Visible = true;
                    label3.Text = "POU Name";
                    foreach (tblController tblcontroller in tblSolution.m_tblSolution().m_tblControllerCollection)
                    {
                        comboBoxSelect1.Items.Add(tblcontroller.ControllerName);
                    }
                    comboBoxSelect1.SelectedIndex = 0;
                    break;
                case "BOOL":
                    comboBoxSelect1.Items.Clear();
                    comboBoxSelect2.Items.Clear();
                    comboBoxSelect1.Visible = true;
                    comboBoxSelect2.Visible = true;
                    label2.Visible = true;
                    label2.Text = "Controller Name";
                    label3.Visible = true;
                    label3.Text = "POU Name";
                    foreach (tblController tblcontroller in tblSolution.m_tblSolution().m_tblControllerCollection)
                    {
                        comboBoxSelect1.Items.Add(tblcontroller.ControllerName);
                    }
                    comboBoxSelect1.SelectedIndex = 0;
                    break;
                case "REAL":
                    comboBoxSelect1.Items.Clear();
                    comboBoxSelect2.Items.Clear();
                    comboBoxSelect1.Visible = true;
                    comboBoxSelect2.Visible = true;
                    label2.Visible = true;
                    label2.Text = "Controller Name";
                    label3.Visible = true;
                    label3.Text = "POU Name";
                    foreach (tblController tblcontroller in tblSolution.m_tblSolution().m_tblControllerCollection)
                    {
                        comboBoxSelect1.Items.Add(tblcontroller.ControllerName);
                    }
                    comboBoxSelect1.SelectedIndex = 0;
                    break;
                case "HMI":
                    comboBoxSelect1.Items.Clear();
                    comboBoxSelect2.Items.Clear();
                    comboBoxSelect1.Visible = false;
                    comboBoxSelect2.Visible = false;
                    label2.Visible = false;
                    label3.Visible = false;
                    break;
                case "Alarm":
                    break;
            }


        }


        private void FormImEx_Load(object sender, EventArgs e)
        {

        }

        private void comboBoxSelect1_SelectedValueChanged(object sender, EventArgs e)
        {
            string str = (string)comboBoxseletedTable.SelectedItem;
            string str1 = (string)comboBoxSelect1.SelectedItem;
            comboBoxSelect2.Items.Clear();
            switch (str)
            {

                case "Channel":
                    {
                        tblController tblcontroller = tblSolution.m_tblSolution().GetControllerFromName(str1);
                        foreach (tblBoard tblboard in tblcontroller.m_tblBoardCollection)
                        {
                            comboBoxSelect2.Items.Add(tblboard.BoardNo);
                        }
                        comboBoxSelect2.SelectedIndex = 0;
                    }
                    break;
                case "Variable":
                    {
                        tblController tblcontroller = tblSolution.m_tblSolution().GetControllerFromName(str1);
                        foreach (tblPou tblpou in tblcontroller.m_tblPouCollection)
                        {
                            comboBoxSelect2.Items.Add(tblpou.pouName);
                        }
                        comboBoxSelect2.SelectedIndex = 0;
                        break;
                    }
                case "BOOL":
                    {
                        tblController tblcontroller = tblSolution.m_tblSolution().GetControllerFromName(str1);
                        foreach (tblPou tblpou in tblcontroller.m_tblPouCollection)
                        {
                            comboBoxSelect2.Items.Add(tblpou.pouName);
                        }
                        comboBoxSelect2.SelectedIndex = 0;
                        break;
                    }
                case "REAL":
                    {
                        tblController tblcontroller = tblSolution.m_tblSolution().GetControllerFromName(str1);
                        foreach (tblPou tblpou in tblcontroller.m_tblPouCollection)
                        {
                            comboBoxSelect2.Items.Add(tblpou.pouName);
                        }
                        comboBoxSelect2.SelectedIndex = 0;
                        break;
                    }
                case "HMI":
                    break;
                case "Alarm":
                    break;
            }
        }


    }
}
