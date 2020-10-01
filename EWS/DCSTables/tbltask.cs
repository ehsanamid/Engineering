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


namespace DCSTables
{
	
	
	public partial class tbltask : Object
	{
		
		#region Static SQL String Memebers
		/// <remarks>This _databasename represents the full INSERT INTO string for the table tbltask.</remarks>
		internal static string SQL_Insert = "INSERT INTO [tbltask] ([TaskName], [ControllerID], [Description], [oIndex], [Inte" +
			"rval], [Triggering], [Signal]) VALUES(@TaskName, @ControllerID, @Description, @o" +
			"Index, @Interval, @Triggering, @Signal) ; select last_insert_rowid(); ";
		
		/// <remarks>This _databasename represents the full UPDATE string for the table tbltask, with the WHERE clause.</remarks>
		internal static string SQL_Update = "UPDATE [tbltask] SET [TaskName] = @TaskName, [ControllerID] = @ControllerID, [Des" +
			"cription] = @Description, [oIndex] = @oIndex, [Interval] = @Interval, [Triggerin" +
			"g] = @Triggering, [Signal] = @Signal WHERE [taskID]=@taskID ";
		
		/// <remarks>This _databasename represents the full SELECT string for the table tbltask, with the WHERE clause.</remarks>
		internal static string SQL_Select = "SELECT [TaskName], [ControllerID], [Description], [oIndex], [Interval], [Triggeri" +
			"ng], [Signal] FROM [tbltask] WHERE [taskID]=@taskID ";
		
		/// <remarks>This _databasename represents the DELETE string for the table tbltask, with the WHERE clause.</remarks>
		internal static string SQL_Delete = "DELETE FROM [tbltask] WHERE [taskID]=@taskID ";
		#endregion
		
		#region Tables Memebers
		/// <remarks>SQL Type:System.String</remarks>
		private string _TaskName;
		
		[DisplayName("Task Name")]
		[Category("Column")]
		public string TaskName
		{
			get
			{
				return _TaskName;
			}
			set
			{
				_TaskName = value;
			}
		}
		
		/// <remarks>SQL Type:System.Int64</remarks>
		private long _taskID;
		
		[DisplayName("task ID")]
		[Category("Primary Key")]
		public long taskID
		{
			get
			{
				return _taskID;
			}
			set
			{
				_taskID = value;
			}
		}
		
		/// <remarks>SQL Type:System.Int64</remarks>
		private long _ControllerID;
		
		[DisplayName("Controller ID")]
		[Category("Foreign Key")]
		public long ControllerID
		{
			get
			{
				return _ControllerID;
			}
			set
			{
				_ControllerID = value;
			}
		}
		
		/// <remarks>SQL Type:System.String</remarks>
		private string _Description;
		
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
		
		/// <remarks>SQL Type:System.Int32</remarks>
		private int _Interval;
		
		[DisplayName("Interval")]
		[Category("Column")]
		public int Interval
		{
			get
			{
				return _Interval;
			}
			set
			{
				_Interval = value;
			}
		}
		
		/// <remarks>SQL Type:System.Int32</remarks>
		private int _Triggering;
		
		[DisplayName("Triggering")]
		[Category("Column")]
		public int Triggering
		{
			get
			{
				return _Triggering;
			}
			set
			{
				_Triggering = value;
			}
		}
		
		/// <remarks>SQL Type:System.Int32</remarks>
		private int _Signal;
		
		[DisplayName("Signal")]
		[Category("Column")]
		public int Signal
		{
			get
			{
				return _Signal;
			}
			set
			{
				_Signal = value;
			}
		}
		#endregion
		
		#region Related Objects
		/// <remarks>Represents the foreign key object</remarks>
		private tblController _ControllerID_tblController;
		
