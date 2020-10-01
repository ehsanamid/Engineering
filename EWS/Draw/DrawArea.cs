using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

using DocToolkit;
using DCS.Forms;
//using DocToolkit.Project_Objects;
using DockSample;
using System.Diagnostics;

using System.Collections.Generic;
using DCS.DCSTables;
using DCS.Tools;
using DCS.Draw;
using DCS.Draw.FBD;
using System.Drawing.Printing;
using DCS.TabPages;

namespace DCS.Draw
{
    /// <summary>
    /// Working area.
    /// Handles mouse input and draws graphics objects.
    /// </summary>
    public partial class DrawArea : UserControl
    {
        //public DrawingDoc parent;

        #region Members

        //public List<DeleteListStruc> DeleteList = new List<DeleteListStruc>();
        PageSetupDialog PageSetupDialog1 = new PageSetupDialog();
        PrintDocument printdoc1 = new PrintDocument();
        PrintPreviewDialog previewdlg = new PrintPreviewDialog();
        PrintDialog PrintDialog1 = new PrintDialog();

        private Color _drawareaBackgroundcolor;


        private float _zoom = 1.0f;
        private float _rotation = 0f;
        private int _panX = 0;
        private int _panY;
        private int _originalPanY;
        private bool _panning = false;
        private Point lastPoint;
        private Color _lineColor = Color.Black;
        private Color _fillColor = Color.White;
        private bool _drawFilled = false;
        private int _lineWidth = -1;
        //private Pen _currentPen;
        private DrawingPens.PenType _penType;
        //private Brush _currentBrush;
        private FillBrushes.BrushType _brushType;

        // Define the Layers collection
        //private Layers _layers;
        /// <summary>
        /// List of Graphic objects (derived from <see cref="DrawObject"/>) contained by this <see cref="Layer"/>
        /// </summary>

        
        public DrawWire tempobject;

        private DrawToolType activeTool; // active drawing tool
        private Tool[] tools; // array of tools

        private Rectangle netRectangle;
        private bool drawNetRectangle = false;


        
        #endregion Members

        TabGraphicPageControl parentTabGraphicPageControl;
        public TabGraphicPageControl ParentTabGraphicPageControl
        {
            get
            {
                return parentTabGraphicPageControl;
            }
            set
            {
                parentTabGraphicPageControl = value;
            }

        }

        //private PageList _pages;
        public int ActivePageNo
        {
            get
            {
                return parentTabGraphicPageControl.GetActivePageNo();
            }
            set
            {
                parentTabGraphicPageControl.SetActivePageNo(value);
            }
        }

#if OWSAPP
        void ScanObjects(ref CrossReference lookup)
        {
            parentTabGraphicPageControl.ScanObjects(ref lookup);
        } 
#endif

        void DrawControl(Graphics g)
        {
            parentTabGraphicPageControl.DrawControl(g);
        }
        //}

        public int NoOfPages
        {
            get
            {
                return parentTabGraphicPageControl.NoOfObjectsinPage;
            }
           
        }

        public PageList Pages
        {
            get
            {
                return parentTabGraphicPageControl.Pages();
            }

        }

        public void AddnewObject(DrawObject o)
        {
            parentTabGraphicPageControl.AddnewObject(o);
        }
        public void UnselectAll()
        {
            parentTabGraphicPageControl.UnselectAll();
        }
        
        #region Constructor, Dispose


        public void PrintDrawArea()
        {
           
            PaperSize p = null;
            bool _tempshowgrid = ShowGrid;
            ShowGrid = false;
            foreach (PaperSize ps in printdoc1.PrinterSettings.PaperSizes)
            {
                if (ps.PaperName.Equals("A3"))
                    p = ps;
            }

            printdoc1.DefaultPageSettings.PaperSize = p;
            printdoc1.OriginAtMargins = true;
            printdoc1.DefaultPageSettings.Landscape = true;
            Margins margins = new Margins(100, 100, 100, 100);
            printdoc1.DefaultPageSettings.Margins = margins;
            int pgno = ActivePageNo;
            ActivePageNo = 0;
            printdoc1.Print();
            ActivePageNo = pgno;
            ShowGrid = _tempshowgrid;
            
        }

        //public void GetPrintArea(Panel pnl)
        //{
        //    MemoryImage = new Bitmap(pnl.Width, pnl.Height);
        //    Rectangle rect = new Rectangle(0, 0, pnl.Width, pnl.Height);
        //    pnl.DrawToBitmap(MemoryImage, new Rectangle(0, 0, pnl.Width, pnl.Height));
        //}
        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    e.Graphics.DrawImage(MemoryImage, 0, 0);
        //    base.OnPaint(e);
        //}

