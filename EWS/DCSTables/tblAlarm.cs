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


    public partial class tblAlarm : SQLiteTable
	{
		
		#region Static SQL String Memebers
		/// <remarks>This _databasename represents the full INSERT INTO string for the table tblAlarm.</remarks>
		internal static string SQL_Insert = @"INSERT INTO [tblAlarm] ([VarNameID], [Type], [AlarmGroupID], [EnableTagID], [EnableTagDirection], [EnableTagDelayOn], [EnableTagDealyOff], [DelayOn], [DelayOff], [SourceAlarmTagID], [FirstOutGroupID], [hysteresis], [UpperLevelGroupID], [StatusBit]) VALUES(@VarNameID, @Type, @AlarmGroupID, @EnableTagID, @EnableTagDirection, @EnableTagDelayOn, @EnableTagDealyOff, @DelayOn, @DelayOff, @SourceAlarmTagID, @FirstOutGroupID, @hysteresis, @UpperLevelGroupID, @StatusBit) ; select last_insert_rowid(); ";
		
		/// <remarks>This _databasename represents the full UPDATE string for the table tblAlarm, with the WHERE clause.</remarks>
		internal static string SQL_Update = @"UPDATE [tblAlarm] SET [VarNameID] = @VarNameID, [Type] = @Type, [AlarmGroupID] = @AlarmGroupID, [EnableTagID] = @EnableTagID, [EnableTagDirection] = @EnableTagDirection, [EnableTagDelayOn] = @EnableTagDelayOn, [EnableTagDealyOff] = @EnableTagDealyOff, [DelayOn] = @DelayOn, [DelayOff] = @DelayOff, [SourceAlarmTagID] = @SourceAlarmTagID, [FirstOutGroupID] = @FirstOutGroupID, [hysteresis] = @hysteresis, [UpperLevelGroupID] = @UpperLevelGroupID, [StatusBit] = @StatusBit WHERE [ID]=@ID ";
		
		/// <remarks>This _databasename represents the full SELECT string for the table tblAlarm, with the WHERE clause.</remarks>
		internal static string SQL_Select = @"SELECT [VarNameID], [Type], [AlarmGroupID], [EnableTagID], [EnableTagDirection], [EnableTagDelayOn], [EnableTagDealyOff], [DelayOn], [DelayOff], [SourceAlarmTagID], [FirstOutGroupID], [hysteresis], [UpperLevelGroupID], [StatusBit] FROM [tblAlarm] WHERE [ID]=@ID ";
		
		/// <remarks>This _databasename represents the DELETE string for the table tblAlarm, with the WHERE clause.</remarks>
		internal static string SQL_Delete = "DELETE FROM [tblAlarm] WHERE [ID]=@ID ";
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
		private long _VarNameID = -1;
		
		[DisplayName("Var Name ID")]
		[Category("Foreign Key")]
		public long VarNameID
		{
			get
			{
				return _VarNameID;
			}
			set
			{
				_VarNameID = value;
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
		
		/// <remarks>SQL Type:System.Int64</remarks>
		private long _AlarmGroupID = -1;
		
		[DisplayName("Alarm Group ID")]
		[Category("Column")]
		public long AlarmGroupID
		{
			get
			{
				return _AlarmGroupID;
			}
			set
			{
				_AlarmGroupID = value;
			}
		}
		
		/// <remarks>SQL Type:System.Int64</remarks>
		private long _EnableTagID = -1;
		
		[DisplayName("Enable Tag ID")]
		[Category("Column")]
		public long EnableTagID
		{
			get
			{
				return _EnableTagID;
			}
			set
			{
				_EnableTagID = value;
			}
		}
		
		/// <remarks>SQL Type:System.Boolean</remarks>
		private bool _EnableTagDirection;
		
		[DisplayName("Enable Tag Direction")]
		[Category("Column")]
		public bool EnableTagDirection
		{
			get
			{
				return _EnableTagDirection;
			}
			set
			{
				_EnableTagDirection = value;
			}
		}
		
		/// <remarks>SQL Type:System.Int32</remarks>
		private int _EnableTagDelayOn;
		
		[DisplayName("Enable Tag Delay On")]
		[Category("Column")]
		public int EnableTagDelayOn
		{
			get
			{
				return _EnableTagDelayOn;
			}
			set
			{
				_EnableTagDelayOn = value;
			}
		}
		
		/// <remarks>SQL Type:System.Int32</remarks>
		private int _EnableTagDealyOff;
		
		[DisplayName("Enable Tag Dealy Off")]
		[Category("Column")]
		public int EnableTagDealyOff
		{
			get
			{
				return _EnableTagDealyOff;
			}
			set
			{
				_EnableTagDealyOff = value;
			}
		}
		
		/// <remarks>SQL Type:System.Int32</remarks>
		private int _DelayOn;
		
		[DisplayName("Delay On")]
		[Category("Column")]
		public int DelayOn
		{
			get
			{
				return _DelayOn;
			}
			set
			{
				_DelayOn = value;
			}
		}
		
		/// <remarks>SQL Type:System.Int32</remarks>
		private int _DelayOff;
		
		[DisplayName("Delay Off")]
		[Category("Column")]
		public int DelayOff
		{
			get
			{
				return _DelayOff;
			}
			set
			{
				_DelayOff = value;
			}
		}
		
		/// <remarks>SQL Type:System.Int64</remarks>
		private long _SourceAlarmTagID = -1;
		
		[DisplayName("Source Alarm Tag ID")]
		[Category("Column")]
		public long SourceAlarmTagID
		{
			get
			{
				return _SourceAlarmTagID;
			}
			set
			{
				_SourceAlarmTagID = value;
			}
		}
		
		/// <remarks>SQL Type:System.Int64</remarks>
		private long _FirstOutGroupID = -1;
		
		[DisplayName("First Out Group ID")]
		[Category("Column")]
		public long FirstOutGroupID
		{
			get
			{
				return _FirstOutGroupID;
			}
			set
			{
				_FirstOutGroupID = value;
			}
		}
		
		/// <remarks>SQL Type:System.Single</remarks>
		private float _hysteresis;
		
		[DisplayName("hysteresis")]
		[Category("Column")]
		public float hysteresis
		{
			get
			{
				return _hysteresis;
			}
			set
			{
				_hysteresis = value;
			}
		}
		
		/// <remarks>SQL Type:System.Int64</remarks>
		private long _UpperLevelGroupID = -1;
		
		[DisplayName("Upper Level Group ID")]
		[Category("Column")]
		public long UpperLevelGroupID
		{
			get
			{
				return _UpperLevelGroupID;
			}
			set
			{
				_UpperLevelGroupID = value;
			}
		}
		
		/// <remarks>SQL Type:System.Int32</remarks>
		private int _StatusBit;
		
		[DisplayName("Status Bit")]
		[Category("Column")]
		public int StatusBit
		{
			get
			{
				return _StatusBit;
			}
			set
			{
				_StatusBit = value;
			}
		}
		#endregion
		
		#region Related Objects
		/// <remarks>Represents the foreign key object</remarks>
		private tblVariable _VarNameID_tblVariable;
		
		[Description("Represents the foreign key object of the type VarNameID")]
		public tblVariable m_VarNameID_tblVariable
		{
			get
			{
				return _VarNameID_tblVariable;
			}
			set
			{
				_VarNameID_tblVariable = value;
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
				Com.CommandText = tblAlarm.SQL_Delete;
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
				Com.CommandText = tblAlarm.SQL_Select;
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
				Com.CommandText = tblAlarm.SQL_Insert;
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
				Com.CommandText = tblAlarm.SQL_Update;
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
		
		public tblAlarm()
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
				SqlParmColl.Add(CommonDB.AddSqlParm("@VarNameID", VarNameID, DbType.Int64));
				SqlParmColl.Add(CommonDB.AddSqlParm("@Type", Type, DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@AlarmGroupID", AlarmGroupID, DbType.Int64));
				SqlParmColl.Add(CommonDB.AddSqlParm("@EnableTagID", EnableTagID, DbType.Int64));
				SqlParmColl.Add(CommonDB.AddSqlParm("@EnableTagDirection", EnableTagDirection, DbType.Boolean));
				SqlParmColl.Add(CommonDB.AddSqlParm("@EnableTagDelayOn", EnableTagDelayOn, DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@EnableTagDealyOff", EnableTagDealyOff, DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@DelayOn", DelayOn, DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@DelayOff", DelayOff, DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@SourceAlarmTagID", SourceAlarmTagID, DbType.Int64));
				SqlParmColl.Add(CommonDB.AddSqlParm("@FirstOutGroupID", FirstOutGroupID, DbType.Int64));
				SqlParmColl.Add(CommonDB.AddSqlParm("@hysteresis", hysteresis, DbType.Single));
				SqlParmColl.Add(CommonDB.AddSqlParm("@UpperLevelGroupID", UpperLevelGroupID, DbType.Int64));
				SqlParmColl.Add(CommonDB.AddSqlParm("@StatusBit", StatusBit, DbType.Int32));
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
				// if value from the recordset, to the VarNameID _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("VarNameID")) == false))
				{
					VarNameID = ((long)(Convert.ChangeType(rs["VarNameID"], typeof(long))));
				}
				// if value from the recordset, to the Type _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("Type")) == false))
				{
					Type = ((int)(Convert.ChangeType(rs["Type"], typeof(int))));
				}
				// if value from the recordset, to the AlarmGroupID _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("AlarmGroupID")) == false))
				{
					AlarmGroupID = ((long)(Convert.ChangeType(rs["AlarmGroupID"], typeof(long))));
				}
				// if value from the recordset, to the EnableTagID _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("EnableTagID")) == false))
				{
					EnableTagID = ((long)(Convert.ChangeType(rs["EnableTagID"], typeof(long))));
				}
				// if value from the recordset, to the EnableTagDirection _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("EnableTagDirection")) == false))
				{
					EnableTagDirection = ((bool)(Convert.ChangeType(rs["EnableTagDirection"], typeof(bool))));
				}
				// if value from the recordset, to the EnableTagDelayOn _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("EnableTagDelayOn")) == false))
				{
					EnableTagDelayOn = ((int)(Convert.ChangeType(rs["EnableTagDelayOn"], typeof(int))));
				}
				// if value from the recordset, to the EnableTagDealyOff _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("EnableTagDealyOff")) == false))
				{
					EnableTagDealyOff = ((int)(Convert.ChangeType(rs["EnableTagDealyOff"], typeof(int))));
				}
				// if value from the recordset, to the DelayOn _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("DelayOn")) == false))
				{
					DelayOn = ((int)(Convert.ChangeType(rs["DelayOn"], typeof(int))));
				}
				// if value from the recordset, to the DelayOff _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("DelayOff")) == false))
				{
					DelayOff = ((int)(Convert.ChangeType(rs["DelayOff"], typeof(int))));
				}
				// if value from the recordset, to the SourceAlarmTagID _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("SourceAlarmTagID")) == false))
				{
					SourceAlarmTagID = ((long)(Convert.ChangeType(rs["SourceAlarmTagID"], typeof(long))));
				}
				// if value from the recordset, to the FirstOutGroupID _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("FirstOutGroupID")) == false))
				{
					FirstOutGroupID = ((long)(Convert.ChangeType(rs["FirstOutGroupID"], typeof(long))));
				}
				// if value from the recordset, to the hysteresis _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("hysteresis")) == false))
				{
					hysteresis = ((float)(Convert.ChangeType(rs["hysteresis"], typeof(float))));
				}
				// if value from the recordset, to the UpperLevelGroupID _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("UpperLevelGroupID")) == false))
				{
					UpperLevelGroupID = ((long)(Convert.ChangeType(rs["UpperLevelGroupID"], typeof(long))));
				}
				// if value from the recordset, to the StatusBit _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("StatusBit")) == false))
				{
					StatusBit = ((int)(Convert.ChangeType(rs["StatusBit"], typeof(int))));
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
				i = this.ColumnExistInHeader("VarNameID");
				if ((i >= 0))
				{
					VarNameID = ((long)(Convert.ChangeType(_strs[i], typeof(long))));
				}
				i = this.ColumnExistInHeader("Type");
				if ((i >= 0))
				{
					Type = ((int)(Convert.ChangeType(_strs[i], typeof(int))));
				}
				i = this.ColumnExistInHeader("AlarmGroupID");
				if ((i >= 0))
				{
					AlarmGroupID = ((long)(Convert.ChangeType(_strs[i], typeof(long))));
				}
				i = this.ColumnExistInHeader("EnableTagID");
				if ((i >= 0))
				{
					EnableTagID = ((long)(Convert.ChangeType(_strs[i], typeof(long))));
				}
				i = this.ColumnExistInHeader("EnableTagDirection");
				if ((i >= 0))
				{
					EnableTagDirection = ((bool)(Convert.ChangeType(_strs[i], typeof(bool))));
				}
				i = this.ColumnExistInHeader("EnableTagDelayOn");
				if ((i >= 0))
				{
					EnableTagDelayOn = ((int)(Convert.ChangeType(_strs[i], typeof(int))));
				}
				i = this.ColumnExistInHeader("EnableTagDealyOff");
				if ((i >= 0))
				{
					EnableTagDealyOff = ((int)(Convert.ChangeType(_strs[i], typeof(int))));
				}
				i = this.ColumnExistInHeader("DelayOn");
				if ((i >= 0))
				{
					DelayOn = ((int)(Convert.ChangeType(_strs[i], typeof(int))));
				}
				i = this.ColumnExistInHeader("DelayOff");
				if ((i >= 0))
				{
					DelayOff = ((int)(Convert.ChangeType(_strs[i], typeof(int))));
				}
				i = this.ColumnExistInHeader("SourceAlarmTagID");
				if ((i >= 0))
				{
					SourceAlarmTagID = ((long)(Convert.ChangeType(_strs[i], typeof(long))));
				}
				i = this.ColumnExistInHeader("FirstOutGroupID");
				if ((i >= 0))
				{
					FirstOutGroupID = ((long)(Convert.ChangeType(_strs[i], typeof(long))));
				}
				i = this.ColumnExistInHeader("hysteresis");
				if ((i >= 0))
				{
					hysteresis = ((float)(Convert.ChangeType(_strs[i], typeof(float))));
				}
				i = this.ColumnExistInHeader("UpperLevelGroupID");
				if ((i >= 0))
				{
					UpperLevelGroupID = ((long)(Convert.ChangeType(_strs[i], typeof(long))));
				}
				i = this.ColumnExistInHeader("StatusBit");
				if ((i >= 0))
				{
					StatusBit = ((int)(Convert.ChangeType(_strs[i], typeof(int))));
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
	
	public delegate void tblAlarmChangedEventHandler(object sender, System.EventArgs e);
	
	public partial class tblAlarmCollection : SQLiteTableCollection
	{
		
		/// <remarks>SQL Type:tblAlarmChangedEventHandler</remarks>
		public event tblAlarmChangedEventHandler tblAlarmChanged;
		
		/// <remarks>Represents the foreign key object</remarks>
		private tblVariable _VarNameID_tblVariable;
		
		[Description("Represents the foreign key object of the type VarNameID")]
		public tblVariable m_VarNameID_tblVariable
		{
			get
			{
				return _VarNameID_tblVariable;
			}
			set
			{
				_VarNameID_tblVariable = value;
			}
		}
		
		[Description("Constructor")]
		public tblAlarmCollection(tblVariable _parent)
		{
			_VarNameID_tblVariable = _parent;
		}
		
		[Description("Invoke the Changed event; called whenever list changes")]
		protected virtual void OntblAlarmChanged(System.EventArgs e)
		{
			if (tblAlarmChanged != null)
			{
				this.tblAlarmChanged(this, e);
			}
		}
		
		[Description("Gets a  tblAlarm from the collection.")]
		public tblAlarm this[int index]
		{
			get
			{
				return ((tblAlarm)(List[index]));
			}
			set
			{
				List[index] = value;
				this.OntblAlarmChanged(EventArgs.Empty);
			}
		}
		
		[Description("Gets a  tblAlarm from the collection.")]
		public tblAlarm Get(int index)
		{
			return ((tblAlarm)(List[index]));
		}
		
		[Description("Adds a new tblAlarm to the collection.")]
		public void Add(tblAlarm item)
		{
			List.Add(item);
			this.OntblAlarmChanged(EventArgs.Empty);
		}
		
		[Description("Removes a tblAlarm from the collection.")]
		public void Remove(tblAlarm item)
		{
			List.Remove(item);
			this.OntblAlarmChanged(EventArgs.Empty);
		}
		
		[Description("Inserts an tblAlarm into the collection at the specified index.")]
		public void Insert(int index, tblAlarm item)
		{
			List.Insert(index, item);
			this.OntblAlarmChanged(EventArgs.Empty);
		}
		
		[Description("Returns the index value of the tblAlarm class in the collection.")]
		public int IndexOf(tblAlarm item)
		{
			return List.IndexOf(item);
		}
		
		[Description("Returns true if the tblAlarm class is present in the collection.")]
		public bool Contains(tblAlarm item)
		{
			return List.Contains(item);
		}
	}
}
