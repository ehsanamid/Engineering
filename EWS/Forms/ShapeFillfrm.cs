using DCS.Draw;
using DCS.Tools;
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
    
    public partial class ShapeFillfrm : Form
    {
        //public ShapeFill m_shapefill;

        public ShapeFill tempshapefill;
        
        public ShapeFillfrm(ShapeFill _shapefill) 
        {
            //m_shapefill = _shapefill;
            tempshapefill = new ShapeFill(_shapefill );
            //tempshapefill = _shapefill;
            InitializeComponent();

            int i = 0;
            foreach (FillGradientType val in Enum.GetValues(typeof(FillGradientType)))
            {
                i++;
            }

            int j = i / 3;
            if (i % 3 != 0)
            {
                j++;
            }
            styleList1.Height = 6 + (4 + 49) * j;

            colorComboStartColor.Title = "Start Color";
            colorComboStartColor.FillColor = tempshapefill.FillColor11;

            colorComboEndColor.Title = "End Color";
            colorComboEndColor.FillColor = tempshapefill.FillColor21;

            if (tempshapefill.FillType == FillTypePatern.Transparent)
            {
                radioButtonNoFill.Checked = true;
                radioButtonSolid.Checked = false;
                radioButtonGradient.Checked = false;
            }
            if (tempshapefill.FillType == FillTypePatern.Solid)
            {
                radioButtonNoFill.Checked = false;
                radioButtonSolid.Checked = true;
                radioButtonGradient.Checked = false;
            }
            if (tempshapefill.FillType == FillTypePatern.Gradient)
            {
                radioButtonNoFill.Checked = false;
                radioButtonSolid.Checked = false;
                radioButtonGradient.Checked = true; ;
            }
            checkBoxBlinking.Checked = tempshapefill.Blinking;

            this.colorComboStartColor.ColorChanged += new EventHandler(colorComboStartColor_ColorChanged);
            this.colorComboEndColor.ColorChanged += new EventHandler(colorComboEndColor_ColorChanged);
        }

        public void colorComboStartColor_ColorChanged(object sender, EventArgs e)
        {
            tempshapefill.FillColor11 = colorComboStartColor.FillColor;
            UpdateControls();
        }

        public void colorComboEndColor_ColorChanged(object sender, EventArgs e)
        {
            tempshapefill.FillColor21 = colorComboEndColor.FillColor;
            UpdateControls();
        }

        
        void UpdateControls()
        {
            if (radioButtonNoFill.Checked)
            {
                colorComboStartColor.Visible = false;
                colorComboEndColor.Visible = false;
                checkBoxBlinking.Visible = false;
                panel1.Visible = false;
                panelSample.Visible = false;

                tempshapefill.FillType = FillTypePatern.Transparent;
            }

            if (radioButtonSolid.Checked)
            {

                colorComboStartColor.Visible = true;
                colorComboEndColor.Visible = false;
                checkBoxBlinking.Visible = true;

                colorComboStartColor.Visible = true;
                checkBoxBlinking.Enabled = true;

                tempshapefill.FillType = FillTypePatern.Solid;

                panel1.Visible = false;
                panelSample.Visible = true;
                Graphics g = panelSample.CreateGraphics();
                using (SolidBrush myBrush = new SolidBrush(tempshapefill.FillColor11))
                {
                    g.FillRectangle(myBrush, panelSample.ClientRectangle);
                }
                
            }

            if (radioButtonGradient.Checked)
            {
                colorComboStartColor.Visible = true;
                colorComboEndColor.Visible = false;
                checkBoxBlinking.Visible = true;

                colorComboStartColor.Visible = true;
                colorComboEndColor.Visible = true;
                checkBoxBlinking.Enabled = true;
                panel1.Visible = true;

                tempshapefill.FillType = FillTypePatern.Gradient;

                panelSample.Visible = true;
                Graphics g = panelSample.CreateGraphics();
                int x1, x2, y1, y2;
                x1 = panelSample.ClientRectangle.X;
                y1 = panelSample.ClientRectangle.Y;
                x2 = panelSample.ClientRectangle.Right;
                y2 = panelSample.ClientRectangle.Bottom;
                switch (tempshapefill.Fillgradienttype)
                {
                    case FillGradientType.Buttom2Top:
                        using (LinearGradientBrush br = new LinearGradientBrush(new Point(x1, y2), new Point(x1, y1),
                            tempshapefill.FillColor11, tempshapefill.FillColor21))
                        {
                            g.FillRectangle(br, panelSample.ClientRectangle);
                            g.DrawRectangle(Pens.Black, panelSample.ClientRectangle);
                        }
                        break;
                    case FillGradientType.Left2Right:
                        using (LinearGradientBrush br = new LinearGradientBrush(new Point(x1, y1), new Point(x1, y2),
                           tempshapefill.FillColor11, tempshapefill.FillColor21))
                        {
                            g.FillRectangle(br, panelSample.ClientRectangle);
                            g.DrawRectangle(Pens.Black, panelSample.ClientRectangle);
                        }
                        break;
                    case FillGradientType.Top2Buttom:
                        using (LinearGradientBrush br = new LinearGradientBrush(new Point(x1, y1), new Point(x1, y2),
                            tempshapefill.FillColor11, tempshapefill.FillColor21))
                        {
                            g.FillRectangle(br, panelSample.ClientRectangle);
                            g.DrawRectangle(Pens.Black, panelSample.ClientRectangle);
                        }
                        break;
                    case FillGradientType.Right2Left:
                        using (LinearGradientBrush br = new LinearGradientBrush(new Point(x2, y1), new Point(x1, y1),
                            tempshapefill.FillColor11, tempshapefill.FillColor21))
                        {
                            g.FillRectangle(br, panelSample.ClientRectangle);
                            g.DrawRectangle(Pens.Black, panelSample.ClientRectangle);
                        }
                        break;
                    case FillGradientType.NE2SW:
                        using (LinearGradientBrush br = new LinearGradientBrush(new Point(x2, y1), new Point(x1, y2),
                            tempshapefill.FillColor11, tempshapefill.FillColor21))
                        {
                            g.FillRectangle(br, panelSample.ClientRectangle);
                            g.DrawRectangle(Pens.Black, panelSample.ClientRectangle);
                        }
                        break;
                    case FillGradientType.NW2SE:
                        using (LinearGradientBrush br = new LinearGradientBrush(new Point(x1, y1), new Point(x2, y2),
                            tempshapefill.FillColor11, tempshapefill.FillColor21))
                        {
                            g.FillRectangle(br, panelSample.ClientRectangle);
                            g.DrawRectangle(Pens.Black, panelSample.ClientRectangle);
                        }
                        break;
                    case FillGradientType.SE2NW:
                        using (LinearGradientBrush br = new LinearGradientBrush(new Point(x2, y2), new Point(x1, y1),
                            tempshapefill.FillColor11, tempshapefill.FillColor21))
                        {
                            g.FillRectangle(br, panelSample.ClientRectangle);
                            g.DrawRectangle(Pens.Black, panelSample.ClientRectangle);
                        }
                        break;
                    case FillGradientType.SW2NE:
                        using (LinearGradientBrush br = new LinearGradientBrush(new Point(x1, y2), new Point(x2, y1),
                            tempshapefill.FillColor11, tempshapefill.FillColor21))
                        {
                            g.FillRectangle(br, panelSample.ClientRectangle);
                            g.DrawRectangle(Pens.Black, panelSample.ClientRectangle);
                        }
                        break;
                    case FillGradientType.FromHCenter:
                        using (LinearGradientBrush br = new LinearGradientBrush(new Point(x1, y1), new Point(x1, y2),
                            tempshapefill.FillColor11, tempshapefill.FillColor21))
                        {
                            ColorBlend cb = new ColorBlend();
                            cb.Colors = new Color[] { tempshapefill.FillColor21, tempshapefill.FillColor11, tempshapefill.FillColor21 };
                            cb.Positions = new float[] { 0, 0.5F, 1 };
                            br.InterpolationColors = cb;
                            g.FillRectangle(br, panelSample.ClientRectangle);
                            g.DrawRectangle(Pens.Black, panelSample.ClientRectangle);
                        }
                        break;
                    case FillGradientType.FromVCenter:
                        using (LinearGradientBrush br = new LinearGradientBrush(new Point(x1, y1), new Point(x2, y1),
                           tempshapefill.FillColor11, tempshapefill.FillColor21))
                        {
                            ColorBlend cb = new ColorBlend();
                            cb.Colors = new Color[] { tempshapefill.FillColor21, tempshapefill.FillColor11, tempshapefill.FillColor21 };
                            cb.Positions = new float[] { 0, 0.5F, 1 };
                            br.InterpolationColors = cb;
                            g.FillRectangle(br, panelSample.ClientRectangle);
                            g.DrawRectangle(Pens.Black, panelSample.ClientRectangle);
                        }
                        break;
                    case FillGradientType.ToHCenter:
                        using (LinearGradientBrush br = new LinearGradientBrush(new Point(x1, y1), new Point(x1, y2),
                            tempshapefill.FillColor11, tempshapefill.FillColor21))
                        {
                            ColorBlend cb = new ColorBlend();
                            cb.Colors = new Color[] { tempshapefill.FillColor11, tempshapefill.FillColor21, tempshapefill.FillColor11 };
                            cb.Positions = new float[] { 0, 0.5F, 1 };
                            br.InterpolationColors = cb;
                            g.FillRectangle(br, panelSample.ClientRectangle);
                            g.DrawRectangle(Pens.Black, panelSample.ClientRectangle);
                        }
                        break;
                    case FillGradientType.ToVCenter:
                        using (LinearGradientBrush br = new LinearGradientBrush(new Point(x1, y1), new Point(x2, y1),
                            tempshapefill.FillColor11, tempshapefill.FillColor21))
                        {
                            ColorBlend cb = new ColorBlend();
                            cb.Colors = new Color[] { tempshapefill.FillColor11, tempshapefill.FillColor21, tempshapefill.FillColor11 };
                            cb.Positions = new float[] { 0, 0.5F, 1 };
                            br.InterpolationColors = cb;
                            g.FillRectangle(br, panelSample.ClientRectangle);
                            g.DrawRectangle(Pens.Black, panelSample.ClientRectangle);
                        }
                        break;
                }
            }
        }

        

        

        private void ShapeFillfrm_Load(object sender, EventArgs e)
        {
            
            UpdateControls();
        }

        
        private void radioButtonNoFill_Click(object sender, EventArgs e)
        {
            UpdateControls();
        }

        private void radioButtonSolid_Click(object sender, EventArgs e)
        {
            UpdateControls();
        }

        
        
       

        private void checkBoxOneColor_Click(object sender, EventArgs e)
        {
            
        }

        private void radioButtonGradiant_Click(object sender, EventArgs e)
        {
            UpdateControls();
        }

        private void radioButtonPattern_Click(object sender, EventArgs e)
        {
            UpdateControls();
        }

        
        

        

        private void styleList1_MouseClick(object sender, MouseEventArgs e)
        {
            Point pt = new Point(e.X,e.Y);
            foreach (ShapeBrush sb in styleList1.brushList)
            {
                if (sb.ReferenceRectangle.Contains(pt))
                {
                    tempshapefill.Fillgradienttype = sb.fillgradienttype;
                    break;
                }
            }
            UpdateControls();
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
            tempshapefill.Blinking = checkBoxBlinking.Checked;
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