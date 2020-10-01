using DCS;
using DCS.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace DCS.LeftControls
{
    public partial class OutputWindow : ToolWindow
    {
        //MainForm mainform;
        //public OutputWindow(MainForm _parent)
        //{
        //    mainform = _parent;
        //    InitializeComponent();
        //}
        public OutputWindow( )
        {
            InitializeComponent();
        }
        public void WriteToOutputWindows(string str)
        {

            richTextBoxOutput.Text += str + Environment.NewLine;
        }

        public void WriteToOutputWindows(string str, LogLevel logLevel)
        {

            richTextBoxOutput.Text += str + Environment.NewLine;
        }
    }
}