//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace EWS.DCSTables
{
	
	
	public partial class tblBlockStatusText : Object
	{
		
		#region Static SQL String Memebers
		/// <remarks>This _databasename represents the full INSERT INTO string for the table tblBlockStatusText.</remarks>
		internal static string SQL_Insert = "INSERT INTO [tblBlockStatusText] ([SolitionID], [Txt], [Bit], [Decsription], [Rea" +
			"donly]) VALUES(@SolitionID, @Txt, @Bit, @Decsription, @Readonly) ; select last_i" +
			"nsert_rowid(); ";
		
		/// <remarks>This _databasename represents the full UPDATE string for the table tblBlockStatusText, with the WHERE clause.</remarks>
		internal static string SQL_Update = "UPDATE [tblBlockStatusText] SET [SolitionID] = @SolitionID, [Txt] = @Txt, [Bit] =" +
			" @Bit, [Decsription] = @Decsription, [Readonly] = @Readonly WHERE [ID]=@ID ";
		
		/// <remarks>This _databasename represents the full SELECT string for the table tblBlockStatusText, with the WHERE clause.</remarks>
		internal static string SQL_Select = "SELECT [SolitionID], [Txt], [Bit], [Decsription], [Readonly] FROM [tblBlockStatus" +
			"Text] WHERE [ID]=@ID ";
		
		/// <remarks>This _databasename represents the DELETE string for the table tblBlockStatusText, with the WHERE clause.</remarks>
		internal static string SQL_Delete = "DELETE FROM [tblBlockStatusText] WHERE [ID]=@ID ";
		#endregion
		
		#region Tables Memebers
		/// <remarks>SQL Type:System.Int64</remarks>
		private long _ID;
		
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
		private long _SolitionID;
		
		[DisplayName("Solition ID")]
		[Category("Foreign Key")]
		public long SolitionID
		{
			get
			{
				return _SolitionID;
			}
			set
			{
				_SolitionID = value;
			}
		}
		
		/// <remarks>SQL Type:System.String</remarks>
		private string _Txt;
		
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
		
		/// <remarks>SQL Type:System.Int32</remarks>
		private int _Bit;
		
		[DisplayName("Bit")]
		[Category("Column")]
		public int Bit
		{
			get
			{
				return _Bit;
			}
			set
			{
				_Bit = value;
			}
		}
		
		/// <remarks>SQL Type:System.String</remarks>
		private string _Decsription;
		
		[DisplayName("Decsription")]
		[Category("Column")]
		public string Decsription
		{
			get
			{
				return _Decsription;
			}
			set
			{
				_Decsription = value;
			}
		}
		
		/// <remarks>SQL Type:System.Boolean</remarks>
		private bool _Readonly;
		
		[DisplayName("Readonly")]
		[Category("Column")]
		public bool Readonly
		{
			get
			{
				return _Readonly;
			}
			set
			{
				_Readonly = value;
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
				Com.CommandText = tblBlockStatusText.SQL_Delete;
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
				Com.CommandText = tblBlockStatusText.SQL_Select;
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
				Com.CommandText = tblBlockStatusText.SQL_Insert;
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
				Com.CommandText = tblBlockStatusText.SQL_Update;
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
		
		public tblBlockStatusText()
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
				SqlParmColl.Add(CommonDB.AddSqlParm("@SolitionID", SolitionID, DbType.Int64));
				SqlParmColl.Add(CommonDB.AddSqlParm("@Txt", Txt, DbType.String));
				SqlParmColl.Add(CommonDB.AddSqlParm("@Bit", Bit, DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@Decsription", Decsription, DbType.String));
				SqlParmColl.Add(CommonDB.AddSqlParm("@Readonly", Readonly, DbType.Boolean));
				return SqlParmColl.ToArray();
			}
			catch (SQLiteException Exc)
			{
				throw Exc;
			}
		}
		
		private void AddFromRecordSet(SQLiteDataReader rs)
		{
			try
			{
				// if value from the recordset, to the ID _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("ID")) == false))
				{
					ID = ((long)(Convert.ChangeType(rs["ID"], typeof(long))));
				}
				// if value from the recordset, to the SolitionID _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("SolitionID")) == false))
				{
					SolitionID = ((long)(Convert.ChangeType(rs["SolitionID"], typeof(long))));
				}
				// if value from the recordset, to the Txt _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("Txt")) == false))
				{
					Txt = ((string)(Convert.ChangeType(rs["Txt"], typeof(string))));
				}
				// if value from the recordset, to the Bit _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("Bit")) == false))
				{
					Bit = ((int)(Convert.ChangeType(rs["Bit"], typeof(int))));
				}
				// if value from the recordset, to the Decsription _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("Decsription")) == false))
				{
					Decsription = ((string)(Convert.ChangeType(rs["Decsription"], typeof(string))));
				}
				// if value from the recordset, to the Readonly _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("Readonly")) == false))
				{
					Readonly = ((bool)(Convert.ChangeType(rs["Readonly"], typeof(bool))));
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
		#endregion
	}
	
	public delegate void tblBlockStatusTextChangedEventHandler(object sender, System.EventArgs e);
	
	public partial class tblBlockStatusTextCollection : System.Collections.CollectionBase
	{
		
		/// <remarks>SQL Type:tblBlockStatusTextChangedEventHandler</remarks>
		public event tblBlockStatusTextChangedEventHandler tblBlockStatusTextChanged;
		
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
		
		[Description("Invoke the Changed event; called whenever list changes")]
		protected virtual void OntblBlockStatusTextChanged(System.EventArgs e)
		{
			if (tblBlockStatusTextChanged != null)
			{
				this.tblBlockStatusTextChanged(this, e);
			}
		}
		
		[Description("Gets a  tblBlockStatusText from the collection.")]
		public tblBlockStatusText this[int index]
		{
			get
			{
				return ((tblBlockStatusText)(List[index]));
			}
			set
			{
				List[index] = value;
				this.OntblBlockStatusTextChanged(EventArgs.Empty);
			}
		}
		
		[Description("Gets a  tblBlockStatusText from the collection.")]
		public tblBlockStatusText Get(int index)
		{
			return ((tblBlockStatusText)(List[index]));
		}
		
		[Description("Adds a new tblBlockStatusText to the collection.")]
		public int Add(tblBlockStatusText item)
		{
			int newindex = List.Add(item);
			this.OntblBlockStatusTextChanged(EventArgs.Empty);
			return newindex;
		}
		
		[Description("Removes a tblBlockStatusText from the collection.")]
		public void Remove(tblBlockStatusText item)
		{
			List.Remove(item);
			this.OntblBlockStatusTextChanged(EventArgs.Empty);
		}
		
		[Description("Inserts an tblBlockStatusText into the collection at the specified index.")]
		public void Insert(int index, tblBlockStatusText item)
		{
			List.Insert(index, item);
			this.OntblBlockStatusTextChanged(EventArgs.Empty);
		}
		
		[Description("Returns the index value of the tblBlockStatusText class in the collection.")]
		public int IndexOf(tblBlockStatusText item)
		{
			return List.IndexOf(item);
		}
		
		[Description("Returns true if the tblBlockStatusText class is present in the collection.")]
		public bool Contains(tblBlockStatusText item)
		{
			return List.Contains(item);
		}
	}
}