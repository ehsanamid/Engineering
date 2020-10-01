using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Runtime.Serialization;
using System.Windows.Forms;
//using DocToolkit.Project_Objects;
using DCS.Tools;
using System.ComponentModel;
using DockSample;
using DCS.DCSTables;
using System.Drawing.Drawing2D;
using DocToolkit;
using DCS.TabPages;


namespace DCS.Draw.FBD
{
	/// <summary>
	/// Base class for all draw objects
	/// </summary>
	[Serializable]
	public class DrawLogic : DrawObject 
	{
		#region Members
		// Object properties

        //public DrawArea drawArea;

        


       
       // private bool movable;
        
		// Last used property values (may be kept in the Registry)
		private static Color lastUsedColor = Color.Black;
		private static int lastUsedPenWidth = 1;

        //private long _pouID;
        [Browsable(false)]
        public long pouID
        {
            get
            {
                return Parentpagelist.Parenttabgraphicpagecontrol.ID;
            }
            
        }
        
        private long _ControllerID;
        [Browsable(false)]
        public long ControllerID
        {
            get
            {
                return _ControllerID;
            }
            set
            {
                _ControllerID = value;
            }
        }
		private int _rotation = 0;
		
        //private int _objectid;

        


		#endregion Members

		#region Properties
        //private Rectangle rectangle;
        //[Browsable(false)]
        //public Rectangle _rectangle;
        //{
        //    get { return rectangle; }
        //    set { rectangle = value; }
        //}

        /// <summary>
        /// If object when is selected can move to new position
        /// </summary>
        //public bool Movable
        //{
        //    get
        //    {
        //        return movable;
        //    }
        //    set
        //    {
        //        movable = value; ;
        //    }
        //}

        private bool acceptconnection;
        /// <summary>
        /// If wire or pipe can connect to this object
        /// </summary>
        /// [Browsable(false)]
        /// 
        [Browsable(false)]
        public bool AcceptConnection
        {
            get
            {
                return acceptconnection;
            }
            set
            {
                acceptconnection = value; ;
            }
        }
        

        
		/// <summary>
		/// Rotation of the object in degrees. Negative is Left, Positive is Right.
		/// </summary>
        /// 
        
		

        
        //private string _InstanseName;
        //[DisplayName("Instanse Name")]
        //[Category("Column")]
        //public string InstanseName
        //{
        //    get
        //    {
        //        try
        //        {
        //            return _InstanseName;
        //        }
        //        catch (System.Exception err)
        //        {
        //            throw new Exception("Error getting InstanseName", err);
        //        }
        //    }
        //    set
        //    {
        //        try
        //        {
        //            _InstanseName = value;
        //        }
        //        catch (System.Exception err)
        //        {
        //            throw new Exception("Error setting FunctionName", err);
        //        }
        //    }
        //}
       
		/// <summary>
		/// Fill Color
		/// </summary>
        /// 
        
        private Color fillColor = Color.Gray;
        [Browsable(false)]
		public Color FillColor
		{
			get 
            {
                if (this.Selected)
                    fillColor = Color.LightBlue;
                else
                    fillColor = Color.LightGray;
                return fillColor; 
            }
			set 
            { 
                fillColor = value; 
            }
		}

		/// <summary>
		/// Border (line) Color
		/// </summary>
        /// 
        private Color color;
        [Browsable(false)]
        public Color Color
        {
            get 
            { 
                return color; 
            }
            set 
            { 
                color = value; 
            }
        }

        private Color linecolor = Color.Black;
        [Browsable(false)]
        public Color LineColor
        {
            get
            {
                return linecolor;
            }
            set
            {
                linecolor = value;
            }
        }

        private int penWidth = 1;
        
		/// <summary>
		/// Pen width
		/// </summary>
        [Browsable(false)]
        public int PenWidth
        {
            get 
            { 
                return penWidth; 
            }
            set 
            { 
                penWidth = value; 
            }
        }
        
        
        private FillBrushes.BrushType _brushType;
        [Browsable(false)]
        public FillBrushes.BrushType BrushType
		{
			get 
            { 
                return _brushType; 
            }
			set 
            { 
                _brushType = value; 
            }
		}

        //private Brush drawBrush;
        
        ///// <summary>
        ///// Brush used to paint object
        ///// </summary>
        //[Browsable(false)]
        //public Brush DrawBrush
        //{
        //    get 
        //    { 
        //        return drawBrush; 
        //    }
        //    set 
        //    { 
        //        drawBrush = value; 
        //    }
        //}
        
