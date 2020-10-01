using DocToolkit;
using DCS.Tools;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

#if EWSAPP
namespace DCS.Draw
{
    /// <summary>
    /// ObjectRectangle tool
    /// </summary>
    internal class ToolText : ToolObject
    {
        public ToolText()
        {
            try
            {
                m_Cursor = new Cursor(Application.StartupPath + "\\Text.cur");
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        public override void OnMouseDown(DrawArea drawArea, MouseEventArgs e)
        {
            Point p = drawArea.BackTrackMouse(new Point(e.X, e.Y));
            TextDialog td = new TextDialog();

            string t = "Text";
            Color c = Color.Black;
            Font f = new Font("Arial", 10);
            DrawText o;
            AddNewObject(drawArea, (o = new DrawText(drawArea.Pages, p.X, p.Y, t, f, c)));
            o.Dirty = true;
            o.oIndex = drawArea.Pages.GetNewobjectoIndex();
            DCS.Forms.MainForm.Instance().m_propertyGrid.SelectedObject = o;
            DCS.Forms.MainForm.Instance().m_propertyGrid.Refresh();

        }

        public override void OnMouseMove(DrawArea drawArea, MouseEventArgs e)
        {
            drawArea.Cursor = m_Cursor;
            if (e.Button == MouseButtons.Left)
            {
                Point point = drawArea.BackTrackMouse(new Point(e.X, e.Y));
                int index = drawArea.ParentTabGraphicPageControl.NoOfObjectsinPage - 1;
                drawArea.ParentTabGraphicPageControl.Pages().GetObject(drawArea.ParentTabGraphicPageControl.Pages().ActivePageNo, index).MoveHandleTo(point, 5);
                Trace.WriteLine("OnMouseMove ");
                drawArea.Refresh();
            }
        }
    }
} 
#endif