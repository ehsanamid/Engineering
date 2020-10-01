using DocToolkit;
using DCS.Forms;
using DCS.DCSTables;
using DCS.Draw;
using DCS.Draw.FBD;
using DCS.Tools;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Reflection;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace DCS.TabPages
{
    /// <summary>
    /// List of graphic objects
    /// </summary>
    [Serializable]
    public class PageList
    {
        //private ArrayList graphicsList;
        private UndoManager undoManager;
        List<GraphicsList> _graphicpageslist;
        public List<GraphicsList> GraphicPagesList
        {
            get
            {
                return _graphicpageslist;
            }
            set
            {
                _graphicpageslist = value;
            }
        }
        

        //private bool _isDirty;

        public bool Dirty
        {
            get
            {
                if (Parenttabgraphicpagecontrol.Dirty)
                {
                    return true;
                }
                else
                {
                    
                    foreach (GraphicsList o in _graphicpageslist)
                    {
                        foreach (DrawObject ob in o.List)
                        {
                            if (ob.Dirty)
                            {
                                Parenttabgraphicpagecontrol.Dirty = true;
                                return true;
                            }
                        }
                    }
                }
                return false;
            }
            set
            {
                //foreach (DrawObject o in graphicsList)
                //    o.Dirty = false;
                //_isDirty = false;
                //_isDirty = value;
                Parenttabgraphicpagecontrol.Dirty = value;
            }
        }

        

        /// <summary>
        /// Returns IEnumerable object which may be used for enumeration
        /// of selected objects.
        /// 
        /// Note: returning IEnumerable<DrawObject> breaks CLS-compliance
        /// (assembly CLSCompliant = true is removed from AssemblyInfo.cs).
        /// To make this program CLS-compliant, replace 
        /// IEnumerable<DrawObject> with IEnumerable. This requires
        /// casting to object at runtime.
        /// </summary>
        /// <value></value>
        //public IEnumerable<DrawObject> Selection
        //{
        //    get
        //    {
        //        foreach (DrawObject o in graphicsList)
        //        {
        //            if (o.Selected)
        //            {
        //                yield return o;
        //            }
        //        }
        //    }
        //}

        //int objectcounter = 0;
        //public int ObjectCounter
        //{
        //    get
        //    {
        //        return objectcounter;
        //    }
        //    set
        //    {
        //        objectcounter = value;
        //    }
        //}

        //private const string entryCount = "ObjectCount";
        //private const string entryType = "ObjectType";

        TabGraphicPageControl _parenttabgraphicpagecontrol;
        public TabGraphicPageControl Parenttabgraphicpagecontrol
        {
            get
            {
                return _parenttabgraphicpagecontrol;
            }
        }
        public PageList(TabGraphicPageControl _parent)
        {
            _parenttabgraphicpagecontrol = _parent;
            //graphicsList = new ArrayList();
            _graphicpageslist = new List<GraphicsList>();
            _graphicpageslist.Add(new GraphicsList());
            //graphicsList = new List<DrawObject>();
            ActivePageNo = 0;
            undoManager = new UndoManager(_graphicpageslist[ActivePageNo]);
        }


        #region Undo
        public void AddCommandToHistory(Command command)
        {
            undoManager.AddCommandToHistory(command);
        }

        /// <summary>
        /// Clear Undo history.
        /// </summary>
        public void ClearHistory()
        {
            undoManager.ClearHistory();
        }

        /// <summary>
        /// Undo
        /// </summary>
        public void Undo()
        {
            undoManager.Undo();
            Parenttabgraphicpagecontrol.drawarea.Refresh();
        }

        /// <summary>
        /// Redo
        /// </summary>
        public void Redo()
        {
            undoManager.Redo();
            Parenttabgraphicpagecontrol.drawarea.Refresh();
        }

        /// <summary>
        /// Return True if Undo operation is possible
        /// </summary>
        public bool CanUndo
        {
            get
            {
                if (undoManager != null)
                {
                    return undoManager.CanUndo;
                }

                return false;
            }
        }

        /// <summary>
        /// Return True if Redo operation is possible
        /// </summary>
        public bool CanRedo
        {
            get
            {
                if (undoManager != null)
                {
                    return undoManager.CanRedo;
                }

                return false;
            }
        }

        #endregion

        

        public bool AddNewPage()
        {
            try
            {
                GraphicPagesList.Add(new GraphicsList());
                ActivePageNo = GraphicPagesList.Count - 1;
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }

        /// <summary>
        /// Load the GraphicsList from data pulled from disk
        /// </summary>
        /// <param name="info">Data from disk</param>
        /// <param name="orderNumber">Layer number to be loaded</param>
        //public void LoadFromStream(SerializationInfo info, int orderNumber)
        //{
        //    graphicsList = new ArrayList();

        //    // Get number of DrawObjects in this GraphicsList
        //    int numberObjects = info.GetInt32(
        //        String.Format(CultureInfo.InvariantCulture,
        //                      "{0}{1}",
        //                      entryCount, orderNumber));

        //    for (int i = 0; i < numberObjects; i++)
        //    {
        //        string typeName;
        //        typeName = info.GetString(
        //            String.Format(CultureInfo.InvariantCulture,
        //                          "{0}{1}",
        //                          entryType, i));

        //        object drawObject;
        //        drawObject = Assembly.GetExecutingAssembly().CreateInstance(
        //            typeName);

        //        // Let the Draw Object load itself
        //        ((DrawObject)drawObject).LoadFromStream(info, orderNumber, i);

        //        graphicsList.Add(drawObject);
        //    }
        //}

        /// <summary>
        /// Save GraphicsList to the stream
        /// </summary>
        /// <param name="info">Stream to place the GraphicsList into</param>
        /// <param name="orderNumber">Layer Number the List is on</param>
        //public void SaveToStream(SerializationInfo info, int orderNumber)
        //{
        //    // First store the number of DrawObjects in the list
        //    info.AddValue(
        //        String.Format(CultureInfo.InvariantCulture,
        //                      "{0}{1}",
        //                      entryCount, orderNumber),
        //        graphicsList.Count);
        //    // Next save each individual object
        //    int i = 0;
        //    foreach (DrawObject o in graphicsList)
        //    {
        //        info.AddValue(
        //            String.Format(CultureInfo.InvariantCulture,
        //                          "{0}{1}",
        //                          entryType, i),
        //            o.GetType().FullName);
        //        // Let each object save itself
        //        o.SaveToStream(info, orderNumber, i);
        //        i++;
        //    }
        //}
        /// <summary>
        /// Draw all the visible objects in the List
        /// </summary>
        /// <param name="g">Graphics to draw on</param>
        public void DrawControl(Graphics g)
        {
            
           
               // GraphicPagesList[ActivePageNo].DrawControl(g);


            int numberObjects = GraphicPagesList[ActivePageNo].List.Count;

            for (int i = 0; i < numberObjects; i++)
            {
                DrawObject o;
                o = (DrawObject)GraphicPagesList[ActivePageNo].List[i];
                if (LayerIsEnable((LAYERS)o.Layer))
                {
                    if (o.IntersectsWith(Rectangle.Round(g.ClipBounds)))
                        o.Draw(g);

                    if (o.Selected)
                        o.DrawTracker(g);
                }
            }
            
        }
        public bool LayerIsEnable(LAYERS layer)
        {
            if (_parenttabgraphicpagecontrol.TabPageType == TABPAGETYPE.DISPLAY)
            {
                switch (layer)
                {
                    case LAYERS.Layer1:
                        return ((TabDisplayPageControl)_parenttabgraphicpagecontrol).tbldisplay.Layer1Enable;
                    case LAYERS.Layer2:
                        return ((TabDisplayPageControl)_parenttabgraphicpagecontrol).tbldisplay.Layer2Enable;
                    case LAYERS.Layer3:
                        return ((TabDisplayPageControl)_parenttabgraphicpagecontrol).tbldisplay.Layer3Enable;
                    case LAYERS.Layer4:
                        return ((TabDisplayPageControl)_parenttabgraphicpagecontrol).tbldisplay.Layer4Enable;
                    case LAYERS.Layer5:
                        return ((TabDisplayPageControl)_parenttabgraphicpagecontrol).tbldisplay.Layer5Enable;
                    case LAYERS.Layer6:
                        return ((TabDisplayPageControl)_parenttabgraphicpagecontrol).tbldisplay.Layer6Enable;
                    case LAYERS.Layer7:
                        return ((TabDisplayPageControl)_parenttabgraphicpagecontrol).tbldisplay.Layer7Enable;
                    case LAYERS.Layer8:
                        return ((TabDisplayPageControl)_parenttabgraphicpagecontrol).tbldisplay.Layer8Enable;
                }
            }
            return true;
        }

        public bool LayerIsNotLock(LAYERS layer)
        {
            if (_parenttabgraphicpagecontrol.TabPageType == TABPAGETYPE.DISPLAY)
            {
                switch (layer)
                {
                    case LAYERS.Layer1:
                        return !((TabDisplayPageControl)_parenttabgraphicpagecontrol).tbldisplay.Layer1Lock;
                    case LAYERS.Layer2:
                        return !((TabDisplayPageControl)_parenttabgraphicpagecontrol).tbldisplay.Layer2Lock;
                    case LAYERS.Layer3:
                        return !((TabDisplayPageControl)_parenttabgraphicpagecontrol).tbldisplay.Layer3Lock;
                    case LAYERS.Layer4:
                        return !((TabDisplayPageControl)_parenttabgraphicpagecontrol).tbldisplay.Layer4Lock;
                    case LAYERS.Layer5:
                        return !((TabDisplayPageControl)_parenttabgraphicpagecontrol).tbldisplay.Layer5Lock;
                    case LAYERS.Layer6:
                        return ((TabDisplayPageControl)_parenttabgraphicpagecontrol).tbldisplay.Layer6Lock;
                    case LAYERS.Layer7:
                        return !((TabDisplayPageControl)_parenttabgraphicpagecontrol).tbldisplay.Layer7Lock;
                    case LAYERS.Layer8:
                        return !((TabDisplayPageControl)_parenttabgraphicpagecontrol).tbldisplay.Layer8Lock;
                }
            }
            return true;
        }
        /// <summary>
        /// Clear all objects in the list
        /// </summary>
        /// <returns>
        /// true if at least one object is deleted
        /// </returns>
        public bool Clear()
        {
            bool result = false;
            foreach (GraphicsList graphiclist in _graphicpageslist)
            {
                result = graphiclist.Clear();
            }
            
            // Set dirty flag based on result. Result is true only if at least one item was cleared and since the list is empty, there can be nothing dirty.
            if (result)
                Dirty = false;
            return result;
        }

        
        /// </summary>
        public int NoOfPages
        {
            get { return _graphicpageslist.Count; }
        }
        /// <summary>
        public GraphicsList ActivePageGraphicList
        {
            get
            {
                return GraphicPagesList[ActivePageNo];
            }
        }

        int _activepageno = 0;
        public int ActivePageNo
        {
            get
            {
                return _activepageno;
            }
            set
            {
                _activepageno = value;
            }
        }

        
        public int NoOfObjectsinPage()
        {
            return GraphicPagesList[_activepageno].List.Count;
        }

        public int NoOfObjectsinPage(int _pn)
        {
            return GraphicPagesList[_pn].List.Count;
        }

        public DrawObject GetObject(int _pageno, int _index)
        {
            return GraphicPagesList[_pageno].List[_index];
        }

        public DrawWire FindWire(int _pgno, Guid _guid)
        {
            try
            {
                foreach (DrawLogic drawlogic in GraphicPagesList[_pgno].List)
                {
                    if (drawlogic is DrawWire)
                    {
                        if (drawlogic.GUID == _guid)
                        {
                            return (DrawWire)drawlogic;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }
        public void RemovePinNumber(Guid _guid, int _pinno)
        {
            //bool result = false;
            int n;
            GraphicsList graphicsList;
            for (int i = 0; i < GraphicPagesList.Count; i++)
            {
                graphicsList = GraphicPagesList[i];
                n = graphicsList.Count;
                foreach (DrawObject drawobject in graphicsList.List)
                {
                    if (drawobject is DrawWire)
                    {
                        DrawWire dw = (DrawWire)drawobject;
                        if (dw.RightGuid == _guid)
                        {
                            if (dw.RightPinNo >= _pinno)
                            {
                                dw.RightPinNo--;
                                dw.Dirty = true;
                            }
                        }
                    }
                }
            }
        }
        
        public void PropertyClick()
        {
#if EWSAPP
            int n = GraphicPagesList[ActivePageNo].Count;

            for (int i = 0; i < n; i++)
            {
                if (GraphicPagesList[ActivePageNo].List[i].Selected)
                {
                    if (GraphicPagesList[ActivePageNo].List[i] is DrawFunctionBlock)
                    {
                        DrawFunctionBlock drawfunctionblock = (DrawFunctionBlock)GraphicPagesList[ActivePageNo].List[i];
                        FBDProperty dlg = new FBDProperty();
                        dlg.drawfunctionblock = drawfunctionblock;

                        // dlg.Show();
                        if (DialogResult.OK == dlg.ShowDialog())
                        {
                            drawfunctionblock.RefreshVisible();
                            drawfunctionblock.Move(0, 0);
                            drawfunctionblock.UpdateWireConnections();
                            Parenttabgraphicpagecontrol.drawarea.Refresh();
                        }
                    }
                    else
                    {

                        MessageBox.Show("dd");
                    }
                }
            } 
#endif
        }

        public DrawObject FindID(long ID)
        {
            // Change current selection if necessary

            int n = GraphicPagesList[ActivePageNo].Count;
            //DrawObject o = null;

            for (int i = 0; i < n; i++)
            {
                if (GraphicPagesList[ActivePageNo].List[i].ID == ID)
                {
                    return GraphicPagesList[ActivePageNo].List[i];
                }
            }

            return null;
        }

        public DrawObject FindSqlTableID(long id)
        {
            // Change current selection if necessary


            int n = GraphicPagesList[ActivePageNo].Count;
            //DrawObject o = null;

            for (int i = 0; i < n; i++)
            {
                if (GraphicPagesList[ActivePageNo].List[i].ID == id)
                {
                    return GraphicPagesList[ActivePageNo].List[i];
                }
            }

            return null;
        }


        public Guid ReturnFBDBoxGUID(long _sqlid, int _pgno)
        {
            try
            {
                foreach (DrawLogic drawlogic in GraphicPagesList[_pgno].List)
                {
                    if (drawlogic is DrawFBDBox)
                    {
                        if (drawlogic.SQLID == _sqlid)
                        {
                            return drawlogic.GUID;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return Guid.Empty;
        }
        public long ReturnFBDBoxSQLID(Guid _guid, int _pgno)
        {
            try
            {
                foreach (DrawLogic drawlogic in GraphicPagesList[_pgno].List)
                {
                    if (drawlogic is DrawFBDBox)
                    {
                        if (drawlogic.GUID == _guid)
                        {
                            return drawlogic.SQLID;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return -1;
        }


        public DrawFBDBox FindFBDbox(Guid _guid, int _pgno)
        {
            try
            {
                foreach (DrawLogic drawlogic in GraphicPagesList[_pgno].List)
                {
                    if (drawlogic is DrawFBDBox)
                    {
                        if (drawlogic.GUID == _guid)
                        {
                            return (DrawFBDBox)drawlogic;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }

        public DrawLogic GetLogicObject(Guid _guid)
        {
            try
            {
                for (int _pgno = 0; _pgno < NoOfPages ; _pgno++)
                {
                    foreach (DrawLogic drawlogic in GraphicPagesList[_pgno].List)
                    {
                        if (drawlogic is DrawFBDBox)
                        {
                            if (((DrawFBDBox)drawlogic).GUID == _guid)
                            {
                                return drawlogic;
                            }
                        }
                        if (drawlogic is DrawWire)
                        {
                            if (((DrawWire)drawlogic).GUID == _guid)
                            {
                                return drawlogic;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }

        public DrawFBDBox GetFBDBoxObject(Guid _guid)
        {
            try
            {
                for (int _pgno = 0; _pgno < NoOfPages ; _pgno++)
                {
                    foreach (DrawLogic drawlogic in GraphicPagesList[_pgno].List)
                    {
                        if (drawlogic is DrawFBDBox)
                        {
                            if (((DrawFBDBox)drawlogic).GUID == _guid)
                            {
                                return (DrawFBDBox)drawlogic;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }

        public DrawWire GetDrawWireObject(Guid _guid)
        {
            try
            {
                for (int _pgno = 0; _pgno < NoOfPages ; _pgno++)
                {
                    foreach (DrawLogic drawlogic in GraphicPagesList[_pgno].List)
                    {
                        if (drawlogic is DrawWire)
                        {
                            if (((DrawWire)drawlogic).GUID == _guid)
                            {
                                return (DrawWire)drawlogic;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }

        public DrawFBDBox GetDrawLogicObject(long functioninid)
        {
            try
            {
                foreach (DrawLogic drawlogic in GraphicPagesList[ActivePageNo].List)
                {
                    if (drawlogic is DrawFBDBox)
                    {
                        if (((DrawFBDBox)drawlogic).tblfbdblock.FBDBlockID == functioninid)
                        {
                            return (DrawFBDBox)drawlogic;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }

        public bool IsMouseOverPin(Point p, ref Guid _guid, ref bool LeftSide, ref int _pinno, ref int _type)
        {
            bool ret = false;
            foreach (DrawLogic obj in GraphicPagesList[ActivePageNo].List)
            {
                if (obj is DrawFBDBox)
                {
                    if (((DrawFBDBox)obj).IsMouseOverPin(p, ref  _guid, ref  LeftSide, ref  _pinno, ref _type))
                    {
                        return true;
                    }
                }
            }
            return ret;
        }


        public bool TestForPinConnection(Point p, ref long ID, ref long PinID, ref int PinNo, ref string PinName, ref  int PinType, ref  short PinClass, ref bool PinIsUsed, ref string objectinstansename)
        {
            // Determine if within 5 pixels of a connection point
            // Step 1: see if a 5 x 5 rectangle centered on the mouse cursor intersects with an object
            // Step 2: If it does, then see if there is a pin connection point within the rectangle
            // Step 3: If there is, move the point to the connection point, record the object's id in the connector
            //
            ID = -1;
            Rectangle testRectangle = new Rectangle(p.X - 4, p.Y - 4, 9, 9);
            bool connectionHere = false;
            Point h = new Point(-1, -1);
            GraphicsList gl = GraphicPagesList[ActivePageNo];
            foreach (DrawLogic obj in GraphicPagesList[ActivePageNo].List)
            {
                if (obj is DrawFBDBox)
                {
                    if (obj.IntersectsWith(testRectangle))
                    {

                        //DrawObject obj = (DrawObject)gl[i];
                        for (int j = 0; j < obj.HandleCount; j++)
                        {
                            h = obj.GetHandle(j);
                            bool testMouseOverPin = testRectangle.Contains(h);
                            //Console.WriteLine("h.x = {0} h.y = {1}", h.X, h.Y);

                            if (testMouseOverPin)
                            {
                                obj.GetPinInfo(j, ref PinID, ref PinNo, ref PinName, ref PinType, ref PinClass, ref PinIsUsed, ref objectinstansename);
                                connectionHere = true;
                                p = h;
                                ID = ((DrawFBDBox)obj).tblfbdblock.FBDBlockID;

                                //			obj.DrawConnection(drawArea., j);
                                return true;
                            }
                        }
                    }
                }
                if (connectionHere)
                    break;
            }

            PinNo = 0;
            PinClass = (short)VarClass.Input;
            return false;
        }

        void DeleteWireConnections(Guid _guid, int _pgno)
        {
            DrawWire drawwire = FindWire(_pgno, _guid);
            FindFBDbox(drawwire.LeftGuid, _pgno).DeleteWireConnectionFromPin(drawwire.LeftPinNo, false/*true*/, _guid);
            FindFBDbox(drawwire.RightGuid, _pgno).DeleteWireConnectionFromPin(drawwire.RightPinNo, true /*false*/, _guid);
            drawwire.MustBeRemoved = true;
            drawwire.Dirty = true;
        }

        void DeleteFBDBoxConnections(Guid _guid, int _pgno)
        {
            DrawFBDBox drawfbdbox = FindFBDbox(_guid, _pgno);
            foreach (FBDPin fbdpin in drawfbdbox.LeftPins)
            {
                for (int i = fbdpin.WireConnectionID.Count - 1; i >= 0; i--)
                {
                    DeleteWireConnections(fbdpin.WireConnectionID[i], _pgno);
                }
                //foreach (Guid guid in fbdpin.WireConnectionID)
                //{
                //    DeleteWireConnections( guid,_pgno);
                //}
            }
            foreach (FBDPin fbdpin in drawfbdbox.RightPins)
            {
                for (int i = fbdpin.WireConnectionID.Count - 1; i >= 0; i--)
                {
                    DeleteWireConnections(fbdpin.WireConnectionID[i], _pgno);
                }
                //foreach (Guid guid in fbdpin.WireConnectionID)
                //{
                //    DeleteWireConnections(guid,_pgno);
                //}
            }
        }



        public void DeleteWire(Guid _guid)
        {
            //bool result = false;
            int n;
            GraphicsList graphicsList;
            for (int i = 0; i < GraphicPagesList.Count; i++)
            {
                graphicsList = GraphicPagesList[i];
                n = graphicsList.Count;
                foreach (DrawObject drawobject in graphicsList.List)
                {
                    if (drawobject.GUID == _guid)
                    {
                        DeleteWireConnections(_guid, i);
                    }
                }
            }
        }



        public void AddUpPinNumber(Guid _guid, int _pinno)
        {
            //bool result = false;
            int n;
            GraphicsList graphicsList;
            for (int i = 0; i < GraphicPagesList.Count; i++)
            {
                graphicsList = GraphicPagesList[i];
                n = graphicsList.Count;
                foreach (DrawObject drawobject in graphicsList.List)
                {
                    if (drawobject is DrawWire)
                    {
                        DrawWire dw = (DrawWire)drawobject;
                        if (dw.RightGuid == _guid)
                        {
                            if (dw.RightPinNo >= _pinno)
                            {

                                dw.RightPinNo++;
                                dw.Dirty = true;
                            }
                        }
                    }
                }
            }
        }


        public bool ContextMenuDrawArea(Point point)
        {
            // Change current selection if necessary

            int n = GraphicPagesList[ActivePageNo].Count;
            DrawObject o = null;

            for (int i = 0; i < n; i++)
            {
                if (LayerIsNotLock((LAYERS)GraphicPagesList[ActivePageNo].List[i].Layer))
                {
                    if (GraphicPagesList[ActivePageNo].List[i].HitTest(point) == 0)
                    {
                        o = GraphicPagesList[ActivePageNo].List[i];
                        break;
                    }
                }
            }

            if (o != null)
            {
                if (!o.Selected)
                {
                    UnselectAll();
                }

                // Select clicked object
                o.Selected = true;
                return true;
               
            }
            else
            {
                
                UnselectAll();
                return false;
            }

            
        }

        public void ScanObjects(ref CrossReference lookup)
        {

            foreach (GraphicsList graphiclist in _graphicpageslist)
            {
                 graphiclist.ScanObjects(ref  lookup);
            }
        }

        public void SelectInRectangle(Rectangle rectangle)
        {
            UnselectAll();

            foreach (DrawObject o in GraphicPagesList[ActivePageNo].List)
            {
                if (LayerIsNotLock((LAYERS)o.Layer))
                {
                    if (o.IntersectsWith(rectangle))
                    {
                        o.Selected = true;
                    }
                }
            }
        }

        

        public void UnselectAll()
        {
            foreach (GraphicsList graphiclist in GraphicPagesList)
            {
                foreach (DrawObject o in graphiclist.List)
                {
                    o.Selected = false;
                }
            }
        }

        public void SelectAll()
        {
            foreach (DrawObject o in GraphicPagesList[ActivePageNo].List)
            {
                if (LayerIsNotLock((LAYERS)o.Layer))
                {
                    o.Selected = true;
                }
            }
        }

        public int GetNewobjectoIndex()
        {
            return GraphicPagesList[ActivePageNo].Count;
        }

        public void DeleteSelection()
        {
            //Pages.GraphicPagesList[this.PageNo].DeleteSelection();
            GraphicsList graphicsList = GraphicPagesList[ActivePageNo];
            bool result = false;

            int n = GraphicPagesList[ActivePageNo].Count;


            foreach (DrawObject drawobject in GraphicPagesList[ActivePageNo].List)
            {
                if (((DrawObject)drawobject).Selected)
                {
                    drawobject.MustBeRemoved = true;
                    drawobject.Dirty = true;
                    if (drawobject is DrawFBDBox)
                    {
                        DeleteFBDBoxConnections(drawobject.GUID, ActivePageNo);
                    }
                    if (drawobject is DrawWire)
                    {
                        DeleteWireConnections(drawobject.GUID, ActivePageNo);
                    }
                }
            }

            for (int i = graphicsList.List.Count - 1; i >= 0; i--)
            {
                if (((DrawObject)graphicsList.List[i]).MustBeRemoved)
                {
                    //if (graphicsList.List[i] is DrawFBDBox)
                    //{
                    //    tabgraphicpagecontrol.DeleteList.Add(new DeleteListStruc(graphicsList.List[i].SQLID, STATIC_OBJ_TYPE.ID_FBDBox));
                    //    tabgraphicpagecontrol.Dirty = true;
                    //}
                    //if (graphicsList.List[i] is DrawWire)
                    //{
                    //    tabgraphicpagecontrol.DeleteList.Add(new DeleteListStruc(graphicsList.List[i].SQLID, STATIC_OBJ_TYPE.ID_FBDWire));
                    //    tabgraphicpagecontrol.Dirty = true;
                    //}
                    Parenttabgraphicpagecontrol.DeleteList.Add(new DeleteListStruc(graphicsList.List[i].SQLID, graphicsList.List[i].ShapeType));
                    Parenttabgraphicpagecontrol.Dirty = true;

                    graphicsList.RemoveFromList(graphicsList.List[i].GUID);
                    result = true;
                }
            }
            //foreach (DrawObject drawobject in graphicsList.List)
            //{
            //    if (((DrawObject)drawobject).Selected)
            //    {
            //        graphicsList.RemoveFromList(drawobject.GUID);
            //        result = true;
            //    }
            //}
            if (result)
                Dirty = true;
            graphicsList.ReindexList();
            // return result;
        }

        public string FindFunctionNameInstance(string _functionname)
        {
            long count = 1;
            bool notfound = true;
            bool tagnameexists = false;
            string str1 = "";
            string str = _functionname;
            DateTime centuryBegin = new DateTime(2015, 1, 1);
            DateTime currentDate = DateTime.Now;

            long elapsedTicks = currentDate.Ticks - centuryBegin.Ticks;
            elapsedTicks = elapsedTicks / 1000;
            while (notfound)
            {
                count = currentDate.Ticks - centuryBegin.Ticks;
                count = elapsedTicks / 1000;
                //elapsedTicks = elapsedTicks / 1000;
                str1 = /*pouID.ToString() +*/ "_" + str + "_" + count.ToString();
                tagnameexists = false;
                foreach (DrawLogic obj in GraphicPagesList[ActivePageNo].List)
                {
                    if ((obj is DrawFunction) || (obj is DrawFunctionEx) || (obj is DrawFunctionBlock) || (obj is DrawVariable))
                    {
                        if (((DrawFBDBox)obj).tblvariable.VarName == str1)
                        {

                            tagnameexists = true;
                            break;
                        }
                    }

                }
                if (tagnameexists)
                {
                    count++;
                }
                else
                {
                    if (tblVariable.checkVariableName(_functionname, ((TabFBDPageControl)this.Parenttabgraphicpagecontrol).ID))
                    {
                        count++;
                    }
                    else
                    {
                        return str1;
                    }
                }
            }
            return str1;
        }


    }
}