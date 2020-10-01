using DCS.Tools;
using System;
using System.Drawing;
using System.Windows.Forms;

#if EWSAPP
namespace DCS.Draw
{
    /// <summary>
    /// PolyLine tool (a PolyLine is a series of connected straight lines where each line is drawn individually)
    /// </summary>
    internal class ToolPolyLine : ToolObject
    {
        bool secondclick = true;
        public ToolPolyLine()
        {
            //m_Cursor = new Cursor(GetType(), "Pencil.cur");
            //m_Cursor = new Cursor(GetType(), "Pencil.cur");
            try
            {

                m_Cursor = new Cursor(Application.StartupPath + "\\Polyline.cur");
                //m_Cursor = new Cursor(GetType(), "Rectangle.cur");
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private DrawPolyLine newPolyLine;
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
                    newPolyLine = new DrawPolyLine(drawArea.ParentTabGraphicPageControl.Pages(), p.X, p.Y, p.X + 1, p.Y + 1);
                    //newPolyLine.EndPoint = new Point(p.X + 1, p.Y + 1);
                    newPolyLine.oIndex = drawArea.Pages.GetNewobjectoIndex();
                    AddNewObject(drawArea, newPolyLine);
                    _drawingInProcess = true;
                    newPolyLine.MoveHandleTo(new Point(e.X, e.Y), newPolyLine.HandleCount);
                    drawArea.Refresh();
                    secondclick = true;
                }
                else
                {
                    if ((secondclick))
                    {
                        //newPolyLine.EndPoint = p;
                        newPolyLine.MoveHandleTo(p, newPolyLine.HandleCount);
                        drawArea.Refresh();
                        secondclick = false;
                    }
                    else
                    {
                        newPolyLine.AddPoint(p);
                        //newPolyLine.EndPoint = p;
                        newPolyLine.MoveHandleTo(new Point(e.X, e.Y), newPolyLine.HandleCount);
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

            if (newPolyLine == null)
                return; // precaution

            Point point = drawArea.BackTrackMouse(new Point(e.X, e.Y));
            // move last point
            newPolyLine.MoveHandleTo(point, newPolyLine.HandleCount);
            drawArea.Refresh();
        }
    }
} 
#endif