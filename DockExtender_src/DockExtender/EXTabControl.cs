using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace DockExtenderApp
{
    public delegate bool PreRemoveTab(int indx);
    public partial class EXTabControl : TabControl
    {
        public EXTabControl(): base()
        {
            PreRemoveTabPage = null;
            InitializeComponent();
        }

        //private ImageList imageList1;
        private IContainer components;
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
            if (PreRemoveTabPage != null)
            {
                bool closeIt = PreRemoveTabPage(i);
                if (!closeIt)
                    return;
            }
            TabPages.Remove(TabPages[i]);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EXTabControl));
            //this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // imageList1
            // 
            //this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            //this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            //this.imageList1.Images.SetKeyName(0, "010.png");
            //this.imageList1.Images.SetKeyName(1, "011.png");
            //this.imageList1.Images.SetKeyName(2, "012.png");
            this.ResumeLayout(false);
            
            this.AllowDrop = true;
            //this.ImageList = this.imageList1;
            this.HotTrack = true;
            this.ResumeLayout(false);

        }

    }
}