        void PrintOnePage(PrintPageEventArgs e)
        {
            e.Graphics.DrawString("test", new Font("Arial", 7), new SolidBrush(Color.Black), 0, 0);
            Matrix mx = new Matrix();
            mx.Translate(-ClientSize.Width / 2f, -ClientSize.Height / 2f, MatrixOrder.Append);
            mx.Rotate(_rotation, MatrixOrder.Append);
            mx.Translate(ClientSize.Width / 2f + _panX, ClientSize.Height / 2f + _panY, MatrixOrder.Append);
            mx.Scale(_zoom, _zoom, MatrixOrder.Append);
            e.Graphics.Transform = mx;
            Point centerRectangle = new Point();
            centerRectangle.X = ClientRectangle.Left + ClientRectangle.Width / 2;
            centerRectangle.Y = ClientRectangle.Top + ClientRectangle.Height / 2;
            centerRectangle = BackTrackMouse(centerRectangle);

            SolidBrush brush = new SolidBrush(DraeAreaBackgroundColor);

            DrawArea_PaintGrid(e.Graphics);
            e.Graphics.FillRectangle(brush, ClientRectangle);

            DrawControl(e.Graphics);

            //if (tempobject != null)
            //{
            //    tempobject.Draw(e.Graphics);
            //}
            DrawNetSelection(e.Graphics);
            brush.Dispose();
        }


        void printdoc1_PrintPage(object sender, PrintPageEventArgs e)
        {
            //int pgno ;

            //for (int i = 0; i < Pages.Count; i++)
            //{
            //    PageNo = i;
                PrintOnePage(e);
                if (ActivePageNo  < NoOfPages - 1)
                {
                    ActivePageNo++;
                    e.HasMorePages = true;
                    //break;
                }
                else
                {
                    e.HasMorePages = false;
                }
            //}
            //PageNo = pgno;
        }

        
        public DrawArea(TabGraphicPageControl _parent)
        {
            printdoc1.PrintPage += new PrintPageEventHandler(printdoc1_PrintPage);
            PageSetupDialog1.PageSettings = new System.Drawing.Printing.PageSettings();
            PageSetupDialog1.PageSettings.PaperSize = new PaperSize();
            PageSetupDialog1.PageSettings.PaperSize.RawKind = (int)PaperKind.A3;
            PageSetupDialog1.PageSettings.Landscape = true;
            PageSetupDialog1.PrinterSettings = new System.Drawing.Printing.PrinterSettings();
            PageSetupDialog1.ShowNetwork = false;

            parentTabGraphicPageControl = _parent;
            // create list of Layers, with one default active visible layer
            //parent = null;
            //ActivePageNo = 0;
            //_pages = new PageList(this);


            //graphicsList = new List<GraphicsList>();
            //graphicsList.Add(new GraphicsList(this));

            _panning = false;
            _panX = 0;
            _panY = 0;
            SnapEnable = true;
            ShowGrid = true;
            SnapX = Common.BaseSize * Common.UnitSize;//30
            SnapY = Common.BaseSize * Common.UnitSize;//30
            GridX = Common.BaseSize * Common.UnitSize;//30
            GridY = Common.BaseSize * Common.UnitSize;//30
            this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.DrawArea_MouseWheel);
            
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();
            //DrawImage o = new DrawImage(0, 0);
            //DrawTools.ToolObject.AddNewObject(this, new DrawImage(0, 0));

        }
        #endregion Constructor, Dispose


       
        #region Enumerations
        public enum DrawToolType
        {
            Pointer,
            Rectangle,
            Ellipse,
            Line,
            PolyLine,
            Polygon,
            Text,
            Image,
            Connector,
            Variable,
            Function,
            FunctionBlock,
            Wire,
            Comment,
            Constant,
            Curve,
            NumberOfDrawTools
        } ;
        #endregion Enumerations

      

        

        

        #region Properties

        //public List<DeleteListStruc> DeleteList
        //{
        //    get
        //    {
        //        return ParentTabGraphicPageControl.DeleteList;
        //    }
        //}
        
        //private long id;
        public long ID
        {
            get
            {
                return parentTabGraphicPageControl.ID;
            }
            //set
            //{
            //    id = value;
            //}
        }

        

        /// <summary>
        /// Background color of Drawing Area
        /// </summary>
        public Color DraeAreaBackgroundColor
        {
            get { return _drawareaBackgroundcolor; }
            set { _drawareaBackgroundcolor = value; }
        }
        
