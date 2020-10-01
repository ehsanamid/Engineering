using DCS;
using DCS.DCSTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DCS.Compile.Token
{
    class CTokenOperator : CToken
    {
        private int M_op_preced;
        private bool M_op_left_assoc;
        private int noofoperands;
        //public OPERATOR m_operator;
        public int m_op_preced
        {
            get
            {
                return M_op_preced;
            }
            set
            {
                M_op_preced = value;
            }
        }
        public bool m_op_left_assoc
        {
            get
            {
                return M_op_left_assoc;
            }
            set
            {
                M_op_left_assoc = value;
            }
        }
        public int NoOfOperands
        {
            get
            {
                return noofoperands;
            }
            set
            {
                noofoperands = value;
            }
        }
        //public  OPERATOR m_operator
        //  {
        //      get
        //      {
        //          return M_operator;
        //      }
        //      set
        //      {
        //          M_operator = value;
        //      }
        //  }

        public CTokenOperator()
        {
            m_token = Token_Type.Token_Operator;
        }
        public CTokenOperator(String _str)
            : base(_str)
        {
            m_token = Token_Type.Token_Operator;
        }


        //  virtual void Print()
        //{
        //    Console.WriteLine ("No of arguments : {0}", m_op_arg_count);
        //    Console.WriteLine (" op_preced : {0}", m_op_preced);
        //    Console.WriteLine ("op_left_assoc : {0}", m_op_left_assoc);
        //CToken c=new CToken ();
        //    c.Print ();

        //}

        //---------------------------
        public override bool CheckArgumentValidity(ref List<TypeReference> _vartypelist, ref TypeReference retval, ref string _retsstring)
        {
            int ret = 0;
            try
            {
                if ((m_str == "*") || (m_str == "/"))
                {
                    if ((ret = Common.IsSamePatern(_vartypelist[0].type, _vartypelist[1].type, (int)VarType.ANY_NUM)) != 0)
                    {
                        retval.type = ret;
                        return true;
                    }
                    else
                    {
                        //CParser::SendOutput(_T("Operators do not have same type ") + m_str);	
                        //_retsstring = "Operators do not have same type " + m_str;	
                    }
                }
                if ((m_str == "+") || (m_str == "-"))
                {
                    if ((ret = Common.IsSamePatern(_vartypelist[0].type, _vartypelist[1].type, (int)VarType.ANY_MAGNITUDE)) != 0)
                    {
                        retval.type = ret;
                        return true;
                    }
                    else
                    {
                        if (((_vartypelist[0].type & (int)VarType.ANY_DATE) != 0) && (_vartypelist[1].type == (int)VarType.TIME))
                        {
                            //CParser::SendOutput(_T("Operators do not have same type ")+m_str+_T(" has wrong argument type"));
                            //_retsstring = "Operators do not have same type " + m_str + " has wrong argument type";
                            //Homay-01/26/2014
                            //throw new  CompilerRunTimeEx("Operators do not have same type " + m_str + " has wrong argument type");
                        }
                        else
                        {
                            //CParser::SendOutput(_T("Operators do not have same type ") + m_str);	
                            //_retsstring = "Operators do not have same type " + m_str;	
                        }
                    }
                }
                if ((m_str == "and") || (m_str == "or") || (m_str == "xor"))
                {
                    if ((ret = Common.IsSamePatern(_vartypelist[0].type, _vartypelist[1].type, (int)VarType.ANY_BIT)) != 0)
                    {
                        retval.type = ret;
                        return true;
                    }
                    else
                    {
                        //CParser::SendOutput(_T("Operators do not have same type ") + m_str);	
                        //_retsstring = "Operators do not have same type " + m_str;	
                    }

                }
                if ((m_str == "<") || (m_str == ">") || (m_str == "<=") || (m_str == ">=") || (m_str == "=") || (m_str == "<>"))
                {
                    if ((ret = Common.IsSamePatern(_vartypelist[0].type, _vartypelist[1].type, (int)VarType.ANY_ELEMENTARY)) != 0)
                    {
                        retval.type = (int)VarType.BOOL;
                        return true;
                    }
                    else
                    {
                        //CParser::SendOutput(_T("Operators do not have same type ") + m_str);	
                        //_retsstring = "Operators do not have same type " + m_str;	
                    }
                }
                if ((m_str == ":="))
                {
                    if ((ret = Common.IsSamePatern(_vartypelist[0].type, _vartypelist[1].type, (int)VarType.ANY_BIT)) != 0)
                    {
                        retval.type = ret;
                        return true;
                    }
                    else
                    {
                        if ((ret = Common.IsSamePatern(_vartypelist[0].type, _vartypelist[1].type, (int)VarType.ANY_REAL)) != 0)
                        {
                            retval.type = ret;
                            return true;
                        }
                        else
                        {
                            if ((ret = Common.IsSamePatern(_vartypelist[0].type, _vartypelist[1].type, (int)VarType.ANY_INT)) != 0)
                            {
                                retval.type = ret;
                                return true;
                            }
                            else
                            {
                                if ((ret = Common.IsSamePatern(_vartypelist[0].type, _vartypelist[1].type, (int)VarType.ANY_DATE)) != 0)
                                {
                                    retval.type = ret;
                                    return true;
                                }
                                else
                                {
                                    if ((ret = Common.IsSamePatern(_vartypelist[0].type, _vartypelist[1].type, (int)VarType.TIME)) != 0)
                                    {
                                        retval.type = ret;
                                        return true;
                                    }
                                    else
                                    {
                                        //CParser::SendOutput(_T("Operators do not have same type ") + m_str);	
                                        //_retsstring = "Operators do not have same type " + m_str;	
                                    }
                                }
                            }
                        }
                    }

                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }

        /*
        _SINT_MUL_SINT_SINT____
        _INT_MUL_INT_INT____
        _DINT_MUL_DINT_DINT____
        _USINT_MUL_USINT_USINT____
        _UINT_MUL_UINT_UINT____
        _UDINT_MUL_UDINT_UDINT____
        _REAL_MUL_REAL_REAL____
        _TIME_MUL_TIME_SINT____
        _TIME_MUL_TIME_INT____
        _TIME_MUL_TIME_DINT____
        _TIME_MUL_TIME_USINT____
        _TIME_MUL_TIME_UINT____
        _TIME_MUL_TIME_UDINT____
        _TIME_MUL_TIME_REAL____

        */

        //__________


        public override bool ReturnOperator(ref TICInstruction _instruction, List<CToken> tokenlist)
        {
            OPERAND op;
            switch (m_str)
            {
                case ":=":
                    _instruction.Operator.ReturnType = ReturnType(tokenlist[0], tokenlist[1]);
                    _instruction.OperandList.Add(GetFinalOperator(tokenlist[0]));
                    _instruction.OperandList.Add(GetFinalOperator(tokenlist[1]));
                    switch ((VarType)_instruction.Operator.ReturnType)
                    {
                        case VarType.BOOL:
                            _instruction.Operator.OpCode = (int)OPCODES.BOOL_TO_BOOL;
                            _instruction.Operator.NoOfArg = (byte)2;
                            break;
                        case VarType.BYTE:
                            _instruction.Operator.OpCode = (int)OPCODES.BYTE_TO_BYTE;
                            _instruction.Operator.NoOfArg = (byte)2;
                            break;
                        case VarType.WORD:
                            _instruction.Operator.OpCode = (int)OPCODES.WORD_TO_WORD;
                            _instruction.Operator.NoOfArg = (byte)2;
                            break;
                        case VarType.DWORD:
                            _instruction.Operator.OpCode = (int)OPCODES.DWORD_TO_DWORD;
                            _instruction.Operator.NoOfArg = (byte)2;
                            break;
                        case VarType.SINT:
                            _instruction.Operator.OpCode = (int)OPCODES.SINT_TO_SINT;
                            _instruction.Operator.NoOfArg = (byte)2;
                            break;
                        case VarType.INT:
                            _instruction.Operator.OpCode = (int)OPCODES.INT_TO_INT;
                            _instruction.Operator.NoOfArg = (byte)2;
                            break;
                        case VarType.DINT:
                            _instruction.Operator.OpCode = (int)OPCODES.DINT_TO_DINT;
                            _instruction.Operator.NoOfArg = (byte)2;
                            break;
                        case VarType.USINT:
                            _instruction.Operator.OpCode = (int)OPCODES.USINT_TO_USINT;
                            _instruction.Operator.NoOfArg = (byte)2;
                            break;
                        case VarType.UINT:
                            _instruction.Operator.OpCode = (int)OPCODES.UINT_TO_UINT;
                            _instruction.Operator.NoOfArg = (byte)2;
                            break;
                        case VarType.UDINT:
                            _instruction.Operator.OpCode = (int)OPCODES.UDINT_TO_UDINT;
                            _instruction.Operator.NoOfArg = (byte)2;
                            break;
                        case VarType.REAL:
                            _instruction.Operator.OpCode = (int)OPCODES.REAL_TO_REAL;
                            _instruction.Operator.NoOfArg = (byte)2;
                            break;
                        case VarType.TIME:
                            _instruction.Operator.OpCode = (int)OPCODES.TIME_TO_TIME;
                            _instruction.Operator.NoOfArg = (byte)2;
                            break;
                    }
                    //return _instruction.Operator;

                    break;
                case "*":


                    _instruction.Operator.ReturnType = ReturnType(tokenlist[0], tokenlist[1]);
                    op = new OPERAND();
                    op.Token = (byte)Token_Type.Token_TempValue;
                    op.type = _instruction.Operator.ReturnType;
                    op.Index = Compiler.GetUnassignedTempVar(op.type);
                    _instruction.OperandList.Add(op);
                    _instruction.OperandList.Add(GetFinalOperator(tokenlist[0]));
                    _instruction.OperandList.Add(GetFinalOperator(tokenlist[1]));

                    //switch ((VarType)_instruction.Operator.ReturnType)
                    switch ((VarType)tokenlist[0].GetTokenPinType())
                    {
                        case VarType.SINT:
                            _instruction.Operator.OpCode = (int)OPCODES.SINT_MUL_SINT_SINT;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.INT:
                            _instruction.Operator.OpCode = (int)OPCODES.INT_MUL_INT_INT;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.DINT:
                            _instruction.Operator.OpCode = (int)OPCODES.DINT_MUL_DINT_DINT;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.USINT:
                            _instruction.Operator.OpCode = (int)OPCODES.USINT_MUL_USINT_USINT;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.UINT:
                            _instruction.Operator.OpCode = (int)OPCODES.UINT_MUL_UINT_UINT;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.UDINT:
                            _instruction.Operator.OpCode = (int)OPCODES.UDINT_MUL_UDINT_UDINT;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.REAL:
                            _instruction.Operator.OpCode = (int)OPCODES.REAL_MUL_REAL_REAL;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.TIME:    // must be check and complete
                            switch ((VarType)tokenlist[1].GetTokenPinType())
                            {
                                case VarType.SINT:
                                    _instruction.Operator.OpCode = (int)OPCODES.TIME_MUL_TIME_SINT;
                                    _instruction.Operator.NoOfArg = (byte)3;
                                    break;
                                case VarType.INT:
                                    _instruction.Operator.OpCode = (int)OPCODES.TIME_MUL_TIME_INT;
                                    _instruction.Operator.NoOfArg = (byte)3;
                                    break;
                                case VarType.DINT:
                                    _instruction.Operator.OpCode = (int)OPCODES.TIME_MUL_TIME_DINT;
                                    _instruction.Operator.NoOfArg = (byte)3;
                                    break;
                                case VarType.USINT:
                                    _instruction.Operator.OpCode = (int)OPCODES.TIME_MUL_TIME_USINT;
                                    _instruction.Operator.NoOfArg = (byte)3;
                                    break;
                                case VarType.UINT:
                                    _instruction.Operator.OpCode = (int)OPCODES.TIME_MUL_TIME_UINT;
                                    _instruction.Operator.NoOfArg = (byte)3;
                                    break;
                                case VarType.UDINT:
                                    _instruction.Operator.OpCode = (int)OPCODES.TIME_MUL_TIME_UDINT;
                                    _instruction.Operator.NoOfArg = (byte)3;
                                    break;
                                case VarType.REAL:
                                    _instruction.Operator.OpCode = (int)OPCODES.TIME_MUL_TIME_REAL;
                                    _instruction.Operator.NoOfArg = (byte)3;
                                    break;
                            }
                            break;
                    }
                    break;


                case "/":

                    _instruction.Operator.ReturnType = ReturnType(tokenlist[0], tokenlist[1]);
                    op = new OPERAND();
                    op.Token = (byte)Token_Type.Token_TempValue;
                    op.type = _instruction.Operator.ReturnType;
                    op.Index = Compiler.GetUnassignedTempVar(op.type);
                    _instruction.OperandList.Add(op);
                    _instruction.OperandList.Add(GetFinalOperator(tokenlist[0]));
                    _instruction.OperandList.Add(GetFinalOperator(tokenlist[1]));

                    switch ((VarType)tokenlist[0].GetTokenPinType())
                    {
                        case VarType.SINT:
                            _instruction.Operator.OpCode = (int)OPCODES.SINT_DIV_SINT_SINT;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.INT:
                            _instruction.Operator.OpCode = (int)OPCODES.INT_DIV_INT_INT;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.DINT:
                            _instruction.Operator.OpCode = (int)OPCODES.DINT_DIV_DINT_DINT;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.USINT:
                            _instruction.Operator.OpCode = (int)OPCODES.USINT_DIV_USINT_USINT;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.UINT:
                            _instruction.Operator.OpCode = (int)OPCODES.UINT_DIV_UINT_UINT;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.UDINT:
                            _instruction.Operator.OpCode = (int)OPCODES.UDINT_DIV_UDINT_UDINT;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.REAL:
                            _instruction.Operator.OpCode = (int)OPCODES.REAL_DIV_REAL_REAL;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.TIME:
                            switch ((VarType)tokenlist[1].GetTokenPinType())
                            {
                                case VarType.SINT:
                                    _instruction.Operator.OpCode = (int)OPCODES.TIME_DIV_TIME_SINT;
                                    _instruction.Operator.NoOfArg = (byte)3;
                                    break;
                                case VarType.INT:
                                    _instruction.Operator.OpCode = (int)OPCODES.TIME_DIV_TIME_INT;
                                    _instruction.Operator.NoOfArg = (byte)3;
                                    break;
                                case VarType.DINT:
                                    _instruction.Operator.OpCode = (int)OPCODES.TIME_DIV_TIME_DINT;
                                    _instruction.Operator.NoOfArg = (byte)3;
                                    break;
                                case VarType.USINT:
                                    _instruction.Operator.OpCode = (int)OPCODES.TIME_DIV_TIME_USINT;
                                    _instruction.Operator.NoOfArg = (byte)3;
                                    break;
                                case VarType.UINT:
                                    _instruction.Operator.OpCode = (int)OPCODES.TIME_DIV_TIME_UINT;
                                    _instruction.Operator.NoOfArg = (byte)3;
                                    break;
                                case VarType.UDINT:
                                    _instruction.Operator.OpCode = (int)OPCODES.TIME_DIV_TIME_UDINT;
                                    _instruction.Operator.NoOfArg = (byte)3;
                                    break;
                                case VarType.REAL:
                                    _instruction.Operator.OpCode = (int)OPCODES.TIME_DIV_TIME_REAL;
                                    _instruction.Operator.NoOfArg = (byte)3;
                                    break;
                            }
                            break;
                    }
                    //return _instruction.Operator;
                    break;
                case "+":

                    _instruction.Operator.ReturnType = ReturnType(tokenlist[0], tokenlist[1]);
                    op = new OPERAND();
                    op.Token = (byte)Token_Type.Token_TempValue;
                    op.type = _instruction.Operator.ReturnType;
                    op.Index = Compiler.GetUnassignedTempVar(op.type);
                    _instruction.OperandList.Add(op);
                    _instruction.OperandList.Add(GetFinalOperator(tokenlist[0]));
                    _instruction.OperandList.Add(GetFinalOperator(tokenlist[1]));

                    switch ((VarType)tokenlist[0].GetTokenPinType())
                    {
                        case VarType.SINT:
                            _instruction.Operator.OpCode = (int)OPCODES.SINT_ADD_SINT_SINT;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.INT:
                            _instruction.Operator.OpCode = (int)OPCODES.INT_ADD_INT_INT;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.DINT:
                            _instruction.Operator.OpCode = (int)OPCODES.DINT_ADD_DINT_DINT;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.USINT:
                            _instruction.Operator.OpCode = (int)OPCODES.USINT_ADD_USINT_USINT;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.UINT:
                            _instruction.Operator.OpCode = (int)OPCODES.UINT_ADD_UINT_UINT;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.UDINT:
                            _instruction.Operator.OpCode = (int)OPCODES.UDINT_ADD_UDINT_UDINT;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.REAL:
                            _instruction.Operator.OpCode = (int)OPCODES.REAL_ADD_REAL_REAL;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.TIME:
                            _instruction.Operator.OpCode = (int)OPCODES.TIME_ADD_TIME_TIME;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                    }
                    //return _instruction.Operator;
                    break;
                case "-":

                    _instruction.Operator.ReturnType = ReturnType(tokenlist[0], tokenlist[1]);
                    op = new OPERAND();
                    op.Token = (byte)Token_Type.Token_TempValue;
                    op.type = _instruction.Operator.ReturnType;
                    op.Index = Compiler.GetUnassignedTempVar(op.type);
                    _instruction.OperandList.Add(op);
                    _instruction.OperandList.Add(GetFinalOperator(tokenlist[0]));
                    _instruction.OperandList.Add(GetFinalOperator(tokenlist[1]));

                    switch ((VarType)tokenlist[0].GetTokenPinType())
                    {
                        case VarType.SINT:
                            _instruction.Operator.OpCode = (int)OPCODES.SINT_SUB_SINT_SINT;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.INT:
                            _instruction.Operator.OpCode = (int)OPCODES.INT_SUB_INT_INT;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.DINT:
                            _instruction.Operator.OpCode = (int)OPCODES.DINT_SUB_DINT_DINT;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.USINT:
                            _instruction.Operator.OpCode = (int)OPCODES.USINT_SUB_USINT_USINT;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.UINT:
                            _instruction.Operator.OpCode = (int)OPCODES.UINT_SUB_UINT_UINT;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.UDINT:
                            _instruction.Operator.OpCode = (int)OPCODES.UDINT_SUB_UDINT_UDINT;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.REAL:
                            _instruction.Operator.OpCode = (int)OPCODES.REAL_SUB_REAL_REAL;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.TIME:
                            _instruction.Operator.OpCode = (int)OPCODES.TIME_SUB_TIME_TIME;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                    }
                    //return _instruction.Operator;
                    break;

                case "and":

                    _instruction.Operator.ReturnType = ReturnType(tokenlist[0], tokenlist[1]);
                    op = new OPERAND();
                    op.Token = (byte)Token_Type.Token_TempValue;
                    op.type = _instruction.Operator.ReturnType;
                    op.Index = Compiler.GetUnassignedTempVar(op.type);
                    _instruction.OperandList.Add(op);
                    _instruction.OperandList.Add(GetFinalOperator(tokenlist[0]));
                    _instruction.OperandList.Add(GetFinalOperator(tokenlist[1]));

                    switch ((VarType)tokenlist[0].GetTokenPinType())
                    {
                        case VarType.BOOL:
                            _instruction.Operator.OpCode = (int)OPCODES.BOOL_AND_BOOL_BOOL;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.BYTE:
                            _instruction.Operator.OpCode = (int)OPCODES.BYTE_AND_BYTE_BYTE;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.WORD:
                            _instruction.Operator.OpCode = (int)OPCODES.WORD_AND_WORD_WORD;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.DWORD:
                            _instruction.Operator.OpCode = (int)OPCODES.DWORD_AND_DWORD_DWORD;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                    }
                    //return _instruction.Operator;
                    break;
                case "or":

                    _instruction.Operator.ReturnType = ReturnType(tokenlist[0], tokenlist[1]);
                    op = new OPERAND();
                    op.Token = (byte)Token_Type.Token_TempValue;
                    op.type = _instruction.Operator.ReturnType;
                    op.Index = Compiler.GetUnassignedTempVar(op.type);
                    _instruction.OperandList.Add(op);
                    _instruction.OperandList.Add(GetFinalOperator(tokenlist[0]));
                    _instruction.OperandList.Add(GetFinalOperator(tokenlist[1]));

                    switch ((VarType)tokenlist[0].GetTokenPinType())
                    {
                        case VarType.BOOL:
                            _instruction.Operator.OpCode = (int)OPCODES.BOOL_OR_BOOL_BOOL;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.BYTE:
                            _instruction.Operator.OpCode = (int)OPCODES.BYTE_OR_BYTE_BYTE;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.WORD:
                            _instruction.Operator.OpCode = (int)OPCODES.WORD_OR_WORD_WORD;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.DWORD:
                            _instruction.Operator.OpCode = (int)OPCODES.DWORD_OR_DWORD_DWORD;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                    }
                    //return _instruction.Operator;
                    break;
                case "xor":

                    _instruction.Operator.ReturnType = ReturnType(tokenlist[0], tokenlist[1]);
                    op = new OPERAND();
                    op.Token = (byte)Token_Type.Token_TempValue;
                    op.type = _instruction.Operator.ReturnType;
                    op.Index = Compiler.GetUnassignedTempVar(op.type);
                    _instruction.OperandList.Add(op);
                    _instruction.OperandList.Add(GetFinalOperator(tokenlist[0]));
                    _instruction.OperandList.Add(GetFinalOperator(tokenlist[1]));

                    switch ((VarType)tokenlist[0].GetTokenPinType())
                    {
                        case VarType.BOOL:
                            _instruction.Operator.OpCode = (int)OPCODES.BOOL_XOR_BOOL_BOOL;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.BYTE:
                            _instruction.Operator.OpCode = (int)OPCODES.BYTE_XOR_BYTE_BYTE;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.WORD:
                            _instruction.Operator.OpCode = (int)OPCODES.WORD_XOR_WORD_WORD;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.DWORD:
                            _instruction.Operator.OpCode = (int)OPCODES.DWORD_XOR_DWORD_DWORD;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                    }
                    //return _instruction.Operator;
                    break;
                case "<=":

                    _instruction.Operator.ReturnType = (int)VarType.BOOL;

                    op = new OPERAND();
                    op.Token = (byte)Token_Type.Token_TempValue;
                    op.type = _instruction.Operator.ReturnType;
                    op.Index = Compiler.GetUnassignedTempVar(op.type);
                    _instruction.OperandList.Add(op);
                    _instruction.OperandList.Add(GetFinalOperator(tokenlist[0]));
                    _instruction.OperandList.Add(GetFinalOperator(tokenlist[1]));
                    switch ((VarType)ReturnType(tokenlist ))
                    {
                        case VarType.BYTE:
                            _instruction.Operator.OpCode = (int)OPCODES.BOOL_LE_BYTE_BYTE;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.WORD:
                            _instruction.Operator.OpCode = (int)OPCODES.BOOL_LE_WORD_WORD;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.DWORD:
                            _instruction.Operator.OpCode = (int)OPCODES.BOOL_LE_DWORD_DWORD;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.SINT:
                            _instruction.Operator.OpCode = (int)OPCODES.BOOL_LE_SINT_SINT;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.INT:
                            _instruction.Operator.OpCode = (int)OPCODES.BOOL_LE_INT_INT;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.DINT:
                            _instruction.Operator.OpCode = (int)OPCODES.BOOL_LE_DINT_DINT;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.USINT:
                            _instruction.Operator.OpCode = (int)OPCODES.BOOL_LE_USINT_USINT;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.UINT:
                            _instruction.Operator.OpCode = (int)OPCODES.BOOL_LE_UINT_UINT;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.UDINT:
                            _instruction.Operator.OpCode = (int)OPCODES.BOOL_LE_UDINT_UDINT;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.REAL:
                            _instruction.Operator.OpCode = (int)OPCODES.BOOL_LE_REAL_REAL;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.TIME:
                            _instruction.Operator.OpCode = (int)OPCODES.BOOL_LE_TIME_TIME;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                    }
                    //return _instruction.Operator;
                    break;
                case "<":

                    _instruction.Operator.ReturnType = (int)VarType.BOOL;

                    op = new OPERAND();
                    op.Token = (byte)Token_Type.Token_TempValue;
                    op.type = _instruction.Operator.ReturnType;
                    op.Index = Compiler.GetUnassignedTempVar(op.type);
                    _instruction.OperandList.Add(op);
                    _instruction.OperandList.Add(GetFinalOperator(tokenlist[0]));
                    _instruction.OperandList.Add(GetFinalOperator(tokenlist[1]));

                    switch ((VarType)tokenlist[0].GetTokenPinType())
                    {
                        case VarType.BYTE:
                            _instruction.Operator.OpCode = (int)OPCODES.BOOL_LT_BYTE_BYTE;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.WORD:
                            _instruction.Operator.OpCode = (int)OPCODES.BOOL_LT_WORD_WORD;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.DWORD:
                            _instruction.Operator.OpCode = (int)OPCODES.BOOL_LT_DWORD_DWORD;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.SINT:
                            _instruction.Operator.OpCode = (int)OPCODES.BOOL_LT_SINT_SINT;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.INT:
                            _instruction.Operator.OpCode = (int)OPCODES.BOOL_LT_INT_INT;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.DINT:
                            _instruction.Operator.OpCode = (int)OPCODES.BOOL_LT_DINT_DINT;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.USINT:
                            _instruction.Operator.OpCode = (int)OPCODES.BOOL_LT_USINT_USINT;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.UINT:
                            _instruction.Operator.OpCode = (int)OPCODES.BOOL_LT_UINT_UINT;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.UDINT:
                            _instruction.Operator.OpCode = (int)OPCODES.BOOL_LT_UDINT_UDINT;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.REAL:
                            _instruction.Operator.OpCode = (int)OPCODES.BOOL_LT_REAL_REAL;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.TIME:
                            _instruction.Operator.OpCode = (int)OPCODES.BOOL_LT_TIME_TIME;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                    }
                    //return _instruction.Operator;
                    break;
                case ">=":

                    _instruction.Operator.ReturnType = (int)VarType.BOOL;

                    op = new OPERAND();
                    op.Token = (byte)Token_Type.Token_TempValue;
                    op.type = _instruction.Operator.ReturnType;
                    op.Index = Compiler.GetUnassignedTempVar(op.type);
                    _instruction.OperandList.Add(op);
                    _instruction.OperandList.Add(GetFinalOperator(tokenlist[0]));
                    _instruction.OperandList.Add(GetFinalOperator(tokenlist[1]));

                    switch ((VarType)tokenlist[0].GetTokenPinType())
                    {
                        case VarType.BYTE:
                            _instruction.Operator.OpCode = (int)OPCODES.BOOL_GE_BYTE_BYTE;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.WORD:
                            _instruction.Operator.OpCode = (int)OPCODES.BOOL_GE_WORD_WORD;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.DWORD:
                            _instruction.Operator.OpCode = (int)OPCODES.BOOL_GE_DWORD_DWORD;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.SINT:
                            _instruction.Operator.OpCode = (int)OPCODES.BOOL_GE_SINT_SINT;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.INT:
                            _instruction.Operator.OpCode = (int)OPCODES.BOOL_GE_INT_INT;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.DINT:
                            _instruction.Operator.OpCode = (int)OPCODES.BOOL_GE_DINT_DINT;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.USINT:
                            _instruction.Operator.OpCode = (int)OPCODES.BOOL_GE_USINT_USINT;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.UINT:
                            _instruction.Operator.OpCode = (int)OPCODES.BOOL_GE_UINT_UINT;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.UDINT:
                            _instruction.Operator.OpCode = (int)OPCODES.BOOL_GE_UDINT_UDINT;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.REAL:
                            _instruction.Operator.OpCode = (int)OPCODES.BOOL_GE_REAL_REAL;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.TIME:
                            _instruction.Operator.OpCode = (int)OPCODES.BOOL_GE_TIME_TIME;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                    }
                    //return _instruction.Operator;
                    break;
                case ">":

                    _instruction.Operator.ReturnType = (int)VarType.BOOL;

                    op = new OPERAND();
                    op.Token = (byte)Token_Type.Token_TempValue;
                    op.type = _instruction.Operator.ReturnType;
                    op.Index = Compiler.GetUnassignedTempVar(op.type);
                    _instruction.OperandList.Add(op);
                    _instruction.OperandList.Add(GetFinalOperator(tokenlist[0]));
                    _instruction.OperandList.Add(GetFinalOperator(tokenlist[1]));

                    switch ((VarType)tokenlist[0].GetTokenPinType())
                    {
                        case VarType.BYTE:
                            _instruction.Operator.OpCode = (int)OPCODES.BOOL_GT_BYTE_BYTE;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.WORD:
                            _instruction.Operator.OpCode = (int)OPCODES.BOOL_GT_WORD_WORD;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.DWORD:
                            _instruction.Operator.OpCode = (int)OPCODES.BOOL_GT_DWORD_DWORD;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.SINT:
                            _instruction.Operator.OpCode = (int)OPCODES.BOOL_GT_SINT_SINT;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.INT:
                            _instruction.Operator.OpCode = (int)OPCODES.BOOL_GT_INT_INT;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.DINT:
                            _instruction.Operator.OpCode = (int)OPCODES.BOOL_GT_DINT_DINT;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.USINT:
                            _instruction.Operator.OpCode = (int)OPCODES.BOOL_GT_USINT_USINT;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.UINT:
                            _instruction.Operator.OpCode = (int)OPCODES.BOOL_GT_UINT_UINT;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.UDINT:
                            _instruction.Operator.OpCode = (int)OPCODES.BOOL_GT_UDINT_UDINT;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.REAL:
                            _instruction.Operator.OpCode = (int)OPCODES.BOOL_GT_REAL_REAL;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.TIME:
                            _instruction.Operator.OpCode = (int)OPCODES.BOOL_GT_TIME_TIME;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                    }
                    //return _instruction.Operator;
                    break;
                case "=":

                    _instruction.Operator.ReturnType = (int)VarType.BOOL;

                    op = new OPERAND();
                    op.Token = (byte)Token_Type.Token_TempValue;
                    op.type = _instruction.Operator.ReturnType;
                    op.Index = Compiler.GetUnassignedTempVar(op.type);
                    _instruction.OperandList.Add(op);
                    _instruction.OperandList.Add(GetFinalOperator(tokenlist[0]));
                    _instruction.OperandList.Add(GetFinalOperator(tokenlist[1]));

                    switch ((VarType)tokenlist[0].GetTokenPinType())
                    {
                        case VarType.BOOL:
                            _instruction.Operator.OpCode = (int)OPCODES.BOOL_EQ_BOOL_BOOL;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.BYTE:
                            _instruction.Operator.OpCode = (int)OPCODES.BOOL_EQ_BYTE_BYTE;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.WORD:
                            _instruction.Operator.OpCode = (int)OPCODES.BOOL_EQ_WORD_WORD;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.DWORD:
                            _instruction.Operator.OpCode = (int)OPCODES.BOOL_EQ_DWORD_DWORD;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.SINT:
                            _instruction.Operator.OpCode = (int)OPCODES.BOOL_EQ_SINT_SINT;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.INT:
                            _instruction.Operator.OpCode = (int)OPCODES.BOOL_EQ_INT_INT;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.DINT:
                            _instruction.Operator.OpCode = (int)OPCODES.BOOL_EQ_DINT_DINT;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.USINT:
                            _instruction.Operator.OpCode = (int)OPCODES.BOOL_EQ_USINT_USINT;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.UINT:
                            _instruction.Operator.OpCode = (int)OPCODES.BOOL_EQ_UINT_UINT;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.UDINT:
                            _instruction.Operator.OpCode = (int)OPCODES.BOOL_EQ_UDINT_UDINT;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.REAL:
                            _instruction.Operator.OpCode = (int)OPCODES.BOOL_EQ_REAL_REAL;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.TIME:
                            _instruction.Operator.OpCode = (int)OPCODES.BOOL_EQ_TIME_TIME;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                    }
                    //return _instruction.Operator;
                    break;
                case "<>":

                    _instruction.Operator.ReturnType = (int)VarType.BOOL;

                    op = new OPERAND();
                    op.Token = (byte)Token_Type.Token_TempValue;
                    op.type = _instruction.Operator.ReturnType;
                    op.Index = Compiler.GetUnassignedTempVar(op.type);
                    _instruction.OperandList.Add(op);
                    _instruction.OperandList.Add(GetFinalOperator(tokenlist[0]));
                    _instruction.OperandList.Add(GetFinalOperator(tokenlist[1]));

                    switch ((VarType)tokenlist[0].GetTokenPinType())
                    {
                        case VarType.BOOL:
                            _instruction.Operator.OpCode = (int)OPCODES.BOOL_NE_BOOL_BOOL;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.BYTE:
                            _instruction.Operator.OpCode = (int)OPCODES.BOOL_NE_BYTE_BYTE;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.WORD:
                            _instruction.Operator.OpCode = (int)OPCODES.BOOL_NE_WORD_WORD;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.DWORD:
                            _instruction.Operator.OpCode = (int)OPCODES.BOOL_NE_DWORD_DWORD;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.SINT:
                            _instruction.Operator.OpCode = (int)OPCODES.BOOL_NE_SINT_SINT;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.INT:
                            _instruction.Operator.OpCode = (int)OPCODES.BOOL_NE_INT_INT;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.DINT:
                            _instruction.Operator.OpCode = (int)OPCODES.BOOL_NE_DINT_DINT;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.USINT:
                            _instruction.Operator.OpCode = (int)OPCODES.BOOL_NE_USINT_USINT;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.UINT:
                            _instruction.Operator.OpCode = (int)OPCODES.BOOL_NE_UINT_UINT;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.UDINT:
                            _instruction.Operator.OpCode = (int)OPCODES.BOOL_NE_UDINT_UDINT;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.REAL:
                            _instruction.Operator.OpCode = (int)OPCODES.BOOL_NE_REAL_REAL;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                        case VarType.TIME:
                            _instruction.Operator.OpCode = (int)OPCODES.BOOL_NE_TIME_TIME;
                            _instruction.Operator.NoOfArg = (byte)3;
                            break;
                    }
                    //return _instruction.Operator;
                    break;
                default:
                    _instruction.Operator.OpCode = (int)OPCODES.UNKNOWN;
                    break;


            }



            return true;
        }



        //public override int GetTokenPinType()
        //{
        //    return (int)VarType.UNKNOWN;
        //}
    }
}
