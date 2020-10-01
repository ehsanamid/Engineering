
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Text;


using DCS.DCSTables;
using System.IO;
using System.Windows.Forms;
using System.Reflection;

namespace DCS.DCSTables
{

   
    public partial class tblController
    {
		public long PlantStructureID
		{
			get
			{
				foreach(tblPlantStructure tblplantstructure in tblSolution.m_tblSolution().m_tblPlantStructureCollection)
				{
					if(tblplantstructure.Name.ToUpper() == this.ControllerName.ToUpper())
					{
						return tblplantstructure.ID;
					}
				}
				tblPlantStructure _tblplantstructure = new tblPlantStructure();
				_tblplantstructure.Name = this.ControllerName;
				_tblplantstructure.Description = this.Description;
                _tblplantstructure.Type = (int)TBLPLANTSTRUCTURE_TYPE.LCU;
				_tblplantstructure.ParentID = -1;
				_tblplantstructure.Insert();
                tblSolution.m_tblSolution().m_tblPlantStructureCollection.Add(_tblplantstructure);
                return _tblplantstructure.ID;
			}
		}
        private bool _controllerisonline;

        public bool ControllerIsOnline
        {
            get
            {
                return _controllerisonline;
            }
            set
            {
                _controllerisonline = value;
            }
        }


        public override bool PostDeleteTriger()
        {
#if EWSAPP
            tblSolution.m_tblSolution().m_tblControllerCollection.Remove(this);
            tblSolution.m_tblSolution().SaveNodesDB(); 
#endif

            return true;
        }

        public override bool PostInsertTriger()
        {
#if EWSAPP
            if ((this.ControllerName != "USERDEFINED"))
            {
                tblPou tblpou = new tblPou();
                tblpou.ControllerID = this.ControllerID;
                tblpou.pouName = "GLOBAL";
                tblpou.Insert();
                tblSolution.m_tblSolution().SaveNodesDB();
            }
            string foldername = "";
            foldername = Common.ProjectPath + "\\LOGIC";
            foldername += "\\";
            foldername += this.ControllerName;
            Common.CreateFolder(foldername);

            tblSolution.m_tblSolution().m_tblControllerCollection.Add(this);

            tblPlantStructure _tblplantstructure = new tblPlantStructure();
            _tblplantstructure.Name = this.ControllerName;
            _tblplantstructure.Description = this.Description;
            _tblplantstructure.Type = (int)TBLPLANTSTRUCTURE_TYPE.LCU;
            _tblplantstructure.ParentID = -1;
            _tblplantstructure.Visible = false;
            _tblplantstructure.Insert();

            tblSolution.m_tblSolution().m_tblPlantStructureCollection.Add(_tblplantstructure);
            
#endif
            return true;
        }

        public override bool PostUpdateTriger()
        {
#if EWSAPP
            tblSolution.m_tblSolution().SaveNodesDB(); 
#endif
            return true;
        }

        

        public override void PostAddFromString(ref string arg2)
        {
            this.SolutionID = tblSolution.m_tblSolution().SolutionID;
            arg2 = "Import tblController " + this.ControllerName;
        }

        #region Public Methods

        public bool SaveDB()
        {
            //ResetCollection();
            //foreach (tblPou tblpou in m_tblPouCollection)
            //{
            //    tblpou.SaveFBD();
            //}
            string filename = "";
            //long lng;
            filename = Common.ProjectPath + "\\LOGIC";
            filename += "\\";
            filename += this.ControllerName;
            filename += "\\";
            //filename += this.ControllerName + ".dbf";
            filename += "Variable.dbf";  // 18092016 added
            if (System.IO.File.Exists(filename))
            {

                System.IO.File.Delete(filename);

            }

            bool ret = false;
            //OnlineSaveDB();
            SaveVariable();
            SavePouDB();
            if (ControllerName != "USERDEFINED")
            {
                SaveAlarmDB();
                SaveBoardDB();
                SaveAlarmGroupDB();
                tblSolution.m_tblSolution().Dummytblcontroller.SaveDB();
            }
            else
            {
                SaveUDFBTypeID();
            }
            return ret;
        }

        void SaveUDFBTypeID()
        {
            string filename = "";
            string str;
            filename = Common.ProjectPath + "\\LOGIC";
            filename += "\\";
            filename += this.ControllerName;
            filename += "\\UDFBTypeID.db";
            
            using (StreamWriter writer = new StreamWriter(filename))
            {
                str = "Type,IsFunction,FunctionID,POUID";
                writer.WriteLine(str);
                foreach (tblPou tblpou in m_tblPouCollection)
                {
                    foreach (tblFunction tblfunction in tblSolution.m_tblSolution().m_tblFunctionCollection)
                    {
                        if (tblfunction.FunctionName.ToUpper() == tblpou.pouName.ToUpper())
                        {
                            str = tblfunction.Type.ToString() + "," +tblfunction.IsFunction.ToString() + ","+ tblfunction.FunctionID.ToString() + "," + tblpou.pouID.ToString();
                            writer.WriteLine(str);
                        }
                    }
                }
                
                writer.Close();
            }
        }

        public bool OnlineSaveDB()
        {
            bool ret = false;
            //ResetCollection();

           

            OnlineSaveVariable();
            SavePouDB();
            SaveBoardDB();
            return ret;
        }

        public bool SaveBoardDB()
        {
            bool ret = false;
            string filename = "";
            string str;

            string[] excludeArray = { "ControllerID", "Description", "VariableID_DIG", "m_ControllerID_tblController", "m_tblChannelCollection", "Headers", "headerString" };
            //long lng;
            filename = Common.ProjectPath + "\\LOGIC";
            filename += "\\";
            //filename += this.DomainID.ToString();
            //filename += "\\";
            filename += this.ControllerName;
            filename += "\\Board.db";

            using (StreamWriter writer = new StreamWriter(filename))
            {

                tblBoard _tblboard = new tblBoard();

                str = Common.convertType2StringHeader(_tblboard, excludeArray);
                writer.WriteLine(str);
                foreach (tblBoard tblboard in this.m_tblBoardCollection)
                {
                    str = Common.convertType2String(tblboard, excludeArray);
                    writer.WriteLine(str);

                }

                writer.Close();
            }
            return ret;
        }


