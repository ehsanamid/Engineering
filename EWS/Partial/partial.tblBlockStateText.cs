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


    public partial class tblBlockStateText 
    {
        
		
	}
	
	
	
	public partial class tblBlockStateTextCollection 
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
                myCommand.CommandText = @"SELECT * FROM [tblBlockStateText] ;";
                myCommand.Connection = Common.Conn;
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    idlist.Add(myReader.GetInt64(myReader.GetOrdinal("ID")));

                }

                myReader.Close();
                myCommand.Dispose();
                int count = idlist.Count;
                foreach (long id in idlist)// (int i = 0; i < count ; i++)
                {
                    tblBlockStateText tblblockstatetext = new tblBlockStateText();
                    tblblockstatetext.ID = id;// idlist[i];
                    tblblockstatetext.m_SolutionID_tblSolution = this.m_SolutionID_tblSolution;
                    tblblockstatetext.Select();

                    this.Add(tblblockstatetext);
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
