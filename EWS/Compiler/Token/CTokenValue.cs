using DCS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DCS.Compile.Token
{
    class CTokenValue : CToken
    {
        private OPERAND _operand;
        public OPERAND m_Operand
        {
            get
            {
                return _operand;
            }
            set
            {
                _operand = value;
            }
        }
        private VALUE _value;
        public VALUE m_Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }

        private VarType _vartype;
        public VarType m_VarType
        {
            get
            {
                return _vartype;
            }
            set
            {
                _vartype = value;
            }
        }

        public CTokenValue()
        {
            m_token = Token_Type.Token_Constant;
            //m_Value = gcnew VarType();

        }
        public CTokenValue(String _str)
            : base(_str)
        {
            m_token = Token_Type.Token_Constant;
            //m_Value = gcnew VarType();
        }
        
        //public void Print()
        //{
        //    CToken c = new CToken();
        //    c.Print();
        //}

        //public OPERAND ReturnOperand()
        //{
        //    return null;// OPERAND();
        //}
        


        public void SetType(VarType _vartype)
        {
            m_VarType = _vartype;
        }
        //public override int GetTokenPinType()
        //{
        //    return (int)m_VarType;
        //}
    }
}


//**************************************
