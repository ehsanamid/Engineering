
using DCS.DCSTables;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Text;
using System.Windows.Forms;
	
namespace DCS.DCSTables
{
    public partial class tblSolution 
	{

        private static tblSolution _tblsolution = null;
        public static tblSolution m_tblSolution()
        {
            if (_tblsolution == null)
            {
                _tblsolution = new tblSolution();
            }
            return _tblsolution;
        }

        public tblController Dummytblcontroller
        {
            get
            {
                foreach (tblController tblcontroller in this.m_tblControllerCollection)
                {
                    if (tblcontroller.type == (int)StationType.DUMMY)
                    {
                        return tblcontroller;
                    }
                }
                tblController _tblcontroller = new tblController();
                _tblcontroller.SolutionID = this.SolutionID;
                _tblcontroller.ControllerName = "USERDEFINED";
                _tblcontroller.type = (int)StationType.DUMMY;
                _tblcontroller.Insert();
                this.m_tblControllerCollection.Add(_tblcontroller);
                return _tblcontroller;
            }
        }

        public override bool PostInsertTriger()
        {
            tblController tblcontroller = new tblController();
            tblcontroller.SolutionID = this.SolutionID;
            tblcontroller.ControllerName = "USERDEFINED";
            tblcontroller.type = (int)StationType.DUMMY;
            tblcontroller.Insert();
            
            return true;
        }
        public void funcset(string _pinname,string _pindescription)
        {
            string str;
            int oIndex ;
            //acknowledge
            bool pinexist = false;
            foreach (tblFunction tblfunction in m_tblFunctionCollection)
            {
                if (!tblfunction.IsFunction)
                {
                    oIndex = -1;
                    pinexist = false;
                    for (int i = 0; i < tblfunction.m_tblFormalParameterCollection.Count; i++)
                    {
                        str = tblfunction.m_tblFormalParameterCollection[i].PinName;
                        if (oIndex < tblfunction.m_tblFormalParameterCollection[i].oIndex)
                        {
                            oIndex = tblfunction.m_tblFormalParameterCollection[i].oIndex;
                        }
                        if (_pinname == str)
                        {
                            pinexist = true;
                            break;
                        }
                    }
                    if (!pinexist)
                    {
                        tblFormalParameter tblformalparameter1 = new tblFormalParameter();
                        tblformalparameter1.PinName = _pinname;
                        tblformalparameter1.Class = (int)VarClass.Internal;
                        tblformalparameter1.PropertyType = true;
                        tblformalparameter1.Description = _pindescription;
                        tblformalparameter1.Type = (int)VarType.UDINT;
                        tblformalparameter1.Extensible = false;
                        tblformalparameter1.FunctionID = tblfunction.FunctionID;
                        tblformalparameter1.oIndex = ++oIndex;
                        tblformalparameter1.Insert();
                    }
                }
            }
        }
        
