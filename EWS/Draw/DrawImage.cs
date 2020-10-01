using DCS.DCSTables;
using DCS.Project_Objects;
using DCS.TabPages;
using DCS.TypeConverters;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Windows.Forms;

namespace DCS.Draw
{
    /// <summary>
    /// Image graphic object
    /// </summary>
    //[Serializable]
    public class DrawImage : DrawGraphic
    {
        tblBitmap sqltable = new tblBitmap();
        RotateFlipType rotation = RotateFlipType.RotateNoneFlipNone;
        [DisplayName("Image Orientation")]
        [Description("Image Orientation")]
        [Category("Format")]
        public RotateFlipType Rotation
        {
            get
            {
                return rotation;
            }
            set
            {
                rotation = value;
            }
        }

        private Bitmap _image;
        private string bitmapname = "";
        [Editor(typeof(ImageEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string BitmapName
        {
            get
            {
                return bitmapname;
            }
            set
            {
                if (value != null)
                {
                    bitmapname = value;
                }
            }
        }

        private bool transparent;
        [Category("Format")]
        public bool Transparent
        {
            get
            {
                return transparent;
            }
            set
            {
                transparent = value;
            }
        }


        /// <summary>
        /// Clone this instance
        /// </summary>
        public override DrawObject Clone()
        {
            DrawImage drawImage = new DrawImage(Parentpagelist);
            drawImage._image = _image;
            //drawImage._originalImage = _originalImage;
            drawImage.rectangle = rectangle;

            FillDrawObjectFields(drawImage);
            return drawImage;
        }

        
        public DrawImage(PageList _parent)
            : base(_parent)
        {
            Resizeable = true;
            SetRectangle(0, 0, 1, 1);
            Initialize();
            Propertylist.Add("BorderWidth,Border Width,DINT");
            Propertylist.Add("BorderColor,Border Color,Color");
            Propertylist.Add("BorderBlinking,Border Blinking,BOOL");
        }

        public DrawImage(PageList _parent, int x, int y)
            : base(_parent)
        {
            Resizeable = true;
            _rectangle.X = x;
            _rectangle.Y = y;
            _rectangle.Width = 1;
            _rectangle.Height = 1;
            Propertylist.Add("BorderWidth,Border Width,DINT");
            Propertylist.Add("BorderColor,Border Color,Color");
            Propertylist.Add("BorderBlinking,Border Blinking,BOOL");
            Initialize();
        }

        public DrawImage(PageList _parent, int x, int y, Bitmap image)
            : base(_parent)
        {
            Resizeable = true;
            _rectangle.X = x;
            _rectangle.Y = y;
            _rectangle.Width = 1;
            _rectangle.Height = 1;
            _image = (Bitmap)image.Clone();
            SetRectangle(rectangle.X, rectangle.Y, image.Width, image.Height);
            Center = new Point(x + (image.Width / 2), y + (image.Height / 2));
            TipText = String.Format("Image Center @ {0}, {1}", Center.X, Center.Y);
            Propertylist.Add("BorderWidth,Border Width,DINT");
            Propertylist.Add("BorderColor,Border Color,Color");
            Propertylist.Add("BorderBlinking,Border Blinking,BOOL");
            Initialize();
        }

        public override Rectangle GetConnectionEllipse(int connectionNumber)
        {
            Point p = GetConnection(connectionNumber);
            // Take into account width of pen
            return new Rectangle(p.X -  3, p.Y -  3, 7 , 7 );
        }
        protected override void UpdateHasExpression()
        {
            base.UpdateHasExpression();
            foreach (DisplayObjectDynamicProperty exp in this.drawexpressionCollection.objDisplayObjectDynamicPropertys.list)
            {
                switch (exp.ObjectType)
                {
                    case enumDynamicGraphicalProperty.BorderWidth:
                        break;
                    case enumDynamicGraphicalProperty.BorderColor:
                        break;
                    case enumDynamicGraphicalProperty.Color1:
                        break;
                    case enumDynamicGraphicalProperty.Color2:
                        break;
                    case enumDynamicGraphicalProperty.TextColor:

                        break;
                    case enumDynamicGraphicalProperty.BorderBlinking:
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


        public override bool Load(object obj)
        {
            bool ret = true;
            Dirty = false;
            sqltable = (tblBitmap)obj;
            SQLID = sqltable.ID;
            oIndex = sqltable.oIndex;
            NewObject = false;


            BitmapName = sqltable.BitmapName;
            _rectangle.X = sqltable.left;
            _rectangle.Y = sqltable.top;
            _rectangle.Width = sqltable.right - sqltable.left;
            _rectangle.Height = sqltable.bottom - sqltable.top;
            Transparent = sqltable.Transparent;
            Rotation = (RotateFlipType)sqltable.Rotation;

            LockPosition = sqltable.LockPosition;
            LockEdit = sqltable.LockEdit;
            Layer = (LAYERS) sqltable.Layer;

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
            //_rectangle.X = sqltable.left;
            //_rectangle.Y = sqltable.top;
            //SetRectangle(rectangle.X, rectangle.Y, _image.Width, _image.Height);
            // Center = new Point(rectangle.X + (_image.Width / 2), rectangle.Y + (_image.Height / 2));
            //TipText = String.Format("Image Center @ {0}, {1}", Center.X, Center.Y);
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
                //string bmppath = Common.ProjectPath + "Bitmaps\\" + sqltable.BitmapName;
                sqltable.BitmapName = BitmapName;

                sqltable.right = rectangle.Right;
                sqltable.left = rectangle.Left;
                sqltable.bottom = rectangle.Bottom;
                sqltable.top = rectangle.Top;

                sqltable.Transparent = Transparent;
                sqltable.Rotation = (int)Rotation;
                sqltable.LockPosition = LockPosition;
                sqltable.LockEdit = LockEdit;
                sqltable.Layer = (int)Layer;
                sqltable.Argument = drawexpressionCollection.DisplayObjectParametersstr;
                sqltable.Expression = drawexpressionCollection.DisplayObjectDynamicPropertysstr;
                sqltable.Action = drawexpressionCollection.DisplayObjectEventHandlersstr;

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
        /// Draw image
        /// </summary>
        /// <param name="g"></param>
        public override void Draw(Graphics g)
        {
            try
            {
                if (this.Visible)
                {
                    if (BitmapName != "")
                    {
                        if (!((rectangle.Width == 0) || (rectangle.Height == 0)))
                        {
                            Rectangle r1 = new Rectangle();
                            r1 = GetNormalizedRectangle(rectangle);
                            string bmppath = Common.ProjectPath + "\\Bitmaps\\" + BitmapName;
                            _image = new System.Drawing.Bitmap(Image.FromFile(bmppath), new Size(r1.Width, r1.Height));


                            // Get existing World transformation
                            Matrix mSave = g.Transform;
                            //if (Rotation != 0)
                            //{
                            //    Matrix m = mSave.Clone();
                            //    m.RotateAt(Rotation, new PointF(rectangle.Left + (rectangle.Width / 2), rectangle.Top + (rectangle.Height / 2)), MatrixOrder.Append);
                            //    g.Transform = m;
                            //}
                            if (_image == null)
                            {
                                Pen p = new Pen(Color.Black, -1f);
                                g.DrawRectangle(p, r1);
                            }
                            else
                            {
                                // g.DrawImage(_image, new Point(rectangle.X, rectangle.Y));

                                _image.RotateFlip(Rotation);
                                g.DrawImage(_image, r1);
                                /*
                                Matrix m;
                                Rectangle destRect1 = new Rectangle();
                                switch (Rotation)
                                {
                                    case TextOrientation.D0:
                                        _image.RotateFlip(rotateFlipType);
                                        g.DrawImage(_image, r1);
                                        break;
                                    case TextOrientation.D90:
                                
                                        destRect1.X = r1.X + r1.Width;
                                        destRect1.Y = r1.Y;
                                        destRect1.Width = r1.Height;
                                        destRect1.Height = r1.Width;
                                
                                        m = mSave.Clone();
                                        m.RotateAt(90, new PointF(destRect1.Left, destRect1.Top));
                                        g.Transform = m;

                                        g.DrawImage(_image, destRect1);
                                        g.Transform.Reset();
                                        g.ResetTransform();
                                        break;
                                    case TextOrientation.D180:
                                        destRect1.X = r1.X + r1.Width;
                                        destRect1.Y = r1.Y + r1.Height;
                                        destRect1.Width = r1.Width;
                                        destRect1.Height = r1.Height;
                                
                                        m = mSave.Clone();
                                        m.RotateAt(180, new PointF(destRect1.Left, destRect1.Top));
                                        g.Transform = m;

                                        g.DrawImage(_image, destRect1);

                                        g.Transform.Reset();
                                        g.ResetTransform();
                                        break;
                                    case TextOrientation.D270:
                                        destRect1.X = r1.X + r1.Height;
                                        destRect1.Y = r1.Y;
                                        destRect1.Width = r1.Height;
                                        destRect1.Height = r1.Width;
            
                     m = mSave.Clone();
                    m.RotateAt(270, new PointF(destRect1.Left , destRect1.Top+destRect1.Width ));
                    g.Transform = m;

                    g.DrawImage(_image, destRect1);
                                        g.Transform.Reset();
                                        g.ResetTransform();
                                        break;
                                }
                                */
                            }
                            // Restore World transformation
                            g.Transform = mSave;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
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
            Dirty = true;
            SetRectangle(left, top, right - left, bottom - top);
            Normalize();
            ResizeImage(rectangle.Width, rectangle.Height);
        }

        protected void ResizeImage(int width, int height)
        {
            //if (_originalImage != null)
            //{
            //    Bitmap b = new Bitmap(_originalImage, new Size(width, height));
            //    _image = (Bitmap)b.Clone();
            //    b.Dispose();
            //}
        }

        public override bool IntersectsWith(Rectangle rectangle)
        {
            return _rectangle.IntersectsWith(rectangle);
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
            base.Dump();

            //Trace.WriteLine("rectangle.X = " + rectangle.X.ToString(CultureInfo.InvariantCulture));
            ////Trace.WriteLine("rectangle.Y = " + rectangle.Y.ToString(CultureInfo.InvariantCulture));
            //Trace.WriteLine("rectangle.Width = " + rectangle.Width.ToString(CultureInfo.InvariantCulture));
            //Trace.WriteLine("rectangle.Height = " + rectangle.Height.ToString(CultureInfo.InvariantCulture));
        }

        
        /// <summary>
        /// Save object to serialization stream
        /// </summary>
        /// <param name="info"></param>
        /// <param name="orderNumber"></param>
        /// <param name="objectIndex"></param>

       
        

        protected DrawImage(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            if (info == null)
                throw new ArgumentNullException("info");

            bitmapname = info.GetString("bitmapname");
            transparent = info.GetBoolean("transparent");
           // oIndex = _parent.GetNewobjectoIndex();
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        protected override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info,context);
            info.AddValue("bitmapname", bitmapname);
            info.AddValue("transparent", transparent);
            
        }
        /*
         * 
         * bitmapname = "";
        [Editor(typeof(ImageEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string BitmapName
        
        private bool transparent;
        */
    }
}