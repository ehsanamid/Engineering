using DCS;
using DCS.DCSTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DCS.Compile.Token
{
    class CTokenFunctionEXInstance : CTokenFunctionEX
    {
        

        
        public CTokenFunctionEXInstance()
        {
            m_token = Token_Type.Token_FunctionEXInstance;
           

        }
        public CTokenFunctionEXInstance(string _str)
        {
            m_token = Token_Type.Token_FunctionEXInstance;
           
        }


        public override bool ReturnOperator(ref TICInstruction _instruction, List<CToken> tokenlist)
        {

            OPERAND op;

            if (tblfunction.IsStandard)
            {
               // _instruction.Operator.ReturnType = tokenlist[0].GetTokenPinType();
                _instruction.Operator.ReturnType = this.OverloadedType;
                for (int i = 0; i < tblvariable.m_tblFInstanceVariableList.Count; i++)
                {
                    if (tblvariable.m_tblFInstanceVariableList[i].Class == (int)(VarClass.Output | VarClass.FunctionInstanse))
                    {
                        op = new OPERAND();
                        op.Index = tblvariable.m_tblFInstanceVariableList[i].VarNameID;
                        op.Token = (byte)Token_Type.Token_FBDPin;
                        op.type = _instruction.Operator.ReturnType;
                        //tblvariable.Type = _instruction.Operator.ReturnType;
                        op.PropertyNo = 0;
                        //op.type = _instruction.Operator.ReturnType;
                        _instruction.OperandList.Add(op);
                        break;
                    }
                }
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


                        #region Selection


                        #region max
                        case "max":
                            {

                                switch ((VarType)_instruction.Operator.ReturnType)
                                {
                                    case VarType.BOOL:
                                        _instruction.Operator.OpCode = (int)OPCODES.BOOL_MAX_BOOL_BOOL;
                                        break;
                                    case VarType.BYTE:
                                        _instruction.Operator.OpCode = (int)OPCODES.BYTE_MAX_BYTE_BYTE;
                                        break;
                                    case VarType.WORD:
                                        _instruction.Operator.OpCode = (int)OPCODES.WORD_MAX_WORD_WORD;
                                        break;
                                    case VarType.DWORD:
                                        _instruction.Operator.OpCode = (int)OPCODES.DWORD_MAX_DWORD_DWORD;
                                        break;
                                    case VarType.SINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.SINT_MAX_SINT_SINT;
                                        break;
                                    case VarType.INT:
                                        _instruction.Operator.OpCode = (int)OPCODES.INT_MAX_INT_INT;
                                        break;
                                    case VarType.DINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.DINT_MAX_DINT_DINT;
                                        break;
                                    case VarType.USINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.USINT_MAX_USINT_USINT;
                                        break;
                                    case VarType.UINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.UINT_MAX_UINT_UINT;
                                        break;
                                    case VarType.UDINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.UDINT_MAX_UDINT_UDINT;
                                        break;
                                    case VarType.REAL:
                                        _instruction.Operator.OpCode = (int)OPCODES.REAL_MAX_REAL_REAL;
                                        break;
                                    case VarType.TIME:
                                        _instruction.Operator.OpCode = (int)OPCODES.TIME_MAX_TIME_TIME;
                                        break;
                                }
                                return true;
                            }
                        #endregion

                        #region min
                        case "min":
                            {
                                switch ((VarType)_instruction.Operator.ReturnType)
                                {
                                    case VarType.BOOL:
                                        _instruction.Operator.OpCode = (int)OPCODES.BOOL_MIN_BOOL_BOOL;
                                        break;
                                    case VarType.BYTE:
                                        _instruction.Operator.OpCode = (int)OPCODES.BYTE_MIN_BYTE_BYTE;
                                        break;
                                    case VarType.WORD:
                                        _instruction.Operator.OpCode = (int)OPCODES.WORD_MIN_WORD_WORD;
                                        _instruction.Operator.NoOfArg = m_NoOfFunctionArguments;
                                        break;
                                    case VarType.DWORD:
                                        _instruction.Operator.OpCode = (int)OPCODES.DWORD_MIN_DWORD_DWORD;
                                        break;
                                    case VarType.SINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.SINT_MIN_SINT_SINT;
                                        break;
                                    case VarType.INT:
                                        _instruction.Operator.OpCode = (int)OPCODES.INT_MIN_INT_INT;
                                        break;
                                    case VarType.DINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.DINT_MIN_DINT_DINT;
                                        break;
                                    case VarType.USINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.USINT_MIN_USINT_USINT;
                                        break;
                                    case VarType.UINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.UINT_MIN_UINT_UINT;
                                        break;
                                    case VarType.UDINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.UDINT_MIN_UDINT_UDINT;
                                        break;
                                    case VarType.REAL:
                                        _instruction.Operator.OpCode = (int)OPCODES.REAL_MIN_REAL_REAL;
                                        break;
                                    case VarType.TIME:
                                        _instruction.Operator.OpCode = (int)OPCODES.TIME_MIN_TIME_TIME;
                                        break;
                                }
                                return true;
                            }
                        #endregion


                        #region mux
                        case "mux":
                            {
                                switch ((VarType)_instruction.Operator.ReturnType)
                                {
                                    case VarType.BOOL:
                                        _instruction.Operator.OpCode = (int)OPCODES.BOOL_MUX_USINT_BOOL_BOOL;
                                        break;
                                    case VarType.BYTE:
                                        _instruction.Operator.OpCode = (int)OPCODES.BYTE_MUX_USINT_BYTE_BYTE;
                                        break;
                                    case VarType.WORD:
                                        _instruction.Operator.OpCode = (int)OPCODES.WORD_MUX_USINT_WORD_WORD;
                                        break;
                                    case VarType.DWORD:
                                        _instruction.Operator.OpCode = (int)OPCODES.DWORD_MUX_USINT_DWORD_DWORD;
                                        break;
                                    case VarType.SINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.SINT_MUX_USINT_SINT_SINT;
                                        break;
                                    case VarType.INT:
                                        _instruction.Operator.OpCode = (int)OPCODES.INT_MUX_USINT_INT_INT;
                                        _instruction.Operator.NoOfArg = 3;
                                        break;
                                    case VarType.DINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.DINT_MUX_USINT_DINT_DINT;
                                        break;
                                    case VarType.USINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.USINT_MUX_USINT_USINT_USINT;
                                        break;
                                    case VarType.UINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.UINT_MUX_USINT_UINT_UINT;
                                        break;
                                    case VarType.UDINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.UDINT_MUX_USINT_UDINT_UDINT;
                                        break;
                                    case VarType.REAL:
                                        _instruction.Operator.OpCode = (int)OPCODES.REAL_MUX_USINT_REAL_REAL;
                                        break;
                                    case VarType.TIME:
                                        _instruction.Operator.OpCode = (int)OPCODES.TIME_MUX_USINT_TIME_TIME;
                                        break;
                                }
                                return true;
                            }
                        #endregion

                        #endregion

                        #region Comparision
                        #region ge
                        case "ge":
                            {
                                switch ((VarType)ReturnType(tokenlist))
                                {
                                    case VarType.BOOL:
                                        _instruction.Operator.OpCode = (int)OPCODES.BOOL_GE_BOOL_BOOL;
                                        break;
                                    case VarType.BYTE:
                                        _instruction.Operator.OpCode = (int)OPCODES.BOOL_GE_BYTE_BYTE;
                                        break;
                                    case VarType.WORD:
                                        _instruction.Operator.OpCode = (int)OPCODES.BOOL_GE_WORD_WORD;
                                        break;
                                    case VarType.DWORD:
                                        _instruction.Operator.OpCode = (int)OPCODES.BOOL_GE_DWORD_DWORD;
                                        break;
                                    case VarType.SINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.BOOL_GE_SINT_SINT;
                                        break;
                                    case VarType.INT:
                                        _instruction.Operator.OpCode = (int)OPCODES.BOOL_GE_INT_INT;
                                        break;
                                    case VarType.DINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.BOOL_GE_DINT_DINT;
                                        break;
                                    case VarType.USINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.BOOL_GE_USINT_USINT;
                                        break;
                                    case VarType.UINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.BOOL_GE_UINT_UINT;
                                        break;
                                    case VarType.UDINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.BOOL_GE_UDINT_UDINT;
                                        break;
                                    case VarType.REAL:
                                        _instruction.Operator.OpCode = (int)OPCODES.BOOL_GE_REAL_REAL;
                                        break;
                                    case VarType.TIME:
                                        _instruction.Operator.OpCode = (int)OPCODES.BOOL_GE_TIME_TIME;
                                        break;
                                }
                                return true;
                            }
                        #endregion

                        #region gt
                        case "gt":
                            {
                                switch ((VarType)ReturnType(tokenlist))
                                {
                                    case VarType.BOOL:
                                        _instruction.Operator.OpCode = (int)OPCODES.BOOL_GT_BOOL_BOOL;
                                        break;
                                    case VarType.BYTE:
                                        _instruction.Operator.OpCode = (int)OPCODES.BOOL_GT_BYTE_BYTE;
                                        break;
                                    case VarType.WORD:
                                        _instruction.Operator.OpCode = (int)OPCODES.BOOL_GT_WORD_WORD;
                                        break;
                                    case VarType.DWORD:
                                        _instruction.Operator.OpCode = (int)OPCODES.BOOL_GT_DWORD_DWORD;
                                        break;
                                    case VarType.SINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.BOOL_GT_SINT_SINT;
                                        break;
                                    case VarType.INT:
                                        _instruction.Operator.OpCode = (int)OPCODES.BOOL_GT_INT_INT;
                                        break;
                                    case VarType.DINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.BOOL_GT_DINT_DINT;
                                        break;
                                    case VarType.USINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.BOOL_GT_USINT_USINT;
                                        break;
                                    case VarType.UINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.BOOL_GT_UINT_UINT;
                                        break;
                                    case VarType.UDINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.BOOL_GT_UDINT_UDINT;
                                        break;
                                    case VarType.REAL:
                                        _instruction.Operator.OpCode = (int)OPCODES.BOOL_GT_REAL_REAL;
                                        break;
                                    case VarType.TIME:
                                        _instruction.Operator.OpCode = (int)OPCODES.BOOL_GT_TIME_TIME;
                                        break;
                                }
                                return true;
                            }
                        #endregion

                        #region eq
                        case "eq":
                            {
                                switch ((VarType)ReturnType(tokenlist))
                                {
                                    case VarType.BOOL:
                                        _instruction.Operator.OpCode = (int)OPCODES.BOOL_EQ_BOOL_BOOL;
                                        break;
                                    case VarType.BYTE:
                                        _instruction.Operator.OpCode = (int)OPCODES.BOOL_EQ_BYTE_BYTE;
                                        break;
                                    case VarType.WORD:
                                        _instruction.Operator.OpCode = (int)OPCODES.BOOL_EQ_WORD_WORD;
                                        break;
                                    case VarType.DWORD:
                                        _instruction.Operator.OpCode = (int)OPCODES.BOOL_EQ_DWORD_DWORD;
                                        break;
                                    case VarType.SINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.BOOL_EQ_SINT_SINT;
                                        break;
                                    case VarType.INT:
                                        _instruction.Operator.OpCode = (int)OPCODES.BOOL_EQ_INT_INT;
                                        break;
                                    case VarType.DINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.BOOL_EQ_DINT_DINT;
                                        break;
                                    case VarType.USINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.BOOL_EQ_USINT_USINT;
                                        break;
                                    case VarType.UINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.BOOL_EQ_UINT_UINT;
                                        break;
                                    case VarType.UDINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.BOOL_EQ_UDINT_UDINT;
                                        break;
                                    case VarType.REAL:
                                        _instruction.Operator.OpCode = (int)OPCODES.BOOL_EQ_REAL_REAL;
                                        break;
                                    case VarType.TIME:
                                        _instruction.Operator.OpCode = (int)OPCODES.BOOL_EQ_TIME_TIME;
                                        break;
                                }
                                return true;
                            }
                        #endregion

                        #region le
                        case "le":
                            {
                                switch ((VarType)ReturnType(tokenlist))
                                {
                                    case VarType.BOOL:
                                        _instruction.Operator.OpCode = (int)OPCODES.BOOL_LE_BOOL_BOOL;
                                        break;
                                    case VarType.BYTE:
                                        _instruction.Operator.OpCode = (int)OPCODES.BOOL_LE_BYTE_BYTE;
                                        break;
                                    case VarType.WORD:
                                        _instruction.Operator.OpCode = (int)OPCODES.BOOL_LE_WORD_WORD;
                                        break;
                                    case VarType.DWORD:
                                        _instruction.Operator.OpCode = (int)OPCODES.BOOL_LE_DWORD_DWORD;
                                        break;
                                    case VarType.SINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.BOOL_LE_SINT_SINT;
                                        break;
                                    case VarType.INT:
                                        _instruction.Operator.OpCode = (int)OPCODES.BOOL_LE_INT_INT;
                                        break;
                                    case VarType.DINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.BOOL_LE_DINT_DINT;
                                        break;
                                    case VarType.USINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.BOOL_LE_USINT_USINT;
                                        break;
                                    case VarType.UINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.BOOL_LE_UINT_UINT;
                                        break;
                                    case VarType.UDINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.BOOL_LE_UDINT_UDINT;
                                        break;
                                    case VarType.REAL:
                                        _instruction.Operator.OpCode = (int)OPCODES.BOOL_LE_REAL_REAL;
                                        break;
                                    case VarType.TIME:
                                        _instruction.Operator.OpCode = (int)OPCODES.BOOL_LE_TIME_TIME;
                                        break;
                                }
                                return true;
                            }
                        #endregion

                        #region lt
                        case "lt":
                            {
                                switch ((VarType)ReturnType(tokenlist))
                                {
                                    case VarType.BOOL:
                                        _instruction.Operator.OpCode = (int)OPCODES.BOOL_LT_BOOL_BOOL;
                                        break;
                                    case VarType.BYTE:
                                        _instruction.Operator.OpCode = (int)OPCODES.BOOL_LT_BYTE_BYTE;
                                        break;
                                    case VarType.WORD:
                                        _instruction.Operator.OpCode = (int)OPCODES.BOOL_LT_WORD_WORD;
                                        break;
                                    case VarType.DWORD:
                                        _instruction.Operator.OpCode = (int)OPCODES.BOOL_LT_DWORD_DWORD;
                                        break;
                                    case VarType.SINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.BOOL_LT_SINT_SINT;
                                        break;
                                    case VarType.INT:
                                        _instruction.Operator.OpCode = (int)OPCODES.BOOL_LT_INT_INT;
                                        break;
                                    case VarType.DINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.BOOL_LT_DINT_DINT;
                                        break;
                                    case VarType.USINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.BOOL_LT_USINT_USINT;
                                        break;
                                    case VarType.UINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.BOOL_LT_UINT_UINT;
                                        break;
                                    case VarType.UDINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.BOOL_LT_UDINT_UDINT;
                                        break;
                                    case VarType.REAL:
                                        _instruction.Operator.OpCode = (int)OPCODES.BOOL_LT_REAL_REAL;
                                        break;
                                    case VarType.TIME:
                                        _instruction.Operator.OpCode = (int)OPCODES.BOOL_LT_TIME_TIME;
                                        break;
                                }
                                return true;
                            }
                        #endregion


                        #endregion

                        #region Arithmetic

                        #region mul
                        case "mul":
                            {
                                switch ((VarType)_instruction.Operator.ReturnType)
                                {
                                    case VarType.SINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.SINT_MUL_SINT_SINT;

                                        break;
                                    case VarType.INT:
                                        _instruction.Operator.OpCode = (int)OPCODES.INT_MUL_INT_INT;
                                        break;
                                    case VarType.DINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.DINT_MUL_DINT_DINT;
                                        break;
                                    case VarType.USINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.USINT_MUL_USINT_USINT;
                                        break;
                                    case VarType.UINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.UINT_MUL_UINT_UINT;
                                        break;
                                    case VarType.UDINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.UDINT_MUL_UDINT_UDINT;
                                        break;
                                    case VarType.REAL:
                                        _instruction.Operator.OpCode = (int)OPCODES.REAL_MUL_REAL_REAL;
                                        break;
                                    case VarType.TIME:
                                        switch ((VarType)tokenlist[1].GetTokenPinType())
                                        {
                                            case VarType.SINT:
                                                _instruction.Operator.OpCode = (int)OPCODES.TIME_MUL_TIME_SINT;
                                                break;
                                            case VarType.INT:
                                                _instruction.Operator.OpCode = (int)OPCODES.TIME_MUL_TIME_INT;
                                                break;
                                            case VarType.DINT:
                                                _instruction.Operator.OpCode = (int)OPCODES.TIME_MUL_TIME_DINT;
                                                break;
                                            case VarType.USINT:
                                                _instruction.Operator.OpCode = (int)OPCODES.TIME_MUL_TIME_USINT;
                                                break;
                                            case VarType.UINT:
                                                _instruction.Operator.OpCode = (int)OPCODES.TIME_MUL_TIME_UINT;
                                                break;
                                            case VarType.UDINT:
                                                _instruction.Operator.OpCode = (int)OPCODES.TIME_MUL_TIME_UDINT;
                                                break;
                                            case VarType.REAL:
                                                _instruction.Operator.OpCode = (int)OPCODES.TIME_MUL_TIME_REAL;
                                                break;
                                        }
                                        break;
                                }
                                return true;
                            }
                        #endregion


                        #region add
                        case "add":
                            {
                                switch ((VarType)_instruction.Operator.ReturnType)
                                {
                                    case VarType.SINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.SINT_ADD_SINT_SINT;
                                        break;
                                    case VarType.INT:
                                        _instruction.Operator.OpCode = (int)OPCODES.INT_ADD_INT_INT;
                                        break;
                                    case VarType.DINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.DINT_ADD_DINT_DINT;
                                        break;
                                    case VarType.USINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.USINT_ADD_USINT_USINT;
                                        break;
                                    case VarType.UINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.UINT_ADD_UINT_UINT;
                                        break;
                                    case VarType.UDINT:
                                        _instruction.Operator.OpCode = (int)OPCODES.UDINT_ADD_UDINT_UDINT;
                                        break;
                                    case VarType.REAL:
                                        _instruction.Operator.OpCode = (int)OPCODES.REAL_ADD_REAL_REAL;
                                        break;
                                    case VarType.TIME:
                                        _instruction.Operator.OpCode = (int)OPCODES.TIME_ADD_TIME_TIME;
                                        break;
                                }
                                return true;
                            }
                        #endregion
                        #endregion
                        #region Bitwise

                        #region and
                        case "and":
                            {
                                switch ((VarType)_instruction.Operator.ReturnType)
                                {
                                    case VarType.BOOL:
                                        _instruction.Operator.OpCode = (int)OPCODES.BOOL_AND_BOOL_BOOL;
                                        break;
                                    case VarType.BYTE:
                                        _instruction.Operator.OpCode = (int)OPCODES.BYTE_AND_BYTE_BYTE;
                                        break;
                                    case VarType.WORD:
                                        _instruction.Operator.OpCode = (int)OPCODES.WORD_AND_WORD_WORD;
                                        break;
                                    case VarType.DWORD:
                                        _instruction.Operator.OpCode = (int)OPCODES.DWORD_AND_DWORD_DWORD;
                                        break;
                                }
                                return true;
                            }
                        #endregion

                        #region or
                        case "or":
                            {
                                switch ((VarType)_instruction.Operator.ReturnType)
                                {
                                    case VarType.BOOL:
                                        _instruction.Operator.OpCode = (int)OPCODES.BOOL_OR_BOOL_BOOL;
                                        break;
                                    case VarType.BYTE:
                                        _instruction.Operator.OpCode = (int)OPCODES.BYTE_OR_BYTE_BYTE;
                                        break;
                                    case VarType.WORD:
                                        _instruction.Operator.OpCode = (int)OPCODES.WORD_OR_WORD_WORD;
                                        break;
                                    case VarType.DWORD:
                                        _instruction.Operator.OpCode = (int)OPCODES.DWORD_OR_DWORD_DWORD;
                                        break;
                                }
                                return true;
                            }
                        #endregion

                        #region xor
                        case "xor":
                            {
                                switch ((VarType)_instruction.Operator.ReturnType)
                                {
                                    case VarType.BOOL:
                                        _instruction.Operator.OpCode = (int)OPCODES.BOOL_XOR_BOOL_BOOL;
                                        break;
                                    case VarType.BYTE:
                                        _instruction.Operator.OpCode = (int)OPCODES.BYTE_XOR_BYTE_BYTE;
                                        break;
                                    case VarType.WORD:
                                        _instruction.Operator.OpCode = (int)OPCODES.WORD_XOR_WORD_WORD;
                                        break;
                                    case VarType.DWORD:
                                        _instruction.Operator.OpCode = (int)OPCODES.DWORD_XOR_DWORD_DWORD;
                                        break;
                                }
                                return true;
                            }
                        #endregion

                        #endregion

                    }
                }
                else  // non overloaded function
                {

                    switch (tblfunction.FunctionName.ToLower())
                    {
                        case "bools2dint":
                            {
                                _instruction.Operator.OpCode = (int)OPCODES.BOOLS_TO_DINT;
                                return true;
                            }


                    }
                }
            }
            else  // user defined function
            {

            }
            _instruction.Operator.OpCode = (int)OPCODES.UNKNOWN;

            return true;
            //-----------------------------------------------------------------------------
        }

    }
}



//---------------------------------------------------------------------------
