using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using System.IO;
using DocToolkit.Forms;
using System.Data.SqlClient;
using EWSTools;
using DocToolkit.Project_Objects;

namespace DockSample
{



    public partial class VarExplorer : DockContent
    {
        public MainForm frm;
        private string domainname;
        //private string controllername;
        //private string pouname;
        private int domainid;
        //private int controllerid;
        //private int pouid;
        tblDomain tbldomain;
        tblController tblcontroller;
        tblPou tblpou;
        private tblDomainCollection m_tblDomainCollection;
        private m_tblControllerCollection _tblControllerCollection;
        private tblPOUCollection _tblPOUCollection;
        //public VarExplorer(MainForm _frm, tblDomainCollection _tbldomaincollection)
        public VarExplorer(MainForm _frm)
        {
            frm = _frm;
            m_tblDomainCollection = frm._tblSolution.m_tblDomainCollection;
            InitializeComponent();
            m_tblDomainCollection.DomainChanged += new DomainChangedEventHandler(updateDomainComboEventhandler);
            
        }
        public void SelectVariable()
        {
            int i = 0;
            int j;
            if (tblpou != null)
            {

                SqlConnection _SqlConnectionConnection = new SqlConnection(ConnectionString);

                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand();
                //SqlConnectionGlobalConnection = new SqlConnection();
                if (_SqlConnectionConnection.State == System.Data.ConnectionState.Open)
                    _SqlConnectionConnection.Close();
                _SqlConnectionConnection.ConnectionString = ConnectionString;
                _SqlConnectionConnection.Open();

                try
                {

                    dataGridViewVar.Rows.Clear();

                    DataGridViewRow row;
                    //dataGridViewVar.AutoGenerateColumns = true;
                    //dataGridViewVar.DataSource = null;
                    myReader = null;
                    //myCommand.CommandText = "SELECT [VarName], [pouID], [Description], [InitialVal], [Type], [Class], [Option], [oIndex] FROM [dbo].[tblVariable] WHERE [pouID]=" + tblpou.pouID + " order by oIndex;";
                    myCommand.CommandText = "SELECT [VarName], [Description], [InitialVal], [Type], [Class], [Option] FROM [dbo].[tblVariable] WHERE [pouID]=" + tblpou.pouID + " order by oIndex;";
                    myCommand.Connection = _SqlConnectionConnection;
                    myReader = myCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        tblVariable tblvariable = new tblVariable();
                        row = (DataGridViewRow)dataGridViewVar.Rows[i++].Clone();
                        row.Cells[0].Value = (string)myReader["VarName"];
                        j = (int)myReader["Type"];
                        row.Cells[1].Value = (VarType)j;
                        row.Cells[2].Value = (VarClass)myReader["Class"];
                        row.Cells[3].Value = (string)myReader["InitialVal"];
                        row.Cells[4].Value = (string)myReader["Description"];
                        row.Cells[5].Value = (VarOption)myReader["Option"];
                        dataGridViewVar.Rows.Add(row);

                    }
                    //dataGridViewVar.DataSource = myCommand.ExecuteReader();
                    //myReader.Close();
                    //myReader.Dispose();
                    //myCommand.Dispose();
                    // _SqlConnectionConnection.Close();

                }
                catch (SqlException ae)
                {
                    MessageBox.Show(ae.Message.ToString());
                }
            }
            else
            {
                dataGridViewVar.Rows.Clear();
            }
        }
        private void dataGridViewVar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        [DisplayName("ConnectionString")]
        [Category("Uplink")]
        public string ConnectionString
        {
            get
            {
                try
                {
                    return frm.ConnectionString;
                }
                catch (System.Exception err)
                {
                    throw new Exception("Error getting connect string", err);
                }
            }

        }
        private void VarExplorer_Load(object sender, EventArgs e)
        {

            updateDomainCombo();
            toolStripComboBoxController.Enabled = false;
            toolStripComboBoxProgram.Enabled = false;
            
            EnblaeCombos();
            
           
        }
        private void updateDomainCombo()
        {

            toolStripComboBoxDomain.Items.Clear();
            for (int i = 0; i < frm._tblSolution.m_tblDomainCollection.Count; i++)
            {
                toolStripComboBoxDomain.Items.Add(frm._tblSolution.m_tblDomainCollection[i]);
            }
            toolStripComboBoxDomain.ComboBox.DisplayMember = "DomainName";
            toolStripComboBoxDomain.ComboBox.ValueMember = "DomainID";
            if (tbldomain != null)
            {
                tbldomain.m_tblControllerCollection.ControllerChanged -= new ControllerChangedEventHandler(updateControllerComboventhandler);
            }
            if (toolStripComboBoxDomain.Items.Count > 0)
            {
                if (toolStripComboBoxDomain.SelectedIndex == -1)
                {
                    toolStripComboBoxDomain.SelectedIndex = 0;
                    
                }
                tbldomain = frm._tblSolution.m_tblDomainCollection[toolStripComboBoxDomain.SelectedIndex];
                tbldomain.m_tblControllerCollection.ControllerChanged += new ControllerChangedEventHandler(updateControllerComboventhandler);
                updateControllerCombo();
            }
            
        }
        private void updateDomainComboEventhandler(object sender, EventArgs e)
        {
            updateDomainCombo();
        }
        private void updateControllerComboventhandler(object sender, EventArgs e)
        {
            updateControllerCombo();
        }
        private void updatePOUComboventhandler(object sender, EventArgs e)
        {
            updatePOUCombo();
        }
        private void updateControllerCombo()
        {
            toolStripComboBoxController.Items.Clear();
            for (int i = 0; i < tbldomain.m_tblControllerCollection.Count; i++)
            {
                toolStripComboBoxController.Items.Add(tbldomain.m_tblControllerCollection[i]);
            }
            toolStripComboBoxController.ComboBox.DisplayMember = "ControllerName";
            if (tblcontroller != null)
            {
                tblcontroller.m_tblPOUCollection.POUChanged -= new POUChangedEventHandler(updatePOUComboventhandler);

            }
            if (toolStripComboBoxController.Items.Count > 0)
            {
                if (toolStripComboBoxController.SelectedIndex == -1)
                {
                    toolStripComboBoxController.SelectedIndex = 0;
                    
                }
                tblcontroller = tbldomain.m_tblControllerCollection[toolStripComboBoxController.SelectedIndex];
                tblcontroller.m_tblPOUCollection.POUChanged += new POUChangedEventHandler(updatePOUComboventhandler);
                updatePOUCombo();
               
            }
            
        }
        private void updatePOUCombo()
        {
            toolStripComboBoxProgram.Items.Clear();
            for (int i = 0; i < tblcontroller.m_tblPOUCollection.Count; i++)
            {
                //if (tblcontroller.m_tblPOUCollection[i].pouName != "GLOBAL")
                {
                    toolStripComboBoxProgram.Items.Add(tblcontroller.m_tblPOUCollection[i]);
                }
            }
            toolStripComboBoxProgram.ComboBox.DisplayMember = "pouName";
            if (toolStripComboBoxProgram.Items.Count > 0)
            {
                if (toolStripComboBoxProgram.SelectedIndex == -1)
                {
                    toolStripComboBoxProgram.SelectedIndex = 0;
                }
                tblpou = tblcontroller.m_tblPOUCollection[toolStripComboBoxProgram.SelectedIndex];
                SelectVariable();
            }
            if (tblpou == null)
            {
                toolStripButtonAdd.Enabled = false;
                toolStripButtonDelete.Enabled = false;
                toolStripButtonEdit.Enabled = false;
            }
            else
            {
                toolStripButtonAdd.Enabled = true;
                toolStripButtonDelete.Enabled = true;
                toolStripButtonEdit.Enabled = true;
            }

        }
        private void toolStripComboBoxController_Click(object sender, EventArgs e)
        {

        }

