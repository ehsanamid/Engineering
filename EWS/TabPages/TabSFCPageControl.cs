﻿using DCS.Compile;
using DCS.DCSTables;
using DCS.Draw;
using DCS.Forms;
using DCS.TableObject;
//using DocToolkit.Project_Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace DCS.TabPages
{
    public partial class TabSFCPageControl : TabGraphicPageControl
    {
#if EWSAPP
        private POUObject _pouobject;
        public POUObject PouObject
        {
            get
            {
                return _pouobject;
            }

        } 
#endif
        private tblPou _tblpou;
        public tblPou tblpou
        {
            get
            {
                return _tblpou;
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


        public Panel panelPageNavigation;
        
        private System.Windows.Forms.ToolStrip toolStripPageNavigation;
        private System.Windows.Forms.ToolStripButton toolStripButtonFirst;
        private System.Windows.Forms.ToolStripButton toolStripButtonPrevious;
        private System.Windows.Forms.ToolStripLabel toolStripLabelPageNumber;
        private System.Windows.Forms.ToolStripButton toolStripButtonNext;
        private System.Windows.Forms.ToolStripButton toolStripButtonLast;
        private System.Windows.Forms.ToolStripButton toolStripButtonAdd;
        private System.Windows.Forms.ToolStripButton toolStripButtonDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;

        //private long _DomainID;
        //public long DomainID
        //{
        //    get
        //    {
        //        return _DomainID;
        //    }
        //    set
        //    {
        //        _DomainID = value;
        //    }
        //}





        public TabSFCPageControl(long id)
            : base( id)
        {
            InitializeComponent();
            //_drawarea = new DrawArea(this);
            TabPageType = TABPAGETYPE.SFC;
            _tblpou = tblSolution.m_tblSolution().GetPouFromID(ID);
#if EWSAPP
            _pouobject = new POUObject(_tblpou); 
#endif
            tblcontroller = tblSolution.m_tblSolution().GetControllerobjectofPOUID(ID);
            drawarea.Size = new System.Drawing.Size(1280, 830);
            drawarea.SnapX = 8;
            drawarea.SnapY = 8;
            drawarea.SnapEnable = true;
            UpdateToolstripNavigation();
        }

        
        //private ImageList imageList1;

        private void InitializeComponent()
        {

            
           // panelTabPage = new System.Windows.Forms.Panel();
            panelPageNavigation = new System.Windows.Forms.Panel();
            toolStripPageNavigation = new System.Windows.Forms.ToolStrip();
            toolStripButtonAdd = new System.Windows.Forms.ToolStripButton();
            toolStripButtonDelete = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            toolStripButtonFirst = new System.Windows.Forms.ToolStripButton();
            toolStripButtonPrevious = new System.Windows.Forms.ToolStripButton();
            toolStripLabelPageNumber = new System.Windows.Forms.ToolStripLabel();
            toolStripButtonNext = new System.Windows.Forms.ToolStripButton();
            toolStripButtonLast = new System.Windows.Forms.ToolStripButton();
           // drawarea = new DrawArea(this);
           // panelTabPage.SuspendLayout();
            panelPageNavigation.SuspendLayout();
            toolStripPageNavigation.SuspendLayout();
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
            // panelPageNavigation
            // 
            this.panelPageNavigation.BackColor = System.Drawing.Color.Gainsboro;
            this.panelPageNavigation.Controls.Add(this.toolStripPageNavigation);
            this.panelPageNavigation.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelPageNavigation.Location = new System.Drawing.Point(0, 167);
            this.panelPageNavigation.Name = "panelPageNavigation";
            this.panelPageNavigation.Size = new System.Drawing.Size(550, 20);
            this.panelPageNavigation.TabIndex = 0;
            // 
            // toolStripPageNavigation
            // 
            this.toolStripPageNavigation.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonAdd,
            this.toolStripButtonDelete,
            this.toolStripSeparator1,
            this.toolStripButtonFirst,
            this.toolStripButtonPrevious,
            this.toolStripLabelPageNumber,
            this.toolStripButtonNext,
            this.toolStripButtonLast});
            this.toolStripPageNavigation.Location = new System.Drawing.Point(0, 0);
            this.toolStripPageNavigation.Name = "toolStripPageNavigation";
            this.toolStripPageNavigation.Size = new System.Drawing.Size(550, 25);
            this.toolStripPageNavigation.TabIndex = 2;
            this.toolStripPageNavigation.Text = "toolStripPageNavigation";
            this.toolStripPageNavigation.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStripPageNavigation_ItemClicked);
            // 
            // toolStripButtonAdd
            // 
            this.toolStripButtonAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAdd.Image = DCS.Properties.Resources._03;
            this.toolStripButtonAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAdd.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripButtonAdd.Name = "toolStripButtonAdd";
            this.toolStripButtonAdd.Size = new System.Drawing.Size(23, 25);
            this.toolStripButtonAdd.Text = "Add";
            // 
            // toolStripButtonNew
            // 
            this.toolStripButtonDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDelete.Image = DCS.Properties.Resources._01;
            this.toolStripButtonDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDelete.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripButtonDelete.Name = "toolStripButtonDelete";
            this.toolStripButtonDelete.Size = new System.Drawing.Size(23, 25);
            this.toolStripButtonDelete.Text = "Delete";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonFirst
            // 
            this.toolStripButtonFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonFirst.Image = DCS.Properties.Resources._38;
            this.toolStripButtonFirst.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonFirst.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripButtonFirst.Name = "toolStripButtonFirst";
            this.toolStripButtonFirst.Size = new System.Drawing.Size(23, 25);
            this.toolStripButtonFirst.Text = "First";
            // 
            // toolStripButtonPrevious
            // 
            this.toolStripButtonPrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonPrevious.Image = DCS.Properties.Resources._44;
            this.toolStripButtonPrevious.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPrevious.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripButtonPrevious.Name = "toolStripButtonPrevious";
            this.toolStripButtonPrevious.Size = new System.Drawing.Size(23, 25);
            this.toolStripButtonPrevious.Text = "Previous";
            // 
            // toolStripLabelPageNumber
            // 
            this.toolStripLabelPageNumber.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripLabelPageNumber.Name = "toolStripLabelPageNumber";
            this.toolStripLabelPageNumber.Size = new System.Drawing.Size(13, 40);
            this.toolStripLabelPageNumber.Text = "1";
            // 
            // toolStripButtonNext
            // 
            this.toolStripButtonNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonNext.Image = DCS.Properties.Resources._43;
            this.toolStripButtonNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonNext.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripButtonNext.Name = "toolStripButtonNext";
            this.toolStripButtonNext.Size = new System.Drawing.Size(23, 25);
            this.toolStripButtonNext.Text = "Next";
            // 
            // toolStripButtonLast
            // 
            this.toolStripButtonLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonLast.Image = DCS.Properties.Resources._37;
            this.toolStripButtonLast.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonLast.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripButtonLast.Name = "toolStripButtonLast";
            this.toolStripButtonLast.Size = new System.Drawing.Size(23, 25);
            this.toolStripButtonLast.Text = "Last";
            // 
            // TabFBDPageControl
            // 
           // this.Controls.Add(this.panelTabPage);
            this.Controls.Add(this.panelPageNavigation);
          //  this.ImageIndex = 0;
            this.Location = new System.Drawing.Point(4, 23);
            this.Size = new System.Drawing.Size(550, 187);
            this.Text = "tabPage";
            
            //this.panelTabPage.ResumeLayout(false);
            //this.panelTabPage.PerformLayout();
            this.panelPageNavigation.ResumeLayout(false);
            this.panelPageNavigation.PerformLayout();
            this.toolStripPageNavigation.ResumeLayout(false);
            this.toolStripPageNavigation.PerformLayout();
            
            this.ResumeLayout(false);

        }

        //public override void UnselectAll()
        //{
        //    tblpou.Pages.UnselectAll();
        //}

        //public override void AddnewObject(DrawObject o)
        //{
        //    tblpou.Pages.ActivePageGraphicList.Add(o);
        //}

        //public override GraphicsList ActivePageGraphicList()
        //{
        //    return tblpou.Pages.GraphicPagesList[tblpou.Pages.ActivePageNo];
        //}

        //public override void Draw(Graphics g)
        //{
        //    tblpou.Pages.Draw(g);
        //}

        public override void CloseTabPage()
        {
            //this.Controls.Clear();

            base.CloseTabPage();
            
            panelPageNavigation.Dispose();

            toolStripPageNavigation.Dispose();
            toolStripButtonAdd.Dispose();
            toolStripButtonDelete.Dispose();
            toolStripSeparator1.Dispose();
            toolStripButtonFirst.Dispose();
            toolStripButtonPrevious.Dispose();
            toolStripLabelPageNumber.Dispose();
            toolStripButtonNext.Dispose();
            toolStripButtonLast.Dispose();

            //drawarea = null;

        }

        

        public override PageList Pages()
        {
            return tblpou.Pages;
        }

        #region override
        public override bool LoadTabPage()
        {
            bool ret = false;
            try
            {

                ret = tblSolution.m_tblSolution().GetPouFromID(ID).LoadFBD(this);
                UpdateToolstripNavigation();
                return ret;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            SetCaption(0);
            return ret;
        }



#if EWSAPP
        public override bool SaveTabPage()
        {
            bool ret = false;
            try
            {
                tblpou.POUObjectCopy(PouObject);
                tblpou.Update();
                tblcontroller.SavePouDB();
                ret = tblSolution.m_tblSolution().GetPouFromID(ID).SaveSFC();
                if (ret)
                {
                    Dirty = false;
                    SetCaption(0);
                }
                return ret;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return ret;
        } 
#endif

        //public override bool SaveTabPage(long controllerID)
        //{
        //    bool ret = false;
        //    try
        //    {
        //        ret = tblSolution.m_tblSolution().GetPouFromID(ID).SaveFBD(drawarea);
        //        ret = true;
        //        SetCaption(0);
        //        return ret;

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    return ret;
        //}


        public override bool PrintTabPage()
        {
            bool ret = false;
            try
            {

                ret = tblSolution.m_tblSolution().GetPouFromID(ID).PrintFBD(drawarea);
                return ret;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return ret;
        }


#if EWSAPP
        public override bool CompileTabPage()
        {

            bool ret = false;
            try
            {
                Compiler compiler = new Compiler(/*mainForm*/);
                ret = compiler.CompilePOU(tblSolution.m_tblSolution().GetPouFromID(ID));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return ret;
        }

        private bool SaveFBDPage()
        {
            bool ret = false;
            try
            {
                ret = tblSolution.m_tblSolution().GetPouFromID(ID).SaveFBD();
                ret = true;
                return ret;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return ret;

        }

        public override bool CheckOutputFileExist()
        {
            bool ret = false;
            string filename = "";
            filename = Common.ProjectPath + "\\LOGIC";
            filename += "\\";
            filename += tblSolution.m_tblSolution().GetControllerobjectofPOUID(ID).ControllerName;
            filename += "\\";
            filename += tblSolution.m_tblSolution().GetPouFromID(ID).pouName + ".st";
            ret = File.Exists(filename);
            return ret;
        }

#endif

        //private bool SaveFBDPage(long _controllerID)
        //{
        //    bool ret = false;
        //    try
        //    {
        //        if (_controllerID == ControllerID)
        //        {
        //            ret = tblSolution.m_tblSolution().GetControllerFromID(ControllerID).GetPouFromID(pouID).SaveFBD(drawarea);
        //        }
        //        ret = true;
        //        return ret;

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    return ret;

        //}

        #endregion

        private void toolStripPageNavigation_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == toolStripButtonAdd)
            {
                tblpou.Pages.AddNewPage();
            }
            if (e.ClickedItem == toolStripButtonDelete)
            {

            }
            if (e.ClickedItem == toolStripButtonFirst)
            {
                tblpou.Pages.ActivePageNo = 0;
            }
            if (e.ClickedItem == toolStripButtonPrevious)
            {
                tblpou.Pages.ActivePageNo--;
            }
            if (e.ClickedItem == toolStripButtonNext)
            {
                tblpou.Pages.ActivePageNo++;
            }
            if (e.ClickedItem == toolStripButtonLast)
            {
                tblpou.Pages.ActivePageNo = drawarea.NoOfPages - 1;
            }
            UpdateToolstripNavigation();

        }

        public void UpdateToolstripNavigation()
        {
            switch (TabPageType)
            {
                case TABPAGETYPE.SFC:
                    toolStripButtonAdd.Enabled = true;
                    if (1 == drawarea.NoOfPages)
                    {
                        toolStripButtonDelete.Enabled = false;
                    }
                    else
                    {
                        toolStripButtonDelete.Enabled = true;
                    }
                    
                    break;
                default:
                    toolStripButtonAdd.Enabled = false;
                    toolStripButtonDelete.Enabled = false;
                    break;
            }

            toolStripButtonFirst.Enabled = true;
            toolStripButtonPrevious.Enabled = true;
            toolStripButtonNext.Enabled = true;
            toolStripButtonLast.Enabled = true;
            if ((tblpou.Pages.ActivePageNo + 1) == 1)
            {
                toolStripButtonFirst.Enabled = false;
                toolStripButtonPrevious.Enabled = false;
            }
            if ((tblpou.Pages.ActivePageNo + 1) == tblpou.Pages.NoOfPages)
            {
                toolStripButtonNext.Enabled = false;
                toolStripButtonLast.Enabled = false;
            }

            toolStripLabelPageNumber.Text = (tblpou.Pages.ActivePageNo + 1).ToString();

        }
        
        
    }
}


