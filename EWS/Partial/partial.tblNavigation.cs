
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Data;
	using System.Data.SQLite;
	using System.Text;
namespace DCS.DCSTables
{

    public partial class tblNavigation 
	{
        
	}

    public partial class tblNavigationCollection 
	{

       

        public override bool Load()
        {
            bool ret = true;
            List<long> idlist = new List<long>();
            SQLiteConnection _SqlConnectionConnection = new SQLiteConnection(Common.ConnectionString);
            SQLiteDataReader myReader = null;
            SQLiteCommand myCommand = new SQLiteCommand();
            if (_SqlConnectionConnection.State == System.Data.ConnectionState.Open)
                _SqlConnectionConnection.Close();
            _SqlConnectionConnection.ConnectionString = Common.ConnectionString;
            _SqlConnectionConnection.Open();

            try
            {
                myReader = null;

                myCommand.CommandText = @"SELECT * FROM [tblNavigation]  WHERE [DisplayID]= " + m_DisplayID_tblDisplay.DisplayID + " order by oIndex;";

                myCommand.Connection = _SqlConnectionConnection;
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    idlist.Add(myReader.GetInt64(myReader.GetOrdinal("ID")));
                }

                myReader.Close();
                myCommand.Dispose();
                _SqlConnectionConnection.Close();

                foreach (long id in idlist)// (int i = 0; i < count ; i++)
                {
                    tblNavigation tblnavigation = new tblNavigation();
                    tblnavigation.ID = id;
                    tblnavigation.m_DisplayID_tblDisplay = this.m_DisplayID_tblDisplay;
                    tblnavigation.Select();

                    Add(tblnavigation);
                }

            }
            catch (SQLiteException ae)
            {
                System.Windows.Forms.MessageBox.Show(ae.Message);
                return false;
            }



            return ret;
        }
	}
	
	
}