        private DrawingPens.PenType _penType;
        [Browsable(false)]
        public DrawingPens.PenType PenType
		{
			get 
            { 
                return _penType; 
            }
			set 
            { 
                _penType = value; 
            }
		}

        //private Pen drawpen;
        ///// <summary>
        ///// Pen used to draw object
        ///// </summary>
        //[Browsable(false)]
        //public Pen DrawPen
        //{
        //    get 
        //    { 
        //        return drawpen; 
        //    }
        //    set 
        //    { 
        //        drawpen = value; 
        //    }
        //}

		/// <summary>
		/// Number of handles
		/// </summary>
        public override int HandleCount
		{
			get 
            { 
                return 0; 
            }
		}
		/// <summary>
		/// Number of Connection Points
		/// </summary>
		public override int ConnectionCount
		{
			get 
            { 
                return 0; 
            }
		}
		/// <summary>
		/// Last used color
		/// </summary>
        [Browsable(false)]
        public static Color LastUsedColor
		{
			get 
            { 
                return lastUsedColor; 
            }
			set 
            { 
                lastUsedColor = value; 
            }
		}

		/// <summary>
		/// Last used pen width
		/// </summary>
        [Browsable(false)]
        public static int LastUsedPenWidth
		{
			get 
            { 
                return lastUsedPenWidth; 
            }
			set 
            { 
                lastUsedPenWidth = value; 
            }
		}
        //private string tipText;
        
        ///// <summary>
        ///// Text to display when mouse is over an object
        ///// </summary>
        //[Browsable(false)]
        //public string TipText
        //{
        //    get 
        //    { 
        //        return tipText; 
        //    }
        //    set 
        //    { 
        //        tipText = value; 
        //    }
        //}

		#endregion Properties
		#region Constructor

        protected DrawLogic(PageList _parent ) : base(_parent)
		{
           // // ReSharper disable DoNotCallOverridableMethodsInConstructor
           // ID = GetHashCode();
           // ObjectID = GetHashCode();
           // Console.WriteLine("ObjectID = {0}", ObjectID);
           // //string str = this.GetType().ToString();
           //// ID = (this.GetType().ToString()).GetHashCode();
           // AcceptConnection = false;
           // Movable = true;
			// ReSharper restore DoNotCallOverridableMethodsInConstructor
		}
		#endregion

		#region Virtual Functions

        
		/// <summary>
		/// Clone this instance.
		/// </summary>

        public override DrawObject Clone()
        {
            DrawLogic drawlogic = new DrawLogic(Parentpagelist);

            return drawlogic;
        }

		/// <summary>
		/// Draw object
		/// </summary>
		/// <param name="g">Graphics object will be drawn on</param>
		public override void Draw(Graphics g)
		{
		}

		#region Selection handle methods

        

        /// <summary>
        /// Get handle point by 1-based number
        /// </summary>
        /// <param name="handleNumber">1-based handle number to return</param>
        /// <returns>if object is Function returns pin number and pin class</returns>
        public virtual bool GetPinInfo(int handleNumber,ref long PinID, ref int PinNo, ref string PinName, ref int PinType, ref short PinClass, ref bool PinIsUsed, ref string objectinstansename)
        {
            PinNo = -1;
            PinClass = (short)VarClass.Input;
            PinIsUsed = true;
            PinType = (int)VarType.UNKNOWN;
            return false;
        }
        
		/// <summary>
		/// Get handle point by 1-based number
		/// </summary>
		/// <param name="handleNumber">1-based handle number to return</param>
		/// <returns>Point where handle is located, if found</returns>
		public override  Point GetHandle(int handleNumber)
		{
			return new Point(0, 0);
		}

		/// <summary>
		/// Get handle rectangle by 1-based number
		/// </summary>
		/// <param name="handleNumber"></param>
		/// <returns>_rectangle structure to draw the handle</returns>
		public override  Rectangle GetHandleRectangle(int handleNumber)
		{
			Point point = GetHandle(handleNumber);
			// Take into account width of pen
			return new Rectangle(point.X - (penWidth + 3), point.Y - (penWidth + 3), 7 + penWidth, 7 + penWidth);
		}

