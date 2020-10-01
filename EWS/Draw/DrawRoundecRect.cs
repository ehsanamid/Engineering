using DCSTables;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace DocToolkit
{
    /// <summary>
    /// ObjectRectangle graphic object
    /// </summary>
    [Serializable]
    public class DrawRoundedRect : DrawRectangle
    {

       // public tblRect tblrect;
        

        
        

        /// <summary>
        /// Clone this instance
        /// </summary>
        public override DrawObject Clone()
        {
            DrawRoundedRect drawRectangle = new DrawRoundedRect();
            drawRectangle.rectangle = rectangle;

            FillDrawObjectFields(drawRectangle);
            return drawRectangle;
        }

        public DrawRoundedRect()
        {
            Resizeable = true;
            SetRectangle(0, 0, 1, 1);
        }

        //public DrawRectangle(int x, int y, int width, int height)
        //{
        //    Resizeable = true;
        //    Center = new Point(x + (width / 2), y + (height / 2));
        //    Rectangle.X = x;
        //    Rectangle.Y = y;
        //    Rectangle.Width = width;
        //    Rectangle.Height = height;
        //    TipText = String.Format("ObjectRectangle Center @ {0}, {1}", Center.X, Center.Y);
        //}

        //public DrawRectangle(int x, int y, int width, int height, Color lineColor, Color fillColor)
        //{
        //    Resizeable = true;
        //    Center = new Point(x + (width / 2), y + (height / 2));
        //    Rectangle.X = x;
        //    Rectangle.Y = y;
        //    Rectangle.Width = width;
        //    Rectangle.Height = height;
        //    Color = lineColor;
        //    FillColor = fillColor;
        //    PenWidth = -1;
        //    TipText = String.Format("ObjectRectangle Center @ {0}, {1}", Center.X, Center.Y);
        //}

        //public DrawRectangle(int x, int y, int width, int height, Color lineColor, Color fillColor, bool filled)
        //{
        //    Resizeable = true;
        //    Center = new Point(x + (width / 2), y + (height / 2));
        //    Rectangle.X = x;
        //    Rectangle.Y = y;
        //    Rectangle.Width = width;
        //    Rectangle.Height = height;
        //    Color = lineColor;
        //    FillColor = fillColor;
        //    Filled = filled;
        //    PenWidth = -1;
        //    TipText = String.Format("ObjectRectangle Center @ {0}, {1}", Center.X, Center.Y);
        //}

        //public DrawRectangle(int x, int y, int width, int height, DrawingPens.PenType pType, Color fillColor, bool filled)
        //{
        //    Resizeable = true;
        //    Center = new Point(x + (width / 2), y + (height / 2));
        //    Rectangle.X = x;
        //    Rectangle.Y = y;
        //    Rectangle.Width = width;
        //    Rectangle.Height = height;
        //    DrawPen = DrawingPens.SetCurrentPen(pType);
        //    PenType = pType;
        //    FillColor = fillColor;
        //    Filled = filled;
        //    TipText = String.Format("ObjectRectangle Center @ {0}, {1}", Center.X, Center.Y);
        //}

        //public DrawRectangle(int x, int y, int width, int height, Color lineColor, Color fillColor, bool filled, int lineWidth)
        //{
        //    Resizeable = true;
        //    Center = new Point(x + (width / 2), y + (height / 2));
        //    Rectangle.X = x;
        //    Rectangle.Y = y;
        //    Rectangle.Width = width;
        //    Rectangle.Height = height;
        //    Color = lineColor;
        //    FillColor = fillColor;
        //    Filled = filled;
        //    PenWidth = lineWidth;
        //    TipText = String.Format("ObjectRectangle Center @ {0}, {1}", Center.X, Center.Y);
        //}

        public void init(tblRect tblrect) 
        {
            base.init(tblrect);
            RoundnessX = tblrect.RoundnessX;
            RoundnessY = tblrect.RoundnessY;
           
        }

        /// <summary>
        /// Draw Rectangle
        /// </summary>
        /// <param name="g"></param>
        public override void Draw(Graphics g)
        {

            Color bcolor = Color.White;
            Color fColor1 = Color.White;
            Color fColor2 = Color.White;
            

            Pen pen;

            if (Common.Blinking && BoarderBlinking)
            {
                bcolor = BoarderColor2;
            }
            else
            {
                bcolor = BoarderColor1;
            }

            pen = new Pen(bcolor, BoarderWidth);
            pen.DashStyle = BoarderDashStyle;
            GraphicsPath gp = new GraphicsPath();

            switch (FillType)
            {
                case 0:
                    break;
                case 1:

                    Brush b;
                    if (Common.Blinking && Blinking)
                    {
                        fColor1 = FillColor12;
                    }
                    else
                    {
                        fColor1 = FillColor11;
                    }
                    break;
                case 2:
                    if (Common.Blinking && Blinking)
                    {
                        fColor1 = Color.Transparent;
                       
                    }
                    else
                    {
                        fColor1 = FillColor11;
                    }

                    break;
                case 3:
                    if (Common.Blinking && Blinking)
                    {
                        fColor1 = FillColor12;
                        fColor2 = FillColor22;
                    }
                    else
                    {
                        fColor1 = FillColor11;
                        fColor2 = FillColor21;
                    }

                    break;
            }
            
            switch (FillType)
            {
                case 0:
                    
                            if (2 * RoundnessY > rectangle.Height)
                                RoundnessY = rectangle.Height / 2;
                            if (2 * RoundnessX > rectangle.Width)
                                RoundnessX = rectangle.Width / 2;
                            gp.AddLine( rectangle.Left + RoundnessX, rectangle.Top, rectangle.Left + rectangle.Width - (RoundnessX), rectangle.Top); // Line
                            gp.AddArc(rectangle.Left + rectangle.Width - (RoundnessX * 2), rectangle.Top, RoundnessX * 2, RoundnessY * 2, 270, 90); // Corner
                            gp.AddLine(rectangle.Left + rectangle.Width, rectangle.Top + RoundnessY, rectangle.Left + rectangle.Width, rectangle.Top + rectangle.Height - (RoundnessY)); // Line
                            gp.AddArc(rectangle.Left + rectangle.Width - (RoundnessX * 2), rectangle.Top + rectangle.Height - (RoundnessY * 2), RoundnessX * 2, RoundnessY * 2, 0, 90); // Corner
                            gp.AddLine(rectangle.Left + rectangle.Width - (RoundnessX), rectangle.Top + rectangle.Height, rectangle.Left + RoundnessX, rectangle.Top + rectangle.Height); // Line
                            gp.AddArc(rectangle.Left, rectangle.Top + rectangle.Height - (RoundnessY * 2), RoundnessX * 2, RoundnessY * 2, 90, 90); // Corner
                            gp.AddLine(rectangle.Left, rectangle.Top + rectangle.Height - (RoundnessY), rectangle.Left, rectangle.Top + RoundnessY); // Line
                            gp.AddArc(rectangle.Left, rectangle.Top, RoundnessX * 2, RoundnessY * 2, 180, 90); // Corner    
                            
                    g.DrawPath(pen, gp);
                    pen.Dispose();
                    gp.Dispose();
                    break;
                case 1:

                    Brush b;
                    b = new SolidBrush(fColor1);
                    
                            if (2 * RoundnessY > rectangle.Height)
                                RoundnessY = rectangle.Height / 2;
                            if (2 * RoundnessX > rectangle.Width)
                                RoundnessX = rectangle.Width / 2;
                            gp.AddLine( rectangle.Left + RoundnessX, rectangle.Top, rectangle.Left + rectangle.Width - (RoundnessX), rectangle.Top); // Line
                            gp.AddArc(rectangle.Left + rectangle.Width - (RoundnessX * 2), rectangle.Top, RoundnessX * 2, RoundnessY * 2, 270, 90); // Corner
                            gp.AddLine(rectangle.Left + rectangle.Width, rectangle.Top + RoundnessY, rectangle.Left + rectangle.Width, rectangle.Top + rectangle.Height - (RoundnessY)); // Line
                            gp.AddArc(rectangle.Left + rectangle.Width - (RoundnessX * 2), rectangle.Top + rectangle.Height - (RoundnessY * 2), RoundnessX * 2, RoundnessY * 2, 0, 90); // Corner
                            gp.AddLine(rectangle.Left + rectangle.Width - (RoundnessX), rectangle.Top + rectangle.Height, rectangle.Left + RoundnessX, rectangle.Top + rectangle.Height); // Line
                            gp.AddArc(rectangle.Left, rectangle.Top + rectangle.Height - (RoundnessY * 2), RoundnessX * 2, RoundnessY * 2, 90, 90); // Corner
                            gp.AddLine(rectangle.Left, rectangle.Top + rectangle.Height - (RoundnessY), rectangle.Left, rectangle.Top + RoundnessY); // Line
                            gp.AddArc(rectangle.Left, rectangle.Top, RoundnessX * 2, RoundnessY * 2, 180, 90); // Corner    
                            
                    
                    g.DrawPath(pen, gp);
                    g.FillPath(b, gp);
                    gp.Dispose();
                    pen.Dispose();
                    b.Dispose();
                    break;
                case 2:

                    HatchBrush hatchbrush = new HatchBrush(hatchStyle, fColor1, Color.Transparent);
                    
                            if (2 * RoundnessY > rectangle.Height)
                                RoundnessY = rectangle.Height / 2;
                            if (2 * RoundnessX > rectangle.Width)
                                RoundnessX = rectangle.Width / 2;
                            gp.AddLine( rectangle.Left + RoundnessX, rectangle.Top, rectangle.Left + rectangle.Width - (RoundnessX), rectangle.Top); // Line
                            gp.AddArc(rectangle.Left + rectangle.Width - (RoundnessX * 2), rectangle.Top, RoundnessX * 2, RoundnessY * 2, 270, 90); // Corner
                            gp.AddLine(rectangle.Left + rectangle.Width, rectangle.Top + RoundnessY, rectangle.Left + rectangle.Width, rectangle.Top + rectangle.Height - (RoundnessY)); // Line
                            gp.AddArc(rectangle.Left + rectangle.Width - (RoundnessX * 2), rectangle.Top + rectangle.Height - (RoundnessY * 2), RoundnessX * 2, RoundnessY * 2, 0, 90); // Corner
                            gp.AddLine(rectangle.Left + rectangle.Width - (RoundnessX), rectangle.Top + rectangle.Height, rectangle.Left + RoundnessX, rectangle.Top + rectangle.Height); // Line
                            gp.AddArc(rectangle.Left, rectangle.Top + rectangle.Height - (RoundnessY * 2), RoundnessX * 2, RoundnessY * 2, 90, 90); // Corner
                            gp.AddLine(rectangle.Left, rectangle.Top + rectangle.Height - (RoundnessY), rectangle.Left, rectangle.Top + RoundnessY); // Line
                            gp.AddArc(rectangle.Left, rectangle.Top, RoundnessX * 2, RoundnessY * 2, 180, 90); // Corner    
                            
                    g.DrawPath(pen, gp);
                    //g.FillPath(hatchbrush, gp);
                    g.FillPath(hatchbrush, gp);
                    gp.Dispose();
                    pen.Dispose();
                    hatchbrush.Dispose();


                    break;
                case 3:
                    LinearGradientBrush linearBrush;

                    linearBrush = new LinearGradientBrush(rectangle, fColor1, fColor2, linearGradientBrush);

                    
                            if (2 * RoundnessY > rectangle.Height)
                                RoundnessY = rectangle.Height / 2;
                            if (2 * RoundnessX > rectangle.Width)
                                RoundnessX = rectangle.Width / 2;
                            gp.AddLine( rectangle.Left + RoundnessX, rectangle.Top, rectangle.Left + rectangle.Width - (RoundnessX), rectangle.Top); // Line
                            gp.AddArc(rectangle.Left + rectangle.Width - (RoundnessX * 2), rectangle.Top, RoundnessX * 2, RoundnessY * 2, 270, 90); // Corner
                            gp.AddLine(rectangle.Left + rectangle.Width, rectangle.Top + RoundnessY, rectangle.Left + rectangle.Width, rectangle.Top + rectangle.Height - (RoundnessY)); // Line
                            gp.AddArc(rectangle.Left + rectangle.Width - (RoundnessX * 2), rectangle.Top + rectangle.Height - (RoundnessY * 2), RoundnessX * 2, RoundnessY * 2, 0, 90); // Corner
                            gp.AddLine(rectangle.Left + rectangle.Width - (RoundnessX), rectangle.Top + rectangle.Height, rectangle.Left + RoundnessX, rectangle.Top + rectangle.Height); // Line
                            gp.AddArc(rectangle.Left, rectangle.Top + rectangle.Height - (RoundnessY * 2), RoundnessX * 2, RoundnessY * 2, 90, 90); // Corner
                            gp.AddLine(rectangle.Left, rectangle.Top + rectangle.Height - (RoundnessY), rectangle.Left, rectangle.Top + RoundnessY); // Line
                            gp.AddArc(rectangle.Left, rectangle.Top, RoundnessX * 2, RoundnessY * 2, 180, 90); // Corner    
                            
                    g.DrawPath(pen, gp);
                    g.FillPath(linearBrush, gp);
                    gp.Dispose();
                    pen.Dispose();
                    linearBrush.Dispose();

                    break;
            }

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

        public override string[] PropertyGridFilterS()
        {
            //string ss = "StartPoint,EndPoint,HandleCount,EndLineCap,StartLineCap,ArrowSize,Center,ShapeType,BoarderColor1,BoarderColor2,BoarderWidth,BoarderBlinking,BoarderType,BoarderDashStyle,BoarderLinePaternScale,Blinking,FillColor11,FillColor21,FillColor12,FillColor22,FillType,linearGradientBrush,hatchStyle,HatchColor,FillPatern,oIndex,Resizeable,Movable,ID,ObjectID,Dirty,Selected,ConnectionCount,TipText";
            string ss = "StartPoint,EndPoint,EndLineCap,StartLineCap,ArrowSize,BoarderColor1,BoarderColor2,BoarderWidth,BoarderBlinking,BoarderType,BoarderDashStyle,BoarderLinePaternScale,Blinking";
            return ss.Length > 0 ? ss.Replace(" ", "").Split(new char[] { ',' }) : null;

        }
        public override string[] PropertyGridFilterH()
        {
            //string ss = "StartPoint,EndPoint,HandleCount,EndLineCap,StartLineCap,ArrowSize,Center,ShapeType,BoarderColor1,BoarderColor2,BoarderWidth,BoarderBlinking,BoarderType,BoarderDashStyle,BoarderLinePaternScale,Blinking,FillColor11,FillColor21,FillColor12,FillColor22,FillType,linearGradientBrush,hatchStyle,HatchColor,FillPatern,oIndex,Resizeable,Movable,ID,ObjectID,Dirty,Selected,ConnectionCount,TipText";
            string ss = "HandleCount,Center,ShapeType,Blinking,FillColor11,FillColor21,FillColor12,FillColor22,FillType,linearGradientBrush,hatchStyle,HatchColor,FillPatern,oIndex,Resizeable,Movable,ID,ObjectID,Dirty,Selected,ConnectionCount,TipText";
            return ss.Length > 0 ? ss.Replace(" ", "").Split(new char[] { ',' }) : null;

        }
        
    }
}