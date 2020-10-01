using EWS.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace DockSample
{
    public partial class DummyExplorer : ToolWindow
    {
        MainForm mainform;
        public DummyExplorer(MainForm _parent)
        {
            mainform = _parent;
            InitializeComponent();
        } 
    }
}