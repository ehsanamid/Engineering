using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using DocToolkit.Forms;
using DocToolkit.Project_Objects;
using System.ComponentModel;

//using DocToolkit;

namespace EWSTools
{
	public class DCSProject
	{
		public enum EWS_Status
		{
			No_Project_Is_Loaded,
			Project_Is_Loaded
		};
		#region Attributes

		//string m_ProjectName;
		//string m_ProjectPath;
		//string m_ProjectCreator;
		//string m_ProjectDescription;
		//  DocToolkit.Forms.MainForm _mainform;
        public MainForm mainfrm;
		private EWS_Status _EWS_Status = EWS_Status.No_Project_Is_Loaded;
		private bool _IsBeingOpened = false;
		public SqlConnection _SqlConnectionGlobalConnection;

		//public CProject m_Project;
        public tblProject _tblProject;
        public int[] ProjectTreePathIndex =  {-1,-1,-1,-1,-1,-1};
        public int ProjectTreeLevel = -1;
		#endregion

		#region Constructor


		public DCSProject(MainForm _frm)
		{
            mainfrm = _frm;
			_projecttreestructure = _PROJECT_TREE_TYPES.__PROJECT_DOMAIN_UA_UA_CONTROLLER;
			//m_Project = new CProject(this);
            //m_Project.ProjectName = ProjectName;
		}
		public DCSProject(MainForm _frm ,ref EWS_Status m_EWS_Status, ref bool m_IsBeingOpened, ref SqlConnection m_SqlConnectionGlobalConnection)
		{
			// TODO: Complete member initialization
			//  _mainform = __mainform;

            mainfrm = _frm;
			_EWS_Status = m_EWS_Status;
			_IsBeingOpened = m_IsBeingOpened;
			_SqlConnectionGlobalConnection = m_SqlConnectionGlobalConnection;
			_projecttreestructure = _PROJECT_TREE_TYPES.__PROJECT_DOMAIN_UA_UA_CONTROLLER;
            //m_Project = new CProject( this);
            //m_Project = new CProject(this);
            //m_Project.ProjectName = ProjectName;

           

		}

		#endregion
		#region Events
		public delegate void ProjectChangedEvent();
		public event ProjectChangedEvent ProjectChanged;
		protected virtual void OnProjectChanged()
		{
			if (ProjectChanged != null && !_IsBeingOpened)
			{
				ProjectChanged();
			}
		}
		#endregion
		#region Properties

		string _projectpath = null;
		//[Category("Project Name & Path")]
		public string ProjectPath
		{
			get
			{
				return _projectpath;
			}
			set
			{
				_projectpath = value;
			}
		}

		string _projectname = null;
		//[Category("Project Name & Path")]
		public string ProjectName
		{
			get
			{
				return _projectname;
			}
			set
			{
				_projectname = value;
			}
		}

        string _connectionstring = "Integrated Security=SSPI;" + "Initial Catalog=;" + "Data Source=localhost;";
		[DisplayName("ConnectionString")]
        [Category("Uplink")]
        public string ConnectionString
        {
            get
            {
                try
                {
                    return _connectionstring;
                }
                catch (System.Exception err)
                {
                    throw new Exception("Error getting connect string", err);
                }
            }
            set
            {
                try
                {
                    _connectionstring = value;
                }
                catch (System.Exception err)
                {
                    throw new Exception("Error setting connect string", err);
                }
            }

        }

		//public static TreeNodeCollection Stations = null;
		//public static TreeNodeCollection LCUs = null;

		#endregion
		#region Serializer & Desrializer

		public void Serialize()
		{
            _tblProject = new tblProject(this, ProjectName);
            _tblProject.Select();
            _tblProject.Serialize();

        }
		public void DeSerialize()
		{
			//try
			//{
			//    OleDbDataAdapter _adapter = new OleDbDataAdapter(string.Empty, frmMain.Connection);
			//    _adapter.SelectCommand.CommandText = "Select * from Project where ProjectName = '" + ProjectName + "'";

			//    DataTable table = new DataTable();
			//    _adapter.Fill(table);

			//    if (table.Rows.Count == 1)
			//    {
			//        _networkRedundant = (bool)table.Rows[0]["IsNetworkRedundant"];
			//        _ILConDAS = (bool)table.Rows[0]["ILConDAS"];
			//        _historical = (bool)table.Rows[0]["HistoricalServer"];
			//        _computerName = (string)table.Rows[0]["ComputerName"];
			//        _databaseName = (string)table.Rows[0]["DatabaseName"];
			//        _logEnabled = (bool)table.Rows[0]["LogEnabled"];
			//        _serverRedundant = (bool)table.Rows[0]["ServerRedundancy"];
			//    }

			//    _adapter.Dispose();

			//}
			//catch (Exception)
			//{
			//    MessageBox.Show("Table is not accessible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			//    return;
			//}
		}

		#endregion


