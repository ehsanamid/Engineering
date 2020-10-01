using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Runtime.Serialization;
using System.Windows.Forms;
using DCS.Tools;
using DCS.Forms;
using System.ComponentModel;
using DCS.DCSTables;
using DCS.TypeConverters;
using System.Collections.Generic;
using DCS.TabPages;


namespace DCS.Draw.FBD
{
    /// <summary>
    /// _rectangle graphic object
    /// </summary>
    [Serializable]
    public class DrawFunctionBlock : DrawFBDBox
    {


        private const string entryRectangle = "Rect";

        #region Tables Memebers

        public List<int> LeftPinsLookup = new List<int>();
        public List<int> RightPinsLookup = new List<int>();

        public override int BoxWidth()
        {

            int w = 8;

            w = FunctionWidth * Common.BaseSize * Common.UnitSize;

            return w;

        }

        //public override int BoxHeight()
        //{


        //    if (fbdboxobject.NoOfVisibleInputs > fbdboxobject.PinCollectionOutput.Count)
        //    {
        //        return BoxHeadHeight() + fbdboxobject.NoOfVisibleInputs * Common.BaseSize * Common.UnitSize;
        //    }
        //    else
        //    {
        //        return BoxHeadHeight() + fbdboxobject.PinCollectionOutput.Count * Common.BaseSize * Common.UnitSize;
        //    }


        //}

        public override int BoxHeadHeight()
        {

            return Common.UnitSize * Common.BaseSize;

        }


        #endregion

        /// <summary>
        /// Clone this instance
        /// </summary>
        public override DrawObject Clone()
        {
            DrawFunctionBlock drawfunction = new DrawFunctionBlock(Parentpagelist);
            //drawfunction._rectangle = _rectangle;

            //FillDrawObjectFields(drawfunction);
            return drawfunction;
        }

        public DrawFunctionBlock(PageList _parent)
            : base(_parent)
        {
            ShapeType = STATIC_OBJ_TYPE.ID_FBDBoxFunctionBlock;
            tblvariable.VarNameID = -1;
            tblfbdblock.FBDBlockID = -1;
            Resizeable = false;
            SetRectangle(0, 0, DeltaY, DeltaX);
            //fbdboxobject = new FBDboxObject(this);
        }
        public override void GenerateGraphic()
        {

            //FunctionName = _tblfunction.FunctionName;
            //Description = _tblfunction.Description;
            //FunctionGroup = (FunctionGroup)_tblfunction.FunctionGroup;
            //InstanseName = _instanseName;

            int pl = 0;
            int pr = 0;
            int j = 0;
            //int k = 0;
            
            for (j = 0; j < tblfunction.m_tblFormalParameterCollection.Count; j++)
            {
                if (((tblfunction.m_tblFormalParameterCollection[j].Class == (short)VarClass.Input) ||
                    (tblfunction.m_tblFormalParameterCollection[j].Class == (short)VarClass.InOut) ||
                    (tblfunction.m_tblFormalParameterCollection[j].Class == (short)VarClass.Internal) )&&
                    (tblfunction.m_tblFormalParameterCollection[j].Visible))
                {
                    LeftPinsLookup.Add(j);
                    LeftPins.Add(new FBDPin(tblfunction.m_tblFormalParameterCollection[j], pl++));
                }
            }
            

            //for (j = 0; j < tblfunction.m_tblFormalParameterCollection.Count; j++)
            //{
            //    if ((tblfunction.m_tblFormalParameterCollection[j].Class == (short)VarClass.Input) ||
            //        (tblfunction.m_tblFormalParameterCollection[j].Class == (short)VarClass.InOut))
            //    {
            //        LeftPinsLookup.Add(j);
            //        LeftPins.Add(new FBDPin(tblfunction.m_tblFormalParameterCollection[j], pl++));
            //    }
            //}
            //for (j = 0; j < tblfunction.m_tblFormalParameterCollection.Count; j++)
            //{
            //    if ((tblfunction.m_tblFormalParameterCollection[j].Class == (short)VarClass.Internal) &&
            //        (tblfunction.m_tblFormalParameterCollection[j].Visible))
            //    {
            //        LeftPinsLookup.Add(j);
            //        LeftPins.Add(new FBDPin(tblfunction.m_tblFormalParameterCollection[j], pl++));
            //    }
            //}
            for (j = 0; j < tblfunction.m_tblFormalParameterCollection.Count; j++)
            {
                if ((tblfunction.m_tblFormalParameterCollection[j].Class == (short)VarClass.Output))
                {
                    RightPinsLookup.Add(j);
                    RightPins.Add(new FBDPin(tblfunction.m_tblFormalParameterCollection[j], pr++));
                }
            }

            base.GenerateGraphic();
            //fbdboxobject.UpdatePins();
        }



