using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace DocToolkit
{
	/// <summary>
	/// Connector graphic object - a Connector is a series of connected straight lines
	///										where each line is drawn individually and at least
	///										one of the ends is anchored to another object
	/// </summary>
	//[Serializable]
	public class DrawConnector : DrawLogic
	{
		// Connector-specific fields
		private LineCap startCap = LineCap.NoAnchor;
		private LineCap endCap = LineCap.ArrowAnchor;
		private bool startIsAnchored = false;
		private bool endIsAnchored = false;
		private int startObjectId = -1;
		private int endObjectId = -1;

		// Last Segment start and end points
		private Point startPoint;
		private Point endPoint;

		private ArrayList pointArray; // list of points
		private Cursor handleCursor;

		private const string entryLength = "Length";
		private const string entryPoint = "Point";
        /// <summary>
        ///  Graphic objects for hit test
        /// </summary>
        private GraphicsPath areaPath = null;
        protected GraphicsPath AreaPath
        {
            get { return areaPath; }
            set { areaPath = value; }
        }

        private Region areaRegion = null;

        private Pen areaPen = null;
        protected Pen AreaPen
        {
            get { return areaPen; }
            set { areaPen = value; }
        }
        protected Region AreaRegion
        {
            get { return areaRegion; }
            set { areaRegion = value; }
        }

		public LineCap StartCap
		{
			get { return startCap; }
			set { startCap = value; }
		}

		public LineCap EndCap
		{
			get { return endCap; }
			set { endCap = value; }
		}

		public bool StartIsAnchored
		{
			get { return startIsAnchored; }
			set { startIsAnchored = value; }
		}

		public bool EndIsAnchored
		{
			get { return endIsAnchored; }
			set { endIsAnchored = value; }
		}

		public int StartObjectId
		{
			get { return startObjectId; }
			set { startObjectId = value; }
		}

		public int EndObjectId
		{
			get { return endObjectId; }
			set { endObjectId = value; }
		}


		public Point StartPoint
		{
			get { return startPoint; }
			set { startPoint = value; }
		}

		public Point EndPoint
		{
			get { return endPoint; }
			set { endPoint = value; }
		}

		/// <summary>
		/// Clone this instance
		/// </summary>
		public override DrawObject Clone()
		{
			DrawConnector drawPolyLine = new DrawConnector();

			drawPolyLine.startPoint = startPoint;
			drawPolyLine.endPoint = endPoint;
			drawPolyLine.pointArray = pointArray;

			FillDrawObjectFields(drawPolyLine);
			return drawPolyLine;
		}

		public DrawConnector()
		{
            //Resizeable = true;
            pointArray = new ArrayList();

			LoadCursor();
			Initialize();
		}

		public DrawConnector(int x1, int y1, int x2, int y2)
		{
            //Resizeable = true;
			pointArray = new ArrayList();
			pointArray.Add(new Point(x1, y1));
			pointArray.Add(new Point(x2, y2));
			TipText = String.Format("Start @ {0}-{1}, End @ {2}, {3}", x1, y1, x2, y2);

			LoadCursor();
			Initialize();
		}

		public DrawConnector(int x1, int y1, int x2, int y2, DrawingPens.PenType p)
		{
            //Resizeable = true;
			pointArray = new ArrayList();
			pointArray.Add(new Point(x1, y1));
			pointArray.Add(new Point(x2, y2));
			TipText = String.Format("Start @ {0}-{1}, End @ {2}, {3}", x1, y1, x2, y2);
			DrawPen = DrawingPens.SetCurrentPen(p);
			PenType = p;

			LoadCursor();
			Initialize();
		}

		public DrawConnector(int x1, int y1, int x2, int y2, Color lineColor, int lineWidth)
		{
            //Resizeable = true;
			pointArray = new ArrayList();
			pointArray.Add(new Point(x1, y1));
			pointArray.Add(new Point(x2, y2));
			TipText = String.Format("Start @ {0}-{1}, End @ {2}, {3}", x1, y1, x2, y2);
			Color = lineColor;
			PenWidth = lineWidth;

			LoadCursor();
			Initialize();
		}

		public override void Draw(Graphics g)
		{
			g.SmoothingMode = SmoothingMode.AntiAlias;
			Pen pen;

			if (DrawPen == null)
				pen = new Pen(Color, PenWidth);
			else
				pen = DrawPen.Clone() as Pen;

			Point[] pts = new Point[pointArray.Count];
			for (int i = 0; i < pointArray.Count; i++)
			{
				Point px = (Point)pointArray[i];
				pts[i] = px;
			}
			byte[] types = new byte[pointArray.Count];
			for (int i = 0; i < pointArray.Count; i++)
				types[i] = (byte)PathPointType.Line;
			GraphicsPath gp = new GraphicsPath(pts, types);
			// Rotate the path about it's center if necessary
			
			g.DrawPath(pen, gp);
			gp.Dispose();
			if (pen != null)
				pen.Dispose();
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
			if (handleNumber < 1)
				handleNumber = 1;

			if (handleNumber > pointArray.Count)
				handleNumber = pointArray.Count;
			pointArray[handleNumber - 1] = point;
			Dirty = true;
			Invalidate();
		}

        /// <summary>
        /// Invalidate object.
        /// When object is invalidated, path used for hit test
        /// is released and should be created again.
        /// </summary>
        protected void Invalidate()
        {
            if (AreaPath != null)
            {
                AreaPath.Dispose();
                AreaPath = null;
            }

            if (AreaPen != null)
            {
                AreaPen.Dispose();
                AreaPen = null;
            }

            if (AreaRegion != null)
            {
                AreaRegion.Dispose();
                AreaRegion = null;
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
		protected  void CreateObjects()
		{
			if (AreaPath != null)
				return;

			// Create closed path which contains all polygon vertexes
			AreaPath = new GraphicsPath();

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

		private void LoadCursor()
		{
			handleCursor = new Cursor(GetType(), "PolyHandle.cur");
		}
	}
}