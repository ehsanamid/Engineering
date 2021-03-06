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


    public partial class tblHMI : SQLiteTable
	{
		
		#region Static SQL String Memebers
		/// <remarks>This _databasename represents the full INSERT INTO string for the table tblHMI.</remarks>
		internal static string SQL_Insert = @"INSERT INTO [tblHMI] ([HMIName], [SolutionID], [NodeNumber], [oIndex], [Description], [CommandTimer], [DualMonitor], [redundantnet], [Redundant], [NetNo]) VALUES(@HMIName, @SolutionID, @NodeNumber, @oIndex, @Description, @CommandTimer, @DualMonitor, @redundantnet, @Redundant, @NetNo) ; select last_insert_rowid(); ";
		
		/// <remarks>This _databasename represents the full UPDATE string for the table tblHMI, with the WHERE clause.</remarks>
		internal static string SQL_Update = @"UPDATE [tblHMI] SET [HMIName] = @HMIName, [SolutionID] = @SolutionID, [NodeNumber] = @NodeNumber, [oIndex] = @oIndex, [Description] = @Description, [CommandTimer] = @CommandTimer, [DualMonitor] = @DualMonitor, [redundantnet] = @redundantnet, [Redundant] = @Redundant, [NetNo] = @NetNo WHERE [HMIID]=@HMIID ";
		
		/// <remarks>This _databasename represents the full SELECT string for the table tblHMI, with the WHERE clause.</remarks>
		internal static string SQL_Select = "SELECT [HMIName], [SolutionID], [NodeNumber], [oIndex], [Description], [CommandTi" +
			"mer], [DualMonitor], [redundantnet], [Redundant], [NetNo] FROM [tblHMI] WHERE [H" +
			"MIID]=@HMIID ";
		
		/// <remarks>This _databasename represents the DELETE string for the table tblHMI, with the WHERE clause.</remarks>
		internal static string SQL_Delete = "DELETE FROM [tblHMI] WHERE [HMIID]=@HMIID ";
		#endregion
		
		#region Tables Memebers
		/// <remarks>SQL Type:System.String</remarks>
		private string _HMIName = "";
		
		[DisplayName("HMIName")]
		[Category("Column")]
		public string HMIName
		{
			get
			{
				return _HMIName;
			}
			set
			{
				_HMIName = value;
			}
		}
		
		/// <remarks>SQL Type:System.Int64</remarks>
		private long _HMIID = -1;
		
		[DisplayName("HMIID")]
		[Category("Primary Key")]
		public long HMIID
		{
			get
			{
				return _HMIID;
			}
			set
			{
				_HMIID = value;
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
		
		/// <remarks>SQL Type:System.Int16</remarks>
		private short _NodeNumber;
		
		[DisplayName("Node Number")]
		[Category("Column")]
		public short NodeNumber
		{
			get
			{
				return _NodeNumber;
			}
			set
			{
				_NodeNumber = value;
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
		private int _CommandTimer;
		
		[DisplayName("Command Timer")]
		[Category("Column")]
		public int CommandTimer
		{
			get
			{
				return _CommandTimer;
			}
			set
			{
				_CommandTimer = value;
			}
		}
		
		/// <remarks>SQL Type:System.Boolean</remarks>
		private bool _DualMonitor;
		
		[DisplayName("Dual Monitor")]
		[Category("Column")]
		public bool DualMonitor
		{
			get
			{
				return _DualMonitor;
			}
			set
			{
				_DualMonitor = value;
			}
		}
		
		/// <remarks>SQL Type:System.Boolean</remarks>
		private bool _redundantnet;
		
		[DisplayName("redundantnet")]
		[Category("Column")]
		public bool redundantnet
		{
			get
			{
				return _redundantnet;
			}
			set
			{
				_redundantnet = value;
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
		private int _NetNo;
		
		[DisplayName("Net No")]
		[Category("Column")]
		public int NetNo
		{
			get
			{
				return _NetNo;
			}
			set
			{
				_NetNo = value;
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
				Com.CommandText = tblHMI.SQL_Delete;
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
				Com.CommandText = tblHMI.SQL_Select;
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
				Com.CommandText = tblHMI.SQL_Insert;
				Com.Parameters.AddRange(GetSqlParameters());
				HMIID = ((long)(Convert.ToInt64(Com.ExecuteScalar())));
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
				Com.CommandText = tblHMI.SQL_Update;
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
		
		public tblHMI()
		{
		}
		#endregion
		
		#region Private Methods
		private SQLiteParameter[] GetSqlParameters()
		{
			List<SQLiteParameter> SqlParmColl = new List<SQLiteParameter>();
			try
			{
				SqlParmColl.Add(CommonDB.AddSqlParm("@HMIName", HMIName, DbType.String));
				SqlParmColl.Add(CommonDB.AddSqlParm("@HMIID", HMIID, DbType.Int64));
				SqlParmColl.Add(CommonDB.AddSqlParm("@SolutionID", SolutionID, DbType.Int64));
				SqlParmColl.Add(CommonDB.AddSqlParm("@NodeNumber", NodeNumber, DbType.Int16));
				SqlParmColl.Add(CommonDB.AddSqlParm("@oIndex", oIndex, DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@Description", Description, DbType.String));
				SqlParmColl.Add(CommonDB.AddSqlParm("@CommandTimer", CommandTimer, DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@DualMonitor", DualMonitor, DbType.Boolean));
				SqlParmColl.Add(CommonDB.AddSqlParm("@redundantnet", redundantnet, DbType.Boolean));
				SqlParmColl.Add(CommonDB.AddSqlParm("@Redundant", Redundant, DbType.Boolean));
				SqlParmColl.Add(CommonDB.AddSqlParm("@NetNo", NetNo, DbType.Int32));
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
				// if value from the recordset, to the HMIName _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("HMIName")) == false))
				{
					HMIName = ((string)(Convert.ChangeType(rs["HMIName"], typeof(string))));
				}
				// if value from the recordset, to the HMIID _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("HMIID")) == false))
				{
					HMIID = ((long)(Convert.ChangeType(rs["HMIID"], typeof(long))));
				}
				// if value from the recordset, to the SolutionID _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("SolutionID")) == false))
				{
					SolutionID = ((long)(Convert.ChangeType(rs["SolutionID"], typeof(long))));
				}
				// if value from the recordset, to the NodeNumber _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("NodeNumber")) == false))
				{
					NodeNumber = ((short)(Convert.ChangeType(rs["NodeNumber"], typeof(short))));
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
				// if value from the recordset, to the CommandTimer _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("CommandTimer")) == false))
				{
					CommandTimer = ((int)(Convert.ChangeType(rs["CommandTimer"], typeof(int))));
				}
				// if value from the recordset, to the DualMonitor _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("DualMonitor")) == false))
				{
					DualMonitor = ((bool)(Convert.ChangeType(rs["DualMonitor"], typeof(bool))));
				}
				// if value from the recordset, to the redundantnet _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("redundantnet")) == false))
				{
					redundantnet = ((bool)(Convert.ChangeType(rs["redundantnet"], typeof(bool))));
				}
				// if value from the recordset, to the Redundant _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("Redundant")) == false))
				{
					Redundant = ((bool)(Convert.ChangeType(rs["Redundant"], typeof(bool))));
				}
				// if value from the recordset, to the NetNo _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("NetNo")) == false))
				{
					NetNo = ((int)(Convert.ChangeType(rs["NetNo"], typeof(int))));
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
				i = this.ColumnExistInHeader("HMIName");
				if ((i >= 0))
				{
					HMIName = ((string)(Convert.ChangeType(_strs[i], typeof(string))));
				}
				i = this.ColumnExistInHeader("SolutionID");
				if ((i >= 0))
				{
					SolutionID = ((long)(Convert.ChangeType(_strs[i], typeof(long))));
				}
				i = this.ColumnExistInHeader("NodeNumber");
				if ((i >= 0))
				{
					NodeNumber = ((short)(Convert.ChangeType(_strs[i], typeof(short))));
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
				i = this.ColumnExistInHeader("CommandTimer");
				if ((i >= 0))
				{
					CommandTimer = ((int)(Convert.ChangeType(_strs[i], typeof(int))));
				}
				i = this.ColumnExistInHeader("DualMonitor");
				if ((i >= 0))
				{
					DualMonitor = ((bool)(Convert.ChangeType(_strs[i], typeof(bool))));
				}
				i = this.ColumnExistInHeader("redundantnet");
				if ((i >= 0))
				{
					redundantnet = ((bool)(Convert.ChangeType(_strs[i], typeof(bool))));
				}
				i = this.ColumnExistInHeader("Redundant");
				if ((i >= 0))
				{
					Redundant = ((bool)(Convert.ChangeType(_strs[i], typeof(bool))));
				}
				i = this.ColumnExistInHeader("NetNo");
				if ((i >= 0))
				{
					NetNo = ((int)(Convert.ChangeType(_strs[i], typeof(int))));
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
	
	public delegate void tblHMIChangedEventHandler(object sender, System.EventArgs e);
	
	public partial class tblHMICollection : SQLiteTableCollection
	{
		
		/// <remarks>SQL Type:tblHMIChangedEventHandler</remarks>
		public event tblHMIChangedEventHandler tblHMIChanged;
		
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
		public tblHMICollection(tblSolution _parent)
		{
			_SolutionID_tblSolution = _parent;
		}
		
		[Description("Invoke the Changed event; called whenever list changes")]
		protected virtual void OntblHMIChanged(System.EventArgs e)
		{
			if (tblHMIChanged != null)
			{
				this.tblHMIChanged(this, e);
			}
		}
		
		[Description("Gets a  tblHMI from the collection.")]
		public tblHMI this[int index]
		{
			get
			{
				return ((tblHMI)(List[index]));
			}
			set
			{
				List[index] = value;
				this.OntblHMIChanged(EventArgs.Empty);
			}
		}
		
		[Description("Gets a  tblHMI from the collection.")]
		public tblHMI Get(int index)
		{
			return ((tblHMI)(List[index]));
		}
		
		[Description("Adds a new tblHMI to the collection.")]
		public void Add(tblHMI item)
		{
			List.Add(item);
			this.OntblHMIChanged(EventArgs.Empty);
		}
		
		[Description("Removes a tblHMI from the collection.")]
		public void Remove(tblHMI item)
		{
			List.Remove(item);
			this.OntblHMIChanged(EventArgs.Empty);
		}
		
		[Description("Inserts an tblHMI into the collection at the specified index.")]
		public void Insert(int index, tblHMI item)
		{
			List.Insert(index, item);
			this.OntblHMIChanged(EventArgs.Empty);
		}
		
		[Description("Returns the index value of the tblHMI class in the collection.")]
		public int IndexOf(tblHMI item)
		{
			return List.IndexOf(item);
		}
		
		[Description("Returns true if the tblHMI class is present in the collection.")]
		public bool Contains(tblHMI item)
		{
			return List.Contains(item);
		}
	}
}
