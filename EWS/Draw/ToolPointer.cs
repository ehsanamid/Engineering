using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System;
using DCS.Tools;
using DocToolkit;
using DCS.Draw.FBD;
using DCS.Forms;
using DCS.TabPages;
using DCS;

namespace DCS.Draw
{
	/// <summary>
	/// Pointer tool
	/// </summary>
	internal class ToolPointer : Tool
	{
		private enum SelectionMode
		{
			None,
			NetSelection, // group selection is active
			Move, // object(s) are moves
			Size // object is resized
		}

		private SelectionMode selectMode = SelectionMode.None;

		// Object which is currently resized:
		private DrawObject resizedObject;
		private int resizedObjectHandle;

		// Keep state about last and current point (used to move and resize objects)
		private Point lastPoint = new Point(0, 0);
		private Point startPoint = new Point(0, 0);
        private Point FirstPoint = new Point(0, 0);
        
		private CommandChangeState commandChangeState;
		private bool wasMove;
		private ToolTip toolTip = new ToolTip();

		/// <summary>
		/// Left mouse button is pressed
		/// </summary>
		/// <param name="drawArea"></param>
		/// <param name="e"></param>
		public override void OnMouseDown(DrawArea drawArea, MouseEventArgs e)
		{
            Point pointscroll = GetEventPointInArea(drawArea, e);
			commandChangeState = null;
			wasMove = false;

			selectMode = SelectionMode.None;
            Trace.WriteLine("ToolPointer OnMouseDown " );
            if (e.Button == MouseButtons.Left)
            {

                Point point;
            //    if (drawArea.SnapEnable)
                {
              //      point = drawArea.BackTrackMouse(new Point(drawArea.FittoSnap(e.X, drawArea.SnapX), drawArea.FittoSnap(e.Y, drawArea.SnapY)));
                }
                //else
                {
                    point = drawArea.BackTrackMouse(pointscroll);
                }
                startPoint = point;
                lastPoint = point;
                FirstPoint = point;
                
                DrawObject o = null;
                int hittestresult = -1;
                for (int i = 0; i < drawArea.Pages.GraphicPagesList[drawArea.ActivePageNo].List.Count; i++)
                //foreach (DrawObject o in drawArea.Pages.GraphicPagesList[drawArea.ActivePageNo].List)
                {
                    o = drawArea.Pages.GraphicPagesList[drawArea.ActivePageNo].List[i];
                    if (drawArea.Pages.LayerIsNotLock((LAYERS)o.Layer))
                    {
                        hittestresult = o.HitTest(point);
                        if (hittestresult != -1)
                        {
#if EWSAPP
                            Trace.WriteLine("ToolPointer OnMouseDown Click over an object");
                            if (o.Selected)      // object was selected
                            {
                                Trace.WriteLine("ToolPointer OnMouseDown object was selected");
                                if (hittestresult > 0)  // over control points
                                {
                                    Console.WriteLine("ToolPointer OnMouseDown over control points e.x {0}  e.y {1}  First.x {2} First.y {3}", o.rectangle.X, o.rectangle.Y, FirstPoint.X, FirstPoint.Y);
                                    selectMode = SelectionMode.Size;
                                    resizedObject = o;
                                    resizedObjectHandle = hittestresult;
                                    // Since we want to resize only one object, unselect all other objects
                                    drawArea.UnselectAll();
                                    o.Selected = true;
                                    commandChangeState = new CommandChangeState(drawArea.Pages.GraphicPagesList[drawArea.ActivePageNo]);
                                    drawArea.Pages.Dirty = true;
                                }
                                else                  // clicked inside object 
                                {
                                    Trace.WriteLine("ToolPointer OnMouseDown clicked inside object ");
                                    //drawArea.Graphics.UnselectAll();
                                    selectMode = SelectionMode.Move;
                                    drawArea.Cursor = Cursors.SizeAll;
                                    startPoint = point;
                                }
                            }
                            else  // object was not selected
                            {
                                Trace.WriteLine("ToolPointer OnMouseDown object was not selected ");
                                if ((Control.ModifierKeys & Keys.Control) == 0)
                                {
                                    drawArea.UnselectAll();
                                }
                                o.Selected = true;
                                DCS.Forms.MainForm.Instance().m_propertyGrid.SelectedObject = o;
                                DCS.Forms.MainForm.Instance().m_propertyGrid.Refresh();
                                commandChangeState = new CommandChangeState(drawArea.Pages.GraphicPagesList[drawArea.ActivePageNo]);
                                selectMode = SelectionMode.Move;
                                drawArea.Cursor = Cursors.SizeAll;
                                drawArea.Refresh();
                            }
                            break;
#endif
                        }
                    }

                }

                if (hittestresult == -1)   // not clicked over any objet
                {
                    Trace.WriteLine("ToolPointer OnMouseDown not clicked over an objet ");
                    selectMode = SelectionMode.NetSelection;
                    if ((Control.ModifierKeys & Keys.Control) == 0)
                    {
                        drawArea.UnselectAll();
                    }
                }
            }
            else
            {

            }
            
		}
	/// <summary>
		/// Mouse is moved.
		/// None button is pressed, ot left button is pressed.
		/// </summary>
		/// <param name="drawArea"></param>
		/// <param name="e"></param>
		public override void OnMouseMove(DrawArea drawArea, MouseEventArgs e)
		{
#if EWSAPP
            //Trace.WriteLine("OnMouseMove ");
            int hittestresult = -1;

            Point point;
            //Point OnSnappoint;
            //Point pt = new Point();
            point = drawArea.BackTrackMouse(new Point(e.X, e.Y));

            Point pointscroll = GetEventPointInArea(drawArea, e);
            Point oldPoint = lastPoint;
            wasMove = true;
            //toolTip.InitialDelay = 1;

            int dx = e.X - lastPoint.X;
            int dy = e.Y - lastPoint.Y;

            lastPoint.X = e.X;
            lastPoint.Y = e.Y;
            switch (e.Button)
            {
                case MouseButtons.Left:
                    switch (selectMode)
                    {
                        case SelectionMode.NetSelection:
                            Trace.WriteLine("ToolPointer OnMouseMove MouseButtons.Left SelectionMode.NetSelection");
                            // Remove old selection rectangle
                            ControlPaint.DrawReversibleFrame(
                                drawArea.RectangleToScreen(DrawRectangle.GetNormalizedRectangle(startPoint, oldPoint)),
                                Color.Black,
                                FrameStyle.Dashed);

                            // Draw new selection rectangle
                            ControlPaint.DrawReversibleFrame(
                                drawArea.RectangleToScreen(DrawRectangle.GetNormalizedRectangle(startPoint, new Point(e.X, e.Y))),
                                Color.Black,
                                FrameStyle.Dashed);
                            drawArea.NetRectangle = DrawRectangle.GetNormalizedRectangle(startPoint, lastPoint);

                            break;
                        case SelectionMode.Move:
                            Trace.WriteLine("ToolPointer OnMouseMove MouseButtons.Left SelectionMode.Move");

                            foreach (DrawObject o in drawArea.Pages.GraphicPagesList[drawArea.ActivePageNo].Selection)
                            {
                                o.Move(dx, dy);
                                if ((o is DrawFBDBox))
                                {
                                    ((DrawFBDBox)o).UpdateWireConnections();
                                }
                            }

                            drawArea.Cursor = Cursors.SizeAll;
                            drawArea.Pages.Dirty = true;
                            drawArea.Refresh();
                            drawArea.Pages.Dirty = true;
                            break;
                        case SelectionMode.Size:
                            Trace.WriteLine("ToolPointer OnMouseMove MouseButtons.Left SelectionMode.Size");
                            if (resizedObject != null)
                            {


                                resizedObject.MoveHandleTo(pointscroll, resizedObjectHandle);

                                drawArea.Refresh();
                                drawArea.Pages.Dirty = true;
                            }
                            break;
                        default:
                            break;
                    }
                    break;
                case MouseButtons.None:
                    Cursor tempcursor = null;
                    foreach (DrawObject o in drawArea.Pages.GraphicPagesList[drawArea.ActivePageNo].Selection)
                    {

                        hittestresult = o.HitTest(point);
                        if (hittestresult > 0)
                        {
                            Trace.WriteLine("ToolPointer OnMouseDown over control points");
                            tempcursor = o.GetHandleCursor(hittestresult);
                            break;
                        }

                    }
                    if (tempcursor == null)
                        tempcursor = Cursors.Default;

                    //drawArea.Cursor = tempcursor;
                    break;
                default:
                    break;
            } 
#endif
		}