		/// <summary>
		/// Draw tracker for selected object
		/// </summary>
		/// <param name="g">Graphics to draw on</param>
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
		#endregion Selection handle methods
		#region Connection Point methods
		/// <summary>
		/// Get connection point by 0-based number
		/// </summary>
		/// <param name="connectionNumber">0-based connection number to return</param>
		/// <returns>Point where connection is located, if found</returns>
		public override Point GetConnection(int connectionNumber)
		{
			return new Point(0, 0);
		}
		/// <summary>
		/// Get connectionPoint rectangle that defines the ellipse for the requested connection
		/// </summary>
		/// <param name="connectionNumber">0-based connection number</param>
		/// <returns>_rectangle structure to draw the connection</returns>
		public override Rectangle GetConnectionEllipse(int connectionNumber)
		{
			Point p = GetConnection(connectionNumber);
			// Take into account width of pen
			return new Rectangle(p.X - (penWidth + 3), p.Y - (penWidth + 3), 7 + penWidth, 7 + penWidth);
		}
		public override void DrawConnection(Graphics g, int connectionNumber)
		{
			SolidBrush b = new SolidBrush(System.Drawing.Color.Red);
			Pen p = new Pen(System.Drawing.Color.Red, -1.0f);
			g.DrawEllipse(p, GetConnectionEllipse(connectionNumber));
			g.FillEllipse(b, GetConnectionEllipse(connectionNumber));
			p.Dispose();
			b.Dispose();
		}
		/// <summary>
		/// Draws the ellipse for the connection handles on the object
		/// </summary>
		/// <param name="g">Graphics to draw on</param>
		public override void DrawConnections(Graphics g)
		{
			if (!Selected)
				return;
			SolidBrush b = new SolidBrush(System.Drawing.Color.White);
			Pen p = new Pen(System.Drawing.Color.Black, -1.0f);
			for (int i = 0; i < ConnectionCount; i++)
			{
				g.DrawEllipse(p, GetConnectionEllipse(i));
				g.FillEllipse(b, GetConnectionEllipse(i));
			}
			p.Dispose();
			b.Dispose();
		}
		#endregion Connection Point methods
		/// <summary>
		/// Hit test to determine if object is hit.
		/// </summary>
		/// <param name="point">Point to test</param>
		/// <returns>			(-1)		no hit
		///						(0)		hit anywhere
		///						(1 to n)	handle number</returns>
		public override int HitTest(Point point)
		{
			return -1;
		}


		/// <summary>
		/// Test whether point is inside of the object
		/// </summary>
		/// <param name="point">Point to test</param>
		/// <returns>true if in object, false if not</returns>
		protected override bool PointInObject(Point point)
		{
			return false;
		}


		/// <summary>
		/// Get cursor for the handle
		/// </summary>
		/// <param name="handleNumber">handle number to return cursor for</param>
		/// <returns>Cursor object</returns>
		public override Cursor GetHandleCursor(int handleNumber)
		{
			return Cursors.Default;
		}

		/// <summary>
		/// Test whether object intersects with rectangle
		/// </summary>
		/// <param name="rectangle">_rectangle structure to test</param>
		/// <returns>true if intersect, false if not</returns>
		public override bool IntersectsWith(Rectangle rectangle)
		{
			return false;
		}

		/// <summary>
		/// Move object
		/// </summary>
		/// <param name="deltaX">Distance along X-axis: (+)=Right, (-)=Left</param>
		/// <param name="deltaY">Distance along Y axis: (+)=Down, (-)=Up</param>
		public override void Move(int deltaX, int deltaY)
		{
		}
        /// <summary>
        /// Get position of connection point of input pin
        /// </summary>
        /// <param name="Input Pin number"></param>
        /// <returns>pin connection point</returns>
        //public override Point GetInputPinPosition(int pinno)
        //{

        //    return new Point(0, 0);
        //}
        ///// <summary>
        ///// Get position of connection point of input pin
        ///// </summary>
        ///// <param name="Input Pin number"></param>
        ///// <returns>pin connection point</returns>
        //public override Point GetOutpuPinPosition(int pinno)
        //{

        //    return new Point(0, 0);
        //}


        /// <summary>
        /// move connection points which are connected to this object
        /// </summary>
        /// <param name=""></param>
        public override void MoveLinks()
        {
        }
		/// <summary>
		/// Move handle to the point
		/// </summary>
		/// <param name="point">Point to Move Handle to</param>
		/// <param name="handleNumber">Handle number to move</param>
		public override void MoveHandleTo(Point point, int handleNumber)
		{
		}

