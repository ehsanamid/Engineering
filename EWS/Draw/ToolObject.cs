using System.Windows.Forms;
using System.Diagnostics;
using DCS.Tools;

namespace DCS.Draw
{
    /// <summary>
    /// Base class for all tools which create new graphic object
    /// </summary>
    internal abstract class ToolObject : Tool
    {
        
        private Cursor cursor;

        /// <summary>
        /// Tool cursor.
        /// </summary>
        public Cursor m_Cursor
        {
            get { return cursor; }
            set { cursor = value; }
        }


        /// <summary>
        /// Left mouse is released.
        /// New object is created and resized.
        /// </summary>
        /// <param name="drawArea"></param>
        /// <param name="e"></param>
        public override void OnMouseUp(DrawArea drawArea, MouseEventArgs e)
        {

            int c = drawArea.ParentTabGraphicPageControl.NoOfObjectsinPage;
            if (c > 0)
                drawArea.ParentTabGraphicPageControl.Pages().GetObject(drawArea.ParentTabGraphicPageControl.Pages().ActivePageNo, c - 1).Normalize();
            //drawArea.ActiveTool = DrawArea.DrawToolType.Pointer;

            drawArea.Capture = false;
            // Trace.WriteLine("drawArea.Capture = false");
            drawArea.Refresh();
        }

        /// <summary>
        /// Add new object to draw area.
        /// Function is called when user left-clicks draw area,
        /// and one of ToolObject-derived tools is active.
        /// </summary>
        /// <param name="drawArea"></param>
        /// <param name="o"></param>
        protected void AddNewObject(DrawArea drawArea, DrawObject o)
        {
            drawArea.UnselectAll();

            o.Selected = true;
            o.Dirty = true;
            //int objectID = 0;
            // Set the object id now

            //objectID = +drawArea.Pages.GraphicPagesList[drawArea.PageNo].List.Count;

            //objectID++;
            //o.ID = objectID;
            o.oIndex = o.Parentpagelist.GetNewobjectoIndex();
            drawArea.Pages.GraphicPagesList[drawArea.ActivePageNo].List.Add(o);
            drawArea.Pages.Dirty = true;
            drawArea.Capture = true;
            // Trace.WriteLine("drawArea.Capture = true");

            drawArea.Refresh();
        }
    }
}