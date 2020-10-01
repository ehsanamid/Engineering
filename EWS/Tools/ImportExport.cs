using DCS.DCSTables;
using DCS.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DCS.Tools
{
    public class ImportExport
    {
        //MainForm ParentMainForm;
        public ImportExport(MainForm _parent)
        {
            //ParentMainForm = _parent;
        }


        public void AddControllers(string filename)
        {
            if (MainForm.Instance().CurrentUser.SystemExplorer != (int)EXPLORER_ACCESS.Full)
            {
                System.Windows.Forms.MessageBox.Show("current user cannot add any Contrller");
            }
            if (!File.Exists(filename))
            {
                DCS.Forms.MainForm.Instance().WriteToOutputWindows("File " + filename + " does not exist");
                return;
            }
            int ret = 0;
            string str;
            string _log = "";
            bool headerline = true;
            tblController tblcontroller = new tblController();
            
            using (StreamReader reader = new StreamReader(filename))
            {
                while ((str = reader.ReadLine()) != null)
                {
                    str.Replace(",,", ", ,");
                    if (str.StartsWith("!"))
                    {
                        continue;
                    }
                    if (headerline)
                    {
                        tblcontroller.headerString = str;
                        headerline = false;
                    }
                    else
                    {
                        string[] _strs = str.Split(new Char[] { ',' });
                        tblcontroller = new tblController();
                        tblcontroller.AddFromString(_strs, "", ref _log);

                        if ((ret = tblcontroller.Insert()) != 0)
                        {
                            if (ret == 19)
                            {
                                DCS.Forms.MainForm.Instance().WriteToOutputWindows(_log + " Already exist in database");
                            }
                        }
                        else
                        {
                            tblSolution.m_tblSolution().m_tblControllerCollection.Add(tblcontroller);
                        }
                    }
                }
                reader.Close();
            }
        }

        public void AddPOU(string filename, string controllername)
        {
            if (MainForm.Instance().CurrentUser.LogicExplorer != (int)EXPLORER_ACCESS.Full)
            {
                System.Windows.Forms.MessageBox.Show("current user cannot add any Contrller");
            }
            if (!File.Exists(filename))
            {
                DCS.Forms.MainForm.Instance().WriteToOutputWindows("File " + filename + " does not exist");
                return;
            }
            int ret = 0;
            string str;
            string _log = "";
            int ControllerNameCol = -1;
            bool headerline = true;
            tblPou tblpou = new tblPou();
            tblController tblcontroller = tblSolution.m_tblSolution().GetControllerFromName(controllername);
            if (tblcontroller == null)
            {
                DCS.Forms.MainForm.Instance().WriteToOutputWindows("Import POU Error controller " + controllername + " does not exist in database");
                return;
            }
            using (StreamReader reader = new StreamReader(filename))
            {
                while ((str = reader.ReadLine()) != null)
                {
                    str.Replace(",,", ", ,");
                    if (str.StartsWith("!"))
                    {
                        continue;
                    }
                    if (headerline)
                    {
                        tblpou.headerString = str;
                        headerline = false;
                        ControllerNameCol = tblpou.ColumnExistInHeader("ControllerName");
                        if (ControllerNameCol == -1)
                        {
                            DCS.Forms.MainForm.Instance().WriteToOutputWindows("POU add error: ControllerName column does not exist in " + filename);
                            break;
                        }
                    }
                    else
                    {
                        tblpou = new tblPou();
                        string[] _strs = str.Split(new Char[] { ',' });
                        if (_strs[ControllerNameCol].ToLower() == controllername)
                        {
                            tblpou.AddFromString(_strs, _strs[ControllerNameCol], ref _log);
                            tblpou.ControllerID = tblcontroller.ControllerID;
                            if ((ret = tblpou.Insert()) != 0)
                            {
                                if (ret == 19)
                                {
                                    DCS.Forms.MainForm.Instance().WriteToOutputWindows(_log + " Already exist in database");
                                }
                            }
                            else
                            {
                                tblcontroller.m_tblPouCollection.Add(tblpou);
                            }
                        }
                    }
                }
                reader.Close();
            }
        }
        public void importBoard(string filename)
        {
            if (MainForm.Instance().CurrentUser.SystemExplorer != (int)EXPLORER_ACCESS.Full)
            {
                System.Windows.Forms.MessageBox.Show("current user cannot add any Contrller");
            }
            if (!File.Exists(filename))
            {
                DCS.Forms.MainForm.Instance().WriteToOutputWindows("File " + filename + " does not exist");
                return;
            }
        }
        public void importChannel(string filename)
        {
            if (!File.Exists(filename))
            {
                DCS.Forms.MainForm.Instance().WriteToOutputWindows("File " + filename + " does not exist");
                return;
            }
        }
        public void AddVariable(string filename, string controllername, string pouname)
        {
            if (MainForm.Instance().CurrentUser.LogicExplorer != (int)EXPLORER_ACCESS.Full)
            {
                System.Windows.Forms.MessageBox.Show("current user cannot add any Contrller");
            }
            if (!File.Exists(filename))
            {
                DCS.Forms.MainForm.Instance().WriteToOutputWindows("File " + filename + " does not exist");
                return;
            }
            int ControllerNameCol = -1;
            int pouNameCol = -1;
            int ret = 0;
            string str;
            string _log = "";
            bool headerline = true;
            tblVariable tblvariable = new tblVariable();
            tblController tblcontroller = tblSolution.m_tblSolution().GetControllerFromName(controllername);
            if (tblcontroller == null)
            {
                DCS.Forms.MainForm.Instance().WriteToOutputWindows("Import Variable Error: controller " + controllername + " does not exist in database");
                return;
            }
            tblPou tblpou = tblcontroller.GetPouFromName(pouname);
            if (tblpou == null)
            {
                DCS.Forms.MainForm.Instance().WriteToOutputWindows("Import Variable Error: pou " + pouname + " does not exist in " + controllername);
                return;
            }
            // var transaction = Common.Conn.BeginTransaction();
            using (StreamReader reader = new StreamReader(filename))
            {
                while ((str = reader.ReadLine()) != null)
                {
                    str.Replace(",,", ", ,");
                    if (str.StartsWith("!"))
                    {
                        continue;
                    }
                    if (headerline)
                    {
                        tblvariable.headerString = str;
                        headerline = false;
                        ControllerNameCol = tblvariable.ColumnExistInHeader("ControllerName");
                        if (ControllerNameCol == -1)
                        {
                            DCS.Forms.MainForm.Instance().WriteToOutputWindows("Variable add error: ControllerName column does not exist in " + filename);
                            break;
                        }
                        pouNameCol = tblvariable.ColumnExistInHeader("pouName");
                        if (pouNameCol == -1)
                        {
                            DCS.Forms.MainForm.Instance().WriteToOutputWindows("Variable add error: pouName column does not exist in " + filename);
                            break;
                        }
                    }
                    else
                    {
                        tblvariable = new tblVariable();
                        string[] _strs = str.Split(new Char[] { ',' });

                        //if (_strs[ControllerNameCol].ToLower() != controllername)
                        //{
                        //    continue;
                        //}

                        if ((_strs[ControllerNameCol].ToLower() == controllername) && (_strs[pouNameCol].ToLower() == pouname))
                        {
                            tblvariable.AddFromString(_strs, _strs[pouNameCol], ref _log);
                            tblvariable.pouID = tblpou.pouID;
                            if ((ret = tblvariable.Insert()) != 0)
                            {
                                if (ret == 19)
                                {
                                    DCS.Forms.MainForm.Instance().WriteToOutputWindows(_log + " Already exist in database");
                                }

                            }
                            else
                            {
                                tblpou.m_tblVariableCollection.Add(tblvariable);
                            }

                        }
                    }

                }
                reader.Close();
            }
            // transaction.Commit();
        }

        //public void importBOOL(string filename,string controllername)

        public void AddBOOL(string filename, string controllername, string pouname)
        {
            if (MainForm.Instance().CurrentUser.LogicExplorer != (int)EXPLORER_ACCESS.Full)
            {
                System.Windows.Forms.MessageBox.Show("current user cannot add any Contrller");
            }
            if (!File.Exists(filename))
            {
                DCS.Forms.MainForm.Instance().WriteToOutputWindows("File " + filename + " does not exist");
                return;
            }
            int ControllerNameCol = -1;
            int pouNameCol = -1;
            int VarNameCol = -1;

            int ret = 0;
            string str;
            string _log = "";
            bool headerline = true;
            tblBOOL tblbool = new tblBOOL();
            tblController tblcontroller = tblSolution.m_tblSolution().GetControllerFromName(controllername);
            if (tblcontroller == null)
            {
                DCS.Forms.MainForm.Instance().WriteToOutputWindows("Import BOOL Error: controller " + controllername + " does not exist in database");
                return;
            }
            tblPou tblpou = tblcontroller.GetPouFromName(pouname);
            if (tblpou == null)
            {
                DCS.Forms.MainForm.Instance().WriteToOutputWindows("Import BOOL Error: pou " + pouname + " does not exist in " + controllername);
                return;
            }
            //var transaction = Common.Conn.BeginTransaction();
            using (StreamReader reader = new StreamReader(filename))
            {
                while ((str = reader.ReadLine()) != null)
                {
                    str.Replace(",,", ", ,");
                    if (str.StartsWith("!"))
                    {
                        continue;
                    }
                    if (headerline)
                    {
                        tblbool.headerString = str;
                        headerline = false;
                        ControllerNameCol = tblbool.ColumnExistInHeader("ControllerName");
                        if (ControllerNameCol == -1)
                        {
                            DCS.Forms.MainForm.Instance().WriteToOutputWindows("BOOL add error: ControllerName column does not exist in " + filename);
                            break;
                        }
                        pouNameCol = tblbool.ColumnExistInHeader("pouName");
                        if (pouNameCol == -1)
                        {
                            DCS.Forms.MainForm.Instance().WriteToOutputWindows("BOOL add error: pouName column does not exist in " + filename);
                            break;
                        }
                        VarNameCol = tblbool.ColumnExistInHeader("VarName");
                        if (VarNameCol == -1)
                        {
                            DCS.Forms.MainForm.Instance().WriteToOutputWindows("BOOL add error: VarName column does not exist in " + filename);
                            break;
                        }
                    }
                    else
                    {
                        tblbool = new tblBOOL();
                        string[] _strs = str.Split(new Char[] { ',' });
                        if ((_strs[ControllerNameCol].ToLower() == controllername) && (_strs[pouNameCol].ToLower() == pouname))
                        {
                            if (tblpou.VariablesByName.ContainsKey(_strs[VarNameCol].ToLower()))
                            {
                                tblVariable tblvariable = tblpou.VariablesByName[_strs[VarNameCol].ToLower()];
                                tblbool.AddFromString(_strs, _strs[pouNameCol], ref _log);

                                tblbool.VarNameID = tblvariable.VarNameID;
                                if ((ret = tblbool.Insert()) != 0)
                                {
                                    if (ret == 19)
                                    {
                                        DCS.Forms.MainForm.Instance().WriteToOutputWindows(_log + " Already exist in database");
                                    }
                                }
                            }
                            else
                            {
                                DCS.Forms.MainForm.Instance().WriteToOutputWindows("BOOL add Error: Varaible " + _strs[VarNameCol] + " does not exist in database");
                            }
                        }

                    }

                }
                reader.Close();
            }
            //transaction.Commit();
        }

        public void AddREAL(string filename, string controllername, string pouname)
        {
            if (MainForm.Instance().CurrentUser.LogicExplorer != (int)EXPLORER_ACCESS.Full)
            {
                System.Windows.Forms.MessageBox.Show("current user cannot add any Contrller");
            }
            if (!File.Exists(filename))
            {
                DCS.Forms.MainForm.Instance().WriteToOutputWindows("File " + filename + " does not exist");
                return;
            }
            int ControllerNameCol = -1;
            int pouNameCol = -1;
            int VarNameCol = -1;

            int ret = 0;
            string str;
            string _log = "";
            bool headerline = true;
            tblREAL tblreal = new tblREAL();
            tblController tblcontroller = tblSolution.m_tblSolution().GetControllerFromName(controllername);
            if (tblcontroller == null)
            {
                DCS.Forms.MainForm.Instance().WriteToOutputWindows("Import REAL Error: controller " + controllername + " does not exist in database");
                return;
            }
            tblPou tblpou = tblcontroller.GetPouFromName(pouname);
            if (tblpou == null)
            {
                DCS.Forms.MainForm.Instance().WriteToOutputWindows("Import REAL Error: pou " + pouname + " does not exist in " + controllername);
                return;
            }
            //var transaction = Common.Conn.BeginTransaction();
            using (StreamReader reader = new StreamReader(filename))
            {
                while ((str = reader.ReadLine()) != null)
                {
                    str.Replace(",,", ", ,");
                    if (str.StartsWith("!"))
                    {
                        continue;
                    }
                    if (headerline)
                    {
                        tblreal.headerString = str;
                        headerline = false;
                        ControllerNameCol = tblreal.ColumnExistInHeader("ControllerName");
                        if (ControllerNameCol == -1)
                        {
                            DCS.Forms.MainForm.Instance().WriteToOutputWindows("REAL add error: ControllerName column does not exist in " + filename);
                            break;
                        }
                        pouNameCol = tblreal.ColumnExistInHeader("pouName");
                        if (pouNameCol == -1)
                        {
                            DCS.Forms.MainForm.Instance().WriteToOutputWindows("REAL add error: pouName column does not exist in " + filename);
                            break;
                        }
                        VarNameCol = tblreal.ColumnExistInHeader("VarName");
                        if (VarNameCol == -1)
                        {
                            DCS.Forms.MainForm.Instance().WriteToOutputWindows("REAL add error: VarName column does not exist in " + filename);
                            break;
                        }
                    }
                    else
                    {
                        tblreal = new tblREAL();
                        string[] _strs = str.Split(new Char[] { ',' });
                        if ((_strs[ControllerNameCol].ToLower() == controllername) && (_strs[pouNameCol].ToLower() == pouname))
                        {
                            if (tblpou.VariablesByName.ContainsKey(_strs[VarNameCol].ToLower()))
                            {
                                tblVariable tblvariable = tblpou.VariablesByName[_strs[VarNameCol].ToLower()];
                                tblreal.AddFromString(_strs, _strs[pouNameCol], ref _log);

                                tblreal.VarNameID = tblvariable.VarNameID;
                                if ((ret = tblreal.Insert()) != 0)
                                {
                                    if (ret == 19)
                                    {
                                        DCS.Forms.MainForm.Instance().WriteToOutputWindows(_log + " Already exist in database");
                                    }
                                }
                            }
                            else
                            {
                                DCS.Forms.MainForm.Instance().WriteToOutputWindows("REAL add Error: Varaible " + _strs[VarNameCol] + " does not exist in database");
                            }
                        }

                    }

                }
                reader.Close();
            }
        }
        public void importAlarm()
        {

        }
        public void AddFormalParameter(string filename)
        {
            if (MainForm.Instance().CurrentUser.LogicExplorer != (int)EXPLORER_ACCESS.Full)
            {
                System.Windows.Forms.MessageBox.Show("current user cannot add any Contrller");
            }
            if (!File.Exists(filename))
            {
                DCS.Forms.MainForm.Instance().WriteToOutputWindows("File " + filename + " does not exist");
                return;
            }
            int ret = 0;
            string str;
            string _log = "";
            int FunctionNameCol = -1;
            string functionname;
            bool headerline = true;
            tblFunction tblfunction;
            tblFormalParameter tblformalparameter = new tblFormalParameter();
            
            using (StreamReader reader = new StreamReader(filename))
            {
                while ((str = reader.ReadLine()) != null)
                {
                    str.Replace(",,", ", ,");
                    if (str.StartsWith("!"))
                    {
                        continue;
                    }
                    if (headerline)
                    {
                        tblformalparameter.headerString = str;
                        headerline = false;
                        FunctionNameCol = tblformalparameter.ColumnExistInHeader("FunctionName");
                        if (FunctionNameCol == -1)
                        {
                            DCS.Forms.MainForm.Instance().WriteToOutputWindows("Formalparameter add error: FunctionName column does not exist in " + filename);
                            break;
                        }
                    }
                    else
                    {
                        tblformalparameter = new tblFormalParameter();
                        string[] _strs = str.Split(new Char[] { ',' });
                        functionname = _strs[FunctionNameCol].ToLower();
                        tblfunction = tblSolution.m_tblSolution().functionbyName[functionname.ToUpper()];
                        if (tblfunction != null)
                        {
                            tblformalparameter.AddFromString(_strs, functionname, ref _log);
                            tblformalparameter.FunctionID = tblSolution.m_tblSolution().functionbyName[functionname.ToUpper()].FunctionID; ;
                            if ((ret = tblformalparameter.Insert()) != 0)
                            {
                                if (ret == 19)
                                {
                                    DCS.Forms.MainForm.Instance().WriteToOutputWindows(_log + " Already exist in database");
                                }
                            }
                            else
                            {
                                tblfunction.m_tblFormalParameterCollection.Add(tblformalparameter);
                            }
                        }
                        else
                        {
                            DCS.Forms.MainForm.Instance().WriteToOutputWindows("Function Name " + functionname  + " doesn't exist in database");
                        }
                    }
                }
                reader.Close();
            }
        }
    }
}
