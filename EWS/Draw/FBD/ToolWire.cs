using System.Drawing;
using System.Windows.Forms;
//using DocToolkit.Project_Objects;
using System.Diagnostics;
using System;
using DCS.DCSTables;
using DCS.Tools;
using DCS.TabPages;

#if EWSAPP
namespace DCS.Draw.FBD
{
    /// <summary>
    /// Connector tool (a Connector is a series of connected straight lines where each line is drawn individually and at least one of the ends is anchored to another object)
    /// </summary>
    internal class ToolWire : ToolObject
    {
        public ToolWire()
        {
            try
            {

                m_Cursor = new Cursor(Application.StartupPath + "\\Wire.cur");
                //m_Cursor = new Cursor(GetType(), "Rectangle.cur");
            }
            catch (NullReferenceException e)
            {
                MessageBox.Show(e.Message.ToString());
            }
        }
        //string Outputnamestr = "";
        //private DrawWire newConnector;
        private bool _drawingInProcess = false; // Set to true when drawing
        private ToolTip toolTip = new ToolTip();

        
        


        /// <summary>
        /// Left mouse button is pressed
        /// </summary>
        /// <param name="drawArea"></param>
        /// <param name="e"></param>
        public override void OnMouseDown(DrawArea drawArea, MouseEventArgs e)
        {
            //Outputnamestr = "";
            short PinClass = (short)VarClass.Input;
            int PinType = (int)VarType.UNKNOWN;
            bool result;
            Guid  _guid = Guid.Empty;
            int _pinno = -1;
            bool _leftside = false;
            if (e.Button == MouseButtons.Right)
            {
                _drawingInProcess = false;
                //newConnector = null;
            }
            else
            {
                Point p;
                p = drawArea.BackTrackMouse(new Point(e.X, e.Y));
                result = drawArea.Pages.IsMouseOverPin(p, ref _guid, ref _leftside, ref _pinno, ref PinType );
                if (result && !_leftside/*&& !pinisused */ )
                {

                    drawArea.tempobject = new DrawWire(drawArea.ParentTabGraphicPageControl.Pages(),/*p.X, p.Y, p.X, p.Y, Color.Black, 1, objectID, PinNo,*/ PinType, PinClass);
                    drawArea.tempobject.StartPinType = PinType;
                    drawArea.tempobject.pointArray0 = drawArea.Pages.GetFBDBoxObject(_guid).GetRightPinPosition(_pinno);
                    drawArea.tempobject.pointArray5 = drawArea.tempobject.pointArray0;
                    drawArea.tempobject.LeftPinNo = _pinno;
                    drawArea.tempobject.LeftGuid = _guid;
                    drawArea.tempobject.TipText = String.Format("PinType = {0}",  (VarType) PinType);
                    toolTip.Show(drawArea.tempobject.TipText, drawArea, p, 2000);
                    _drawingInProcess = true;
                }
                else
                {

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

            //if (e.Button != MouseButtons.Left)
            //    return;

            //if (newConnector == null)
            //    return; // precaution
            Guid _guid = Guid.Empty;
            int _pinno = -1;
            bool _leftside = false;
            Point p;
            int PinType = (int)VarType.UNKNOWN;
            bool pinisused = true;
            bool result;
            string TipText;
           p = drawArea.BackTrackMouse(new Point(e.X, e.Y));
           result = drawArea.Pages.IsMouseOverPin(p, ref _guid, ref _leftside, ref _pinno, ref PinType);
            if (result)
            {
                TipText = String.Format("PinType = {0}", (VarType)PinType);
                 toolTip.Show(TipText, drawArea, p, 2000);
            }
            if (result && !pinisused)
            {
                try
                {
                    drawArea.Cursor = new Cursor(Application.StartupPath + "\\WireL.cur");
                }
                catch (NullReferenceException ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            else
            {
                drawArea.Cursor = m_Cursor;
            }
            if (_drawingInProcess == true)
            {
                if (result && !pinisused && CompatibeTypes(((DrawWire)drawArea.tempobject).StartPinType , PinType))
                {
                    try
                    {
                        drawArea.Cursor = new Cursor(Application.StartupPath + "\\WireL.cur");
                    }
                    catch (NullReferenceException ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
                else
                {
                    drawArea.Cursor = m_Cursor;
                }
                drawArea.tempobject.MoveHandleTo(p, 6);
                drawArea.Refresh();
            }
        }
        /// <summary>
        /// Left mouse is released.
        /// New object is created and resized.
        /// </summary>
        /// <param name="drawArea"></param>
        /// <param name="e"></param>
        public override void OnMouseUp(DrawArea drawArea, MouseEventArgs e)
        {
            Guid _guid = Guid.Empty;
            int _pinno = -1;
            bool _leftside = false;
            bool result;
            Point p;
            //short PinClass = (short)VarClass.Input;
            int PinType = (int)VarType.UNKNOWN;
            bool pinisused = true;

            p = drawArea.BackTrackMouse(new Point(e.X, e.Y));
            result = drawArea.Pages.IsMouseOverPin(p, ref _guid, ref _leftside, ref _pinno,ref PinType);    
            if (result && !pinisused )
            {
                try
                {
                    drawArea.Cursor = new Cursor(Application.StartupPath + "\\WireL.cur");
                }
                catch (NullReferenceException ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            else
            {
                drawArea.Cursor = m_Cursor;
            }
            //if ((_drawingInProcess == true) && result && !_leftside && !pinisused)
            if ((_drawingInProcess == true) && result && _leftside )
            {
                if (CompatibeTypes(((DrawWire)drawArea.tempobject).StartPinType, PinType))
                {
                    //if (InputOutputMaches(((DrawWire)drawArea.tempobject).StartPinClass, PinClass))
                    {
                        ((DrawWire)drawArea.tempobject).ConnectionIsOk = true;
                        drawArea.tempobject.RightPinNo = _pinno;
                        drawArea.tempobject.RightGuid = _guid;
                        drawArea.tempobject.pointArray5 = drawArea.Pages.GetFBDBoxObject(_guid).GetLeftPinPosition(_pinno); //drawArea.GetLogicObject(ID).GetInputPinPosition(PinID);
                        //drawArea.tempobject.tblfbdpinconnection.NotTemporary = false;
                        drawArea.tempobject.tblfbdpinconnection.pouID = ((TabFBDPageControl)drawArea.ParentTabGraphicPageControl).ID;
                        //drawArea.tempobject.tblfbdpinconnection.Insert();
                        drawArea.tempobject.Addlinks();
                        AddNewObject(drawArea, ((DrawWire)drawArea.tempobject));
                        //drawArea.tempobject.AreaPath.Dispose();
                        //drawArea.tempobject.AreaPen.Dispose();
                        //drawArea.tempobject.AreaRegion.Dispose();
                        drawArea.tempobject = null;
                    }
                }
            }
            _drawingInProcess = false;
            drawArea.tempobject = null;
            drawArea.Capture = false;
            drawArea.Refresh();
        }
        private bool CompatibeTypes(int PinType1, int PinType2)
        {
            int temp = PinType1 & PinType2;
            if (temp != 0)
                return true;
            return false;
        }
        private bool InputOutputMaches(short PinClass1, short PinClass2)
        {
            if (((PinClass1 == (short)VarClass.Output) && ((PinClass2 == (short)VarClass.Input) || (PinClass2 == (short)VarClass.InOut) || (PinClass2 == (short)VarClass.Internal))) || (((PinClass2 == (short)VarClass.Input) || (PinClass2 == (short)VarClass.InOut) || (PinClass2 == (short)VarClass.Internal)) && (PinClass2 == (short)VarClass.Output)))
            {
                return true;
            }
            return false;
        }
        //public void Addlinks(DrawArea drawArea,DrawWire tempobject)
        //{
            
        //    foreach (DrawLogic drawlogic in drawArea.graphicsList.List)
        //    {
        //        if (drawlogic.InstanseName == tempobject.OutputObjectName)
        //        {
        //            ((DrawFBDBox)drawlogic).fbdboxobject.PinCollectionOutput[tempobject.OutputPinNo].WireConnection.Add(tempobject.InstanseName);
        //            break;
        //        }
        //    }

        //    foreach (DrawLogic drawlogic in drawArea.graphicsList.List)
        //    {
        //        if (drawlogic.InstanseName == tempobject.InputObjectName)
        //        {
        //            ((DrawFBDBox)drawlogic).fbdboxobject.PinCollectionInput[tempobject.InputPinNo].WireConnection.Add(tempobject.InstanseName);
        //            break;
        //        }
        //    }
        //}

        

        

    }
}

#endif