        public bool SavePouDB()
        {
            bool ret = false;
            string str;
            string filename = "";
            string[] excludeArray = { "Pages", "ControllerID", "Description", "STText", "m_ControllerID_tblController", "m_tblFBDBlockCollection", "m_tblFBDPinConnectionCollection", "m_tblVariableCollection", "Headers", "headerString","VariablesByName" };
            
            //long lng;
            filename = Common.ProjectPath + "\\LOGIC";
            filename += "\\";
            filename += this.ControllerName;
            filename += "\\POU.db";

            using (StreamWriter writer = new StreamWriter(filename))
            {

                tblPou _tblpou = new tblPou();

                str = Common.convertType2StringHeader(_tblpou, excludeArray);
                writer.WriteLine(str);

                foreach (tblPou tblpou in this.m_tblPouCollection)
                {
                    str = Common.convertType2String(tblpou, excludeArray);
                    writer.WriteLine(str);
                }

                writer.Close();
            }
            return ret;
        }

        //public bool SaveVariableDB(StreamWriter writer,int _type)
        //{
        //    bool ret = true;
        //    bool foundtype = false;
        //    string[] VarNameexcludeArray = {"VarNameID"};
        //    string str = "";
        //    List<int> ExistingTypes = new List<int>();
        //    foreach (tblPou tblpou in m_tblPouCollection)
        //    {
        //        foreach (tblVariable tblvariable in tblpou.m_tblVariableCollection)
        //        {
        //            if (tblvariable.Type == _type)
        //            {
        //                foundtype = true;
        //                break;
        //            }
        //        }
        //        if (foundtype)
        //        {
        //            break;
        //        }
        //    }

        //    if (foundtype)
        //    {
        //        Int32 index = 0;
        //        while (index < ExistingTypes.Count - 1)
        //        {
        //            if (ExistingTypes[index] == ExistingTypes[index + 1])
        //                ExistingTypes.RemoveAt(index);
        //            else
        //                index++;
        //        }


        //        for (int i = 0; i < ExistingTypes.Count; i++)
        //        {
        //            if (ExistingTypes[i] == (int)VarType.BOOL)
        //            {
        //                str = "Type=" + ExistingTypes[i].ToString();
        //                writer.WriteLine(str);
        //                tblVariable _tblvariable = new tblVariable();
        //                tblBOOL _tblbool = new tblBOOL();
        //                str = Common.GetType2StringHeader(_tblvariable, "VarNameID") + Common.GetType2StringHeader(_tblbool, "", VarNameexcludeArray);
        //                //str = str.Remove(str.Length - 1);
        //                writer.WriteLine(str);
        //                foreach (tblPou tblpou in m_tblPouCollection)
        //                {
        //                    foreach (tblVariable tblvariable in tblpou.m_tblVariableCollection)
        //                    {
        //                        if (ExistingTypes[i] == tblvariable.Type)
        //                        {
        //                            _tblbool = new tblBOOL();
        //                            _tblbool.VarNameID = tblvariable.VarNameID;
        //                            _tblbool.SelectVarID();
        //                            str = Common.GetType2String(tblvariable, "VarNameID") + Common.GetType2String(_tblbool, "", VarNameexcludeArray);
        //                            //str = str.Remove(str.Length - 1);
        //                            writer.WriteLine(str);
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //        for (int i = 0; i < ExistingTypes.Count; i++)
        //        {
        //            if (ExistingTypes[i] == (int)VarType.REAL)
        //            {
        //                str = "Type=" + ExistingTypes[i].ToString();
        //                writer.WriteLine(str);
        //                tblVariable _tblvariable = new tblVariable();
        //                tblREAL _tblreal = new tblREAL();
        //                str = Common.GetType2StringHeader(_tblvariable, "VarNameID") + Common.GetType2StringHeader(_tblreal, "", VarNameexcludeArray);
        //                //str = str.Remove(str.Length - 1);
        //                writer.WriteLine(str);
        //                foreach (tblPou tblpou in m_tblPouCollection)
        //                {
        //                    foreach (tblVariable tblvariable in tblpou.m_tblVariableCollection)
        //                    {
        //                        if (ExistingTypes[i] == tblvariable.Type)
        //                        {
        //                            _tblreal = new tblREAL();
        //                            _tblreal.VarNameID = tblvariable.VarNameID;
        //                            _tblreal.SelectVarID();
        //                            str = Common.GetType2String(tblvariable, "VarNameID") + Common.GetType2String(_tblreal, "", VarNameexcludeArray);
        //                            //str = str.Remove(str.Length - 1);
        //                            writer.WriteLine(str);
        //                        }
        //                    }
        //                }
        //            }
        //        }

        //        for (int i = 0; i < ExistingTypes.Count; i++)
        //        {
        //            if ((ExistingTypes[i] != (int)VarType.BOOL) && (ExistingTypes[i] != (int)VarType.REAL))
        //            {
        //                str = "Type=" + ExistingTypes[i].ToString();
        //                writer.WriteLine(str);
        //                tblVariable _tblvariable = new tblVariable();
        //                Common.convertType2StringHeader(_tblvariable, writer);
        //                foreach (tblPou tblpou in m_tblPouCollection)
        //                {
        //                    foreach (tblVariable tblvariable in tblpou.m_tblVariableCollection)
        //                    {
        //                        if (ExistingTypes[i] == tblvariable.Type)
        //                        {
        //                            str = Common.convertType2String(tblvariable);
        //                            writer.WriteLine(str);
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //        writer.Close();

        //    }
        //    return ret;
        //}

        

