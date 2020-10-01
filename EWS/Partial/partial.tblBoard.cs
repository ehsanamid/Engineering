using DCS.DCSTables;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Text;
namespace DCS.DCSTables
{


    public partial class tblBoard 
	{
        
				
		#region Public Methods
        public static int GetBoardID(string ConnectionString, string boardname)
        {
            int ret = -1;
            try
            {
                //SQLiteConnection Conn = new SQLiteConnection(Common.ConnectionString);
                if (Common.Conn == null)
                {
                    Common.Conn = new SQLiteConnection(Common.ConnectionString);
                    Common.Conn.Open();
                }
                SQLiteCommand Com = Common.Conn.CreateCommand();
                Com.CommandText = "SELECT [BoardID] FROM [tblBoard] WHERE [BoardName]= '" + boardname + "'";
                //Com.Parameters.AddRange(GetSqlParameters());
                //Conn.Open();
                SQLiteDataReader rs = Com.ExecuteReader();
                while (rs.Read())
                {

                    ret = rs.GetInt32(rs.GetOrdinal("BoardID"));
                }
                rs.Close();
                //Conn.Close();
                rs.Dispose();
                Com.Dispose();
                //Conn.Dispose();
            }
            catch (System.Exception)
            {

            }
            return ret;
        }

        public void ResetCollection()
        {
            m_tblChannelCollection.Clear();
            m_tblChannelCollection = null;

        }
		
		
		#endregion
		
		
	}

    public partial class tblBoardCollection 
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
            //SQLiteConnection _SqlConnectionConnection = new SQLiteConnection(Common.ConnectionString);
            SQLiteDataReader myReader = null;
            SQLiteCommand myCommand = new SQLiteCommand();
            //if (_SqlConnectionConnection.State == System.Data.ConnectionState.Open)
            //    _SqlConnectionConnection.Close();
            //_SqlConnectionConnection.ConnectionString = Common.ConnectionString;
            //_SqlConnectionConnection.Open();
            //tblBoard] WHERE [BoardID
            try
            {
                myReader = null;
                myCommand.CommandText = @"SELECT * FROM [tblBoard]  WHERE [ControllerID]= " + m_ControllerID_tblController.ControllerID + " order by oIndex;";
                myCommand.Connection = Common.Conn;
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    idlist.Add(myReader.GetInt64(myReader.GetOrdinal("BoardID")));

                }

                myReader.Close();
                myCommand.Dispose();
                //_SqlConnectionConnection.Close();

                foreach (long id in idlist)// (int i = 0; i < count ; i++)
                {
                    tblBoard tblboard = new tblBoard();
                    tblboard.BoardID = id;
                    tblboard.m_ControllerID_tblController = this._ControllerID_tblController;
                    tblboard.Select();
                    // tblpou.m_tblVariableCollection.Load( tblpou.pouID);
                    this.Add(tblboard);
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
