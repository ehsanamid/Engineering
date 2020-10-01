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
    public class DrawVariable : DrawFBDBox
	{
		
        //tblFunction tblfunction;
		private const string entryRectangle = "Rect";

        #region Tables Memebers

        //private bool _isobject = false;
        string extendedpropertytxt = "";
        public string ExtendedPropertyTXT
        {
            get
            {
                return extendedpropertytxt;
            }
            set
            {
                extendedpropertytxt = value;
            }
        }

        public bool IsObject
        {
            get
            {
                if (tblformalparameter == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private bool _isconstant = false;
        public bool IsConstant
        {
            get
            {
                return _isconstant;
            }
        }

        //private bool _isextendedproperty = false;
        public bool HasExtendedProperty
        {
            get
            {
                if (extendedpropertytxt == "")
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        private string VarName
        {
            get
            {
                if (IsObject)
                {
                    return tblvariable.VarName;
                }
                else
                {
                    if (HasExtendedProperty)
                    {
                        return tblvariable.VarName + "." + tblformalparameter.PinName + "." + ExtendedPropertyTXT;
                    }
                    else
                    {
                        return tblvariable.VarName + "." + tblformalparameter.PinName;
                    }
                }
            }
        }

        //public tblFormalParameter tblformalparameter = new tblFormalParameter();
        public tblFormalParameter tblformalparameter;
        public int VariableWidht = 7 * Common.BaseSize * Common.UnitSize;
        public int DescriptionWidth = 9 * Common.BaseSize * Common.UnitSize;
        public override int BoxWidth()
        {
            
                int w = 8;
                switch (ShowMode)
                {
                    case ShowVariableMode.Normal:
                        w = VariableWidht;
                        break;
                    case ShowVariableMode.Compact:
                        w = VariableWidht;
                        break;
                    case ShowVariableMode.WideLeft:
                    case ShowVariableMode.WideRight:
                        w = VariableWidht + DescriptionWidth;
                        break;
                }
                return w;
            
        }


        public override int BoxHeight()
        {
                return Common.BaseSize * Common.UnitSize;
            
        }

        public override int BoxHeadHeight()
        {
            
                return 0;
            
        }

        ShowVariableMode oldmode = ShowVariableMode.Normal;
        private ShowVariableMode _showmode = ShowVariableMode.Normal;
        /// <summary>
        /// Show Name or Name and Description of variable in variable box true: Show Name - false: Show Name & Description
        /// </summary>
        public ShowVariableMode ShowMode
        {
            get
            {
                return _showmode;
            }
            set
            {
                oldmode = _showmode;
                _showmode = value;
                switch (oldmode)
                {
                    case ShowVariableMode.Normal:
                    case ShowVariableMode.Compact:
                        switch (_showmode)
                        {
                            case ShowVariableMode.WideLeft:
                                if (LeftPins[0].Connected == false)
                                {
                                    _rectangle.X -= DescriptionWidth;
                                    _rectangle.Width += DescriptionWidth;
                                }
                                else
                                {
                                    _showmode = oldmode;
                                }

                                break;
                            case ShowVariableMode.WideRight:

                                if (RightPins[0].Connected == false)
                                {
                                    //_rectangle.X -= fbdboxobject.DescriptionWidth;
                                    _rectangle.Width += DescriptionWidth;
                                }
                                else
                                {
                                    _showmode = oldmode;
                                }
                                break;
                        }
                        break;
                    case ShowVariableMode.WideLeft:
                        switch (_showmode)
                        {
                            case ShowVariableMode.Normal:
                            case ShowVariableMode.Compact:
                                _rectangle.X += DescriptionWidth;
                                _rectangle.Width -= DescriptionWidth;
                                break;
                            case ShowVariableMode.WideRight:

                                if (RightPins[0].Connected == false)
                                {
                                    _rectangle.X += DescriptionWidth;
                                    //_rectangle.Width += fbdboxobject.DescriptionWidth;
                                }
                                else
                                {
                                    _showmode = oldmode;
                                }
                                break;
                        }
                        break;
                    case ShowVariableMode.WideRight:
                        switch (_showmode)
                        {
                            case ShowVariableMode.Normal:
                            case ShowVariableMode.Compact:
                                //_rectangle.X += fbdboxobject.DescriptionWidth;
                                _rectangle.Width -= DescriptionWidth;
                                break;
                            case ShowVariableMode.WideLeft:

                                if (LeftPins[0].Connected == false)
                                {
                                    _rectangle.X -= DescriptionWidth;
                                    //_rectangle.Width += fbdboxobject.DescriptionWidth;
                                }
                                else
                                {
                                    _showmode = oldmode;
                                }
                                break;
                        }
                        break;
                }

                
            }
        }
        

        
        
        

        #endregion

		/// <summary>
		/// Clone this instance
		/// </summary>
        public override DrawObject Clone()
		{
            DrawVariable drawfunction = new DrawVariable(Parentpagelist);
            //drawfunction._rectangle = _rectangle;

            //FillDrawObjectFields(drawfunction);
            return drawfunction;
		}

        public DrawVariable(PageList _parent)
            : base(_parent)
        {
            NewObject = false;
            Resizeable = false;
            SetRectangle(0, 0, DeltaY, DeltaX);
            //fbdboxobject = new FBDboxObject(this);
            ShapeType = STATIC_OBJ_TYPE.ID_FBDBoxVariable;
        }

        public override void GenerateGraphic()
        {
            if (!IsObject)
            {
                LeftPins.Add(new FBDPin(tblformalparameter, 0));
                RightPins.Add(new FBDPin(tblformalparameter, 0));
            }
            else
            {
                LeftPins.Add(new FBDPin(tblvariable.Type, 0));
                RightPins.Add(new FBDPin(tblvariable.Type, 0));
            }
			base.GenerateGraphic();
        }

       public DrawVariable(PageList _parent, int x, int y, tblVariable _tblvariable, tblFormalParameter _tblformalparameter,string extendedproperystring/*,bool isextendedproperty,bool isobject*/) 
           : base( _parent)
		{

            tblvariable = _tblvariable;
            tblformalparameter = _tblformalparameter;
            //this._isobject = isobject;
            this.ExtendedPropertyTXT = extendedproperystring;
            //this._isextendedproperty = isextendedproperty;
            ShapeType = STATIC_OBJ_TYPE.ID_FBDBoxVariable;
            Initalize(x, y);
            GenerateGraphic();
            
            
		}

       
        
        

         /// <summary>
        /// Draw function rectangle , function name input and output pins and connection lines for input/output pins
        /// </summary>
        /// <param name="g"></param>
		public override void Draw(Graphics g)
		{
            Pen pen;
            Brush b = new SolidBrush(FillColor);

           // if (DrawPen == null)
                pen = new Pen(Color, PenWidth);
          //  else
           //     pen = (Pen)DrawPen.Clone();

            //GraphicsPath gp = new GraphicsPath();
            //gp.AddRectangle(_rectangle);
            //// Rotate the path about it's center if necessary


            //g.DrawPath(pen, gp);
            //if (Filled)
            //    g.FillPath(b, gp);

            //DrawRoundedRectangle(g, _rectangle, 10, pen);
            /////////////////////////////
            // Draw string for Name and Description
            /////////////////////////////
            Font drawFont;
            SolidBrush drawBrush;
            StringFormat drawFormat;
            Rectangle drawRectName;
            Rectangle drawRectDescription;
            switch (_showmode)
            {
                case ShowVariableMode.Normal:
                    drawFont = new Font("Arial", 8);
                    drawBrush = new SolidBrush(Color.Black);

                    // Set format of string.
                    drawFormat = new StringFormat();
                    drawFormat.Alignment = StringAlignment.Center;
                    drawFormat.LineAlignment = StringAlignment.Center;
                    // Draw string to screen.
                    DrawRoundedRectangle(g, _rectangle, 10, pen);
                    g.DrawString(VarName, drawFont, drawBrush, _rectangle, drawFormat);
                    drawBrush.Dispose();
            drawFont.Dispose();
                    break;
                case ShowVariableMode.Compact:
                    drawFont = new Font("Arial", 8);
                    drawBrush = new SolidBrush(Color.Black);

                    // Create rectangle for drawing.

                    drawRectName = new Rectangle(_rectangle.X, _rectangle.Y, _rectangle.Width, _rectangle.Height / 2);
                    drawRectDescription = new Rectangle(_rectangle.X, _rectangle.Y + _rectangle.Height / 2, _rectangle.Width, _rectangle.Height / 2);


                    // Set format of string.
                    drawFormat = new StringFormat();
                    drawFormat.Alignment = StringAlignment.Center;
                    drawFormat.LineAlignment = StringAlignment.Center;
                    // Draw string to screen.
                    DrawRoundedRectangle(g, _rectangle, 10, pen);
                    g.DrawString(VarName, drawFont, drawBrush, drawRectName, drawFormat);
                    g.DrawString(tblvariable.Description, drawFont, drawBrush, drawRectDescription, drawFormat);
                    drawBrush.Dispose();
            drawFont.Dispose();
                    break;
                case ShowVariableMode.WideLeft:
                    drawFont = new Font("Arial", 8);
                    drawBrush = new SolidBrush(Color.Black);


                    drawFormat = new StringFormat();
                    drawFormat.Alignment = StringAlignment.Center;
                    drawFormat.LineAlignment = StringAlignment.Center;

                    drawRectName = new Rectangle(_rectangle.X + DescriptionWidth, _rectangle.Y, VariableWidht, _rectangle.Height);
                    DrawRoundedRectangle(g, drawRectName, 10, pen);
                    drawRectDescription = new Rectangle(_rectangle.X, _rectangle.Y, DescriptionWidth, _rectangle.Height);
                    DrawRoundedRectangle(g, drawRectDescription, 10, pen);

                    g.DrawString(VarName, drawFont, drawBrush, drawRectName, drawFormat);
                    drawFormat.Alignment = StringAlignment.Near;
                    drawFormat.LineAlignment = StringAlignment.Center;
                    g.DrawString(tblvariable.Description, drawFont, drawBrush, drawRectDescription, drawFormat);
                    drawBrush.Dispose();
            drawFont.Dispose();
                    break;
                case ShowVariableMode.WideRight:
                    drawFont = new Font("Arial", 8);
                    drawBrush = new SolidBrush(Color.Black);


                    drawFormat = new StringFormat();
                    drawFormat.Alignment = StringAlignment.Center;
                    drawFormat.LineAlignment = StringAlignment.Center;

                    drawRectName = new Rectangle(_rectangle.X, _rectangle.Y, VariableWidht, _rectangle.Height);
                    DrawRoundedRectangle(g, drawRectName, 10, pen);
                    drawRectDescription = new Rectangle(_rectangle.X + VariableWidht, _rectangle.Y, DescriptionWidth, _rectangle.Height);
                    DrawRoundedRectangle(g, drawRectDescription, 10, pen);

                    g.DrawString(VarName, drawFont, drawBrush, drawRectName, drawFormat);
                    drawFormat.Alignment = StringAlignment.Near;
                    drawFormat.LineAlignment = StringAlignment.Center;
                    g.DrawString(tblvariable.Description, drawFont, drawBrush, drawRectDescription, drawFormat);
                    drawBrush.Dispose();
            drawFont.Dispose();
                    break;
            }

            ///////////////////////////////////////
            // End of Drawing strings
            //////////////////////////////////////
            // gp.Dispose();
            
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
                return 2;
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

      

       

        //public override string GetLeftEndConnectionStringOfPin(int _pinno)
        //{
        //    if (_pinno == 0)
        //    {
        //        if (RightPins[_pinno].Connected)
        //        {
        //            Guid wireguid = RightPins[_pinno].GetRightGUID();
        //            //DrawWire _drawwire = drawArea.GetDrawWireObject(wireguid);
        //            //Guid leftguid = _drawwire.LeftGuid;
        //            //DrawFBDBox drawfbdbox = drawArea.GetFBDBoxObject(leftguid);
        //            //drawfbdbox.GetLeftEndConnectionStringOfPin(_drawwire.LeftPinNo);
        //            return drawArea.GetDrawWireObject(wireguid).Leftstring;
        //            //if(this.IsExtendedProperty)
        //            //{
        //            //    return drawfbdbox.GetRightPinConnectionString(_drawwire.LeftPinNo);
        //            //}
        //            //else
        //            //{
                    
        //            //return drawfbdbox.GetRightPinConnectionString(_drawwire.LeftPinNo);
        //            //}
        //        }
        //    }
        //    return "";
        //}

        public override string GetOutputPinExpression(int _pinno)
        {
            try
            {
                if (IsObject)   // 100920016 added
                {
                    return tblvariable.VarName;
                }
                else
                {
                    if (HasExtendedProperty)
                    {
                        return tblvariable.VarName + "." + tblformalparameter.PinName + "." + this.ExtendedPropertyTXT;
                    }
                    else
                    {
                        return tblvariable.VarName + "." + tblformalparameter.PinName;
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return "";
        }

        public override string GetRightPinConnectionString(int _pinno)
        {
            try
            {
                // if (_pinno == 0)
                // {
                //     if (RightPins[_pinno].Connected)
                //     {
                if (HasExtendedProperty)
                {
                    return tblvariable.VarName + "." + tblformalparameter.PinName + "." + this.ExtendedPropertyTXT;
                }
                else
                {
                    return tblvariable.VarName + "." + tblformalparameter.PinName;
                }
                //     }
                //  }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return "";
        }

        

         

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

            //IsObject = tblfbdblock.ISObject;
            //_isextendedproperty = tblfbdblock.IsExtendedProperty;
            ExtendedPropertyTXT = tblfbdblock.ExtendedPropertyTXT;
            tblvariable.VarNameID = tblfbdblock.VarNameID;
            tblvariable.Select();
            string typname = tblSolution.m_tblSolution().GetFunctionFromType(tblvariable.Type).FunctionName;
            if (!tblfbdblock.ISObject)
            {
                tblformalparameter = new tblFormalParameter(tblSolution.m_tblSolution().GetFunctionFromName(typname).GetFormalParameterFromName(tblfbdblock.PinName));
            }
            else
            {
                tblformalparameter = null;
            }
            //tblformalparameter.PinName = tblfbdblock.PinName;
            //tblformalparameter.Select();
            initstr = tblvariable.InitialVal;
            pinshowState = tblvariable.PinState;
            //int i = 0;

            //FunctionWidth = tblfunction.Width;
            Initalize(tblfbdblock.X, tblfbdblock.Y);
            GenerateGraphic();
            Dirty = false;
            
            return ret;
        }

        public override bool Save(long _id,int _pageno)
        {
            bool ret = false;
            
            try
            {
                //tblFBDBlock tblfbdblock = new tblFBDBlock();
                //tblfbdblock.DomainID = DomainID;
                //tblfbdblock.ControllerID = ControllerID;
                tblfbdblock.pouID = _id;
                
                tblfbdblock.X = _rectangle.Left;
                tblfbdblock.Y = _rectangle.Top;
                tblfbdblock.InstanceName = VarName;

                tblfbdblock.FunctionID = -1;
                //tblfbdblock.VarControllerID = TempVar.controllerid;
                tblfbdblock.VarpouID = tblvariable.pouID;
                tblfbdblock.VarNameID = tblvariable.VarNameID;
                tblfbdblock.VarType = tblvariable.Type;
                tblfbdblock.Type = (int)STATIC_OBJ_TYPE.ID_FBDBoxVariable; //1;   // 1 variable  2   function  3   extensible function   4 function block
                tblfbdblock.Page = _pageno;
                tblfbdblock.NoOfExtensiblePins = (int)_showmode;
                if (!IsObject)
                {
                    tblfbdblock.PinName = tblformalparameter.PinName;
                    tblfbdblock.ExtendedPropertyTXT = ExtendedPropertyTXT;
                }
                else
                {
                    tblfbdblock.PinName = "";
                    tblfbdblock.ExtendedPropertyTXT = "";
                }
                //tblfbdblock.HasExtendedProperty = HasExtendedProperty;
                tblfbdblock.ISObject = IsObject;

                //tblfbdblock.NotTemporary = true;
                
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

        //public override Point GetOutputPinPosition(long _pinid)
        //{
        //    return new Point(this.fbdboxobject.PinCollectionOutput[0].X, this.fbdboxobject.PinCollectionOutput[0].Y);
        //}

        //public override Point GetInputPinPosition(long _pinid)
        //{
        //    return new Point(this.fbdboxobject.PinCollectionInput[0].X, this.fbdboxobject.PinCollectionInput[0].Y);
        //}

        public override bool IsMouseOverPin(Point p, ref Guid _guid, ref bool LeftSide, ref int _pinno, ref int _type)
        {
            bool ret = false;
            for (int i = 0; i < LeftPins.Count; i++)
            {
                if (LeftPins[i].PointOverPort(p))
                {
                    LeftSide = true;
                    _pinno = i;
                    _guid = GUID;
                    if (HasExtendedProperty)
                    {
                        _type = (int)VarType.BOOL;
                    }
                    else
                    {
                        _type = LeftPins[i].PinType;
                    }
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
                    if (HasExtendedProperty)
                    {
                        _type = (int)VarType.BOOL;
                    }
                    else
                    {
                        _type = RightPins[i].PinType;
                    }
                    return true;
                }
            }
            return ret;
        }

        
       
        //#region Helper Functions
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
        //#endregion Helper Functions
	}
}