        //public DrawFunctionBlock(int x, int y, tblFunction _tblfunction/*, string _instanseName*/, int _noofextension, TemporayVariable _tempvar/*, long _selectedvarid, long _domainid, long _controllerid, long _pouid*/)
        public DrawFunctionBlock(PageList _parent, int x, int y, tblFunction _tblfunction, tblVariable _tblvariable)
            : base(_parent)
        {
            ShapeType = STATIC_OBJ_TYPE.ID_FBDBoxFunctionBlock;
            tblvariable = _tblvariable;
            tblfunction = _tblfunction;
            tblvariable.VarNameID = -1;
            tblfbdblock.FBDBlockID = -1;       
            Initalize(x, y);
            updateinital(tblvariable.InitialVal, tblvariable.PinState);
            GenerateGraphic();
        }


        public override void DrawHead(Graphics g)
        {
            Pen pen;
            Brush b = new SolidBrush(FillColor);
            Rectangle rect = new Rectangle();
          //  if (DrawPen == null)
                pen = new Pen(Color, PenWidth);
          //  else
           //     pen = (Pen)DrawPen.Clone();

            Font drawFont = new Font("Arial", 7);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            // Set format of string.
            StringFormat drawFormat = new StringFormat();
            _rectangle.Width = BoxWidth();
            _rectangle.Height = BoxHeight();

            #region Draw string for Name and Description
            drawFormat.Alignment = StringAlignment.Center;
            drawFormat.LineAlignment = StringAlignment.Center;

            rect.X = _rectangle.X;
            rect.Y = _rectangle.Y;
            rect.Width = BoxWidth();
            rect.Height = BoxHeadHeight() / 2;
            DrawRoundedRectangle(g, rect, 10, pen);
            g.DrawString(tblfunction.FunctionName, drawFont, drawBrush, rect, drawFormat);

            rect.Y = _rectangle.Y + BoxHeadHeight() / 2;
            rect.Height = BoxHeadHeight() / 2;
            DrawRoundedRectangle(g, rect, 10, pen);
            g.DrawString(tblvariable.VarName, drawFont, drawBrush, rect, drawFormat);

            #endregion


            drawBrush.Dispose();
            drawFont.Dispose();
            //gp.Dispose();
            pen.Dispose();
            b.Dispose();
        }

        /// <summary>
        /// Draw function rectangle , function name input and output pins and connection lines for input/output pins
        /// </summary>
        /// <param name="g"></param>
        public override void Draw(Graphics g)
        {
            DrawHead(g);
            DrawBox(g);
            for (int i = 0; i < LeftPins.Count; i++)
            {
                DrawPin(g, LeftPins[i], true);

            }
            for (int i = 0; i < RightPins.Count; i++)
            {
                DrawPin(g, RightPins[i], false);
            }

        }



        /// <summary>
        /// To indication that object has been selected, draw four small rectangles around object 
        /// </summary>
        /// <remarks>Draw four points around object</remarks>
        public override void DrawTracker(Graphics g)
        {
            if (!Selected)
                return;
            //SolidBrush brush = new SolidBrush(Color.Black);

            //for (int i = 1; i <= 4 /*HandleCount*/; i++)
            //{
            //    g.FillRectangle(brush, GetHandleRectangle(i));
            //}
            //brush.Dispose();
        }


