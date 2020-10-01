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
using DCS.TabPages;
using DCS.Forms;
using System.Security.Permissions;
using DCS;


namespace DCS.Draw
{
    public delegate void SelectedObjectChangedEventHandler(object sender, EventArgs e);
	/// <summary>
	/// Base class for all draw objects
	/// </summary>
	[Serializable]
	public abstract class DrawObject : ISerializable
	{
		#region Members

        //public Rectangle _rectangle;
        protected Rectangle _rectangle;
        public Rectangle rectangle
        {
            get
            {
                return _rectangle;
            }
            set
            {
                _rectangle = value;
            }
        }
 

		#endregion Members

		#region Properties

        private string tipText = "";

        

        private bool dirty;

        int topposition;
        [Browsable(false)]
        public int TopPosition
        {
            get
            {
                return topposition;
            }
            set
            {
                topposition = value;
            }
        }
        int leftposition;
        [Browsable(false)]
        public int LeftPosition
        {
            get
            {
                return leftposition;
            }
            set
            {
                leftposition = value;
            }
        }
        private int oindex;
        /// <summary>
        /// ZOrder is the order the objects will be drawn in - lower the ZOrder, the closer the to top the object is.
        /// </summary>
        [Browsable(false)]
        public int oIndex
        {
            get
            {
                return oindex;
            }
            set
            {
                oindex = value;
            }
        }
        private bool _resizeable;
        /// <summary>
        /// If object can be resized or has fixed size
        /// </summary>
        [Browsable(false)]
        public bool Resizeable
        {
            get { return _resizeable; }
            set { _resizeable = value; }
        }


        private LAYERS layer;
        public LAYERS Layer
        {
            get
            {
                return layer;
            }
            set
            {
                layer = value;
            }
        }


        private STATIC_OBJ_TYPE _type;

