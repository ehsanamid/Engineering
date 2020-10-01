using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Text;
using DockSample;
using DocToolkit;
using System.Windows.Forms;
using System.IO;
using DCS.Tools;
using DCS.Draw;
using DCS.Draw.FBD;
#if EWSAPP
using DCS.Compile.Operation; 
#endif
using DCS.TabPages;
using System.Threading;
using DCS.Compile;
using DCS.TableObject;

namespace DCS.DCSTables
{


    public partial class tblPou 
    {
        

        public override bool PostDeleteTriger()
        {
            tblController tblcontroller = tblSolution.m_tblSolution().GetControllerobjectofPOUID(pouID);
            tblcontroller.m_tblPouCollection.Remove(this);
            tblcontroller.SavePouDB();
            return true;
        }

        public override bool PostUpdateTriger()
        {
            //tblSolution.m_tblSolution().Dummytblcontroller.SavePouDB();
            tblSolution.m_tblSolution().GetControllerobjectofPOUID(pouID).SavePouDB();
            return true;
        }

        public CrossReference Lookup = new CrossReference();
        //public Mutex mut = new Mutex();
        public readonly object _locker = new object();
        //WaitHandle wh = new WaitHandle();

        Dictionary<string, tblVariable> variablesbyname = null;
        public Dictionary<string, tblVariable> VariablesByName
        {
            get
            {
               // WaitHandler.WaitOne(wh);
                lock (_locker)
                {
                    if (variablesbyname == null)
                    {
                        variablesbyname = new Dictionary<string, tblVariable>();
                        foreach (tblVariable tblvariable in m_tblVariableCollection)
                        {
                            variablesbyname.Add(tblvariable.VarName.ToLower(), tblvariable);
                        }
                    }
                    return variablesbyname;
                }
                
            }
            set
            {
                variablesbyname = value;
            }
        }
        
        #region Graphical Members
        //private DrawingDoc _drawingdoc;
        //public DrawingDoc m_DrawingDoc
        //{
        //    get { return _drawingdoc; }
        //    set { _drawingdoc = value; }
        //}
        #endregion

        

