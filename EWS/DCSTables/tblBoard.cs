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


    public partial class tblBoard : SQLiteTable
	{
		
		#region Static SQL String Memebers
		/// <remarks>This _databasename represents the full INSERT INTO string for the table tblBoard.</remarks>
		internal static string SQL_Insert = @"INSERT INTO [tblBoard] ([BoardName], [ControllerID], [oIndex], [Description], [BoardGroup], [Type], [SlotNo1], [SlotNo2], [IORackNumber1], [IORackNumber2], [BoardNo], [ScanTime], [MBA1], [MBA2], [Redundant], [VariableID_DIG]) VALUES(@BoardName, @ControllerID, @oIndex, @Description, @BoardGroup, @Type, @SlotNo1, @SlotNo2, @IORackNumber1, @IORackNumber2, @BoardNo, @ScanTime, @MBA1, @MBA2, @Redundant, @VariableID_DIG) ; select last_insert_rowid(); ";
		
		/// <remarks>This _databasename represents the full UPDATE string for the table tblBoard, with the WHERE clause.</remarks>
		internal static string SQL_Update = @"UPDATE [tblBoard] SET [BoardName] = @BoardName, [ControllerID] = @ControllerID, [oIndex] = @oIndex, [Description] = @Description, [BoardGroup] = @BoardGroup, [Type] = @Type, [SlotNo1] = @SlotNo1, [SlotNo2] = @SlotNo2, [IORackNumber1] = @IORackNumber1, [IORackNumber2] = @IORackNumber2, [BoardNo] = @BoardNo, [ScanTime] = @ScanTime, [MBA1] = @MBA1, [MBA2] = @MBA2, [Redundant] = @Redundant, [VariableID_DIG] = @VariableID_DIG WHERE [BoardID]=@BoardID ";
		
		/// <remarks>This _databasename represents the full SELECT string for the table tblBoard, with the WHERE clause.</remarks>
		internal static string SQL_Select = "SELECT [BoardName], [ControllerID], [oIndex], [Description], [BoardGroup], [Type]" +
			", [SlotNo1], [SlotNo2], [IORackNumber1], [IORackNumber2], [BoardNo], [ScanTime]," +
			" [MBA1], [MBA2], [Redundant], [VariableID_DIG] FROM [tblBoard] WHERE [BoardID]=@" +
			"BoardID ";
		
		/// <remarks>This _databasename represents the DELETE string for the table tblBoard, with the WHERE clause.</remarks>
		internal static string SQL_Delete = "DELETE FROM [tblBoard] WHERE [BoardID]=@BoardID ";
		#endregion
		
		#region Tables Memebers
		/// <remarks>SQL Type:System.String</remarks>
		private string _BoardName = "";
		
		[DisplayName("Board Name")]
		[Category("Column")]
		public string BoardName
		{
			get
			{
				return _BoardName;
			}
			set
			{
				_BoardName = value;
			}
		}
		
		/// <remarks>SQL Type:System.Int64</remarks>
		private long _BoardID = -1;
		
		[DisplayName("Board ID")]
		[Category("Primary Key")]
		public long BoardID
		{
			get
			{
				return _BoardID;
			}
			set
			{
				_BoardID = value;
			}
		}
		
		/// <remarks>SQL Type:System.Int32</remarks>
		private int _ControllerID;
		
		[DisplayName("Controller ID")]
		[Category("Foreign Key")]
		public int ControllerID
		{
			get
			{
				return _ControllerID;
			}
			set
			{
				_ControllerID = value;
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
		
		/// <remarks>SQL Type:System.Int32</remarks>
		private int _BoardGroup;
		
		[DisplayName("Board Group")]
		[Category("Column")]
		public int BoardGroup
		{
			get
			{
				return _BoardGroup;
			}
			set
			{
				_BoardGroup = value;
			}
		}
		
		/// <remarks>SQL Type:System.String</remarks>
		private string _Type = "";
		
		[DisplayName("Type")]
		[Category("Column")]
		public string Type
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
		
		/// <remarks>SQL Type:System.Int32</remarks>
		private int _SlotNo1;
		
		[DisplayName("Slot No 1")]
		[Category("Column")]
		public int SlotNo1
		{
			get
			{
				return _SlotNo1;
			}
			set
			{
				_SlotNo1 = value;
			}
		}
		
		/// <remarks>SQL Type:System.Int32</remarks>
		private int _SlotNo2;
		
		[DisplayName("Slot No 2")]
		[Category("Column")]
		public int SlotNo2
		{
			get
			{
				return _SlotNo2;
			}
			set
			{
				_SlotNo2 = value;
			}
		}
		
		/// <remarks>SQL Type:System.Int32</remarks>
		private int _IORackNumber1;
		
		[DisplayName("IORack Number 1")]
		[Category("Column")]
		public int IORackNumber1
		{
			get
			{
				return _IORackNumber1;
			}
			set
			{
				_IORackNumber1 = value;
			}
		}
		
		/// <remarks>SQL Type:System.Int32</remarks>
		private int _IORackNumber2;
		
		[DisplayName("IORack Number 2")]
		[Category("Column")]
		public int IORackNumber2
		{
			get
			{
				return _IORackNumber2;
			}
			set
			{
				_IORackNumber2 = value;
			}
		}
		
		/// <remarks>SQL Type:System.Int32</remarks>
		private int _BoardNo;
		
		[DisplayName("Board No")]
		[Category("Column")]
		public int BoardNo
		{
			get
			{
				return _BoardNo;
			}
			set
			{
				_BoardNo = value;
			}
		}
		
		/// <remarks>SQL Type:System.Int32</remarks>
		private int _ScanTime;
		
		[DisplayName("Scan Time")]
		[Category("Column")]
		public int ScanTime
		{
			get
			{
				return _ScanTime;
			}
			set
			{
				_ScanTime = value;
			}
		}
		
		/// <remarks>SQL Type:System.String</remarks>
		private string _MBA1 = "";
		
		[DisplayName("MBA1")]
		[Category("Column")]
		public string MBA1
		{
			get
			{
				return _MBA1;
			}
			set
			{
				_MBA1 = value;
			}
		}
		
		/// <remarks>SQL Type:System.String</remarks>
		private string _MBA2 = "";
		
		[DisplayName("MBA2")]
		[Category("Column")]
		public string MBA2
		{
			get
			{
				return _MBA2;
			}
			set
			{
				_MBA2 = value;
			}
		}
		
		/// <remarks>SQL Type:System.Boolean</remarks>
		private bool _Redundant;
		
		[DisplayName("Redundant")]
		[Category("Column")]
		public bool Redundant
		{
			get
			{
				return _Redundant;
			}
			set
			{
				_Redundant = value;
			}
		}
		
		/// <remarks>SQL Type:System.Int32</remarks>
		private int _VariableID_DIG;
		
		[DisplayName("Variable ID_DIG")]
		[Category("Column")]
		public int VariableID_DIG
		{
			get
			{
				return _VariableID_DIG;
			}
			set
			{
				_VariableID_DIG = value;
			}
		}
		#endregion
		
		#region Related Objects
		/// <remarks>Represents the foreign key object</remarks>
		private tblController _ControllerID_tblController;
		
		[Description("Represents the foreign key object of the type ControllerID")]
		public tblController m_ControllerID_tblController
		{
			get
			{
				return _ControllerID_tblController;
			}
			set
			{
				_ControllerID_tblController = value;
			}
		}
		#endregion
		
		#region Collection Objects
		/// <remarks>Lock for accessing collection</remarks>
		private readonly object _tblChannelCollectionLock = new object();
		
		/// <remarks>Represents the foreign key object</remarks>
		private tblChannelCollection _tblChannelCollection;
		
		[Description("Represents the foreign key object of the type BoardID")]
		public tblChannelCollection m_tblChannelCollection
		{
			get
			{
              lock(_tblChannelCollectionLock)
              {
				if (_tblChannelCollection == null)
				{
					_tblChannelCollection =  new tblChannelCollection(this);
					_tblChannelCollection.Load();
				}
				return _tblChannelCollection;
              }
			}
			set
			{
				_tblChannelCollection = value;
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
				Com.CommandText = tblBoard.SQL_Delete;
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
				Com.CommandText = tblBoard.SQL_Select;
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
				Com.CommandText = tblBoard.SQL_Insert;
				Com.Parameters.AddRange(GetSqlParameters());
				BoardID = ((long)(Convert.ToInt64(Com.ExecuteScalar())));
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
				Com.CommandText = tblBoard.SQL_Update;
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
		
		public tblBoard()
		{
		}
		#endregion
		
		#region Private Methods
		private SQLiteParameter[] GetSqlParameters()
		{
			List<SQLiteParameter> SqlParmColl = new List<SQLiteParameter>();
			try
			{
				SqlParmColl.Add(CommonDB.AddSqlParm("@BoardName", BoardName, DbType.String));
				SqlParmColl.Add(CommonDB.AddSqlParm("@BoardID", BoardID, DbType.Int64));
				SqlParmColl.Add(CommonDB.AddSqlParm("@ControllerID", ControllerID, DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@oIndex", oIndex, DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@Description", Description, DbType.String));
				SqlParmColl.Add(CommonDB.AddSqlParm("@BoardGroup", BoardGroup, DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@Type", Type, DbType.String));
				SqlParmColl.Add(CommonDB.AddSqlParm("@SlotNo1", SlotNo1, DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@SlotNo2", SlotNo2, DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@IORackNumber1", IORackNumber1, DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@IORackNumber2", IORackNumber2, DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@BoardNo", BoardNo, DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@ScanTime", ScanTime, DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@MBA1", MBA1, DbType.String));
				SqlParmColl.Add(CommonDB.AddSqlParm("@MBA2", MBA2, DbType.String));
				SqlParmColl.Add(CommonDB.AddSqlParm("@Redundant", Redundant, DbType.Boolean));
				SqlParmColl.Add(CommonDB.AddSqlParm("@VariableID_DIG", VariableID_DIG, DbType.Int32));
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
				// if value from the recordset, to the BoardName _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("BoardName")) == false))
				{
					BoardName = ((string)(Convert.ChangeType(rs["BoardName"], typeof(string))));
				}
				// if value from the recordset, to the BoardID _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("BoardID")) == false))
				{
					BoardID = ((long)(Convert.ChangeType(rs["BoardID"], typeof(long))));
				}
				// if value from the recordset, to the ControllerID _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("ControllerID")) == false))
				{
					ControllerID = ((int)(Convert.ChangeType(rs["ControllerID"], typeof(int))));
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
				// if value from the recordset, to the BoardGroup _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("BoardGroup")) == false))
				{
					BoardGroup = ((int)(Convert.ChangeType(rs["BoardGroup"], typeof(int))));
				}
				// if value from the recordset, to the Type _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("Type")) == false))
				{
					Type = ((string)(Convert.ChangeType(rs["Type"], typeof(string))));
				}
				// if value from the recordset, to the SlotNo1 _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("SlotNo1")) == false))
				{
					SlotNo1 = ((int)(Convert.ChangeType(rs["SlotNo1"], typeof(int))));
				}
				// if value from the recordset, to the SlotNo2 _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("SlotNo2")) == false))
				{
					SlotNo2 = ((int)(Convert.ChangeType(rs["SlotNo2"], typeof(int))));
				}
				// if value from the recordset, to the IORackNumber1 _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("IORackNumber1")) == false))
				{
					IORackNumber1 = ((int)(Convert.ChangeType(rs["IORackNumber1"], typeof(int))));
				}
				// if value from the recordset, to the IORackNumber2 _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("IORackNumber2")) == false))
				{
					IORackNumber2 = ((int)(Convert.ChangeType(rs["IORackNumber2"], typeof(int))));
				}
				// if value from the recordset, to the BoardNo _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("BoardNo")) == false))
				{
					BoardNo = ((int)(Convert.ChangeType(rs["BoardNo"], typeof(int))));
				}
				// if value from the recordset, to the ScanTime _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("ScanTime")) == false))
				{
					ScanTime = ((int)(Convert.ChangeType(rs["ScanTime"], typeof(int))));
				}
				// if value from the recordset, to the MBA1 _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("MBA1")) == false))
				{
					MBA1 = ((string)(Convert.ChangeType(rs["MBA1"], typeof(string))));
				}
				// if value from the recordset, to the MBA2 _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("MBA2")) == false))
				{
					MBA2 = ((string)(Convert.ChangeType(rs["MBA2"], typeof(string))));
				}
				// if value from the recordset, to the Redundant _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("Redundant")) == false))
				{
					Redundant = ((bool)(Convert.ChangeType(rs["Redundant"], typeof(bool))));
				}
				// if value from the recordset, to the VariableID_DIG _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("VariableID_DIG")) == false))
				{
					VariableID_DIG = ((int)(Convert.ChangeType(rs["VariableID_DIG"], typeof(int))));
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
				i = this.ColumnExistInHeader("BoardName");
				if ((i >= 0))
				{
					BoardName = ((string)(Convert.ChangeType(_strs[i], typeof(string))));
				}
				i = this.ColumnExistInHeader("ControllerID");
				if ((i >= 0))
				{
					ControllerID = ((int)(Convert.ChangeType(_strs[i], typeof(int))));
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
				i = this.ColumnExistInHeader("BoardGroup");
				if ((i >= 0))
				{
					BoardGroup = ((int)(Convert.ChangeType(_strs[i], typeof(int))));
				}
				i = this.ColumnExistInHeader("Type");
				if ((i >= 0))
				{
					Type = ((string)(Convert.ChangeType(_strs[i], typeof(string))));
				}
				i = this.ColumnExistInHeader("SlotNo1");
				if ((i >= 0))
				{
					SlotNo1 = ((int)(Convert.ChangeType(_strs[i], typeof(int))));
				}
				i = this.ColumnExistInHeader("SlotNo2");
				if ((i >= 0))
				{
					SlotNo2 = ((int)(Convert.ChangeType(_strs[i], typeof(int))));
				}
				i = this.ColumnExistInHeader("IORackNumber1");
				if ((i >= 0))
				{
					IORackNumber1 = ((int)(Convert.ChangeType(_strs[i], typeof(int))));
				}
				i = this.ColumnExistInHeader("IORackNumber2");
				if ((i >= 0))
				{
					IORackNumber2 = ((int)(Convert.ChangeType(_strs[i], typeof(int))));
				}
				i = this.ColumnExistInHeader("BoardNo");
				if ((i >= 0))
				{
					BoardNo = ((int)(Convert.ChangeType(_strs[i], typeof(int))));
				}
				i = this.ColumnExistInHeader("ScanTime");
				if ((i >= 0))
				{
					ScanTime = ((int)(Convert.ChangeType(_strs[i], typeof(int))));
				}
				i = this.ColumnExistInHeader("MBA1");
				if ((i >= 0))
				{
					MBA1 = ((string)(Convert.ChangeType(_strs[i], typeof(string))));
				}
				i = this.ColumnExistInHeader("MBA2");
				if ((i >= 0))
				{
					MBA2 = ((string)(Convert.ChangeType(_strs[i], typeof(string))));
				}
				i = this.ColumnExistInHeader("Redundant");
				if ((i >= 0))
				{
					Redundant = ((bool)(Convert.ChangeType(_strs[i], typeof(bool))));
				}
				i = this.ColumnExistInHeader("VariableID_DIG");
				if ((i >= 0))
				{
					VariableID_DIG = ((int)(Convert.ChangeType(_strs[i], typeof(int))));
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
	
	public delegate void tblBoardChangedEventHandler(object sender, System.EventArgs e);
	
	public partial class tblBoardCollection : SQLiteTableCollection
	{
		
		/// <remarks>SQL Type:tblBoardChangedEventHandler</remarks>
		public event tblBoardChangedEventHandler tblBoardChanged;
		
		/// <remarks>Represents the foreign key object</remarks>
		private tblController _ControllerID_tblController;
		
		[Description("Represents the foreign key object of the type ControllerID")]
		public tblController m_ControllerID_tblController
		{
			get
			{
				return _ControllerID_tblController;
			}
			set
			{
				_ControllerID_tblController = value;
			}
		}
		
		[Description("Constructor")]
		public tblBoardCollection(tblController _parent)
		{
			_ControllerID_tblController = _parent;
		}
		
		[Description("Invoke the Changed event; called whenever list changes")]
		protected virtual void OntblBoardChanged(System.EventArgs e)
		{
			if (tblBoardChanged != null)
			{
				this.tblBoardChanged(this, e);
			}
		}
		
		[Description("Gets a  tblBoard from the collection.")]
		public tblBoard this[int index]
		{
			get
			{
				return ((tblBoard)(List[index]));
			}
			set
			{
				List[index] = value;
				this.OntblBoardChanged(EventArgs.Empty);
			}
		}
		
		[Description("Gets a  tblBoard from the collection.")]
		public tblBoard Get(int index)
		{
			return ((tblBoard)(List[index]));
		}
		
		[Description("Adds a new tblBoard to the collection.")]
		public void Add(tblBoard item)
		{
			List.Add(item);
			this.OntblBoardChanged(EventArgs.Empty);
		}
		
		[Description("Removes a tblBoard from the collection.")]
		public void Remove(tblBoard item)
		{
			List.Remove(item);
			this.OntblBoardChanged(EventArgs.Empty);
		}
		
		[Description("Inserts an tblBoard into the collection at the specified index.")]
		public void Insert(int index, tblBoard item)
		{
			List.Insert(index, item);
			this.OntblBoardChanged(EventArgs.Empty);
		}
		
		[Description("Returns the index value of the tblBoard class in the collection.")]
		public int IndexOf(tblBoard item)
		{
			return List.IndexOf(item);
		}
		
		[Description("Returns true if the tblBoard class is present in the collection.")]
		public bool Contains(tblBoard item)
		{
			return List.Contains(item);
		}
	}
}
