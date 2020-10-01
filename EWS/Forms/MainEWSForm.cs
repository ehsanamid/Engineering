
using DCS.DCSTables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Timers;
using System.Windows.Forms;

using Microsoft.Win32;
using Utility.ModifyRegistry;
using DCS.Tools;
using DCS.Compile;
using System.Threading;
using ENG.Network;
using DCS.Forms;
using DCS.TabPages;
using DCS.Draw;
using DockSample;
using WeifenLuo.WinFormsUI.Docking;
using Lextm.SharpSnmpLib;
using DCS.LeftControls;
using System.Xml;
using DCS.Project_Objects;
using System.Xml.Serialization;


namespace DCS.Forms
{
    //public class tst
    //{
    //    public static MainForm parent;

    //    public static void ppp(string str)
    //    {
    //        parent.WriteToOutputWindows(str);
    //    }
    //}
    public partial class MainForm : Form
    {
        public tblEWSUser CurrentUser;
        public List<long> lcuList = new List<long>();
        private static MainForm aForm = null;
        public static MainForm Instance()
        {
            if (aForm == null)
            {
                aForm = new MainForm();
            }
            return aForm;
        }


        Thread BackgroubdDatabaseLoaderThread;
        private readonly ToolStripRenderer _toolStripProfessionalRenderer = new ToolStripProfessionalRenderer();
        private readonly ToolStripRenderer _vs2012ToolStripRenderer = new VS2012ToolStripRenderer();
        private readonly ToolStripRenderer _vs2013ToolStripRenderer = new Vs2013ToolStripRenderer();
        
        //bool ProjectLoaded = false;
        //tst ttt;
        public Networking networking;
        //ControlExtenders.DockExtender dockExtender;
        public List<DrawArea> DrawAreaList = new List<DrawArea>();
        //private bool _controlKey = false;

        private static System.Windows.Forms.Timer aTimer;

        Compiler compiler;

        PropertyWindow m_propertywindow;
        ToolboxWindow m_toolboxwindow;
        ErrorWindow m_errorwindow;
        OutputWindow m_outputwindow;
        LayerWindow m_layerwindow;
        LogicExplorer m_pouexplorer;
        SystemExplorer m_systemexplorer;
        DisplayExplorer m_displayexplorer;
        ReportExplorer m_reportexplorer;
        StructureExplorer m_structureexplorer;

        public TabPlantStructurePageControl tabplantstructurepagecontrol
        {
            get
            {
                return m_structureexplorer.tabplantstructurepagecontrol;
            }
            set
            {
                m_structureexplorer.tabplantstructurepagecontrol = value;
            }
        }

        public MainForm()
        {
            InitializeComponent();
            //Common.Static_mainform = this;
            bool aa = Common.AutoLoad;
            //InitFrame();


            //DisplayObjectParameters list1 = new DisplayObjectParameters();
            //DisplayObjectParameter para = new DisplayObjectParameter();
            //para.Name = "A1";
            //para.Type = "BOOL";
            //para.Reference = "True";
            //para.Description = "A1";
            //para.Assignment = "FCS00_01GLOBALBOOL008";
            //list1.list.Add(para);

            //para = new DisplayObjectParameter();
            //para.Name = "A2";
            //para.Type = "BOOL";
            //para.Reference = "True";
            //para.Description = "A1";
            //para.Assignment = "FCS00_01GLOBALBOOL007";
            //list1.list.Add(para);

            //SerializeDeserialize<DisplayObjectParameters> serializeParameters;
            //serializeParameters = new SerializeDeserialize<DisplayObjectParameters>();

            //string serializedEmployee = serializeParameters.SerializeData(list1);


            //DisplayObjectParameters list2 = serializeParameters.DeserializeData(serializedEmployee);

            

            ReadRegistrySetting();

           
            vS2012ToolStripExtender1.DefaultRenderer = _toolStripProfessionalRenderer;
            vS2012ToolStripExtender1.VS2012Renderer = _vs2012ToolStripRenderer;
            vS2012ToolStripExtender1.VS2013Renderer = _vs2013ToolStripRenderer;

            //this.topBar.BackColor = this.bottomBar.BackColor = Color.FromArgb(0xFF, 41, 57, 85);

           // SetSchema(this.menuItemSchemaVS2013Blue, null);

            aTimer = new System.Windows.Forms.Timer();
            aTimer.Interval = 500;
            // Hook up the Elapsed event for the timer. 
            aTimer.Tick += new EventHandler(BlinkingTimer);
            aTimer.Start();
        }

        public System.Windows.Forms.ContextMenuStrip FBDPagectxMenu
        {
            get
            {
                return contextMenuStripFBD;
            }
        }

        public LayerWindow layerwindow
        {
            get
            {
                return m_layerwindow;
            }
        }

        public FilteredPropertyGrid m_propertyGrid
        {
            get
            {
                return m_propertywindow.propertyGridComponemt;
            }
        }

        public ListView m_toolBox
        {
            get
            {
                return m_toolboxwindow.m_toolBox;
            }
        }