        public bool SaveVariable()
        {
            bool ret = true;
            string filename = "";
            string[] excludeArray = { "m_tblFInstanceVariableList", "Description", "PinState", "ParentVarID", "ParentVarLinkName", "ParentVarLinkID", "DispalyID", "UsedPOUID", "m_pouID_tblPou", "m_tblAlarmCollection", "Headers", "headerString", "m_tblBOOLCollection", "m_tblREALCollection" };
            //long lng;
            filename = Common.ProjectPath + "\\LOGIC";
            filename += "\\";
            filename += this.ControllerName;
            filename += "\\";
            filename += "Variable.db";
            List<int> ExistingTypes = new List<int>();
            foreach (tblPou tblpou in m_tblPouCollection)
            {
                foreach (tblVariable tblvariable in tblpou.m_tblVariableCollection)
                {
                    ExistingTypes.Add(tblvariable.Type);
                }
            }

            ExistingTypes.Sort();
            Int32 index = 0;
            while (index < ExistingTypes.Count - 1)
            {
                if (ExistingTypes[index] == ExistingTypes[index + 1])
                    ExistingTypes.RemoveAt(index);
                else
                    index++;
            }

            using (StreamWriter writer = new StreamWriter(filename))
            {
                for (int i = 0; i < ExistingTypes.Count; i++)
                {
                    switch ((VarType)ExistingTypes[i])
                    {
                        case VarType.BOOL:
                            SaveVariableDBBOOL(writer, ExistingTypes[i], excludeArray);
                            break;
                        case VarType.REAL:
                            SaveVariableDBREAL(writer, ExistingTypes[i], excludeArray);
                            break;
                        default:
                            SaveVariableDBOTHER(writer, ExistingTypes[i], excludeArray);
                            break;
                    }
                }
                writer.Close();
            }
            return ret;
        }

        public bool SaveVariableDBBOOL(StreamWriter writer, int _type, string[] excludeArray)
        {
            bool ret = false;
            string str = "";
            string[] exclude = { "VarNameID", "Headers", "headerString" };
            str = "Type=" + _type.ToString();
            writer.WriteLine(str);
            tblVariable _tblvariable = new tblVariable();
            tblBOOL _tblbool = new tblBOOL();
            str = "mod," + Common.GetType2StringHeader(_tblvariable, "VarNameID", excludeArray) + Common.GetType2StringHeader(_tblbool, "", exclude);
            //str = str.Remove(str.Length - 1);
            writer.WriteLine(str);
            foreach (tblPou tblpou in m_tblPouCollection)
            {
                foreach (tblVariable tblvariable in tblpou.m_tblVariableCollection)
                {
                    if (_type == tblvariable.Type)
                    {
                        _tblbool = new tblBOOL();
                        _tblbool.VarNameID = tblvariable.VarNameID;
                        _tblbool.SelectVarID();
                        str = "NEW," + Common.GetType2String(tblvariable, "VarNameID", excludeArray) + Common.GetType2String(_tblbool, "", exclude);
                        //str = str.Remove(str.Length - 1);
                        writer.WriteLine(str);
                    }
                }
            }
            return ret;
        }

        public bool SaveVariableDBREAL(StreamWriter writer, int _type, string[] excludeArray)
        {
            bool ret = false;
            string str = "";
            string[] exclude = { "VarNameID", "Headers", "headerString" };
            str = "Type=" + _type.ToString();
            writer.WriteLine(str);
            tblVariable _tblvariable = new tblVariable();
            tblREAL _tblreal = new tblREAL();
            str = "mod," + Common.GetType2StringHeader(_tblvariable, "VarNameID", excludeArray) + Common.GetType2StringHeader(_tblreal, "", exclude);
            //str = str.Remove(str.Length - 1);
            writer.WriteLine(str);
            foreach (tblPou tblpou in m_tblPouCollection)
            {
                foreach (tblVariable tblvariable in tblpou.m_tblVariableCollection)
                {
                    if (_type == tblvariable.Type)
                    {
                        _tblreal = new tblREAL();
                        _tblreal.VarNameID = tblvariable.VarNameID;
                        _tblreal.SelectVarID();
                        str = "NEW," + Common.GetType2String(tblvariable, "VarNameID", excludeArray) + Common.GetType2String(_tblreal, "", exclude);
                        //str = str.Remove(str.Length - 1);
                        writer.WriteLine(str);
                    }
                }
            }
            return ret;
        }

        public bool SaveVariableDBOTHER(StreamWriter writer, int _type, string[] excludeArray)
        {
            bool ret = false;
            string str = "";
            string[] exclude = { "VarNameID", "Headers", "headerString" };
            str = "Type=" + _type.ToString();
            writer.WriteLine(str);
            tblVariable _tblvariable = new tblVariable();
            //Common.convertType2StringHeader(_tblvariable, writer);

            str = "mod," + Common.GetType2StringHeader(_tblvariable, "VarNameID", excludeArray);
            //str = str.Remove(str.Length - 1);
            writer.WriteLine(str);

            foreach (tblPou tblpou in m_tblPouCollection)
            {
                foreach (tblVariable tblvariable in tblpou.m_tblVariableCollection)
                {
                    if (_type == tblvariable.Type)
                    {
                        //Common.convertType2String(tblvariable, writer);
                        str = "NEW," + Common.GetType2String(tblvariable, "VarNameID", excludeArray);
                        //str = str.Remove(str.Length - 1);
                        writer.WriteLine(str);
                    }
                }
            }
            return ret;
        }

        public bool OnlineSaveVariableDBBOOL(Dictionary<long, string> _treenodesdictionary, StreamWriter writer, int _type, string[] excludeArray)
        {
            bool ret = false;
            string str = "";
            string[] exclude = { "VarNameID" };
            str = "Type=" + _type.ToString();
            writer.WriteLine(str);
            tblVariable _tblvariable = new tblVariable();
            tblBOOL _tblbool = new tblBOOL();
            str = "mod," + Common.GetType2StringHeader(_tblvariable, "VarNameID", excludeArray) + Common.GetType2StringHeader(_tblbool, "", exclude);
            //str = str.Remove(str.Length - 1);
            writer.WriteLine(str);
            foreach (tblPou tblpou in m_tblPouCollection)
            {
                foreach (tblVariable tblvariable in tblpou.m_tblVariableCollection)
                {
                    if (_type == tblvariable.Type)
                    {
                        _tblbool = new tblBOOL();
                        _tblbool.VarNameID = tblvariable.VarNameID;
                        _tblbool.SelectVarID();
                        str = Common.GetType2String(tblvariable, "VarNameID", excludeArray) + Common.GetType2String(_tblbool, "", exclude);
                        //str = str.Remove(str.Length - 1);
                        if (_treenodesdictionary.ContainsKey(tblvariable.VarNameID)) // variable exist
                        {
                            if (str != _treenodesdictionary[tblvariable.VarNameID])
                            {
                                str = "UPDATE," + str;
                                writer.WriteLine(str);
                            }
                            _treenodesdictionary.Remove(tblvariable.VarNameID);
                        }
                        else //new variable
                        {
                            str = "NEW," + str;
                            writer.WriteLine(str);
                        }
                        
                    }
                }
            }
            return ret;
        }