        public void funcsetorder()
        {
            string str;
            int oIndex;
            //acknowledge
            tblFormalParameter tblformalparameter1;
            foreach (tblFunction tblfunction in m_tblFunctionCollection)
            {
                if (!tblfunction.IsFunction)
                {
                    oIndex = 10;
                    for (int i = 0; i < tblfunction.m_tblFormalParameterCollection.Count; i++)
                    {
                        str = tblfunction.m_tblFormalParameterCollection[i].PinName;
                        tblformalparameter1 = new tblFormalParameter();
                        switch (str)
                        {
                            case "Mode":
                                tblformalparameter1.PinID = tblfunction.m_tblFormalParameterCollection[i].PinID;
                                tblformalparameter1.Select();
                                tblformalparameter1.oIndex = 0;
                                tblformalparameter1.Update();
                                break;
                            case "State":
                                tblformalparameter1.PinID = tblfunction.m_tblFormalParameterCollection[i].PinID;
                                tblformalparameter1.Select();
                                tblformalparameter1.oIndex = 1;
                                tblformalparameter1.Update();
                                break;
                            case "ALS":
                                tblformalparameter1.PinID = tblfunction.m_tblFormalParameterCollection[i].PinID;
                                tblformalparameter1.Select();
                                tblformalparameter1.oIndex = 2;
                                tblformalparameter1.Update();
                                break;
                            case "ALA":
                                tblformalparameter1.PinID = tblfunction.m_tblFormalParameterCollection[i].PinID;
                                tblformalparameter1.Select();
                                tblformalparameter1.oIndex = 3;
                                tblformalparameter1.Update();
                                break;
                            case "ALB":
                                tblformalparameter1.PinID = tblfunction.m_tblFormalParameterCollection[i].PinID;
                                tblformalparameter1.Select();
                                tblformalparameter1.oIndex = 4;
                                tblformalparameter1.Update();
                                break;
                            case "AEB":
                                tblformalparameter1.PinID = tblfunction.m_tblFormalParameterCollection[i].PinID;
                                tblformalparameter1.Select();
                                tblformalparameter1.oIndex = 5;
                                tblformalparameter1.Update();
                                break;
                            case "OPN":
                                tblformalparameter1.PinID = tblfunction.m_tblFormalParameterCollection[i].PinID;
                                tblformalparameter1.Select();
                                tblformalparameter1.oIndex = 6;
                                tblformalparameter1.Update();
                                break;
                            case "OPH":
                                tblformalparameter1.PinID = tblfunction.m_tblFormalParameterCollection[i].PinID;
                                tblformalparameter1.Select();
                                tblformalparameter1.oIndex = 7;
                                tblformalparameter1.Update();
                                break;
                            case "OPM":
                                tblformalparameter1.PinID = tblfunction.m_tblFormalParameterCollection[i].PinID;
                                tblformalparameter1.Select();
                                tblformalparameter1.oIndex = 8;
                                tblformalparameter1.Update();
                                break;
                            case "MNN":
                                tblformalparameter1.PinID = tblfunction.m_tblFormalParameterCollection[i].PinID;
                                tblformalparameter1.Select();
                                tblformalparameter1.oIndex = 9;
                                tblformalparameter1.Update();
                                break;
                            default:
                                tblformalparameter1.PinID = tblfunction.m_tblFormalParameterCollection[i].PinID;
                                tblformalparameter1.Select();
                                tblformalparameter1.oIndex = oIndex++;
                                tblformalparameter1.Update();
                                break;
                        }
                    }
                    
                }
            }
        }
        public void funcEnum()
        {
            //string str;
            foreach (tblFunction tblfunction in m_tblFunctionCollection)
            {
                if (!tblfunction.IsFunction)
                {
                    Console.WriteLine("enum Prop_"+tblfunction.FunctionName);
                    Console.WriteLine("{");
                    for (int i = 0; i < tblfunction.m_tblFormalParameterCollection.Count; i++)
                    {
                        if (tblfunction.m_tblFormalParameterCollection[i].oIndex > 9)
                        {
                            //str = tblfunction.m_tblFormalParameterCollection[i].oIndex.ToString();
                            Console.WriteLine(tblfunction.m_tblFormalParameterCollection[i].PinName + "_" +
                                tblfunction.FunctionName + "_Property = "+ tblfunction.m_tblFormalParameterCollection[i].oIndex.ToString()+ ",");
                        }
                        
                    }
                    Console.WriteLine("};");

                }
            }
        }


        [Description("Gets a tblFunction from ID the collection.")]
        public tblFunction GetFunctionbyType(int _type)
        {
            if (functionbytype.ContainsKey(_type))
            {
                return functionbytype[_type];
            }
            else
            {
                return null;
            }
            //foreach (tblFunction tblfunction in m_tblFunctionCollection)
            //{
            //    if (tblfunction.Type == _type)
            //    {
            //        return tblfunction;
            //    }
            //}
            //return null;
        }

        [Description("Gets a function name from function type")]
        public string GetFunctionNamebyType(int _type)
        {
            if (functionbyType.ContainsKey(_type))
            {
                return functionbyType[_type].FunctionName.ToUpper();
            }
            return "";
            //foreach (tblFunction tblfunction in m_tblFunctionCollection)
            //{
            //    if (tblfunction.Type == _type)
            //    {
            //        return tblfunction.FunctionName;
            //    }
            //}
            //return "";
        }


#if OWSAPP

        public VALUE []tempVariables = new VALUE[32];
        Dictionary<long, tblVariable> rtdb;

