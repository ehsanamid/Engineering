using DCS.DCSTables;
using DCS.TabPages;
using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace DCS.Draw
{
	/// <summary>
	/// PolyLine graphic object - a PolyLine is a series of connected lines
	/// </summary>
	//[Serializable]
    public class DrawCurve : DrawPolyLine
	{
        tblCurve sqltable = new tblCurve();
		/// <summary>
		/// Clone this instance
		/// </summary>
		public override DrawObject Clone()
		{
            DrawCurve drawcurve = new DrawCurve(Parentpagelist);

			//FillDrawObjectFields(drawcurve);
			return drawcurve;
		}

        public DrawCurve(PageList _parent)
            : base(_parent)
		{
            //Resizeable = true;
            //pointArray = new ArrayList();
            ShapeType = STATIC_OBJ_TYPE.ID_CURVE;
			//LoadCursor();
			Initialize();
		}

        public DrawCurve(PageList _parent, int x1, int y1, int x2, int y2)
            : base(_parent)
		{
            Resizeable = true;
            //pointArray = new ArrayList();
            pointArray.Add(new Point(x1, y1));
            pointArray.Add(new Point(x2, y2));
            ShapeType = STATIC_OBJ_TYPE.ID_CURVE;
            //shapefill.FillColor = Common.LastFillColor;
            shapeoutline.LineStyle = Common.LastLineStyle;
            Propertylist.Add("BorderWidth,Border Width,DINT");
            Propertylist.Add("BorderColor,Border Color,Color");
            Propertylist.Add("BorderBlinking,Border Blinking,BOOL");
            //LoadCursor();
            Initialize();
		}
        

        

        
        public override Rectangle GetConnectionEllipse(int connectionNumber)
        {
            Point p = GetConnection(connectionNumber);
            // Take into account width of pen
            return new Rectangle(p.X - (shapeoutline.BoarderWidth + 3), p.Y - (shapeoutline.BoarderWidth + 3), 7 + shapeoutline.BoarderWidth, 7 + shapeoutline.BoarderWidth);
        }



        public override void Draw(Graphics g)
        {

            try
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                Color bcolor = Color.White;
                SelecactiveColor(ref bcolor, shapeoutline);
                Pen pen = MakePen(bcolor, shapeoutline);
                g.DrawCurve(pen, pointArray.ToArray());
                pen.Dispose();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

       

        public override bool Load(object obj)
        {
            bool ret = true;
            Dirty = false;
            sqltable = (tblCurve)obj;
            SQLID = sqltable.ID;
            oIndex = sqltable.oIndex;
            Layer = (LAYERS)sqltable.Layer;
            NewObject = false;

            shapeoutline.LineStyle = sqltable.LineStyle;
            ShapeType = STATIC_OBJ_TYPE.ID_CURVE;
#if EWSAPP
            drawexpressionCollection.DisplayObjectParametersstr = sqltable.Argument;
            drawexpressionCollection.DisplayObjectDynamicPropertysstr = sqltable.Expression;
            drawexpressionCollection.DisplayObjectEventHandlersstr = sqltable.Action;
#endif
            Points = sqltable.Points;

#if OWSAPP
            if (sqltable.validexpression)
            {
                loadDrawExpressionCollection(sqltable.CompiledExp);
                UpdateHasExpression();
            } 
#endif
            return ret;

        }

        public override bool Save(long _id, int _no)
        {
            try
            {
#if EWSAPP
                sqltable.oIndex = _no;
                sqltable.DisplayID = _id;
                sqltable.Layer = (int)Layer;
                sqltable.LineStyle = shapeoutline.LineStyle;
                sqltable.Argument = drawexpressionCollection.DisplayObjectParametersstr;
                sqltable.Expression = drawexpressionCollection.DisplayObjectDynamicPropertysstr;
                sqltable.Action = drawexpressionCollection.DisplayObjectEventHandlersstr;
                sqltable.Points = Points;
                //drawexpressionCollection.ClearCollection();
                if (drawexpressionCollection.CompileGraphicDispalyExpressions(((TabDisplayPageControl)Parentpagelist.Parenttabgraphicpagecontrol).tbldisplay))
                {
                    sqltable.validexpression = true;
                    sqltable.CompiledExp = drawexpressionCollection.SaveCompiledExpressions();

                }
                else
                {
                    sqltable.validexpression = false;
                }
                if (sqltable.ID == -1)
                {
                    sqltable.Insert();
                    SQLID = sqltable.ID;
                }
                else
                {
                    sqltable.Update();
                }





                Dirty = false; 
#endif
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

		public override int HandleCount
		{
			get { return pointArray.Count; }
		}

		/// <summary>
		/// Get handle point by 1-based number
		/// </summary>
		/// <param name="handleNumber"></param>
		/// <returns></returns>
		public override Point GetHandle(int handleNumber)
		{
			if (handleNumber < 1)
				handleNumber = 1;
			if (handleNumber > pointArray.Count)
				handleNumber = pointArray.Count;
			return ((Point)pointArray[handleNumber - 1]);
		}

		public override Cursor GetHandleCursor(int handleNumber)
		{
			return handleCursor;
		}

		public override void MoveHandleTo(Point point, int handleNumber)
		{
            try
            {
                if (handleNumber < 1)
                    handleNumber = 1;

                if (handleNumber > pointArray.Count)
                    handleNumber = pointArray.Count;
                pointArray[handleNumber - 1] = point;
                Invalidate();
                Dirty = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
		}

		public override void Move(int deltaX, int deltaY)
		{
            int n = pointArray.Count;

            for (int i = 0; i < n; i++)
            {
                Point point;
                point = new Point(((Point)pointArray[i]).X + deltaX, ((Point)pointArray[i]).Y + deltaY);
                pointArray[i] = point;
            }
            Dirty = true;
            Invalidate();
		}

		
        ///// <summary>
        ///// Create graphic object used for hit test
        ///// </summary>
        protected override void CreateObjects()
        {
        if (AreaPath != null)
				return;

			// Create closed path which contains all polygon vertexes
			AreaPath = new GraphicsPath();
            // Take into account the width of the pen used to draw the actual object
            AreaPen = new Pen(Color.Black, shapeoutline.BoarderWidth < 7 ? 7 : shapeoutline.BoarderWidth);
            // Prevent Out of Memory crash when startPoint == endPoint
            //int x1 = 0, y1 = 0; // previous point

            //IEnumerator enumerator = pointArray.GetEnumerator();

            //if (enumerator.MoveNext())
            //{
            //    x1 = ((Point)enumerator.Current).X;
            //    y1 = ((Point)enumerator.Current).Y;
            //}

            //while (enumerator.MoveNext())
            //{
            //    int x2, y2; // current point
            //    x2 = ((Point)enumerator.Current).X;
            //    y2 = ((Point)enumerator.Current).Y;

            //    //AreaPath.AddLine(x1, y1, x2, y2);
                 
            //    x1 = x2;
            //    y1 = y2;
            //}
            AreaPath.AddCurve(pointArray.ToArray());
			//AreaPath.CloseFigure();

			// Create region from the path
			AreaRegion = new Region(AreaPath);
        }

        //private void LoadCursor()
        //{
			
        //    try
        //    {

        //        handleCursor = new Cursor(Application.StartupPath + "\\Curve.cur");
        //        //m_Cursor = new Cursor(GetType(), "Rectangle.cur");
        //    }
        //    catch (NullReferenceException e)
        //    {
        //        MessageBox.Show(e.Message.ToString());
        //    }
        //}

        
	}
}