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
using System.Drawing;


namespace DCS.DCSTables
{


    public partial class tblSymbolPolyline : SQLiteTable
	{
		
		#region Static SQL String Memebers
		/// <remarks>This _databasename represents the full INSERT INTO string for the table tblSymbolPolyline.</remarks>
		internal static string SQL_Insert = @"INSERT INTO [tblSymbolPolyline] ([SymbolStatusID], [oIndex], [BorderBlinking], [BorderColor1], [BorderColor2], [BorderWidth], [BorderDashStyle], [LinePaternScale], [Blinking], [FillColor11], [FillColor12], [FillColor21], [FillColor22], [FillType], [LinearGradientBrush], [HachStyle], [HachColor], [NoPoints], [Type]) VALUES(@SymbolStatusID, @oIndex, @BorderBlinking, @BorderColor1, @BorderColor2, @BorderWidth, @BorderDashStyle, @LinePaternScale, @Blinking, @FillColor11, @FillColor12, @FillColor21, @FillColor22, @FillType, @LinearGradientBrush, @HachStyle, @HachColor, @NoPoints, @Type) ; select last_insert_rowid(); ";
		
		/// <remarks>This _databasename represents the full UPDATE string for the table tblSymbolPolyline, with the WHERE clause.</remarks>
		internal static string SQL_Update = @"UPDATE [tblSymbolPolyline] SET [SymbolStatusID] = @SymbolStatusID, [oIndex] = @oIndex, [BorderBlinking] = @BorderBlinking, [BorderColor1] = @BorderColor1, [BorderColor2] = @BorderColor2, [BorderWidth] = @BorderWidth, [BorderDashStyle] = @BorderDashStyle, [LinePaternScale] = @LinePaternScale, [Blinking] = @Blinking, [FillColor11] = @FillColor11, [FillColor12] = @FillColor12, [FillColor21] = @FillColor21, [FillColor22] = @FillColor22, [FillType] = @FillType, [LinearGradientBrush] = @LinearGradientBrush, [HachStyle] = @HachStyle, [HachColor] = @HachColor, [NoPoints] = @NoPoints, [Type] = @Type WHERE [PolylineID]=@PolylineID ";
		
		/// <remarks>This _databasename represents the full SELECT string for the table tblSymbolPolyline, with the WHERE clause.</remarks>
		internal static string SQL_Select = @"SELECT [SymbolStatusID], [oIndex], [BorderBlinking], [BorderColor1], [BorderColor2], [BorderWidth], [BorderDashStyle], [LinePaternScale], [Blinking], [FillColor11], [FillColor12], [FillColor21], [FillColor22], [FillType], [LinearGradientBrush], [HachStyle], [HachColor], [NoPoints], [Type] FROM [tblSymbolPolyline] WHERE [PolylineID]=@PolylineID ";
		
		/// <remarks>This _databasename represents the DELETE string for the table tblSymbolPolyline, with the WHERE clause.</remarks>
		internal static string SQL_Delete = "DELETE FROM [tblSymbolPolyline] WHERE [PolylineID]=@PolylineID ";
		#endregion
		
		#region Tables Memebers
		/// <remarks>SQL Type:System.Int64</remarks>
		private long _PolylineID = -1;
		
