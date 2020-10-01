using System.Drawing;
using System.Windows.Forms;
using System;
//using EWS.Properties;
using System.Diagnostics;
using DCS.Tools;

#if EWSAPP
namespace DCS.Draw
{
    /// <summary>
    /// ObjectRectangle tool
    /// </summary>
    internal class ToolRectangle : ToolObject
    {
        public ToolRectangle()
        {
            try
            {
                m_Cursor = new Cursor(Application.StartupPath + "\\Rectangle.cur");
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message.ToString());
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
            DrawRectangle o;
            //if (drawArea.CurrentPen == null)
            //    AddNewObject(drawArea,(o =  new DrawRectangle(p.X, p.Y, 1, 1, drawArea.LineColor, drawArea.FillColor, drawArea.DrawFilled, drawArea.LineWidth)));
            //else
            //AddNewObject(drawArea, (o = new DrawRectangle(drawArea.ParentTabGraphicPageControl.Pages(),p.X, p.Y, 1, 1, drawArea.PenType, drawArea.FillColor, drawArea.DrawFilled)));
            AddNewObject(drawArea, (o = new DrawRectangle(drawArea.ParentTabGraphicPageControl.Pages(), p.X, p.Y, 1, 1)));

            o.Dirty = true;
            drawArea.Pages.Dirty = true;
            o.oIndex = drawArea.Pages.GetNewobjectoIndex();
            DCS.Forms.MainForm.Instance().m_propertyGrid.SelectedObject = o;
            DCS.Forms.MainForm.Instance().m_propertyGrid.Refresh();
        }

        public override void OnMouseMove(DrawArea drawArea, MouseEventArgs e)
        {
            //Trace.WriteLine("OnMouseMove");
            drawArea.Cursor = m_Cursor;
            if (e.Button == MouseButtons.Left)
            {
                //Trace.WriteLine("Rect OnMouseMove X=" + e.X.ToString() + " Y="+ e.Y.ToString());
                Point point;
                if (drawArea.SnapEnable)
                {
                    point = drawArea.BackTrackMouse(new Point(drawArea.FittoSnap(e.X, drawArea.SnapX), drawArea.FittoSnap(e.Y, drawArea.SnapY)));
                }
                else
                {
                    point = drawArea.BackTrackMouse(new Point(e.X, e.Y));
                }
                //Trace.WriteLine("Rect OnMouseMove pX=" + p.X.ToString() + " pY="+ p.Y.ToString());
                int index = drawArea.ParentTabGraphicPageControl.NoOfObjectsinPage - 1;
                drawArea.Pages.GetObject(drawArea.Pages.ActivePageNo, index).MoveHandleTo(point, 5);
                // Trace.WriteLine("OnMouseMove ");
                drawArea.Refresh();
            }
        }
    }
} 
#endif