using DCS;
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
    public class DrawText : DrawGraphic
    {
        private Rectangle transformrectangle;
        private string _theText;

        tblADText sqltable = new tblADText();

        

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

        

        private TextFormat _format;
        
        [DisplayName("Text Format")]
        [Description("Text Format")]
        [Category("Format")]
        [TypeConverter(typeof(EnumeratorTypeConverter))]
        public TextFormat Format
        {
            get
            {
                return _format;
            }
            set
            {
                _format = value;
            }
        }

        STRINGOBJ m_strval = new STRINGOBJ();
        bool HasTextExpression = false;
        private string _textvalue;
        [Category("Expression")]
        public string TextValue
        {
            get
            {
                if (HasTextExpression)
                {

#if OWSAPP
                    if (drawexpressionCollection.RunField(enumDynamicGraphicalProperty.Text, ref m_strval))
                    {
                        _textvalue = m_strval.getStringValue(); 
                    }
#endif
                }
                
                return _textvalue;
            }
            set
            {
                _textvalue = value;
            }
        }

        

        
        private Font _font;
        [Category("Format")]
        public Font font
        {
            get
            {
                return _font;
            }
            set
            {
                _font = value;
            }
        }

        private bool _unitshow;
        [Category("Unit")]
        public bool UnitShow
        {
            get
            {
                return _unitshow;
            }
            set
            {
                _unitshow = value;
            }
        }

        private TextOrientation orientation = TextOrientation.D0;
        [DisplayName("Text Orientation")]
        [Description("Text Orientation")]
        [Category("Format")]
        [TypeConverter(typeof(EnumeratorTypeConverter))]
        public TextOrientation Orientation
        {
            get
            {
                return orientation;
            }
            set
            {
                orientation = value;
            }
        }

        private bool isfix;
        [Category("Format")]
        public bool IsFix
        {
            get
            {
                return isfix;
            }
            set
            {
                isfix = value;
            }
        }
        

        private Color textcolor;
        [Category("Default")]

        public Color TextColor
        {
            get
            {
                return textcolor;
            }
            set
            {
                textcolor = value;
            }
        }
        private bool textblinking;
        [Category("Default")]

        public bool TextBlinking
        {
            get
            {
                return textblinking;
            }
            set
            {
                textblinking = value;
            }
        }
       
        StringFormat format = new StringFormat();
                
        private TextAlignment textalignment = TextAlignment.CenterCenter;
        [DisplayName("Text Alignment")]
        [Description("Text Alignment")]
        [Category("Default")]
        [TypeConverter(typeof(EnumeratorTypeConverter))]
        public TextAlignment textAlignment
        {
            get
            {
                return textalignment;
            }
            set
            {
                
                textalignment = value;
                ChangeFormat();
            }
        }

        void ChageOrientation(Graphics g)
        {
            switch (Orientation)
            {
                case TextOrientation.D0:
                    transformrectangle = rectangle;

                    break;
                case TextOrientation.D90:
                    g.TranslateTransform(rectangle.X + rectangle.Width, rectangle.Y);
                    g.RotateTransform(90);
                    transformrectangle.X = 0;
                    transformrectangle.Y = 0;
                    transformrectangle.Height = rectangle.Width;
                    transformrectangle.Width = rectangle.Height;
                    break;
                case TextOrientation.D180:
                    g.TranslateTransform(rectangle.X, rectangle.Y);
                    g.RotateTransform(180);
                    transformrectangle.X = -1 * rectangle.Width;
                    transformrectangle.Y = -1 * rectangle.Height;
                    transformrectangle.Height = rectangle.Height;
                    transformrectangle.Width = rectangle.Width;
                    break;
                case TextOrientation.D270:
                    g.TranslateTransform(rectangle.X, rectangle.Y);
                    g.RotateTransform(270);

                    transformrectangle.Y = 0;
                    transformrectangle.X = -1 * rectangle.Height;
                    transformrectangle.Height = rectangle.Width;
                    transformrectangle.Width = rectangle.Height;
                    break;
                default:
                    break;
            }
        }

        void ChangeFormat()
        {
            switch (textalignment)
            {
                case TextAlignment.LeftTop:
                    
                    format.Alignment = StringAlignment.Near;
                    format.LineAlignment = StringAlignment.Near;
                    break;
                case TextAlignment.LeftCenter:
                    
                    format.Alignment = StringAlignment.Near;
                    format.LineAlignment = StringAlignment.Center;
                    break;
                case TextAlignment.LeftBottom:

                    format.Alignment = StringAlignment.Near;
                    format.LineAlignment = StringAlignment.Far;
                    break;
                case TextAlignment.CenterTop:

                    format.Alignment = StringAlignment.Center;
                    format.LineAlignment = StringAlignment.Near;
                    break;
                case TextAlignment.CenterCenter:

                    format.Alignment = StringAlignment.Center;
                    format.LineAlignment = StringAlignment.Center;
                    break;
                case TextAlignment.CenterBottom:

                    format.Alignment = StringAlignment.Center;
                    format.LineAlignment = StringAlignment.Far;
                    break;
                case TextAlignment.RightTop:

                    format.Alignment = StringAlignment.Far;
                    format.LineAlignment = StringAlignment.Near;
                    break;
                case TextAlignment.RightCenter:

                    format.Alignment = StringAlignment.Far;
                    format.LineAlignment = StringAlignment.Center;
                    break;
                case TextAlignment.RightBottom:

                    format.Alignment = StringAlignment.Far;
                    format.LineAlignment = StringAlignment.Far;
                    break;
            }
        }
        

        public DrawText(PageList _parent)
            : base(_parent)
        {
            _shapeoutline = new ShapeOutline(this);
            _shapefill = new ShapeFill(this);
            Resizeable = true;
            //SetRectangle(0, 0, 1,1);
            _theText = "";
            this.ShapeType = STATIC_OBJ_TYPE.ID_TEXT;
            shapefill.FillColor = Common.LastFillColor;
            shapeoutline.LineStyle = Common.LastLineStyle;
            Propertylist.Add("Text,Text,STRING");
            Propertylist.Add("TextColor,Text Color,Color");
            Propertylist.Add("TextBlinking,Text Blinking,BOOL");
            Propertylist.Add("BorderWidth,Border Width,DINT");
            Propertylist.Add("BorderColor,Border Color,Color");
            Propertylist.Add("BorderBlinking,Border Blinking,BOOL");
            Propertylist.Add("Color1,Fill Color,Color");
            Propertylist.Add("Visible,Visible,BOOL");
            Initialize();
        }

        /// <summary>
        /// Clone this instance
        /// </summary>
        public override DrawObject Clone()
        {
            DrawText drawText = new DrawText(Parentpagelist);

            drawText._font = _font;
            drawText._theText = _theText;
            drawText.rectangle = rectangle;

            FillDrawObjectFields(drawText);

            return drawText;
        }


        public DrawText(PageList _parent, int x, int y, string textToDraw, Font textFont, Color textColor)
            : base(_parent)
        {
            _shapeoutline = new ShapeOutline(this);
            _shapefill = new ShapeFill(this);
            Resizeable = true;
            _rectangle.X = x;
            _rectangle.Y = y;
            _theText = textToDraw;
            _font = textFont;
            TextColor = textColor;
            this.ShapeType = STATIC_OBJ_TYPE.ID_TEXT;
            shapefill.FillColor = Common.LastFillColor;
            shapeoutline.LineStyle = Common.LastLineStyle;
            Propertylist.Add("Text,Text,STRING");
            Propertylist.Add("TextColor,Text Color,Color");
            Propertylist.Add("TextBlinking,Text Blinking,BOOL");
            Propertylist.Add("BorderWidth,Border Width,DINT");
            Propertylist.Add("BorderColor,Border Color,Color");
            Propertylist.Add("BorderBlinking,Border Blinking,BOOL");
            Propertylist.Add("Color1,Fill Color,Color");
            Propertylist.Add("Visible,Visible,BOOL");
            Initialize();
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
                        HasTextExpression = true;
                        break;
                }
            }


        }

        //public void init(tblADText sqltable)
        public override bool Load(object obj)
        {
            bool ret = true;
            Dirty = false;
            sqltable = (tblADText)obj;
            SQLID = sqltable.ID;
            oIndex = sqltable.oIndex;
            NewObject = false;

            //this.Rectangle = new Rectangle(sqltable.Left, sqltable.Top, sqltable.Right - sqltable.Left, sqltable.Bottom - sqltable.Top);
            this.rectangle = GetNormalizedRectangle(sqltable.Left, sqltable.Top, sqltable.Right, sqltable.Bottom);
            this.Format = (TextFormat) sqltable.Format;
            //this.Alignment = (TextAlignment) sqltable.Alignment;
            this.TextValue = sqltable.TextValue;
            this.TextColor = sqltable.TextColor;
            this.TextBlinking = sqltable.TextBlinking;
            this.shapefill.FillColor = sqltable.FillColor;
            this.shapeoutline.LineStyle = sqltable.LineStyle;
            this.Orientation = (TextOrientation)sqltable.Orientation;

            //System.ComponentModel.TypeConverter converter = System.ComponentModel.TypeDescriptor.GetConverter(typeof(Font));

            //this.font = (Font)converter.ConvertFromString(sqltable.Font);
            this.font = FontXmlConverter.ConvertToFont(sqltable.Font);
            
            
            this.TextValue = sqltable.TextValue;
            this.TextColor = sqltable.TextColor;
            this.TextBlinking = sqltable.TextBlinking;
            
            this.isfix = sqltable.isfix;
            
            this.LastRev = sqltable.LastRev;
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
                sqltable.Layer = (int)Layer;
                sqltable.Left = rectangle.Left;
                sqltable.Right = rectangle.Right;
                sqltable.Top = rectangle.Top;
                sqltable.Bottom = rectangle.Bottom;

                sqltable.Format = (int)this.Format;
                sqltable.Alignment = (byte)this.textAlignment;
                sqltable.TextValue = this.TextValue;
                sqltable.TextColor = this.TextColor;
                sqltable.TextBlinking = this.TextBlinking;
                sqltable.FillColor = this.shapefill.FillColor;
                sqltable.LineStyle = this.shapeoutline.LineStyle;
                //FontConverter cvt = new FontConverter();
                //sqltable.Font = cvt.ConvertToString(this.font);
                sqltable.Font = FontXmlConverter.ConvertToString(this.font);
                sqltable.UnitShow = this.UnitShow;
                //cvt = new FontConverter();
                //sqltable.UnitFont = cvt.ConvertToString(this.UnitFont);
                //sqltable.UnitColor = this.UnitColor;

                sqltable.TextValue = this.TextValue;
                sqltable.TextColor = this.TextColor;
                sqltable.TextBlinking = this.TextBlinking;
                sqltable.isfix = this.isfix;
                sqltable.Orientation = (int)this.Orientation;
                sqltable.LastRev = this.LastRev;
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
         /// <summary>
         /// Draw rectangle
        /// </summary>
        /// <param name="g"></param>
        /// 
         public override void Draw(Graphics g)
         {

             Color bcolor = Color.White;
             Color fColor1 = Color.White;
             Color fColor2 = Color.White;

             try
             {
                 if (this.Visible)
                 {
                     Brush bf = new SolidBrush(TextColor);
                     ChangeFormat();
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


                     gp.AddRectangle(rectangle);



                     switch (shapefill.FillType)
                     {
                         case FillTypePatern.Transparent:


                             if (shapeoutline.BoarderWidth != 0)
                             {
                                 g.DrawPath(pen, gp);
                             }
                             ChageOrientation(g);
                             g.DrawString(TextValue, this.font, bf, transformrectangle, format);
                             g.ResetTransform();
                             pen.Dispose();
                             gp.Dispose();
                             bf.Dispose();
                             break;
                         case FillTypePatern.Solid:

                             Brush b = new SolidBrush(fColor1);

                             g.FillPath(b, gp);



                             if (shapeoutline.BoarderWidth != 0)
                             {
                                 g.DrawPath(pen, gp);
                             }

                             ChageOrientation(g);
                             g.DrawString(TextValue, this.font, bf, transformrectangle, format);
                             g.ResetTransform();

                             gp.Dispose();
                             pen.Dispose();
                             b.Dispose();
                             bf.Dispose();
                             break;
                         case FillTypePatern.Hatched:

                             using (HatchBrush hatchbrush = new HatchBrush(shapefill.hatchStyle, fColor1, Color.Transparent))
                             {
                                 g.DrawString(TextValue, this.font, bf, transformrectangle, format);
                                 g.ResetTransform();
                                 if (shapeoutline.BoarderWidth != 0)
                                 {
                                     g.DrawPath(pen, gp);
                                 }
                                 g.FillPath(hatchbrush, gp);

                                 ChageOrientation(g);
                                 g.DrawString(TextValue, this.font, bf, transformrectangle, format);
                                 g.ResetTransform();

                             }
                             gp.Dispose();
                             pen.Dispose();
                             bf.Dispose();


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
                                         ChageOrientation(g);
                                         g.DrawString(TextValue, this.font, bf, transformrectangle, format);
                                         g.ResetTransform();

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

                                         ChageOrientation(g);
                                         g.DrawString(TextValue, this.font, bf, transformrectangle, format);
                                         g.ResetTransform();

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
                                         ChageOrientation(g);
                                         g.DrawString(TextValue, this.font, bf, transformrectangle, format);
                                         g.ResetTransform();

                                     }
                                     break;
                             }

                             gp.Dispose();
                             pen.Dispose();
                             bf.Dispose();
                             break;
                     }
                 }
             }
             catch (Exception e)
             {
                 // MessageBox.Show(e.Message);
                 Trace.WriteLine(e.Message);
             }
             //Trace.WriteLine("Draw rectangle.Left=" + rectangle.Left.ToString() + " rectangle.Top=" + rectangle.Top.ToString() + " rectangle.Width=" + rectangle.Width.ToString() + " rectangle.Height=" + rectangle.Height.ToString());


         }


        /// <summary>
        /// Get number of handles
        /// </summary>
        public override int HandleCount
        {
            get { return 8; }
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
            Normalize();
            SetRectangle(left, top, right - left, bottom - top);
        }


        public override bool IntersectsWith(Rectangle rect)
        {
            return rectangle.IntersectsWith(rect);
        }

        /// <summary>
        /// Move object
        /// </summary>
        /// <param name="deltaX"></param>
        /// <param name="deltaY"></param>
        public override void Move(int deltaX, int deltaY)
        {
            _rectangle.X += deltaX;
            _rectangle.Y += deltaY;
            Dirty = true;
        }

        public override void Dump()
        {
            //base.Dump ();

            //Trace.WriteLine("rectangle.X = " + rectangle.X.ToString(CultureInfo.InvariantCulture));
            //Trace.WriteLine("rectangle.Y = " + rectangle.Y.ToString(CultureInfo.InvariantCulture));
            //Trace.WriteLine("rectangle.Width = " + rectangle.Width.ToString(CultureInfo.InvariantCulture));
            //Trace.WriteLine("rectangle.Height = " + rectangle.Height.ToString(CultureInfo.InvariantCulture));
        }

        

        

        
        
        protected void SetRectangle(int x, int y, int width, int height)
        {
            _rectangle.X = x;
            _rectangle.Y = y;
            _rectangle.Width = width;
            _rectangle.Height = height;
        }

        
        protected DrawText(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            if (info == null)
                throw new ArgumentNullException("info");
            try
            {
                _shapeoutline = new ShapeOutline(this);
                _shapefill = new ShapeFill(this);
                this.ShapeType = STATIC_OBJ_TYPE.ID_TEXT;
                TextValue = info.GetString("TextValue");
                font = FontXmlConverter.ConvertToFont(info.GetString("font"));
                Orientation = (TextOrientation)info.GetInt32("Orientation");
                TextBlinking = info.GetBoolean("TextBlinking");
                textAlignment = (TextAlignment)info.GetInt32("textAlignment");
                IsFix = info.GetBoolean("IsFix");
                TextColor = (Color)info.GetValue("TextColor", TextColor.GetType());
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
            info.AddValue("TextValue", TextValue);
            info.AddValue("font", FontXmlConverter.ConvertToString(font));
            info.AddValue("Orientation", (int)Orientation);
            info.AddValue("TextBlinking", TextBlinking);
            info.AddValue("textAlignment", (int)textAlignment);
            info.AddValue("IsFix", IsFix);
            info.AddValue("TextColor", TextColor);
            info.AddValue("ShapeFill",_shapefill.FillColor);
            info.AddValue("shapeoutline",_shapeoutline.LineStyle);
            
        }

    }
}

/*
        public Color TextColor
     */   