        public bool OnlineSaveVariableDBREAL(Dictionary<long, string> _treenodesdictionary, StreamWriter writer, int _type, string[] excludeArray)
        {
            bool ret = false;
            string str = "";
            string[] exclude = { "VarNameID" };
            str = "Type=" + _type.ToString();
            writer.WriteLine(str);
            tblVariable _tblvariable = new tblVariable();
            tblREAL _tblreal = new tblREAL();
            str = "mod," + Common.GetType2StringHeader(_tblvariable, "VarNameID", excludeArray) + Common.GetType2StringHeader(_tblreal, "", exclude);
            //str = str.Remove(str.Length - 1);
            writer.WriteLine(str);
            foreach (tblPou tblpou in m_tblPouCollection)
            {
                foreach (tblVariable tblvariable in tblpou.m_tblVariableCollection)
                {
                    if (_type == tblvariable.Type)
                    {
                        _tblreal = new tblREAL();
                        _tblreal.VarNameID = tblvariable.VarNameID;
                        _tblreal.SelectVarID();
                        str = Common.GetType2String(tblvariable, "VarNameID", excludeArray) + Common.GetType2String(_tblreal, "", exclude);
                        //str = str.Remove(str.Length - 1);
                        if (_treenodesdictionary.ContainsKey(tblvariable.VarNameID)) // variable exist
                        {
                            if (str != _treenodesdictionary[tblvariable.VarNameID])
                            {
                                str = "UPDATE," + str;
                                writer.WriteLine(str);
                            }
                            _treenodesdictionary.Remove(tblvariable.VarNameID);
                        }
                        else //new variable
                        {
                            str = "NEW," + str;
                            writer.WriteLine(str);
                        }
                    }
                }
            }
            return ret;
        }

        public bool OnlineSaveVariableDBOTHER(Dictionary<long, string> _treenodesdictionary, StreamWriter writer, int _type, string[] excludeArray)
        {
            bool ret = false;
            string str = "";
            str = "Type=" + _type.ToString();
            writer.WriteLine(str);
            tblVariable _tblvariable = new tblVariable();
            str = "mod," + Common.GetType2StringHeader(_tblvariable, "VarNameID", excludeArray);
            //str = str.Remove(str.Length - 1);
            writer.WriteLine(str);
            foreach (tblPou tblpou in m_tblPouCollection)
            {
                foreach (tblVariable tblvariable in tblpou.m_tblVariableCollection)
                {
                    if (_type == tblvariable.Type)
                    {
                        //Common.convertType2String(tblvariable, writer);
                        str = Common.GetType2String(tblvariable, "VarNameID", excludeArray);
                       // str = str.Remove(str.Length - 1);
                        if (_treenodesdictionary.ContainsKey(tblvariable.VarNameID)) // variable exist
                        {
                            if (str != _treenodesdictionary[tblvariable.VarNameID])
                            {
                                str = "UPDATE," + str;
                                writer.WriteLine(str);
                            }
                            _treenodesdictionary.Remove(tblvariable.VarNameID);
                        }
                        else //new variable
                        {
                            str = "NEW," + str;
                            writer.WriteLine(str);
                        }
                    }
                }
            }
            return ret;
        }

        public bool OnlineSaveDeletedVariable(Dictionary<long, string> _treenodesdictionary, StreamWriter writer)
        {
            bool ret = false;
            string str = "";
            str = "Type=0";
            writer.WriteLine(str);
            tblVariable _tblvariable = new tblVariable();
            str = "mod,VarNameID";
            
            writer.WriteLine(str);
            foreach (long keyID in _treenodesdictionary.Keys )
            {
                str = "DELETE," + keyID.ToString(); 
                writer.WriteLine(str);
            }
            return ret;
        }

        //public bool SaveVariableDB( Dictionary<long, string> _treenodesdictionary=null)
        //{
        //    bool ret = true;
        //    string str = "";
        //    List<int> ExistingTypes = new List<int>();

        //    string filename = "";
        //    //long lng;
        //    filename = Common.ProjectPath + "\\LOGIC";
        //    filename += "\\";
        //    //filename += this.DomainID.ToString();
        //    //filename += "\\";
        //    filename += this.ControllerName;
        //    filename += "\\";
        //    filename += this.ControllerName + ".db";
        //    foreach (tblPou tblpou in m_tblPouCollection)
        //    {
        //        foreach (tblVariable tblvariable in tblpou.m_tblVariableCollection)
        //        {
        //            ExistingTypes.Add(tblvariable.Type);
        //        }
        //    }

        //    ExistingTypes.Sort();
        //    Int32 index = 0;
        //    while (index < ExistingTypes.Count - 1)
        //    {
        //        if (ExistingTypes[index] == ExistingTypes[index + 1])
        //            ExistingTypes.RemoveAt(index);
        //        else
        //            index++;
        //    }

        //    using (StreamWriter writer = new StreamWriter(filename))
        //    {
        //        for (int i = 0; i < ExistingTypes.Count; i++)
        //        {
        //            if (ExistingTypes[i] == (int)VarType.BOOL)
        //            {
        //                str = "Type=" + ExistingTypes[i].ToString();
        //                writer.WriteLine(str);
        //                tblVariable _tblvariable = new tblVariable();
        //                tblBOOL _tblbool = new tblBOOL();
        //                str = Common.GetType2StringHeader(_tblvariable, "VarNameID") + Common.GetType2StringHeader(_tblbool, "", "VarNameID");
        //               // str = str.Remove(str.Length - 1);
        //                writer.WriteLine(str);
        //                foreach (tblPou tblpou in m_tblPouCollection)
        //                {
        //                    foreach (tblVariable tblvariable in tblpou.m_tblVariableCollection)
        //                    {
        //                        if (ExistingTypes[i] == tblvariable.Type)
        //                        {
        //                            _tblbool = new tblBOOL();
        //                            _tblbool.VarNameID = tblvariable.VarNameID;
        //                            _tblbool.SelectVarID();
        //                            str = Common.GetType2String(tblvariable, "VarNameID") + Common.GetType2String(_tblbool, "", "VarNameID");
        //                            //str = str.Remove(str.Length - 1);
        //                            if (_treenodesdictionary != null)
        //                            {
        //                                if (_treenodesdictionary.ContainsKey(tblvariable.VarNameID)) // var not a new tag
        //                                {
        //                                    if (str == _treenodesdictionary[tblvariable.VarNameID])  // does not changed
        //                                    {