        private bool _snapenable;
        /// <summary>
        /// Enable Snap
        /// </summary>
        public bool SnapEnable
        {
            get
            {
                return _snapenable;
            }
            set
            {
                //switch (_pagetype)
                //{
                //    case DrawAreaType.FBD:
                //        break;
                //    default:
                //        _snapenable = value;
                //        break;
                //}
                _snapenable = value;
                
            }
        }
        private bool _showgrid;
        /// <summary>
        /// Show Grid Lines
        /// </summary>
        public bool ShowGrid
        {
            get
            {
                return _showgrid;
            }
            set
            {
                _showgrid = value;
            }
        }
        private int _snapx;
        
        /// <summary>
        /// vertical snap size
        /// </summary>
        public int SnapX
        {
            get
            {
                try
                {
                    return _snapx;
                }
                catch (System.Exception err)
                {
                    throw new Exception("Error getting Snap X", err);
                }
            }
            set
            {
                try
                {
                    if ((value >= 1))
                    {
                        //switch (_pagetype)
                        //{
                        //    case DrawAreaType.FBD:
                        //        break;
                        //    default:
                        //        _snapx = value;
                        //        break;
                        //}
                        _snapx = value; 
                    }
                    else
                    {
                        throw new OverflowException("Error setting Snap X, Length of value must be more than 1. Minimum value : 2");
                    }
                }
                catch (System.Exception err)
                {
                    throw new Exception("Error setting Snap X", err);
                }
            }
        }
        private int _snapy;
        
        /// <summary>
        /// horizental snap size
        /// </summary>
        public int SnapY
        {
            
            get
            {
                try
                {
                    return _snapy;
                }
                catch (System.Exception err)
                {
                    throw new Exception("Error getting Snap Y", err);
                }
            }
            set
            {
                try
                {
                    if ((value >= 1))
                    {
                        //switch (_pagetype)
                        //{
                        //    case DrawAreaType.FBD:
                        //        break;
                        //    default:
                        //        _snapy = value;
                        //        break;
                        //}
                        _snapy = value;
                    }
                    else
                    {
                        throw new OverflowException("Error setting Snap Y, Length of value must be more than 1. Minimum value : 2");
                    }
                }
                catch (System.Exception err)
                {
                    throw new Exception("Error setting Snap Y", err);
                }
            }
        }
        private int _gridx;
        
        /// <summary>
        /// vertical grid size
        /// </summary>
        public int GridX
        {
            get
            {
                return _gridx;
            }
            set
            {
                _gridx = value;
            }
        }
        private int _gridy;
        /// <summary>
        /// horizental grid size
        /// </summary>
        public int GridY
        {
            get
            {
                return _gridy;
            }
            set
            {
                _gridy = value;
            }
        }


        /// <summary>
        /// Allow tools and objects to see the type of brush set
        /// </summary>
        public FillBrushes.BrushType BrushType
        {
            get { return _brushType; }
            set { _brushType = value; }
        }

        //public Brush CurrentBrush
        //{
        //    get { return _currentBrush; }
        //    set { _currentBrush = value; }
        //}

        /// <summary>
        /// Allow tools and objects to see the type of pen set
        /// </summary>
        public DrawingPens.PenType PenType
        {
            get { return _penType; }
            set { _penType = value; }
        }

        /// <summary>
        /// Current Drawing Pen
        /// </summary>
        //public Pen CurrentPen
        //{
        //    get { return _currentPen; }
        //    set { _currentPen = value; }
        //}

        /// <summary>
        /// Current Line Width
        /// </summary>
        public int LineWidth
        {
            get { return _lineWidth; }
            set { _lineWidth = value; }
        }

        /// <summary>
        /// Flag determines if objects will be drawn filled or not
        /// </summary>
        public bool DrawFilled
        {
            get { return _drawFilled; }
            set { _drawFilled = value; }
        }

        /// <summary>
        /// Color to draw filled objects with
        /// </summary>
        public Color FillColor
        {
            get { return _fillColor; }
            set { _fillColor = value; }
        }

        /// <summary>
        /// Color for drawing lines
        /// </summary>
        public Color LineColor
        {
            get { return _lineColor; }
            set { _lineColor = value; }
        }

        /// <summary>
        /// Original Y position - used when panning
        /// </summary>
        public int OriginalPanY
        {
            get { return _originalPanY; }
            set { _originalPanY = value; }
        }

        /// <summary>
        /// Flag is true if panning active
        /// </summary>
        public bool Panning
        {
            get { return _panning; }
            set { _panning = value; }
        }

        /// <summary>
        /// Current pan offset along X-axis
        /// </summary>
        public int PanX
        {
            get { return _panX; }
            set { _panX = value; }
        }

