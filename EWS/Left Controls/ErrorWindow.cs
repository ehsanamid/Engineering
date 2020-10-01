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
    
    public partial class ErrorWindow : ToolWindow
    {
        //MainForm mainform;
        List<ErrorInfo> errorinfolist = new List<ErrorInfo>();
        //public ErrorWindow(MainForm _parent)
        //{
        //    mainform = _parent;
        //    InitializeComponent();
        //}
        public ErrorWindow()
        {
            InitializeComponent();
        }
        public void Clear()
        {
            dataGridView1.Rows.Clear();
            errorinfolist.Clear();
        }

        public void Add(ErrorInfo _errorinfo)
        {
            int index = dataGridView1.Rows.Add();

            DataGridViewRow row = dataGridView1.Rows[index];

            row.Cells[0].Value = _errorinfo.ErrorNo.ToString();
            row.Cells[1].Value = _errorinfo.str;
            errorinfolist.Add(_errorinfo);

        }


        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
        }

        private void dataGridView1_ClientSizeChanged(object sender, EventArgs e)
        {
            int i = this.ClientSize.Width;
            int j = this.ClientSize.Height;
            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].Width = i - 105;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        
    }
}