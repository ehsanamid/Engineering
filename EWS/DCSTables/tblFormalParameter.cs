//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;


namespace DCS.DCSTables
{


    public partial class tblFormalParameter : SQLiteTable
	{
		
		#region Static SQL String Memebers
		/// <remarks>This _databasename represents the full INSERT INTO string for the table tblFormalParameter.</remarks>
		internal static string SQL_Insert = @"INSERT INTO [tblFormalParameter] ([PinName], [FunctionID], [Type], [Reference], [Class], [Extensible], [oIndex], [Description], [InitializeValue], [EV_TXT], [EV_EBL], [Option], [FBDPossible], [STEdit], [PropertyType], [ENUM_TEXT], [popback], [pushback]) VALUES(@PinName, @FunctionID, @Type, @Reference, @Class, @Extensible, @oIndex, @Description, @InitializeValue, @EV_TXT, @EV_EBL, @Option, @FBDPossible, @STEdit, @PropertyType, @ENUM_TEXT, @popback, @pushback) ; select last_insert_rowid(); ";
		
		/// <remarks>This _databasename represents the full UPDATE string for the table tblFormalParameter, with the WHERE clause.</remarks>
		internal static string SQL_Update = @"UPDATE [tblFormalParameter] SET [PinName] = @PinName, [FunctionID] = @FunctionID, [Type] = @Type, [Reference] = @Reference, [Class] = @Class, [Extensible] = @Extensible, [oIndex] = @oIndex, [Description] = @Description, [InitializeValue] = @InitializeValue, [EV_TXT] = @EV_TXT, [EV_EBL] = @EV_EBL, [Option] = @Option, [FBDPossible] = @FBDPossible, [STEdit] = @STEdit, [PropertyType] = @PropertyType, [ENUM_TEXT] = @ENUM_TEXT, [popback] = @popback, [pushback] = @pushback WHERE [PinID]=@PinID ";
		
		/// <remarks>This _databasename represents the full SELECT string for the table tblFormalParameter, with the WHERE clause.</remarks>
		internal static string SQL_Select = @"SELECT [PinName], [FunctionID], [Type], [Reference], [Class], [Extensible], [oIndex], [Description], [InitializeValue], [EV_TXT], [EV_EBL], [Option], [FBDPossible], [STEdit], [PropertyType], [ENUM_TEXT], [popback], [pushback] FROM [tblFormalParameter] WHERE [PinID]=@PinID ";
		
		/// <remarks>This _databasename represents the DELETE string for the table tblFormalParameter, with the WHERE clause.</remarks>
		internal static string SQL_Delete = "DELETE FROM [tblFormalParameter] WHERE [PinID]=@PinID ";
		#endregion
		
		#region Tables Memebers
		/// <remarks>SQL Type:System.Int64</remarks>
		private long _PinID = -1;
		
		[DisplayName("Pin ID")]
		[Category("Primary Key")]
		public long PinID
		{
			get
			{
				return _PinID;
			}
			set
			{
				_PinID = value;
			}
		}
		
		/// <remarks>SQL Type:System.String</remarks>
		private string _PinName = "";
		
		[DisplayName("Pin Name")]
		[Category("Column")]
		public string PinName
		{
			get
			{
				return _PinName;
			}
			set
			{
				_PinName = value;
			}
		}
		
		/// <remarks>SQL Type:System.Int64</remarks>
		private long _FunctionID = -1;
		
		[DisplayName("Function ID")]
		[Category("Foreign Key")]
		public long FunctionID
		{
			get
			{
				return _FunctionID;
			}
			set
			{
				_FunctionID = value;
			}
		}
		
		/// <remarks>SQL Type:System.Int32</remarks>
		private int _Type;
		
		[DisplayName("Type")]
		[Category("Column")]
		public int Type
		{
			get
			{
				return _Type;
			}
			set
			{
				_Type = value;
			}
		}
		
		/// <remarks>SQL Type:System.Boolean</remarks>
		private bool _Reference;
		