		[DisplayName("Polyline ID")]
		[Category("Primary Key")]
		public long PolylineID
		{
			get
			{
				return _PolylineID;
			}
			set
			{
				_PolylineID = value;
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
		private bool _BorderBlinking;
		
		[DisplayName("Border Blinking")]
		[Category("Column")]
		public bool BorderBlinking
		{
			get
			{
				return _BorderBlinking;
			}
			set
			{
				_BorderBlinking = value;
			}
		}
		
		/// <remarks>SQL Type:System.Drawing.Color</remarks>
		private System.Drawing.Color _BorderColor1;
		
		[DisplayName("Border Color 1")]
		[Category("Column")]
		public System.Drawing.Color BorderColor1
		{
			get
			{
				return _BorderColor1;
			}
			set
			{
				_BorderColor1 = value;
			}
		}
		
		/// <remarks>SQL Type:System.Drawing.Color</remarks>
		private System.Drawing.Color _BorderColor2;
		
		[DisplayName("Border Color 2")]
		[Category("Column")]
		public System.Drawing.Color BorderColor2
		{
			get
			{
				return _BorderColor2;
			}
			set
			{
				_BorderColor2 = value;
			}
		}
		
		/// <remarks>SQL Type:System.Int32</remarks>
		private int _BorderWidth;
		
		[DisplayName("Border Width")]
		[Category("Column")]
		public int BorderWidth
		{
			get
			{
				return _BorderWidth;
			}
			set
			{
				_BorderWidth = value;
			}
		}
		
		/// <remarks>SQL Type:System.Int32</remarks>
		private int _BorderDashStyle;
		
		[DisplayName("Border Dash Style")]
		[Category("Column")]
		public int BorderDashStyle
		{
			get
			{
				return _BorderDashStyle;
			}
			set
			{
				_BorderDashStyle = value;
			}
		}
		
		/// <remarks>SQL Type:System.Int32</remarks>
		private int _LinePaternScale;
		
		[DisplayName("Line Patern Scale")]
		[Category("Column")]
		public int LinePaternScale
		{
			get
			{
				return _LinePaternScale;
			}
			set
			{
				_LinePaternScale = value;
			}
		}
		
		/// <remarks>SQL Type:System.Boolean</remarks>
		private bool _Blinking;
		
		[DisplayName("Blinking")]
		[Category("Column")]
		public bool Blinking
		{
			get
			{
				return _Blinking;
			}
			set
			{
				_Blinking = value;
			}
		}
		
		/// <remarks>SQL Type:System.Drawing.Color</remarks>
		private System.Drawing.Color _FillColor11;
		
		[DisplayName("Fill Color 11")]
		[Category("Column")]
		public System.Drawing.Color FillColor11
		{
			get
			{
				return _FillColor11;
			}
			set
			{
				_FillColor11 = value;
			}
		}
		
		/// <remarks>SQL Type:System.Drawing.Color</remarks>
		private System.Drawing.Color _FillColor12;
		
		[DisplayName("Fill Color 12")]
		[Category("Column")]
		public System.Drawing.Color FillColor12
		{
			get
			{
				return _FillColor12;
			}
			set
			{
				_FillColor12 = value;
			}
		}
		
		/// <remarks>SQL Type:System.Drawing.Color</remarks>
		private System.Drawing.Color _FillColor21;
		
		[DisplayName("Fill Color 21")]
		[Category("Column")]
		public System.Drawing.Color FillColor21
		{
			get
			{
				return _FillColor21;
			}
			set
			{
				_FillColor21 = value;
			}
		}
		
		/// <remarks>SQL Type:System.Drawing.Color</remarks>
		private System.Drawing.Color _FillColor22;
		
		[DisplayName("Fill Color 22")]
		[Category("Column")]
		public System.Drawing.Color FillColor22
		{
			get
			{
				return _FillColor22;
			}
			set
			{
				_FillColor22 = value;
			}
		}
		
		/// <remarks>SQL Type:System.Int32</remarks>
		private int _FillType;
		
		[DisplayName("Fill Type")]
		[Category("Column")]
		public int FillType
		{
			get
			{
				return _FillType;
			}
			set
			{
				_FillType = value;
			}
		}
		
		/// <remarks>SQL Type:System.Int32</remarks>
		private int _LinearGradientBrush;
		
		[DisplayName("Linear Gradient Brush")]
		[Category("Column")]
		public int LinearGradientBrush
		{
			get
			{
				return _LinearGradientBrush;
			}
			set
			{
				_LinearGradientBrush = value;
			}
		}
		
		/// <remarks>SQL Type:System.Int32</remarks>
		private int _HachStyle;
		
		[DisplayName("Hach Style")]
		[Category("Column")]
		public int HachStyle
		{
			get
			{
				return _HachStyle;
			}
			set
			{
				_HachStyle = value;
			}
		}
		
		/// <remarks>SQL Type:System.Drawing.Color</remarks>
		private System.Drawing.Color _HachColor;
		
		[DisplayName("Hach Color")]
		[Category("Column")]
		public System.Drawing.Color HachColor
		{
			get
			{
				return _HachColor;
			}
			set
			{
				_HachColor = value;
			}
		}
		
		/// <remarks>SQL Type:System.Int32</remarks>
		private int _NoPoints;
		
		[DisplayName("No Points")]
		[Category("Column")]
		public int NoPoints
		{
			get
			{
				return _NoPoints;
			}
			set
			{
				_NoPoints = value;
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
		
		#region Collection Objects
		/// <remarks>Lock for accessing collection</remarks>
		private readonly object _tblSymbolPointsPolylineCollectionLock = new object();
		
		/// <remarks>Represents the foreign key object</remarks>
		private tblSymbolPointsPolylineCollection _tblSymbolPointsPolylineCollection;
		
		[Description("Represents the foreign key object of the type PolylineID")]
		public tblSymbolPointsPolylineCollection m_tblSymbolPointsPolylineCollection
		{
			get
			{
              lock(_tblSymbolPointsPolylineCollectionLock)
              {
				if (_tblSymbolPointsPolylineCollection == null)
				{
					_tblSymbolPointsPolylineCollection =  new tblSymbolPointsPolylineCollection(this);
					_tblSymbolPointsPolylineCollection.Load();
				}
				return _tblSymbolPointsPolylineCollection;
              }
			}
			set
			{
				_tblSymbolPointsPolylineCollection = value;
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
				Com.CommandText = tblSymbolPolyline.SQL_Delete;
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
				Com.CommandText = tblSymbolPolyline.SQL_Select;
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
				Com.CommandText = tblSymbolPolyline.SQL_Insert;
				Com.Parameters.AddRange(GetSqlParameters());
				PolylineID = ((long)(Convert.ToInt64(Com.ExecuteScalar())));
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
				Com.CommandText = tblSymbolPolyline.SQL_Update;
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
		
		public tblSymbolPolyline()
		{
		}
		#endregion
		
		#region Private Methods
		private SQLiteParameter[] GetSqlParameters()
		{
			List<SQLiteParameter> SqlParmColl = new List<SQLiteParameter>();
			try
			{
				SqlParmColl.Add(CommonDB.AddSqlParm("@PolylineID", PolylineID, DbType.Int64));
				SqlParmColl.Add(CommonDB.AddSqlParm("@SymbolStatusID", SymbolStatusID, DbType.Int64));
				SqlParmColl.Add(CommonDB.AddSqlParm("@oIndex", oIndex, DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@BorderBlinking", BorderBlinking, DbType.Boolean));
				SqlParmColl.Add(CommonDB.AddSqlParm("@BorderColor1", BorderColor1.ToArgb(), DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@BorderColor2", BorderColor2.ToArgb(), DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@BorderWidth", BorderWidth, DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@BorderDashStyle", BorderDashStyle, DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@LinePaternScale", LinePaternScale, DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@Blinking", Blinking, DbType.Boolean));
				SqlParmColl.Add(CommonDB.AddSqlParm("@FillColor11", FillColor11.ToArgb(), DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@FillColor12", FillColor12.ToArgb(), DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@FillColor21", FillColor21.ToArgb(), DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@FillColor22", FillColor22.ToArgb(), DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@FillType", FillType, DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@LinearGradientBrush", LinearGradientBrush, DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@HachStyle", HachStyle, DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@HachColor", HachColor.ToArgb(), DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@NoPoints", NoPoints, DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@Type", Type, DbType.Int32));
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
				// if value from the recordset, to the PolylineID _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("PolylineID")) == false))
				{
					PolylineID = ((long)(Convert.ChangeType(rs["PolylineID"], typeof(long))));
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
				// if value from the recordset, to the BorderBlinking _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("BorderBlinking")) == false))
				{
					BorderBlinking = ((bool)(Convert.ChangeType(rs["BorderBlinking"], typeof(bool))));
				}
				// if value from the recordset, to the BorderColor1 _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("BorderColor1")) == false))
				{
					BorderColor1 = Color.FromArgb(((int)(Convert.ChangeType(rs["BorderColor1"], typeof(int)))));
				}
				// if value from the recordset, to the BorderColor2 _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("BorderColor2")) == false))
				{
					BorderColor2 = Color.FromArgb(((int)(Convert.ChangeType(rs["BorderColor2"], typeof(int)))));
				}
				// if value from the recordset, to the BorderWidth _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("BorderWidth")) == false))
				{
					BorderWidth = ((int)(Convert.ChangeType(rs["BorderWidth"], typeof(int))));
				}
				// if value from the recordset, to the BorderDashStyle _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("BorderDashStyle")) == false))
				{
					BorderDashStyle = ((int)(Convert.ChangeType(rs["BorderDashStyle"], typeof(int))));
				}
				// if value from the recordset, to the LinePaternScale _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("LinePaternScale")) == false))
				{
					LinePaternScale = ((int)(Convert.ChangeType(rs["LinePaternScale"], typeof(int))));
				}
				// if value from the recordset, to the Blinking _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("Blinking")) == false))
				{
					Blinking = ((bool)(Convert.ChangeType(rs["Blinking"], typeof(bool))));
				}
				// if value from the recordset, to the FillColor11 _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("FillColor11")) == false))
				{
					FillColor11 = Color.FromArgb(((int)(Convert.ChangeType(rs["FillColor11"], typeof(int)))));
				}
				// if value from the recordset, to the FillColor12 _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("FillColor12")) == false))
				{
					FillColor12 = Color.FromArgb(((int)(Convert.ChangeType(rs["FillColor12"], typeof(int)))));
				}
				// if value from the recordset, to the FillColor21 _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("FillColor21")) == false))
				{
					FillColor21 = Color.FromArgb(((int)(Convert.ChangeType(rs["FillColor21"], typeof(int)))));
				}
				// if value from the recordset, to the FillColor22 _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("FillColor22")) == false))
				{
					FillColor22 = Color.FromArgb(((int)(Convert.ChangeType(rs["FillColor22"], typeof(int)))));
				}
				// if value from the recordset, to the FillType _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("FillType")) == false))
				{
					FillType = ((int)(Convert.ChangeType(rs["FillType"], typeof(int))));
				}
				// if value from the recordset, to the LinearGradientBrush _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("LinearGradientBrush")) == false))
				{
					LinearGradientBrush = ((int)(Convert.ChangeType(rs["LinearGradientBrush"], typeof(int))));
				}
				// if value from the recordset, to the HachStyle _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("HachStyle")) == false))
				{
					HachStyle = ((int)(Convert.ChangeType(rs["HachStyle"], typeof(int))));
				}
				// if value from the recordset, to the HachColor _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("HachColor")) == false))
				{
					HachColor = Color.FromArgb(((int)(Convert.ChangeType(rs["HachColor"], typeof(int)))));
				}
				// if value from the recordset, to the NoPoints _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("NoPoints")) == false))
				{
					NoPoints = ((int)(Convert.ChangeType(rs["NoPoints"], typeof(int))));
				}
				// if value from the recordset, to the Type _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("Type")) == false))
				{
					Type = ((int)(Convert.ChangeType(rs["Type"], typeof(int))));
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
				i = this.ColumnExistInHeader("BorderBlinking");
				if ((i >= 0))
				{
					BorderBlinking = ((bool)(Convert.ChangeType(_strs[i], typeof(bool))));
				}
				i = this.ColumnExistInHeader("BorderColor1");
				if ((i >= 0))
				{
					BorderColor1 = Color.FromArgb(((int)(Convert.ChangeType(_strs[i], typeof(int)))));
				}
				i = this.ColumnExistInHeader("BorderColor2");
				if ((i >= 0))
				{
					BorderColor2 = Color.FromArgb(((int)(Convert.ChangeType(_strs[i], typeof(int)))));
				}
				i = this.ColumnExistInHeader("BorderWidth");
				if ((i >= 0))
				{
					BorderWidth = ((int)(Convert.ChangeType(_strs[i], typeof(int))));
				}
				i = this.ColumnExistInHeader("BorderDashStyle");
				if ((i >= 0))
				{
					BorderDashStyle = ((int)(Convert.ChangeType(_strs[i], typeof(int))));
				}
				i = this.ColumnExistInHeader("LinePaternScale");
				if ((i >= 0))
				{
					LinePaternScale = ((int)(Convert.ChangeType(_strs[i], typeof(int))));
				}
				i = this.ColumnExistInHeader("Blinking");
				if ((i >= 0))
				{
					Blinking = ((bool)(Convert.ChangeType(_strs[i], typeof(bool))));
				}
				i = this.ColumnExistInHeader("FillColor11");
				if ((i >= 0))
				{
					FillColor11 = Color.FromArgb(((int)(Convert.ChangeType(_strs[i], typeof(int)))));
				}
				i = this.ColumnExistInHeader("FillColor12");
				if ((i >= 0))
				{
					FillColor12 = Color.FromArgb(((int)(Convert.ChangeType(_strs[i], typeof(int)))));
				}
				i = this.ColumnExistInHeader("FillColor21");
				if ((i >= 0))
				{
					FillColor21 = Color.FromArgb(((int)(Convert.ChangeType(_strs[i], typeof(int)))));
				}
				i = this.ColumnExistInHeader("FillColor22");
				if ((i >= 0))
				{
					FillColor22 = Color.FromArgb(((int)(Convert.ChangeType(_strs[i], typeof(int)))));
				}
				i = this.ColumnExistInHeader("FillType");
				if ((i >= 0))
				{
					FillType = ((int)(Convert.ChangeType(_strs[i], typeof(int))));
				}
				i = this.ColumnExistInHeader("LinearGradientBrush");
				if ((i >= 0))
				{
					LinearGradientBrush = ((int)(Convert.ChangeType(_strs[i], typeof(int))));
				}
				i = this.ColumnExistInHeader("HachStyle");
				if ((i >= 0))
				{
					HachStyle = ((int)(Convert.ChangeType(_strs[i], typeof(int))));
				}
				i = this.ColumnExistInHeader("HachColor");
				if ((i >= 0))
				{
					HachColor = Color.FromArgb(((int)(Convert.ChangeType(_strs[i], typeof(int)))));
				}
				i = this.ColumnExistInHeader("NoPoints");
				if ((i >= 0))
				{
					NoPoints = ((int)(Convert.ChangeType(_strs[i], typeof(int))));
				}
				i = this.ColumnExistInHeader("Type");
				if ((i >= 0))
				{
					Type = ((int)(Convert.ChangeType(_strs[i], typeof(int))));
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
	
	public delegate void tblSymbolPolylineChangedEventHandler(object sender, System.EventArgs e);
	
	public partial class tblSymbolPolylineCollection : SQLiteTableCollection
	{
		
		/// <remarks>SQL Type:tblSymbolPolylineChangedEventHandler</remarks>
		public event tblSymbolPolylineChangedEventHandler tblSymbolPolylineChanged;
		
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
		public tblSymbolPolylineCollection(tblSymbolStatus _parent)
		{
			_SymbolStatusID_tblSymbolStatus = _parent;
		}
		
		[Description("Invoke the Changed event; called whenever list changes")]
		protected virtual void OntblSymbolPolylineChanged(System.EventArgs e)
		{
			if (tblSymbolPolylineChanged != null)
			{
				this.tblSymbolPolylineChanged(this, e);
			}
		}
		
		[Description("Gets a  tblSymbolPolyline from the collection.")]
		public tblSymbolPolyline this[int index]
		{
			get
			{
				return ((tblSymbolPolyline)(List[index]));
			}
			set
			{
				List[index] = value;
				this.OntblSymbolPolylineChanged(EventArgs.Empty);
			}
		}
		
		[Description("Gets a  tblSymbolPolyline from the collection.")]
		public tblSymbolPolyline Get(int index)
		{
			return ((tblSymbolPolyline)(List[index]));
		}
		
		[Description("Adds a new tblSymbolPolyline to the collection.")]
		public void Add(tblSymbolPolyline item)
		{
			List.Add(item);
			this.OntblSymbolPolylineChanged(EventArgs.Empty);
		}
		
		[Description("Removes a tblSymbolPolyline from the collection.")]
		public void Remove(tblSymbolPolyline item)
		{
			List.Remove(item);
			this.OntblSymbolPolylineChanged(EventArgs.Empty);
		}
		
		[Description("Inserts an tblSymbolPolyline into the collection at the specified index.")]
		public void Insert(int index, tblSymbolPolyline item)
		{
			List.Insert(index, item);
			this.OntblSymbolPolylineChanged(EventArgs.Empty);
		}
		
		[Description("Returns the index value of the tblSymbolPolyline class in the collection.")]
		public int IndexOf(tblSymbolPolyline item)
		{
			return List.IndexOf(item);
		}
		
		[Description("Returns true if the tblSymbolPolyline class is present in the collection.")]
		public bool Contains(tblSymbolPolyline item)
		{
			return List.Contains(item);
		}
	}
}
