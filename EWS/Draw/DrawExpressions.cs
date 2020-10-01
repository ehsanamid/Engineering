using DCS.Compile;
//#if EWSAPP
using DCS.Compile.Operation; 
//#endif
using DCS;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml;
using System.Runtime.InteropServices;
using DCS.Tools;
using DCS.TabPages;
using DCS.DCSTables;
using DCS.Forms;
using DCS.Project_Objects;
using System.Windows.Forms;


namespace DCS.Draw
{
   
    //public class Argumentstruct
    //{
    //    public string Name;
    //    public string Type;
    //    public string Reference;
    //    public string Iuput;
    //}

    //public class Actionstruct
    //{
    //    public string Event;
    //    public string Handler;
    //    public string AccessLevel;
    //}
    //public class conditionstruct
    //{
    //    //public string condition;
    //    public VALUE m_value = new VALUE();
    //    public STRINGOBJ m_strvalue = new STRINGOBJ();
    //    string _value;
    //    public string value
    //    {
    //        get
    //        {
    //            return _value;
    //        }
    //        set
    //        {
    //            _value = value;
    //        }
    //    }
    //    public SimpleOperation simpleoperation;
    //    public bool IsValid;
    //    public conditionstruct()
    //    {
    //        simpleoperation = new SimpleOperation();
    //        IsValid = false;
    //    }
    //}



    //public class Expressions
    //{
    //    public string FieldName;
    //    PropertyExpressionList _name;
    //    public PropertyExpressionList Name
    //    {
    //        get
    //        {
    //            return _name;
    //        }
    //        set
    //        {
    //            _name = value;
    //        }
    //    }
    //    public string FieldType;
    //    public VarType Type;
    //    public List<conditionstruct> conditionlist;
    //    public bool IsValid;
    //    public bool IsColor;
    //    public bool IsString;
    //    public Expressions()
    //    {
    //        conditionlist = new List<conditionstruct>();

    //    }

    //}



    public class DrawExpressionCollection
    {
        DrawGraphic parentDrawGraphic;
        #region Lists
        public DisplayObjectParameters objDisplayObjectParameters = new DisplayObjectParameters();
        public DisplayObjectEventHandlers objDisplayObjectEventHandlers = new DisplayObjectEventHandlers();
        public DisplayObjectDynamicPropertys objDisplayObjectDynamicPropertys = new DisplayObjectDynamicPropertys();



