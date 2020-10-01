
using DCS.DCSTables;
using DCS.Draw;
using DCS.Forms;
using DCS.Tools;
//using DocToolkit.Project_Objects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DCS.TabPages
{
    public partial class TabGraphicPageControl : TabPageControl
    {
        public int _X;
        public int _Y;
        DrawArea _drawarea;
        public DrawArea drawarea
        {
            get
            {
                return _drawarea; ;
            }
        }
        public List<DeleteListStruc> DeleteList = new List<DeleteListStruc>();
        private System.Windows.Forms.Panel panelTabPage;

        public TabGraphicPageControl()
            : base()
        {
            InitializeComponent();
        }

        public TabGraphicPageControl(long id)
            : base(id)
        {
            _drawarea = new DrawArea(this);
            // 
            // drawArea1
            // 
            this._drawarea.ActiveTool = DCS.Draw.DrawArea.DrawToolType.Pointer;
            this._drawarea.BrushType = DocToolkit.FillBrushes.BrushType.Brown;
            this._drawarea.DraeAreaBackgroundColor = System.Drawing.Color.Empty;
            this._drawarea.DrawFilled = false;
            this._drawarea.DrawNetRectangle = false;
            this._drawarea.FillColor = System.Drawing.Color.White;
            this._drawarea.GridX = 32;
            this._drawarea.GridY = 32;
            this._drawarea.LineColor = System.Drawing.Color.Black;
            this._drawarea.LineWidth = -1;
            this._drawarea.Location = new System.Drawing.Point(34, 9);
            this._drawarea.Margin = new System.Windows.Forms.Padding(0);
            this._drawarea.Name = "_drawarea";
            this._drawarea.NetRectangle = new System.Drawing.Rectangle(0, 0, 0, 0);
            this._drawarea.OriginalPanY = 0;
            this._drawarea.Panning = false;
            this._drawarea.PanX = 0;
            this._drawarea.PanY = 0;
            this._drawarea.PenType = DCS.Draw.DrawingPens.PenType.Generic;
            this._drawarea.Rotation = 0F;
            this._drawarea.ShowGrid = true;
            this._drawarea.Size = new System.Drawing.Size(150, 150);
            this._drawarea.SnapEnable = true;
            this._drawarea.SnapX = 32;
            this._drawarea.SnapY = 32;
            this._drawarea.TabIndex = 0;
            this._drawarea.Zoom = 1F;
            InitializeComponent();
            this.panelTabPage.Controls.Add(_drawarea);
            //_drawarea.ParentTabGraphicPageControl = this;
            _drawarea.Size = new System.Drawing.Size(1280, 830);
        }

        //public virtual GraphicsList ActivePageGraphicList()
        //{
        //    return _pages.GraphicPagesList[ActivePageNo];
        //}

        //public bool AddNewPage()
        //{
        //    bool ret = false;
        //    GraphicsList gr = new GraphicsList();
        //    _pages.GraphicPagesList.Add(gr);
        //    PageNo = _pages.GraphicPagesList.Count - 1;
        //    return ret;
        //}
        //private ImageList imageList1;

        private void InitializeComponent()
        {
            this.panelTabPage = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panelTabPage
            // 
            this.panelTabPage.AutoScroll = true;
            this.panelTabPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTabPage.Location = new System.Drawing.Point(0, 0);
            this.panelTabPage.Name = "panelTabPage";
            this.panelTabPage.Size = new System.Drawing.Size(534, 149);
            this.panelTabPage.TabIndex = 0;
            this.panelTabPage.Scroll += new System.Windows.Forms.ScrollEventHandler(this.panelTabPage_Scroll);
            this.panelTabPage.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panelTabPage_MouseClick);
            // 
            // TabGraphicPageControl
            // 
            this.ClientSize = new System.Drawing.Size(534, 149);
            this.Controls.Add(this.panelTabPage);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "TabGraphicPageControl";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TabGraphicPageControl_KeyPress);
            this.ResumeLayout(false);

        }
        

        public void OpenObjectProperty()
        {
            Pages().PropertyClick();
        }
        public  int GetActivePageNo()
        {
            return Pages().ActivePageNo;
        }
        public  void SetActivePageNo(int _pn)
        {
            Pages().ActivePageNo = _pn;
        }

        public  void UnselectAll()
        {
            Pages().UnselectAll();
        }

        public  void AddnewObject(DrawObject o)
        {
            Pages().ActivePageGraphicList.Add(o);
        }

        public  GraphicsList ActivePageGraphicList()
        {
            return Pages().GraphicPagesList[Pages().ActivePageNo];
        }

#if OWSAPP
        public void ScanObjects(ref CrossReference lookup)
        {
            Pages().ScanObjects(ref lookup);
        } 
