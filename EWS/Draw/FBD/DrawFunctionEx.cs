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
using DCS.TabPages;


namespace DCS.Draw.FBD
{
    /// <summary>
    /// _rectangle graphic object
    /// </summary>
    [Serializable]
    public class DrawFunctionEx : DrawFBDBox
    {

        //public tblFunction tblfunction;
        private const string entryRectangle = "Rect";

        #region Tables Memebers

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

            return Common.UnitSize * Common.BaseSize / 2;

        }

        private int noofnonextendableinputs = 0;
        


        int noofextendablepins;
        [DisplayName("Number of Variable Pins")]
        [Category("Column")]
        public int NoOfExtendablePins
        {
            get
            {

                return noofextendablepins;

            }
            set
            {
                try
                {

                    //int newnoofextendablepins = value;
                    int k = 0;
                    int j;
                    //int count = 0;
                    noofnonextendableinputs = 0;
                    for (j = 0; j < tblfunction.m_tblFormalParameterCollection.Count; j++)
                    {
                        if (tblfunction.m_tblFormalParameterCollection[j].Class == (int)VarClass.Input )
                        {
                            if (tblfunction.m_tblFormalParameterCollection[j].Extensible == false)
                            {
                                LeftPins[noofnonextendableinputs].Visible = true;
                                
                                noofnonextendableinputs++;
                            }
                            else
                            {
                                for (k = 0; k < noofextendablepins ; k++)
                                {
                                    if (noofnonextendableinputs + k < LeftPins.Count)
                                    {

                                    }
                                    else
                                    {
                                        FBDPin fbdpin = new FBDPin(tblfunction.m_tblFormalParameterCollection[j], noofnonextendableinputs + k);
                                        LeftPins.Add(fbdpin);
                                    }
                                }
                                for (k = noofnonextendableinputs + noofextendablepins; k < LeftPins.Count; k++)
                                {
                                    if (!LeftPins[LeftPins.Count - 1].Connected)
                                    {
                                        LeftPins.RemoveAt(LeftPins.Count - 1);
                                    }
                                    else
                                    {
                                        Parentpagelist.DeleteWire(LeftPins[LeftPins.Count - 1].ConnectionGuid);
                                        LeftPins.RemoveAt(LeftPins.Count - 1);
                                    }

                                }
                            }

                        }
                    }
                    
                    
                    //fbdboxobject.NoOfVisibleInputs = count;
                    //fbdboxobject.UpdatePins();

                }
                catch (System.Exception err)
                {
                    throw new Exception("Error setting Extensible input number", err);
                }
            }
        }







        #endregion

        /// <summary>
        /// Clone this instance
        /// </summary>
        public override DrawObject Clone()
        {
            DrawFunctionEx drawfunction = new DrawFunctionEx(Parentpagelist);
            drawfunction._rectangle = _rectangle;

            // FillDrawObjectFields(drawfunction);
            return drawfunction;
        }

        public DrawFunctionEx(PageList _parent)
            : base(_parent)
        {
            ShapeType = STATIC_OBJ_TYPE.ID_FBDBoxFunctionEx;
            Resizeable = false;
            tblvariable.VarNameID = -1;
            tblfbdblock.FBDBlockID = -1;
            SetRectangle(0, 0, DeltaY, DeltaX);
            //fbdboxobject = new FBDboxObject(this);
        }
        public override void GenerateGraphic()
        {

            
            int pnl = 0;
            int pnr = 0;
            int j = 0;

            for (j = 0; j < tblfunction.m_tblFormalParameterCollection.Count; j++)
            {
                switch ((VarClass)tblfunction.m_tblFormalParameterCollection[j].Class)
                {
                    case VarClass.Input:
                    case VarClass.InOut:
                        if (tblfunction.m_tblFormalParameterCollection[j].Extensible == false)
                        {
                            LeftPins.Add(new FBDPin(tblfunction.m_tblFormalParameterCollection[j], pnl++));
                        }
                        else
                        {
                            for (int k = 0; k < NoOfExtendablePins; k++)
                            {
                                LeftPins.Add(new FBDPin(tblfunction.m_tblFormalParameterCollection[j], pnl++));
                            }
                        }
                        break;
                    case VarClass.Output:

                        RightPins.Add(new FBDPin(tblfunction.m_tblFormalParameterCollection[j], pnr++));
                        break;
                    default:
                        break;
                }

            }
            base.GenerateGraphic();
        }




