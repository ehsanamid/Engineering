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


    public partial class tblUser : SQLiteTable
	{
		
		#region Static SQL String Memebers
		/// <remarks>This _databasename represents the full INSERT INTO string for the table tblUser.</remarks>
		internal static string SQL_Insert = "INSERT INTO [tblUser] ([User_Name], [Description], [Pass_word], [UserGroupID], [S" +
			"tartupDisplay]) VALUES(@User_Name, @Description, @Pass_word, @UserGroupID, @Star" +
			"tupDisplay) ; select last_insert_rowid(); ";
		
		/// <remarks>This _databasename represents the full UPDATE string for the table tblUser, with the WHERE clause.</remarks>
		internal static string SQL_Update = "UPDATE [tblUser] SET [User_Name] = @User_Name, [Description] = @Description, [Pas" +
			"s_word] = @Pass_word, [UserGroupID] = @UserGroupID, [StartupDisplay] = @StartupD" +
			"isplay WHERE [UserNameID]=@UserNameID ";
		
		/// <remarks>This _databasename represents the full SELECT string for the table tblUser, with the WHERE clause.</remarks>
		internal static string SQL_Select = "SELECT [User_Name], [Description], [Pass_word], [UserGroupID], [StartupDisplay] F" +
			"ROM [tblUser] WHERE [UserNameID]=@UserNameID ";
		
		/// <remarks>This _databasename represents the DELETE string for the table tblUser, with the WHERE clause.</remarks>
		internal static string SQL_Delete = "DELETE FROM [tblUser] WHERE [UserNameID]=@UserNameID ";
		#endregion
		
		#region Tables Memebers
		/// <remarks>SQL Type:System.Int64</remarks>
		private long _UserNameID = -1;
		
		[DisplayName("User Name ID")]
		[Category("Primary Key")]
		public long UserNameID
		{
			get
			{
				return _UserNameID;
			}
			set
			{
				_UserNameID = value;
			}
		}
		
		/// <remarks>SQL Type:System.String</remarks>
		private string _User_Name = "";
		
		[DisplayName("User_Name")]
		[Category("Column")]
		public string User_Name
		{
			get
			{
				return _User_Name;
			}
			set
			{
				_User_Name = value;
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
		
		/// <remarks>SQL Type:System.String</remarks>
		private string _Pass_word = "";
		
		[DisplayName("Pass_word")]
		[Category("Column")]
		public string Pass_word
		{
			get
			{
				return _Pass_word;
			}
			set
			{
				_Pass_word = value;
			}
		}
		
		/// <remarks>SQL Type:System.Int64</remarks>
		private long _UserGroupID = -1;
		
		[DisplayName("User Group ID")]
		[Category("Column")]
		public long UserGroupID
		{
			get
			{
				return _UserGroupID;
			}
			set
			{
				_UserGroupID = value;
			}
		}
		
		/// <remarks>SQL Type:System.Int32</remarks>
		private int _StartupDisplay;
		
		[DisplayName("Startup Display")]
		[Category("Column")]
		public int StartupDisplay
		{
			get
			{
				return _StartupDisplay;
			}
			set
			{
				_StartupDisplay = value;
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
				Com.CommandText = tblUser.SQL_Delete;
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
				Com.CommandText = tblUser.SQL_Select;
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
				Com.CommandText = tblUser.SQL_Insert;
				Com.Parameters.AddRange(GetSqlParameters());
				UserNameID = ((long)(Convert.ToInt64(Com.ExecuteScalar())));
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
				Com.CommandText = tblUser.SQL_Update;
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
		
		public tblUser()
		{
		}
		#endregion
		
		#region Private Methods
		private SQLiteParameter[] GetSqlParameters()
		{
			List<SQLiteParameter> SqlParmColl = new List<SQLiteParameter>();
			try
			{
				SqlParmColl.Add(CommonDB.AddSqlParm("@UserNameID", UserNameID, DbType.Int64));
				SqlParmColl.Add(CommonDB.AddSqlParm("@User_Name", User_Name, DbType.String));
				SqlParmColl.Add(CommonDB.AddSqlParm("@Description", Description, DbType.String));
				SqlParmColl.Add(CommonDB.AddSqlParm("@Pass_word", Pass_word, DbType.String));
				SqlParmColl.Add(CommonDB.AddSqlParm("@UserGroupID", UserGroupID, DbType.Int64));
				SqlParmColl.Add(CommonDB.AddSqlParm("@StartupDisplay", StartupDisplay, DbType.Int32));
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
				// if value from the recordset, to the UserNameID _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("UserNameID")) == false))
				{
					UserNameID = ((long)(Convert.ChangeType(rs["UserNameID"], typeof(long))));
				}
				// if value from the recordset, to the User_Name _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("User_Name")) == false))
				{
					User_Name = ((string)(Convert.ChangeType(rs["User_Name"], typeof(string))));
				}
				// if value from the recordset, to the Description _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("Description")) == false))
				{
					Description = ((string)(Convert.ChangeType(rs["Description"], typeof(string))));
				}
				// if value from the recordset, to the Pass_word _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("Pass_word")) == false))
				{
					Pass_word = ((string)(Convert.ChangeType(rs["Pass_word"], typeof(string))));
				}
				// if value from the recordset, to the UserGroupID _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("UserGroupID")) == false))
				{
					UserGroupID = ((long)(Convert.ChangeType(rs["UserGroupID"], typeof(long))));
				}
				// if value from the recordset, to the StartupDisplay _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("StartupDisplay")) == false))
				{
					StartupDisplay = ((int)(Convert.ChangeType(rs["StartupDisplay"], typeof(int))));
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
				i = this.ColumnExistInHeader("User_Name");
				if ((i >= 0))
				{
					User_Name = ((string)(Convert.ChangeType(_strs[i], typeof(string))));
				}
				i = this.ColumnExistInHeader("Description");
				if ((i >= 0))
				{
					Description = ((string)(Convert.ChangeType(_strs[i], typeof(string))));
				}
				i = this.ColumnExistInHeader("Pass_word");
				if ((i >= 0))
				{
					Pass_word = ((string)(Convert.ChangeType(_strs[i], typeof(string))));
				}
				i = this.ColumnExistInHeader("UserGroupID");
				if ((i >= 0))
				{
					UserGroupID = ((long)(Convert.ChangeType(_strs[i], typeof(long))));
				}
				i = this.ColumnExistInHeader("StartupDisplay");
				if ((i >= 0))
				{
					StartupDisplay = ((int)(Convert.ChangeType(_strs[i], typeof(int))));
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
	
	public delegate void tblUserChangedEventHandler(object sender, System.EventArgs e);
	
	public partial class tblUserCollection : SQLiteTableCollection
	{
		
		/// <remarks>SQL Type:tblUserChangedEventHandler</remarks>
		public event tblUserChangedEventHandler tblUserChanged;
		
		[Description("Constructor")]
		public tblUserCollection()
		{
		}
		
		[Description("Invoke the Changed event; called whenever list changes")]
		protected virtual void OntblUserChanged(System.EventArgs e)
		{
			if (tblUserChanged != null)
			{
				this.tblUserChanged(this, e);
			}
		}
		
		[Description("Gets a  tblUser from the collection.")]
		public tblUser this[int index]
		{
			get
			{
				return ((tblUser)(List[index]));
			}
			set
			{
				List[index] = value;
				this.OntblUserChanged(EventArgs.Empty);
			}
		}
		
		[Description("Gets a  tblUser from the collection.")]
		public tblUser Get(int index)
		{
			return ((tblUser)(List[index]));
		}
		
		[Description("Adds a new tblUser to the collection.")]
		public void Add(tblUser item)
		{
			List.Add(item);
			this.OntblUserChanged(EventArgs.Empty);
		}
		
		[Description("Removes a tblUser from the collection.")]
		public void Remove(tblUser item)
		{
			List.Remove(item);
			this.OntblUserChanged(EventArgs.Empty);
		}
		
		[Description("Inserts an tblUser into the collection at the specified index.")]
		public void Insert(int index, tblUser item)
		{
			List.Insert(index, item);
			this.OntblUserChanged(EventArgs.Empty);
		}
		
		[Description("Returns the index value of the tblUser class in the collection.")]
		public int IndexOf(tblUser item)
		{
			return List.IndexOf(item);
		}
		
		[Description("Returns true if the tblUser class is present in the collection.")]
		public bool Contains(tblUser item)
		{
			return List.Contains(item);
		}
	}
}