		[Description("Represents the foreign key object of the type ControllerID")]
		public tblController m_ControllerID_tblController
		{
			get
			{
				return _ControllerID_tblController;
			}
			set
			{
				_ControllerID_tblController = value;
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
				Com.CommandText = tbltask.SQL_Delete;
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
				Com.CommandText = tbltask.SQL_Select;
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
				Com.CommandText = tbltask.SQL_Insert;
				Com.Parameters.AddRange(GetSqlParameters());
				Conn.Open();
				taskID = ((long)(Convert.ToInt64(Com.ExecuteScalar())));
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
				Com.CommandText = tbltask.SQL_Update;
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
		
		public tbltask()
		{
		}
		#endregion
		
		#region Private Methods
		private SQLiteParameter[] GetSqlParameters()
		{
			List<SQLiteParameter> SqlParmColl = new List<SQLiteParameter>();
			try
			{
				SqlParmColl.Add(CommonDB.AddSqlParm("@TaskName", TaskName, DbType.String));
				SqlParmColl.Add(CommonDB.AddSqlParm("@taskID", taskID, DbType.Int64));
				SqlParmColl.Add(CommonDB.AddSqlParm("@ControllerID", ControllerID, DbType.Int64));
				SqlParmColl.Add(CommonDB.AddSqlParm("@Description", Description, DbType.String));
				SqlParmColl.Add(CommonDB.AddSqlParm("@oIndex", oIndex, DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@Interval", Interval, DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@Triggering", Triggering, DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@Signal", Signal, DbType.Int32));
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
				// if value from the recordset, to the TaskName _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("TaskName")) == false))
				{
					TaskName = ((string)(Convert.ChangeType(rs["TaskName"], typeof(string))));
				}
				// if value from the recordset, to the taskID _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("taskID")) == false))
				{
					taskID = ((long)(Convert.ChangeType(rs["taskID"], typeof(long))));
				}
				// if value from the recordset, to the ControllerID _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("ControllerID")) == false))
				{
					ControllerID = ((long)(Convert.ChangeType(rs["ControllerID"], typeof(long))));
				}
				// if value from the recordset, to the Description _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("Description")) == false))
				{
					Description = ((string)(Convert.ChangeType(rs["Description"], typeof(string))));
				}
				// if value from the recordset, to the oIndex _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("oIndex")) == false))
				{
					oIndex = ((int)(Convert.ChangeType(rs["oIndex"], typeof(int))));
				}
				// if value from the recordset, to the Interval _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("Interval")) == false))
				{
					Interval = ((int)(Convert.ChangeType(rs["Interval"], typeof(int))));
				}
				// if value from the recordset, to the Triggering _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("Triggering")) == false))
				{
					Triggering = ((int)(Convert.ChangeType(rs["Triggering"], typeof(int))));
				}
				// if value from the recordset, to the Signal _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("Signal")) == false))
				{
					Signal = ((int)(Convert.ChangeType(rs["Signal"], typeof(int))));
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
	
	public delegate void tbltaskChangedEventHandler(object sender, System.EventArgs e);
	
	public partial class tbltaskCollection : System.Collections.CollectionBase
	{
		
		/// <remarks>SQL Type:tbltaskChangedEventHandler</remarks>
		public event tbltaskChangedEventHandler tbltaskChanged;
		
		/// <remarks>Represents the foreign key object</remarks>
		private tblController _ControllerID_tblController;
		
		[Description("Represents the foreign key object of the type ControllerID")]
		public tblController m_ControllerID_tblController
		{
			get
			{
				return _ControllerID_tblController;
			}
			set
			{
				_ControllerID_tblController = value;
			}
		}
		
		[Description("Invoke the Changed event; called whenever list changes")]
		protected virtual void OntbltaskChanged(System.EventArgs e)
		{
			if (tbltaskChanged != null)
			{
				this.tbltaskChanged(this, e);
			}
		}
		
		[Description("Gets a  tbltask from the collection.")]
		public tbltask this[int index]
		{
			get
			{
				return ((tbltask)(List[index]));
			}
			set
			{
				List[index] = value;
				this.OntbltaskChanged(EventArgs.Empty);
			}
		}
		
		[Description("Gets a  tbltask from the collection.")]
		public tbltask Get(int index)
		{
			return ((tbltask)(List[index]));
		}
		
		[Description("Adds a new tbltask to the collection.")]
		public int Add(tbltask item)
		{
			int newindex = List.Add(item);
			this.OntbltaskChanged(EventArgs.Empty);
			return newindex;
		}
		
		[Description("Removes a tbltask from the collection.")]
		public void Remove(tbltask item)
		{
			List.Remove(item);
			this.OntbltaskChanged(EventArgs.Empty);
		}
		
		[Description("Inserts an tbltask into the collection at the specified index.")]
		public void Insert(int index, tbltask item)
		{
			List.Insert(index, item);
			this.OntbltaskChanged(EventArgs.Empty);
		}
		
		[Description("Returns the index value of the tbltask class in the collection.")]
		public int IndexOf(tbltask item)
		{
			return List.IndexOf(item);
		}
		
		[Description("Returns true if the tbltask class is present in the collection.")]
		public bool Contains(tbltask item)
		{
			return List.Contains(item);
		}
	}
}