        //public DrawFunctionEx(int x, int y, tblFunction _tblfunction/*, string _instanseName*/, int _noofextension, TemporayVariable _tempvar/*, long _selectedvarid, long _domainid, long _controllerid, long _pouid*/)
        public DrawFunctionEx(PageList _parent, int x, int y, tblFunction _tblfunction, tblVariable _tblvariable, int _noofextension)
            : base(_parent)
        {
            ShapeType = STATIC_OBJ_TYPE.ID_FBDBoxFunctionEx;
            tblvariable = _tblvariable;
            tblfunction = _tblfunction;
            tblvariable.VarNameID = -1;
            tblfbdblock.FBDBlockID = -1;
            noofextendablepins = _noofextension;
            Initalize(x, y);
            GenerateGraphic();
        }
        


        /// <summary>
        /// Draw function rectangle , function name input and output pins and connection lines for input/output pins
        /// </summary>
        /// <param name="g"></param>
        //public override void Draw(Graphics g)
        //{

        //    Pen pen;
        //    Brush b = new SolidBrush(FillColor);
        //    Rectangle rect = new Rectangle();
        //    if (DrawPen == null)
        //        pen = new Pen(Color, PenWidth);
        //    else
        //        pen = (Pen)DrawPen.Clone();

        //    Font drawFont = new Font("Arial", 7);
        //    SolidBrush drawBrush = new SolidBrush(Color.Black);

        //    // Set format of string.
        //    StringFormat drawFormat = new StringFormat();
        //    _rectangle.Width = BoxWidth();
        //    _rectangle.Height = BoxHeight();

        //    #region Draw string for Name and Description
        //    drawFormat.Alignment = StringAlignment.Center;
        //    drawFormat.LineAlignment = StringAlignment.Center;

        //    rect.X = _rectangle.X;
        //    rect.Y = _rectangle.Y;
        //    rect.Width = BoxWidth();
        //    rect.Height = BoxHeadHeight();
        //    DrawRoundedRectangle(g, rect, 10, pen);
        //    g.DrawString(tblfunction.FunctionName, drawFont, drawBrush, rect, drawFormat);

        //    #endregion

        //    rect.X = _rectangle.X;
        //    rect.Y = _rectangle.Y + BoxHeadHeight(); ;
        //    rect.Width = BoxWidth();
        //    rect.Height = _rectangle.Height - BoxHeadHeight() ;
        //    DrawRoundedRectangle(g, rect, 10, pen);

        //    #region Draw Connection Lines for each input and output pin and draw name of pin
        //    int x1, x2, y1, y2, u;
        //    string str1;
        //    u = Common.BaseSize * Common.UnitSize;
        //    for (int i = 0; i < LeftPins.Count; i++)
        //    {
        //        if (LeftPins[i].Visible)
        //        {
        //            //x1 = _rectangle.X + PinCollectionInput[i].X;
        //            //y1 = _rectangle.Y + PinCollectionInput[i].Y;
        //            x1 = LeftPins[i].PinRect.Left;
        //            y1 = LeftPins[i].PinRect.Top;
        //            x2 = x1 - 3;
        //            y2 = y1;
        //            g.DrawLine(pen, x1, y1, x2, y2);

        //            drawFormat.Alignment = StringAlignment.Near;
        //            drawFormat.LineAlignment = StringAlignment.Center;
        //            rect = LeftPins[i].PinRect;
        //            // Draw string to screen.
        //            str1 = LeftPins[i].PinName;
        //            g.DrawString(str1, drawFont, drawBrush, rect, drawFormat);
        //        }
        //    }
        //    for (int i = 0; i < RightPins.Count; i++)
        //    {
        //        //x1 = _rectangle.X + PinCollectionOutput[i].X;
        //        //y1 = _rectangle.Y + PinCollectionOutput[i].Y;
        //        x1 = RightPins[i].PinRect.Left;
        //        y1 = RightPins[i].PinRect.Top;
        //        x2 = x1 + 3;
        //        y2 = y1;
        //        g.DrawLine(pen, x1, y1, x2, y2);

        //        drawFormat.Alignment = StringAlignment.Far;
        //        drawFormat.LineAlignment = StringAlignment.Center;
        //        rect = RightPins[i].PinRect;
        //        // Draw string to screen.
        //        str1 = RightPins[i].PinName;
        //        g.DrawString(str1, drawFont, drawBrush, rect, drawFormat);
        //    }
        //    #endregion


