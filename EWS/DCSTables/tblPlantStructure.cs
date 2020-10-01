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


    public partial class tblPlantStructure : SQLiteTable
	{
		
		#region Static SQL String Memebers
		/// <remarks>This _databasename represents the full INSERT INTO string for the table tblPlantStructure.</remarks>
		internal static string SQL_Insert = @"INSERT INTO [tblPlantStructure] ([SolutionID], [Name], [ParentID], [Type], [Description], [IsObject], [IsFolder], [PropertyPath], [Argument], [Visible], [NoOfAvailable]) VALUES(@SolutionID, @Name, @ParentID, @Type, @Description, @IsObject, @IsFolder, @PropertyPath, @Argument, @Visible, @NoOfAvailable) ; select last_insert_rowid(); ";
		
		/// <remarks>This _databasename represents the full UPDATE string for the table tblPlantStructure, with the WHERE clause.</remarks>
		internal static string SQL_Update = @"UPDATE [tblPlantStructure] SET [SolutionID] = @SolutionID, [Name] = @Name, [ParentID] = @ParentID, [Type] = @Type, [Description] = @Description, [IsObject] = @IsObject, [IsFolder] = @IsFolder, [PropertyPath] = @PropertyPath, [Argument] = @Argument, [Visible] = @Visible, [NoOfAvailable] = @NoOfAvailable WHERE [ID]=@ID ";
		
		/// <remarks>This _databasename represents the full SELECT string for the table tblPlantStructure, with the WHERE clause.</remarks>
		internal static string SQL_Select = "SELECT [SolutionID], [Name], [ParentID], [Type], [Description], [IsObject], [IsFo" +
			"lder], [PropertyPath], [Argument], [Visible], [NoOfAvailable] FROM [tblPlantStru" +
			"cture] WHERE [ID]=@ID ";
		
		/// <remarks>This _databasename represents the DELETE string for the table tblPlantStructure, with the WHERE clause.</remarks>
		internal static string SQL_Delete = "DELETE FROM [tblPlantStructure] WHERE [ID]=@ID ";
		#endregion
		
		#region Tables Memebers
		/// <remarks>SQL Type:System.Int64</remarks>
		private long _ID = -1;
		
		[DisplayName("ID")]
		[Category("Primary Key")]
		public long ID
		{
			get
			{
				return _ID;
			}
			set
			{
				_ID = value;
			}
		}
		
		/// <remarks>SQL Type:System.Int64</remarks>
		private long _SolutionID = -1;
		
		[DisplayName("Solution ID")]
		[Category("Foreign Key")]
		public long SolutionID
		{
			get
			{
				return _SolutionID;
			}
			set
			{
				_SolutionID = value;
			}
		}
		
		/// <remarks>SQL Type:System.String</remarks>
		private string _Name = "";
		
		[DisplayName("Name")]
		[Category("Column")]
		public string Name
		{
			get
			{
				return _Name;
			}
			set
			{
				_Name = value;
			}
		}
		
		/// <remarks>SQL Type:System.Int64</remarks>
		private long _ParentID = -1;
		
		[DisplayName("Parent ID")]
		[Category("Column")]
		public long ParentID
		{
			get
			{
				return _ParentID;
			}
			set
			{
				_ParentID = value;
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
		
		/// <remarks>SQL Type:System.Boolean</remarks>
		private bool _IsObject;
		
		[DisplayName("Is Object")]
		[Category("Column")]
		public bool IsObject
		{
			get
			{
				return _IsObject;
			}
			set
			{
				_IsObject = value;
			}
		}
		
		/// <remarks>SQL Type:System.Boolean</remarks>
		private bool _IsFolder;
		
		[DisplayName("Is Folder")]
		[Category("Column")]
		public bool IsFolder
		{
			get
			{
				return _IsFolder;
			}
			set
			{
				_IsFolder = value;
			}
		}
		
		/// <remarks>SQL Type:System.String</remarks>
		private string _PropertyPath = "";
		
		[DisplayName("Property Path")]
		[Category("Column")]
		public string PropertyPath
		{
			get
			{
				return _PropertyPath;
			}
			set
			{
				_PropertyPath = value;
			}
		}
		
		/// <remarks>SQL Type:System.String</remarks>
		private string _Argument = "";
		
		[DisplayName("Argument")]
		[Category("Column")]
		public string Argument
		{
			get
			{
				return _Argument;
			}
			set
			{
				_Argument = value;
			}
		}
		
		/// <remarks>SQL Type:System.Boolean</remarks>
		private bool _Visible;
		
		[DisplayName("Visible")]
		[Category("Column")]
		public bool Visible
		{
			get
			{
				return _Visible;
			}
			set
			{
				_Visible = value;
			}
		}
		
		/// <remarks>SQL Type:System.Int32</remarks>
		private int _NoOfAvailable;
		
		[DisplayName("No Of Available")]
		[Category("Column")]
		public int NoOfAvailable
		{
			get
			{
				return _NoOfAvailable;
			}
			set
			{
				_NoOfAvailable = value;
			}
		}
		#endregion
		
		#region Related Objects
		/// <remarks>Represents the foreign key object</remarks>
		private tblSolution _SolutionID_tblSolution;
		
		[Description("Represents the foreign key object of the type SolutionID")]
		public tblSolution m_SolutionID_tblSolution
		{
			get
			{
				return _SolutionID_tblSolution;
			}
			set
			{
				_SolutionID_tblSolution = value;
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
				Com.CommandText = tblPlantStructure.SQL_Delete;
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
				Com.CommandText = tblPlantStructure.SQL_Select;
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
				Com.CommandText = tblPlantStructure.SQL_Insert;
				Com.Parameters.AddRange(GetSqlParameters());
				ID = ((long)(Convert.ToInt64(Com.ExecuteScalar())));
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
				Com.CommandText = tblPlantStructure.SQL_Update;
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
		
		public tblPlantStructure()
		{
		}
		#endregion
		
		#region Private Methods
		private SQLiteParameter[] GetSqlParameters()
		{
			List<SQLiteParameter> SqlParmColl = new List<SQLiteParameter>();
			try
			{
				SqlParmColl.Add(CommonDB.AddSqlParm("@ID", ID, DbType.Int64));
				SqlParmColl.Add(CommonDB.AddSqlParm("@SolutionID", SolutionID, DbType.Int64));
				SqlParmColl.Add(CommonDB.AddSqlParm("@Name", Name, DbType.String));
				SqlParmColl.Add(CommonDB.AddSqlParm("@ParentID", ParentID, DbType.Int64));
				SqlParmColl.Add(CommonDB.AddSqlParm("@Type", Type, DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@Description", Description, DbType.String));
				SqlParmColl.Add(CommonDB.AddSqlParm("@IsObject", IsObject, DbType.Boolean));
				SqlParmColl.Add(CommonDB.AddSqlParm("@IsFolder", IsFolder, DbType.Boolean));
				SqlParmColl.Add(CommonDB.AddSqlParm("@PropertyPath", PropertyPath, DbType.String));
				SqlParmColl.Add(CommonDB.AddSqlParm("@Argument", Argument, DbType.String));
				SqlParmColl.Add(CommonDB.AddSqlParm("@Visible", Visible, DbType.Boolean));
				SqlParmColl.Add(CommonDB.AddSqlParm("@NoOfAvailable", NoOfAvailable, DbType.Int32));
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
				// if value from the recordset, to the ID _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("ID")) == false))
				{
					ID = ((long)(Convert.ChangeType(rs["ID"], typeof(long))));
				}
				// if value from the recordset, to the SolutionID _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("SolutionID")) == false))
				{
					SolutionID = ((long)(Convert.ChangeType(rs["SolutionID"], typeof(long))));
				}
				// if value from the recordset, to the Name _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("Name")) == false))
				{
					Name = ((string)(Convert.ChangeType(rs["Name"], typeof(string))));
				}
				// if value from the recordset, to the ParentID _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("ParentID")) == false))
				{
					ParentID = ((long)(Convert.ChangeType(rs["ParentID"], typeof(long))));
				}
				// if value from the recordset, to the Type _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("Type")) == false))
				{
					Type = ((int)(Convert.ChangeType(rs["Type"], typeof(int))));
				}
				// if value from the recordset, to the Description _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("Description")) == false))
				{
					Description = ((string)(Convert.ChangeType(rs["Description"], typeof(string))));
				}
				// if value from the recordset, to the IsObject _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("IsObject")) == false))
				{
					IsObject = ((bool)(Convert.ChangeType(rs["IsObject"], typeof(bool))));
				}
				// if value from the recordset, to the IsFolder _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("IsFolder")) == false))
				{
					IsFolder = ((bool)(Convert.ChangeType(rs["IsFolder"], typeof(bool))));
				}
				// if value from the recordset, to the PropertyPath _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("PropertyPath")) == false))
				{
					PropertyPath = ((string)(Convert.ChangeType(rs["PropertyPath"], typeof(string))));
				}
				// if value from the recordset, to the Argument _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("Argument")) == false))
				{
					Argument = ((string)(Convert.ChangeType(rs["Argument"], typeof(string))));
				}
				// if value from the recordset, to the Visible _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("Visible")) == false))
				{
					Visible = ((bool)(Convert.ChangeType(rs["Visible"], typeof(bool))));
				}
				// if value from the recordset, to the NoOfAvailable _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("NoOfAvailable")) == false))
				{
					NoOfAvailable = ((int)(Convert.ChangeType(rs["NoOfAvailable"], typeof(int))));
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
				i = this.ColumnExistInHeader("SolutionID");
				if ((i >= 0))
				{
					SolutionID = ((long)(Convert.ChangeType(_strs[i], typeof(long))));
				}
				i = this.ColumnExistInHeader("Name");
				if ((i >= 0))
				{
					Name = ((string)(Convert.ChangeType(_strs[i], typeof(string))));
				}
				i = this.ColumnExistInHeader("ParentID");
				if ((i >= 0))
				{
					ParentID = ((long)(Convert.ChangeType(_strs[i], typeof(long))));
				}
				i = this.ColumnExistInHeader("Type");
				if ((i >= 0))
				{
					Type = ((int)(Convert.ChangeType(_strs[i], typeof(int))));
				}
				i = this.ColumnExistInHeader("Description");
				if ((i >= 0))
				{
					Description = ((string)(Convert.ChangeType(_strs[i], typeof(string))));
				}
				i = this.ColumnExistInHeader("IsObject");
				if ((i >= 0))
				{
					IsObject = ((bool)(Convert.ChangeType(_strs[i], typeof(bool))));
				}
				i = this.ColumnExistInHeader("IsFolder");
				if ((i >= 0))
				{
					IsFolder = ((bool)(Convert.ChangeType(_strs[i], typeof(bool))));
				}
				i = this.ColumnExistInHeader("PropertyPath");
				if ((i >= 0))
				{
					PropertyPath = ((string)(Convert.ChangeType(_strs[i], typeof(string))));
				}
				i = this.ColumnExistInHeader("Argument");
				if ((i >= 0))
				{
					Argument = ((string)(Convert.ChangeType(_strs[i], typeof(string))));
				}
				i = this.ColumnExistInHeader("Visible");
				if ((i >= 0))
				{
					Visible = ((bool)(Convert.ChangeType(_strs[i], typeof(bool))));
				}
				i = this.ColumnExistInHeader("NoOfAvailable");
				if ((i >= 0))
				{
					NoOfAvailable = ((int)(Convert.ChangeType(_strs[i], typeof(int))));
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
	
	public delegate void tblPlantStructureChangedEventHandler(object sender, System.EventArgs e);
	
	public partial class tblPlantStructureCollection : SQLiteTableCollection
	{
		
		/// <remarks>SQL Type:tblPlantStructureChangedEventHandler</remarks>
		public event tblPlantStructureChangedEventHandler tblPlantStructureChanged;
		
		/// <remarks>Represents the foreign key object</remarks>
		private tblSolution _SolutionID_tblSolution;
		
		[Description("Represents the foreign key object of the type SolutionID")]
		public tblSolution m_SolutionID_tblSolution
		{
			get
			{
				return _SolutionID_tblSolution;
			}
			set
			{
				_SolutionID_tblSolution = value;
			}
		}
		
		[Description("Constructor")]
		public tblPlantStructureCollection(tblSolution _parent)
		{
			_SolutionID_tblSolution = _parent;
		}
		
		[Description("Invoke the Changed event; called whenever list changes")]
		protected virtual void OntblPlantStructureChanged(System.EventArgs e)
		{
			if (tblPlantStructureChanged != null)
			{
				this.tblPlantStructureChanged(this, e);
			}
		}
		
		[Description("Gets a  tblPlantStructure from the collection.")]
		public tblPlantStructure this[int index]
		{
			get
			{
				return ((tblPlantStructure)(List[index]));
			}
			set
			{
				List[index] = value;
				this.OntblPlantStructureChanged(EventArgs.Empty);
			}
		}
		
		[Description("Gets a  tblPlantStructure from the collection.")]
		public tblPlantStructure Get(int index)
		{
			return ((tblPlantStructure)(List[index]));
		}
		
		[Description("Adds a new tblPlantStructure to the collection.")]
		public void Add(tblPlantStructure item)
		{
			List.Add(item);
			this.OntblPlantStructureChanged(EventArgs.Empty);
		}
		
		[Description("Removes a tblPlantStructure from the collection.")]
		public void Remove(tblPlantStructure item)
		{
			List.Remove(item);
			this.OntblPlantStructureChanged(EventArgs.Empty);
		}
		
		[Description("Inserts an tblPlantStructure into the collection at the specified index.")]
		public void Insert(int index, tblPlantStructure item)
		{
			List.Insert(index, item);
			this.OntblPlantStructureChanged(EventArgs.Empty);
		}
		
		[Description("Returns the index value of the tblPlantStructure class in the collection.")]
		public int IndexOf(tblPlantStructure item)
		{
			return List.IndexOf(item);
		}
		
		[Description("Returns true if the tblPlantStructure class is present in the collection.")]
		public bool Contains(tblPlantStructure item)
		{
			return List.Contains(item);
		}
	}
}
