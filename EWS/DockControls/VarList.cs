using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WinFormsUI.Docking;
using System.IO;
using DCS.Forms;
using System.Data.SQLite;
using DCS.Tools;
//using DocToolkit.Project_Objects;
using DCS.DCSTables;
using DCS;
using WeifenLuo.WinFormsUI.Docking;


namespace DockSample
{



    public partial class VarExplorer : DockContent
    {
        
        //private GridOffice2007Filter filter;
        
        //bool colFilterd
        
            

        public MainForm frm;
        //private string domainname;
        //private string controllername;
        //private string pouname;
        //private long domainid;
        //private int controllerid;
        //private int pouid;
        //tblDomain tbldomain;
        tblController tblcontroller;
        tblPou tblpou;
        //private tblDomainCollection m_tblDomainCollection;
        
        

        public VarExplorer(MainForm _frm)
        {
            //frm = _frm;
            //m_tblDomainCollection = tblSolution.m_tblSolution().m_tblDomainCollection;
            //InitializeComponent();

            
            //m_tblDomainCollection.tblDomainChanged += new tblDomainChangedEventHandler(updateDomainComboEventhandler);
            
        }
        
        public void SelectVariable1()
        {
            //int i = 0;
            //int j;

            if (tblpou != null)
            {

                if (Common.Conn == null)
                {
                    Common.Conn = new SQLiteConnection(Common.ConnectionString);
                    Common.Conn.Open();
                }
                SQLiteDataReader myReader = null;
                SQLiteCommand myCommand = new SQLiteCommand();

                try
                {


                    //DataGridViewRow row;
                    myReader = null;
                    myCommand.CommandText = "SELECT [tblVariable].[VarName], [tblVariable].[Description], [tblVarType].[TypeName], [tblVariable].[Class], [tblVariable].[InitialVal], [tblVariable].[Option] " +
                                            "FROM [dbo].[tblVariable] INNER JOIN [dbo].[tblVarType] ON [tblVariable].[Type] = [tblVarType].[Value]";

                    myCommand.Connection = Common.Conn;// _SqlConnectionConnection;
                    myReader = myCommand.ExecuteReader();
                    using (myReader)
                    {
                        DataTable table = new DataTable();
                        table.Load(myReader);
                    }

                }
                catch (SQLiteException ae)
                {
                    MessageBox.Show(ae.Message.ToString());
                }
            }
            else
            {
            }
        }
        
//        
        private void dataGridViewVar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

            //toolStripComboBoxDomain.Items.Clear();
            //for (int i = 0; i < tblSolution.m_tblSolution().m_tblDomainCollection.Count; i++)
            //{
            //    toolStripComboBoxDomain.Items.Add(tblSolution.m_tblSolution().m_tblDomainCollection[i]);
            //}
            //toolStripComboBoxDomain.ComboBox.DisplayMember = "DomainName";
            //toolStripComboBoxDomain.ComboBox.ValueMember = "DomainID";
            //if (tbldomain != null)
            //{
            //    tbldomain.m_tblControllerCollection.tblControllerChanged -= new tblControllerChangedEventHandler(updateControllerComboventhandler);
            //}
            //if (toolStripComboBoxDomain.Items.Count > 0)
            //{
            //    if (toolStripComboBoxDomain.SelectedIndex == -1)
            //    {
            //        toolStripComboBoxDomain.SelectedIndex = 0;
                    
            //    }
            //    tbldomain = tblSolution.m_tblSolution().m_tblDomainCollection[toolStripComboBoxDomain.SelectedIndex];
            //    tbldomain.m_tblControllerCollection.tblControllerChanged += new tblControllerChangedEventHandler(updateControllerComboventhandler);
            //    updateControllerCombo();
            //}
            
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
            //toolStripComboBoxController.Items.Clear();
            //for (int i = 0; i < tbldomain.m_tblControllerCollection.Count; i++)
            //{
            //    toolStripComboBoxController.Items.Add(tbldomain.m_tblControllerCollection[i]);
            //}
            //toolStripComboBoxController.ComboBox.DisplayMember = "ControllerName";
            //if (tblcontroller != null)
            //{
            //    tblcontroller.m_tblPouCollection.tblPouChanged -= new tblPouChangedEventHandler(updatePOUComboventhandler);

            //}
            //if (toolStripComboBoxController.Items.Count > 0)
            //{
            //    if (toolStripComboBoxController.SelectedIndex == -1)
            //    {
            //        toolStripComboBoxController.SelectedIndex = 0;
                    
            //    }
            //    tblcontroller = tbldomain.m_tblControllerCollection[toolStripComboBoxController.SelectedIndex];
            //    tblcontroller.m_tblPouCollection.tblPouChanged += new tblPouChangedEventHandler(updatePOUComboventhandler);
            //    updatePOUCombo();
               
