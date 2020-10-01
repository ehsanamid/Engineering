using DCS.Draw;
using System;
using System.Drawing;
using System.Windows.Forms;

#if EWSAPP
namespace DCS.Draw
{
    /// <summary>
    /// Scribble tool
    /// </summary>
    internal class ToolPolygon : ToolObject
    {
        bool secondclick = true;
        public ToolPolygon()
        {
            //m_Cursor = new Cursor(GetType(), "Pencil.cur");
            try
            {

                m_Cursor = new Cursor(Application.StartupPath + "\\Polygon.cur");
                //m_Cursor = new Cursor(GetType(), "Rectangle.cur");
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private DrawPolygon newPolygon;
        public bool _drawingInProcess = false; // Set to true when drawing

        /// <summary>
        /// Left nouse button is pressed
        /// </summary>
        /// <param name="drawArea"></param>
        /// <param name="e"></param>
        public override void OnMouseDown(DrawArea drawArea, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                _drawingInProcess = false;
                //newPolyLine = null;
            }
            else
            {
                Point p = drawArea.BackTrackMouse(new Point(e.X, e.Y));
                if (_drawingInProcess == false)
                {
                    newPolygon = new DrawPolygon(drawArea.ParentTabGraphicPageControl.Pages(), p.X, p.Y, p.X + 1, p.Y + 1);
                    //newPolygon.EndPoint = new Point(p.X + 1, p.Y + 1);
                    newPolygon.oIndex = drawArea.Pages.GetNewobjectoIndex();
                    AddNewObject(drawArea, newPolygon);
                    _drawingInProcess = true;
                    newPolygon.MoveHandleTo(new Point(e.X, e.Y), newPolygon.HandleCount);
                    drawArea.Refresh();
                    secondclick = true;
                }
                else
                {
                    if ((secondclick))
                    {
                        //newPolygon.EndPoint = p;
                        newPolygon.MoveHandleTo(p, newPolygon.HandleCount);
                        drawArea.Refresh();
                        secondclick = false;
                    }
                    else
                    {
                        newPolygon.AddPoint(p);
                        //newPolygon.EndPoint = p;
                        newPolygon.MoveHandleTo(new Point(e.X, e.Y), newPolygon.HandleCount);
                        drawArea.Refresh();
                        secondclick = false;
                    }
                }
            }
        }

        /// <summary>
        /// Mouse move - resize new polygon
        /// </summary>
        /// <param name="drawArea"></param>
        /// <param name="e"></param>
        public override void OnMouseMove(DrawArea drawArea, MouseEventArgs e)
        {
            drawArea.Cursor = m_Cursor;

            if (e.Button != MouseButtons.Left)
                return;

            if (newPolygon == null)
                return; // precaution

            Point point = drawArea.BackTrackMouse(new Point(e.X, e.Y));
            // move last point
            newPolygon.MoveHandleTo(point, newPolygon.HandleCount);
            drawArea.Refresh();
        }
    }
} 
#endif