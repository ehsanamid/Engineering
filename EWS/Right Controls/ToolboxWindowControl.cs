using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WinFormsUI.Docking;
using EWS.Forms;
using EWS;
using EWS.OtherControls;
using EWS.TabPages;
using EWS.Draw;
//using DocToolkit.Project_Objects;


namespace EWS.RightControls
{
    public partial class ToolboxWindowControl : UserControl
    {
        public MainForm mainform;

        public ToolboxWindowControl(MainForm _parent)
        {
            //frm = _frm;
            InitializeComponent();
            mainform = _parent;
        }

        public ToolboxWindowControl(/*MainForm _frm*/)
        {
            //frm = _frm;
            InitializeComponent();
        }
        //public void SetParent(MainForm _parent)
        //{
        //    mainform = _parent;
        //}
        private void listViewToolbox_MouseClick(object sender, MouseEventArgs e)
        {
            ListView.SelectedListViewItemCollection li = listViewToolbox.SelectedItems;
            Form tp = mainform.ActiveMdiChild;
            //TabPageControl tp = (TabPageControl)mainform.TabControlMain.SelectedTab;
            if (tp is TabPageControl)
            {
                switch (((TabPageControl)tp).TabPageType)
                {
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
                            if ("ObjectRectangle" == item.SubItems[0].Text)
                            {
                                _drawarea.ActiveTool = DrawArea.DrawToolType.Rectangle;
                                _drawarea.DrawFilled = true;
                            }
                            if ("RoundedRect" == item.SubItems[0].Text)
                            {
                                _drawarea.ActiveTool = DrawArea.DrawToolType.Rectangle;
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
                                _drawarea.ActiveTool = DrawArea.DrawToolType.PolyLine;
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

        private void listViewToolbox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}