		[DisplayName("Reference")]
		[Category("Column")]
		public bool Reference
		{
			get
			{
				return _Reference;
			}
			set
			{
				_Reference = value;
			}
		}
		
		/// <remarks>SQL Type:System.Int16</remarks>
		private short _Class;
		
		[DisplayName("Class")]
		[Category("Column")]
		public short Class
		{
			get
			{
				return _Class;
			}
			set
			{
				_Class = value;
			}
		}
		
		/// <remarks>SQL Type:System.Boolean</remarks>
		private bool _Extensible;
		
		[DisplayName("Extensible")]
		[Category("Column")]
		public bool Extensible
		{
			get
			{
				return _Extensible;
			}
			set
			{
				_Extensible = value;
			}
		}
		
		/// <remarks>SQL Type:System.Int32</remarks>
		private int _oIndex;
		
		[DisplayName("o Index")]
		[Category("Column")]
		public int oIndex
		{
			get
			{
				return _oIndex;
			}
			set
			{
				_oIndex = value;
			}
		}
		
		/// <remarks>SQL Type:System.String</remarks>
		private string _Description = "";
		
		[DisplayName("Description")]
		[Category("Column")]
		public string Description
		{
			get
			{
				return _Description;
			}
			set
			{
				_Description = value;
			}
		}
		
		/// <remarks>SQL Type:System.String</remarks>
		private string _InitializeValue = "";
		
		[DisplayName("Initialize Value")]
		[Category("Column")]
		public string InitializeValue
		{
			get
			{
				return _InitializeValue;
			}
			set
			{
				_InitializeValue = value;
			}
		}
		
		/// <remarks>SQL Type:System.String</remarks>
		private string _EV_TXT = "";
		
		[DisplayName("EV_TXT")]
		[Category("Column")]
		public string EV_TXT
		{
			get
			{
				return _EV_TXT;
			}
			set
			{
				_EV_TXT = value;
			}
		}
		
		/// <remarks>SQL Type:System.Boolean</remarks>
		private bool _EV_EBL;
		
		[DisplayName("EV_EBL")]
		[Category("Column")]
		public bool EV_EBL
		{
			get
			{
				return _EV_EBL;
			}
			set
			{
				_EV_EBL = value;
			}
		}
		
		/// <remarks>SQL Type:System.Int32</remarks>
		private int _Option;
		
		[DisplayName("Option")]
		[Category("Column")]
		public int Option
		{
			get
			{
				return _Option;
			}
			set
			{
				_Option = value;
			}
		}
		
		/// <remarks>SQL Type:System.Boolean</remarks>
		private bool _FBDPossible;
		
		[DisplayName("FBDPossible")]
		[Category("Column")]
		public bool FBDPossible
		{
			get
			{
				return _FBDPossible;
			}
			set
			{
				_FBDPossible = value;
			}
		}
		
		/// <remarks>SQL Type:System.Boolean</remarks>
		private bool _STEdit;
		
		[DisplayName("STEdit")]
		[Category("Column")]
		public bool STEdit
		{
			get
			{
				return _STEdit;
			}
			set
			{
				_STEdit = value;
			}
		}
		
		/// <remarks>SQL Type:System.Boolean</remarks>
		private bool _PropertyType;
		
		[DisplayName("Property Type")]
		[Category("Column")]
		public bool PropertyType
		{
			get
			{
				return _PropertyType;
			}
			set
			{
				_PropertyType = value;
			}
		}
		
		/// <remarks>SQL Type:System.String</remarks>
		private string _ENUM_TEXT = "";
		
		[DisplayName("ENUM_TEXT")]
		[Category("Column")]
		public string ENUM_TEXT
		{
			get
			{
				return _ENUM_TEXT;
			}
			set
			{
				_ENUM_TEXT = value;
			}
		}
		
		/// <remarks>SQL Type:System.Boolean</remarks>
		private bool _popback;
		
		[DisplayName("popback")]
		[Category("Column")]
		public bool popback
		{
			get
			{
				return _popback;
			}
			set
			{
				_popback = value;
			}
		}
		
		/// <remarks>SQL Type:System.Boolean</remarks>
		private bool _pushback;
		
