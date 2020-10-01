using DCS.DCSTables;
using DCS.Project_Objects;
using DCS.TabPages;
using DCS.TypeConverters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
    public class DrawPolygon : DrawGraphic
	{
        protected tblPolygon sqltable = new tblPolygon();
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

        ShapeFill _shapefill ;

        [Editor(typeof(ShapeFillTypeEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(ShapeFillTypeConverter))]  //[TypeConverter(typeof(ExpandableObjectConverter))]
        [Category("Advance")]
        public ShapeFill shapefill
        {
            get
            {
                return _shapefill;
            }
            set
            {
                _shapefill = value;
            }
        }

        ShapeOutline _shapeoutline ;
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
        

		/// <summary>
		/// Clone this instance
		/// </summary>
		public override DrawObject Clone()
		{
            DrawPolygon drawpolygon = new DrawPolygon(Parentpagelist);
			//drawPolyLine.pointArray = pointArray;
			//FillDrawObjectFields(drawPolyLine);
            return drawpolygon;
		}

        public DrawPolygon(PageList _parent)
            : base(_parent)
		{
            _shapeoutline = new ShapeOutline(this);
            _shapefill = new ShapeFill(this);
            Resizeable = true;
			//pointArray = new ArrayList();
            ShapeType = STATIC_OBJ_TYPE.ID_POLYGON;
            shapefill.FillColor = Common.LastFillColor;
            shapeoutline.LineStyle = Common.LastLineStyle;
            Propertylist.Add("BorderWidth,Border Width,DINT");
            Propertylist.Add("BorderColor,Border Color,Color");
            Propertylist.Add("BorderBlinking,Border Blinking,BOOL");
			//LoadCursor();
			Initialize();
		}

        public DrawPolygon(PageList _parent, int x1, int y1, int x2, int y2)
            : base(_parent)
        {
            _shapeoutline = new ShapeOutline(this);
            _shapefill = new ShapeFill(this);
            Resizeable = true;
            //pointArray = new ArrayList();
            pointArray.Add(new Point(x1, y1));
            pointArray.Add(new Point(x2, y2));
            ShapeType = STATIC_OBJ_TYPE.ID_POLYGON;
            shapefill.FillColor = Common.LastFillColor;
            shapeoutline.LineStyle = Common.LastLineStyle;
            Propertylist.Add("BorderWidth,Border Width,DINT");
            Propertylist.Add("BorderColor,Border Color,Color");
            Propertylist.Add("BorderBlinking,Border Blinking,BOOL");
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

        public void Replacesecondpoint(Point pt)
        {
            pointArray.RemoveAt(1);
            pointArray.Add(pt);
            
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
                        this.shapefill.HasFillColor11Expression = true;
                        break;
                    case enumDynamicGraphicalProperty.Color2:
                        this.shapefill.HasFillColor21Expression = true;
                        break;
                    case enumDynamicGraphicalProperty.TextColor:

                        break;
                    case enumDynamicGraphicalProperty.BorderBlinking:
                        this.shapeoutline.HasBoarderBlinkingExpression = true;
                        break;
                    case enumDynamicGraphicalProperty.Blinking:
                        this.shapefill.HasBlinkingExpression = true;
                        break;
                    case enumDynamicGraphicalProperty.TextBlinking:

                        break;
                    case enumDynamicGraphicalProperty.Text:

                        break;
                }
            }


        }

        //public void init(tblPolyline sqltable)
        public override bool Load(object obj)
        {
            bool ret = true;
            Dirty = false;
            sqltable = (tblPolygon)obj;
            SQLID = sqltable.ID;
            oIndex = sqltable.oIndex;
            Layer = (LAYERS)sqltable.Layer;
            NewObject = false;
            
            shapeoutline.LineStyle = sqltable.LineStyle;
            ShapeType = STATIC_OBJ_TYPE.ID_POLYGON;
            shapefill.FillColor = sqltable.FillColor;
            shapeoutline.LineStyle = sqltable.LineStyle;
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
            Points = sqltable.Points;
            LineType = sqltable.LineType;

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
                sqltable.FillColor = shapefill.FillColor;
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

        /*
        public override void Draw(Graphics g)
        {

            try
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                Color bcolor = Color.White;
                Color fColor1 = Color.White;
                Color fColor2 = Color.White;

                SelecactiveColor(ref  bcolor, ref fColor1, ref fColor2,shapefill,shapeoutline);

                Pen pen = MakePen(bcolor,shapeoutline);


                GraphicsPath gp = new GraphicsPath();

                ///////////////////////////
                switch (shapefill.FillType)
                {
                    case FillTypePatern.Transparent:

                        for (int i = 0; i < pointArray.Count - 1; i++)
                        {
                            gp.AddLine(((Point)pointArray[i]), ((Point)pointArray[i + 1]));
                        }
                        if (ShapeType == STATIC_OBJ_TYPE.ID_POLYGON)
                        {
                            gp.CloseFigure();
                        }
                        g.DrawPath(pen, gp);
                        pen.Dispose();
                        gp.Dispose();
                        break;
                    case FillTypePatern.Solid:

                        Brush b;
                        b = new SolidBrush(fColor1);

                        for (int i = 0; i < pointArray.Count - 1; i++)
                        {
                            gp.AddLine(((Point)pointArray[i]), ((Point)pointArray[i + 1]));
                        }
                        if (ShapeType == STATIC_OBJ_TYPE.ID_POLYGON)
                        {
                            gp.CloseFigure();
                        }

                        g.DrawPath(pen, gp);
                        g.FillPath(b, gp);
                        gp.Dispose();
                        pen.Dispose();
                        b.Dispose();
                        break;
                    case FillTypePatern.Hatched:

                        HatchBrush hatchbrush = new HatchBrush(shapefill.hatchStyle, fColor1, Color.Transparent);

                        for (int i = 0; i < pointArray.Count - 1; i++)
                        {
                            gp.AddLine(((Point)pointArray[i]), ((Point)pointArray[i + 1]));
                        }
                        if (ShapeType == STATIC_OBJ_TYPE.ID_POLYGON)
                        {
                            gp.CloseFigure();
                        }

                        g.DrawPath(pen, gp);
                        g.FillPath(hatchbrush, gp);
                        g.FillPath(hatchbrush, gp);
                        gp.Dispose();
                        pen.Dispose();
                        hatchbrush.Dispose();


                        break;
                    case FillTypePatern.Gradient:
                        LinearGradientBrush linearBrush;

                        //linearBrush = new LinearGradientBrush(rectangle, fColor1, fColor2, linearGradientBrush);
                        linearBrush = new LinearGradientBrush(rectangle, fColor1, fColor2,LinearGradientMode.ForwardDiagonal);

                        for (int i = 0; i < pointArray.Count - 1; i++)
                        {
                            gp.AddLine(((Point)pointArray[i]), ((Point)pointArray[i + 1]));
                        }
                        if (ShapeType == STATIC_OBJ_TYPE.ID_POLYGON)
                        {
                            gp.CloseFigure();
                        }

                        g.DrawPath(pen, gp);
                        g.FillPath(linearBrush, gp);
                        gp.Dispose();
                        pen.Dispose();
                        linearBrush.Dispose();

                        break;
                    default:
                        break;
                }
                ///////////////////////////

                //for (int i = 0; i < pointArray.Count - 1; i++)
                //{
                //    gp.AddLine(((Point)pointArray[i]), ((Point)pointArray[i + 1]));
                //}
                //g.DrawPath(pen, gp);
                //gp.Dispose();
                //pen.Dispose();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        */

         public override void Draw(Graphics g)
         {
             
                 Color bcolor = Color.White;
                 Color fColor1 = Color.White;
                 Color fColor2 = Color.White;

                 try
                 {
                     if (this.Visible)
                     {
                         if (Common.Blinking && shapeoutline.BoarderBlinking)
                         {
                             bcolor = shapeoutline.BoarderColor2;
                         }
                         else
                         {
                             bcolor = shapeoutline.BoarderColor1;
                         }
                         Pen pen = new Pen(bcolor, shapeoutline.BoarderWidth);
                         pen.DashStyle = shapeoutline.BoarderDashStyle;
                         GraphicsPath gp = new GraphicsPath();

                         switch (shapefill.FillType)
                         {
                             case FillTypePatern.Transparent:
                                 break;
                             case FillTypePatern.Solid:


                                 if (Common.Blinking && shapefill.Blinking)
                                 {
                                     fColor1 = shapefill.FillColor12;
                                 }
                                 else
                                 {
                                     fColor1 = shapefill.FillColor11;
                                 }
                                 break;
                             case FillTypePatern.Hatched:
                                 if (Common.Blinking && shapefill.Blinking)
                                 {
                                     fColor1 = Color.Transparent;

                                 }
                                 else
                                 {
                                     fColor1 = shapefill.FillColor11;
                                 }

                                 break;
                             case FillTypePatern.Gradient:
                                 if (Common.Blinking && shapefill.Blinking)
                                 {
                                     fColor1 = Color.Transparent;
                                     fColor2 = Color.Transparent;
                                 }
                                 else
                                 {
                                     fColor1 = shapefill.FillColor11;
                                     fColor2 = shapefill.FillColor21;
                                 }

                                 break;
                         }
                         gp.AddPolygon(pointArray.ToArray());
                         //if ((RoundnessX == 0) && (RoundnessY == 0))
                         //{
                         //    gp.AddRectangle(rectangle);
                         //}
                         //else
                         //{
                         //    if (RoundnessX == 0)
                         //    {
                         //        RoundnessX = 1;
                         //    }
                         //    if (RoundnessY == 0)
                         //    {
                         //        RoundnessY = 1;
                         //    }

                         //    if (2 * RoundnessY > rectangle.Height)
                         //        RoundnessY = rectangle.Height / 2;
                         //    if (2 * RoundnessX > rectangle.Width)
                         //        RoundnessX = rectangle.Width / 2;
                         //    gp.AddLine(rectangle.Left + RoundnessX, rectangle.Top, rectangle.Left + rectangle.Width - (RoundnessX), rectangle.Top); // Line
                         //    gp.AddArc(rectangle.Left + rectangle.Width - (RoundnessX * 2), rectangle.Top, RoundnessX * 2, RoundnessY * 2, 270, 90); // Corner
                         //    gp.AddLine(rectangle.Left + rectangle.Width, rectangle.Top + RoundnessY, rectangle.Left + rectangle.Width, rectangle.Top + rectangle.Height - (RoundnessY)); // Line
                         //    gp.AddArc(rectangle.Left + rectangle.Width - (RoundnessX * 2), rectangle.Top + rectangle.Height - (RoundnessY * 2), RoundnessX * 2, RoundnessY * 2, 0, 90); // Corner
                         //    gp.AddLine(rectangle.Left + rectangle.Width - (RoundnessX), rectangle.Top + rectangle.Height, rectangle.Left + RoundnessX, rectangle.Top + rectangle.Height); // Line
                         //    gp.AddArc(rectangle.Left, rectangle.Top + rectangle.Height - (RoundnessY * 2), RoundnessX * 2, RoundnessY * 2, 90, 90); // Corner
                         //    gp.AddLine(rectangle.Left, rectangle.Top + rectangle.Height - (RoundnessY), rectangle.Left, rectangle.Top + RoundnessY); // Line
                         //    gp.AddArc(rectangle.Left, rectangle.Top, RoundnessX * 2, RoundnessY * 2, 180, 90); // Corner    
                         //}

                         switch (shapefill.FillType)
                         {
                             case FillTypePatern.Transparent:

                                 if (shapeoutline.BoarderWidth != 0)
                                 {
                                     g.DrawPath(pen, gp);
                                 }
                                 pen.Dispose();
                                 gp.Dispose();
                                 break;
                             case FillTypePatern.Solid:

                                 Brush b = new SolidBrush(fColor1);

                                 g.FillPath(b, gp);
                                 if (shapeoutline.BoarderWidth != 0)
                                 {
                                     g.DrawPath(pen, gp);
                                 }

                                 gp.Dispose();
                                 pen.Dispose();
                                 b.Dispose();
                                 break;
                             case FillTypePatern.Hatched:

                                 using (HatchBrush hatchbrush = new HatchBrush(shapefill.hatchStyle, fColor1, Color.Transparent))
                                 {

                                     if (shapeoutline.BoarderWidth != 0)
                                     {
                                         g.DrawPath(pen, gp);
                                     }

                                     g.FillPath(hatchbrush, gp);
                                 }
                                 gp.Dispose();
                                 pen.Dispose();
                                 //hatchbrush.Dispose();


                                 break;
                             case FillTypePatern.Gradient:
                                 int x1, x2, y1, y2;
                                 x1 = 1000000;
                                 y1 = 1000000;
                                 x2 = 0;
                                 y2 = 0;
                                 getSurroundingRect(ref x1, ref y1, ref x2, ref y2);
                                 //x1 = rectangle.X;
                                 //y1 = rectangle.Y;
                                 //x2 = rectangle.Right;
                                 //y2 = rectangle.Bottom;
                                 Point pt1 = new Point();
                                 Point pt2 = new Point();
                                 switch (shapefill.Fillgradienttype)
                                 {
                                     case FillGradientType.Buttom2Top:
                                         pt1 = new Point(x1, y2);
                                         pt2 = new Point(x1, y1);
                                         break;
                                     case FillGradientType.Left2Right:
                                         pt1 = new Point(x1, y1);
                                         pt2 = new Point(x2, y1);
                                         break;
                                     case FillGradientType.Top2Buttom:
                                         pt1 = new Point(x1, y1);
                                         pt2 = new Point(x1, y2);
                                         break;
                                     case FillGradientType.Right2Left:
                                         pt1 = new Point(x2, y1);
                                         pt2 = new Point(x1, y1);
                                         break;
                                     case FillGradientType.NE2SW:
                                         pt1 = new Point(x2, y1);
                                         pt2 = new Point(x1, y2);
                                         break;
                                     case FillGradientType.NW2SE:
                                         pt1 = new Point(x1, y1);
                                         pt2 = new Point(x2, y2);
                                         break;
                                     case FillGradientType.SE2NW:
                                         pt1 = new Point(x2, y2);
                                         pt2 = new Point(x1, y1);
                                         break;
                                     case FillGradientType.SW2NE:
                                         pt1 = new Point(x1, y2);
                                         pt2 = new Point(x2, y1);
                                         break;
                                     case FillGradientType.FromHCenter:
                                         pt1 = new Point(x1, y1);
                                         pt2 = new Point(x1, y2);
                                         break;
                                     case FillGradientType.FromVCenter:
                                         pt1 = new Point(x1, y1);
                                         pt2 = new Point(x2, y1);
                                         break;
                                     case FillGradientType.ToHCenter:
                                         pt1 = new Point(x1, y1);
                                         pt2 = new Point(x1, y2);
                                         break;
                                     case FillGradientType.ToVCenter:
                                         pt1 = new Point(x1, y1);
                                         pt2 = new Point(x2, y1);
                                         break;
                                 }

                                 switch (shapefill.Fillgradienttype)
                                 {
                                     case FillGradientType.Buttom2Top:
                                     case FillGradientType.Left2Right:
                                     case FillGradientType.Top2Buttom:
                                     case FillGradientType.Right2Left:
                                     case FillGradientType.NE2SW:
                                     case FillGradientType.NW2SE:
                                     case FillGradientType.SE2NW:
                                     case FillGradientType.SW2NE:
                                         using (LinearGradientBrush br = new LinearGradientBrush(pt1, pt2, fColor1, fColor2))
                                         {
                                             g.FillPath(br, gp);
                                             if (shapeoutline.BoarderWidth != 0)
                                             {
                                                 g.DrawPath(pen, gp);
                                             }
                                         }
                                         break;
                                     case FillGradientType.FromHCenter:
                                     case FillGradientType.FromVCenter:
                                         using (LinearGradientBrush br = new LinearGradientBrush(pt1, pt2, fColor1, fColor2))
                                         {
                                             ColorBlend cb = new ColorBlend();
                                             cb.Colors = new Color[] { fColor2, fColor1, fColor2 };
                                             cb.Positions = new float[] { 0, 0.5F, 1 };
                                             br.InterpolationColors = cb;
                                             g.FillPath(br, gp);
                                             if (shapeoutline.BoarderWidth != 0)
                                             {
                                                 g.DrawPath(pen, gp);
                                             }
                                         }
                                         break;
                                     case FillGradientType.ToHCenter:
                                     case FillGradientType.ToVCenter:
                                         using (LinearGradientBrush br = new LinearGradientBrush(pt1, pt2, fColor1, fColor2))
                                         {
                                             ColorBlend cb = new ColorBlend();
                                             cb.Colors = new Color[] { fColor1, fColor2, fColor1 };
                                             cb.Positions = new float[] { 0, 0.5F, 1 };
                                             br.InterpolationColors = cb;
                                             g.FillPath(br, gp);
                                             if (shapeoutline.BoarderWidth != 0)
                                             {
                                                 g.DrawPath(pen, gp);
                                             }
                                         }
                                         break;
                                 }

                                 gp.Dispose();
                                 pen.Dispose();
                                 break;
                         }
                     }
                 }
                 catch (Exception e)
                 {
                     MessageBox.Show(e.Message);

                 }
             
             //Trace.WriteLine("Draw rectangle.Left=" + rectangle.Left.ToString() + " rectangle.Top=" + rectangle.Top.ToString() + " rectangle.Width=" + rectangle.Width.ToString() + " rectangle.Height=" + rectangle.Height.ToString());


         }


         void getSurroundingRect(ref int x1, ref int y1, ref int x2, ref int y2)
         {

             for (int i = 0; i < pointArray.Count; i++)
             {
                 if (x1 > pointArray[i].X)
                 {
                     x1 = pointArray[i].X;
                 }
                 if (y1 > pointArray[i].Y)
                 {
                     y1 = pointArray[i].Y;
                 }
                 if (x2 < pointArray[i].X)
                 {
                     x2 = pointArray[i].X;
                 }
                 if (y2 < pointArray[i].Y)
                 {
                     y2 = pointArray[i].Y;
                 }
             }
         }

         //public override void Draw(Graphics g)
         //{

         //    try
         //    {
         //        g.SmoothingMode = SmoothingMode.AntiAlias;
         //        Color bcolor = Color.White;
         //        SelecactiveColor(ref bcolor, shapeoutline);
         //        Pen pen = MakePen(bcolor, shapeoutline);



         //        GraphicsPath gp = new GraphicsPath();
         //        //gp.AddLine(startPoint, endPoint);
         //        for (int i = 0; i < pointArray.Count - 1; i++)
         //        {
         //            gp.AddLine(pointArray[i], pointArray[i + 1]);
         //        }
         //        //Trace.WriteLine("Draw startPointX=" + startPoint.X.ToString() + " startPointY="+ startPoint.Y.ToString() + " endPoint=" + endPoint.X.ToString() + " endPoint="+ endPoint.Y.ToString());
         //        g.DrawPath(pen, gp);
         //        gp.Dispose();
         //        pen.Dispose();
         //    }
         //    catch (Exception e)
         //    {
         //        MessageBox.Show(e.Message);
         //    }
         //}


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
            
            //AreaPath.Dispose();

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

			AreaPath.CloseFigure();

			// Create region from the path
			AreaRegion = new Region(AreaPath);
		}

        //private void LoadCursor()
        //{

        //    try
        //    {

        //        handleCursor = new Cursor(Application.StartupPath + "\\Polygon.cur");
        //        //m_Cursor = new Cursor(GetType(), "Rectangle.cur");
        //    }
        //    catch (NullReferenceException e)
        //    {
        //        MessageBox.Show(e.Message.ToString());
        //    }
        //}

        

        protected DrawPolygon(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            if (info == null)
                throw new ArgumentNullException("info");
            try
            {
                _shapeoutline = new ShapeOutline(this);
                _shapefill = new ShapeFill(this);
                this.ShapeType = STATIC_OBJ_TYPE.ID_POLYLINE;
                Points = info.GetString("Points");
                _shapefill.FillColor = info.GetString("ShapeFill");
                _shapeoutline.LineStyle = info.GetString("shapeoutline");
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
            info.AddValue("ShapeFill",_shapefill.FillColor);
            info.AddValue("shapeoutline",_shapeoutline.LineStyle);
            
        }
	}
}