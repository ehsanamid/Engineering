using EWS.DCSTables;
using EWS.OtherControls;
//using DocToolkit.Project_Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EWS.TabPages
{
    public partial class TabDisplayPageControl : TabGraphicPageControl
    {
        public TabDisplayPageControl(EXTabControl _parent, long id)
            : base(_parent, id)
        {
            InitializeComponent();
            //_drawarea = new DrawArea(this);
            TabPageType = TABPAGETYPE.DISPLAY;
            drawarea.Size = new System.Drawing.Size(1280, 830);
        }

        
        //private ImageList imageList1;

        private void InitializeComponent()
        {

            
            //panelTabPage = new System.Windows.Forms.Panel();
            
            //drawarea = new DrawArea(this);
           // panelTabPage.SuspendLayout();
            
            SuspendLayout();
            // 
            // panelTabPage
            // 
            //this.panelTabPage.AutoScroll = true;
            ////panelTabPage.Controls.Add(drawarea);
            //this.panelTabPage.Dock = System.Windows.Forms.DockStyle.Fill;
            //this.panelTabPage.Location = new System.Drawing.Point(0, 0);
            //this.panelTabPage.Name = "panelTabPage";
            //this.panelTabPage.Size = new System.Drawing.Size(550, 167);
            //this.panelTabPage.TabIndex = 0;
            
            // 
            // TabDisplayPageControl
            // 
           // this.Controls.Add(this.panelTabPage);
            this.ImageIndex = 0;
            this.Location = new System.Drawing.Point(4, 23);
            this.Size = new System.Drawing.Size(550, 187);
            this.Text = "tabPage";
            
            //this.panelTabPage.ResumeLayout(false);
           // this.panelTabPage.PerformLayout();
            
            
            this.ResumeLayout(false);

        }
        


        #region Load
        public override bool LoadTabPage()
        {
            bool ret = false;

            SetCaption(0);
            return ret;
        }

        
        #endregion

        #region Save
        public override bool SaveTabPage()
        {
            bool ret = false;
            
            SetCaption(0);
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
        

        
        #endregion

       
        
    }
}


