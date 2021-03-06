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


    public partial class tblSymbolBitmap : SQLiteTable
	{
		
		#region Static SQL String Memebers
		/// <remarks>This _databasename represents the full INSERT INTO string for the table tblSymbolBitmap.</remarks>
		internal static string SQL_Insert = @"INSERT INTO [tblSymbolBitmap] ([BitmapName], [SymbolStatusID], [oIndex], [bBrush], [bPen], [LogpenLopnColor], [LogpenLopnStyle], [LogpenLopnWidthX], [LogpenLopnWidthY], [LogbrushLbColor], [LogbrushLbHatch], [LogbrushLbStyle], [left], [top], [right], [bottom], [Transparent]) VALUES(@BitmapName, @SymbolStatusID, @oIndex, @bBrush, @bPen, @LogpenLopnColor, @LogpenLopnStyle, @LogpenLopnWidthX, @LogpenLopnWidthY, @LogbrushLbColor, @LogbrushLbHatch, @LogbrushLbStyle, @left, @top, @right, @bottom, @Transparent) ; select last_insert_rowid(); ";
		
		/// <remarks>This _databasename represents the full UPDATE string for the table tblSymbolBitmap, with the WHERE clause.</remarks>
		internal static string SQL_Update = @"UPDATE [tblSymbolBitmap] SET [BitmapName] = @BitmapName, [SymbolStatusID] = @SymbolStatusID, [oIndex] = @oIndex, [bBrush] = @bBrush, [bPen] = @bPen, [LogpenLopnColor] = @LogpenLopnColor, [LogpenLopnStyle] = @LogpenLopnStyle, [LogpenLopnWidthX] = @LogpenLopnWidthX, [LogpenLopnWidthY] = @LogpenLopnWidthY, [LogbrushLbColor] = @LogbrushLbColor, [LogbrushLbHatch] = @LogbrushLbHatch, [LogbrushLbStyle] = @LogbrushLbStyle, [left] = @left, [top] = @top, [right] = @right, [bottom] = @bottom, [Transparent] = @Transparent WHERE [BitmapID]=@BitmapID ";
		
		/// <remarks>This _databasename represents the full SELECT string for the table tblSymbolBitmap, with the WHERE clause.</remarks>
		internal static string SQL_Select = @"SELECT [BitmapName], [SymbolStatusID], [oIndex], [bBrush], [bPen], [LogpenLopnColor], [LogpenLopnStyle], [LogpenLopnWidthX], [LogpenLopnWidthY], [LogbrushLbColor], [LogbrushLbHatch], [LogbrushLbStyle], [left], [top], [right], [bottom], [Transparent] FROM [tblSymbolBitmap] WHERE [BitmapID]=@BitmapID ";
		
		/// <remarks>This _databasename represents the DELETE string for the table tblSymbolBitmap, with the WHERE clause.</remarks>
		internal static string SQL_Delete = "DELETE FROM [tblSymbolBitmap] WHERE [BitmapID]=@BitmapID ";
		#endregion
		
		#region Tables Memebers
		/// <remarks>SQL Type:System.Int64</remarks>
		private long _BitmapID = -1;
		
		[DisplayName("Bitmap ID")]
		[Category("Primary Key")]
		public long BitmapID
		{
			get
			{
				return _BitmapID;
			}
			set
			{
				_BitmapID = value;
			}
		}
		
		/// <remarks>SQL Type:System.String</remarks>
		private string _BitmapName = "";
		
		[DisplayName("Bitmap Name")]
		[Category("Column")]
		public string BitmapName
		{
			get
			{
				return _BitmapName;
			}
			set
			{
				_BitmapName = value;
			}
		}
		
		/// <remarks>SQL Type:System.Int64</remarks>
		private long _SymbolStatusID = -1;
		
		[DisplayName("Symbol Status ID")]
		[Category("Foreign Key")]
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
		
		/// <remarks>SQL Type:System.Boolean</remarks>
		private bool _bBrush;
		
		[DisplayName("b Brush")]
		[Category("Column")]
		public bool bBrush
		{
			get
			{
				return _bBrush;
			}
			set
			{
				_bBrush = value;
			}
		}
		
		/// <remarks>SQL Type:System.Boolean</remarks>
		private bool _bPen;
		
		[DisplayName("b Pen")]
		[Category("Column")]
		public bool bPen
		{
			get
			{
				return _bPen;
			}
			set
			{
				_bPen = value;
			}
		}
		
		/// <remarks>SQL Type:System.Int32</remarks>
		private int _LogpenLopnColor;
		
		[DisplayName("Logpen Lopn Color")]
		[Category("Column")]
		public int LogpenLopnColor
		{
			get
			{
				return _LogpenLopnColor;
			}
			set
			{
				_LogpenLopnColor = value;
			}
		}
		
		/// <remarks>SQL Type:System.Int32</remarks>
		private int _LogpenLopnStyle;
		
		[DisplayName("Logpen Lopn Style")]
		[Category("Column")]
		public int LogpenLopnStyle
		{
			get
			{
				return _LogpenLopnStyle;
			}
			set
			{
				_LogpenLopnStyle = value;
			}
		}
		
		/// <remarks>SQL Type:System.Int32</remarks>
		private int _LogpenLopnWidthX;
		
		[DisplayName("Logpen Lopn Width X")]
		[Category("Column")]
		public int LogpenLopnWidthX
		{
			get
			{
				return _LogpenLopnWidthX;
			}
			set
			{
				_LogpenLopnWidthX = value;
			}
		}
		
		/// <remarks>SQL Type:System.Int32</remarks>
		private int _LogpenLopnWidthY;
		
		[DisplayName("Logpen Lopn Width Y")]
		[Category("Column")]
		public int LogpenLopnWidthY
		{
			get
			{
				return _LogpenLopnWidthY;
			}
			set
			{
				_LogpenLopnWidthY = value;
			}
		}
		
		/// <remarks>SQL Type:System.Int32</remarks>
		private int _LogbrushLbColor;
		
		[DisplayName("Logbrush Lb Color")]
		[Category("Column")]
		public int LogbrushLbColor
		{
			get
			{
				return _LogbrushLbColor;
			}
			set
			{
				_LogbrushLbColor = value;
			}
		}
		
		/// <remarks>SQL Type:System.Int32</remarks>
		private int _LogbrushLbHatch;
		
		[DisplayName("Logbrush Lb Hatch")]
		[Category("Column")]
		public int LogbrushLbHatch
		{
			get
			{
				return _LogbrushLbHatch;
			}
			set
			{
				_LogbrushLbHatch = value;
			}
		}
		
		/// <remarks>SQL Type:System.Int32</remarks>
		private int _LogbrushLbStyle;
		
		[DisplayName("Logbrush Lb Style")]
		[Category("Column")]
		public int LogbrushLbStyle
		{
			get
			{
				return _LogbrushLbStyle;
			}
			set
			{
				_LogbrushLbStyle = value;
			}
		}
		
		/// <remarks>SQL Type:System.Int32</remarks>
		private int _left;
		
		[DisplayName("left")]
		[Category("Column")]
		public int left
		{
			get
			{
				return _left;
			}
			set
			{
				_left = value;
			}
		}
		
		/// <remarks>SQL Type:System.Int32</remarks>
		private int _top;
		
		[DisplayName("top")]
		[Category("Column")]
		public int top
		{
			get
			{
				return _top;
			}
			set
			{
				_top = value;
			}
		}
		
		/// <remarks>SQL Type:System.Int32</remarks>
		private int _right;
		
		[DisplayName("right")]
		[Category("Column")]
		public int right
		{
			get
			{
				return _right;
			}
			set
			{
				_right = value;
			}
		}
		
		/// <remarks>SQL Type:System.Int32</remarks>
		private int _bottom;
		
		[DisplayName("bottom")]
		[Category("Column")]
		public int bottom
		{
			get
			{
				return _bottom;
			}
			set
			{
				_bottom = value;
			}
		}
		
		/// <remarks>SQL Type:System.Boolean</remarks>
		private bool _Transparent;
		
		[DisplayName("Transparent")]
		[Category("Column")]
		public bool Transparent
		{
			get
			{
				return _Transparent;
			}
			set
			{
				_Transparent = value;
			}
		}
		#endregion
		
		#region Related Objects
		/// <remarks>Represents the foreign key object</remarks>
		private tblSymbolStatus _SymbolStatusID_tblSymbolStatus;
		
		[Description("Represents the foreign key object of the type SymbolStatusID")]
		public tblSymbolStatus m_SymbolStatusID_tblSymbolStatus
		{
			get
			{
				return _SymbolStatusID_tblSymbolStatus;
			}
			set
			{
				_SymbolStatusID_tblSymbolStatus = value;
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
				Com.CommandText = tblSymbolBitmap.SQL_Delete;
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
				Com.CommandText = tblSymbolBitmap.SQL_Select;
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
				Com.CommandText = tblSymbolBitmap.SQL_Insert;
				Com.Parameters.AddRange(GetSqlParameters());
				BitmapID = ((long)(Convert.ToInt64(Com.ExecuteScalar())));
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
				Com.CommandText = tblSymbolBitmap.SQL_Update;
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
		
		public tblSymbolBitmap()
		{
		}
		#endregion
		
		#region Private Methods
		private SQLiteParameter[] GetSqlParameters()
		{
			List<SQLiteParameter> SqlParmColl = new List<SQLiteParameter>();
			try
			{
				SqlParmColl.Add(CommonDB.AddSqlParm("@BitmapID", BitmapID, DbType.Int64));
				SqlParmColl.Add(CommonDB.AddSqlParm("@BitmapName", BitmapName, DbType.String));
				SqlParmColl.Add(CommonDB.AddSqlParm("@SymbolStatusID", SymbolStatusID, DbType.Int64));
				SqlParmColl.Add(CommonDB.AddSqlParm("@oIndex", oIndex, DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@bBrush", bBrush, DbType.Boolean));
				SqlParmColl.Add(CommonDB.AddSqlParm("@bPen", bPen, DbType.Boolean));
				SqlParmColl.Add(CommonDB.AddSqlParm("@LogpenLopnColor", LogpenLopnColor, DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@LogpenLopnStyle", LogpenLopnStyle, DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@LogpenLopnWidthX", LogpenLopnWidthX, DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@LogpenLopnWidthY", LogpenLopnWidthY, DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@LogbrushLbColor", LogbrushLbColor, DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@LogbrushLbHatch", LogbrushLbHatch, DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@LogbrushLbStyle", LogbrushLbStyle, DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@left", left, DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@top", top, DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@right", right, DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@bottom", bottom, DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@Transparent", Transparent, DbType.Boolean));
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
				// if value from the recordset, to the BitmapID _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("BitmapID")) == false))
				{
					BitmapID = ((long)(Convert.ChangeType(rs["BitmapID"], typeof(long))));
				}
				// if value from the recordset, to the BitmapName _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("BitmapName")) == false))
				{
					BitmapName = ((string)(Convert.ChangeType(rs["BitmapName"], typeof(string))));
				}
				// if value from the recordset, to the SymbolStatusID _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("SymbolStatusID")) == false))
				{
					SymbolStatusID = ((long)(Convert.ChangeType(rs["SymbolStatusID"], typeof(long))));
				}
				// if value from the recordset, to the oIndex _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("oIndex")) == false))
				{
					oIndex = ((int)(Convert.ChangeType(rs["oIndex"], typeof(int))));
				}
				// if value from the recordset, to the bBrush _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("bBrush")) == false))
				{
					bBrush = ((bool)(Convert.ChangeType(rs["bBrush"], typeof(bool))));
				}
				// if value from the recordset, to the bPen _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("bPen")) == false))
				{
					bPen = ((bool)(Convert.ChangeType(rs["bPen"], typeof(bool))));
				}
				// if value from the recordset, to the LogpenLopnColor _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("LogpenLopnColor")) == false))
				{
					LogpenLopnColor = ((int)(Convert.ChangeType(rs["LogpenLopnColor"], typeof(int))));
				}
				// if value from the recordset, to the LogpenLopnStyle _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("LogpenLopnStyle")) == false))
				{
					LogpenLopnStyle = ((int)(Convert.ChangeType(rs["LogpenLopnStyle"], typeof(int))));
				}
				// if value from the recordset, to the LogpenLopnWidthX _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("LogpenLopnWidthX")) == false))
				{
					LogpenLopnWidthX = ((int)(Convert.ChangeType(rs["LogpenLopnWidthX"], typeof(int))));
				}
				// if value from the recordset, to the LogpenLopnWidthY _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("LogpenLopnWidthY")) == false))
				{
					LogpenLopnWidthY = ((int)(Convert.ChangeType(rs["LogpenLopnWidthY"], typeof(int))));
				}
				// if value from the recordset, to the LogbrushLbColor _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("LogbrushLbColor")) == false))
				{
					LogbrushLbColor = ((int)(Convert.ChangeType(rs["LogbrushLbColor"], typeof(int))));
				}
				// if value from the recordset, to the LogbrushLbHatch _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("LogbrushLbHatch")) == false))
				{
					LogbrushLbHatch = ((int)(Convert.ChangeType(rs["LogbrushLbHatch"], typeof(int))));
				}
				// if value from the recordset, to the LogbrushLbStyle _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("LogbrushLbStyle")) == false))
				{
					LogbrushLbStyle = ((int)(Convert.ChangeType(rs["LogbrushLbStyle"], typeof(int))));
				}
				// if value from the recordset, to the left _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("left")) == false))
				{
					left = ((int)(Convert.ChangeType(rs["left"], typeof(int))));
				}
				// if value from the recordset, to the top _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("top")) == false))
				{
					top = ((int)(Convert.ChangeType(rs["top"], typeof(int))));
				}
				// if value from the recordset, to the right _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("right")) == false))
				{
					right = ((int)(Convert.ChangeType(rs["right"], typeof(int))));
				}
				// if value from the recordset, to the bottom _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("bottom")) == false))
				{
					bottom = ((int)(Convert.ChangeType(rs["bottom"], typeof(int))));
				}
				// if value from the recordset, to the Transparent _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("Transparent")) == false))
				{
					Transparent = ((bool)(Convert.ChangeType(rs["Transparent"], typeof(bool))));
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
				i = this.ColumnExistInHeader("BitmapName");
				if ((i >= 0))
				{
					BitmapName = ((string)(Convert.ChangeType(_strs[i], typeof(string))));
				}
				i = this.ColumnExistInHeader("SymbolStatusID");
				if ((i >= 0))
				{
					SymbolStatusID = ((long)(Convert.ChangeType(_strs[i], typeof(long))));
				}
				i = this.ColumnExistInHeader("oIndex");
				if ((i >= 0))
				{
					oIndex = ((int)(Convert.ChangeType(_strs[i], typeof(int))));
				}
				i = this.ColumnExistInHeader("bBrush");
				if ((i >= 0))
				{
					bBrush = ((bool)(Convert.ChangeType(_strs[i], typeof(bool))));
				}
				i = this.ColumnExistInHeader("bPen");
				if ((i >= 0))
				{
					bPen = ((bool)(Convert.ChangeType(_strs[i], typeof(bool))));
				}
				i = this.ColumnExistInHeader("LogpenLopnColor");
				if ((i >= 0))
				{
					LogpenLopnColor = ((int)(Convert.ChangeType(_strs[i], typeof(int))));
				}
				i = this.ColumnExistInHeader("LogpenLopnStyle");
				if ((i >= 0))
				{
					LogpenLopnStyle = ((int)(Convert.ChangeType(_strs[i], typeof(int))));
				}
				i = this.ColumnExistInHeader("LogpenLopnWidthX");
				if ((i >= 0))
				{
					LogpenLopnWidthX = ((int)(Convert.ChangeType(_strs[i], typeof(int))));
				}
				i = this.ColumnExistInHeader("LogpenLopnWidthY");
				if ((i >= 0))
				{
					LogpenLopnWidthY = ((int)(Convert.ChangeType(_strs[i], typeof(int))));
				}
				i = this.ColumnExistInHeader("LogbrushLbColor");
				if ((i >= 0))
				{
					LogbrushLbColor = ((int)(Convert.ChangeType(_strs[i], typeof(int))));
				}
				i = this.ColumnExistInHeader("LogbrushLbHatch");
				if ((i >= 0))
				{
					LogbrushLbHatch = ((int)(Convert.ChangeType(_strs[i], typeof(int))));
				}
				i = this.ColumnExistInHeader("LogbrushLbStyle");
				if ((i >= 0))
				{
					LogbrushLbStyle = ((int)(Convert.ChangeType(_strs[i], typeof(int))));
				}
				i = this.ColumnExistInHeader("left");
				if ((i >= 0))
				{
					left = ((int)(Convert.ChangeType(_strs[i], typeof(int))));
				}
				i = this.ColumnExistInHeader("top");
				if ((i >= 0))
				{
					top = ((int)(Convert.ChangeType(_strs[i], typeof(int))));
				}
				i = this.ColumnExistInHeader("right");
				if ((i >= 0))
				{
					right = ((int)(Convert.ChangeType(_strs[i], typeof(int))));
				}
				i = this.ColumnExistInHeader("bottom");
				if ((i >= 0))
				{
					bottom = ((int)(Convert.ChangeType(_strs[i], typeof(int))));
				}
				i = this.ColumnExistInHeader("Transparent");
				if ((i >= 0))
				{
					Transparent = ((bool)(Convert.ChangeType(_strs[i], typeof(bool))));
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
	
	public delegate void tblSymbolBitmapChangedEventHandler(object sender, System.EventArgs e);
	
	public partial class tblSymbolBitmapCollection : SQLiteTableCollection
	{
		
		/// <remarks>SQL Type:tblSymbolBitmapChangedEventHandler</remarks>
		public event tblSymbolBitmapChangedEventHandler tblSymbolBitmapChanged;
		
		/// <remarks>Represents the foreign key object</remarks>
		private tblSymbolStatus _SymbolStatusID_tblSymbolStatus;
		
		[Description("Represents the foreign key object of the type SymbolStatusID")]
		public tblSymbolStatus m_SymbolStatusID_tblSymbolStatus
		{
			get
			{
				return _SymbolStatusID_tblSymbolStatus;
			}
			set
			{
				_SymbolStatusID_tblSymbolStatus = value;
			}
		}
		
		[Description("Constructor")]
		public tblSymbolBitmapCollection(tblSymbolStatus _parent)
		{
			_SymbolStatusID_tblSymbolStatus = _parent;
		}
		
		[Description("Invoke the Changed event; called whenever list changes")]
		protected virtual void OntblSymbolBitmapChanged(System.EventArgs e)
		{
			if (tblSymbolBitmapChanged != null)
			{
				this.tblSymbolBitmapChanged(this, e);
			}
		}
		
		[Description("Gets a  tblSymbolBitmap from the collection.")]
		public tblSymbolBitmap this[int index]
		{
			get
			{
				return ((tblSymbolBitmap)(List[index]));
			}
			set
			{
				List[index] = value;
				this.OntblSymbolBitmapChanged(EventArgs.Empty);
			}
		}
		
		[Description("Gets a  tblSymbolBitmap from the collection.")]
		public tblSymbolBitmap Get(int index)
		{
			return ((tblSymbolBitmap)(List[index]));
		}
		
		[Description("Adds a new tblSymbolBitmap to the collection.")]
		public void Add(tblSymbolBitmap item)
		{
			List.Add(item);
			this.OntblSymbolBitmapChanged(EventArgs.Empty);
		}
		
		[Description("Removes a tblSymbolBitmap from the collection.")]
		public void Remove(tblSymbolBitmap item)
		{
			List.Remove(item);
			this.OntblSymbolBitmapChanged(EventArgs.Empty);
		}
		
		[Description("Inserts an tblSymbolBitmap into the collection at the specified index.")]
		public void Insert(int index, tblSymbolBitmap item)
		{
			List.Insert(index, item);
			this.OntblSymbolBitmapChanged(EventArgs.Empty);
		}
		
		[Description("Returns the index value of the tblSymbolBitmap class in the collection.")]
		public int IndexOf(tblSymbolBitmap item)
		{
			return List.IndexOf(item);
		}
		
		[Description("Returns true if the tblSymbolBitmap class is present in the collection.")]
		public bool Contains(tblSymbolBitmap item)
		{
			return List.Contains(item);
		}
	}
}
