using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Runtime.Serialization;
using System.Windows.Forms;
using System.Collections.Generic;
//using DocToolkit.Project_Objects;
using DCS.Forms;
using DCS.DCSTables;
using DCS.Tools;
using DCS.TabPages;


namespace DCS.Draw.FBD
{


    /// 
    /// <summary>
    /// Connector graphic object - a Connector is a series of connected straight lines
    ///										where each line is drawn individually and at least
    ///										one of the ends is anchored to another object
    /// </summary>
    //[Serializable]
    public class DrawWire : DrawLogic
    {
        
        // Connector-specific fields
        private const string entryLength = "Length";
        private const string entryPoint = "Point";
        private int drawingtype = 0;
        public tblFBDPinConnection tblfbdpinconnection = new tblFBDPinConnection();

        string _leftstring;
        public string Leftstring
        {
            get
            {
                return _leftstring;
            }
            set
            {
                _leftstring = value;
            }

        }

        public bool ConnectionIsOk;
        
        Point _pointArray0 = new Point();
        public Point pointArray0
        {
            get
            {
                if (LeftGuid != Guid.Empty)
                {
                    return Parentpagelist.GetFBDBoxObject(LeftGuid).GetRightPinPosition(LeftPinNo);
                }
                else
                {
                    return _pointArray0;
                }
            }
            set
            {
                _pointArray0 = value;
            }
        }
        Point _pointArray1 = new Point();
        public Point pointArray1
        {
            get
            {
                return _pointArray1;
            }
            set
            {
                _pointArray1 = value;
            }
        }
        Point _pointArray2 = new Point();
        public Point pointArray2
        {
            get
            {
                return _pointArray2;
            }
            set
            {
                _pointArray2 = value;
            }
        }
        Point _pointArray3 = new Point();
        public Point pointArray3
        {
            get
            {
                return _pointArray3;
            }
            set
            {
                _pointArray3 = value;
            }
        }
        Point _pointArray4 = new Point();
        public Point pointArray4
        {
            get
            {
                return _pointArray4;
            }
            set
            {
                _pointArray4 = value;
            }
        }
        Point _pointArray5 = new Point();
        public Point pointArray5
        {
            get
            {
                if (RightGuid != Guid.Empty)
                {
                    //return drawArea.GetLogicObject(LeftGuid).GetInputPinPosition(InputPinID);
                    return Parentpagelist.GetFBDBoxObject(RightGuid).GetLeftPinPosition(RightPinNo);
                }
                else
                {
                    return _pointArray5;
                }
                //return _pointArray5;
            }
            set
            {
                _pointArray5 = value;
            }
        }

        private Cursor handleCursor;

        Guid leftguid = Guid.Empty;
        public Guid LeftGuid
        {
            get
            {
                return leftguid;
            }
            set
            {
                leftguid = value;
            }
        }

        Guid rightguid = Guid.Empty;
        public Guid RightGuid
        {
            get
            {
                return rightguid;
            }
            set
            {
                rightguid = value;
            }
        }

        int leftpinno;
        public int LeftPinNo
        {
            get
            {
                return leftpinno;
            }
            set
            {
                leftpinno = value;
            }
        }

        int rightpinno;
        public int RightPinNo
        {
            get
            {
                return rightpinno;
            }
            set
            {
                rightpinno = value;
            }
        }


        long rightobjectsqlid = -1;
        public long RightObjectSQLID
        {
            get
            {
                return rightobjectsqlid;
            }
            set
            {
                rightobjectsqlid = value;
            }
        }
        
        //long outputobjectid = -1;
        //public long OutputObjectID
        //{
        //    get
        //    {
        //        return outputobjectid;
        //    }
        //    set
        //    {
        //        outputobjectid = value;
        //    }
        //}

 
        
        long leftobjectsqlid;
        public long LeftObjectSQLID
        {
            get
            {
                return leftobjectsqlid;
            }
            set
            {
                leftobjectsqlid = value;
            }
        }
        
        //long inputobjectid = -1;
        //public long InputObjectID
        //{
        //    get
        //    {
        //        return inputobjectid;
        //    }
        //    set
        //    {
        //        inputobjectid = value;
        //    }
        //}
        int inputpinno;
        public int InputPinNo
        {
            get
            {
                return inputpinno;
            }
            set
            {
                inputpinno = value;
            }
        }

        string inputpinname = "";
        public string InputPinName
        {
            get
            {
                return inputpinname;
            }
            set
            {
                inputpinname = value;
            }
        }

        string outputpinname = "";
        public string OutputPinName
        {
            get
            {
                return outputpinname;
            }
            set
            {

                outputpinname = value;
            }

        }

