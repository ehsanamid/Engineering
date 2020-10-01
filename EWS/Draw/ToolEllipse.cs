using DCS.Tools;
using System;
using System.Drawing;
using System.Windows.Forms;

#if EWSAPP
namespace DCS.Draw
{
    /// <summary>
    /// Ellipse tool
    /// </summary>
    internal class ToolEllipse : ToolRectangle
    {
        public ToolEllipse()
        {
            try
            {

                m_Cursor = new Cursor(Application.StartupPath + "\\Ellipse.cur");
                //m_Cursor = new Cursor(GetType(), "Rectangle.cur");
            }
            catch (NullReferenceException e)
            {
                MessageBox.Show(e.Message.ToString());
            }
        }

        public override void OnMouseDown(DrawArea drawArea, MouseEventArgs e)
        {
            Point p = drawArea.BackTrackMouse(new Point(e.X, e.Y));
            //if (drawArea.CurrentPen == null)
            //    AddNewObject(drawArea, new DrawEllipse(p.X, p.Y, 1, 1, drawArea.LineColor, drawArea.FillColor, drawArea.DrawFilled, drawArea.LineWidth));
            //else

            DrawEllipse o;
            AddNewObject(drawArea, (o = new DrawEllipse(drawArea.Pages, p.X, p.Y, 1, 1, drawArea.PenType, drawArea.FillColor, drawArea.DrawFilled)));

            o.Dirty = true;
            drawArea.Pages.Dirty = true;
            o.oIndex = drawArea.Pages.GetNewobjectoIndex();
            DCS.Forms.MainForm.Instance().m_propertyGrid.SelectedObject = o;
            DCS.Forms.MainForm.Instance().m_propertyGrid.Refresh();
        }
    }
} 
#endif