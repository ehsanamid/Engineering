using DCS;
using DCS.Draw;
using DCS.Forms;
using DCS.TabPages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace DCS.LeftControls
{
    public partial class ToolboxWindow : ToolWindow
    {
        //MainForm mainform;
        
        
        public ToolboxWindow()
        {
           // mainform = _parent;
            InitializeComponent();
        }

        public ListView m_toolBox
        {
            get
            {
                return listViewToolbox;
            }
        }

        private void listViewToolbox_MouseClick(object sender, MouseEventArgs e)
        {
            ListView.SelectedListViewItemCollection li = listViewToolbox.SelectedItems;
            Form tp = MainForm.Instance().ActiveMdiChild;
            if (tp is TabPageControl)
            {
                switch (((TabPageControl)tp).TabPageType)
                {
                    case TABPAGETYPE.UD_FUNCTION:
                    case TABPAGETYPE.UD_FUNCTIONBLOCK:
                    case TABPAGETYPE.FBD:
                    case TABPAGETYPE.DISPLAY:

                        DrawArea _drawarea = ((TabGraphicPageControl)tp).drawarea;
                        foreach (ListViewItem item in li)
                        {
                            if ("Pointer" == item.SubItems[0].Text)
                            {
                                _drawarea.ActiveTool = DrawArea.DrawToolType.Pointer;
                            }
                            if ("Connection" == item.SubItems[0].Text)
                            {
                                _drawarea.ActiveTool = DrawArea.DrawToolType.Wire;
                                _drawarea.DrawFilled = true;
                            }
                            if ("Function Block" == item.SubItems[0].Text)
                            {
                                _drawarea.ActiveTool = DrawArea.DrawToolType.FunctionBlock;
                                _drawarea.DrawFilled = true;
                            }
                            if ("Comment" == item.SubItems[0].Text)
                            {
                                _drawarea.ActiveTool = DrawArea.DrawToolType.Comment;
                                _drawarea.DrawFilled = true;

                            }
                            if ("Function" == item.SubItems[0].Text)
                            {
                                _drawarea.ActiveTool = DrawArea.DrawToolType.Function;
                                _drawarea.DrawFilled = true;

                            }
                            if ("Variable" == item.SubItems[0].Text)
                            {
                                _drawarea.ActiveTool = DrawArea.DrawToolType.Variable;
                                _drawarea.DrawFilled = true;
                            }

                            if ("Line" == item.SubItems[0].Text)
                            {
                                _drawarea.ActiveTool = DrawArea.DrawToolType.Line;
                                _drawarea.DrawFilled = true;
                            }
                            if ("Rectangle" == item.SubItems[0].Text)
                            {
                                _drawarea.ActiveTool = DrawArea.DrawToolType.Rectangle;
                                _drawarea.DrawFilled = true;
                            }
                            if ("Curve" == item.SubItems[0].Text)
                            {
                                _drawarea.ActiveTool = DrawArea.DrawToolType.Curve;
                                _drawarea.DrawFilled = true;
                            }
                            if ("Ellipse" == item.SubItems[0].Text)
                            {
                                _drawarea.ActiveTool = DrawArea.DrawToolType.Ellipse;
                                _drawarea.DrawFilled = true;
                            }
                            if ("Image" == item.SubItems[0].Text)
                            {
                                _drawarea.ActiveTool = DrawArea.DrawToolType.Image;
                                _drawarea.DrawFilled = true;
                            }
                            if ("Polyline" == item.SubItems[0].Text)
                            {
                                _drawarea.ActiveTool = DrawArea.DrawToolType.PolyLine;
                                _drawarea.DrawFilled = true;
                            }
                            if ("Polygon" == item.SubItems[0].Text)
                            {
                                _drawarea.ActiveTool = DrawArea.DrawToolType.Polygon;
                                _drawarea.DrawFilled = true;
                            }
                            if ("Text" == item.SubItems[0].Text)
                            {
                                _drawarea.ActiveTool = DrawArea.DrawToolType.Text;
                                _drawarea.DrawFilled = true;
                            }
                        }
                        break;
                }
            }
        }
    }
}