		[DisplayName("pushback")]
		[Category("Column")]
		public bool pushback
		{
			get
			{
				return _pushback;
			}
			set
			{
				_pushback = value;
			}
		}
		#endregion
		
		#region Related Objects
		/// <remarks>Represents the foreign key object</remarks>
		private tblFunction _FunctionID_tblFunction;
		
		[Description("Represents the foreign key object of the type FunctionID")]
		public tblFunction m_FunctionID_tblFunction
		{
			get
			{
				return _FunctionID_tblFunction;
			}
			set
			{
				_FunctionID_tblFunction = value;
			}
		}
		#endregion
		
		#region Public Methods
		public int Delete()
		{
			try
			{
				if (Common.Conn == null)
				{
					Common.Conn = new SQLiteConnection(Common.ConnectionString);
					Common.Conn.Open();
				}
				this.PreDeleteTriger();
				SQLiteCommand Com = Common.Conn.CreateCommand();
				SQLiteCommand ComSync = Common.Conn.CreateCommand();
				Com.CommandText = tblFormalParameter.SQL_Delete;
				ComSync.CommandText = "PRAGMA foreign_keys=ON";
				Com.Parameters.AddRange(GetSqlParameters());
				ComSync.ExecuteNonQuery();
				int rowseffected = Com.ExecuteNonQuery();
				ComSync.Dispose();
				Com.Dispose();
				this.PostDeleteTriger();
				return 0;
			}
			catch (SQLiteException ex)
			{
				return ex.ErrorCode;
			}
		}
		
		public int Select()
		{
			try
			{
				if (Common.Conn == null)
				{
					Common.Conn = new SQLiteConnection(Common.ConnectionString);
					Common.Conn.Open();
				}
				SQLiteCommand Com = Common.Conn.CreateCommand();
				Com.CommandText = tblFormalParameter.SQL_Select;
				Com.Parameters.AddRange(GetSqlParameters());
				SQLiteDataReader rs = Com.ExecuteReader();
				for (
				; rs.Read(); 
				)
				{
					AddFromRecordSet(rs);
				}
				rs.Close();
				rs.Dispose();
				Com.Dispose();
				return 0;
			}
			catch (SQLiteException ex)
			{
				return ex.ErrorCode;
			}
		}
		
		public int Insert()
		{
			try
			{
				if (Common.Conn == null)
				{
					Common.Conn = new SQLiteConnection(Common.ConnectionString);
					Common.Conn.Open();
				}
				this.PreInsertTriger();
				SQLiteCommand Com = Common.Conn.CreateCommand();
				Com.CommandText = tblFormalParameter.SQL_Insert;
				Com.Parameters.AddRange(GetSqlParameters());
				PinID = ((long)(Convert.ToInt64(Com.ExecuteScalar())));
				Com.Dispose();
				this.PostInsertTriger();
				return 0;
			}
			catch (SQLiteException ex)
			{
				return ex.ErrorCode;
			}
		}
		
		public int Update()
		{
			try
			{
				if (Common.Conn == null)
				{
					Common.Conn = new SQLiteConnection(Common.ConnectionString);
					Common.Conn.Open();
				}
				this.PreUpdateTriger();
				SQLiteCommand Com = Common.Conn.CreateCommand();
				Com.CommandText = tblFormalParameter.SQL_Update;
				Com.Parameters.AddRange(GetSqlParameters());
				int rowseffected = Com.ExecuteNonQuery();
				Com.Dispose();
				this.PostUpdateTriger();
				return 0;
			}
			catch (SQLiteException ex)
			{
				return ex.ErrorCode;
			}
		}
		
		public tblFormalParameter()
		{
		}
		#endregion
		
