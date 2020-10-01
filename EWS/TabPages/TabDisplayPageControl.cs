using DCS.DCSTables;
using DCS.Draw;
using DCS.Forms;
using DCS.TableObject;
using DCS.Tools;
//using DocToolkit.Project_Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DCS.TabPages
{
    public partial class TabDisplayPageControl : TabGraphicPageControl
    {
#if EWSAPP
        DisplayObject _displayobject;
        public DisplayObject Displayobject
        {
            get
            {
                return _displayobject;
            }
        } 
#endif
        private tblDisplay _tbldisplay;
        public tblDisplay tbldisplay
        {
            get
            {
                return _tbldisplay;
            }
            
        }

        public TabDisplayPageControl(long id)
            : base( id)
        {
            InitializeComponent();
            //_drawarea = new DrawArea(this);
            TabPageType = TABPAGETYPE.DISPLAY;
            drawarea.Size = new System.Drawing.Size(1280, 830);
            _tbldisplay = tblSolution.m_tblSolution().GetDisplayFromID(ID);
#if EWSAPP
            _displayobject = new DisplayObject(_tbldisplay); 
#endif
        }

        
        //private ImageList imageList1;

        private void InitializeComponent()
        {
            SuspendLayout();
            
            this.Location = new System.Drawing.Point(4, 23);
            this.Size = new System.Drawing.Size(550, 187);
            this.Text = "tabPage";
           
            this.ResumeLayout(false);

        }

        

        public override PageList Pages()
        {
            return tbldisplay.Pages;
        }

        public override void CloseTabPage()
        {
      
            base.CloseTabPage();

#if EWSAPP

            if (Dirty)
            {
                if (DialogResult.Yes == MessageBox.Show("Do you want to save?", "Save", MessageBoxButtons.YesNoCancel))
                {
                    SaveTabPage();
                }
            } 
#endif
            tbldisplay.ClearDisplayCollections();
            


        }

        #region Load
        public override bool LoadTabPage()
        {
            bool ret = false;

            tbldisplay.LoadDisplay(this);
            return ret;
        }

        
        #endregion

        #region Save
#if EWSAPP
        public override bool SaveTabPage()
        {
            if (Dirty || !CheckOutputFileExist())
            {
                tbldisplay.DisplayObjectCopy(Displayobject);
                tbldisplay.Update();
                Dirty = !tbldisplay.SaveDisplay();
            }
            return !Dirty;

        } 
#endif

        

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

#if EWSAPP
        public override void UpdatePropertyGrid()
        {
            MainForm.Instance().m_propertyGrid.SelectedObject = Displayobject; ;
        }

        public void SetDirtyObjects()
        {
            foreach (DrawObject o in Pages().GraphicPagesList[0].Selection)
            {
                o.Dirty = true;
            }
        } 
#endif
        #endregion

       
        
    }
}


