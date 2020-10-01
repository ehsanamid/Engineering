using DCS.Forms;
using DCS.DCSTables;
using DCS.Tools;
using System;
using System.Drawing;
using System.Windows.Forms;

#if EWSAPP
namespace DCS.Draw.FBD
{
	/// <summary>
	/// ObjectRectangle tool
	/// </summary>
	internal class ToolConstant : ToolObject
	{
        //public static int DeltaX = 30;
        //public static int DeltaY = 180;
        Color VarColor = Color.Black;
        Color VarFillColor = Color.Blue;

        public ToolConstant()
		{
            try
            {

                m_Cursor = new Cursor(Application.StartupPath + "\\Constant.cur");
                //m_Cursor = new Cursor(GetType(), "Rectangle.cur");
            }
            catch (NullReferenceException e)
            {
                MessageBox.Show(e.Message.ToString());
            }
		}

		public override void OnMouseDown(DrawArea drawArea, MouseEventArgs e)
		{
            Point p;
            if (drawArea.SnapEnable)
            {
                p = drawArea.BackTrackMouse(new Point(drawArea.FittoSnap(e.X, drawArea.SnapX), drawArea.FittoSnap(e.Y, drawArea.SnapY)));
            }
            else
            {
                p = drawArea.BackTrackMouse(new Point(e.X, e.Y));
            }

            //VariableForm varlistfrm = new VariableForm(((TabFBDPageControl)drawArea.ParentTabGraphicPageControl).pouID);
            
		}

		public override void OnMouseMove(DrawArea drawArea, MouseEventArgs e)
		{
            drawArea.Cursor = m_Cursor;
			//int al = drawArea.TheLayers.ActiveLayerIndex;
			if (e.Button == MouseButtons.Left)
			{
                Point p;
                if (drawArea.SnapEnable)
                {
                    p = drawArea.BackTrackMouse(new Point(drawArea.FittoSnap(e.X, drawArea.SnapX), drawArea.FittoSnap(e.Y, drawArea.SnapY)));
                }
                else
                {
                    p = drawArea.BackTrackMouse(new Point(e.X, e.Y));
                }
                //drawArea.Graphics[0].MoveHandleTo(p, 5);
				drawArea.Refresh();
			}
		}
	}
}

#endif