        //long inputpinid = -1;
        //public long InputPinID
        //{
        //    get
        //    {
        //        return inputpinid;
        //    }
        //    set
        //    {

        //        inputpinid = value;
        //    }
        //}

        //long outputpinid = -1;
        //public long OutputPinID
        //{
        //    get
        //    {
        //        return outputpinid;
        //    }
        //    set
        //    {

        //        outputpinid = value;
        //    }

        //}
        /// <summary>
        ///  Graphic objects for hit test
        /// </summary>
        

        

        private int startPinType = (int)VarType.UNKNOWN;
        
        public int StartPinType
        {
            get { return startPinType; }
            set { startPinType = value; }
        }
        

        private int endPinType = (int)VarType.UNKNOWN;
        public int EndPinType
        {
            get { return endPinType; }
            set { endPinType = value; }
        }
        private short startPinClass = (short)VarClass.Input;
        
        public short StartPinClass
        {
            get { return startPinClass; }
            set { startPinClass = value; }
        }
        private short endPinClass = (short)VarClass.Output;
        public short EndPinClass
        {
            get { return endPinClass; }
            set { endPinClass = value; }
        }
        bool _autodraw = false;
        public bool AutoDraw
        {
            get
            {
                return _autodraw;
            }
            set
            {
                _autodraw = value;
            }
        }


        

        /// <summary>
        /// Clone this instance
        /// </summary>
        public override DrawObject Clone()
        {
            DrawWire drawPolyLine = new DrawWire(Parentpagelist);

            //drawPolyLine.pointArray0 = pointArray0;
            drawPolyLine.pointArray1 = pointArray1;
            drawPolyLine.pointArray2 = pointArray2;
            drawPolyLine.pointArray3 = pointArray3;
            drawPolyLine.pointArray4 = pointArray4;
            //drawPolyLine.pointArray5 = pointArray5;

            FillDrawObjectFields(drawPolyLine);
            return drawPolyLine;
        }

        public DrawWire(PageList _parent)
            : base(_parent)
        {
            ShapeType = STATIC_OBJ_TYPE.ID_FBDWire;
            Resizeable = true;
            Movable = false;
            //pointArray = new ArrayList();
            //Color = lineColor;
            //PenWidth = lineWidth;
            //LoadCursor();
            tblfbdpinconnection.FBDPinConnectionID = -1;
            Initialize();
        }

        //public DrawWire(int x1, int y1, int x2, int y2)
        //{
        //    Resizeable = true;
        //    //pointArray = new ArrayList();
        //    pointArray.Add(new Point(x1, y1));
        //    pointArray.Add(new Point(x2, y2));
        //    TipText = String.Format("Start @ {0}-{1}, End @ {2}, {3}", x1, y1, x2, y2);

        //    LoadCursor();
        //    Initialize();
        //}

        //public DrawWire(int x1, int y1, int x2, int y2, DrawingPens.PenType p)
        //{
        //    Resizeable = true;
        //    //pointArray = new ArrayList();
        //    pointArray.Add(new Point(x1, y1));
        //    pointArray.Add(new Point(x2, y2));
        //    TipText = String.Format("Start @ {0}-{1}, End @ {2}, {3}", x1, y1, x2, y2);
        //    DrawPen = DrawingPens.SetCurrentPen(p);
        //    PenType = p;

        //    LoadCursor();
        //    Initialize();
        //}


        //public void DirectStartandEndPoints()
        //{
        //    int temp;
        //    VarClass tempclass;
        //    if (endPinClass == VarClass.Output)
        //    {
                
                
        //    }

