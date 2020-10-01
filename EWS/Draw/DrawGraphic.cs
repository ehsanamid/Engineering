using DCS.Compile;
using DCS.DCSTables;
using DCS.Project_Objects;
using DCS.TabPages;
using DCS.Tools;
using DCS.TypeConverters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Windows.Forms;

namespace DCS.Draw
{
    /// <summary>
    /// _rectangle graphic object
    /// </summary>
    [Serializable]
    public class DrawGraphic : DrawObject
    {
        
        // public tblRect tblrect;

        /// <summary>
        ///  Graphic objects for hit test
        /// </summary>
              VALUE m_val = new VALUE();
        public bool HasVisibleExpression = false;
        protected bool _visible =true;
        public bool Visible
        {
            get
            {
                if (HasVisibleExpression)
                {

#if OWSAPP
                    if (drawexpressionCollection.RunField(enumDynamicGraphicalProperty.Visible, ref m_val))
                    {
                        return m_val.BOOL;
                    }
#endif
                }
                return _visible;
            }
            set
            {
                _visible = value;
            }
        }


        protected Point _center;
        /// <summary>
        /// Center of the object being drawn.
        /// </summary>
        public Point Center
        {
            get { return _center; }
            set { _center = value; }
        }

        private GraphicsPath areaPath = null;
        protected GraphicsPath AreaPath
        {
            get
            {
                return areaPath;
            }
            set
            {
                areaPath = value;
            }
        }

        //



        protected Pen areaPen = null;
        protected Pen AreaPen
        {
            get { return areaPen; }
            set { areaPen = value; }
        }