        //    //gp.Dispose();
        //    pen.Dispose();
        //    b.Dispose();

        //}

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
        public override void DrawHead(Graphics g)
        {
            Pen pen;
            Brush b = new SolidBrush(FillColor);
            Rectangle rect = new Rectangle();
         //   if (DrawPen == null)
                pen = new Pen(Color, PenWidth);
          //  else
          //      pen = (Pen)DrawPen.Clone();

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
            rect.Height = BoxHeadHeight();
            DrawRoundedRectangle(g, rect, 10, pen);
            g.DrawString(tblfunction.FunctionName, drawFont, drawBrush, rect, drawFormat);

            #endregion

            drawBrush.Dispose();
            drawFont.Dispose();
            pen.Dispose();
            b.Dispose();
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
        public override int HandleCount
        {
            get
            {
                //return 4 + 1 + tblfunction.tblPinCollection.Count; 
                return LeftPins.Count + RightPins.Count;
            }
        }
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
        //    //switch (handleNumber)
        //    //{
        //    //    case 1:
        //    //        x = _rectangle.X;
        //    //        y = _rectangle.Y;
        //    //        break;
        //    //    case 2:
        //    //        x = _rectangle.Right;
        //    //        y = _rectangle.Y;
        //    //        break;
        //    //    case 3:
        //    //        x = _rectangle.Right;
        //    //        y = _rectangle.Bottom;
        //    //        break;
        //    //    case 4:
        //    //        x = _rectangle.X;
        //    //        y = _rectangle.Bottom;
        //    //        break;
        //    //    default:
        //    //        if ((handleNumber >= 5) && (handleNumber < (5 + fbdboxobject.PinCollectionInput.Count)))
        //    //        {
        //    //            x = _rectangle.X;
        //    //            y = _rectangle.Y + fbdboxobject.HeadHeight + Common.UnitSize * Common.BaseSize * (handleNumber - 5) + Common.UnitSize * Common.BaseSize / 2;
        //    //        }
        //    //        else
        //    //        {
        //    //            if ((handleNumber >= (5 + fbdboxobject.PinCollectionInput.Count)) && (handleNumber < (5 + fbdboxobject.PinCollectionInput.Count + fbdboxobject.PinCollectionOutput.Count)))
        //    //            {
        //    //                x = _rectangle.Right;
        //    //                y = _rectangle.Bottom - Common.UnitSize * Common.BaseSize * (4 + fbdboxobject.PinCollectionInput.Count + fbdboxobject.PinCollectionOutput.Count - handleNumber) - Common.UnitSize * Common.BaseSize / 2;

        //    //            }
        //    //            else
        //    //            {
        //    //                MessageBox.Show("Wrong Handel number");
        //    //            }
        //    //        }
        //    //        break;

        //    //}

        //    return new Point(x, y);
        //}


        

        ///// <summary>
        ///// Get position of connection point of input pin
        ///// </summary>
        ///// <param name="Input Pin number"></param>
        ///// <returns>pin connection point</returns>
        //public override Point GetInputPinPosition(int pinno)
        //{
        //    int x = 0;
        //    int y = 0;
        //    if (pinno < PinCollectionInput.Count)
        //    {
        //        //x = rectangle.X;
        //        //y = rectangle.Y + HeadHeight + Common.UnitSize * Common.BaseSize * (pinno) + Common.UnitSize * Common.BaseSize / 2;
        //        x = 0;
        //        y = HeadHeight + Common.UnitSize * Common.BaseSize * (pinno) + Common.UnitSize * Common.BaseSize / 2;
        //    }

        //    return new Point(x, y);
        //}
        ///// <summary>
        ///// Get position of connection point of input pin
        ///// </summary>
        ///// <param name="Input Pin number"></param>
        ///// <returns>pin connection point</returns>
        //public override Point GetOutpuPinPosition(int pinno)
        //{
        //    int x = 0;
        //    int y = 0;
        //    if (pinno < PinCollectionOutput.Count)
        //    {
        //        //x = rectangle.Right;
        //        //y = rectangle.Bottom - Common.UnitSize * Common.BaseSize * (PinCollectionOutput.Count - pinno -1) - Common.UnitSize * Common.BaseSize / 2;
        //        x = _rectangle.Width;
        //        y = _rectangle.Height - Common.UnitSize * Common.BaseSize * (PinCollectionOutput.Count - pinno - 1) - Common.UnitSize * Common.BaseSize / 2;
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

            // Trace.WriteLine("rectangle.X = " + _rectangle.X.ToString(CultureInfo.InvariantCulture));
            // Trace.WriteLine("rectangle.Y = " + _rectangle.Y.ToString(CultureInfo.InvariantCulture));
            // Trace.WriteLine("rectangle.Width = " + _rectangle.Width.ToString(CultureInfo.InvariantCulture));
            // Trace.WriteLine("rectangle.Height = " + _rectangle.Height.ToString(CultureInfo.InvariantCulture));
        }

        

