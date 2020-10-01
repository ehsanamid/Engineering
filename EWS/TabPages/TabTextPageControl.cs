using DCS.DCSTables;
using DCS.Forms;
using DCS.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DCS.TabPages
{
    public partial class TabTextPageControl : TabPageControl
    {
        private LineNumbers_For_RichTextBox lineNumbers_For_RichTextBox1;
        private RichTextBox textboxControl;
        //public DrawArea drawarea;
        public TabTextPageControl(  long id)
            : base(id)
        {

            InitializeComponent();
            //_drawarea = new DrawArea(this);
            
        }

        public TabTextPageControl()
        {

            InitializeComponent();

        }

        public RichTextBox m_textboxControl
        {
            get
            {
                return textboxControl;
            }
        }
        //private ImageList imageList1;

        private void InitializeComponent()
        {
            this.textboxControl = new System.Windows.Forms.RichTextBox();
            this.lineNumbers_For_RichTextBox1 = new DCS.Tools.LineNumbers_For_RichTextBox();
            this.SuspendLayout();
            // 
            // textboxControl
            // 
            this.textboxControl.AcceptsTab = true;
            this.textboxControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textboxControl.Location = new System.Drawing.Point(56, 65);
            this.textboxControl.Name = "textboxControl";
            this.textboxControl.Size = new System.Drawing.Size(100, 96);
            this.textboxControl.TabIndex = 1;
            this.textboxControl.Text = "";
            this.textboxControl.TextChanged += new System.EventHandler(this.textboxControl_TextChanged);
            // 
            // lineNumbers_For_RichTextBox1
            // 
            this.lineNumbers_For_RichTextBox1._SeeThroughMode_ = false;
            this.lineNumbers_For_RichTextBox1.AutoSizing = true;
            this.lineNumbers_For_RichTextBox1.BackgroundGradient_AlphaColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lineNumbers_For_RichTextBox1.BackgroundGradient_BetaColor = System.Drawing.Color.LightSteelBlue;
            this.lineNumbers_For_RichTextBox1.BackgroundGradient_Direction = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lineNumbers_For_RichTextBox1.BorderLines_Color = System.Drawing.Color.SlateGray;
            this.lineNumbers_For_RichTextBox1.BorderLines_Style = System.Drawing.Drawing2D.DashStyle.Dot;
            this.lineNumbers_For_RichTextBox1.BorderLines_Thickness = 1F;
            this.lineNumbers_For_RichTextBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.lineNumbers_For_RichTextBox1.DockSide = LineNumbers_For_RichTextBox.LineNumberDockSide.Left;
            this.lineNumbers_For_RichTextBox1.GridLines_Color = System.Drawing.Color.SlateGray;
            this.lineNumbers_For_RichTextBox1.GridLines_Style = System.Drawing.Drawing2D.DashStyle.Dot;
            this.lineNumbers_For_RichTextBox1.GridLines_Thickness = 1F;
            this.lineNumbers_For_RichTextBox1.LineNrs_Alignment = System.Drawing.ContentAlignment.TopRight;
            this.lineNumbers_For_RichTextBox1.LineNrs_AntiAlias = true;
            this.lineNumbers_For_RichTextBox1.LineNrs_AsHexadecimal = false;
            this.lineNumbers_For_RichTextBox1.LineNrs_ClippedByItemRectangle = true;
            this.lineNumbers_For_RichTextBox1.LineNrs_LeadingZeroes = true;
            this.lineNumbers_For_RichTextBox1.LineNrs_Offset = new System.Drawing.Size(0, 0);
            this.lineNumbers_For_RichTextBox1.Location = new System.Drawing.Point(0, 0);
            this.lineNumbers_For_RichTextBox1.Margin = new System.Windows.Forms.Padding(0);
            this.lineNumbers_For_RichTextBox1.MarginLines_Color = System.Drawing.Color.SlateGray;
            this.lineNumbers_For_RichTextBox1.MarginLines_Side = LineNumbers_For_RichTextBox.LineNumberDockSide.Right;
            this.lineNumbers_For_RichTextBox1.MarginLines_Style = System.Drawing.Drawing2D.DashStyle.Solid;
            this.lineNumbers_For_RichTextBox1.MarginLines_Thickness = 1F;
            this.lineNumbers_For_RichTextBox1.Name = "lineNumbers_For_RichTextBox1";
            this.lineNumbers_For_RichTextBox1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.lineNumbers_For_RichTextBox1.ParentRichTextBox = this.textboxControl;
            this.lineNumbers_For_RichTextBox1.Show_BackgroundGradient = true;
            this.lineNumbers_For_RichTextBox1.Show_BorderLines = true;
            this.lineNumbers_For_RichTextBox1.Show_GridLines = true;
            this.lineNumbers_For_RichTextBox1.Show_LineNrs = true;
            this.lineNumbers_For_RichTextBox1.Show_MarginLines = true;
            this.lineNumbers_For_RichTextBox1.Size = new System.Drawing.Size(17, 311);
            this.lineNumbers_For_RichTextBox1.TabIndex = 0;
            
            // 
            // TabTextPageControl
            // 
            this.ClientSize = new System.Drawing.Size(211, 285);
            this.Controls.Add(this.textboxControl);
            this.Controls.Add(this.lineNumbers_For_RichTextBox1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "TabTextPageControl";
            this.ResumeLayout(false);

        }
        

        //private string titletext = "title";





        public override void CloseTabPage()
        {
            //this.Controls.Clear();

            base.CloseTabPage();
            
            //panelTabPage.Dispose();

           

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

        private void textboxControl_TextChanged(object sender, EventArgs e)
        {
            Dirty = true;
        }

        

        
    }
}


