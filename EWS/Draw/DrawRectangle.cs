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
    /// _rectangle graphic object
    /// </summary>
    [Serializable]
    public class DrawRectangle : DrawGraphic
    {

        tblRect sqltable = new tblRect();
        private const string entryRectangle = "Rect";

        private int _roundnessx = 0;
        public int RoundnessX
        {
            get
            {
                return _roundnessx;
            }
            set
            {
                _roundnessx = value;
            }
        }

        private int _roundnessy = 0;
        public int RoundnessY
        {
            get
            {
                return _roundnessy;
            }
            set
            {
                _roundnessy = value;
            }
        }

        ShapeFill _shapefill;

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

        //public float[] cuspat;

        /// <summary>
        /// Clone this instance
        /// </summary>
        public override DrawObject Clone()
        {
            DrawRectangle drawRectangle = new DrawRectangle(Parentpagelist);
            drawRectangle.rectangle = rectangle;

            FillDrawObjectFields(drawRectangle);
            return drawRectangle;
        }

        

        public DrawRectangle(PageList _parent)
            : base(_parent)
        {
            _shapeoutline = new ShapeOutline(this);
            _shapefill = new ShapeFill(this);
            Resizeable = true;
            SetRectangle(0, 0, 1, 1);
            ShapeType = STATIC_OBJ_TYPE.ID_RECT;
            shapefill.FillColor = Common.LastFillColor;
            shapeoutline.LineStyle = Common.LastLineStyle;
            Propertylist.Add("BorderWidth,Border Width,DINT");
            Propertylist.Add("BorderColor,Border Color,Color");
            Propertylist.Add("BorderBlinking,Border Blinking,BOOL");
            Propertylist.Add("Color1,Fill Color 1,Color");
            Propertylist.Add("Color2,Fill Color 2,Color");
            Propertylist.Add("Blinking,Blinking,BOOL");
            Propertylist.Add("Visible,Visible,BOOL");
        }

        public DrawRectangle(PageList _parent, int x, int y, int width, int height)
            : base(_parent)
        {
            _shapeoutline = new ShapeOutline(this);
            _shapefill = new ShapeFill(this);
            Resizeable = true;
            Center = new Point(x + (width / 2), y + (height / 2));
            _rectangle.X = x;
            _rectangle.Y = y;
            _rectangle.Width = width;
            _rectangle.Height = height;
            ShapeType = STATIC_OBJ_TYPE.ID_RECT;
            shapefill.FillColor = Common.LastFillColor;
            shapeoutline.LineStyle = Common.LastLineStyle;
            TipText = String.Format("_rectangle Center @ {0}, {1}", Center.X, Center.Y);
            Propertylist.Add("BorderWidth,Border Width,DINT");
            Propertylist.Add("BorderColor,Border Color,Color");
            Propertylist.Add("BorderBlinking,Border Blinking,BOOL");
            Propertylist.Add("Color1,Fill Color 1,Color");
            Propertylist.Add("Color2,Fill Color 2,Color");
            Propertylist.Add("Blinking,Blinking,BOOL");
            Propertylist.Add("Visible,Visible,BOOL");

        

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

        public override bool Load(object obj) 
        {
            bool ret = true;
            Dirty = false;
            sqltable = (tblRect)obj;
            SQLID = sqltable.ID;
            oIndex = sqltable.oIndex;
            Layer = (LAYERS)sqltable.Layer;
            NewObject = false;
            //Rect = new Rectangle(sqltable.Left, sqltable.Top, sqltable.Width, sqltable.Height);
            rectangle = GetNormalizedRectangle(sqltable.Left, sqltable.Top, sqltable.Left + sqltable.Width, sqltable.Top + sqltable.Height);
            shapefill.FillColor = sqltable.FillColor;
            shapeoutline.LineStyle = sqltable.LineStyle;
            
            //drawexpressionCollection.Argumentstr = sqltable.Argument;
            //drawexpressionCollection.Expressionstr = sqltable.Expression;
            //drawexpressionCollection.Actionstr = sqltable.Action;

            ShapeType = (STATIC_OBJ_TYPE)sqltable.Type;

            RoundnessX = sqltable.RoundnessX;
            RoundnessY = sqltable.RoundnessY;
            
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

            return ret;
        }

        public override bool Save(long _id, int _no)
        {
            try
            {
#if EWSAPP
                sqltable.oIndex = _no;
                sqltable.DisplayID = _id;
                sqltable.Layer = (int)Layer ;
                sqltable.Left = _rectangle.Left;
                sqltable.Top = _rectangle.Top;
                sqltable.Height = _rectangle.Height;
                sqltable.Width = _rectangle.Width;

                sqltable.FillColor = shapefill.FillColor;
                sqltable.LineStyle = shapeoutline.LineStyle;


                sqltable.Type = (int)ShapeType;

                sqltable.RoundnessX = RoundnessX;
                sqltable.RoundnessY = RoundnessY;
                sqltable.Argument = drawexpressionCollection.DisplayObjectParametersstr;
                sqltable.Expression = drawexpressionCollection.DisplayObjectDynamicPropertysstr;
                sqltable.Action = drawexpressionCollection.DisplayObjectEventHandlersstr;
                if (drawexpressionCollection.CompileGraphicDispalyExpressions(((TabDisplayPageControl)Parentpagelist.Parenttabgraphicpagecontrol).tbldisplay))
                {
                    sqltable.validexpression = true;
                    sqltable.CompiledExp = drawexpressionCollection.SaveCompiledExpressions();

                }
                else
                {
                    sqltable.validexpression = false;
                }

                CheckExistingExpressions();
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

        public override void CheckExistingExpressions()
        {
            //"BoarderWidth"
            //"BoarderColor"
            //"BoarderBlinking"
            bool ret = false;

            for (int i = 0; i < this.drawexpressionCollection.objDisplayObjectDynamicPropertys.Count; i++)
            {

                switch (this.drawexpressionCollection.objDisplayObjectDynamicPropertys.list[i].ObjectType)
                {
                    case enumDynamicGraphicalProperty.BorderWidth:// "BOARDERWIDTH":
                        shapeoutline.HasBoarderWidthExpression = true;
                        break;
                    case enumDynamicGraphicalProperty.BorderColor://"BOARDERCOLOR":
                        shapeoutline.HasBoarderColor1Expression = true;
                        break;
                    case enumDynamicGraphicalProperty.BorderBlinking://"BOARDERBLINKING":
                        shapeoutline.HasBoarderBlinkingExpression = true;
                        break;
                    case enumDynamicGraphicalProperty.Visible://"VISIBLE":
                        HasVisibleExpression  = true;
                        break;

                }

            }
        }


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

                    if ((RoundnessX == 0) && (RoundnessY == 0))
                    {
                        gp.AddRectangle(rectangle);
                    }
                    else
                    {
                        if (RoundnessX == 0)
                        {
                            RoundnessX = 1;
                        }
                        if (RoundnessY == 0)
                        {
                            RoundnessY = 1;
                        }

                        if (2 * RoundnessY > rectangle.Height)
                            RoundnessY = rectangle.Height / 2;
                        if (2 * RoundnessX > rectangle.Width)
                            RoundnessX = rectangle.Width / 2;
                        gp.AddLine(rectangle.Left + RoundnessX, rectangle.Top, rectangle.Left + rectangle.Width - (RoundnessX), rectangle.Top); // Line
                        gp.AddArc(rectangle.Left + rectangle.Width - (RoundnessX * 2), rectangle.Top, RoundnessX * 2, RoundnessY * 2, 270, 90); // Corner
                        gp.AddLine(rectangle.Left + rectangle.Width, rectangle.Top + RoundnessY, rectangle.Left + rectangle.Width, rectangle.Top + rectangle.Height - (RoundnessY)); // Line
                        gp.AddArc(rectangle.Left + rectangle.Width - (RoundnessX * 2), rectangle.Top + rectangle.Height - (RoundnessY * 2), RoundnessX * 2, RoundnessY * 2, 0, 90); // Corner
                        gp.AddLine(rectangle.Left + rectangle.Width - (RoundnessX), rectangle.Top + rectangle.Height, rectangle.Left + RoundnessX, rectangle.Top + rectangle.Height); // Line
                        gp.AddArc(rectangle.Left, rectangle.Top + rectangle.Height - (RoundnessY * 2), RoundnessX * 2, RoundnessY * 2, 90, 90); // Corner
                        gp.AddLine(rectangle.Left, rectangle.Top + rectangle.Height - (RoundnessY), rectangle.Left, rectangle.Top + RoundnessY); // Line
                        gp.AddArc(rectangle.Left, rectangle.Top, RoundnessX * 2, RoundnessY * 2, 180, 90); // Corner    
                    }

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
            }
            catch (Exception e)
            {
                 MessageBox.Show(e.Message);
            }
            //Trace.WriteLine("Draw rectangle.Left=" + rectangle.Left.ToString() + " rectangle.Top=" + rectangle.Top.ToString() + " rectangle.Width=" + rectangle.Width.ToString() + " rectangle.Height=" + rectangle.Height.ToString());


        }
        

        //public override void Draw(Graphics g)
        //{

        //    Color bcolor = Color.White;
        //    Color fColor1 = Color.White;
        //    Color fColor2 = Color.White;

        //    try
        //    {
        //        //Pen pen;

        //        if (Common.Blinking && shapeoutline.BoarderBlinking)
        //        {
        //            bcolor = shapeoutline.BoarderColor2;
        //        }
        //        else
        //        {
        //            bcolor = shapeoutline.BoarderColor1;
        //        }
        //        Pen pen = MakePen(bcolor, shapeoutline);
        //        //pen = new Pen(bcolor, BoarderWidth);
        //        pen.DashStyle = shapeoutline.BoarderDashStyle;
        //        GraphicsPath gp = new GraphicsPath();

        //        switch (shapefill.FillType)
        //        {
        //            case FillTypePatern.Transparent:
        //                break;
        //            case FillTypePatern.Solid:


        //                if (Common.Blinking && shapefill.Blinking)
        //                {
        //                    fColor1 = shapefill.FillColor12;
        //                }
        //                else
        //                {
        //                    fColor1 = shapefill.FillColor11;
        //                }
        //                break;
        //            case FillTypePatern.Hatched:
        //                if (Common.Blinking && shapefill.Blinking)
        //                {
        //                    fColor1 = Color.Transparent;

        //                }
        //                else
        //                {
        //                    fColor1 = shapefill.FillColor11;
        //                }

        //                break;
        //            case FillTypePatern.Gradient:
        //                if (Common.Blinking && shapefill.Blinking)
        //                {
        //                    fColor1 = shapefill.FillColor12;
        //                    fColor2 = shapefill.FillColor22;
        //                }
        //                else
        //                {
        //                    fColor1 = shapefill.FillColor11;
        //                    fColor2 = shapefill.FillColor21;
        //                }

        //                break;
        //        }

        //        switch (shapefill.FillType)
        //        {
        //            case FillTypePatern.Transparent:
        //                if ((RoundnessX == 0) && (RoundnessY == 0))
        //                {
        //                    gp.AddRectangle(rectangle);
        //                }
        //                else
        //                {
        //                    if (2 * RoundnessY > rectangle.Height)
        //                        RoundnessY = rectangle.Height / 2;
        //                    if (2 * RoundnessX > rectangle.Width)
        //                        RoundnessX = rectangle.Width / 2;
        //                    gp.AddLine(rectangle.Left + RoundnessX, rectangle.Top, rectangle.Left + rectangle.Width - (RoundnessX), rectangle.Top); // Line
        //                    gp.AddArc(rectangle.Left + rectangle.Width - (RoundnessX * 2), rectangle.Top, RoundnessX * 2, RoundnessY * 2, 270, 90); // Corner
        //                    gp.AddLine(rectangle.Left + rectangle.Width, rectangle.Top + RoundnessY, rectangle.Left + rectangle.Width, rectangle.Top + rectangle.Height - (RoundnessY)); // Line
        //                    gp.AddArc(rectangle.Left + rectangle.Width - (RoundnessX * 2), rectangle.Top + rectangle.Height - (RoundnessY * 2), RoundnessX * 2, RoundnessY * 2, 0, 90); // Corner
        //                    gp.AddLine(rectangle.Left + rectangle.Width - (RoundnessX), rectangle.Top + rectangle.Height, rectangle.Left + RoundnessX, rectangle.Top + rectangle.Height); // Line
        //                    gp.AddArc(rectangle.Left, rectangle.Top + rectangle.Height - (RoundnessY * 2), RoundnessX * 2, RoundnessY * 2, 90, 90); // Corner
        //                    gp.AddLine(rectangle.Left, rectangle.Top + rectangle.Height - (RoundnessY), rectangle.Left, rectangle.Top + RoundnessY); // Line
        //                    gp.AddArc(rectangle.Left, rectangle.Top, RoundnessX * 2, RoundnessY * 2, 180, 90); // Corner    
        //                }
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
        //                if ((RoundnessX == 0) && (RoundnessY == 0))
        //                {
        //                    gp.AddRectangle(rectangle);
        //                }
        //                else
        //                {
        //                    if (2 * RoundnessY > rectangle.Height)
        //                        RoundnessY = rectangle.Height / 2;
        //                    if (2 * RoundnessX > rectangle.Width)
        //                        RoundnessX = rectangle.Width / 2;
        //                    gp.AddLine(rectangle.Left + RoundnessX, rectangle.Top, rectangle.Left + rectangle.Width - (RoundnessX), rectangle.Top); // Line
        //                    gp.AddArc(rectangle.Left + rectangle.Width - (RoundnessX * 2), rectangle.Top, RoundnessX * 2, RoundnessY * 2, 270, 90); // Corner
        //                    gp.AddLine(rectangle.Left + rectangle.Width, rectangle.Top + RoundnessY, rectangle.Left + rectangle.Width, rectangle.Top + rectangle.Height - (RoundnessY)); // Line
        //                    gp.AddArc(rectangle.Left + rectangle.Width - (RoundnessX * 2), rectangle.Top + rectangle.Height - (RoundnessY * 2), RoundnessX * 2, RoundnessY * 2, 0, 90); // Corner
        //                    gp.AddLine(rectangle.Left + rectangle.Width - (RoundnessX), rectangle.Top + rectangle.Height, rectangle.Left + RoundnessX, rectangle.Top + rectangle.Height); // Line
        //                    gp.AddArc(rectangle.Left, rectangle.Top + rectangle.Height - (RoundnessY * 2), RoundnessX * 2, RoundnessY * 2, 90, 90); // Corner
        //                    gp.AddLine(rectangle.Left, rectangle.Top + rectangle.Height - (RoundnessY), rectangle.Left, rectangle.Top + RoundnessY); // Line
        //                    gp.AddArc(rectangle.Left, rectangle.Top, RoundnessX * 2, RoundnessY * 2, 180, 90); // Corner    
        //                }
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

        //                HatchBrush hatchbrush = new HatchBrush(shapefill.hatchStyle, fColor1, Color.Transparent);
        //                if ((RoundnessX == 0) && (RoundnessY == 0))
        //                {
        //                    gp.AddRectangle(rectangle);
        //                }
        //                else
        //                {
        //                    if (2 * RoundnessY > rectangle.Height)
        //                        RoundnessY = rectangle.Height / 2;
        //                    if (2 * RoundnessX > rectangle.Width)
        //                        RoundnessX = rectangle.Width / 2;
        //                    gp.AddLine(rectangle.Left + RoundnessX, rectangle.Top, rectangle.Left + rectangle.Width - (RoundnessX), rectangle.Top); // Line
        //                    gp.AddArc(rectangle.Left + rectangle.Width - (RoundnessX * 2), rectangle.Top, RoundnessX * 2, RoundnessY * 2, 270, 90); // Corner
        //                    gp.AddLine(rectangle.Left + rectangle.Width, rectangle.Top + RoundnessY, rectangle.Left + rectangle.Width, rectangle.Top + rectangle.Height - (RoundnessY)); // Line
        //                    gp.AddArc(rectangle.Left + rectangle.Width - (RoundnessX * 2), rectangle.Top + rectangle.Height - (RoundnessY * 2), RoundnessX * 2, RoundnessY * 2, 0, 90); // Corner
        //                    gp.AddLine(rectangle.Left + rectangle.Width - (RoundnessX), rectangle.Top + rectangle.Height, rectangle.Left + RoundnessX, rectangle.Top + rectangle.Height); // Line
        //                    gp.AddArc(rectangle.Left, rectangle.Top + rectangle.Height - (RoundnessY * 2), RoundnessX * 2, RoundnessY * 2, 90, 90); // Corner
        //                    gp.AddLine(rectangle.Left, rectangle.Top + rectangle.Height - (RoundnessY), rectangle.Left, rectangle.Top + RoundnessY); // Line
        //                    gp.AddArc(rectangle.Left, rectangle.Top, RoundnessX * 2, RoundnessY * 2, 180, 90); // Corner    
        //                }
        //                if (shapeoutline.BoarderWidth != 0)
        //                {
        //                    g.DrawPath(pen, gp);
        //                }

        //                g.FillPath(hatchbrush, gp);
        //                gp.Dispose();
        //                pen.Dispose();
        //                hatchbrush.Dispose();


        //                break;
        //            case FillTypePatern.Gradient:
        //                LinearGradientBrush linearBrush;

        //                linearBrush = new LinearGradientBrush(rectangle, fColor1, fColor2, linearGradientBrush);
        //                if ((RoundnessX == 0) && (RoundnessY == 0))
        //                {
        //                    gp.AddRectangle(rectangle);
        //                }
        //                else
        //                {
        //                    if (2 * RoundnessY > rectangle.Height)
        //                        RoundnessY = rectangle.Height / 2;
        //                    if (2 * RoundnessX > rectangle.Width)
        //                        RoundnessX = rectangle.Width / 2;
        //                    gp.AddLine(rectangle.Left + RoundnessX, rectangle.Top, rectangle.Left + rectangle.Width - (RoundnessX), rectangle.Top); // Line
        //                    gp.AddArc(rectangle.Left + rectangle.Width - (RoundnessX * 2), rectangle.Top, RoundnessX * 2, RoundnessY * 2, 270, 90); // Corner
        //                    gp.AddLine(rectangle.Left + rectangle.Width, rectangle.Top + RoundnessY, rectangle.Left + rectangle.Width, rectangle.Top + rectangle.Height - (RoundnessY)); // Line
        //                    gp.AddArc(rectangle.Left + rectangle.Width - (RoundnessX * 2), rectangle.Top + rectangle.Height - (RoundnessY * 2), RoundnessX * 2, RoundnessY * 2, 0, 90); // Corner
        //                    gp.AddLine(rectangle.Left + rectangle.Width - (RoundnessX), rectangle.Top + rectangle.Height, rectangle.Left + RoundnessX, rectangle.Top + rectangle.Height); // Line
        //                    gp.AddArc(rectangle.Left, rectangle.Top + rectangle.Height - (RoundnessY * 2), RoundnessX * 2, RoundnessY * 2, 90, 90); // Corner
        //                    gp.AddLine(rectangle.Left, rectangle.Top + rectangle.Height - (RoundnessY), rectangle.Left, rectangle.Top + RoundnessY); // Line
        //                    gp.AddArc(rectangle.Left, rectangle.Top, RoundnessX * 2, RoundnessY * 2, 180, 90); // Corner    
        //                }
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
        //       // MessageBox.Show(e.Message);
        //        Trace.WriteLine(e.Message);
        //    }
        //    //Trace.WriteLine("Draw rectangle.Left=" + rectangle.Left.ToString() + " rectangle.Top=" + rectangle.Top.ToString() + " rectangle.Width=" + rectangle.Width.ToString() + " rectangle.Height=" + rectangle.Height.ToString());
               

        //}

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
            get { return 8; }
        }
        /// <summary>
        /// Get number of connection points
        /// </summary>
        public override int ConnectionCount
        {
            get { return HandleCount; }
        }
        public override Point GetConnection(int connectionNumber)
        {
            return GetHandle(connectionNumber);
        }
        /// <summary>
        /// Get handle point by 1-based number
        /// </summary>
        /// <param name="handleNumber"></param>
        /// <returns></returns>
        public override Point GetHandle(int handleNumber)
        {
            int x, y, xCenter, yCenter;

            xCenter = rectangle.X + rectangle.Width / 2;
            yCenter = rectangle.Y + rectangle.Height / 2;
            x = rectangle.X;
            y = rectangle.Y;

            switch (handleNumber)
            {
                case 1:
                    x = rectangle.X;
                    y = rectangle.Y;
                    break;
                case 2:
                    x = xCenter;
                    y = rectangle.Y;
                    break;
                case 3:
                    x = rectangle.Right;
                    y = rectangle.Y;
                    break;
                case 4:
                    x = rectangle.Right;
                    y = yCenter;
                    break;
                case 5:
                    x = rectangle.Right;
                    y = rectangle.Bottom;
                    break;
                case 6:
                    x = xCenter;
                    y = rectangle.Bottom;
                    break;
                case 7:
                    x = rectangle.X;
                    y = rectangle.Bottom;
                    break;
                case 8:
                    x = rectangle.X;
                    y = yCenter;
                    break;
            }
            return new Point(x, y);
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
                for (int i = 1; i <= HandleCount; i++)
                {
                    if (GetHandleRectangle(i).Contains(point))
                        return i;
                }
            }

            if (PointInObject(point))
                return 0;
            return -1;
        }

        protected override bool PointInObject(Point point)
        {
            return rectangle.Contains(point);
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
                    return Cursors.SizeNWSE;
                case 2:
                    return Cursors.SizeNS;
                case 3:
                    return Cursors.SizeNESW;
                case 4:
                    return Cursors.SizeWE;
                case 5:
                    return Cursors.SizeNWSE;
                case 6:
                    return Cursors.SizeNS;
                case 7:
                    return Cursors.SizeNESW;
                case 8:
                    return Cursors.SizeWE;
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
            int left = rectangle.Left;
            int top = rectangle.Top;
            int right = rectangle.Right;
            int bottom = rectangle.Bottom;

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
             Trace.WriteLine("MoveHandleTo left = "+left.ToString()+ " top = " + top.ToString() + " right = " + right.ToString() + " bottom = " + bottom.ToString());
             Normalize();
            SetRectangle(left, top, right - left, bottom - top);
        }


        public override bool IntersectsWith(Rectangle _rect)
        {
            return rectangle.IntersectsWith(_rect);
        }

        
        public override void Dump()
        {
            base.Dump();

            //Trace.WriteLine("rectangle.X = " + rectangle.X.ToString(CultureInfo.InvariantCulture));
            //Trace.WriteLine("rectangle.Y = " + rectangle.Y.ToString(CultureInfo.InvariantCulture));
            //Trace.WriteLine("rectangle.Width = " + rectangle.Width.ToString(CultureInfo.InvariantCulture));
            //Trace.WriteLine("rectangle.Height = " + rectangle.Height.ToString(CultureInfo.InvariantCulture));
        }

        

        

        

        protected DrawRectangle(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            if (info == null)
                throw new ArgumentNullException("info");
            try
            {
                _shapeoutline = new ShapeOutline(this);
                _shapefill = new ShapeFill(this);
                this.ShapeType = STATIC_OBJ_TYPE.ID_RECT;
                _roundnessx = info.GetInt32("RoundnessX");
                _roundnessy = info.GetInt32("RoundnessY");
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
            info.AddValue("RoundnessX",_roundnessx);
            info.AddValue("RoundnessY",_roundnessy);
            info.AddValue("ShapeFill",_shapefill.FillColor);
            info.AddValue("shapeoutline",_shapeoutline.LineStyle);
            
        }

        
    }
}

        