        public Dictionary<long, tblVariable> RTDB
        {
            get
            {
                if (rtdb == null)
                {
                    rtdb = new Dictionary<long, tblVariable>();
                    foreach (tblController tblcontroller in m_tblControllerCollection)
                    {
                        foreach (tblPou tblpou in tblcontroller.m_tblPouCollection)
                        {
                            foreach (tblVariable tblvariable in tblpou.m_tblVariableCollection)
                            {
                                rtdb.Add(tblvariable.VarNameID, tblvariable);
                            }
                        }
                    }
                }
                return rtdb;
            }
            //set
            //{
            //    vartypestringlist = value;
            //}
        }
        
        Dictionary<long, tblPou> poudb;

        public Dictionary<long, tblPou> POUDB
        {
            get
            {
                if (poudb == null)
                {
                    poudb = new Dictionary<long, tblPou>();
                    foreach (tblController tblcontroller in m_tblControllerCollection)
                    {
                        foreach (tblPou tblpou in tblcontroller.m_tblPouCollection)
                        {
                            poudb.Add(tblpou.pouID, tblpou);
                        }
                    }
                }
                return poudb;
            }
            //set
            //{
            //    vartypestringlist = value;
            //}
        }

        Dictionary<long, tblController> stationdb;

        public Dictionary<long, tblController> STDB
        {
            get
            {
                if (stationdb == null)
                {
                    stationdb = new Dictionary<long, tblController>();
                    foreach (tblController tblcontroller in m_tblControllerCollection)
                    {
                        stationdb.Add(tblcontroller.ControllerID, tblcontroller);
                    }
                }
                return stationdb;
            }
            //set
            //{
            //    vartypestringlist = value;
            //}
        }

#endif

        Dictionary<string, tblPlantStructure> plantstructure;
        public Dictionary<string, tblPlantStructure> PlantStructure
        {
            get
            {
                if (plantstructure == null)
                {
                    plantstructure = new Dictionary<string, tblPlantStructure>();
                    foreach (tblPlantStructure tblplantstructure in m_tblPlantStructureCollection)
                    {
                        plantstructure.Add(tblplantstructure.Name, tblplantstructure);
                    }
                }
                return plantstructure;
            }
        }


        Dictionary<int, tblPlantStructureProperty> plantstructureproperty;
        public Dictionary<int, tblPlantStructureProperty> PlantStructureProperty
        {
            get
            {
                if (plantstructureproperty == null)
                {
                    plantstructureproperty = new Dictionary<int, tblPlantStructureProperty>();
                    foreach (tblPlantStructureProperty tblplantstructureproperty in m_tblPlantStructurePropertyCollection)
                    {
                        plantstructureproperty.Add(tblplantstructureproperty.Type, tblplantstructureproperty);
                    }
                }
                return plantstructureproperty;
            }
        }

        Dictionary<int, tblPlantStructureObject> plantstructureobject;
        public Dictionary<int, tblPlantStructureObject> PlantStructureObject
        {
            get
            {
                if (plantstructureobject == null)
                {
                    plantstructureobject = new Dictionary<int, tblPlantStructureObject>();
                    foreach (tblPlantStructureObject tblplantstructureobject in m_tblPlantStructureObjectCollection)
                    {
                        plantstructureobject.Add(tblplantstructureobject.Type, tblplantstructureobject);
                    }
                }
                return plantstructureobject;
            }
        }

        Dictionary<int, tblFunction> functionbytype;
        Dictionary<string, tblFunction> functionbyname;
        public Dictionary<int, tblFunction> functionbyType
        {
            get
            {
                if (functionbytype == null)
                {
                    functionbytype = new Dictionary<int, tblFunction>();
                    functionbyname = new Dictionary<string, tblFunction>();
                    foreach (tblFunction tblfunction in m_tblFunctionCollection)
                    {
                        functionbytype.Add(tblfunction.Type, tblfunction);
                        functionbyname.Add(tblfunction.FunctionName.ToUpper(), tblfunction);
                    }
                }
                return functionbytype;
            }
        }
        public Dictionary<string, tblFunction> functionbyName
        {
            get
            {
                if (functionbyname == null)
                {
                    functionbytype = new Dictionary<int, tblFunction>();
                    functionbyname = new Dictionary<string, tblFunction>();
                    foreach (tblFunction tblfunction in m_tblFunctionCollection)
                    {
                        functionbytype.Add(tblfunction.Type, tblfunction);
                        functionbyname.Add(tblfunction.FunctionName.ToUpper(), tblfunction);
                    }
                }
                return functionbyname;
            }
        }