        #region Public Methods

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

#if EWSAPP
        public bool SaveST(RichTextBox rtb)
        {
            string filename = "";
            bool ret = true;
            try
            {
                filename = Common.ProjectPath + "\\LOGIC";
                filename += "\\";
                filename += tblSolution.m_tblSolution().GetControllerFromID(ControllerID).ControllerName;
                filename += "\\";
                filename += this.pouName + ".st";
                StreamWriter writer = new StreamWriter(filename);
                writer.Write(rtb.Text);
                writer.Close();
                this.STText = rtb.Text;
                this.Update();
                
                Compile();
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return ret;
        }

        public bool SaveSFC()
        {
            bool ret = false;
            return ret;
        }
        public bool SaveFBD()
        {
            bool ret = false;
            int count;
            //ResetCollection();
            ret = CheckFBDInstanceNameUnique();
            if (ret)
            {
                ret = SaveFBDDrawing();
                string stfilename = "";
                string bifilename = "";
                stfilename = Common.ProjectPath + "\\LOGIC";
                stfilename += "\\";
                stfilename += tblSolution.m_tblSolution().GetControllerFromID(ControllerID).ControllerName;
                stfilename += "\\";
                stfilename += this.pouName;
                bifilename = stfilename;
                stfilename += ".st";
                bifilename += ".bi";
                Common.RenameFile(stfilename + "o", stfilename);

            }
            else
            {
                return ret;
            }
            if (ret)
            {
                count = Pages.NoOfPages;
                for (int i = 0; i < count; i++)
                {

                    foreach (DrawLogic drawobject in Pages.GraphicPagesList[i].List)
                    {
                        if ((drawobject is DrawFunction) || (drawobject is DrawFunctionBlock) || (drawobject is DrawFunctionEx))
                        {
                            drawobject.NewObject = false;

                        }
                    }
                }
                ret = CheckAllInOutConnected();
            }
            else
            {
                return ret;
            }
            if (ret)
            {
                ret = CheckFBDInstanceNameUnique();
            }
            else
            {
                return ret;
            }
            if (ret)
            {
                ret = CheckFBDOverrideMatch();
            }
            else
            {
                return ret;
            }
            if (ret)
            {
                ret = AddLinkedVariables();
            }
            else
            {
                return ret;
            }
            if (ret)
            {
                ret = tblSolution.m_tblSolution().GetControllerobjectofPOUID(this.pouID).SaveVariable();
            }
            else
            {
                return ret;
            }
            if (ret)
            {
                ret = SaveFBD2ST();
            }
            else
            {
                return ret;
            }
            if (ret)
            {
                ret = Compile();
            }
            else
            {
                return ret;
            }

            return ret;
        } 
#endif

        public tblVariable GettblVariableVariable(long id)
        {
            foreach (tblVariable tblvariable in m_tblVariableCollection)
            {
                if (tblvariable.VarNameID == id)
                {
                    return tblvariable;
                }
            }
            return null;
        }

        private bool AddLinkedVariables()
        {
            bool ret = true;
            for (int i = 0; i < Pages.NoOfPages; i++)
            {
                foreach (DrawLogic drawobject in Pages.GraphicPagesList[i].List)
                {
                    if (drawobject is DrawFunctionBlock)
                    {
                        ((DrawFunctionBlock)drawobject).AddLinkedVariables();
                    }
                    else
                    {
                        if (drawobject is DrawFunction)
                        {
                            ((DrawFunction)drawobject).AddLinkedVariables();
                        }
                        else
                        {
                            if (drawobject is DrawFunctionEx)
                            {
                                ((DrawFunctionEx)drawobject).AddLinkedVariables();
                            }

                        }
                    }
                }
            }
            return ret;
        }


        private bool FBDisEmpty()
        {

            for (int i = 0; i < Pages.NoOfPages; i++)
            {
                if (Pages.NoOfObjectsinPage(i) > 0)
                {
                    return false;
                }
            }
            return true;
        }

#if EWSAPP
        public bool Compile()
        {
            bool ret = false;

            Compiler compiler = new Compiler(/*DCS.Forms.MainForm.Instance()*/);

            ret = compiler.CompilePOU(this);

            return ret;
        } 
#endif

        //private bool SaveFBD2ST()
        //{
        //    bool ret = true;
        //    string filename = "";
        //    //long lng;
        //    if (FBDisEmpty())
        //    {
        //        filename = Common.ProjectPath + "\\LOGIC";
        //        filename += "\\";
        //        filename += tblSolution.m_tblSolution().GetControllerFromID(ControllerID).ControllerName;
        //        filename += "\\";
        //        filename += this.pouName + ".st";

        //    }
        //    else
        //    {
        //        filename = Common.ProjectPath + "\\LOGIC";
        //        filename += "\\";
        //        filename += tblSolution.m_tblSolution().GetControllerFromID(ControllerID).ControllerName;
        //        filename += "\\";
        //        filename += this.pouName + ".st";
        //        string str = "";
        //        string tempstr = "";
        //        int k = 0;
        //        for (int i = 0; i < Pages.NoOfPages; i++)
        //        {
        //            foreach (DrawLogic drawobject in Pages.GraphicPagesList[i].List)
        //            {
        //                if (drawobject is DrawFBDBox)
        //                {
        //                    ((DrawFBDBox)drawobject).Saved = false;
        //                    ((DrawFBDBox)drawobject).IsOutputBlock = ((DrawFBDBox)drawobject).IsOutputobject();
        //                    drawobject.oIndex = k++;
        //                    drawobject.LeftPosition = Pages.GraphicPagesList[i].List[k]._rectangle.X;
        //                    drawobject.TopPosition = Pages.GraphicPagesList[i].List[k]._rectangle.Y;
        //                }
        //            }
        //        }
        //        //k = 0;
        //        //for (int i = 0; i < Pages.NoOfPages; i++)
        //        //{
        //        //    foreach (DrawLogic drawobject in Pages.GraphicPagesList[i].List.OrderBy(x => x.TopPosition).ThenBy(x => x.LeftPosition))
        //        //    {
        //        //        drawobject.oIndex = k++;

        //        //    }
        //        //}
        //        using (StreamWriter writer = new StreamWriter(filename))
        //        {
        //            for (int i = 0; i < Pages.NoOfPages; i++)
        //            {
        //                foreach (DrawLogic drawobject in Pages.GraphicPagesList[i].List)
        //                {
        //                    str = "";
        //                    if (drawobject is DrawFunctionBlock)
        //                    {
        //                        str = ((DrawFunctionBlock)drawobject).tblvariable.VarName;
        //                        str += "(";
        //                        for (int j = 0; j < ((DrawFunctionBlock)drawobject).LeftPins.Count; j++)
        //                        {
        //                            tempstr = ((DrawFunctionBlock)drawobject).GetLeftEndConnectionStringOfPin(j);
        //                            if (tempstr != "")
        //                            {
        //                                str += tempstr;
        //                                str += ",";
        //                            }
        //                            else
        //                            {
        //                                DCS.Forms.MainForm.Instance().WriteToOutputWindows("function block " + ((DrawFunctionBlock)drawobject).tblvariable.VarName + "has not connected Inputs");
        //                            }

        //                        }
        //                        str = str.Substring(0, str.Length - 1);
        //                        str += ");";
        //                        writer.WriteLine(str);
        //                    }
        //                    else
        //                    {
        //                        if (drawobject is DrawFunction)
        //                        {
        //                            //str = ((DrawFunction)drawobject).tblvariable.VarName;
        //                            str = ((DrawFunction)drawobject).tblvariable.m_tblFInstanceVariableList[0].VarName;
        //                            str += ".VAL";
        //                            str += " := ";
        //                            str += tblSolution.m_tblSolution().GetFunctionbyName(((DrawFunction)drawobject).tblvariable.Type);
        //                            str += "(";
        //                            for (int j = 0; j < ((DrawFunction)drawobject).LeftPins.Count; j++)
        //                            {
        //                                tempstr = ((DrawFunction)drawobject).GetLeftEndConnectionStringOfPin(j);
        //                                if (tempstr != "")
        //                                {
        //                                    str += tempstr;
        //                                    str += ",";
        //                                }
        //                                else
        //                                {
        //                                    DCS.Forms.MainForm.Instance().WriteToOutputWindows("function " + ((DrawFunction)drawobject).tblvariable.VarName + "has not connected Inputs");
        //                                }

        //                            }
        //                            str = str.Substring(0, str.Length - 1);
        //                            str += ");";
        //                            writer.WriteLine(str);
        //                        }
        //                        else
        //                        {
        //                            if (drawobject is DrawFunctionEx)
        //                            {
        //                                //str = ((DrawFunctionEx)drawobject).tblvariable.VarName;
        //                                str = ((DrawFunctionEx)drawobject).tblvariable.m_tblFInstanceVariableList[0].VarName;
        //                                str += ".VAL";
        //                                str += " := ";
        //                                int temp = ((DrawFunctionEx)drawobject).tblvariable.Type;
        //                                str += tblSolution.m_tblSolution().GetFunctionbyName(((DrawFunctionEx)drawobject).tblvariable.Type);
        //                                str += "(";
        //                                for (int j = 0; j < ((DrawFunctionEx)drawobject).LeftPins.Count; j++)
        //                                {
        //                                    tempstr = ((DrawFunctionEx)drawobject).GetLeftEndConnectionStringOfPin(j);
        //                                    if (tempstr != "")
        //                                    {
        //                                        str += tempstr;
        //                                        str += ",";
        //                                    }
        //                                    else
        //                                    {
        //                                        DCS.Forms.MainForm.Instance().WriteToOutputWindows("functionex " + ((DrawFunctionEx)drawobject).tblvariable.VarName + "has not connected Inputs");
        //                                    }

        //                                }
        //                                str = str.Substring(0, str.Length - 1);
        //                                str += ");";
        //                                writer.WriteLine(str);
        //                            }
        //                            else
        //                            {
        //                                if (drawobject is DrawVariable)
        //                                {

        //                                    tempstr = ((DrawVariable)drawobject).GetLeftEndConnectionStringOfPin(0);
        //                                    if (tempstr != "")
        //                                    {
        //                                        if (!((DrawVariable)drawobject).HasExtendedProperty)
        //                                        {
        //                                            str = ((DrawVariable)drawobject).tblvariable.VarName + "." + ((DrawVariable)drawobject).tblformalparameter.PinName;
        //                                        }
        //                                        else
        //                                        {
        //                                            str = ((DrawVariable)drawobject).tblvariable.VarName + "." + ((DrawVariable)drawobject).tblformalparameter.PinName + "." + ((DrawVariable)drawobject).ExtendedPropertyTXT;
        //                                        }
        //                                        str += " := ";
        //                                        str += tempstr;
        //                                        str += ";";
        //                                        writer.WriteLine(str);
        //                                    }
        //                                    else
        //                                    {
        //                                        //Pages.Parent.mainForm.WriteToOutputWindows("variable  " + ((DrawVariable)drawobject).tblvariable.VarName + "has not connected Inputs");
        //                                    }

        //                                }
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //            writer.Close();
        //        }
        //    }
        //    return ret;
        //}


#if EWSAPP

        private bool SaveFBD2ST()
        {
            bool ret = true;
            string filename = "";
            //long lng;
            if (FBDisEmpty())
            {
                filename = Common.ProjectPath + "\\LOGIC";
                filename += "\\";
                filename += tblSolution.m_tblSolution().GetControllerFromID(ControllerID).ControllerName;
                filename += "\\";
                filename += this.pouName + ".st";
                Common.RemoveFile(filename);

            }
            else
            {
                filename = Common.ProjectPath + "\\LOGIC";
                filename += "\\";
                filename += tblSolution.m_tblSolution().GetControllerFromID(ControllerID).ControllerName;
                filename += "\\";
                filename += this.pouName + ".st";
                //string str = "";
                //string tempstr = "";
                int k = 0;
                for (int i = 0; i < Pages.NoOfPages; i++)
                {
                    foreach (DrawLogic drawobject in Pages.GraphicPagesList[i].List)
                    {
                        if (drawobject is DrawFBDBox)
                        {
                            ((DrawFBDBox)drawobject).Saved = false;
                            ((DrawFBDBox)drawobject).IsOutputBlock = ((DrawFBDBox)drawobject).IsOutputobject();
                            drawobject.oIndex = k++;
                            drawobject.LeftPosition = drawobject.rectangle.X;
                            drawobject.TopPosition = drawobject.rectangle.Y;
                        }
                    }
                }

                using (StreamWriter writer = new StreamWriter(filename))
                {
                    for (int i = 0; i < Pages.NoOfPages; i++)
                    {
                        //foreach (DrawLogic drawobject in Pages.GraphicPagesList[i].List)
                        foreach (DrawLogic drawobject in Pages.GraphicPagesList[i].List.OrderBy(x => x.TopPosition).ThenBy(x => x.LeftPosition))
                        {
                            if (drawobject is DrawFBDBox)
                            {
                                if (((DrawFBDBox)drawobject).IsOutputBlock)
                                {
                                    ChangeDrawFBDBoxs2String(writer, (DrawFBDBox)drawobject);
                                }
                            }
                        }
                    }
                    writer.Close();
                }
            }
            return ret;
        }

        void ChangeDrawFBDBoxs2String(StreamWriter writer, DrawFBDBox drawobject)
        {
            string strlog = "";
            string str = "";
            string tempstr = "";
            #region DrawFunctionBlock
            if (drawobject is DrawFunctionBlock)
            {
                str = ((DrawFunctionBlock)drawobject).tblvariable.VarName;
                strlog = "!FBD{FunctionBlock;" + str + ":" + drawobject.rectangle.Left.ToString() + "," + drawobject.rectangle.Top.ToString() + "}";
                


                str += "(";
                for (int j = 0; j < ((DrawFunctionBlock)drawobject).LeftPins.Count; j++)
                {
                    if (((DrawFunctionBlock)drawobject).GetLeftEndConnectionDrawFBDBox(j) != null)
                    {
                        if (!((DrawFunctionBlock)drawobject).GetLeftEndConnectionDrawFBDBox(j).Saved)
                        {
                            ChangeDrawFBDBoxs2String(writer, ((DrawFunctionBlock)drawobject).GetLeftEndConnectionDrawFBDBox(j));
                        }
                    }
                    tempstr = ((DrawFunctionBlock)drawobject).GetLeftEndConnectionStringOfPin(j);
                    if (tempstr != "")
                    {
                        str += tempstr;
                        str += ",";
                    }
                    else
                    {
                        DCS.Forms.MainForm.Instance().WriteToOutputWindows("function block " + ((DrawFunctionBlock)drawobject).tblvariable.VarName + "has not connected Inputs");
                    }

                }
                str = str.Substring(0, str.Length - 1);
                str += ");";
                writer.WriteLine(strlog);
                writer.WriteLine(str);
                drawobject.Saved = true;
                return;
            } 
            #endregion

            #region DrawFunction
            if (drawobject is DrawFunction)
            {
                str = ((DrawFunction)drawobject).tblvariable.VarName;
                //str = ((DrawFunction)drawobject).tblvariable.m_tblFInstanceVariableList[0].VarName;
                strlog = "!FBD{Function;" + str + ":" + drawobject.rectangle.Left.ToString() + "," + drawobject.rectangle.Top.ToString() + "}";
                
                str += ".VAL";
                str += " := ";
                //str += tblSolution.m_tblSolution().GetFunctionNamebyType(((DrawFunction)drawobject).tblvariable.Type); //10092016 commented
                str += ((DrawFunction)drawobject).tblfunction.FunctionName;   // 10092016 added
                str += "(";
                for (int j = 0; j < ((DrawFunction)drawobject).LeftPins.Count; j++)
                {
                    if (((DrawFunction)drawobject).GetLeftEndConnectionDrawFBDBox(j) != null)
                    {
                        if (!((DrawFunction)drawobject).GetLeftEndConnectionDrawFBDBox(j).Saved)
                        {
                            ChangeDrawFBDBoxs2String(writer, ((DrawFunction)drawobject).GetLeftEndConnectionDrawFBDBox(j));
                        }
                    }
                    tempstr = ((DrawFunction)drawobject).GetLeftEndConnectionStringOfPin(j);
                    if (tempstr != "")
                    {
                        str += tempstr;
                        str += ",";
                    }
                    else
                    {
                        DCS.Forms.MainForm.Instance().WriteToOutputWindows("function " + ((DrawFunction)drawobject).tblvariable.VarName + "has not connected Inputs");
                    }

                }
                str = str.Substring(0, str.Length - 1);
                str += ");";
                writer.WriteLine(strlog);
                writer.WriteLine(str);
                drawobject.Saved = true;
                return;
            } 
            #endregion

            #region DrawFunctionEx
            if (drawobject is DrawFunctionEx)
            {
                str = ((DrawFunctionEx)drawobject).tblvariable.VarName;
                //str = ((DrawFunctionEx)drawobject).tblvariable.m_tblFInstanceVariableList[0].VarName;
                strlog = "!FBD{Function;" + str + ":" + drawobject.rectangle.Left.ToString() + "," + drawobject.rectangle.Top.ToString() + "}";
                
                str += ".VAL";
                str += " := ";
                //str += tblSolution.m_tblSolution().GetFunctionNamebyType(((DrawFunctionEx)drawobject).tblvariable.Type);  //10092016 commented
                str += ((DrawFunctionEx)drawobject).tblfunction.FunctionName;   // 10092016 added
                str += "(";
                for (int j = 0; j < ((DrawFunctionEx)drawobject).LeftPins.Count; j++)
                {
                    if (((DrawFunctionEx)drawobject).GetLeftEndConnectionDrawFBDBox(j) != null)
                    {
                        if (!((DrawFunctionEx)drawobject).GetLeftEndConnectionDrawFBDBox(j).Saved)
                        {
                            ChangeDrawFBDBoxs2String(writer, ((DrawFunctionEx)drawobject).GetLeftEndConnectionDrawFBDBox(j));
                        }
                    }
                    tempstr = ((DrawFunctionEx)drawobject).GetLeftEndConnectionStringOfPin(j);
                    if (tempstr != "")
                    {
                        str += tempstr;
                        str += ",";
                    }
                    else
                    {
                        DCS.Forms.MainForm.Instance().WriteToOutputWindows("functionex " + ((DrawFunctionEx)drawobject).tblvariable.VarName + "has not connected Inputs");
                    }

                }
                str = str.Substring(0, str.Length - 1);
                str += ");";
                writer.WriteLine(strlog);
                writer.WriteLine(str);
                drawobject.Saved = true;
                return;
            } 
            #endregion

            #region DrawVariable
            if (drawobject is DrawVariable)
            {
                if (((DrawVariable)drawobject).GetLeftEndConnectionDrawFBDBox(0) != null)
                {
                    if (!((DrawVariable)drawobject).GetLeftEndConnectionDrawFBDBox(0).Saved)
                    {
                        ChangeDrawFBDBoxs2String(writer, ((DrawVariable)drawobject).GetLeftEndConnectionDrawFBDBox(0));
                    }
                }
                tempstr = ((DrawVariable)drawobject).GetLeftEndConnectionStringOfPin(0);
                if (tempstr != "")
                {
                    if (!((DrawVariable)drawobject).HasExtendedProperty)
                    {
                        str = ((DrawVariable)drawobject).tblvariable.VarName + "." + ((DrawVariable)drawobject).tblformalparameter.PinName;
                    }
                    else
                    {
                        str = ((DrawVariable)drawobject).tblvariable.VarName + "." + ((DrawVariable)drawobject).tblformalparameter.PinName + "." + ((DrawVariable)drawobject).ExtendedPropertyTXT;
                    }

                    strlog = "!FBD{Variable;" + str + ":" + drawobject.rectangle.Left.ToString() + "," + drawobject.rectangle.Top.ToString() + "}";
                    
                    str += " := ";
                    str += tempstr;
                    str += ";";
                    writer.WriteLine(strlog);
                    writer.WriteLine(str);
                }
                else
                {
                    //Pages.Parent.mainForm.WriteToOutputWindows("variable  " + ((DrawVariable)drawobject).tblvariable.VarName + "has not connected Inputs");
                }
                drawobject.Saved = true;
                return;
            } 
            #endregion

        }

#endif

        private bool CheckAllInOutConnected()
        {
            bool ret = true;
            for (int i = 0; i < Pages.NoOfPages; i++)
            {
                foreach (DrawLogic drawobject in Pages.GraphicPagesList[i].List)
                {
                    if (drawobject is DrawFunctionBlock)
                    {
                        for (int j = 0; j < ((DrawFunctionBlock)drawobject).LeftPins.Count; j++)
                        {
                            if (!((DrawFunctionBlock)drawobject).LeftPins[j].Connected)
                            {
                                ret = false;
                                DCS.Forms.MainForm.Instance().WriteToOutputWindows("function block " + ((DrawFunctionBlock)drawobject).tblvariable.VarName + "Input Pin " + j.ToString() + " not connected");
                            }

                        }
                    }
                    else
                    {
                        if (drawobject is DrawFunction) 
                        {
                            for (int j = 0; j < ((DrawFunction)drawobject).LeftPins.Count; j++)
                            {
                                if (!((DrawFunction)drawobject).LeftPins[j].Connected)
                                {
                                    ret = false;
                                    DCS.Forms.MainForm.Instance().WriteToOutputWindows("function  " + ((DrawFunction)drawobject).tblvariable.VarName + "Input Pin " + j.ToString() + " not connected");
                                }

                            }
                            for (int j = 0; j < ((DrawFunction)drawobject).RightPins.Count; j++)
                            {
                                if (!((DrawFunction)drawobject).RightPins[j].Connected)
                                {
                                    ret = false;
                                    DCS.Forms.MainForm.Instance().WriteToOutputWindows("function  " + ((DrawFunction)drawobject).tblvariable.VarName + "Input Pin " + j.ToString() + " not connected");
                                }

                            }
                        }
                        else
                        {
                            if (drawobject is DrawFunctionEx)
                            {
                                for (int j = 0; j < ((DrawFunctionEx)drawobject).LeftPins.Count; j++)
                                {
                                    if (!((DrawFunctionEx)drawobject).LeftPins[j].Connected)
                                    {
                                        ret = false;
                                        DCS.Forms.MainForm.Instance().WriteToOutputWindows("function  " + ((DrawFunctionEx)drawobject).tblvariable.VarName + "Input Pin " + j.ToString() + " not connected");
                                    }

                                }
                                for (int j = 0; j < ((DrawFunctionEx)drawobject).RightPins.Count; j++)
                                {
                                    if (!((DrawFunctionEx)drawobject).RightPins[j].Connected)
                                    {
                                        ret = false;
                                        DCS.Forms.MainForm.Instance().WriteToOutputWindows("function  " + ((DrawFunctionEx)drawobject).tblvariable.VarName + "Input Pin " + j.ToString() + " not connected");
                                    }

                                }
                            }
                        }

                    }
                }
            }


            return ret;
        }

        private bool CheckFBDInstanceNameUnique()
        {
            bool ret = true;

            for (int i = 0; i < Pages.NoOfPages; i++)
            {

                foreach (DrawLogic drawobject in Pages.GraphicPagesList[i].List)
                {
                    if ((drawobject is DrawFunction) || (drawobject is DrawFunctionBlock) || (drawobject is DrawFunctionEx))
                    {
                        if (drawobject.NewObject)
                        {
                            //TemporayVariable tv = ((DrawFBDBox)drawobject).tblvariable;
                            //if (tblVariable.checkVariableName(tv.domainid, tv.controllerid, tv.varid, tv.name))
                            if (tblVariable.checkVariableName(((DrawFBDBox)drawobject).tblvariable.VarName, ((DrawFBDBox)drawobject).tblvariable.pouID))
                            {
                                DCS.Forms.MainForm.Instance().WriteToOutputWindows("Variable " + ((DrawFBDBox)drawobject).tblvariable.VarName + "already exists in this POU.\n");
                                DCS.Forms.MainForm.Instance().WriteToOutputWindows("Cannot save POU.\n");

                                return false;
                            }
                        }
                    }
                }
            }
            
            return ret;
        }

        private bool CheckFBDOverrideMatch()
        {
            bool ret = true;
            bool setoutputtypeOK = false;
            bool Next = true;
            List<int> _types;
            int _type = 0;
            while (Next)
            {
                Next = false;
                for (int i = 0; i < Pages.NoOfPages; i++)
                {
                    foreach (DrawLogic drawobject in Pages.GraphicPagesList[i].List)
                    {
                        if (drawobject is DrawFunction )
                        {
                            if ((((DrawFunction)drawobject).tblfunction.Overloaded) && !(Common.IsSimpleType(((DrawFunction)drawobject).GetRightPinType(0))))
                            {
                                _types = ((DrawFunction)drawobject).GetRightSideConnectionTypes(0);
                                _type = (int)VarType.ANY;
                                for (int j = 0; j < _types.Count; j++)
                                {
                                    if ((Common.IsSimpleType(_types[j])) && (_type == (int)VarType.ANY))
                                    {
                                        _type = _types[j];
                                        break;
                                    }
                                }
                                setoutputtypeOK = true;
                                for (int j = 0; j < _types.Count; j++)
                                {
                                    if ((_type & _types[j]) == 0)
                                    {
                                        ret = false;
                                        setoutputtypeOK = false;
                                        DCS.Forms.MainForm.Instance().WriteToOutputWindows("function connected to different type.\n");
                                        break;
                                    }
                                }
                                if (setoutputtypeOK)
                                {
                                    Next = true;
                                    ((DrawFunction)drawobject).SetRightPinType(0, _type);
                                }
                            }
                        }
                        if (drawobject is DrawFunctionEx)
                        {
                            if ((((DrawFunctionEx)drawobject).tblfunction.Overloaded) && !(Common.IsSimpleType(((DrawFunctionEx)drawobject).GetRightPinType(0))))
                            {
                                
                                _types = ((DrawFunctionEx)drawobject).GetRightSideConnectionTypes(0);
                                if (_types.Count > 0)
                                {
                                    _type = (int)VarType.ANY;
                                    for (int j = 0; j < _types.Count; j++)
                                    {
                                        if ((Common.IsSimpleType(_types[j])) && (_type == (int)VarType.ANY))
                                        {
                                            _type = _types[j];
                                            break;
                                        }
                                    }
                                    setoutputtypeOK = true;
                                    for (int j = 0; j < _types.Count; j++)
                                    {
                                        if ((_type & _types[j]) == 0)
                                        {
                                            ret = false;
                                            setoutputtypeOK = false;
                                            DCS.Forms.MainForm.Instance().WriteToOutputWindows("function connected to different type.\n");
                                            break;
                                        }
                                    }
                                    if (setoutputtypeOK)
                                    {
                                        Next = true;
                                        ((DrawFunctionEx)drawobject).SetRightPinType(0, _type);
                                    }
                                }
                                else
                                {
                                    return false;
                                }
                            }
                        }
                    }
                }
            }
            
            
            return ret;
        }

#if EWSAPP
        private bool SaveFBDDrawing()
        {
            bool ret = true;

            for (int i = 0; i < Pages.NoOfPages; i++)
            {

                foreach (DrawLogic drawobject in Pages.GraphicPagesList[i].List)
                {
                    if ((drawobject is DrawFBDBox) && drawobject.Dirty)
                    {
                        drawobject.Save(this.pouID, i);
                    }
                }
            }

            for (int i = 0; i < Pages.NoOfPages; i++)
            {

                foreach (DrawLogic drawobject in Pages.GraphicPagesList[i].List)
                {
                    if ((drawobject is DrawWire) && drawobject.Dirty)
                    {
                        //drawobject.DomainID = _drawarea.DomainID;
                        //drawobject.ControllerID = _drawarea.ControllerID;
                        drawobject.Save(this.pouID, i);
                    }
                }
            }

            foreach (DeleteListStruc deleteliststruc in Pages.Parenttabgraphicpagecontrol.DeleteList)
            {
                if (deleteliststruc.ID != -1)
                {
                    switch ((STATIC_OBJ_TYPE)deleteliststruc.Type)
                    {
                        case STATIC_OBJ_TYPE.ID_FBDBox:
                        case STATIC_OBJ_TYPE.ID_FBDBoxVariable:
                        case STATIC_OBJ_TYPE.ID_FBDBoxFunction:
                        case STATIC_OBJ_TYPE.ID_FBDBoxFunctionEx:
                        case STATIC_OBJ_TYPE.ID_FBDBoxFunctionBlock:
                            tblFBDBlock tblfbdblock = new tblFBDBlock();
                            tblfbdblock.FBDBlockID = deleteliststruc.ID;
                            tblfbdblock.Select();
                            switch ((STATIC_OBJ_TYPE)tblfbdblock.Type)
                            {
                                case STATIC_OBJ_TYPE.ID_FBDBoxVariable:
                                    break;
                                case STATIC_OBJ_TYPE.ID_FBDBoxFunction:
                                case STATIC_OBJ_TYPE.ID_FBDBoxFunctionEx:
                                case STATIC_OBJ_TYPE.ID_FBDBoxFunctionBlock:
                                    //tblfbdblock.Update();
                                    tblVariable tblvariable = new tblVariable();
                                    tblvariable.VarNameID = tblfbdblock.VarNameID;
                                    tblvariable.Delete();
                                    break;
                            }
                            tblfbdblock.Delete();
                            break;
                        case STATIC_OBJ_TYPE.ID_FBDWire:
                            tblFBDPinConnection tblfbdpinconnection = new tblFBDPinConnection();
                            tblfbdpinconnection.FBDPinConnectionID = deleteliststruc.ID;
                            tblfbdpinconnection.Delete();
                            break;
                    }
                }
            }
            Pages.Parenttabgraphicpagecontrol.DeleteList.Clear();


            return ret;
        }

#endif
        public bool LoadFBD(TabGraphicPageControl tabfbdpagecontrol)
        {
            bool ret = true;
            try
            {
                Lookup.Filename = Common.ProjectPath + "\\CRF" + this.pouID.ToString() + ".crf";
                Lookup.Load();
                Pages = new PageList(tabfbdpagecontrol);
                foreach (tblFBDBlock tblfbdblock in this.m_tblFBDBlockCollection)
                {
                    if (tblfbdblock.Page >= Pages.NoOfPages)
                    {
                        int count = tblfbdblock.Page - Pages.NoOfPages + 1;
                        for (int i = 0; i < count; i++)
                        {
                            
                            Pages.GraphicPagesList.Add(new GraphicsList());
                        }
                    }
                    switch ((STATIC_OBJ_TYPE)tblfbdblock.Type)
                    {
                        case STATIC_OBJ_TYPE.ID_FBDBoxVariable:
                            DrawVariable drawvariable = new DrawVariable(Pages);
                            drawvariable.Load(tblfbdblock);
                            Pages.GraphicPagesList[tblfbdblock.Page].Add(drawvariable);
                            break;
                        case STATIC_OBJ_TYPE.ID_FBDBoxFunction:
                            DrawFunction drawfuntion = new DrawFunction(Pages);
                            drawfuntion.Load(tblfbdblock);
                            Pages.GraphicPagesList[tblfbdblock.Page].Add(drawfuntion);
                            break;
                        case STATIC_OBJ_TYPE.ID_FBDBoxFunctionEx:
                            DrawFunctionEx drawfunctionex = new DrawFunctionEx(Pages);
                            drawfunctionex.Load(tblfbdblock);
                            Pages.GraphicPagesList[tblfbdblock.Page].Add(drawfunctionex);
                            break;
                        case STATIC_OBJ_TYPE.ID_FBDBoxFunctionBlock:
                            DrawFunctionBlock drawfuntionblock = new DrawFunctionBlock(Pages);
                            drawfuntionblock.Load(tblfbdblock);
                            Pages.GraphicPagesList[tblfbdblock.Page].Add(drawfuntionblock);
                            break;
                    }

                }

                foreach (tblFBDPinConnection tblfbdpinconnection in this.m_tblFBDPinConnectionCollection)
                {
                    DrawWire drawwire = new DrawWire(Pages);
                    drawwire.Load(tblfbdpinconnection);
                    Pages.GraphicPagesList[tblfbdpinconnection.Page].Add(drawwire);
                }
                m_tblFBDBlockCollection.Clear();
                m_tblFBDPinConnectionCollection.Clear();
                m_tblFBDBlockCollection = null;
                m_tblFBDPinConnectionCollection = null;

                for (int i = 0; i < Pages.NoOfPages; i++)
                {

                    foreach (DrawLogic drawobject in Pages.GraphicPagesList[i].List)
                    {
                        drawobject.Dirty = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return ret;
        }

        public bool ImportST(RichTextBox rtb)
        {
            string filename = "";
            bool ret = true;
            try
            {
                filename = Common.ProjectPath + "\\LOGIC";
                filename += "\\";
                filename += tblSolution.m_tblSolution().GetControllerFromID(ControllerID).ControllerName;
                filename += "\\";
                filename += this.pouName + ".st";
                StreamReader sr = new StreamReader(filename);
                rtb.Text = sr.ReadToEnd();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return ret;
        }
        public bool LoadST(RichTextBox rtb)
        {
           // string filename = "";
            bool ret = true;
            try
            {
                rtb.Text = STText ;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return ret;
        }



        public bool PrintFBD(DrawArea _drawarea)
        {
            bool ret = false;
            _drawarea.PrintDrawArea();
            
            return ret;
        }

        public bool ExistInPou(string _variablename, ref tblVariable _tblvariable)
        {
            
            foreach (tblVariable tblvariable in m_tblVariableCollection)
            {
                if (tblvariable.VarName.ToLower() == _variablename)
                {
                    _tblvariable = tblvariable;
                    return true;
                    
                }
            }
            return false;
        }

        public int CheckVariableExistInPou(string _variablename, out tblVariable _tblvariable)
        {

            //foreach (tblVariable tblvariable in m_tblVariableCollection)
            //{
            //    if (tblvariable.VarName.ToLower() == _variablename)
            //    {
            //        _tblvariable = tblvariable;
            //        return tblvariable.Type;

            //    }
            //}
            if (VariablesByName.ContainsKey(_variablename))
            {
                _tblvariable = VariablesByName[_variablename];
                return _tblvariable.Type;
            }
            _tblvariable = null;
            return 0;
        }


        //public bool IsVariable(string _variablename, string _propertyname, ref tblVariable _tblvariable, ref tblFormalParameter _tblformalparameter)
        //{
        //    string tempstr = "";
        //    if (ExistInPou(_variablename.ToLower(), ref _tblvariable))
        //    {

        //        //if (!(_tblvariable.Class == (int)VarClass.FunctionInstanse))
        //        {
        //            tblFunction tblfunction = tblSolution.m_tblSolution().GetFunctionbyType(_tblvariable.Type);
        //            foreach (tblFormalParameter tblformalparameter in tblfunction.m_tblFormalParameterCollection)
        //            {
        //                if (tblformalparameter.PinName.ToLower() == _propertyname)
        //                {
                            
        //                    _tblformalparameter = tblformalparameter;
        //                    return true;
        //                }
        //            }
        //        }
        //        //else
        //        //{
        //        //    tempstr = _variablename + "_" + _propertyname;
        //        //    foreach (tblVariable tb in _tblvariable.m_tblFInstanceVariableList)
        //        //    {
        //        //        if (tb.VarName.ToLower() == tempstr)
        //        //        {
        //        //            foreach (tblFormalParameter tblformalparameter in tblSolution.m_tblSolution().GetFunctionbyType(tb.Type).m_tblFormalParameterCollection)
        //        //            {
        //        //                if (tblformalparameter.PinName.ToLower() == "val")
        //        //                {
        //        //                    _tblvariable = tb;
        //        //                    _tblformalparameter = tblformalparameter;
        //        //                    return true;
        //        //                }
        //        //            }
        //        //            break;
        //        //        }
        //        //    }
        //        //}


        //    }
        //    return false;
        //}

        //public bool IsVariable(string _str, ref tblVariable _tblvariable, ref tblFormalParameter _tblformalparameter, ref string _subpropertytxt, ref byte _subproperty, ref bool _isrefernce)
        public bool IsVariable(string _str, ref tblVariable _tblvariable, ref bool _isrefernce, ref tblFormalParameter _tblformalparameter, ref string _subpropertytxt, ref byte _subproperty)
        {
            string str = "";
            _str = _str.ToLower();
            string[] varname = _str.Split(new Char[] { '.' });
            int count = varname.Length;
            if (ExistInPou(varname[0], ref _tblvariable))
            {
                for (int i = 1; i < count; i++)
                {
                    str += varname[i] + ".";
                }
                if (str == "")
                {

                    _tblformalparameter = null;
                    _subpropertytxt = "";
                    _subproperty = 0;
                    _isrefernce = true;
                    return true;
                }
                else
                {

                    str = str.Remove(str.Length - 1,1);
                    tblFunction tblfunction = tblSolution.m_tblSolution().GetFunctionbyType(_tblvariable.Type);
                    if (tblfunction.IsFormalparameterexist(str, ref _tblformalparameter, ref _subpropertytxt, ref  _subproperty))
                    {
                        _isrefernce = false;
                        return true;
                    }
                    
                }
            }
            return false;
        }

        public void ResetCollection()
        {
            m_tblVariableCollection.Clear();
            m_tblVariableCollection = null;

        }

        public tblVariable GetVariableFromID(long id)
        {
            foreach (tblVariable tblvariable in m_tblVariableCollection)
            {
                if (tblvariable.VarNameID == id)
                {
                    return tblvariable;
                }
            }
            return null;
        }

        #endregion

#if EWSAPP
        public void POUObjectCopy(POUObject tocopy)
        {
            pouName = tocopy.pouName;
            Description = tocopy.Description;
            Type = tocopy.Type;
            triggerSignalID = tocopy.triggerSignalID;
            executiontype = tocopy.executiontype;
            Language = tocopy.Language;
        }
#endif
        
    }

    public partial class tblPouCollection
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

            //SQLiteConnection _SqlConnectionConnection = new SQLiteConnection(Common.ConnectionString);
            SQLiteDataReader myReader = null;
            SQLiteCommand myCommand = new SQLiteCommand();
            //if (_SqlConnectionConnection.State == System.Data.ConnectionState.Open)
            //    _SqlConnectionConnection.Close();
            //_SqlConnectionConnection.ConnectionString = Common.ConnectionString;
            //_SqlConnectionConnection.Open();

            try
            {
                myReader = null;
                myCommand.CommandText = @"SELECT * FROM [tblPou]  WHERE [ControllerID]= " + m_ControllerID_tblController.ControllerID + " order by oIndex;";
                myCommand.Connection = Common.Conn;
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    idlist.Add(myReader.GetInt64(myReader.GetOrdinal("pouID")));

                }

                myReader.Close();
                myCommand.Dispose();
                //_SqlConnectionConnection.Close();

                foreach (long id in idlist)// (int i = 0; i < count ; i++)
                {
                    tblPou tblpou = new tblPou();
                    tblpou.pouID = id;
                    tblpou.m_ControllerID_tblController = this._ControllerID_tblController;
                    tblpou.Select();
                    // tblpou.m_tblVariableCollection.Load( tblpou.pouID);
                    this.Add(tblpou);
                }


            }
            catch (SQLiteException ae)
            {
                MessageBox.Show(ae.Message.ToString());
                return false;
                // MessageBox.Show(ae.Message.ToString());
            }



            return ret;
        }
    }


}
