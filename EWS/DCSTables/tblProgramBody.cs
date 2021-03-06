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
	
	
	public partial class tblProgramBody : Object
	{
		
		#region Static SQL String Memebers
		/// <remarks>This _databasename represents the full INSERT INTO string for the table tblProgramBody.</remarks>
		internal static string SQL_Insert = "INSERT INTO [tblProgramBody] ([VariableID], [PouID]) VALUES(@VariableID, @PouID) " +
			"; select last_insert_rowid(); ";
		
		/// <remarks>This _databasename represents the full UPDATE string for the table tblProgramBody, with the WHERE clause.</remarks>
		internal static string SQL_Update = "UPDATE [tblProgramBody] SET [VariableID] = @VariableID, [PouID] = @PouID WHERE [P" +
			"rogramBodyID]=@ProgramBodyID ";
		
		/// <remarks>This _databasename represents the full SELECT string for the table tblProgramBody, with the WHERE clause.</remarks>
		internal static string SQL_Select = "SELECT [VariableID], [PouID] FROM [tblProgramBody] WHERE [ProgramBodyID]=@Program" +
			"BodyID ";
		
		/// <remarks>This _databasename represents the DELETE string for the table tblProgramBody, with the WHERE clause.</remarks>
		internal static string SQL_Delete = "DELETE FROM [tblProgramBody] WHERE [ProgramBodyID]=@ProgramBodyID ";
		#endregion
		
		#region Tables Memebers
		/// <remarks>SQL Type:System.Int64</remarks>
		private long _VariableID;
		
		[DisplayName("Variable ID")]
		[Category("Foreign Key")]
		public long VariableID
		{
			get
			{
				return _VariableID;
			}
			set
			{
				_VariableID = value;
			}
		}
		
		/// <remarks>SQL Type:System.Int64</remarks>
		private long _PouID;
		
		[DisplayName("Pou ID")]
		[Category("Foreign Key")]
		public long PouID
		{
			get
			{
				return _PouID;
			}
			set
			{
				_PouID = value;
			}
		}
		
		/// <remarks>SQL Type:System.Int64</remarks>
		private long _ProgramBodyID;
		
		[DisplayName("Program Body ID")]
		[Category("Primary Key")]
		public long ProgramBodyID
		{
			get
			{
				return _ProgramBodyID;
			}
			set
			{
				_ProgramBodyID = value;
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
		
		/// <remarks>Represents the foreign key object</remarks>
		private tblPou _pouID_tblPou;
		
		[Description("Represents the foreign key object of the type pouID")]
		public tblPou m_pouID_tblPou
		{
			get
			{
				return _pouID_tblPou;
			}
			set
			{
				_pouID_tblPou = value;
			}
		}
		#endregion
		
		#region Public Methods
		public int Delete()
		{
			try
			{
				SQLiteConnection Conn = new SQLiteConnection(Common.ConnectionString);
				SQLiteCommand Com = Conn.CreateCommand();
				SQLiteCommand ComSync = Conn.CreateCommand();
				Com.CommandText = tblProgramBody.SQL_Delete;
				ComSync.CommandText = "PRAGMA foreign_keys=ON";
				Com.Parameters.AddRange(GetSqlParameters());
				Conn.Open();
				ComSync.ExecuteNonQuery();
				int rowseffected = Com.ExecuteNonQuery();
				Conn.Close();
				ComSync.Dispose();
				Com.Dispose();
				Conn.Dispose();
				return rowseffected;
			}
			catch (System.Exception )
			{
				throw;
			}
		}
		
		public void Select()
		{
			try
			{
				SQLiteConnection Conn = new SQLiteConnection(Common.ConnectionString);
				SQLiteCommand Com = Conn.CreateCommand();
				Com.CommandText = tblProgramBody.SQL_Select;
				Com.Parameters.AddRange(GetSqlParameters());
				Conn.Open();
				SQLiteDataReader rs = Com.ExecuteReader();
				for (
				; rs.Read(); 
				)
				{
					AddFromRecordSet(rs);
				}
				rs.Close();
				Conn.Close();
				rs.Dispose();
				Com.Dispose();
				Conn.Dispose();
			}
			catch (System.Exception )
			{
				throw;
			}
		}
		
		public int Insert()
		{
			try
			{
				SQLiteConnection Conn = new SQLiteConnection(Common.ConnectionString);
				SQLiteCommand Com = Conn.CreateCommand();
				Com.CommandText = tblProgramBody.SQL_Insert;
				Com.Parameters.AddRange(GetSqlParameters());
				Conn.Open();
				ProgramBodyID = ((long)(Convert.ToInt64(Com.ExecuteScalar())));
				Conn.Close();
				Com.Dispose();
				Conn.Dispose();
				return 0;
			}
			catch (SqlException ex)
			{
				throw;
			}
		}
		
		public int Update()
		{
			try
			{
				SQLiteConnection Conn = new SQLiteConnection(Common.ConnectionString);
				SQLiteCommand Com = Conn.CreateCommand();
				Com.CommandText = tblProgramBody.SQL_Update;
				Com.Parameters.AddRange(GetSqlParameters());
				Conn.Open();
				int rowseffected = Com.ExecuteNonQuery();
				Conn.Close();
				Com.Dispose();
				Conn.Dispose();
				return rowseffected;
			}
			catch (System.Exception )
			{
				throw;
			}
		}
		
		public tblProgramBody()
		{
		}
		#endregion
		
		#region Private Methods
		private SQLiteParameter[] GetSqlParameters()
		{
			List<SQLiteParameter> SqlParmColl = new List<SQLiteParameter>();
			try
			{
				SqlParmColl.Add(CommonDB.AddSqlParm("@VariableID", VariableID, DbType.Int64));
				SqlParmColl.Add(CommonDB.AddSqlParm("@PouID", PouID, DbType.Int64));
				SqlParmColl.Add(CommonDB.AddSqlParm("@ProgramBodyID", ProgramBodyID, DbType.Int64));
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
				// if value from the recordset, to the VariableID _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("VariableID")) == false))
				{
					VariableID = ((long)(Convert.ChangeType(rs["VariableID"], typeof(long))));
				}
				// if value from the recordset, to the PouID _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("PouID")) == false))
				{
					PouID = ((long)(Convert.ChangeType(rs["PouID"], typeof(long))));
				}
				// if value from the recordset, to the ProgramBodyID _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("ProgramBodyID")) == false))
				{
					ProgramBodyID = ((long)(Convert.ChangeType(rs["ProgramBodyID"], typeof(long))));
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
	
	public delegate void tblProgramBodyChangedEventHandler(object sender, System.EventArgs e);
	
	public partial class tblProgramBodyCollection : System.Collections.CollectionBase
	{
		
		/// <remarks>SQL Type:tblProgramBodyChangedEventHandler</remarks>
		public event tblProgramBodyChangedEventHandler tblProgramBodyChanged;
		
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
		
		/// <remarks>Represents the foreign key object</remarks>
		private tblPou _pouID_tblPou;
		
		[Description("Represents the foreign key object of the type pouID")]
		public tblPou m_pouID_tblPou
		{
			get
			{
				return _pouID_tblPou;
			}
			set
			{
				_pouID_tblPou = value;
			}
		}
		
		[Description("Invoke the Changed event; called whenever list changes")]
		protected virtual void OntblProgramBodyChanged(System.EventArgs e)
		{
			if (tblProgramBodyChanged != null)
			{
				this.tblProgramBodyChanged(this, e);
			}
		}
		
		[Description("Gets a  tblProgramBody from the collection.")]
		public tblProgramBody this[int index]
		{
			get
			{
				return ((tblProgramBody)(List[index]));
			}
			set
			{
				List[index] = value;
				this.OntblProgramBodyChanged(EventArgs.Empty);
			}
		}
		
		[Description("Gets a  tblProgramBody from the collection.")]
		public tblProgramBody Get(int index)
		{
			return ((tblProgramBody)(List[index]));
		}
		
		[Description("Adds a new tblProgramBody to the collection.")]
		public int Add(tblProgramBody item)
		{
			int newindex = List.Add(item);
			this.OntblProgramBodyChanged(EventArgs.Empty);
			return newindex;
		}
		
		[Description("Removes a tblProgramBody from the collection.")]
		public void Remove(tblProgramBody item)
		{
			List.Remove(item);
			this.OntblProgramBodyChanged(EventArgs.Empty);
		}
		
		[Description("Inserts an tblProgramBody into the collection at the specified index.")]
		public void Insert(int index, tblProgramBody item)
		{
			List.Insert(index, item);
			this.OntblProgramBodyChanged(EventArgs.Empty);
		}
		
		[Description("Returns the index value of the tblProgramBody class in the collection.")]
		public int IndexOf(tblProgramBody item)
		{
			return List.IndexOf(item);
		}
		
		[Description("Returns true if the tblProgramBody class is present in the collection.")]
		public bool Contains(tblProgramBody item)
		{
			return List.Contains(item);
		}
	}
}
