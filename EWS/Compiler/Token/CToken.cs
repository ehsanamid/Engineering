using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO ;
using DCS.DCSTables;
using DCS;

namespace DCS.Compile.Token
{
    class CToken
    {
        private bool isrefernce = false;
        public bool IsReference
        {
            get
            {
                return isrefernce;
            }
            set
            {
                isrefernce = value;
            }
        }
        //public OPERATOR Operator = new OPERATOR();
        //public OPERATOR Operator
        //{
        //    get
        //    {
        //        return _operator;
        //    }
        //    set
        //    {
        //        _operator = value;
        //    }
        //}

        //public OPERAND Operand = new OPERAND();
        
        private  string _str;
        public string m_str
        {
            get
            {
                return _str;
            }
            set
            {
                _str = value;
            }
        }
        private Token_Type mtoken;
        public Token_Type m_token
        {
            get
            {
                return mtoken;
            }
            set
            {
                mtoken = value;
            }
        }
        public CToken (string _str )

        {
            m_str = _str;
            m_token = Token_Type.Token_Unknown;
        }
        public CToken()
        {
            m_str = "";
            m_token = Token_Type.Token_Unknown;
        }

        
    //    public CToken oprator( CToken param)
    //{
    //    return this;
    //}

        protected OPERAND GetFinalOperator(CToken _token)
        {
            OPERAND tempoperand = new OPERAND();
            switch (_token.m_token)
            {
                case Token_Type.Token_Constant:
                    tempoperand.Index = ((CTokenOperand)_token).m_Index;
                    tempoperand.Token = (byte)((CTokenOperand)_token).m_token;
                    //tempoperand.type = ((CTokenOperand)_token).m_Type;
                    break;
                case Token_Type.Token_String:
                    tempoperand.Index = ((CTokenOperand)_token).m_Index;
                    tempoperand.Token = (byte)((CTokenOperand)_token).m_token;
                    //tempoperand.type = ((CTokenOperand)_token).m_Type;
                    break;
                case Token_Type.Token_Variable:
                    //_operand8[0].type = (VarType) ((CTokenVariable*)tok)->m_PropertyType ;
                    tempoperand.Token = (byte)_token.m_token;
                    //_operand8[0].Index = ((CTokenVariable*)tok)->m_Index;
                    tblFunction tblfunction = tblSolution.m_tblSolution().GetFunctionbyType(((CTokenVariable)_token).tblvariable.Type);
                    if (((CTokenVariable)_token).isrefernce)
                    {
                        tempoperand.Index = ((CTokenVariable)_token).tblvariable.VarNameID;
                        tempoperand.PropertyNo = 0;
                        tempoperand.HasSubPropety = 0;
                        tempoperand.SubProperty = 0;
                        tempoperand.IsReference = 1;
                    }
                    else
                    {
                        tempoperand.IsReference = 0;
                        if (Common.IsSimpleType(((CTokenVariable)_token).tblvariable.Type) ||
                            (tblfunction.IsStandard && !tblfunction.IsFunction))
                        {
                            tempoperand.Index = ((CTokenVariable)_token).tblvariable.VarNameID;
                            tempoperand.PropertyNo = (byte)((CTokenVariable)_token).tblformalparameter.oIndex;
                            tempoperand.HasSubPropety = ((CTokenVariable)_token).HasSubPropety;
                            tempoperand.SubProperty = ((CTokenVariable)_token).SubProperty;
                        }
                        else
                        {
                            foreach (tblVariable _linktblvariable in ((CTokenVariable)_token).tblvariable.m_tblFInstanceVariableList)
                            {
                                if (_linktblvariable.ParentVarLinkName == ((CTokenVariable)_token).tblformalparameter.PinName)
                                {
                                    tempoperand.Index = _linktblvariable.VarNameID;
                                    tempoperand.PropertyNo = 0;
                                    break;
                                }
                            }

                        }
                    }


                    break;
                case Token_Type.Token_TempString:
                case Token_Type.Token_TempValue:
                    tempoperand.Index = ((CTokenTempVariable)_token).m_Index;
                    tempoperand.Token = (byte)((CTokenTempVariable)_token).m_token;
                    tempoperand.type = ((CTokenTempVariable)_token).m_Type;
                    Compiler.FreeAssignedTempVar(tempoperand.type, (int)tempoperand.Index);
                    break;
                case Token_Type.Token_FBDPin:
                    tempoperand.Index = ((CTokenFBDPin)_token).tblvariable.VarNameID;
                    tempoperand.PinID = ((CTokenFBDPin)_token).PinID;
                    tempoperand.PropertyNo = (byte)((CTokenFBDPin)_token).tblformalparameterVariable.oIndex;
                    tempoperand.HasSubPropety = ((CTokenFBDPin)_token).HasSubPropety;
                    tempoperand.SubProperty = ((CTokenFBDPin)_token).SubProperty;
                    tempoperand.PinNo = (byte)((CTokenFBDPin)_token).tblformalparameterPin.oIndex;
                    tempoperand.Token = (byte)((CTokenOperand)_token).m_token;
                    break;
                default:
                    break;
            }
            return tempoperand;
        }

        protected int ReturnType(int v1, int v2)
        {
            if (Common.IsSimpleType(v1))
            {
                return v1;

            }
            else
            {
                return v2;

            }
        }

        protected int ReturnType(CToken t1, CToken t2)
        {
            return ReturnType(t1.GetTokenPinType(), t2.GetTokenPinType());
        }

        protected int ReturnType(List<CToken> t)
        {
            for (int i = 0; i < t.Count; i++)
            {
                if (Common.IsSimpleType(t[i].GetTokenPinType()))
                {
                    return t[i].GetTokenPinType();

                }
            }
            return 0;
        }

        public virtual void Print()

        {
            System.Console.WriteLine(m_str);
        }

        public virtual int GetTokenPinType()
        {
            return (int)VarType.UNKNOWN;
        }

        public virtual bool CheckArgumentValidity(ref List<TypeReference> _vartypelist, ref TypeReference retval, ref string _retsstring)
        {
            bool _NoError = true;

            return _NoError;
        }
        public virtual bool ReturnOperator(ref TICInstruction _instruction, List<CToken> operandlist)
        {

            return true;
        }
    }
}