        #endregion

#if EWSAPP
        #region ImporExportSelected
        string _DisplayObjectParametersstr = "";
        public string DisplayObjectParametersstr
        {
            get
            {
                SerializeDeserialize<DisplayObjectParameters> sd;
                sd = new SerializeDeserialize<DisplayObjectParameters>();
                _DisplayObjectParametersstr = sd.SerializeData(objDisplayObjectParameters);
                return _DisplayObjectParametersstr;
            }
            set
            {
                try
                {
                    _DisplayObjectParametersstr = value;
                    objDisplayObjectParameters.list.Clear();
                    if (_DisplayObjectParametersstr != "")
                    {

                        SerializeDeserialize<DisplayObjectParameters> sd;
                        sd = new SerializeDeserialize<DisplayObjectParameters>();
                        objDisplayObjectParameters = new DisplayObjectParameters();
                        objDisplayObjectParameters = sd.DeserializeData(_DisplayObjectParametersstr);
                        
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }

        string _DisplayObjectEventHandlersstr = "";
        public string DisplayObjectEventHandlersstr
        {
            get
            {
                SerializeDeserialize<DisplayObjectEventHandlers> sd;
                sd = new SerializeDeserialize<DisplayObjectEventHandlers>();
                _DisplayObjectEventHandlersstr = sd.SerializeData(objDisplayObjectEventHandlers);
                return _DisplayObjectEventHandlersstr;
            }
            set
            {
                try
                {
                    _DisplayObjectEventHandlersstr = value;
                    objDisplayObjectEventHandlers.list.Clear();
                    if (_DisplayObjectEventHandlersstr != "")
                    {
                        SerializeDeserialize<DisplayObjectEventHandlers> sd;
                        sd = new SerializeDeserialize<DisplayObjectEventHandlers>();
                        objDisplayObjectEventHandlers = new DisplayObjectEventHandlers();
                        objDisplayObjectEventHandlers = sd.DeserializeData(_DisplayObjectEventHandlersstr);
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }

        string _DisplayObjectDynamicPropertysstr = "";
        public string DisplayObjectDynamicPropertysstr
        {
            get
            {
                SerializeDeserialize<DisplayObjectDynamicPropertys> sd;
                sd = new SerializeDeserialize<DisplayObjectDynamicPropertys>();
                _DisplayObjectDynamicPropertysstr = sd.SerializeData(objDisplayObjectDynamicPropertys);
                return _DisplayObjectDynamicPropertysstr;
            }
            set
            {
                try
                {
                    _DisplayObjectDynamicPropertysstr = value;
                    objDisplayObjectDynamicPropertys.list.Clear();
                    if (_DisplayObjectDynamicPropertysstr != "")
                    {
                        SerializeDeserialize<DisplayObjectDynamicPropertys> sd;
                        sd = new SerializeDeserialize<DisplayObjectDynamicPropertys>();
                        objDisplayObjectDynamicPropertys = new DisplayObjectDynamicPropertys();
                        objDisplayObjectDynamicPropertys = sd.DeserializeData(_DisplayObjectDynamicPropertysstr);
                        objDisplayObjectDynamicPropertys.SetStringvalue2Value();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        
        #endregion 
#endif
        
        public DrawExpressionCollection(DrawGraphic _parent)
        {
            parentDrawGraphic = _parent;
        }

        
        
       
        

#if EWSAPP

        //private void FillPropertyList(ref ExpressionCode expressioncode, string fieldname)
        private void FillPropertyList(ref ExpressionCode expressioncode, enumDynamicGraphicalProperty fieldname)
        {
            switch (fieldname)
            {
                case enumDynamicGraphicalProperty.BorderWidth:
                    expressioncode.Property = (int)enumDynamicGraphicalProperty.BorderWidth;
                    expressioncode.ReturnType = (int)VarType.DINT;
                    expressioncode.IsColor = 0;
                    break;
                case enumDynamicGraphicalProperty.BorderColor:
                    expressioncode.Property = (int)enumDynamicGraphicalProperty.BorderColor;
                    expressioncode.ReturnType = (int)VarType.DINT;
                    expressioncode.IsColor = 1;
                    break;
                case enumDynamicGraphicalProperty.Color1:
                    expressioncode.Property = (int)enumDynamicGraphicalProperty.Color1;
                    expressioncode.ReturnType = (int)VarType.DINT;
                    expressioncode.IsColor = 1;
                    break;
                case enumDynamicGraphicalProperty.Color2:
                    expressioncode.Property = (int)enumDynamicGraphicalProperty.Color2;
                    expressioncode.ReturnType = (int)VarType.DINT;
                    expressioncode.IsColor = 1;
                    break;
                case enumDynamicGraphicalProperty.TextColor:
                    expressioncode.Property = (int)enumDynamicGraphicalProperty.TextColor;
                    expressioncode.ReturnType = (int)VarType.DINT;
                    expressioncode.IsColor = 1;
                    break;
                case enumDynamicGraphicalProperty.BorderBlinking:
                    expressioncode.Property = (int)enumDynamicGraphicalProperty.BorderBlinking;
                    expressioncode.ReturnType = (int)VarType.BOOL;
                    expressioncode.IsColor = 0;
                    break;
                case enumDynamicGraphicalProperty.Blinking:
                    expressioncode.Property = (int)enumDynamicGraphicalProperty.Blinking;
                    expressioncode.ReturnType = (int)VarType.BOOL;
                    expressioncode.IsColor = 0;
                    break;
                case enumDynamicGraphicalProperty.TextBlinking:
                    expressioncode.Property = (int)enumDynamicGraphicalProperty.TextBlinking;
                    expressioncode.ReturnType = (int)VarType.BOOL;
                    expressioncode.IsColor = 0;
                    break;
                case enumDynamicGraphicalProperty.Text:
                    expressioncode.Property = (int)enumDynamicGraphicalProperty.Text;
                    expressioncode.ReturnType = (int)VarType.STRING;
                    expressioncode.IsColor = 0;
                    break;
                case enumDynamicGraphicalProperty.Visible:
                    expressioncode.Property = (int)enumDynamicGraphicalProperty.Visible;
                    expressioncode.ReturnType = (int)VarType.BOOL;
                    expressioncode.IsColor = 0;
                    break;
            }
        }
        public void ClearCollection()
        {
            foreach (DisplayObjectDynamicProperty graphicobjectproperty in objDisplayObjectDynamicPropertys.list)
            {
                foreach (DisplayObjectDynamicPropertyCondition cs in graphicobjectproperty.ConditionList)
                {
                    foreach (TICInstruction ins in cs.SimpleOperation.instructionlist)
                    {
                        ins.OperandList.Clear();
                    }
                    cs.SimpleOperation.instructionlist.Clear();
                }
                //exs.conditionlist.Clear();
            }
        }
        public bool CompileGraphicDispalyExpressions(tblDisplay _tbldisplay)
        {
            foreach (DisplayObjectDynamicProperty graphicobjectproperty in objDisplayObjectDynamicPropertys.list)
            {
                foreach (DisplayObjectDynamicPropertyCondition cs in graphicobjectproperty.ConditionList)
                {
                    if (!CompileGraphicDispalyExpression(_tbldisplay, cs.SimpleOperation, this.objDisplayObjectParameters))
                    {
                        MainForm.Instance().WriteToOutputWindows("Expression compile error");
                        return false;
                    }
                }
            }
            return true;
        }

        public byte[] SaveCompiledExpressions()
        {
            List<byte> buffer = new List<byte>();
            //VALUE _value = new VALUE();
            //string _valuestr = "";
            int size = 0;

            DrawExpressionCollectionCode drawexpressioncollectioncode = new DrawExpressionCollectionCode();

            size = Marshal.SizeOf(drawexpressioncollectioncode);
            drawexpressioncollectioncode.BufferSize = size;
            drawexpressioncollectioncode.IsValid = 1;
            drawexpressioncollectioncode.NoOfDynamicProperties = objDisplayObjectDynamicPropertys.Count;
            //drawexpressioncollectioncode.NoOfExpressions = 0;
            // add above structure to buffer
            StructFile sfDrawExpressionCollectionCode = new StructFile(typeof(DrawExpressionCollectionCode));
            sfDrawExpressionCollectionCode.WriteStructure(ref buffer, (object)drawexpressioncollectioncode);
            //

            foreach (DisplayObjectDynamicProperty exs in objDisplayObjectDynamicPropertys.list)
            {
                ExpressionCode expressioncode = new ExpressionCode();

                size = Marshal.SizeOf(expressioncode);
                expressioncode.Property = (int)exs.ObjectType;
                expressioncode.NoOfConditions = exs.NoOfConditions;
                expressioncode.ReturnType = (int)exs.Type;
                if (exs.IsColor)
                {
                    expressioncode.IsColor = 1;
                }
                else
                {
                    expressioncode.IsColor = 0;
                }
                expressioncode.ExecutionType = 1;//  0 initialization  1 Cyclic
                expressioncode.IsValid = 0;

                StructFile sfEcpressionCode = new StructFile(typeof(ExpressionCode));

                expressioncode.IsValid = 1;

                FillPropertyList(ref  expressioncode, exs.ObjectType);
                sfEcpressionCode.WriteStructure(ref buffer, (object)expressioncode);

                foreach (DisplayObjectDynamicPropertyCondition cs in exs.ConditionList)
                {
                    ConditionCode conditioncode = new ConditionCode();
                    //conditioncode.StrValue = new STRINGOBJ();
                    conditioncode.Size = cs.SimpleOperation.Size1();
                    if (exs.IsString)
                    {
                        //unsafe
                        {
                            conditioncode.StrValue.Len = cs.m_StrValue.Len;
                            conditioncode.StrValue.Val00 = cs.m_StrValue.Val00;
                            conditioncode.StrValue.Val01 = cs.m_StrValue.Val01;
                            conditioncode.StrValue.Val02 = cs.m_StrValue.Val02;
                            conditioncode.StrValue.Val03 = cs.m_StrValue.Val03;
                            conditioncode.StrValue.Val04 = cs.m_StrValue.Val04;
                            conditioncode.StrValue.Val05 = cs.m_StrValue.Val05;
                            conditioncode.StrValue.Val06 = cs.m_StrValue.Val06;
                            conditioncode.StrValue.Val07 = cs.m_StrValue.Val07;
                            conditioncode.StrValue.Val08 = cs.m_StrValue.Val08;
                            conditioncode.StrValue.Val09 = cs.m_StrValue.Val09;
                            conditioncode.StrValue.Val10 = cs.m_StrValue.Val10;
                            conditioncode.StrValue.Val11 = cs.m_StrValue.Val11;
                            conditioncode.StrValue.Val12 = cs.m_StrValue.Val12;
                            conditioncode.StrValue.Val13 = cs.m_StrValue.Val13;
                            conditioncode.StrValue.Val14 = cs.m_StrValue.Val14;
                            conditioncode.StrValue.Val15 = cs.m_StrValue.Val15;
                            //for (int k = 0; k < cs.m_StrValue.Len; k++)
                            //{
                            //    conditioncode.Val[k] = cs.m_StrValue.Val[k];
                            //}
                        }
                        
                    }
                    else
                    {
                        conditioncode.Value.ULINT = cs.m_Value.ULINT;
                    }
                    StructFile sfConditionCode = new StructFile(typeof(ConditionCode));
                    sfConditionCode.WriteStructure(ref buffer, conditioncode);
                    cs.SimpleOperation.Write2Buffer(ref buffer);
                }
            }

            return buffer.ToArray();
        }

        bool CompileGraphicDispalyExpression(tblDisplay _tbldisplay, SimpleOperation simpleoperation, DisplayObjectParameters _Parameters)
        {
            Compiler compiler = new Compiler();
            CrossReference Lookup = ((TabDisplayPageControl)parentDrawGraphic.Parentpagelist.Parenttabgraphicpagecontrol).tbldisplay.crossreference;
            return compiler.CompileGraphicDispalyExpression(_tbldisplay, simpleoperation, _Parameters);
        } 
#endif

#if OWSAPP
        //VALUE m_val = new VALUE();
        public bool RunField(enumDynamicGraphicalProperty _prop, ref VALUE m_val)
        {
            foreach (DisplayObjectDynamicProperty displayobjectdynamicproperty in objDisplayObjectDynamicPropertys.list)
            {
                if (displayobjectdynamicproperty.ObjectType == _prop)
                {
                    foreach (DisplayObjectDynamicPropertyCondition cs in displayobjectdynamicproperty.ConditionList)
                    {
                        if (cs.SimpleOperation.RUNCondition().BOOL)
                        {
                            switch (displayobjectdynamicproperty.Type)
                            {
                                case VarType.BOOL:
                                    m_val.BOOL = cs.m_Value.BOOL;
                                    return true;
                                case VarType.INT:
                                    m_val.INT = cs.m_Value.INT;
                                    return true;
                                case VarType.DINT:
                                    if (displayobjectdynamicproperty.IsColor)
                                    {
                                        Color _color = Color.FromArgb(cs.m_Value.DINT);
                                        m_val.DINT = _color.ToArgb();
                                        return true;
                                    }
                                    else
                                    {
                                        m_val.DINT = cs.m_Value.DINT;
                                        return true;
                                    }
                                case VarType.REAL:
                                    m_val.REAL = cs.m_Value.REAL;
                                    return true;
                            }

                            break;
                        }

                    }
                    break;
                }

            }
            return false;
        }


        public bool RunField(enumDynamicGraphicalProperty _prop, ref STRINGOBJ m_strval)
        {
            foreach (DisplayObjectDynamicProperty displayobjectdynamicproperty in objDisplayObjectDynamicPropertys.list)
            {
                if (displayobjectdynamicproperty.ObjectType == _prop)
                {
                    foreach (DisplayObjectDynamicPropertyCondition cs in displayobjectdynamicproperty.ConditionList)
                    {
                        if (cs.SimpleOperation.RUNCondition().BOOL)
                        {
                            m_strval.Len = cs.m_StrValue.Len;
                            m_strval.Val00 = cs.m_StrValue.Val00;
                            m_strval.Val01 = cs.m_StrValue.Val01;
                            m_strval.Val02 = cs.m_StrValue.Val02;
                            m_strval.Val03 = cs.m_StrValue.Val03;
                            m_strval.Val04 = cs.m_StrValue.Val04;
                            m_strval.Val05 = cs.m_StrValue.Val05;
                            m_strval.Val06 = cs.m_StrValue.Val06;
                            m_strval.Val07 = cs.m_StrValue.Val07;
                            m_strval.Val08 = cs.m_StrValue.Val08;
                            m_strval.Val09 = cs.m_StrValue.Val09;
                            m_strval.Val10 = cs.m_StrValue.Val10;
                            m_strval.Val11 = cs.m_StrValue.Val11;
                            m_strval.Val12 = cs.m_StrValue.Val12;
                            m_strval.Val13 = cs.m_StrValue.Val13;
                            m_strval.Val14 = cs.m_StrValue.Val14;
                            m_strval.Val15 = cs.m_StrValue.Val15;

                            //unsafe
                            //{
                            //    for (int k = 0; k < 16; k++)
                            //    {
                            //        m_strval.Val[k] = cs.m_StrValue.Val[k];
                            //    }
                            //}

                            return true;
               
                        }

                    }
                    break;
                }

            }
            return false;
        }

        
#endif
    }
}