        //}
        public void MoveEndPoint(int x2, int y2)
        {

            
            //endPoint.X = x2;
            //endPoint.Y = y2;


            if (pointArray0.X < x2)
            {
                Point pt = pointArray1;

                pt.X = (x2 + pointArray0.X) / 2;
                pt.Y = pointArray0.Y;
                pointArray1 = pt;
                pt = pointArray2;
                pt.X = (x2 + pointArray0.X) / 2;
                pt.Y =  y2;
                pointArray2 = pt;
                pt = pointArray3;
                pt.X = x2;
                pt.Y = y2;
                pointArray3 = pt;
                
            }
            else
            {
                Point pt = pointArray1;

                pt.X = (pointArray0.X);
                pt.Y = pointArray0.Y;
                pointArray1 = pt;
                pt = pointArray2;
                pt.X = (pointArray0.X);
                pt.Y = y2;
                pointArray2 = pt;
                pt = pointArray3;
                pt.X = x2;
                pt.Y = y2;
                pointArray3 = pt;
                
                
            }
            //Console.WriteLine("x1 = {0} y1 = {1} x2 = {0} y2 = {1}", pointArray[0].X, pointArray[0].Y,pointArray[1].X, pointArray[1].Y);
            //Console.WriteLine("x2 = {0} y2 = {1} x3 = {0} y3 = {1}", pointArray[1].X, pointArray[1].Y, pointArray[2].X, pointArray[2].Y);
            //Console.WriteLine("x3 = {0} y3 = {1} x4 = {0} y4 = {1}", pointArray[2].X, pointArray[2].Y, pointArray[3].X, pointArray[3].Y);
        }
        public DrawWire( PageList _parent, int PinType, short PinClass) : base(_parent)
        {
            ShapeType = STATIC_OBJ_TYPE.ID_FBDWire;
            ConnectionIsOk = false;
            //Resizeable = true;
            Movable = false;
            
            startPinClass=PinClass;
            startPinType = PinType;
            
            //calculateWireConections(x1, y1, x2, y2);
            //firstdraw = false;
            //TipText = String.Format("Start @ {0}-{1}, End @ {2}, {3}", x1, y1, x2, y2);
            Color = LineColor;
            //PenWidth = lineWidth;
            tblfbdpinconnection.FBDPinConnectionID = -1;
           // LoadCursor();
            Initialize();
        }

        public void UpdateWireConections()
        {
            int u = Common.BaseSize * Common.UnitSize;
            Point pt;


            
            pt = pointArray5;
            if (((pointArray0.X + u) < pointArray5.X) && (pointArray0.Y == pointArray5.Y))
            {
                pointArray1 = pt;
                pointArray2 = pt;
                pointArray3 = pt;
                pointArray4 = pt;
                drawingtype = 0;
            }
            else
            {
                if ((pointArray0.X + u) < pointArray5.X)
                {
                    pt = pointArray1;
                    pt.X = (pointArray0.X + pointArray5.X) / 2;
                    pt.Y = pointArray0.Y;
                    pointArray1 = pt;
                    pointArray2 = pt;

                    pt = pointArray3;
                    pt.X = (pointArray0.X + pointArray5.X) / 2;
                    pt.Y = pointArray5.Y;
                    pointArray3 = pt;
                    pointArray4 = pt;
                    if (pointArray0.Y > pointArray5.Y)
                    {
                        drawingtype = 1;
                    }
                    else
                    {
                        drawingtype = 2;
                    }

                }
                else
                {
                    if (pointArray0.Y == pointArray5.Y)
                    {
                        pt = pointArray1;
                        pt.X = pointArray0.X + u;
                        pt.Y = pointArray0.Y;//(pointArray0.Y + pointArray5.Y)/2
                        pointArray1 = pt;

                        pt = pointArray2;
                        pt.X = pointArray0.X + u;
                        pt.Y = pointArray0.Y + u;
                        pointArray2 = pt;

                        pt = pointArray3;
                        pt.X = pointArray5.X - u;
                        pt.Y = pointArray0.Y + u;
                        pointArray3 = pt;

                        pt = pointArray4;
                        pt.X = pointArray5.X - u;
                        pt.Y = pointArray5.Y;
                        pointArray4 = pt;
                        drawingtype = 5;

                    }
                    else
                    {
                        pt = pointArray1;
                        pt.X = pointArray0.X + u;
                        pt.Y = pointArray0.Y;//(pointArray0.Y + pointArray5.Y)/2
                        pointArray1 = pt;

                        pt = pointArray2;
                        pt.X = pointArray0.X + u;
                        pt.Y = (pointArray0.Y + pointArray5.Y) / 2;
                        pointArray2 = pt;

                        pt = pointArray3;
                        pt.X = pointArray5.X - u;
                        pt.Y = (pointArray0.Y + pointArray5.Y) / 2;
                        pointArray3 = pt;

                        pt = pointArray4;
                        pt.X = pointArray5.X - u;
                        pt.Y = pointArray5.Y;
                        pointArray4 = pt;
                        if (pointArray0.Y > pointArray5.Y)
                        {
                            drawingtype = 3;
                        }
                        else
                        {
                            drawingtype = 4;
                        }
                    }

                }
            }
        }
        public void calculateWireConections(int x1, int y1, int x2, int y2)
        //public void calculateWireConections()
        {
            int u = Common.BaseSize * Common.UnitSize;
            Point pt;
            

            _pointArray0.X = x1;
            _pointArray0.Y = y1;



            _pointArray5.X = x2;
            _pointArray5.Y = y2;
           
            pt = _pointArray5;
            if (((_pointArray0.X + u) < _pointArray5.X) && (_pointArray0.Y == _pointArray5.Y))
            {
                pointArray1 = pt;
                pointArray2 = pt;
                pointArray3 = pt;
                pointArray4 = pt;
                drawingtype = 0;
            }
            else
            {
                if ((_pointArray0.X + u) < _pointArray5.X)
                {
                    pt = pointArray1;
                    pt.X = (_pointArray0.X + _pointArray5.X) / 2;
                    pt.Y = _pointArray0.Y;
                    pointArray1 = pt;
                    pointArray2 = pt;

                    pt = pointArray3;
                    pt.X = (_pointArray0.X + _pointArray5.X) / 2;
                    pt.Y = _pointArray5.Y;
                    pointArray3 = pt;
                    pointArray4 = pt;
                    if (_pointArray0.Y > _pointArray5.Y)
                    {
                        drawingtype = 1;
                    }
                    else
                    {
                        drawingtype = 2;
                    }

                }
                else
                {
                    if (_pointArray0.Y == _pointArray5.Y)
                    {
                        pt = pointArray1;
                        pt.X = _pointArray0.X + u;
                        pt.Y = _pointArray0.Y;//(pointArray0.Y + pointArray5.Y)/2
                        pointArray1 = pt;

                        pt = pointArray2;
                        pt.X = _pointArray0.X + u;
                        pt.Y = _pointArray0.Y + u;
                        pointArray2 = pt;

                        pt = pointArray3;
                        pt.X = _pointArray5.X - u;
                        pt.Y = _pointArray0.Y + u;
                        pointArray3 = pt;

                        pt = pointArray4;
                        pt.X = _pointArray5.X - u;
                        pt.Y = _pointArray5.Y;
                        pointArray4 = pt;
                        drawingtype = 5;
                    
                    }
                    else
                    {
                        pt = pointArray1;
                        pt.X = _pointArray0.X + u;
                        pt.Y = _pointArray0.Y;//(pointArray0.Y + pointArray5.Y)/2
                        pointArray1 = pt;

                        pt = pointArray2;
                        pt.X = _pointArray0.X + u;
                        pt.Y = (_pointArray0.Y + _pointArray5.Y) / 2;
                        pointArray2 = pt;

                        pt = pointArray3;
                        pt.X = _pointArray5.X - u;
                        pt.Y = (_pointArray0.Y + _pointArray5.Y) / 2;
                        pointArray3 = pt;

                        pt = pointArray4;
                        pt.X = _pointArray5.X - u;
                        pt.Y = _pointArray5.Y;
                        pointArray4 = pt;
                        if (_pointArray0.Y > _pointArray5.Y)
                        {
                            drawingtype = 3;
                        }
                        else
                        {
                            drawingtype = 4;
                        }
                    }

                }
            }
        }
        //public void calculateWireConections(Point ptstart, Point ptend)
        //{
        //    calculateWireConections(ptstart.X,ptstart.Y,ptend.X,ptend.Y);
            
