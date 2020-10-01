using DocToolkit;
using DCS.Draw;
using DCS.Draw.FBD;
using DCS.TabPages;
using DCS.Tools;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Reflection;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace DCS.Draw
{
    /// <summary>
    /// List of graphic objects
    /// </summary>
    [Serializable]
    public class GraphicsList
    {
        //private ArrayList graphicsList;
        List<DrawObject> graphicsList;
        public List<DrawObject> List
        {
            get
            {
                return graphicsList;
            }
            set
            {
                graphicsList = value;
            }
        }

       // private bool _isDirty;

        
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
        public IEnumerable<DrawObject> Selection
        {
            get
            {
                foreach (DrawObject o in graphicsList)
                {
                    if (o.Selected)
                    {
                        yield return o;
                    }
                }
            }
        }

        int objectcounter = 0;
        public int ObjectCounter
        {
            get
            {
                return objectcounter;
            }
            set
            {
                objectcounter = value;
            }
        }

        private const string entryCount = "ObjectCount";
        private const string entryType = "ObjectType";

        //DrawArea Parent;
        //TabGraphicPageControl Parent;
        public GraphicsList(/*TabGraphicPageControl _parent DrawArea _parent*/)
        {
           // Parent = _parent;
            //graphicsList = new ArrayList();
            graphicsList = new List<DrawObject>();
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
        //public void DrawControl(Graphics g)
        //{
        //    int numberObjects = graphicsList.Count;

        //    for (int i = 0 ; i < numberObjects ; i++)
        //    {
        //        DrawObject o;
        //        o = (DrawObject)graphicsList[i];
        //        if (LayerIsEnable(o))
        //        {
        //            if (o.IntersectsWith(Rectangle.Round(g.ClipBounds)))
        //                o.Draw(g);

        //            if (o.Selected)
        //                o.DrawTracker(g);
        //        }
        //    }
        //}

        

        public void ScanObjects(ref CrossReference lookup)
        {
            //GraphicPagesList[ActivePageNo].ScanObjects(ref lookup);
            int numberObjects = graphicsList.Count;

            for (int i = 0; i < numberObjects; i++)
            {
                DrawObject o;
                o = (DrawObject)graphicsList[i];
                o.ScanObjects(ref  lookup);

            }
        }
        /// <summary>
        /// Clear all objects in the list
        /// </summary>
        /// <returns>
        /// true if at least one object is deleted
        /// </returns>
        public bool Clear()
        {
            bool result = (graphicsList.Count > 0);
            graphicsList.Clear();
            // Set dirty flag based on result. Result is true only if at least one item was cleared and since the list is empty, there can be nothing dirty.
            //if (result)
            //    Dirty = false;
            return result;
        }

        /// <summary>
        /// Count and this [nIndex] allow to read all graphics objects
        /// from GraphicsList in the loop.
        /// </summary>
        public int Count
        {
            get { return graphicsList.Count; }
        }
        /// <summary>
        /// Allow accessing Draw Objects by index
        /// </summary>
        /// <param name="index">0-based index to retrieve</param>
        /// <returns>Selected DrawObject</returns>
        public DrawObject this[int index]
        {
            get
            {
                if (index < 0 ||
                    index >= graphicsList.Count)
                    return null;

                return (DrawObject)graphicsList[index];
            }
        }

        /// <summary>
        /// SelectedCount and GetSelectedObject allow to read
        /// selected objects in the loop
        /// </summary>
        public int SelectionCount
        {
            get
            {
                int n = 0;

                foreach (DrawObject o in graphicsList)
                {
                    if (o.Selected)
                        n++;
                }

                return n;
            }
        }

        public DrawObject GetSelectedObject(int index)
        {
            int n = -1;

            foreach (DrawObject o in graphicsList)
            {
                if (o.Selected)
                {
                    n++;

                    if (n == index)
                        return o;
                }
            }

            return null;
        }

        public void Add(DrawObject obj)
        {
            
            graphicsList.Add(obj);
        }

        /// <summary>
        /// Thanks to Member 3272353 for this fix to object ordering problem.
        /// </summary>
        /// <param name="obj"></param>
        public void Append(DrawObject obj)
        {
            graphicsList.Add(obj);
        }

        //public void SelectInRectangle(Rectangle rectangle)
        //{
        //    UnselectAll();

        //    foreach (DrawObject o in graphicsList)
        //    {
        //        if (o.IntersectsWith(rectangle))
        //            o.Selected = true;
        //    }
        //}

        //public void UnselectAll()
        //{
        //    foreach (DrawObject o in graphicsList)
        //    {
        //        o.Selected = false;
        //    }
        //}

        //public void SelectAll()
        //{
        //    foreach (DrawObject o in graphicsList)
        //    {
        //        o.Selected = true;
        //    }
        //}

        /// <summary>
        /// Delete selected items
        /// </summary>
        /// <returns>
        /// true if at least one object is deleted
        /// </returns>
        //public bool DeleteSelection()
        //{
        //    bool result = false;

        //    int n = graphicsList.Count;

            
        //    foreach (DrawObject drawobject in graphicsList)
        //    {
        //        if (((DrawObject)drawobject).Selected)
        //        {
        //            drawobject.MustBeRemoved = true;
        //            if (drawobject is DrawFBDBox)
        //            {
        //                foreach (FBDObjectPin fbdobjectpin in ((DrawFBDBox)drawobject).fbdboxobject.PinCollectionInput)
        //                {
        //                    foreach (long lng in fbdobjectpin.WireConnectionID)
        //                    {
        //                        foreach (DrawLogic drawobject1 in graphicsList)
        //                        {
        //                            if (drawobject1.ID == lng)
        //                            {
        //                                drawobject1.MustBeRemoved = true;
        //                                break;
        //                            }
        //                        }
        //                    }
        //                }
        //                foreach (FBDObjectPin fbdobjectpin in ((DrawFBDBox)drawobject).fbdboxobject.PinCollectionOutput)
        //                {
        //                    foreach (long lng in fbdobjectpin.WireConnectionID)
        //                    {
        //                        foreach (DrawLogic drawobject1 in graphicsList)
        //                        {
        //                            if (drawobject1.ID == lng)
        //                            {
        //                                drawobject1.MustBeRemoved = true;
        //                                break;
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //            if (drawobject is DrawWire)
        //            {
        //                foreach (DrawLogic drawobject1 in graphicsList)
        //                {
        //                    //if (((DrawWire)drawobject).OutputObjectName == drawobject1.InstanseName)
        //                    if (drawobject1 is DrawFBDBox)
        //                    {
        //                        if (((DrawWire)drawobject).OutputObjectID == drawobject1.ID)
        //                        {
        //                            for (int i = 0; i < ((DrawFBDBox)drawobject1).fbdboxobject.PinCollectionOutput[((DrawWire)drawobject).OutputPinNo].WireConnectionID.Count; i++)
        //                            {
        //                                if (((DrawFBDBox)drawobject1).fbdboxobject.PinCollectionOutput[((DrawWire)drawobject).OutputPinNo].WireConnectionID[i] == ((DrawWire)drawobject).ID)
        //                                {
        //                                    ((DrawFBDBox)drawobject1).fbdboxobject.PinCollectionOutput[((DrawWire)drawobject).OutputPinNo].WireConnectionID.RemoveAt(i);
        //                                    break;
        //                                }
        //                            }
        //                        }
        //                        //if (((DrawWire)drawobject).InputObjectName == drawobject1.InstanseName)
        //                        if (((DrawWire)drawobject).InputObjectID == drawobject1.ID)
        //                        {
        //                            for (int i = 0; i < ((DrawFBDBox)drawobject1).fbdboxobject.PinCollectionInput[((DrawWire)drawobject).InputPinNo].WireConnectionID.Count; i++)
        //                            {
        //                                if (((DrawFBDBox)drawobject1).fbdboxobject.PinCollectionInput[((DrawWire)drawobject).InputPinNo].WireConnectionID[i] == ((DrawWire)drawobject).ID)
        //                                {
        //                                    ((DrawFBDBox)drawobject1).fbdboxobject.PinCollectionInput[((DrawWire)drawobject).InputPinNo].WireConnectionID.RemoveAt(i);
        //                                    break;
        //                                }
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //            //drawobject = true;
        //        }
        //    }

        //    for (int i = n - 1; i >= 0; i--)
        //    {
        //        if (((DrawObject)graphicsList[i]).MustBeRemoved)
        //        {
        //            graphicsList.RemoveAt(i);
        //            result = true;
        //        }
        //    }

        //    if (result)
        //        Dirty = true;
        //    UpdateoIndex();
        //    return result;
        //}


        /// <summary>
        /// Delete selected items
        /// </summary>
        /// <returns>
        /// true if at least one object is deleted
        /// </returns>
        public bool RemoveFromList(Guid _guid)
        {
            bool result = false;

            
            for (int i = 0 ; i< graphicsList.Count ; i++)
            {
                if (((DrawObject)graphicsList[i]).GUID == _guid)
                {
                    graphicsList.RemoveAt(i);
                    result = true;
                }
            }

            //if (result)
            //    Dirty = true;
            ReindexList();
            return result;
        }

        /// <summary>
        /// Move selected items
        /// </summary>
        /// <returns>
        /// </returns>
        public void MoveSelection(int dx, int dy)
        {
            foreach (DrawObject drawobject in graphicsList)
            {
                if (((DrawObject)drawobject).Selected)
                {
                    drawobject.Move(dx, dy);
                    drawobject.Dirty = true;
                    //Dirty = true;
                }
            }
        }

        /// <summary>
        /// Delete last added object from the list
        /// (used for Undo operation).
        /// </summary>
        public void DeleteLastAddedObject()
        {
            if (graphicsList.Count > 0)
            {
                graphicsList.RemoveAt(0);
                ReindexList();
            }
        }

        /// <summary>
        /// Replace object in specified place.
        /// Used for Undo.
        /// </summary>
        public void Replace(int index, DrawObject obj)
        {
            if (index >= 0 && index < graphicsList.Count)
            {
                graphicsList.RemoveAt(index);
                graphicsList.Insert(index, obj);
                ReindexList();
            }
        }

        /// <summary>
        /// Remove object by index.
        /// Used for Undo.
        /// </summary>
        public void RemoveAt(int index)
        {
            graphicsList.RemoveAt(index);
            ReindexList();
        }

        /// <summary>
        /// Move selected items to front (beginning of the list)
        /// </summary>
        /// <returns>
        /// true if at least one object is moved
        /// </returns>
        /// 
         public bool MoveSelectionToFront()
        {
            int no = 0;
            int count = graphicsList.Count;
            int selectedcount = SelectionCount;
            no = count - 1;
            for (int i = count - 1; i >= 0; i--)
            {
                if (graphicsList[i].Selected)
                {
                    graphicsList[i].oIndex = no--;
                    graphicsList[i].Dirty = true;
                }
            }
            for (int i = count - 1; i >= 0; i--)
            {
                if (!graphicsList[i].Selected)
                {
                    graphicsList[i].oIndex = no--;
                    graphicsList[i].Dirty = true;
                }
            }
            SortoIndex();
            //ReindexList();
            return true;
            
        }
        /// <summary>
        /// Move selected items to back (end of the list)
        /// </summary>
        /// <returns>
        /// true if at least one object is moved
        /// </returns>
        /// 

         public bool MoveSelectionToBack()
        {
            int no = 0;
            int count = graphicsList.Count;
            int selectedcount = SelectionCount;
            for (int i = 0; i < count; i++)
            {
                if (graphicsList[i].Selected)
                {
                    graphicsList[i].oIndex = no++;
                    graphicsList[i].Dirty = true;
                }
            }
            for (int i = 0; i < count; i++)
            {
                if (!graphicsList[i].Selected)
                {
                    graphicsList[i].oIndex = no++;
                    graphicsList[i].Dirty = true;
                }
            }
            SortoIndex();
            return true;
        }

        
        public void ReindexList()
        {
            int n;
            int i;

            n = graphicsList.Count;
            for (i = 0; i < n; i++)
            {
                ((DrawObject)graphicsList[i]).oIndex = i;
            }
        }

        public void SortoIndex()
        {
            IEnumerable<DrawObject> query = graphicsList.OrderBy(x => x.oIndex).ToList(); ;
            graphicsList.Clear();
            graphicsList = query.ToList<DrawObject>();
        }

        /// <summary>
        /// Get properties from selected objects and fill GraphicsProperties instance
        /// </summary>
        /// <returns></returns>
        private GraphicsProperties GetProperties()
        {
            GraphicsProperties properties = new GraphicsProperties();

            //int n = SelectionCount;

            //if (n < 1)
            //    return properties;

            //DrawObject o = GetSelectedObject(0);

            //int firstColor = o.Color.ToArgb();
            //int firstPenWidth = o.PenWidth;

            //bool allColorsAreEqual = true;
            //bool allWidthAreEqual = true;

            //for (int i = 1; i < n; i++)
            //{
            //    if (GetSelectedObject(i).Color.ToArgb() != firstColor)
            //        allColorsAreEqual = false;

            //    if (GetSelectedObject(i).PenWidth != firstPenWidth)
            //        allWidthAreEqual = false;
            //}

            //if (allColorsAreEqual)
            //{
            //    properties.ColorDefined = true;
            //    properties.Color = Color.FromArgb(firstColor);
            //}

            //if (allWidthAreEqual)
            //{
            //    properties.PenWidthDefined = true;
            //    properties.PenWidth = firstPenWidth;
            //}

            return properties;
        }

        /// <summary>
        /// Apply properties for all selected objects
        /// </summary>
        private void ApplyProperties()
        {
            //foreach (DrawObject o in graphicsList)
            //{
            //    if (o.Selected)
            //    {
            //        if (properties.ColorDefined)
            //        {
            //            o.Color = properties.Color;
            //            DrawObject.LastUsedColor = properties.Color;
            //        }

            //        if (properties.PenWidthDefined)
            //        {
            //            o.PenWidth = properties.PenWidth;
            //            DrawObject.LastUsedPenWidth = properties.PenWidth;
            //        }
            //    }
            //}
        }

        /// <summary>
        /// Show Properties dialog. Return true if list is changed
        /// </summary>
        /// <param name="parent"></param>
        /// <returns></returns>
        public bool ShowPropertiesDialog(IWin32Window parent)
        {
            if (SelectionCount < 1)
                return false;

            GraphicsProperties properties = GetProperties();
            PropertiesDialog dlg = new PropertiesDialog();
            dlg.Properties = properties;

            if (dlg.ShowDialog(parent) !=
                DialogResult.OK)
                return false;

            ApplyProperties();

            return true;
        }
    }
}