using DCS.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace DCS.Forms
{
    public partial class CustomTextFilter : Form
    {
        public bool ClearFilter = false;
        public Filter filter = new Filter();
        public CustomTextFilter()
        {
            InitializeComponent();
        }

        public CustomTextFilter(OpEnum _operation, object _value)
        {
            InitializeComponent();
            textBox1.Text = (string)_value;
            comboBox1.SelectedIndex = (int)_operation;

        }

        private void CustomTextFilter_Load(object sender, EventArgs e)
        {
            
        }


        private void buttonOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            filter.PropertyName = "VarName";
            filter.Value = textBox1.Text;
            filter.Operation = (OpEnum)comboBox1.SelectedIndex;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult= DialogResult.Cancel;
            Close();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            ClearFilter = true;
            Close();
        }
    }
}
