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
	
	
	public partial class tblAlarmGroup 
    {
        
	}
	
	
	public partial class tblAlarmGroupCollection 
    {
        public override bool Load()
        {
            bool ret = true;
            //List<long> idlist = new List<long>();
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
                myCommand.CommandText = @"SELECT * FROM [tblAlarmGroup] order by oIndex ;";
                myCommand.Connection = Common.Conn;
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    tblAlarmGroup tblalarmgroup = new tblAlarmGroup();
                    tblalarmgroup.m_SolutionID_tblSolution = this.m_SolutionID_tblSolution;
                    tblalarmgroup.AddFromRecordSet(myReader);

                    this.Add(tblalarmgroup);

                }

                myReader.Close();
                myCommand.Dispose();
                //int count = idlist.Count;
                //foreach (long id in idlist)// (int i = 0; i < count ; i++)
                //{
                //    tblAlarmGroup tblalarmgroup = new tblAlarmGroup();
                //    tblalarmgroup.ID = id;// idlist[i];
                //    tblalarmgroup.m_SolutionID_tblSolution = this.m_SolutionID_tblSolution;
                //    tblalarmgroup.Select();

                //    this.Add(tblalarmgroup);
                //}
            }
            catch (SQLiteException ae)
            {
                MessageBox.Show(ae.Message.ToString());
                return false;
                // 
            }



            return ret;
        }

	}
}
