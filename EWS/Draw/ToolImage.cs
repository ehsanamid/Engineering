using DCS.Tools;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

#if EWSAPP
namespace DCS.Draw
{
    /// <summary>
    /// Image tool
    /// </summary>
    internal class ToolImage : ToolObject
    {
        public ToolImage()
        {
            //m_Cursor = new Cursor(GetType(), "Rectangle.cur");
            try
            {

                m_Cursor = new Cursor(Application.StartupPath + "\\Rectangle.cur");
                //m_Cursor = new Cursor(GetType(), "Rectangle.cur");
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
            DrawImage o;
            AddNewObject(drawArea, (o = new DrawImage(drawArea.Pages, p.X, p.Y)));

            o.Dirty = true;
            drawArea.Pages.Dirty = true;
            o.oIndex = drawArea.Pages.GetNewobjectoIndex();
            DCS.Forms.MainForm.Instance().m_propertyGrid.SelectedObject = o;
            DCS.Forms.MainForm.Instance().m_propertyGrid.Refresh();
        }

        public override void OnMouseMove(DrawArea drawArea, MouseEventArgs e)
        {
            drawArea.Cursor = m_Cursor;

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
                int index = drawArea.ParentTabGraphicPageControl.NoOfObjectsinPage - 1;
                drawArea.Pages.GetObject(drawArea.Pages.ActivePageNo, index).MoveHandleTo(p, 5);
                //Trace.WriteLine("OnMouseMove " );

                drawArea.Refresh();
            }
        }

        public override void OnMouseUp(DrawArea drawArea, MouseEventArgs e)
        {
            //OpenFileDialog ofd = new OpenFileDialog();
            //ofd.Title = "Select an Image to insert into map";
            //ofd.Filter = "Bitmap (*.bmp)|*.bmp|JPEG (*.jpg)|*.jpg|Fireworks (*.png)|*.png|GIF (*.gif)|*.gif|Icon (*.ico)|*.ico|All files|*.*";
            //ofd.InitialDirectory = Environment.SpecialFolder.MyPictures.ToString();
            ////int al = drawArea.TheLayers.ActiveLayerIndex;
            //if (ofd.ShowDialog() == DialogResult.OK)
            //    ((DrawImage)drawArea.graphicsList[0]).TheImage = (Bitmap)Bitmap.FromFile(ofd.FileName);
            //ofd.Dispose();
            //base.OnMouseUp(drawArea, e);
        }
    }
} 
#endif