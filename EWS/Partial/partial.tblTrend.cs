
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Data;
	using System.Data.SQLite;
	using System.Text;
namespace DCS.DCSTables
{

    public partial class tblTrend 
	{
       
	}

    public partial class tblTrendCollection 
	{

        

        public override bool Load()
        {
            bool ret = true;
            List<long> idlist = new List<long>();
            if (Common.Conn == null)
            {
                Common.Conn = new SQLiteConnection(Common.ConnectionString);
                Common.Conn.Open();
            }
            SQLiteDataReader myReader = null;
            SQLiteCommand myCommand = new SQLiteCommand();
            

            try
            {
                myReader = null;

                myCommand.CommandText = @"SELECT * FROM [tblTrend]  WHERE [DisplayID]= " + m_DisplayID_tblDisplay.DisplayID + " order by oIndex;";

                myCommand.Connection = Common.Conn;
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    idlist.Add(myReader.GetInt64(myReader.GetOrdinal("ID")));
                }

                myReader.Close();
                myCommand.Dispose();

                foreach (long id in idlist)// (int i = 0; i < count ; i++)
                {
                    tblTrend tbltrend = new tblTrend();
                    tbltrend.ID = id;
                    tbltrend.m_DisplayID_tblDisplay = this.m_DisplayID_tblDisplay;
                    tbltrend.Select();

                    Add(tbltrend);
                }

            }
            catch (SQLiteException ae)
            {
                System.Windows.Forms.MessageBox.Show(ae.Message);
                return false;
            }



            return ret;
        }

        public bool RemoveFromTable()
        {
            try
            {
                if (Common.Conn == null)
                {
                    Common.Conn = new SQLiteConnection(Common.ConnectionString);
                    Common.Conn.Open();
                }
                SQLiteCommand Com = Common.Conn.CreateCommand(); //SQLiteCommand Com = Conn.CreateCommand();
                SQLiteCommand ComSync = Common.Conn.CreateCommand();
                Com.CommandText = @"DELETE FROM [tblTrend] WHERE  WHERE [DisplayID]= " + m_DisplayID_tblDisplay.DisplayID + ";";
                ComSync.CommandText = "PRAGMA foreign_keys=ON";

                //Conn.Open();
                ComSync.ExecuteNonQuery();
                int rowseffected = Com.ExecuteNonQuery();
                //Conn.Close();
                ComSync.Dispose();
                Com.Dispose();
                //Conn.Dispose();
                return true;

            }
            catch (SQLiteException ae)
            {
                System.Windows.Forms.MessageBox.Show(ae.Message);
                return false;
            }
        }
	}
	
	
}