            //}
            
        }
        private void updatePOUCombo()
        {
            toolStripComboBoxProgram.Items.Clear();
            for (int i = 0; i < tblcontroller.m_tblPouCollection.Count; i++)
            {
                {
                    toolStripComboBoxProgram.Items.Add(tblcontroller.m_tblPouCollection[i]);
                }
            }
            toolStripComboBoxProgram.ComboBox.DisplayMember = "pouName";
            if (toolStripComboBoxProgram.Items.Count > 0)
            {
                if (toolStripComboBoxProgram.SelectedIndex == -1)
                {
                    toolStripComboBoxProgram.SelectedIndex = 0;
                }
                tblpou = tblcontroller.m_tblPouCollection[toolStripComboBoxProgram.SelectedIndex];
                SelectVariable1();
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
            //bool _global;
           
            //if(tblpou!= null)
            //{
                
            //    if (tblpou.pouName == "GLOBAL")
            //    {
            //        _global = true;
            //    }
            //    else
            //    {
            //        _global = false;
            //    }

            //}
        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripComboBoxDomain_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (tbldomain != null)
            //{
            //    tbldomain.m_tblControllerCollection.tblControllerChanged -= new tblControllerChangedEventHandler(updateControllerComboventhandler);
            //}
            //tbldomain = (tblDomain)toolStripComboBoxDomain.SelectedItem;
            //domainname = tbldomain.DomainName;
            //domainid = tbldomain.DomainID;
            //tbldomain.m_tblControllerCollection.tblControllerChanged += new tblControllerChangedEventHandler(updateControllerComboventhandler);
            //if (tbldomain.m_tblControllerCollection.Count > 0)
            //{
            //    updateControllerCombo();
            //    toolStripComboBoxController.Enabled = true;
            //}
            //else
            //{
            //    toolStripComboBoxController.Items.Clear();
            //    toolStripComboBoxProgram.Items.Clear();
            //    toolStripComboBoxController.Enabled = false;
            //    toolStripComboBoxProgram.Enabled = false;
            //    tblcontroller = null;
            //    tblpou = null;
            //    SelectVariable1();
            //}
        }

        private void toolStripComboBoxController_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tblcontroller != null)
            {
                tblcontroller.m_tblPouCollection.tblPouChanged -= new tblPouChangedEventHandler(updatePOUComboventhandler);
            }
            tblcontroller = (tblController)toolStripComboBoxController.SelectedItem;
            tblcontroller.m_tblPouCollection.tblPouChanged += new tblPouChangedEventHandler(updatePOUComboventhandler);

            updatePOUCombo();
            toolStripComboBoxProgram.Enabled = true;
        }

        private void toolStripComboBoxProgram_SelectedIndexChanged(object sender, EventArgs e)
        {
            tblpou = (tblPou)toolStripComboBoxProgram.SelectedItem;
            
        }

        
        public void EnblaeCombos()
        {
            //if (tblSolution.m_tblSolution().m_tblDomainCollection.Count > 0)
            //{
            //    toolStripComboBoxController.Enabled = true;
            //}
            //else
            //{
            //    toolStripComboBoxController.Enabled = false;
            //}
            


        }

        private void dataGridViewVar_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            


        }

        private void updateHeader(int colIndex, bool filterd)
        {
           
        }

        
    }

   

    //public class VarColumCollection : System.Collections.CollectionBase
    //{
    //    [Description("Get elememt from the collection.")]
    //    public stringColumnItems this[int index]
    //    {
    //        get
    //        {
    //            return ((stringColumnItems)List[index]);
    //        }
    //        set
    //        {
    //            List[index] = value;
    //        }
    //    }

    //    [Description("Adds a new tblController to the collection.")]
    //    public int Add(stringColumnItems item)
    //    {
    //        int newindex = List.Add(item);
    //        return newindex;
    //    }

    //    [Description("Removes a tblController from the collection.")]
    //    public void Remove(stringColumnItems item)
    //    {
    //        List.Remove(item);
    //    }

    //    [Description("Inserts an tblController into the collection at the specified index.")]
    //    public void Insert(int index, object item)
    //    {
    //        List.Insert(index, item);
    //    }

    //    [Description("Returns the index value of the tblController class in the collection.")]
    //    public int IndexOf(object item)
    //    {
    //        return List.IndexOf(item);
    //    }

    //    [Description("Returns true if the tblController class is present in the collection.")]
    //    public bool Contains(object item)
    //    {
    //        return List.Contains(item);
    //    }

    //    [Description("Returns tblBoardtypes which it name is input argument of method.")]
    //    public stringColumnItems Find(string name)
    //    {
    //        foreach (stringColumnItems o in List)
    //        {
    //            if (o.Name == name)
    //                return o;
    //        }
    //        return null;
    //    }
    //}
}