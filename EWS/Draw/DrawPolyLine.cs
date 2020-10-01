using DCS;
using DCS.DCSTables;
using DCS.TabPages;
using DCS.TypeConverters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Windows.Forms;
using System.Xml;

namespace DCS.Draw
{
	/// <summary>
	/// PolyLine graphic object - a PolyLine is a series of connected lines
	/// </summary>
	[Serializable]
    public class DrawPolyLine : DrawLine
	{
        tblPolyline sqltable = new tblPolyline();
        protected List<Point> pointArray = new List<Point>(); // list of points
        protected Cursor handleCursor;

        int _linetype = 0;
        public int LineType
        {
            get
            {
                return _linetype;
            }
            set
            {
                _linetype = value;
            }
        }

        string _ponits = "";

        public string Points
        {
            get
            {
                XmlDocument dom = new XmlDocument();

                XmlElement PointsElement = dom.CreateElement("Points");
                dom.AppendChild(PointsElement);

                for (int i = 0; i < pointArray.Count; i++)
                {
                    XmlElement PointElement = dom.CreateElement("Point");
                    PointElement.InnerText = pointArray[i].X.ToString();
                    PointsElement.AppendChild(PointElement);


                    XmlElement XElement = dom.CreateElement("X");
                    XElement.InnerText = pointArray[i].X.ToString();
                    PointElement.AppendChild(XElement);

                    XmlElement YElement = dom.CreateElement("Y");
                    YElement.InnerText = pointArray[i].Y.ToString();
                    PointElement.AppendChild(YElement);

                }
                _ponits = dom.InnerXml;
                return _ponits;
            }
            set
            {
                _ponits = value;
                if (_ponits != "")
                {
                    XmlDocument doc = new XmlDocument();

                    doc.LoadXml(_ponits);
                    XmlNode myNode = doc.DocumentElement;
                     XmlNode PointsNodes = doc.SelectSingleNode("Points");
                     if (PointsNodes != null)
                     {
                         XmlNodeList xnList = PointsNodes.SelectNodes("Point");
                         foreach (XmlNode pointnode in xnList)
                         {
                             //XmlNode expressionnode = expressionsnodes.SelectSingleNode("Expression");
                             Point pt = new Point();
                             pt.X = int.Parse(pointnode["X"].InnerText);
                             pt.Y = int.Parse(pointnode["Y"].InnerText);
                             pointArray.Add(pt);
                         }
                     }
                }
                 
            }
        }

        


		/// <summary>
		/// Clone this instance
		/// </summary>
		public override DrawObject Clone()
		{
            DrawPolyLine drawPolyLine = new DrawPolyLine(Parentpagelist);
			//drawPolyLine.pointArray = pointArray;
			//FillDrawObjectFields(drawPolyLine);
			return drawPolyLine;
		}

        

        public DrawPolyLine(PageList _parent)
            : base(_parent)
		{
            Resizeable = true;
			//pointArray = new ArrayList();
            ShapeType = STATIC_OBJ_TYPE.ID_POLYLINE;
            shapeoutline.LineStyle = Common.LastLineStyle;
            Propertylist.Add("BorderWidth,Line Width,DINT");
            Propertylist.Add("BorderColor,Line Color,Color");
            Propertylist.Add("BorderBlinking,Line Blinking,BOOL");
			//LoadCursor();
			Initialize();
		}

        public DrawPolyLine(PageList _parent, int x1, int y1, int x2, int y2)
            : base(_parent)
        {
            Resizeable = true;
            //pointArray = new ArrayList();
            pointArray.Add(new Point(x1, y1));
            pointArray.Add(new Point(x2, y2));
            ShapeType = STATIC_OBJ_TYPE.ID_POLYLINE;
            //shapefill.FillColor = Common.LastFillColor;
            shapeoutline.LineStyle = Common.LastLineStyle;
            Propertylist.Add("BorderWidth,Line Width,DINT");
            Propertylist.Add("BorderColor,Line Color,Color");
            Propertylist.Add("BorderBlinking,Line Blinking,BOOL");
            //LoadCursor();
            Initialize();
        }

        //public DrawPolyLine(PageList _parent,int x1, int y1, int x2, int y2, DrawingPens.PenType p)
        //    : base(_parent)
        //{
        //    Resizeable = true;
        //    //pointArray = new ArrayList();
        //    pointArray.Add(new Point(x1, y1));
        //    pointArray.Add(new Point(x2, y2));
        //    //DrawPen = DrawingPens.SetCurrentPen(p);
        //    //PenType = p;
        //    ShapeType = STATIC_OBJ_TYPE.ID_POLYLINE;
        //    Propertylist.Add("BoarderWidth,DINT");
        //    Propertylist.Add("BoarderColor,Color");
        //    Propertylist.Add("BoarderBlinking,BOOL");
        //    LoadCursor();
        //    Initialize();
        //}

