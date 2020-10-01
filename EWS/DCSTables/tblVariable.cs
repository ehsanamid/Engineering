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


    public partial class tblVariable : SQLiteTable
	{
		
		#region Static SQL String Memebers
		/// <remarks>This _databasename represents the full INSERT INTO string for the table tblVariable.</remarks>
		internal static string SQL_Insert = @"INSERT INTO [tblVariable] ([VarName], [pouID], [Description], [InitialVal], [Type], [Class], [Option], [PinState], [PlantStructureID], [ParentVarID], [ParentVarLinkName], [ParentVarLinkID], [DispalyID], [UsedPOUID], [ConnectedtoChannel], [ALB], [AEB], [SampleTime], [RTT], [Interval], [Archive], [ArchiveInterval], [oIndex]) VALUES(@VarName, @pouID, @Description, @InitialVal, @Type, @Class, @Option, @PinState, @PlantStructureID, @ParentVarID, @ParentVarLinkName, @ParentVarLinkID, @DispalyID, @UsedPOUID, @ConnectedtoChannel, @ALB, @AEB, @SampleTime, @RTT, @Interval, @Archive, @ArchiveInterval, @oIndex) ; select last_insert_rowid(); ";
		
		/// <remarks>This _databasename represents the full UPDATE string for the table tblVariable, with the WHERE clause.</remarks>
		internal static string SQL_Update = @"UPDATE [tblVariable] SET [VarName] = @VarName, [pouID] = @pouID, [Description] = @Description, [InitialVal] = @InitialVal, [Type] = @Type, [Class] = @Class, [Option] = @Option, [PinState] = @PinState, [PlantStructureID] = @PlantStructureID, [ParentVarID] = @ParentVarID, [ParentVarLinkName] = @ParentVarLinkName, [ParentVarLinkID] = @ParentVarLinkID, [DispalyID] = @DispalyID, [UsedPOUID] = @UsedPOUID, [ConnectedtoChannel] = @ConnectedtoChannel, [ALB] = @ALB, [AEB] = @AEB, [SampleTime] = @SampleTime, [RTT] = @RTT, [Interval] = @Interval, [Archive] = @Archive, [ArchiveInterval] = @ArchiveInterval, [oIndex] = @oIndex WHERE [VarNameID]=@VarNameID ";
		
		/// <remarks>This _databasename represents the full SELECT string for the table tblVariable, with the WHERE clause.</remarks>
		internal static string SQL_Select = @"SELECT [VarName], [pouID], [Description], [InitialVal], [Type], [Class], [Option], [PinState], [PlantStructureID], [ParentVarID], [ParentVarLinkName], [ParentVarLinkID], [DispalyID], [UsedPOUID], [ConnectedtoChannel], [ALB], [AEB], [SampleTime], [RTT], [Interval], [Archive], [ArchiveInterval], [oIndex] FROM [tblVariable] WHERE [VarNameID]=@VarNameID ";
		
		/// <remarks>This _databasename represents the DELETE string for the table tblVariable, with the WHERE clause.</remarks>
		internal static string SQL_Delete = "DELETE FROM [tblVariable] WHERE [VarNameID]=@VarNameID ";
		#endregion
		
		#region Tables Memebers
		/// <remarks>SQL Type:System.String</remarks>
		private string _VarName = "";
		
		[DisplayName("Var Name")]
		[Category("Column")]
		public string VarName
		{
			get
			{
				return _VarName;
			}
			set
			{
				_VarName = value;
			}
		}
		
		/// <remarks>SQL Type:System.Int64</remarks>
		private long _VarNameID = -1;
		
		[DisplayName("Var Name ID")]
		[Category("Primary Key")]
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
		
		/// <remarks>SQL Type:System.Int64</remarks>
		private long _pouID = -1;
		
		[DisplayName("pou ID")]
		[Category("Foreign Key")]
		public long pouID
		{
			get
			{
				return _pouID;
			}
			set
			{
				_pouID = value;
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
		private string _InitialVal = "";
		
		[DisplayName("Initial Val")]
		[Category("Column")]
		public string InitialVal
		{
			get
			{
				return _InitialVal;
			}
			set
			{
				_InitialVal = value;
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
		
		/// <remarks>SQL Type:System.Int32</remarks>
		private int _Class;
		
		[DisplayName("Class")]
		[Category("Column")]
		public int Class
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
		
		/// <remarks>SQL Type:System.String</remarks>
		private string _PinState = "";
		
		[DisplayName("Pin State")]
		[Category("Column")]
		public string PinState
		{
			get
			{
				return _PinState;
			}
			set
			{
				_PinState = value;
			}
		}
		
		/// <remarks>SQL Type:System.Int64</remarks>
		private long _PlantStructureID = -1;
		
		[DisplayName("Plant Structure ID")]
		[Category("Column")]
		public long PlantStructureID
		{
			get
			{
				return _PlantStructureID;
			}
			set
			{
				_PlantStructureID = value;
			}
		}
		
		/// <remarks>SQL Type:System.Int64</remarks>
		private long _ParentVarID = -1;
		
		[DisplayName("Parent Var ID")]
		[Category("Column")]
		public long ParentVarID
		{
			get
			{
				return _ParentVarID;
			}
			set
			{
				_ParentVarID = value;
			}
		}
		
		/// <remarks>SQL Type:System.String</remarks>
		private string _ParentVarLinkName = "";
		
		[DisplayName("Parent Var Link Name")]
		[Category("Column")]
		public string ParentVarLinkName
		{
			get
			{
				return _ParentVarLinkName;
			}
			set
			{
				_ParentVarLinkName = value;
			}
		}
		
		/// <remarks>SQL Type:System.Int64</remarks>
		private long _ParentVarLinkID = -1;
		
		[DisplayName("Parent Var Link ID")]
		[Category("Column")]
		public long ParentVarLinkID
		{
			get
			{
				return _ParentVarLinkID;
			}
			set
			{
				_ParentVarLinkID = value;
			}
		}
		
		/// <remarks>SQL Type:System.Int64</remarks>
		private long _DispalyID = -1;
		
		[DisplayName("Dispaly ID")]
		[Category("Column")]
		public long DispalyID
		{
			get
			{
				return _DispalyID;
			}
			set
			{
				_DispalyID = value;
			}
		}
		
		/// <remarks>SQL Type:System.Int64</remarks>
		private long _UsedPOUID = -1;
		
		[DisplayName("Used POUID")]
		[Category("Column")]
		public long UsedPOUID
		{
			get
			{
				return _UsedPOUID;
			}
			set
			{
				_UsedPOUID = value;
			}
		}
		
		/// <remarks>SQL Type:System.Boolean</remarks>
		private bool _ConnectedtoChannel;
		
		[DisplayName("Connectedto Channel")]
		[Category("Column")]
		public bool ConnectedtoChannel
		{
			get
			{
				return _ConnectedtoChannel;
			}
			set
			{
				_ConnectedtoChannel = value;
			}
		}
		
		/// <remarks>SQL Type:System.Int64</remarks>
		private long _ALB = -1;
		
		[DisplayName("ALB")]
		[Category("Column")]
		public long ALB
		{
			get
			{
				return _ALB;
			}
			set
			{
				_ALB = value;
			}
		}
		
		/// <remarks>SQL Type:System.Int64</remarks>
		private long _AEB = -1;
		
		[DisplayName("AEB")]
		[Category("Column")]
		public long AEB
		{
			get
			{
				return _AEB;
			}
			set
			{
				_AEB = value;
			}
		}
		
		/// <remarks>SQL Type:System.Int32</remarks>
		private int _SampleTime;
		
		[DisplayName("Sample Time")]
		[Category("Column")]
		public int SampleTime
		{
			get
			{
				return _SampleTime;
			}
			set
			{
				_SampleTime = value;
			}
		}
		
		/// <remarks>SQL Type:System.Boolean</remarks>
		private bool _RTT;
		
		[DisplayName("RTT")]
		[Category("Column")]
		public bool RTT
		{
			get
			{
				return _RTT;
			}
			set
			{
				_RTT = value;
			}
		}
		
		/// <remarks>SQL Type:System.Int32</remarks>
		private int _Interval;
		
		[DisplayName("Interval")]
		[Category("Column")]
		public int Interval
		{
			get
			{
				return _Interval;
			}
			set
			{
				_Interval = value;
			}
		}
		
		/// <remarks>SQL Type:System.Boolean</remarks>
		private bool _Archive;
		
		[DisplayName("Archive")]
		[Category("Column")]
		public bool Archive
		{
			get
			{
				return _Archive;
			}
			set
			{
				_Archive = value;
			}
		}
		
		/// <remarks>SQL Type:System.Int32</remarks>
		private int _ArchiveInterval;
		
		[DisplayName("Archive Interval")]
		[Category("Column")]
		public int ArchiveInterval
		{
			get
			{
				return _ArchiveInterval;
			}
			set
			{
				_ArchiveInterval = value;
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
		#endregion
		
		#region Related Objects
		/// <remarks>Represents the foreign key object</remarks>
		private tblPou _pouID_tblPou;
		
		[Description("Represents the foreign key object of the type pouID")]
		public tblPou m_pouID_tblPou
		{
			get
			{
				return _pouID_tblPou;
			}
			set
			{
				_pouID_tblPou = value;
			}
		}
		#endregion
		
		#region Collection Objects
		/// <remarks>Lock for accessing collection</remarks>
		private readonly object _tblAlarmCollectionLock = new object();
		
		/// <remarks>Represents the foreign key object</remarks>
		private tblAlarmCollection _tblAlarmCollection;
		
		[Description("Represents the foreign key object of the type VarNameID")]
		public tblAlarmCollection m_tblAlarmCollection
		{
			get
			{
              lock(_tblAlarmCollectionLock)
              {
				if (_tblAlarmCollection == null)
				{
					_tblAlarmCollection =  new tblAlarmCollection(this);
					_tblAlarmCollection.Load();
				}
				return _tblAlarmCollection;
              }
			}
			set
			{
				_tblAlarmCollection = value;
			}
		}
		
		/// <remarks>Lock for accessing collection</remarks>
		private readonly object _tblBOOLCollectionLock = new object();
		
		/// <remarks>Represents the foreign key object</remarks>
		private tblBOOLCollection _tblBOOLCollection;
		
		[Description("Represents the foreign key object of the type VarNameID")]
		public tblBOOLCollection m_tblBOOLCollection
		{
			get
			{
              lock(_tblBOOLCollectionLock)
              {
				if (_tblBOOLCollection == null)
				{
					_tblBOOLCollection =  new tblBOOLCollection(this);
					_tblBOOLCollection.Load();
				}
				return _tblBOOLCollection;
              }
			}
			set
			{
				_tblBOOLCollection = value;
			}
		}
		
		/// <remarks>Lock for accessing collection</remarks>
		private readonly object _tblREALCollectionLock = new object();
		
		/// <remarks>Represents the foreign key object</remarks>
		private tblREALCollection _tblREALCollection;
		
		[Description("Represents the foreign key object of the type VarNameID")]
		public tblREALCollection m_tblREALCollection
		{
			get
			{
              lock(_tblREALCollectionLock)
              {
				if (_tblREALCollection == null)
				{
					_tblREALCollection =  new tblREALCollection(this);
					_tblREALCollection.Load();
				}
				return _tblREALCollection;
              }
			}
			set
			{
				_tblREALCollection = value;
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
				Com.CommandText = tblVariable.SQL_Delete;
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
				Com.CommandText = tblVariable.SQL_Select;
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
				Com.CommandText = tblVariable.SQL_Insert;
				Com.Parameters.AddRange(GetSqlParameters());
				VarNameID = ((long)(Convert.ToInt64(Com.ExecuteScalar())));
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
				Com.CommandText = tblVariable.SQL_Update;
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
		
		public tblVariable()
		{
		}
		#endregion
		
		#region Private Methods
		private SQLiteParameter[] GetSqlParameters()
		{
			List<SQLiteParameter> SqlParmColl = new List<SQLiteParameter>();
			try
			{
				SqlParmColl.Add(CommonDB.AddSqlParm("@VarName", VarName, DbType.String));
				SqlParmColl.Add(CommonDB.AddSqlParm("@VarNameID", VarNameID, DbType.Int64));
				SqlParmColl.Add(CommonDB.AddSqlParm("@pouID", pouID, DbType.Int64));
				SqlParmColl.Add(CommonDB.AddSqlParm("@Description", Description, DbType.String));
				SqlParmColl.Add(CommonDB.AddSqlParm("@InitialVal", InitialVal, DbType.String));
				SqlParmColl.Add(CommonDB.AddSqlParm("@Type", Type, DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@Class", Class, DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@Option", Option, DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@PinState", PinState, DbType.String));
				SqlParmColl.Add(CommonDB.AddSqlParm("@PlantStructureID", PlantStructureID, DbType.Int64));
				SqlParmColl.Add(CommonDB.AddSqlParm("@ParentVarID", ParentVarID, DbType.Int64));
				SqlParmColl.Add(CommonDB.AddSqlParm("@ParentVarLinkName", ParentVarLinkName, DbType.String));
				SqlParmColl.Add(CommonDB.AddSqlParm("@ParentVarLinkID", ParentVarLinkID, DbType.Int64));
				SqlParmColl.Add(CommonDB.AddSqlParm("@DispalyID", DispalyID, DbType.Int64));
				SqlParmColl.Add(CommonDB.AddSqlParm("@UsedPOUID", UsedPOUID, DbType.Int64));
				SqlParmColl.Add(CommonDB.AddSqlParm("@ConnectedtoChannel", ConnectedtoChannel, DbType.Boolean));
				SqlParmColl.Add(CommonDB.AddSqlParm("@ALB", ALB, DbType.Int64));
				SqlParmColl.Add(CommonDB.AddSqlParm("@AEB", AEB, DbType.Int64));
				SqlParmColl.Add(CommonDB.AddSqlParm("@SampleTime", SampleTime, DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@RTT", RTT, DbType.Boolean));
				SqlParmColl.Add(CommonDB.AddSqlParm("@Interval", Interval, DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@Archive", Archive, DbType.Boolean));
				SqlParmColl.Add(CommonDB.AddSqlParm("@ArchiveInterval", ArchiveInterval, DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@oIndex", oIndex, DbType.Int32));
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
				// if value from the recordset, to the VarName _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("VarName")) == false))
				{
					VarName = ((string)(Convert.ChangeType(rs["VarName"], typeof(string))));
				}
				// if value from the recordset, to the VarNameID _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("VarNameID")) == false))
				{
					VarNameID = ((long)(Convert.ChangeType(rs["VarNameID"], typeof(long))));
				}
				// if value from the recordset, to the pouID _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("pouID")) == false))
				{
					pouID = ((long)(Convert.ChangeType(rs["pouID"], typeof(long))));
				}
				// if value from the recordset, to the Description _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("Description")) == false))
				{
					Description = ((string)(Convert.ChangeType(rs["Description"], typeof(string))));
				}
				// if value from the recordset, to the InitialVal _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("InitialVal")) == false))
				{
					InitialVal = ((string)(Convert.ChangeType(rs["InitialVal"], typeof(string))));
				}
				// if value from the recordset, to the Type _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("Type")) == false))
				{
					Type = ((int)(Convert.ChangeType(rs["Type"], typeof(int))));
				}
				// if value from the recordset, to the Class _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("Class")) == false))
				{
					Class = ((int)(Convert.ChangeType(rs["Class"], typeof(int))));
				}
				// if value from the recordset, to the Option _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("Option")) == false))
				{
					Option = ((int)(Convert.ChangeType(rs["Option"], typeof(int))));
				}
				// if value from the recordset, to the PinState _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("PinState")) == false))
				{
					PinState = ((string)(Convert.ChangeType(rs["PinState"], typeof(string))));
				}
				// if value from the recordset, to the PlantStructureID _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("PlantStructureID")) == false))
				{
					PlantStructureID = ((long)(Convert.ChangeType(rs["PlantStructureID"], typeof(long))));
				}
				// if value from the recordset, to the ParentVarID _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("ParentVarID")) == false))
				{
					ParentVarID = ((long)(Convert.ChangeType(rs["ParentVarID"], typeof(long))));
				}
				// if value from the recordset, to the ParentVarLinkName _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("ParentVarLinkName")) == false))
				{
					ParentVarLinkName = ((string)(Convert.ChangeType(rs["ParentVarLinkName"], typeof(string))));
				}
				// if value from the recordset, to the ParentVarLinkID _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("ParentVarLinkID")) == false))
				{
					ParentVarLinkID = ((long)(Convert.ChangeType(rs["ParentVarLinkID"], typeof(long))));
				}
				// if value from the recordset, to the DispalyID _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("DispalyID")) == false))
				{
					DispalyID = ((long)(Convert.ChangeType(rs["DispalyID"], typeof(long))));
				}
				// if value from the recordset, to the UsedPOUID _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("UsedPOUID")) == false))
				{
					UsedPOUID = ((long)(Convert.ChangeType(rs["UsedPOUID"], typeof(long))));
				}
				// if value from the recordset, to the ConnectedtoChannel _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("ConnectedtoChannel")) == false))
				{
					ConnectedtoChannel = ((bool)(Convert.ChangeType(rs["ConnectedtoChannel"], typeof(bool))));
				}
				// if value from the recordset, to the ALB _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("ALB")) == false))
				{
					ALB = ((long)(Convert.ChangeType(rs["ALB"], typeof(long))));
				}
				// if value from the recordset, to the AEB _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("AEB")) == false))
				{
					AEB = ((long)(Convert.ChangeType(rs["AEB"], typeof(long))));
				}
				// if value from the recordset, to the SampleTime _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("SampleTime")) == false))
				{
					SampleTime = ((int)(Convert.ChangeType(rs["SampleTime"], typeof(int))));
				}
				// if value from the recordset, to the RTT _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("RTT")) == false))
				{
					RTT = ((bool)(Convert.ChangeType(rs["RTT"], typeof(bool))));
				}
				// if value from the recordset, to the Interval _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("Interval")) == false))
				{
					Interval = ((int)(Convert.ChangeType(rs["Interval"], typeof(int))));
				}
				// if value from the recordset, to the Archive _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("Archive")) == false))
				{
					Archive = ((bool)(Convert.ChangeType(rs["Archive"], typeof(bool))));
				}
				// if value from the recordset, to the ArchiveInterval _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("ArchiveInterval")) == false))
				{
					ArchiveInterval = ((int)(Convert.ChangeType(rs["ArchiveInterval"], typeof(int))));
				}
				// if value from the recordset, to the oIndex _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("oIndex")) == false))
				{
					oIndex = ((int)(Convert.ChangeType(rs["oIndex"], typeof(int))));
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
				i = this.ColumnExistInHeader("VarName");
				if ((i >= 0))
				{
					VarName = ((string)(Convert.ChangeType(_strs[i], typeof(string))));
				}
				i = this.ColumnExistInHeader("pouID");
				if ((i >= 0))
				{
					pouID = ((long)(Convert.ChangeType(_strs[i], typeof(long))));
				}
				i = this.ColumnExistInHeader("Description");
				if ((i >= 0))
				{
					Description = ((string)(Convert.ChangeType(_strs[i], typeof(string))));
				}
				i = this.ColumnExistInHeader("InitialVal");
				if ((i >= 0))
				{
					InitialVal = ((string)(Convert.ChangeType(_strs[i], typeof(string))));
				}
				i = this.ColumnExistInHeader("Type");
				if ((i >= 0))
				{
					Type = ((int)(Convert.ChangeType(_strs[i], typeof(int))));
				}
				i = this.ColumnExistInHeader("Class");
				if ((i >= 0))
				{
					Class = ((int)(Convert.ChangeType(_strs[i], typeof(int))));
				}
				i = this.ColumnExistInHeader("Option");
				if ((i >= 0))
				{
					Option = ((int)(Convert.ChangeType(_strs[i], typeof(int))));
				}
				i = this.ColumnExistInHeader("PinState");
				if ((i >= 0))
				{
					PinState = ((string)(Convert.ChangeType(_strs[i], typeof(string))));
				}
				i = this.ColumnExistInHeader("PlantStructureID");
				if ((i >= 0))
				{
					PlantStructureID = ((long)(Convert.ChangeType(_strs[i], typeof(long))));
				}
				i = this.ColumnExistInHeader("ParentVarID");
				if ((i >= 0))
				{
					ParentVarID = ((long)(Convert.ChangeType(_strs[i], typeof(long))));
				}
				i = this.ColumnExistInHeader("ParentVarLinkName");
				if ((i >= 0))
				{
					ParentVarLinkName = ((string)(Convert.ChangeType(_strs[i], typeof(string))));
				}
				i = this.ColumnExistInHeader("ParentVarLinkID");
				if ((i >= 0))
				{
					ParentVarLinkID = ((long)(Convert.ChangeType(_strs[i], typeof(long))));
				}
				i = this.ColumnExistInHeader("DispalyID");
				if ((i >= 0))
				{
					DispalyID = ((long)(Convert.ChangeType(_strs[i], typeof(long))));
				}
				i = this.ColumnExistInHeader("UsedPOUID");
				if ((i >= 0))
				{
					UsedPOUID = ((long)(Convert.ChangeType(_strs[i], typeof(long))));
				}
				i = this.ColumnExistInHeader("ConnectedtoChannel");
				if ((i >= 0))
				{
					ConnectedtoChannel = ((bool)(Convert.ChangeType(_strs[i], typeof(bool))));
				}
				i = this.ColumnExistInHeader("ALB");
				if ((i >= 0))
				{
					ALB = ((long)(Convert.ChangeType(_strs[i], typeof(long))));
				}
				i = this.ColumnExistInHeader("AEB");
				if ((i >= 0))
				{
					AEB = ((long)(Convert.ChangeType(_strs[i], typeof(long))));
				}
				i = this.ColumnExistInHeader("SampleTime");
				if ((i >= 0))
				{
					SampleTime = ((int)(Convert.ChangeType(_strs[i], typeof(int))));
				}
				i = this.ColumnExistInHeader("RTT");
				if ((i >= 0))
				{
					RTT = ((bool)(Convert.ChangeType(_strs[i], typeof(bool))));
				}
				i = this.ColumnExistInHeader("Interval");
				if ((i >= 0))
				{
					Interval = ((int)(Convert.ChangeType(_strs[i], typeof(int))));
				}
				i = this.ColumnExistInHeader("Archive");
				if ((i >= 0))
				{
					Archive = ((bool)(Convert.ChangeType(_strs[i], typeof(bool))));
				}
				i = this.ColumnExistInHeader("ArchiveInterval");
				if ((i >= 0))
				{
					ArchiveInterval = ((int)(Convert.ChangeType(_strs[i], typeof(int))));
				}
				i = this.ColumnExistInHeader("oIndex");
				if ((i >= 0))
				{
					oIndex = ((int)(Convert.ChangeType(_strs[i], typeof(int))));
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
	
	public delegate void tblVariableChangedEventHandler(object sender, System.EventArgs e);
	
	public partial class tblVariableCollection : SQLiteTableCollection
	{
		
		/// <remarks>SQL Type:tblVariableChangedEventHandler</remarks>
		public event tblVariableChangedEventHandler tblVariableChanged;
		
		/// <remarks>Represents the foreign key object</remarks>
		private tblPou _pouID_tblPou;
		
		[Description("Represents the foreign key object of the type pouID")]
		public tblPou m_pouID_tblPou
		{
			get
			{
				return _pouID_tblPou;
			}
			set
			{
				_pouID_tblPou = value;
			}
		}
		
		[Description("Constructor")]
		public tblVariableCollection(tblPou _parent)
		{
			_pouID_tblPou = _parent;
		}
		
		[Description("Invoke the Changed event; called whenever list changes")]
		protected virtual void OntblVariableChanged(System.EventArgs e)
		{
			if (tblVariableChanged != null)
			{
				this.tblVariableChanged(this, e);
			}
		}
		
		[Description("Gets a  tblVariable from the collection.")]
		public tblVariable this[int index]
		{
			get
			{
				return ((tblVariable)(List[index]));
			}
			set
			{
				List[index] = value;
				this.OntblVariableChanged(EventArgs.Empty);
			}
		}
		
		[Description("Gets a  tblVariable from the collection.")]
		public tblVariable Get(int index)
		{
			return ((tblVariable)(List[index]));
		}
		
		[Description("Adds a new tblVariable to the collection.")]
		public void Add(tblVariable item)
		{
			List.Add(item);
			this.OntblVariableChanged(EventArgs.Empty);
		}
		
		[Description("Removes a tblVariable from the collection.")]
		public void Remove(tblVariable item)
		{
			List.Remove(item);
			this.OntblVariableChanged(EventArgs.Empty);
		}
		
		[Description("Inserts an tblVariable into the collection at the specified index.")]
		public void Insert(int index, tblVariable item)
		{
			List.Insert(index, item);
			this.OntblVariableChanged(EventArgs.Empty);
		}
		
		[Description("Returns the index value of the tblVariable class in the collection.")]
		public int IndexOf(tblVariable item)
		{
			return List.IndexOf(item);
		}
		
		[Description("Returns true if the tblVariable class is present in the collection.")]
		public bool Contains(tblVariable item)
		{
			return List.Contains(item);
		}
	}
}
