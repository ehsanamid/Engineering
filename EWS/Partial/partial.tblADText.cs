
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Data;
	using System.Data.SQLite;
	using System.Text;
namespace DCS.DCSTables
{

    public partial class tblADText 
	{
        
        
	}

    public partial class tblADTextCollection 
	{

        
        public override bool Load()
        {
            bool ret = true;
            //List<long> idlist = new List<long>();
            //SQLiteConnection _SqlConnectionConnection = new SQLiteConnection(Common.ConnectionString);
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

                myCommand.CommandText = @"SELECT * FROM [tblADText]  WHERE [DisplayID]= " + m_DisplayID_tblDisplay.DisplayID + " order by oIndex;";

                myCommand.Connection = Common.Conn;
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    //idlist.Add(myReader.GetInt64(myReader.GetOrdinal("ADTextID")));
                    tblADText tbladtext = new tblADText();
                    tbladtext.m_DisplayID_tblDisplay = this.m_DisplayID_tblDisplay;
                    tbladtext.AddFromRecordSet(myReader);
                    Add(tbladtext);
                }

                myReader.Close();
                myCommand.Dispose();
               // _SqlConnectionConnection.Close();

                //foreach (long id in idlist)// (int i = 0; i < count ; i++)
                //{
                //    tblADText tbladtext = new tblADText();
                //    tbladtext.ADTextID = id;
                //    tbladtext.m_DisplayID_tblDisplay = this.m_DisplayID_tblDisplay;
                //    tbladtext.Select();

                //    Add(tbladtext);
                //}

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
                SQLiteCommand Com = Common.Conn.CreateCommand();
                SQLiteCommand ComSync = Common.Conn.CreateCommand();
                Com.CommandText = @"DELETE FROM [tblADText] WHERE [DisplayID]= " + m_DisplayID_tblDisplay.DisplayID + ";";
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
