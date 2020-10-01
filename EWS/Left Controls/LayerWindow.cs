using DCS.Forms;
using DCS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace DCS.LeftControls
{
    public partial class LayerWindow : ToolWindow
    {
        //MainForm mainform;
        public LayerWindow()
        {
            //mainform = _parent;
            InitializeComponent();
        }
        public DataGridView DataGridViewLayer
        {
            get
            {
                return dataGridViewLayer;
            }
        }

        private void dataGridViewLayer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            bool _enable;
            bool _lock;
            dataGridViewLayer.EndEdit();
            if ((e.ColumnIndex == 2) || (e.ColumnIndex == 3))
            {
                _enable = (bool)this.dataGridViewLayer.Rows[e.RowIndex].Cells[2].Value;
                _lock = (bool)this.dataGridViewLayer.Rows[e.RowIndex].Cells[3].Value;
                MainForm.Instance().UpdateLayerChange((LAYERS)e.RowIndex, _enable, _lock);
            }
        }
        public void Show(bool _show)
        {
            dataGridViewLayer.Visible = _show;
        }

        
        
        

        
    }
}