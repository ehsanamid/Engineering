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


    public partial class tblSymbolPointsPolyline
    {
        
	}


    public partial class tblSymbolPointsPolylineCollection
    {
        
        public override bool Load()
        {
            bool ret = true;
            //List<long> idlist = new List<long>();
            //SQLiteConnection _SqlConnectionConnection = new SQLiteConnection(Common.ConnectionString);
            //SQLiteDataReader myReader = null;
            //SQLiteCommand myCommand = new SQLiteCommand();
            //if (_SqlConnectionConnection.State == System.Data.ConnectionState.Open)
            //    _SqlConnectionConnection.Close();
            //_SqlConnectionConnection.ConnectionString = Common.ConnectionString;
            //_SqlConnectionConnection.Open();
            //try
            //{
            //    myReader = null;
            //    myCommand.CommandText = @"SELECT * FROM [tblFormalParameter]  WHERE [FunctionID]= " + this._FunctionID_tblFunction.FunctionID + " order by oIndex;";
            //    myCommand.Connection = _SqlConnectionConnection;
            //    myReader = myCommand.ExecuteReader();
            //    while (myReader.Read())
            //    {
            //        idlist.Add(myReader.GetInt64(myReader.GetOrdinal("PinID")));
            //    }

            //    myReader.Close();
            //    myCommand.Dispose();
            //    _SqlConnectionConnection.Close();

            //    for (int i = 0; i < idlist.Count; i++)
            //    {
            //        tblFormalParameter tblformalparameter = new tblFormalParameter();

            //        tblformalparameter.PinID = idlist[i];
            //        tblformalparameter.Select();
            //        this.Add(tblformalparameter);
            //    }

            //}
            //catch (SQLiteException ae)
            //{
            //    return false;
            //    // MessageBox.Show(ae.Message.ToString());
            //}



            return ret;
        }
	}
}