		/// <summary>
		/// Dump (for debugging)
		/// </summary>
		public override void Dump()
		{
			//Trace.WriteLine("");
			//Trace.WriteLine(GetType().Name);
			//Trace.WriteLine("Selected = " + selected.ToString(CultureInfo.InvariantCulture));
		}

		

        
		
		#endregion Virtual Functions

		#region Other functions
		/// <summary>
		/// Initialization
		/// </summary>
		

        public void makeBoarderDashStyle(DashStyle BoarderDashStyle, int BoarderWidth,int BoarderLinePaternScale,ref float[] cuspat )
        {
            switch (BoarderDashStyle)
            {
                case DashStyle.Dot:
                    cuspat = new float[4];
                    cuspat[0] = BoarderWidth * BoarderLinePaternScale;
                    cuspat[1] = BoarderWidth * BoarderLinePaternScale;
                    cuspat[2] = BoarderWidth * BoarderLinePaternScale;
                    cuspat[3] = BoarderWidth * BoarderLinePaternScale;
                    break;
                case DashStyle.DashDotDot:
                    cuspat = new float[6];
                    cuspat[0] = BoarderWidth * BoarderLinePaternScale * 5;
                    cuspat[1] = BoarderWidth * BoarderLinePaternScale;
                    cuspat[2] = BoarderWidth * BoarderLinePaternScale;
                    cuspat[3] = BoarderWidth * BoarderLinePaternScale;
                    cuspat[4] = BoarderWidth * BoarderLinePaternScale;
                    cuspat[5] = BoarderWidth * BoarderLinePaternScale;
                    break;
                case DashStyle.DashDot:
                    cuspat = new float[4];
                    cuspat[0] = BoarderWidth * BoarderLinePaternScale * 5;
                    cuspat[1] = BoarderWidth * BoarderLinePaternScale;
                    cuspat[2] = BoarderWidth * BoarderLinePaternScale;
                    cuspat[3] = BoarderWidth * BoarderLinePaternScale;
                    break;
                case DashStyle.Dash:
                    cuspat = new float[2];
                    cuspat[0] = BoarderWidth * BoarderLinePaternScale * 5;
                    cuspat[1] = BoarderWidth * BoarderLinePaternScale;
                    break;
            }
        }

        //public Pen MakePen(Color _color, int _boarderwidth, DashStyle _boarderdashstyle, float[] cuspat)
        //{
        //    Pen pen = new Pen(_color, _boarderwidth);

        //    switch (_boarderdashstyle)
        //    {
                
        //        case DashStyle.Dot:
        //        case DashStyle.DashDotDot:
        //        case DashStyle.DashDot:
        //        case DashStyle.Dash:
        //            pen.DashPattern = cuspat;
        //            break;
        //        default :
        //            pen.DashStyle = DashStyle.Solid; ;
        //            break;
        //    }
        //    return pen;
        //}


        public void SelecactiveColor(bool BoarderBlinking, Color BoarderColor1, Color BoarderColor2, ref Color bcolor)
        {
           
            if (Common.Blinking && BoarderBlinking)
            {
                bcolor = BoarderColor2;
            }
            else
            {
                bcolor = BoarderColor1;
            }

            
        }

        public void SelecactiveColor(bool BoarderBlinking, Color BoarderColor1, Color BoarderColor2, bool Blinking, int FillType, Color FillColor11, Color FillColor12, Color FillColor21, Color FillColor22, ref Color bcolor, ref Color fColor1, ref Color fColor2)
        {

            if (Common.Blinking && BoarderBlinking)
            {
                bcolor = BoarderColor2;
            }
            else
            {
                bcolor = BoarderColor1;
            }

            switch (FillType)
            {
                case 0:
                    break;
                case 1:

                    //Brush b;
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
        }
		//		private 
		/// <summary>
		/// Copy fields from this instance to cloned instance drawObject.
		/// Called from Clone functions of derived classes.
		/// </summary>
		/// <param name="drawObject">Object being cloned</param>
		protected void FillDrawObjectFields(DrawLogic drawObject)
		{
			drawObject.Selected = Selected;
			drawObject.color = color;
			drawObject.penWidth = penWidth;
			drawObject.ID = ID;
			drawObject._brushType = _brushType;
			drawObject._penType = _penType;
			//drawObject.drawBrush = drawBrush;
			//drawObject.drawpen = drawpen;
			drawObject.fillColor = fillColor;
			drawObject._rotation = _rotation;
			//drawObject._center = _center;
		}
		#endregion Other functions

		
	}
}