        //}
        public override void Draw(Graphics g)
        {
            try
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                Pen pen;

               // if (DrawPen == null)
                    pen = new Pen(LineColor, PenWidth);
               // else
               //     pen = DrawPen.Clone() as Pen;
                GraphicsPath gp = new GraphicsPath();
                if (ConnectionIsOk)
                {
                    switch (drawingtype)
                    {
                        case 0:
                            gp.AddLine(pointArray0, pointArray5);
                            break;
                        case 1:
                        case 2:
                            gp.AddLine(pointArray0, pointArray1);
                            gp.AddLine(pointArray2, pointArray3);
                            gp.AddLine(pointArray4, pointArray5);
                            break;
                        case 3:
                        case 4:
                        case 5:
                            gp.AddLine(pointArray0, pointArray1);
                            gp.AddLine(pointArray1, pointArray2);
                            gp.AddLine(pointArray2, pointArray3);
                            gp.AddLine(pointArray3, pointArray4);
                            gp.AddLine(pointArray4, pointArray5);
                            break;
                    }
                }
                else
                {
                    gp.AddLine(pointArray0, pointArray5);
                    //Console.WriteLine(" Draw temporary connection ");
                }
                g.DrawPath(pen, gp);
                gp.Dispose();
                if (pen != null)
                    pen.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public override void DrawTracker(Graphics g)
        {
            if (!Selected)
                return;
            SolidBrush brush = new SolidBrush(Color.Black);
            switch (drawingtype)
            {
                
                case 1:
                case 2:
                    g.FillRectangle(brush, GetHandleRectangle(1));
                    break;
                case 3:
                case 4:
                case 5:
                    g.FillRectangle(brush, GetHandleRectangle(2));
                    g.FillRectangle(brush, GetHandleRectangle(3));
                    g.FillRectangle(brush, GetHandleRectangle(4));
                    break;
            }
            brush.Dispose();
        }
       
        //public void AddPoint(Point point)
        //{
        //    pointArray.Add(point);
        //}

        public override int HandleCount
        {
            get 
            {
                return 6;// pointArray.Count; 
            }
        }

        /// <summary>
        /// Get handle point by 1-based number
        /// </summary>
        /// <param name="handleNumber"></param>
        /// <returns></returns>
        public override Point GetHandle(int handleNumber)
        {
            //if (handleNumber < 1)
            //    handleNumber = 1;
            //if (handleNumber > pointArray.Count)
            //    handleNumber = pointArray.Count;
            //return ((Point)pointArray[handleNumber - 1]);
            switch (handleNumber)
            {
                case 1:
                    return new Point(pointArray1.X, (pointArray1.Y + pointArray3.Y) / 2);
                case 2:
                    return new Point(pointArray1.X, (pointArray1.Y + pointArray2.Y) / 2);
                case 3:
                    return new Point((pointArray2.X+pointArray3.X)/2,pointArray2.Y );
                case 4:
                    return new Point(pointArray3.X, (pointArray3.Y + pointArray4.Y) / 2);
            }
            return new Point(0, 0);
        }
        /// <summary>
        /// Hit test.
        /// Return value: -1 - no hit
        ///                0 - hit over connection
        ///                1 - hit over one vertical line in wire
        ///                2 - hit over first horizental rect
        ///                3 - hit over rect in vertical connection 
        ///                4 - hit over second horizental rect
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public override int HitTest(Point point)
        {
            if (Selected)
            {
                switch (drawingtype)
                {
                    case 0:
                        if (PointInObject(point))
                        {
                            return 0;
                        }
                        break;
                    case 1:
                    case 2:
                        if (GetHandleRectangle(1).Contains(point))
                        {
                            return 1;
                        }
                        break;
                    case 3:
                    case 4:
                    case 5:
                        if (GetHandleRectangle(2).Contains(point))
                        {
                            return 2;
                        }
                        if (GetHandleRectangle(3).Contains(point))
                        {
                            return 3;
                        }
                        if (GetHandleRectangle(4).Contains(point))
                        {
                            return 4;
                        }
                        break;
                }
                
            }

            if (PointInObject(point))
                return 0;
            return -1;
        }
        /// Input value:   1 - hit over one vertical line in wire
        ///                2 - hit over first horizental rect
        ///                3 - hit over rect in vertical connection 
        ///                4 - hit over second horizental rect
        
        public override Rectangle GetHandleRectangle(int handleNumber)
        {
            int o = Common.BaseSize;
            Point pt = GetHandle(handleNumber);
            switch (handleNumber)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                    return new Rectangle(pt.X - o, pt.Y - o, 2 * o, 2 * o);
            }
            return new Rectangle();
        }
        /// <summary>
        /// Hit test.
        /// Return value: -1 - no hit
        ///                0 - hit over connection
        ///                1 - hit over one vertical line in wire
        ///                2 - hit over first horizental rect
        ///                3 - hit over rect in vertical connection 
        ///                4 - hit over second horizental rect
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        private bool CheckPointIsOverline(Point chkpoint, Point startpoint, Point endpoint)
        {
            int u = Common.BaseSize * Common.UnitSize;
            int o = Common.BaseSize*2;
            Rectangle rect = new Rectangle();
            rect.X = startpoint.X;
            rect.Y = startpoint.Y;
            rect.Width = endpoint.X - startpoint.X;
            rect.Height = endpoint.Y - startpoint.Y;
            rect.Inflate(o, o);
            return rect.Contains(chkpoint);       
        }

