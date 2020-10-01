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


namespace DCS.DCSTables
{
	
	
	public partial class tblText 
	{
        
	}
	
	public partial class tblTextCollection 
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

                myCommand.CommandText = @"SELECT * FROM [tblText]  WHERE [DisplayID]= " + m_DisplayID_tblDisplay.DisplayID + " order by oIndex;";

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
                    tblText tblText = new tblText();
                    tblText.ID = id;
                    tblText.m_DisplayID_tblDisplay = this.m_DisplayID_tblDisplay;
                    tblText.Select();

                    Add(tblText);
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