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


    public partial class tblText : SQLiteTable
	{
		
		#region Static SQL String Memebers
		/// <remarks>This _databasename represents the full INSERT INTO string for the table tblText.</remarks>
		internal static string SQL_Insert = @"INSERT INTO [tblText] ([DisplayID], [oIndex], [bFont], [Hidable], [Font], [TextColor], [Left], [Top], [Right], [Bottom], [Txt], [FillColor], [lineStyle], [Lock], [Visible], [Expression], [Action], [Layer], [CompiledExp], [validexpression]) VALUES(@DisplayID, @oIndex, @bFont, @Hidable, @Font, @TextColor, @Left, @Top, @Right, @Bottom, @Txt, @FillColor, @lineStyle, @Lock, @Visible, @Expression, @Action, @Layer, @CompiledExp, @validexpression) ; select last_insert_rowid(); ";
		
		/// <remarks>This _databasename represents the full UPDATE string for the table tblText, with the WHERE clause.</remarks>
		internal static string SQL_Update = @"UPDATE [tblText] SET [DisplayID] = @DisplayID, [oIndex] = @oIndex, [bFont] = @bFont, [Hidable] = @Hidable, [Font] = @Font, [TextColor] = @TextColor, [Left] = @Left, [Top] = @Top, [Right] = @Right, [Bottom] = @Bottom, [Txt] = @Txt, [FillColor] = @FillColor, [lineStyle] = @lineStyle, [Lock] = @Lock, [Visible] = @Visible, [Expression] = @Expression, [Action] = @Action, [Layer] = @Layer, [CompiledExp] = @CompiledExp, [validexpression] = @validexpression WHERE [ID]=@ID ";
		
		/// <remarks>This _databasename represents the full SELECT string for the table tblText, with the WHERE clause.</remarks>
		internal static string SQL_Select = "SELECT [DisplayID], [oIndex], [bFont], [Hidable], [Font], [TextColor], [Left], [T" +
			"op], [Right], [Bottom], [Txt], [FillColor], [lineStyle], [Lock], [Visible], [Exp" +
			"ression], [Action], [Layer], [CompiledExp], [validexpression] FROM [tblText] WHE" +
			"RE [ID]=@ID ";
		
		/// <remarks>This _databasename represents the DELETE string for the table tblText, with the WHERE clause.</remarks>
		internal static string SQL_Delete = "DELETE FROM [tblText] WHERE [ID]=@ID ";
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
		
		/// <remarks>SQL Type:System.Boolean</remarks>
		private bool _bFont;
		
		[DisplayName("b Font")]
		[Category("Column")]
		public bool bFont
		{
			get
			{
				return _bFont;
			}
			set
			{
				_bFont = value;
			}
		}
		
		/// <remarks>SQL Type:System.Boolean</remarks>
		private bool _Hidable;
		
		[DisplayName("Hidable")]
		[Category("Column")]
		public bool Hidable
		{
			get
			{
				return _Hidable;
			}
			set
			{
				_Hidable = value;
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
		private System.Drawing.Color _TextColor;
		
		[DisplayName("Text Color")]
		[Category("Column")]
		public System.Drawing.Color TextColor
		{
			get
			{
				return _TextColor;
			}
			set
			{
				_TextColor = value;
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
		
		/// <remarks>SQL Type:System.String</remarks>
		private string _Txt = "";
		
		[DisplayName("Txt")]
		[Category("Column")]
		public string Txt
		{
			get
			{
				return _Txt;
			}
			set
			{
				_Txt = value;
			}
		}
		
		/// <remarks>SQL Type:System.String</remarks>
		private string _FillColor = "";
		
		[DisplayName("Fill Color")]
		[Category("Column")]
		public string FillColor
		{
			get
			{
				return _FillColor;
			}
			set
			{
				_FillColor = value;
			}
		}
		
		/// <remarks>SQL Type:System.String</remarks>
		private string _lineStyle = "";
		
		[DisplayName("line Style")]
		[Category("Column")]
		public string lineStyle
		{
			get
			{
				return _lineStyle;
			}
			set
			{
				_lineStyle = value;
			}
		}
		
		/// <remarks>SQL Type:System.Boolean</remarks>
		private bool _Lock;
		
		[DisplayName("Lock")]
		[Category("Column")]
		public bool Lock
		{
			get
			{
				return _Lock;
			}
			set
			{
				_Lock = value;
			}
		}
		
		/// <remarks>SQL Type:System.Boolean</remarks>
		private bool _Visible;
		
		[DisplayName("Visible")]
		[Category("Column")]
		public bool Visible
		{
			get
			{
				return _Visible;
			}
			set
			{
				_Visible = value;
			}
		}
		
		/// <remarks>SQL Type:System.String</remarks>
		private string _Expression = "";
		
		[DisplayName("Expression")]
		[Category("Column")]
		public string Expression
		{
			get
			{
				return _Expression;
			}
			set
			{
				_Expression = value;
			}
		}
		
		/// <remarks>SQL Type:System.String</remarks>
		private string _Action = "";
		
		[DisplayName("Action")]
		[Category("Column")]
		public string Action
		{
			get
			{
				return _Action;
			}
			set
			{
				_Action = value;
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
				Com.CommandText = tblText.SQL_Delete;
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
				Com.CommandText = tblText.SQL_Select;
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
				Com.CommandText = tblText.SQL_Insert;
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
				Com.CommandText = tblText.SQL_Update;
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
		
		public tblText()
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
				SqlParmColl.Add(CommonDB.AddSqlParm("@bFont", bFont, DbType.Boolean));
				SqlParmColl.Add(CommonDB.AddSqlParm("@Hidable", Hidable, DbType.Boolean));
				SqlParmColl.Add(CommonDB.AddSqlParm("@Font", Font, DbType.String));
				SqlParmColl.Add(CommonDB.AddSqlParm("@TextColor", TextColor.ToArgb(), DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@Left", Left, DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@Top", Top, DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@Right", Right, DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@Bottom", Bottom, DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@Txt", Txt, DbType.String));
				SqlParmColl.Add(CommonDB.AddSqlParm("@FillColor", FillColor, DbType.String));
				SqlParmColl.Add(CommonDB.AddSqlParm("@lineStyle", lineStyle, DbType.String));
				SqlParmColl.Add(CommonDB.AddSqlParm("@Lock", Lock, DbType.Boolean));
				SqlParmColl.Add(CommonDB.AddSqlParm("@Visible", Visible, DbType.Boolean));
				SqlParmColl.Add(CommonDB.AddSqlParm("@Expression", Expression, DbType.String));
				SqlParmColl.Add(CommonDB.AddSqlParm("@Action", Action, DbType.String));
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
				// if value from the recordset, to the bFont _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("bFont")) == false))
				{
					bFont = ((bool)(Convert.ChangeType(rs["bFont"], typeof(bool))));
				}
				// if value from the recordset, to the Hidable _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("Hidable")) == false))
				{
					Hidable = ((bool)(Convert.ChangeType(rs["Hidable"], typeof(bool))));
				}
				// if value from the recordset, to the Font _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("Font")) == false))
				{
					Font = ((string)(Convert.ChangeType(rs["Font"], typeof(string))));
				}
				// if value from the recordset, to the TextColor _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("TextColor")) == false))
				{
					TextColor = Color.FromArgb(((int)(Convert.ChangeType(rs["TextColor"], typeof(int)))));
				}
				// if value from the recordset, to the Left _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("Left")) == false))
				{
					Left = ((int)(Convert.ChangeType(rs["Left"], typeof(int))));
				}
				// if value from the recordset, to the Top _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("Top")) == false))
				{
					Top = ((int)(Convert.ChangeType(rs["Top"], typeof(int))));
				}
				// if value from the recordset, to the Right _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("Right")) == false))
				{
					Right = ((int)(Convert.ChangeType(rs["Right"], typeof(int))));
				}
				// if value from the recordset, to the Bottom _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("Bottom")) == false))
				{
					Bottom = ((int)(Convert.ChangeType(rs["Bottom"], typeof(int))));
				}
				// if value from the recordset, to the Txt _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("Txt")) == false))
				{
					Txt = ((string)(Convert.ChangeType(rs["Txt"], typeof(string))));
				}
				// if value from the recordset, to the FillColor _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("FillColor")) == false))
				{
					FillColor = ((string)(Convert.ChangeType(rs["FillColor"], typeof(string))));
				}
				// if value from the recordset, to the lineStyle _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("lineStyle")) == false))
				{
					lineStyle = ((string)(Convert.ChangeType(rs["lineStyle"], typeof(string))));
				}
				// if value from the recordset, to the Lock _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("Lock")) == false))
				{
					Lock = ((bool)(Convert.ChangeType(rs["Lock"], typeof(bool))));
				}
				// if value from the recordset, to the Visible _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("Visible")) == false))
				{
					Visible = ((bool)(Convert.ChangeType(rs["Visible"], typeof(bool))));
				}
				// if value from the recordset, to the Expression _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("Expression")) == false))
				{
					Expression = ((string)(Convert.ChangeType(rs["Expression"], typeof(string))));
				}
				// if value from the recordset, to the Action _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("Action")) == false))
				{
					Action = ((string)(Convert.ChangeType(rs["Action"], typeof(string))));
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
				i = this.ColumnExistInHeader("bFont");
				if ((i >= 0))
				{
					bFont = ((bool)(Convert.ChangeType(_strs[i], typeof(bool))));
				}
				i = this.ColumnExistInHeader("Hidable");
				if ((i >= 0))
				{
					Hidable = ((bool)(Convert.ChangeType(_strs[i], typeof(bool))));
				}
				i = this.ColumnExistInHeader("Font");
				if ((i >= 0))
				{
					Font = ((string)(Convert.ChangeType(_strs[i], typeof(string))));
				}
				i = this.ColumnExistInHeader("TextColor");
				if ((i >= 0))
				{
					TextColor = Color.FromArgb(((int)(Convert.ChangeType(_strs[i], typeof(int)))));
				}
				i = this.ColumnExistInHeader("Left");
				if ((i >= 0))
				{
					Left = ((int)(Convert.ChangeType(_strs[i], typeof(int))));
				}
				i = this.ColumnExistInHeader("Top");
				if ((i >= 0))
				{
					Top = ((int)(Convert.ChangeType(_strs[i], typeof(int))));
				}
				i = this.ColumnExistInHeader("Right");
				if ((i >= 0))
				{
					Right = ((int)(Convert.ChangeType(_strs[i], typeof(int))));
				}
				i = this.ColumnExistInHeader("Bottom");
				if ((i >= 0))
				{
					Bottom = ((int)(Convert.ChangeType(_strs[i], typeof(int))));
				}
				i = this.ColumnExistInHeader("Txt");
				if ((i >= 0))
				{
					Txt = ((string)(Convert.ChangeType(_strs[i], typeof(string))));
				}
				i = this.ColumnExistInHeader("FillColor");
				if ((i >= 0))
				{
					FillColor = ((string)(Convert.ChangeType(_strs[i], typeof(string))));
				}
				i = this.ColumnExistInHeader("lineStyle");
				if ((i >= 0))
				{
					lineStyle = ((string)(Convert.ChangeType(_strs[i], typeof(string))));
				}
				i = this.ColumnExistInHeader("Lock");
				if ((i >= 0))
				{
					Lock = ((bool)(Convert.ChangeType(_strs[i], typeof(bool))));
				}
				i = this.ColumnExistInHeader("Visible");
				if ((i >= 0))
				{
					Visible = ((bool)(Convert.ChangeType(_strs[i], typeof(bool))));
				}
				i = this.ColumnExistInHeader("Expression");
				if ((i >= 0))
				{
					Expression = ((string)(Convert.ChangeType(_strs[i], typeof(string))));
				}
				i = this.ColumnExistInHeader("Action");
				if ((i >= 0))
				{
					Action = ((string)(Convert.ChangeType(_strs[i], typeof(string))));
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
	
	public delegate void tblTextChangedEventHandler(object sender, System.EventArgs e);
	
	public partial class tblTextCollection : SQLiteTableCollection
	{
		
		/// <remarks>SQL Type:tblTextChangedEventHandler</remarks>
		public event tblTextChangedEventHandler tblTextChanged;
		
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
		public tblTextCollection(tblDisplay _parent)
		{
			_DisplayID_tblDisplay = _parent;
		}
		
		[Description("Invoke the Changed event; called whenever list changes")]
		protected virtual void OntblTextChanged(System.EventArgs e)
		{
			if (tblTextChanged != null)
			{
				this.tblTextChanged(this, e);
			}
		}
		
		[Description("Gets a  tblText from the collection.")]
		public tblText this[int index]
		{
			get
			{
				return ((tblText)(List[index]));
			}
			set
			{
				List[index] = value;
				this.OntblTextChanged(EventArgs.Empty);
			}
		}
		
		[Description("Gets a  tblText from the collection.")]
		public tblText Get(int index)
		{
			return ((tblText)(List[index]));
		}
		
		[Description("Adds a new tblText to the collection.")]
		public void Add(tblText item)
		{
			List.Add(item);
			this.OntblTextChanged(EventArgs.Empty);
		}
		
		[Description("Removes a tblText from the collection.")]
		public void Remove(tblText item)
		{
			List.Remove(item);
			this.OntblTextChanged(EventArgs.Empty);
		}
		
		[Description("Inserts an tblText into the collection at the specified index.")]
		public void Insert(int index, tblText item)
		{
			List.Insert(index, item);
			this.OntblTextChanged(EventArgs.Empty);
		}
		
		[Description("Returns the index value of the tblText class in the collection.")]
		public int IndexOf(tblText item)
		{
			return List.IndexOf(item);
		}
		
		[Description("Returns true if the tblText class is present in the collection.")]
		public bool Contains(tblText item)
		{
			return List.Contains(item);
		}
	}
}
