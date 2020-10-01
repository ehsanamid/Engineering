using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.IO;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.ComponentModel;
using System.Data;


namespace DCS.DCSTables
{
    public class CommonDB
    {
        public static SQLiteParameter AddSqlParm(string ParmName, object Value, DbType Sqltype)
        {

            return AddSqlParm(ParmName, Value, Sqltype, -1);
        }

        public static SQLiteParameter AddSqlParm(string ParmName, object Value, DbType Sqltype, int SqlSize)
        {

            SQLiteParameter genSqlData;
            if ((SqlSize == -1))
                genSqlData = new SQLiteParameter(ParmName, Sqltype);
            else
                genSqlData = new SQLiteParameter(ParmName, Sqltype, SqlSize);
            if ((Value == null))
                genSqlData.Value = DBNull.Value;
            else
                genSqlData.Value = Value;
            return genSqlData;
        }
        public enum SQL_String : int
        {
            SQL_Select = 0,
            SQL_Insert,
            SQL_Update,
            SQL_Delete,
            SQL_Rename
        }
    }
    public class sqlite2class
    {
        
        public static void getlietoftables()
        {
            //string ss;
            List<string> tablelist = new List<string>();
            try
            {
                //string name;
                //string type;
                //bool pk;
                SQLiteConnection Conn = new SQLiteConnection(Common.ConnectionString);
                SQLiteCommand Com1 = Conn.CreateCommand();
                SQLiteCommand Com = Conn.CreateCommand();
                Com1.CommandText = "PRAGMA foreign_keys=ON";
                Com.CommandText = "delete from tblcontroller where CONTROLLERID = 65;";

                Conn.Open();
                Com1.ExecuteReader();
                Com.ExecuteReader();
               
               
                Conn.Close();
               
                Com.Dispose();
                Conn.Dispose();
                //SQLiteConnection Conn = new SQLiteConnection(Common.ConnectionString);
                //SQLiteCommand Com = Conn.CreateCommand();
                //Com.CommandText = "SELECT name FROM sqlite_master WHERE type = 'table'";

                //Conn.Open();
                //SQLiteDataReader rs = Com.ExecuteReader();
                //while (rs.Read())
                //{
                //    if ((rs.IsDBNull(rs.GetOrdinal("name")) == false))
                //    {
                //        tablelist.Add(rs.GetString(rs.GetOrdinal("name")));
                //    }
                //}
                //rs.Close();
                //Conn.Close();
                //rs.Dispose();
                //Com.Dispose();
                //Conn.Dispose();
                //foreach (string id in tablelist)// (int i = 0; i < count ; i++)
                //{
                    
                //}
                //string name;
                //string type;
                //bool pk;
                //SQLiteConnection Conn = new SQLiteConnection(Common.ConnectionString);
                //SQLiteCommand Com = Conn.CreateCommand();
                //Com.CommandText = "PRAGMA table_info('tblController')";

                //Conn.Open();
                //SQLiteDataReader rs = Com.ExecuteReader();
                //while (rs.Read())
                //{
                //    if ((rs.IsDBNull(rs.GetOrdinal("name")) == false))
                //    {
                //        name = rs.GetString(rs.GetOrdinal("name"));
                //        type = rs.GetString(rs.GetOrdinal("type"));
                //        pk = rs.GetBoolean(rs.GetOrdinal("pk"));
                //    }
                //}
                //rs.Close();
                //Conn.Close();
                //rs.Dispose();
                //Com.Dispose();
                //Conn.Dispose();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

    }
}
