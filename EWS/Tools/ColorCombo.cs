using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DCS.Tools
{
    
    public partial class ColorCombo : UserControl
    {
        public event EventHandler ColorChanged;

        private void FunctionThatRaisesEvent()
        {
            //Null check makes sure the main page is attached to the event
            if (this.ColorChanged != null)
                this.ColorChanged(new object(), new EventArgs());
        }
        Color fillcolor;
        public Color FillColor
        {
            get
            {
                return fillcolor;
            }
            set
            {
                fillcolor = value;
            }
        }

        public string Title
        {
            get
            {
                return label_StartColor.Text;
            }
            set
            {
                label_StartColor.Text = value;
            }
        }
        

        public string LabelColor
        {
            get
            {
                return labelColor1.Text;
            }
            set
            {
                labelColor1.Text = value;
            }
        }
        public ColorCombo() 
        {
          
            //tempshapefill = _shapefill;
            InitializeComponent();
            
            

        }

        
        
        private void SetStartColor(Color newColor)
        {
            string startRGBText = newColor.ToString().TrimEnd(']').Substring(7);
            //comboBox_StartColor.Text = startRGBText;
            KnownColor kn = newColor.ToKnownColor();
            if (kn == 0)
            {
                labelColor1.Text = startRGBText;
            }
            else
            {
                labelColor1.Text = newColor.ToKnownColor().ToString();
            }
           // label_StartColor.Text = "Start Color: " + startRGBText;
            panel_StartColor.BackColor = newColor;
        }





        private void ShapeFillfrm_Load(object sender, EventArgs e)
        {

            List<Color> colors = new List<Color>();
           // colors.Add(Color.Transparent);
            for (KnownColor enumValue = KnownColor.AliceBlue; enumValue <= KnownColor.YellowGreen; enumValue++)
            {
                colors.Add(Color.FromKnownColor(enumValue));
            }

            SetStartColor(fillcolor);
           
        }

        
        
        private void button_SelectStartColor_Click(object sender, EventArgs e)
        {
            ColorDialog startColorDialog = new ColorDialog();
            startColorDialog.Color = panel_StartColor.BackColor;
            if (startColorDialog.ShowDialog() == DialogResult.OK)
            {
                SetStartColor(startColorDialog.Color);
                fillcolor = startColorDialog.Color;
                FunctionThatRaisesEvent();
            }
        }

        private void ColorCombo_VisibleChanged(object sender, EventArgs e)
        {

            button_SelectStartColor.Visible = Visible;
            this.panel_StartColor.Visible = Visible;
            this.panelColor1.Visible = Visible;
            label_StartColor.Visible = Visible;
            labelColor1.Visible = Visible;
            button_SelectStartColor.Visible = Visible;
        }

        private void ColorCombo_EnabledChanged(object sender, EventArgs e)
        {
            button_SelectStartColor.Enabled = Enabled;
        }

        private void panel_StartColor_Paint(object sender, PaintEventArgs e)
        {

        }       
    }
}
