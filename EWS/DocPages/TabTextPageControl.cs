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
    public partial class TabTextPageControl : TabPageControl
    {
        public RichTextBox textboxControl;
        //public DrawArea drawarea;
        public Panel panelTabPage;
        public TabTextPageControl(EXTabControl _parent, long id)
            : base(_parent,id)
        {

            InitializeComponent();
            //_drawarea = new DrawArea(this);
            
        }

        
        //private ImageList imageList1;

        private void InitializeComponent()
        {
            this.panelTabPage = new System.Windows.Forms.Panel();
            this.textboxControl = new System.Windows.Forms.RichTextBox();
            this.panelTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTabPage
            // 
            this.panelTabPage.AutoScroll = true;
            this.panelTabPage.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelTabPage.Controls.Add(this.textboxControl);
            this.panelTabPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTabPage.Location = new System.Drawing.Point(0, 0);
            this.panelTabPage.Name = "panelTabPage";
            this.panelTabPage.Size = new System.Drawing.Size(550, 187);
            this.panelTabPage.TabIndex = 0;
            // 
            // textboxControl
            // 
            this.textboxControl.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.textboxControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textboxControl.Location = new System.Drawing.Point(0, 0);
            this.textboxControl.Name = "textboxControl";
            this.textboxControl.Size = new System.Drawing.Size(550, 187);
            this.textboxControl.TabIndex = 0;
            this.textboxControl.Text = "";
            this.textboxControl.WordWrap = false;
            // 
            // TabTextPageControl
            // 
            this.Controls.Add(this.panelTabPage);
            this.panelTabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        

        //private string titletext = "title";





        public override void CloseTabPage()
        {
            //this.Controls.Clear();

            base.CloseTabPage();
            
            panelTabPage.Dispose();

           

            //drawarea = null;

        }
        
       
        #region Load
        public override bool LoadTabPage()
        {
            bool ret = false;
            

            return ret;
        }

        
        #endregion

        #region Save
        public override bool SaveTabPage()
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
        
        

        
        #endregion

        

        
    }
}


