
using DCS.DCSTables;
using DCS.TabPages;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Text;
using System.Windows.Forms;
using DCS.Draw;
using DCS.Draw.FBD;
using System.IO;

#if EWSAPP
using DCS.Compile.Operation; 
#endif

namespace DCS.DCSTables
{

    public partial class tblFunction
    {

        public override bool PostDeleteTriger()
        {
            tblSolution.m_tblSolution().m_tblFunctionCollection.Remove(this);
            tblSolution.m_tblSolution().functionbyType.Remove(this.Type);
            tblSolution.m_tblSolution().functionbyName.Remove(this.FunctionName);
            return true;
        }
        
        public override bool PostInsertTriger()
        {
            tblSolution.m_tblSolution().m_tblFunctionCollection.Add(this);
            tblSolution.m_tblSolution().functionbyType.Add(this.Type, this);
            tblSolution.m_tblSolution().functionbyName.Add(this.FunctionName, this);
            return true;
        }
        public long UDPouID
        {

            get
            {
                foreach (tblPou tblpou in tblSolution.m_tblSolution().Dummytblcontroller.m_tblPouCollection)
                {
                    if (this.FunctionName.ToUpper() == tblpou.pouName.ToUpper())
                    {
                        return tblpou.pouID;
                    }
                }
                return -1;
            }
        }

        private PageList _pages;
        public PageList Pages
        {
            get
            {
                return _pages;
            }
            set
            {
                _pages = value;
            }
        }

        private List<string> _modes = null;
        public List<string> Modes
        {
            get
            {
                if (_modes == null)
                {
                    int k = 1;
                    string str;
                    _modes = new List<string>();
                    for (int i = 0; i < 32; i++)
                    {
                        if (((this.Mode >> i) & 1) == 1)
                        {
                            MODE tmode = (MODE)k;
                            str = tmode.ToString();
                            _modes.Add(str);
                        }
                        k = k * 2;
                    }
                }
                return _modes;
            }
            set
            {
                _modes = value;
            }
        }

        private List<string> _statuses = null;
        public List<string> Statuses
        {
            get
            {
                if (_statuses == null)
                {
                    int k = 1;
                    string str;
                    _statuses = new List<string>();
                    for (int i = 0; i < 32; i++)
                    {
                        if (((this.Status >> i) & 1) == 1)
                        {
                            AlarmStatus tstatus = (AlarmStatus)k;
                            str = tstatus.ToString();
                            _statuses.Add(str);
                        }
                        k = k * 2;
                    }
                }
                return _statuses;
            }
            set
            {
                _modes = value;
            }
        }


        #region Related Objects
        //private tblSolution _SolutionID_tblSolution;

        //[Description("Represents the foreign key object of the type SolutionID")]
        //public tblSolution m_SolutionID_tblSolution
        //{
        //    get
        //    {
        //        return _SolutionID_tblSolution;
        //    }
        //    set
        //    {
        //        _SolutionID_tblSolution = value;
        //    }
        //}
        #endregion

        #region Public Methods

        public tblFunction(tblFunction ToCopy)
        {
            _FunctionName = ToCopy._FunctionName;
            _FunctionID = ToCopy._FunctionID;
            _SolutionID = ToCopy._SolutionID;
            _Description = ToCopy._Description;
            _Type = ToCopy._Type;
            _IsStandard = ToCopy._IsStandard;
            _FunctionGroup = ToCopy._FunctionGroup;
            _Extensible = ToCopy._Extensible;
            _IsFunction = ToCopy._IsFunction;

            _Language = ToCopy._Language;
            _Overloaded = ToCopy._Overloaded;
            _Width = ToCopy._Width;
            foreach (tblFormalParameter tblformalparameter in ToCopy.m_tblFormalParameterCollection)
            {
                this.m_tblFormalParameterCollection.Add(new tblFormalParameter(tblformalparameter));
            }

        }

        public int GetReturnType()
        {
            if (this.IsFunction)
            {
                foreach (tblFormalParameter tblformalparameter in this.m_tblFormalParameterCollection)
                {
                    if ((VarClass)tblformalparameter.Class == VarClass.Output)
                    {
                        return tblformalparameter.Type;
                    }
                }
            }
            return 0;
        }

