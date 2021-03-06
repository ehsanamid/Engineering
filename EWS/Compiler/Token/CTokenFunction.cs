﻿using DCS;
using DCS.DCSTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace DCS.Compile.Token
{
    class CTokenFunction : CToken
    {
        private int _overloadedtype;
        public int OverloadedType
        {
            get
            {
                return _overloadedtype;
            }
            set
            {
                _overloadedtype = value;
            }
        }

        private tblFunction _tblfunction;
        public tblFunction tblfunction
        {
            get
            {
                return _tblfunction;
            }
            set
            {
                _tblfunction = value;
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

        private byte _nooffunctionarguments;
        public byte m_NoOfFunctionArguments
        {
            get
            {
                return _nooffunctionarguments;
            }
            set
            {
                _nooffunctionarguments = value;
            }
        }

        public CTokenFunction()
        {
            m_token = Token_Type.Token_Function;
            //_tblformalparameter = new tblFormalParameter();
            _tblfunction = new tblFunction();
            _tblvariable = new tblVariable();

        }
        public CTokenFunction(string _str)
        {
            m_token = Token_Type.Token_Function;
            // _tblformalparameter = new tblFormalParameter();
            _tblfunction = new tblFunction();
            _tblvariable = new tblVariable();
        }






        public override bool CheckArgumentValidity(ref List<TypeReference> _vartypelist, ref TypeReference retval, ref string _retsstring)
        {
            try
            {
                if (tblfunction.IsStandard)
                {
                    if (tblfunction.Overloaded)
                    {
                        switch (tblfunction.FunctionName.ToLower())
                        {
                            case "abs":
                            case "sqrt":
                            case "ln":
                            case "log":
                            case "exp":
                            case "sin":
                            case "cos":
                            case "tan":
                            case "asin":
                            case "acos":
                            case "atan":
                            case "not":
                                if ((tblfunction.m_tblFormalParameterCollection[0].Type & _vartypelist[0].type) == 0)
                                {
                                    return false;
                                }
                                retval = _vartypelist[0];
                                break;
                            case "ne":
                            case "div":
                            case "sub":
                            case "mod":
                            case "expt":
                            case "shl":
                            case "shr":
                            case "ror":
                            case "rol":
                                if (((tblfunction.m_tblFormalParameterCollection[0].Type & _vartypelist[0].type) == 0) ||
                                      ((tblfunction.m_tblFormalParameterCollection[1].Type & _vartypelist[1].type) == 0) ||
                                (_vartypelist[0].type != _vartypelist[1].type))
                                {
                                    return false;
                                }
                                retval = _vartypelist[0];
                                break;

                            case "sel":
                                if (((tblfunction.m_tblFormalParameterCollection[0].Type & _vartypelist[0].type) == 0) ||
                                ((tblfunction.m_tblFormalParameterCollection[1].Type & _vartypelist[1].type) == 0) ||
                                ((tblfunction.m_tblFormalParameterCollection[2].Type & _vartypelist[2].type) == 0) ||
                                (_vartypelist[1].type != _vartypelist[2].type))
                                {
                                    return false;
                                }
                                retval = _vartypelist[1];
                                break;
                            case "limit":
                                if (((tblfunction.m_tblFormalParameterCollection[0].Type & _vartypelist[0].type) == 0) ||
                                    ((tblfunction.m_tblFormalParameterCollection[1].Type & _vartypelist[1].type) == 0) ||
                                    ((tblfunction.m_tblFormalParameterCollection[2].Type & _vartypelist[2].type) == 0) ||
                                    (_vartypelist[0].type != _vartypelist[1].type) ||
                                    (_vartypelist[1].type != _vartypelist[2].type) ||
                                    (_vartypelist[2].type != _vartypelist[0].type))
                                {
                                    return false;
                                }
                                retval = _vartypelist[0];
                                break;

                            case "move":
                                retval = _vartypelist[0];
                                break;
                        }
                    }
                    else
                    {
                        switch (tblfunction.FunctionName.ToLower())
                        {

                            case "getlocalyear":
                            case "getlocalmonth":
                            case "getlocalday":
                            case "getlocalhour":
                            case "getlocalminute":
                            case "getlocalsecond":
                            case "getlocalmilisecond":
                                if (tblfunction.m_tblFormalParameterCollection[0].Type != _vartypelist[0].type)
                                {
                                    return false;
                                }

                                break;
                            case "sub_date":
                            case "sub_dt":
                            case "sub_dt_time":
                            case "sub_time":
                            case "sub_tod_time":
                            case "sub_tod_tod":
                                if ((tblfunction.m_tblFormalParameterCollection[0].Type != _vartypelist[0].type) ||
                                    (tblfunction.m_tblFormalParameterCollection[1].Type != _vartypelist[1].type))
                                {
                                    return false;
                                }
                                break;
                            case "rgb":
                                if ((tblfunction.m_tblFormalParameterCollection[0].Type != _vartypelist[0].type) ||
                                     (tblfunction.m_tblFormalParameterCollection[1].Type != _vartypelist[1].type) ||
                                     (tblfunction.m_tblFormalParameterCollection[2].Type != _vartypelist[2].type))
                                {
                                    return false;
                                }
                                break;


                            case "formated":
                                return false;

                        }
                        retval.type = 0;
                        foreach (tblFormalParameter tblFormalParameter in tblfunction.m_tblFormalParameterCollection)
                        {
                            if (tblFormalParameter.Class == (int)VarClass.Output)
                            {
                                retval.type = tblFormalParameter.Type;
                                break;
                            }
                        }
                    }

                }
                else
                {
                    for (int i = 0; i < tblfunction.m_tblFormalParameterCollection.Count; i++)
                    {

                        if ((tblfunction.m_tblFormalParameterCollection[i].Class == (int)VarClass.Input) || (tblfunction.m_tblFormalParameterCollection[i].Class == (int)VarClass.InOut))
                        {
                            if (_vartypelist[i].type != tblfunction.m_tblFormalParameterCollection[i].Type)
                            {
                                return false;
                            }
                        }
                        if (tblfunction.m_tblFormalParameterCollection[i].Class == (int)VarClass.Output)
                        {
                            retval.type = tblfunction.m_tblFormalParameterCollection[i].Type;

                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return true;
        }


        public override bool ReturnOperator(ref TICInstruction _instruction, List<CToken> tokenlist)
        {

            OPERAND op;
            if (tblfunction.IsStandard)
            {
                _instruction.Operator.ReturnType = this.OverloadedType;
                op = new OPERAND();
                op.Token = (byte)Token_Type.Token_TempValue;
                op.type = _instruction.Operator.ReturnType;
                op.Index = Compiler.GetUnassignedTempVar(op.type);
                op.PropertyNo = 0;
                //op.type = _instruction.Operator.ReturnType;
                _instruction.OperandList.Add(op);

                _instruction.Operator.NoOfArg = 1;
                for (int i = 0; i < tokenlist.Count; i++)
                {
                    _instruction.OperandList.Add(GetFinalOperator(tokenlist[i]));
                    _instruction.Operator.NoOfArg++;
                }
                if (tblfunction.Overloaded)
                {
                    switch (tblfunction.FunctionName.ToLower())
                    {
                        #region Numerical
                        #region abs

                        case "abs":
                            {
                                switch ((VarType)_instruction.Operator.ReturnType)
                                {
                                    case VarType.SINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.SINT_ABS_SINT;

                                        break;
                                    case VarType.INT:
                                        _instruction.Operator.OpCode = (int)OPCODES.INT_ABS_INT;
                                        break;
                                    case VarType.DINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.DINT_ABS_DINT;
                                        break;
                                    case VarType.USINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.USINT_ABS_USINT;
                                        break;
                                    case VarType.UINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.UINT_ABS_UINT;
                                        break;
                                    case VarType.UDINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.UDINT_ABS_UDINT;
                                        break;
                                    case VarType.REAL:
                                        _instruction.Operator.OpCode = (int)OPCODES.REAL_ABS_REAL;
                                        break;

                                }
                                return true;
                            }
                        #endregion

                        #region sqrt
                        case "sqrt":
                            {
                                switch ((VarType)_instruction.Operator.ReturnType)
                                {
                                    case VarType.REAL:
                                        _instruction.Operator.OpCode = (int)OPCODES.REAL_SQRT_REAL;
                                        break;
                                }
                                return true;
                            }
                        #endregion

                        #region ln
                        case "ln":
                            {
                                switch ((VarType)_instruction.Operator.ReturnType)
                                {
                                    case VarType.REAL:
                                        _instruction.Operator.OpCode = (int)OPCODES.REAL_LN_REAL;
                                        break;
                                }
                                return true;
                            }
                        #endregion

                        #region log
                        case "log":
                            {
                                switch ((VarType)_instruction.Operator.ReturnType)
                                {
                                    case VarType.REAL:
                                        _instruction.Operator.OpCode = (int)OPCODES.REAL_LOG_REAL;
                                        break;
                                }
                                return true;
                            }
                        #endregion

                        #region exp
                        case "exp":
                            {
                                switch ((VarType)_instruction.Operator.ReturnType)
                                {
                                    case VarType.REAL:
                                        _instruction.Operator.OpCode = (int)OPCODES.REAL_EXP_REAL;
                                        break;
                                }
                                return true;
                            }
                        #endregion

                        #region sin
                        case "sin":
                            {

                                switch ((VarType)_instruction.Operator.ReturnType)
                                {
                                    case VarType.REAL:
                                        _instruction.Operator.OpCode = (int)OPCODES.REAL_SIN_REAL;
                                        break;
                                }
                                return true;
                            }
                        #endregion

                        #region cos
                        case "cos":
                            {

                                switch ((VarType)_instruction.Operator.ReturnType)
                                {
                                    case VarType.REAL:
                                        _instruction.Operator.OpCode = (int)OPCODES.REAL_COS_REAL;
                                        break;
                                }
                                return true;
                            }
                        #endregion

                        #region tan
                        case "tan":
                            {
                                switch ((VarType)_instruction.Operator.ReturnType)
                                {
                                    case VarType.REAL:
                                        _instruction.Operator.OpCode = (int)OPCODES.REAL_TAN_REAL;
                                        break;
                                }
                                return true;
                            }
                        #endregion


                        #region asin
                        case "asin":
                            {
                                switch ((VarType)_instruction.Operator.ReturnType)
                                {
                                    case VarType.REAL:
                                        _instruction.Operator.OpCode = (int)OPCODES.REAL_ASIN_REAL;
                                        break;
                                }
                                return true;
                            }
                        #endregion


                        #region acos
                        case "acos":
                            {
                                switch ((VarType)tokenlist[0].GetTokenPinType())
                                {
                                    case VarType.REAL:
                                        _instruction.Operator.OpCode = (int)OPCODES.REAL_ACOS_REAL;
                                        break;
                                }
                                return true;
                            }
                        #endregion

                        #region atan
                        case "atan":
                            {
                                switch ((VarType)_instruction.Operator.ReturnType)
                                {
                                    case VarType.REAL:
                                        _instruction.Operator.OpCode = (int)OPCODES.REAL_ATAN_REAL;
                                        break;
                                }
                                return true;
                            }
                        #endregion

                        #endregion

                        #region Bit-shift
                        #region shl
                        case "shl":
                            {
                                switch ((VarType)_instruction.Operator.ReturnType)
                                {
                                    case VarType.BYTE:
                                        _instruction.Operator.OpCode = (int)OPCODES.BYTE_SHL_BYTE_UINT;
                                        break;
                                    case VarType.WORD:
                                        _instruction.Operator.OpCode = (int)OPCODES.WORD_SHL_WORD_UINT;
                                        break;
                                    case VarType.DWORD:
                                        _instruction.Operator.OpCode = (int)OPCODES.DWORD_SHL_DWORD_UINT;
                                        break;
                                }

                                return true;
                            }
                        #endregion

                        #region shr
                        case "shr":
                            {
                                switch ((VarType)_instruction.Operator.ReturnType)
                                {
                                    case VarType.BYTE:
                                        _instruction.Operator.OpCode = (int)OPCODES.BYTE_SHR_BYTE_UINT;
                                        break;
                                    case VarType.WORD:
                                        _instruction.Operator.OpCode = (int)OPCODES.WORD_SHR_WORD_UINT;
                                        break;
                                    case VarType.DWORD:
                                        _instruction.Operator.OpCode = (int)OPCODES.DWORD_SHR_DWORD_UINT;
                                        break;
                                }

                                return true;
                            }
                        #endregion

                        #region ror
                        case "ror":
                            {
                                switch ((VarType)_instruction.Operator.ReturnType)
                                {
                                    case VarType.BYTE:
                                        _instruction.Operator.OpCode = (int)OPCODES.BYTE_ROR_BYTE_UINT;
                                        break;
                                    case VarType.WORD:
                                        _instruction.Operator.OpCode = (int)OPCODES.WORD_ROR_WORD_UINT;
                                        break;
                                    case VarType.DWORD:
                                        _instruction.Operator.OpCode = (int)OPCODES.DWORD_ROR_DWORD_UINT;
                                        break;
                                }

                                return true;
                            }
                        #endregion

                        #region rol
                        case "rol":
                            {
                                switch ((VarType)_instruction.Operator.ReturnType)
                                {
                                    case VarType.BYTE:
                                        _instruction.Operator.OpCode = (int)OPCODES.BYTE_ROL_BYTE_UINT;
                                        break;
                                    case VarType.WORD:
                                        _instruction.Operator.OpCode = (int)OPCODES.WORD_ROL_WORD_UINT;
                                        break;
                                    case VarType.DWORD:
                                        _instruction.Operator.OpCode = (int)OPCODES.DWORD_ROL_DWORD_UINT;
                                        break;
                                }

                                return true;
                            }
                        #endregion

                        #endregion


                        #region Selection
                        #region sel
                        case "sel":
                            {
                                switch ((VarType)_instruction.Operator.ReturnType)
                                {
                                    case VarType.BOOL:
                                        _instruction.Operator.OpCode = (int)OPCODES.BOOL_SEL_BOOL_BOOL_BOOL;
                                        break;
                                    case VarType.BYTE:
                                        _instruction.Operator.OpCode = (int)OPCODES.BYTE_SEL_BOOL_BYTE_BYTE;
                                        break;
                                    case VarType.WORD:
                                        _instruction.Operator.OpCode = (int)OPCODES.WORD_SEL_BOOL_WORD_WORD;
                                        break;
                                    case VarType.DWORD:
                                        _instruction.Operator.OpCode = (int)OPCODES.DWORD_SEL_BOOL_DWORD_DWORD;
                                        break;
                                    case VarType.SINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.SINT_SEL_BOOL_SINT_SINT;
                                        break;
                                    case VarType.INT:
                                        _instruction.Operator.OpCode = (int)OPCODES.INT_SEL_BOOL_INT_INT;
                                        break;
                                    case VarType.DINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.DINT_SEL_BOOL_DINT_DINT;
                                        break;
                                    case VarType.USINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.USINT_SEL_BOOL_USINT_USINT;
                                        break;
                                    case VarType.UINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.UINT_SEL_BOOL_UINT_UINT;
                                        break;
                                    case VarType.UDINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.UDINT_SEL_BOOL_UDINT_UDINT;
                                        break;
                                    case VarType.REAL:
                                        _instruction.Operator.OpCode = (int)OPCODES.REAL_SEL_BOOL_REAL_REAL;
                                        break;
                                    case VarType.TIME:
                                        _instruction.Operator.OpCode = (int)OPCODES.TIME_SEL_BOOL_TIME_TIME;
                                        break;
                                    default:
                                        return false;
                                }
                                return true;
                            }
                        #endregion


                        #region limit
                        case "limit":
                            {
                                switch ((VarType)_instruction.Operator.ReturnType)
                                {
                                    case VarType.BOOL:
                                        _instruction.Operator.OpCode = (int)OPCODES.BOOL_LIMIT_BOOL_BOOL_BOOL;
                                        break;
                                    case VarType.BYTE:
                                        _instruction.Operator.OpCode = (int)OPCODES.BYTE_LIMIT_BYTE_BYTE_BYTE;
                                        break;
                                    case VarType.WORD:
                                        _instruction.Operator.OpCode = (int)OPCODES.WORD_LIMIT_WORD_WORD_WORD;
                                        break;
                                    case VarType.DWORD:
                                        _instruction.Operator.OpCode = (int)OPCODES.DWORD_LIMIT_DWORD_DWORD_DWORD;
                                        break;
                                    case VarType.SINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.SINT_LIMIT_SINT_SINT_SINT;
                                        break;
                                    case VarType.INT:
                                        _instruction.Operator.OpCode = (int)OPCODES.INT_LIMIT_INT_INT_INT;
                                        break;
                                    case VarType.DINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.DINT_LIMIT_DINT_DINT_DINT;
                                        break;
                                    case VarType.USINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.USINT_LIMIT_USINT_USINT_USINT;
                                        break;
                                    case VarType.UINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.UINT_LIMIT_UINT_UINT_UINT;
                                        break;
                                    case VarType.UDINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.UDINT_LIMIT_UDINT_UDINT_UDINT;
                                        break;
                                    case VarType.REAL:
                                        _instruction.Operator.OpCode = (int)OPCODES.REAL_LIMIT_REAL_REAL_REAL;
                                        break;
                                    case VarType.TIME:
                                        _instruction.Operator.OpCode = (int)OPCODES.LREAL_LIMIT_LREAL_LREAL_LREAL;
                                        break;
                                }
                                return true;
                            }
                        #endregion


                        #endregion

                        #region Comparision



                        #region ne
                        case "ne":
                            {
                                switch ((VarType)_instruction.Operator.ReturnType)
                                {
                                    case VarType.BOOL:
                                        _instruction.Operator.OpCode = (int)OPCODES.BOOL_NE_BOOL_BOOL;
                                        break;
                                    case VarType.BYTE:
                                        _instruction.Operator.OpCode = (int)OPCODES.BOOL_NE_BYTE_BYTE;
                                        break;
                                    case VarType.WORD:
                                        _instruction.Operator.OpCode = (int)OPCODES.BOOL_NE_WORD_WORD;
                                        break;
                                    case VarType.DWORD:
                                        _instruction.Operator.OpCode = (int)OPCODES.BOOL_NE_DWORD_DWORD;
                                        break;
                                    case VarType.SINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.BOOL_NE_SINT_SINT;
                                        break;
                                    case VarType.INT:
                                        _instruction.Operator.OpCode = (int)OPCODES.BOOL_NE_INT_INT;
                                        break;
                                    case VarType.DINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.BOOL_NE_DINT_DINT;
                                        break;
                                    case VarType.USINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.BOOL_NE_USINT_USINT;
                                        break;
                                    case VarType.UINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.BOOL_NE_UINT_UINT;
                                        break;
                                    case VarType.UDINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.BOOL_NE_UDINT_UDINT;
                                        break;
                                    case VarType.REAL:
                                        _instruction.Operator.OpCode = (int)OPCODES.BOOL_NE_REAL_REAL;
                                        break;
                                    case VarType.TIME:
                                        _instruction.Operator.OpCode = (int)OPCODES.BOOL_NE_TIME_TIME;
                                        break;
                                }
                                return true;
                            }
                        #endregion

                        #endregion

                        #region Arithmetic


                        #region div
                        case "div":
                            {
                                switch ((VarType)_instruction.Operator.ReturnType)
                                {
                                    case VarType.SINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.SINT_DIV_SINT_SINT;
                                        break;
                                    case VarType.INT:
                                        _instruction.Operator.OpCode = (int)OPCODES.INT_DIV_INT_INT;
                                        break;
                                    case VarType.DINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.DINT_DIV_DINT_DINT;
                                        break;
                                    case VarType.USINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.USINT_DIV_USINT_USINT;
                                        break;
                                    case VarType.UINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.UINT_DIV_UINT_UINT;
                                        break;
                                    case VarType.UDINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.UDINT_DIV_UDINT_UDINT;
                                        break;
                                    case VarType.REAL:
                                        _instruction.Operator.OpCode = (int)OPCODES.REAL_DIV_REAL_REAL;
                                        break;
                                    case VarType.TIME:
                                        switch ((VarType)tokenlist[1].GetTokenPinType())
                                        {
                                            case VarType.SINT:
                                                _instruction.Operator.OpCode = (int)OPCODES.TIME_DIV_TIME_SINT;
                                                break;
                                            case VarType.INT:
                                                _instruction.Operator.OpCode = (int)OPCODES.TIME_DIV_TIME_INT;
                                                break;
                                            case VarType.DINT:
                                                _instruction.Operator.OpCode = (int)OPCODES.TIME_DIV_TIME_DINT;
                                                break;
                                            case VarType.USINT:
                                                _instruction.Operator.OpCode = (int)OPCODES.TIME_DIV_TIME_USINT;
                                                break;
                                            case VarType.UINT:
                                                _instruction.Operator.OpCode = (int)OPCODES.TIME_DIV_TIME_UINT;
                                                break;
                                            case VarType.UDINT:
                                                _instruction.Operator.OpCode = (int)OPCODES.TIME_DIV_TIME_UDINT;
                                                break;
                                            case VarType.REAL:
                                                _instruction.Operator.OpCode = (int)OPCODES.TIME_DIV_TIME_REAL;
                                                break;
                                        }
                                        break;
                                }
                                return true;
                            }
                        #endregion


                        #region sub
                        case "sub":
                            {
                                switch ((VarType)_instruction.Operator.ReturnType)
                                {
                                    case VarType.SINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.SINT_SUB_SINT_SINT;
                                        break;
                                    case VarType.INT:
                                        _instruction.Operator.OpCode = (int)OPCODES.INT_SUB_INT_INT;
                                        break;
                                    case VarType.DINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.DINT_SUB_DINT_DINT;
                                        break;
                                    case VarType.USINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.USINT_SUB_USINT_USINT;
                                        break;
                                    case VarType.UINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.UINT_SUB_UINT_UINT;
                                        break;
                                    case VarType.UDINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.UDINT_SUB_UDINT_UDINT;
                                        break;
                                    case VarType.REAL:
                                        _instruction.Operator.OpCode = (int)OPCODES.REAL_SUB_REAL_REAL;
                                        break;
                                    case VarType.TIME:
                                        _instruction.Operator.OpCode = (int)OPCODES.TIME_SUB_TIME_TIME;
                                        break;
                                }
                                return true;
                            }
                        #endregion

                        #region mod
                        case "mod":
                            {
                                switch ((VarType)_instruction.Operator.ReturnType)
                                {
                                    case VarType.SINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.SINT_MOD_SINT_SINT;
                                        break;
                                    case VarType.INT:
                                        _instruction.Operator.OpCode = (int)OPCODES.INT_MOD_INT_INT;
                                        break;
                                    case VarType.DINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.DINT_MOD_DINT_DINT;
                                        break;
                                    case VarType.USINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.USINT_MOD_USINT_USINT;
                                        break;
                                    case VarType.UINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.UINT_MOD_UINT_UINT;
                                        break;
                                    case VarType.UDINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.UDINT_MOD_UDINT_UDINT;
                                        break;
                                    case VarType.REAL:
                                        _instruction.Operator.OpCode = (int)OPCODES.REAL_MOD_REAL_REAL;
                                        break;
                                }
                                return true;
                            }
                        #endregion

                        #region EXPT
                        case "expt":
                            {
                                switch ((VarType)_instruction.Operator.ReturnType)
                                {
                                    case VarType.SINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.SINT_EXPT_SINT_SINT;
                                        break;
                                    case VarType.INT:
                                        _instruction.Operator.OpCode = (int)OPCODES.INT_EXPT_INT_INT;
                                        break;
                                    case VarType.DINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.DINT_EXPT_DINT_DINT;
                                        break;
                                    case VarType.USINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.USINT_EXPT_USINT_USINT;
                                        break;
                                    case VarType.UINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.UINT_EXPT_UINT_UINT;
                                        break;
                                    case VarType.UDINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.UDINT_EXPT_UDINT_UDINT;
                                        break;
                                    case VarType.REAL:
                                        _instruction.Operator.OpCode = (int)OPCODES.REAL_EXPT_REAL_REAL;
                                        break;
                                }
                                return true;
                            }
                        #endregion

                        #region move
                        case "move":
                            {
                                switch ((VarType)_instruction.Operator.ReturnType)
                                {
                                    case VarType.BOOL:
                                        _instruction.Operator.OpCode = (int)OPCODES.BOOL_TO_BOOL;
                                        break;
                                    case VarType.BYTE:
                                        _instruction.Operator.OpCode = (int)OPCODES.BYTE_TO_BYTE;
                                        break;
                                    case VarType.WORD:
                                        _instruction.Operator.OpCode = (int)OPCODES.WORD_TO_WORD;
                                        break;
                                    case VarType.DWORD:
                                        _instruction.Operator.OpCode = (int)OPCODES.DWORD_TO_DWORD;
                                        break;
                                    case VarType.SINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.SINT_TO_SINT;
                                        break;
                                    case VarType.INT:
                                        _instruction.Operator.OpCode = (int)OPCODES.INT_TO_INT;
                                        break;
                                    case VarType.DINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.DINT_TO_DINT;
                                        break;
                                    case VarType.USINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.USINT_TO_USINT;
                                        break;
                                    case VarType.UINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.UINT_TO_UINT;
                                        break;
                                    case VarType.UDINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.UDINT_TO_UDINT;
                                        break;
                                    case VarType.REAL:
                                        _instruction.Operator.OpCode = (int)OPCODES.REAL_TO_REAL;
                                        break;
                                    case VarType.TIME:
                                        _instruction.Operator.OpCode = (int)OPCODES.TIME_TO_TIME;
                                        break;
                                }
                                return true;
                            }
                        #endregion

                        #endregion

                        #region Bitwise



                        #region not
                        case "not":
                            {
                                switch ((VarType)_instruction.Operator.ReturnType)
                                {
                                    case VarType.BOOL:
                                        _instruction.Operator.OpCode = (int)OPCODES.BOOL_NOT_BOOL;
                                        break;
                                    case VarType.BYTE:
                                        _instruction.Operator.OpCode = (int)OPCODES.BYTE_NOT_BYTE;
                                        break;
                                    case VarType.WORD:
                                        _instruction.Operator.OpCode = (int)OPCODES.WORD_NOT_WORD;
                                        break;
                                    case VarType.DWORD:
                                        _instruction.Operator.OpCode = (int)OPCODES.DWORD_NOT_DWORD;
                                        break;
                                }
                                return true;
                            }
                        #endregion


                        #endregion
                    }
                }
                else
                {
                    switch (tblfunction.FunctionName.ToLower())
                    {
                        #region ENUM_KTC_DEFINED

                        #region rgb
                        case "rgb":
                            {
                                _instruction.Operator.OpCode = (int)OPCODES.UDINT_RGB_DINT_DINT_DINT;
                                return true;
                            }

                        #endregion

                        #region formated

                        case "formated":
                            {
                                _instruction.Operator.OpCode = (int)OPCODES.FORMATED_STRING_REAL_UINT;
                                return true;
                            }


                        #endregion

                        #region time
                        case "sub_time":
                            {
                                _instruction.Operator.OpCode = (int)OPCODES.TIME_SUB_TIME_TIME;
                                return true;
                            }

                        case "getlocalyear":
                            {
                                _instruction.Operator.OpCode = (int)OPCODES.DINT_GETYEAR_DINT;

                                return true;
                            }
                        case "getlocalmonth":
                            {
                                _instruction.Operator.OpCode = (int)OPCODES.DINT_GETMONTH_DINT;

                                return true;
                            }
                        case "getlocalday":
                            {
                                _instruction.Operator.OpCode = (int)OPCODES.DINT_GETDAY_DINT;
                                return true;
                            }
                        case "getlocalhour":
                            {
                                _instruction.Operator.OpCode = (int)OPCODES.DINT_GETHOUR_DINT;
                                return true;
                            }
                        case "getlocalminute":
                            {
                                _instruction.Operator.OpCode = (int)OPCODES.DINT_GETMINUTE_DINT;
                                return true;
                            }
                        case "getlocalsecond":
                            {
                                _instruction.Operator.OpCode = (int)OPCODES.DINT_GETSECOND_DINT;
                                return true;
                            }

                        case "getlocalmilisecond":
                            {
                                _instruction.Operator.OpCode = (int)OPCODES.DINT_GETMILLSECOND_DINT;
                                return true;
                            }
                        #endregion

                        #endregion

                    }
                }
            }
            else
            {
                _instruction.Operator.ReturnType = tblfunction.GetReturnType();
                _instruction.Operator.OpCode = (int)OPCODES.CALLF;
                op = new OPERAND();
                op.Token = (byte)Token_Type.Token_TempValue;
                op.type = _instruction.Operator.ReturnType;
                op.Index = Compiler.GetUnassignedTempVar(op.type);
                op.PropertyNo = 0;
                //op.type = _instruction.Operator.ReturnType;
                _instruction.OperandList.Add(op);

                _instruction.Operator.NoOfArg = 1;

                op = new OPERAND();
                op.Token = (byte)Token_Type.Token_FBID;
                op.type = (int)VarType.ULINT;
                op.Index = tblfunction.UDPouID;
                op.PropertyNo = 0;
                //op.type = _instruction.Operator.ReturnType;
                _instruction.OperandList.Add(op);

                _instruction.Operator.NoOfArg++;

                for (int i = 0; i < tokenlist.Count; i++)
                {
                    _instruction.OperandList.Add(GetFinalOperator(tokenlist[i]));
                    _instruction.Operator.NoOfArg++;
                }
                return true;

                
            }
            _instruction.Operator.OpCode = (int)OPCODES.UNKNOWN;

            return true;
            //-----------------------------------------------------------------------------
        }

        //public override int GetTokenPinType()
        //{
        //    return (int)VarType.UNKNOWN;
        //}
    }
}



//---------------------------------------------------------------------------