        /// <summary>
        /// Current pan offset along Y-axis
        /// </summary>
        public int PanY
        {
            get { return _panY; }
            set { _panY = value; }
        }

        /// <summary>
        /// Degrees of rotation of the drawing
        /// </summary>
        public float Rotation
        {
            get { return _rotation; }
            set { _rotation = value; }
        }

        /// <summary>
        /// Current Zoom factor
        /// </summary>
        public float Zoom
        {
            get { return _zoom; }
            set { _zoom = value; }
        }

        /// <summary>
        /// Group selection rectangle. Used for drawing.
        /// </summary>
        public Rectangle NetRectangle
        {
            get { return netRectangle; }
            set { netRectangle = value; }
        }

        /// <summary>
        /// Flag is set to true if group selection rectangle should be drawn.
        /// </summary>
        public bool DrawNetRectangle
        {
            get { return drawNetRectangle; }
            set { drawNetRectangle = value; }
        }

        /// <summary>
        /// Reference to the owner form
        /// </summary>
        //public MainForm Owner
        //{
        //    get { return owner; }
        //    set { owner = value; }
        //}


        // Information about owner form
        //private MainForm mainewsform;
        /// <summary>
        /// 
        /// Reference to the owner form
        /// </summary>
        //public MainForm mainEWSForm
        //{
        //    get 
        //    {
        //        return parentTabGraphicPageControl.mainForm; 
        //    }
            
        //}

        /// <summary>
        /// Reference to DocManager
        /// </summary>
        //public DocManager DocManager
        //{
        //    get { return docManager; }
        //    set { docManager = value; }
        //}

        /// <summary>
        /// Active drawing tool.
        /// </summary>
        public DrawToolType ActiveTool
        {
            get { return activeTool; }
            set { activeTool = value; }
        }

        

        
        #endregion

        #region Event Handlers
        /// <summary>
        /// Draw graphic objects and group selection rectangle (optionally)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawArea_Paint(object sender, PaintEventArgs e)
        {
            //Trace.WriteLine("DrawArea_Paint");
            Matrix mx = new Matrix();
            mx.Translate(-ClientSize.Width / 2f, -ClientSize.Height / 2f, MatrixOrder.Append);
            mx.Rotate(_rotation, MatrixOrder.Append);
            mx.Translate(ClientSize.Width / 2f + _panX, ClientSize.Height / 2f + _panY, MatrixOrder.Append);
            mx.Scale(_zoom, _zoom, MatrixOrder.Append);
            e.Graphics.Transform = mx;
            // Determine center of ClientRectangle
            Point centerRectangle = new Point();
            centerRectangle.X = ClientRectangle.Left + ClientRectangle.Width / 2;
            centerRectangle.Y = ClientRectangle.Top + ClientRectangle.Height / 2;
            // Get true center point
            centerRectangle = BackTrackMouse(centerRectangle);
            // Determine offset from current mouse position

            SolidBrush brush = new SolidBrush(DraeAreaBackgroundColor);

            DrawArea_PaintGrid(e.Graphics);
            e.Graphics.FillRectangle(brush, ClientRectangle);

            DrawControl(e.Graphics);
            
            if (tempobject != null)
            {
                tempobject.Draw(e.Graphics);
            }
           

            DrawNetSelection(e.Graphics);
            
            
            
            brush.Dispose();

            
        }

        private void DrawArea_PaintGrid(Graphics g)
        {

            
           // Trace.WriteLine("DrawArea_PaintGid");

            if (ShowGrid)
            {
                int width = this.Width;
                int height = this.Height;
                int i;
                Pen blackPen = new Pen(Color.Black, 1);
                //blackPen.DashStyle = DashStyle.DashDotDot;
                blackPen.DashPattern = new float[] { 1.0F, 7.0F, 1.0F, 7.0F };
                blackPen.Width = 1;
                // Create points that define line.
                i = 1;
                while (i * GridY < height)
                {
                    // Draw line to screen.
                    g.DrawLine(blackPen, 0, i * GridY, width, i * GridY);
                    i++;
                }
                i = 1;
                while (i * GridX < width)
                {
                    // Draw line to screen.
                    g.DrawLine(blackPen, i * GridX, 0, i * GridX, height);
                    i++;
                }
            }


            //brush.Dispose();


        }

