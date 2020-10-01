using DCS.Tools;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

#if EWSAPP
namespace DCS.Draw
{
    /// <summary>
    /// Line tool
    /// </summary>
    internal class ToolLine : ToolObject
    {
        public ToolLine()
        {

            try
            {

                m_Cursor = new Cursor(Application.StartupPath + "\\Line.cur");
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
            Trace.WriteLine("Line OnMouseDown X=" + e.X.ToString() + " Y=", e.Y.ToString());
            if (drawArea.SnapEnable)
            {
                p = drawArea.BackTrackMouse(new Point(drawArea.FittoSnap(e.X, drawArea.SnapX), drawArea.FittoSnap(e.Y, drawArea.SnapY)));
            }
            else
            {
                p = drawArea.BackTrackMouse(new Point(e.X, e.Y));
            }
            Trace.WriteLine("Line OnMouseDown pX=" + p.X.ToString() + " pY="+ p.Y.ToString());
            DrawLine o;
            if (drawArea.PenType == DrawingPens.PenType.Generic)
            {
                //AddNewObject(drawArea, new DrawLine(p.X, p.Y, p.X + 1, p.Y + 1, drawArea.LineColor, drawArea.LineWidth));

                AddNewObject(drawArea, (o = new DrawLine(drawArea.Pages, p.X, p.Y, p.X + 1, p.Y + 1)));
            }
            else
            {
                //AddNewObject(drawArea, new DrawLine(p.X, p.Y, p.X + 1, p.Y + 1, drawArea.PenType));
                AddNewObject(drawArea, (o = new DrawLine(drawArea.Pages, p.X, p.Y, p.X + 1, p.Y + 1)));
            }
            o.Dirty = true;
            drawArea.Pages.Dirty = true;
            o.oIndex = drawArea.Pages.GetNewobjectoIndex();
            DCS.Forms.MainForm.Instance().m_propertyGrid.SelectedObject = o;
            DCS.Forms.MainForm.Instance().m_propertyGrid.Refresh();

        }

        public override void OnMouseMove(DrawArea drawArea, MouseEventArgs e)
        {
            //drawArea.Cursor = m_Cursor;

            if (e.Button == MouseButtons.Left)
            {
                //Trace.WriteLine("Line OnMouseMove X=" + e.X.ToString() + " Y="+ e.Y.ToString());
                Point p;
                if (drawArea.SnapEnable)
                {
                    p = drawArea.BackTrackMouse(new Point(drawArea.FittoSnap(e.X, drawArea.SnapX), drawArea.FittoSnap(e.Y, drawArea.SnapY)));
                }
                else
                {
                    p = drawArea.BackTrackMouse(new Point(e.X, e.Y));
                }
                //Trace.WriteLine("Line OnMouseMove pX=" + p.X.ToString() + " pY="+ p.Y.ToString());
                int index = drawArea.ParentTabGraphicPageControl.NoOfObjectsinPage - 1;
                drawArea.Pages.GetObject(drawArea.Pages.ActivePageNo, index).MoveHandleTo(p, 2);
                drawArea.Refresh();
            }
        }
    }
} 
#endif