        private Region areaRegion = null;
        protected Region AreaRegion
        {
            get
            {
                return areaRegion;
            }
            set
            {
                areaRegion = value;
            }
        }
        
        
        DrawExpressionCollection _drawexpressionsCollection;
#if EWSAPP      
        [Editor(typeof(ExpressionTypeEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(ExpressionTypeConverter))]  //[TypeConverter(typeof(ExpandableObjectConverter))]
        [Category("Advance")] 
#endif
        public DrawExpressionCollection drawexpressionCollection
        {
            get
            {
                return _drawexpressionsCollection;
            }
            set
            {
                _drawexpressionsCollection = value;
            }
        }

        protected virtual void  UpdateHasExpression()
        {
            foreach (DisplayObjectDynamicProperty exp in this.drawexpressionCollection.objDisplayObjectDynamicPropertys.list)
            {
                switch (exp.ObjectType)
                {
                    case enumDynamicGraphicalProperty.Visible:
                        this.HasVisibleExpression = true;
                        break;
                }
            }
        }

        public void loadDrawExpressionCollection(byte[] _compiledexp)
        {
            int size = 0;
            int size1 = 0;
            //drawexpressionCollection = new DrawExpressionCollection(this);
            DrawExpressionCollectionCode drawexpressioncollectioncode = new DrawExpressionCollectionCode();
            drawexpressioncollectioncode = (DrawExpressionCollectionCode)RawDeserialize(_compiledexp, 0, typeof(DrawExpressionCollectionCode));
            size = Marshal.SizeOf(drawexpressioncollectioncode);
            if (drawexpressioncollectioncode.IsValid == 1)
            {
                for (int i = 0; i < drawexpressioncollectioncode.NoOfDynamicProperties; i++)
                {
                    ExpressionCode expressioncode = new ExpressionCode();
                    expressioncode = (ExpressionCode)RawDeserialize(_compiledexp, size, typeof(ExpressionCode));
                    size += Marshal.SizeOf(expressioncode);
                    
                    DisplayObjectDynamicProperty displayobjectdynamicproperty = new DisplayObjectDynamicProperty();
                    displayobjectdynamicproperty.ObjectType = (enumDynamicGraphicalProperty)expressioncode.Property;
                    displayobjectdynamicproperty.Type = (VarType)expressioncode.ReturnType;
                    //displayobjectdynamicproperty.IsValid = 1;
                    displayobjectdynamicproperty.IsColor = Convert.ToBoolean(expressioncode.IsColor);
                    displayobjectdynamicproperty.IsString = Convert.ToBoolean(expressioncode.IsString);

                    for (int j = 0; j < expressioncode.NoOfConditions; j++)
                    {
                        ConditionCode conditioncode = new ConditionCode();
                        //conditioncode.StrValue = new STRINGOBJ();
                        conditioncode = (ConditionCode)RawDeserialize(_compiledexp, size, typeof(ConditionCode));
                        size += Marshal.SizeOf(conditioncode);
                        DisplayObjectDynamicPropertyCondition displayobjectdynamicpropertycondition = new DisplayObjectDynamicPropertyCondition();
                        displayobjectdynamicpropertycondition.IsValid = true;
                        displayobjectdynamicpropertycondition.m_Value = conditioncode.Value;
                        //unsafe
                        {
                            displayobjectdynamicpropertycondition.ToCopySTRINGOBJ(conditioncode.StrValue);
                            
                            //for (int k = 0; k < 16; k++)
                            //{
                            //    displayobjectdynamicpropertycondition.m_StrValue.Val[k] = conditioncode.Val[k];
                            //}
                        }
                        size1 = 0;
                        {
                            OPERATION _operation = new OPERATION();
                            _operation = (OPERATION)RawDeserialize(_compiledexp, size, typeof(OPERATION));

                            size1 = Marshal.SizeOf(_operation);
                            size += Marshal.SizeOf(_operation);
                            while (size1 < _operation.Size1)
                            {
                                TICInstruction instruction = new TICInstruction();
                                instruction.Operator = (OPERATOR)RawDeserialize(_compiledexp, size, typeof(OPERATOR));
                                size += Marshal.SizeOf(instruction.Operator);
                                size1 += Marshal.SizeOf(instruction.Operator);
                                for (int k = 0; k < instruction.Operator.NoOfArg; k++)
                                {
                                    OPERAND operand = new OPERAND();
                                    operand = (OPERAND)RawDeserialize(_compiledexp, size, typeof(OPERAND));
                                    size += Marshal.SizeOf(operand);
                                    size1 += Marshal.SizeOf(operand);
                                    instruction.OperandList.Add(operand);
                                }
                                displayobjectdynamicpropertycondition.SimpleOperation.instructionlist.Add(instruction);
                            }
                        }
                        displayobjectdynamicproperty.ConditionList.Add(displayobjectdynamicpropertycondition);
                    }
                    drawexpressionCollection.objDisplayObjectDynamicPropertys.list.Add(displayobjectdynamicproperty);
                }
            }

        }
        
        
        
        public static object RawDeserialize(byte[] rawData, int position, Type anyType)
        {

            try
            {
                int rawsize = Marshal.SizeOf(anyType);
                if (rawsize > rawData.Length)
                    return null;
                IntPtr buffer = Marshal.AllocHGlobal(rawsize);
                Marshal.Copy(rawData, position, buffer, rawsize);
                object retobj = Marshal.PtrToStructure(buffer, anyType);
                Marshal.FreeHGlobal(buffer);
                return retobj;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }
        public virtual void CheckExistingExpressions()
        {

        }
        
        
        //public float[] cuspat = new float[6];

        public List<string> Propertylist = new List<string>();
            

        /*
        //string argumentstr = "";

        [Editor(typeof(ArgumentTypeEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(ArgumentTypeEditor))]  //[TypeConverter(typeof(ExpandableObjectConverter))]
        [Category("Advance")]
        
        public string Argumentstr
        {
            get
            {
                return _drawexpressionsCollection.Argumentstr;
            }
            set
            {
                _drawexpressionsCollection.Argumentstr = value;
            }
        }

        //string expressionstr = "";

        [Editor(typeof(ExpressionTypeEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(ExpressionTypeConverter))]  //[TypeConverter(typeof(ExpandableObjectConverter))]
        [Category("Advance")]
        
        public string Expressionstr
        {
            get
            {
                return _drawexpressionsCollection.Expressionstr;
            }
            set
            {
                _drawexpressionsCollection.Expressionstr = value;
            }
        }
        //string actionstr = "";

        [Editor(typeof(ActionTypeEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(ActionTypeConverter))]  //[TypeConverter(typeof(ExpandableObjectConverter))]
        [Category("Advance")]
        
        public string Actionstr
        {
            get
            {
                return _drawexpressionsCollection.Actionstr;
            }
            set
            {
                _drawexpressionsCollection.Actionstr = value;
            }
        }
        */
        /// <summary>
        /// Clone this instance
        /// </summary>
        public override DrawObject Clone()
        {
            DrawObject drawRectangle = new DrawGraphic(Parentpagelist);
            
            return drawRectangle;
        }

        public DrawGraphic(PageList _parent)
            : base(_parent)
        {
            Resizeable = true;
            _drawexpressionsCollection = new DrawExpressionCollection(this);
        }

        //public DrawGraphic(PageList _parent,int x, int y, int width, int height)
        //    : base(_parent)
        //{
        //    Resizeable = true;
        //    Center = new Point(x + (width / 2), y + (height / 2));
            
        //    TipText = String.Format("_rectangle Center @ {0}, {1}", Center.X, Center.Y);
        //}

        //public DrawGraphic(PageList _parent, int x, int y, int width, int height, Color lineColor, Color fillColor)
        //    : base(_parent)
        //{
        //    Resizeable = true;
        //    Center = new Point(x + (width / 2), y + (height / 2));

        //    //shapeoutline.BoarderColor1 = lineColor;
        //    //FillColor11 = fillColor;
        //    //FillType = FillTypePatern.Transparent;
        //    //shapeoutline.BoarderWidth = 1;
        //    TipText = String.Format("_rectangle Center @ {0}, {1}", Center.X, Center.Y);
        //}

        //public DrawGraphic(PageList _parent, int x, int y, int width, int height, Color lineColor, Color fillColor, bool filled)
        //    : base(_parent)
        //{
        //    Resizeable = true;
        //    Center = new Point(x + (width / 2), y + (height / 2));
            
        //    //BoarderColor1 = lineColor;
        //    //FillColor11 = fillColor;
        //    ////if (filled)
        //    ////{
        //    //FillType = FillTypePatern.Transparent;
        //    //}
        //    //else
        //    //{
        //    //    FillType = 0;
        //    //}
        //    //BoarderWidth = 1;
        //    TipText = String.Format("_rectangle Center @ {0}, {1}", Center.X, Center.Y);
        //}

        //public DrawGraphic(PageList _parent, int x, int y, int width, int height, DrawingPens.PenType pType, Color fillColor, bool filled)
        //    : base(_parent)
        //{
        //    Resizeable = true;
        //    Center = new Point(x + (width / 2), y + (height / 2));
            
        //    //DrawPen = DrawingPens.SetCurrentPen(pType);
        //    //PenType = pType;
        //    //FillColor11 = fillColor;
        //    //FillType = FillTypePatern.Transparent;
        //    //BoarderWidth = 1;
        //    TipText = String.Format("_rectangle Center @ {0}, {1}", Center.X, Center.Y);
        //}

        //public DrawGraphic(PageList _parent, int x, int y, int width, int height, Color lineColor, Color fillColor, bool filled, int lineWidth)
        //    : base(_parent)
        //{
        //    Resizeable = true;
        //    Center = new Point(x + (width / 2), y + (height / 2));
            

        //    //BoarderColor1 = lineColor;
        //    //FillColor11 = fillColor;
        //    //FillType = FillTypePatern.Transparent;
            
        //    //BoarderWidth = lineWidth;
        //    TipText = String.Format("_rectangle Center @ {0}, {1}", Center.X, Center.Y);
        //}

        /// <summary>
        /// Draw rectangle
        /// </summary>
        /// <param name="g"></param>

        //public void makeBoarderDashStyle(/*DashStyle BoarderDashStyle, int BoarderWidth, int BoarderLinePaternScale, ref float[] cuspat*/)
        //{
        //    if (cuspat != null)
        //    {
        //        cuspat = null;
        //    }
        //    //cuspat = new float[6];
        //    switch (shapeoutline.BoarderDashStyle)
        //    {
        //        case DashStyle.Dot:
        //            cuspat = new float[4];
        //            cuspat[0] =  BoarderLinePaternScale;
        //            cuspat[1] =  BoarderLinePaternScale;
        //            cuspat[2] =  BoarderLinePaternScale;
        //            cuspat[3] =  BoarderLinePaternScale;
        //           break;
        //        case DashStyle.DashDotDot:
        //           cuspat = new float[6];
        //            cuspat[0] =  BoarderLinePaternScale * 5;
        //            cuspat[1] =  BoarderLinePaternScale;
        //            cuspat[2] =  BoarderLinePaternScale;
        //            cuspat[3] =  BoarderLinePaternScale;
        //            cuspat[4] =  BoarderLinePaternScale;
        //            cuspat[5] =  BoarderLinePaternScale;
        //            break;
        //        case DashStyle.DashDot:
        //            cuspat = new float[4];
        //            cuspat[0] =  BoarderLinePaternScale * 5;
        //            cuspat[1] =  BoarderLinePaternScale;
        //            cuspat[2] =  BoarderLinePaternScale;
        //            cuspat[3] =  BoarderLinePaternScale;
        //            break;
        //        case DashStyle.Dash:
        //            cuspat = new float[2];
        //            cuspat[0] =  BoarderLinePaternScale * 5;
        //            cuspat[1] =  BoarderLinePaternScale;
        //           break;
        //    }
        //}
        public Pen MakePen(Color _color,ShapeOutline shapeoutline)
        {
            Pen pen = new Pen(_color, shapeoutline.BoarderWidth);

            pen.DashStyle = shapeoutline.BoarderDashStyle;
            //switch (BoarderDashStyle)
            //{

            //    case DashStyle.Dot:
            //    case DashStyle.DashDotDot:
            //    case DashStyle.DashDot:
            //    case DashStyle.Dash:
            //        pen.DashStyle = DashStyle.Custom;
            //        pen.DashPattern = cuspat;
            //        break;
            //    default:
            //        pen.DashStyle = DashStyle.Solid; ;
            //        break;
            //}
            return pen;
        }


        public void SelecactiveColor(ref Color bcolor, ShapeOutline shapeoutline)
        {

            if (Common.Blinking && shapeoutline.BoarderBlinking)
            {
                bcolor = shapeoutline.BoarderColor2;
            }
            else
            {
                bcolor = shapeoutline.BoarderColor1;
            }


        }

        public void SelecactiveColor(ref Color bcolor, ref Color fColor1, ref Color fColor2, ShapeFill shapefill, ShapeOutline shapeoutline)
        {

            if (Common.Blinking && shapeoutline.BoarderBlinking)
            {
                bcolor = shapeoutline.BoarderColor2;
            }
            else
            {
                bcolor = shapeoutline.BoarderColor1;
            }

            switch (shapefill.FillType)
            {
                case FillTypePatern.Transparent:
                    break;
                case FillTypePatern.Solid:

                    //Brush b;
                    if (Common.Blinking && shapefill.Blinking)
                    {
                        fColor1 = shapefill.FillColor12;
                    }
                    else
                    {
                        fColor1 = shapefill.FillColor11;
                    }
                    break;
                case FillTypePatern.Hatched:
                    if (Common.Blinking && shapefill.Blinking)
                    {
                        fColor1 = Color.Transparent;

                    }
                    else
                    {
                        fColor1 = shapefill.FillColor11;
                    }

                    break;
                case FillTypePatern.Gradient:
                    if (Common.Blinking && shapefill.Blinking)
                    {
                        fColor1 = shapefill.FillColor12;
                        fColor2 = shapefill.FillColor22;
                    }
                    else
                    {
                        fColor1 = shapefill.FillColor11;
                        fColor2 = shapefill.FillColor21;
                    }

                    break;
            }
        }

        /// <summary>
        /// Invalidate object.
        /// When object is invalidated, path used for hit test
        /// is released and should be created again.
        /// </summary>
        protected void Invalidate()
        {
            if (AreaPath != null)
            {
                AreaPath.Dispose();
                AreaPath = null;
            }

            if (AreaPen != null)
            {
                AreaPen.Dispose();
                AreaPen = null;
            }

            if (AreaRegion != null)
            {
                AreaRegion.Dispose();
                AreaRegion = null;
            }
        }

        /// <summary>
        /// Create graphic objects used for hit test.
        /// </summary>
        protected virtual void CreateObjects()
        {
            
        }

       


        public override Rectangle GetConnectionEllipse(int connectionNumber)
        {
            Point p = GetConnection(connectionNumber);
            // Take into account width of pen
            return new Rectangle(p.X -3 , p.Y -3 , 7, 7 );
        }


        public override bool Save(long _id, int _no)
        {
              
              return true;
            
        }

        protected DrawGraphic(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            if (info == null)
                throw new ArgumentNullException("info");
            try
            {
#if EWSAPP
                drawexpressionCollection.DisplayObjectParametersstr = info.GetString("Parametersstr");
                drawexpressionCollection.DisplayObjectDynamicPropertysstr = info.GetString("GraphicObjectPropertysstr");
                drawexpressionCollection.DisplayObjectEventHandlersstr = info.GetString("EventHandlersstr"); 
#endif
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        protected override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
#if EWSAPP
            info.AddValue("Argumentstr", drawexpressionCollection.DisplayObjectParametersstr);
            info.AddValue("Expressionstr", drawexpressionCollection.DisplayObjectDynamicPropertysstr);
            info.AddValue("Actionstr", drawexpressionCollection.DisplayObjectEventHandlersstr); 
#endif
            
        }

#if OWSAPP
        public override void ScanObjects(ref CrossReference lookup)
        {
            //drawexpressionCollection.ScanField(ref lookup);
            foreach (DisplayObjectDynamicProperty displayobjectdynamicproperty in drawexpressionCollection.objDisplayObjectDynamicPropertys.list)
            {

                foreach (DisplayObjectDynamicPropertyCondition displayobjectdynamicpropertycondition in displayobjectdynamicproperty.ConditionList)
                {
                    displayobjectdynamicpropertycondition.SimpleOperation.ScanCondition(ref lookup);
                }
            }
        } 

        //void ScanField(ref CrossReference lookup)
        //{
        //    drawexpressionCollection.objDisp
        //    foreach (Expressions exs in drawexpressionCollection.obj)
        //    {
        //        foreach (conditionstruct cs in exs.conditionlist)
        //        {
        //            cs.simpleoperation.ScanCondition(ref  lookup);
                    
        //        }
        //    }
        //} 
#endif
        
    }
}