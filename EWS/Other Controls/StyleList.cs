using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EWS.OtherControls
{
    public partial class StyleList : UserControl
    {
        private const int BRUSH_IMAGE_SIZE = 30;

        public  List<ShapeBrush> brushList = new List<ShapeBrush>();
        public Color color1 = Color.Black;
        public Color color2 = Color.White;
        public StyleList()
        {
            InitializeComponent();
            
        }

        private void StyleList_Load(object sender, EventArgs e)
        {
            int i, j;
            int width = this.Width;
            //int brushwidth = (width - 12 )/3;
            int brushwidth = 49;
            i = 0;
            j = 0;
            foreach (FillGradientType val in Enum.GetValues(typeof(FillGradientType)))
            {
                ShapeBrush sb = new ShapeBrush(new Rectangle(3+(4+brushwidth)*i,3+(4+brushwidth)*j,brushwidth,brushwidth),color1,color2,val);
                brushList.Add(sb);
                i++;
                if (i == 3)
                {
                    j++;
                    i = 0;
                }
            }
            
        }

        private void StyleList_Paint(object sender, PaintEventArgs e)
        {
            foreach (ShapeBrush sb in brushList)
            {
                sb.Draw(e.Graphics);
            }
        }
    }
}
