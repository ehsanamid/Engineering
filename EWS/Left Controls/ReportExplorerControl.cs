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
//using DocToolkit.Project_Objects;
using EWS.OtherControls;
using EWS.Forms;

namespace EWS.LeftControls
{
    public partial class ReportExplorerControl : ExplorerControl
    {
        public ReportExplorerControl(MainForm _parent)
            : base(_parent)
        {
            InitializeComponent();
        }

        public ReportExplorerControl()
            : base()
        {
            InitializeComponent();
        }

        

        public override bool Initialize()
        {
            bool ret = true;
            
            return ret;
        }
    }
}
