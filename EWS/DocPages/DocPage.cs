using EWS.DCSTables;
//using DocToolkit.Project_Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EWS.TabPages
{
    public partial class TabPageControl : TabPage
    {
        EXTabControl exparent;
        public EXTabControl EXParent
        {
            get
            {
                return exparent;
            }
        }


        //public TabPageControl()
        //    : base()
        //{
        //    InitializeComponent();
        //    //_drawarea = new DrawArea(this);

        //}


        

        public TabPageControl(EXTabControl _parent,long id)
            : base()
        {
            exparent = _parent;
            InitializeComponent();
            //TabPageType = TABPAGETYPE.BOARD;
            ID = id;
            //_drawarea = new DrawArea(this);
            
        }

        
        //private ImageList imageList1;

        private void InitializeComponent()
        {

            
            
            SuspendLayout();
            // 
            // panelTabPage
            // 
            
            this.ImageIndex = 0;
            this.Location = new System.Drawing.Point(4, 23);
            this.Size = new System.Drawing.Size(550, 187);
            this.Text = "tabPage";
            
            
            
            this.ResumeLayout(false);

        }
        

        //private string titletext = "title";
        public string TitleText
        {
            get
            {
                //return titletext;
                return this.Text;
            }
            set
            {
                //titletext = value;
                this.Text = value;
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
                if (dirty)
                {
                    SetCaption(1);
                }
                else
                {
                    SetCaption(0);
                }
            }
        }



        protected void SetCaption(int i)
        {
            if ((i != 0) && (i != 1))
            {
                i = 1;
            }
            this.ImageIndex = i;
            
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

        

        
    }
}