        //                                    }
        //                                    else
        //                                    {
        //                                        str = "UPDATE," + str;
        //                                    }
        //                                }
        //                                else
        //                                {
        //                                    str = "NEW," + str;
        //                                }
        //                                _treenodesdictionary.Remove(tblvariable.VarNameID);
        //                            }
        //                            writer.WriteLine(str);
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //        for (int i = 0; i < ExistingTypes.Count; i++)
        //        {
        //            if (ExistingTypes[i] == (int)VarType.REAL)
        //            {
        //                str = "Type=" + ExistingTypes[i].ToString();
        //                writer.WriteLine(str);
        //                tblVariable _tblvariable = new tblVariable();
        //                tblREAL _tblreal = new tblREAL();
        //                str = Common.GetType2StringHeader(_tblvariable, "VarNameID") + Common.GetType2StringHeader(_tblreal, "", "VarNameID");
        //                //str = str.Remove(str.Length - 1);
        //                writer.WriteLine(str);
        //                foreach (tblPou tblpou in m_tblPouCollection)
        //                {
        //                    foreach (tblVariable tblvariable in tblpou.m_tblVariableCollection)
        //                    {
        //                        if (ExistingTypes[i] == tblvariable.Type)
        //                        {
        //                            _tblreal = new tblREAL();
        //                            _tblreal.VarNameID = tblvariable.VarNameID;
        //                            _tblreal.SelectVarID();
        //                            str = Common.GetType2String(tblvariable, "VarNameID") + Common.GetType2String(_tblreal, "VarNameID", "VarNameID");
        //                            //str = str.Remove(str.Length - 1);
        //                            writer.WriteLine(str);
        //                        }
        //                    }
        //                }
        //            }
        //        }

        //        for (int i = 0; i < ExistingTypes.Count; i++)
        //        {
        //            if ((ExistingTypes[i] != (int)VarType.BOOL) && (ExistingTypes[i] != (int)VarType.REAL))
        //            {
        //                str = "Type=" + ExistingTypes[i].ToString();
        //                writer.WriteLine(str);
        //                tblVariable _tblvariable = new tblVariable();
        //                Common.convertType2StringHeader(_tblvariable, writer);
        //                foreach (tblPou tblpou in m_tblPouCollection)
        //                {
        //                    foreach (tblVariable tblvariable in tblpou.m_tblVariableCollection)
        //                    {
        //                        if (ExistingTypes[i] == tblvariable.Type)
        //                        {
        //                            str = Common.convertType2String(tblvariable);
        //                            writer.WriteLine(str);

        //                        }
        //                    }
        //                }
        //            }
        //        }
        //        writer.Close();

        //    }
        //    return ret;
        //}

        public bool SaveAlarmDB(Dictionary<long, string> _treenodesdictionary = null)
        {
            bool ret = true;
            string str = "";
            string[] excludeArray = { "m_VarNameID_tblVariable", "Headers", "headerString" };
            List<int> ExistingTypes = new List<int>();
            bool firsttime = true;
            string filename = "";
            //long lng;
            filename = Common.ProjectPath + "\\LOGIC";
            filename += "\\";
            //filename += this.DomainID.ToString();
            //filename += "\\";
            filename += this.ControllerName;
            filename += "\\";
            filename += this.ControllerName + ".al";
            
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (tblPou tblpou in m_tblPouCollection)
                {
                    foreach (tblVariable tblvariable in tblpou.m_tblVariableCollection)
                    {
                        foreach (tblAlarm tblalarm in tblvariable.m_tblAlarmCollection)
                        {
                            if (firsttime)
                            {
                                str = "mod," + Common.GetType2StringHeader(tblalarm, "VarNameID", excludeArray);
                                writer.WriteLine(str);
                                firsttime = false;
                            }
                            str = "NEW," + Common.GetType2String(tblalarm, "VarNameID", excludeArray);
                            writer.WriteLine(str);
                        }
                    }
                }
                writer.Close();
            }


            return ret;
        }

        public bool SaveAlarmGroupDB()
        {
            bool ret = true;
            string str = "";
            List<int> ExistingTypes = new List<int>();
            string[] excludeArray = { "SolutionID", "m_SolutionID_tblSolution", "Headers", "headerString" };
            bool firsttime = true;
            string filename = "";
            //long lng;
            filename = Common.ProjectPath + "\\LOGIC";
            filename += "\\";
            //filename += this.DomainID.ToString();
            //filename += "\\";
            filename += this.ControllerName;
            filename += "\\";
            filename +=  "AlarmGroup.gal";
            

            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach(tblAlarmGroup tblalarmgroup in tblSolution.m_tblSolution().m_tblAlarmGroupCollection)
                {
                    if (firsttime)
                    {
                        str = "mod," + Common.GetType2StringHeader(tblalarmgroup, "ID",excludeArray);
                        writer.WriteLine(str);
                        firsttime = false;
                    }
                    str = "NEW," + Common.GetType2String(tblalarmgroup, "ID", excludeArray);
                    writer.WriteLine(str);
                }
                writer.Close();
            }