		#region Private Methods
		private SQLiteParameter[] GetSqlParameters()
		{
			List<SQLiteParameter> SqlParmColl = new List<SQLiteParameter>();
			try
			{
				SqlParmColl.Add(CommonDB.AddSqlParm("@PinID", PinID, DbType.Int64));
				SqlParmColl.Add(CommonDB.AddSqlParm("@PinName", PinName, DbType.String));
				SqlParmColl.Add(CommonDB.AddSqlParm("@FunctionID", FunctionID, DbType.Int64));
				SqlParmColl.Add(CommonDB.AddSqlParm("@Type", Type, DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@Reference", Reference, DbType.Boolean));
				SqlParmColl.Add(CommonDB.AddSqlParm("@Class", Class, DbType.Int16));
				SqlParmColl.Add(CommonDB.AddSqlParm("@Extensible", Extensible, DbType.Boolean));
				SqlParmColl.Add(CommonDB.AddSqlParm("@oIndex", oIndex, DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@Description", Description, DbType.String));
				SqlParmColl.Add(CommonDB.AddSqlParm("@InitializeValue", InitializeValue, DbType.String));
				SqlParmColl.Add(CommonDB.AddSqlParm("@EV_TXT", EV_TXT, DbType.String));
				SqlParmColl.Add(CommonDB.AddSqlParm("@EV_EBL", EV_EBL, DbType.Boolean));
				SqlParmColl.Add(CommonDB.AddSqlParm("@Option", Option, DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@FBDPossible", FBDPossible, DbType.Boolean));
				SqlParmColl.Add(CommonDB.AddSqlParm("@STEdit", STEdit, DbType.Boolean));
				SqlParmColl.Add(CommonDB.AddSqlParm("@PropertyType", PropertyType, DbType.Boolean));
				SqlParmColl.Add(CommonDB.AddSqlParm("@ENUM_TEXT", ENUM_TEXT, DbType.String));
				SqlParmColl.Add(CommonDB.AddSqlParm("@popback", popback, DbType.Boolean));
				SqlParmColl.Add(CommonDB.AddSqlParm("@pushback", pushback, DbType.Boolean));
				return SqlParmColl.ToArray();
			}
			catch (SQLiteException Exc)
			{
				throw Exc;
			}
		}
		
		public void AddFromRecordSet(SQLiteDataReader rs)
		{
			try
			{
				// if value from the recordset, to the PinID _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("PinID")) == false))
				{
					PinID = ((long)(Convert.ChangeType(rs["PinID"], typeof(long))));
				}
				// if value from the recordset, to the PinName _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("PinName")) == false))
				{
					PinName = ((string)(Convert.ChangeType(rs["PinName"], typeof(string))));
				}
				// if value from the recordset, to the FunctionID _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("FunctionID")) == false))
				{
					FunctionID = ((long)(Convert.ChangeType(rs["FunctionID"], typeof(long))));
				}
				// if value from the recordset, to the Type _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("Type")) == false))
				{
					Type = ((int)(Convert.ChangeType(rs["Type"], typeof(int))));
				}
				// if value from the recordset, to the Reference _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("Reference")) == false))
				{
					Reference = ((bool)(Convert.ChangeType(rs["Reference"], typeof(bool))));
				}
				// if value from the recordset, to the Class _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("Class")) == false))
				{
					Class = ((short)(Convert.ChangeType(rs["Class"], typeof(short))));
				}
				// if value from the recordset, to the Extensible _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("Extensible")) == false))
				{
					Extensible = ((bool)(Convert.ChangeType(rs["Extensible"], typeof(bool))));
				}
				// if value from the recordset, to the oIndex _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("oIndex")) == false))
				{
					oIndex = ((int)(Convert.ChangeType(rs["oIndex"], typeof(int))));
				}
				// if value from the recordset, to the Description _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("Description")) == false))
				{
					Description = ((string)(Convert.ChangeType(rs["Description"], typeof(string))));
				}
				// if value from the recordset, to the InitializeValue _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("InitializeValue")) == false))
				{
					InitializeValue = ((string)(Convert.ChangeType(rs["InitializeValue"], typeof(string))));
				}
				// if value from the recordset, to the EV_TXT _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("EV_TXT")) == false))
				{
					EV_TXT = ((string)(Convert.ChangeType(rs["EV_TXT"], typeof(string))));
				}
				// if value from the recordset, to the EV_EBL _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("EV_EBL")) == false))
				{
					EV_EBL = ((bool)(Convert.ChangeType(rs["EV_EBL"], typeof(bool))));
				}
				// if value from the recordset, to the Option _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("Option")) == false))
				{
					Option = ((int)(Convert.ChangeType(rs["Option"], typeof(int))));
				}
				// if value from the recordset, to the FBDPossible _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("FBDPossible")) == false))
				{
					FBDPossible = ((bool)(Convert.ChangeType(rs["FBDPossible"], typeof(bool))));
				}
				// if value from the recordset, to the STEdit _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("STEdit")) == false))
				{
					STEdit = ((bool)(Convert.ChangeType(rs["STEdit"], typeof(bool))));
				}
				// if value from the recordset, to the PropertyType _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("PropertyType")) == false))
				{
					PropertyType = ((bool)(Convert.ChangeType(rs["PropertyType"], typeof(bool))));
				}
				// if value from the recordset, to the ENUM_TEXT _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("ENUM_TEXT")) == false))
				{
					ENUM_TEXT = ((string)(Convert.ChangeType(rs["ENUM_TEXT"], typeof(string))));
				}
				// if value from the recordset, to the popback _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("popback")) == false))
				{
					popback = ((bool)(Convert.ChangeType(rs["popback"], typeof(bool))));
				}
				// if value from the recordset, to the pushback _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("pushback")) == false))
				{
					pushback = ((bool)(Convert.ChangeType(rs["pushback"], typeof(bool))));
				}
			}
			catch (SQLiteException sqlExc)
			{
				throw sqlExc;
			}
			catch (Exception Exc)
			{
				throw Exc;
			}
		}
		
		public override void AddFromString(string[] _strs, string arg1, ref string _log)
		{
			try
			{
				this.PreAddFromString(ref _log);
				int i;
				i = this.ColumnExistInHeader("PinName");
				if ((i >= 0))
				{
					PinName = ((string)(Convert.ChangeType(_strs[i], typeof(string))));
				}
				i = this.ColumnExistInHeader("FunctionID");
				if ((i >= 0))
				{
					FunctionID = ((long)(Convert.ChangeType(_strs[i], typeof(long))));
				}
				i = this.ColumnExistInHeader("Type");
				if ((i >= 0))
				{
					Type = ((int)(Convert.ChangeType(_strs[i], typeof(int))));
				}
				i = this.ColumnExistInHeader("Reference");
				if ((i >= 0))
				{
					Reference = ((bool)(Convert.ChangeType(_strs[i], typeof(bool))));
				}
				i = this.ColumnExistInHeader("Class");
				if ((i >= 0))
				{
					Class = ((short)(Convert.ChangeType(_strs[i], typeof(short))));
				}
				i = this.ColumnExistInHeader("Extensible");
				if ((i >= 0))
				{
					Extensible = ((bool)(Convert.ChangeType(_strs[i], typeof(bool))));
				}
				i = this.ColumnExistInHeader("oIndex");
				if ((i >= 0))
				{
					oIndex = ((int)(Convert.ChangeType(_strs[i], typeof(int))));
				}
				i = this.ColumnExistInHeader("Description");
				if ((i >= 0))
				{
					Description = ((string)(Convert.ChangeType(_strs[i], typeof(string))));
				}
				i = this.ColumnExistInHeader("InitializeValue");
				if ((i >= 0))
				{
					InitializeValue = ((string)(Convert.ChangeType(_strs[i], typeof(string))));
				}
				i = this.ColumnExistInHeader("EV_TXT");
				if ((i >= 0))
				{
					EV_TXT = ((string)(Convert.ChangeType(_strs[i], typeof(string))));
				}
				i = this.ColumnExistInHeader("EV_EBL");
				if ((i >= 0))
				{
					EV_EBL = ((bool)(Convert.ChangeType(_strs[i], typeof(bool))));
				}
				i = this.ColumnExistInHeader("Option");
				if ((i >= 0))
				{
					Option = ((int)(Convert.ChangeType(_strs[i], typeof(int))));
				}
				i = this.ColumnExistInHeader("FBDPossible");
				if ((i >= 0))
				{
					FBDPossible = ((bool)(Convert.ChangeType(_strs[i], typeof(bool))));
				}
				i = this.ColumnExistInHeader("STEdit");
				if ((i >= 0))
				{
					STEdit = ((bool)(Convert.ChangeType(_strs[i], typeof(bool))));
				}
				i = this.ColumnExistInHeader("PropertyType");
				if ((i >= 0))
				{
					PropertyType = ((bool)(Convert.ChangeType(_strs[i], typeof(bool))));
				}
				i = this.ColumnExistInHeader("ENUM_TEXT");
				if ((i >= 0))
				{
					ENUM_TEXT = ((string)(Convert.ChangeType(_strs[i], typeof(string))));
				}
				i = this.ColumnExistInHeader("popback");
				if ((i >= 0))
				{
					popback = ((bool)(Convert.ChangeType(_strs[i], typeof(bool))));
				}
				i = this.ColumnExistInHeader("pushback");
				if ((i >= 0))
				{
					pushback = ((bool)(Convert.ChangeType(_strs[i], typeof(bool))));
				}
				this.PostAddFromString(ref _log);
			}
			catch (SQLiteException sqlExc)
			{
				throw sqlExc;
			}
			catch (Exception Exc)
			{
				throw Exc;
			}
		}
		#endregion
	}
	
	public delegate void tblFormalParameterChangedEventHandler(object sender, System.EventArgs e);
	
	public partial class tblFormalParameterCollection : SQLiteTableCollection
	{
		
		/// <remarks>SQL Type:tblFormalParameterChangedEventHandler</remarks>
		public event tblFormalParameterChangedEventHandler tblFormalParameterChanged;
		
		/// <remarks>Represents the foreign key object</remarks>
		private tblFunction _FunctionID_tblFunction;
		
		[Description("Represents the foreign key object of the type FunctionID")]
		public tblFunction m_FunctionID_tblFunction
		{
			get
			{
				return _FunctionID_tblFunction;
			}
			set
			{
				_FunctionID_tblFunction = value;
			}
		}
		
		[Description("Constructor")]
		public tblFormalParameterCollection(tblFunction _parent)
		{
			_FunctionID_tblFunction = _parent;
		}
		
		[Description("Invoke the Changed event; called whenever list changes")]
		protected virtual void OntblFormalParameterChanged(System.EventArgs e)
		{
			if (tblFormalParameterChanged != null)
			{
				this.tblFormalParameterChanged(this, e);
			}
		}
		
		[Description("Gets a  tblFormalParameter from the collection.")]
		public tblFormalParameter this[int index]
		{
			get
			{
				return ((tblFormalParameter)(List[index]));
			}
			set
			{
				List[index] = value;
				this.OntblFormalParameterChanged(EventArgs.Empty);
			}
		}
		
		[Description("Gets a  tblFormalParameter from the collection.")]
		public tblFormalParameter Get(int index)
		{
			return ((tblFormalParameter)(List[index]));
		}
		
		[Description("Adds a new tblFormalParameter to the collection.")]
		public void Add(tblFormalParameter item)
		{
			List.Add(item);
			this.OntblFormalParameterChanged(EventArgs.Empty);
		}
		
		[Description("Removes a tblFormalParameter from the collection.")]
		public void Remove(tblFormalParameter item)
		{
			List.Remove(item);
			this.OntblFormalParameterChanged(EventArgs.Empty);
		}
		
		[Description("Inserts an tblFormalParameter into the collection at the specified index.")]
		public void Insert(int index, tblFormalParameter item)
		{
			List.Insert(index, item);
			this.OntblFormalParameterChanged(EventArgs.Empty);
		}
		
		[Description("Returns the index value of the tblFormalParameter class in the collection.")]
		public int IndexOf(tblFormalParameter item)
		{
			return List.IndexOf(item);
		}
		
		[Description("Returns true if the tblFormalParameter class is present in the collection.")]
		public bool Contains(tblFormalParameter item)
		{
			return List.Contains(item);
		}
	}
}