        /// <summary>
        /// Back Track the Mouse to return accurate coordinates regardless of zoom or pan effects.
        /// Courtesy of BobPowell.net <seealso cref="http://www.bobpowell.net/backtrack.htm"/>
        /// </summary>
        /// <param name="p">Point to backtrack</param>
        /// <returns>Backtracked point</returns>
        public Point BackTrackMouse(Point p)
        {
            // Backtrack the mouse...
            Point[] pts = new Point[] { p };
            Matrix mx = new Matrix();
            mx.Translate(-ClientSize.Width / 2f, -ClientSize.Height / 2f, MatrixOrder.Append);
            mx.Rotate(_rotation, MatrixOrder.Append);
            mx.Translate(ClientSize.Width / 2f + _panX, ClientSize.Height / 2f + _panY, MatrixOrder.Append);
            mx.Scale(_zoom, _zoom, MatrixOrder.Append);
            mx.Invert();
            mx.TransformPoints(pts);
            return pts[0];
        }

        /// <summary>
        /// adjust positio with snap size 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="snapVal"></param>
        public int FittoSnap(int x,int snapVal)
        {
            if(x % snapVal >= snapVal/2)
            {
                return x + snapVal - (x % snapVal);
            }
            else
            {
                return x - (x % snapVal);
            }
        }


        /// <summary>
        /// Mouse down.
        /// Left button down event is passed to active tool.
        /// Right button down event is handled in this class.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawArea_MouseDown(object sender, MouseEventArgs e)
        {

            //Trace.WriteLine("DrawArea_MouseDown");
            lastPoint = BackTrackMouse(e.Location);
            if (SnapEnable)
            {
                lastPoint.X = FittoSnap(e.X, SnapX);
                lastPoint.Y = FittoSnap(e.Y, SnapY);
            }
           // Trace.WriteLine("DrawArea_MouseDown1");
            if (e.Button == MouseButtons.Left)
            {
                tools[(int)activeTool].OnMouseDown(this, e);
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (_panning)
                {
                    _panning = false;
                }
                if (activeTool == DrawToolType.PolyLine || activeTool == DrawToolType.Polygon || activeTool == DrawToolType.Curve)
                {
                    tools[(int)activeTool].OnMouseDown(this, e);
                    ActiveTool = DrawToolType.Pointer;
                }
                else
                {
                    ActiveTool = DrawToolType.Pointer;
                    OnContextMenu(e);
                }
            }
            //Trace.WriteLine("DrawArea_MouseDown End");
        }

        //        else if (e.Button == MouseButtons.Right)
        //{
        //if (_panning == true)
        //_panning = false; 

        //if (activeTool == DrawToolType.PolyLine)
        //tools[(int)activeTool].OnMouseDown(this, e);

        //ActiveTool = TETemplateDrawArea.DrawToolType.Pointer;
        //}

