using System.Drawing;
using System.Windows.Forms;
using DCS.Tools;
using DCS.Forms;
using DCS.DCSTables;
using System;
using DCS.TabPages;

#if EWSAPP
namespace DCS.Draw.FBD
{
	/// <summary>
	/// ObjectRectangle tool
	/// </summary>
	internal class ToolFunction : ToolObject
	{
        
        
        public int TitleSize;
        Color FunctionColor = Color.Black;
        Color FunctionFillColor = Color.Blue;
        
        bool IsFunction;
        public ToolFunction(bool _isfunction)
		{
            IsFunction = _isfunction;
            try
            {
                if (IsFunction)
                {
                    m_Cursor = new Cursor(Application.StartupPath + "\\Function.cur");



                }
                else
                {
                    m_Cursor = new Cursor(Application.StartupPath + "\\FB.cur");
                }
            }
            catch (NullReferenceException e)
            {
                MessageBox.Show(e.Message.ToString());
            }
            //DeltaX = Common.UnitSize * Common.BaseSize ;
            //DeltaY = Common.UnitSize * Common.BaseSize * 6 ;
            //TitleSize = Common.UnitSize * Common.BaseSize;
		}
        
		public override void OnMouseDown(DrawArea drawArea, MouseEventArgs e)
		{
            Point p;
            if (drawArea.SnapEnable)
            {
                p = drawArea.BackTrackMouse(new Point(drawArea.FittoSnap(e.X, drawArea.SnapX), drawArea.FittoSnap(e.Y, drawArea.SnapY)));
            }
            else
            {
                p = drawArea.BackTrackMouse(new Point(e.X, e.Y));
            }
            InsertFBD insertfbd = new InsertFBD(IsFunction);
			DialogResult dialogResult;
            if (drawArea.ParentTabGraphicPageControl.TabPageType == TABPAGETYPE.FBD)
            {
                insertfbd.pouID = ((TabFBDPageControl)drawArea.ParentTabGraphicPageControl).ID;
                //insertfbd.ControllerID = tblSolution.m_tblSolution().GetControllerobjectofPOUID(insertfbd.pouID).ControllerID;
            }
            
            

//insertfbd.drawArea = drawArea;
            dialogResult = insertfbd.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                
                DrawFBDBox obj;
                if (IsFunction)
                {
                    insertfbd._tblvariable.VarName = drawArea.ParentTabGraphicPageControl.Pages().FindFunctionNameInstance(insertfbd._tblfunction.FunctionName);
                    if (insertfbd._tblfunction.Extensible)
                    {

                        AddNewObject(drawArea, (obj = new DrawFunctionEx(drawArea.ParentTabGraphicPageControl.Pages(), p.X, p.Y, insertfbd._tblfunction, insertfbd._tblvariable, insertfbd.NoOfExtension)));
                    }
                    else
                    {
                        AddNewObject(drawArea, (obj = new DrawFunction(drawArea.ParentTabGraphicPageControl.Pages(), p.X, p.Y, insertfbd._tblfunction, insertfbd._tblvariable)));
                    }
                }
                else
                {
                    AddNewObject(drawArea, (obj = new DrawFunctionBlock(drawArea.Pages, p.X, p.Y, insertfbd._tblfunction, insertfbd._tblvariable)));
                }
                obj.DeltaX = Common.UnitSize * Common.BaseSize;
                obj.DeltaY = Common.UnitSize * Common.BaseSize * 6;
                TitleSize = Common.UnitSize * Common.BaseSize;
                DCS.Forms.MainForm.Instance().m_propertyGrid.SelectedObject = obj;
                
                drawArea.Capture = false;

            }
		}

		public override void OnMouseMove(DrawArea drawArea, MouseEventArgs e)
		{
            drawArea.Cursor = m_Cursor;
			if (e.Button == MouseButtons.Left)
			{
                Point p;
                //if (drawArea.SnapEnable)
                //{
                //    p = drawArea.BackTrackMouse(new Point(drawArea.FittoSnap(e.X, drawArea.SnapX), drawArea.FittoSnap(e.Y, drawArea.SnapY)));
                //}
                //else
                {
                    p = drawArea.BackTrackMouse(new Point(e.X, e.Y));
                }
                //drawArea.Graphics[0].MoveHandleTo(p, 5);
				drawArea.Refresh();
			}
		}
	}
}

#endif