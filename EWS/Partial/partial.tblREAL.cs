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


namespace DCS.DCSTables
{
	
	
	public partial class tblREAL 
    {
        ///// <remarks>This _databasename represents the full INSERT INTO string for the table tblREAL.</remarks>
        //string SQL_Insert_TXT = "INSERT INTO [tblREAL] ( [UNI], [FOR], [IRL], [IRH], [LL], [HH], [L], [H]) VALUES(@SampleTime, @PointGroup, @UNI, @FOR, @IRL, @IRH, @LL, @HH, @L, @H, @RTT, @Interval) ; select last_insert_rowid();";

        ///// <remarks>This _databasename represents the full UPDATE string for the table tblREAL, with the WHERE clause.</remarks>
        //string SQL_Update_TXT = "UPDATE [tblREAL] SET  [UNI] = @UNI, [FOR] = @FOR, [IRL] = @IRL, [IRH] = @IRH, [LL] = @LL, [HH] = @HH, [L] = @L, [H] = @H,  WHERE [VarNameID]=@VarNameID ";

        /// <remarks>This _databasename represents the full SELECT string for the table tblREAL, with the WHERE clause.</remarks>
        string SQL_Select_TXT = "SELECT  [UNI], [FOR], [IRL], [IRH], [LL], [HH], [L], [H] FROM [tblREAL] WHERE [VarNameID]=@VarNameID ";

        ///// <remarks>This _databasename represents the DELETE string for the table tblREAL, with the WHERE clause.</remarks>
        //string SQL_Delete_TXT = "DELETE FROM [tblREAL] WHERE [VarNameID]=@VarNameID ";
        

        public int SelectVarID()
        {
            try
            {
                if (Common.Conn == null)
                {
                    Common.Conn = new SQLiteConnection(Common.ConnectionString);
                    Common.Conn.Open();
                }
                SQLiteCommand Com = Common.Conn.CreateCommand();
                Com.CommandText = SQL_Select_TXT;
                Com.Parameters.AddRange(GetSqlParameters());
                SQLiteDataReader rs = Com.ExecuteReader();
                for ( ; rs.Read();   )
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
	}
	
	
	public partial class tblREALCollection 
    {
        public override bool Load()
        {
            bool ret = true;


            return ret;
        }
	}
}