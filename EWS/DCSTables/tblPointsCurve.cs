//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
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
using System.Text;


namespace DCSTables
{
	
	
	public partial class tblPointsCurve : Object
	{
		
		#region Static SQL String Memebers
		/// <remarks>This _databasename represents the full INSERT INTO string for the table tblPointsCurve.</remarks>
		internal static string SQL_Insert = "INSERT INTO [tblPointsCurve] ([CurveID], [oIndex], [PtX], [PtY]) VALUES(@CurveID," +
			" @oIndex, @PtX, @PtY) ; select last_insert_rowid(); ";
		
		/// <remarks>This _databasename represents the full UPDATE string for the table tblPointsCurve, with the WHERE clause.</remarks>
		internal static string SQL_Update = "UPDATE [tblPointsCurve] SET [CurveID] = @CurveID, [oIndex] = @oIndex, [PtX] = @Pt" +
			"X, [PtY] = @PtY WHERE [PointsCurveID]=@PointsCurveID ";
		
		/// <remarks>This _databasename represents the full SELECT string for the table tblPointsCurve, with the WHERE clause.</remarks>
		internal static string SQL_Select = "SELECT [CurveID], [oIndex], [PtX], [PtY] FROM [tblPointsCurve] WHERE [PointsCurve" +
			"ID]=@PointsCurveID ";
		
		/// <remarks>This _databasename represents the DELETE string for the table tblPointsCurve, with the WHERE clause.</remarks>
		internal static string SQL_Delete = "DELETE FROM [tblPointsCurve] WHERE [PointsCurveID]=@PointsCurveID ";
		#endregion
		
		#region Tables Memebers
		/// <remarks>SQL Type:System.Int64</remarks>
		private long _PointsCurveID;
		
		[DisplayName("Points Curve ID")]
		[Category("Primary Key")]
		public long PointsCurveID
		{
			get
			{
				return _PointsCurveID;
			}
			set
			{
				_PointsCurveID = value;
			}
		}
		
		/// <remarks>SQL Type:System.Int64</remarks>
		private long _CurveID;
		