        /// <summary>
        /// Get number of handles
        /// </summary>
        //public override int HandleCount
        //{
        //    get
        //    {
        //        //return 4 + 1 + tblfunction.tblPinCollection.Count; 
        //        return fbdboxobject.NoOfVisibleInputs + fbdboxobject.PinCollectionOutput.Count;
        //    }
        //}
        /// <summary>
        /// Get number of connection points
        /// </summary>
        /// <value>returns number of connection point including inpput and output pins and four points around object</value>
        public override int ConnectionCount
        {
            get
            {
                return HandleCount;
            }
        }
        public override Point GetConnection(int connectionNumber)
        {
            return GetHandle(connectionNumber);
        }
        /// <summary>
        /// Get handle point by 1-based number
        /// </summary>
        /// <param name="handleNumber">1-based handle number to return</param>
        /// <returns>if object is Function returns pin number and pin class</returns>
        //public override bool GetPinInfo(int handleNumber, ref long PinID, ref int PinNo, ref string PinName, ref int PinType, ref short PinClass, ref bool PinIsUsed, ref string objectinstansename)
        //{
        //    //int x, y, xCenter, yCenter;
        //    int NoOfVisibleInputs = fbdboxobject.NoOfVisibleInputs;
        //    objectinstansename = tblvariable.VarName;

        //    if (handleNumber < NoOfVisibleInputs)
        //    {
        //        int no = 0;
        //        for (int i = 0; i < fbdboxobject.PinCollectionInput.Count; i++)
        //        {
        //            if (fbdboxobject.PinCollectionInput[i].Visible)
        //            {
        //                if (no == handleNumber)
        //                {

        //                    PinNo = fbdboxobject.PinCollectionInput[i].PinNo;
        //                    PinType = fbdboxobject.PinCollectionInput[i].tblformalparameter.Type;
        //                    PinClass = fbdboxobject.PinCollectionInput[i].tblformalparameter.Class;
        //                    PinIsUsed = fbdboxobject.PinCollectionInput[i].Connected;
        //                    PinName = fbdboxobject.PinCollectionInput[i].tblformalparameter.PinName;
        //                    PinID = fbdboxobject.PinCollectionInput[i].tblformalparameter.PinID;
        //                    break;
        //                }
        //                else
        //                {
        //                    no++;
        //                }

        //            }

        //        }

        //        return true;
        //    }
        //    else
        //    {
        //        if (handleNumber < NoOfVisibleInputs + fbdboxobject.PinCollectionOutput.Count)
        //        {
        //            PinNo = fbdboxobject.PinCollectionOutput[handleNumber - NoOfVisibleInputs].PinNo;
        //            PinType = fbdboxobject.PinCollectionOutput[handleNumber - NoOfVisibleInputs].tblformalparameter.Type;
        //            PinClass = fbdboxobject.PinCollectionOutput[handleNumber - NoOfVisibleInputs].tblformalparameter.Class;
        //            PinID = fbdboxobject.PinCollectionOutput[handleNumber - NoOfVisibleInputs].tblformalparameter.PinID;
        //            PinIsUsed = false;
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }


        //}
        ///// <summary>
        /// Get handle point by 1-based number
        /// </summary>
        /// <param name="handleNumber"></param>
        /// <returns></returns>
        //public override Point GetHandle(int handleNumber)
        //{
        //    int x, y, xCenter, yCenter;
        //    int NoOfVisibleInputs = fbdboxobject.NoOfVisibleInputs;
        //    xCenter = _rectangle.X + _rectangle.Width / 2;
        //    yCenter = _rectangle.Y + _rectangle.Height / 2;
        //    x = _rectangle.X;
        //    y = _rectangle.Y;

        //    if (handleNumber < NoOfVisibleInputs)
        //    {
        //        int no = 0;
        //        for (int i = 0; i < fbdboxobject.PinCollectionInput.Count; i++)
        //        {
        //            if (fbdboxobject.PinCollectionInput[i].Visible)
        //            {
        //                if (no == handleNumber)
        //                {
        //                    x = fbdboxobject.PinCollectionInput[i].X;
        //                    y = fbdboxobject.PinCollectionInput[i].Y;
        //                    break;
        //                }
        //                else
        //                {
        //                    no++;
        //                }

        //            }

        //        }

        //    }
        //    else
        //    {
        //        if (handleNumber < NoOfVisibleInputs + fbdboxobject.PinCollectionOutput.Count)
        //        {
        //            x = fbdboxobject.PinCollectionOutput[handleNumber - NoOfVisibleInputs].X;
        //            y = fbdboxobject.PinCollectionOutput[handleNumber - NoOfVisibleInputs].Y;
        //        }
        //        else
        //        {
        //            MessageBox.Show("Wrong Handel number");
        //        }
        //    }


