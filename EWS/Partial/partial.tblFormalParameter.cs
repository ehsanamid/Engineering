
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Text;
namespace DCS.DCSTables
{


    public partial class tblFormalParameter 
	{

        bool visible;
        public bool Visible
        {
            get
            {
                return visible;
            }
            set
            {
                visible = value;
            }
        }

        bool uvisible;
        public bool UVisible
        {
            get
            {
                return uvisible;
            }
            set
            {
                uvisible = value;
            }
        }

        
		#region Public Methods


        public tblFormalParameter(tblFormalParameter ToCopy)
        {
            _PinName = ToCopy._PinName;
            _PinID = ToCopy._PinID;
            _FunctionID = ToCopy._FunctionID;
            _Type = ToCopy._Type;
            _Class = ToCopy._Class;
            _Extensible = ToCopy._Extensible;
            _oIndex = ToCopy._oIndex;
            _Description = ToCopy._Description;
            _InitializeValue = ToCopy._InitializeValue;
            _EV_TXT = ToCopy._EV_TXT;
            _EV_EBL = ToCopy._EV_EBL;
            _Option = ToCopy._Option;

        }

        public static int GetPinID(string ConnectionString, string pinname, string functionname)
        {
            int ret = -1;
            try
            {
                //"SELECT [PinName], [FunctionID], [Type], [Class], [Extensible], [oIndex], [Description], [InitializeValue], [EV_EBL], [EV_TXT], [EV_AUD], [EV_TYP], [EV_PRN] FROM [tblFormalParameter] WHERE [PinID]=@PinID ";

                if (Common.Conn == null)
                {
                    Common.Conn = new SQLiteConnection(Common.ConnectionString);
                    Common.Conn.Open();
                }
                SQLiteCommand Com = Common.Conn.CreateCommand();
                //Com.CommandText = "SELECT tblController.ControllerID FROM tblDomain, tblController WHERE tblcontroller.domainid=tbldomain.domainid AND tblController.ControllerName = '" + controllername + "' AND tblDomain.DomainName = '" + domainanme + "'";
                Com.CommandText = "SELECT tblFormalParameter.PinID, tblFormalParameter.PinName, tblFunction.FunctionName FROM tblFormalParameter INNER JOIN tblFunction ON tblFormalParameter.FunctionID = tblFunction.FunctionID WHERE tblFormalParameter.PinName = '" + pinname +"' AND tblFunction.FunctionName = '" + functionname + "';";
                //Conn.Open();
                SQLiteDataReader rs = Com.ExecuteReader();
                while (rs.Read())
                {

                    ret = rs.GetInt32(rs.GetOrdinal("PinID"));
                }
                rs.Close();
                //Conn.Close();
                rs.Dispose();
                Com.Dispose();
                //Conn.Dispose();
            }
            catch (System.Exception)
            {
                return -1;
            }
            return ret;
        }
		
		#endregion
		
		
	}

    public partial class tblFormalParameterCollection 
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
            //if (_SqlConnectionConnection.State == System.Data.ConnectionState.Open)
            //    _SqlConnectionConnection.Close();
            //_SqlConnectionConnection.ConnectionString = Common.ConnectionString;
            //_SqlConnectionConnection.Open();
            try
            {
                myReader = null;
                myCommand.CommandText = @"SELECT * FROM [tblFormalParameter]  WHERE [FunctionID]= " + this._FunctionID_tblFunction.FunctionID + " order by oIndex;";
                myCommand.Connection = Common.Conn;
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    idlist.Add(myReader.GetInt64(myReader.GetOrdinal("PinID")));      
                }

                myReader.Close();
                myCommand.Dispose();
               // _SqlConnectionConnection.Close();

                for (int i = 0; i < idlist.Count; i++)
                {
                    tblFormalParameter tblformalparameter = new tblFormalParameter();

                    tblformalparameter.PinID = idlist[i];
                    tblformalparameter.m_FunctionID_tblFunction = m_FunctionID_tblFunction;
                    tblformalparameter.Select();
                    this.Add(tblformalparameter);
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
