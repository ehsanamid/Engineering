using DCS.DCSTables;
using DCS.Project_Objects;
using DCS.TabPages;
using DCS.TypeConverters;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Windows.Forms;

namespace DCS.Draw
{
	/// <summary>
	/// Line graphic object
	/// </summary>
	[Serializable]
    public class DrawLine : DrawGraphic
	{
        tblLine sqltable = new tblLine();
        private static Color staticboardercolor1 = Color.Red;
        private static Color staticboardercolor2 = Color.Red;
		
        private Point startPoint;
        public Point StartPoint
        {
            get { return startPoint; }
            set { startPoint = value; }
        }
        
        private Point endPoint;
        public Point EndPoint
        {
            get { return endPoint; }
            set { endPoint = value; }
        }
		

        ShapeOutline _shapeoutline;
        [Editor(typeof(ShapeOutlineTypeEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(ShapeOutlineTypeConverter))]  //[TypeConverter(typeof(ExpandableObjectConverter))]
        [Category("Advance")]
        public ShapeOutline shapeoutline
        {
            get
            {
                return _shapeoutline;
            }
            set
            {
                _shapeoutline = value;
            }
        }

        private int _arrowsize = 1;
        public int ArrowSize
        {
            get
            {
                return _arrowsize;
            }
            set
            {
                _arrowsize = value;
            }
        }
        

        public DrawLine(PageList _parent)
            : base(_parent)
		{
            _shapeoutline = new ShapeOutline(this);
            ShapeType = STATIC_OBJ_TYPE.ID_LINE;
            shapeoutline.LineStyle = Common.LastLineStyle;
            Resizeable = true;
			startPoint.X = 0;
			startPoint.Y = 0;
			endPoint.X = 1;
			endPoint.Y = 1;
			oIndex = 0;
            

            ArrowSize = 1;

            Propertylist.Add("Border Width,Line Width,DINT");
            Propertylist.Add("BorderColor,Line Color,Color");
            Propertylist.Add("BorderBlinking,Line Blinking,BOOL");
            Propertylist.Add("Visible,Visible,BOOL");

			Initialize();
		}

        public DrawLine(PageList _parent, int x1, int y1, int x2, int y2)
            : base(_parent)
        {
            _shapeoutline = new ShapeOutline(this);
            ShapeType = STATIC_OBJ_TYPE.ID_LINE;
            shapeoutline.LineStyle = Common.LastLineStyle;
            Resizeable = true;
            startPoint.X = x1;
            startPoint.Y = y1;
            endPoint.X = x2;
            endPoint.Y = y2;
            

            ArrowSize = 1;
            Propertylist.Add("Border Width,Line Width,DINT");
            Propertylist.Add("BorderColor,Line Color,Color");
            Propertylist.Add("BorderBlinking,Line Blinking,BOOL");
            Propertylist.Add("Visible,Visible,BOOL");
            
            oIndex = 0;
            TipText = String.Format("Line Start @ {0}-{1}, End @ {2}-{3}", x1, y1, x2, y2);
            Initialize();
        }

        
        public override Rectangle GetConnectionEllipse(int connectionNumber)
        {
            Point p = GetConnection(connectionNumber);
            // Take into account width of pen
            return new Rectangle(p.X - (shapeoutline.BoarderWidth + 3), p.Y - (shapeoutline.BoarderWidth + 3), 7 + shapeoutline.BoarderWidth, 7 + shapeoutline.BoarderWidth);
        }
        protected override void UpdateHasExpression()
        {
            base.UpdateHasExpression();
            foreach (DisplayObjectDynamicProperty exp in this.drawexpressionCollection.objDisplayObjectDynamicPropertys.list)
            {
                switch (exp.ObjectType)
                {
                    case enumDynamicGraphicalProperty.BorderWidth:
                        this.shapeoutline.HasBoarderWidthExpression = true;
                        break;
                    case enumDynamicGraphicalProperty.BorderColor:
                        this.shapeoutline.HasBoarderColor1Expression = true;
                        break;
                    case enumDynamicGraphicalProperty.Color1:

                        break;
                    case enumDynamicGraphicalProperty.Color2:

                        break;
                    case enumDynamicGraphicalProperty.TextColor:

                        break;
                    case enumDynamicGraphicalProperty.BorderBlinking:
                        this.shapeoutline.HasBoarderBlinkingExpression = true;
                        break;
                    case enumDynamicGraphicalProperty.Blinking:

                        break;
                    case enumDynamicGraphicalProperty.TextBlinking:

                        break;
                    case enumDynamicGraphicalProperty.Text:

                        break;
                 
                }
            }


        }

        //public void init(tblLine tblline)
        public override bool Load(object obj)
        {
            bool ret = true;
            Dirty = false;
            sqltable = (tblLine)obj;
            SQLID = sqltable.ID;
            oIndex = sqltable.oIndex;
            Layer = (LAYERS)sqltable.Layer;
            NewObject = false;
            //, , , 
            startPoint.X = sqltable.Left;
            startPoint.Y = sqltable.Top;
            endPoint.X = sqltable.Right;
            endPoint.Y = sqltable.Bottom;
            //BoarderColor1 = Color.FromArgb(tblline.BoarderColor1);
            shapeoutline.LineStyle = sqltable.LineStyle;

            ArrowSize = 1;// tblline.ArrowSize;

#if EWSAPP
            drawexpressionCollection.DisplayObjectParametersstr = sqltable.Argument;
            drawexpressionCollection.DisplayObjectDynamicPropertysstr = sqltable.Expression;
            drawexpressionCollection.DisplayObjectEventHandlersstr = sqltable.Action;
#endif
#if OWSAPP
            if (sqltable.validexpression)
            {
                loadDrawExpressionCollection(sqltable.CompiledExp);
                UpdateHasExpression();
            } 
#endif
            //makeBoarderDashStyle(  );
            return ret;
        }

        public override bool Save(long _id, int _no)
        {
            try
            {
#if EWSAPP
                sqltable.oIndex = _no;
                sqltable.DisplayID = _id;
                sqltable.Layer = (int)Layer;
                sqltable.Left = startPoint.X;
                sqltable.Top = startPoint.Y;
                sqltable.Right = endPoint.X;
                sqltable.Bottom = endPoint.Y;
                sqltable.Argument = drawexpressionCollection.DisplayObjectParametersstr;
                sqltable.Expression = drawexpressionCollection.DisplayObjectDynamicPropertysstr;
                sqltable.Action = drawexpressionCollection.DisplayObjectEventHandlersstr;

                //tblline.BoarderColor1 = BoarderColor1.ToArgb();
                sqltable.LineStyle = shapeoutline.LineStyle;
                if (drawexpressionCollection.CompileGraphicDispalyExpressions(((TabDisplayPageControl)Parentpagelist.Parenttabgraphicpagecontrol).tbldisplay))
                {
                    sqltable.validexpression = true;
                    sqltable.CompiledExp = drawexpressionCollection.SaveCompiledExpressions();

                }
                else
                {
                    sqltable.validexpression = false;
                }
                if (sqltable.ID == -1)
                {
                    sqltable.Insert();
                    SQLID = sqltable.ID;
                }
                else
                {
                    sqltable.Update();
                }
                Dirty = false; 
#endif
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public override void Draw(Graphics g)
        {

            try
            {
                if (this.Visible)
                {
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    Color bcolor = Color.White;
                    SelecactiveColor(ref bcolor, shapeoutline);
                    Pen pen = MakePen(bcolor, shapeoutline);
                    switch (shapeoutline.EndLineCap)
                    {
                        case LineCap.ArrowAnchor:
                            AdjustableArrowCap bigArrow = new AdjustableArrowCap(ArrowSize, ArrowSize);
                            pen.CustomEndCap = bigArrow;
                            break;
                        default:
                            pen.EndCap = shapeoutline.EndLineCap;
                            break;
                    }
                    switch (shapeoutline.StartLineCap)
                    {
                        case LineCap.ArrowAnchor:
                            AdjustableArrowCap bigArrow = new AdjustableArrowCap(ArrowSize, ArrowSize);
                            pen.CustomStartCap = bigArrow;
                            break;
                        default:
                            pen.StartCap = shapeoutline.StartLineCap;
                            break;
                    }

                    GraphicsPath gp = new GraphicsPath();
                    gp.AddLine(startPoint, endPoint);
                    //Trace.WriteLine("Draw startPointX=" + startPoint.X.ToString() + " startPointY="+ startPoint.Y.ToString() + " endPoint=" + endPoint.X.ToString() + " endPoint="+ endPoint.Y.ToString());
                    g.DrawPath(pen, gp);
                    gp.Dispose();
                    pen.Dispose();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        /// <summary>
        /// Clone this instance
        /// </summary>
        public override DrawObject Clone()
		{
            DrawLine drawLine = new DrawLine(Parentpagelist);
			drawLine.startPoint = startPoint;
			drawLine.endPoint = endPoint;

			FillDrawObjectFields(drawLine);
			return drawLine;
		}

		public override int HandleCount
		{
			get { return 2; }
		}

		/// <summary>
		/// Get handle point by 1-based number
		/// </summary>
		/// <param name="handleNumber"></param>
		/// <returns></returns>
		public override Point GetHandle(int handleNumber)
		{
			GraphicsPath gp = new GraphicsPath();
			Matrix m = new Matrix();
			gp.AddLine(startPoint, endPoint);
			RectangleF pathBounds = gp.GetBounds();
			//m.RotateAt(Rotation, new PointF(pathBounds.Left + (pathBounds.Width / 2), pathBounds.Top + (pathBounds.Height / 2)), MatrixOrder.Append);
			gp.Transform(m);
			Point start, end;
			start = Point.Truncate(gp.PathPoints[0]);
			end = Point.Truncate(gp.PathPoints[1]);
			gp.Dispose();
			m.Dispose();
			if (handleNumber == 1)
				return start;
			else
				return end;
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
				for (int i = 1; i <= HandleCount; i++)
				{
					GraphicsPath gp = new GraphicsPath();
					gp.AddRectangle(GetHandleRectangle(i));
					bool vis = gp.IsVisible(point);
					gp.Dispose();
					if (vis)
						return i;
				}
			// OK, so the point is not on a selection handle, is it anywhere else on the line?
			if (PointInObject(point))
				return 0;
			return -1;
		}

		protected override bool PointInObject(Point point)
		{
			CreateObjects();
			//return AreaPath.IsVisible(point);
			return AreaRegion.IsVisible(point);
		}

		public override bool IntersectsWith(Rectangle rectangle)
		{
			CreateObjects();

			return AreaRegion.IsVisible(rectangle);
		}

		public override Cursor GetHandleCursor(int handleNumber)
		{
			switch (handleNumber)
			{
				case 1:
				case 2:
					return Cursors.SizeAll;
				default:
					return Cursors.Default;
			}
		}

		public override void MoveHandleTo(Point point, int handleNumber)
		{
			//GraphicsPath gp = new GraphicsPath();
			//Matrix m = new Matrix();
			//if (handleNumber == 1)
			//    gp.AddLine(point, endPoint);
			//else
			//    gp.AddLine(startPoint, point);

			//RectangleF pathBounds = gp.GetBounds();
			//m.RotateAt(Rotation, new PointF(pathBounds.Left + (pathBounds.Width / 2), pathBounds.Top + (pathBounds.Height / 2)), MatrixOrder.Append);
			//gp.Transform(m);
			//Point start, end;
			//start = Point.Truncate(gp.PathPoints[0]);
			//end = Point.Truncate(gp.PathPoints[1]);
			//gp.Dispose();
			//m.Dispose();
			//if (handleNumber == 1)
			//    startPoint = start;
			//else
			//    endPoint = end;

			if (handleNumber == 1)
				startPoint = point;
			else
				endPoint = point;
            Trace.WriteLine("MoveHandleTo endPoint.X = " + endPoint.X.ToString() + " endPoint.Y = " + endPoint.Y.ToString() );
			Dirty = true;
			Invalidate();
		}

		public override void Move(int deltaX, int deltaY)
		{
			startPoint.X += deltaX;
			startPoint.Y += deltaY;

			endPoint.X += deltaX;
			endPoint.Y += deltaY;
			Dirty = true;
			Invalidate();
		}

		
		

		/// <summary>
		/// Create graphic objects used for hit test.
		/// </summary>
		protected override void CreateObjects()
		{
			if (AreaPath != null)
				return;

			// Create path which contains wide line
			// for easy mouse selection
			AreaPath = new GraphicsPath();
			// Take into account the width of the pen used to draw the actual object
            AreaPen = new Pen(Color.Black, shapeoutline.BoarderWidth < 7 ? 7 : shapeoutline.BoarderWidth);
			// Prevent Out of Memory crash when startPoint == endPoint
			if (startPoint.Equals((Point)endPoint))
			{
				endPoint.X++;
				endPoint.Y++;
			}
			AreaPath.AddLine(startPoint.X, startPoint.Y, endPoint.X, endPoint.Y);
			AreaPath.Widen(AreaPen);
			// Rotate the path about it's center if necessary
			

			// Create region from the path
			AreaRegion = new Region(AreaPath);
		}

        

        //private Point startPoint;
        //private Point endPoint;
        protected DrawLine(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            if (info == null)
                throw new ArgumentNullException("info");

            _shapeoutline = new ShapeOutline(this);
            startPoint = (Point)info.GetValue("startPoint", startPoint.GetType());
            endPoint = (Point)info.GetValue("endPoint", endPoint.GetType());
            _shapeoutline = (ShapeOutline)info.GetValue("shapeoutline", _shapeoutline.GetType());
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        protected override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info,context);
            info.AddValue("startPoint", startPoint);
            info.AddValue("endPoint", endPoint);
            info.AddValue("shapeoutline", _shapeoutline.LineStyle);
            
        }

        
	}
}