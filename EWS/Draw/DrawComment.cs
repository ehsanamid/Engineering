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
	/// Rectangle graphic object
	/// </summary>
	[Serializable]
	public class DrawVariable : DrawObject
	{
		private Rectangle rectangle;

		private const string entryRectangle = "Rect";
        private string _varname;
        private string _vardescription;
        private bool _showmode;

		protected Rectangle Rectangle
		{
			get { return rectangle; }
			set { rectangle = value; }
		}

        /// <summary>
        /// Show Name or Name and Description of variable in variable box true: Show Name - false: Show Name & Description
        /// </summary>
        public bool ShowMode
        {
            get
            {
                return _showmode;
            }
            set
            {
                _showmode = value;
            }
        }

        /// <summary>
        /// Variable Name
        /// </summary>
        public string VarName
        {
            get 
            { 
                return _varname; 
            }
            set 
            { 
                _varname = value; 
            }
        }

        /// <summary>
        /// Variable Description
        /// </summary>
        public string VarDescription
        {
            get
            {
                return _vardescription;
            }
            set
            {
                _vardescription = value;
            }
        }

		/// <summary>
		/// Clone this instance
		/// </summary>
		public override DrawObject Clone()
		{
            DrawVariable drawRectangle = new DrawVariable();
			drawRectangle.rectangle = rectangle;

			FillDrawObjectFields(drawRectangle);
			return drawRectangle;
		}

		public DrawVariable()
		{
            VarName = "VarName";
            VarDescription = "Description";
            Resizeable = false;
            SetRectangle(0, 0, ToolVariable.DeltaY, ToolVariable.DeltaX);
		}

		public DrawVariable(int x, int y, int width, int height)
		{
            VarName = "VarName";
            VarDescription = "Description";
            Resizeable = false;
			Center = new Point(x + (width / 2), y + (height / 2));
			rectangle.X = x;
			rectangle.Y = y;
			rectangle.Width = width;
			rectangle.Height = height;
			TipText = String.Format("Rectangle Center @ {0}, {1}", Center.X, Center.Y);
		}

		public DrawVariable(int x, int y, int width, int height, Color lineColor, Color fillColor)
		{
            VarName = "VarName";
            VarDescription = "Description";
            Resizeable = false;
			Center = new Point(x + (width / 2), y + (height / 2));
			rectangle.X = x;
			rectangle.Y = y;
			rectangle.Width = width;
			rectangle.Height = height;
			Color = lineColor;
			FillColor = fillColor;
			PenWidth = -1;
			TipText = String.Format("Rectangle Center @ {0}, {1}", Center.X, Center.Y);
		}

		public DrawVariable(int x, int y, int width, int height, Color lineColor, Color fillColor, bool filled)
		{
            VarName = "VarName";
            VarDescription = "Description";
            Resizeable = false;
			Center = new Point(x + (width / 2), y + (height / 2));
			rectangle.X = x;
			rectangle.Y = y;
			rectangle.Width = width;
			rectangle.Height = height;
			Color = lineColor;
			FillColor = fillColor;
			Filled = filled;
			PenWidth = -1;
			TipText = String.Format("Rectangle Center @ {0}, {1}", Center.X, Center.Y);
		}

		public DrawVariable(int x, int y, int width, int height, DrawingPens.PenType pType, Color fillColor, bool filled)
		{
            VarName = "VarName";
            VarDescription = "Description";
            Resizeable = false;
			Center = new Point(x + (width / 2), y + (height / 2));
			rectangle.X = x;
			rectangle.Y = y;
			rectangle.Width = width;
			rectangle.Height = height;
			DrawPen = DrawingPens.SetCurrentPen(pType);
			PenType = pType;
			FillColor = fillColor;
			Filled = filled;
			TipText = String.Format("Rectangle Center @ {0}, {1}", Center.X, Center.Y);
		}

        public DrawVariable(int x, int y, int width, int height, Color lineColor, Color fillColor, bool filled, int lineWidth)
		{
            VarName = "VarName";
            VarDescription = "Description";
            Resizeable = false;
			Center = new Point(x + (width / 2), y + (height / 2));
			rectangle.X = x;
			rectangle.Y = y;
			rectangle.Width = width;
			rectangle.Height = height;
			Color = lineColor;
			FillColor = fillColor;
			Filled = filled;
			PenWidth = lineWidth;
			TipText = String.Format("Rectangle Center @ {0}, {1}", Center.X, Center.Y);
		}

		/// <summary>
		/// Draw rectangle
		/// </summary>
		/// <param name="g"></param>
		public override void Draw(Graphics g)
		{
			Pen pen;
			Brush b = new SolidBrush(FillColor);

			if (DrawPen == null)
				pen = new Pen(Color, PenWidth);
			else
				pen = (Pen)DrawPen.Clone();

			GraphicsPath gp = new GraphicsPath();
			gp.AddRectangle(GetNormalizedRectangle(Rectangle));
			// Rotate the path about it's center if necessary
			if (Rotation != 0)
			{
				RectangleF pathBounds = gp.GetBounds();
				Matrix m = new Matrix();
				m.RotateAt(Rotation, new PointF(pathBounds.Left + (pathBounds.Width / 2), pathBounds.Top + (pathBounds.Height / 2)), MatrixOrder.Append);
				gp.Transform(m);
			}

			g.DrawPath(pen, gp);
			if (Filled)
				g.FillPath(b, gp);
            /////////////////////////////
            // Draw string for Name and Description
            /////////////////////////////

            if (ShowMode)
            {
                Font drawFont = new Font("Arial", 10);
                SolidBrush drawBrush = new SolidBrush(Color.Black);

                // Set format of string.
                StringFormat drawFormat = new StringFormat();
                drawFormat.Alignment = StringAlignment.Center;

                // Draw string to screen.
                g.DrawString(VarName, drawFont, drawBrush, Rectangle, drawFormat);
            }
            else
            {
                Font drawFont = new Font("Arial", 6);
                SolidBrush drawBrush = new SolidBrush(Color.Black);

                // Create rectangle for drawing.
                
                Rectangle drawRectName = new Rectangle(Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height/2);
                Rectangle drawRectDescription = new Rectangle(Rectangle.X, Rectangle.Y + Rectangle.Height / 2, Rectangle.Width, Rectangle.Height / 2);


                // Set format of string.
                StringFormat drawFormat = new StringFormat();
                drawFormat.Alignment = StringAlignment.Center;

                // Draw string to screen.
                g.DrawString(VarName, drawFont, drawBrush, drawRectName, drawFormat);
                g.DrawString(VarDescription, drawFont, drawBrush, drawRectDescription, drawFormat);
            }
            ///////////////////////////////////////
            // End of Drawing strings
            //////////////////////////////////////
			gp.Dispose();
			pen.Dispose();
			b.Dispose();
		}
        public override void DrawTracker(Graphics g)
        {
            if (!Selected)
                return;
            SolidBrush brush = new SolidBrush(Color.Black);

            for (int i = 1; i <= HandleCount; i++)
            {
                g.FillRectangle(brush, GetHandleRectangle(i));
            }
            brush.Dispose();
        }
		protected void SetRectangle(int x, int y, int width, int height)
		{
			rectangle.X = x;
			rectangle.Y = y;
			rectangle.Width = width;
			rectangle.Height = height;
		}

		/// <summary>
		/// Get number of handles
		/// </summary>
		public override int HandleCount
		{
			get { return 6; }
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
					y = yCenter;// rectangle.Y;
					break;
				case 2:
					x = rectangle.Right;// xCenter;
					y = yCenter;// rectangle.Y;
					break;
				case 3:
					x = rectangle.X;
					y = rectangle.Y;
					break;
				case 4:
					x = rectangle.Right;
                    y = rectangle.Y;
					break;
				case 5:
					x = rectangle.Right;
					y = rectangle.Bottom;
					break;
				case 6:
					x = rectangle.X;;
					y = rectangle.Bottom;
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
        public override Rectangle GetHandleRectangle(int handleNumber)
        {
            Point point = GetHandle(handleNumber);
            switch (handleNumber)
            {
                case 1:
                    return new Rectangle(point.X - 1, point.Y - 1, 2, 2);
                case 2:
                    return new Rectangle(point.X+1 , point.Y - 1, 1, 2);
                default:
                    return new Rectangle(point.X - (PenWidth + 1), point.Y - (PenWidth + 1), 3 + PenWidth, 3 + PenWidth);
            }
            
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
			int left = Rectangle.Left;
			int top = Rectangle.Top;
			int right = Rectangle.Right;
			int bottom = Rectangle.Bottom;

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
			return Rectangle.IntersectsWith(rectangle);
		}

		/// <summary>
		/// Move object
		/// </summary>
		/// <param name="deltaX"></param>
		/// <param name="deltaY"></param>
		public override void Move(int deltaX, int deltaY)
		{
			rectangle.X += deltaX;
			rectangle.Y += deltaY;
			Dirty = true;
		}

		public override void Dump()
		{
			base.Dump();

			Trace.WriteLine("rectangle.X = " + rectangle.X.ToString(CultureInfo.InvariantCulture));
			Trace.WriteLine("rectangle.Y = " + rectangle.Y.ToString(CultureInfo.InvariantCulture));
			Trace.WriteLine("rectangle.Width = " + rectangle.Width.ToString(CultureInfo.InvariantCulture));
			Trace.WriteLine("rectangle.Height = " + rectangle.Height.ToString(CultureInfo.InvariantCulture));
		}

		/// <summary>
		/// Normalize rectangle
		/// </summary>
		public override void Normalize()
		{
			rectangle = GetNormalizedRectangle(rectangle);
		}

		/// <summary>
		/// Save objevt to serialization stream
		/// </summary>
		/// <param name="info">Contains all data being written to disk</param>
		/// <param name="orderNumber">Index of the Layer being saved</param>
		/// <param name="objectIndex">Index of the drawing object in the Layer</param>
		public override void SaveToStream(SerializationInfo info, int orderNumber, int objectIndex)
		{
			info.AddValue(
				String.Format(CultureInfo.InvariantCulture,
							  "{0}{1}-{2}",
							  entryRectangle, orderNumber, objectIndex),
				rectangle);

			base.SaveToStream(info, orderNumber, objectIndex);
		}

		/// <summary>
		/// LOad object from serialization stream
		/// </summary>
		/// <param name="info"></param>
		/// <param name="orderNumber"></param>
		/// <param name="objectIndex"></param>
		public override void LoadFromStream(SerializationInfo info, int orderNumber, int objectIndex)
		{
			rectangle = (Rectangle)info.GetValue(
									String.Format(CultureInfo.InvariantCulture,
												  "{0}{1}-{2}",
												  entryRectangle, orderNumber, objectIndex),
									typeof(Rectangle));

			base.LoadFromStream(info, orderNumber, objectIndex);
		}

		#region Helper Functions
		public static Rectangle GetNormalizedRectangle(int x1, int y1, int x2, int y2)
		{
			if (x2 < x1)
			{
				int tmp = x2;
				x2 = x1;
				x1 = tmp;
			}

			if (y2 < y1)
			{
				int tmp = y2;
				y2 = y1;
				y1 = tmp;
			}
			return new Rectangle(x1, y1, x2 - x1, y2 - y1);
		}

		public static Rectangle GetNormalizedRectangle(Point p1, Point p2)
		{
			return GetNormalizedRectangle(p1.X, p1.Y, p2.X, p2.Y);
		}

		public static Rectangle GetNormalizedRectangle(Rectangle r)
		{
			return GetNormalizedRectangle(r.X, r.Y, r.X + r.Width, r.Y + r.Height);
		}
		#endregion Helper Functions
	}
}