            return ret;
        }


        public bool OnlineSaveVariable()
        {
            bool ret = true;
            string[] excludeArray = { "m_tblFInstanceVariableList", "Description", "PinState", "ParentVarID", "ParentVarLinkName", "ParentVarLinkID", "DispalyID", "UsedPOUID", "m_pouID_tblPou", "m_tblAlarmCollection" };
            
            Dictionary<long, string> _treenodesdictionary = new Dictionary<long, string>();
            //List<string> diffstringlist = new List<string>();
            string filename = "";
            //long lng;
            try
            {

                filename = Common.ProjectPath + "\\LOGIC";
                filename += "\\";
                filename += this.ControllerName;
                filename += "\\";
                filename += this.ControllerName + ".db";
                string str = "";

                using (StreamReader reader = new StreamReader(filename))
                {
                    while ((str = reader.ReadLine()) != null)
                    {
                        if (!(str.StartsWith("Type=") || str.StartsWith("mod")))
                        {
                            string[] splitstring = str.Split(',');
                            if (str.StartsWith("NEW,"))
                            {
                                str = str.Remove(0,4);
                            }
                            else
                            {

                            }
                            _treenodesdictionary[long.Parse(splitstring[1])] = str;
                        }
                    }
                    reader.Close();
                }



                filename = "";
                //long lng;
                filename = Common.ProjectPath + "\\LOGIC";
                filename += "\\";
                //filename += this.DomainID.ToString();
                //filename += "\\";
                filename += this.ControllerName;
                filename += "\\";
                filename += this.ControllerName + ".dbf";
                List<int> ExistingTypes = new List<int>();
                foreach (tblPou tblpou in m_tblPouCollection)
                {
                    foreach (tblVariable tblvariable in tblpou.m_tblVariableCollection)
                    {
                        ExistingTypes.Add(tblvariable.Type);
                    }
                }

                ExistingTypes.Sort();
                Int32 index = 0;
                while (index < ExistingTypes.Count - 1)
                {
                    if (ExistingTypes[index] == ExistingTypes[index + 1])
                        ExistingTypes.RemoveAt(index);
                    else
                        index++;
                }

                using (StreamWriter writer = new StreamWriter(filename))
                {
                    for (int i = 0; i < ExistingTypes.Count; i++)
                    {
                        switch ((VarType)ExistingTypes[i])
                        {
                            case VarType.BOOL:
                                OnlineSaveVariableDBBOOL(_treenodesdictionary, writer, ExistingTypes[i], excludeArray);
                                break;
                            case VarType.REAL:
                                OnlineSaveVariableDBREAL(_treenodesdictionary, writer, ExistingTypes[i], excludeArray);
                                break;
                            default:
                                OnlineSaveVariableDBOTHER(_treenodesdictionary, writer, ExistingTypes[i], excludeArray);
                                break;
                        }
                    }
                    if (_treenodesdictionary.Count > 0)
                    {
                        OnlineSaveDeletedVariable(_treenodesdictionary, writer);
                    }
                    writer.Close();
                }
            }
            catch (FileNotFoundException ex)
            {

            }
            return ret;
        }
        private bool ReadDB()
        {
            Dictionary<long, string> _treenodesdictionary = new Dictionary<long, string>();
            List<string> diffstringlist = new List<string>();
            bool ret = false;
            string filename = "";
            //long lng;
            int i;
            
            filename = Common.ProjectPath + "\\LOGIC";
            filename += "\\";
            filename += this.ControllerName;
            filename += "\\";
            filename += this.ControllerName + ".db";
            string str = "";
            
            
            //bool found = false;

            
            
            using (StreamReader reader = new StreamReader(filename))
            {
                while ((str = reader.ReadLine()) != null)
                {
                    if (!(str.StartsWith("Type=") || str.StartsWith("mod")))
                    {
                        string[] splitstring = str.Split(',');
                        _treenodesdictionary[long.Parse(splitstring[1])] = str;
                    }
                }
                reader.Close();
            }

            
            if (diffstringlist.Count > 0)
            {

                filename = Common.ProjectPath + "\\LOGIC";
                filename += "\\";

                filename += this.ControllerName;
                filename += "\\";
                filename += this.ControllerName + ".df";
                using (StreamWriter writer = new StreamWriter(filename))
                {
                    for (i = 0; i < diffstringlist.Count; i++)
                    {
                        writer.WriteLine(diffstringlist[i]);
                    }
                    writer.Close();
                }
            }
            SaveDB();

            return ret;
        }



        public void ResetCollection()
        {
            foreach (tblPou tblpou in m_tblPouCollection)
            {
                tblpou.ResetCollection();
            }

            foreach (tblBoard tblboard in m_tblBoardCollection)
            {
                tblboard.ResetCollection();
            }
        }

        public static void SelectAllPou(string ConnectionString, List<int> controllerlist)
        {
            int pouid;
           // int count = 0;
            List<int> poulist = new List<int>();
            int _controllerid;
            try
            {
                for (int i = 0; i < controllerlist.Count; i++)
                {

                    poulist.Clear();
                    _controllerid = controllerlist[i];
                    if ((_controllerid == 64) || (_controllerid == 65) || (_controllerid == 66) || (_controllerid == 67))
                    {
                        if (Common.Conn == null)
                        {
                            Common.Conn = new SQLiteConnection(Common.ConnectionString);
                            Common.Conn.Open();
                        }
                        SQLiteCommand Com = Common.Conn.CreateCommand();

                        Com.CommandText = "SELECT [pouName], [pouID], [Description], [Type], [Language], [oIndex] FROM [tblPou] WHERE [ControllerID]=" + _controllerid + " order by oIndex; ";
                        //Conn.Open();
                        SQLiteDataReader rs = Com.ExecuteReader();
                        while (rs.Read())
                        {
                            pouid = rs.GetInt32(rs.GetOrdinal("pouID"));
                            poulist.Add(pouid);

                        }
                        rs.Close();
                        //Conn.Close();
                        rs.Dispose();
                        Com.Dispose();
                        //Conn.Dispose();
                        //tblPou.ReindexPou(ConnectionString, poulist);
                    }
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        public static int GetControllerID(string ConnectionString, string controllername, string domainanme)
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
                Com.CommandText = "SELECT tblController.ControllerID FROM tblDomain, tblController WHERE tblcontroller.domainid=tbldomain.domainid AND tblController.ControllerName = '" + controllername + "' AND tblDomain.DomainName = '" + domainanme + "'";

                //Conn.Open();
                SQLiteDataReader rs = Com.ExecuteReader();
                while (rs.Read())
                {

                    ret = rs.GetInt32(rs.GetOrdinal("ControllerID"));
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


        public tblPou GetPouFromID(long id)
        {
            foreach (tblPou tblpou in m_tblPouCollection)
            {
                if (tblpou.pouID == id)
                {
                    return tblpou;
                }
            }
            return null;
        }

        #endregion

        #region Private Methods

        #endregion


        public void ReindexPOUs()
        {
            int index = 0;
            long ID;

            if (Common.Conn == null)
            {
                Common.Conn = new SQLiteConnection(Common.ConnectionString);
                Common.Conn.Open();
            }
            SQLiteDataReader myReader = null;
            SQLiteCommand myCommand = new SQLiteCommand();
            myReader = null;
            myCommand.CommandText = "Select * from tblPou where ControllerID = " + this.ControllerID  + " order by oIndex;";
            myCommand.Connection = Common.Conn;
            myReader = myCommand.ExecuteReader();
            while (myReader.Read())
            {
                ID = myReader.GetInt64(myReader.GetOrdinal("pouID"));
                tblPou tblpou = tblSolution.m_tblSolution().GetControllerFromID(this.ControllerID).GetPouFromID(ID);
                if ((tblpou.pouName == "GLOBAL") && (tblpou.oIndex != 0))
                {
                    tblpou.oIndex = 0;
                    tblpou.Update();
                }
                if ((tblpou.pouName != "GLOBAL") && (tblpou.oIndex != index))
                {
                    tblpou.oIndex = index;
                    tblpou.Update();
                }
                index++;
            }
            
            myReader.Close();
            myCommand.Dispose();
        }

        public void MoveUpPOU(int _index)
        {
            long ID;
            long ID1 = 0;
            long ID2 = 0;
            int index;

            if (Common.Conn == null)
            {
                Common.Conn = new SQLiteConnection(Common.ConnectionString);
                Common.Conn.Open();
            }
            SQLiteDataReader myReader = null;
            SQLiteCommand myCommand = new SQLiteCommand();
            myReader = null;
            myCommand.CommandText = "Select * from tblPou where ControllerID = " + this.ControllerID + " order by oIndex;";
            myCommand.Connection = Common.Conn;
            myReader = myCommand.ExecuteReader();
            while (myReader.Read())
            {
                ID = myReader.GetInt64(myReader.GetOrdinal("pouID"));
                index = myReader.GetInt32(myReader.GetOrdinal("oIndex"));
                if (index == _index)
                {
                    ID2 = ID;
                }
                if (index == (_index-1))
                {
                    ID1 = ID;
                }
            }
            tblPou tblpou1 = tblSolution.m_tblSolution().GetControllerFromID(this.ControllerID).GetPouFromID(ID1);
            tblpou1.oIndex = _index;
            tblpou1.Update();
            tblPou tblpou2 = tblSolution.m_tblSolution().GetControllerFromID(this.ControllerID).GetPouFromID(ID2);
            tblpou2.oIndex = _index-1;
            tblpou2.Update();



            myReader.Close();
            myCommand.Dispose();
        }

        public void MoveDownPOU(int _index)
        {
            long ID;
            long ID1 = 0;
            long ID2 = 0;
            int index;

            if (Common.Conn == null)
            {
                Common.Conn = new SQLiteConnection(Common.ConnectionString);
                Common.Conn.Open();
            }
            SQLiteDataReader myReader = null;
            SQLiteCommand myCommand = new SQLiteCommand();
            myReader = null;
            myCommand.CommandText = "Select * from tblPou where ControllerID = " + this.ControllerID + " order by oIndex;";
            myCommand.Connection = Common.Conn;
            myReader = myCommand.ExecuteReader();
            while (myReader.Read())
            {
                ID = myReader.GetInt64(myReader.GetOrdinal("pouID"));
                index = myReader.GetInt32(myReader.GetOrdinal("oIndex"));
                if (index == _index)
                {
                    ID2 = ID;
                }
                if (index == (_index + 1))
                {
                    ID1 = ID;
                }
            }
            tblPou tblpou1 = tblSolution.m_tblSolution().GetControllerFromID(this.ControllerID).GetPouFromID(ID1);
            tblpou1.oIndex = _index;
            tblpou1.Update();
            tblPou tblpou2 = tblSolution.m_tblSolution().GetControllerFromID(this.ControllerID).GetPouFromID(ID2);
            tblpou2.oIndex = _index + 1;
            tblpou2.Update();



            myReader.Close();
            myCommand.Dispose();
        }


        public bool CheckPOUNameExist(string name)
        {
            bool findnewname = true;
            if (Common.Conn == null)
            {
                Common.Conn = new SQLiteConnection(Common.ConnectionString);
                Common.Conn.Open();
            }
            SQLiteDataReader myReader = null;
            SQLiteCommand myCommand = new SQLiteCommand();
            myReader = null;
            myCommand.CommandText = "Select * from tblPou where (ControllerID = " + this.ControllerID + " and PouName = '" + name + "')";
            myCommand.Connection = Common.Conn;
            myReader = myCommand.ExecuteReader();
            if (myReader.HasRows == false)
            {
                findnewname = false;
            }
            myReader.Close();
            myCommand.Dispose();
            return findnewname;
        }

        public bool CheckPouName(string name)
        {
            return true;
        }

        public tblPou GetPouFromID(int _pouid)
        {

            foreach (tblPou tblpou in m_tblPouCollection)
            {
                if (tblpou.pouID == _pouid)
                {
                    return tblpou;
                }
            }
            return null;
        }

        public tblPou GetPouFromName(string name)
        {

            foreach (tblPou tblpou in m_tblPouCollection)
            {
                if (tblpou.pouName.ToLower() == name.ToLower())
                {
                    return tblpou;
                }
            }
            return null;
        }

        public string GetNewPOUName()
        {
            int No = 0;
            string str1 = "";
            try
            {
                do
                {
                    No++;
                    str1 = "POU_" + No.ToString();
                }
                while (CheckPOUNameExist(str1));
                
                return str1;
            }
            catch (SQLiteException ae)
            {
                MessageBox.Show(ae.Message);
                return "";
            }
        }


        //public bool GetNewControllerName(long _domainid, ref string strControllerName, ref int intNodeNumber)
        //{


        //    if (Common.Conn == null)
        //    {
        //        Common.Conn = new SQLiteConnection(Common.ConnectionString+"; Password="+Common.PassString+Common.WordString+";");
        //        Common.Conn.Open();
        //    }

        //    int No = 1;
        //    string str = "Controller";
        //    string str1 = "dd";
        //    bool findnewname = false;
        //    SQLiteDataReader myReader = null;
        //    SQLiteCommand myCommand = new SQLiteCommand();
        //    //if (_SqlConnectionConnection.State == System.Data.ConnectionState.Open)
        //    //    _SqlConnectionConnection.Close();
        //    //_SqlConnectionConnection.ConnectionString = Common.ConnectionString;
        //    //_SqlConnectionConnection.Open();
        //    try
        //    {
        //        findnewname = false;
        //        No = 1;
        //        while (findnewname == false)
        //        {
        //            myReader = null;
        //            str1 = str + No.ToString();
        //            //myCommand = new SqlCommand("Select Name from tblDomain where (Name = " + i.ToString() + ")", conn);
        //            myCommand.CommandText = "Select ControllerName,DomainID from tblController where (ControllerName = '" + str1 + "' and DomainID = '" + _domainid + "')";
        //            myCommand.Connection = Common.Conn;
        //            myReader = myCommand.ExecuteReader();
        //            if (myReader.HasRows == false)
        //            {
        //                findnewname = true;
        //            }
        //            else
        //            {
        //                No++;
        //            }
        //            myReader.Close();
        //            myCommand.Dispose();

        //        }
        //        strControllerName = str1;
        //    }
        //    catch (SQLiteException ae)
        //    {
        //        MessageBox.Show(ae.Message);
        //        return false;
        //    }
        //    try
        //    {

        //        findnewname = false;
        //        No = 1;
        //        while (findnewname == false)
        //        {
        //            myReader = null;
        //            str1 = str + No.ToString();
        //            myCommand.CommandText = "Select ControllerName,DomainID,NodeNumber from tblController where (DomainID = " + _domainid + "and NodeNumber =" + No.ToString() + ")";
        //            myCommand.Connection = Common.Conn;
        //            myReader = myCommand.ExecuteReader();
        //            if (myReader.HasRows == false)
        //            {
        //                findnewname = true;
        //            }
        //            else
        //            {
        //                No++;
        //            }
        //            myReader.Close();
        //            myCommand.Dispose();
        //        }

        //        intNodeNumber = No;
        //    }
        //    catch (SQLiteException ae)
        //    {


        //        // MessageBox.Show(ae.Message.ToString());
        //        return false;
        //    }
        //    //_SqlConnectionConnection.Close();
        //    return true;
        //}

        //public bool IsVariable(string _pouname, string _variablename, string _propertyname, ref tblVariable _tblvariable, ref tblFormalParameter _tblformalparameter)
        //{
        //    foreach (tblPou tblpou in m_tblPouCollection)
        //    {
        //        if (tblpou.pouName.ToLower() == _pouname)
        //        {
        //            if (tblpou.IsVariable(_variablename, _propertyname, ref  _tblvariable, ref  _tblformalparameter))
        //            {
        //                return true;
        //            }
        //            else
        //            {
        //                return false;
        //            }
        //        }
        //    }
        //    return false;
        //}

        public tblPou GetGlobalPOU()
        {
            foreach (tblPou tblpou in m_tblPouCollection)
            {
                if (tblpou.pouName == "GLOBAL")
                {
                    return tblpou;
                }
            }
            return null;
        }

        public bool BoardExist(string _name, ref tblBoard _tblboard)
        {
            string tempstr = _name.ToLower();
            foreach (tblBoard tblboard in m_tblBoardCollection)
            {
                if (tblboard.BoardName.ToLower() == tempstr)
                {
                    _tblboard = tblboard;
                    return true;

                }
            }
            return false;
        }

    }


    public partial class tblControllerCollection
    {
        


        /*
         public bool Load(long _domainid = -1)
         {
             bool ret = true;
             List<long> idlist = new List<long>();
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
                 if (_domainid == -1)
                 {
                     myCommand.CommandText = @"SELECT * FROM [tblController] ";
                 }
                 else
                 {
                     myCommand.CommandText = @"SELECT * FROM [tblController]  WHERE [DomainID]= " + _domainid + " order by oIndex;";
                 }
                 myCommand.Connection = _SqlConnectionConnection;
                 myReader = myCommand.ExecuteReader();
                 while (myReader.Read())
                 {
                     idlist.Add(myReader.GetInt64(myReader.GetOrdinal("ControllerID")));
                 }

                 myReader.Close();
                 myCommand.Dispose();
                 _SqlConnectionConnection.Close();

                 foreach (long id in idlist)// (int i = 0; i < count ; i++)
                 {
                     tblController tblcontroller = new tblController();
                     tblcontroller.ControllerID = id;
                     tblcontroller.Select();
                     tblcontroller.m_tblPouCollection.Load( tblcontroller.ControllerID);
                     tblcontroller.m_tblBoardCollection.Load(tblcontroller.ControllerID);
                     Add(tblcontroller);
                 }

             }
             catch (SQLiteException ae)
             {
                 return false;
                 // MessageBox.Show(ae.Message.ToString());
             }
            


             return ret;
         }

         */

        public override bool Load()
        {
            bool ret = true;
           // List<long> idlist = new List<long>();
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

                myCommand.CommandText = @"SELECT * FROM [tblController]  WHERE [SolutionID]= " + m_SolutionID_tblSolution.SolutionID + " order by oIndex;";

                myCommand.Connection = Common.Conn;
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {

                    tblController tblcontroller = new tblController();
                    tblcontroller.m_SolutionID_tblSolution = this.m_SolutionID_tblSolution;
                    tblcontroller.AddFromRecordSet(myReader);
                    Add(tblcontroller);
                }

                myReader.Close();
                myCommand.Dispose();
                //_SqlConnectionConnection.Close();

                //foreach (long id in idlist)// (int i = 0; i < count ; i++)
                //{
                //    tblController tblcontroller = new tblController();
                //    tblcontroller.ControllerID = id;
                //    tblcontroller.m_SolutionID_tblSolution = this.m_SolutionID_tblSolution;
                //    tblcontroller.Select();
                //    //tblcontroller.m_tblPouCollection.Load(/*tblcontroller.ControllerID*/);
                //    //tblcontroller.m_tblBoardCollection.Load(/*tblcontroller.ControllerID*/);
                //    Add(tblcontroller);
                //}

            }
            catch (SQLiteException ae)
            {
                MessageBox.Show(ae.Message);
                return false;
            }



            return ret;
        }

        [Description("Gets a  tblController from the collection.")]
        public tblController GetObjectFromID(long id)
        {
            foreach (tblController tblcontroller in List)
            {
                if (tblcontroller.ControllerID == id)
                {
                    return tblcontroller;
                }
            }
            return null;
        }
    }


}
