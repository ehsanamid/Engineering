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


    public partial class tblREAL : SQLiteTable
	{
		
		#region Static SQL String Memebers
		/// <remarks>This _databasename represents the full INSERT INTO string for the table tblREAL.</remarks>
		internal static string SQL_Insert = @"INSERT INTO [tblREAL] ([VarNameID], [UNI], [FOR], [IRL], [IRH], [LL], [HH], [L], [H], [InstrumentUnitsGrpID], [InstrumentUnitsID]) VALUES(@VarNameID, @UNI, @FOR, @IRL, @IRH, @LL, @HH, @L, @H, @InstrumentUnitsGrpID, @InstrumentUnitsID) ; select last_insert_rowid(); ";
		
		/// <remarks>This _databasename represents the full UPDATE string for the table tblREAL, with the WHERE clause.</remarks>
		internal static string SQL_Update = "UPDATE [tblREAL] SET [VarNameID] = @VarNameID, [UNI] = @UNI, [FOR] = @FOR, [IRL] " +
			"= @IRL, [IRH] = @IRH, [LL] = @LL, [HH] = @HH, [L] = @L, [H] = @H, [InstrumentUni" +
			"tsGrpID] = @InstrumentUnitsGrpID, [InstrumentUnitsID] = @InstrumentUnitsID WHERE" +
			" [ID]=@ID ";
		
		/// <remarks>This _databasename represents the full SELECT string for the table tblREAL, with the WHERE clause.</remarks>
		internal static string SQL_Select = "SELECT [VarNameID], [UNI], [FOR], [IRL], [IRH], [LL], [HH], [L], [H], [Instrument" +
			"UnitsGrpID], [InstrumentUnitsID] FROM [tblREAL] WHERE [ID]=@ID ";
		
		/// <remarks>This _databasename represents the DELETE string for the table tblREAL, with the WHERE clause.</remarks>
		internal static string SQL_Delete = "DELETE FROM [tblREAL] WHERE [ID]=@ID ";
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
		
		/// <remarks>SQL Type:System.String</remarks>
		private string _UNI = "";
		
		[DisplayName("UNI")]
		[Category("Column")]
		public string UNI
		{
			get
			{
				return _UNI;
			}
			set
			{
				_UNI = value;
			}
		}
		
		/// <remarks>SQL Type:System.Int32</remarks>
		private int _FOR;
		
		[DisplayName("FOR")]
		[Category("Column")]
		public int FOR
		{
			get
			{
				return _FOR;
			}
			set
			{
				_FOR = value;
			}
		}
		
		/// <remarks>SQL Type:System.Single</remarks>
		private float _IRL;
		
		[DisplayName("IRL")]
		[Category("Column")]
		public float IRL
		{
			get
			{
				return _IRL;
			}
			set
			{
				_IRL = value;
			}
		}
		
		/// <remarks>SQL Type:System.Single</remarks>
		private float _IRH;
		
		[DisplayName("IRH")]
		[Category("Column")]
		public float IRH
		{
			get
			{
				return _IRH;
			}
			set
			{
				_IRH = value;
			}
		}
		
		/// <remarks>SQL Type:System.Single</remarks>
		private float _LL;
		
		[DisplayName("LL")]
		[Category("Column")]
		public float LL
		{
			get
			{
				return _LL;
			}
			set
			{
				_LL = value;
			}
		}
		
		/// <remarks>SQL Type:System.Single</remarks>
		private float _HH;
		
		[DisplayName("HH")]
		[Category("Column")]
		public float HH
		{
			get
			{
				return _HH;
			}
			set
			{
				_HH = value;
			}
		}
		
		/// <remarks>SQL Type:System.Single</remarks>
		private float _L;
		
		[DisplayName("L")]
		[Category("Column")]
		public float L
		{
			get
			{
				return _L;
			}
			set
			{
				_L = value;
			}
		}
		
		/// <remarks>SQL Type:System.Single</remarks>
		private float _H;
		
		[DisplayName("H")]
		[Category("Column")]
		public float H
		{
			get
			{
				return _H;
			}
			set
			{
				_H = value;
			}
		}
		
		/// <remarks>SQL Type:System.Int64</remarks>
		private long _InstrumentUnitsGrpID = -1;
		
		[DisplayName("Instrument Units Grp ID")]
		[Category("Column")]
		public long InstrumentUnitsGrpID
		{
			get
			{
				return _InstrumentUnitsGrpID;
			}
			set
			{
				_InstrumentUnitsGrpID = value;
			}
		}
		
		/// <remarks>SQL Type:System.Int64</remarks>
		private long _InstrumentUnitsID = -1;
		
		[DisplayName("Instrument Units ID")]
		[Category("Column")]
		public long InstrumentUnitsID
		{
			get
			{
				return _InstrumentUnitsID;
			}
			set
			{
				_InstrumentUnitsID = value;
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
				Com.CommandText = tblREAL.SQL_Delete;
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
				Com.CommandText = tblREAL.SQL_Select;
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
				Com.CommandText = tblREAL.SQL_Insert;
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
				Com.CommandText = tblREAL.SQL_Update;
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
		
		public tblREAL()
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
				SqlParmColl.Add(CommonDB.AddSqlParm("@UNI", UNI, DbType.String));
				SqlParmColl.Add(CommonDB.AddSqlParm("@FOR", FOR, DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@IRL", IRL, DbType.Single));
				SqlParmColl.Add(CommonDB.AddSqlParm("@IRH", IRH, DbType.Single));
				SqlParmColl.Add(CommonDB.AddSqlParm("@LL", LL, DbType.Single));
				SqlParmColl.Add(CommonDB.AddSqlParm("@HH", HH, DbType.Single));
				SqlParmColl.Add(CommonDB.AddSqlParm("@L", L, DbType.Single));
				SqlParmColl.Add(CommonDB.AddSqlParm("@H", H, DbType.Single));
				SqlParmColl.Add(CommonDB.AddSqlParm("@InstrumentUnitsGrpID", InstrumentUnitsGrpID, DbType.Int64));
				SqlParmColl.Add(CommonDB.AddSqlParm("@InstrumentUnitsID", InstrumentUnitsID, DbType.Int64));
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
				// if value from the recordset, to the UNI _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("UNI")) == false))
				{
					UNI = ((string)(Convert.ChangeType(rs["UNI"], typeof(string))));
				}
				// if value from the recordset, to the FOR _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("FOR")) == false))
				{
					FOR = ((int)(Convert.ChangeType(rs["FOR"], typeof(int))));
				}
				// if value from the recordset, to the IRL _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("IRL")) == false))
				{
					IRL = ((float)(Convert.ChangeType(rs["IRL"], typeof(float))));
				}
				// if value from the recordset, to the IRH _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("IRH")) == false))
				{
					IRH = ((float)(Convert.ChangeType(rs["IRH"], typeof(float))));
				}
				// if value from the recordset, to the LL _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("LL")) == false))
				{
					LL = ((float)(Convert.ChangeType(rs["LL"], typeof(float))));
				}
				// if value from the recordset, to the HH _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("HH")) == false))
				{
					HH = ((float)(Convert.ChangeType(rs["HH"], typeof(float))));
				}
				// if value from the recordset, to the L _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("L")) == false))
				{
					L = ((float)(Convert.ChangeType(rs["L"], typeof(float))));
				}
				// if value from the recordset, to the H _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("H")) == false))
				{
					H = ((float)(Convert.ChangeType(rs["H"], typeof(float))));
				}
				// if value from the recordset, to the InstrumentUnitsGrpID _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("InstrumentUnitsGrpID")) == false))
				{
					InstrumentUnitsGrpID = ((long)(Convert.ChangeType(rs["InstrumentUnitsGrpID"], typeof(long))));
				}
				// if value from the recordset, to the InstrumentUnitsID _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("InstrumentUnitsID")) == false))
				{
					InstrumentUnitsID = ((long)(Convert.ChangeType(rs["InstrumentUnitsID"], typeof(long))));
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
				i = this.ColumnExistInHeader("UNI");
				if ((i >= 0))
				{
					UNI = ((string)(Convert.ChangeType(_strs[i], typeof(string))));
				}
				i = this.ColumnExistInHeader("FOR");
				if ((i >= 0))
				{
					FOR = ((int)(Convert.ChangeType(_strs[i], typeof(int))));
				}
				i = this.ColumnExistInHeader("IRL");
				if ((i >= 0))
				{
					IRL = ((float)(Convert.ChangeType(_strs[i], typeof(float))));
				}
				i = this.ColumnExistInHeader("IRH");
				if ((i >= 0))
				{
					IRH = ((float)(Convert.ChangeType(_strs[i], typeof(float))));
				}
				i = this.ColumnExistInHeader("LL");
				if ((i >= 0))
				{
					LL = ((float)(Convert.ChangeType(_strs[i], typeof(float))));
				}
				i = this.ColumnExistInHeader("HH");
				if ((i >= 0))
				{
					HH = ((float)(Convert.ChangeType(_strs[i], typeof(float))));
				}
				i = this.ColumnExistInHeader("L");
				if ((i >= 0))
				{
					L = ((float)(Convert.ChangeType(_strs[i], typeof(float))));
				}
				i = this.ColumnExistInHeader("H");
				if ((i >= 0))
				{
					H = ((float)(Convert.ChangeType(_strs[i], typeof(float))));
				}
				i = this.ColumnExistInHeader("InstrumentUnitsGrpID");
				if ((i >= 0))
				{
					InstrumentUnitsGrpID = ((long)(Convert.ChangeType(_strs[i], typeof(long))));
				}
				i = this.ColumnExistInHeader("InstrumentUnitsID");
				if ((i >= 0))
				{
					InstrumentUnitsID = ((long)(Convert.ChangeType(_strs[i], typeof(long))));
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
	
	public delegate void tblREALChangedEventHandler(object sender, System.EventArgs e);
	
	public partial class tblREALCollection : SQLiteTableCollection
	{
		
		/// <remarks>SQL Type:tblREALChangedEventHandler</remarks>
		public event tblREALChangedEventHandler tblREALChanged;
		
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
		public tblREALCollection(tblVariable _parent)
		{
			_VarNameID_tblVariable = _parent;
		}
		
		[Description("Invoke the Changed event; called whenever list changes")]
		protected virtual void OntblREALChanged(System.EventArgs e)
		{
			if (tblREALChanged != null)
			{
				this.tblREALChanged(this, e);
			}
		}
		
		[Description("Gets a  tblREAL from the collection.")]
		public tblREAL this[int index]
		{
			get
			{
				return ((tblREAL)(List[index]));
			}
			set
			{
				List[index] = value;
				this.OntblREALChanged(EventArgs.Empty);
			}
		}
		
		[Description("Gets a  tblREAL from the collection.")]
		public tblREAL Get(int index)
		{
			return ((tblREAL)(List[index]));
		}
		
		[Description("Adds a new tblREAL to the collection.")]
		public void Add(tblREAL item)
		{
			List.Add(item);
			this.OntblREALChanged(EventArgs.Empty);
		}
		
		[Description("Removes a tblREAL from the collection.")]
		public void Remove(tblREAL item)
		{
			List.Remove(item);
			this.OntblREALChanged(EventArgs.Empty);
		}
		
		[Description("Inserts an tblREAL into the collection at the specified index.")]
		public void Insert(int index, tblREAL item)
		{
			List.Insert(index, item);
			this.OntblREALChanged(EventArgs.Empty);
		}
		
		[Description("Returns the index value of the tblREAL class in the collection.")]
		public int IndexOf(tblREAL item)
		{
			return List.IndexOf(item);
		}
		
		[Description("Returns true if the tblREAL class is present in the collection.")]
		public bool Contains(tblREAL item)
		{
			return List.Contains(item);
		}
	}
}
