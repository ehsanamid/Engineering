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
    internal class ToolCurve : ToolObject
    {
        bool secondclick = true;
        public ToolCurve()
        {
            //m_Cursor = new Cursor(GetType(), "Pencil.cur");
            //m_Cursor = new Cursor(GetType(), "Pencil.cur");
            try
            {

                m_Cursor = new Cursor(Application.StartupPath + "\\Curve.cur");
                //m_Cursor = new Cursor(GetType(), "Rectangle.cur");
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private DrawCurve newCurve;
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
                    newCurve = new DrawCurve(drawArea.ParentTabGraphicPageControl.Pages(), p.X, p.Y, p.X + 1, p.Y + 1);
                    newCurve.oIndex = drawArea.Pages.GetNewobjectoIndex();
                    AddNewObject(drawArea, newCurve);
                    _drawingInProcess = true;
                    newCurve.MoveHandleTo(new Point(e.X, e.Y), newCurve.HandleCount);
                    drawArea.Refresh();
                    secondclick = true;
                }
                else
                {
                    if ((secondclick))
                    {
                        //newCurve.EndPoint = p;
                        newCurve.MoveHandleTo(p, newCurve.HandleCount);
                        drawArea.Refresh();
                        secondclick = false;
                    }
                    else
                    {
                        newCurve.AddPoint(p);
                        //newCurve.EndPoint = p;
                        newCurve.MoveHandleTo(new Point(e.X, e.Y), newCurve.HandleCount);
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

            if (newCurve == null)
                return; // precaution

            Point point = drawArea.BackTrackMouse(new Point(e.X, e.Y));
            // move last point
            newCurve.MoveHandleTo(point, newCurve.HandleCount);
            drawArea.Refresh();
        }
    }
} 
#endif