        public static int SelectFunction(string functionname)
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
                Com.CommandText = "SELECT [FunctionName], [FunctionID] FROM [tblFunction] WHERE [FunctionName]= '" + functionname + "'";
                //Com.Parameters.AddRange(GetSqlParameters());
                //Conn.Open();
                SQLiteDataReader rs = Com.ExecuteReader();
                while (rs.Read())
                {

                    ret = rs.GetInt32(rs.GetOrdinal("FunctionID"));
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

        public int GetNoOfInputs()
        {
            int count = 0;
            if (this.IsFunction)
            {
                foreach (tblFormalParameter tblformalparameter in this.m_tblFormalParameterCollection)
                {
                    if ((VarClass)tblformalparameter.Class == VarClass.Input)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public int GetAllPossibleInputs()
        {
            int count = 0;
            //if (this.IsFunction)
            {
                foreach (tblFormalParameter tblformalparameter in this.m_tblFormalParameterCollection)
                {
                    if (((VarClass)tblformalparameter.Class == VarClass.Input) ||
                         ((VarClass)tblformalparameter.Class == VarClass.InOut) ||
                         ((VarClass)tblformalparameter.Class == VarClass.Internal))
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public tblFormalParameter GetFormalParameterFromName(string _formalparameter)
        {

            foreach (tblFormalParameter tblformalparameter in m_tblFormalParameterCollection)
            {
                if (tblformalparameter.PinName == _formalparameter)
                {
                    return tblformalparameter;
                }
            }

            return null;
        }

        public bool CheckFormalparameterExistInFunction(string _str,  out tblFormalParameter _tblformalparameter)
        {
            //string str = "";
            string[] varname = _str.Split(new Char[] { '.' });
            int count = varname.Length;

            //if (!IsFunction && !IsStandard)
            //{
            //    foreach (tblPou tblpou in tblSolution.m_tblSolution().Dummytblcontroller.m_tblPouCollection)
            //    {
            //        if (tblpou.pouName.ToUpper() == FunctionName.ToUpper())
            //        {
            //            foreach (tblVariable tblvariable in tblpou.m_tblVariableCollection)
            //            {
            //                if (varname[0].ToUpper() == tblvariable.VarName.ToUpper())
            //                {
            //                    _id = tblvariable.VarNameID;
            //                    break;
            //                }
            //            }
            //            break;
            //        }
            //    }
            //}
            //else
            //{
            //    _id = -1;
            //}
            foreach (tblFormalParameter tblformalparameter in m_tblFormalParameterCollection)
            {
                if (tblformalparameter.PinName.ToUpper() == varname[0].ToUpper())
                {
                    _tblformalparameter = tblformalparameter;

                    return true;
                }
            }
            _tblformalparameter = null;
            return false;
        }

        public long returnPinIDofUDFB(string _str)
        {
            //string str = "";
            string[] varname = _str.Split(new Char[] { '.' });
            int count = varname.Length;

            if (!IsFunction && !IsStandard)
            {
                foreach (tblPou tblpou in tblSolution.m_tblSolution().Dummytblcontroller.m_tblPouCollection)
                {
                    if (tblpou.pouName.ToUpper() == FunctionName.ToUpper())
                    {
                        foreach (tblVariable tblvariable in tblpou.m_tblVariableCollection)
                        {
                            if (varname[0].ToUpper() == tblvariable.VarName.ToUpper())
                            {
                                return tblvariable.VarNameID;
                                break;
                            }
                        }
                        break;
                    }
                }
            }
            return -1;
            
        }


        public bool IsFormalparameterexist(string _str, ref tblFormalParameter _tblformalparameter, ref string _subpropertytxt, ref byte _subproperty)
        {
            string str = "";
            string[] varname = _str.Split(new Char[] { '.' });
            int count = varname.Length;

            foreach (tblFormalParameter tblformalparameter in m_tblFormalParameterCollection)
            {
                if (tblformalparameter.PinName.ToLower() == varname[0])
                {
                    _tblformalparameter = tblformalparameter;
                    for (int i = 1; i < count; i++)
                    {
                        str += varname[i] + ".";
                    }
                    if (str == "")
                    {
                        _subpropertytxt = "";
                        _subproperty = 0;
                        return true;
                    }
                    else
                    {
                        if (count == 2)
                        {
                            str = str.Remove(str.Length - 1, 1);
                            if (varname[0] == "mode")
                            {
                                uint i = 1;
                                MODE tmode;
                                for (byte k = 0; k < 32; k++)
                                {
                                    tmode = (MODE)i;
                                    if ((_Mode & i) != 0)
                                    {
                                        if (varname[1] == tmode.ToString().ToLower())
                                        {
                                            _subpropertytxt = tmode.ToString();
                                            _subproperty = k;
                                            return true;
                                        }
                                    }
                                    i *= 2;
                                }
                            }
                            if (varname[0] == "state")
                            {
                                uint i = 1;
                                BlockState blockstate;
                                for (byte k = 0; k < 32; k++)
                                {
                                    blockstate = (BlockState)i;
                                    if ((_Mode & i) != 0)
                                    {
                                        if (varname[1] == blockstate.ToString().ToLower())
                                        {
                                            _subpropertytxt = blockstate.ToString();
                                            _subproperty = k;
                                            return true;
                                        }
                                    }
                                    i *= 2;
                                }
                            }

                            if ((varname[0] == "als") ||
                                (varname[0] == "ala") ||
                                (varname[0] == "alb") ||
                                (varname[0] == "aeb"))
                            {
                                uint i = 1;
                                AlarmStatus tstatus;
                                for (byte k = 0; k < 32; k++)
                                {
                                    tstatus = (AlarmStatus)i;
                                    if ((Status & i) != 0)
                                    {
                                        if (varname[1] == tstatus.ToString().ToLower())
                                        {
                                            _subpropertytxt = tstatus.ToString();
                                            _subproperty = k;
                                            return true;
                                        }
                                    }
                                    i *= 2;
                                }

                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }
            return false;
        }

        #endregion
    
    }

    public partial class tblFunctionCollection 
    {
        

        /// <remarks>Represents the foreign key object</remarks>
        //private tblSolution _SolutionID_tblSolution;

        //[Description("Represents the foreign key object of the type SolutionID")]
        //public tblSolution m_SolutionID_tblSolution
        //{
        //    get
        //    {
        //        return _SolutionID_tblSolution;
        //    }
        //    set
        //    {
        //        _SolutionID_tblSolution = value;
        //    }
        //}


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
            //if (_SqlConnectionConnection.State == System.Data.ConnectionState.Open)
            //    _SqlConnectionConnection.Close();
            //_SqlConnectionConnection.ConnectionString = Common.ConnectionString;
            //_SqlConnectionConnection.Open();

            try
            {
                myReader = null;
                myCommand.CommandText = @"SELECT * FROM [tblFunction] ;";
                myCommand.Connection = Common.Conn;
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    tblFunction tblfunction = new tblFunction();
                    tblfunction.m_SolutionID_tblSolution = this.m_SolutionID_tblSolution;
                    tblfunction.AddFromRecordSet(myReader);
                    this.Add(tblfunction);  
                    
                }

                myReader.Close();
                myCommand.Dispose();
                //_SqlConnectionConnection.Close();
                //int count = idlist.Count;
                //foreach( long id in idlist)// (int i = 0; i < count ; i++)
                //{
                //    tblFunction tblfunction = new tblFunction();
                //    tblfunction.FunctionID = id;// idlist[i];
                //    tblfunction.m_SolutionID_tblSolution = this.m_SolutionID_tblSolution;
                //    tblfunction.Select();
                //    //tblfunction.m_tblFormalParameterCollection.Load(_connectionstring, tblfunction.FunctionID);
                //    this.Add(tblfunction);  
                //}
                //"SELECT [FunctionName], [Description], [Type], [IsStandard], [FunctionGroup], [Extensible], [IsFunction], [Body], [Language] FROM [tblFunction] WHERE [FunctionID]=@FunctionID ";
            }
            catch (SQLiteException ae)
            {
                System.Windows.Forms.MessageBox.Show(ae.Message);
                return false;
            }



            return ret;
        }
        [Description("Returns tblFunction which it name is input argument of method.")]
        public tblFunction Find(string name)
        {
            foreach (tblFunction o in List)
            {
                if (o.FunctionName == name)
                    return o;
            }
            return null;
        }


        [Description("Gets a tblFunction from ID the collection.")]
        public tblFunction GetFunction(long _ID)
        {
            foreach (tblFunction tblfunction in List)
            {
                if (tblfunction.FunctionID == _ID)
                {
                    return tblfunction;
                }
            }
            return null;
       }

        

        [Description("Returns the ID value of the tblFunction class in the collection.")]
        public long IDOf(tblFunction item)
        {
            return ((tblFunction)List[List.IndexOf(item)]).FunctionID;
        }
	}
	
	
}
