using EWS.Draw;
using EWS.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EWS.TabPages
{
    public delegate bool PreRemoveTab(int indx);
    public partial class EXTabControl : TabControl
    {
        MainForm mainewsform;
        public MainForm mainEWSForm
        {
            get
            {
                return mainewsform;
            }
        }
        PreRemoveTab closedelage;
        private bool _controlKey = false;
        public EXTabControl(): base()
        {
            PreRemoveTabPage = null;
            InitializeComponent();
            
        }
        public EXTabControl(MainForm _parent)
            : base()
        {
            PreRemoveTabPage = null;
            InitializeComponent();
            mainewsform = _parent;
            closedelage = new PreRemoveTab(mainEWSForm.CloseTab);

        }
        //public void SetParent(MainForm _parent)
        //{
        //    mainewsform = _parent;
        //    closedelage = new PreRemoveTab(mainEWSForm.CloseTab);
        //}

        //private ImageList imageList1;
        //private IContainer components;
        public PreRemoveTab PreRemoveTabPage;

        

        protected override void OnMouseClick(MouseEventArgs e)
        {
           // base.OnMouseClick(e);
            Point p = e.Location;
            for (int i = 0; i < TabCount; i++)
            {
                Rectangle r = GetTabRect(i);
                r.Offset(2, 2);
                r.Width = 16;
                r.Height = 16;
                if (r.Contains(p))
                {
                    CloseTab(i);
                }
            }
        }
        private void CloseTab(int i)
        {
            //if (PreRemoveTabPage != null)
            //{
            //    bool closeIt = PreRemoveTabPage(i);
            //    if (!closeIt)
            //        return;
            //}

            if (closedelage != null)
            {
                bool closeIt = closedelage(i);
                if (!closeIt)
                    return;
            }
            TabPages.Remove(TabPages[i]);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // EXTabControl
            // 
            this.AllowDrop = true;
            this.HotTrack = true;
            //this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EXTabControl_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EXTabControl_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.EXTabControl_KeyUp);
            this.ResumeLayout(false);

        }

        private void EXTabControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            //int i = 0;
        }

        //private void EXTabControl_KeyDown(object sender, KeyEventArgs e)
        //{
        //    int i = this.SelectedIndex;
        //    if ((((TabPageControl)TabPages[i]).TabPageType == TABPAGETYPE.FBD) ||
        //        (((TabPageControl)TabPages[i]).TabPageType == TABPAGETYPE.DISPLAY))
        //    {
        //        DrawArea _drawarea = ((TabGraphicPageControl)TabPages[i]).drawarea;
        //        int pageno = _drawarea.PageNo;

        //        switch (e.KeyCode)
        //        {
        //            case Keys.Delete:
        //                //((TabPageControl)TabPages[i]).drawarea.Pages.GraphicPagesList[pageno].DeleteSelection();
        //                _drawarea.DeleteSelection();
        //                _drawarea.Invalidate();
        //                i = 1;
        //                break;
        //            case Keys.Right:
        //                _drawarea.Pages.GraphicPagesList[pageno].MoveSelection(1, 0);
        //                _drawarea.Invalidate();
        //                break;
        //            case Keys.Left:
        //                _drawarea.Pages.GraphicPagesList[pageno].MoveSelection(-1, 0);
        //                _drawarea.Invalidate();
        //                break;
        //            case Keys.Up:
        //                _drawarea.Pages.GraphicPagesList[pageno].MoveSelection(0, -1);
        //                _drawarea.Invalidate();
        //                break;
        //            case Keys.Down:
        //                _drawarea.Pages.GraphicPagesList[pageno].MoveSelection(0, 1);
        //                _drawarea.Invalidate();
        //                break;
        //            case Keys.ControlKey:
        //                _controlKey = true;
        //                break;
        //            default:
        //                break;
        //        }
        //    }
        //    //drawArea.Invalidate();
        //    //SetStateOfControls();
        //}

        private void EXTabControl_KeyUp(object sender, KeyEventArgs e)
        {
            _controlKey = false;
        }

    }
}


/*


*/