		public void NewProject()
		{
			//string path;
			bool m_StartAgain = false;
			NewProjectForm frmnewproject = new NewProjectForm(New_Open_Project_Form.New_Project_Form);
			DialogResult dialogResult;

			do
			{
				m_StartAgain = false;
				dialogResult = frmnewproject.ShowDialog();
				if (dialogResult == DialogResult.OK)
				{

					//  path = "\\\\"+frmnewproject.textboxServerName.Text + "\\DCS Project" + frmnewproject.textboxProjectName.Text;
					ProjectName = frmnewproject.textboxProjectName.Text;
					SQLServerIPAddress = frmnewproject.textboxServerName.Text;
					ProjectPath = "\\\\" + SQLServerIPAddress + "\\DCS Project\\" + ProjectName;
					if (!Directory.Exists(ProjectPath))         // Determine whether the directory exists.
					{
						try
						{
							CreateProjectDirectories();
						}
						catch (System.Exception ex)
						{
							m_StartAgain = true;
							MessageBox.Show(ex.ToString(), "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
					}
					else
					{
						DialogResult result = MessageBox.Show("That path exists already. Do you want to use this directory or select another path", "MyProgram", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
						if (result == DialogResult.Yes)
						{
							// Clear Directory
						}
						else
						{
							m_StartAgain = true;
						}
					}
				}
				else
				{
					_EWS_Status = EWS_Status.No_Project_Is_Loaded;
					break;
				}

			} while (m_StartAgain == true);

			if (m_StartAgain == false)
			{

				//   m_DCSProject = new Project(frmnewproject.textBoxProjectName.Text);
				//  ProjectPath = frmnewproject.textboxServerName.Text + "\\" + frmnewproject.textboxProjectName.Text;

				try
				{

					SqlConnectionStringBuilder tmpconn = new SqlConnectionStringBuilder();
					tmpconn.DataSource = _sqlservername;
					tmpconn.Password = "eng";
					tmpconn.UserID = "sa";
					ConnectionString = tmpconn.ConnectionString;
					_SqlConnectionGlobalConnection = new SqlConnection(ConnectionString);
					CreateDB();
					tmpconn.InitialCatalog = ProjectName;
					ConnectionString = tmpconn.ConnectionString;


				}
				catch (Exception)
				{
					MessageBox.Show("database can not be created.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					_SqlConnectionGlobalConnection.Close();
					return;
				}


				CreateProjectDatabases();
                FillDatabaseForTheFirstTime();

                LoadProjectDatabasesFromSQLDatabase();

                
				//LoadFromISALib();
				//FillBoardGroups();
				//FillUserDefFunctions();
				

			}
		}
        //private void AddProject(string strProjectName)
        //{
        //    if (_SqlConnectionGlobalConnection.State == System.Data.ConnectionState.Open)
        //        _SqlConnectionGlobalConnection.Close();
        //    _SqlConnectionGlobalConnection.ConnectionString = ConnectionString;
        //    _SqlConnectionGlobalConnection.Open();
  
        //    try
        //    {
        //        string sql = "INSERT INTO tblProject(ProjectName,ServerName,ProjectPath) " +
        //         "VALUES ('" + ProjectName +"','"+ SQLServerIPAddress + "','" + ProjectPath + "') ";
        //        SqlCommand cmd = new SqlCommand(sql, _SqlConnectionGlobalConnection);
        //        cmd.ExecuteNonQuery();

        //    }
        //    catch (SqlException ae)
        //    {
        //        MessageBox.Show(ae.Message.ToString());
        //    }
        //}

        /// <summary>
		/// Load all databases in SQL project database 
		/// </summary>
		/// 
        private void LoadProjectDatabasesFromSQLDatabase()
        {
            _tblProject = new tblProject(this, ProjectName);
            _tblProject.ProjectName = ProjectName;
            _tblProject.ServerName = _sqlservername;
            _tblProject.ProjectPath = ProjectPath;
            _tblProject.Serialize();
            _tblProject.Select();
            mainfrm.propertyGridComponemt.SelectedObject = _tblProject;
        }
        /// <summary>
		/// Open parent
		/// </summary>
		/// 
		public void OpenProject()
		{
			string path;
			bool m_StartAgain = false;
			NewProjectForm frmnewproject = new NewProjectForm(New_Open_Project_Form.Open_Project_Form);
			DialogResult dialogResult;


			m_StartAgain = false;
			dialogResult = frmnewproject.ShowDialog();
			if (dialogResult == DialogResult.OK)
			{

				// path = frmnewproject.textboxServerName.Text + "\\" + frmnewproject.textboxProjectName.Text;
				ProjectName = frmnewproject.textboxProjectName.Text;
				SQLServerIPAddress = frmnewproject.textboxServerName.Text;
				ProjectPath = "\\\\" + SQLServerIPAddress + "\\DCS Project\\" + ProjectName;

			}
			else
			{
				_EWS_Status = EWS_Status.No_Project_Is_Loaded;

			}


			if (m_StartAgain == false)
			{
				string str = frmnewproject.textboxServerName.Text;

				path = frmnewproject.textboxServerName.Text + "\\" + frmnewproject.textboxProjectName.Text;

				ProjectName = frmnewproject.textboxProjectName.Text;
				ProjectPath = frmnewproject.textboxServerName.Text;
				try
				{

					//m_ConnectionString = "Server=\\\\192.168.2.27\\SQLEXPRESS;Initial Catalog=" + ProjectName + ";User ID=sa;Pwd=123456;";
					SqlConnectionStringBuilder tmpconn = new SqlConnectionStringBuilder();
					tmpconn.DataSource = _sqlservername;
					tmpconn.Password = "eng";
					tmpconn.UserID = "sa";
					tmpconn.InitialCatalog = ProjectName;
					ConnectionString = tmpconn.ConnectionString;
					_SqlConnectionGlobalConnection = new SqlConnection(ConnectionString);

				}
				catch (Exception)
				{
					MessageBox.Show("database can not be created.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					_SqlConnectionGlobalConnection.Close();
					return;
				}
				//m_Project
				//m_Blocks.AddRoot("Blocks", 10, m_Blocks.DisplayMenu);
				// m_Displays.AddRoot("Displays", 10, m_Displays.DisplayMenu);
				//m_Sysconfig.AddRoot("Project", (int)_IMAGELIST._IMAGELIST_8_PROJECT, null);
				//m_Users.AddRoot("Users", (int)_IMAGELIST._IMAGELIST_2_USERS, m_Users.UserRootManu);
				//m_Reports.AddRoot("Reports", (int)_IMAGELIST._IMAGELIST_28_REPORTROOT, m_Reports.contextMenuSripProjectReport);

				//m_PointQuery.Show(dockPanel);


				//EWS_Ver6.ProjectClasses.Project.ProjectPath = newDialog.ProjectPath.Text + "\\" + newDialog.ProjectName.Text;

				//CloseProjectItem.Enabled = true;
				//uDefFunctions.Enabled = true;

				//LoadFromISALib();
				//FillBoardGroups();
				//FillUserDefFunctions();

				//ListviewProject.Items.Add(m_DCSProject.ProjectName);
				//ListviewDisplay.Items.Add(m_DCSProject.ProjectName);
				//ListviewUser.Items.Add(m_DCSProject.ProjectName);
				//ListviewReport.Items.Add(m_DCSProject.ProjectName);
				//ListviewBlock.Items.Add(m_DCSProject.ProjectName);
				//ListviewProgram.Items.Add(m_DCSProject.ProjectName);
				////drawingCanvas.Subscribe(mProperyGrid);
				//drawingCanvas._WpfProperty = mProperyGrid;
				// mProperyGrid.SelectedObject = (object)drawingCanvas;
			}
            //m_Project.ProjectName = ProjectName;
            //m_Project.Serialize();
            LoadProjectDatabasesFromSQLDatabase();
		}
		//private void CreateDB(string _ProjectPath, string _ProjectName)
		private void CreateDB()
		{
			//SqlConnectionStringBuilder tmpconn = new SqlConnectionStringBuilder();
			//        tmpconn.DataSource = SQLServerName + "\\ENGINEERING";
			//        tmpconn.Password = "eng";
			//        tmpconn.UserID = "sa";
			//m_ConnectionString= tmpconn.ToString();

			// Create a connection
			_SqlConnectionGlobalConnection = new SqlConnection(ConnectionString);
			// Open the connection
			if (_SqlConnectionGlobalConnection.State != System.Data.ConnectionState.Open)
			{
				_SqlConnectionGlobalConnection.Open();
			}
			string str = "CREATE DATABASE " + ProjectName + " ON PRIMARY " +
						"(NAME = " + ProjectName + "_Data, " +
						"FILENAME = '" + ProjectPath + "\\" + ProjectName + ".mdf', " +
						"SIZE = 20MB, MAXSIZE = 100MB, FILEGROWTH = 10%) " +
						"LOG ON (NAME = " + ProjectName + "_Log, " +
						"FILENAME = '" + ProjectPath + "\\" + ProjectName + ".ldf', " +
						"SIZE = 1MB, " +
						"MAXSIZE = 5MB, " +
						"FILEGROWTH = 10%)";
			// m_ConnectionString = "Data Source=\\\\192.168.2.27\\ENGINEERING;Initial Catalog=;User ID=sa;Pwd=eng;";
			ExecuteSQLStmt(str);
			//tmpconn.InitialCatalog = ProjectName;
			//m_ConnectionString= tmpconn.ToString();

		}

		public void CreateTable(string sql)
		{
			// Open the connection
			if (_SqlConnectionGlobalConnection.State == System.Data.ConnectionState.Open)
				_SqlConnectionGlobalConnection.Close();

			_SqlConnectionGlobalConnection.ConnectionString = ConnectionString;
			_SqlConnectionGlobalConnection.Open();

			SqlCommand cmd = new SqlCommand(sql, _SqlConnectionGlobalConnection);
			try
			{
				cmd.ExecuteNonQuery();
				
			}
			catch (SqlException ae)
			{
				MessageBox.Show(ae.Message.ToString());
			}
		}

		private void ExecuteSQLStmt(string sql)
		{

			if (_SqlConnectionGlobalConnection.State == System.Data.ConnectionState.Open)
				_SqlConnectionGlobalConnection.Close();
			_SqlConnectionGlobalConnection.ConnectionString = ConnectionString;
			_SqlConnectionGlobalConnection.Open();
			SqlCommand m_cmd = new SqlCommand(sql, _SqlConnectionGlobalConnection);
			try
			{
				m_cmd.ExecuteNonQuery();
				m_cmd.Dispose();
			}
			catch (SqlException ae)
			{
				MessageBox.Show(ae.Message.ToString());
			}
		}

		// This method creates a new SQL Server database

		private bool CheckCapacity(string path)
		{
			bool ret = true;
			//string letter = path.Substring(0, 2);

			//SelectQuery query = new SelectQuery("select name, FreeSpace from win32_logicaldisk where name = '" + letter + "'");
			//ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);

			//foreach (ManagementObject mo in searcher.Get())
			//{
			//    if (mo["FreeSpace"] != null)
			//    {
			//        if ((ulong)(mo["FreeSpace"]) > 1024 * 1024)
			//        {
			//            ret = true;
			//            break;
			//        }
			//    }
			//}

			//if (!ret)
			//{
			//    if (MessageBox.Show("This Partition has not enough free space. Are you sure to continue?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
			//        ret = true;
			//}

			return ret;
		}

		private void Project()
		{
			CreateTable("Create Table tblProject([ProjectName] Varchar(50) PRIMARY KEY, " +
            "[IsNetworkRedundant] bit default(1)," +
            "[ServerRedundancy] bit default(0), " +
            "[ILConDAS] bit default(0), " +
            "[HistoricalServer] bit default(1), " +
            "[ServerName] Varchar(50), " +
            "[ProjectPath] Varchar(120), " +
            "[LogEnabled] bit default(1))");

		}

		private void Domain()
		{
			CreateTable("Create Table tblDomain([DomainName] Varchar(50) ," +
            "[Description] Varchar(120), " +
            "[DomainNo] int ," +
            "[oIndex] int ," +
            "[ProjectName] Varchar(50)," +
            "PRIMARY KEY(DomainName)," + 
            "FOREIGN KEY (ProjectName) References tblProject(ProjectName) on delete cascade on update cascade)");
		}

		private void Controller()
		{
			CreateTable("Create Table tblController([ControllerName] Varchar(50) ," +
                "[DomainName] Varchar(50)," +
                "[NodeNumber] int ," +
                "[oIndex] int ," +
				"[Description] Varchar(120) ," +
                "[Redundant] bit default(1)," +
                "[TargetType] int default(0)," +
                "[SlowCycleTime] int default(1000), " +
                "[NormalCycleTime] int default(100), " +
                "[FastCycleTime] int default(10)," +
                "PRIMARY KEY(ControllerName,DomainName)," +
                "FOREIGN KEY (DomainName) References tblDomain(DomainName) on delete cascade on update cascade," +
                ")");

		}
		private void Rack()
		{
     		CreateTable("Create Table tblIORack([IORackName] Varchar(50) NOT NULL,"+
                "[ControllerName] Varchar(50)  , " +
                "[DomainName] Varchar(50)," +
                "[oIndex] int ," +
                "[NoOfSlots] int default(20), " +
                "[EngagedSlots] int default(0)," +
                "[IORackNo] int," +
                "CONSTRAINT Engaged_Slot_Exists CHECK(NoOfSlots >= 0 AND NoOfSlots <= 21 AND EngagedSlots <= (2 ^ NoOfSlots - 1))," +
                "PRIMARY KEY(IORackName, ControllerName,DomainName), " +
                "FOREIGN KEY (ControllerName,DomainName) References tblController(ControllerName,DomainName) on delete cascade on update cascade" +
                ")");
		}

		private void Board()
		{
			CreateTable("Create Table tblBoard([BoardName] Varchar(50), " +
            "[DomainName] Varchar(50)," +
            "[ControllerName] varchar(50), " +
            "[IORackName] Varchar(50), " +
            "[oIndex] int ," +
            "[Description] Varchar(120)," +
			"[BoardGroup] int, " +
            "[Type] Varchar(50), " +
            "[SlotNo1] int, " +
            "[SlotNo2] int, " +
            "[BoardNo] int IDENTITY, " +
            "[ScanTime] int default(100), " +
            "[MBA] Varchar(50) default('e10000'), " +
            "[Redundant] bit default(0), " +
            "PRIMARY KEY(BoardName, IORackName,ControllerName,DomainName), " +
            "FOREIGN KEY (IORackName,ControllerName,DomainName) References tblIORack(IORackName,ControllerName,DomainName) on delete cascade on update cascade" +
            ")");
		}

        private void Program()
        {
            CreateTable("Create Table tblProgram([ProgramName] Varchar(50) NOT NULL, " +
            "[ControllerName] varchar(50), " +
            "[DomainName] Varchar(50)," +
            "[Description] Varchar(120) NOT NULL, " +
            "[oIndex] int, " +
            "[CycleTime] int default(1000), " +
            "[Type] int NOT NULL, " +
            "[CycleGroup] int " +
            "PRIMARY KEY(ProgramName, ControllerName,DomainName), " +
            "FOREIGN KEY (ControllerName,DomainName) References tblController(ControllerName,DomainName) on delete cascade on update cascade" +  
            ")");

        }

        private void Function()
        {
            CreateTable("Create Table tblFunction([FunctionName] Varchar(50) , " +
                "[Description] Varchar(120) , " +
                "[FunctionGroup] int , " +
                "[Extensible] bit default(0)," +
                "[IsFunction] bit default(1)," +
                "PRIMARY KEY (FunctionName)" +
                ")");

        }
        
        private void Pin()
        {
            CreateTable("Create Table tblPin([PinName] Varchar(50), " +
                "[FunctionName] Varchar(50) , " +
                "[Type] int default(0) NOT NULL, " +
                "[Class] int default(0) NOT NULL, " +
                "[Extensible] bit default(1)," +
                "[oIndex] int ," +
                "[Description] Varchar(120) , " +
                "PRIMARY KEY(PinName, FunctionName), " +
                "FOREIGN KEY (FunctionName) References tblFunction(FunctionName) on delete cascade on update cascade" +
                ")");

        }

        private void VariableType()
        {
            CreateTable("Create Table tblVarType([TypeName] Varchar(50), " +
                "[ParentName] Varchar(50) , " +
                "[Generic] int default(0) NOT NULL, " +
                "[Value] int ," +
                "[Description] Varchar(120) , " +
                "PRIMARY KEY(TypeName), " +
                ")");

        }
        //private void FillStandardFunction( string _functionname, VarType _returntype, string _description, FunctionGroup _functiongroup, bool _standard)
        //{
        //    tblFunction tblfunction = new tblFunction(_tblProject, _functionname, _returntype, _description, _functiongroup, _standard);
        //    tblfunction.Insert();
        //    _tblProject.tblFunctionCollection.Add(tblfunction);
        //}
        //private void FillStandardFunctionPins(string _pinname, int _type, int _class, bool _extensible, int oindex, string _description)
        //{
        //    tblPin tblpin = new tblPin(_tblProject, _functionname, _returntype, _description, _functiongroup, _standard);
        //    tblpin.Insert();
            
        //}

        private void FillDatabaseForTheFirstTime()
        {
            tblProject.InsertProject(ConnectionString, ProjectName, true, false, false, true, SQLServerIPAddress, ProjectPath, false);
            FillStandardFunctions();
        }
        private void FillStandardFunctions()
        {
            tblFunction.InsertFunction(ConnectionString, "_TO_", "Data type conversion", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN1", "_TO_", VarType.ANY, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "_TO_", VarType.ANY, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "_TO_BCD", "Conversion to BCD", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN1", "_TO_BCD", VarType.ANY_INT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "_TO_BCD", VarType.ANY_BIT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "ABS", "Absolute number", FunctionGroup.NUMERICAL, false, true);
            tblPin.InsertPin(ConnectionString, "IN1", "ABS", VarType.ANY_NUM, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "ABS", VarType.ANY_NUM, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "ACOS", "Arc cosine", FunctionGroup.NUMERICAL, false, true);
            tblPin.InsertPin(ConnectionString, "IN1", "ACOS", VarType.ANY_REAL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "ACOS", VarType.ANY_REAL, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "ADD", "Addition", FunctionGroup.ARITHMETIC, true, true);
            tblPin.InsertPin(ConnectionString, "IN", "ADD", VarType.ANY_NUM, VarClass.Input, true, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "ADD", VarType.ANY_NUM, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "ADD_DT_TIME", "Date addition", FunctionGroup.TIME, false, true);
            tblPin.InsertPin(ConnectionString, "IN1", "ADD_DT_TIME", VarType.DT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "IN2", "ADD_DT_TIME", VarType.TIME, VarClass.Input, false, 1, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "ADD_DT_TIME", VarType.DT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "ADD_TIME", "Time addition", FunctionGroup.TIME, false, true);
            tblPin.InsertPin(ConnectionString, "IN1", "ADD_TIME", VarType.TIME, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "IN2", "ADD_TIME", VarType.TIME, VarClass.Input, false, 1, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "ADD_TIME", VarType.TIME, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "ADD_TOD_TIME", "Time-of-day addition", FunctionGroup.TIME, false, true);
            tblPin.InsertPin(ConnectionString, "IN1", "ADD_TOD_TIME", VarType.TOD, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "IN2", "ADD_TOD_TIME", VarType.TIME, VarClass.Input, false, 1, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "ADD_TOD_TIME", VarType.TOD, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "AND", "Bitwise AND", FunctionGroup.BITWISE, true, true);
            tblPin.InsertPin(ConnectionString, "IN", "AND", VarType.ANY_BIT, VarClass.Input, true, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "AND", VarType.ANY_BIT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "ASIN", "Arc sine", FunctionGroup.NUMERICAL, false, true);
            tblPin.InsertPin(ConnectionString, "IN1", "ASIN", VarType.ANY_REAL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "ASIN", VarType.ANY_REAL, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "ATAN", "Arc tangent", FunctionGroup.NUMERICAL, false, true);
            tblPin.InsertPin(ConnectionString, "IN1", "ATAN", VarType.ANY_REAL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "ATAN", VarType.ANY_REAL, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "BCD_TO_", "Conversion from BCD", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN1", "BCD_TO_", VarType.ANY_BIT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "BCD_TO_", VarType.ANY_INT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "CONCAT", "Concatenation", FunctionGroup.CHARACTER_STRING, true, true);
            tblPin.InsertPin(ConnectionString, "IN", "CONCAT", VarType.STRING, VarClass.Input, true, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "CONCAT", VarType.STRING, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "CONCAT_DAT_TOD", "Time concatenation", FunctionGroup.CHARACTER_STRING, false, true);
            tblPin.InsertPin(ConnectionString, "IN1", "CONCAT_DAT_TOD", VarType.DATE, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "IN2", "CONCAT_DAT_TOD", VarType.TOD, VarClass.Input, false, 1, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "CONCAT_DAT_TOD", VarType.DT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "COS", "Cosine", FunctionGroup.NUMERICAL, false, true);
            tblPin.InsertPin(ConnectionString, "IN1", "COS", VarType.ANY_REAL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "COS", VarType.ANY_REAL, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "DATE_AND_TIME_TO_DATE", "Conversion to date", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN1", "DATE_AND_TIME_TO_DATE", VarType.DT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "DATE_AND_TIME_TO_DATE", VarType.DATE, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "DATE_AND_TIME_TO_TIME_OF_DAY", "Conversion to time-of-day", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN1", "DATE_AND_TIME_TO_TIME_OF_DAY", VarType.DT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "DATE_AND_TIME_TO_TIME_OF_DAY", VarType.TOD, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "DELETE", "Deletion (within)", FunctionGroup.CHARACTER_STRING, false, true);
            tblPin.InsertPin(ConnectionString, "IN1", "DELETE", VarType.STRING, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "L", "DELETE", VarType.INT, VarClass.Input, false, 1, " ");
            tblPin.InsertPin(ConnectionString, "P", "DELETE", VarType.INT, VarClass.Input, false, 2, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "DELETE", VarType.STRING, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "DIV", "Division", FunctionGroup.ARITHMETIC, false, true);
            tblPin.InsertPin(ConnectionString, "IN1", "DIV", VarType.ANY_NUM, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "IN2", "DIV", VarType.ANY_NUM, VarClass.Input, false, 1, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "DIV", VarType.ANY_NUM, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "DIVTIME", "Time division", FunctionGroup.TIME, false, true);
            tblPin.InsertPin(ConnectionString, "IN1", "DIVTIME", VarType.TIME, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "IN2", "DIVTIME", VarType.ANY_NUM, VarClass.Input, false, 1, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "DIVTIME", VarType.TIME, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "EQ", "Equal to", FunctionGroup.COMPARISON, true, true);
            tblPin.InsertPin(ConnectionString, "IN", "EQ", VarType.ANY, VarClass.Input, true, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "EQ", VarType.BOOL, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "EXP", "Exponentiation", FunctionGroup.NUMERICAL, false, true);
            tblPin.InsertPin(ConnectionString, "IN1", "EXP", VarType.ANY_REAL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "EXP", VarType.ANY_REAL, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "EXPT", "Exponent", FunctionGroup.ARITHMETIC, false, true);
            tblPin.InsertPin(ConnectionString, "IN1", "EXPT", VarType.ANY_REAL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "IN2", "EXPT", VarType.ANY_NUM, VarClass.Input, false, 1, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "EXPT", VarType.ANY_REAL, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "FIND", "Find position", FunctionGroup.CHARACTER_STRING, false, true);
            tblPin.InsertPin(ConnectionString, "IN1", "FIND", VarType.STRING, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "IN2", "FIND", VarType.STRING, VarClass.Input, false, 1, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "FIND", VarType.INT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "GE", "Greater than or equal to", FunctionGroup.COMPARISON, true, true);
            tblPin.InsertPin(ConnectionString, "IN", "GE", VarType.ANY, VarClass.Input, true, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "GE", VarType.BOOL, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "GT", "Greater than", FunctionGroup.COMPARISON, true, true);
            tblPin.InsertPin(ConnectionString, "IN", "GT", VarType.ANY, VarClass.Input, true, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "GT", VarType.BOOL, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "INSERT", "Insertion (into)", FunctionGroup.CHARACTER_STRING, false, true);
            tblPin.InsertPin(ConnectionString, "IN1", "INSERT", VarType.STRING, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "IN2", "INSERT", VarType.STRING, VarClass.Input, false, 1, " ");
            tblPin.InsertPin(ConnectionString, "P", "INSERT", VarType.INT, VarClass.Input, false, 2, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "INSERT", VarType.STRING, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "LE", "Less than or equal to", FunctionGroup.COMPARISON, true, true);
            tblPin.InsertPin(ConnectionString, "IN", "LE", VarType.ANY, VarClass.Input, true, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "LE", VarType.BOOL, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "LEFT", "string left of", FunctionGroup.CHARACTER_STRING, false, true);
            tblPin.InsertPin(ConnectionString, "IN1", "LEFT", VarType.STRING, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "L", "LEFT", VarType.INT, VarClass.Input, false, 1, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "LEFT", VarType.STRING, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "LEN", "Length of string", FunctionGroup.CHARACTER_STRING, false, true);
            tblPin.InsertPin(ConnectionString, "IN1", "LEN", VarType.STRING, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "LEN", VarType.INT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "LIMIT", "Limitation", FunctionGroup.SELECTION, false, true);
            tblPin.InsertPin(ConnectionString, "MN", "LIMIT", VarType.INT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "IN2", "LIMIT", VarType.ANY, VarClass.Input, false, 1, " ");
            tblPin.InsertPin(ConnectionString, "MX", "LIMIT", VarType.INT, VarClass.Input, false, 2, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "LIMIT", VarType.ANY, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "LN", "Natural logarithm", FunctionGroup.NUMERICAL, false, true);
            tblPin.InsertPin(ConnectionString, "IN1", "LN", VarType.ANY_REAL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "LN", VarType.ANY_REAL, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "LOG", "Logarithm to base 10", FunctionGroup.NUMERICAL, false, true);
            tblPin.InsertPin(ConnectionString, "IN1", "LOG", VarType.ANY_REAL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "LOG", VarType.ANY_REAL, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "LT", "Less than", FunctionGroup.COMPARISON, true, true);
            tblPin.InsertPin(ConnectionString, "IN", "LT", VarType.ANY, VarClass.Input, true, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "LT", VarType.BOOL, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "MAX", "Maximum", FunctionGroup.SELECTION, true, true);
            tblPin.InsertPin(ConnectionString, "IN", "MAX", VarType.ANY, VarClass.Input, true, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "MAX", VarType.ANY, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "MID", "string from the middle", FunctionGroup.CHARACTER_STRING, false, true);
            tblPin.InsertPin(ConnectionString, "IN1", "MID", VarType.STRING, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "L", "MID", VarType.INT, VarClass.Input, false, 1, " ");
            tblPin.InsertPin(ConnectionString, "O", "MID", VarType.INT, VarClass.Input, false, 2, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "MID", VarType.STRING, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "MIN", "Minimum", FunctionGroup.SELECTION, true, true);
            tblPin.InsertPin(ConnectionString, "IN", "MIN", VarType.ANY, VarClass.Input, true, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "MIN", VarType.ANY, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "MOD", "Remainder (modulo)", FunctionGroup.ARITHMETIC, false, true);
            tblPin.InsertPin(ConnectionString, "IN1", "MOD", VarType.ANY_INT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "IN2", "MOD", VarType.ANY_INT, VarClass.Input, false, 1, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "MOD", VarType.ANY_INT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "MOVE", "Assignment", FunctionGroup.ARITHMETIC, false, true);
            tblPin.InsertPin(ConnectionString, "IN1", "MOVE", VarType.ANY, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "MOVE", VarType.ANY, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "MUL", "Multiplication", FunctionGroup.ARITHMETIC, true, true);
            tblPin.InsertPin(ConnectionString, "IN", "MUL", VarType.ANY_NUM, VarClass.Input, true, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "MUL", VarType.ANY_NUM, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "MULTIME", "Time multiplication", FunctionGroup.TIME, false, true);
            tblPin.InsertPin(ConnectionString, "IN1", "MULTIME", VarType.TIME, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "IN2", "MULTIME", VarType.ANY_NUM, VarClass.Input, false, 1, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "MULTIME", VarType.TIME, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "MUX", "Multiplexer (select 1 of N)", FunctionGroup.SELECTION, true, true);
            tblPin.InsertPin(ConnectionString, "K", "MUX", VarType.ANY_INT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "IN", "MUX", VarType.ANY, VarClass.Input, true, 1, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "MUX", VarType.ANY, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "NE", "Not equal to", FunctionGroup.COMPARISON, false, true);
            tblPin.InsertPin(ConnectionString, "IN1", "NE", VarType.ANY, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "IN2", "NE", VarType.ANY, VarClass.Input, false, 1, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "NE", VarType.BOOL, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "NOT", "Bitwise inverting", FunctionGroup.BITWISE, false, true);
            tblPin.InsertPin(ConnectionString, "IN1", "NOT", VarType.ANY_BIT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "NOT", VarType.ANY_BIT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "OR", "Bitwise OR", FunctionGroup.BITWISE, true, true);
            tblPin.InsertPin(ConnectionString, "IN", "OR", VarType.ANY_BIT, VarClass.Input, true, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "OR", VarType.ANY_BIT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "REPLACE", "Replacement (within)", FunctionGroup.CHARACTER_STRING, false, true);
            tblPin.InsertPin(ConnectionString, "IN1", "REPLACE", VarType.STRING, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "IN2", "REPLACE", VarType.STRING, VarClass.Input, false, 1, " ");
            tblPin.InsertPin(ConnectionString, "L", "REPLACE", VarType.ANY_INT, VarClass.Input, false, 2, " ");
            tblPin.InsertPin(ConnectionString, "P", "REPLACE", VarType.ANY_INT, VarClass.Input, false, 3, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "REPLACE", VarType.STRING, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "RIGHT", "string right of", FunctionGroup.CHARACTER_STRING, false, true);
            tblPin.InsertPin(ConnectionString, "IN1", "RIGHT", VarType.STRING, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "L", "RIGHT", VarType.ANY_INT, VarClass.Input, false, 1, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "RIGHT", VarType.STRING, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "ROL", "Rotate left", FunctionGroup.BIT_SHIFT, false, true);
            tblPin.InsertPin(ConnectionString, "IN1", "ROL", VarType.ANY_BIT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "N", "ROL", VarType.ANY_INT, VarClass.Input, false, 1, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "ROL", VarType.ANY_BIT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "ROR", "Rotate right", FunctionGroup.BIT_SHIFT, false, true);
            tblPin.InsertPin(ConnectionString, "IN1", "ROR", VarType.ANY_BIT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "N", "ROR", VarType.ANY_INT, VarClass.Input, false, 1, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "ROR", VarType.ANY_BIT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "SEL", "Binary selection (1 of 2)", FunctionGroup.SELECTION, false, true);
            tblPin.InsertPin(ConnectionString, "G", "SEL", VarType.BOOL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "IN0", "SEL", VarType.ANY, VarClass.Input, false, 1, " ");
            tblPin.InsertPin(ConnectionString, "IN1", "SEL", VarType.ANY, VarClass.Input, false, 2, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "SEL", VarType.ANY, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "SHL", "Shift left", FunctionGroup.BIT_SHIFT, false, true);
            tblPin.InsertPin(ConnectionString, "IN1", "SHL", VarType.ANY_BIT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "N", "SHL", VarType.ANY_INT, VarClass.Input, false, 1, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "SHL", VarType.ANY_BIT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "SHR", "Shift right", FunctionGroup.BIT_SHIFT, false, true);
            tblPin.InsertPin(ConnectionString, "IN1", "SHR", VarType.ANY_BIT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "N", "SHR", VarType.ANY_INT, VarClass.Input, false, 1, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "SHR", VarType.ANY_BIT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "SIN", "Sine", FunctionGroup.NUMERICAL, false, true);
            tblPin.InsertPin(ConnectionString, "IN1", "SIN", VarType.ANY_REAL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "SIN", VarType.ANY_REAL, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "SQRT", "Square root (base 2)", FunctionGroup.NUMERICAL, false, true);
            tblPin.InsertPin(ConnectionString, "IN1", "SQRT", VarType.ANY_REAL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "SQRT", VarType.ANY_REAL, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "SUB", "Subtraction", FunctionGroup.ARITHMETIC, false, true);
            tblPin.InsertPin(ConnectionString, "IN1", "SUB", VarType.ANY_NUM, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "IN2", "SUB", VarType.ANY_NUM, VarClass.Input, false, 1, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "SUB", VarType.ANY_NUM, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "SUB_DATE", "Date subtraction", FunctionGroup.TIME, false, true);
            tblPin.InsertPin(ConnectionString, "IN1", "SUB_DATE", VarType.DATE, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "IN2", "SUB_DATE", VarType.DATE, VarClass.Input, false, 1, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "SUB_DATE", VarType.TIME, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "SUB_DT", "Date and time subtraction", FunctionGroup.TIME, false, true);
            tblPin.InsertPin(ConnectionString, "IN1", "SUB_DT", VarType.DT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "IN2", "SUB_DT", VarType.DT, VarClass.Input, false, 1, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "SUB_DT", VarType.TIME, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "SUB_DT_TIME", "Date and time subtraction", FunctionGroup.TIME, false, true);
            tblPin.InsertPin(ConnectionString, "IN1", "SUB_DT_TIME", VarType.DT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "IN2", "SUB_DT_TIME", VarType.TIME, VarClass.Input, false, 1, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "SUB_DT_TIME", VarType.TIME, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "SUB_TIME", "Time subtraction", FunctionGroup.TIME, false, true);
            tblPin.InsertPin(ConnectionString, "IN1", "SUB_TIME", VarType.TIME, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "IN2", "SUB_TIME", VarType.TIME, VarClass.Input, false, 1, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "SUB_TIME", VarType.TIME, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "SUB_TOD_TIME", "Time-of-day subtraction", FunctionGroup.TIME, false, true);
            tblPin.InsertPin(ConnectionString, "IN1", "SUB_TOD_TIME", VarType.TOD, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "IN2", "SUB_TOD_TIME", VarType.TIME, VarClass.Input, false, 1, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "SUB_TOD_TIME", VarType.TOD, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "SUB_TOD_TOD", "Time-of-day subtraction", FunctionGroup.TIME, false, true);
            tblPin.InsertPin(ConnectionString, "IN1", "SUB_TOD_TOD", VarType.TOD, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "IN2", "SUB_TOD_TOD", VarType.TOD, VarClass.Input, false, 1, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "SUB_TOD_TOD", VarType.TIME, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "TAN", "Tangent", FunctionGroup.NUMERICAL, false, true);
            tblPin.InsertPin(ConnectionString, "IN1", "TAN", VarType.ANY_REAL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "TAN", VarType.ANY_REAL, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "TRUNC", "Rounding up/down", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN1", "TRUNC", VarType.ANY_REAL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "TRUNC", VarType.ANY_INT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "XOR", "Bitwise XOR", FunctionGroup.BITWISE, true, true);
            tblPin.InsertPin(ConnectionString, "IN", "XOR", VarType.ANY_BIT, VarClass.Input, true, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "XOR", VarType.ANY_BIT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "SR", "The SR bistable is a latch where the Set dominates.", FunctionGroup.FLIP_FLOP, false, false);
            tblPin.InsertPin(ConnectionString, "S1", "SR", VarType.BOOL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "R", "SR", VarType.BOOL, VarClass.Input, false, 1, " ");
            tblPin.InsertPin(ConnectionString, "Q1", "SR", VarType.BOOL, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "RS", "The RS bistable is a latch where the Reset dominates.", FunctionGroup.FLIP_FLOP, false, false);
            tblPin.InsertPin(ConnectionString, "S", "RS", VarType.BOOL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "R1", "RS", VarType.BOOL, VarClass.Input, false, 1, " ");
            tblPin.InsertPin(ConnectionString, "Q1", "RS", VarType.BOOL, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "SEMA", "The semaphore provides a mechanism to allow software elements mutually exclusive access to certain ressources.", FunctionGroup.ADDITIONAL, false, false);
            tblPin.InsertPin(ConnectionString, "CLAIM", "SEMA", VarType.BOOL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "RELEASE", "SEMA", VarType.BOOL, VarClass.Input, false, 1, " ");
            tblPin.InsertPin(ConnectionString, "BUSY", "SEMA", VarType.BOOL, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "R_TRIG", "The output produces a single pulse when a rising edge is detected.", FunctionGroup.EDGE_DETECTION, false, false);
            tblPin.InsertPin(ConnectionString, "CLK", "R_TRIG", VarType.BOOL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "Q", "R_TRIG", VarType.BOOL, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "F_TRIG", "The output produces a single pulse when a falling edge is detected.", FunctionGroup.EDGE_DETECTION, false, false);
            tblPin.InsertPin(ConnectionString, "CLK", "F_TRIG", VarType.BOOL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "Q", "F_TRIG", VarType.BOOL, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "CTU", "The up-counter can be used to signal when a count has reached a maximum value.", FunctionGroup.COUNTER, false, false);
            tblPin.InsertPin(ConnectionString, "CU", "CTU", VarType.BOOL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "R", "CTU", VarType.BOOL, VarClass.Input, false, 1, " ");
            tblPin.InsertPin(ConnectionString, "PV", "CTU", VarType.INT, VarClass.Input, false, 2, " ");
            tblPin.InsertPin(ConnectionString, "Q", "CTU", VarType.BOOL, VarClass.Output, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "CV", "CTU", VarType.INT, VarClass.Output, false, 1, " ");
            tblFunction.InsertFunction(ConnectionString, "CTD", "The down-counter can be used to signal when a count has reached zero  on counting down from a preset value.", FunctionGroup.COUNTER, false, false);
            tblPin.InsertPin(ConnectionString, "CD", "CTD", VarType.BOOL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "LD", "CTD", VarType.BOOL, VarClass.Input, false, 1, " ");
            tblPin.InsertPin(ConnectionString, "PV", "CTD", VarType.INT, VarClass.Input, false, 2, " ");
            tblPin.InsertPin(ConnectionString, "Q", "CTD", VarType.BOOL, VarClass.Output, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "CV", "CTD", VarType.INT, VarClass.Output, false, 1, " ");
            tblFunction.InsertFunction(ConnectionString, "CTUD", "The up-down counter can be used to both count up on one input and down on the other.", FunctionGroup.COUNTER, false, false);
            tblPin.InsertPin(ConnectionString, "CU", "CTUD", VarType.BOOL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "CD", "CTUD", VarType.BOOL, VarClass.Input, false, 1, " ");
            tblPin.InsertPin(ConnectionString, "R", "CTUD", VarType.BOOL, VarClass.Input, false, 2, " ");
            tblPin.InsertPin(ConnectionString, "LD", "CTUD", VarType.BOOL, VarClass.Input, false, 3, " ");
            tblPin.InsertPin(ConnectionString, "PV", "CTUD", VarType.INT, VarClass.Input, false, 4, " ");
            tblPin.InsertPin(ConnectionString, "QU", "CTUD", VarType.BOOL, VarClass.Output, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "QD", "CTUD", VarType.BOOL, VarClass.Output, false, 1, " ");
            tblPin.InsertPin(ConnectionString, "CV", "CTUD", VarType.INT, VarClass.Output, false, 2, " ");
            tblFunction.InsertFunction(ConnectionString, "TP", "The pulse timer can be used to generate output pulses of a given time duration.", FunctionGroup.TIMER, false, false);
            tblPin.InsertPin(ConnectionString, "IN", "TP", VarType.BOOL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "PT", "TP", VarType.TIME, VarClass.Input, false, 1, " ");
            tblPin.InsertPin(ConnectionString, "Q", "TP", VarType.BOOL, VarClass.Output, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "ET", "TP", VarType.TIME, VarClass.Output, false, 1, " ");
            tblFunction.InsertFunction(ConnectionString, "TON", "The on-delay timer can be used to delay setting an output true  for fixed period after an input becomes true.", FunctionGroup.TIMER, false, false);
            tblPin.InsertPin(ConnectionString, "IN", "TON", VarType.BOOL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "PT", "TON", VarType.TIME, VarClass.Input, false, 1, " ");
            tblPin.InsertPin(ConnectionString, "Q", "TON", VarType.BOOL, VarClass.Output, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "ET", "TON", VarType.TIME, VarClass.Output, false, 1, " ");
            tblFunction.InsertFunction(ConnectionString, "TOF", "The off-delay timer can be used to delay setting an output false  for fixed period after input goes false.", FunctionGroup.TIMER, false, false);
            tblPin.InsertPin(ConnectionString, "IN", "TOF", VarType.BOOL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "PT", "TOF", VarType.TIME, VarClass.Input, false, 1, " ");
            tblPin.InsertPin(ConnectionString, "Q", "TOF", VarType.BOOL, VarClass.Output, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "ET", "TOF", VarType.TIME, VarClass.Output, false, 1, " ");
            tblFunction.InsertFunction(ConnectionString, "RTC", "The real time clock has many uses including time stamping  setting dates and times of day in batch reports", FunctionGroup.ADDITIONAL, false, false);
            tblPin.InsertPin(ConnectionString, "IN", "RTC", VarType.BOOL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "PDT", "RTC", VarType.DT, VarClass.Input, false, 1, " ");
            tblPin.InsertPin(ConnectionString, "Q", "RTC", VarType.BOOL, VarClass.Output, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "CDT", "RTC", VarType.DT, VarClass.Output, false, 1, " ");
            tblFunction.InsertFunction(ConnectionString, "INTEGRAL", "The integral function block integrates the value of input XIN over time.", FunctionGroup.ADDITIONAL, false, false);
            tblPin.InsertPin(ConnectionString, "RUN", "INTEGRAL", VarType.BOOL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "R1", "INTEGRAL", VarType.BOOL, VarClass.Input, false, 1, " ");
            tblPin.InsertPin(ConnectionString, "XIN", "INTEGRAL", VarType.REAL, VarClass.Input, false, 2, " ");
            tblPin.InsertPin(ConnectionString, "X0", "INTEGRAL", VarType.REAL, VarClass.Input, false, 3, " ");
            tblPin.InsertPin(ConnectionString, "CYCLE", "INTEGRAL", VarType.TIME, VarClass.Input, false, 4, " ");
            tblPin.InsertPin(ConnectionString, "Q", "INTEGRAL", VarType.BOOL, VarClass.Output, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "XOUT", "INTEGRAL", VarType.REAL, VarClass.Output, false, 1, " ");
            tblFunction.InsertFunction(ConnectionString, "DERIVATIVE", "The derivative function block produces an output XOUT proportional to the rate of change of the input XIN.", FunctionGroup.ADDITIONAL, false, false);
            tblPin.InsertPin(ConnectionString, "RUN", "DERIVATIVE", VarType.BOOL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "XIN", "DERIVATIVE", VarType.REAL, VarClass.Input, false, 1, " ");
            tblPin.InsertPin(ConnectionString, "CYCLE", "DERIVATIVE", VarType.TIME, VarClass.Input, false, 2, " ");
            tblPin.InsertPin(ConnectionString, "XOUT", "DERIVATIVE", VarType.REAL, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "PID", "The PID proportional  Integral  Derivative function block provides controller for closed loop control.", FunctionGroup.ADDITIONAL, false, false);
            tblPin.InsertPin(ConnectionString, "AUTO", "PID", VarType.BOOL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "PV", "PID", VarType.REAL, VarClass.Input, false, 1, " ");
            tblPin.InsertPin(ConnectionString, "SP", "PID", VarType.REAL, VarClass.Input, false, 2, " ");
            tblPin.InsertPin(ConnectionString, "X0", "PID", VarType.REAL, VarClass.Input, false, 3, " ");
            tblPin.InsertPin(ConnectionString, "KP", "PID", VarType.REAL, VarClass.Input, false, 4, " ");
            tblPin.InsertPin(ConnectionString, "TR", "PID", VarType.REAL, VarClass.Input, false, 5, " ");
            tblPin.InsertPin(ConnectionString, "TD", "PID", VarType.REAL, VarClass.Input, false, 6, " ");
            tblPin.InsertPin(ConnectionString, "CYCLE", "PID", VarType.TIME, VarClass.Input, false, 7, " ");
            tblPin.InsertPin(ConnectionString, "XOUT", "PID", VarType.REAL, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "RAMP", "The RAMP function block is modelled on example given in the standard.", FunctionGroup.ADDITIONAL, false, false);
            tblPin.InsertPin(ConnectionString, "RUN", "RAMP", VarType.BOOL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "X0", "RAMP", VarType.REAL, VarClass.Input, false, 1, " ");
            tblPin.InsertPin(ConnectionString, "X1", "RAMP", VarType.REAL, VarClass.Input, false, 2, " ");
            tblPin.InsertPin(ConnectionString, "TR", "RAMP", VarType.TIME, VarClass.Input, false, 3, " ");
            tblPin.InsertPin(ConnectionString, "CYCLE", "RAMP", VarType.TIME, VarClass.Input, false, 4, " ");
            tblPin.InsertPin(ConnectionString, "BUSY", "RAMP", VarType.BOOL, VarClass.Output, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "XOUT", "RAMP", VarType.REAL, VarClass.Output, false, 1, " ");
            tblFunction.InsertFunction(ConnectionString, "HYSTERESIS", "The hysteresis function block provides a hysteresis boolean output driven by the difference of two floating points.", FunctionGroup.ADDITIONAL, false, false);
            tblPin.InsertPin(ConnectionString, "XIN1", "HYSTERESIS", VarType.REAL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "XIN2", "HYSTERESIS", VarType.REAL, VarClass.Input, false, 1, " ");
            tblPin.InsertPin(ConnectionString, "EPS", "HYSTERESIS", VarType.REAL, VarClass.Input, false, 2, " ");
            tblPin.InsertPin(ConnectionString, "Q", "HYSTERESIS", VarType.BOOL, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "BYTE_TO_REAL", "Convert BYTE to REAL", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "BYTE_TO_REAL", VarType.BYTE, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "BYTE_TO_REAL", VarType.REAL, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "BYTE_TO_LREAL", "Convert BYTE to LREAL", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "BYTE_TO_LREAL", VarType.BYTE, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "BYTE_TO_LREAL", VarType.LREAL, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "BYTE_TO_SINT", "Convert BYTE to SINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "BYTE_TO_SINT", VarType.BYTE, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "BYTE_TO_SINT", VarType.SINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "BYTE_TO_INT", "Convert BYTE to INT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "BYTE_TO_INT", VarType.BYTE, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "BYTE_TO_INT", VarType.INT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "BYTE_TO_DINT", "Convert BYTE to DINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "BYTE_TO_DINT", VarType.BYTE, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "BYTE_TO_DINT", VarType.DINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "BYTE_TO_LINT", "Convert BYTE to LINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "BYTE_TO_LINT", VarType.BYTE, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "BYTE_TO_LINT", VarType.LINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "BYTE_TO_USINT", "Convert BYTE to USINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "BYTE_TO_USINT", VarType.BYTE, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "BYTE_TO_USINT", VarType.USINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "BYTE_TO_UINT", "Convert BYTE to UINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "BYTE_TO_UINT", VarType.BYTE, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "BYTE_TO_UINT", VarType.UINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "BYTE_TO_UDINT", "Convert BYTE to UDINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "BYTE_TO_UDINT", VarType.BYTE, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "BYTE_TO_UDINT", VarType.UDINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "BYTE_TO_ULINT", "Convert BYTE to ULINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "BYTE_TO_ULINT", VarType.BYTE, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "BYTE_TO_ULINT", VarType.ULINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "WORD_TO_REAL", "Convert WORD to REAL", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "WORD_TO_REAL", VarType.WORD, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "WORD_TO_REAL", VarType.REAL, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "WORD_TO_LREAL", "Convert WORD to LREAL", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "WORD_TO_LREAL", VarType.WORD, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "WORD_TO_LREAL", VarType.LREAL, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "WORD_TO_SINT", "Convert WORD to SINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "WORD_TO_SINT", VarType.WORD, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "WORD_TO_SINT", VarType.SINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "WORD_TO_INT", "Convert WORD to INT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "WORD_TO_INT", VarType.WORD, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "WORD_TO_INT", VarType.INT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "WORD_TO_DINT", "Convert WORD to DINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "WORD_TO_DINT", VarType.WORD, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "WORD_TO_DINT", VarType.DINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "WORD_TO_LINT", "Convert WORD to LINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "WORD_TO_LINT", VarType.WORD, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "WORD_TO_LINT", VarType.LINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "WORD_TO_USINT", "Convert WORD to USINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "WORD_TO_USINT", VarType.WORD, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "WORD_TO_USINT", VarType.USINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "WORD_TO_UINT", "Convert WORD to UINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "WORD_TO_UINT", VarType.WORD, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "WORD_TO_UINT", VarType.UINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "WORD_TO_UDINT", "Convert WORD to UDINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "WORD_TO_UDINT", VarType.WORD, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "WORD_TO_UDINT", VarType.UDINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "WORD_TO_ULINT", "Convert WORD to ULINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "WORD_TO_ULINT", VarType.WORD, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "WORD_TO_ULINT", VarType.ULINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "DWORD_TO_REAL", "Convert DWORD to REAL", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "DWORD_TO_REAL", VarType.DWORD, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "DWORD_TO_REAL", VarType.REAL, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "DWORD_TO_LREAL", "Convert DWORD to LREAL", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "DWORD_TO_LREAL", VarType.DWORD, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "DWORD_TO_LREAL", VarType.LREAL, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "DWORD_TO_SINT", "Convert DWORD to SINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "DWORD_TO_SINT", VarType.DWORD, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "DWORD_TO_SINT", VarType.SINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "DWORD_TO_INT", "Convert DWORD to INT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "DWORD_TO_INT", VarType.DWORD, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "DWORD_TO_INT", VarType.INT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "DWORD_TO_DINT", "Convert DWORD to DINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "DWORD_TO_DINT", VarType.DWORD, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "DWORD_TO_DINT", VarType.DINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "DWORD_TO_LINT", "Convert DWORD to LINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "DWORD_TO_LINT", VarType.DWORD, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "DWORD_TO_LINT", VarType.LINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "DWORD_TO_USINT", "Convert DWORD to USINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "DWORD_TO_USINT", VarType.DWORD, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "DWORD_TO_USINT", VarType.USINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "DWORD_TO_UINT", "Convert DWORD to UINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "DWORD_TO_UINT", VarType.DWORD, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "DWORD_TO_UINT", VarType.UINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "DWORD_TO_UDINT", "Convert DWORD to UDINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "DWORD_TO_UDINT", VarType.DWORD, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "DWORD_TO_UDINT", VarType.UDINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "DWORD_TO_ULINT", "Convert DWORD to ULINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "DWORD_TO_ULINT", VarType.DWORD, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "DWORD_TO_ULINT", VarType.ULINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "LWORD_TO_REAL", "Convert LWORD to REAL", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "LWORD_TO_REAL", VarType.LWORD, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "LWORD_TO_REAL", VarType.REAL, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "LWORD_TO_LREAL", "Convert LWORD to LREAL", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "LWORD_TO_LREAL", VarType.LWORD, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "LWORD_TO_LREAL", VarType.LREAL, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "LWORD_TO_SINT", "Convert LWORD to SINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "LWORD_TO_SINT", VarType.LWORD, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "LWORD_TO_SINT", VarType.SINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "LWORD_TO_INT", "Convert LWORD to INT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "LWORD_TO_INT", VarType.LWORD, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "LWORD_TO_INT", VarType.INT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "LWORD_TO_DINT", "Convert LWORD to DINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "LWORD_TO_DINT", VarType.LWORD, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "LWORD_TO_DINT", VarType.DINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "LWORD_TO_LINT", "Convert LWORD to LINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "LWORD_TO_LINT", VarType.LWORD, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "LWORD_TO_LINT", VarType.LINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "LWORD_TO_USINT", "Convert LWORD to USINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "LWORD_TO_USINT", VarType.LWORD, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "LWORD_TO_USINT", VarType.USINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "LWORD_TO_UINT", "Convert LWORD to UINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "LWORD_TO_UINT", VarType.LWORD, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "LWORD_TO_UINT", VarType.UINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "LWORD_TO_UDINT", "Convert LWORD to UDINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "LWORD_TO_UDINT", VarType.LWORD, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "LWORD_TO_UDINT", VarType.UDINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "LWORD_TO_ULINT", "Convert LWORD to ULINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "LWORD_TO_ULINT", VarType.LWORD, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "LWORD_TO_ULINT", VarType.ULINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "BOOL_TO_REAL", "Convert BOOL to REAL", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "BOOL_TO_REAL", VarType.BOOL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "BOOL_TO_REAL", VarType.REAL, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "BOOL_TO_LREAL", "Convert BOOL to LREAL", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "BOOL_TO_LREAL", VarType.BOOL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "BOOL_TO_LREAL", VarType.LREAL, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "BOOL_TO_SINT", "Convert BOOL to SINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "BOOL_TO_SINT", VarType.BOOL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "BOOL_TO_SINT", VarType.SINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "BOOL_TO_INT", "Convert BOOL to INT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "BOOL_TO_INT", VarType.BOOL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "BOOL_TO_INT", VarType.INT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "BOOL_TO_DINT", "Convert BOOL to DINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "BOOL_TO_DINT", VarType.BOOL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "BOOL_TO_DINT", VarType.DINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "BOOL_TO_LINT", "Convert BOOL to LINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "BOOL_TO_LINT", VarType.BOOL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "BOOL_TO_LINT", VarType.LINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "BOOL_TO_USINT", "Convert BOOL to USINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "BOOL_TO_USINT", VarType.BOOL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "BOOL_TO_USINT", VarType.USINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "BOOL_TO_UINT", "Convert BOOL to UINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "BOOL_TO_UINT", VarType.BOOL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "BOOL_TO_UINT", VarType.UINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "BOOL_TO_UDINT", "Convert BOOL to UDINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "BOOL_TO_UDINT", VarType.BOOL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "BOOL_TO_UDINT", VarType.UDINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "BOOL_TO_ULINT", "Convert BOOL to ULINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "BOOL_TO_ULINT", VarType.BOOL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "BOOL_TO_ULINT", VarType.ULINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "BYTE_TO_BYTE", "Convert BYTE to BYTE", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "BYTE_TO_BYTE", VarType.BYTE, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "BYTE_TO_BYTE", VarType.BYTE, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "BYTE_TO_WORD", "Convert BYTE to WORD", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "BYTE_TO_WORD", VarType.BYTE, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "BYTE_TO_WORD", VarType.WORD, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "BYTE_TO_DWORD", "Convert BYTE to DWORD", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "BYTE_TO_DWORD", VarType.BYTE, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "BYTE_TO_DWORD", VarType.DWORD, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "BYTE_TO_LWORD", "Convert BYTE to LWORD", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "BYTE_TO_LWORD", VarType.BYTE, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "BYTE_TO_LWORD", VarType.LWORD, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "BYTE_TO_BOOL", "Convert BYTE to BOOL", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "BYTE_TO_BOOL", VarType.BYTE, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "BYTE_TO_BOOL", VarType.BOOL, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "WORD_TO_BYTE", "Convert WORD to BYTE", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "WORD_TO_BYTE", VarType.WORD, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "WORD_TO_BYTE", VarType.BYTE, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "WORD_TO_WORD", "Convert WORD to WORD", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "WORD_TO_WORD", VarType.WORD, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "WORD_TO_WORD", VarType.WORD, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "WORD_TO_DWORD", "Convert WORD to DWORD", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "WORD_TO_DWORD", VarType.WORD, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "WORD_TO_DWORD", VarType.DWORD, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "WORD_TO_LWORD", "Convert WORD to LWORD", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "WORD_TO_LWORD", VarType.WORD, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "WORD_TO_LWORD", VarType.LWORD, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "WORD_TO_BOOL", "Convert WORD to BOOL", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "WORD_TO_BOOL", VarType.WORD, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "WORD_TO_BOOL", VarType.BOOL, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "DWORD_TO_BYTE", "Convert DWORD to BYTE", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "DWORD_TO_BYTE", VarType.DWORD, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "DWORD_TO_BYTE", VarType.BYTE, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "DWORD_TO_WORD", "Convert DWORD to WORD", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "DWORD_TO_WORD", VarType.DWORD, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "DWORD_TO_WORD", VarType.WORD, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "DWORD_TO_DWORD", "Convert DWORD to DWORD", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "DWORD_TO_DWORD", VarType.DWORD, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "DWORD_TO_DWORD", VarType.DWORD, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "DWORD_TO_LWORD", "Convert DWORD to LWORD", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "DWORD_TO_LWORD", VarType.DWORD, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "DWORD_TO_LWORD", VarType.LWORD, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "DWORD_TO_BOOL", "Convert DWORD to BOOL", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "DWORD_TO_BOOL", VarType.DWORD, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "DWORD_TO_BOOL", VarType.BOOL, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "LWORD_TO_BYTE", "Convert LWORD to BYTE", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "LWORD_TO_BYTE", VarType.LWORD, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "LWORD_TO_BYTE", VarType.BYTE, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "LWORD_TO_WORD", "Convert LWORD to WORD", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "LWORD_TO_WORD", VarType.LWORD, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "LWORD_TO_WORD", VarType.WORD, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "LWORD_TO_DWORD", "Convert LWORD to DWORD", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "LWORD_TO_DWORD", VarType.LWORD, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "LWORD_TO_DWORD", VarType.DWORD, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "LWORD_TO_LWORD", "Convert LWORD to LWORD", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "LWORD_TO_LWORD", VarType.LWORD, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "LWORD_TO_LWORD", VarType.LWORD, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "LWORD_TO_BOOL", "Convert LWORD to BOOL", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "LWORD_TO_BOOL", VarType.LWORD, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "LWORD_TO_BOOL", VarType.BOOL, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "BOOL_TO_BYTE", "Convert BOOL to BYTE", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "BOOL_TO_BYTE", VarType.BOOL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "BOOL_TO_BYTE", VarType.BYTE, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "BOOL_TO_WORD", "Convert BOOL to WORD", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "BOOL_TO_WORD", VarType.BOOL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "BOOL_TO_WORD", VarType.WORD, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "BOOL_TO_DWORD", "Convert BOOL to DWORD", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "BOOL_TO_DWORD", VarType.BOOL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "BOOL_TO_DWORD", VarType.DWORD, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "BOOL_TO_LWORD", "Convert BOOL to LWORD", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "BOOL_TO_LWORD", VarType.BOOL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "BOOL_TO_LWORD", VarType.LWORD, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "BOOL_TO_BOOL", "Convert BOOL to BOOL", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "BOOL_TO_BOOL", VarType.BOOL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "BOOL_TO_BOOL", VarType.BOOL, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "REAL_TO_REAL", "Convert REAL to REAL", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "REAL_TO_REAL", VarType.REAL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "REAL_TO_REAL", VarType.REAL, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "REAL_TO_LREAL", "Convert REAL to LREAL", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "REAL_TO_LREAL", VarType.REAL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "REAL_TO_LREAL", VarType.LREAL, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "REAL_TO_SINT", "Convert REAL to SINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "REAL_TO_SINT", VarType.REAL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "REAL_TO_SINT", VarType.SINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "REAL_TO_INT", "Convert REAL to INT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "REAL_TO_INT", VarType.REAL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "REAL_TO_INT", VarType.INT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "REAL_TO_DINT", "Convert REAL to DINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "REAL_TO_DINT", VarType.REAL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "REAL_TO_DINT", VarType.DINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "REAL_TO_LINT", "Convert REAL to LINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "REAL_TO_LINT", VarType.REAL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "REAL_TO_LINT", VarType.LINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "REAL_TO_USINT", "Convert REAL to USINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "REAL_TO_USINT", VarType.REAL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "REAL_TO_USINT", VarType.USINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "REAL_TO_UINT", "Convert REAL to UINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "REAL_TO_UINT", VarType.REAL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "REAL_TO_UINT", VarType.UINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "REAL_TO_UDINT", "Convert REAL to UDINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "REAL_TO_UDINT", VarType.REAL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "REAL_TO_UDINT", VarType.UDINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "REAL_TO_ULINT", "Convert REAL to ULINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "REAL_TO_ULINT", VarType.REAL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "REAL_TO_ULINT", VarType.ULINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "LREAL_TO_REAL", "Convert LREAL to REAL", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "LREAL_TO_REAL", VarType.LREAL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "LREAL_TO_REAL", VarType.REAL, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "LREAL_TO_LREAL", "Convert LREAL to LREAL", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "LREAL_TO_LREAL", VarType.LREAL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "LREAL_TO_LREAL", VarType.LREAL, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "LREAL_TO_SINT", "Convert LREAL to SINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "LREAL_TO_SINT", VarType.LREAL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "LREAL_TO_SINT", VarType.SINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "LREAL_TO_INT", "Convert LREAL to INT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "LREAL_TO_INT", VarType.LREAL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "LREAL_TO_INT", VarType.INT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "LREAL_TO_DINT", "Convert LREAL to DINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "LREAL_TO_DINT", VarType.LREAL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "LREAL_TO_DINT", VarType.DINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "LREAL_TO_LINT", "Convert LREAL to LINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "LREAL_TO_LINT", VarType.LREAL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "LREAL_TO_LINT", VarType.LINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "LREAL_TO_USINT", "Convert LREAL to USINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "LREAL_TO_USINT", VarType.LREAL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "LREAL_TO_USINT", VarType.USINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "LREAL_TO_UINT", "Convert LREAL to UINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "LREAL_TO_UINT", VarType.LREAL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "LREAL_TO_UINT", VarType.UINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "LREAL_TO_UDINT", "Convert LREAL to UDINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "LREAL_TO_UDINT", VarType.LREAL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "LREAL_TO_UDINT", VarType.UDINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "LREAL_TO_ULINT", "Convert LREAL to ULINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "LREAL_TO_ULINT", VarType.LREAL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "LREAL_TO_ULINT", VarType.ULINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "SINT_TO_REAL", "Convert SINT to REAL", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "SINT_TO_REAL", VarType.SINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "SINT_TO_REAL", VarType.REAL, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "SINT_TO_LREAL", "Convert SINT to LREAL", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "SINT_TO_LREAL", VarType.SINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "SINT_TO_LREAL", VarType.LREAL, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "SINT_TO_SINT", "Convert SINT to SINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "SINT_TO_SINT", VarType.SINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "SINT_TO_SINT", VarType.SINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "SINT_TO_INT", "Convert SINT to INT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "SINT_TO_INT", VarType.SINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "SINT_TO_INT", VarType.INT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "SINT_TO_DINT", "Convert SINT to DINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "SINT_TO_DINT", VarType.SINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "SINT_TO_DINT", VarType.DINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "SINT_TO_LINT", "Convert SINT to LINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "SINT_TO_LINT", VarType.SINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "SINT_TO_LINT", VarType.LINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "SINT_TO_USINT", "Convert SINT to USINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "SINT_TO_USINT", VarType.SINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "SINT_TO_USINT", VarType.USINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "SINT_TO_UINT", "Convert SINT to UINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "SINT_TO_UINT", VarType.SINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "SINT_TO_UINT", VarType.UINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "SINT_TO_UDINT", "Convert SINT to UDINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "SINT_TO_UDINT", VarType.SINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "SINT_TO_UDINT", VarType.UDINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "SINT_TO_ULINT", "Convert SINT to ULINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "SINT_TO_ULINT", VarType.SINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "SINT_TO_ULINT", VarType.ULINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "INT_TO_REAL", "Convert INT to REAL", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "INT_TO_REAL", VarType.INT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "INT_TO_REAL", VarType.REAL, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "INT_TO_LREAL", "Convert INT to LREAL", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "INT_TO_LREAL", VarType.INT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "INT_TO_LREAL", VarType.LREAL, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "INT_TO_SINT", "Convert INT to SINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "INT_TO_SINT", VarType.INT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "INT_TO_SINT", VarType.SINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "INT_TO_INT", "Convert INT to INT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "INT_TO_INT", VarType.INT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "INT_TO_INT", VarType.INT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "INT_TO_DINT", "Convert INT to DINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "INT_TO_DINT", VarType.INT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "INT_TO_DINT", VarType.DINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "INT_TO_LINT", "Convert INT to LINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "INT_TO_LINT", VarType.INT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "INT_TO_LINT", VarType.LINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "INT_TO_USINT", "Convert INT to USINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "INT_TO_USINT", VarType.INT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "INT_TO_USINT", VarType.USINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "INT_TO_UINT", "Convert INT to UINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "INT_TO_UINT", VarType.INT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "INT_TO_UINT", VarType.UINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "INT_TO_UDINT", "Convert INT to UDINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "INT_TO_UDINT", VarType.INT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "INT_TO_UDINT", VarType.UDINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "INT_TO_ULINT", "Convert INT to ULINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "INT_TO_ULINT", VarType.INT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "INT_TO_ULINT", VarType.ULINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "DINT_TO_REAL", "Convert DINT to REAL", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "DINT_TO_REAL", VarType.DINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "DINT_TO_REAL", VarType.REAL, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "DINT_TO_LREAL", "Convert DINT to LREAL", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "DINT_TO_LREAL", VarType.DINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "DINT_TO_LREAL", VarType.LREAL, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "DINT_TO_SINT", "Convert DINT to SINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "DINT_TO_SINT", VarType.DINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "DINT_TO_SINT", VarType.SINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "DINT_TO_INT", "Convert DINT to INT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "DINT_TO_INT", VarType.DINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "DINT_TO_INT", VarType.INT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "DINT_TO_DINT", "Convert DINT to DINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "DINT_TO_DINT", VarType.DINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "DINT_TO_DINT", VarType.DINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "DINT_TO_LINT", "Convert DINT to LINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "DINT_TO_LINT", VarType.DINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "DINT_TO_LINT", VarType.LINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "DINT_TO_USINT", "Convert DINT to USINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "DINT_TO_USINT", VarType.DINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "DINT_TO_USINT", VarType.USINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "DINT_TO_UINT", "Convert DINT to UINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "DINT_TO_UINT", VarType.DINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "DINT_TO_UINT", VarType.UINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "DINT_TO_UDINT", "Convert DINT to UDINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "DINT_TO_UDINT", VarType.DINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "DINT_TO_UDINT", VarType.UDINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "DINT_TO_ULINT", "Convert DINT to ULINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "DINT_TO_ULINT", VarType.DINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "DINT_TO_ULINT", VarType.ULINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "LINT_TO_REAL", "Convert LINT to REAL", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "LINT_TO_REAL", VarType.LINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "LINT_TO_REAL", VarType.REAL, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "LINT_TO_LREAL", "Convert LINT to LREAL", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "LINT_TO_LREAL", VarType.LINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "LINT_TO_LREAL", VarType.LREAL, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "LINT_TO_SINT", "Convert LINT to SINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "LINT_TO_SINT", VarType.LINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "LINT_TO_SINT", VarType.SINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "LINT_TO_INT", "Convert LINT to INT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "LINT_TO_INT", VarType.LINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "LINT_TO_INT", VarType.INT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "LINT_TO_DINT", "Convert LINT to DINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "LINT_TO_DINT", VarType.LINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "LINT_TO_DINT", VarType.DINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "LINT_TO_LINT", "Convert LINT to LINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "LINT_TO_LINT", VarType.LINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "LINT_TO_LINT", VarType.LINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "LINT_TO_USINT", "Convert LINT to USINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "LINT_TO_USINT", VarType.LINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "LINT_TO_USINT", VarType.USINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "LINT_TO_UINT", "Convert LINT to UINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "LINT_TO_UINT", VarType.LINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "LINT_TO_UINT", VarType.UINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "LINT_TO_UDINT", "Convert LINT to UDINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "LINT_TO_UDINT", VarType.LINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "LINT_TO_UDINT", VarType.UDINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "LINT_TO_ULINT", "Convert LINT to ULINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "LINT_TO_ULINT", VarType.LINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "LINT_TO_ULINT", VarType.ULINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "USINT_TO_REAL", "Convert USINT to REAL", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "USINT_TO_REAL", VarType.USINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "USINT_TO_REAL", VarType.REAL, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "USINT_TO_LREAL", "Convert USINT to LREAL", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "USINT_TO_LREAL", VarType.USINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "USINT_TO_LREAL", VarType.LREAL, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "USINT_TO_SINT", "Convert USINT to SINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "USINT_TO_SINT", VarType.USINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "USINT_TO_SINT", VarType.SINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "USINT_TO_INT", "Convert USINT to INT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "USINT_TO_INT", VarType.USINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "USINT_TO_INT", VarType.INT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "USINT_TO_DINT", "Convert USINT to DINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "USINT_TO_DINT", VarType.USINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "USINT_TO_DINT", VarType.DINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "USINT_TO_LINT", "Convert USINT to LINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "USINT_TO_LINT", VarType.USINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "USINT_TO_LINT", VarType.LINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "USINT_TO_USINT", "Convert USINT to USINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "USINT_TO_USINT", VarType.USINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "USINT_TO_USINT", VarType.USINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "USINT_TO_UINT", "Convert USINT to UINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "USINT_TO_UINT", VarType.USINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "USINT_TO_UINT", VarType.UINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "USINT_TO_UDINT", "Convert USINT to UDINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "USINT_TO_UDINT", VarType.USINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "USINT_TO_UDINT", VarType.UDINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "USINT_TO_ULINT", "Convert USINT to ULINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "USINT_TO_ULINT", VarType.USINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "USINT_TO_ULINT", VarType.ULINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "UINT_TO_REAL", "Convert UINT to REAL", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "UINT_TO_REAL", VarType.UINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "UINT_TO_REAL", VarType.REAL, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "UINT_TO_LREAL", "Convert UINT to LREAL", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "UINT_TO_LREAL", VarType.UINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "UINT_TO_LREAL", VarType.LREAL, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "UINT_TO_SINT", "Convert UINT to SINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "UINT_TO_SINT", VarType.UINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "UINT_TO_SINT", VarType.SINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "UINT_TO_INT", "Convert UINT to INT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "UINT_TO_INT", VarType.UINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "UINT_TO_INT", VarType.INT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "UINT_TO_DINT", "Convert UINT to DINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "UINT_TO_DINT", VarType.UINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "UINT_TO_DINT", VarType.DINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "UINT_TO_LINT", "Convert UINT to LINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "UINT_TO_LINT", VarType.UINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "UINT_TO_LINT", VarType.LINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "UINT_TO_USINT", "Convert UINT to USINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "UINT_TO_USINT", VarType.UINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "UINT_TO_USINT", VarType.USINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "UINT_TO_UINT", "Convert UINT to UINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "UINT_TO_UINT", VarType.UINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "UINT_TO_UINT", VarType.UINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "UINT_TO_UDINT", "Convert UINT to UDINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "UINT_TO_UDINT", VarType.UINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "UINT_TO_UDINT", VarType.UDINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "UINT_TO_ULINT", "Convert UINT to ULINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "UINT_TO_ULINT", VarType.UINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "UINT_TO_ULINT", VarType.ULINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "UDINT_TO_REAL", "Convert UDINT to REAL", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "UDINT_TO_REAL", VarType.UDINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "UDINT_TO_REAL", VarType.REAL, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "UDINT_TO_LREAL", "Convert UDINT to LREAL", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "UDINT_TO_LREAL", VarType.UDINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "UDINT_TO_LREAL", VarType.LREAL, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "UDINT_TO_SINT", "Convert UDINT to SINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "UDINT_TO_SINT", VarType.UDINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "UDINT_TO_SINT", VarType.SINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "UDINT_TO_INT", "Convert UDINT to INT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "UDINT_TO_INT", VarType.UDINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "UDINT_TO_INT", VarType.INT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "UDINT_TO_DINT", "Convert UDINT to DINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "UDINT_TO_DINT", VarType.UDINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "UDINT_TO_DINT", VarType.DINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "UDINT_TO_LINT", "Convert UDINT to LINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "UDINT_TO_LINT", VarType.UDINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "UDINT_TO_LINT", VarType.LINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "UDINT_TO_USINT", "Convert UDINT to USINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "UDINT_TO_USINT", VarType.UDINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "UDINT_TO_USINT", VarType.USINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "UDINT_TO_UINT", "Convert UDINT to UINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "UDINT_TO_UINT", VarType.UDINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "UDINT_TO_UINT", VarType.UINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "UDINT_TO_UDINT", "Convert UDINT to UDINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "UDINT_TO_UDINT", VarType.UDINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "UDINT_TO_UDINT", VarType.UDINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "UDINT_TO_ULINT", "Convert UDINT to ULINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "UDINT_TO_ULINT", VarType.UDINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "UDINT_TO_ULINT", VarType.ULINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "ULINT_TO_REAL", "Convert ULINT to REAL", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "ULINT_TO_REAL", VarType.ULINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "ULINT_TO_REAL", VarType.REAL, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "ULINT_TO_LREAL", "Convert ULINT to LREAL", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "ULINT_TO_LREAL", VarType.ULINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "ULINT_TO_LREAL", VarType.LREAL, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "ULINT_TO_SINT", "Convert ULINT to SINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "ULINT_TO_SINT", VarType.ULINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "ULINT_TO_SINT", VarType.SINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "ULINT_TO_INT", "Convert ULINT to INT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "ULINT_TO_INT", VarType.ULINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "ULINT_TO_INT", VarType.INT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "ULINT_TO_DINT", "Convert ULINT to DINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "ULINT_TO_DINT", VarType.ULINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "ULINT_TO_DINT", VarType.DINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "ULINT_TO_LINT", "Convert ULINT to LINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "ULINT_TO_LINT", VarType.ULINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "ULINT_TO_LINT", VarType.LINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "ULINT_TO_USINT", "Convert ULINT to USINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "ULINT_TO_USINT", VarType.ULINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "ULINT_TO_USINT", VarType.USINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "ULINT_TO_UINT", "Convert ULINT to UINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "ULINT_TO_UINT", VarType.ULINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "ULINT_TO_UINT", VarType.UINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "ULINT_TO_UDINT", "Convert ULINT to UDINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "ULINT_TO_UDINT", VarType.ULINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "ULINT_TO_UDINT", VarType.UDINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "ULINT_TO_ULINT", "Convert ULINT to ULINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "ULINT_TO_ULINT", VarType.ULINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "ULINT_TO_ULINT", VarType.ULINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "REAL_TO_BYTE", "Convert REAL to BYTE", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "REAL_TO_BYTE", VarType.REAL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "REAL_TO_BYTE", VarType.BYTE, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "REAL_TO_WORD", "Convert REAL to WORD", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "REAL_TO_WORD", VarType.REAL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "REAL_TO_WORD", VarType.WORD, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "REAL_TO_DWORD", "Convert REAL to DWORD", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "REAL_TO_DWORD", VarType.REAL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "REAL_TO_DWORD", VarType.DWORD, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "REAL_TO_LWORD", "Convert REAL to LWORD", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "REAL_TO_LWORD", VarType.REAL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "REAL_TO_LWORD", VarType.LWORD, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "REAL_TO_BOOL", "Convert REAL to BOOL", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "REAL_TO_BOOL", VarType.REAL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "REAL_TO_BOOL", VarType.BOOL, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "LREAL_TO_BYTE", "Convert LREAL to BYTE", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "LREAL_TO_BYTE", VarType.LREAL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "LREAL_TO_BYTE", VarType.BYTE, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "LREAL_TO_WORD", "Convert LREAL to WORD", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "LREAL_TO_WORD", VarType.LREAL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "LREAL_TO_WORD", VarType.WORD, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "LREAL_TO_DWORD", "Convert LREAL to DWORD", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "LREAL_TO_DWORD", VarType.LREAL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "LREAL_TO_DWORD", VarType.DWORD, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "LREAL_TO_LWORD", "Convert LREAL to LWORD", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "LREAL_TO_LWORD", VarType.LREAL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "LREAL_TO_LWORD", VarType.LWORD, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "LREAL_TO_BOOL", "Convert LREAL to BOOL", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "LREAL_TO_BOOL", VarType.LREAL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "LREAL_TO_BOOL", VarType.BOOL, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "SINT_TO_BYTE", "Convert SINT to BYTE", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "SINT_TO_BYTE", VarType.SINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "SINT_TO_BYTE", VarType.BYTE, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "SINT_TO_WORD", "Convert SINT to WORD", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "SINT_TO_WORD", VarType.SINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "SINT_TO_WORD", VarType.WORD, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "SINT_TO_DWORD", "Convert SINT to DWORD", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "SINT_TO_DWORD", VarType.SINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "SINT_TO_DWORD", VarType.DWORD, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "SINT_TO_LWORD", "Convert SINT to LWORD", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "SINT_TO_LWORD", VarType.SINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "SINT_TO_LWORD", VarType.LWORD, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "SINT_TO_BOOL", "Convert SINT to BOOL", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "SINT_TO_BOOL", VarType.SINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "SINT_TO_BOOL", VarType.BOOL, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "INT_TO_BYTE", "Convert INT to BYTE", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "INT_TO_BYTE", VarType.INT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "INT_TO_BYTE", VarType.BYTE, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "INT_TO_WORD", "Convert INT to WORD", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "INT_TO_WORD", VarType.INT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "INT_TO_WORD", VarType.WORD, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "INT_TO_DWORD", "Convert INT to DWORD", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "INT_TO_DWORD", VarType.INT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "INT_TO_DWORD", VarType.DWORD, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "INT_TO_LWORD", "Convert INT to LWORD", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "INT_TO_LWORD", VarType.INT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "INT_TO_LWORD", VarType.LWORD, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "INT_TO_BOOL", "Convert INT to BOOL", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "INT_TO_BOOL", VarType.INT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "INT_TO_BOOL", VarType.BOOL, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "DINT_TO_BYTE", "Convert DINT to BYTE", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "DINT_TO_BYTE", VarType.DINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "DINT_TO_BYTE", VarType.BYTE, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "DINT_TO_WORD", "Convert DINT to WORD", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "DINT_TO_WORD", VarType.DINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "DINT_TO_WORD", VarType.WORD, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "DINT_TO_DWORD", "Convert DINT to DWORD", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "DINT_TO_DWORD", VarType.DINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "DINT_TO_DWORD", VarType.DWORD, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "DINT_TO_LWORD", "Convert DINT to LWORD", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "DINT_TO_LWORD", VarType.DINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "DINT_TO_LWORD", VarType.LWORD, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "DINT_TO_BOOL", "Convert DINT to BOOL", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "DINT_TO_BOOL", VarType.DINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "DINT_TO_BOOL", VarType.BOOL, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "LINT_TO_BYTE", "Convert LINT to BYTE", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "LINT_TO_BYTE", VarType.LINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "LINT_TO_BYTE", VarType.BYTE, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "LINT_TO_WORD", "Convert LINT to WORD", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "LINT_TO_WORD", VarType.LINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "LINT_TO_WORD", VarType.WORD, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "LINT_TO_DWORD", "Convert LINT to DWORD", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "LINT_TO_DWORD", VarType.LINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "LINT_TO_DWORD", VarType.DWORD, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "LINT_TO_LWORD", "Convert LINT to LWORD", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "LINT_TO_LWORD", VarType.LINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "LINT_TO_LWORD", VarType.LWORD, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "LINT_TO_BOOL", "Convert LINT to BOOL", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "LINT_TO_BOOL", VarType.LINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "LINT_TO_BOOL", VarType.BOOL, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "USINT_TO_BYTE", "Convert USINT to BYTE", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "USINT_TO_BYTE", VarType.USINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "USINT_TO_BYTE", VarType.BYTE, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "USINT_TO_WORD", "Convert USINT to WORD", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "USINT_TO_WORD", VarType.USINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "USINT_TO_WORD", VarType.WORD, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "USINT_TO_DWORD", "Convert USINT to DWORD", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "USINT_TO_DWORD", VarType.USINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "USINT_TO_DWORD", VarType.DWORD, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "USINT_TO_LWORD", "Convert USINT to LWORD", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "USINT_TO_LWORD", VarType.USINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "USINT_TO_LWORD", VarType.LWORD, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "USINT_TO_BOOL", "Convert USINT to BOOL", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "USINT_TO_BOOL", VarType.USINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "USINT_TO_BOOL", VarType.BOOL, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "UINT_TO_BYTE", "Convert UINT to BYTE", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "UINT_TO_BYTE", VarType.UINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "UINT_TO_BYTE", VarType.BYTE, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "UINT_TO_WORD", "Convert UINT to WORD", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "UINT_TO_WORD", VarType.UINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "UINT_TO_WORD", VarType.WORD, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "UINT_TO_DWORD", "Convert UINT to DWORD", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "UINT_TO_DWORD", VarType.UINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "UINT_TO_DWORD", VarType.DWORD, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "UINT_TO_LWORD", "Convert UINT to LWORD", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "UINT_TO_LWORD", VarType.UINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "UINT_TO_LWORD", VarType.LWORD, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "UINT_TO_BOOL", "Convert UINT to BOOL", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "UINT_TO_BOOL", VarType.UINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "UINT_TO_BOOL", VarType.BOOL, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "UDINT_TO_BYTE", "Convert UDINT to BYTE", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "UDINT_TO_BYTE", VarType.UDINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "UDINT_TO_BYTE", VarType.BYTE, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "UDINT_TO_WORD", "Convert UDINT to WORD", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "UDINT_TO_WORD", VarType.UDINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "UDINT_TO_WORD", VarType.WORD, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "UDINT_TO_DWORD", "Convert UDINT to DWORD", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "UDINT_TO_DWORD", VarType.UDINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "UDINT_TO_DWORD", VarType.DWORD, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "UDINT_TO_LWORD", "Convert UDINT to LWORD", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "UDINT_TO_LWORD", VarType.UDINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "UDINT_TO_LWORD", VarType.LWORD, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "UDINT_TO_BOOL", "Convert UDINT to BOOL", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "UDINT_TO_BOOL", VarType.UDINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "UDINT_TO_BOOL", VarType.BOOL, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "ULINT_TO_BYTE", "Convert ULINT to BYTE", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "ULINT_TO_BYTE", VarType.ULINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "ULINT_TO_BYTE", VarType.BYTE, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "ULINT_TO_WORD", "Convert ULINT to WORD", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "ULINT_TO_WORD", VarType.ULINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "ULINT_TO_WORD", VarType.WORD, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "ULINT_TO_DWORD", "Convert ULINT to DWORD", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "ULINT_TO_DWORD", VarType.ULINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "ULINT_TO_DWORD", VarType.DWORD, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "ULINT_TO_LWORD", "Convert ULINT to LWORD", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "ULINT_TO_LWORD", VarType.ULINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "ULINT_TO_LWORD", VarType.LWORD, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "ULINT_TO_BOOL", "Convert ULINT to BOOL", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "ULINT_TO_BOOL", VarType.ULINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "ULINT_TO_BOOL", VarType.BOOL, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "BYTE_TO_TIME", "Convert BYTE to TIME", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "BYTE_TO_TIME", VarType.BYTE, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "BYTE_TO_TIME", VarType.TIME, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "WORD_TO_TIME", "Convert WORD to TIME", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "WORD_TO_TIME", VarType.WORD, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "WORD_TO_TIME", VarType.TIME, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "DWORD_TO_TIME", "Convert DWORD to TIME", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "DWORD_TO_TIME", VarType.DWORD, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "DWORD_TO_TIME", VarType.TIME, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "LWORD_TO_TIME", "Convert LWORD to TIME", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "LWORD_TO_TIME", VarType.LWORD, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "LWORD_TO_TIME", VarType.TIME, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "BOOL_TO_TIME", "Convert BOOL to TIME", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "BOOL_TO_TIME", VarType.BOOL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "BOOL_TO_TIME", VarType.TIME, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "REAL_TO_TIME", "Convert REAL to TIME", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "REAL_TO_TIME", VarType.REAL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "REAL_TO_TIME", VarType.TIME, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "LREAL_TO_TIME", "Convert LREAL to TIME", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "LREAL_TO_TIME", VarType.LREAL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "LREAL_TO_TIME", VarType.TIME, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "SINT_TO_TIME", "Convert SINT to TIME", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "SINT_TO_TIME", VarType.SINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "SINT_TO_TIME", VarType.TIME, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "INT_TO_TIME", "Convert INT to TIME", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "INT_TO_TIME", VarType.INT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "INT_TO_TIME", VarType.TIME, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "DINT_TO_TIME", "Convert DINT to TIME", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "DINT_TO_TIME", VarType.DINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "DINT_TO_TIME", VarType.TIME, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "LINT_TO_TIME", "Convert LINT to TIME", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "LINT_TO_TIME", VarType.LINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "LINT_TO_TIME", VarType.TIME, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "USINT_TO_TIME", "Convert USINT to TIME", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "USINT_TO_TIME", VarType.USINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "USINT_TO_TIME", VarType.TIME, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "UINT_TO_TIME", "Convert UINT to TIME", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "UINT_TO_TIME", VarType.UINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "UINT_TO_TIME", VarType.TIME, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "UDINT_TO_TIME", "Convert UDINT to TIME", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "UDINT_TO_TIME", VarType.UDINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "UDINT_TO_TIME", VarType.TIME, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "ULINT_TO_TIME", "Convert ULINT to TIME", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "ULINT_TO_TIME", VarType.ULINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "ULINT_TO_TIME", VarType.TIME, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "BYTE_TO_DATE", "Convert BYTE to DATE", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "BYTE_TO_DATE", VarType.BYTE, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "BYTE_TO_DATE", VarType.DATE, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "BYTE_TO_TOD", "Convert BYTE to TOD", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "BYTE_TO_TOD", VarType.BYTE, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "BYTE_TO_TOD", VarType.TOD, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "BYTE_TO_DT", "Convert BYTE to DT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "BYTE_TO_DT", VarType.BYTE, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "BYTE_TO_DT", VarType.DT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "WORD_TO_DATE", "Convert WORD to DATE", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "WORD_TO_DATE", VarType.WORD, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "WORD_TO_DATE", VarType.DATE, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "WORD_TO_TOD", "Convert WORD to TOD", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "WORD_TO_TOD", VarType.WORD, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "WORD_TO_TOD", VarType.TOD, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "WORD_TO_DT", "Convert WORD to DT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "WORD_TO_DT", VarType.WORD, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "WORD_TO_DT", VarType.DT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "DWORD_TO_DATE", "Convert DWORD to DATE", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "DWORD_TO_DATE", VarType.DWORD, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "DWORD_TO_DATE", VarType.DATE, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "DWORD_TO_TOD", "Convert DWORD to TOD", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "DWORD_TO_TOD", VarType.DWORD, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "DWORD_TO_TOD", VarType.TOD, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "DWORD_TO_DT", "Convert DWORD to DT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "DWORD_TO_DT", VarType.DWORD, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "DWORD_TO_DT", VarType.DT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "LWORD_TO_DATE", "Convert LWORD to DATE", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "LWORD_TO_DATE", VarType.LWORD, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "LWORD_TO_DATE", VarType.DATE, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "LWORD_TO_TOD", "Convert LWORD to TOD", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "LWORD_TO_TOD", VarType.LWORD, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "LWORD_TO_TOD", VarType.TOD, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "LWORD_TO_DT", "Convert LWORD to DT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "LWORD_TO_DT", VarType.LWORD, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "LWORD_TO_DT", VarType.DT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "BOOL_TO_DATE", "Convert BOOL to DATE", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "BOOL_TO_DATE", VarType.BOOL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "BOOL_TO_DATE", VarType.DATE, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "BOOL_TO_TOD", "Convert BOOL to TOD", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "BOOL_TO_TOD", VarType.BOOL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "BOOL_TO_TOD", VarType.TOD, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "BOOL_TO_DT", "Convert BOOL to DT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "BOOL_TO_DT", VarType.BOOL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "BOOL_TO_DT", VarType.DT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "REAL_TO_DATE", "Convert REAL to DATE", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "REAL_TO_DATE", VarType.REAL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "REAL_TO_DATE", VarType.DATE, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "REAL_TO_TOD", "Convert REAL to TOD", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "REAL_TO_TOD", VarType.REAL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "REAL_TO_TOD", VarType.TOD, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "REAL_TO_DT", "Convert REAL to DT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "REAL_TO_DT", VarType.REAL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "REAL_TO_DT", VarType.DT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "LREAL_TO_DATE", "Convert LREAL to DATE", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "LREAL_TO_DATE", VarType.LREAL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "LREAL_TO_DATE", VarType.DATE, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "LREAL_TO_TOD", "Convert LREAL to TOD", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "LREAL_TO_TOD", VarType.LREAL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "LREAL_TO_TOD", VarType.TOD, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "LREAL_TO_DT", "Convert LREAL to DT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "LREAL_TO_DT", VarType.LREAL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "LREAL_TO_DT", VarType.DT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "SINT_TO_DATE", "Convert SINT to DATE", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "SINT_TO_DATE", VarType.SINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "SINT_TO_DATE", VarType.DATE, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "SINT_TO_TOD", "Convert SINT to TOD", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "SINT_TO_TOD", VarType.SINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "SINT_TO_TOD", VarType.TOD, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "SINT_TO_DT", "Convert SINT to DT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "SINT_TO_DT", VarType.SINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "SINT_TO_DT", VarType.DT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "INT_TO_DATE", "Convert INT to DATE", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "INT_TO_DATE", VarType.INT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "INT_TO_DATE", VarType.DATE, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "INT_TO_TOD", "Convert INT to TOD", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "INT_TO_TOD", VarType.INT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "INT_TO_TOD", VarType.TOD, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "INT_TO_DT", "Convert INT to DT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "INT_TO_DT", VarType.INT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "INT_TO_DT", VarType.DT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "DINT_TO_DATE", "Convert DINT to DATE", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "DINT_TO_DATE", VarType.DINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "DINT_TO_DATE", VarType.DATE, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "DINT_TO_TOD", "Convert DINT to TOD", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "DINT_TO_TOD", VarType.DINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "DINT_TO_TOD", VarType.TOD, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "DINT_TO_DT", "Convert DINT to DT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "DINT_TO_DT", VarType.DINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "DINT_TO_DT", VarType.DT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "LINT_TO_DATE", "Convert LINT to DATE", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "LINT_TO_DATE", VarType.LINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "LINT_TO_DATE", VarType.DATE, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "LINT_TO_TOD", "Convert LINT to TOD", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "LINT_TO_TOD", VarType.LINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "LINT_TO_TOD", VarType.TOD, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "LINT_TO_DT", "Convert LINT to DT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "LINT_TO_DT", VarType.LINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "LINT_TO_DT", VarType.DT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "USINT_TO_DATE", "Convert USINT to DATE", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "USINT_TO_DATE", VarType.USINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "USINT_TO_DATE", VarType.DATE, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "USINT_TO_TOD", "Convert USINT to TOD", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "USINT_TO_TOD", VarType.USINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "USINT_TO_TOD", VarType.TOD, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "USINT_TO_DT", "Convert USINT to DT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "USINT_TO_DT", VarType.USINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "USINT_TO_DT", VarType.DT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "UINT_TO_DATE", "Convert UINT to DATE", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "UINT_TO_DATE", VarType.UINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "UINT_TO_DATE", VarType.DATE, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "UINT_TO_TOD", "Convert UINT to TOD", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "UINT_TO_TOD", VarType.UINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "UINT_TO_TOD", VarType.TOD, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "UINT_TO_DT", "Convert UINT to DT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "UINT_TO_DT", VarType.UINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "UINT_TO_DT", VarType.DT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "UDINT_TO_DATE", "Convert UDINT to DATE", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "UDINT_TO_DATE", VarType.UDINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "UDINT_TO_DATE", VarType.DATE, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "UDINT_TO_TOD", "Convert UDINT to TOD", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "UDINT_TO_TOD", VarType.UDINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "UDINT_TO_TOD", VarType.TOD, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "UDINT_TO_DT", "Convert UDINT to DT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "UDINT_TO_DT", VarType.UDINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "UDINT_TO_DT", VarType.DT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "ULINT_TO_DATE", "Convert ULINT to DATE", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "ULINT_TO_DATE", VarType.ULINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "ULINT_TO_DATE", VarType.DATE, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "ULINT_TO_TOD", "Convert ULINT to TOD", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "ULINT_TO_TOD", VarType.ULINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "ULINT_TO_TOD", VarType.TOD, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "ULINT_TO_DT", "Convert ULINT to DT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "ULINT_TO_DT", VarType.ULINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "ULINT_TO_DT", VarType.DT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "TIME_TO_REAL", "Convert TIME to REAL", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "TIME_TO_REAL", VarType.TIME, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "TIME_TO_REAL", VarType.REAL, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "TIME_TO_LREAL", "Convert TIME to LREAL", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "TIME_TO_LREAL", VarType.TIME, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "TIME_TO_LREAL", VarType.LREAL, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "TIME_TO_SINT", "Convert TIME to SINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "TIME_TO_SINT", VarType.TIME, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "TIME_TO_SINT", VarType.SINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "TIME_TO_INT", "Convert TIME to INT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "TIME_TO_INT", VarType.TIME, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "TIME_TO_INT", VarType.INT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "TIME_TO_DINT", "Convert TIME to DINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "TIME_TO_DINT", VarType.TIME, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "TIME_TO_DINT", VarType.DINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "TIME_TO_LINT", "Convert TIME to LINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "TIME_TO_LINT", VarType.TIME, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "TIME_TO_LINT", VarType.LINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "TIME_TO_USINT", "Convert TIME to USINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "TIME_TO_USINT", VarType.TIME, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "TIME_TO_USINT", VarType.USINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "TIME_TO_UINT", "Convert TIME to UINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "TIME_TO_UINT", VarType.TIME, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "TIME_TO_UINT", VarType.UINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "TIME_TO_UDINT", "Convert TIME to UDINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "TIME_TO_UDINT", VarType.TIME, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "TIME_TO_UDINT", VarType.UDINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "TIME_TO_ULINT", "Convert TIME to ULINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "TIME_TO_ULINT", VarType.TIME, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "TIME_TO_ULINT", VarType.ULINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "TIME_TO_BYTE", "Convert TIME to BYTE", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "TIME_TO_BYTE", VarType.TIME, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "TIME_TO_BYTE", VarType.BYTE, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "TIME_TO_WORD", "Convert TIME to WORD", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "TIME_TO_WORD", VarType.TIME, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "TIME_TO_WORD", VarType.WORD, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "TIME_TO_DWORD", "Convert TIME to DWORD", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "TIME_TO_DWORD", VarType.TIME, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "TIME_TO_DWORD", VarType.DWORD, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "TIME_TO_LWORD", "Convert TIME to LWORD", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "TIME_TO_LWORD", VarType.TIME, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "TIME_TO_LWORD", VarType.LWORD, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "TIME_TO_BOOL", "Convert TIME to BOOL", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "TIME_TO_BOOL", VarType.TIME, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "TIME_TO_BOOL", VarType.BOOL, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "DATE_TO_REAL", "Convert DATE to REAL", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "DATE_TO_REAL", VarType.DATE, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "DATE_TO_REAL", VarType.REAL, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "DATE_TO_LREAL", "Convert DATE to LREAL", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "DATE_TO_LREAL", VarType.DATE, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "DATE_TO_LREAL", VarType.LREAL, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "DATE_TO_SINT", "Convert DATE to SINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "DATE_TO_SINT", VarType.DATE, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "DATE_TO_SINT", VarType.SINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "DATE_TO_INT", "Convert DATE to INT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "DATE_TO_INT", VarType.DATE, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "DATE_TO_INT", VarType.INT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "DATE_TO_DINT", "Convert DATE to DINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "DATE_TO_DINT", VarType.DATE, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "DATE_TO_DINT", VarType.DINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "DATE_TO_LINT", "Convert DATE to LINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "DATE_TO_LINT", VarType.DATE, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "DATE_TO_LINT", VarType.LINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "DATE_TO_USINT", "Convert DATE to USINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "DATE_TO_USINT", VarType.DATE, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "DATE_TO_USINT", VarType.USINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "DATE_TO_UINT", "Convert DATE to UINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "DATE_TO_UINT", VarType.DATE, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "DATE_TO_UINT", VarType.UINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "DATE_TO_UDINT", "Convert DATE to UDINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "DATE_TO_UDINT", VarType.DATE, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "DATE_TO_UDINT", VarType.UDINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "DATE_TO_ULINT", "Convert DATE to ULINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "DATE_TO_ULINT", VarType.DATE, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "DATE_TO_ULINT", VarType.ULINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "TOD_TO_REAL", "Convert TOD to REAL", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "TOD_TO_REAL", VarType.TOD, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "TOD_TO_REAL", VarType.REAL, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "TOD_TO_LREAL", "Convert TOD to LREAL", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "TOD_TO_LREAL", VarType.TOD, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "TOD_TO_LREAL", VarType.LREAL, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "TOD_TO_SINT", "Convert TOD to SINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "TOD_TO_SINT", VarType.TOD, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "TOD_TO_SINT", VarType.SINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "TOD_TO_INT", "Convert TOD to INT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "TOD_TO_INT", VarType.TOD, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "TOD_TO_INT", VarType.INT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "TOD_TO_DINT", "Convert TOD to DINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "TOD_TO_DINT", VarType.TOD, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "TOD_TO_DINT", VarType.DINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "TOD_TO_LINT", "Convert TOD to LINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "TOD_TO_LINT", VarType.TOD, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "TOD_TO_LINT", VarType.LINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "TOD_TO_USINT", "Convert TOD to USINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "TOD_TO_USINT", VarType.TOD, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "TOD_TO_USINT", VarType.USINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "TOD_TO_UINT", "Convert TOD to UINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "TOD_TO_UINT", VarType.TOD, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "TOD_TO_UINT", VarType.UINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "TOD_TO_UDINT", "Convert TOD to UDINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "TOD_TO_UDINT", VarType.TOD, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "TOD_TO_UDINT", VarType.UDINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "TOD_TO_ULINT", "Convert TOD to ULINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "TOD_TO_ULINT", VarType.TOD, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "TOD_TO_ULINT", VarType.ULINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "DT_TO_REAL", "Convert DT to REAL", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "DT_TO_REAL", VarType.DT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "DT_TO_REAL", VarType.REAL, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "DT_TO_LREAL", "Convert DT to LREAL", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "DT_TO_LREAL", VarType.DT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "DT_TO_LREAL", VarType.LREAL, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "DT_TO_SINT", "Convert DT to SINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "DT_TO_SINT", VarType.DT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "DT_TO_SINT", VarType.SINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "DT_TO_INT", "Convert DT to INT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "DT_TO_INT", VarType.DT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "DT_TO_INT", VarType.INT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "DT_TO_DINT", "Convert DT to DINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "DT_TO_DINT", VarType.DT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "DT_TO_DINT", VarType.DINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "DT_TO_LINT", "Convert DT to LINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "DT_TO_LINT", VarType.DT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "DT_TO_LINT", VarType.LINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "DT_TO_USINT", "Convert DT to USINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "DT_TO_USINT", VarType.DT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "DT_TO_USINT", VarType.USINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "DT_TO_UINT", "Convert DT to UINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "DT_TO_UINT", VarType.DT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "DT_TO_UINT", VarType.UINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "DT_TO_UDINT", "Convert DT to UDINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "DT_TO_UDINT", VarType.DT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "DT_TO_UDINT", VarType.UDINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "DT_TO_ULINT", "Convert DT to ULINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "DT_TO_ULINT", VarType.DT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "DT_TO_ULINT", VarType.ULINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "DATE_TO_BYTE", "Convert DATE to BYTE", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "DATE_TO_BYTE", VarType.DATE, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "DATE_TO_BYTE", VarType.BYTE, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "DATE_TO_WORD", "Convert DATE to WORD", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "DATE_TO_WORD", VarType.DATE, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "DATE_TO_WORD", VarType.WORD, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "DATE_TO_DWORD", "Convert DATE to DWORD", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "DATE_TO_DWORD", VarType.DATE, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "DATE_TO_DWORD", VarType.DWORD, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "DATE_TO_LWORD", "Convert DATE to LWORD", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "DATE_TO_LWORD", VarType.DATE, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "DATE_TO_LWORD", VarType.LWORD, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "DATE_TO_BOOL", "Convert DATE to BOOL", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "DATE_TO_BOOL", VarType.DATE, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "DATE_TO_BOOL", VarType.BOOL, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "TOD_TO_BYTE", "Convert TOD to BYTE", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "TOD_TO_BYTE", VarType.TOD, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "TOD_TO_BYTE", VarType.BYTE, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "TOD_TO_WORD", "Convert TOD to WORD", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "TOD_TO_WORD", VarType.TOD, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "TOD_TO_WORD", VarType.WORD, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "TOD_TO_DWORD", "Convert TOD to DWORD", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "TOD_TO_DWORD", VarType.TOD, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "TOD_TO_DWORD", VarType.DWORD, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "TOD_TO_LWORD", "Convert TOD to LWORD", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "TOD_TO_LWORD", VarType.TOD, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "TOD_TO_LWORD", VarType.LWORD, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "TOD_TO_BOOL", "Convert TOD to BOOL", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "TOD_TO_BOOL", VarType.TOD, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "TOD_TO_BOOL", VarType.BOOL, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "DT_TO_BYTE", "Convert DT to BYTE", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "DT_TO_BYTE", VarType.DT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "DT_TO_BYTE", VarType.BYTE, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "DT_TO_WORD", "Convert DT to WORD", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "DT_TO_WORD", VarType.DT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "DT_TO_WORD", VarType.WORD, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "DT_TO_DWORD", "Convert DT to DWORD", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "DT_TO_DWORD", VarType.DT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "DT_TO_DWORD", VarType.DWORD, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "DT_TO_LWORD", "Convert DT to LWORD", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "DT_TO_LWORD", VarType.DT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "DT_TO_LWORD", VarType.LWORD, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "DT_TO_BOOL", "Convert DT to BOOL", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "DT_TO_BOOL", VarType.DT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "DT_TO_BOOL", VarType.BOOL, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "DT_TO_DATE", "Convert DT to DATE", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "DT_TO_DATE", VarType.DT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "DT_TO_DATE", VarType.DATE, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "DT_TO_DT", "Convert DT to DT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "DT_TO_DT", VarType.DT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "DT_TO_DT", VarType.DT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "DT_TO_TOD", "Convert DT to TOD", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "DT_TO_TOD", VarType.DT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "DT_TO_TOD", VarType.TOD, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "DATE_TO_DATE", "Convert DATE to DATE", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "DATE_TO_DATE", VarType.DATE, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "DATE_TO_DATE", VarType.DATE, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "TOD_TO_TOD", "Convert TOD to TOD", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "TOD_TO_TOD", VarType.TOD, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "TOD_TO_TOD", VarType.TOD, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "TIME_TO_TIME", "Convert TIME to TIME", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "TIME_TO_TIME", VarType.TIME, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "TIME_TO_TIME", VarType.TIME, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "BYTE_TO_STRING", "Convert BYTE to STRING", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "BYTE_TO_STRING", VarType.BYTE, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "BYTE_TO_STRING", VarType.STRING, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "WORD_TO_STRING", "Convert WORD to STRING", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "WORD_TO_STRING", VarType.WORD, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "WORD_TO_STRING", VarType.STRING, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "DWORD_TO_STRING", "Convert DWORD to STRING", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "DWORD_TO_STRING", VarType.DWORD, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "DWORD_TO_STRING", VarType.STRING, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "LWORD_TO_STRING", "Convert LWORD to STRING", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "LWORD_TO_STRING", VarType.LWORD, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "LWORD_TO_STRING", VarType.STRING, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "BOOL_TO_STRING", "Convert BOOL to STRING", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "BOOL_TO_STRING", VarType.BOOL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "BOOL_TO_STRING", VarType.STRING, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "REAL_TO_STRING", "Convert REAL to STRING", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "REAL_TO_STRING", VarType.REAL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "REAL_TO_STRING", VarType.STRING, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "LREAL_TO_STRING", "Convert LREAL to STRING", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "LREAL_TO_STRING", VarType.LREAL, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "LREAL_TO_STRING", VarType.STRING, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "SINT_TO_STRING", "Convert SINT to STRING", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "SINT_TO_STRING", VarType.SINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "SINT_TO_STRING", VarType.STRING, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "INT_TO_STRING", "Convert INT to STRING", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "INT_TO_STRING", VarType.INT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "INT_TO_STRING", VarType.STRING, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "DINT_TO_STRING", "Convert DINT to STRING", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "DINT_TO_STRING", VarType.DINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "DINT_TO_STRING", VarType.STRING, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "LINT_TO_STRING", "Convert LINT to STRING", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "LINT_TO_STRING", VarType.LINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "LINT_TO_STRING", VarType.STRING, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "USINT_TO_STRING", "Convert USINT to STRING", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "USINT_TO_STRING", VarType.USINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "USINT_TO_STRING", VarType.STRING, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "UINT_TO_STRING", "Convert UINT to STRING", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "UINT_TO_STRING", VarType.UINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "UINT_TO_STRING", VarType.STRING, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "UDINT_TO_STRING", "Convert UDINT to STRING", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "UDINT_TO_STRING", VarType.UDINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "UDINT_TO_STRING", VarType.STRING, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "ULINT_TO_STRING", "Convert ULINT to STRING", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "ULINT_TO_STRING", VarType.ULINT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "ULINT_TO_STRING", VarType.STRING, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "DATE_TO_STRING", "Convert DATE to STRING", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "DATE_TO_STRING", VarType.DATE, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "DATE_TO_STRING", VarType.STRING, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "TOD_TO_STRING", "Convert TOD to STRING", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "TOD_TO_STRING", VarType.TOD, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "TOD_TO_STRING", VarType.STRING, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "DT_TO_STRING", "Convert DT to STRING", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "DT_TO_STRING", VarType.DT, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "DT_TO_STRING", VarType.STRING, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "TIME_TO_STRING", "Convert TIME to STRING", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "TIME_TO_STRING", VarType.TIME, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "TIME_TO_STRING", VarType.STRING, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "STRING_TO_BYTE", "Convert STRING to BYTE", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "STRING_TO_BYTE", VarType.STRING, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "STRING_TO_BYTE", VarType.BYTE, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "STRING_TO_WORD", "Convert STRING to WORD", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "STRING_TO_WORD", VarType.STRING, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "STRING_TO_WORD", VarType.WORD, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "STRING_TO_DWORD", "Convert STRING to DWORD", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "STRING_TO_DWORD", VarType.STRING, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "STRING_TO_DWORD", VarType.DWORD, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "STRING_TO_LWORD", "Convert STRING to LWORD", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "STRING_TO_LWORD", VarType.STRING, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "STRING_TO_LWORD", VarType.LWORD, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "STRING_TO_BOOL", "Convert STRING to BOOL", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "STRING_TO_BOOL", VarType.STRING, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "STRING_TO_BOOL", VarType.BOOL, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "STRING_TO_REAL", "Convert STRING to REAL", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "STRING_TO_REAL", VarType.STRING, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "STRING_TO_REAL", VarType.REAL, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "STRING_TO_LREAL", "Convert STRING to LREAL", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "STRING_TO_LREAL", VarType.STRING, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "STRING_TO_LREAL", VarType.LREAL, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "STRING_TO_SINT", "Convert STRING to SINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "STRING_TO_SINT", VarType.STRING, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "STRING_TO_SINT", VarType.SINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "STRING_TO_INT", "Convert STRING to INT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "STRING_TO_INT", VarType.STRING, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "STRING_TO_INT", VarType.INT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "STRING_TO_DINT", "Convert STRING to DINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "STRING_TO_DINT", VarType.STRING, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "STRING_TO_DINT", VarType.DINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "STRING_TO_LINT", "Convert STRING to LINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "STRING_TO_LINT", VarType.STRING, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "STRING_TO_LINT", VarType.LINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "STRING_TO_USINT", "Convert STRING to USINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "STRING_TO_USINT", VarType.STRING, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "STRING_TO_USINT", VarType.USINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "STRING_TO_UINT", "Convert STRING to UINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "STRING_TO_UINT", VarType.STRING, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "STRING_TO_UINT", VarType.UINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "STRING_TO_UDINT", "Convert STRING to UDINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "STRING_TO_UDINT", VarType.STRING, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "STRING_TO_UDINT", VarType.UDINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "STRING_TO_ULINT", "Convert STRING to ULINT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "STRING_TO_ULINT", VarType.STRING, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "STRING_TO_ULINT", VarType.ULINT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "STRING_TO_DATE", "Convert STRING to DATE", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "STRING_TO_DATE", VarType.STRING, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "STRING_TO_DATE", VarType.DATE, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "STRING_TO_TOD", "Convert STRING to TOD", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "STRING_TO_TOD", VarType.STRING, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "STRING_TO_TOD", VarType.TOD, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "STRING_TO_DT", "Convert STRING to DT", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "STRING_TO_DT", VarType.STRING, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "STRING_TO_DT", VarType.DT, VarClass.Output, false, 0, " ");
            tblFunction.InsertFunction(ConnectionString, "STRING_TO_TIME", "Convert STRING to TIME", FunctionGroup.TYPE_CONVERSION, false, true);
            tblPin.InsertPin(ConnectionString, "IN", "STRING_TO_TIME", VarType.STRING, VarClass.Input, false, 0, " ");
            tblPin.InsertPin(ConnectionString, "OUT", "STRING_TO_TIME", VarType.TIME, VarClass.Output, false, 0, " ");

        }
       
        
        private void Common()
        {
            CreateTable("Create Table tblCommon([NAME] Varchar(50) UNIQUE,"+
                "[ControllerName] varchar(50), " +
                "[DomainName] Varchar(50)," +
                "[Description] Varchar(120) default (' '), " +
                "[InitialVal] Varchar(50)," +
                "[Type] int, " +
                "[Class] int, " +
                "[Option] int, " +
                "PRIMARY KEY(ProgramName, ControllerName,DomainName), " +
                "FOREIGN KEY (ControllerName,DomainName) References tblController(ControllerName,DomainName) on delete cascade on update cascade" +
                 ")");

        }
        // 021 44867689
        //+98 912 3943683

        private void AI()
        {
            CreateTable("Create Table AI([NAME] Varchar(50) References Common(Name) on delete cascade on update cascade, " +
                "[PointIndex] int Default 0, [SampleTime] int Default 0, " +
                "[PointGroup] int Default 0, [BoardName] varchar(50), " +
                "[UNI] Varchar(10) DEFAULT 'unit', [FOR] Varchar(10) DEFAULT 'format'," +
                "[IRL_LIM] real Default 0, [IRL_EBL] int Default 0, [IRL_TXT] Varchar(15) DEFAULT 'Text', [IRL_AUD] int Default 0, [IRL_TYP] int Default 0, [IRL_PRN] int Default 0," +
                "[IRH_LIM] real Default 0, [IRH_EBL] int Default 0, [IRH_TXT] Varchar(15) DEFAULT 'Text', [IRH_AUD] int  Default 0, [IRH_TYP] int Default 0, [IRH_PRN] int Default 0," +
                "[LL_LIM] real Default 0, [LL_EBL] int Default 0, [LL_TXT] Varchar(15) DEFAULT 'Text', [LL_AUD] int Default 0, [LL_TYP] int Default 0, [LL_PRN] int Default 0," +
                "[HH_LIM] real Default 0, [HH_EBL] int Default 0, [HH_TXT] Varchar(15) DEFAULT 'Text', [HH_AUD] int Default 0, [HH_TYP] int Default 0, [HH_PRN] int Default 0," +
                "[L_LIM] real Default 0, [L_EBL] int Default 0, [L_TXT] Varchar(15) DEFAULT 'Text', [L_AUD] int Default 0, [L_TYP] int Default 0, [L_PRN] int Default 0," +
                "[H_LIM] real Default 0, [H_EBL] int Default 0, [H_TXT] Varchar(15) DEFAULT 'Text', [H_AUD] int Default 0, [H_TYP] int Default 0, [H_PRN] int Default 0," +
                "[CHN] int, [AD0] real Default 0, [AD1] int Default 0, [EN0] real Default 0, [EN1] real Default 0, [FLT] int Default 0, [DEB] int Default 0, " +
                "FOREIGN KEY (BoardName, Station) References Boards(Name, StationName) on delete cascade on update cascade)");

        }

        private void AO()
        {
            CreateTable("Create Table AO([NAME] Varchar(50) References Common(Name) on delete cascade on update cascade, [Description] Varchar(120) NOT NULL, [Station] varchar(50), [PointIndex] int Default 0, [SampleTime] int Default 0, [DCSISA] int Default 0, [PointGroup] int Default 0, [Retain] bit Default 0, [BoardName] varchar(50), " +
                "[INI] real Default 0, [UNI] Varchar(10) DEFAULT 'unit', [FOR] Varchar(10) DEFAULT 'format', [IRL_LIM] real Default 0, [IRL_EBL] int Default 0, [IRL_TXT] Varchar(15) DEFAULT 'Text', [IRL_AUD] int Default 0, [IRL_TYP] int Default 0, [IRL_PRN] int Default 0," +
                "[IRH_LIM] real Default 0, [IRH_EBL] int Default 0, [IRH_TXT] Varchar(15) DEFAULT 'Text', [IRH_AUD] int Default 0, [IRH_TYP] int Default 0, [IRH_PRN] int Default 0," +
                "[LL_LIM] real Default 0, [LL_EBL] int Default 0, [LL_TXT] Varchar(15) DEFAULT 'Text', [LL_AUD] int Default 0, [LL_TYP] int Default 0, [LL_PRN] int Default 0," +
                "[HH_LIM] real Default 0, [HH_EBL] int Default 0, [HH_TXT] Varchar(15) DEFAULT 'Text', [HH_AUD] int Default 0, [HH_TYP] int Default 0, [HH_PRN] int Default 0," +
                "[L_LIM] real Default 0, [L_EBL] int Default 0, [L_TXT] Varchar(15) DEFAULT 'Text', [L_AUD] int Default 0, [L_TYP] int Default 0, [L_PRN] int Default 0," +
                "[H_LIM] real Default 0, [H_EBL] int Default 0, [H_TXT] Varchar(15) DEFAULT 'Text', [H_AUD] int Default 0, [H_TYP] int Default 0, [H_PRN] int Default 0," +
                "[RTR] real Default 0, [CHN] int, [NUM] int Default 0, [AD0] real Default 0, [AD1] int Default 0, [EN0] real Default 0, [EN1] real Default 0, FOREIGN KEY (BoardName, Station) References Boards(Name, StationName) on delete cascade on update cascade)");

        }

        private void ACR()
        {
            CreateTable("Create Table ACR([NAME] Varchar(50) References Common(Name) on delete cascade on update cascade, [Description] Varchar(120) NOT NULL, [Station] varchar(50) references LCU(Name) on delete cascade on update cascade," +
                "[PointIndex] int  Default 0, [SampleTime] int Default 0, [DCSISA] int Default 0, [PointGroup] int Default 0, [Retain] bit Default 0, [INI] real Default 0, [UNI] Varchar(10) DEFAULT 'unit', [FOR] Varchar(10) DEFAULT 'format'," +
                "[IRL_LIM] real Default 0, [IRL_EBL] int Default 0, [IRL_TXT] Varchar(15) DEFAULT 'Text', [IRL_AUD] int Default 0, [IRL_TYP] int Default 0, [IRL_PRN] int Default 0," +
                "[IRH_LIM] real Default 0, [IRH_EBL] int Default 0, [IRH_TXT] Varchar(15) DEFAULT 'Text', [IRH_AUD] int Default 0, [IRH_TYP] int Default 0, [IRH_PRN] int Default 0," +
                "[LL_LIM] real Default 0, [LL_EBL] int Default 0, [LL_TXT] Varchar(15) DEFAULT 'Text', [LL_AUD] int Default 0, [LL_TYP] int Default 0, [LL_PRN] int Default 0," +
                "[HH_LIM] real Default 0, [HH_EBL] int Default 0, [HH_TXT] Varchar(15) DEFAULT 'Text', [HH_AUD] int Default 0, [HH_TYP] int Default 0, [HH_PRN] int Default 0," +
                "[L_LIM] real Default 0, [L_EBL] int Default 0, [L_TXT] Varchar(15) DEFAULT 'Text', [L_AUD] int Default 0, [L_TYP] int Default 0, [L_PRN] int Default 0," +
                "[H_LIM] real Default 0, [H_EBL] int Default 0, [H_TXT] Varchar(15) DEFAULT 'Text', [H_AUD] int Default 0, [H_TYP] int Default 0, [H_PRN] int Default 0," +
                "[RTR] real Default 0, [Link] int Default 0, [SlaveNo] int Default 0, [REG] int Default 0, [Multiplicator] real Default 0, [IO_Modbus] int Default 0," +
                "[Real] int Default 0, [PBSLV] int Default 0, [PBADR] int Default 0, [PBBIT] int Default 0, [PBTYP] int Default 0)");

        }

        private void ACI()
        {
            CreateTable("Create Table ACI([NAME] Varchar(50) References Common(Name) on delete cascade on update cascade, [Description] Varchar(120) NOT NULL, [Station] varchar(50) references LCU(Name) on delete cascade on update cascade," +
                "[PointIndex] int Default 0, [SampleTime] int Default 0, [DCSISA] int Default 0, [PointGroup] int Default 0,[Retain] bit Default 0, [INI] int Default 0, [UNI] Varchar(10) DEFAULT 'unit', [FOR] Varchar(10) DEFAULT 'format'," +
                "[IRL_LIM] real Default 0, [IRL_EBL] int Default 0, [IRL_TXT] Varchar(15) DEFAULT 'Text', [IRL_AUD] int Default 0, [IRL_TYP] int Default 0, [IRL_PRN] int Default 0," +
                "[IRH_LIM] real Default 0, [IRH_EBL] int Default 0, [IRH_TXT] Varchar(15) DEFAULT 'Text', [IRH_AUD] int Default 0, [IRH_TYP] int Default 0, [IRH_PRN] int Default 0," +
                "[LL_LIM] real Default 0, [LL_EBL] int Default 0, [LL_TXT] Varchar(15) DEFAULT 'Text', [LL_AUD] int Default 0, [LL_TYP] int Default 0, [LL_PRN] int Default 0," +
                "[HH_LIM] real Default 0, [HH_EBL] int Default 0, [HH_TXT] Varchar(15) DEFAULT 'Text', [HH_AUD] int Default 0, [HH_TYP] int Default 0, [HH_PRN] int Default 0," +
                "[L_LIM] real Default 0, [L_EBL] int Default 0, [L_TXT] Varchar(15) DEFAULT 'Text', [L_AUD] int Default 0, [L_TYP] int Default 0, [L_PRN] int Default 0," +
                "[H_LIM] real Default 0, [H_EBL] int Default 0, [H_TXT] Varchar(15) DEFAULT 'Text', [H_AUD] int Default 0, [H_TYP] int Default 0, [H_PRN] int Default 0," +
                "[RTR] real Default 0, [Link] int Default 0, [SlaveNo] int Default 0, [REG] int Default 0, [Multiplicator] real Default 0, [IO_Modbus] int Default 0," +
                "[Real] int Default 0, [PBSLV] int Default 0, [PBADR] int Default 0, [PBBIT] int Default 0, [PBTYP] int Default 0)");


        }

        private void DI()
        {
            CreateTable("Create Table DI([NAME] Varchar(50) References Common(Name) on delete cascade on update cascade, [Description] Varchar(120) NOT NULL, [Station] varchar(50), [PointIndex] int Default 0, [SampleTime] int Default 0, [DCSISA] int Default 0, [PointGroup] int Default 0, [Retain] bit Default 0, [BoardName] varchar(50), [NR_EBL] int Default 0, [NR_TXT] Varchar(50) DEFAULT 'Text'," +
                "[NR_AUD] int Default 0, [NR_TYP] int Default 0, [NR_PRN] int Default 0, [AB_EBL] int Default 0, [AB_TXT] Varchar(50) DEFAULT 'Text', [AB_AUD] int Default 0, [AB_TYP] int Default 0, [AB_PRN] int Default 0, [INI] bit Default 0, [CHN] int, [INV] int Default 0, FOREIGN KEY (BoardName, Station) References Boards(Name, StationName) on delete cascade on update cascade)");


        }
        private void DO()
        {
            CreateTable("Create Table DO([NAME] Varchar(50) References Common(Name) on delete cascade on update cascade, [Description] Varchar(120) NOT NULL, [Station] varchar(50), [PointIndex] int Default 0, [SampleTime] int Default 0, [DCSISA] int Default 0, [PointGroup] int Default 0, [Retain] bit Default 0, [BoardName] varchar(50), " +
                "[NR_EBL] int Default 0, [NR_TXT] Varchar(50) DEFAULT 'Text', [NR_AUD] int Default 0, [NR_TYP] int Default 0, [NR_PRN] int Default 0, [AB_EBL] int Default 0, [AB_TXT] Varchar(50) DEFAULT 'Text', [AB_AUD] int Default 0, [AB_TYP] int Default 0, [AB_PRN] int Default 0, [INI] bit Default 0, [CHN] int, [INV] int Default 0, [PER] int Default 0, [OPD] int Default 0, FOREIGN KEY (BoardName, Station) References Boards(Name, StationName) on delete cascade on update cascade)");

        }
        private void DC()
        {
            CreateTable("Create Table DC([NAME] Varchar(50) References Common(Name) on delete cascade on update cascade, [Description] Varchar(120) NOT NULL, [Station] varchar(50) references LCU(Name) on delete cascade on update cascade," +
                "[PointIndex] int Default 0, [SampleTime] int Default 0, [DCSISA] int Default 0, [PointGroup] int Default 0, [Retain] bit Default 0, [NR_EBL] int Default 0, [NR_TXT] Varchar(50) DEFAULT 'Text'," +
                "[NR_AUD] int Default 0, [NR_TYP] int Default 0, [NR_PRN] int Default 0, [AB_EBL] int Default 0," +
                "[AB_TXT] Varchar(50) DEFAULT 'Text', [AB_AUD] int Default 0, [AB_TYP] int Default 0, [AB_PRN] int Default 0, [INI] bit Default 0, [PER] int Default 0," +
                "[OPD] int Default 0, [CTX] Varchar(50), [Link] int Default 0, [SlaveNo] int Default 0, [REG] int Default 0, [_BIT] int Default 0," +
                "[IO_Modbus] int Default 0, [PBSLV] int Default 0, [PBADR] int Default 0, [PBBIT] int Default 0, [PBTYP] int Default 0)");


        }
		private void Timers()
		{
            CreateTable("Create Table Timers([Name] Varchar(50)," +
                "PRIMARY KEY(Name), " +
                "FOREIGN KEY (Name) References tblCommon(Name) on delete cascade on update cascade" +
                 ")");
		}
		
		

		

		#region Stations
		private void Stations()
		{
			CreateTable("Create Table Stations([Name] Varchar(50) PRIMARY KEY, [StationNo] int IDENTITY)");
		}

		
		private void OWS()
		{
			CreateTable("Create Table OWS([Name] Varchar(50) References Stations(Name) on delete cascade on update cascade, [Description] Varchar(120) NOT NULL, [IP1] int NOT NULL, [IP2] int NOT NULL, [PrinterType] int NOT NULL)");
		}

		private void DAS()
		{
			CreateTable("Create Table DAS([Name] Varchar(50) References Stations(Name) on delete cascade on update cascade, [Description] Varchar(120), [Redundant] bit NOT NULL, [IP1] int NOT NULL, [IP2] int NOT NULL, [IP3] int NOT NULL, [IP4] int NOT NULL, [PrinterType1] int NOT NULL, [PrinterType2] int)");
		}

		
		#endregion

		

		private void Pages()
		{
			CreateTable("Create Table Pages([Name] Varchar(50), [Description] Varchar(120), [ProgramName] Varchar(50), [StationName] Varchar(50), [PageIndex] int, [Type] int, PRIMARY KEY(Name, ProgramName, StationName), FOREIGN KEY (ProgramName, StationName) References Programs(Name, StationName) on delete cascade on update cascade)");
		}


		private void Displays()
		{
			CreateTable("Create Table Displays([FullPath] varchar(100) NOT NULL PRIMARY KEY, [NodeIndex] int NOT NULL," +
				"[NodeLevel] int NOT NULL, [NodeType] int NOT NULL)");


		}

		private void ModbusPorts()
		{
			CreateTable("Create Table ModbusPorts([Name] varchar(50) NOT NULL, [BaudRate] int NOT NULL," +
				"[Parity] int NOT NULL, [DataBits] int NOT NULL, [StopBits] int NOT NULL, [BoardName] varchar(50) references Boards(Name) on delete cascade on update cascade, [StationName] varchar(50) references Boards(StationName) on delete cascade on update cascade, PRIMARY KEY(Name, StationName))");


		}

		private void ModbusPortNodes()
		{
			CreateTable("Create Table ModbusPortNodes([Name] varchar(50) NOT NULL, [SlaveNo] int NOT NULL," +
			"[ReadDFC] int NOT NULL, [WriteDFC] int NOT NULL, [ReadAFC] int NOT NULL, [WriteAFC] int NOT NULL, [BoardName] varchar(50) references Boards(Name) on delete cascade on update cascade, [StationName] varchar(50) references Boards(StationName) on delete cascade on update cascade, [PortName] varchar(50) references ModbusPorts(Name) on delete cascade on update cascade, PRIMARY KEY(Name, StationName, PortName))");

		}

		private void DINodePoints()
		{
			CreateTable("Create Table DINodePoints([Name] varchar(50) references DI(Name) on update cascade on delete cascade, [NodeName] varchar(50) references ModbusPortNodes(Name) on update cascade on delete cascade, [Reg] int NOT NULL," +
			"[Bit] int NOT NULL))");
		}

		private void Blocks()
		{
			CreateTable("Create Table Blocks([FullPath] Varchar(100)  NOT NULL PRIMARY KEY, [NodeIndex] int NOT NULL," +
				"[NodeLevel] int NOT NULL, [NodeType] int NOT NULL)");

		}

        //private void Common()
        //{
        //    CreateTable("Create Table Common([NAME] Varchar(50) PRIMARY KEY)");

        //}

        //private void AI()
        //{
        //    CreateTable("Create Table AI([NAME] Varchar(50) References Common(Name) on delete cascade on update cascade, [Description] Varchar(120) NOT NULL, [Station] varchar(50), [PointIndex] int Default 0, [SampleTime] int Default 0, [DCSISA] int Default 0, [PointGroup] int Default 0, [Retain] bit Default 0, [BoardName] varchar(50), [INI] real Default 0, [UNI] Varchar(10) DEFAULT 'unit', [FOR] Varchar(10) DEFAULT 'format'," +
        //        "[IRL_LIM] real Default 0, [IRL_EBL] int Default 0, [IRL_TXT] Varchar(15) DEFAULT 'Text', [IRL_AUD] int Default 0, [IRL_TYP] int Default 0, [IRL_PRN] int Default 0," +
        //        "[IRH_LIM] real Default 0, [IRH_EBL] int Default 0, [IRH_TXT] Varchar(15) DEFAULT 'Text', [IRH_AUD] int  Default 0, [IRH_TYP] int Default 0, [IRH_PRN] int Default 0," +
        //        "[LL_LIM] real Default 0, [LL_EBL] int Default 0, [LL_TXT] Varchar(15) DEFAULT 'Text', [LL_AUD] int Default 0, [LL_TYP] int Default 0, [LL_PRN] int Default 0," +
        //        "[HH_LIM] real Default 0, [HH_EBL] int Default 0, [HH_TXT] Varchar(15) DEFAULT 'Text', [HH_AUD] int Default 0, [HH_TYP] int Default 0, [HH_PRN] int Default 0," +
        //        "[L_LIM] real Default 0, [L_EBL] int Default 0, [L_TXT] Varchar(15) DEFAULT 'Text', [L_AUD] int Default 0, [L_TYP] int Default 0, [L_PRN] int Default 0," +
        //        "[H_LIM] real Default 0, [H_EBL] int Default 0, [H_TXT] Varchar(15) DEFAULT 'Text', [H_AUD] int Default 0, [H_TYP] int Default 0, [H_PRN] int Default 0," +
        //        "[RTR] real Default 0, [CHN] int, [NUM] int Default 0, [AD0] real Default 0, [AD1] int Default 0, [EN0] real Default 0, [EN1] real Default 0, [FLT] int Default 0, [DEB] int Default 0, FOREIGN KEY (BoardName, Station) References Boards(Name, StationName) on delete cascade on update cascade)");

        //}

        //private void AO()
        //{
        //    CreateTable("Create Table AO([NAME] Varchar(50) References Common(Name) on delete cascade on update cascade, [Description] Varchar(120) NOT NULL, [Station] varchar(50), [PointIndex] int Default 0, [SampleTime] int Default 0, [DCSISA] int Default 0, [PointGroup] int Default 0, [Retain] bit Default 0, [BoardName] varchar(50), " +
        //        "[INI] real Default 0, [UNI] Varchar(10) DEFAULT 'unit', [FOR] Varchar(10) DEFAULT 'format', [IRL_LIM] real Default 0, [IRL_EBL] int Default 0, [IRL_TXT] Varchar(15) DEFAULT 'Text', [IRL_AUD] int Default 0, [IRL_TYP] int Default 0, [IRL_PRN] int Default 0," +
        //        "[IRH_LIM] real Default 0, [IRH_EBL] int Default 0, [IRH_TXT] Varchar(15) DEFAULT 'Text', [IRH_AUD] int Default 0, [IRH_TYP] int Default 0, [IRH_PRN] int Default 0," +
        //        "[LL_LIM] real Default 0, [LL_EBL] int Default 0, [LL_TXT] Varchar(15) DEFAULT 'Text', [LL_AUD] int Default 0, [LL_TYP] int Default 0, [LL_PRN] int Default 0," +
        //        "[HH_LIM] real Default 0, [HH_EBL] int Default 0, [HH_TXT] Varchar(15) DEFAULT 'Text', [HH_AUD] int Default 0, [HH_TYP] int Default 0, [HH_PRN] int Default 0," +
        //        "[L_LIM] real Default 0, [L_EBL] int Default 0, [L_TXT] Varchar(15) DEFAULT 'Text', [L_AUD] int Default 0, [L_TYP] int Default 0, [L_PRN] int Default 0," +
        //        "[H_LIM] real Default 0, [H_EBL] int Default 0, [H_TXT] Varchar(15) DEFAULT 'Text', [H_AUD] int Default 0, [H_TYP] int Default 0, [H_PRN] int Default 0," +
        //        "[RTR] real Default 0, [CHN] int, [NUM] int Default 0, [AD0] real Default 0, [AD1] int Default 0, [EN0] real Default 0, [EN1] real Default 0, FOREIGN KEY (BoardName, Station) References Boards(Name, StationName) on delete cascade on update cascade)");

        //}

        //private void ACR()
        //{
        //    CreateTable("Create Table ACR([NAME] Varchar(50) References Common(Name) on delete cascade on update cascade, [Description] Varchar(120) NOT NULL, [Station] varchar(50) references LCU(Name) on delete cascade on update cascade," +
        //        "[PointIndex] int  Default 0, [SampleTime] int Default 0, [DCSISA] int Default 0, [PointGroup] int Default 0, [Retain] bit Default 0, [INI] real Default 0, [UNI] Varchar(10) DEFAULT 'unit', [FOR] Varchar(10) DEFAULT 'format'," +
        //        "[IRL_LIM] real Default 0, [IRL_EBL] int Default 0, [IRL_TXT] Varchar(15) DEFAULT 'Text', [IRL_AUD] int Default 0, [IRL_TYP] int Default 0, [IRL_PRN] int Default 0," +
        //        "[IRH_LIM] real Default 0, [IRH_EBL] int Default 0, [IRH_TXT] Varchar(15) DEFAULT 'Text', [IRH_AUD] int Default 0, [IRH_TYP] int Default 0, [IRH_PRN] int Default 0," +
        //        "[LL_LIM] real Default 0, [LL_EBL] int Default 0, [LL_TXT] Varchar(15) DEFAULT 'Text', [LL_AUD] int Default 0, [LL_TYP] int Default 0, [LL_PRN] int Default 0," +
        //        "[HH_LIM] real Default 0, [HH_EBL] int Default 0, [HH_TXT] Varchar(15) DEFAULT 'Text', [HH_AUD] int Default 0, [HH_TYP] int Default 0, [HH_PRN] int Default 0," +
        //        "[L_LIM] real Default 0, [L_EBL] int Default 0, [L_TXT] Varchar(15) DEFAULT 'Text', [L_AUD] int Default 0, [L_TYP] int Default 0, [L_PRN] int Default 0," +
        //        "[H_LIM] real Default 0, [H_EBL] int Default 0, [H_TXT] Varchar(15) DEFAULT 'Text', [H_AUD] int Default 0, [H_TYP] int Default 0, [H_PRN] int Default 0," +
        //        "[RTR] real Default 0, [Link] int Default 0, [SlaveNo] int Default 0, [REG] int Default 0, [Multiplicator] real Default 0, [IO_Modbus] int Default 0," +
        //        "[Real] int Default 0, [PBSLV] int Default 0, [PBADR] int Default 0, [PBBIT] int Default 0, [PBTYP] int Default 0)");

        //}

        //private void ACI()
        //{
        //    CreateTable("Create Table ACI([NAME] Varchar(50) References Common(Name) on delete cascade on update cascade, [Description] Varchar(120) NOT NULL, [Station] varchar(50) references LCU(Name) on delete cascade on update cascade," +
        //        "[PointIndex] int Default 0, [SampleTime] int Default 0, [DCSISA] int Default 0, [PointGroup] int Default 0,[Retain] bit Default 0, [INI] int Default 0, [UNI] Varchar(10) DEFAULT 'unit', [FOR] Varchar(10) DEFAULT 'format'," +
        //        "[IRL_LIM] real Default 0, [IRL_EBL] int Default 0, [IRL_TXT] Varchar(15) DEFAULT 'Text', [IRL_AUD] int Default 0, [IRL_TYP] int Default 0, [IRL_PRN] int Default 0," +
        //        "[IRH_LIM] real Default 0, [IRH_EBL] int Default 0, [IRH_TXT] Varchar(15) DEFAULT 'Text', [IRH_AUD] int Default 0, [IRH_TYP] int Default 0, [IRH_PRN] int Default 0," +
        //        "[LL_LIM] real Default 0, [LL_EBL] int Default 0, [LL_TXT] Varchar(15) DEFAULT 'Text', [LL_AUD] int Default 0, [LL_TYP] int Default 0, [LL_PRN] int Default 0," +
        //        "[HH_LIM] real Default 0, [HH_EBL] int Default 0, [HH_TXT] Varchar(15) DEFAULT 'Text', [HH_AUD] int Default 0, [HH_TYP] int Default 0, [HH_PRN] int Default 0," +
        //        "[L_LIM] real Default 0, [L_EBL] int Default 0, [L_TXT] Varchar(15) DEFAULT 'Text', [L_AUD] int Default 0, [L_TYP] int Default 0, [L_PRN] int Default 0," +
        //        "[H_LIM] real Default 0, [H_EBL] int Default 0, [H_TXT] Varchar(15) DEFAULT 'Text', [H_AUD] int Default 0, [H_TYP] int Default 0, [H_PRN] int Default 0," +
        //        "[RTR] real Default 0, [Link] int Default 0, [SlaveNo] int Default 0, [REG] int Default 0, [Multiplicator] real Default 0, [IO_Modbus] int Default 0," +
        //        "[Real] int Default 0, [PBSLV] int Default 0, [PBADR] int Default 0, [PBBIT] int Default 0, [PBTYP] int Default 0)");


        //}

        //private void DI()
        //{
        //    CreateTable("Create Table DI([NAME] Varchar(50) References Common(Name) on delete cascade on update cascade, [Description] Varchar(120) NOT NULL, [Station] varchar(50), [PointIndex] int Default 0, [SampleTime] int Default 0, [DCSISA] int Default 0, [PointGroup] int Default 0, [Retain] bit Default 0, [BoardName] varchar(50), [NR_EBL] int Default 0, [NR_TXT] Varchar(50) DEFAULT 'Text'," +
        //        "[NR_AUD] int Default 0, [NR_TYP] int Default 0, [NR_PRN] int Default 0, [AB_EBL] int Default 0, [AB_TXT] Varchar(50) DEFAULT 'Text', [AB_AUD] int Default 0, [AB_TYP] int Default 0, [AB_PRN] int Default 0, [INI] bit Default 0, [CHN] int, [INV] int Default 0, FOREIGN KEY (BoardName, Station) References Boards(Name, StationName) on delete cascade on update cascade)");


        //}
        //private void DO()
        //{
        //    CreateTable("Create Table DO([NAME] Varchar(50) References Common(Name) on delete cascade on update cascade, [Description] Varchar(120) NOT NULL, [Station] varchar(50), [PointIndex] int Default 0, [SampleTime] int Default 0, [DCSISA] int Default 0, [PointGroup] int Default 0, [Retain] bit Default 0, [BoardName] varchar(50), " +
        //        "[NR_EBL] int Default 0, [NR_TXT] Varchar(50) DEFAULT 'Text', [NR_AUD] int Default 0, [NR_TYP] int Default 0, [NR_PRN] int Default 0, [AB_EBL] int Default 0, [AB_TXT] Varchar(50) DEFAULT 'Text', [AB_AUD] int Default 0, [AB_TYP] int Default 0, [AB_PRN] int Default 0, [INI] bit Default 0, [CHN] int, [INV] int Default 0, [PER] int Default 0, [OPD] int Default 0, FOREIGN KEY (BoardName, Station) References Boards(Name, StationName) on delete cascade on update cascade)");

        //}
        //private void DC()
        //{
        //    CreateTable("Create Table DC([NAME] Varchar(50) References Common(Name) on delete cascade on update cascade, [Description] Varchar(120) NOT NULL, [Station] varchar(50) references LCU(Name) on delete cascade on update cascade," +
        //        "[PointIndex] int Default 0, [SampleTime] int Default 0, [DCSISA] int Default 0, [PointGroup] int Default 0, [Retain] bit Default 0, [NR_EBL] int Default 0, [NR_TXT] Varchar(50) DEFAULT 'Text'," +
        //        "[NR_AUD] int Default 0, [NR_TYP] int Default 0, [NR_PRN] int Default 0, [AB_EBL] int Default 0," +
        //        "[AB_TXT] Varchar(50) DEFAULT 'Text', [AB_AUD] int Default 0, [AB_TYP] int Default 0, [AB_PRN] int Default 0, [INI] bit Default 0, [PER] int Default 0," +
        //        "[OPD] int Default 0, [CTX] Varchar(50), [Link] int Default 0, [SlaveNo] int Default 0, [REG] int Default 0, [_BIT] int Default 0," +
        //        "[IO_Modbus] int Default 0, [PBSLV] int Default 0, [PBADR] int Default 0, [PBBIT] int Default 0, [PBTYP] int Default 0)");


        //}

		//          21,500,000
		//          7,750,000
		//          29,250,000

		private void User()
		{
			CreateTable("Create Table Users([Name] Varchar(50), [UserType] int, [Software] Varchar(50), [Station] Varchar(50), [ChangeUserAccess] bit," +
				"[Download] int, [DownloadIsagraph] bit, [SystemConfiguration] bit, [ChangeDatabase] bit," +
				"[ChangeDisplay] bit, [ChangeBlock] bit, [Build] bit, [RunDAS] bit," +
				"[ProcessView] bit, [Block] bit, [ManualEntered] bit, [Command] bit, [ForceOutput] bit, [Acknowledge] bit," +
				"[Silence] bit, [OnModification] bit, [OnConvTableChan] bit, [EditBoxOperator] bit, [EditBoxSuppervisor] bit, [EditBoxEngineer] bit," +
				"[ButtonOperator] bit, [ButtonSuppervisor] bit, [ButtonEngineer] bit)");

		}

		private void Version()
		{
			CreateTable("Create Table Version([VER] Varchar(20), [LastUpdated] Varchar(50), [BuildVersion] int)");
		}

		

		private void ProjectProperty()
		{
			CreateTable("Create Table ProjectProperty([Snap] int , [Grid] int)");

		}
		private void ProjectTree()
		{
			CreateTable("Create Table ProjectTree([Snap] int , [Grid] int)");

		}

		private void Reports()
		{
			CreateTable("Create Table Reports([ReportName] Varchar(50), [Group1] Varchar(20)," +
				"[Group2] Varchar(20), [Group3] Varchar(20), [Automatic] bit, [CycleTime] int, [OutputToPrinter] bit)");

		}



		private void UserDefFunctions()
		{
			CreateTable("Create Table UserDefFunctions([Name] Varchar(50) PRIMARY KEY, [Expression] Varchar(250), [ExpType] int, " +
				"[VarName1] Varchar(20), [VarType1] Varchar(20), [VarName2] Varchar(20), [VarType2] Varchar(20)," +
				"[VarName3] Varchar(20), [VarType3] Varchar(20), [VarName4] Varchar(20), [VarType4] Varchar(20)," +
				"[VarName5] Varchar(20), [VarType5] Varchar(20), [VarName6] Varchar(20), [VarType6] Varchar(20)," +
				"[VarName7] Varchar(20), [VarType7] Varchar(20), [VarName8] Varchar(20), [VarType8] Varchar(20))");


		}

		

		private void CreateProjectDirectories()
		{
			Directory.CreateDirectory(ProjectPath);
			Directory.CreateDirectory(ProjectPath + "\\" + "Displays");
			Directory.CreateDirectory(ProjectPath + "\\" + "Blocks");
			Directory.CreateDirectory(ProjectPath + "\\" + "Bitmaps");
			Directory.CreateDirectory(ProjectPath + "\\" + "Logics");
			Directory.CreateDirectory(ProjectPath + "\\" + "Reports");

		}

        /// <summary>
		/// this function is temoray function during testing an must be deleted finally
		/// </summary>
        public void temporary_CreateProjectDatabases()
        {
           // Function();
           // Pin();
           // FillStandardFunctions();

        }
		/// <summary>
		/// Create all Databases for parent in Sql server
		/// </summary>
		private void CreateProjectDatabases()
		{
			ProjectProperty();
			Project();
			Domain();
			Controller();
			Rack();
			Board();

            Program();

            Function();
            Pin();
            VariableType();

			//Displays();
			//Blocks();

			//UserDefFunctions();
			//Functions();
			//Pins();

			//Version();

			//Stations();
			//OWS();
		   
			//DAS();
			//Racks();
			//Boards();

			//Common();
			//DI();
			//DO();
			//DC();

			//ACI();

			//AI();
			//AO();
			//ACR();

			//User();

			//Timers();

		   
			
			//Reports();
			//Programs();
			//Pages();

			//ModbusPorts();
			//ModbusPortNodes();

		}

		#region Domain
		
		#endregion
		/// <summary>
		/// set root of trees with parent name
		/// </summary>
		

		public _PROJECT_TREE_TYPES ProjectTreeStructure
		{
			get
			{
				return _projecttreestructure;
			}
			set
			{
				_projecttreestructure = value;
			}
		}

		private _PROJECT_TREE_TYPES _projecttreestructure;

		private string _sqlservername;


		private static string _instansename = "\\ENGINEERING";
		private string _sqlserveripAddress;
		public string SQLServerIPAddress
		{
			get
			{
				return _sqlserveripAddress;
			}
			set
			{
				_sqlserveripAddress = value;
				_sqlservername = _sqlserveripAddress + _instansename;
			}

		}

	}

	

}
