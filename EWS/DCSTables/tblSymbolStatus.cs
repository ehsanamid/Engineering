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


    public partial class tblSymbolStatus : SQLiteTable
	{
		
		#region Static SQL String Memebers
		/// <remarks>This _databasename represents the full INSERT INTO string for the table tblSymbolStatus.</remarks>
		internal static string SQL_Insert = "INSERT INTO [tblSymbolStatus] ([StatusNo], [SymbolID]) VALUES(@StatusNo, @SymbolI" +
			"D) ; select last_insert_rowid(); ";
		
		/// <remarks>This _databasename represents the full UPDATE string for the table tblSymbolStatus, with the WHERE clause.</remarks>
		internal static string SQL_Update = "UPDATE [tblSymbolStatus] SET [StatusNo] = @StatusNo, [SymbolID] = @SymbolID WHERE" +
			" [SymbolStatusID]=@SymbolStatusID ";
		
		/// <remarks>This _databasename represents the full SELECT string for the table tblSymbolStatus, with the WHERE clause.</remarks>
		internal static string SQL_Select = "SELECT [StatusNo], [SymbolID] FROM [tblSymbolStatus] WHERE [SymbolStatusID]=@Symb" +
			"olStatusID ";
		
		/// <remarks>This _databasename represents the DELETE string for the table tblSymbolStatus, with the WHERE clause.</remarks>
		internal static string SQL_Delete = "DELETE FROM [tblSymbolStatus] WHERE [SymbolStatusID]=@SymbolStatusID ";
		#endregion
		
		#region Tables Memebers
		/// <remarks>SQL Type:System.Int64</remarks>
		private long _SymbolStatusID = -1;
		
		[DisplayName("Symbol Status ID")]
		[Category("Primary Key")]
		public long SymbolStatusID
		{
			get
			{
				return _SymbolStatusID;
			}
			set
			{
				_SymbolStatusID = value;
			}
		}
		
		/// <remarks>SQL Type:System.Byte</remarks>
		private byte _StatusNo;
		
		[DisplayName("Status No")]
		[Category("Column")]
		public byte StatusNo
		{
			get
			{
				return _StatusNo;
			}
			set
			{
				_StatusNo = value;
			}
		}
		
		/// <remarks>SQL Type:System.Int64</remarks>
		private long _SymbolID = -1;
		
		[DisplayName("Symbol ID")]
		[Category("Foreign Key")]
		public long SymbolID
		{
			get
			{
				return _SymbolID;
			}
			set
			{
				_SymbolID = value;
			}
		}
		#endregion
		
		#region Related Objects
		/// <remarks>Represents the foreign key object</remarks>
		private tblSymbols _SymbolID_tblSymbols;
		
		[Description("Represents the foreign key object of the type SymbolID")]
		public tblSymbols m_SymbolID_tblSymbols
		{
			get
			{
				return _SymbolID_tblSymbols;
			}
			set
			{
				_SymbolID_tblSymbols = value;
			}
		}
		#endregion
		
		#region Collection Objects
		/// <remarks>Lock for accessing collection</remarks>
		private readonly object _tblSymbolADTextCollectionLock = new object();
		
		/// <remarks>Represents the foreign key object</remarks>
		private tblSymbolADTextCollection _tblSymbolADTextCollection;
		
		[Description("Represents the foreign key object of the type SymbolStatusID")]
		public tblSymbolADTextCollection m_tblSymbolADTextCollection
		{
			get
			{
              lock(_tblSymbolADTextCollectionLock)
              {
				if (_tblSymbolADTextCollection == null)
				{
					_tblSymbolADTextCollection =  new tblSymbolADTextCollection(this);
					_tblSymbolADTextCollection.Load();
				}
				return _tblSymbolADTextCollection;
              }
			}
			set
			{
				_tblSymbolADTextCollection = value;
			}
		}
		
		/// <remarks>Lock for accessing collection</remarks>
		private readonly object _tblSymbolBitmapCollectionLock = new object();
		
		/// <remarks>Represents the foreign key object</remarks>
		private tblSymbolBitmapCollection _tblSymbolBitmapCollection;
		
		[Description("Represents the foreign key object of the type SymbolStatusID")]
		public tblSymbolBitmapCollection m_tblSymbolBitmapCollection
		{
			get
			{
              lock(_tblSymbolBitmapCollectionLock)
              {
				if (_tblSymbolBitmapCollection == null)
				{
					_tblSymbolBitmapCollection =  new tblSymbolBitmapCollection(this);
					_tblSymbolBitmapCollection.Load();
				}
				return _tblSymbolBitmapCollection;
              }
			}
			set
			{
				_tblSymbolBitmapCollection = value;
			}
		}
		
		/// <remarks>Lock for accessing collection</remarks>
		private readonly object _tblSymbolLineCollectionLock = new object();
		
		/// <remarks>Represents the foreign key object</remarks>
		private tblSymbolLineCollection _tblSymbolLineCollection;
		
		[Description("Represents the foreign key object of the type SymbolStatusID")]
		public tblSymbolLineCollection m_tblSymbolLineCollection
		{
			get
			{
              lock(_tblSymbolLineCollectionLock)
              {
				if (_tblSymbolLineCollection == null)
				{
					_tblSymbolLineCollection =  new tblSymbolLineCollection(this);
					_tblSymbolLineCollection.Load();
				}
				return _tblSymbolLineCollection;
              }
			}
			set
			{
				_tblSymbolLineCollection = value;
			}
		}
		
		/// <remarks>Lock for accessing collection</remarks>
		private readonly object _tblSymbolPolylineCollectionLock = new object();
		
		/// <remarks>Represents the foreign key object</remarks>
		private tblSymbolPolylineCollection _tblSymbolPolylineCollection;
		
		[Description("Represents the foreign key object of the type SymbolStatusID")]
		public tblSymbolPolylineCollection m_tblSymbolPolylineCollection
		{
			get
			{
              lock(_tblSymbolPolylineCollectionLock)
              {
				if (_tblSymbolPolylineCollection == null)
				{
					_tblSymbolPolylineCollection =  new tblSymbolPolylineCollection(this);
					_tblSymbolPolylineCollection.Load();
				}
				return _tblSymbolPolylineCollection;
              }
			}
			set
			{
				_tblSymbolPolylineCollection = value;
			}
		}
		
		/// <remarks>Lock for accessing collection</remarks>
		private readonly object _tblSymbolRectCollectionLock = new object();
		
		/// <remarks>Represents the foreign key object</remarks>
		private tblSymbolRectCollection _tblSymbolRectCollection;
		
		[Description("Represents the foreign key object of the type SymbolStatusID")]
		public tblSymbolRectCollection m_tblSymbolRectCollection
		{
			get
			{
              lock(_tblSymbolRectCollectionLock)
              {
				if (_tblSymbolRectCollection == null)
				{
					_tblSymbolRectCollection =  new tblSymbolRectCollection(this);
					_tblSymbolRectCollection.Load();
				}
				return _tblSymbolRectCollection;
              }
			}
			set
			{
				_tblSymbolRectCollection = value;
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
				Com.CommandText = tblSymbolStatus.SQL_Delete;
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
				Com.CommandText = tblSymbolStatus.SQL_Select;
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
				Com.CommandText = tblSymbolStatus.SQL_Insert;
				Com.Parameters.AddRange(GetSqlParameters());
				SymbolStatusID = ((long)(Convert.ToInt64(Com.ExecuteScalar())));
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
				Com.CommandText = tblSymbolStatus.SQL_Update;
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
		
		public tblSymbolStatus()
		{
		}
		#endregion
		
		#region Private Methods
		private SQLiteParameter[] GetSqlParameters()
		{
			List<SQLiteParameter> SqlParmColl = new List<SQLiteParameter>();
			try
			{
				SqlParmColl.Add(CommonDB.AddSqlParm("@SymbolStatusID", SymbolStatusID, DbType.Int64));
				SqlParmColl.Add(CommonDB.AddSqlParm("@StatusNo", StatusNo, DbType.Byte));
				SqlParmColl.Add(CommonDB.AddSqlParm("@SymbolID", SymbolID, DbType.Int64));
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
				// if value from the recordset, to the SymbolStatusID _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("SymbolStatusID")) == false))
				{
					SymbolStatusID = ((long)(Convert.ChangeType(rs["SymbolStatusID"], typeof(long))));
				}
				// if value from the recordset, to the StatusNo _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("StatusNo")) == false))
				{
					StatusNo = ((byte)(Convert.ChangeType(rs["StatusNo"], typeof(byte))));
				}
				// if value from the recordset, to the SymbolID _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("SymbolID")) == false))
				{
					SymbolID = ((long)(Convert.ChangeType(rs["SymbolID"], typeof(long))));
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
				i = this.ColumnExistInHeader("StatusNo");
				if ((i >= 0))
				{
					StatusNo = ((byte)(Convert.ChangeType(_strs[i], typeof(byte))));
				}
				i = this.ColumnExistInHeader("SymbolID");
				if ((i >= 0))
				{
					SymbolID = ((long)(Convert.ChangeType(_strs[i], typeof(long))));
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
	
	public delegate void tblSymbolStatusChangedEventHandler(object sender, System.EventArgs e);
	
	public partial class tblSymbolStatusCollection : SQLiteTableCollection
	{
		
		/// <remarks>SQL Type:tblSymbolStatusChangedEventHandler</remarks>
		public event tblSymbolStatusChangedEventHandler tblSymbolStatusChanged;
		
		/// <remarks>Represents the foreign key object</remarks>
		private tblSymbols _SymbolID_tblSymbols;
		
		[Description("Represents the foreign key object of the type SymbolID")]
		public tblSymbols m_SymbolID_tblSymbols
		{
			get
			{
				return _SymbolID_tblSymbols;
			}
			set
			{
				_SymbolID_tblSymbols = value;
			}
		}
		
		[Description("Constructor")]
		public tblSymbolStatusCollection(tblSymbols _parent)
		{
			_SymbolID_tblSymbols = _parent;
		}
		
		[Description("Invoke the Changed event; called whenever list changes")]
		protected virtual void OntblSymbolStatusChanged(System.EventArgs e)
		{
			if (tblSymbolStatusChanged != null)
			{
				this.tblSymbolStatusChanged(this, e);
			}
		}
		
		[Description("Gets a  tblSymbolStatus from the collection.")]
		public tblSymbolStatus this[int index]
		{
			get
			{
				return ((tblSymbolStatus)(List[index]));
			}
			set
			{
				List[index] = value;
				this.OntblSymbolStatusChanged(EventArgs.Empty);
			}
		}
		
		[Description("Gets a  tblSymbolStatus from the collection.")]
		public tblSymbolStatus Get(int index)
		{
			return ((tblSymbolStatus)(List[index]));
		}
		
		[Description("Adds a new tblSymbolStatus to the collection.")]
		public void Add(tblSymbolStatus item)
		{
			List.Add(item);
			this.OntblSymbolStatusChanged(EventArgs.Empty);
		}
		
		[Description("Removes a tblSymbolStatus from the collection.")]
		public void Remove(tblSymbolStatus item)
		{
			List.Remove(item);
			this.OntblSymbolStatusChanged(EventArgs.Empty);
		}
		
		[Description("Inserts an tblSymbolStatus into the collection at the specified index.")]
		public void Insert(int index, tblSymbolStatus item)
		{
			List.Insert(index, item);
			this.OntblSymbolStatusChanged(EventArgs.Empty);
		}
		
		[Description("Returns the index value of the tblSymbolStatus class in the collection.")]
		public int IndexOf(tblSymbolStatus item)
		{
			return List.IndexOf(item);
		}
		
		[Description("Returns true if the tblSymbolStatus class is present in the collection.")]
		public bool Contains(tblSymbolStatus item)
		{
			return List.Contains(item);
		}
	}
}