#endif

        public void DrawControl(Graphics g)
        {
            System.Drawing.Point CurrentPoint;
            CurrentPoint = panelTabPage.AutoScrollPosition; 
            Pages().DrawControl(g);
            panelTabPage.AutoScrollPosition = new Point(Math.Abs(panelTabPage.AutoScrollPosition.X), Math.Abs(CurrentPoint.Y)); 
        }

        public  bool ContextMenuDrawArea(Point point)
        {
            return Pages().ContextMenuDrawArea(point);
        }

        public int NoOfObjectsinPage
        {
            get
            {
                return Pages().NoOfObjectsinPage();
            }
        }

        
        public virtual PageList Pages()
        {
            return null;
        }
        
        
        public override void CloseTabPage()
        {
            base.CloseTabPage();
            panelTabPage.Dispose();
            drawarea.CloseDrawArea();
        }
        


        #region Load
        public override bool LoadTabPage()
        {
            bool ret = false;
            
            return ret;
        }

     
        #endregion
#if EWSAPP

        #region Save
        public override bool SaveTabPage()
        {
            return true;
        }

        public override bool SaveTabPage(long controllerID)
        {
            bool ret = false;

            return ret;
        }


        public override bool PrintTabPage()
        {
            bool ret = false;


            return ret;
        }


        public override bool CompileTabPage()
        {
            bool ret = false;


            return ret;
        }
        public void CopySelectedSlidesToClipboard()
        {
            string format = "MyUserList";

            for (int i = 0; i < Pages().ActivePageGraphicList.Count; i++)
            {
                if (Pages().ActivePageGraphicList[i].Selected)
                {
                    if (Common.IsSerializable(Pages().ActivePageGraphicList[i]))
                    {
                        format = Pages().ActivePageGraphicList[i].GetType().ToString();
                        Clipboard.SetData(format, Pages().ActivePageGraphicList[i]);
                    }
                }
            }

        }

        public override void Cut2Clipboard()
        {

        }
        public void PasteSlidesFromClipboard()
        {
            DrawObject _drawobject = null;
            if (Clipboard.ContainsData("DCS.Draw.DrawRectangle"))
            {
                _drawobject = (DrawRectangle)Clipboard.GetData("DCS.Draw.DrawRectangle");
            }
            if (Clipboard.ContainsData("DCS.Draw.DrawLine"))
            {
                _drawobject = (DrawLine)Clipboard.GetData("DCS.Draw.DrawLine");
            }
            if (Clipboard.ContainsData("DCS.Draw.DrawText"))
            {
                _drawobject = (DrawText)Clipboard.GetData("DCS.Draw.DrawText");
            }

            if (_drawobject != null)
            {
                UnselectAll();
                _drawobject.Selected = true;
                _drawobject.Move(Cursor.Position.X, Cursor.Position.Y);
                _drawobject.oIndex = 1;
                Pages().ActivePageGraphicList.Add(_drawobject);
            }


        }
        public override void Copy2Clipboard()
        {
            // List<DrawObject> SelectedDrawObject = new List<DrawObject>();
            // Construct data format for Slide collection
            DataFormats.Format dataFormat = DataFormats.GetFormat(typeof(List<DrawObject>).FullName);

            // Construct data object from selected slides
            IDataObject dataObject = new DataObject();

            List<DrawObject> dataToCopy = new List<DrawObject>();

            for (int i = 0; i < Pages().ActivePageGraphicList.Count; i++)
            {
                if (Pages().ActivePageGraphicList[i].Selected)
                {
                    if (Common.IsSerializable(Pages().ActivePageGraphicList[i]))
                    {
                        dataToCopy.Add(Pages().ActivePageGraphicList[i]);
                    }
                }
            }
            dataObject.SetData(dataFormat.Name, false, dataToCopy);

            // Put data into clipboard
            Clipboard.SetDataObject(dataObject, false);
        }
        public override void PastefromClipboard()
        {
            try
            {
                UnselectAll();
                List<DrawObject> DrawObjects = new List<DrawObject>();
                // Get data object from the clipboard
                IDataObject dataObject = Clipboard.GetDataObject();
                if (dataObject != null)
                {
                    // Check if a collection of Slides is in the clipboard
                    string dataFormat = typeof(List<DrawObject>).FullName;
                    if (dataObject.GetDataPresent(dataFormat))
                    {
                        // Retrieve slides from the clipboard
                        DrawObjects = dataObject.GetData(dataFormat) as List<DrawObject>;
                        if (DrawObjects != null)
                        {
                            foreach (DrawObject _drawobject in DrawObjects)
                            {
                                if (_drawobject != null)
                                {

                                    _drawobject.Selected = true;
                                    _drawobject.Move(Cursor.Position.X, Cursor.Position.Y);
                                    _drawobject.oIndex = 1;
                                    Pages().ActivePageGraphicList.Add(_drawobject);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        #endregion
        
#endif
        private void TabGraphicPageControl_KeyPress(object sender, KeyPressEventArgs e)
        {
           // int i = 0;
        }

        private void panelTabPage_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
            {
                _X = e.NewValue;
            }

            if (e.ScrollOrientation == ScrollOrientation.VerticalScroll)
            {
                _Y = e.NewValue;
            }
        }

        private void panelTabPage_MouseClick(object sender, MouseEventArgs e)
        {
            int x = panelTabPage.HorizontalScroll.Value;
            int y = panelTabPage.VerticalScroll.Value;
        }

    }
}

