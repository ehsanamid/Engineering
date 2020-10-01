using System.Drawing;
using System.Windows.Forms;
using EWSTools;
using DocToolkit.Forms;

namespace DocToolkit
{
	/// <summary>
	/// Rectangle tool
	/// </summary>
	internal class ToolDynamic : ToolObject
	{
        
        public static int DeltaX  = 30;
        public static int DeltaY = 180;
        public int TitleSize;
        Color FunctionColor = Color.Black;
        Color FunctionFillColor = Color.Blue;
        int FunctionLineWidth = 1;
        public ToolDynamic()
		{
			Cursor = new Cursor(GetType(), "Function.cur");
            DeltaX = MainForm.UnitSize * MainForm.BaseSize ;
            DeltaY = MainForm.UnitSize * MainForm.BaseSize * 6 ;
            TitleSize = MainForm.UnitSize * MainForm.BaseSize;
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
            //if (drawArea.CurrentPen == null)
            //    AddNewObject(drawArea, new DrawRectangle(p.X, p.Y, 1, 1, drawArea.LineColor, drawArea.FillColor, drawArea.DrawFilled, drawArea.LineWidth));
            //else
            //    AddNewObject(drawArea, new DrawRectangle(p.X, p.Y, 1, 1, drawArea.PenType, drawArea.FillColor, drawArea.DrawFilled));
            AddNewObject(drawArea, new DrawDynamic(p.X, p.Y, DeltaX, DeltaY, FunctionColor, FunctionFillColor, false, FunctionLineWidth));
		}

		public override void OnMouseMove(DrawArea drawArea, MouseEventArgs e)
		{
			drawArea.Cursor = Cursor;
			int al = drawArea.TheLayers.ActiveLayerIndex;
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
                //drawArea.TheLayers[al].Graphics[0].MoveHandleTo(p, 5);
				drawArea.Refresh();
			}
		}
	}
}