        #region Related Object Collections
        
        
        
        Dictionary<long, string> areastringlist;

        public Dictionary<long, string> AreaStringList
        {
            get
            {
                if (areastringlist == null)
                {
                    areastringlist = new Dictionary<long, string>();
                    foreach (tblPlantStructure tblplantstructure in m_tblPlantStructureCollection)
                    {
                        areastringlist.Add(tblplantstructure.ID, tblplantstructure.Name);
                    }
                }
                return areastringlist;
            }
            //set
            //{
            //    vartypestringlist = value;
            //}
        }

        Dictionary<long, tblVariable> variables = null;
        

        public Dictionary<long, tblVariable> Variables
        {
            get
            {
                if (variables == null)
                {
                    
                    TimeSpan ts = new TimeSpan(DateTime.UtcNow.Ticks);
                    double ms = ts.TotalMilliseconds;
                    variables = new Dictionary<long, tblVariable>();
                    
                    foreach (tblController tblcontroller in m_tblControllerCollection)
                    {
                        foreach (tblPou tblpou in tblcontroller.m_tblPouCollection)
                        {
                            lock (tblpou._locker)
                            {
                                Console.WriteLine(tblcontroller.ControllerName + ":" + tblpou.pouName);
                                //tblpou.VariablesByName = new Dictionary<string, tblVariable>();
                                foreach (tblVariable tblvariable in tblpou.m_tblVariableCollection)
                                {

                                    variables.Add(tblvariable.VarNameID, tblvariable);
                                    //tblpou.VariablesByName.Add(tblvariable.VarName.ToLower(), tblvariable);
                                }
                            }
                        }
                    }
                    
                    TimeSpan ts1 = new TimeSpan(DateTime.UtcNow.Ticks);
                    int ms1 = (int)(ts1.TotalMilliseconds - ms);
                    Console.WriteLine("loading Variables in " + ms1.ToString() + "ms");
                }
                return variables;
            }
            //set
            //{
            //    variables = value;
            //}
        }
  

        


        Dictionary<string ,long> arealonglist;

        public Dictionary<string, long> AreaLongList
        {
            get
            {
                if (arealonglist == null)
                {
                    arealonglist = new Dictionary<string, long>();
                    foreach (tblPlantStructure tblplantstructure in m_tblPlantStructureCollection)
                    {
                        arealonglist.Add(tblplantstructure.Name, tblplantstructure.ID);
                    }
                }
                return arealonglist;
            }
            //set
            //{
            //    vartypestringlist = value;
            //}
        }


        Dictionary<int, string> vartypestringlist;
        public Dictionary<int, string> VarTypeStringList
        {
            get
            {
                if (vartypestringlist == null)
                {
                    vartypestringlist = new Dictionary<int, string>();
                    foreach (tblFunction tblfunction in m_tblFunctionCollection)
                    {
                        if (!tblfunction.IsFunction)
                        {
                            vartypestringlist.Add(tblfunction.Type, tblfunction.FunctionName);
                        }
                    }
                }
                return vartypestringlist;
            }
            //set
            //{
            //    vartypestringlist = value;
            //}
        }

        Dictionary<string, int> stringvartypelist;

