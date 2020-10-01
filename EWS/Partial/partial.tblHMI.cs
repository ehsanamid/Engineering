
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Data;
	using System.Data.SQLite;
	using System.Text;
namespace DCS.DCSTables
{

    public partial class tblHMI 
	{
        
		
		
	}

    public partial class tblHMICollection 
	{
        

        public override bool Load()
        {
            bool ret = true;
            List<long> idlist = new List<long>();
            //SQLiteConnection _SqlConnectionConnection = new SQLiteConnection(Common.ConnectionString);
            if (Common.Conn == null)
            {
                Common.Conn = new SQLiteConnection(Common.ConnectionString);
                Common.Conn.Open();
            }
            SQLiteDataReader myReader = null;
            SQLiteCommand myCommand = new SQLiteCommand();
            //if (_SqlConnectionConnection.State == System.Data.ConnectionState.Open)
            //    _SqlConnectionConnection.Close();
            //_SqlConnectionConnection.ConnectionString = Common.ConnectionString;
            //_SqlConnectionConnection.Open();

            try
            {
                myReader = null;
                myCommand.CommandText = @"SELECT * FROM [tblHMI] ";
                myCommand.Connection = Common.Conn;
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    idlist.Add(myReader.GetInt64(myReader.GetOrdinal("HMIID")));
                }

                myReader.Close();
                myCommand.Dispose();
                //_SqlConnectionConnection.Close();

                foreach (long id in idlist)// (int i = 0; i < count ; i++)
                {
                    tblHMI tblhmi = new tblHMI();
                    tblhmi.HMIID = id;
                    tblhmi.m_SolutionID_tblSolution = this.m_SolutionID_tblSolution;
                    tblhmi.SolutionID = this.m_SolutionID_tblSolution.SolutionID;
                    tblhmi.Select();
                    this.Add(tblhmi);
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