        protected override bool PointInObject(Point point)
        {
            //int u = Common.BaseSize * Common.UnitSize;
            //int o = Common.BaseSize ;
            
            //Rectangle rect = new Rectangle();

            switch (drawingtype)
            {
                case 0:
                    if (CheckPointIsOverline(point, pointArray0, pointArray5))
                        return true;
                    break;
                case 1:
                    if (CheckPointIsOverline(point, pointArray0, pointArray1))
                        return true;
                    if (CheckPointIsOverline(point, pointArray3, pointArray2))
                        return true;
                    if (CheckPointIsOverline(point, pointArray4, pointArray5))
                        return true;
                    break;
                case 2:
                    if (CheckPointIsOverline(point, pointArray0, pointArray1))
                        return true;
                    if (CheckPointIsOverline(point, pointArray2, pointArray3))
                        return true;
                    if (CheckPointIsOverline(point, pointArray4, pointArray5))
                        return true;
                    break;
                case 3:
                    if (CheckPointIsOverline(point, pointArray0, pointArray1))
                        return true;
                    if (CheckPointIsOverline(point, pointArray2, pointArray1))
                        return true;
                    if (CheckPointIsOverline(point, pointArray3, pointArray2))
                        return true;
                    if (CheckPointIsOverline(point, pointArray4, pointArray3))
                        return true;
                    if (CheckPointIsOverline(point, pointArray4, pointArray5))
                        return true;
                    break;
                case 4:
                    if (CheckPointIsOverline(point, pointArray0, pointArray1))
                        return true;
                    if (CheckPointIsOverline(point, pointArray1, pointArray2))
                        return true;
                    if (CheckPointIsOverline(point, pointArray3, pointArray2))
                        return true;
                    if (CheckPointIsOverline(point, pointArray3, pointArray4))
                        return true;
                    if (CheckPointIsOverline(point, pointArray4, pointArray5))
                        return true;
                    break;
                case 5:
                    if (CheckPointIsOverline(point, pointArray0, pointArray1))
                        return true;
                    if (CheckPointIsOverline(point, pointArray2, pointArray1))
                        return true;
                    if (CheckPointIsOverline(point, pointArray3, pointArray2))
                        return true;
                    if (CheckPointIsOverline(point, pointArray3, pointArray4))
                        return true;
                    if (CheckPointIsOverline(point, pointArray4, pointArray5))
                        return true;
                    break;
            }
            return false;
        }

