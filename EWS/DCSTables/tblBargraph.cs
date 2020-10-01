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


    public partial class tblBargraph : SQLiteTable
	{
		
		#region Static SQL String Memebers
		/// <remarks>This _databasename represents the full INSERT INTO string for the table tblBargraph.</remarks>
		internal static string SQL_Insert = @"INSERT INTO [tblBargraph] ([DisplayID], [oIndex], [DlgType], [DlgIndex], [Left], [Right], [Top], [Bottom], [VertHorz], [RoolerFormat], [Direction], [BarColor], [BarColorID], [BarColorDefult], [BackColor], [BorderColor], [Index], [Font], [FontColor], [LastRev], [LockPosition], [LockEdit], [Layer], [CompiledExp], [validexpression]) VALUES(@DisplayID, @oIndex, @DlgType, @DlgIndex, @Left, @Right, @Top, @Bottom, @VertHorz, @RoolerFormat, @Direction, @BarColor, @BarColorID, @BarColorDefult, @BackColor, @BorderColor, @Index, @Font, @FontColor, @LastRev, @LockPosition, @LockEdit, @Layer, @CompiledExp, @validexpression) ; select last_insert_rowid(); ";
		
		/// <remarks>This _databasename represents the full UPDATE string for the table tblBargraph, with the WHERE clause.</remarks>
		internal static string SQL_Update = @"UPDATE [tblBargraph] SET [DisplayID] = @DisplayID, [oIndex] = @oIndex, [DlgType] = @DlgType, [DlgIndex] = @DlgIndex, [Left] = @Left, [Right] = @Right, [Top] = @Top, [Bottom] = @Bottom, [VertHorz] = @VertHorz, [RoolerFormat] = @RoolerFormat, [Direction] = @Direction, [BarColor] = @BarColor, [BarColorID] = @BarColorID, [BarColorDefult] = @BarColorDefult, [BackColor] = @BackColor, [BorderColor] = @BorderColor, [Index] = @Index, [Font] = @Font, [FontColor] = @FontColor, [LastRev] = @LastRev, [LockPosition] = @LockPosition, [LockEdit] = @LockEdit, [Layer] = @Layer, [CompiledExp] = @CompiledExp, [validexpression] = @validexpression WHERE [ID]=@ID ";
		
		/// <remarks>This _databasename represents the full SELECT string for the table tblBargraph, with the WHERE clause.</remarks>
		internal static string SQL_Select = @"SELECT [DisplayID], [oIndex], [DlgType], [DlgIndex], [Left], [Right], [Top], [Bottom], [VertHorz], [RoolerFormat], [Direction], [BarColor], [BarColorID], [BarColorDefult], [BackColor], [BorderColor], [Index], [Font], [FontColor], [LastRev], [LockPosition], [LockEdit], [Layer], [CompiledExp], [validexpression] FROM [tblBargraph] WHERE [ID]=@ID ";
		
		/// <remarks>This _databasename represents the DELETE string for the table tblBargraph, with the WHERE clause.</remarks>
		internal static string SQL_Delete = "DELETE FROM [tblBargraph] WHERE [ID]=@ID ";
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
		private long _DisplayID = -1;
		
		[DisplayName("Display ID")]
		[Category("Foreign Key")]
		public long DisplayID
		{
			get
			{
				return _DisplayID;
			}
			set
			{
				_DisplayID = value;
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
		
		/// <remarks>SQL Type:System.Byte</remarks>
		private byte _DlgType;
		
		[DisplayName("Dlg Type")]
		[Category("Column")]
		public byte DlgType
		{
			get
			{
				return _DlgType;
			}
			set
			{
				_DlgType = value;
			}
		}
		
		/// <remarks>SQL Type:System.Int32</remarks>
		private int _DlgIndex;
		
		[DisplayName("Dlg Index")]
		[Category("Column")]
		public int DlgIndex
		{
			get
			{
				return _DlgIndex;
			}
			set
			{
				_DlgIndex = value;
			}
		}
		
		/// <remarks>SQL Type:System.Int32</remarks>
		private int _Left;
		
		[DisplayName("Left")]
		[Category("Column")]
		public int Left
		{
			get
			{
				return _Left;
			}
			set
			{
				_Left = value;
			}
		}
		
		/// <remarks>SQL Type:System.Int32</remarks>
		private int _Right;
		
		[DisplayName("Right")]
		[Category("Column")]
		public int Right
		{
			get
			{
				return _Right;
			}
			set
			{
				_Right = value;
			}
		}
		
		/// <remarks>SQL Type:System.Int32</remarks>
		private int _Top;
		
		[DisplayName("Top")]
		[Category("Column")]
		public int Top
		{
			get
			{
				return _Top;
			}
			set
			{
				_Top = value;
			}
		}
		
		/// <remarks>SQL Type:System.Int32</remarks>
		private int _Bottom;
		
		[DisplayName("Bottom")]
		[Category("Column")]
		public int Bottom
		{
			get
			{
				return _Bottom;
			}
			set
			{
				_Bottom = value;
			}
		}
		
		/// <remarks>SQL Type:System.Boolean</remarks>
		private bool _VertHorz;
		
		[DisplayName("Vert Horz")]
		[Category("Column")]
		public bool VertHorz
		{
			get
			{
				return _VertHorz;
			}
			set
			{
				_VertHorz = value;
			}
		}
		
		/// <remarks>SQL Type:System.Byte</remarks>
		private byte _RoolerFormat;
		
		[DisplayName("Rooler Format")]
		[Category("Column")]
		public byte RoolerFormat
		{
			get
			{
				return _RoolerFormat;
			}
			set
			{
				_RoolerFormat = value;
			}
		}
		
		/// <remarks>SQL Type:System.Byte</remarks>
		private byte _Direction;
		
		[DisplayName("Direction")]
		[Category("Column")]
		public byte Direction
		{
			get
			{
				return _Direction;
			}
			set
			{
				_Direction = value;
			}
		}
		
		/// <remarks>SQL Type:System.String</remarks>
		private string _BarColor = "";
		
		[DisplayName("Bar Color")]
		[Category("Column")]
		public string BarColor
		{
			get
			{
				return _BarColor;
			}
			set
			{
				_BarColor = value;
			}
		}
		
		/// <remarks>SQL Type:System.Int32</remarks>
		private int _BarColorID;
		
		[DisplayName("Bar Color ID")]
		[Category("Column")]
		public int BarColorID
		{
			get
			{
				return _BarColorID;
			}
			set
			{
				_BarColorID = value;
			}
		}
		
		/// <remarks>SQL Type:System.Drawing.Color</remarks>
		private System.Drawing.Color _BarColorDefult;
		
		[DisplayName("Bar Color Defult")]
		[Category("Column")]
		public System.Drawing.Color BarColorDefult
		{
			get
			{
				return _BarColorDefult;
			}
			set
			{
				_BarColorDefult = value;
			}
		}
		
		/// <remarks>SQL Type:System.Drawing.Color</remarks>
		private System.Drawing.Color _BackColor;
		
		[DisplayName("Back Color")]
		[Category("Column")]
		public System.Drawing.Color BackColor
		{
			get
			{
				return _BackColor;
			}
			set
			{
				_BackColor = value;
			}
		}
		
		/// <remarks>SQL Type:System.Drawing.Color</remarks>
		private System.Drawing.Color _BorderColor;
		
		[DisplayName("Border Color")]
		[Category("Column")]
		public System.Drawing.Color BorderColor
		{
			get
			{
				return _BorderColor;
			}
			set
			{
				_BorderColor = value;
			}
		}
		
		/// <remarks>SQL Type:System.Int32</remarks>
		private int _Index;
		
		[DisplayName("Index")]
		[Category("Column")]
		public int Index
		{
			get
			{
				return _Index;
			}
			set
			{
				_Index = value;
			}
		}
		
		/// <remarks>SQL Type:System.String</remarks>
		private string _Font = "";
		
		[DisplayName("Font")]
		[Category("Column")]
		public string Font
		{
			get
			{
				return _Font;
			}
			set
			{
				_Font = value;
			}
		}
		
		/// <remarks>SQL Type:System.Drawing.Color</remarks>
		private System.Drawing.Color _FontColor;
		
		[DisplayName("Font Color")]
		[Category("Column")]
		public System.Drawing.Color FontColor
		{
			get
			{
				return _FontColor;
			}
			set
			{
				_FontColor = value;
			}
		}
		
		/// <remarks>SQL Type:System.Boolean</remarks>
		private bool _LastRev;
		
		[DisplayName("Last Rev")]
		[Category("Column")]
		public bool LastRev
		{
			get
			{
				return _LastRev;
			}
			set
			{
				_LastRev = value;
			}
		}
		
		/// <remarks>SQL Type:System.Boolean</remarks>
		private bool _LockPosition;
		
		[DisplayName("Lock Position")]
		[Category("Column")]
		public bool LockPosition
		{
			get
			{
				return _LockPosition;
			}
			set
			{
				_LockPosition = value;
			}
		}
		
		/// <remarks>SQL Type:System.Boolean</remarks>
		private bool _LockEdit;
		
		[DisplayName("Lock Edit")]
		[Category("Column")]
		public bool LockEdit
		{
			get
			{
				return _LockEdit;
			}
			set
			{
				_LockEdit = value;
			}
		}
		
		/// <remarks>SQL Type:System.Int32</remarks>
		private int _Layer;
		
		[DisplayName("Layer")]
		[Category("Column")]
		public int Layer
		{
			get
			{
				return _Layer;
			}
			set
			{
				_Layer = value;
			}
		}
		
		/// <remarks>SQL Type:System.Byte[]</remarks>
		private byte[] _CompiledExp;
		
		[DisplayName("Compiled Exp")]
		[Category("Column")]
		public byte[] CompiledExp
		{
			get
			{
				return _CompiledExp;
			}
			set
			{
				_CompiledExp = value;
			}
		}
		
		/// <remarks>SQL Type:System.Boolean</remarks>
		private bool _validexpression;
		
		[DisplayName("validexpression")]
		[Category("Column")]
		public bool validexpression
		{
			get
			{
				return _validexpression;
			}
			set
			{
				_validexpression = value;
			}
		}
		#endregion
		
		#region Related Objects
		/// <remarks>Represents the foreign key object</remarks>
		private tblDisplay _DisplayID_tblDisplay;
		
		[Description("Represents the foreign key object of the type DisplayID")]
		public tblDisplay m_DisplayID_tblDisplay
		{
			get
			{
				return _DisplayID_tblDisplay;
			}
			set
			{
				_DisplayID_tblDisplay = value;
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
				Com.CommandText = tblBargraph.SQL_Delete;
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
				Com.CommandText = tblBargraph.SQL_Select;
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
				Com.CommandText = tblBargraph.SQL_Insert;
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
				Com.CommandText = tblBargraph.SQL_Update;
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
		
		public tblBargraph()
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
				SqlParmColl.Add(CommonDB.AddSqlParm("@DisplayID", DisplayID, DbType.Int64));
				SqlParmColl.Add(CommonDB.AddSqlParm("@oIndex", oIndex, DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@DlgType", DlgType, DbType.Byte));
				SqlParmColl.Add(CommonDB.AddSqlParm("@DlgIndex", DlgIndex, DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@Left", Left, DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@Right", Right, DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@Top", Top, DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@Bottom", Bottom, DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@VertHorz", VertHorz, DbType.Boolean));
				SqlParmColl.Add(CommonDB.AddSqlParm("@RoolerFormat", RoolerFormat, DbType.Byte));
				SqlParmColl.Add(CommonDB.AddSqlParm("@Direction", Direction, DbType.Byte));
				SqlParmColl.Add(CommonDB.AddSqlParm("@BarColor", BarColor, DbType.String));
				SqlParmColl.Add(CommonDB.AddSqlParm("@BarColorID", BarColorID, DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@BarColorDefult", BarColorDefult.ToArgb(), DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@BackColor", BackColor.ToArgb(), DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@BorderColor", BorderColor.ToArgb(), DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@Index", Index, DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@Font", Font, DbType.String));
				SqlParmColl.Add(CommonDB.AddSqlParm("@FontColor", FontColor.ToArgb(), DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@LastRev", LastRev, DbType.Boolean));
				SqlParmColl.Add(CommonDB.AddSqlParm("@LockPosition", LockPosition, DbType.Boolean));
				SqlParmColl.Add(CommonDB.AddSqlParm("@LockEdit", LockEdit, DbType.Boolean));
				SqlParmColl.Add(CommonDB.AddSqlParm("@Layer", Layer, DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@CompiledExp", CompiledExp, DbType.Binary));
				SqlParmColl.Add(CommonDB.AddSqlParm("@validexpression", validexpression, DbType.Boolean));
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
				// if value from the recordset, to the DisplayID _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("DisplayID")) == false))
				{
					DisplayID = ((long)(Convert.ChangeType(rs["DisplayID"], typeof(long))));
				}
				// if value from the recordset, to the oIndex _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("oIndex")) == false))
				{
					oIndex = ((int)(Convert.ChangeType(rs["oIndex"], typeof(int))));
				}
				// if value from the recordset, to the DlgType _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("DlgType")) == false))
				{
					DlgType = ((byte)(Convert.ChangeType(rs["DlgType"], typeof(byte))));
				}
				// if value from the recordset, to the DlgIndex _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("DlgIndex")) == false))
				{
					DlgIndex = ((int)(Convert.ChangeType(rs["DlgIndex"], typeof(int))));
				}
				// if value from the recordset, to the Left _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("Left")) == false))
				{
					Left = ((int)(Convert.ChangeType(rs["Left"], typeof(int))));
				}
				// if value from the recordset, to the Right _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("Right")) == false))
				{
					Right = ((int)(Convert.ChangeType(rs["Right"], typeof(int))));
				}
				// if value from the recordset, to the Top _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("Top")) == false))
				{
					Top = ((int)(Convert.ChangeType(rs["Top"], typeof(int))));
				}
				// if value from the recordset, to the Bottom _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("Bottom")) == false))
				{
					Bottom = ((int)(Convert.ChangeType(rs["Bottom"], typeof(int))));
				}
				// if value from the recordset, to the VertHorz _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("VertHorz")) == false))
				{
					VertHorz = ((bool)(Convert.ChangeType(rs["VertHorz"], typeof(bool))));
				}
				// if value from the recordset, to the RoolerFormat _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("RoolerFormat")) == false))
				{
					RoolerFormat = ((byte)(Convert.ChangeType(rs["RoolerFormat"], typeof(byte))));
				}
				// if value from the recordset, to the Direction _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("Direction")) == false))
				{
					Direction = ((byte)(Convert.ChangeType(rs["Direction"], typeof(byte))));
				}
				// if value from the recordset, to the BarColor _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("BarColor")) == false))
				{
					BarColor = ((string)(Convert.ChangeType(rs["BarColor"], typeof(string))));
				}
				// if value from the recordset, to the BarColorID _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("BarColorID")) == false))
				{
					BarColorID = ((int)(Convert.ChangeType(rs["BarColorID"], typeof(int))));
				}
				// if value from the recordset, to the BarColorDefult _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("BarColorDefult")) == false))
				{
					BarColorDefult = Color.FromArgb(((int)(Convert.ChangeType(rs["BarColorDefult"], typeof(int)))));
				}
				// if value from the recordset, to the BackColor _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("BackColor")) == false))
				{
					BackColor = Color.FromArgb(((int)(Convert.ChangeType(rs["BackColor"], typeof(int)))));
				}
				// if value from the recordset, to the BorderColor _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("BorderColor")) == false))
				{
					BorderColor = Color.FromArgb(((int)(Convert.ChangeType(rs["BorderColor"], typeof(int)))));
				}
				// if value from the recordset, to the Index _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("Index")) == false))
				{
					Index = ((int)(Convert.ChangeType(rs["Index"], typeof(int))));
				}
				// if value from the recordset, to the Font _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("Font")) == false))
				{
					Font = ((string)(Convert.ChangeType(rs["Font"], typeof(string))));
				}
				// if value from the recordset, to the FontColor _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("FontColor")) == false))
				{
					FontColor = Color.FromArgb(((int)(Convert.ChangeType(rs["FontColor"], typeof(int)))));
				}
				// if value from the recordset, to the LastRev _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("LastRev")) == false))
				{
					LastRev = ((bool)(Convert.ChangeType(rs["LastRev"], typeof(bool))));
				}
				// if value from the recordset, to the LockPosition _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("LockPosition")) == false))
				{
					LockPosition = ((bool)(Convert.ChangeType(rs["LockPosition"], typeof(bool))));
				}
				// if value from the recordset, to the LockEdit _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("LockEdit")) == false))
				{
					LockEdit = ((bool)(Convert.ChangeType(rs["LockEdit"], typeof(bool))));
				}
				// if value from the recordset, to the Layer _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("Layer")) == false))
				{
					Layer = ((int)(Convert.ChangeType(rs["Layer"], typeof(int))));
				}
				// if value from the recordset, to the CompiledExp _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("CompiledExp")) == false))
				{
					CompiledExp = ((byte[])(Convert.ChangeType(rs["CompiledExp"], typeof(byte[]))));
				}
				// if value from the recordset, to the validexpression _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("validexpression")) == false))
				{
					validexpression = ((bool)(Convert.ChangeType(rs["validexpression"], typeof(bool))));
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
				i = this.ColumnExistInHeader("DisplayID");
				if ((i >= 0))
				{
					DisplayID = ((long)(Convert.ChangeType(_strs[i], typeof(long))));
				}
				i = this.ColumnExistInHeader("oIndex");
				if ((i >= 0))
				{
					oIndex = ((int)(Convert.ChangeType(_strs[i], typeof(int))));
				}
				i = this.ColumnExistInHeader("DlgType");
				if ((i >= 0))
				{
					DlgType = ((byte)(Convert.ChangeType(_strs[i], typeof(byte))));
				}
				i = this.ColumnExistInHeader("DlgIndex");
				if ((i >= 0))
				{
					DlgIndex = ((int)(Convert.ChangeType(_strs[i], typeof(int))));
				}
				i = this.ColumnExistInHeader("Left");
				if ((i >= 0))
				{
					Left = ((int)(Convert.ChangeType(_strs[i], typeof(int))));
				}
				i = this.ColumnExistInHeader("Right");
				if ((i >= 0))
				{
					Right = ((int)(Convert.ChangeType(_strs[i], typeof(int))));
				}
				i = this.ColumnExistInHeader("Top");
				if ((i >= 0))
				{
					Top = ((int)(Convert.ChangeType(_strs[i], typeof(int))));
				}
				i = this.ColumnExistInHeader("Bottom");
				if ((i >= 0))
				{
					Bottom = ((int)(Convert.ChangeType(_strs[i], typeof(int))));
				}
				i = this.ColumnExistInHeader("VertHorz");
				if ((i >= 0))
				{
					VertHorz = ((bool)(Convert.ChangeType(_strs[i], typeof(bool))));
				}
				i = this.ColumnExistInHeader("RoolerFormat");
				if ((i >= 0))
				{
					RoolerFormat = ((byte)(Convert.ChangeType(_strs[i], typeof(byte))));
				}
				i = this.ColumnExistInHeader("Direction");
				if ((i >= 0))
				{
					Direction = ((byte)(Convert.ChangeType(_strs[i], typeof(byte))));
				}
				i = this.ColumnExistInHeader("BarColor");
				if ((i >= 0))
				{
					BarColor = ((string)(Convert.ChangeType(_strs[i], typeof(string))));
				}
				i = this.ColumnExistInHeader("BarColorID");
				if ((i >= 0))
				{
					BarColorID = ((int)(Convert.ChangeType(_strs[i], typeof(int))));
				}
				i = this.ColumnExistInHeader("BarColorDefult");
				if ((i >= 0))
				{
					BarColorDefult = Color.FromArgb(((int)(Convert.ChangeType(_strs[i], typeof(int)))));
				}
				i = this.ColumnExistInHeader("BackColor");
				if ((i >= 0))
				{
					BackColor = Color.FromArgb(((int)(Convert.ChangeType(_strs[i], typeof(int)))));
				}
				i = this.ColumnExistInHeader("BorderColor");
				if ((i >= 0))
				{
					BorderColor = Color.FromArgb(((int)(Convert.ChangeType(_strs[i], typeof(int)))));
				}
				i = this.ColumnExistInHeader("Index");
				if ((i >= 0))
				{
					Index = ((int)(Convert.ChangeType(_strs[i], typeof(int))));
				}
				i = this.ColumnExistInHeader("Font");
				if ((i >= 0))
				{
					Font = ((string)(Convert.ChangeType(_strs[i], typeof(string))));
				}
				i = this.ColumnExistInHeader("FontColor");
				if ((i >= 0))
				{
					FontColor = Color.FromArgb(((int)(Convert.ChangeType(_strs[i], typeof(int)))));
				}
				i = this.ColumnExistInHeader("LastRev");
				if ((i >= 0))
				{
					LastRev = ((bool)(Convert.ChangeType(_strs[i], typeof(bool))));
				}
				i = this.ColumnExistInHeader("LockPosition");
				if ((i >= 0))
				{
					LockPosition = ((bool)(Convert.ChangeType(_strs[i], typeof(bool))));
				}
				i = this.ColumnExistInHeader("LockEdit");
				if ((i >= 0))
				{
					LockEdit = ((bool)(Convert.ChangeType(_strs[i], typeof(bool))));
				}
				i = this.ColumnExistInHeader("Layer");
				if ((i >= 0))
				{
					Layer = ((int)(Convert.ChangeType(_strs[i], typeof(int))));
				}
				i = this.ColumnExistInHeader("CompiledExp");
				if ((i >= 0))
				{
					CompiledExp = ((byte[])(Convert.ChangeType(_strs[i], typeof(byte[]))));
				}
				i = this.ColumnExistInHeader("validexpression");
				if ((i >= 0))
				{
					validexpression = ((bool)(Convert.ChangeType(_strs[i], typeof(bool))));
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
	
	public delegate void tblBargraphChangedEventHandler(object sender, System.EventArgs e);
	
	public partial class tblBargraphCollection : SQLiteTableCollection
	{
		
		/// <remarks>SQL Type:tblBargraphChangedEventHandler</remarks>
		public event tblBargraphChangedEventHandler tblBargraphChanged;
		
		/// <remarks>Represents the foreign key object</remarks>
		private tblDisplay _DisplayID_tblDisplay;
		
		[Description("Represents the foreign key object of the type DisplayID")]
		public tblDisplay m_DisplayID_tblDisplay
		{
			get
			{
				return _DisplayID_tblDisplay;
			}
			set
			{
				_DisplayID_tblDisplay = value;
			}
		}
		
		[Description("Constructor")]
		public tblBargraphCollection(tblDisplay _parent)
		{
			_DisplayID_tblDisplay = _parent;
		}
		
		[Description("Invoke the Changed event; called whenever list changes")]
		protected virtual void OntblBargraphChanged(System.EventArgs e)
		{
			if (tblBargraphChanged != null)
			{
				this.tblBargraphChanged(this, e);
			}
		}
		
		[Description("Gets a  tblBargraph from the collection.")]
		public tblBargraph this[int index]
		{
			get
			{
				return ((tblBargraph)(List[index]));
			}
			set
			{
				List[index] = value;
				this.OntblBargraphChanged(EventArgs.Empty);
			}
		}
		
		[Description("Gets a  tblBargraph from the collection.")]
		public tblBargraph Get(int index)
		{
			return ((tblBargraph)(List[index]));
		}
		
		[Description("Adds a new tblBargraph to the collection.")]
		public void Add(tblBargraph item)
		{
			List.Add(item);
			this.OntblBargraphChanged(EventArgs.Empty);
		}
		
		[Description("Removes a tblBargraph from the collection.")]
		public void Remove(tblBargraph item)
		{
			List.Remove(item);
			this.OntblBargraphChanged(EventArgs.Empty);
		}
		
		[Description("Inserts an tblBargraph into the collection at the specified index.")]
		public void Insert(int index, tblBargraph item)
		{
			List.Insert(index, item);
			this.OntblBargraphChanged(EventArgs.Empty);
		}
		
		[Description("Returns the index value of the tblBargraph class in the collection.")]
		public int IndexOf(tblBargraph item)
		{
			return List.IndexOf(item);
		}
		
		[Description("Returns true if the tblBargraph class is present in the collection.")]
		public bool Contains(tblBargraph item)
		{
			return List.Contains(item);
		}
	}
}
