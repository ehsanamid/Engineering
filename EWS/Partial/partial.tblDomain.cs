using EWS.DCSTables;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Text;
	
namespace EWS.DCSTables
{

    public partial class tblDomain 
	{

        private bool PreDeleteTriger()
        {

            return true;
        }
        private bool PostDeleteTriger()
        {

            return true;
        }
        private bool PreInsertTriger()
        {

            return true;
        }
        private bool PostInsertTriger()
        {

            return true;
        }
        private bool PreUpdateTriger()
        {

            return true;
        }
        private bool PostUpdateTriger()
        {

            return true;
        }
		
		#region Public Methods

        

        public static void SelectAllController(string ConnectionString, List<int> domainlist)
        {
            List<int> controllerlist = new List<int>();
            int controllerid;
            int _domainid;
            
            try
            {
                for (int i = 0; i < domainlist.Count; i++)
                {
                    _domainid = domainlist[i];
                    if (Common.Conn == null)
                    {
                        Common.Conn = new SQLiteConnection(Common.ConnectionString);
                        Common.Conn.Open();
                    }
                    SQLiteCommand Com = Common.Conn.CreateCommand();
                    Com.CommandText = "SELECT [ControllerName], [ControllerID], [NodeNumber], [oIndex], [Description], [Redundant], [TargetType], [NumberOfIORack], [DIGID], [HW1DIGID], [HW2DIGID], [IP1_1DIGID], [IP1_2DIGID], [IP2_1DIGID], [IP2_2DIGID] FROM [tblController] WHERE [DomainID]= " + _domainid + "; ";
                    //Conn.Open();
                    SQLiteDataReader rs = Com.ExecuteReader();
                    while (rs.Read())
                    {
                        controllerid = rs.GetInt32(rs.GetOrdinal("ControllerID"));
                        controllerlist.Add(controllerid);
                    }
                    rs.Close();
                    //Conn.Close();
                    rs.Dispose();
                    Com.Dispose();
                    //Conn.Dispose();

                    
                }
                tblController.SelectAllPou(ConnectionString, controllerlist);
            }
            catch (System.Exception)
            {
                throw;
            }

        }

       
        public static int GetDomainID(string ConnectionString,string domainname)
        {
            int ret = -1;
            try
            {
                if (Common.Conn == null)
                {
                    Common.Conn = new SQLiteConnection(Common.ConnectionString);
                    Common.Conn.Open();
                }
                SQLiteCommand Com = Common.Conn.CreateCommand();
                Com.CommandText = "SELECT [DomainID] FROM [tblDomain] WHERE [DomainName]= '" + domainname + "'";
                //Com.Parameters.AddRange(GetSqlParameters());
                //Conn.Open();
                SQLiteDataReader rs = Com.ExecuteReader();
                while (rs.Read())
                {

                    ret = rs.GetInt32(rs.GetOrdinal("DomainID"));
                }
                rs.Close();
                //Conn.Close();
                rs.Dispose();
                Com.Dispose();
               // Conn.Dispose();
            }
            catch (System.Exception)
            {
                
            }
            return ret;
        }

        public tblController GettblControllerObjectFromID(long id)
        {
            foreach (tblController tblcontroller in m_tblControllerCollection)
            {
                if (tblcontroller.ControllerID == id)
                {
                    return tblcontroller;
                }
            }
            return null;
        }

        public long GetDomainIDofControllerID(long id)
        {
            foreach (tblController tblcontroller in m_tblControllerCollection)
            {
                if (tblcontroller.ControllerID == id)
                {
                    return tblcontroller.ControllerID;
                }
            }
            return -1;
        }

        
		#endregion
		
		

        