        private void toolStripComboBoxDomain_Click(object sender, EventArgs e)
        {

        }

        private void toolStripComboBoxProgram_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            bool _global;
           
            if(tblpou!= null)
            {
                
                if (tblpou.pouName == "GLOBAL")
                {
                    _global = true;
                }
                else
                {
                    _global = false;
                }
                AddVariableForm varform = new AddVariableForm(frm, _global, tblpou.pouID); 
                DialogResult dialogResult;
                dialogResult = varform.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    SelectVariable();
                    
                }

            }
        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripComboBoxDomain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbldomain != null)
            {
                tbldomain.m_tblControllerCollection.ControllerChanged -= new ControllerChangedEventHandler(updateControllerComboventhandler);
            }
            tbldomain = (tblDomain)toolStripComboBoxDomain.SelectedItem;
            domainname = tbldomain.DomainName;
            domainid = tbldomain.DomainID;
            tbldomain.m_tblControllerCollection.ControllerChanged += new ControllerChangedEventHandler(updateControllerComboventhandler);
            if (tbldomain.m_tblControllerCollection.Count > 0)
            {
                updateControllerCombo();
                toolStripComboBoxController.Enabled = true;
            }
            else
            {
                toolStripComboBoxController.Items.Clear();
                toolStripComboBoxProgram.Items.Clear();
                toolStripComboBoxController.Enabled = false;
                toolStripComboBoxProgram.Enabled = false;
                tblcontroller = null;
                tblpou = null;
                SelectVariable();
            }
        }

        private void toolStripComboBoxController_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tblcontroller != null)
            {
                tblcontroller.m_tblPOUCollection.POUChanged -= new POUChangedEventHandler(updatePOUComboventhandler);
            }
            tblcontroller = (tblController)toolStripComboBoxController.SelectedItem;
            tblcontroller.m_tblPOUCollection.POUChanged += new POUChangedEventHandler(updatePOUComboventhandler);

            updatePOUCombo();
            toolStripComboBoxProgram.Enabled = true;
        }

        private void toolStripComboBoxProgram_SelectedIndexChanged(object sender, EventArgs e)
        {
            tblpou = (tblPou)toolStripComboBoxProgram.SelectedItem;
            
        }

        
        public void EnblaeCombos()
        {
            if (frm._tblSolution.m_tblDomainCollection.Count > 0)
            {
                toolStripComboBoxController.Enabled = true;
            }
            else
            {
                toolStripComboBoxController.Enabled = false;
            }
            


        }

        
    }
}