using EWS.DCSTables;
using EWS.Draw;
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
    public partial class TabGraphicPageControl : TabPageControl
    {
        
        public DrawArea drawarea;
        
        public Panel panelTabPage;
        
        //public TabGraphicPageControl() : base()
        //{
        //    InitializeComponent();
        //    //_drawarea = new DrawArea(this);

        //    drawarea.Size = new System.Drawing.Size(1280, 830);
        //    //UpdateToolstripNavigation();
        //}

        public TabGraphicPageControl(EXTabControl _parent,long id)
            : base(_parent,id)
        {
            InitializeComponent();
            //_drawarea = new DrawArea(this);
            
            drawarea.Size = new System.Drawing.Size(1280, 830);
            //UpdateToolstripNavigation();
        }

        
        //private ImageList imageList1;

        private void InitializeComponent()
        {

            
            panelTabPage = new System.Windows.Forms.Panel();
            //panelPageNavigation = new System.Windows.Forms.Panel();
            
            drawarea = new DrawArea(this);
            panelTabPage.SuspendLayout();
            //panelPageNavigation.SuspendLayout();
            SuspendLayout();
            // 
            // panelTabPage
            // 
            this.panelTabPage.AutoScroll = true;
            panelTabPage.Controls.Add(drawarea);
            this.panelTabPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTabPage.Location = new System.Drawing.Point(0, 0);
            this.panelTabPage.Name = "panelTabPage";
            this.panelTabPage.Size = new System.Drawing.Size(550, 167);
            this.panelTabPage.TabIndex = 0;
            // 
            // panelPageNavigation
            // 
           // this.panelPageNavigation.BackColor = System.Drawing.Color.Gainsboro;
           //this.panelPageNavigation.Dock = System.Windows.Forms.DockStyle.Bottom;
           // this.panelPageNavigation.Location = new System.Drawing.Point(0, 167);
           // this.panelPageNavigation.Name = "panelPageNavigation";
           // this.panelPageNavigation.Size = new System.Drawing.Size(550, 20);
           // this.panelPageNavigation.TabIndex = 0;
            
            // 
            // TabGraphicPageControl
            // 
            this.Controls.Add(this.panelTabPage);
            //this.Controls.Add(this.panelPageNavigation);
            this.ImageIndex = 0;
            this.Location = new System.Drawing.Point(4, 23);
            this.Size = new System.Drawing.Size(550, 187);
            this.Text = "tabPage";
            
            this.panelTabPage.ResumeLayout(false);
            this.panelTabPage.PerformLayout();
            //this.panelPageNavigation.ResumeLayout(false);
            //this.panelPageNavigation.PerformLayout();
            
            this.ResumeLayout(false);

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

        #region Save
        public override bool SaveTabPage()
        {
            bool ret = false;
            
            return ret;
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
        
        

        
        

        
        #endregion

        //private void toolStripPageNavigation_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        //{
        //    if (e.ClickedItem == toolStripButtonAdd)
        //    {
        //        drawarea.AddNewPage();
        //    }
        //    if (e.ClickedItem == toolStripButtonDelete)
        //    {

        //    } 
        //    if (e.ClickedItem == toolStripButtonFirst)
        //    {
        //        drawarea.PageNo = 0;
        //    } 
        //    if (e.ClickedItem == toolStripButtonPrevious)
        //    {
        //        drawarea.PageNo--;
        //    } 
        //    if (e.ClickedItem == toolStripButtonNext)
        //    {
        //        drawarea.PageNo++;
        //    } 
        //    if (e.ClickedItem == toolStripButtonLast)
        //    {
        //        drawarea.PageNo = drawarea.NoOfPages-1;
        //    }
        //    UpdateToolstripNavigation();

        //}

        //public void UpdateToolstripNavigation()
        //{
        //    switch (_pagetype)
        //    {
        //        case DrawAreaType.FBD:
        //            toolStripButtonAdd.Enabled = true;
        //            if (1 == drawarea.NoOfPages)
        //            {
        //                toolStripButtonDelete.Enabled = false;
        //            }
        //            else
        //            {
        //                toolStripButtonDelete.Enabled = true;
        //            }
                    
        //            break;
        //        default:
        //            toolStripButtonAdd.Enabled = false;
        //            toolStripButtonDelete.Enabled = false;
        //            break;
        //    }

        //    toolStripButtonFirst.Enabled = true;
        //    toolStripButtonPrevious.Enabled = true;
        //    toolStripButtonNext.Enabled = true;
        //    toolStripButtonLast.Enabled = true;
        //    if ((drawarea.PageNo + 1) == 1)
        //    {
        //        toolStripButtonFirst.Enabled = false;
        //        toolStripButtonPrevious.Enabled = false;
        //    }
        //    if ((drawarea.PageNo + 1) == drawarea.NoOfPages)
        //    {
        //        toolStripButtonNext.Enabled = false;
        //        toolStripButtonLast.Enabled = false;
        //    }
            
        //    toolStripLabelPageNumber.Text = (drawarea.PageNo + 1).ToString();
         
        //}
    }
}


