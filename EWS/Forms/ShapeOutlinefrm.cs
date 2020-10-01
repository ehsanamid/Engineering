using DCS.Draw;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DCS.Forms
{

    public partial class ShapeOutlinefrm : Form
    {
        bool loaded = false;

        public ShapeOutline tempshapeoutline;
        public ShapeOutlinefrm(ShapeOutline _shapeoutline)
        {
            this.tempshapeoutline = new ShapeOutline(_shapeoutline);
            InitializeComponent();

            comboBoxStartCap.Visible = this.tempshapeoutline.ShowCaps;
            comboBoxEndCap.Visible = this.tempshapeoutline.ShowCaps;
            labelStrartCap.Visible = this.tempshapeoutline.ShowCaps;
            labelEndCap.Visible = this.tempshapeoutline.ShowCaps;

            comboBoxStartCap.DataSource = Enum.GetValues(typeof(LineCap));
            comboBoxEndCap.DataSource = Enum.GetValues(typeof(LineCap));
            comboBoxDash.DataSource = Enum.GetValues(typeof(DashStyle));

            colorComboStartColor.Title = "Start Color";
            colorComboStartColor.FillColor = tempshapeoutline.BoarderColor1;
            numericUpDown1.Value = tempshapeoutline.BoarderWidth;

            comboBoxDash.SelectedItem = tempshapeoutline.BoarderDashStyle;
            comboBoxStartCap.SelectedItem = tempshapeoutline.StartLineCap;
            comboBoxEndCap.SelectedItem = tempshapeoutline.EndLineCap;

            checkBoxBlinking.Checked = tempshapeoutline.BoarderBlinking;

            this.colorComboStartColor.ColorChanged += new EventHandler(colorComboStartColor_ColorChanged);
        }

        public void colorComboStartColor_ColorChanged(object sender, EventArgs e)
        {
            tempshapeoutline.BoarderColor1 = colorComboStartColor.FillColor;
            UpdateControls();
        }



        void UpdateControls()
        {


            
            Graphics g = panelSample.CreateGraphics();
            Color c = tabPage1.BackColor; ;
            Color c1 = this.BackColor;
            g.FillRectangle(new SolidBrush(Color.White /*panelSample.BackColor*/), panelSample.ClientRectangle);
            Pen pen = new Pen(tempshapeoutline.BoarderColor1, tempshapeoutline.BoarderWidth);
            pen.DashStyle = tempshapeoutline.BoarderDashStyle;

            if (tempshapeoutline.BoarderWidth != 0)
            {
                int x1, x2, y1, y2;
                x1 = panelSample.ClientRectangle.X + 10;
                y1 = (panelSample.ClientRectangle.Top + panelSample.ClientRectangle.Bottom) / 2;
                x2 = panelSample.ClientRectangle.Right - 10;
                y2 = (panelSample.ClientRectangle.Top + panelSample.ClientRectangle.Bottom) / 2;
                g.DrawLine(pen, x1, y1, x2, y2);
            }
            pen.Dispose();


        }





        private void ShapeFillfrm_Load(object sender, EventArgs e)
        {

            UpdateControls();
            loaded = true;
        }


        private void radioButtonNoFill_Click(object sender, EventArgs e)
        {
            if (loaded)
            {
                UpdateControls();
            }
        }

        private void radioButtonSolid_Click(object sender, EventArgs e)
        {
            if (loaded)
            {
                UpdateControls();
            }
        }





        private void radioButtonPattern_Click(object sender, EventArgs e)
        {
            if (loaded)
            {
                UpdateControls();
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void checkBoxBlinking_CheckedChanged(object sender, EventArgs e)
        {
            
            if (loaded)
            {
                tempshapeoutline.BoarderBlinking = checkBoxBlinking.Checked;
                UpdateControls();
            }
        }

        private void radioButtonDash_Click(object sender, EventArgs e)
        {
            if (loaded)
            {
                UpdateControls();
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            
            if (loaded)
            {
                tempshapeoutline.BoarderWidth = (int)numericUpDown1.Value;
                UpdateControls();
            }
        }

        private void comboBoxDash_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (loaded)
            {
                tempshapeoutline.BoarderDashStyle = (DashStyle)comboBoxDash.SelectedItem;
                UpdateControls();
            }
        }

        private void comboBoxStartCap_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loaded)
            {
                tempshapeoutline.StartLineCap = (LineCap)comboBoxStartCap.SelectedItem;
                UpdateControls();
            }
        }

        private void comboBoxEndCap_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loaded)
            {
                tempshapeoutline.EndLineCap = (LineCap)comboBoxEndCap.SelectedItem;
                UpdateControls();
            }
        }


    }
}
/*
private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.dataGridView1.Controls.Clear();
            if (this.dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString() == "Histogram")
            {
                System.Windows.Forms.Button btn = new System.Windows.Forms.Button();
                btn.Text = "...";
                btn.Font = new System.Drawing.Font("Arial", 7);
                btn.Visible = true; 

                btn.Width = this.dataGridView1.GetCellDisplayRectangle(e.ColumnIndex,
                                e.RowIndex, true).Height;
                btn.Height = this.dataGridView1.GetCellDisplayRectangle(e.ColumnIndex,
                                e.RowIndex, true).Height;

                btn.Click += new EventHandler(btn_Click);

                this.dataGridView1.Controls.Add(btn);

                btn.Location = new System.Drawing.Point(((this.dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Right) -
                        (btn.Width)), this.dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Y);
            }
        }

        void btn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("OK");
        }
		}
		*/