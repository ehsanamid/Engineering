using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DockSample;
using EWS.DCSTables;
using EWS.OtherControls;
using EWS.Forms;

namespace EWS.LeftControls
{
    public partial class UserExplorerControl : ExplorerControl
    {
        //private Dictionary<long, TreeNode> _treenodesdictionary = new Dictionary<long, TreeNode>();
        public UserExplorerControl(MainForm _parent)
            : base(_parent)
        {
            InitializeComponent();
        }
        public UserExplorerControl(): base()
        {
            InitializeComponent();
        }
        protected override void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            this.treeViewControl.Nodes.Clear();
            Initialize();
        }


        public override bool Initialize()
        {
            bool ret = true;

            return ret;
        }

        //private void InitializeComponent()
        //{
        //    System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserExplorerControl));
        //    this.panelControl.SuspendLayout();
        //    this.panelContent.SuspendLayout();
        //    this.SuspendLayout();
        //    // 
        //    // treeViewControl
        //    // 
        //    this.treeViewControl.LineColor = System.Drawing.Color.Black;
        //    // 
        //    // imageListControl
        //    // 
        //    this.imageListControl.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListControl.ImageStream")));
        //    this.imageListControl.Images.SetKeyName(0, "usergroup.png");
        //    this.imageListControl.Images.SetKeyName(1, "user.png");
        //    // 
        //    // UserExplorerControl
        //    // 
        //    this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        //    this.Name = "UserExplorerControl";
        //    this.panelControl.ResumeLayout(false);
        //    this.panelControl.PerformLayout();
        //    this.panelContent.ResumeLayout(false);
        //    this.ResumeLayout(false);

        //}
    }
}