        /// <summary>
        /// Mouse move.
        /// Moving without button pressed or with left button pressed
        /// is passed to active tool.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawArea_MouseMove(object sender, MouseEventArgs e)
        {
           // Trace.WriteLine("DrawArea_MouseMove");
           // Console.WriteLine(" e.x = {0} e.y = {1} Cursorsize {2}", e.X, e.Y,Cursor.Size);
            Point curLoc = BackTrackMouse(e.Location);
            //if (SnapEnable)
            //{
            //    curLoc.X = FittoSnap(e.X, SnapX);
            //    curLoc.Y = FittoSnap(e.Y, SnapY);
            //}
            //Trace.WriteLine("DrawArea_MouseMove1");
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.None)
            {
                if (e.Button == MouseButtons.Left && _panning)
                {
                    Trace.WriteLine("DrawArea_MouseMove1.1");
                    if (curLoc.X != lastPoint.X)
                        _panX += curLoc.X - lastPoint.X;
                    if (curLoc.Y != lastPoint.Y)
                        _panY += curLoc.Y - lastPoint.Y;
                   // Trace.WriteLine("DrawArea_MouseMove1.5");
                    Invalidate();
                    //Trace.WriteLine("DrawArea_MouseMove2");
                }
                else
                {
                    //Trace.WriteLine("DrawArea_MouseMove4 " + activeTool.ToString());
                    tools[(int)activeTool].OnMouseMove(this, e);
                   // Trace.WriteLine("DrawArea_MouseMove5");
                }
            }
            else
            {
                Cursor = Cursors.Default;
            }
            //Trace.WriteLine("DrawArea_MouseMove6");
            lastPoint = BackTrackMouse(e.Location);
            if (SnapEnable)
            {
                lastPoint.X = FittoSnap(e.X, SnapX);
                lastPoint.Y = FittoSnap(e.Y, SnapY);
            }
            //Trace.WriteLine("DrawArea_MouseMove end");
        }

        /// <summary>
        /// Mouse up event.
        /// Left button up event is passed to active tool.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawArea_MouseUp(object sender, MouseEventArgs e)
        {
           // Trace.WriteLine("DrawArea_MouseUp");
            //lastPoint = BackTrackMouse(e.Location);
            if (e.Button ==
              MouseButtons.Left)
            {
                //this.AddCommandToHistory(new CommandAdd(this.Graphics[0]));
                tools[(int)activeTool].OnMouseUp(this, e);
            }
        }
        #endregion

        #region Other Functions
        /// <summary>
        

        public void Initialize(/*MainForm owner, DocManager docManager*/)
        {

            SetStyle(ControlStyles.AllPaintingInWmPaint |
                 ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            Invalidate();

            // Keep reference to owner form
            //mainEWSForm = owner;
            //DocManager = docManager;

            // set default tool
            activeTool = DrawToolType.Pointer;

            // Create undo manager
            

            // create array of drawing tools

            

            tools = new Tool[(int)DrawToolType.NumberOfDrawTools];
            tools[(int)DrawToolType.Pointer] = new ToolPointer();
#if EWSAPP
            tools[(int)DrawToolType.Rectangle] = new ToolRectangle();
            tools[(int)DrawToolType.Ellipse] = new ToolEllipse();
            tools[(int)DrawToolType.Line] = new ToolLine();
            tools[(int)DrawToolType.PolyLine] = new ToolPolyLine();
            tools[(int)DrawToolType.Text] = new ToolText();
            tools[(int)DrawToolType.Polygon] = new ToolPolygon();
            tools[(int)DrawToolType.Image] = new ToolImage();
            tools[(int)DrawToolType.Variable] = new ToolVariable();
            tools[(int)DrawToolType.Function] = new ToolFunction(true);
            tools[(int)DrawToolType.FunctionBlock] = new ToolFunction(false);
            tools[(int)DrawToolType.Wire] = new ToolWire();
            tools[(int)DrawToolType.Constant] = new ToolConstant();
            tools[(int)DrawToolType.Comment] = new ToolConstant();
            tools[(int)DrawToolType.Curve] = new ToolCurve(); 
#endif
            LineColor = Color.Black;
            FillColor = Color.White;
            LineWidth = -1;
        }

        /// <summary>
        /// Add command to history.
        /// </summary>
        
        /// <summary>
        ///  Draw group selection rectangle
        /// </summary>
        /// <param name="g"></param>
        public void DrawNetSelection(Graphics g)
        {
            if (!DrawNetRectangle)
                return;

            ControlPaint.DrawFocusRectangle(g, NetRectangle, Color.Black, Color.Transparent);
        }
        
        /// <summary>
        /// Right-click handler
        /// </summary>
        /// <param name="e"></param>
        private void OnContextMenu(MouseEventArgs e)
        {
            // Change current selection if necessary

#if EWSAPP
            Point point = BackTrackMouse(new Point(e.X, e.Y));
            Point menuPoint = new Point(e.X, e.Y);
            if (this.parentTabGraphicPageControl.ContextMenuDrawArea(point))
            {

                Refresh();
                //ContextMenu mnuContextMenu = new ContextMenu();
                //MenuItem CopyMenuItem = new MenuItem("Copy");
                //MenuItem DeleteMenuItem = new MenuItem("Delete");
                //MenuItem PropertyMenuItem = new MenuItem("ImporExportSelected");
                //CopyMenuItem.Click += CopyMenuItem_Click;
                //DeleteMenuItem.Click += DeleteMenuItem_Click;
                //PropertyMenuItem.Click += PropertyMenuItem_Click;
                //mnuContextMenu.MenuItems.Add(CopyMenuItem);
                //mnuContextMenu.MenuItems.Add(DeleteMenuItem);
                //mnuContextMenu.MenuItems.Add(PropertyMenuItem);
                //mnuContextMenu.Show(this, menuPoint);
                //mainEWSForm.ctxtMenu.Show(this, menuPoint);
                if (parentTabGraphicPageControl.TabPageType == TABPAGETYPE.DISPLAY)
                {
                    DCS.Forms.MainForm.Instance().GraphicPagectxMenu.Show(this, menuPoint);
                }
                if (parentTabGraphicPageControl.TabPageType == TABPAGETYPE.FBD)
                {
                    DCS.Forms.MainForm.Instance().FBDPagectxMenu.Show(this, menuPoint);
                }
            }
            else
            {
                Refresh();
                DCS.Forms.MainForm.Instance().GraphicPagectxMenu.Show(this, menuPoint);
            } 
#endif

            
        }

       

        public void CopyMenuItem_Click(object sender, EventArgs e)
        {
            
        }


        
        public void DeleteMenuItem_Click(object sender, EventArgs e)
        {
            Pages.DeleteSelection();
        }

        
        
        public void PropertyMenuItem_Click(object sender, EventArgs e)
        {
            parentTabGraphicPageControl.OpenObjectProperty();
        }

        

        /// <summary>
        /// 
        /// </summary>
        /// <param name=ID></param>
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name=ID></param>
       
      
        //public long FindLocalFromSqlTableID(long sqltableid)
        //{
        //    // Change current selection if necessary
        //    foreach (GraphicsList graphiclist in Pages.GraphicPagesList)
        //    {
        //        foreach (DrawLogic drawlogic in graphiclist.List)
        //        {
        //            if (drawlogic.SqlTableID == sqltableid)
        //            {
        //                return drawlogic.ID;
        //            }
        //        }
        //    }

            
        //    return -1;
        //}

        
        #endregion

        public void CutObject()
        {
            MessageBox.Show("Cut (from drawarea)");
        }
        private void DrawArea_MouseWheel(object sender, MouseEventArgs e)
        {
        }
        
        //public void SetDirty()
        //{
        //    ParentTabGraphicPageControl.Dirty = true;
        //}

        //public void Addlinks( DrawWire tempobject,int _pageno)
        //{

        //    //foreach (DrawLogic drawlogic in Pages.GraphicPagesList[_pageno].List)
        //    //{
        //    //    if (drawlogic.InstanseName == tempobject.OutputObjectName)
        //    //    {
        //    //        ((DrawFBDBox)drawlogic).fbdboxobject.PinCollectionOutput[tempobject.OutputPinNo].WireConnection.Add(tempobject.InstanseName);
        //    //        break;
        //    //    }
        //    //}

        //    //foreach (DrawLogic drawlogic in Pages.GraphicPagesList[_pageno].List)
        //    //{
        //    //    if (drawlogic.InstanseName == tempobject.InputObjectName)
        //    //    {
        //    //        ((DrawFBDBox)drawlogic).fbdboxobject.PinCollectionInput[tempobject.InputPinNo].WireConnection.Add(tempobject.InstanseName);
        //    //        break;
        //    //    }
        //    //}

        //    foreach (DrawLogic drawlogic in Pages.GraphicPagesList[_pageno].List)
        //    {
        //        if (drawlogic.ID == tempobject.OutputObjectID)
        //        {
        //            ((DrawFBDBox)drawlogic).fbdboxobject.PinCollectionOutput[tempobject.OutputPinNo].WireConnectionID.Add(tempobject.ID);
        //            break;
        //        }
        //    }

        //    foreach (DrawLogic drawlogic in Pages.GraphicPagesList[_pageno].List)
        //    {
        //        if (drawlogic.ID == tempobject.InputObjectID)
        //        {
        //            ((DrawFBDBox)drawlogic).fbdboxobject.PinCollectionInput[tempobject.InputPinNo].WireConnectionID.Add(tempobject.ID);
        //            break;
        //        }
        //    }
        //}

        

        private void DrawArea_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        


        //public Point GetPinInputPosition( long functioninid, int pinno)
        //{
        //    Point pt = new Point();
        //    foreach (DrawLogic drawlogic in Pages.GraphicPagesList[PageNo].List)
        //    {
        //        if (drawlogic.ID == functioninid)
        //        {
        //            pt.X = ((DrawFBDBox)drawlogic).fbdboxobject.PinCollectionInput[pinno].X;
        //            pt.Y = ((DrawFBDBox)drawlogic).fbdboxobject.PinCollectionInput[pinno].Y;
        //            break;
        //        }
        //    }
        //    return pt;
        //}

        
        //public Point GetPinOutputPosition( long functioninid, int pinno)
        //{
        //    Point pt = new Point();
        //    foreach (DrawLogic drawlogic in Pages.GraphicPagesList[PageNo].List)
        //    {
        //        if (drawlogic.ID == functioninid)
        //        {
        //            pt.X = ((DrawFBDBox)drawlogic).fbdboxobject.PinCollectionOutput[pinno].X;
        //            pt.Y = ((DrawFBDBox)drawlogic).fbdboxobject.PinCollectionOutput[pinno].Y;
        //            break;
        //        }
        //    }
        //    return pt;
        //}

        

        
        private void DrawArea_Load(object sender, EventArgs e)
        {

        }

        private void DrawArea_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                tools[(int)activeTool].MouseDoubleClick(this, e);
            }

        }
        public void CloseDrawArea()
        {
            //this.SuspendLayout();
            //// 
            //// DrawArea
            //// 
            //this.Load -= new System.EventHandler(this.DrawArea_Load);
            //this.Paint -= new System.Windows.Forms.PaintEventHandler(this.DrawArea_Paint);
            //this.KeyPress -= new System.Windows.Forms.KeyPressEventHandler(this.DrawArea_KeyPress);
            //this.MouseDoubleClick -= new System.Windows.Forms.MouseEventHandler(this.DrawArea_MouseDoubleClick);
            //this.MouseDown -= new System.Windows.Forms.MouseEventHandler(this.DrawArea_MouseDown);
            //this.MouseMove -= new System.Windows.Forms.MouseEventHandler(this.DrawArea_MouseMove);
            //this.MouseUp -= new System.Windows.Forms.MouseEventHandler(this.DrawArea_MouseUp);
            //this.ResumeLayout(false);
            //_currentPen.Dispose();
            //_currentBrush.Dispose();
            foreach (Control control in this.Controls)
            {
                control.Dispose();
            }

            PageSetupDialog1.Dispose();
            printdoc1.Dispose();
            previewdlg.Dispose();
            PrintDialog1.Dispose();

            if (tempobject != null)
            {
                tempobject.AreaPath.Dispose();
                tempobject.AreaPen.Dispose();
                tempobject.AreaRegion.Dispose();
            }
            //((ToolObject)tools[(int)DrawToolType.Pointer]).m_Cursor.Dispose();
            //((ToolObject)tools[(int)DrawToolType.Rectangle]).m_Cursor.Dispose();
            //((ToolObject)tools[(int)DrawToolType.Ellipse]).m_Cursor.Dispose();
            //((ToolObject)tools[(int)DrawToolType.Line]).m_Cursor.Dispose();
            //((ToolObject)tools[(int)DrawToolType.PolyLine]).m_Cursor.Dispose();
            //((ToolObject)tools[(int)DrawToolType.Text]).m_Cursor.Dispose();
            //((ToolObject)tools[(int)DrawToolType.Image]).m_Cursor.Dispose();
            //((ToolObject)tools[(int)DrawToolType.Variable]).m_Cursor.Dispose();
            //((ToolObject)tools[(int)DrawToolType.Function]).m_Cursor.Dispose();
            //((ToolObject)tools[(int)DrawToolType.FunctionBlock]).m_Cursor.Dispose();
            //((ToolObject)tools[(int)DrawToolType.Wire]).m_Cursor.Dispose();
            //((ToolObject)tools[(int)DrawToolType.Constant]).m_Cursor.Dispose();

        }

        private void DrawArea_KeyDown(object sender, KeyEventArgs e)
        {
#if EWSAPP
            if (e.KeyCode == Keys.C && e.Modifiers == Keys.Control)
            {
                parentTabGraphicPageControl.Copy2Clipboard();

            }
            else
            {
                if (e.KeyCode == Keys.V && e.Modifiers == Keys.Control)
                {
                    parentTabGraphicPageControl.PastefromClipboard();

                }
            } 
#endif

        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {



            switch (keyData)
            {
                case Keys.Down:
                    //Handle down arrow key event
                    if (SnapEnable)
                    {
                        MoveSelectedobjects(0, SnapY);
                    }
                    else
                    {
                        MoveSelectedobjects(0, 1);
                    }
                    break;
                case Keys.Up:
                    //Handle up arrow key event
                    if (SnapEnable)
                    {
                        MoveSelectedobjects(0, -SnapY);
                    }
                    else
                    {
                        MoveSelectedobjects(0, -1);
                    }
                    break;
                case Keys.Right:
                    //Handle right arrow key event
                    if (SnapEnable)
                    {
                        MoveSelectedobjects(SnapX, 0);
                    }
                    else
                    {
                        MoveSelectedobjects(1, 0);
                    }
                    break;
                case Keys.Left:
                    //Handle left arrow key event
                    if (SnapEnable)
                    {
                        MoveSelectedobjects(-SnapX, 0);
                    }
                    else
                    {
                        MoveSelectedobjects(-1, 0);
                    }
                    break;
                case Keys.Delete:
                    Pages.DeleteSelection();
                    break;

            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <param name="deltaX">Distance along X-axis: (+)=Right, (-)=Left</param>
		/// <param name="deltaY">Distance along Y axis: (+)=Down, (-)=Up</param>

        void MoveSelectedobjects(int deltaX, int deltaY)
        {
            foreach (DrawObject o in Pages.GraphicPagesList[ActivePageNo].Selection)
            {
                o.Move(deltaX, deltaY);
                if ((o is DrawFBDBox))
                {
                    ((DrawFBDBox)o).UpdateWireConnections();
                }
            }
        }
    }
}