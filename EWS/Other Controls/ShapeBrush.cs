using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace EWS.OtherControls
{
    

    public class ShapeBrush : Object
    {
        public ShapeBrush(Rectangle rec,Color _color1,Color _color2,FillGradientType fgt)
        {
            referenceRct = rec;
            _fillgradienttype = fgt;
            color1 = _color1;
            color2 = _color2;
            switch (fgt)
            {
                case FillGradientType.Buttom2Top:
                case FillGradientType.Left2Right:
                case FillGradientType.Top2Buttom:
                case FillGradientType.Right2Left:
                case FillGradientType.NE2SW:
                case FillGradientType.NW2SE:
                case FillGradientType.SE2NW:
                case FillGradientType.SW2NE:
                    surroundingColors.Add(color1);
                    surroundingColors.Add(color2);
                    positions.Add(0.0f);
                    positions.Add(1.0f);
                    break;
                case FillGradientType.FromHCenter:
                case FillGradientType.FromVCenter:
                    surroundingColors.Add(color1);
                    surroundingColors.Add(color2);
                    surroundingColors.Add(color1);
                    positions.Add(0.0f);
                    positions.Add(0.5f);
                    positions.Add(1.0f);
                    break;
                case FillGradientType.ToHCenter:
                case FillGradientType.ToVCenter:
                    surroundingColors.Add(color2);
                    surroundingColors.Add(color1);
                    surroundingColors.Add(color2);
                    positions.Add(0.0f);
                    positions.Add(0.5f);
                    positions.Add(1.0f);
                    break;
            }
           
        }

        

        

        #region properties describing the brush for this shape



        private FillGradientType _fillgradienttype;
        public FillGradientType fillgradienttype
        {
            get
            {
                return _fillgradienttype;
            }
            set
            {
                _fillgradienttype = value;
            }
        }

        private Rectangle referenceRct;
        public Rectangle ReferenceRectangle
        {
            get { return referenceRct; }
            set { referenceRct = value; }
        }

       
        
        private Color color1 = Color.Black;
       
        private Color color2 = Color.Black;
        

        protected List<Color> surroundingColors = new List<Color>();
        
        protected List<float> positions = new List<float>();
       
        #endregion

        

        #region SetBrush and associated methods
         //private ColorBlend cb = new ColorBlend();

        
        
        #endregion

        #region Draw method

        /// <summary>
        /// Draw a thumbnail using the current brush
        /// </summary>
        /// <param name="g"></param>
        /// <param name="rct">The location and size of the thumbnail</param>
        public void Draw(Graphics g)
        {
            int x1, x2, y1, y2;
            x1 = referenceRct.X;
            y1 = referenceRct.Y;
            x2 = referenceRct.Right;
            y2 = referenceRct.Bottom;
            switch (_fillgradienttype)
            {
                case FillGradientType.Buttom2Top:
                    using (LinearGradientBrush br = new LinearGradientBrush(new Point(x1, y2), new Point(x1, y1), 
                        color1, color2))
                    {
                        g.FillRectangle(br, referenceRct);
                        g.DrawRectangle(Pens.Black, referenceRct);
                    }
                    break;
                case FillGradientType.Left2Right:
                     using (LinearGradientBrush br = new LinearGradientBrush(new Point(x1, y1),new Point(x1, y2), 
                        color1, color2))
                    {
                        g.FillRectangle(br, referenceRct);
                        g.DrawRectangle(Pens.Black, referenceRct);
                    }
                    break;
                case FillGradientType.Top2Buttom:
                    using (LinearGradientBrush br = new LinearGradientBrush(new Point(x1, y1),new Point(x1, y2), 
                        color1, color2))
                    {
                        g.FillRectangle(br, referenceRct);
                        g.DrawRectangle(Pens.Black, referenceRct);
                    }
                    break;
                case FillGradientType.Right2Left:
                    using (LinearGradientBrush br = new LinearGradientBrush(new Point(x2, y1),new Point(x1, y1), 
                        color1, color2))
                    {
                        g.FillRectangle(br, referenceRct);
                        g.DrawRectangle(Pens.Black, referenceRct);
                    }
                    break;
                case FillGradientType.NE2SW:
                    using (LinearGradientBrush br = new LinearGradientBrush(new Point(x2, y1),new Point(x1, y2), 
                        color1, color2))
                    {
                        g.FillRectangle(br, referenceRct);
                        g.DrawRectangle(Pens.Black, referenceRct);
                    }
                    break;
                case FillGradientType.NW2SE:
                    using (LinearGradientBrush br = new LinearGradientBrush(new Point(x1, y1),new Point(x2, y2), 
                        color1, color2))
                    {
                        g.FillRectangle(br, referenceRct);
                        g.DrawRectangle(Pens.Black, referenceRct);
                    }
                    break;
                case FillGradientType.SE2NW:
                    using (LinearGradientBrush br = new LinearGradientBrush(new Point(x2, y2),new Point(x1, y1), 
                        color1, color2))
                    {
                        g.FillRectangle(br, referenceRct);
                        g.DrawRectangle(Pens.Black, referenceRct);
                    }
                    break;
                case FillGradientType.SW2NE:
                    using (LinearGradientBrush br = new LinearGradientBrush(new Point(x1, y2),new Point(x2, y1), 
                        color1, color2))
                    {
                        g.FillRectangle(br, referenceRct);
                        g.DrawRectangle(Pens.Black, referenceRct);
                    }
                    break;
                case FillGradientType.FromHCenter:
                    using (LinearGradientBrush br = new LinearGradientBrush(new Point(x1, y1), new Point(x1, y2),
                        color1, color2))
                    {
                        ColorBlend cb = new ColorBlend();
                        cb.Colors = new Color[] { color2, color1, color2 };
                        cb.Positions = new float[] { 0, 0.5F, 1 };
                        br.InterpolationColors = cb;
                        g.FillRectangle(br, referenceRct);
                        g.DrawRectangle(Pens.Black, referenceRct);
                    }
                    break;
                case FillGradientType.FromVCenter:
                     using (LinearGradientBrush br = new LinearGradientBrush(new Point(x1, y1), new Point(x2, y1),
                        color1, color2))
                    {
                        ColorBlend cb = new ColorBlend();
                        cb.Colors = new Color[] { color2, color1, color2 };
                        cb.Positions = new float[] { 0, 0.5F, 1 };
                        br.InterpolationColors = cb;
                        g.FillRectangle(br, referenceRct);
                        g.DrawRectangle(Pens.Black, referenceRct);
                    }
                    break;
                case FillGradientType.ToHCenter:
                    using (LinearGradientBrush br = new LinearGradientBrush(new Point(x1, y1), new Point(x1, y2),
                        color1, color2))
                    {
                        ColorBlend cb = new ColorBlend();
                        cb.Colors = new Color[] { color1, color2, color1 };
                        cb.Positions = new float[] { 0, 0.5F, 1 };
                        br.InterpolationColors = cb;
                        g.FillRectangle(br, referenceRct);
                        g.DrawRectangle(Pens.Black, referenceRct);
                    }
                    break;
                case FillGradientType.ToVCenter:
                    using (LinearGradientBrush br = new LinearGradientBrush(new Point(x1, y1), new Point(x2, y1),
                        color1, color2))
                    {
                        ColorBlend cb = new ColorBlend();
                        cb.Colors = new Color[] { color1, color2, color1 };
                        cb.Positions = new float[] { 0, 0.5F, 1 };
                        br.InterpolationColors = cb;
                        g.FillRectangle(br, referenceRct);
                        g.DrawRectangle(Pens.Black, referenceRct);
                    }
                    break;
            }

            //GraphicsPath gp = null;
            //ShapeBase sb = new ShapeBase();

            //sb.CurrentBrush = this;
            //gp = ShapeBase.CreateRoundedRectangle(sb.CurrentBrush.referenceRct, 10);

            //Brush br = SetBrush(sb.CurrentBrush.referenceRct, gp);
           // g.FillPath(br, gp);
            //g.DrawPath(new Pen(Color.Black), gp);

            //gp.Dispose();
            //br.Dispose();
        }

        
        #endregion

       
    }
}
