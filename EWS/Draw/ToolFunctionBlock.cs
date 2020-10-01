using System.Drawing;
using System.Windows.Forms;

namespace DocToolkit
{
	/// <summary>
	/// Rectangle tool
	/// </summary>
	internal class ToolVariable : ToolObject
	{
        public static int DeltaX = 30;
        public static int DeltaY = 180;
        Color VarColor = Color.Black;
        Color VarFillColor = Color.Blue;
        int VarLineWidth = 1;
        public ToolVariable()
		{
			Cursor = new Cursor(GetType(), "Variable.cur");
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
            AddNewObject(drawArea, new DrawVariable(p.X, p.Y, DeltaY, DeltaX, VarColor, VarFillColor, false, VarLineWidth));
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