		[DisplayName("Curve ID")]
		[Category("Foreign Key")]
		public long CurveID
		{
			get
			{
				return _CurveID;
			}
			set
			{
				_CurveID = value;
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
		private int _PtX;
		
		[DisplayName("Pt X")]
		[Category("Column")]
		public int PtX
		{
			get
			{
				return _PtX;
			}
			set
			{
				_PtX = value;
			}
		}
		
		/// <remarks>SQL Type:System.Int32</remarks>
		private int _PtY;
		
		[DisplayName("Pt Y")]
		[Category("Column")]
		public int PtY
		{
			get
			{
				return _PtY;
			}
			set
			{
				_PtY = value;
			}
		}
		#endregion
		
		#region Related Objects
		/// <remarks>Represents the foreign key object</remarks>
		private tblCurve _CurveID_tblCurve;
		
		[Description("Represents the foreign key object of the type CurveID")]
		public tblCurve m_CurveID_tblCurve
		{
			get
			{
				return _CurveID_tblCurve;
			}
			set
			{
				_CurveID_tblCurve = value;
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
				Com.CommandText = tblPointsCurve.SQL_Delete;
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
				Com.CommandText = tblPointsCurve.SQL_Select;
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
				Com.CommandText = tblPointsCurve.SQL_Insert;
				Com.Parameters.AddRange(GetSqlParameters());
				Conn.Open();
				PointsCurveID = ((long)(Convert.ToInt64(Com.ExecuteScalar())));
				Conn.Close();
				Com.Dispose();
				Conn.Dispose();
				return 0;
			}
			catch (System.Exception )
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
				Com.CommandText = tblPointsCurve.SQL_Update;
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
		
		public tblPointsCurve()
		{
		}
		#endregion
		
		#region Private Methods
		private SQLiteParameter[] GetSqlParameters()
		{
			List<SQLiteParameter> SqlParmColl = new List<SQLiteParameter>();
			try
			{
				SqlParmColl.Add(CommonDB.AddSqlParm("@PointsCurveID", PointsCurveID, DbType.Int64));
				SqlParmColl.Add(CommonDB.AddSqlParm("@CurveID", CurveID, DbType.Int64));
				SqlParmColl.Add(CommonDB.AddSqlParm("@oIndex", oIndex, DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@PtX", PtX, DbType.Int32));
				SqlParmColl.Add(CommonDB.AddSqlParm("@PtY", PtY, DbType.Int32));
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
				// if value from the recordset, to the PointsCurveID _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("PointsCurveID")) == false))
				{
					PointsCurveID = ((long)(rs["PointsCurveID"]));
				}
				// if value from the recordset, to the CurveID _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("CurveID")) == false))
				{
					CurveID = ((long)(rs["CurveID"]));
				}
				// if value from the recordset, to the oIndex _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("oIndex")) == false))
				{
					oIndex = ((int)(rs["oIndex"]));
				}
				// if value from the recordset, to the PtX _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("PtX")) == false))
				{
					PtX = ((int)(rs["PtX"]));
				}
				// if value from the recordset, to the PtY _databasename is NOT null then set the value.
				if ((rs.IsDBNull(rs.GetOrdinal("PtY")) == false))
				{
					PtY = ((int)(rs["PtY"]));
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
	
	public delegate void tblPointsCurveChangedEventHandler(object sender, System.EventArgs e);
	
	public partial class tblPointsCurveCollection : System.Collections.CollectionBase
	{
		
		/// <remarks>SQL Type:tblPointsCurveChangedEventHandler</remarks>
		public event tblPointsCurveChangedEventHandler tblPointsCurveChanged;
		
		/// <remarks>Represents the foreign key object</remarks>
		private tblCurve _CurveID_tblCurve;
		
		[Description("Represents the foreign key object of the type CurveID")]
		public tblCurve m_CurveID_tblCurve
		{
			get
			{
				return _CurveID_tblCurve;
			}
			set
			{
				_CurveID_tblCurve = value;
			}
		}
		
		[Description("Invoke the Changed event; called whenever list changes")]
		protected virtual void OntblPointsCurveChanged(System.EventArgs e)
		{
			if (tblPointsCurveChanged != null)
			{
				this.tblPointsCurveChanged(this, e);
			}
		}
		
		[Description("Gets a  tblPointsCurve from the collection.")]
		public tblPointsCurve this[int index]
		{
			get
			{
				return ((tblPointsCurve)(List[index]));
			}
			set
			{
				List[index] = value;
				this.OntblPointsCurveChanged(EventArgs.Empty);
			}
		}
		
		[Description("Gets a  tblPointsCurve from the collection.")]
		public tblPointsCurve Get(int index)
		{
			return ((tblPointsCurve)(List[index]));
		}
		
		[Description("Adds a new tblPointsCurve to the collection.")]
		public int Add(tblPointsCurve item)
		{
			int newindex = List.Add(item);
			this.OntblPointsCurveChanged(EventArgs.Empty);
			return newindex;
		}
		
		[Description("Removes a tblPointsCurve from the collection.")]
		public void Remove(tblPointsCurve item)
		{
			List.Remove(item);
			this.OntblPointsCurveChanged(EventArgs.Empty);
		}
		
		[Description("Inserts an tblPointsCurve into the collection at the specified index.")]
		public void Insert(int index, tblPointsCurve item)
		{
			List.Insert(index, item);
			this.OntblPointsCurveChanged(EventArgs.Empty);
		}
		
		[Description("Returns the index value of the tblPointsCurve class in the collection.")]
		public int IndexOf(tblPointsCurve item)
		{
			return List.IndexOf(item);
		}
		
		[Description("Returns true if the tblPointsCurve class is present in the collection.")]
		public bool Contains(tblPointsCurve item)
		{
			return List.Contains(item);
		}
	}
}