using DCS.DCSTables;
using DCS.TabPages;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Windows.Forms;

namespace DCS.Draw
{
	/// <summary>
	/// Ellipse graphic object
	/// </summary>
	[Serializable]
	public class DrawEllipse : DrawRectangle
	{
        public DrawEllipse(PageList _parent)
            : base(_parent)
		{
            Resizeable = true;
			SetRectangle(0, 0, 1, 1);
			Initialize();
		}

		/// <summary>
		/// Clone this instance
		/// </summary>
		public override DrawObject Clone()
		{
            DrawEllipse drawEllipse = new DrawEllipse(Parentpagelist);
			drawEllipse.rectangle = rectangle;

			FillDrawObjectFields(drawEllipse);
			return drawEllipse;
		}

        
        public DrawEllipse(PageList _parent, int x, int y, int width, int height)
            : base(_parent)
        {
            Resizeable = true;
            rectangle = new Rectangle(x, y, width, height);
            Center = new Point(x + (width / 2), y + (height / 2));
            TipText = String.Format("Ellipse Center @ {0}, {1}", Center.X, Center.Y);
            ShapeType = STATIC_OBJ_TYPE.ID_ELLIPS;
            Initialize();
        }

        public DrawEllipse(PageList _parent, int x, int y, int width, int height, Color lineColor, Color fillColor, bool filled)
            : base(_parent)
        {
            Resizeable = true;
            rectangle = new Rectangle(x, y, width, height);
            Center = new Point(x + (width / 2), y + (height / 2));
            TipText = String.Format("Ellipse Center @ {0}, {1}", Center.X, Center.Y);
            shapeoutline.BoarderColor1 = lineColor;
            //FillColor = fillColor;
            //Filled = filled;
            ShapeType = STATIC_OBJ_TYPE.ID_ELLIPS;
            Initialize();
        }

        public DrawEllipse(PageList _parent, int x, int y, int width, int height, DrawingPens.PenType pType, Color fillColor, bool filled)
            : base(_parent)
        {
            Resizeable = true;
            rectangle = new Rectangle(x, y, width, height);
            Center = new Point(x + (width / 2), y + (height / 2));
            TipText = String.Format("Ellipse Center @ {0}, {1}", Center.X, Center.Y);
            //DrawPen = DrawingPens.SetCurrentPen(pType);
            //PenType = pType;
            //FillColor = fillColor;
            //Filled = filled;
            ShapeType = STATIC_OBJ_TYPE.ID_ELLIPS;
            Initialize();
        }

        public DrawEllipse(PageList _parent, int x, int y, int width, int height, Color lineColor, Color fillColor, bool filled, int lineWidth)
            : base(_parent)
        {
            Resizeable = true;
            rectangle = new Rectangle(x, y, width, height);
            Center = new Point(x + (width / 2), y + (height / 2));
            TipText = String.Format("Ellipse Center @ {0}, {1}", Center.X, Center.Y);
            shapeoutline.BoarderColor1 = lineColor;
            //FillColor = fillColor;
            //Filled = filled;
            shapeoutline.BoarderWidth = lineWidth;
            ShapeType = STATIC_OBJ_TYPE.ID_ELLIPS;
            Initialize();
        }

        public override Rectangle GetConnectionEllipse(int connectionNumber)
        {
            Point p = GetConnection(connectionNumber);
            // Take into account width of pen
            return new Rectangle(p.X - (shapeoutline.BoarderWidth + 3), p.Y - (shapeoutline.BoarderWidth + 3), 7 + shapeoutline.BoarderWidth, 7 + shapeoutline.BoarderWidth);
        }

        public override void Draw(Graphics g)
        {

            Color bcolor = Color.White;
            Color fColor1 = Color.White;
            Color fColor2 = Color.White;

            try
            {
                //Pen pen;

                if (Common.Blinking && shapeoutline.BoarderBlinking)
                {
                    bcolor = shapeoutline.BoarderColor2;
                }
                else
                {
                    bcolor = shapeoutline.BoarderColor1;
                }
                Pen pen = new Pen(bcolor, shapeoutline.BoarderWidth);
                //pen = new Pen(bcolor, BoarderWidth);
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



                gp.AddEllipse(rectangle);


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
                        x1 = rectangle.X;
                        y1 = rectangle.Y;
                        x2 = rectangle.Right;
                        y2 = rectangle.Bottom;
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
            catch (Exception e)
            {
                // MessageBox.Show(e.Message);
                Trace.WriteLine(e.Message);
            }
            //Trace.WriteLine("Draw rectangle.Left=" + rectangle.Left.ToString() + " rectangle.Top=" + rectangle.Top.ToString() + " rectangle.Width=" + rectangle.Width.ToString() + " rectangle.Height=" + rectangle.Height.ToString());


        }
        
        //public override void Draw(Graphics g)
        //{

        //    try
        //    {

        //        Color bcolor = Color.White;
        //        Color fColor1 = Color.White;
        //        Color fColor2 = Color.White;

        //        SelecactiveColor( ref  bcolor, ref fColor1, ref fColor2,shapefill,shapeoutline);

        //        Pen pen = MakePen(bcolor,shapeoutline);

        //        GraphicsPath gp = new GraphicsPath();


        //        switch (shapefill.FillType)
        //        {
        //            case FillTypePatern.Transparent:

        //                gp.AddEllipse(rectangle);

        //                if (shapeoutline.BoarderWidth != 0)
        //                {
        //                    g.DrawPath(pen, gp);
        //                }
        //                pen.Dispose();
        //                gp.Dispose();
        //                break;
        //            case FillTypePatern.Solid:

        //                Brush b;
        //                b = new SolidBrush(fColor1);

        //                gp.AddEllipse(rectangle);


        //                if (shapeoutline.BoarderWidth != 0)
        //                {
        //                    g.DrawPath(pen, gp);
        //                }
        //                g.FillPath(b, gp);
        //                gp.Dispose();
        //                pen.Dispose();
        //                b.Dispose();
        //                break;
        //            case FillTypePatern.Hatched:

        //                using (HatchBrush hatchbrush = new HatchBrush(shapefill.hatchStyle, fColor1, Color.Transparent))
        //                {

        //                    gp.AddEllipse(rectangle);

        //                    if (shapeoutline.BoarderWidth != 0)
        //                    {
        //                        g.DrawPath(pen, gp);
        //                    }

        //                    //g.FillPath(hatchbrush, gp);
        //                    g.FillPath(hatchbrush, gp);
        //                }
        //                gp.Dispose();
        //                pen.Dispose();
        //                //hatchbrush.Dispose();


        //                break;
        //            case FillTypePatern.Gradient:
        //                LinearGradientBrush linearBrush;

        //                linearBrush = new LinearGradientBrush(rectangle, fColor1, fColor2, linearGradientBrush);


        //                gp.AddEllipse(rectangle);

        //                if (BoarderWidth != 0)
        //                {
        //                    g.DrawPath(pen, gp);
        //                }
        //                g.FillPath(linearBrush, gp);
        //                gp.Dispose();
        //                pen.Dispose();
        //                linearBrush.Dispose();

        //                break;
        //        }

        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show(e.Message);
        //    }
        //}
        
        
        

        protected DrawEllipse(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            if (info == null)
                throw new ArgumentNullException("info");
           // oIndex = _parent.GetNewobjectoIndex();
            
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        protected override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info,context);
            
            
        }
	}
}