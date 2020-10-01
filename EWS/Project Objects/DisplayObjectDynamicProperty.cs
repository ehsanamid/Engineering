using DCS.Compile;
using DCS.Compile.Operation;
using DCS.Draw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DCS.Project_Objects
{

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class DisplayObjectDynamicPropertys
    {
        public List<DisplayObjectDynamicProperty> list = new List<DisplayObjectDynamicProperty>();
        public void Clear()
        {
            list.Clear();
        }
        public int Count
        {
            get
            {
                return list.Count;
            }
        }

        public void SetStringvalue2Value()
        {
            foreach (DisplayObjectDynamicProperty displayobjectdynamicproperty in list)
            {
                displayobjectdynamicproperty.SetStringvalue2Value();
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class DisplayObjectDynamicProperty
    {


        private enumDynamicGraphicalProperty objectTypeField;
        /// <remarks/>
        public enumDynamicGraphicalProperty ObjectType
        {
            get
            {
                return this.objectTypeField;
            }
            set
            {
                this.objectTypeField = value;
            }
        }
        
        private string returnTypeField;
        /// <remarks/>
        public string ReturnType
        {
            get
            {
                return this.returnTypeField;
            }
            set
            {
                this.returnTypeField = value;
            }
        }

        VarType type;
         [XmlIgnoreAttribute]
        public VarType Type
        {
            get
            {
                return type;
                //try
                //{
                //    if (IsColor)
                //    {
                //        type = VarType.UDINT;
                //    }
                //    else
                //    {
                //        type = (VarType)Enum.Parse(typeof(VarType), returnTypeField);
                //    }
                //    return type;
                //}
                //catch (Exception ex)
                //{

                //}
                //return VarType.UNKNOWN;
            }
            set
            {
                type = value;
            }
        }

        //public void SetType(VarType _type)
        //{
        //    type = _type;
        //}
        
        bool iscolor;
        [XmlIgnoreAttribute]
        public bool IsColor
        {
            get
            {
               
                return iscolor;
            }
            set
            {
                iscolor = value;
            }
        }
        
        bool isstring;
        [XmlIgnoreAttribute]
        public bool IsString
        {
            get
            {
#if EWSAPP
                if (returnTypeField.ToUpper() == "STRING")
                {
                    isstring = true;
                }
                else
                {
                    isstring = false;
                }
#endif
                return isstring;
            }
            set
            {
                isstring = value;
            }
        }
        public List<DisplayObjectDynamicPropertyCondition> ConditionList = new List<DisplayObjectDynamicPropertyCondition>();
        
        
        public int NoOfConditions
        {
            get
            {
                return ConditionList.Count;
            }
        }

        public void SetStringvalue2Value()
        {
            foreach (DisplayObjectDynamicPropertyCondition condition in ConditionList)
            {
                condition.SetValue(ReturnType, IsString);
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class DisplayObjectDynamicPropertyCondition
    {

        private string ifField;
        /// <remarks/>
        public string If
        {
            get
            {
                return this.ifField;
            }
            set
            {
                this.ifField = value;
                simpleoperation.OperationString = value;
            }
        }
        
        private string thenField;
        /// <remarks/>
        public string Then
        {
            get
            {
                return this.thenField;
            }
            set
            {
                this.thenField = value;
               
            }
        }
        
        public void  SetValue(string _type,bool _isstring)
        {
            if (_isstring)
            {
                Assingment2StringValue();
            }
            else
            {
                Assingment2Value(_type);
            }
        }
        VALUE m_value = new VALUE();
         [XmlIgnoreAttribute]
        public VALUE m_Value
        {
            get
            {
                return m_value;
            }
            set
            {
                m_value = value;
            }
        }

         STRINGOBJ m_strvalue = new STRINGOBJ();
         [XmlIgnoreAttribute]
        public STRINGOBJ m_StrValue
        {
            get
            {
                return m_strvalue;
            }
            set
            {
                m_StrValue = value;
            }
        }
        private byte indexField;
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte Index
        {
            get
            {
                return this.indexField;
            }
            set
            {
                this.indexField = value;
            }
        }

        
        //public string condition;



        SimpleOperation simpleoperation = new SimpleOperation();
         [XmlIgnoreAttribute]
        public SimpleOperation SimpleOperation
        {
            get
            {
                return simpleoperation;
            }
            set
            {
                simpleoperation = value;
            }
        }

        public bool IsValid;
        public DisplayObjectDynamicPropertyCondition()
        {
            IsValid = false;
        }

        private void Assingment2Value(string typestr)
        {
            ValueObj _valueobj = new ValueObj();

            if ((typestr.ToUpper() == "BOOL") && Common.IsValueBOOL(thenField, ref  _valueobj))
            {
                m_value.BOOL = _valueobj.Val.BOOL;
                return;
            }
            if ((typestr.ToUpper() == "BYTE") && Common.IsValueBYTE(thenField, ref  _valueobj))
            {
                m_value.BYTE = _valueobj.Val.BYTE;
                return;
            }
            if ((typestr.ToUpper() == "WORD") && Common.IsValueWORD(thenField, ref  _valueobj))
            {
                m_value.WORD = _valueobj.Val.WORD;
                return;
            }
            if ((typestr.ToUpper() == "DWORD") && Common.IsValueDWORD(thenField, ref  _valueobj))
            {
                m_value.DWORD = _valueobj.Val.DWORD;
                return;
            }
            if ((typestr.ToUpper() == "LWORD") && Common.IsValueLWORD(thenField, ref  _valueobj))
            {
                m_value.LWORD = _valueobj.Val.LWORD;
                return;
            }
            if ((typestr.ToUpper() == "SINT") && Common.IsValueSINT(thenField, ref  _valueobj))
            {
                m_value.SINT = _valueobj.Val.SINT;
                return;
            }
            if ((typestr.ToUpper() == "INT") && Common.IsValueINT(thenField, ref  _valueobj))
            {
                m_value.INT = _valueobj.Val.INT;
                return;
            }
            if ((typestr.ToUpper() == "DINT") && Common.IsValueDINT(thenField, ref  _valueobj))
            {
                m_value.DINT = _valueobj.Val.DINT;
                return;
            }
            if ((typestr.ToUpper() == "LINT") && Common.IsValueLINT(thenField, ref  _valueobj))
            {
                m_value.LINT = _valueobj.Val.LINT;
                return;
            }
            if ((typestr.ToUpper() == "USINT") && Common.IsValueUSINT(Then, ref  _valueobj))
            {
                m_value.USINT = _valueobj.Val.USINT;
                return;
            }
            if ((typestr.ToUpper() == "UINT") && Common.IsValueUINT(thenField, ref  _valueobj))
            {
                m_value.UINT = _valueobj.Val.UINT;
                return;
            }
            if ((typestr.ToUpper() == "UDINT") && Common.IsValueUDINT(thenField, ref  _valueobj))
            {
                m_value.UDINT = _valueobj.Val.UDINT;
                return;
            }
            if ((typestr.ToUpper() == "ULINT") && Common.IsValueULINT(thenField, ref  _valueobj))
            {
                m_value.ULINT = _valueobj.Val.ULINT;
                return;
            }
            if ((typestr.ToUpper() == "REAL") && Common.IsValueREAL(thenField, ref  _valueobj))
            {
                m_value.REAL = _valueobj.Val.REAL;
                return;
            }
            if ((typestr.ToUpper() == "LREAL") && Common.IsValueLREAL(thenField, ref  _valueobj))
            {
                m_value.LREAL = _valueobj.Val.LREAL;
                return;
            }
            if ((typestr.ToUpper() == "COLOR") && Common.IsValueColor(thenField, ref  _valueobj))
            {
                m_value.DINT = _valueobj.Val.DINT;
                return;
            }
            if ((typestr.ToUpper() == "TIME") && Common.IsValueTIME(thenField, ref  _valueobj))
            {
                m_value.TIME = _valueobj.Val.TIME;
                return;
            }
            if ((typestr.ToUpper() == "DATE") && Common.IsValueDATE(thenField, ref  _valueobj))
            {
                m_value.DATE = _valueobj.Val.DATE;
                return;
            }
            if ((typestr.ToUpper() == "TOD") && Common.IsValueTOD(thenField, ref  _valueobj))
            {
                m_value.TOD = _valueobj.Val.TOD;
                return;
            }
            if ((typestr.ToUpper() == "DT") && Common.IsValueDT(thenField, ref  _valueobj))
            {
                m_value.DT = _valueobj.Val.DT;
                return;
            }
        }

        private void Assingment2StringValue()
        {
            byte[] Val = new byte[Common.MAX_STRING_SIZE];
            Val = Encoding.ASCII.GetBytes(thenField);
            m_strvalue.Len = thenField.Length;
            try
            {
                m_strvalue.Val00 = Val[0];
                m_strvalue.Val01 = Val[1];
                m_strvalue.Val02 = Val[2];
                m_strvalue.Val03 = Val[3];
                m_strvalue.Val04 = Val[4];
                m_strvalue.Val05 = Val[5];
                m_strvalue.Val06 = Val[6];
                m_strvalue.Val07 = Val[7];
                m_strvalue.Val08 = Val[8];
                m_strvalue.Val09 = Val[9];
                m_strvalue.Val10 = Val[10];
                m_strvalue.Val11 = Val[11];
                m_strvalue.Val12 = Val[12];
                m_strvalue.Val13 = Val[13];
                m_strvalue.Val14 = Val[14];
                m_strvalue.Val15 = Val[15];
            }
            catch (Exception ex)
            {

            }
          
        }

        public void ToCopySTRINGOBJ(STRINGOBJ tocopy)
        {
            m_strvalue.Len = tocopy.Len;
            m_strvalue.Val00 = tocopy.Val00;
            m_strvalue.Val01 = tocopy.Val01;
            m_strvalue.Val02 = tocopy.Val02;
            m_strvalue.Val03 = tocopy.Val03;
            m_strvalue.Val04 = tocopy.Val04;
            m_strvalue.Val05 = tocopy.Val05;
            m_strvalue.Val06 = tocopy.Val06;
            m_strvalue.Val07 = tocopy.Val07;
            m_strvalue.Val08 = tocopy.Val08;
            m_strvalue.Val09 = tocopy.Val09;
            m_strvalue.Val10 = tocopy.Val10;
            m_strvalue.Val11 = tocopy.Val11;
            m_strvalue.Val12 = tocopy.Val12;
            m_strvalue.Val13 = tocopy.Val13;
            m_strvalue.Val14 = tocopy.Val14;
            m_strvalue.Val15 = tocopy.Val15;
        }
    }


}