        public Dictionary<string, int> StringVarTypeList
        {
            get
            {
                if (stringvartypelist == null)
                {
                    stringvartypelist = new Dictionary<string, int>();
                    foreach (tblFunction tblfunction in m_tblFunctionCollection)
                    {
                        if (!tblfunction.IsFunction)
                        {
                            stringvartypelist.Add( tblfunction.FunctionName,tblfunction.Type);
                        }
                    }
                }
                return stringvartypelist;
            }
            //set
            //{
            //    stringvartypelist = value;
            //}
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

        public List<tblPlantStructure> GetPlantStructure(long _parentid)
        {
            List<tblPlantStructure> list = new List<tblPlantStructure>();
            foreach (tblPlantStructure tblplantstructure in m_tblPlantStructureCollection)
            {
                if (tblplantstructure.ParentID == _parentid)
                {
                    list.Add(tblplantstructure);
                }
            }
            return list;
        }
        
        
        /// <remarks>Represents the foreign key object</remarks>
        private tblSymbolsCollection _tblsymbolcollection;

        public tblSymbolsCollection m_tblSymbolCollection
        {
            get
            {
                try
                {
                    return _tblsymbolcollection;
                }
                catch (System.Exception err)
                {
                    throw new Exception("Error getting m_tblSymbolCollection", err);
                }
            }
            set
            {
                try
                {
                    _tblsymbolcollection = value;
                }
                catch (System.Exception err)
                {
                    throw new Exception("Error setting m_tblSymbolCollection", err);
                }
            }
        }


        /// <remarks>Represents the foreign key object</remarks>
        private tblBoardTypeCollection _tblboardtypescollection;
        [Description("Represents the foreign key relation. This is an Collection of tblSolution.")]
        public tblBoardTypeCollection m_tblBoardtypesCollection
        {
            get
            {
                try
                {
                    return _tblboardtypescollection;
                }
                catch (System.Exception err)
                {
                    throw new Exception("Error getting m_tblBoardtypesCollection", err);
                }
            }
            set
            {
                try
                {
                    _tblboardtypescollection = value;
                }
                catch (System.Exception err)
                {
                    throw new Exception("Error setting m_tblBoardtypesCollection", err);
                }
            }
        }
        #endregion

        

       

        //public bool CompileController(string _domainname, string _controllername)
        //{
        //    bool ret = false;
        //    foreach (tblDomain tbldomain in m_tblDomainCollection)
        //    {
        //        ret = tbldomain.CompileController(_controllername);
        //        break;
        //    }
        //    return ret;
        //}
        public bool Load()
        {
            try
            {
                if (Common.Conn == null)
                {
                    Common.Conn = new SQLiteConnection(Common.ConnectionString);
                    Common.Conn.Open();
                }
                SQLiteCommand Com = Common.Conn.CreateCommand(); //SQLiteCommand Com = Conn.CreateCommand();
                Com.CommandText = "SELECT  [SolutionID] FROM [tblSolution] ";
                Com.Parameters.AddRange(GetSqlParameters());
                //Conn.Open();
                SQLiteDataReader rs = Com.ExecuteReader();
                while (rs.Read())
                {
                    AddFromRecordSet(rs);
                }
                rs.Close();
                //Conn.Close();
                rs.Dispose();
                Com.Dispose();
                this.Select();
                //Conn.Dispose();
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            //m_tblDomainCollection.Load();
            //m_tblFunctionCollection.Load();
           // tblHMICollection.Load();
            return true;
        }

        
        public bool CheckName(string strDomainName)
        {

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
                myCommand.CommandText = "Select DomainName from tblDomain where (DomainName = '" + strDomainName + "')";
                myCommand.Connection = _SqlConnectionConnection;
                myReader = myCommand.ExecuteReader();
                if (myReader.HasRows == false)
                {
                    myReader.Close();
                    myCommand.Dispose();
                    _SqlConnectionConnection.Close();
                    return true;
                }
                else
                {
                    myReader.Close();
                    myCommand.Dispose();
                    _SqlConnectionConnection.Close();
                    return false;
                }
            }
            catch (SQLiteException ae)
            {
                System.Windows.Forms.MessageBox.Show(ae.Message);
                return false;
            }
        }

        public bool GetNewName( ref string strDomainName, ref int intDomainNo)
        {

            SQLiteConnection _SqlConnectionConnection = new SQLiteConnection(Common.ConnectionString);

            int No = 1;
            string str = "Domain";
            string str1 = "dd";
            bool findnewname = false;
            SQLiteDataReader myReader = null;
            SQLiteCommand myCommand = new SQLiteCommand();
            if (_SqlConnectionConnection.State == System.Data.ConnectionState.Open)
                _SqlConnectionConnection.Close();
            _SqlConnectionConnection.ConnectionString = Common.ConnectionString;
            _SqlConnectionConnection.Open();


            try
            {

                findnewname = false;
                No = 1;
                while (findnewname == false)
                {
                    myReader = null;
                    str1 = str + No.ToString();
                    myCommand.CommandText = "Select DomainName from tblDomain where (DomainName = '" + str1 + "')";
                    myCommand.Connection = _SqlConnectionConnection;
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

                strDomainName = str1;
            }
            catch (SQLiteException ae)
            {
                System.Windows.Forms.MessageBox.Show(ae.Message);
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
                    myCommand.CommandText = "Select DomainNo from tblDomain where (DomainNo = " + No.ToString() + ")";
                    myCommand.Connection = _SqlConnectionConnection;
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
                _SqlConnectionConnection.Close();
                intDomainNo = No;
            }
            catch (SQLiteException ae)
            {
                System.Windows.Forms.MessageBox.Show(ae.Message);
                return false;
            }
            return true;


        }

        public tblController GetControllerFromID(long _controllerid)
        {
            
                foreach (tblController tblcontroller in m_tblControllerCollection)
                {
                    if (tblcontroller.ControllerID == _controllerid)
                    {
                        return tblcontroller;
                    }
                }
            
            return null;
        }

        public tblDisplay GetDisplayFromID(long _displayid)
        {

            foreach (tblDisplay tbldisplay in m_tblDisplayCollection)
            {
                if (tbldisplay.DisplayID == _displayid)
                {
                    return tbldisplay;
                }
            }

            return null;
        }

        public tblController GetControllerFromName(string _controllername)
        {

            foreach (tblController tblcontroller in m_tblControllerCollection)
            {
                if (tblcontroller.ControllerName.ToLower() == _controllername.ToLower())
                {
                    return tblcontroller;
                }
            }

            return null;
        }

        public tblFunction GetFunctionFromID(long _functionid)
        {

            foreach (tblFunction tblfunction in m_tblFunctionCollection)
            {
                if (tblfunction.FunctionID == _functionid)
                {
                    return tblfunction;
                }
            }

            return null;
        }

        public tblFunction GetFunctionFromName(string _functionname)
        {

            foreach (tblFunction tblfunction in m_tblFunctionCollection)
            {
                if (tblfunction.FunctionName.ToLower() == _functionname.ToLower())
                {
                    return tblfunction;
                }
            }

            return null;
        }

        public tblFunction GetFunctionFromType(int _type)
        {

            foreach (tblFunction tblfunction in m_tblFunctionCollection)
            {
                if (tblfunction.Type == _type)
                {
                    return tblfunction;
                }
            }

            return null;
        }

        public tblController GetControllerobjectofPOUID(long id)
        {
            
                foreach (tblController tblcontroller in m_tblControllerCollection)
                {
                    foreach (tblPou tblpou in tblcontroller.m_tblPouCollection)
                    {
                        if (tblpou.pouID == id)
                        {
                            return tblcontroller;
                        }
                    }
                }
            
            return null;
        }

        public tblPou GetPouFromID(long id)
        {
            tblController tblcontroller = GetControllerobjectofPOUID(id);
            foreach (tblPou tblpou in tblcontroller.m_tblPouCollection)
            {
                if (tblpou.pouID == id)
                {
                    return tblpou;
                }
            }
            return null;
        }

        public tblPou GetGlobaltblPouObjectFromID(long id)
        {
            tblController tblcontroller = GetControllerobjectofPOUID(id);
            foreach (tblPou tblpou in tblcontroller.m_tblPouCollection)
            {
                if (tblpou.pouName == "GLOBAL")
                {
                    return tblpou;
                }
            }
            return null;
        }

        

        public bool IsFCSName(string _name,ref tblController _tblcontroller)
        {
            
            foreach (tblController tblcontroller in m_tblControllerCollection)
            {
                if (tblcontroller.ControllerName.ToLower() == _name.ToLower())
                {
                    _tblcontroller =  tblcontroller;
                    return true;
                }
            }
            return false;
        }
        public bool IsFCSName(string _name)
        {

            foreach (tblController tblcontroller in m_tblControllerCollection)
            {
                if (tblcontroller.ControllerName.ToLower() == _name.ToLower())
                {
                    return true;
                }
            }
            return false;
        }


        public bool IsHMIName(string _name, ref tblHMI _tblhmi)
        {

            foreach (tblHMI tblhmi in m_tblHMICollection)
            {
                if (tblhmi.HMIName.ToLower() == _name.ToLower())
                {
                    _tblhmi =  tblhmi;
                    return true;
                }
            }
            return false;
        }

        public bool IsHMIName(string _name)
        {

            foreach (tblHMI tblhmi in m_tblHMICollection)
            {
                if (tblhmi.HMIName.ToLower() == _name.ToLower())
                {
                    return true;
                }
            }
            return false;
        }

        public ItemType IsValidItem(string str)
        {
            int len;
            string _str = str.ToLower();
            string[] parts = _str.Split(new Char[] { '.' });
            len = parts.Length;
            if (len != 0)
            {
                tblController _tblcontroller = null;
                if(IsFCSName(parts[0],ref _tblcontroller ) )
                {
                    if (len == 1)
                    {
                        return ItemType.FCS;
                    }
                    else
                    {

                    }
                }

            }
            return ItemType.UNKNOWN;
        }



        public bool IsVariable(string _str, ref tblController _tblcontroller, ref tblVariable _tblvariable, ref tblFormalParameter _tblformalparameter, ref string _subpropertytxt, ref byte _subproperty, ref bool _isrefernce)
        {
            string str = "";
            int count = 0;
            _str = _str.ToLower();
            string[] varname = _str.Split(new Char[] { '.' });
            _subproperty = 0;
            count = varname.Length;
            // count = varname.Count();
            if (varname != null)
            {
                if (IsFCSName(varname[0], ref _tblcontroller))
                {
                    for (int i = 1; i < count; i++)
                    {
                        str += varname[i] + ".";
                    }
                    if (str != "")
                    {
                        str = str.Remove(str.Length - 1,1);
                        if (_tblcontroller.GetGlobalPOU().IsVariable(str, ref _tblvariable, ref _isrefernce, ref _tblformalparameter, ref  _subpropertytxt, ref _subproperty))
                        {

                        }
                    }
                    
                }
            }
            return false;
        }


#if OWSAPP
        public VALUE GetValueSub(long _id, uint _property, uint _subproperty)
        {
            return RTDB[_id].RealTimeData.GetValueSub(_property, _subproperty);
        }

        public VALUE GetValue(long _id, int _property)
        {
            //VALUE _v = new VALUE();
            // RTDB[_id]._any.m_Value = LCU.GetValue(_id, _property);
            return RTDB[_id].RealTimeData.GetValue(_property);
        }

        public void LockVariable(long _id, bool _lock)
        {
            VALUE _v = new VALUE();
            _v.BOOL = _lock;
            //LCU.SetValueSub(_id, (int)Prop_ANY.State_Property,StatusBar.);
        }

        public void SetAcknowledgeBit(long _id)
        {

            // LCU.SetAcknowledgeBit(_id);
        }

        public void SetAcknowledgeBits(long _id, int _subproperty)
        {

            //LCU.SetAcknowledgeBits(_id, _subproperty);
        }

        public void SetValue(long _id, int _property, VALUE _v)
        {

            //LCU.SetValue(_id, _property,_v.LINT);
        }

        public void SetValueSub(long _id, int _property, int _subproperty, VALUE _v)
        {

            //LCU.SetValueSub(_id, _property,_subproperty, _v.LINT);
        }

        public string GetBlockMode(int _mode)
        {
            string ret = "";
            int bitno;
            for (int j = 0; j < m_tblBlockModeTextCollection.Count; j++)
            {
                bitno = m_tblBlockModeTextCollection[j].Bit;
                if (Common.IsBitSet(_mode, bitno))
                {
                    ret = m_tblBlockModeTextCollection[j].Txt;
                    return ret;
                }
            }

            return ret;
        }

        public string GetBlockState(int _state)
        {
            string ret = "";
            int bitno;
            for (int j = 0; j < m_tblBlockStateTextCollection.Count; j++)
            {
                bitno = m_tblBlockStateTextCollection[j].Bit;
                if (Common.IsBitSet(_state, bitno))
                {
                    ret = m_tblBlockStateTextCollection[j].Txt;
                    return ret;
                }
            }

            return ret;
        }
        public string GetBlockAlarmStaus(int _als)
        {
            string ret = "";
            int bitno;
            for (int j = 0; j < m_tblBlockAlarmStatusTextCollection.Count; j++)
            {
                bitno = m_tblBlockAlarmStatusTextCollection[j].Bit;
                if (Common.IsBitSet(_als, bitno))
                {
                    ret = m_tblBlockAlarmStatusTextCollection[j].Txt;
                    return ret;
                }
            }

            return ret;
        }
        public bool GetBlockAlarmStausBlinking(int _ala)
        {
            bool ret = false;
            int bitno;
            for (int j = 0; j < m_tblBlockAlarmStatusTextCollection.Count; j++)
            {
                bitno = m_tblBlockAlarmStatusTextCollection[j].Bit;
                if (Common.IsBitSet(_ala, bitno))
                {

                    return true;
                }
            }

            return ret;
        }
        
#endif
#if EWSAPP

        //public bool SaveUDPOUs()
        //{

        //    bool ret = false;
        //    string str;
        //    string filename = "";
        //    string[] excludeArray = { "Pages", "ControllerID", "Description", "STText", "m_ControllerID_tblController", "m_tblFBDBlockCollection", "m_tblFBDPinConnectionCollection", "m_tblVariableCollection", "Headers", "headerString" };

        //    //long lng;
        //    Common.CheckFolderExist(Common.ProjectPath + "\\LOGIC");
        //    Common.CheckFolderExist(Common.ProjectPath + "\\LOGIC\\USERDEFINED");
        //    filename = Common.ProjectPath + "\\LOGIC\\USERDEFINED\\POU.db";

        //    using (StreamWriter writer = new StreamWriter(filename))
        //    {

        //        tblPou _tblpou = new tblPou();

        //        str = Common.convertType2StringHeader(_tblpou, excludeArray);
        //        writer.WriteLine(str);

        //        foreach (tblPou tblpou in tblSolution.m_tblSolution().Dummytblcontroller.m_tblPouCollection)
        //        {
        //            str = Common.convertType2String(tblpou, excludeArray);
        //            writer.WriteLine(str);
        //        }

        //        writer.Close();
        //    }
            
        //    return ret;
        //}

        public bool SaveNodesDB()
        {
            bool ret = true;

            int _nodeno;
            int _host1, _host2;
            string _net1, _net2;
            string filename = "";
            //long lng;
            filename = Common.ProjectPath + "\\Node.db";
            string str = "";
            _net1 = Net1;
            _net2 = Net2;
            using (StreamWriter writer = new StreamWriter(filename))
            {
                str = "NodeID;NodeNo;Type;NetNo;CPURedundant;NetworkRedundant";
                writer.WriteLine(str);

                foreach (tblController tblcontroller in tblSolution.m_tblSolution().m_tblControllerCollection)
                {
                    _nodeno = tblcontroller.NodeNumber;

                    str = tblcontroller.ControllerID.ToString();
                    str += ";";
                    str += _nodeno.ToString();
                    str += ";";
                    str += ((int)StationType.LCU).ToString(); ;
                    str += ";";
                    str += tblcontroller.NetNo.ToString();
                    str += ";";
                    str += tblcontroller.redundantnet.ToString();
                    str += ";";
                    str += tblcontroller.redundantnet.ToString();
                    str += ";";
                    writer.WriteLine(str);
                }



                foreach (tblHMI tblhmi in tblSolution.m_tblSolution().m_tblHMICollection)
                {
                    _nodeno = tblhmi.NodeNumber;
                    str = tblhmi.HMIID.ToString();
                    str += ";";
                    str += _nodeno.ToString();
                    str += ";";
                    str += ((int)StationType.OWS).ToString(); ;
                    str += ";";
                    str += tblhmi.NetNo.ToString();
                    str += ";";
                    str += tblhmi.Redundant.ToString();
                    str += ";";
                    str += tblhmi.redundantnet.ToString();
                    str += ";";

                    writer.WriteLine(str);
                }



                writer.Close();
            }
            return ret;

        }

#endif
    }

     public partial class tblSolutionCollection 
	{

        
	}
	
	
}