        //    return new Point(x, y);
        //}


        


        /// <summary>
        /// Hit test.
        /// Return value: -1 - no hit
        ///                0 - hit anywhere
        ///                > 1 - handle number
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public override int HitTest(Point point)
        {
            if (Selected)
            {
                // Four point around object are not important for this object
                for (int i = 0 /* 1 */ ; i < HandleCount; i++)
                {
                    if (GetHandleRectangle(i).Contains(point))
                        return i;
                }
            }

            if (PointInObject(point))
                return 0;
            return -1;
        }
        public override Rectangle GetHandleRectangle(int handleNumber)
        {
            Point point = GetHandle(handleNumber);
            switch (handleNumber)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                    return new Rectangle(point.X - (PenWidth + 1), point.Y - (PenWidth + 1), 3 + PenWidth, 3 + PenWidth);
                default:
                    if (handleNumber < ConnectionCount)
                    {
                        return new Rectangle(point.X - 4, point.Y - 2, 6, 4);
                    }
                    else
                    {
                        if (handleNumber == ConnectionCount)
                        {
                            return new Rectangle(point.X - 1, point.Y - 2, 6, 4);
                        }
                        else
                        {
                            MessageBox.Show("Wrong Handel number");
                        }
                    }
                    break;
            }
            return new Rectangle(point.X - 1, point.Y - 1, 2, 2);

        }
        protected override bool PointInObject(Point point)
        {
            return _rectangle.Contains(point);
        }

        /// <summary>
        /// Get cursor for the handle
        /// </summary>
        /// <param name="handleNumber"></param>
        /// <returns></returns>
        public override Cursor GetHandleCursor(int handleNumber)
        {
            switch (handleNumber)
            {
                case 1:
                    return Cursors.Cross;//.SizeNWSE;
                case 2:
                    return Cursors.Cross;//.SizeNS;
                //case 3:
                //    return Cursors.SizeNESW;
                //case 4:
                //    return Cursors.SizeWE;
                //case 5:
                //    return Cursors.SizeNWSE;
                //case 6:
                //    return Cursors.SizeNS;
                //case 7:
                //    return Cursors.SizeNESW;
                //case 8:
                //    return Cursors.SizeWE;
                default:
                    return Cursors.Default;
            }
        }

        /// <summary>
        /// Move handle to new point (resizing)
        /// </summary>
        /// <param name="point"></param>
        /// <param name="handleNumber"></param>
        public override void MoveHandleTo(Point point, int handleNumber)
        {
            int left = _rectangle.Left;
            int top = _rectangle.Top;
            int right = _rectangle.Right;
            int bottom = _rectangle.Bottom;

            switch (handleNumber)
            {
                case 1:
                    left = point.X;
                    top = point.Y;
                    break;
                case 2:
                    top = point.Y;
                    break;
                case 3:
                    right = point.X;
                    top = point.Y;
                    break;
                case 4:
                    right = point.X;
                    break;
                case 5:
                    right = point.X;
                    bottom = point.Y;
                    break;
                case 6:
                    bottom = point.Y;
                    break;
                case 7:
                    left = point.X;
                    bottom = point.Y;
                    break;
                case 8:
                    left = point.X;
                    break;
            }
            Dirty = true;
            SetRectangle(left, top, right - left, bottom - top);
        }


        public override bool IntersectsWith(Rectangle rectangle)
        {
            bool Val = _rectangle.IntersectsWith(rectangle);
            if (Val)
            {
                //Console.WriteLine("x = {0} y = {1} w = {2} h = {3}", _rectangle.X, _rectangle.Y, _rectangle.Width, _rectangle.Height);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Move object
        /// </summary>
        /// <param name="deltaX"></param>
        /// <param name="deltaY"></param>
        //public override void Move(int deltaX, int deltaY)
        //{
        //    _rectangle.X += deltaX;
        //    _rectangle.Y += deltaY;

        //    Dirty = true;
        //}

        public override void Dump()
        {
            base.Dump();

        }

        

        private void updateinital(string initstr, string pinshowState)
        {
            int i = 0;
            string[] splitinitval = initstr.Split(';');
            string[] splitpinstate = pinshowState.Split(';');
            for (int j = 0; j < tblfunction.m_tblFormalParameterCollection.Count; j++)
            {
                try
                {
                    if (i < splitpinstate.Length)
                    {
                        if (splitpinstate[i].ToLower() != "true")
                        {
                            splitpinstate[i] = "False";
                        }
                        else
                        {
                            splitpinstate[i] = "True";
                        }
                        tblfunction.m_tblFormalParameterCollection[j].Visible = bool.Parse(splitpinstate[i]);
                        tblfunction.m_tblFormalParameterCollection[j].InitializeValue = splitinitval[i++];
                    }
                    else
                    {
                        tblfunction.m_tblFormalParameterCollection[j].Visible = false;
                        tblfunction.m_tblFormalParameterCollection[j].InitializeValue = "0";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public void RefreshVisible()
        {
            try
            {
                int i = 0;
                int n = -1;
                //int m = 0;

                for (i = 0; i < tblfunction.m_tblFormalParameterCollection.Count; i++)
                {
                    if ((tblfunction.m_tblFormalParameterCollection[i].Class == (int)VarClass.Input) ||
                            (tblfunction.m_tblFormalParameterCollection[i].Class == (int)VarClass.InOut) ||
                            (tblfunction.m_tblFormalParameterCollection[i].Class == (int)VarClass.Internal))
                    {
                        if (tblfunction.m_tblFormalParameterCollection[i].Visible)
                        {
                            n++;
                        }
                        if (tblfunction.m_tblFormalParameterCollection[i].Visible != tblfunction.m_tblFormalParameterCollection[i].UVisible)
                        {
                            if (tblfunction.m_tblFormalParameterCollection[i].UVisible == true)
                            {
                                Parentpagelist.AddUpPinNumber(this.GUID, n + 1);
                                LeftPinsLookup.Insert(n+1,i);
                                LeftPins.Insert(n+1,new FBDPin(tblfunction.m_tblFormalParameterCollection[i], n+1));
                            }
                            if (tblfunction.m_tblFormalParameterCollection[i].UVisible == false)
                            {
                                Parentpagelist.RemovePinNumber(this.GUID, n);
                                LeftPinsLookup.RemoveAt(n);
                                LeftPins.RemoveAt(n);
                            }
                            tblfunction.m_tblFormalParameterCollection[i].Visible = tblfunction.m_tblFormalParameterCollection[i].UVisible;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public override bool Load(object obj)
        {
            base.Load(obj);
            bool ret = false;
            //tblfbdblock = (tblFBDBlock)obj;
            //this.SqlTableID = tblfbdblock.FBDBlockID;
            NewObject = false;
           
            updateinital(tblvariable.InitialVal, tblvariable.PinState);
            
            //FunctionWidth = tblfunction.Width;
            Initalize(tblfbdblock.X, tblfbdblock.Y);
            GenerateGraphic();
            return ret;
        }

        public override bool Save(long _id, int _no)
        {
            bool ret = false;
            string initstr = "";
            string pinshowState = "";
            try
            {
                //tblFBDBlock tblfbdblock = new tblFBDBlock();
                //tblfbdblock.DomainID = DomainID;
                //tblfbdblock.ControllerID = ControllerID;
                tblfbdblock.pouID = _id;

                tblfbdblock.X = _rectangle.Left;
                tblfbdblock.Y = _rectangle.Top;
                tblfbdblock.InstanceName = tblvariable.VarName;
                tblfbdblock.VarpouID = tblvariable.pouID;
                tblfbdblock.VarNameID = tblvariable.VarNameID;
                tblfbdblock.VarType = tblvariable.Type;
                //int i = tblSolution.m_tblSolution().m_tblFunctionCollection.IndexOf(tblfunction);
                //tblfbdblock.FunctionID = tblSolution.m_tblSolution().m_tblFunctionCollection[i].FunctionID;
                tblfbdblock.FunctionID = tblfunction.FunctionID;
                for (int i = 0; i < tblfunction.m_tblFormalParameterCollection.Count; i++)
                {
                    initstr += tblfunction.m_tblFormalParameterCollection[i].InitializeValue;
                    initstr += ";";
                    pinshowState += tblfunction.m_tblFormalParameterCollection[i].Visible;
                    pinshowState += ";";
                }
                tblvariable.InitialVal = initstr;
                tblvariable.PinState = pinshowState;
                tblfbdblock.Type = (int)STATIC_OBJ_TYPE.ID_FBDBoxFunctionBlock; //4;   // 1 variable  2   function  3   extensible function   4 function block
                tblfbdblock.NoOfExtensiblePins = 0;
                tblfbdblock.Page = _no;
                //tblfbdblock.NotTemporary = true;
                //if (NewObject)
                //{

                //    tblvariable.Insert();
                //    tblfbdblock.VarNameID = tblvariable.VarNameID;
                //    tblfbdblock.Update();
                //    NewObject = false;
                //}
                //else
                //{
                //    tblvariable.Update();
                //    tblfbdblock.Update();

                //}
                try
                {
                    tblSolution.m_tblSolution().GetPouFromID(_id).VariablesByName.Add(tblvariable.VarName.ToLower(), tblvariable);
                }
                catch (ArgumentException)
                {
                } 
                tblvariable.PlantStructureID = tblSolution.m_tblSolution().AreaLongList[tblSolution.m_tblSolution().GetControllerobjectofPOUID(tblvariable.pouID).ControllerName];
                
                tblvariable.Class = (int)VarClass.FBInstance;
                if (tblvariable.VarNameID == -1)
                {
                    tblvariable.Insert();
                               // AddLinkedVariables();

                }
                else
                {
                    tblvariable.Update();
                    UpdateLinkedVariables();
                }

                tblfbdblock.VarNameID = tblvariable.VarNameID;

                if (tblfbdblock.FBDBlockID == -1)
                {
                    tblfbdblock.Insert();
                    SQLID = tblfbdblock.FBDBlockID;
                }
                else
                {
                    tblfbdblock.Update();
                }
                Dirty = false;
                ret = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return ret;
        }


        public override void AddLinkedVariables()
        {
            try
            {
                string name;
                bool exist = false;
                tblvariable.LoadLinkedVariable();
                if (!tblfunction.IsStandard)
                {
                    foreach (tblFormalParameter tblformalparameter in tblfunction.m_tblFormalParameterCollection)
                    {
                        if ((tblformalparameter.Class == (int)VarClass.Output) ||
                            //(tblformalparameter.Class == (int)VarClass.Internal) ||
                            (tblformalparameter.Class == (int)VarClass.Local))
                        {
                            name = tblvariable.VarName + "_" + tblformalparameter.PinName;
                            exist = false;
                            foreach (tblVariable tv in tblvariable.m_tblFInstanceVariableList)
                            {
                                if (tv.VarName == name)
                                {
                                    exist = true;
                                    break;
                                }
                            }
                            if (!exist)
                            {
                                tblVariable temp = new tblVariable();
                                temp.VarName = tblvariable.VarName + "_" + tblformalparameter.PinName;
                                //temp.Class = (int)VarClass.Child;
                                temp.Class = (int)tblformalparameter.Class | (int)VarClass.FunctionInstanse;
                                temp.Option = tblformalparameter.Option;
                                temp.Type = tblformalparameter.Type;
                                temp.ParentVarID = tblvariable.VarNameID;
                                temp.ParentVarLinkName = tblformalparameter.PinName;
                                temp.ParentVarLinkID = tblformalparameter.PinID;
                                temp.pouID = tblvariable.pouID;
                                //temp.oIndex = tblformalparameter.oIndex;
                                temp.InitialVal = tblformalparameter.InitializeValue;
                                temp.PlantStructureID = tblSolution.m_tblSolution().AreaLongList[tblSolution.m_tblSolution().GetControllerobjectofPOUID(tblvariable.pouID).ControllerName];
                                temp.Insert();
                                tblSolution.m_tblSolution().GetPouFromID(tblvariable.pouID).VariablesByName.Add(temp.VarName.ToLower(), temp);

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                DCS.Forms.MainForm.Instance().WriteToOutputWindows("Output variable linked to function " + tblvariable.VarName + " cannot be inserted");
            }
        }

        public override void UpdateLinkedVariables()
        {
            try
            {
                foreach (tblFormalParameter tblformalparameter in tblfunction.m_tblFormalParameterCollection)
                {
                    if ((tblformalparameter.Class == (int)VarClass.Output) ||
                        (tblformalparameter.Class == (int)VarClass.Internal) ||
                        (tblformalparameter.Class == (int)VarClass.Local))
                    {
                        tblVariable temp = new tblVariable();
                        temp.VarName = tblvariable.VarName + "_" + tblformalparameter.PinName;
                        temp.Class = (int)VarClass.Child;
                        temp.Option = tblformalparameter.Option;
                        temp.Type = tblformalparameter.Type;
                        temp.ParentVarID = tblvariable.VarNameID;
                        temp.ParentVarLinkName = tblformalparameter.PinName;
                        temp.ParentVarLinkID = tblformalparameter.PinID;
                        temp.pouID = this.pouID;
                        //temp.oIndex = tblformalparameter.oIndex;
                        temp.InitialVal = tblformalparameter.InitializeValue;
                        temp.Update();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                DCS.Forms.MainForm.Instance().WriteToOutputWindows("Output variable linked to function " + tblvariable.VarName + " cannot be inserted");
            }
        }


        public override string GetLeftEndConnectionStringOfPin(int _pinno)
        {
            if (LeftPins[_pinno].Connected)
            {
                Guid wireguid = LeftPins[_pinno].GetRightGUID();
                DrawWire _drawwire = Parentpagelist.GetDrawWireObject(wireguid);
                Guid leftguid = _drawwire.LeftGuid;
                DrawFBDBox drawfbdbox = Parentpagelist.GetFBDBoxObject(leftguid);
                //drawfbdbox.GetLeftEndConnectionStringOfPin(_drawwire.LeftPinNo);
                return LeftPins[_pinno].PinName + ":=" + drawfbdbox.GetRightPinConnectionString(_drawwire.LeftPinNo);
            }

            return "";
        }


        public override string GetRightPinConnectionString(int _pinno)
        {
            if (RightPins[_pinno].Connected)
            {
                //Guid wireguid = LeftPins[_pinno].GetRightGUID();
                //DrawWire _drawwire = drawArea.GetDrawWireObject(wireguid);
                //Guid leftguid = _drawwire.LeftGuid;
                //DrawFBDBox drawfbdbox = drawArea.GetFBDBoxObject(leftguid);
                //drawfbdbox.GetLeftEndConnectionStringOfPin(_drawwire.LeftPinNo);
                return tblvariable.VarName + "."+ RightPins[_pinno].PinName;
                //return RightPins[_pinno].PinName + ":=" + drawfbdbox.GetLeftEndConnectionStringOfPin(_drawwire.LeftPinNo);
            }

            return "";
        }

        public override string GetOutputPinExpression(int _pinno)
        {
            if (LeftPins[_pinno].Connected)
            {
                //Guid wireguid = LeftPins[_pinno].GetRightGUID();
                //DrawWire _drawwire = drawArea.GetDrawWireObject(wireguid);
                //Guid leftguid = _drawwire.LeftGuid;
                //DrawFBDBox drawfbdbox = drawArea.GetFBDBoxObject(leftguid);
                //return LeftPins[_pinno].PinName + ":=" + drawfbdbox.GetRightPinConnectionString(_drawwire.LeftPinNo);
                return tblvariable.VarName + "." + RightPins[_pinno].PinName;
            }

            return "";
        }

        

        #region Helper Functions
        //public static Rectangle GetNormalizedRectangle(int x1, int y1, int x2, int y2)
        //{
        //    if (x2 < x1)
        //    {
        //        int tmp = x2;
        //        x2 = x1;
        //        x1 = tmp;
        //    }

        //    if (y2 < y1)
        //    {
        //        int tmp = y2;
        //        y2 = y1;
        //        y1 = tmp;
        //    }
        //    return new Rectangle(x1, y1, x2 - x1, y2 - y1);
        //}

        //public static Rectangle GetNormalizedRectangle(Point p1, Point p2)
        //{
        //    return GetNormalizedRectangle(p1.X, p1.Y, p2.X, p2.Y);
        //}

        //public static Rectangle GetNormalizedRectangle(Rectangle r)
        //{
        //    return GetNormalizedRectangle(r.X, r.Y, r.X + r.Width, r.Y + r.Height);
        //}
        #endregion Helper Functions
    }
}