        public int CheckControllerNameExist(string strname)
        {
            int i;
            for (i = 0; i < m_tblControllerCollection.Count; i++)
            {
                if (strname == m_tblControllerCollection[i].ControllerName)
                {
                    return i;
                }
            }
            return -1;
        }
        public bool GetNewControllerName(ref string strControllerName, ref int intNodeNumber)
        {


            if (Common.Conn == null)
            {
                Common.Conn = new SQLiteConnection(Common.ConnectionString);
                Common.Conn.Open();
            }

            int No = 1;
            string str = "Controller";
            string str1 = "dd";
            bool findnewname = false;
            SQLiteDataReader myReader = null;
            SQLiteCommand myCommand = new SQLiteCommand();
            //if (_SqlConnectionConnection.State == System.Data.ConnectionState.Open)
            //    _SqlConnectionConnection.Close();
            //_SqlConnectionConnection.ConnectionString = Common.ConnectionString;
            //_SqlConnectionConnection.Open();
            try
            {
                findnewname = false;
                No = 1;
                while (findnewname == false)
                {
                    myReader = null;
                    str1 = str + No.ToString();
                    //myCommand = new SqlCommand("Select Name from tblDomain where (Name = " + i.ToString() + ")", conn);
                    myCommand.CommandText = "Select ControllerName,DomainID from tblController where (ControllerName = '" + str1 + "' and DomainID = '" + DomainID + "')";
                    myCommand.Connection = Common.Conn;
                    myReader = myCommand.ExecuteReader();
                    if (myReader.HasRows == false)
                    {
                        findnewname = true;
                    }
                    else
                    {
                        No++;
                    }
                    myReader.Close();
                    myCommand.Dispose();

                }
                strControllerName = str1;
            }
            catch (SQLiteException ae)
            {
                //MessageBox.Show(ae.Message.ToString());
                return false;
            }
            try
            {

                findnewname = false;
                No = 1;
                while (findnewname == false)
                {
                    myReader = null;
                    str1 = str + No.ToString();
                    myCommand.CommandText = "Select ControllerName,DomainID,NodeNumber from tblController where (DomainID = " + DomainID + "and NodeNumber =" + No.ToString() + ")";
                    myCommand.Connection = Common.Conn;
                    myReader = myCommand.ExecuteReader();
                    if (myReader.HasRows == false)
                    {
                        findnewname = true;
                    }
                    else
                    {
                        No++;
                    }
                    myReader.Close();
                    myCommand.Dispose();
                }

                intNodeNumber = No;
            }
            catch (SQLiteException ae)
            {


                //MessageBox.Show(ae.Message.ToString());
                return false;
            }
            //_SqlConnectionConnection.Close();
            return true;
        }

        public List<tblDisplay> GetDisplays(long _parentid)
        {
            List<tblDisplay> list = new List<tblDisplay>();
            foreach (tblDisplay tbldispaly in m_tblDisplayCollection)
            {
                if (tbldispaly.ParrentDisplay == _parentid)
                {
                    list.Add(tbldispaly);
                }
            }
            return list;
        }

        public bool IsVariable(string _fcsname, string _pouname, string _variablename, string _propertyname,  ref tblVariable _tblvariable, ref tblFormalParameter _tblformalparameter)
        {
            string tempstr = "";
            int count = 0;


            foreach (tblController tblcontroller in m_tblControllerCollection)
            {
                if (tblcontroller.ControllerName.ToLower() == _fcsname)
                {
                    if (tblcontroller.IsVariable( _pouname, _variablename, _propertyname, ref  _tblvariable, ref  _tblformalparameter))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }

    }

    
    public partial class tblDomainCollection 
	{
        public tblDomainCollection(tblSolution parent)
        {
            m_SolutionID_tblSolution = parent;
        }

        public bool Load()
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
                myCommand.CommandText = @"SELECT * FROM [tblDomain] "; 
                myCommand.Connection = Common.Conn;
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    idlist.Add(myReader.GetInt64(myReader.GetOrdinal("DomainID")));
                }

                myReader.Close();
                myCommand.Dispose();
                //_SqlConnectionConnection.Close();

                foreach (long id in idlist)// (int i = 0; i < count ; i++)
                {
                    tblDomain tbldomain = new tblDomain();
                    tbldomain.DomainID = id;
                    tbldomain.m_SolutionID_tblSolution = this.m_SolutionID_tblSolution;
                    tbldomain.SolutionName = this.m_SolutionID_tblSolution.SolutionName;
                    tbldomain.Select();
                    //tbldomain.m_tblControllerCollection.m_DomainID_tblDomain = tbldomain;
                    // tbldomain.m_tblDisplayCollection.m_DomainID_tblDomain = tbldomain;
                    //tbldomain.m_tblControllerCollection.Load( /*tbldomain.DomainID*/);
                    //tbldomain.m_tblDisplayCollection.Load( /*tbldomain.DomainID*/);
                    this.Add(tbldomain);
                }

            }
            catch (SQLiteException ae)
            {
                return false;
                // MessageBox.Show(ae.Message.ToString());
            }
            


            return ret;
        }

        [Description("Search collection for DomaniID and returns domain.")]
        public tblDomain SearchID(long _id)
        {
            foreach (tblDomain tbldomain in List)
            {
                if (tbldomain.DomainID == _id)
                {
                    return tbldomain;
                }
            }
            return null;
        }

        [Description("Gets a  tblDomain from the collection.")]
        public tblDomain GetObjectFromID(long id)
        {
            foreach (tblDomain tbldomain in List)
            {
                if (tbldomain.DomainID == id)
                {
                    return tbldomain;
                }
            }
            return null;
        }

        public bool CompileController(string _controllername)
        {
            bool ret = false;
            //foreach (tblController tblcontroller in List)
            //{
            //    if (tblcontroller.ControllerName == _controllername)
            //    {
            //        ret = tblcontroller.CompileController();
            //        break;
            //    }
            //}
            return ret;
        }

        public bool CompileController(long _controllerid)
        {
            bool ret = false;
            //foreach (tblController tblcontroller in List)
            //{
            //    if (tblcontroller.ControllerID == _controllerid)
            //    {
            //        ret = tblcontroller.CompileController();
            //        break;
            //    }
            //}
            return ret;
        }
	}
	
	
}
