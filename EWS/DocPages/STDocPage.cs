using ENG.Compiler;
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
    public partial class TabSTPageControl : TabTextPageControl
    {
        private tblPou _tblpou;
        public tblPou tblpou
        {
            get
            {
                return _tblpou;
            }
            set
            {
                _tblpou = value;
            }
        }

        private tblController _tblcontroller;
        public tblController tblcontroller
        {
            get
            {
                return _tblcontroller;
            }
            set
            {
                _tblcontroller = value;
            }
        }

        public TabSTPageControl(EXTabControl _parent, long id)
            : base(_parent, id)
        {

            InitializeComponent();
            TabPageType = TABPAGETYPE.ST;
            //_drawarea = new DrawArea(this);
            tblpou = Global.EWS.m_tblSolution.GetPouFromID(ID);
            tblcontroller = Global.EWS.m_tblSolution.GetControllerobjectofPOUID(ID);
        }

        
        //private ImageList imageList1;

        private void InitializeComponent()
        {
            
            ////drawarea = new DrawArea(this);
            //this.panelTabPage.SuspendLayout();
            //this.SuspendLayout();
            //// 
            //// panelTabPage
            //// 
            //this.panelTabPage.AutoScroll = true;
            //this.panelTabPage.BackColor = System.Drawing.SystemColors.ActiveCaption;
            //this.panelTabPage.Controls.Add(this.textboxControl);
            ////this.panelTabPage.Controls.Add(drawarea);
            //this.panelTabPage.Dock = System.Windows.Forms.DockStyle.Fill;
            //this.panelTabPage.Location = new System.Drawing.Point(0, 0);
            //this.panelTabPage.Name = "panelTabPage";
            //this.panelTabPage.Size = new System.Drawing.Size(550, 187);
            //this.panelTabPage.TabIndex = 0;
            //// 
            //// textboxControl
            //// 
            //this.textboxControl.BackColor = System.Drawing.SystemColors.InactiveBorder;
            //this.textboxControl.Dock = System.Windows.Forms.DockStyle.Fill;
            //this.textboxControl.Location = new System.Drawing.Point(0, 0);
            //this.textboxControl.Multiline = true;
            //this.textboxControl.Name = "textboxControl";
            //this.textboxControl.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            //this.textboxControl.Size = new System.Drawing.Size(550, 187);
            ////this.textboxControl.TabIndex = 0;
            //// 
            //// TabTextPageControl
            //// 
            //this.Controls.Add(this.panelTabPage);
            //this.panelTabPage.ResumeLayout(false);
            //this.panelTabPage.PerformLayout();
            //this.ResumeLayout(false);

        }
        

        //private string titletext = "title";
        

        

        

        
       
        #region Load
        public override bool LoadTabPage()
        {
            bool ret = false;
            ret = Global.EWS.m_tblSolution.GetPouFromID(ID).LoadST(textboxControl);

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
            Compiler compiler = new Compiler(EXParent.mainEWSForm);
            ret = compiler.CompilePOU(Global.EWS.m_tblSolution.GetPouFromID(ID));
            return ret;
        }
        
        

        
        #endregion

        

        
    }
}


