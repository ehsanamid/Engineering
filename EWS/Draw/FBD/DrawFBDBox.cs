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
	public class DrawFBDBox : DrawLogic
	{
        public int DeltaY = Common.UnitSize * Common.BaseSize;
        public int DeltaX = 180;
        bool isoutputblock;
        [Browsable(false)]
        public bool IsOutputBlock
        {
            get
            {
                return isoutputblock;
            }
            set
            {
                isoutputblock = value;
            }
        }

        bool saved;
        [Browsable(false)]
        public bool Saved
        {
            get
            {
                return saved;
            }
            set
            {
                saved = value;
            }
        }
		private const string entryRectangle = "Rect";
        int overridetype = (int)VarType.ANY;
        public int OverideType
        {
            get
            {
                return overridetype;
            }
            set
            {
                overridetype = value;
            }
        }
        #region Tables Memebers

        //public TemporayVariable TempVar;
        //public long VarDomainID;
        //public long VarControllerID;
        //public long VarPouID;
        public tblVariable tblvariable = new tblVariable();
        public tblFunction tblfunction = new tblFunction();
        public tblFBDBlock tblfbdblock = new tblFBDBlock();
        
        public long TempVar_id = -1;
        public virtual int BoxWidth()
        {

            return 0;

        }


        

        public List<FBDPin> LeftPins = new List<FBDPin>();
        public List<FBDPin> RightPins = new List<FBDPin>();

        public virtual int BoxHeight()
        {
            int m = Math.Max(LeftPins.Count, RightPins.Count);
            return BoxHeadHeight() + Math.Max(LeftPins.Count, RightPins.Count) * Common.BaseSize * Common.UnitSize;// +(Common.BaseSize * Common.UnitSize) / 2;
        }

        public virtual int BoxHeadHeight()
        {

            return 0;

        }

        ///// <remarks>SQL Type:varchar - </remarks>
        //private string _FunctionName;

        //[DisplayName("Function Name")]
        //[Browsable(false)]
        //[Category("Column")]
        //public string FunctionName
        //{
        //    get
        //    {
        //        try
        //        {
        //            return _FunctionName;
        //        }
        //        catch (System.Exception err)
        //        {
        //            throw new Exception("Error getting FunctionName", err);
        //        }
        //    }
        //    set
        //    {
        //        try
        //        {
        //            if ((value.Length <= 50))
        //            {
        //                _FunctionName = value;
        //            }
        //            else
        //            {
        //                throw new OverflowException("Error setting FunctionName, Length of value is to long. Maximum Length: 50");
        //            }
        //        }
        //        catch (System.Exception err)
        //        {
        //            throw new Exception("Error setting FunctionName", err);
        //        }
        //    }
        //}

        
        //private string _Description;

        //[DisplayName("Description")]
        //[Browsable(false)]
        //[Category("Column")]
        //public string Description
        //{
        //    get
        //    {
        //        try
        //        {
        //            return _Description;
        //        }
        //        catch (System.Exception err)
        //        {
        //            throw new Exception("Error getting Description", err);
        //        }
        //    }
        //    set
        //    {
        //        try
        //        {
        //            if ((value.Length <= 120))
        //            {
        //                _Description = value;
        //            }
        //            else
        //            {
        //                throw new OverflowException("Error setting Description, Length of value is to long. Maximum Length: 120");
        //            }
        //        }
        //        catch (System.Exception err)
        //        {
        //            throw new Exception("Error setting Description", err);
        //        }
        //    }
        //}

        ///// <remarks>SQL Type:int - </remarks>
        //private FunctionGroup _FunctionGroup;

        //[DisplayName("Function Group")]
        //[Browsable(false)]
        //[Category("Column")]
        //public FunctionGroup FunctionGroup
        //{
        //    get
        //    {
        //        try
        //        {
        //            return _FunctionGroup;
        //        }
        //        catch (System.Exception err)
        //        {
        //            throw new Exception("Error getting FunctionGroup", err);
        //        }
        //    }
        //    set
        //    {
        //        try
        //        {
        //            _FunctionGroup = value;
        //        }
        //        catch (System.Exception err)
        //        {
        //            throw new Exception("Error setting FunctionGroup", err);
        //        }
        //    }
        //}

        int functionwidth;
        [Browsable(false)]
        public int FunctionWidth
        {
            get
            {
                return functionwidth;
            }
            set
            {
                functionwidth = value;
            }
        }
    
        //private FBDboxObject _fbdboxobject;
        //[Description("Represents collection of input pins for graphical use")]
        //[TypeConverter(typeof(FBDboxObjectTypeConverter))]
        //public FBDboxObject fbdboxobject
        //{
        //    get
        //    {
        //        return _fbdboxobject;
        //    }
        //    set
        //    {
        //        _fbdboxobject = value;
        //    }
        //}

        

        #endregion

		/// <summary>
		/// Clone this instance
		/// </summary>
        public override DrawObject Clone()
        {
            DrawFBDBox drawfbdbox = new DrawFBDBox(Parentpagelist);

            return drawfbdbox;
        }

        public DrawFBDBox(PageList _parent)
            : base(_parent)
        {
           
            Resizeable = false;
            SetRectangle(0, 0, DeltaY, DeltaX);
            tblfbdblock.FBDBlockID = -1;
            tblvariable.VarNameID = -1;
            //fbdboxobject = new FBDboxObject(this);
        }

        public DrawFBDBox(PageList _parent, int x, int y, TemporayVariable _tempvar)
            : base(_parent)
		{
            tblfbdblock.FBDBlockID = -1;
            tblvariable.VarNameID = -1;
		}

        public DrawFBDBox(PageList _parent, int x, int y, tblFunction _tblfunction, int _noofextension, TemporayVariable _tempvar)
            : base(_parent)
		{
            tblfbdblock.FBDBlockID = -1;
            tblvariable.VarNameID = -1;   
		}

        public virtual void GenerateGraphic()
        {
			UpdatePinlocations();
            
        }
        public virtual Point GetRightPinPosition(int _pinno)
        {
            return RightPins[_pinno].PortCenterPoint;
            
        }
        public virtual Point GetLeftPinPosition(int _pinno)
        {
            return LeftPins[_pinno].PortCenterPoint;
        }

        public  int GetLeftPinType(int _pinno)
        {
            int _type = 0;
            _type = LeftPins[_pinno].PinType;
            return _type;
        }

        public  int GetRightPinType(int _pinno)
        {
            int _type = 0;
            _type = RightPins[_pinno].PinType;
            return _type;
        }

        public void SetRightPinType(int _pinno, int _type)
        {
            RightPins[_pinno].PinType = _type;
            for (int i = 0; i < LeftPins.Count; i++)
            {
                if (!Common.IsSimpleType(LeftPins[i].PinType))
                {
                    LeftPins[i].PinType = _type;
                }
            }
        }


        public virtual List<int> GetRightSideConnectionTypes(int _pinno)
        {
            List<int> _type = new List<int>();
            foreach (Guid guid in  RightPins[_pinno].WireConnectionID)
            {
                DrawWire _drawwire = Parentpagelist.GetDrawWireObject(guid);
                Guid rightguid = _drawwire.RightGuid;
                DrawFBDBox drawfbdbox = Parentpagelist.GetFBDBoxObject(rightguid);
                _type.Add(drawfbdbox.GetLeftPinType(_drawwire.RightPinNo));
            }
            
            return _type;
        }


        public virtual string GetLeftEndConnectionStringOfPin(int _pinno)
        {
            if (LeftPins[_pinno].Connected)
            {
                Guid wireguid = LeftPins[_pinno].GetRightGUID();
                DrawWire _drawwire = Parentpagelist.GetDrawWireObject(wireguid);
                return Parentpagelist.GetFBDBoxObject(_drawwire.LeftGuid).GetOutputPinExpression(_drawwire.LeftPinNo);
                //DrawFBDBox drawfbdbox = drawArea.GetFBDBoxObject(leftguid);
                //return drawfbdbox.GetRightPinConnectionString(_drawwire.LeftPinNo);
            }

            return "";
        }

        public virtual DrawFBDBox GetLeftEndConnectionDrawFBDBox(int _pinno)
        {
            if (LeftPins[_pinno].Connected)
            {
                Guid wireguid = LeftPins[_pinno].GetRightGUID();
                DrawWire _drawwire = Parentpagelist.GetDrawWireObject(wireguid);
                return Parentpagelist.GetFBDBoxObject(_drawwire.LeftGuid);
            }

            return null;
        }

        public virtual string GetRightPinConnectionString(int _pinno)
        {
            if (RightPins[_pinno].Connected)
            {
                return RightPins[_pinno].PinName;
            }
            return "";
        }

        public virtual string GetOutputPinExpression(int _pinno)
        {
            if (RightPins[_pinno].Connected)
            {
                return RightPins[_pinno].PinName;
            }
            return "";
        }
        public virtual void AddLinkedVariables()
        {
            //try
            //{
            //    string name;
            //    bool exist = false;
            //    if (tblvariable.m_tblFInstanceVariableList.Count > 1)
            //    {
            //        tblvariable.DeleteLinkedVariable();
            //    }
            //    foreach (tblFormalParameter tblformalparameter in tblfunction.m_tblFormalParameterCollection)
            //    {
            //        if( (tblformalparameter.Class == (int)VarClass.Output) /*|| (tblformalparameter.Class == (int)VarClass.Local)*/)
            //        {
            //            name = tblvariable.VarName + "_" + tblformalparameter.PinName;
            //            exist = false;
            //            foreach (tblVariable tv in tblvariable.m_tblFInstanceVariableList)
            //            {
            //                if (tv.VarName == name)
            //                {
            //                    exist = true;
            //                    break;
            //                }
            //            }
            //            if (!exist)
            //            {
            //                tblVariable temp = new tblVariable();
            //                temp.VarName = name;
            //                temp.Class = (int)tblformalparameter.Class | (int)VarClass.FunctionInstanse;
            //                temp.Option = tblformalparameter.Option;
            //                temp.Type = RightPins[0].PinType;
            //                temp.ParentVarID = tblvariable.VarNameID;
            //                temp.ParentVarLinkName = tblformalparameter.PinName;
            //                temp.ParentVarLinkID = tblformalparameter.PinID;
            //                temp.pouID = this.pouID;
            //                temp.InitialVal = tblformalparameter.InitializeValue;
            //                temp.PlantStructureID = tblSolution.m_tblSolution().AreaLongList[tblSolution.m_tblSolution().GetControllerobjectofPOUID(tblvariable.pouID).ControllerName];
                                
            //                temp.Insert();
            //                tblvariable.m_tblFInstanceVariableList.Add(temp);
            //                tblSolution.m_tblSolution().GetPouFromID(temp.pouID).VariablesByName[temp.VarName] = temp;
            //                break;
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //    DCS.Forms.MainForm.Instance().WriteToOutputWindows("Output variable linked to function " + tblvariable.VarName + " cannot be inserted");
            //}
        }

        // 10092016 commented
        public virtual void UpdateLinkedVariables()
        {
        //    try
        //    {
        //        foreach (tblFormalParameter tblformalparameter in tblfunction.m_tblFormalParameterCollection)
        //        {
        //            if ((tblformalparameter.Class == (int)VarClass.Output) /*|| (tblformalparameter.Class == (int)VarClass.Local)*/)
        //            {
        //                tblVariable temp = new tblVariable();
        //                temp.VarName = tblvariable.VarName + "_" + tblformalparameter.PinName;
        //                temp.Class = (int)VarClass.Child;
        //                temp.Option = tblformalparameter.Option;
        //                temp.Type = tblformalparameter.Type;
        //                temp.ParentVarID = tblvariable.VarNameID;
        //                temp.ParentVarLinkName = tblformalparameter.PinName;
        //                temp.ParentVarLinkID = tblformalparameter.PinID;
        //                temp.pouID = this.pouID;
        //                //temp.oIndex = tblformalparameter.oIndex;
        //                temp.InitialVal = tblformalparameter.InitializeValue;
        //                temp.Update();

        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //        DCS.Forms.MainForm.Instance().WriteToOutputWindows("Output variable linked to function " + tblvariable.VarName + " cannot be inserted");
        //    }
        }

        public void AddConnectionToPort(Guid _guid,bool _leftpin,int _pinno)
        {
            if (_leftpin)
            {
                LeftPins[_pinno].AddConnectionToPort(_guid);
            }
            else
            {
                RightPins[_pinno].AddConnectionToPort(_guid);
            }
            Dirty = true;
        }
        public virtual void Initalize(int x, int y)
        {
            FunctionWidth = tblfunction.Width;
            Resizeable = false;
            AcceptConnection = true;

            _rectangle.X = x;
            _rectangle.Y = y;
            _rectangle.Width = BoxWidth();
            _rectangle.Height = BoxHeight();
            Color = Color.Black; ;
            FillColor = Color.White; ;

            PenWidth = 1;
            //TipText = String.Format("_rectangle Center @ {0}, {1}", Center.X, Center.Y);


        }

        public virtual void DrawHead(Graphics g)
        {
            //Pen pen;
            //Brush b = new SolidBrush(FillColor);
            //Rectangle rect = new Rectangle();
            //if (DrawPen == null)
            //    pen = new Pen(Color, PenWidth);
            //else
            //    pen = (Pen)DrawPen.Clone();

            //Font drawFont = new Font("Arial", 7);
            //SolidBrush drawBrush = new SolidBrush(Color.Black);

            //// Set format of string.
            //StringFormat drawFormat = new StringFormat();
            //_rectangle.Width = BoxWidth();
            //_rectangle.Height = BoxHeight();

            //#region Draw string for Name and Description
            //drawFormat.Alignment = StringAlignment.Center;
            //drawFormat.LineAlignment = StringAlignment.Center;

            //rect.X = _rectangle.X;
            //rect.Y = _rectangle.Y;
            //rect.Width = BoxWidth();
            //rect.Height = BoxHeadHeight() / 2;
            //DrawRoundedRectangle(g, rect, 10, pen);
            //g.DrawString(tblfunction.FunctionName, drawFont, drawBrush, rect, drawFormat);

            //rect.Y = _rectangle.Y + BoxHeadHeight() / 2;
            //rect.Height = BoxHeadHeight() / 2;
            //DrawRoundedRectangle(g, rect, 10, pen);
            //g.DrawString(tblvariable.VarName, drawFont, drawBrush, rect, drawFormat);

            //#endregion

                

            ////gp.Dispose();
            //pen.Dispose();
            //b.Dispose();
        }

        public virtual void DrawBox(Graphics g)
        {
            Pen pen;
            Brush b = new SolidBrush(FillColor);
            Rectangle rect = new Rectangle();
           // if (DrawPen == null)
                pen = new Pen(Color, PenWidth);
            //else
            //    pen = (Pen)DrawPen.Clone();

            Font drawFont = new Font("Arial", 7);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            // Set format of string.
            StringFormat drawFormat = new StringFormat();
            _rectangle.Width = BoxWidth();
            _rectangle.Height = BoxHeight();
            rect.X = _rectangle.X;
            rect.Y = _rectangle.Y + BoxHeadHeight(); ;
            rect.Width = BoxWidth();
            rect.Height = _rectangle.Height - BoxHeadHeight();
            DrawRoundedRectangle(g, rect, 10, pen);


            drawBrush.Dispose();
            drawFont.Dispose();

            //gp.Dispose();
            pen.Dispose();
            b.Dispose();
        }

        public virtual void DrawPin(Graphics g,FBDPin fbdpin,bool leftpin)
        {
            Pen pen;
            Brush b = new SolidBrush(FillColor);
            
          //  if (DrawPen == null)
                pen = new Pen(Color, PenWidth);
          //  else
          //      pen = (Pen)DrawPen.Clone();

            Font drawFont = new Font("Arial", 7);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            // Set format of string.
            StringFormat drawFormat = new StringFormat();
            

            #region Draw Connection Lines for each input and output pin and draw name of pin

            //g.DrawRectangle(pen, fbdpin.PinRect);
            if (leftpin)
            {
                g.DrawLine(pen, fbdpin.PortCenterPoint.X, fbdpin.PortCenterPoint.Y,fbdpin.PortCenterPoint.X-3, fbdpin.PortCenterPoint.Y );
                drawFormat.Alignment = StringAlignment.Near;
                drawFormat.LineAlignment = StringAlignment.Center;
                g.DrawString(fbdpin.PinName, drawFont, drawBrush, fbdpin.PinRect, drawFormat);

            }
            else
            {
                g.DrawLine(pen, fbdpin.PortCenterPoint.X, fbdpin.PortCenterPoint.Y, fbdpin.PortCenterPoint.X + 3, fbdpin.PortCenterPoint.Y);
                drawFormat.Alignment = StringAlignment.Far;
                drawFormat.LineAlignment = StringAlignment.Center;
                g.DrawString(fbdpin.PinName, drawFont, drawBrush, fbdpin.PinRect, drawFormat);
            }
            #endregion

            drawBrush.Dispose();
            drawFont.Dispose();
            //gp.Dispose();
            pen.Dispose();
            b.Dispose();
        }



        public bool IsMouseOverBox(Point p, ref Guid _guid)
        {
            bool ret = false;
            if (containPoint(p))
            {
                _guid = GUID;
                ret = true;
            }
            return ret;
        }

        public virtual bool IsMouseOverPin(Point p, ref Guid _guid, ref bool LeftSide, ref int _pinno, ref int _type)
        {
            bool ret = false;
            for (int i = 0; i < LeftPins.Count; i++)
            {
                if (LeftPins[i].PointOverPort(p))
                {
                    LeftSide = true;
                    _pinno = i;
                    _guid = GUID;
                    _type = LeftPins[i].PinType;
                    return true;
                }
            }
            for (int i = 0; i < RightPins.Count; i++)
            {
                if (RightPins[i].PointOverPort(p))
                {
                    LeftSide = false;
                    _pinno = i;
                    _guid = GUID;
                    _type = RightPins[i].PinType;
                    return true;
                }
            }
            return ret;
        }

    

        protected void DrawRoundedRectangle(Graphics gfx, Rectangle Bounds, int CornerRadius, Pen DrawPen)
        {
            int strokeOffset = Convert.ToInt32(Math.Ceiling(DrawPen.Width));
            //Bounds = _rectangle.Inflate(Bounds, -strokeOffset, -strokeOffset);

            DrawPen.EndCap = DrawPen.StartCap = LineCap.Round;

            GraphicsPath gfxPath = new GraphicsPath();
            gfxPath.AddArc(Bounds.X, Bounds.Y, CornerRadius, CornerRadius, 180, 90);
            gfxPath.AddArc(Bounds.X + Bounds.Width - CornerRadius, Bounds.Y, CornerRadius, CornerRadius, 270, 90);
            gfxPath.AddArc(Bounds.X + Bounds.Width - CornerRadius, Bounds.Y + Bounds.Height - CornerRadius, CornerRadius, CornerRadius, 0, 90);
            gfxPath.AddArc(Bounds.X, Bounds.Y + Bounds.Height - CornerRadius, CornerRadius, CornerRadius, 90, 90);
            gfxPath.CloseAllFigures();
            //e.Graphics.FillPath(Brushes.White, path);
            //e.Graphics.DrawPath(Pens.Black, path);
            //gfx.FillPath(Brushes.White, gfxPath);
            SolidBrush drawBrush = new SolidBrush(FillColor);
            gfx.FillPath(drawBrush, gfxPath);
            gfx.DrawPath(Pens.Black, gfxPath);
            drawBrush.Dispose();
        }
        /// <summary>
        /// Draw function rectangle , function name input and output pins and connection lines for input/output pins
        /// </summary>
        /// <param name="g"></param>
		public override void Draw(Graphics g)
		{
            
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
		protected void SetRectangle(int x, int y, int width, int height)
		{
            _rectangle.X = x;
            _rectangle.Y = y;
            _rectangle.Width = width;
            _rectangle.Height = height;
		}

		/// <summary>
		/// Get number of handles
		/// </summary>
		public override int HandleCount
		{
			get 
            {
                //return 4 + 1 + tblfunction.tblPinCollection.Count; 
                //return fbdboxobject.NoOfVisibleInputs + fbdboxobject.PinCollectionOutput.Count;
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
        public override bool GetPinInfo(int handleNumber, ref long PinID, ref int PinNo, ref string PinName, ref int PinType, ref short PinClass, ref bool PinIsUsed, ref string objectinstansename)
        {
            ////int x, y, xCenter, yCenter;
            //int NoOfVisibleInputs = fbdboxobject.NoOfVisibleInputs;
            //objectinstansename = InstanseName;

            //if (handleNumber < NoOfVisibleInputs)
            //{
            //    int no = 0;
            //    for (int i = 0; i < fbdboxobject.PinCollectionInput.Count; i++)
            //    {
            //        if (fbdboxobject.PinCollectionInput[i].Visible)
            //        {
            //            if (no == handleNumber)
            //            {
                            
            //                PinNo = fbdboxobject.PinCollectionInput[i].PinNo;
            //                PinType = fbdboxobject.PinCollectionInput[i].Type;
            //                PinClass = fbdboxobject.PinCollectionInput[i].Class;
            //                PinIsUsed = fbdboxobject.PinCollectionInput[i].Connected;
            //                break;
            //            }
            //            else
            //            {
            //                no++;
            //            }

            //        }

            //    }
                
            //    return true;
            //}
            //else
            //{
            //    if (handleNumber < NoOfVisibleInputs + fbdboxobject.PinCollectionOutput.Count)
            //    {
            //        PinNo = fbdboxobject.PinCollectionOutput[handleNumber - NoOfVisibleInputs].PinNo;
            //        PinType = fbdboxobject.PinCollectionOutput[handleNumber - NoOfVisibleInputs].Type;
            //        PinClass = fbdboxobject.PinCollectionOutput[handleNumber - NoOfVisibleInputs].Class;
            //        PinIsUsed = false;
            //        return true;
            //    }
            //    else
            //    {
            //        return false;
            //    }
            //}
            return true;
            
        }
		/// <summary>
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
                            return new Rectangle(point.X -1, point.Y - 2, 6, 4);
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
            Parentpagelist.Dirty = true;
			SetRectangle(left, top, right - left, bottom - top);
		}

        public bool containPoint(Point pt)
        {
            bool ret = false;
            if (_rectangle.Contains(pt))
            {
                ret = true;
            }
            return ret;
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
		public override void Move(int deltaX, int deltaY)
		{
            
            //_rectangle.X += drawArea.FittoSnap(deltaX, drawArea.SnapX);
            //_rectangle.Y += drawArea.FittoSnap(deltaY, drawArea.SnapY);
            _rectangle.X += deltaX;
            _rectangle.Y += deltaY;
            UpdatePinlocations();
           
			Dirty = true;
            Parentpagelist.Dirty = true;
            //drawArea.SetDirty();
		}


        public override void MoveTo(int _newx, int _newy)
        {
            _rectangle.X = _newx;
            _rectangle.Y = _newy;
            UpdatePinlocations();

            Dirty = true;
            Parentpagelist.Dirty = true;
        }
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
            bool ret = false;
            Dirty = false;
            tblfbdblock = (tblFBDBlock)obj;
            SQLID = tblfbdblock.FBDBlockID;
            NewObject = false;
            tblvariable.VarNameID = tblfbdblock.VarNameID;
            tblvariable = tblSolution.m_tblSolution().GetPouFromID(tblfbdblock.VarpouID).GettblVariableVariable(tblfbdblock.VarNameID);
            if(tblvariable == null)
            {
                return false;
            }
            if (tblfbdblock.FunctionID != -1)
            {
                tblfunction.FunctionID = tblfbdblock.FunctionID;// = tblSolution.m_tblSolution().m_tblFunctionCollection.GetFunctionbyType(tblvariable.Type);
                tblfunction.Select();
            }
            FunctionWidth = tblfunction.Width;
            return ret;
        }

        public override bool Save(long _id,int _pageno)
        {
            bool ret = false;
            
            return ret;
        }

        public void UpdateWireConnections()
        {
            foreach (FBDPin fbdpin in LeftPins)
            {
                foreach (Guid guid in fbdpin.WireConnectionID)
                {
                    Parentpagelist.FindWire(Parentpagelist.ActivePageNo, guid).UpdateWireConections();
                }
            }
            foreach (FBDPin fbdpin in RightPins)
            {
                foreach (Guid guid in fbdpin.WireConnectionID)
                {
                    Parentpagelist.FindWire(Parentpagelist.ActivePageNo, guid).UpdateWireConections();
                }
            }
       }
        public void DeleteWireConnectionFromPin(int _pinno, bool _leftconnection, Guid wireguid)
        {
            if (_leftconnection)
            {
                LeftPins[_pinno].RemoveConnection(wireguid);
            }
            else
            {
                RightPins[_pinno].RemoveConnection(wireguid);
            }
        }

        public virtual void UpdatePinlocations()
        {
            for (int i = 0; i < LeftPins.Count; i++)
            {
                LeftPins[i].PinRect = SetPinRect(i, true);
                LeftPins[i].PortCenterPoint = SetPortCenterPoint(i, true);
            }
            for (int i = 0; i < RightPins.Count; i++)
            {
                RightPins[i].PinRect = SetPinRect(i, false);
                RightPins[i].PortCenterPoint = SetPortCenterPoint(i, false);
            }

        }


        public Rectangle SetPinRect(int _pinno,bool _leftpin)
		{
		int u = Common.BaseSize * Common.UnitSize;
		int x = _rectangle.X;
		int y = _rectangle.Y;
		int w = BoxWidth();
		int hi = BoxHeight();
		int h = BoxHeadHeight();
		int mi = RightPins.Count;
			if(_leftpin)
			{
				return new Rectangle(x,y+h+_pinno*u,w,u);
			}
			else
			{
				return new Rectangle(x,y+hi-(mi-_pinno)*u,w,u);
			}
		}
		
		public Point SetPortCenterPoint(int _pinno,bool _leftpin)
		{
		int u = Common.BaseSize * Common.UnitSize;
		int x = _rectangle.X;
		int y = _rectangle.Y;
		int w = BoxWidth();
		int hi = BoxHeight();
		int h = BoxHeadHeight();
		int mi = RightPins.Count;
			if(_leftpin)
			{
				return new Point(x,y+h+_pinno*u+u/2);
			}
			else
			{
				return new Point(x+w,y+hi-(mi-_pinno)*u+u/2);
			}
		}

        public virtual bool IsOutputobject()
        {
            for (int i = 0; i < RightPins.Count; i++)
            {
                if (RightPins[i].Connected)
                {
                    return false;
                }
            }
            return true;
        }
		
	}
}