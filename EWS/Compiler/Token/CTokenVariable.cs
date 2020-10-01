using DCS;
using DCS.DCSTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DCS.Compile.Token
{
    class CTokenVariable:CTokenOperand 
    {
        private VarType referencetype;
        public VarType ReferneceType
        {
            get
            {
                return referencetype;
            }
            set
            {
                referencetype = value;
            }
        }
        private tblFormalParameter _tblformalparameter;
        public tblFormalParameter tblformalparameter
        {
            get
            {
                return _tblformalparameter;
            }
            set
            {
                _tblformalparameter = value;
            }
        }

        

        private tblVariable _tblvariable;
        public tblVariable tblvariable
        {
            get
            {
                return _tblvariable;
            }
            set
            {
                _tblvariable = value;
            }
        }
        private byte hassubpropety;
        public byte HasSubPropety
        {
            get
            {
                return hassubpropety;
            }
            set
            {
                hassubpropety = value;
            }
        }

        private byte subproperty;
        public byte SubProperty
        {
            get
            {
                return subproperty;
            }
            set
            {
                subproperty = value;
            }
        }

        private long pouid;
        public long pouID
        {
            get
            {
                return pouid;
            }
            set
            {
                pouid = value;
            }
        }

        private long controllerid;
        public long controllerID
        {
            get
            {
                return controllerid;
            }
            set
            {
                controllerid = value;
            }
        }
        private long displayid;
        public long displayID
        {
            get
            {
                return displayid;
            }
            set
            {
                displayid = value;
            }
        }
        private long pinid;
        public long PinID
        {
            get
            {
                return pinid;
            }
            set
            {
                pinid = value;
            }
        }
        //private int	M_Index;
        //public int m_Index
        //{
        //    get
        //    {
        //        return M_Index;
        //    }
        //    set
        //    {
        //        M_Index = value;
        //    }
        //}
        //private byte M_NodeNo;
        //public byte m_NodeNo
        //{
        //    get
        //    {
        //        return M_NodeNo;
        //    }
        //    set
        //    {
        //        M_NodeNo = value;
        //    }
        //}
        //private String M_Property;
        //public string m_Property
        //{
        //    get
        //    {
        //        return M_Property;
        //    }
        //    set
        //    {
        //        M_Property = value;
        //    }
        //}
        //private int M_PropertyNo;
        //public int m_PropertyNo
        //{
        //    get
        //    {
        //        return M_PropertyNo;
        //    }
        //    set
        //    {
        //        M_PropertyNo = value;
        //    }
        //}
        //private VarType M_PropertyType;
        //public VarType m_PropertyType
        //{
        //    get
        //    {
        //        return M_PropertyType;
        //    }
        //    set
        //    {
        //        M_PropertyType = value;
        //    }
        //}
	    public OPERAND m_Operand;
        //public OPERAND m_Operand
        //{
        //    get
        //    {
        //        return M_Operand;
        //    }
        //    set
        //    {
        //        M_Operand = value;
        //    }
        //}
        //private string M_VarName;
        //public string  m_VarName
        //{
        //    get
        //    {
        //        return M_VarName;
        //    }
        //    set
        //    {
        //        M_VarName = value;
        //    }
        //} 
        public CTokenVariable()
        {
	        m_token =Token_Type. Token_Variable;
	        //m_Value = gcnew VarType();
            //m_PropertyType = VarType.UNKNOWN;
            _tblformalparameter = new tblFormalParameter();
            _tblvariable = new tblVariable();
         }

        public void Fill(tblVariable _tblvariable, tblFormalParameter _tblformalparameter)
        {
            tblvariable = _tblvariable;
            tblformalparameter = _tblformalparameter;
            //Operand.Index = _tblvariable.VarNameID;


        }
        public CTokenVariable(String _str) : base(_str)
         {
		     m_token =Token_Type. Token_Variable;
		    //m_Value = gcnew VarType();
		    //m_PropertyType =VarType.UNKNOWN;
            _tblformalparameter = new tblFormalParameter();
            _tblvariable = new tblVariable();
         }
       
        //public void Print()
        //{
        //    Console .WriteLine (m_str);
        //    Console .WriteLine(m_VarName);
        //    Console .WriteLine(m_Property);
        //    Console .WriteLine ();
        //}

        public OPERAND ReturnOperand()
        {
            //m_Operand.Token =Token_Type. Token_Variable;
            //m_Operand.PropertyNo =(char) m_PropertyNo;
            //m_Operand.Index =(uint) m_Index;
	        return m_Operand;
        }

        public override int GetTokenPinType()
        {
            if (IsReference)
            {
                return (int)ReferneceType;
            }
            else
            {
                if (HasSubPropety == 1)
                {
                    return (int)VarType.BOOL;
                }
                else
                {
                    return (int)tblformalparameter.Type;
                }
            }
        }
    }
}