        /// <summary>
		/// Right mouse button is released
		/// </summary>
		/// <param name="drawArea"></param>
		/// <param name="e"></param>
		public override void OnMouseUp(DrawArea drawArea, MouseEventArgs e)
		{
#if EWSAPP
            int newx;
            int newy;


            switch (selectMode)
            {
                case SelectionMode.NetSelection:
                    Trace.WriteLine("ToolPointer OnMouseUp MouseButtons.Left SelectionMode.NetSelection");
                    drawArea.Pages.SelectInRectangle(drawArea.NetRectangle);

                    selectMode = SelectionMode.None;

                    drawArea.DrawNetRectangle = false;
                    if (resizedObject != null)
                    {
                        // after resizing
                        resizedObject.Normalize();
                        resizedObject = null;
                    }

                    drawArea.Capture = false;
                    drawArea.Refresh();

                    if (commandChangeState != null && wasMove)
                    {
                        // Keep state after moving/resizing and add command to history
                        commandChangeState.NewState(drawArea.Pages.GraphicPagesList[drawArea.ActivePageNo]);
                        drawArea.Pages.AddCommandToHistory(commandChangeState);
                        commandChangeState = null;
                    }
                    lastPoint = drawArea.BackTrackMouse(e.Location);
                    break;
                case SelectionMode.Size:
                    Trace.WriteLine("ToolPointer OnMouseUp MouseButtons.Left SelectionMode.Size");
                    break;
                case SelectionMode.Move:
                    newx = e.X - FirstPoint.X;
                    newy = e.Y - FirstPoint.Y;
                    //newx = drawArea.FittoSnap(e.X, drawArea.SnapX);
                    //newy = drawArea.FittoSnap(e.Y, drawArea.SnapY);
                    if ((newx != 0) || (newy != 0))
                    {
                        if (drawArea.SnapEnable)
                        {
                            foreach (DrawObject o in drawArea.Pages.GraphicPagesList[drawArea.ActivePageNo].Selection)
                            {
                                //o.MoveTo(drawArea.FittoSnap(o._rectangle.X + newx, drawArea.SnapX), drawArea.FittoSnap(o._rectangle.Y + newy, drawArea.SnapY));
                                int _x = o.rectangle.X;
                                _x = o.rectangle.X + newx;
                                _x = drawArea.FittoSnap(o.rectangle.X, drawArea.SnapX);
                                int _y = o.rectangle.Y;
                                _y = o.rectangle.Y + newy;
                                _y = drawArea.FittoSnap(o.rectangle.Y, drawArea.SnapY);

                                o.MoveTo(_x, _y);
                                if ((o is DrawFBDBox))
                                {
                                    ((DrawFBDBox)o).UpdateWireConnections();
                                }
                            }
                        }

                        drawArea.Cursor = Cursors.SizeAll;
                        drawArea.Refresh();
                        drawArea.Pages.Dirty = true;
                    }
                    break;
                default:

                    break;
            }

            selectMode = SelectionMode.None;
            drawArea.Cursor = Cursors.Default; 
#endif
			
		}
        public override void MouseDoubleClick(DrawArea drawArea, MouseEventArgs e)
        {
            Point pointscroll = GetEventPointInArea(drawArea, e);
            commandChangeState = null;
            wasMove = false;

            selectMode = SelectionMode.None;
            Trace.WriteLine("ToolPointer OnMouseDown ");
            if (e.Button == MouseButtons.Left)
            {

                Point point;
                //    if (drawArea.SnapEnable)
                {
                    //      point = drawArea.BackTrackMouse(new Point(drawArea.FittoSnap(e.X, drawArea.SnapX), drawArea.FittoSnap(e.Y, drawArea.SnapY)));
                }
                //else
                {
                    point = drawArea.BackTrackMouse(pointscroll);
                }
                startPoint = point;
                lastPoint = point;
                FirstPoint = point;

                //DrawObject o = null;
                int hittestresult = -1;
                //for (int i = 0; i < drawArea.graphicsList.List.Count; i++)
                foreach (DrawObject drawobject in drawArea.Pages.GraphicPagesList[drawArea.ActivePageNo].List)
                {
                    //o = drawArea.graphicsList.List[i];
                    if (drawArea.Pages.LayerIsNotLock((LAYERS)drawobject.Layer))
                    {
                        hittestresult = drawobject.HitTest(point);
                        if (hittestresult != -1)
                        {
                            if (drawobject is DrawFunctionBlock)
                            {

                            }
                            else
                            {
                                if (drawobject is DrawFunction)
                                {

                                }
                                else
                                {
                                    if (drawobject is DrawFunctionEx)
                                    {

                                    }
                                    else
                                    {
                                        if (drawobject is DrawVariable)
                                        {

#if EWSAPP
                                            VariableForm varlistfrm = new VariableForm(/*drawArea.mainEWSForm,*/ ((TabFBDPageControl)drawArea.ParentTabGraphicPageControl).ID);
                                            if (DialogResult.OK == varlistfrm.ShowDialog())
                                            {
                                                ((DrawVariable)drawobject).tblvariable = varlistfrm.tblvariable;
                                                ((DrawVariable)drawobject).tblformalparameter = varlistfrm.tblformalparameter;
                                                ((DrawVariable)drawobject).ExtendedPropertyTXT = varlistfrm.SubPropertyTxt;
                                                drawArea.Capture = false;
                                            }
#endif

                                        }
                                    }
                                }
                            }

                            break;
                        }
                    }
                }

                
            }
            
            
        }
    }
}