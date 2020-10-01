using DCS.Compile;
using DCS;
using DCS.DCSTables;
using DCS.Forms;
using DCS.TabPages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DCS.LeftControls
{
    public partial class ReportExplorer : ToolWindow
    {
        protected System.Windows.Forms.TreeNode tmpSelectedNode;
        protected string SelectedNodeString;
        //MainForm mainform;
        //public ReportExplorer(MainForm _parent)
        //{
        //    mainform = _parent;
        //    InitializeComponent();
        //    Initialize();
        //}
        public ReportExplorer()
        {
            InitializeComponent();
            Initialize();
        }
         bool Initialize()
        {
            bool ret = true;
            
            return ret;
        }

        private void treeViewControl_DoubleClick(object sender, EventArgs e)
        {
          
        }

    }
}