        public override Cursor GetHandleCursor(int handleNumber)
        {
            switch (handleNumber)
            {
                
                case 3:
                    return Cursors.SizeNS;
                case 1:
                case 2:
                case 4:
                    return Cursors.SizeWE;
                default:
                    return Cursors.Default;
            }
        }

        public override void MoveHandleTo(Point point, int handleNumber)
        {
            int u = Common.BaseSize * Common.UnitSize;
            Point pt;
            //if (handleNumber < 1)
            //    handleNumber = 1;

            //if (handleNumber > pointArray.Count)
            //    handleNumber = pointArray.Count;
            switch (handleNumber)
            {
                case 0:
                    calculateWireConections(point.X, point.Y,pointArray5.X, pointArray5.Y);
                    //calculateWireConections();
                    break;
                case 1:
                    if( (point.X > (pointArray0.X + u)) && (point.X < (pointArray5.X - u)) )
                    {
                        pt = pointArray1;
                        pt.X = point.X;
                        pointArray1 = pt;
                        pointArray2 = pt;
                        pt = pointArray3;
                        pt.X = point.X;
                        pointArray3 = pt;
                        pointArray4 = pt;

                    }
                    break;
                case 2:
                    if( (point.X > (pointArray0.X + u))  )
                    {
                        pt = pointArray1;
                        pt.X = point.X;
                        pointArray1 = pt;
                        
                        pt = pointArray2;
                        pt.X = point.X;
                        pointArray2 = pt;
                        

                    }
                    break;
                case 3:
                    //if ((point.X > (pointArray0.X + u)) && (point.X < (pointArray5.X - u)))
                    {
                        pt = pointArray2;
                        pt.Y = point.Y;
                        pointArray2 = pt;
  
                        pt = pointArray3;
                        pt.Y = point.Y;
                        pointArray3 = pt;


                    }
                    break;
                case 4:
                    if( (point.X < (pointArray5.X - u))  )
                    {
                        pt = pointArray3;
                        pt.X = point.X;
                        pointArray3 = pt;
  
                        pt = pointArray4;
                        pt.X = point.X;
                        pointArray4 = pt;


                    }
                    break;
                case 5:
                    break;
                case 6:
                    calculateWireConections(pointArray0.X, pointArray0.Y, point.X, point.Y);
                    //calculateWireConections();
                    break;
            }
            
            //pointArray[handleNumber - 1] = point;
            Dirty = true;
            Invalidate();
        }
        