        [Browsable(false)]
        public STATIC_OBJ_TYPE ShapeType
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
            }
        }


        bool newobject = true;

        [Browsable(false)]
        public bool NewObject
        {
            get
            {
                return newobject;
            }
            set
            {
                newobject = value;
            }
        }
		

        //protected MainForm mainForm
        //{
        //    get
        //    {
        //        return pagelist.tabgraphicpagecontrol.mainForm;
        //    }
        //}

        //private Rectangle rectangle;
        //public Rectangle _rectangle;
        //{
        //    get { return rectangle; }
        //    set { rectangle = value; }
        //}
        private bool movable;
        /// <summary>
        /// If object when is selected can move to new position
        /// </summary>
        [Browsable(false)]
        public bool Movable
        {
            get
            {
                return movable;
            }
            set
            {
                movable = value; ;
            }
        }

        private Guid guid;

        [Browsable(false)]
        public Guid GUID
        {
            get
            {
                return guid;
            }
            set
            {
                guid = value;
            }
        }

        private bool lockposition;
        [Category("Format")]
        
        
        public bool LockPosition
        {
            get
            {
                return lockposition;
            }
            set
            {
                lockposition = value;
            }
        }

        private bool lockedit;
        [Category("Format")]
        
        
        public bool LockEdit
        {
            get
            {
                return lockedit;
            }
            set
            {
                lockedit = value;
            }
        }

        public System.Windows.Forms.ContextMenuStrip drawObjectctxtMenu;

        //GraphicsList Parent;
        private int _id;
        /// <summary>
        /// Object ID used for Undo Redo functions
        /// </summary>
        [Browsable(false)]
        public int ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }


        private long _sqlid;
        /// <summary>
        /// Object ID used for Undo Redo functions
        /// </summary>
        [Browsable(false)]
        public long SQLID
        {
            get
            {
                return _sqlid;
            }
            set
            {
                _sqlid = value;
            }
        }
        //private long _sqltableid = -1;
        ///// <summary>
        ///// Unique ID of Object
        ///// </summary>
        //public long SqlTableID
        //{
        //    get
        //    {
        //        return _sqltableid;
        //    }
        //    set
        //    {
        //        _sqltableid = value;
        //    }
        //}

		/// <summary>
		/// Set to true whenever the object changes
		/// </summary>
        /// 
        [Browsable(false)]
		public bool Dirty
		{
			get 
            { 
                return dirty; 
            }
			set 
            { 
                dirty = value;
            }
		}

        ///// <summary>
        ///// Draw object filled?
        ///// </summary>
        //public bool Filled
        //{
        //    get { return filled; }
        //    set { filled = value; }
        //}


        //public event SelectedObjectChangedEventHandler SelectedObjectChanged;

        //// Invoke the Changed event; called whenever list changes
        //protected virtual void OnSelectedObjectChanged(PropertyGridEventArgs e)
        //{
        //    if (SelectedObjectChanged != null)
        //        SelectedObjectChanged(this, e);
        //}

        private bool mustberemoved = false;
        /// <summary>
        /// Selection flag
        /// </summary>
        /// 

        [Browsable(false)]
        public bool MustBeRemoved
        {
            get
            {
                return mustberemoved;
            }
            set
            {
                mustberemoved = value;
            }
        }

        private bool selected;
		/// <summary>
		/// Selection flag
		/// </summary>
        /// 

        [Browsable(false)]
		public bool Selected
		{
			get 
            { 
                return selected; 
            }
			set 
            { 
                selected = value;
                if (selected)
                {
                    //PropertyGridEventArgs arg = new PropertyGridEventArgs(this, 1);
                    //OnSelectedObjectChanged(arg);
                }
            }
		}
        private bool lastrev= false;
        [Browsable(false)]
        public bool LastRev
        {
            get
            {
                return lastrev;
            }
            set
            {
                lastrev = value;
            }
        }


		/// <summary>
		/// Number of handles
		/// </summary>
        /// 
        [Browsable(false)]
		public virtual int HandleCount
		{
			get { return 0; }
		}
		/// <summary>
		/// Number of Connection Points
		/// </summary>
        /// 
        [Browsable(false)]
		public virtual int ConnectionCount
		{
			get { return 0; }
		}
        

		/// <summary>
		/// Text to display when mouse is over an object
		/// </summary>
        /// 
        [Browsable(false)]
		public string TipText
		{
			get { return tipText; }
			set { tipText = value; }
		}

		#endregion Properties
		#region Constructor

        public PageList Parentpagelist;
        public DrawObject(PageList _parent)
		{
            Parentpagelist = _parent;
            GUID = Guid.NewGuid();
			ID = GetHashCode();
            //oIndex = pagelist.GetNewobjectoIndex();
            Movable = true;
		}
		#endregion

		#region Virtual Functions
		/// <summary>
		/// Clone this instance.
		/// </summary>
		public abstract DrawObject Clone();

		/// <summary>
		/// Draw object
		/// </summary>
		/// <param name="g">Graphics object will be drawn on</param>
		public virtual void Draw(Graphics g)
		{
		}

        public virtual void ScanObjects(ref CrossReference lookup)
        {

        }

        public virtual bool Save(long _id, int _no)
        {
            return false;
        }

        public virtual bool Load(object obj)
        {
            return false;
        }
        
		#region Selection handle methods
        /// <summary>
        /// Get handle point by 1-based number
        /// </summary>
        /// <param name="handleNumber">1-based handle number to return</param>
        /// <returns>if object is Function returns pin number and pin class</returns>
        //public virtual bool GetPinInfo(int handleNumber, ref int PinNo,ref VarType PinType, ref VarClass PinClass, ref bool PinIsUsed)
        //{
        //    PinNo = -1;
        //    PinClass = VarClass.Input;
        //    PinIsUsed = true;
        //    PinType = VarType.UNKNOWN;
        //    return false;
        //}
        
		/// <summary>
		/// Get handle point by 1-based number
		/// </summary>
		/// <param name="handleNumber">1-based handle number to return</param>
		/// <returns>Point where handle is located, if found</returns>
		public virtual Point GetHandle(int handleNumber)
		{
			return new Point(0, 0);
		}

		/// <summary>
		/// Get handle rectangle by 1-based number
		/// </summary>
		/// <param name="handleNumber"></param>
		/// <returns>_rectangle structure to draw the handle</returns>
		public virtual Rectangle GetHandleRectangle(int handleNumber)
		{
			Point point = GetHandle(handleNumber);
			// Take into account width of pen
            return new Rectangle(point.X - 3, point.Y - 3, 7, 7);
		}

		/// <summary>
		/// Draw tracker for selected object
		/// </summary>
		/// <param name="g">Graphics to draw on</param>
		public virtual void DrawTracker(Graphics g)
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
		public virtual Point GetConnection(int connectionNumber)
		{
			return new Point(0, 0);
		}
		/// <summary>
		/// Get connectionPoint rectangle that defines the ellipse for the requested connection
		/// </summary>
		/// <param name="connectionNumber">0-based connection number</param>
		/// <returns>_rectangle structure to draw the connection</returns>
		public virtual Rectangle GetConnectionEllipse(int connectionNumber)
		{
			Point p = GetConnection(connectionNumber);
			// Take into account width of pen
			return new Rectangle(1,1,1,1);
		}
		public virtual void DrawConnection(Graphics g, int connectionNumber)
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
		public virtual void DrawConnections(Graphics g)
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
		public virtual int HitTest(Point point)
		{
			return -1;
		}


		/// <summary>
		/// Test whether point is inside of the object
		/// </summary>
		/// <param name="point">Point to test</param>
		/// <returns>true if in object, false if not</returns>
		protected virtual bool PointInObject(Point point)
		{
			return false;
		}


		/// <summary>
		/// Get cursor for the handle
		/// </summary>
		/// <param name="handleNumber">handle number to return cursor for</param>
		/// <returns>Cursor object</returns>
		public virtual Cursor GetHandleCursor(int handleNumber)
		{
			return Cursors.Default;
		}

		/// <summary>
		/// Test whether object intersects with rectangle
		/// </summary>
		/// <param name="rectangle">_rectangle structure to test</param>
		/// <returns>true if intersect, false if not</returns>
		public virtual bool IntersectsWith(Rectangle rectangle)
		{
			return false;
		}

		/// <summary>
		/// Move object
		/// </summary>
		/// <param name="deltaX">Distance along X-axis: (+)=Right, (-)=Left</param>
		/// <param name="deltaY">Distance along Y axis: (+)=Down, (-)=Up</param>
		public virtual void Move(int deltaX, int deltaY)
		{
            _rectangle.X += deltaX;
            _rectangle.Y += deltaY;
            //Trace.WriteLine("Move ");
            Dirty = true;
		}

        /// <summary>
        /// Move object to new position
        /// </summary>
       
        public virtual void MoveTo(int X, int Y)
        {
            _rectangle.X = X;
            _rectangle.Y = Y;
            //Trace.WriteLine("Move ");
            Dirty = true;
        }


      

        /// <summary>
        /// Get position of connection point of input pin
        /// </summary>
        /// <param name="Input Pin number"></param>
        /// <returns>pin connection point</returns>
        public virtual Point GetInputPinPosition(int pinno)
        {

            return new Point(0, 0);
        }
        /// <summary>
        /// Get position of connection point of input pin
        /// </summary>
        /// <param name="Input Pin number"></param>
        /// <returns>pin connection point</returns>
        public virtual Point GetOutpuPinPosition(int pinno)
        {

            return new Point(0, 0);
        }


        /// <summary>
        /// move connection points which are connected to this object
        /// </summary>
        /// <param name=""></param>
        public virtual void MoveLinks()
        {
        }
		/// <summary>
		/// Move handle to the point
		/// </summary>
		/// <param name="point">Point to Move Handle to</param>
		/// <param name="handleNumber">Handle number to move</param>
		public virtual void MoveHandleTo(Point point, int handleNumber)
		{
		}

		/// <summary>
		/// Dump (for debugging)
		/// </summary>
		public virtual void Dump()
		{
			//Trace.WriteLine("");
			//Trace.WriteLine(GetType().Name);
			//Trace.WriteLine("Selected = " + selected.ToString(CultureInfo.InvariantCulture));
		}

		/// <summary>
		/// Normalize object.
		/// Call this function in the end of object resizing.
		/// </summary>
		public virtual void Normalize()
		{
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
        #endregion

       
		
		#endregion Virtual Functions

		#region Other functions
		/// <summary>
		/// Initialization
		/// </summary>
		protected void Initialize()
		{
		}

        
		//		private 
		/// <summary>
		/// Copy fields from this instance to cloned instance drawObject.
		/// Called from Clone functions of derived classes.
		/// </summary>
		/// <param name="drawObject">Object being cloned</param>
		protected void FillDrawObjectFields(DrawObject drawObject)
		{
            //drawObject.selected = selected;
            //drawObject.color = color;
            //drawObject.penWidth = penWidth;
            //drawObject.ID = ID;
            //drawObject._brushType = _brushType;
            //drawObject._penType = _penType;
            //drawObject.drawBrush = drawBrush;
            //drawObject.drawpen = drawpen;
            //drawObject.fillColor = fillColor;
            //drawObject._rotation = _rotation;
            //drawObject._center = _center;
		}
		#endregion Other functions

		#region IComparable Members
		/// <summary>
		/// Returns (-1), (0), (+1) to represent the relative Z-order of the object being compared with this object
		/// </summary>
		/// <param name="obj">DrawObject that is compared to this object</param>
		/// <returns>	(-1)	if the object is less (further back) than this object.
		///				(0)	if the object is equal to this object (same level graphically).
		///				(1)	if the object is greater (closer to the front) than this object.</returns>
		public int CompareTo(object obj)
		{
			DrawObject d = obj as DrawObject;
			int x = 0;
			if (d != null)
				if (d.oIndex == oIndex)
					x = 0;
                else if (d.oIndex > oIndex)
					x = -1;
				else
					x = 1;

			return x;
		}
		#endregion IComparable Members

        protected DrawObject(SerializationInfo info, StreamingContext context)
        {
            try
            {
                if (info == null)
                    throw new ArgumentNullException("info");

                GUID = Guid.NewGuid();
                ID = GetHashCode();
                oIndex = Parentpagelist.GetNewobjectoIndex();
                //Movable = true;
                rectangle = (Rectangle)info.GetValue("Rectangle", rectangle.GetType());
                this.tipText = info.GetString("tipText");
                this.movable = info.GetBoolean("Movable");
                this._resizeable = info.GetBoolean("Resizeable");
                this.layer = (LAYERS)info.GetInt32("LAYERS");
                this._type = (STATIC_OBJ_TYPE)info.GetInt32("STATIC_OBJ_TYPE");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        protected virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Rectangle", this.rectangle);
            info.AddValue("tipText", this.tipText);
            info.AddValue("Movable", this.movable);
            info.AddValue("Resizeable", this._resizeable);
            info.AddValue("LAYERS", (int)this.layer);
            info.AddValue("STATIC_OBJ_TYPE", (int)this._type);
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException("info");

            GetObjectData(info, context);
        }

        

	}

    

        

        



    [Serializable]
    public class Book : ISerializable
    {
        private readonly string _Title;

        public Book(string title)
        {
            if (title == null)
                throw new ArgumentNullException("title");

            _Title = title;
        }

        protected Book(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException("info");

            _Title = info.GetString("Title");
        }

        public string Title
        {
            get { return _Title; }
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        protected virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Title", _Title);
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException("info");

            GetObjectData(info, context);
        }
    }

    [Serializable]
    public class LibraryBook : Book
    {
        private readonly DateTime _CheckedOut;

        public LibraryBook(string title, DateTime checkedOut)
            : base(title)
        {
            _CheckedOut = checkedOut;
        }

        protected LibraryBook(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            _CheckedOut = info.GetDateTime("CheckedOut");
        }

        public DateTime CheckedOut
        {
            get { return _CheckedOut; }
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        protected override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            info.AddValue("CheckedOut", _CheckedOut);
        }
    }
}