        public override bool Load(object obj)
        {
            base.Load(obj);
            bool ret = false;
            //tblfbdblock = (tblFBDBlock)obj;
            //this.SqlTableID = tblfbdblock.FBDBlockID;
            NewObject = false;
            string initstr = "";
            string pinshowState = "";

            noofextendablepins = tblfbdblock.NoOfExtensiblePins;

            //tblvariable = tblSolution.m_tblSolution().GettbltblDomainObjectFromID(tblfbdblock.DomainID).GettblControllerObjectFromID(tblfbdblock.ControllerID).GettblPouObjectFromID(tblfbdblock.pouID).GettblVariableVariable(tblfbdblock.VarNameID);
            //tblvariable.Select();
            
            initstr = tblvariable.InitialVal;
            pinshowState = tblvariable.PinState;
            //tblfunction.FunctionID = tblfbdblock.FunctionID;// = tblSolution.m_tblSolution().m_tblFunctionCollection.GetFunctionbyType(tblvariable.Type);
            //tblfunction.Select();
            //int i = 0;
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
                tblfbdblock.pouID = _id;
                tblfbdblock.X = _rectangle.Left;
                tblfbdblock.Y = _rectangle.Top;
                tblfbdblock.InstanceName = tblvariable.VarName;
                tblfbdblock.VarpouID = tblvariable.pouID;
                tblfbdblock.VarNameID = tblvariable.VarNameID;
                tblfbdblock.VarType = tblvariable.Type;
                tblfbdblock.FunctionID = tblfunction.FunctionID;
                for (int i = 0; i < LeftPins.Count; i++)
                {
                    initstr += LeftPins[i].InitialValue;
                    initstr += ";";
                    //pinshowState += LeftPins[i].Visible.ToString();
                    //pinshowState += ",";
                }
                tblvariable.InitialVal = initstr;
                tblvariable.PinState = pinshowState;
                tblfbdblock.Type = (int)STATIC_OBJ_TYPE.ID_FBDBoxFunctionEx; 
                tblfbdblock.NoOfExtensiblePins = NoOfExtendablePins;
                tblfbdblock.Page = _no;
                tblvariable.Class = (int)VarClass.FunctionInstanse;
                try
                {
                    tblSolution.m_tblSolution().GetPouFromID(_id).VariablesByName.Add(tblvariable.VarName.ToLower(), tblvariable);
                }
                catch (ArgumentException)
                {
                } 
                tblvariable.PlantStructureID = tblSolution.m_tblSolution().AreaLongList[tblSolution.m_tblSolution().GetControllerobjectofPOUID(tblvariable.pouID).ControllerName];
                
                if (tblvariable.VarNameID == -1)
                {
                    tblvariable.Insert();
                    //tblSolution.m_tblSolution().GetPouFromID(_id).VariablesByName[tblvariable.VarName] = tblvariable;
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
                if (tblvariable.Type != RightPins[0].PinType)
                {
                    tblvariable.Type = RightPins[0].PinType;
                    tblvariable.Update();
                }
                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                DCS.Forms.MainForm.Instance().WriteToOutputWindows("function " + tblvariable.VarName + " cannot be updated");
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
                string sss = Parentpagelist.GetDrawWireObject(wireguid).Leftstring;
                return drawfbdbox.GetRightPinConnectionString(_drawwire.LeftPinNo);
            }

            return "";
        }

        public override string GetOutputPinExpression(int _pinno)
        {
            if (LeftPins[_pinno].Connected)
            {
                //return tblvariable.m_tblFInstanceVariableList[0].VarName + ".VAL";   //10092016 commented
                return tblvariable.VarName + ".VAL";  //10092016 added
            }
            return "";
        }

        public override string GetRightPinConnectionString(int _pinno)
        {
            if (RightPins[_pinno].Connected)
            {
                //return tblvariable.VarName + "." + RightPins[_pinno].PinName; //10092016 commented
                return tblvariable.VarName + ".VAL";  //10092016 added
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