        public override bool IntersectsWith(Rectangle rectangle)
        {
            
            
                
                if (rectangle.Contains(pointArray0))
                    return true;
                if (rectangle.Contains(pointArray1))
                    return true;
                if (rectangle.Contains(pointArray2))
                    return true;
                if (rectangle.Contains(pointArray3))
                    return true;
                if (rectangle.Contains(pointArray4))
                    return true;
                if (rectangle.Contains(pointArray5))
                    return true;
            
            return false;
        }

        
        public override void Move(int deltaX, int deltaY)
        {
            //int n = pointArray.Count;

            //for (int i = 0; i < n; i++)
            //{
            //    Point point;
            //    point = new Point(((Point)pointArray[i]).X + deltaX, ((Point)pointArray[i]).Y + deltaY);
            //    pointArray[i] = point;
            //}
            //_pointArray0.X = _pointArray0.X + deltaX;
            //_pointArray0.Y = _pointArray0.Y + deltaY;
            //_pointArray1.X = _pointArray1.X + deltaX;
            //_pointArray1.Y = _pointArray1.Y + deltaY;
            //_pointArray2.X = _pointArray2.X + deltaX;
            //_pointArray2.Y = _pointArray2.Y + deltaY;
            //_pointArray3.X = _pointArray3.X + deltaX;
            //_pointArray3.Y = _pointArray3.Y + deltaY;
            //_pointArray4.X = _pointArray4.X + deltaX;
            //_pointArray4.Y = _pointArray4.Y + deltaY;
            //_pointArray5.X = _pointArray5.X + deltaX;
            //_pointArray5.Y = _pointArray5.Y + deltaY;
            //Dirty = true;
            //Invalidate();
        }

        //public void SetEndPolint(int x, int y)
        //{
        //    _pointArray5.X = x;
        //    _pointArray5.Y = y;
        //    UpdateWireConections();
        //}

        //public void SetStartPolint(int x, int y)
        //{
        //    _pointArray0.X = x;
        //    _pointArray0.Y = y;
        //    UpdateWireConections();
        //}
        /// <summary>
        /// Create graphic object used for hit test
        /// </summary>
        protected virtual void CreateObjects()
        {
            if (AreaPath != null)
                return;

            // Create closed path which contains all polygon vertexes
            AreaPath = new GraphicsPath();

            //int x1 = 0, y1 = 0; // previous point

            //IEnumerator enumerator = pointArray.GetEnumerator();

            //if (enumerator.MoveNext())
            //{
            //    x1 = ((Point)enumerator.Current).X;
            //    y1 = ((Point)enumerator.Current).Y;
            //}

            //while (enumerator.MoveNext())
            //{
            //    int x2, y2; // current point
            //    x2 = ((Point)enumerator.Current).X;
            //    y2 = ((Point)enumerator.Current).Y;

            //    AreaPath.AddLine(x1, y1, x2, y2);

            //    x1 = x2;
            //    y1 = y2;
            //}
            AreaPath.AddLine(pointArray0.X, pointArray0.Y, pointArray1.X, pointArray1.Y);
            AreaPath.AddLine(pointArray1.X, pointArray1.Y, pointArray2.X, pointArray2.Y);
            AreaPath.AddLine(pointArray2.X, pointArray2.Y, pointArray3.X, pointArray3.Y);
            AreaPath.AddLine(pointArray3.X, pointArray3.Y, pointArray4.X, pointArray4.Y);
            AreaPath.AddLine(pointArray4.X, pointArray4.Y, pointArray5.X, pointArray5.Y);
            AreaPath.CloseFigure();

            // Create region from the path
            AreaRegion = new Region(AreaPath);
        }

        //private void LoadCursor()
        //{
        //    try
        //    {

        //        handleCursor = new Cursor(Application.StartupPath + "\\PolyHandle.cur");
        //        //m_Cursor = new Cursor(GetType(), "Rectangle.cur");
        //    }
        //    catch (NullReferenceException e)
        //    {
        //        MessageBox.Show(e.Message.ToString());
        //    }
        //}
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