        public void InitializeLeftTree()
        {
             m_pouexplorer.updateChangeEventhandler();
             m_systemexplorer.updateChangeEventhandler();
             m_displayexplorer.updateChangeEventhandler();
        }
        void item_MouseUp(object sender, MouseEventArgs e)
        {
            //ToolStripItem item = sender as ToolStripItem;
            //Floaty floaty = item.Tag as Floaty;
            //floaty.Show();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void newprojectToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openprojectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenProject();
        }
        private void OpenProject()
        {

            bool result = false;


            if (!Common.AutoLoad)
            {
                OpenProjectForm frmnewproject = new OpenProjectForm();
                DialogResult dialogResult;
                dialogResult = frmnewproject.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            else
            {
                result = true;
            }
            if (result)
            {
                try
                {
                    LoginForm loginform = new LoginForm();
                    if (loginform.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        if (tblSolution.m_tblSolution().Load())
                        {

                            //StartNetwork();
                            LoadProjectObjects();

                            ProjectLoaded = true;
                            this.Cursor = Cursors.Default;
                            //UDFPinForm udfpinform = new UDFPinForm(true);
                            //if (DialogResult.OK == udfpinform.ShowDialog())
                            //{

                            //}

                        }
                    }
                    else
                    {
                        this.Close();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        public bool CheckDocIsOpen(TABPAGETYPE _tabpagetype,long _id)
        {
            foreach (Form form in MdiChildren)
            {
                if (form is TabPageControl)
                {
                    if ((((TabPageControl)form).TabPageType == _tabpagetype) && (((TabPageControl)form).ID == _id))
                    {
                        form.Activate();
                        return true;
                    }
                }
            }
            return false;
        }

        public void activateDoc(TABPAGETYPE _tabpagetype, long _id)
        {
            foreach (Form form in MdiChildren)
            {
                if (form is TabPageControl)
                {
                    if ((((TabPageControl)form).TabPageType == _tabpagetype) && (((TabPageControl)form).ID == _id))
                    {
                        form.Activate();
                        //this.ActiveMdiChild = form;
                    }
                }
            }
  
        }

        public void ShowTabPage(TabPageControl tabpagecontrol)
        {
            tabpagecontrol.Show(dockPanel);
        }

        
        private void CreateProjectDirectories(string ProjectPath)
        {
            Directory.CreateDirectory(ProjectPath);
            Directory.CreateDirectory(ProjectPath + "\\" + "Displays");
            Directory.CreateDirectory(ProjectPath + "\\" + "Blocks");
            Directory.CreateDirectory(ProjectPath + "\\" + "Bitmaps");
            Directory.CreateDirectory(ProjectPath + "\\" + "Logics");
            Directory.CreateDirectory(ProjectPath + "\\" + "Reports");

        }
        private void LoadBackgroundDatabsseReader()
        {
            this.BackgroubdDatabaseLoaderThread = new Thread(new ThreadStart(BackgroundDatabsseReader));
            this.BackgroubdDatabaseLoaderThread.Start();
        }
        private void BackgroundDatabsseReader()
        {
            object tempvar1 = tblSolution.m_tblSolution().functionbyType;
            object var = tblSolution.m_tblSolution().Variables;
            //WriteToOutputWindows("all variables are loaded"); 
            BackgroubdDatabaseLoaderThread.Abort();
        }
        private void LoadProjectObjects()
        {
            
            m_propertywindow = new PropertyWindow();
            m_toolboxwindow = new ToolboxWindow();
            m_outputwindow = new OutputWindow();
            m_errorwindow = new ErrorWindow();
            m_layerwindow = new LayerWindow();
            m_pouexplorer = new LogicExplorer();
            m_systemexplorer = new SystemExplorer();
            m_displayexplorer = new DisplayExplorer();
            m_reportexplorer = new ReportExplorer();
            m_structureexplorer = new StructureExplorer();


            m_outputwindow.Show(dockPanel, DockState.DockBottom);
            m_layerwindow.Show(m_outputwindow.Pane, m_outputwindow);
            m_errorwindow.Show(m_layerwindow.Pane, m_layerwindow);
            
            m_propertywindow.RightToLeftLayout = RightToLeftLayout;
            m_propertywindow.Show(dockPanel, DockState.DockRight);
            m_toolboxwindow.Show(m_propertywindow.Pane, m_propertywindow);

            bool firstexplorer = true;

            DockPane _pane = null;
            object beforeContent = null;
            if (CurrentUser.LogicExplorer != (int)EXPLORER_ACCESS.NoAccess)
            {
                m_pouexplorer.Show(dockPanel, DockState.DockLeft);
                _pane = m_pouexplorer.Pane;
                beforeContent = m_pouexplorer;
                firstexplorer = false;
            }
            if (CurrentUser.SystemExplorer != (int)EXPLORER_ACCESS.NoAccess)
            {
                if (!firstexplorer)
                {
                    m_systemexplorer.Show(_pane, (IDockContent)beforeContent);
                }
                else
                {
                    m_systemexplorer.Show(dockPanel, DockState.DockLeft);
                    _pane = m_systemexplorer.Pane;
                    beforeContent = m_systemexplorer;
                    firstexplorer = false;
                }
            }
            if (CurrentUser.DisplayExplorer != (int)EXPLORER_ACCESS.NoAccess)
            {
                if (!firstexplorer)
                {
                    m_displayexplorer.Show(_pane, (IDockContent)beforeContent);
                }
                else
                {
                    m_displayexplorer.Show(dockPanel, DockState.DockLeft);
                    _pane = m_displayexplorer.Pane;
                    beforeContent = m_displayexplorer;
                    firstexplorer = false;
                }
            }
            if (CurrentUser.ReportExplorer != (int)EXPLORER_ACCESS.NoAccess)
            {
                if (!firstexplorer)
                {
                    m_reportexplorer.Show(_pane, (IDockContent)beforeContent);
                }
                else
                {
                    m_reportexplorer.Show(dockPanel, DockState.DockLeft);
                    _pane = m_reportexplorer.Pane;
                    beforeContent = m_reportexplorer;
                    firstexplorer = false;
                }
            }
            if (CurrentUser.PlantStructureExplorer != (int)EXPLORER_ACCESS.NoAccess)
            {
                if (!firstexplorer)
                {
                    m_structureexplorer.Show(_pane, (IDockContent)beforeContent);
                }
                else
                {
                    m_structureexplorer.Show(dockPanel, DockState.DockLeft);
                    _pane = m_structureexplorer.Pane;
                    beforeContent = m_structureexplorer;
                    firstexplorer = false;
                }
            }
            //m_displayexplorer.Show(m_systemexplorer.Pane, m_systemexplorer);
            //m_reportexplorer.Show(m_displayexplorer.Pane, m_displayexplorer);
            //m_structureexplorer.Show(m_reportexplorer.Pane, m_reportexplorer);

            LoadBackgroundDatabsseReader(); 

        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void importDisplayToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void importSymbolsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

       

       
        

        private void StartNetwork()
        {
            networking = new Networking();

            Thread newThread = new Thread(new ThreadStart(networking.ReadData));
            newThread.Start();
            newThread = new Thread(new ThreadStart(networking.CheckWorkstations));
            newThread.Start();
        }

        private void ShowDisplayToolbox()
        {
            if (ProjectLoaded)
            {
                m_toolBox.Columns.Add("hhh", m_toolboxwindow.Size.Width - 20, HorizontalAlignment.Left);
               // m_toolBox.Columns.Add("hhh");
                m_toolBox.FullRowSelect = true;
                m_toolBox.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;

                // if (dockPanel.ActiveContent != null)
                {


                    m_toolBox.Items.Clear();
                    m_toolBox.View = View.Details;
                    m_toolBox.LabelEdit = false;
                    m_toolBox.AllowColumnReorder = false;
                    m_toolBox.CheckBoxes = false;
                    
                    m_toolBox.Items.Add(new ListViewItem("Pointer", (int)STATIC_OBJ_TYPE.ID_Pointer));
                    m_toolBox.Items.Add(new ListViewItem("Line", (int)STATIC_OBJ_TYPE.ID_LINE));
                    m_toolBox.Items.Add(new ListViewItem("Rectangle", (int)STATIC_OBJ_TYPE.ID_RECT));
                    m_toolBox.Items.Add(new ListViewItem("Curve", (int)STATIC_OBJ_TYPE.ID_CURVE));
                    m_toolBox.Items.Add(new ListViewItem("Ellipse", (int)STATIC_OBJ_TYPE.ID_ELLIPS));
                    m_toolBox.Items.Add(new ListViewItem("Image", (int)STATIC_OBJ_TYPE.ID_BITMAP));
                    m_toolBox.Items.Add(new ListViewItem("Polyline", (int)STATIC_OBJ_TYPE.ID_POLYLINE));
                    m_toolBox.Items.Add(new ListViewItem("Polygon", (int)STATIC_OBJ_TYPE.ID_POLYGON));
                    m_toolBox.Items.Add(new ListViewItem("Arc", (int)STATIC_OBJ_TYPE.ID_ARC));
                    m_toolBox.Items.Add(new ListViewItem("Triangle", (int)STATIC_OBJ_TYPE.ID_Triangle));
                    //m_toolBox.Items.Add(new ListViewItem("Arrow", (int)STATIC_OBJ_TYPE.ID_ARC));
                    m_toolBox.Items.Add(new ListViewItem("Pie", (int)STATIC_OBJ_TYPE.ID_Pie));
                    m_toolBox.Items.Add(new ListViewItem("Text", (int)STATIC_OBJ_TYPE.ID_TEXT));
                    m_toolBox.Items.Add(new ListViewItem("Radibotton", (int)STATIC_OBJ_TYPE.ID_Radibotton));
                    m_toolBox.Items.Add(new ListViewItem("Combobox", (int)STATIC_OBJ_TYPE.ID_Combobox));
                    m_toolBox.Items.Add(new ListViewItem("Bargraph", (int)STATIC_OBJ_TYPE.ID_BARGRAPH));
                    m_toolBox.Items.Add(new ListViewItem("Trend", (int)STATIC_OBJ_TYPE.ID_Trend));
                    m_toolBox.Items.Add(new ListViewItem("Guage", (int)STATIC_OBJ_TYPE.ID_Guage));
                    m_toolBox.Items.Add(new ListViewItem("Block", (int)STATIC_OBJ_TYPE.ID_Block));
                    m_toolBox.Items.Add(new ListViewItem("Digitaltext", (int)STATIC_OBJ_TYPE.ID_DIGTEXT));
                    m_toolBox.Items.Add(new ListViewItem("Analogtext", (int)STATIC_OBJ_TYPE.ID_ANATEXT));
                    m_toolBox.Items.Add(new ListViewItem("Button", (int)STATIC_OBJ_TYPE.ID_BUTTON));
                    m_toolBox.Items.Add(new ListViewItem("Editbox", (int)STATIC_OBJ_TYPE.ID_Editbox));
                    m_toolBox.Items.Add(new ListViewItem("Checkbox", (int)STATIC_OBJ_TYPE.ID_Checkbox));
                }
            }
        }
        private void ShowFBDToolbox()
        {
            if (ProjectLoaded)
            {
                m_toolBox.Columns.Add("hhh", m_toolboxwindow.Size.Width - 20, HorizontalAlignment.Left);
                //m_toolBox.Columns.Add("hhh");
                m_toolBox.FullRowSelect = true;
                m_toolBox.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;

                // if (dockPanel.ActiveContent != null)
                {

                    m_toolBox.Items.Clear();
                    m_toolBox.View = View.Details;
                    m_toolBox.LabelEdit = false;
                    m_toolBox.AllowColumnReorder = false;
                    m_toolBox.CheckBoxes = false;
                    m_toolBox.Items.Add(new ListViewItem("Pointer", (int)STATIC_OBJ_TYPE.ID_Pointer));
                    m_toolBox.Items.Add(new ListViewItem("Variable", (int)STATIC_OBJ_TYPE.ID_FBDBoxVariable));
                    m_toolBox.Items.Add(new ListViewItem("Function", (int)STATIC_OBJ_TYPE.ID_FBDBoxFunction));
                    m_toolBox.Items.Add(new ListViewItem("Function Block", (int)STATIC_OBJ_TYPE.ID_FBDBoxFunctionBlock));
                    m_toolBox.Items.Add(new ListViewItem("Connection", (int)STATIC_OBJ_TYPE.ID_FBDWire));
                    m_toolBox.Items.Add(new ListViewItem("Comment", (int)STATIC_OBJ_TYPE.ID_FBDBoxLabel));
                    m_toolBox.Items.Add(new ListViewItem("Constant", (int)STATIC_OBJ_TYPE.ID_FBDBoxConstant));

                }
            }
        }
        private void ShowSFCToolbox()
        {
            if (ProjectLoaded)
            {
                m_toolBox.Columns.Add("hhh", m_toolboxwindow.Size.Width - 20, HorizontalAlignment.Left);
                //m_toolBox.Columns.Add("hhh");
                m_toolBox.FullRowSelect = true;
                m_toolBox.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;

                // if (dockPanel.ActiveContent != null)
                {

                    m_toolBox.Items.Clear();
                    m_toolBox.View = View.Details;
                    m_toolBox.LabelEdit = false;
                    m_toolBox.AllowColumnReorder = false;
                    m_toolBox.CheckBoxes = false;
                    m_toolBox.Items.Add(new ListViewItem("Pointer", (int)STATIC_OBJ_TYPE.ID_Pointer));
                    m_toolBox.Items.Add(new ListViewItem("Initial Step", (int)STATIC_OBJ_TYPE.ID_Initial_Step));
                    m_toolBox.Items.Add(new ListViewItem("Step", (int)STATIC_OBJ_TYPE.ID_Step));
                    m_toolBox.Items.Add(new ListViewItem("Transition", (int)STATIC_OBJ_TYPE.ID_Transition));
                    m_toolBox.Items.Add(new ListViewItem("AND", (int)STATIC_OBJ_TYPE.ID_AND));
                    m_toolBox.Items.Add(new ListViewItem("AND UCorner", (int)STATIC_OBJ_TYPE.ID_AND_UCorner));
                    m_toolBox.Items.Add(new ListViewItem("AND DCorner", (int)STATIC_OBJ_TYPE.ID_AND_DCorner));
                    m_toolBox.Items.Add(new ListViewItem("OR", (int)STATIC_OBJ_TYPE.ID_OR));
                    m_toolBox.Items.Add(new ListViewItem("OR UCorner", (int)STATIC_OBJ_TYPE.ID_OR_UCorner));
                    m_toolBox.Items.Add(new ListViewItem("OR DCorner", (int)STATIC_OBJ_TYPE.ID_OR_DCorner));
                    m_toolBox.Items.Add(new ListViewItem("Jump", (int)STATIC_OBJ_TYPE.ID_Jump));
                    m_toolBox.Items.Add(new ListViewItem("Comment", (int)STATIC_OBJ_TYPE.ID_Comment));

                }
            }
        }
        private void ShowSTToolbox()
        {
            if (ProjectLoaded)
            {
                m_toolBox.Items.Clear();
            }
        }
        private void ShowUserToolbox()
        {
            if (ProjectLoaded)
            {

            }
        }
        private void ShowBlockToolbox()
        {
            if (ProjectLoaded)
            {

            }
        }
        bool _projectLoaded = false;
        public bool ProjectLoaded
        {
            get
            {
                return _projectLoaded;
            }
            set
            {
                _projectLoaded = value;

            }
        }


        //private void TabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        //{


        //    UpdateToolbox();
        //    Form activeChild = this.ActiveMdiChild;
        //    if (activeChild is TabPageControl)
        //    {
        //        switch (((TabPageControl)activeChild).TabPageType)
        //        {
        //            case TABPAGETYPE.DISPLAY:
        //                m_layerwindow.Show(true);
        //                UpdateLayer(((TabDisplayPageControl)activeChild).tbldisplay);
        //                break;
        //            default:
        //                m_layerwindow.Show(false);
        //                break;
        //        }
        //    }
            
        //}


        public void UpdateLayer(tblDisplay tbldisplay)
        {
            m_layerwindow.DataGridViewLayer.Rows.Clear();
            int index = m_layerwindow.DataGridViewLayer.Rows.Add();
            DataGridViewRow row = m_layerwindow.DataGridViewLayer.Rows[index];
            row.Cells[0].Value = tblSolution.m_tblSolution().Layer1;
            row.Cells[1].Value = tblSolution.m_tblSolution().Layer1Desc;
            row.Cells[2].Value = tbldisplay.Layer1Enable;
            row.Cells[3].Value = tbldisplay.Layer1Lock;

            index = m_layerwindow.DataGridViewLayer.Rows.Add();
            row = m_layerwindow.DataGridViewLayer.Rows[index];
            row.Cells[0].Value = tblSolution.m_tblSolution().Layer2;
            row.Cells[1].Value = tblSolution.m_tblSolution().Layer2Desc;
            row.Cells[2].Value = tbldisplay.Layer2Enable;
            row.Cells[3].Value = tbldisplay.Layer2Lock;

            index = m_layerwindow.DataGridViewLayer.Rows.Add();
            row = m_layerwindow.DataGridViewLayer.Rows[index];
            row.Cells[0].Value = tblSolution.m_tblSolution().Layer3;
            row.Cells[1].Value = tblSolution.m_tblSolution().Layer3Desc;
            row.Cells[2].Value = tbldisplay.Layer3Enable;
            row.Cells[3].Value = tbldisplay.Layer3Lock;

            index = m_layerwindow.DataGridViewLayer.Rows.Add();
            row = m_layerwindow.DataGridViewLayer.Rows[index];
            row.Cells[0].Value = tblSolution.m_tblSolution().Layer4;
            row.Cells[1].Value = tblSolution.m_tblSolution().Layer4Desc;
            row.Cells[2].Value = tbldisplay.Layer4Enable;
            row.Cells[3].Value = tbldisplay.Layer4Lock;

            index = m_layerwindow.DataGridViewLayer.Rows.Add();
            row = m_layerwindow.DataGridViewLayer.Rows[index];
            row.Cells[0].Value = tblSolution.m_tblSolution().Layer5;
            row.Cells[1].Value = tblSolution.m_tblSolution().Layer5Desc;
            row.Cells[2].Value = tbldisplay.Layer5Enable;
            row.Cells[3].Value = tbldisplay.Layer5Lock;

            index = m_layerwindow.DataGridViewLayer.Rows.Add();
            row = m_layerwindow.DataGridViewLayer.Rows[index];
            row.Cells[0].Value = tblSolution.m_tblSolution().Layer6;
            row.Cells[1].Value = tblSolution.m_tblSolution().Layer6Desc;
            row.Cells[2].Value = tbldisplay.Layer6Enable;
            row.Cells[3].Value = tbldisplay.Layer6Lock;

            index = m_layerwindow.DataGridViewLayer.Rows.Add();
            row = m_layerwindow.DataGridViewLayer.Rows[index];
            row.Cells[0].Value = tblSolution.m_tblSolution().Layer7;
            row.Cells[1].Value = tblSolution.m_tblSolution().Layer7Desc;
            row.Cells[2].Value = tbldisplay.Layer7Enable;
            row.Cells[3].Value = tbldisplay.Layer7Lock;

            index = m_layerwindow.DataGridViewLayer.Rows.Add();
            row = m_layerwindow.DataGridViewLayer.Rows[index];
            row.Cells[0].Value = tblSolution.m_tblSolution().Layer8;
            row.Cells[1].Value = tblSolution.m_tblSolution().Layer8Desc;
            row.Cells[2].Value = tbldisplay.Layer8Enable;
            row.Cells[3].Value = tbldisplay.Layer8Lock;

        }
        public void UpdateLayerChange(LAYERS layerno,bool _enable,bool _lock)
        {
            Form activeChild = this.ActiveMdiChild;
            if (activeChild is TabDisplayPageControl)
            {
                switch(layerno)
                {
                    case LAYERS.Layer1:
                        ((TabDisplayPageControl)activeChild).tbldisplay.Layer1Enable = _enable;
                        ((TabDisplayPageControl)activeChild).tbldisplay.Layer1Lock = _lock;
                        break;
                    case LAYERS.Layer2:
                        ((TabDisplayPageControl)activeChild).tbldisplay.Layer2Enable = _enable;
                        ((TabDisplayPageControl)activeChild).tbldisplay.Layer2Lock = _lock;
                        break;
                    case LAYERS.Layer3:
                        ((TabDisplayPageControl)activeChild).tbldisplay.Layer3Enable = _enable;
                        ((TabDisplayPageControl)activeChild).tbldisplay.Layer3Lock = _lock;
                        break;
                    case LAYERS.Layer4:
                        ((TabDisplayPageControl)activeChild).tbldisplay.Layer4Enable = _enable;
                        ((TabDisplayPageControl)activeChild).tbldisplay.Layer4Lock = _lock;
                        break;
                    case LAYERS.Layer5:
                        ((TabDisplayPageControl)activeChild).tbldisplay.Layer5Enable = _enable;
                        ((TabDisplayPageControl)activeChild).tbldisplay.Layer5Lock = _lock;
                        break;
                    case LAYERS.Layer6:
                        ((TabDisplayPageControl)activeChild).tbldisplay.Layer6Enable = _enable;
                        ((TabDisplayPageControl)activeChild).tbldisplay.Layer6Lock = _lock;
                        break;
                    case LAYERS.Layer7:
                        ((TabDisplayPageControl)activeChild).tbldisplay.Layer7Enable = _enable;
                        ((TabDisplayPageControl)activeChild).tbldisplay.Layer7Lock = _lock;
                        break;
                    case LAYERS.Layer8:
                        ((TabDisplayPageControl)activeChild).tbldisplay.Layer8Enable = _enable;
                        ((TabDisplayPageControl)activeChild).tbldisplay.Layer8Lock = _lock;
                        break;
                }
                ((TabDisplayPageControl)activeChild).Refresh();

            }
        }

        public void UpdateToolbox()
        {
            Form activeChild = this.ActiveMdiChild;
            if (activeChild is TabPageControl)
            {
                switch (((TabPageControl)activeChild).TabPageType)
                {
                    case TABPAGETYPE.DISPLAY:
                        ShowDisplayToolbox();
                        break;
                    case TABPAGETYPE.UD_FUNCTION:
                    case TABPAGETYPE.UD_FUNCTIONBLOCK:
                    case TABPAGETYPE.FBD:
                        ShowFBDToolbox();
                        break;
                    case TABPAGETYPE.SFC:
                        ShowSFCToolbox();
                        break;
                    case TABPAGETYPE.ST:
                        ShowSTToolbox();
                        break;
                    case TABPAGETYPE.BLOCK:
                        ShowBlockToolbox();
                        break;
                    case TABPAGETYPE.REPORT:
                        ShowUserToolbox();
                        break;
                }
            }
        }

        private void moveToFrontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form activeChild = this.ActiveMdiChild;
            if (activeChild is TabGraphicPageControl)
            {

                PageList Pages = ((TabGraphicPageControl)activeChild).Pages();
                int pageno = Pages.ActivePageNo;
                if (Pages.GraphicPagesList[pageno].MoveSelectionToFront())
                {
                    Pages.Dirty = true;
                    ((TabGraphicPageControl)activeChild).drawarea.Refresh();
                }
            }
        }

        private void moveToBackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form activeChild = this.ActiveMdiChild;
            if (activeChild is TabGraphicPageControl)
            {

                PageList Pages = ((TabGraphicPageControl)activeChild).Pages();
                int pageno = Pages.ActivePageNo;
                if (Pages.GraphicPagesList[pageno].MoveSelectionToBack())
                {
                    Pages.Dirty = true;
                    ((TabGraphicPageControl)activeChild).drawarea.Refresh();
                }
            }
        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        //public bool UpateDisplayFromPropertygrid(int i)
        //{
        //    bool ret = true;
        //    if ((i >= 0) && (i < TabControlMain.TabPages.Count))
        //    {
        //        // if (((TabPageControl)TabControlMain.TabPages[i]).drawarea.Graphics.Dirty)
        //        {

        //            switch (((TabPageControl)TabControlMain.TabPages[i]).TabPageType)
        //            {
        //                case TABPAGETYPE.DISPLAY:
        //                case TABPAGETYPE.FBD:
        //                    ((TabGraphicPageControl)TabControlMain.TabPages[i]).drawarea.Invalidate();
        //                    break;
        //                case TABPAGETYPE.VARIABLE:
        //                    ((TabVariableGridPageControl)TabControlMain.TabPages[i]).UpdateTabPage();
        //                    break;
        //                case TABPAGETYPE.ALARM_GROUP:
        //                    break;
        //            }
        //        }
        //    }

        //    return ret;
        //}

        public bool UpateDocPagefromPropertyGrid()
        {
            bool ret = true;
            Form activeChild = this.ActiveMdiChild;
            if (activeChild is TabPageControl)
            {
                switch (((TabPageControl)activeChild).TabPageType)
                {
                    case TABPAGETYPE.FBD:
                        ((TabFBDPageControl)activeChild).Dirty = true;
                        
                        break;
                    case TABPAGETYPE.ST:
                        ((TabSTPageControl)activeChild).Dirty = true;

                        break;
                    case TABPAGETYPE.DISPLAY:
                        ((TabDisplayPageControl)activeChild).Dirty = true;
                        ((TabDisplayPageControl)activeChild).SetDirtyObjects();
                        ((TabDisplayPageControl)activeChild).drawarea.Invalidate();
                        break;
                    case TABPAGETYPE.VARIABLE:
                        ((TabVariableGridPageControl)activeChild).UpdateTabPage();
                        break;
                    case TABPAGETYPE.ALARM_GROUP:
                        break;
                    case TABPAGETYPE.PLANT_STRUCTURE:
                        break;
                }
            }
            return ret;
        }

        public void UpateVariableFromPropertygrid()
        {
            Form activeChild = this.ActiveMdiChild;
            if (activeChild is TabVariableGridPageControl)
            {
                switch (((TabPageControl)activeChild).TabPageType)
                {

                    case TABPAGETYPE.VARIABLE:
                        // ((TabVariableGridPageControl)TabControlMain.TabPages[i]).UpdateTabPage();
                        ((TabVariableGridPageControl)activeChild).Dirty = true;
                        break;

                }


            }


        }

        

        //private void SaveDisplay(long _id, DrawArea _drawarea)
        //{
        //    foreach (tblDisplay tbldisplay in tblSolution.m_tblSolution().m_tblDisplayCollection)
        //    {
        //        if (_id == tbldisplay.DisplayID)
        //        {
        //            tbldisplay.SaveDisplayobjects(_drawarea);
        //            break;
        //        }
        //    }

        //}

        public void SaveOpenPOUs(long _controllerID)
        {
            //int i = TabControlMain.SelectedIndex;
            //if (i >= 0)
            //{
            //    //int pageno = ((TabPageControl)TabControlMain.TabPages[i]).drawarea.PageNo;
            //    if ((i >= 0) && (i < TabControlMain.TabPages.Count))
            //    {
            //        if ((((TabFBDPageControl)TabControlMain.TabPages[i]).Dirty) ||
            //            !(((TabPageControl)TabControlMain.TabPages[i]).CheckOutputFileExist()) ||
            //             (((TabFBDPageControl)TabControlMain.TabPages[i]).drawarea.DeleteList.Count > 0))
            //        {
            //            switch (((TabPageControl)TabControlMain.TabPages[i]).TabPageType)
            //            {

            //                case TABPAGETYPE.FBD:
            //                    //SaveFBD(((TabPageControl)TabControlMain.TabPages[i]).drawarea.ID, ((TabPageControl)TabControlMain.TabPages[i]).drawarea);
            //                    ((TabPageControl)TabControlMain.TabPages[i]).SaveTabPage(_controllerID);

            //                    break;
            //                default:
            //                    break;
            //            }
            //        }
            //    }
            //}

        }

        public void SaveControllerOpenItems(long _controllerID)
        {

            //for (int i = 0; i < TabControlMain.TabPages.Count; i++)
            //{
            //    switch (((TabPageControl)TabControlMain.TabPages[i]).TabPageType)
            //    {
            //        case TABPAGETYPE.FBD:
            //            if (((TabFBDPageControl)TabControlMain.TabPages[i]).tblcontroller.ControllerID == _controllerID)
            //            {
            //                if ((((TabFBDPageControl)TabControlMain.TabPages[i]).Dirty || !(((TabFBDPageControl)TabControlMain.TabPages[i]).CheckOutputFileExist())))
            //                {
            //                    ((TabFBDPageControl)TabControlMain.TabPages[i]).SaveTabPage();
            //                    TabControlMain.TabPages[i].ImageIndex = 0;
            //                }
            //            }
            //            break;
            //        case TABPAGETYPE.SFC:
            //            if (((TabSFCPageControl)TabControlMain.TabPages[i]).tblcontroller.ControllerID == _controllerID)
            //            {
            //                if ((((TabSFCPageControl)TabControlMain.TabPages[i]).Dirty || !(((TabSFCPageControl)TabControlMain.TabPages[i]).CheckOutputFileExist())))
            //                {
            //                    ((TabSFCPageControl)TabControlMain.TabPages[i]).SaveTabPage();
            //                    TabControlMain.TabPages[i].ImageIndex = 0;
            //                }
            //            }
            //            break;
            //        case TABPAGETYPE.ST:
            //            if (((TabSTPageControl)TabControlMain.TabPages[i]).tblcontroller.ControllerID == _controllerID)
            //            {
            //                if (((TabSTPageControl)TabControlMain.TabPages[i]).Dirty)
            //                {
            //                    ((TabSTPageControl)TabControlMain.TabPages[i]).SaveTabPage();
            //                    TabControlMain.TabPages[i].ImageIndex = 0;
            //                }
            //            }
            //            break;
            //        case TABPAGETYPE.VARIABLE:
            //            if (((TabPageControl)TabControlMain.TabPages[i]).ID == _controllerID)
            //            {
            //                if (((TabPageControl)TabControlMain.TabPages[i]).Dirty)
            //                {
            //                    ((TabPageControl)TabControlMain.TabPages[i]).SaveTabPage();
            //                    TabControlMain.TabPages[i].ImageIndex = 0;
            //                }
            //            }
            //            break;

            //    }
            //}



        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            Form activeChild = this.ActiveMdiChild;
            if (activeChild is TabPageControl)
            {
                ((TabPageControl)activeChild).SaveTabPage();
            }
        }
            //int i = TabControlMain.SelectedIndex;
            //if (i >= 0)
            //{
            //    // int pageno = ((TabPageControl)TabControlMain.TabPages[i]).drawarea.PageNo;
            //    if ((i >= 0) && (i < TabControlMain.TabPages.Count))
            //    {
            //        if ((((TabPageControl)TabControlMain.TabPages[i]).Dirty || !(((TabPageControl)TabControlMain.TabPages[i]).CheckOutputFileExist())))
            //        {
            //            ((TabPageControl)TabControlMain.TabPages[i]).SaveTabPage();
            //            TabControlMain.TabPages[i].ImageIndex = 0;
            //            /*
            //            switch (((TabPageControl)TabControlMain.TabPages[i]).PageType)
            //            {
            //                case DrawAreaType.DISPLAY:
            //                    //SaveDisplay(((TabPageControl)TabControlMain.TabPages[i]).drawarea.ID, ((TabPageControl)TabControlMain.TabPages[i]).drawarea);
            //                    TabControlMain.TabPages[i].ImageIndex = 0;
            //                    break;
            //                case DrawAreaType.FBD:
            //                    //SaveFBD(((TabPageControl)TabControlMain.TabPages[i]).drawarea.ID, ((TabPageControl)TabControlMain.TabPages[i]).drawarea);
            //                    ((TabPageControl)TabControlMain.TabPages[i]).SaveTabPage();
            //                    TabControlMain.TabPages[i].ImageIndex = 0;
            //                    break;
            //                default:
            //                    break;
            //            }
            //            */
            //        }
            //    }

            //}
        

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form activeChild = this.ActiveMdiChild;
            if (activeChild is TabPageControl)
            {
                ((TabPageControl)activeChild).PrintTabPage();
            }
            //int i = TabControlMain.SelectedIndex;
            ////int pageno = ((TabPageControl)TabControlMain.TabPages[i]).drawarea.PageNo;
            //if ((i >= 0) && (i < TabControlMain.TabPages.Count))
            //{

            //    switch (((TabPageControl)TabControlMain.TabPages[i]).TabPageType)
            //    {
            //        case TABPAGETYPE.DISPLAY:

            //            break;
            //        case TABPAGETYPE.FBD:
            //            //SaveFBD(((TabPageControl)TabControlMain.TabPages[i]).drawarea.ID, ((TabPageControl)TabControlMain.TabPages[i]).drawarea);
            //            ((TabPageControl)TabControlMain.TabPages[i]).PrintTabPage();
            //            TabControlMain.TabPages[i].ImageIndex = 0;
            //            break;
            //        default:
            //            break;
            //    }

            //}
        }

        private void menuStrip1_KeyDown(object sender, KeyEventArgs e)
        {


        }

        private void menuStrip1_KeyUp(object sender, KeyEventArgs e)
        {
            //_controlKey = false;
        }


        private void BlinkingTimer(object sender, EventArgs e)
        {

            Common.Blinking = !Common.Blinking;
            try
            {
                Form activeChild = this.ActiveMdiChild;

                if(activeChild is TabPageControl)
                {
                    switch (((TabPageControl)activeChild).TabPageType)
                    {
                        case TABPAGETYPE.FBD:
                        case TABPAGETYPE.DISPLAY:
                            ((TabGraphicPageControl)activeChild).drawarea.Invalidate();
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //private void OnTimedEvent(Object source, ElapsedEventArgs e)
        //{

        //    Common.Blinking = !Common.Blinking;
        //    try
        //    {
        //        if (TabControlMain.TabPages.Count > 0)
        //        {
        //            int i = TabControlMain.SelectedIndex;
        //            ((TabPageControl)TabControlMain.TabPages[0]).drawarea.Invalidate();
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }

        //}

        private void MainForm_Load(object sender, EventArgs e)
        {
            //aTimer = new System.Timers.Timer(5500);
            // Hook up the Elapsed event for the timer. 
            //aTimer.Elapsed += OnTimedEvent;
            //aTimer.Enabled = true;
            //tst.ppp("test");
            if (Common.AutoLoad)
            {
                
                OpenProject();

                foreach (tblController tblcontroller in tblSolution.m_tblSolution().m_tblControllerCollection)
                {
                    if (tblcontroller.type == 0)
                    {
                        lcuList.Add(tblcontroller.ControllerID);
                    }
                }
                WriteToOutputWindows("Project " + Common.ProjectPath + "\\" + Common.DatabaseName + "Loaded.");
               //Common.Static_mainform = this;
            }

        }



        public void WriteToOutputWindows(string str)
        {

            //richTextBoxOutput.Text += str + Environment.NewLine;
            if (m_outputwindow != null)
            {
                m_outputwindow.WriteToOutputWindows(str);
            }
        }

        public void WriteToOutputWindows(string str, LogLevel logLevel)
        {
            if (m_outputwindow != null)
            {
                m_outputwindow.WriteToOutputWindows(str, logLevel);
                //richTextBoxOutput.Text += str + Environment.NewLine;
            }
        }
        private void ReadRegistrySetting()
        {
            ModifyRegistry ApplicationRegistry = new ModifyRegistry();
            Common.ProjectPath = ApplicationRegistry.Read("ProjectPath");
            Common.DatabaseName = ApplicationRegistry.Read("DatabaseName");
            Common.ConnectionStringR = ApplicationRegistry.Read("ConnectionString");
            Common.ConnectionString = Common.ConnectionStringR + "; Password=" + Common.PassString + Common.WordString + ";";
            Common.AutoLoad = ApplicationRegistry.ReadBool("Auto Load");
            Common.LogLevel = ApplicationRegistry.ReadWord("Log Level");

            Common.Variable_NextShow = (int)ApplicationRegistry.ReadWord("Variable NextShow");
            Common.Variable_LastSelectedType = (int)ApplicationRegistry.ReadWord("Variable LastSelectedType");
            Common.Variable_LastSelectedFilter = ApplicationRegistry.Read("Variable LastSelectedFilter");
            Common.Variable_ShowMode = ApplicationRegistry.ReadBool("Variable ShowMode");
            Common.Variable_ShowState = ApplicationRegistry.ReadBool("Variable ShowState");
            Common.Variable_ShowALS = ApplicationRegistry.ReadBool("Variable ShowALS");
            Common.Variable_ShowALA = ApplicationRegistry.ReadBool("Variable ShowALA");
            Common.Variable_ShowALB = ApplicationRegistry.ReadBool("Variable ShowALB");
            Common.Variable_ShowAEB = ApplicationRegistry.ReadBool("Variable ShowAEB");
            Common.Variable_ShowOPN = ApplicationRegistry.ReadBool("Variable ShowOPN");
            Common.Variable_ShowOPH = ApplicationRegistry.ReadBool("Variable ShowOPH");
            Common.Variable_ShowOPM = ApplicationRegistry.ReadBool("Variable ShowOPM");
            Common.Variable_ShowMNN = ApplicationRegistry.ReadBool("Variable ShowMNN");
            Common.Variable_NameColWidth = (int)ApplicationRegistry.ReadWord("Variable NameColWidth");
            Common.Variable_DescriptionColWidth = (int)ApplicationRegistry.ReadWord("Variable DescriptionColWidth");
            Common.Variable_TypeColWidth = (int)ApplicationRegistry.ReadWord("Variable TypeColWidth");
            Common.Variable_IDColWidth = (int)ApplicationRegistry.ReadWord("Variable IDColWidth");
            Common.Variable_LocalSelected = ApplicationRegistry.ReadBool("Variable LocalSelected");
            Common.Variable_LastSelectedArea = (long)ApplicationRegistry.ReadWord("Variable LastSelectedArea");

            Common.TabPageGridAlarmGroupControl_RowColWidth = (int)ApplicationRegistry.ReadWord("TabPageGridAlarmGroupControl RowColWidth");
            Common.TabPageGridAlarmGroupControl_NameColWidth = (int)ApplicationRegistry.ReadWord("TabPageGridAlarmGroupControl NameColWidth");
            Common.TabPageGridAlarmGroupControl_TypeColWidth = (int)ApplicationRegistry.ReadWord("TabPageGridAlarmGroupControl TypeColWidth");
            Common.TabPageGridAlarmGroupControl_ArchiveColWidth = (int)ApplicationRegistry.ReadWord("TabPageGridAlarmGroupControl ArchiveColWidth");
            Common.TabPageGridAlarmGroupControl_RetriggerColWidth = (int)ApplicationRegistry.ReadWord("TabPageGridAlarmGroupControl RetriggerColWidth");
            Common.TabPageGridAlarmGroupControl_PrintColWidth = (int)ApplicationRegistry.ReadWord("TabPageGridAlarmGroupControl PrintColWidth");

            Common.TabVariableGridPageControl_NameColWidth = (int)ApplicationRegistry.ReadWord("TabVariableGridPageControl NameColWidth");
            Common.TabVariableGridPageControl_DescriptionColWidth = (int)ApplicationRegistry.ReadWord("TabVariableGridPageControl DescriptionColWidth");
            Common.TabVariableGridPageControl_POUColWidth = (int)ApplicationRegistry.ReadWord("TabVariableGridPageControl POUColWidth");
            Common.TabVariableGridPageControl_TypeColWidth = (int)ApplicationRegistry.ReadWord("TabVariableGridPageControl TypeColWidth");
            Common.TabVariableGridPageControl_InitialValColWidth = (int)ApplicationRegistry.ReadWord("TabVariableGridPageControl InitialValColWidth");
            Common.TabVariableGridPageControl_GroupColWidth = (int)ApplicationRegistry.ReadWord("TabVariableGridPageControl GroupColWidth");



        }

        private void WirteRegistrySetting()
        {
            ModifyRegistry ApplicationRegistry = new ModifyRegistry();
            ApplicationRegistry.Write("ProjectPath", Common.ProjectPath);
            ApplicationRegistry.Write("DatabaseName", Common.DatabaseName);
            ApplicationRegistry.Write("ConnectionString", Common.ConnectionStringR);
            ApplicationRegistry.WriteBool("Auto Load", Common.AutoLoad);
            ApplicationRegistry.WriteWord("Log Level", (int)Common.LogLevel);

            ApplicationRegistry.WriteWord("Variable NextShow", (int)Common.Variable_NextShow);
            if (Common.Variable_NextShow == 2)
            {
                ApplicationRegistry.WriteWord("Variable LastSelectedType", (int)Common.Variable_LastSelectedType);
                ApplicationRegistry.Write("Variable LastSelectedFilter", Common.Variable_LastSelectedFilter);
                ApplicationRegistry.WriteBool("Variable ShowMode", Common.Variable_ShowMode);
                ApplicationRegistry.WriteBool("Variable ShowState", Common.Variable_ShowState);
                ApplicationRegistry.WriteBool("Variable ShowALS", Common.Variable_ShowALS);
                ApplicationRegistry.WriteBool("Variable ShowALA", Common.Variable_ShowALA);
                ApplicationRegistry.WriteBool("Variable ShowALB", Common.Variable_ShowALB);
                ApplicationRegistry.WriteBool("Variable ShowAEB", Common.Variable_ShowAEB);
                ApplicationRegistry.WriteBool("Variable ShowOPN", Common.Variable_ShowOPN);
                ApplicationRegistry.WriteBool("Variable ShowOPH", Common.Variable_ShowOPH);
                ApplicationRegistry.WriteBool("Variable ShowOPM", Common.Variable_ShowOPM);
                ApplicationRegistry.WriteBool("Variable ShowMNN", Common.Variable_ShowMNN);
                ApplicationRegistry.WriteWord("Variable NameColWidth", (int)Common.Variable_NameColWidth);
                ApplicationRegistry.WriteWord("Variable DescriptionColWidth", (int)Common.Variable_DescriptionColWidth);
                ApplicationRegistry.WriteWord("Variable TypeColWidth", (int)Common.Variable_TypeColWidth);
                ApplicationRegistry.WriteWord("Variable IDColWidth", (int)Common.Variable_IDColWidth);
                ApplicationRegistry.WriteBool("Variable LocalSelected", Common.Variable_LocalSelected);
                ApplicationRegistry.WriteWord("Variable LastSelectedArea", Common.Variable_LastSelectedArea);
            }
            ApplicationRegistry.WriteWord("TabPageGridAlarmGroupControl RowColWidth", Common.TabPageGridAlarmGroupControl_RowColWidth);
            ApplicationRegistry.WriteWord("TabPageGridAlarmGroupControl NameColWidth", Common.TabPageGridAlarmGroupControl_NameColWidth);
            ApplicationRegistry.WriteWord("TabPageGridAlarmGroupControl TypeColWidth", Common.TabPageGridAlarmGroupControl_TypeColWidth);
            ApplicationRegistry.WriteWord("TabPageGridAlarmGroupControl ArchiveColWidth", Common.TabPageGridAlarmGroupControl_ArchiveColWidth);
            ApplicationRegistry.WriteWord("TabPageGridAlarmGroupControl RetriggerColWidth", Common.TabPageGridAlarmGroupControl_RetriggerColWidth);
            ApplicationRegistry.WriteWord("TabPageGridAlarmGroupControl PrintColWidth", Common.TabPageGridAlarmGroupControl_PrintColWidth);

            ApplicationRegistry.WriteWord("TabVariableGridPageControl NameColWidth", Common.TabVariableGridPageControl_NameColWidth);
            ApplicationRegistry.WriteWord("TabVariableGridPageControl DescriptionColWidth", Common.TabVariableGridPageControl_DescriptionColWidth);
            ApplicationRegistry.WriteWord("TabVariableGridPageControl POUColWidth", Common.TabVariableGridPageControl_POUColWidth);
            ApplicationRegistry.WriteWord("TabVariableGridPageControl TypeColWidth", Common.TabVariableGridPageControl_TypeColWidth);
            ApplicationRegistry.WriteWord("TabVariableGridPageControl InitialValColWidth", Common.TabVariableGridPageControl_InitialValColWidth);
            ApplicationRegistry.WriteWord("TabVariableGridPageControl GroupColWidth", Common.TabVariableGridPageControl_GroupColWidth);








        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            WirteRegistrySetting();
        }

        private void TabControlMain_KeyPress(object sender, KeyPressEventArgs e)
        {
            //int i = 0;
        }

        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            //int i = 0;
            switch (e.KeyCode)
            {
                case Keys.Delete:
                    //drawArea.TheLayers[al].Graphics.DeleteSelection();
                    //drawArea.Invalidate();
                    //i = 1;
                    break;
                case Keys.Right:
                    //drawArea.PanX -= 10;
                    //drawArea.Invalidate();
                    //i = 1;
                    break;
                case Keys.Left:
                    //drawArea.PanX += 10;
                    //drawArea.Invalidate();
                    //i = 2;
                    break;
                case Keys.Up:
                    //if (e.KeyCode == Keys.Up &&
                    //    e.Shift)
                    //    AdjustZoom(.1f);
                    //else
                    //    drawArea.PanY += 10;
                    //drawArea.Invalidate();
                    //i = 3;
                    break;
                case Keys.Down:
                    //if (e.KeyCode == Keys.Down &&
                    //    e.Shift)
                    //    AdjustZoom(-.1f);
                    //else
                    //    drawArea.PanY -= 10;
                    //drawArea.Invalidate();
                    //i = 4;
                    break;
                case Keys.ControlKey:
                    //_controlKey = true;
                    break;
                default:
                    break;
            }
            //drawArea.Invalidate();
            //SetStateOfControls();
        }

        private void richTextBoxOutput_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolStripButtonCompile_Click(object sender, EventArgs e)
        {
            //int i = TabControlMain.SelectedIndex;
            ////int pageno = ((TabPageControl)TabControlMain.TabPages[i]).drawarea.PageNo;
            //if ((i >= 0) && (i < TabControlMain.TabPages.Count))
            //{
            //    ((TabPageControl)TabControlMain.TabPages[i]).CompileTabPage();
            //}
            /*
            switch (((TabPageControl)TabControlMain.TabPages[i]).PageType)
            {
                case DrawAreaType.DISPLAY:

                    break;
                case DrawAreaType.FBD:
                    if (((TabFBDPageControl)TabControlMain.TabPages[i]).Dirty)
                    {
                        ((TabFBDPageControl)TabControlMain.TabPages[i]).SaveTabPage();
                    }
                    compiler = null;
                    compiler = new Compiler(this);

                    foreach (tblController tblcontroller in tblSolution.m_tblSolution().m_tblControllerCollection)
                    {
                        if (tblcontroller.ControllerID == ((TabPageControl)TabControlMain.TabPages[i]).ControllerID)
                        {
                            foreach (tblPou tblpou in tblcontroller.m_tblPouCollection)
                            {
                                if (tblpou.pouID == ((TabPageControl)TabControlMain.TabPages[i]).pouID)
                                {
                                    compiler.CompilePOU(tblcontroller, tblpou);
                                    break;
                                }
                            }
                        }
                    }


                    TabControlMain.TabPages[i].ImageIndex = 0;
                    break;
                default:
                    break;
            }  
             */
        }
        private void toolStripButtonCompileAll_Click(object sender, EventArgs e)
        {
            // int i = TabControlMain.SelectedIndex;
            //// int pageno = ((TabPageControl)TabControlMain.TabPages[i]).drawarea.PageNo;
            // if ((i >= 0) && (i < TabControlMain.TabPages.Count))
            // {

            //     switch (((TabPageControl)TabControlMain.TabPages[i]).PageType)
            //     {
            //         case DrawAreaType.DISPLAY:

            //             break;
            //         case DrawAreaType.FBD:
            //             compiler = null;
            //             compiler = new Compiler(this);

            //                     foreach (tblController tblcontroller in tblSolution.m_tblSolution().m_tblControllerCollection)
            //                     {
            //                         if (tblcontroller.ControllerID == ((TabPageControl)TabControlMain.TabPages[i]).ControllerID)
            //                         {
            //                             compiler.CompileController(tblcontroller);
            //                             break;
            //                         }
            //                     }


            //             TabControlMain.TabPages[i].ImageIndex = 0;
            //             break;
            //         default:
            //             break;
            //     }

            // }
        }

        public void CompileController(tblController tblcontroller)
        {
            compiler = null;
            compiler = new Compiler(/*this*/);
            compiler.CompileController(tblcontroller);
            tblSolution.m_tblSolution().SaveNodesDB();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripButtonOfflineDownload_Click(object sender, EventArgs e)
        {

        }

        private void generateAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tblSolution.m_tblSolution().SaveNodesDB();
        }

        private void MainForm_MdiChildActivate(object sender, EventArgs e)
        {

        }

        private void moveToFrontToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void moveToBackToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void copyToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void cutGraphicPageToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void copyGraphicPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form activeChild = this.ActiveMdiChild;
            if (activeChild is TabGraphicPageControl)
            {

                PageList Pages = ((TabGraphicPageControl)activeChild).Pages();
                int pageno = Pages.ActivePageNo;
                ((TabGraphicPageControl)activeChild).Copy2Clipboard();
            }
        }

        private void pasteGraphicPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Point pt = Cursor.Position;
            Form activeChild = this.ActiveMdiChild;
            if (activeChild is TabGraphicPageControl)
            {
                
                PageList Pages = ((TabGraphicPageControl)activeChild).Pages();
                int pageno = Pages.ActivePageNo;
                ((TabGraphicPageControl)activeChild).PastefromClipboard();
            }
        }

        private void deleteGraphicPageToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void moveToFrontGraphicPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form activeChild = this.ActiveMdiChild;
            if (activeChild is TabGraphicPageControl)
            {

                PageList Pages = ((TabGraphicPageControl)activeChild).Pages();
                int pageno = Pages.ActivePageNo;
                if (Pages.GraphicPagesList[pageno].MoveSelectionToFront())
                {
                    //Pages.GraphicPagesList[pageno].Dirty = true;
                    Pages.Dirty = true;
                    ((TabGraphicPageControl)activeChild).drawarea.Refresh();
                }
            }
        }

        private void moveToBackGraphicPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form activeChild = this.ActiveMdiChild;
            if (activeChild is TabGraphicPageControl)
            {

                PageList Pages = ((TabGraphicPageControl)activeChild).Pages();
                int pageno = Pages.ActivePageNo;
                if (Pages.GraphicPagesList[pageno].MoveSelectionToBack())
                {
                    //Pages.GraphicPagesList[pageno].Dirty = true;
                    Pages.Dirty = true;
                    ((TabGraphicPageControl)activeChild).drawarea.Refresh();
                }
            }
        }

        private void propertyGraphicPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form activeChild = this.ActiveMdiChild;
            if (activeChild is TabGraphicPageControl)
            {

                PageList Pages = ((TabGraphicPageControl)activeChild).Pages();
                Pages.PropertyClick();
                
            }
        }

        private void imporExportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormImEx frmImportExport = new FormImEx(this);
            DialogResult dialogResult;
            dialogResult = frmImportExport.ShowDialog();
            //if (dialogResult == DialogResult.OK)
            //{
            //    ImportExport importexport = new ImportExport();
            //    importexport.ImporExportSelected = frmImportExport.ImporExportSelected;
            //}
           
        }

        private void pinsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form activeChild = this.ActiveMdiChild;
            if (activeChild is TabFBDPageControl)
            {

                PageList Pages = ((TabFBDPageControl)activeChild).Pages();
                Pages.PropertyClick();

            } 
        }


        public void AddError2ErrorWindow(ErrorInfo _errorinfo)
        {
            m_errorwindow.Add(_errorinfo);
        }
        


    }
}

