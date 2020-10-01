using DCS.DCSTables;
using DCS.Forms;
//using DocToolkit.Project_Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace DCS.TabPages
{
    public partial class TabPageControl : DockContent
    {
        //MainForm _mainform;
        //public MainForm mainForm
        //{
        //    get
        //    {
        //        return _mainform;
        //    }
        //}


        public TabPageControl()
            : base()
        {
            InitializeComponent();
            //_drawarea = new DrawArea(this);

        }




        public TabPageControl(long id)
            : base()
        {
            //_mainform = _parent;
            InitializeComponent();
            //TabPageType = TABPAGETYPE.BOARD;
            ID = id;
            //_drawarea = new DrawArea(this);
            
        }

        
        //private ImageList imageList1;

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // TabPageControl
            // 
            this.ClientSize = new System.Drawing.Size(211, 246);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Location = new System.Drawing.Point(4, 23);
            this.Name = "TabPageControl";
            this.Text = "tabPage";
            this.Activated += new System.EventHandler(this.TabPageControl_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TabPageControl_FormClosing);
            
            this.ResumeLayout(false);

        }
        

        private string titletext = "title";
        public string TitleText
        {
            get
            {
                return titletext;
               // return this.Text;
            }
            set
            {
                titletext = value;
                if (Dirty)
                {
                    this.Text = "(*)" + titletext;
                }
                else
                {
                    this.Text = titletext;
                }
            }
        }

        TABPAGETYPE _tabpagetype;
        /// <summary>
        /// Type of Tab page
        /// </summary>
        public TABPAGETYPE TabPageType
        {
            get
            {
                return _tabpagetype;
            }
            set
            {
                _tabpagetype = value; 
            }
        }

        public bool IsGraphic()
        {
            if ((TabPageType == TABPAGETYPE.FBD) || (TabPageType == TABPAGETYPE.DISPLAY))
            {
                return true;
            }
            return false;
        }

        private long id;
        public long ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }


        private bool dirty = false;
        /// <summary>
        /// Dirty property (true when document has unsaved changes).
        /// </summary>
        public bool Dirty
        {
            get
            {
                return dirty;
            }
            set
            {
                dirty = value;
                TitleText = TitleText;
            }
        }



        protected void SetCaption(int i)
        {
            if ((i != 0) && (i != 1))
            {
                i = 1;
            }
        //    this.ImageIndex = i;
            
        }


        #region virtual
        public virtual void CloseTabPage()
        {

        }
        public virtual bool LoadTabPage()
        {
            bool ret = false;
            

            return ret;
        }

        public virtual bool SaveTabPage()
        {
            bool ret = false;
            Dirty = false;
            return ret;
        }

        public virtual bool SaveTabPage(long controllerID)
        {
            bool ret = false;
            

            return ret;
        }


        public virtual bool PrintTabPage()
        {
            bool ret = false;
            

            return ret;
        }


        public virtual bool CompileTabPage()
        {
            bool ret = false;
            
            return ret;
        }

        public virtual bool CheckOutputFileExist()
        {
            bool ret = true;

            return ret;
        }

        public virtual bool UpdateTabPage()
        {
            bool ret = true;

            return ret;
        }

        
        #endregion

        private void TabPageControl_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseTabPage();
        }

        public virtual void Copy2Clipboard()
        {

        }

        public virtual void Cut2Clipboard()
        {

        }

        public virtual void PastefromClipboard()
        {

        }

        public virtual void UpdatePropertyGrid()
        {

        }
        

        private void TabPageControl_Activated(object sender, EventArgs e)
        {
#if EWSAPP
            UpdatePropertyGrid();
            MainForm.Instance().UpdateToolbox();

            Form activeChild = this.ActiveMdiChild;
            if (activeChild is TabPageControl)
            {
                switch (((TabPageControl)activeChild).TabPageType)
                {
                    case TABPAGETYPE.DISPLAY:
                        MainForm.Instance().layerwindow.Show(true);
                        MainForm.Instance().UpdateLayer(((TabDisplayPageControl)activeChild).tbldisplay);
                        break;
                    default:
                        MainForm.Instance().layerwindow.Show(false);
                        break;
                }
            } 
#endif
        }

        
    }
}