        public override bool Load(object obj)
        {
            bool ret = false;
            Dirty = false;
            tblfbdpinconnection = (tblFBDPinConnection)obj;
            SQLID = tblfbdpinconnection.FBDPinConnectionID;
            //InstanseName = tblfbdpinconnection.InstanceName;
            NewObject = false;
            //OutputObjectName = tblfbdpinconnection.OutputObjectName;
            //InputObjectName = tblfbdpinconnection.InputObjectName;
            RightObjectSQLID = tblfbdpinconnection.RightObjectID;
            LeftObjectSQLID = tblfbdpinconnection.LeftObjectID;
            RightGuid = Parentpagelist.ReturnFBDBoxGUID(RightObjectSQLID, tblfbdpinconnection.Page);
            LeftGuid = Parentpagelist.ReturnFBDBoxGUID(LeftObjectSQLID, tblfbdpinconnection.Page);
            //OutputObjectID = tblfbdpinconnection.OutputObjectID;
            //InputObjectID = tblfbdpinconnection.InputObjectID;
            RightPinNo = tblfbdpinconnection.RightPinNo;
            LeftPinNo = tblfbdpinconnection.LeftPinNo;
            //OutputPinID = tblfbdpinconnection.OutputPinID;
            //InputPinID = tblfbdpinconnection.InputPinID;
            AutoDraw = tblfbdpinconnection.autodraw;
            _pointArray0 = Parentpagelist.GetFBDBoxObject(LeftGuid).GetRightPinPosition(LeftPinNo); 
            //_pointArray0.X = tblfbdpinconnection.X0;
            //_pointArray0.Y = tblfbdpinconnection.Y0;
            _pointArray1.X = tblfbdpinconnection.X1;
            _pointArray1.Y = tblfbdpinconnection.Y1;
            _pointArray2.X = tblfbdpinconnection.X2;
            _pointArray2.Y = tblfbdpinconnection.Y2;
            _pointArray3.X = tblfbdpinconnection.X3;
            _pointArray3.Y = tblfbdpinconnection.Y3;
            _pointArray4.X = tblfbdpinconnection.X4;
            _pointArray4.Y = tblfbdpinconnection.Y4;
            _pointArray5 = Parentpagelist.GetFBDBoxObject(RightGuid).GetLeftPinPosition(RightPinNo);
            //_pointArray5.X = tblfbdpinconnection.X5;
            //_pointArray5.Y = tblfbdpinconnection.Y5;
            ConnectionIsOk = true;
            Addlinks();
            UpdateWireConections();
            //Leftstring =  drawArea.GetFBDBoxObject(LeftGuid).GetRightPinConnectionString(LeftPinNo);
            Leftstring = Parentpagelist.GetFBDBoxObject(LeftGuid).GetOutputPinExpression(LeftPinNo);
            return ret;
        }

        public override bool Save(long _id,int _pageno)
        {
            bool ret = false;
            try
            {
                tblfbdpinconnection.pouID = _id;
                tblfbdpinconnection.Page = _pageno;
                tblfbdpinconnection.RightObjectID = Parentpagelist.ReturnFBDBoxSQLID(RightGuid, tblfbdpinconnection.Page);
                tblfbdpinconnection.LeftObjectID = Parentpagelist.ReturnFBDBoxSQLID(LeftGuid, tblfbdpinconnection.Page);
                tblfbdpinconnection.RightPinNo = RightPinNo;
                tblfbdpinconnection.LeftPinNo = LeftPinNo;
                tblfbdpinconnection.autodraw = AutoDraw;
                tblfbdpinconnection.X0 = pointArray0.X;
                tblfbdpinconnection.Y0 = pointArray0.Y;
                tblfbdpinconnection.X1 = pointArray1.X;
                tblfbdpinconnection.Y1 = pointArray1.Y;
                tblfbdpinconnection.X2 = pointArray2.X;
                tblfbdpinconnection.Y2 = pointArray2.Y;
                tblfbdpinconnection.X3 = pointArray3.X;
                tblfbdpinconnection.Y3 = pointArray3.Y;
                tblfbdpinconnection.X4 = pointArray4.X;
                tblfbdpinconnection.Y4 = pointArray4.Y;
                tblfbdpinconnection.X5 = pointArray5.X;
                tblfbdpinconnection.Y5 = pointArray5.Y;

                if (tblfbdpinconnection.FBDPinConnectionID == -1)
                {
                    tblfbdpinconnection.Insert();
                    //this.SqlTableID = tblfbdpinconnection.FBDPinConnectionID;
                    NewObject = false;
                }
                else
                {
                    tblfbdpinconnection.Update();
                }
                Dirty = false;
                ret = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return ret;
        }


        private GraphicsPath areaPath = null;
        public GraphicsPath AreaPath
        {
            get { return areaPath; }
            set { areaPath = value; }
        }

        private Pen areaPen = null;
        public Pen AreaPen
        {
            get { return areaPen; }
            set { areaPen = value; }
        }

        private Region areaRegion = null;
        public Region AreaRegion
        {
            get { return areaRegion; }
            set { areaRegion = value; }
        }

        

        public void Addlinks()
        {
            Parentpagelist.GetFBDBoxObject(RightGuid).AddConnectionToPort(this.GUID, true, RightPinNo);
            Parentpagelist.GetFBDBoxObject(LeftGuid).AddConnectionToPort(this.GUID, false, LeftPinNo);
            
        }
    }
}