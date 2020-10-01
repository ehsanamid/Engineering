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


    public partial class tblFBDAlarmOrder : SQLiteTable
	{
		
		#region Static SQL String Memebers
		/// <remarks>This _databasename represents the full INSERT INTO string for the table tblFBDAlarmOrder.</remarks>
		internal static string SQL_Insert = "INSERT INTO [tblFBDAlarmOrder] ([FunctionID], [FunctionType], [Status], [oIndex])" +
			" VALUES(@FunctionID, @FunctionType, @Status, @oIndex) ; select last_insert_rowid" +
			"(); ";
		
		/// <remarks>This _databasename represents the full UPDATE string for the table tblFBDAlarmOrder, with the WHERE clause.</remarks>
		internal static string SQL_Update = "UPDATE [tblFBDAlarmOrder] SET [FunctionID] = @FunctionID, [FunctionType] = @Funct" +
			"ionType, [Status] = @Status, [oIndex] = @oIndex WHERE [ID]=@ID ";
		
		/// <remarks>This _databasename represents the full SELECT string for the table tblFBDAlarmOrder, with the WHERE clause.</remarks>
		internal static string SQL_Select = "SELECT [FunctionID], [FunctionType], [Status], [oIndex] FROM [tblFBDAlarmOrder] W" +
			"HERE [ID]=@ID ";
		
		/// <remarks>This _databasename represents the DELETE string for the table tblFBDAlarmOrder, with the WHERE clause.</remarks>
		internal static string SQL_Delete = "DELETE FROM [tblFBDAlarmOrder] WHERE [ID]=@ID ";
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
		private int _FunctionType;
		
		[DisplayName("Function Type")]
		[Category("Column")]
		public int FunctionType
		{
			get
			{
				return _FunctionType;
			}
			set
			{
				_FunctionType = value;
			}
		}
		
		/// <remarks>SQL Type:System.Int32</remarks>
		private int _Status;
		
		[DisplayName("Status")]
		[Category("Column")]
		public int Status
		{
			get
			{
				return _Status;
			}
			set
			{
				_Status = value;
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
				Com.CommandText = tblFBDAlarmOrder.SQL_Delete;
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
				Com.CommandText = tblFBDAlarmOrder.SQL_Select;
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
				Com.CommandText = tblFBDAlarmOrder.SQL_Insert;
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
				Com.CommandText = tblFBDAlarmOrder.SQL_Update;
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
		
		public tblFBDAlarmOrder()
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
				SqlParmColl.Add(CommonDB.AddSqlParm("@FunctionID", FunctionID, DbType.Int64));
				SqlParmColl.Add(CommonDB.AddSqlParm("@FunctionType", FunctionType, DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@Status", Status, DbType.Int32));
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
				// if value from the recordset, to the ID _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("ID")) == false))
				{
					ID = ((long)(Convert.ChangeType(rs["ID"], typeof(long))));
				}
				// if value from the recordset, to the FunctionID _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("FunctionID")) == false))
				{
					FunctionID = ((long)(Convert.ChangeType(rs["FunctionID"], typeof(long))));
				}
				// if value from the recordset, to the FunctionType _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("FunctionType")) == false))
				{
					FunctionType = ((int)(Convert.ChangeType(rs["FunctionType"], typeof(int))));
				}
				// if value from the recordset, to the Status _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("Status")) == false))
				{
					Status = ((int)(Convert.ChangeType(rs["Status"], typeof(int))));
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
				i = this.ColumnExistInHeader("FunctionID");
				if ((i >= 0))
				{
					FunctionID = ((long)(Convert.ChangeType(_strs[i], typeof(long))));
				}
				i = this.ColumnExistInHeader("FunctionType");
				if ((i >= 0))
				{
					FunctionType = ((int)(Convert.ChangeType(_strs[i], typeof(int))));
				}
				i = this.ColumnExistInHeader("Status");
				if ((i >= 0))
				{
					Status = ((int)(Convert.ChangeType(_strs[i], typeof(int))));
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
	
	public delegate void tblFBDAlarmOrderChangedEventHandler(object sender, System.EventArgs e);
	
	public partial class tblFBDAlarmOrderCollection : SQLiteTableCollection
	{
		
		/// <remarks>SQL Type:tblFBDAlarmOrderChangedEventHandler</remarks>
		public event tblFBDAlarmOrderChangedEventHandler tblFBDAlarmOrderChanged;
		
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
		public tblFBDAlarmOrderCollection(tblFunction _parent)
		{
			_FunctionID_tblFunction = _parent;
		}
		
		[Description("Invoke the Changed event; called whenever list changes")]
		protected virtual void OntblFBDAlarmOrderChanged(System.EventArgs e)
		{
			if (tblFBDAlarmOrderChanged != null)
			{
				this.tblFBDAlarmOrderChanged(this, e);
			}
		}
		
		[Description("Gets a  tblFBDAlarmOrder from the collection.")]
		public tblFBDAlarmOrder this[int index]
		{
			get
			{
				return ((tblFBDAlarmOrder)(List[index]));
			}
			set
			{
				List[index] = value;
				this.OntblFBDAlarmOrderChanged(EventArgs.Empty);
			}
		}
		
		[Description("Gets a  tblFBDAlarmOrder from the collection.")]
		public tblFBDAlarmOrder Get(int index)
		{
			return ((tblFBDAlarmOrder)(List[index]));
		}
		
		[Description("Adds a new tblFBDAlarmOrder to the collection.")]
		public void Add(tblFBDAlarmOrder item)
		{
			List.Add(item);
			this.OntblFBDAlarmOrderChanged(EventArgs.Empty);
		}
		
		[Description("Removes a tblFBDAlarmOrder from the collection.")]
		public void Remove(tblFBDAlarmOrder item)
		{
			List.Remove(item);
			this.OntblFBDAlarmOrderChanged(EventArgs.Empty);
		}
		
		[Description("Inserts an tblFBDAlarmOrder into the collection at the specified index.")]
		public void Insert(int index, tblFBDAlarmOrder item)
		{
			List.Insert(index, item);
			this.OntblFBDAlarmOrderChanged(EventArgs.Empty);
		}
		
		[Description("Returns the index value of the tblFBDAlarmOrder class in the collection.")]
		public int IndexOf(tblFBDAlarmOrder item)
		{
			return List.IndexOf(item);
		}
		
		[Description("Returns true if the tblFBDAlarmOrder class is present in the collection.")]
		public bool Contains(tblFBDAlarmOrder item)
		{
			return List.Contains(item);
		}
	}
}