        //public DrawPolyLine(PageList _parent,int x1, int y1, int x2, int y2, Color lineColor, int lineWidth)
        //    : base(_parent)
        //{
        //    Resizeable = true;
        //    //pointArray = new ArrayList();
        //    pointArray.Add(new Point(x1, y1));
        //    pointArray.Add(new Point(x2, y2));
        //    shapeoutline.BoarderColor1 = lineColor;
        //    shapeoutline.BoarderWidth = lineWidth;
        //    ShapeType = STATIC_OBJ_TYPE.ID_POLYLINE;
        //    Propertylist.Add("BoarderWidth,DINT");
        //    Propertylist.Add("BoarderColor,Color");
        //    Propertylist.Add("BoarderBlinking,BOOL");
        //    LoadCursor();
        //    Initialize();
        //}

        
        public override Rectangle GetConnectionEllipse(int connectionNumber)
        {
            Point p = GetConnection(connectionNumber);
            // Take into account width of pen
            return new Rectangle(p.X - (shapeoutline.BoarderWidth + 3), p.Y - (shapeoutline.BoarderWidth + 3), 7 + shapeoutline.BoarderWidth, 7 + shapeoutline.BoarderWidth);
        }

        
        //public void init(tblPolyline sqltable)
        public override bool Load(object obj)
        {
            bool ret = true;
            Dirty = false;
            sqltable = (tblPolyline)obj;
            SQLID = sqltable.ID;
            oIndex = sqltable.oIndex;
            Layer = (LAYERS)sqltable.Layer;
            NewObject = false;
            
            shapeoutline.LineStyle = sqltable.LineStyle;
            ShapeType = STATIC_OBJ_TYPE.ID_POLYLINE;
#if EWSAPP
            drawexpressionCollection.DisplayObjectParametersstr = sqltable.Argument;
            drawexpressionCollection.DisplayObjectDynamicPropertysstr = sqltable.Expression;
            drawexpressionCollection.DisplayObjectEventHandlersstr = sqltable.Action;
#endif
            Points = sqltable.Points;
            LineType = sqltable.LineType;
#if OWSAPP
            if (sqltable.validexpression)
            {
                loadDrawExpressionCollection(sqltable.CompiledExp);
                UpdateHasExpression();
            } 
#endif

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
                //sqltable.FillColor = shapefill.FillColor;
                sqltable.LineStyle = shapeoutline.LineStyle;

                sqltable.LineType = LineType;
                sqltable.Argument = drawexpressionCollection.DisplayObjectParametersstr;
                sqltable.Expression = drawexpressionCollection.DisplayObjectDynamicPropertysstr;
                sqltable.Action = drawexpressionCollection.DisplayObjectEventHandlersstr;
                sqltable.Points = Points;

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
                     //gp.AddLine(startPoint, endPoint);
                     for (int i = 0; i < pointArray.Count - 1; i++)
                     {
                         gp.AddLine(pointArray[i], pointArray[i + 1]);
                     }
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


		public void AddPoint(Point point)
		{
			pointArray.Add(point);
		}

		public override int HandleCount
		{
			get { return pointArray.Count; }
		}

		/// <summary>
		/// Get handle point by 1-based number
		/// </summary>
		/// <param name="handleNumber"></param>
		/// <returns></returns>
		public override Point GetHandle(int handleNumber)
		{
			if (handleNumber < 1)
				handleNumber = 1;
			if (handleNumber > pointArray.Count)
				handleNumber = pointArray.Count;
			return ((Point)pointArray[handleNumber - 1]);
		}

		public override Cursor GetHandleCursor(int handleNumber)
		{
			return handleCursor;
		}

		public override void MoveHandleTo(Point point, int handleNumber)
		{
            try
            {
                if (handleNumber < 1)
                    handleNumber = 1;

                if (handleNumber > pointArray.Count)
                    handleNumber = pointArray.Count;
                pointArray[handleNumber - 1] = point;
                Invalidate();
                Dirty = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
			
		}

		public override void Move(int deltaX, int deltaY)
		{
			int n = pointArray.Count;

			for (int i = 0; i < n; i++)
			{
				Point point;
				point = new Point(((Point)pointArray[i]).X + deltaX, ((Point)pointArray[i]).Y + deltaY);
				pointArray[i] = point;
			}
            Dirty = true;
			Invalidate();
		}

		
		/// <summary>
		/// Create graphic object used for hit test
		/// </summary>
        protected override void CreateObjects()
		{
			if (AreaPath != null)
				return;

			// Create closed path which contains all polygon vertexes
			AreaPath = new GraphicsPath();
            // Take into account the width of the pen used to draw the actual object
            AreaPen = new Pen(Color.Black, shapeoutline.BoarderWidth < 7 ? 7 : shapeoutline.BoarderWidth);
            // Prevent Out of Memory crash when startPoint == endPoint
			int x1 = 0, y1 = 0; // previous point

			IEnumerator enumerator = pointArray.GetEnumerator();

			if (enumerator.MoveNext())
			{
				x1 = ((Point)enumerator.Current).X;
				y1 = ((Point)enumerator.Current).Y;
			}

			while (enumerator.MoveNext())
			{
				int x2, y2; // current point
				x2 = ((Point)enumerator.Current).X;
				y2 = ((Point)enumerator.Current).Y;

				AreaPath.AddLine(x1, y1, x2, y2);

				x1 = x2;
				y1 = y2;
			}

			//AreaPath.CloseFigure();

			// Create region from the path
			AreaRegion = new Region(AreaPath);
		}

        //private void LoadCursor()
        //{

        //    try
        //    {

        //        handleCursor = new Cursor(Application.StartupPath + "\\Polyline.cur");
        //        //m_Cursor = new Cursor(GetType(), "Rectangle.cur");
        //    }
        //    catch (NullReferenceException e)
        //    {
        //        MessageBox.Show(e.Message.ToString());
        //    }
        //}

        

        protected DrawPolyLine(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            if (info == null)
                throw new ArgumentNullException("info");
            try
            {
                this.ShapeType = STATIC_OBJ_TYPE.ID_POLYGON;
                Points = info.GetString("Points");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        protected override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info,context);
            info.AddValue("Points", Points);
            
        }
	}
}