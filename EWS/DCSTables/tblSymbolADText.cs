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


    public partial class tblSymbolADText : SQLiteTable
	{
		
		#region Static SQL String Memebers
		/// <remarks>This _databasename represents the full INSERT INTO string for the table tblSymbolADText.</remarks>
		internal static string SQL_Insert = @"INSERT INTO [tblSymbolADText] ([SymbolStatusID], [oIndex], [DlgType], [DlgIndex], [Left], [Right], [Top], [Bottom], [Format], [Alignment], [Font], [TextValueDefult], [TextColorDefult], [TextBlinkingDefult], [BorderColorDefult], [BorderBlinkingDefult], [BorderWidthDefult], [BackGroundColorDefult], [BackGroundBlinkingDefult], [Orientation]) VALUES(@SymbolStatusID, @oIndex, @DlgType, @DlgIndex, @Left, @Right, @Top, @Bottom, @Format, @Alignment, @Font, @TextValueDefult, @TextColorDefult, @TextBlinkingDefult, @BorderColorDefult, @BorderBlinkingDefult, @BorderWidthDefult, @BackGroundColorDefult, @BackGroundBlinkingDefult, @Orientation) ; select last_insert_rowid(); ";
		
		/// <remarks>This _databasename represents the full UPDATE string for the table tblSymbolADText, with the WHERE clause.</remarks>
		internal static string SQL_Update = @"UPDATE [tblSymbolADText] SET [SymbolStatusID] = @SymbolStatusID, [oIndex] = @oIndex, [DlgType] = @DlgType, [DlgIndex] = @DlgIndex, [Left] = @Left, [Right] = @Right, [Top] = @Top, [Bottom] = @Bottom, [Format] = @Format, [Alignment] = @Alignment, [Font] = @Font, [TextValueDefult] = @TextValueDefult, [TextColorDefult] = @TextColorDefult, [TextBlinkingDefult] = @TextBlinkingDefult, [BorderColorDefult] = @BorderColorDefult, [BorderBlinkingDefult] = @BorderBlinkingDefult, [BorderWidthDefult] = @BorderWidthDefult, [BackGroundColorDefult] = @BackGroundColorDefult, [BackGroundBlinkingDefult] = @BackGroundBlinkingDefult, [Orientation] = @Orientation WHERE [ADTextID]=@ADTextID ";
		
		/// <remarks>This _databasename represents the full SELECT string for the table tblSymbolADText, with the WHERE clause.</remarks>
		internal static string SQL_Select = @"SELECT [SymbolStatusID], [oIndex], [DlgType], [DlgIndex], [Left], [Right], [Top], [Bottom], [Format], [Alignment], [Font], [TextValueDefult], [TextColorDefult], [TextBlinkingDefult], [BorderColorDefult], [BorderBlinkingDefult], [BorderWidthDefult], [BackGroundColorDefult], [BackGroundBlinkingDefult], [Orientation] FROM [tblSymbolADText] WHERE [ADTextID]=@ADTextID ";
		
		/// <remarks>This _databasename represents the DELETE string for the table tblSymbolADText, with the WHERE clause.</remarks>
		internal static string SQL_Delete = "DELETE FROM [tblSymbolADText] WHERE [ADTextID]=@ADTextID ";
		#endregion
		
		#region Tables Memebers
		/// <remarks>SQL Type:System.Int64</remarks>
		private long _ADTextID = -1;
		
		[DisplayName("ADText ID")]
		[Category("Primary Key")]
		public long ADTextID
		{
			get
			{
				return _ADTextID;
			}
			set
			{
				_ADTextID = value;
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
		
		/// <remarks>SQL Type:System.Int32</remarks>
		private int _Format;
		
		[DisplayName("Format")]
		[Category("Column")]
		public int Format
		{
			get
			{
				return _Format;
			}
			set
			{
				_Format = value;
			}
		}
		
		/// <remarks>SQL Type:System.Byte</remarks>
		private byte _Alignment;
		
		[DisplayName("Alignment")]
		[Category("Column")]
		public byte Alignment
		{
			get
			{
				return _Alignment;
			}
			set
			{
				_Alignment = value;
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
		
		/// <remarks>SQL Type:System.String</remarks>
		private string _TextValueDefult = "";
		
		[DisplayName("Text Value Defult")]
		[Category("Column")]
		public string TextValueDefult
		{
			get
			{
				return _TextValueDefult;
			}
			set
			{
				_TextValueDefult = value;
			}
		}
		
		/// <remarks>SQL Type:System.Drawing.Color</remarks>
		private System.Drawing.Color _TextColorDefult;
		
		[DisplayName("Text Color Defult")]
		[Category("Column")]
		public System.Drawing.Color TextColorDefult
		{
			get
			{
				return _TextColorDefult;
			}
			set
			{
				_TextColorDefult = value;
			}
		}
		
		/// <remarks>SQL Type:System.Boolean</remarks>
		private bool _TextBlinkingDefult;
		
		[DisplayName("Text Blinking Defult")]
		[Category("Column")]
		public bool TextBlinkingDefult
		{
			get
			{
				return _TextBlinkingDefult;
			}
			set
			{
				_TextBlinkingDefult = value;
			}
		}
		
		/// <remarks>SQL Type:System.Drawing.Color</remarks>
		private System.Drawing.Color _BorderColorDefult;
		
		[DisplayName("Border Color Defult")]
		[Category("Column")]
		public System.Drawing.Color BorderColorDefult
		{
			get
			{
				return _BorderColorDefult;
			}
			set
			{
				_BorderColorDefult = value;
			}
		}
		
		/// <remarks>SQL Type:System.Boolean</remarks>
		private bool _BorderBlinkingDefult;
		
		[DisplayName("Border Blinking Defult")]
		[Category("Column")]
		public bool BorderBlinkingDefult
		{
			get
			{
				return _BorderBlinkingDefult;
			}
			set
			{
				_BorderBlinkingDefult = value;
			}
		}
		
		/// <remarks>SQL Type:System.Int32</remarks>
		private int _BorderWidthDefult;
		
		[DisplayName("Border Width Defult")]
		[Category("Column")]
		public int BorderWidthDefult
		{
			get
			{
				return _BorderWidthDefult;
			}
			set
			{
				_BorderWidthDefult = value;
			}
		}
		
		/// <remarks>SQL Type:System.Drawing.Color</remarks>
		private System.Drawing.Color _BackGroundColorDefult;
		
		[DisplayName("Back Ground Color Defult")]
		[Category("Column")]
		public System.Drawing.Color BackGroundColorDefult
		{
			get
			{
				return _BackGroundColorDefult;
			}
			set
			{
				_BackGroundColorDefult = value;
			}
		}
		
		/// <remarks>SQL Type:System.Boolean</remarks>
		private bool _BackGroundBlinkingDefult;
		
		[DisplayName("Back Ground Blinking Defult")]
		[Category("Column")]
		public bool BackGroundBlinkingDefult
		{
			get
			{
				return _BackGroundBlinkingDefult;
			}
			set
			{
				_BackGroundBlinkingDefult = value;
			}
		}
		
		/// <remarks>SQL Type:System.Int32</remarks>
		private int _Orientation;
		
		[DisplayName("Orientation")]
		[Category("Column")]
		public int Orientation
		{
			get
			{
				return _Orientation;
			}
			set
			{
				_Orientation = value;
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
				Com.CommandText = tblSymbolADText.SQL_Delete;
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
				Com.CommandText = tblSymbolADText.SQL_Select;
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
				Com.CommandText = tblSymbolADText.SQL_Insert;
				Com.Parameters.AddRange(GetSqlParameters());
				ADTextID = ((long)(Convert.ToInt64(Com.ExecuteScalar())));
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
				Com.CommandText = tblSymbolADText.SQL_Update;
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
		
		public tblSymbolADText()
		{
		}
		#endregion
		
		#region Private Methods
		private SQLiteParameter[] GetSqlParameters()
		{
			List<SQLiteParameter> SqlParmColl = new List<SQLiteParameter>();
			try
			{
				SqlParmColl.Add(CommonDB.AddSqlParm("@ADTextID", ADTextID, DbType.Int64));
				SqlParmColl.Add(CommonDB.AddSqlParm("@SymbolStatusID", SymbolStatusID, DbType.Int64));
				SqlParmColl.Add(CommonDB.AddSqlParm("@oIndex", oIndex, DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@DlgType", DlgType, DbType.Byte));
				SqlParmColl.Add(CommonDB.AddSqlParm("@DlgIndex", DlgIndex, DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@Left", Left, DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@Right", Right, DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@Top", Top, DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@Bottom", Bottom, DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@Format", Format, DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@Alignment", Alignment, DbType.Byte));
				SqlParmColl.Add(CommonDB.AddSqlParm("@Font", Font, DbType.String));
				SqlParmColl.Add(CommonDB.AddSqlParm("@TextValueDefult", TextValueDefult, DbType.String));
				SqlParmColl.Add(CommonDB.AddSqlParm("@TextColorDefult", TextColorDefult.ToArgb(), DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@TextBlinkingDefult", TextBlinkingDefult, DbType.Boolean));
				SqlParmColl.Add(CommonDB.AddSqlParm("@BorderColorDefult", BorderColorDefult.ToArgb(), DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@BorderBlinkingDefult", BorderBlinkingDefult, DbType.Boolean));
				SqlParmColl.Add(CommonDB.AddSqlParm("@BorderWidthDefult", BorderWidthDefult, DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@BackGroundColorDefult", BackGroundColorDefult.ToArgb(), DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@BackGroundBlinkingDefult", BackGroundBlinkingDefult, DbType.Boolean));
				SqlParmColl.Add(CommonDB.AddSqlParm("@Orientation", Orientation, DbType.Int32));
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
				// if value from the recordset, to the ADTextID _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("ADTextID")) == false))
				{
					ADTextID = ((long)(Convert.ChangeType(rs["ADTextID"], typeof(long))));
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
				// if value from the recordset, to the Format _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("Format")) == false))
				{
					Format = ((int)(Convert.ChangeType(rs["Format"], typeof(int))));
				}
				// if value from the recordset, to the Alignment _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("Alignment")) == false))
				{
					Alignment = ((byte)(Convert.ChangeType(rs["Alignment"], typeof(byte))));
				}
				// if value from the recordset, to the Font _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("Font")) == false))
				{
					Font = ((string)(Convert.ChangeType(rs["Font"], typeof(string))));
				}
				// if value from the recordset, to the TextValueDefult _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("TextValueDefult")) == false))
				{
					TextValueDefult = ((string)(Convert.ChangeType(rs["TextValueDefult"], typeof(string))));
				}
				// if value from the recordset, to the TextColorDefult _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("TextColorDefult")) == false))
				{
					TextColorDefult = Color.FromArgb(((int)(Convert.ChangeType(rs["TextColorDefult"], typeof(int)))));
				}
				// if value from the recordset, to the TextBlinkingDefult _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("TextBlinkingDefult")) == false))
				{
					TextBlinkingDefult = ((bool)(Convert.ChangeType(rs["TextBlinkingDefult"], typeof(bool))));
				}
				// if value from the recordset, to the BorderColorDefult _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("BorderColorDefult")) == false))
				{
					BorderColorDefult = Color.FromArgb(((int)(Convert.ChangeType(rs["BorderColorDefult"], typeof(int)))));
				}
				// if value from the recordset, to the BorderBlinkingDefult _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("BorderBlinkingDefult")) == false))
				{
					BorderBlinkingDefult = ((bool)(Convert.ChangeType(rs["BorderBlinkingDefult"], typeof(bool))));
				}
				// if value from the recordset, to the BorderWidthDefult _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("BorderWidthDefult")) == false))
				{
					BorderWidthDefult = ((int)(Convert.ChangeType(rs["BorderWidthDefult"], typeof(int))));
				}
				// if value from the recordset, to the BackGroundColorDefult _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("BackGroundColorDefult")) == false))
				{
					BackGroundColorDefult = Color.FromArgb(((int)(Convert.ChangeType(rs["BackGroundColorDefult"], typeof(int)))));
				}
				// if value from the recordset, to the BackGroundBlinkingDefult _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("BackGroundBlinkingDefult")) == false))
				{
					BackGroundBlinkingDefult = ((bool)(Convert.ChangeType(rs["BackGroundBlinkingDefult"], typeof(bool))));
				}
				// if value from the recordset, to the Orientation _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("Orientation")) == false))
				{
					Orientation = ((int)(Convert.ChangeType(rs["Orientation"], typeof(int))));
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
				i = this.ColumnExistInHeader("Format");
				if ((i >= 0))
				{
					Format = ((int)(Convert.ChangeType(_strs[i], typeof(int))));
				}
				i = this.ColumnExistInHeader("Alignment");
				if ((i >= 0))
				{
					Alignment = ((byte)(Convert.ChangeType(_strs[i], typeof(byte))));
				}
				i = this.ColumnExistInHeader("Font");
				if ((i >= 0))
				{
					Font = ((string)(Convert.ChangeType(_strs[i], typeof(string))));
				}
				i = this.ColumnExistInHeader("TextValueDefult");
				if ((i >= 0))
				{
					TextValueDefult = ((string)(Convert.ChangeType(_strs[i], typeof(string))));
				}
				i = this.ColumnExistInHeader("TextColorDefult");
				if ((i >= 0))
				{
					TextColorDefult = Color.FromArgb(((int)(Convert.ChangeType(_strs[i], typeof(int)))));
				}
				i = this.ColumnExistInHeader("TextBlinkingDefult");
				if ((i >= 0))
				{
					TextBlinkingDefult = ((bool)(Convert.ChangeType(_strs[i], typeof(bool))));
				}
				i = this.ColumnExistInHeader("BorderColorDefult");
				if ((i >= 0))
				{
					BorderColorDefult = Color.FromArgb(((int)(Convert.ChangeType(_strs[i], typeof(int)))));
				}
				i = this.ColumnExistInHeader("BorderBlinkingDefult");
				if ((i >= 0))
				{
					BorderBlinkingDefult = ((bool)(Convert.ChangeType(_strs[i], typeof(bool))));
				}
				i = this.ColumnExistInHeader("BorderWidthDefult");
				if ((i >= 0))
				{
					BorderWidthDefult = ((int)(Convert.ChangeType(_strs[i], typeof(int))));
				}
				i = this.ColumnExistInHeader("BackGroundColorDefult");
				if ((i >= 0))
				{
					BackGroundColorDefult = Color.FromArgb(((int)(Convert.ChangeType(_strs[i], typeof(int)))));
				}
				i = this.ColumnExistInHeader("BackGroundBlinkingDefult");
				if ((i >= 0))
				{
					BackGroundBlinkingDefult = ((bool)(Convert.ChangeType(_strs[i], typeof(bool))));
				}
				i = this.ColumnExistInHeader("Orientation");
				if ((i >= 0))
				{
					Orientation = ((int)(Convert.ChangeType(_strs[i], typeof(int))));
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
	
	public delegate void tblSymbolADTextChangedEventHandler(object sender, System.EventArgs e);
	
	public partial class tblSymbolADTextCollection : SQLiteTableCollection
	{
		
		/// <remarks>SQL Type:tblSymbolADTextChangedEventHandler</remarks>
		public event tblSymbolADTextChangedEventHandler tblSymbolADTextChanged;
		
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
		public tblSymbolADTextCollection(tblSymbolStatus _parent)
		{
			_SymbolStatusID_tblSymbolStatus = _parent;
		}
		
		[Description("Invoke the Changed event; called whenever list changes")]
		protected virtual void OntblSymbolADTextChanged(System.EventArgs e)
		{
			if (tblSymbolADTextChanged != null)
			{
				this.tblSymbolADTextChanged(this, e);
			}
		}
		
		[Description("Gets a  tblSymbolADText from the collection.")]
		public tblSymbolADText this[int index]
		{
			get
			{
				return ((tblSymbolADText)(List[index]));
			}
			set
			{
				List[index] = value;
				this.OntblSymbolADTextChanged(EventArgs.Empty);
			}
		}
		
		[Description("Gets a  tblSymbolADText from the collection.")]
		public tblSymbolADText Get(int index)
		{
			return ((tblSymbolADText)(List[index]));
		}
		
		[Description("Adds a new tblSymbolADText to the collection.")]
		public void Add(tblSymbolADText item)
		{
			List.Add(item);
			this.OntblSymbolADTextChanged(EventArgs.Empty);
		}
		
		[Description("Removes a tblSymbolADText from the collection.")]
		public void Remove(tblSymbolADText item)
		{
			List.Remove(item);
			this.OntblSymbolADTextChanged(EventArgs.Empty);
		}
		
		[Description("Inserts an tblSymbolADText into the collection at the specified index.")]
		public void Insert(int index, tblSymbolADText item)
		{
			List.Insert(index, item);
			this.OntblSymbolADTextChanged(EventArgs.Empty);
		}
		
		[Description("Returns the index value of the tblSymbolADText class in the collection.")]
		public int IndexOf(tblSymbolADText item)
		{
			return List.IndexOf(item);
		}
		
		[Description("Returns true if the tblSymbolADText class is present in the collection.")]
		public bool Contains(tblSymbolADText item)
		{
			return List.Contains(item);
		}
	}
}
