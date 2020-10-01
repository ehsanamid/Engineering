using DCS;
using DCS.DCSTables;
using DCS.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace DCS.Compile
{
    public class TICInstruction
    {
#if OWSAPP
        VALUE m_val = new VALUE(); 
#endif
        public List<OPERAND> OperandList = new List<OPERAND>();
        public OPERATOR Operator = new OPERATOR();
        public TICInstruction()
        {

        }
        public int Size()
        {
            int s = 0;
            s = Marshal.SizeOf(Operator);
            if (OperandList.Count > 0)
            {
                s += (OperandList.Count * Marshal.SizeOf(OperandList[0]));
            }

            return s;
        }

#if OWSAPP
        VALUE GetValue(OPERAND op)
        {
            switch ((Token_Type)op.Token)
            {
                case Token_Type.Token_Variable:
                    if (op.HasSubPropety != 0)
                    {
                        return tblSolution.m_tblSolution().GetValueSub(op.Index, op.PropertyNo, op.SubProperty);
                    }
                    else
                    {
                        return tblSolution.m_tblSolution().GetValue(op.Index, op.PropertyNo);
                    }
                case Token_Type.Token_Constant:
                    VALUE _val = new VALUE();
                    _val.LINT = op.Index;
                    return _val;

                case Token_Type.Token_TempString:

                    break;
                case Token_Type.Token_TempValue:
                    return tblSolution.m_tblSolution().tempVariables[(int)op.Index];
                    
                case Token_Type.Token_String:

                    break;
            }
            m_val.LWORD = 0;
            return m_val;
        }

        void SetValue(OPERAND op, VALUE _val)
        {
            switch ((Token_Type)op.Token)
            {
                case Token_Type.Token_Variable:
                    if (op.HasSubPropety != 0)
                    {
                        tblSolution.m_tblSolution().SetValueSub(op.Index, op.PropertyNo, op.SubProperty, _val);
                    }
                    else
                    {
                        tblSolution.m_tblSolution().SetValue(op.Index, op.PropertyNo, _val);
                    }
                    break;
                case Token_Type.Token_Constant:

                    break;
                case Token_Type.Token_TempValue:
                    tblSolution.m_tblSolution().tempVariables[(int)op.Index].ULINT = _val.ULINT;
                    //tblSolution.m_tblSolution().SetToConstantcollection((int)op.Index, _val, op.type);
                    break;
                case Token_Type.Token_TempString:

                    break;
            }
        }


        public VALUE RunInstruction()
        {
            int i;
            VALUE _value = new VALUE();
            _value.LREAL = 0;
            int _count = 0;
            OPCODES op = (OPCODES)Operator.OpCode;
            try
            {

                switch ((OPCODES)Operator.OpCode)
                {
                    case OPCODES.BOOL_TO_BOOL:
                    case OPCODES.BYTE_TO_BYTE:
                    case OPCODES.WORD_TO_WORD:
                    case OPCODES.DWORD_TO_DWORD:
                    case OPCODES.LWORD_TO_LWORD:
                    case OPCODES.SINT_TO_SINT:
                    case OPCODES.INT_TO_INT:
                    case OPCODES.DINT_TO_DINT:
                    case OPCODES.LINT_TO_LINT:
                    case OPCODES.USINT_TO_USINT:
                    case OPCODES.UINT_TO_UINT:
                    case OPCODES.UDINT_TO_UDINT:
                    case OPCODES.ULINT_TO_ULINT:
                    case OPCODES.REAL_TO_REAL:
                    case OPCODES.LREAL_TO_LREAL:
                    case OPCODES.TIME_TO_TIME:
                    case OPCODES.DATE_TO_DATE:
                    case OPCODES.DT_TO_DT:
                    case OPCODES.TOD_TO_TOD:
                    case OPCODES.STRING_TO_STRING:
                    case OPCODES.WSTRING_TO_WSTRING:
                    case OPCODES.BOOL_MOVE_BOOL:
                    case OPCODES.BYTE_MOVE_BYTE:
                    case OPCODES.WORD_MOVE_WORD:
                    case OPCODES.DWORD_MOVE_DWORD:
                    case OPCODES.LWORD_MOVE_LWORD:
                    case OPCODES.SINT_MOVE_SINT:
                    case OPCODES.INT_MOVE_INT:
                    case OPCODES.DINT_MOVE_DINT:
                    case OPCODES.LINT_MOVE_LINT:
                    case OPCODES.USINT_MOVE_USINT:
                    case OPCODES.UINT_MOVE_UINT:
                    case OPCODES.UDINT_MOVE_UDINT:
                    case OPCODES.ULINT_MOVE_ULINT:
                    case OPCODES.REAL_MOVE_REAL:
                    case OPCODES.LREAL_MOVE_LREAL:
                    case OPCODES.TIME_MOVE_TIME:
                    case OPCODES.DATE_MOVE_DATE:
                    case OPCODES.DT_MOVE_DT:
                    case OPCODES.TOD_MOVE_TOD:
                    case OPCODES.STRING_MOVE_STRING:
                    case OPCODES.WSTRING_MOVE_WSTRING:
                        _value = GetValue(OperandList[1]);
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.BOOL_TO_BYTE:
                        _value = GetValue(OperandList[1]);
                        if (_value.BOOL == true)
                        {
                            _value.BYTE = 1;
                        }
                        else
                        {
                            _value.BYTE = 0;
                        }
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.BOOL_TO_WORD:
                        _value = GetValue(OperandList[1]);
                        if (_value.BOOL == true)
                        {
                            _value.WORD = 1;
                        }
                        else
                        {
                            _value.WORD = 0;
                        }
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.BOOL_TO_DWORD:
                        _value = GetValue(OperandList[1]);
                        if (_value.BOOL == true)
                        {
                            _value.DWORD = 1;
                        }
                        else
                        {
                            _value.DWORD = 0;
                        }
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.BOOL_TO_LWORD:
                        _value = GetValue(OperandList[1]);
                        if (_value.BOOL == true)
                        {
                            _value.LWORD = 1;
                        }
                        else
                        {
                            _value.LWORD = 0;
                        }
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.BOOL_TO_SINT:
                        _value = GetValue(OperandList[1]);
                        if (_value.BOOL == true)
                        {
                            _value.SINT = 1;
                        }
                        else
                        {
                            _value.SINT = 0;
                        }
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.BOOL_TO_INT:
                        _value = GetValue(OperandList[1]);
                        if (_value.BOOL == true)
                        {
                            _value.INT = 1;
                        }
                        else
                        {
                            _value.INT = 0;
                        }
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.BOOL_TO_DINT:
                        _value = GetValue(OperandList[1]);
                        if (_value.BOOL == true)
                        {
                            _value.DINT = 1;
                        }
                        else
                        {
                            _value.DINT = 0;
                        }
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.BOOL_TO_LINT:
                        _value = GetValue(OperandList[1]);
                        if (_value.BOOL == true)
                        {
                            _value.LINT = 1;
                        }
                        else
                        {
                            _value.LINT = 0;
                        }
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.BOOL_TO_UINT:
                        _value = GetValue(OperandList[1]);
                        if (_value.BOOL == true)
                        {
                            _value.UINT = 1;
                        }
                        else
                        {
                            _value.UINT = 0;
                        }
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.BOOL_TO_UDINT:
                        _value = GetValue(OperandList[1]);
                        if (_value.BOOL == true)
                        {
                            _value.UDINT = 1;
                        }
                        else
                        {
                            _value.UDINT = 0;
                        }
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.BOOL_TO_ULINT:
                        _value = GetValue(OperandList[1]);
                        if (_value.BOOL == true)
                        {
                            _value.ULINT = 1;
                        }
                        else
                        {
                            _value.ULINT = 0;
                        }
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.BOOL_TO_REAL:
                        _value = GetValue(OperandList[1]);
                        if (_value.BOOL == true)
                        {
                            _value.REAL = 1;
                        }
                        else
                        {
                            _value.REAL = 0;
                        }
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.BOOL_TO_LREAL:
                        _value = GetValue(OperandList[1]);
                        if (_value.BOOL == true)
                        {
                            _value.LREAL = 1;
                        }
                        else
                        {
                            _value.LREAL = 0;
                        }
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.BOOL_TO_TIME:
                        _value = GetValue(OperandList[1]);
                        if (_value.BOOL == true)
                        {
                            _value.TIME = 1000;
                        }
                        else
                        {
                            _value.TIME = 0;
                        }
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.BOOL_TO_DATE:
                        _value = GetValue(OperandList[1]);
                        if (_value.BOOL == true)
                        {
                            _value.DATE.date = 0;
                            _value.DATE.Day = 1;
                        }
                        else
                        {
                            _value.DATE.date = 0;
                        }
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.BOOL_TO_TOD:
                        _value = GetValue(OperandList[1]);
                        if (_value.BOOL == true)
                        {
                            _value.TOD.tod = 0;
                            _value.TOD.Second = 1;
                        }
                        else
                        {
                            _value.TOD.tod = 0;
                        }
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.BOOL_TO_DT:
                        _value = GetValue(OperandList[1]);
                        if (_value.BOOL == true)
                        {
                            _value.DT.dt = 0;
                            _value.DT.Second = 1;
                        }
                        else
                        {
                            _value.DT.dt = 0;
                        }
                        SetValue(OperandList[0], _value);
                        break;
                    //			case   OPCODES.BYTE_TO_BOOL :  break;

                    //			case   OPCODES.BYTE_TO_WORD :  
                    //				break;
                    //			case   OPCODES.BYTE_TO_DWORD : 
                    //				break;
                    //			case   OPCODES.BYTE_TO_LWORD :  
                    //				break;
                    //			case   OPCODES.BYTE_TO_SINT :  break;
                    //			case   OPCODES.BYTE_TO_INT :  break;
                    //			case   OPCODES.BYTE_TO_DINT :  break;
                    //			case   OPCODES.BYTE_TO_LINT :  break;
                    //			case   OPCODES.BYTE_TO_USINT :  break;
                    //			case   OPCODES.BYTE_TO_UINT :  break;
                    //			case   OPCODES.BYTE_TO_UDINT :  break;
                    //			case   OPCODES.BYTE_TO_ULINT :  break;
                    //			case   OPCODES.BYTE_TO_REAL :  break;
                    //			case   OPCODES.BYTE_TO_LREAL :  break;
                    //			case   OPCODES.BYTE_TO_TIME :  break;
                    //			case   OPCODES.BYTE_TO_DATE :  break;
                    //			case   OPCODES.BYTE_TO_TOD :  break;
                    //			case   OPCODES.BYTE_TO_DT :  break;
                    //			case   OPCODES.WORD_TO_BOOL :  break;
                    //			case   OPCODES.WORD_TO_BYTE :  break;

                    //			case   OPCODES.WORD_TO_DWORD :  break;
                    //			case   OPCODES.WORD_TO_LWORD :  break;
                    //			case   OPCODES.WORD_TO_SINT :  break;
                    //			case   OPCODES.WORD_TO_INT :  break;
                    //			case   OPCODES.WORD_TO_DINT :  break;
                    //			case   OPCODES.WORD_TO_LINT :  break;
                    //			case   OPCODES.WORD_TO_USINT :  break;
                    //			case   OPCODES.WORD_TO_UINT :  break;
                    //			case   OPCODES.WORD_TO_UDINT :  break;
                    //			case   OPCODES.WORD_TO_ULINT :  break;
                    //			case   OPCODES.WORD_TO_REAL :  break;
                    //			case   OPCODES.WORD_TO_LREAL :  break;
                    //			case   OPCODES.WORD_TO_TIME :  break;
                    //			case   OPCODES.WORD_TO_DATE :  break;
                    //			case   OPCODES.WORD_TO_TOD :  break;
                    //			case   OPCODES.WORD_TO_DT :  break;
                    //			case   OPCODES.DWORD_TO_BOOL :  break;
                    //			case   OPCODES.DWORD_TO_BYTE :  break;
                    //			case   OPCODES.DWORD_TO_WORD :  break;

                    //			case   OPCODES.DWORD_TO_LWORD :  break;
                    //			case   OPCODES.DWORD_TO_SINT :  break;
                    //			case   OPCODES.DWORD_TO_INT :  break;
                    //			case   OPCODES.DWORD_TO_DINT :  break;
                    //			case   OPCODES.DWORD_TO_LINT :  break;
                    //			case   OPCODES.DWORD_TO_USINT :  break;
                    //			case   OPCODES.DWORD_TO_UINT :  break;
                    //			case   OPCODES.DWORD_TO_UDINT :  break;
                    //			case   OPCODES.DWORD_TO_ULINT :  break;
                    //			case   OPCODES.DWORD_TO_REAL :  break;
                    //			case   OPCODES.DWORD_TO_LREAL :  break;
                    //			case   OPCODES.DWORD_TO_TIME :  break;
                    //			case   OPCODES.DWORD_TO_DATE :  break;
                    //			case   OPCODES.DWORD_TO_TOD :  break;
                    //			case   OPCODES.DWORD_TO_DT :  break;
                    //			case   OPCODES.LWORD_TO_BOOL :  break;
                    //			case   OPCODES.LWORD_TO_BYTE :  break;
                    //			case   OPCODES.LWORD_TO_WORD :  break;
                    //			case   OPCODES.LWORD_TO_DWORD :  break;
                    //			case   OPCODES.LWORD_TO_LWORD :  break;
                    //			case   OPCODES.LWORD_TO_SINT :  break;
                    //			case   OPCODES.LWORD_TO_INT :  break;
                    //			case   OPCODES.LWORD_TO_DINT :  break;
                    //			case   OPCODES.LWORD_TO_LINT :  break;
                    //			case   OPCODES.LWORD_TO_USINT :  break;
                    //			case   OPCODES.LWORD_TO_UINT :  break;
                    //			case   OPCODES.LWORD_TO_UDINT :  break;
                    //			case   OPCODES.LWORD_TO_ULINT :  break;
                    //			case   OPCODES.LWORD_TO_REAL :  break;
                    //			case   OPCODES.LWORD_TO_LREAL :  break;
                    //			case   OPCODES.LWORD_TO_TIME :  break;
                    //			case   OPCODES.LWORD_TO_DATE :  break;
                    //			case   OPCODES.LWORD_TO_TOD :  break;
                    //			case   OPCODES.LWORD_TO_DT :  break;
                    //			case   OPCODES.SINT_TO_BOOL :  break;
                    //			case   OPCODES.SINT_TO_BYTE :  break;
                    //			case   OPCODES.SINT_TO_WORD :  break;
                    //			case   OPCODES.SINT_TO_DWORD :  break;
                    //			case   OPCODES.SINT_TO_LWORD :  break;

                    //			case   OPCODES.SINT_TO_INT :  break;
                    //			case   OPCODES.SINT_TO_DINT :  break;
                    //			case   OPCODES.SINT_TO_LINT :  break;
                    //			case   OPCODES.SINT_TO_USINT :  break;
                    //			case   OPCODES.SINT_TO_UINT :  break;
                    //			case   OPCODES.SINT_TO_UDINT :  break;
                    //			case   OPCODES.SINT_TO_ULINT :  break;
                    //			case   OPCODES.SINT_TO_REAL :  break;
                    //			case   OPCODES.SINT_TO_LREAL :  break;
                    //			case   OPCODES.SINT_TO_TIME :  break;
                    //			case   OPCODES.SINT_TO_DATE :  break;
                    //			case   OPCODES.SINT_TO_TOD :  break;
                    //			case   OPCODES.SINT_TO_DT :  break;
                    //			case   OPCODES.INT_TO_BOOL :  break;
                    //			case   OPCODES.INT_TO_BYTE :  break;
                    //			case   OPCODES.INT_TO_WORD :  break;
                    //			case   OPCODES.INT_TO_DWORD :  break;
                    //			case   OPCODES.INT_TO_LWORD :  break;
                    //			case   OPCODES.INT_TO_SINT :  break;

                    //			case   OPCODES.INT_TO_DINT :  break;
                    //			case   OPCODES.INT_TO_LINT :  break;
                    //			case   OPCODES.INT_TO_USINT :  break;
                    //			case   OPCODES.INT_TO_UINT :  break;
                    //			case   OPCODES.INT_TO_UDINT :  break;
                    //			case   OPCODES.INT_TO_ULINT :  break;
                    //			case   OPCODES.INT_TO_REAL :  break;
                    //			case   OPCODES.INT_TO_LREAL :  break;
                    //			case   OPCODES.INT_TO_TIME :  break;
                    //			case   OPCODES.INT_TO_DATE :  break;
                    //			case   OPCODES.INT_TO_TOD :  break;
                    //			case   OPCODES.INT_TO_DT :  break;
                    //			case   OPCODES.DINT_TO_BOOL :  break;
                    //			case   OPCODES.DINT_TO_BYTE :  break;
                    //			case   OPCODES.DINT_TO_WORD :  break;
                    //			case   OPCODES.DINT_TO_DWORD :  break;
                    //			case   OPCODES.DINT_TO_LWORD :  break;
                    //			case   OPCODES.DINT_TO_SINT :  break;
                    //			case   OPCODES.DINT_TO_INT :  break;

                    //			case   OPCODES.DINT_TO_LINT :  break;
                    //			case   OPCODES.DINT_TO_USINT :  break;
                    //			case   OPCODES.DINT_TO_UINT :  break;
                    //			case   OPCODES.DINT_TO_UDINT :  break;
                    //			case   OPCODES.DINT_TO_ULINT :  break;
                    //			case   OPCODES.DINT_TO_REAL :  break;
                    //			case   OPCODES.DINT_TO_LREAL :  break;
                    //			case   OPCODES.DINT_TO_TIME :  break;
                    //			case   OPCODES.DINT_TO_DATE :  break;
                    //			case   OPCODES.DINT_TO_TOD :  break;
                    //			case   OPCODES.DINT_TO_DT :  break;
                    //			case   OPCODES.LINT_TO_BOOL :  break;
                    //			case   OPCODES.LINT_TO_BYTE :  break;
                    //			case   OPCODES.LINT_TO_WORD :  break;
                    //			case   OPCODES.LINT_TO_DWORD :  break;
                    //			case   OPCODES.LINT_TO_LWORD :  break;
                    //			case   OPCODES.LINT_TO_SINT :  break;
                    //			case   OPCODES.LINT_TO_INT :  break;
                    //			case   OPCODES.LINT_TO_DINT :  break;
                    //			case   OPCODES.LINT_TO_LINT :  break;
                    //			case   OPCODES.LINT_TO_USINT :  break;
                    //			case   OPCODES.LINT_TO_UINT :  break;
                    //			case   OPCODES.LINT_TO_UDINT :  break;
                    //			case   OPCODES.LINT_TO_ULINT :  break;
                    //			case   OPCODES.LINT_TO_REAL :  break;
                    //			case   OPCODES.LINT_TO_LREAL :  break;
                    //			case   OPCODES.LINT_TO_TIME :  break;
                    //			case   OPCODES.LINT_TO_DATE :  break;
                    //			case   OPCODES.LINT_TO_TOD :  break;
                    //			case   OPCODES.LINT_TO_DT :  break;
                    //			case   OPCODES.USINT_TO_BOOL :  break;
                    //			case   OPCODES.USINT_TO_BYTE :  break;
                    //			case   OPCODES.USINT_TO_WORD :  break;
                    //			case   OPCODES.USINT_TO_DWORD :  break;
                    //			case   OPCODES.USINT_TO_LWORD :  break;
                    //			case   OPCODES.USINT_TO_SINT :  break;
                    //			case   OPCODES.USINT_TO_INT :  break;
                    //			case   OPCODES.USINT_TO_DINT :  break;
                    //			case   OPCODES.USINT_TO_LINT :  break;
                    //			case   OPCODES.USINT_TO_UINT :  break;
                    //			case   OPCODES.USINT_TO_UDINT :  break;
                    //			case   OPCODES.USINT_TO_ULINT :  break;
                    //			case   OPCODES.USINT_TO_REAL :  break;
                    //			case   OPCODES.USINT_TO_LREAL :  break;
                    //			case   OPCODES.USINT_TO_TIME :  break;
                    //			case   OPCODES.USINT_TO_DATE :  break;
                    //			case   OPCODES.USINT_TO_TOD :  break;
                    //			case   OPCODES.USINT_TO_DT :  break;
                    //			case   OPCODES.UINT_TO_BOOL :  break;
                    //			case   OPCODES.UINT_TO_BYTE :  break;
                    //			case   OPCODES.UINT_TO_WORD :  break;
                    //			case   OPCODES.UINT_TO_DWORD :  break;
                    //			case   OPCODES.UINT_TO_LWORD :  break;
                    //			case   OPCODES.UINT_TO_SINT :  break;
                    //			case   OPCODES.UINT_TO_INT :  break;
                    //			case   OPCODES.UINT_TO_DINT :  break;
                    //			case   OPCODES.UINT_TO_LINT :  break;
                    //			case   OPCODES.UINT_TO_USINT :  break;
                    //			case   OPCODES.UINT_TO_UDINT :  break;
                    //			case   OPCODES.UINT_TO_ULINT :  break;
                    //			case   OPCODES.UINT_TO_REAL :  break;
                    //			case   OPCODES.UINT_TO_LREAL :  break;
                    //			case   OPCODES.UINT_TO_TIME :  break;
                    //			case   OPCODES.UINT_TO_DATE :  break;
                    //			case   OPCODES.UINT_TO_TOD :  break;
                    //			case   OPCODES.UINT_TO_DT :  break;
                    //			case   OPCODES.UDINT_TO_BOOL :  break;
                    //			case   OPCODES.UDINT_TO_BYTE :  break;
                    //			case   OPCODES.UDINT_TO_WORD :  break;
                    //			case   OPCODES.UDINT_TO_DWORD :  break;
                    //			case   OPCODES.UDINT_TO_LWORD :  break;
                    //			case   OPCODES.UDINT_TO_SINT :  break;
                    //			case   OPCODES.UDINT_TO_INT :  break;
                    //			case   OPCODES.UDINT_TO_DINT :  break;
                    //			case   OPCODES.UDINT_TO_LINT :  break;
                    //			case   OPCODES.UDINT_TO_USINT :  break;
                    //			case   OPCODES.UDINT_TO_UINT :  break;
                    //			case   OPCODES.UDINT_TO_ULINT :  break;
                    //			case   OPCODES.UDINT_TO_REAL :  break;
                    //			case   OPCODES.UDINT_TO_LREAL :  break;
                    //			case   OPCODES.UDINT_TO_TIME :  break;
                    //			case   OPCODES.UDINT_TO_DATE :  break;
                    //			case   OPCODES.UDINT_TO_TOD :  break;
                    //			case   OPCODES.UDINT_TO_DT :  break;
                    //			case   OPCODES.ULINT_TO_BOOL :  break;
                    //			case   OPCODES.ULINT_TO_BYTE :  break;
                    //			case   OPCODES.ULINT_TO_WORD :  break;
                    //			case   OPCODES.ULINT_TO_DWORD :  break;
                    //			case   OPCODES.ULINT_TO_LWORD :  break;
                    //			case   OPCODES.ULINT_TO_SINT :  break;
                    //			case   OPCODES.ULINT_TO_INT :  break;
                    //			case   OPCODES.ULINT_TO_DINT :  break;
                    //			case   OPCODES.ULINT_TO_LINT :  break;
                    //			case   OPCODES.ULINT_TO_USINT :  break;
                    //			case   OPCODES.ULINT_TO_UINT :  break;
                    //			case   OPCODES.ULINT_TO_UDINT :  break;
                    //			case   OPCODES.ULINT_TO_ULINT :  break;
                    //			case   OPCODES.ULINT_TO_REAL :  break;
                    //			case   OPCODES.ULINT_TO_LREAL :  break;
                    //			case   OPCODES.ULINT_TO_TIME :  break;
                    //			case   OPCODES.ULINT_TO_DATE :  break;
                    //			case   OPCODES.ULINT_TO_TOD :  break;
                    //			case   OPCODES.ULINT_TO_DT :  break;
                    //			case   OPCODES.REAL_TO_BOOL :  break;
                    //			case   OPCODES.REAL_TO_BYTE :  break;
                    //			case   OPCODES.REAL_TO_WORD :  break;
                    //			case   OPCODES.REAL_TO_DWORD :  break;
                    //			case   OPCODES.REAL_TO_LWORD :  break;
                    //			case   OPCODES.REAL_TO_SINT :  break;
                    //			case   OPCODES.REAL_TO_INT :  break;
                    //			case   OPCODES.REAL_TO_DINT :  break;
                    //			case   OPCODES.REAL_TO_LINT :  break;
                    //			case   OPCODES.REAL_TO_USINT :  break;
                    //			case   OPCODES.REAL_TO_UINT :  break;
                    //			case   OPCODES.REAL_TO_UDINT :  break;
                    //			case   OPCODES.REAL_TO_ULINT :  break;
                    //			case   OPCODES.REAL_TO_LREAL :  break;
                    //			case   OPCODES.REAL_TO_TIME :  break;
                    //			case   OPCODES.REAL_TO_DATE :  break;
                    //			case   OPCODES.REAL_TO_TOD :  break;
                    //			case   OPCODES.REAL_TO_DT :  break;
                    //			case   OPCODES.LREAL_TO_BOOL :  break;
                    //			case   OPCODES.LREAL_TO_BYTE :  break;
                    //			case   OPCODES.LREAL_TO_WORD :  break;
                    //			case   OPCODES.LREAL_TO_DWORD :  break;
                    //			case   OPCODES.LREAL_TO_LWORD :  break;
                    //			case   OPCODES.LREAL_TO_SINT :  break;
                    //			case   OPCODES.LREAL_TO_INT :  break;
                    //			case   OPCODES.LREAL_TO_DINT :  break;
                    //			case   OPCODES.LREAL_TO_LINT :  break;
                    //			case   OPCODES.LREAL_TO_USINT :  break;
                    //			case   OPCODES.LREAL_TO_UINT :  break;
                    //			case   OPCODES.LREAL_TO_UDINT :  break;
                    //			case   OPCODES.LREAL_TO_ULINT :  break;
                    //			case   OPCODES.LREAL_TO_REAL :  break;
                    //			case   OPCODES.LREAL_TO_LREAL :  break;
                    //			case   OPCODES.LREAL_TO_TIME :  break;
                    //			case   OPCODES.LREAL_TO_DATE :  break;
                    //			case   OPCODES.LREAL_TO_TOD :  break;
                    //			case   OPCODES.LREAL_TO_DT :  break;
                    //			case   OPCODES.TIME_TO_BOOL :  break;
                    //			case   OPCODES.TIME_TO_BYTE :  break;
                    //			case   OPCODES.TIME_TO_WORD :  break;
                    //			case   OPCODES.TIME_TO_DWORD :  break;
                    //			case   OPCODES.TIME_TO_LWORD :  break;
                    //			case   OPCODES.TIME_TO_SINT :  break;
                    //			case   OPCODES.TIME_TO_INT :  break;
                    //			case   OPCODES.TIME_TO_DINT :  break;
                    //			case   OPCODES.TIME_TO_LINT :  break;
                    //			case   OPCODES.TIME_TO_USINT :  break;
                    //			case   OPCODES.TIME_TO_UINT :  break;
                    //			case   OPCODES.TIME_TO_UDINT :  break;
                    //			case   OPCODES.TIME_TO_ULINT :  break;
                    //			case   OPCODES.TIME_TO_REAL :  break;
                    //			case   OPCODES.TIME_TO_LREAL :  break;
                    //			case   OPCODES.DATE_TO_BOOL :  break;
                    //			case   OPCODES.DATE_TO_BYTE :  break;
                    //			case   OPCODES.DATE_TO_WORD :  break;
                    //			case   OPCODES.DATE_TO_DWORD :  break;
                    //			case   OPCODES.DATE_TO_LWORD :  break;
                    //			case   OPCODES.DATE_TO_SINT :  break;
                    //			case   OPCODES.DATE_TO_INT :  break;
                    //			case   OPCODES.DATE_TO_DINT :  break;
                    //			case   OPCODES.DATE_TO_LINT :  break;
                    //			case   OPCODES.DATE_TO_USINT :  break;
                    //			case   OPCODES.DATE_TO_UINT :  break;
                    //			case   OPCODES.DATE_TO_UDINT :  break;
                    //			case   OPCODES.DATE_TO_ULINT :  break;
                    //			case   OPCODES.DATE_TO_REAL :  break;
                    //			case   OPCODES.DATE_TO_LREAL :  break;
                    //			case   OPCODES.DATE_TO_DATE :  break;
                    //			case   OPCODES.DATE_TO_DT :  break;
                    //			case   OPCODES.TOD_TO_BOOL :  break;
                    //			case   OPCODES.TOD_TO_BYTE :  break;
                    //			case   OPCODES.TOD_TO_WORD :  break;
                    //			case   OPCODES.TOD_TO_DWORD :  break;
                    //			case   OPCODES.TOD_TO_LWORD :  break;
                    //			case   OPCODES.TOD_TO_SINT :  break;
                    //			case   OPCODES.TOD_TO_INT :  break;
                    //			case   OPCODES.TOD_TO_DINT :  break;
                    //			case   OPCODES.TOD_TO_LINT :  break;
                    //			case   OPCODES.TOD_TO_USINT :  break;
                    //			case   OPCODES.TOD_TO_UINT :  break;
                    //			case   OPCODES.TOD_TO_UDINT :  break;
                    //			case   OPCODES.TOD_TO_ULINT :  break;
                    //			case   OPCODES.TOD_TO_REAL :  break;
                    //			case   OPCODES.TOD_TO_LREAL :  break;
                    //			case   OPCODES.TOD_TO_TOD :  break;
                    //			case   OPCODES.TOD_TO_DT :  break;
                    //			case   OPCODES.DT_TO_BOOL :  break;
                    //			case   OPCODES.DT_TO_BYTE :  break;
                    //			case   OPCODES.DT_TO_WORD :  break;
                    //			case   OPCODES.DT_TO_DWORD :  break;
                    //			case   OPCODES.DT_TO_LWORD :  break;
                    //			case   OPCODES.DT_TO_SINT :  break;
                    //			case   OPCODES.DT_TO_INT :  break;
                    //			case   OPCODES.DT_TO_DINT :  break;
                    //			case   OPCODES.DT_TO_LINT :  break;
                    //			case   OPCODES.DT_TO_USINT :  break;
                    //			case   OPCODES.DT_TO_UINT :  break;
                    //			case   OPCODES.DT_TO_UDINT :  break;
                    //			case   OPCODES.DT_TO_ULINT :  break;
                    //			case   OPCODES.DT_TO_REAL :  break;
                    //			case   OPCODES.DT_TO_LREAL :  break;
                    //			case   OPCODES.DT_TO_DT :  break;  
                    //
                    //

                    case OPCODES.BOOL_AND_BOOL_BOOL:
                        _value.BOOL = true;
                        for (i = 1; i < Operator.NoOfArg; i++)
                        {
                            _value.BOOL = (GetValue(OperandList[i]).BOOL && _value.BOOL);
                            if (_value.BOOL == false)
                            {
                                break;
                            }
                        }
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.BYTE_AND_BYTE_BYTE:
                        _value.BYTE = 0xff;
                        for (i = 1; i < Operator.NoOfArg; i++)
                        {
                            _value.BYTE = (byte)((int)GetValue(OperandList[i]).BYTE & (int)_value.BYTE);
                        }
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.WORD_AND_WORD_WORD:
                        _value.WORD = 0xffff;
                        for (i = 1; i < Operator.NoOfArg; i++)
                        {
                            _value.WORD = (ushort)((int)GetValue(OperandList[i]).WORD & (int)_value.WORD);
                        }
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.DWORD_AND_DWORD_DWORD:
                        _value.DWORD = 0xffffffff;
                        for (i = 1; i < Operator.NoOfArg; i++)
                        {
                            _value.DWORD = (uint)((int)GetValue(OperandList[i]).DWORD & (int)_value.DWORD);
                        }
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.LWORD_AND_LWORD_LWORD:
                        _value.LWORD = 0xffffffffffffffff;
                        for (i = 1; i < Operator.NoOfArg; i++)
                        {
                            _value.LWORD = (GetValue(OperandList[i]).LWORD & _value.LWORD);
                        }
                        SetValue(OperandList[0], _value);
                        break;

                    case OPCODES.BOOL_OR_BOOL_BOOL:
                        _value.BOOL = false;
                        for (i = 1; i < Operator.NoOfArg; i++)
                        {
                            _value.BOOL = (GetValue(OperandList[i]).BOOL | _value.BOOL);
                        }
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.BYTE_OR_BYTE_BYTE:
                        _value.BYTE = 0;
                        for (i = 1; i < Operator.NoOfArg; i++)
                        {
                            _value.BYTE = (byte)((int)GetValue(OperandList[i]).BYTE | (int)_value.BYTE);
                        }
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.WORD_OR_WORD_WORD:
                        _value.WORD = 0;
                        for (i = 1; i < Operator.NoOfArg; i++)
                        {
                            _value.WORD = (ushort)((int)GetValue(OperandList[i]).WORD | (int)_value.WORD);
                        }
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.DWORD_OR_DWORD_DWORD:
                        _value.DWORD = 0;
                        for (i = 1; i < Operator.NoOfArg; i++)
                        {
                            _value.DWORD = (uint)((int)GetValue(OperandList[i]).DWORD | (int)_value.DWORD);
                        }
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.LWORD_OR_LWORD_LWORD:
                        _value.LWORD = 0;
                        for (i = 1; i < Operator.NoOfArg; i++)
                        {
                            _value.LWORD = (GetValue(OperandList[i]).LWORD | _value.LWORD);
                        }
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.BOOL_XOR_BOOL_BOOL:
                        _value.BOOL = GetValue(OperandList[1]).BOOL;
                        for (i = 2; i < Operator.NoOfArg; i++)
                        {
                            _value.BOOL = (GetValue(OperandList[i]).BOOL ^ _value.BOOL);
                        }
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.BYTE_XOR_BYTE_BYTE:
                        _value.BYTE = GetValue(OperandList[1]).BYTE;
                        for (i = 2; i < Operator.NoOfArg; i++)
                        {
                            _value.BYTE = (byte)((int)GetValue(OperandList[i]).BYTE ^ (int)_value.BYTE);
                        }
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.WORD_XOR_WORD_WORD:
                        _value.WORD = GetValue(OperandList[1]).WORD;
                        for (i = 2; i < Operator.NoOfArg; i++)
                        {
                            _value.WORD = (ushort)((int)GetValue(OperandList[i]).WORD ^ (int)_value.WORD);
                        }
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.DWORD_XOR_DWORD_DWORD:
                        _value.DWORD = GetValue(OperandList[1]).DWORD;
                        for (i = 2; i < Operator.NoOfArg; i++)
                        {
                            _value.DWORD = (uint)((int)GetValue(OperandList[i]).DWORD ^ (int)_value.DWORD);
                        }
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.LWORD_XOR_LWORD_LWORD:
                        _value.LWORD = GetValue(OperandList[1]).LWORD;
                        for (i = 2; i < Operator.NoOfArg; i++)
                        {
                            _value.LWORD = (GetValue(OperandList[i]).LWORD ^ _value.LWORD);
                        }
                        SetValue(OperandList[0], _value);
                        break;

                    case OPCODES.BOOL_NOT_BOOL:
                        _value.BOOL = !GetValue(OperandList[1]).BOOL;
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.BYTE_NOT_BYTE:
                        _value.BYTE = (byte)(~((int)GetValue(OperandList[1]).BYTE));
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.WORD_NOT_WORD:
                        _value.WORD = (ushort)(~((int)GetValue(OperandList[1]).WORD));
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.DWORD_NOT_DWORD:
                        _value.DWORD = ~GetValue(OperandList[1]).DWORD;
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.LWORD_NOT_LWORD:
                        _value.LWORD = ~GetValue(OperandList[1]).LWORD;
                        SetValue(OperandList[0], _value);
                        break;

                    case OPCODES.SINT_ADD_SINT_SINT:
                        _value.SINT = 0;
                        for (i = 1; i < Operator.NoOfArg; i++)
                        {
                            _value.SINT += GetValue(OperandList[i]).SINT;
                        }
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.INT_ADD_INT_INT:
                        _value.INT = 0;
                        for (i = 1; i < Operator.NoOfArg; i++)
                        {
                            _value.INT += GetValue(OperandList[i]).INT;
                        }
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.DINT_ADD_DINT_DINT:
                        _value.DINT = 0;
                        for (i = 1; i < Operator.NoOfArg; i++)
                        {
                            _value.DINT += GetValue(OperandList[i]).DINT;
                        }
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.LINT_ADD_LINT_LINT:
                        _value.LINT = 0;
                        for (i = 1; i < Operator.NoOfArg; i++)
                        {
                            _value.LINT += GetValue(OperandList[i]).LINT;
                        }
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.USINT_ADD_USINT_USINT:
                        _value.USINT = 0;
                        for (i = 1; i < Operator.NoOfArg; i++)
                        {
                            _value.USINT += GetValue(OperandList[i]).USINT;
                        }
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.UINT_ADD_UINT_UINT:
                        _value.UINT = 0;
                        for (i = 1; i < Operator.NoOfArg; i++)
                        {
                            _value.UINT += GetValue(OperandList[i]).UINT;
                        }
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.UDINT_ADD_UDINT_UDINT:
                        _value.UDINT = 0;
                        for (i = 1; i < Operator.NoOfArg; i++)
                        {
                            _value.UDINT += GetValue(OperandList[i]).UDINT;
                        }
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.ULINT_ADD_ULINT_ULINT:
                        _value.ULINT = 0;
                        for (i = 1; i < Operator.NoOfArg; i++)
                        {
                            _value.ULINT += GetValue(OperandList[i]).ULINT;
                        }
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.REAL_ADD_REAL_REAL:
                        _value.REAL = 0;
                        for (i = 1; i < Operator.NoOfArg; i++)
                        {
                            _value.REAL += GetValue(OperandList[i]).REAL;
                        }
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.LREAL_ADD_LREAL_LREAL:
                        _value.LREAL = 0;
                        for (i = 1; i < Operator.NoOfArg; i++)
                        {
                            _value.LREAL += GetValue(OperandList[i]).LREAL;
                        }
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.TIME_ADD_TIME_TIME:
                        _value.TIME = 0;
                        for (i = 1; i < Operator.NoOfArg; i++)
                        {
                            _value.TIME += GetValue(OperandList[i]).TIME;
                        }
                        SetValue(OperandList[0], _value);
                        break;
                    //			case   OPCODES.TOD_ADD_TOD_TIME :  break;
                    //			case   OPCODES.DT_ADD_DT_TIME :  break;  
                    //
                    case OPCODES.SINT_SUB_SINT_SINT:
                        _value.SINT = (sbyte)((int)GetValue(OperandList[1]).SINT - (int)GetValue(OperandList[2]).SINT);
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.INT_SUB_INT_INT:
                        _value.INT = (short)((int)GetValue(OperandList[1]).INT - (int)GetValue(OperandList[2]).INT);
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.DINT_SUB_DINT_DINT:
                        _value.DINT = GetValue(OperandList[1]).DINT - GetValue(OperandList[2]).DINT;
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.LINT_SUB_LINT_LINT:
                        _value.LINT = GetValue(OperandList[1]).LINT - GetValue(OperandList[2]).LINT;
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.USINT_SUB_USINT_USINT:
                        _value.USINT = (byte)((int)GetValue(OperandList[1]).USINT - (int)GetValue(OperandList[2]).USINT);
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.UINT_SUB_UINT_UINT:
                        _value.UINT = (ushort)((uint)GetValue(OperandList[1]).UINT - (uint)GetValue(OperandList[2]).UINT);
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.UDINT_SUB_UDINT_UDINT:
                        _value.UDINT = GetValue(OperandList[1]).UDINT - GetValue(OperandList[2]).UDINT;
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.ULINT_SUB_ULINT_ULINT: break;
                    case OPCODES.REAL_SUB_REAL_REAL:
                        _value.REAL = GetValue(OperandList[1]).REAL - GetValue(OperandList[2]).REAL;
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.LREAL_SUB_LREAL_LREAL: break;
                    case OPCODES.TIME_SUB_TIME_TIME:
                        _value.TIME = GetValue(OperandList[1]).TIME - GetValue(OperandList[2]).TIME;
                        SetValue(OperandList[0], _value);
                        break;
                    //			case   OPCODES.TIME_SUB_DATE_DATE :  break;
                    //			case   OPCODES.TOD_SUB_TOD_TIME :  break;
                    //			case   OPCODES.TIME_SUB_TOD_TOD :  break;
                    //			case   OPCODES.DT_SUB_DT_TIME :  break;
                    //			case   OPCODES.TIME_SUB_DT_DT :  break;  
                    //
                    case OPCODES.SINT_MUL_SINT_SINT:
                        _value.SINT = 1;
                        for (i = 1; i < Operator.NoOfArg; i++)
                        {
                            _value.SINT *= GetValue(OperandList[i]).SINT;
                        }
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.INT_MUL_INT_INT:
                        _value.INT = 1;
                        for (i = 1; i < Operator.NoOfArg; i++)
                        {
                            _value.INT *= GetValue(OperandList[i]).INT;
                        }
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.DINT_MUL_DINT_DINT:
                        _value.DINT = 1;
                        for (i = 1; i < Operator.NoOfArg; i++)
                        {
                            _value.DINT *= GetValue(OperandList[i]).DINT;
                        }
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.LINT_MUL_LINT_LINT:
                        _value.LINT = 1;
                        for (i = 1; i < Operator.NoOfArg; i++)
                        {
                            _value.LINT *= GetValue(OperandList[i]).LINT;
                        }
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.USINT_MUL_USINT_USINT:
                        _value.USINT = 1;
                        for (i = 1; i < Operator.NoOfArg; i++)
                        {
                            _value.USINT *= GetValue(OperandList[i]).USINT;
                        }
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.UINT_MUL_UINT_UINT:
                        _value.UINT = 1;
                        for (i = 1; i < Operator.NoOfArg; i++)
                        {
                            _value.UINT *= GetValue(OperandList[i]).UINT;
                        }
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.UDINT_MUL_UDINT_UDINT:
                        _value.UDINT = 1;
                        for (i = 1; i < Operator.NoOfArg; i++)
                        {
                            _value.UDINT *= GetValue(OperandList[i]).UDINT;
                        }
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.ULINT_MUL_ULINT_ULINT:
                        _value.ULINT = 1;
                        for (i = 1; i < Operator.NoOfArg; i++)
                        {
                            _value.ULINT *= GetValue(OperandList[i]).ULINT;
                        }
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.REAL_MUL_REAL_REAL:
                        _value.REAL = 1;
                        for (i = 1; i < Operator.NoOfArg; i++)
                        {
                            _value.REAL *= GetValue(OperandList[i]).REAL;
                        }
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.LREAL_MUL_LREAL_LREAL:
                        _value.LREAL = 1;
                        for (i = 1; i < Operator.NoOfArg; i++)
                        {
                            _value.LREAL *= GetValue(OperandList[i]).LREAL;
                        }
                        SetValue(OperandList[0], _value);
                        break;
                    //			case   OPCODES.TIME_MUL_TIME_SINT :  break;
                    //			case   OPCODES.TIME_MUL_TIME_INT :  break;
                    //			case   OPCODES.TIME_MUL_TIME_DINT :  break;
                    //			case   OPCODES.TIME_MUL_TIME_LINT :  break;
                    //			case   OPCODES.TIME_MUL_TIME_USINT :  break;
                    //			case   OPCODES.TIME_MUL_TIME_UINT :  break;
                    //			case   OPCODES.TIME_MUL_TIME_UDINT :  break;
                    //			case   OPCODES.TIME_MUL_TIME_ULINT :  break;
                    //			case   OPCODES.TIME_MUL_TIME_REAL :  break;
                    //			case   OPCODES.TIME_MUL_TIME_LREAL :  break;
                    //
                    case OPCODES.SINT_DIV_SINT_SINT:
                        _value.SINT = (sbyte)((int)GetValue(OperandList[1]).SINT / (int)GetValue(OperandList[2]).SINT);
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.INT_DIV_INT_INT:
                        _value.INT = (short)((int)GetValue(OperandList[1]).INT / (int)GetValue(OperandList[2]).INT);
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.DINT_DIV_DINT_DINT:
                        _value.DINT = GetValue(OperandList[1]).DINT / GetValue(OperandList[2]).DINT;
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.LINT_DIV_LINT_LINT:
                        _value.LINT = GetValue(OperandList[1]).LINT / GetValue(OperandList[2]).LINT;
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.USINT_DIV_USINT_USINT:
                        _value.USINT = (byte)((uint)GetValue(OperandList[1]).USINT / (uint)GetValue(OperandList[2]).USINT);
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.UINT_DIV_UINT_UINT:
                        _value.UINT = (ushort)((uint)GetValue(OperandList[1]).UINT / (uint)GetValue(OperandList[2]).UINT);
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.UDINT_DIV_UDINT_UDINT:
                        _value.UDINT = GetValue(OperandList[1]).UDINT / GetValue(OperandList[2]).UDINT;
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.ULINT_DIV_ULINT_ULINT:
                        _value.ULINT = GetValue(OperandList[1]).ULINT / GetValue(OperandList[2]).ULINT;
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.REAL_DIV_REAL_REAL:
                        _value.REAL = GetValue(OperandList[1]).REAL / GetValue(OperandList[2]).REAL;
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.LREAL_DIV_LREAL_LREAL:
                        _value.LREAL = GetValue(OperandList[1]).LREAL / GetValue(OperandList[2]).LREAL;
                        SetValue(OperandList[0], _value);
                        break;
                    //			case   OPCODES.TIME_DIV_TIME_SINT :  break;
                    //			case   OPCODES.TIME_DIV_TIME_INT :  break;
                    //			case   OPCODES.TIME_DIV_TIME_DINT :  break;
                    //			case   OPCODES.TIME_DIV_TIME_LINT :  break;
                    //			case   OPCODES.TIME_DIV_TIME_USINT :  break;
                    //			case   OPCODES.TIME_DIV_TIME_UINT :  break;
                    //			case   OPCODES.TIME_DIV_TIME_UDINT :  break;
                    //			case   OPCODES.TIME_DIV_TIME_ULINT :  break;
                    //			case   OPCODES.TIME_DIV_TIME_REAL :  break;
                    //			case   OPCODES.TIME_DIV_TIME_LREAL :  break;
                    //
                    case OPCODES.SINT_MOD_SINT_SINT:
                        _value.SINT = (sbyte)((uint)GetValue(OperandList[1]).SINT % GetValue(OperandList[2]).SINT);
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.INT_MOD_INT_INT:
                        _value.INT = (sbyte)((uint)GetValue(OperandList[1]).INT % GetValue(OperandList[2]).INT);
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.DINT_MOD_DINT_DINT:
                        _value.DINT = GetValue(OperandList[1]).DINT % GetValue(OperandList[2]).DINT;
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.LINT_MOD_LINT_LINT:
                        _value.LINT = GetValue(OperandList[1]).LINT % GetValue(OperandList[2]).LINT;
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.USINT_MOD_USINT_USINT:
                        _value.USINT = (byte)((uint)GetValue(OperandList[1]).USINT % (uint)GetValue(OperandList[2]).USINT);
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.UINT_MOD_UINT_UINT:
                        _value.UINT = (ushort)((uint)GetValue(OperandList[1]).UINT % (uint)GetValue(OperandList[2]).UINT);
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.UDINT_MOD_UDINT_UDINT:
                        _value.UDINT = GetValue(OperandList[1]).UDINT % GetValue(OperandList[2]).UDINT;
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.ULINT_MOD_ULINT_ULINT:
                        _value.ULINT = GetValue(OperandList[1]).ULINT % GetValue(OperandList[2]).ULINT;
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.SINT_EXPT_SINT_SINT:
                        _value.SINT = (sbyte)Math.Pow((float)GetValue(OperandList[1]).SINT, (int)GetValue(OperandList[2]).SINT);
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.INT_EXPT_INT_INT:
                        _value.INT = (short)Math.Pow((float)GetValue(OperandList[1]).INT, (int)GetValue(OperandList[2]).INT);
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.DINT_EXPT_DINT_DINT:
                        _value.DINT = (int)Math.Pow((float)GetValue(OperandList[1]).DINT, (int)GetValue(OperandList[2]).DINT);
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.LINT_EXPT_LINT_LINT:
                        _value.LINT = (int)Math.Pow((float)GetValue(OperandList[1]).LINT, (int)GetValue(OperandList[2]).LINT);
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.USINT_EXPT_USINT_USINT:
                        _value.USINT = (byte)Math.Pow((float)GetValue(OperandList[1]).USINT, (int)GetValue(OperandList[2]).USINT);
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.UINT_EXPT_UINT_UINT:
                        _value.UINT = (ushort)Math.Pow((float)GetValue(OperandList[1]).UINT, (int)GetValue(OperandList[2]).UINT);
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.UDINT_EXPT_UDINT_UDINT:
                        _value.UDINT = (uint)Math.Pow((float)GetValue(OperandList[1]).UDINT, (int)GetValue(OperandList[2]).UDINT);
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.ULINT_EXPT_ULINT_ULINT:
                        _value.ULINT = (ulong)Math.Pow((float)GetValue(OperandList[1]).ULINT, (int)GetValue(OperandList[2]).ULINT);
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.REAL_EXPT_REAL_REAL:
                        _value.REAL = (float)Math.Pow((float)GetValue(OperandList[1]).REAL, (float)GetValue(OperandList[2]).REAL);
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.LREAL_EXPT_LREAL_LREAL:
                        _value.LREAL = (float)Math.Pow((float)GetValue(OperandList[1]).LREAL, (float)GetValue(OperandList[2]).LREAL);
                        SetValue(OperandList[0], _value);
                        break;

                    case OPCODES.LREAL_SQRT_LREAL:
                        _value.LREAL = (float)Math.Sqrt(GetValue(OperandList[1]).LREAL);
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.REAL_SQRT_REAL:
                        _value.REAL = (float)Math.Sqrt(GetValue(OperandList[1]).REAL);
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.LREAL_LN_LREAL:
                        _value.LREAL = (float)Math.Log(GetValue(OperandList[1]).LREAL);
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.REAL_LN_REAL:
                        _value.REAL = (float)Math.Log(GetValue(OperandList[1]).REAL);
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.LREAL_LOG_LREAL:
                        _value.LREAL = (float)Math.Log10(GetValue(OperandList[1]).LREAL);
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.REAL_LOG_REAL:
                        _value.REAL = (float)Math.Log10(GetValue(OperandList[1]).REAL);
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.LREAL_EXP_LREAL:
                        _value.LREAL = (float)Math.Exp(GetValue(OperandList[1]).LREAL);
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.REAL_EXP_REAL:
                        _value.REAL = (float)Math.Exp(GetValue(OperandList[1]).REAL);
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.LREAL_SIN_LREAL:
                        _value.LREAL = (float)Math.Sin(GetValue(OperandList[1]).LREAL);
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.REAL_SIN_REAL:
                        _value.REAL = (float)Math.Sin(GetValue(OperandList[1]).REAL);
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.LREAL_COS_LREAL:
                        _value.LREAL = (float)Math.Cos(GetValue(OperandList[1]).LREAL);
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.REAL_COS_REAL:
                        _value.REAL = (float)Math.Cos(GetValue(OperandList[1]).REAL);
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.LREAL_TAN_LREAL:
                        _value.LREAL = (float)Math.Tan(GetValue(OperandList[1]).LREAL);
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.REAL_TAN_REAL:
                        _value.REAL = (float)Math.Tan(GetValue(OperandList[1]).REAL);
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.LREAL_ASIN_LREAL:
                        _value.LREAL = (float)Math.Asin(GetValue(OperandList[1]).LREAL);
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.REAL_ASIN_REAL:
                        _value.REAL = (float)Math.Asin(GetValue(OperandList[1]).REAL);
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.LREAL_ACOS_LREAL:
                        _value.LREAL = (float)Math.Acos(GetValue(OperandList[1]).LREAL);
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.REAL_ACOS_REAL:
                        _value.REAL = (float)Math.Acos(GetValue(OperandList[1]).REAL);
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.LREAL_ATAN_LREAL:
                        _value.LREAL = (float)Math.Atan(GetValue(OperandList[1]).LREAL);
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.REAL_ATAN_REAL:
                        _value.REAL = (float)Math.Atan(GetValue(OperandList[1]).REAL);
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.SINT_ABS_SINT:
                        _value.SINT = Math.Abs(GetValue(OperandList[1]).SINT);
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.INT_ABS_INT:
                        _value.INT = Math.Abs(GetValue(OperandList[1]).INT);
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.DINT_ABS_DINT:
                        _value.DINT = Math.Abs(GetValue(OperandList[1]).DINT);
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.LINT_ABS_LINT:
                        _value.LINT = Math.Abs(GetValue(OperandList[1]).LINT);
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.USINT_ABS_USINT:
                        _value.USINT = GetValue(OperandList[1]).USINT;
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.UINT_ABS_UINT:
                        _value.UINT = GetValue(OperandList[1]).UINT;
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.UDINT_ABS_UDINT:
                        _value.UDINT = GetValue(OperandList[1]).UDINT;
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.ULINT_ABS_ULINT:
                        _value.ULINT = GetValue(OperandList[1]).ULINT;
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.REAL_ABS_REAL:
                        _value.REAL = (float)Math.Abs(GetValue(OperandList[1]).REAL);
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.LREAL_ABS_LREAL:
                        _value.LREAL = (float)Math.Abs(GetValue(OperandList[1]).LREAL);
                        SetValue(OperandList[0], _value);
                        break;

                    case OPCODES.BYTE_SHL_BYTE_UINT:
                        _value.BYTE = 0;
                        _value.BYTE = GetValue(OperandList[1]).BYTE;
                        _value.BYTE = (byte)(_value.BYTE << (int)(GetValue(OperandList[2]).UINT));
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.WORD_SHL_WORD_UINT:
                        _value.WORD = 0;
                        _value.WORD = GetValue(OperandList[1]).WORD;
                        _value.WORD = (ushort)(_value.WORD << (int)GetValue(OperandList[2]).UINT);
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.DWORD_SHL_DWORD_UINT:
                        _value.DWORD = 0;
                        _value.DWORD = GetValue(OperandList[1]).DWORD;
                        _value.DWORD = _value.DWORD << GetValue(OperandList[2]).UINT; ;
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.LWORD_SHL_LWORD_UINT:
                        _value.LWORD = 0;
                        _value.LWORD = GetValue(OperandList[1]).LWORD;
                        _value.LWORD = _value.LWORD << GetValue(OperandList[2]).UINT; ;
                        SetValue(OperandList[0], _value);
                        break;

                    case OPCODES.BYTE_SHR_BYTE_UINT:
                        _value.BYTE = 0;
                        _value.BYTE = GetValue(OperandList[1]).BYTE;
                        _value.BYTE = (byte)(_value.BYTE >> (int)GetValue(OperandList[2]).UINT);
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.WORD_SHR_WORD_UINT:
                        _value.WORD = 0;
                        _value.WORD = GetValue(OperandList[1]).WORD;
                        _value.WORD = (ushort)(_value.WORD >> (int)GetValue(OperandList[2]).UINT);
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.DWORD_SHR_DWORD_UINT:
                        _value.DWORD = 0;
                        _value.DWORD = GetValue(OperandList[1]).DWORD;
                        _value.DWORD = _value.DWORD >> GetValue(OperandList[2]).UINT;
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.LWORD_SHR_LWORD_UINT:
                        _value.LWORD = 0;
                        _value.LWORD = GetValue(OperandList[1]).LWORD;
                        _value.LWORD = _value.LWORD >> GetValue(OperandList[2]).UINT;
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.BYTE_ROR_BYTE_UINT:
                        _value.BYTE = GetValue(OperandList[1]).BYTE;
                        _count = (int)GetValue(OperandList[2]).UINT;
                        _value.BYTE = (byte)((_value.BYTE >> _count) | (_value.BYTE << (8 - _count)));
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.WORD_ROR_WORD_UINT:
                        _value.WORD = GetValue(OperandList[1]).WORD;
                        _count = (int)GetValue(OperandList[2]).UINT;
                        _value.WORD = (ushort)((_value.WORD >> _count) | (_value.WORD << (16 - _count)));
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.DWORD_ROR_DWORD_UINT:
                        _value.DWORD = GetValue(OperandList[1]).DWORD;
                        _count = (int)GetValue(OperandList[2]).UINT;
                        _value.DWORD = (uint)((_value.DWORD >> _count) | (_value.DWORD << (32 - _count)));
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.LWORD_ROR_LWORD_UINT:
                        _value.LWORD = 0;
                        _count = (int)GetValue(OperandList[2]).UINT;
                        _value.LWORD = (ulong)((_value.LWORD >> _count) | (_value.LWORD << (64 - _count)));
                        SetValue(OperandList[0], _value);
                        break;

                    case OPCODES.BYTE_ROL_BYTE_UINT:
                        _value.BYTE = GetValue(OperandList[1]).BYTE;
                        _count = (int)GetValue(OperandList[2]).UINT;
                        _value.BYTE = (byte)((_value.BYTE << _count) | (_value.BYTE >> (8 - _count)));
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.WORD_ROL_WORD_UINT:
                        _value.WORD = GetValue(OperandList[1]).WORD;
                        _count = (int)GetValue(OperandList[2]).UINT;
                        _value.WORD = (ushort)((_value.WORD << _count) | (_value.WORD >> (16 - _count)));
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.DWORD_ROL_DWORD_UINT:
                        _value.DWORD = GetValue(OperandList[1]).DWORD;
                        _count = (int)GetValue(OperandList[2]).UINT;
                        _value.DWORD = (uint)((_value.DWORD << _count) | (_value.DWORD >> (32 - _count)));
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.LWORD_ROL_LWORD_UINT:
                        _value.LWORD = 0;
                        _count = (int)GetValue(OperandList[2]).UINT;
                        _value.LWORD = (ulong)((_value.LWORD << _count) | (_value.LWORD >> (64 - _count)));
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.SINT_MAX_SINT_SINT:
                    case OPCODES.INT_MAX_INT_INT:
                    case OPCODES.DINT_MAX_DINT_DINT:
                    case OPCODES.LINT_MAX_LINT_LINT:
                    case OPCODES.USINT_MAX_USINT_USINT:
                    case OPCODES.UINT_MAX_UINT_UINT:
                    case OPCODES.UDINT_MAX_UDINT_UDINT:
                    case OPCODES.ULINT_MAX_ULINT_ULINT:
                    case OPCODES.REAL_MAX_REAL_REAL:
                    case OPCODES.LREAL_MAX_LREAL_LREAL:
                    case OPCODES.TIME_MAX_TIME_TIME:
                    case OPCODES.DATE_MAX_DATE_DATE:
                    case OPCODES.DT_MAX_DT_DT:
                    case OPCODES.TOD_MAX_TOD_TOD:
                        SetValue(OperandList[0], MAX(OperandList, Operator.NoOfArg, (OPCODES)Operator.OpCode));
                        break;
                    case OPCODES.SINT_MIN_SINT_SINT:
                    case OPCODES.INT_MIN_INT_INT:
                    case OPCODES.DINT_MIN_DINT_DINT:
                    case OPCODES.LINT_MIN_LINT_LINT:
                    case OPCODES.USINT_MIN_USINT_USINT:
                    case OPCODES.UINT_MIN_UINT_UINT:
                    case OPCODES.UDINT_MIN_UDINT_UDINT:
                    case OPCODES.ULINT_MIN_ULINT_ULINT:
                    case OPCODES.REAL_MIN_REAL_REAL:
                    case OPCODES.LREAL_MIN_LREAL_LREAL:
                    case OPCODES.TIME_MIN_TIME_TIME:
                    case OPCODES.DATE_MIN_DATE_DATE:
                    case OPCODES.DT_MIN_DT_DT:
                    case OPCODES.TOD_MIN_TOD_TOD:
                        SetValue(OperandList[0], MIN(OperandList, Operator.NoOfArg, (OPCODES)Operator.OpCode));
                        break;

                    case OPCODES.SINT_LIMIT_SINT_SINT_SINT:
                    case OPCODES.INT_LIMIT_INT_INT_INT:
                    case OPCODES.DINT_LIMIT_DINT_DINT_DINT:
                    case OPCODES.LINT_LIMIT_LINT_LINT_LINT:
                    case OPCODES.USINT_LIMIT_USINT_USINT_USINT:
                    case OPCODES.UINT_LIMIT_UINT_UINT_UINT:
                    case OPCODES.UDINT_LIMIT_UDINT_UDINT_UDINT:
                    case OPCODES.ULINT_LIMIT_ULINT_ULINT_ULINT:
                    case OPCODES.REAL_LIMIT_REAL_REAL_REAL:
                    case OPCODES.LREAL_LIMIT_LREAL_LREAL_LREAL:
                    case OPCODES.TIME_LIMIT_TIME_TIME_TIME:
                    case OPCODES.DATE_LIMIT_DATE_DATE_DATE:
                    case OPCODES.DT_LIMIT_DT_DT_DT:
                    case OPCODES.TOD_LIMIT_TOD_TOD_TOD:
                        _value = LIMIT(OperandList, (OPCODES)Operator.OpCode);
                        SetValue(OperandList[0], _value);
                        break;

                    case OPCODES.BOOL_MUX_USINT_BOOL_BOOL:
                    case OPCODES.BYTE_MUX_USINT_BYTE_BYTE:
                    case OPCODES.WORD_MUX_USINT_WORD_WORD:
                    case OPCODES.DWORD_MUX_USINT_DWORD_DWORD:
                    case OPCODES.LWORD_MUX_USINT_LWORD_LWORD:
                    case OPCODES.SINT_MUX_USINT_SINT_SINT:
                    case OPCODES.INT_MUX_USINT_INT_INT:
                    case OPCODES.DINT_MUX_USINT_DINT_DINT:
                    case OPCODES.LINT_MUX_USINT_LINT_LINT:
                    case OPCODES.USINT_MUX_USINT_USINT_USINT:
                    case OPCODES.UINT_MUX_USINT_UINT_UINT:
                    case OPCODES.UDINT_MUX_USINT_UDINT_UDINT:
                    case OPCODES.ULINT_MUX_USINT_ULINT_ULINT:
                    case OPCODES.REAL_MUX_USINT_REAL_REAL:
                    case OPCODES.LREAL_MUX_USINT_LREAL_LREAL:
                    case OPCODES.TIME_MUX_USINT_TIME_TIME:
                    case OPCODES.DATE_MUX_USINT_DATE_DATE:
                    case OPCODES.TOD_MUX_USINT_TOD_TOD:
                    case OPCODES.DT_MUX_USINT_DT_DT:
                        _value = MUX(OperandList, Operator.NoOfArg);
                        SetValue(OperandList[0], _value);
                        break;

                    case OPCODES.BOOL_GT_SINT_SINT:
                    case OPCODES.BOOL_GT_INT_INT:
                    case OPCODES.BOOL_GT_DINT_DINT:
                    case OPCODES.BOOL_GT_LINT_LINT:
                    case OPCODES.BOOL_GT_USINT_USINT:
                    case OPCODES.BOOL_GT_UINT_UINT:
                    case OPCODES.BOOL_GT_UDINT_UDINT:
                    case OPCODES.BOOL_GT_ULINT_ULINT:
                    case OPCODES.BOOL_GT_REAL_REAL:
                    case OPCODES.BOOL_GT_LREAL_LREAL:
                    case OPCODES.BOOL_GT_TIME_TIME:
                    case OPCODES.BOOL_GT_DATE_DATE:
                    case OPCODES.BOOL_GT_TOD_TOD:
                    case OPCODES.BOOL_GT_DT_DT:
                        _value = GT(OperandList, Operator.NoOfArg, (OPCODES)Operator.OpCode);
                        SetValue(OperandList[0], _value);
                        break;

                    case OPCODES.BOOL_GE_SINT_SINT:
                    case OPCODES.BOOL_GE_INT_INT:
                    case OPCODES.BOOL_GE_DINT_DINT:
                    case OPCODES.BOOL_GE_LINT_LINT:
                    case OPCODES.BOOL_GE_USINT_USINT:
                    case OPCODES.BOOL_GE_UINT_UINT:
                    case OPCODES.BOOL_GE_UDINT_UDINT:
                    case OPCODES.BOOL_GE_ULINT_ULINT:
                    case OPCODES.BOOL_GE_REAL_REAL:
                    case OPCODES.BOOL_GE_LREAL_LREAL:
                    case OPCODES.BOOL_GE_TIME_TIME:
                    case OPCODES.BOOL_GE_DATE_DATE:
                    case OPCODES.BOOL_GE_TOD_TOD:
                    case OPCODES.BOOL_GE_DT_DT:
                        _value = GE(OperandList, Operator.NoOfArg, (OPCODES)Operator.OpCode);
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.BOOL_LT_SINT_SINT:
                    case OPCODES.BOOL_LT_INT_INT:
                    case OPCODES.BOOL_LT_DINT_DINT:
                    case OPCODES.BOOL_LT_LINT_LINT:
                    case OPCODES.BOOL_LT_USINT_USINT:
                    case OPCODES.BOOL_LT_UINT_UINT:
                    case OPCODES.BOOL_LT_UDINT_UDINT:
                    case OPCODES.BOOL_LT_ULINT_ULINT:
                    case OPCODES.BOOL_LT_REAL_REAL:
                    case OPCODES.BOOL_LT_LREAL_LREAL:
                    case OPCODES.BOOL_LT_TIME_TIME:
                    case OPCODES.BOOL_LT_DATE_DATE:
                    case OPCODES.BOOL_LT_TOD_TOD:
                    case OPCODES.BOOL_LT_DT_DT:
                        _value = LT(OperandList, Operator.NoOfArg, (OPCODES)Operator.OpCode);
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.BOOL_LE_SINT_SINT:
                    case OPCODES.BOOL_LE_INT_INT:
                    case OPCODES.BOOL_LE_DINT_DINT:
                    case OPCODES.BOOL_LE_LINT_LINT:
                    case OPCODES.BOOL_LE_USINT_USINT:
                    case OPCODES.BOOL_LE_UINT_UINT:
                    case OPCODES.BOOL_LE_UDINT_UDINT:
                    case OPCODES.BOOL_LE_ULINT_ULINT:
                    case OPCODES.BOOL_LE_REAL_REAL:
                    case OPCODES.BOOL_LE_LREAL_LREAL:
                    case OPCODES.BOOL_LE_TIME_TIME:
                    case OPCODES.BOOL_LE_DATE_DATE:
                    case OPCODES.BOOL_LE_TOD_TOD:
                    case OPCODES.BOOL_LE_DT_DT:
                        _value = LE(OperandList, Operator.NoOfArg, (OPCODES)Operator.OpCode);
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.BOOL_EQ_BOOL_BOOL:
                    case OPCODES.BOOL_EQ_BYTE_BYTE:
                    case OPCODES.BOOL_EQ_WORD_WORD:
                    case OPCODES.BOOL_EQ_DWORD_DWORD:
                    case OPCODES.BOOL_EQ_LWORD_LWORD:
                    case OPCODES.BOOL_EQ_SINT_SINT:
                    case OPCODES.BOOL_EQ_INT_INT:
                    case OPCODES.BOOL_EQ_DINT_DINT:
                    case OPCODES.BOOL_EQ_LINT_LINT:
                    case OPCODES.BOOL_EQ_USINT_USINT:
                    case OPCODES.BOOL_EQ_UINT_UINT:
                    case OPCODES.BOOL_EQ_UDINT_UDINT:
                    case OPCODES.BOOL_EQ_ULINT_ULINT:
                    case OPCODES.BOOL_EQ_REAL_REAL:
                    case OPCODES.BOOL_EQ_LREAL_LREAL:
                    case OPCODES.BOOL_EQ_TIME_TIME:
                    case OPCODES.BOOL_EQ_DATE_DATE:
                    case OPCODES.BOOL_EQ_TOD_TOD:
                    case OPCODES.BOOL_EQ_DT_DT:
                        _value = EQ(OperandList, Operator.NoOfArg, (OPCODES)Operator.OpCode);
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.BOOL_NE_BOOL_BOOL:
                    case OPCODES.BOOL_NE_BYTE_BYTE:
                    case OPCODES.BOOL_NE_WORD_WORD:
                    case OPCODES.BOOL_NE_DWORD_DWORD:
                    case OPCODES.BOOL_NE_LWORD_LWORD:
                    case OPCODES.BOOL_NE_SINT_SINT:
                    case OPCODES.BOOL_NE_INT_INT:
                    case OPCODES.BOOL_NE_DINT_DINT:
                    case OPCODES.BOOL_NE_LINT_LINT:
                    case OPCODES.BOOL_NE_USINT_USINT:
                    case OPCODES.BOOL_NE_UINT_UINT:
                    case OPCODES.BOOL_NE_UDINT_UDINT:
                    case OPCODES.BOOL_NE_ULINT_ULINT:
                    case OPCODES.BOOL_NE_REAL_REAL:
                    case OPCODES.BOOL_NE_LREAL_LREAL:
                    case OPCODES.BOOL_NE_TIME_TIME:
                    case OPCODES.BOOL_NE_DATE_DATE:
                    case OPCODES.BOOL_NE_TOD_TOD:
                    case OPCODES.BOOL_NE_DT_DT:
                        _value = NE(OperandList, (OPCODES)Operator.OpCode);
                        SetValue(OperandList[0], _value);
                        break;

                    case OPCODES.BOOL_SEL_BOOL_BOOL_BOOL:
                    case OPCODES.BYTE_SEL_BOOL_BYTE_BYTE:
                    case OPCODES.WORD_SEL_BOOL_WORD_WORD:
                    case OPCODES.DWORD_SEL_BOOL_DWORD_DWORD:
                    case OPCODES.LWORD_SEL_BOOL_LWORD_LWORD:
                    case OPCODES.SINT_SEL_BOOL_SINT_SINT:
                    case OPCODES.INT_SEL_BOOL_INT_INT:
                    case OPCODES.DINT_SEL_BOOL_DINT_DINT:
                    case OPCODES.LINT_SEL_BOOL_LINT_LINT:
                    case OPCODES.USINT_SEL_BOOL_USINT_USINT:
                    case OPCODES.UINT_SEL_BOOL_UINT_UINT:
                    case OPCODES.UDINT_SEL_BOOL_UDINT_UDINT:
                    case OPCODES.ULINT_SEL_BOOL_ULINT_ULINT:
                    case OPCODES.REAL_SEL_BOOL_REAL_REAL:
                    case OPCODES.LREAL_SEL_BOOL_LREAL_LREAL:
                    case OPCODES.TIME_SEL_BOOL_TIME_TIME:
                    case OPCODES.DATE_SEL_BOOL_DATE_DATE:
                    case OPCODES.DT_SEL_BOOL_DT_DT:
                    case OPCODES.TOD_SEL_BOOL_TOD_TOD:
                        if (!GetValue(OperandList[1]).BOOL)
                        {
                            _value = GetValue(OperandList[2]);
                        }
                        else
                        {
                            _value = GetValue(OperandList[3]);
                        }
                        SetValue(OperandList[0], _value);
                        break;

                    case OPCODES.BOOLS_TO_DINT:
                        _value.DINT = 0;
                        for (i = 1; i < Operator.NoOfArg; i++)
                        {
                            //unsigned char temp = 0;
                            //if(GetValue(OperandList[i] ).BOOL)
                            //{
                            //    temp = 1;
                            //}

                            //temp <<= (i-1);
                            //_value.DINT |= temp;
                            _value.DINT |= ((GetValue(OperandList[i]).BOOL) ? 1 : 0);
                        }
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.UDINT_RGB_DINT_DINT_DINT:
                        _value.UDINT = (((uint)GetValue(OperandList[1]).DINT << (int)16) & 0xff0000);
                        _value.UDINT |= (((uint)GetValue(OperandList[2]).DINT << 8) & 0xff00);
                        _value.UDINT |= (((uint)GetValue(OperandList[3]).DINT) & 0xff);
                        SetValue(OperandList[0], _value);
                        break;
                    case OPCODES.FBD_CALL_ALARMANC:
                        break;
                    case OPCODES.FBD_CALL_CMP:
                        break;
                    case OPCODES.FBD_CALL_CTD:
                        break;
                    case OPCODES.FBD_CALL_CTU:
                        break;
                    case OPCODES.FBD_CALL_CTUD:
                        break;
                    case OPCODES.FBD_CALL_DERIVATIVE:
                        break;
                    case OPCODES.FBD_CALL_F_TRIG:
                        break;
                    case OPCODES.FBD_CALL_HYSTERESIS:
                        break;
                    case OPCODES.FBD_CALL_INTEGRAL:
                        break;
                    case OPCODES.FBD_CALL_LAG:
                        break;
                    case OPCODES.FBD_CALL_PID:
                        //if(!GetValue(OperandList[0].Index,INR_PID_Property).BOOL)
                        //{
                        //    for(i = 1 ; i < Operator.NoOfArg ; i++)
                        //    {
                        //        if((OperandList[i]).PinNo == PV_PID_Property)
                        //        {
                        //            GetRange(OperandList[i],_lowrange,_highrange);
                        //            SetRange(OperandList[0],_lowrange,_highrange);
                        //            break;
                        //        }
                        //    }
                        //}
                        //for(i = 1 ; i < Operator.NoOfArg ; i++)
                        //{
                        //    SetValue(OperandList[0].Index , (OperandList[i]).PinNo, GetValue(OperandList[i] ));
                        //}
                        //RunFBD(OperandList[0].Index);
                        break;
                    case OPCODES.FBD_CALL_PIDCAS:
                        break;
                    case OPCODES.FBD_CALL_PIDOVR:
                        break;
                    case OPCODES.FBD_CALL_R_TRIG:
                        break;
                    case OPCODES.FBD_CALL_RAMP:
                        break;
                    case OPCODES.FBD_CALL_RS:
                        break;
                    case OPCODES.FBD_CALL_RTC:
                        break;
                    case OPCODES.FBD_CALL_SELPRI:
                        break;
                    case OPCODES.FBD_CALL_SELREAD:
                        break;
                    case OPCODES.FBD_CALL_SEMA:
                        break;
                    case OPCODES.FBD_CALL_SETPRI:
                        break;
                    case OPCODES.FBD_CALL_SIG_GEN:
                        break;
                    case OPCODES.FBD_CALL_SPLIT:
                        break;
                    case OPCODES.FBD_CALL_SR:
                        break;
                    case OPCODES.FBD_CALL_STACKIN:
                        break;
                    case OPCODES.FBD_CALL_SWDOUT:
                        break;
                    case OPCODES.FBD_CALL_SWSOUT:
                        break;
                    case OPCODES.FBD_CALL_TOF:
                        break;
                    case OPCODES.FBD_CALL_TON:
                        break;
                    case OPCODES.FBD_CALL_TP:
                        break;
                    case OPCODES.FBD_CALL_TPLS:
                        break;
                    case OPCODES.FBD_CALL_TSTP:
                        break;
                    case OPCODES.FBD_CALL_WKHOUR:
                        break;
                    case OPCODES.FBD_CALL_TOTALIZER:
                        break;
                    case OPCODES.FBD_CALL_RAMP_GEN:
                        break;
                    case OPCODES.RETURN_VALUE:
                        _value = GetValue(OperandList[0]);
                        break;

                    default:
                        {
                            _value.BOOL = false;
                            break;
                        }
                }


                return _value;
            }
            catch (Exception ex)
            {

            }
            return _value;

        }

        public void ScanInstruction(ref CrossReference Lookup)
        {
            try
            {

                switch ((OPCODES)Operator.OpCode)
                {
                    case OPCODES.BOOL_TO_BOOL:
                    case OPCODES.BYTE_TO_BYTE:
                    case OPCODES.WORD_TO_WORD:
                    case OPCODES.DWORD_TO_DWORD:
                    case OPCODES.LWORD_TO_LWORD:
                    case OPCODES.SINT_TO_SINT:
                    case OPCODES.INT_TO_INT:
                    case OPCODES.DINT_TO_DINT:
                    case OPCODES.LINT_TO_LINT:
                    case OPCODES.USINT_TO_USINT:
                    case OPCODES.UINT_TO_UINT:
                    case OPCODES.UDINT_TO_UDINT:
                    case OPCODES.ULINT_TO_ULINT:
                    case OPCODES.REAL_TO_REAL:
                    case OPCODES.LREAL_TO_LREAL:
                    case OPCODES.TIME_TO_TIME:
                    case OPCODES.DATE_TO_DATE:
                    case OPCODES.DT_TO_DT:
                    case OPCODES.TOD_TO_TOD:
                    case OPCODES.STRING_TO_STRING:
                    case OPCODES.WSTRING_TO_WSTRING:
                    case OPCODES.BOOL_MOVE_BOOL:
                    case OPCODES.BYTE_MOVE_BYTE:
                    case OPCODES.WORD_MOVE_WORD:
                    case OPCODES.DWORD_MOVE_DWORD:
                    case OPCODES.LWORD_MOVE_LWORD:
                    case OPCODES.SINT_MOVE_SINT:
                    case OPCODES.INT_MOVE_INT:
                    case OPCODES.DINT_MOVE_DINT:
                    case OPCODES.LINT_MOVE_LINT:
                    case OPCODES.USINT_MOVE_USINT:
                    case OPCODES.UINT_MOVE_UINT:
                    case OPCODES.UDINT_MOVE_UDINT:
                    case OPCODES.ULINT_MOVE_ULINT:
                    case OPCODES.REAL_MOVE_REAL:
                    case OPCODES.LREAL_MOVE_LREAL:
                    case OPCODES.TIME_MOVE_TIME:
                    case OPCODES.DATE_MOVE_DATE:
                    case OPCODES.DT_MOVE_DT:
                    case OPCODES.TOD_MOVE_TOD:
                    case OPCODES.STRING_MOVE_STRING:
                    case OPCODES.WSTRING_MOVE_WSTRING:
                    case OPCODES.BOOL_TO_BYTE:
                    case OPCODES.BOOL_TO_WORD:
                    case OPCODES.BOOL_TO_DWORD:
                    case OPCODES.BOOL_TO_LWORD:
                    case OPCODES.BOOL_TO_SINT:
                    case OPCODES.BOOL_TO_INT:
                    case OPCODES.BOOL_TO_DINT:
                    case OPCODES.BOOL_TO_LINT:
                    case OPCODES.BOOL_TO_UINT:
                    case OPCODES.BOOL_TO_UDINT:
                    case OPCODES.BOOL_TO_ULINT:
                    case OPCODES.BOOL_TO_REAL:
                    case OPCODES.BOOL_TO_LREAL:
                    case OPCODES.BOOL_TO_TIME:
                    case OPCODES.BOOL_TO_DATE:
                    case OPCODES.BOOL_TO_TOD:
                    case OPCODES.BOOL_TO_DT:
                    case OPCODES.BYTE_TO_BOOL:
                    case OPCODES.BYTE_TO_WORD:
                    case OPCODES.BYTE_TO_DWORD:
                    case OPCODES.BYTE_TO_LWORD:
                    case OPCODES.BYTE_TO_SINT:
                    case OPCODES.BYTE_TO_INT:
                    case OPCODES.BYTE_TO_DINT:
                    case OPCODES.BYTE_TO_LINT:
                    case OPCODES.BYTE_TO_USINT:
                    case OPCODES.BYTE_TO_UINT:
                    case OPCODES.BYTE_TO_UDINT:
                    case OPCODES.BYTE_TO_ULINT:
                    case OPCODES.BYTE_TO_REAL:
                    case OPCODES.BYTE_TO_LREAL:
                    case OPCODES.BYTE_TO_TIME:
                    case OPCODES.BYTE_TO_DATE:
                    case OPCODES.BYTE_TO_TOD:
                    case OPCODES.BYTE_TO_DT:
                    case OPCODES.WORD_TO_BOOL:
                    case OPCODES.WORD_TO_BYTE:
                    case OPCODES.WORD_TO_DWORD:
                    case OPCODES.WORD_TO_LWORD:
                    case OPCODES.WORD_TO_SINT:
                    case OPCODES.WORD_TO_INT:
                    case OPCODES.WORD_TO_DINT:
                    case OPCODES.WORD_TO_LINT:
                    case OPCODES.WORD_TO_USINT:
                    case OPCODES.WORD_TO_UINT:
                    case OPCODES.WORD_TO_UDINT:
                    case OPCODES.WORD_TO_ULINT:
                    case OPCODES.WORD_TO_REAL:
                    case OPCODES.WORD_TO_LREAL:
                    case OPCODES.WORD_TO_TIME:
                    case OPCODES.WORD_TO_DATE:
                    case OPCODES.WORD_TO_TOD:
                    case OPCODES.WORD_TO_DT:
                    case OPCODES.DWORD_TO_BOOL:
                    case OPCODES.DWORD_TO_BYTE:
                    case OPCODES.DWORD_TO_WORD:
                    case OPCODES.DWORD_TO_LWORD:
                    case OPCODES.DWORD_TO_SINT:
                    case OPCODES.DWORD_TO_INT:
                    case OPCODES.DWORD_TO_DINT:
                    case OPCODES.DWORD_TO_LINT:
                    case OPCODES.DWORD_TO_USINT:
                    case OPCODES.DWORD_TO_UINT:
                    case OPCODES.DWORD_TO_UDINT:
                    case OPCODES.DWORD_TO_ULINT:
                    case OPCODES.DWORD_TO_REAL:
                    case OPCODES.DWORD_TO_LREAL:
                    case OPCODES.DWORD_TO_TIME:
                    case OPCODES.DWORD_TO_DATE:
                    case OPCODES.DWORD_TO_TOD:
                    case OPCODES.DWORD_TO_DT:
                    case OPCODES.LWORD_TO_BOOL:
                    case OPCODES.LWORD_TO_BYTE:
                    case OPCODES.LWORD_TO_WORD:
                    case OPCODES.LWORD_TO_DWORD:
                    case OPCODES.LWORD_TO_SINT:
                    case OPCODES.LWORD_TO_INT:
                    case OPCODES.LWORD_TO_DINT:
                    case OPCODES.LWORD_TO_LINT:
                    case OPCODES.LWORD_TO_USINT:
                    case OPCODES.LWORD_TO_UINT:
                    case OPCODES.LWORD_TO_UDINT:
                    case OPCODES.LWORD_TO_ULINT:
                    case OPCODES.LWORD_TO_REAL:
                    case OPCODES.LWORD_TO_LREAL:
                    case OPCODES.LWORD_TO_TIME:
                    case OPCODES.LWORD_TO_DATE:
                    case OPCODES.LWORD_TO_TOD:
                    case OPCODES.LWORD_TO_DT:
                    case OPCODES.SINT_TO_BOOL:
                    case OPCODES.SINT_TO_BYTE:
                    case OPCODES.SINT_TO_WORD:
                    case OPCODES.SINT_TO_DWORD:
                    case OPCODES.SINT_TO_LWORD:
                    case OPCODES.SINT_TO_INT:
                    case OPCODES.SINT_TO_DINT:
                    case OPCODES.SINT_TO_LINT:
                    case OPCODES.SINT_TO_USINT:
                    case OPCODES.SINT_TO_UINT:
                    case OPCODES.SINT_TO_UDINT:
                    case OPCODES.SINT_TO_ULINT:
                    case OPCODES.SINT_TO_REAL:
                    case OPCODES.SINT_TO_LREAL:
                    case OPCODES.SINT_TO_TIME:
                    case OPCODES.SINT_TO_DATE:
                    case OPCODES.SINT_TO_TOD:
                    case OPCODES.SINT_TO_DT:
                    case OPCODES.INT_TO_BOOL:
                    case OPCODES.INT_TO_BYTE:
                    case OPCODES.INT_TO_WORD:
                    case OPCODES.INT_TO_DWORD:
                    case OPCODES.INT_TO_LWORD:
                    case OPCODES.INT_TO_SINT:
                    case OPCODES.INT_TO_DINT:
                    case OPCODES.INT_TO_LINT:
                    case OPCODES.INT_TO_USINT:
                    case OPCODES.INT_TO_UINT:
                    case OPCODES.INT_TO_UDINT:
                    case OPCODES.INT_TO_ULINT:
                    case OPCODES.INT_TO_REAL:
                    case OPCODES.INT_TO_LREAL:
                    case OPCODES.INT_TO_TIME:
                    case OPCODES.INT_TO_DATE:
                    case OPCODES.INT_TO_TOD:
                    case OPCODES.INT_TO_DT:
                    case OPCODES.DINT_TO_BOOL:
                    case OPCODES.DINT_TO_BYTE:
                    case OPCODES.DINT_TO_WORD:
                    case OPCODES.DINT_TO_DWORD:
                    case OPCODES.DINT_TO_LWORD:
                    case OPCODES.DINT_TO_SINT:
                    case OPCODES.DINT_TO_INT:
                    case OPCODES.DINT_TO_LINT:
                    case OPCODES.DINT_TO_USINT:
                    case OPCODES.DINT_TO_UINT:
                    case OPCODES.DINT_TO_UDINT:
                    case OPCODES.DINT_TO_ULINT:
                    case OPCODES.DINT_TO_REAL:
                    case OPCODES.DINT_TO_LREAL:
                    case OPCODES.DINT_TO_TIME:
                    case OPCODES.DINT_TO_DATE:
                    case OPCODES.DINT_TO_TOD:
                    case OPCODES.DINT_TO_DT:
                    case OPCODES.LINT_TO_BOOL:
                    case OPCODES.LINT_TO_BYTE:
                    case OPCODES.LINT_TO_WORD:
                    case OPCODES.LINT_TO_DWORD:
                    case OPCODES.LINT_TO_LWORD:
                    case OPCODES.LINT_TO_SINT:
                    case OPCODES.LINT_TO_INT:
                    case OPCODES.LINT_TO_DINT:
                    case OPCODES.LINT_TO_USINT:
                    case OPCODES.LINT_TO_UINT:
                    case OPCODES.LINT_TO_UDINT:
                    case OPCODES.LINT_TO_ULINT:
                    case OPCODES.LINT_TO_REAL:
                    case OPCODES.LINT_TO_LREAL:
                    case OPCODES.LINT_TO_TIME:
                    case OPCODES.LINT_TO_DATE:
                    case OPCODES.LINT_TO_TOD:
                    case OPCODES.LINT_TO_DT:
                    case OPCODES.USINT_TO_BOOL:
                    case OPCODES.USINT_TO_BYTE:
                    case OPCODES.USINT_TO_WORD:
                    case OPCODES.USINT_TO_DWORD:
                    case OPCODES.USINT_TO_LWORD:
                    case OPCODES.USINT_TO_SINT:
                    case OPCODES.USINT_TO_INT:
                    case OPCODES.USINT_TO_DINT:
                    case OPCODES.USINT_TO_LINT:
                    case OPCODES.USINT_TO_UINT:
                    case OPCODES.USINT_TO_UDINT:
                    case OPCODES.USINT_TO_ULINT:
                    case OPCODES.USINT_TO_REAL:
                    case OPCODES.USINT_TO_LREAL:
                    case OPCODES.USINT_TO_TIME:
                    case OPCODES.USINT_TO_DATE:
                    case OPCODES.USINT_TO_TOD:
                    case OPCODES.USINT_TO_DT:
                    case OPCODES.UINT_TO_BOOL:
                    case OPCODES.UINT_TO_BYTE:
                    case OPCODES.UINT_TO_WORD:
                    case OPCODES.UINT_TO_DWORD:
                    case OPCODES.UINT_TO_LWORD:
                    case OPCODES.UINT_TO_SINT:
                    case OPCODES.UINT_TO_INT:
                    case OPCODES.UINT_TO_DINT:
                    case OPCODES.UINT_TO_LINT:
                    case OPCODES.UINT_TO_USINT:
                    case OPCODES.UINT_TO_UDINT:
                    case OPCODES.UINT_TO_ULINT:
                    case OPCODES.UINT_TO_REAL:
                    case OPCODES.UINT_TO_LREAL:
                    case OPCODES.UINT_TO_TIME:
                    case OPCODES.UINT_TO_DATE:
                    case OPCODES.UINT_TO_TOD:
                    case OPCODES.UINT_TO_DT:
                    case OPCODES.UDINT_TO_BOOL:
                    case OPCODES.UDINT_TO_BYTE:
                    case OPCODES.UDINT_TO_WORD:
                    case OPCODES.UDINT_TO_DWORD:
                    case OPCODES.UDINT_TO_LWORD:
                    case OPCODES.UDINT_TO_SINT:
                    case OPCODES.UDINT_TO_INT:
                    case OPCODES.UDINT_TO_DINT:
                    case OPCODES.UDINT_TO_LINT:
                    case OPCODES.UDINT_TO_USINT:
                    case OPCODES.UDINT_TO_UINT:
                    case OPCODES.UDINT_TO_ULINT:
                    case OPCODES.UDINT_TO_REAL:
                    case OPCODES.UDINT_TO_LREAL:
                    case OPCODES.UDINT_TO_TIME:
                    case OPCODES.UDINT_TO_DATE:
                    case OPCODES.UDINT_TO_TOD:
                    case OPCODES.UDINT_TO_DT:
                    case OPCODES.ULINT_TO_BOOL:
                    case OPCODES.ULINT_TO_BYTE:
                    case OPCODES.ULINT_TO_WORD:
                    case OPCODES.ULINT_TO_DWORD:
                    case OPCODES.ULINT_TO_LWORD:
                    case OPCODES.ULINT_TO_SINT:
                    case OPCODES.ULINT_TO_INT:
                    case OPCODES.ULINT_TO_DINT:
                    case OPCODES.ULINT_TO_LINT:
                    case OPCODES.ULINT_TO_USINT:
                    case OPCODES.ULINT_TO_UINT:
                    case OPCODES.ULINT_TO_UDINT:
                    case OPCODES.ULINT_TO_REAL:
                    case OPCODES.ULINT_TO_LREAL:
                    case OPCODES.ULINT_TO_TIME:
                    case OPCODES.ULINT_TO_DATE:
                    case OPCODES.ULINT_TO_TOD:
                    case OPCODES.ULINT_TO_DT:
                    case OPCODES.REAL_TO_BOOL:
                    case OPCODES.REAL_TO_BYTE:
                    case OPCODES.REAL_TO_WORD:
                    case OPCODES.REAL_TO_DWORD:
                    case OPCODES.REAL_TO_LWORD:
                    case OPCODES.REAL_TO_SINT:
                    case OPCODES.REAL_TO_INT:
                    case OPCODES.REAL_TO_DINT:
                    case OPCODES.REAL_TO_LINT:
                    case OPCODES.REAL_TO_USINT:
                    case OPCODES.REAL_TO_UINT:
                    case OPCODES.REAL_TO_UDINT:
                    case OPCODES.REAL_TO_ULINT:
                    case OPCODES.REAL_TO_LREAL:
                    case OPCODES.REAL_TO_TIME:
                    case OPCODES.REAL_TO_DATE:
                    case OPCODES.REAL_TO_TOD:
                    case OPCODES.REAL_TO_DT:
                    case OPCODES.LREAL_TO_BOOL:
                    case OPCODES.LREAL_TO_BYTE:
                    case OPCODES.LREAL_TO_WORD:
                    case OPCODES.LREAL_TO_DWORD:
                    case OPCODES.LREAL_TO_LWORD:
                    case OPCODES.LREAL_TO_SINT:
                    case OPCODES.LREAL_TO_INT:
                    case OPCODES.LREAL_TO_DINT:
                    case OPCODES.LREAL_TO_LINT:
                    case OPCODES.LREAL_TO_USINT:
                    case OPCODES.LREAL_TO_UINT:
                    case OPCODES.LREAL_TO_UDINT:
                    case OPCODES.LREAL_TO_ULINT:
                    case OPCODES.LREAL_TO_REAL:
                    case OPCODES.LREAL_TO_TIME:
                    case OPCODES.LREAL_TO_DATE:
                    case OPCODES.LREAL_TO_TOD:
                    case OPCODES.LREAL_TO_DT:
                    case OPCODES.TIME_TO_BOOL:
                    case OPCODES.TIME_TO_BYTE:
                    case OPCODES.TIME_TO_WORD:
                    case OPCODES.TIME_TO_DWORD:
                    case OPCODES.TIME_TO_LWORD:
                    case OPCODES.TIME_TO_SINT:
                    case OPCODES.TIME_TO_INT:
                    case OPCODES.TIME_TO_DINT:
                    case OPCODES.TIME_TO_LINT:
                    case OPCODES.TIME_TO_USINT:
                    case OPCODES.TIME_TO_UINT:
                    case OPCODES.TIME_TO_UDINT:
                    case OPCODES.TIME_TO_ULINT:
                    case OPCODES.TIME_TO_REAL:
                    case OPCODES.TIME_TO_LREAL:
                    case OPCODES.DATE_TO_BOOL:
                    case OPCODES.DATE_TO_BYTE:
                    case OPCODES.DATE_TO_WORD:
                    case OPCODES.DATE_TO_DWORD:
                    case OPCODES.DATE_TO_LWORD:
                    case OPCODES.DATE_TO_SINT:
                    case OPCODES.DATE_TO_INT:
                    case OPCODES.DATE_TO_DINT:
                    case OPCODES.DATE_TO_LINT:
                    case OPCODES.DATE_TO_USINT:
                    case OPCODES.DATE_TO_UINT:
                    case OPCODES.DATE_TO_UDINT:
                    case OPCODES.DATE_TO_ULINT:
                    case OPCODES.DATE_TO_REAL:
                    case OPCODES.DATE_TO_LREAL:
                    case OPCODES.DATE_TO_DT:
                    case OPCODES.TOD_TO_BOOL:
                    case OPCODES.TOD_TO_BYTE:
                    case OPCODES.TOD_TO_WORD:
                    case OPCODES.TOD_TO_DWORD:
                    case OPCODES.TOD_TO_LWORD:
                    case OPCODES.TOD_TO_SINT:
                    case OPCODES.TOD_TO_INT:
                    case OPCODES.TOD_TO_DINT:
                    case OPCODES.TOD_TO_LINT:
                    case OPCODES.TOD_TO_USINT:
                    case OPCODES.TOD_TO_UINT:
                    case OPCODES.TOD_TO_UDINT:
                    case OPCODES.TOD_TO_ULINT:
                    case OPCODES.TOD_TO_REAL:
                    case OPCODES.TOD_TO_LREAL:
                    case OPCODES.TOD_TO_DT:
                    case OPCODES.DT_TO_BOOL:
                    case OPCODES.DT_TO_BYTE:
                    case OPCODES.DT_TO_WORD:
                    case OPCODES.DT_TO_DWORD:
                    case OPCODES.DT_TO_LWORD:
                    case OPCODES.DT_TO_SINT:
                    case OPCODES.DT_TO_INT:
                    case OPCODES.DT_TO_DINT:
                    case OPCODES.DT_TO_LINT:
                    case OPCODES.DT_TO_USINT:
                    case OPCODES.DT_TO_UINT:
                    case OPCODES.DT_TO_UDINT:
                    case OPCODES.DT_TO_ULINT:
                    case OPCODES.DT_TO_REAL:
                    case OPCODES.DT_TO_LREAL:
                    case OPCODES.BOOL_AND_BOOL_BOOL:
                    case OPCODES.BYTE_AND_BYTE_BYTE:
                    case OPCODES.WORD_AND_WORD_WORD:
                    case OPCODES.DWORD_AND_DWORD_DWORD:
                    case OPCODES.LWORD_AND_LWORD_LWORD:
                    case OPCODES.BOOL_OR_BOOL_BOOL:
                    case OPCODES.BYTE_OR_BYTE_BYTE:
                    case OPCODES.WORD_OR_WORD_WORD:
                    case OPCODES.DWORD_OR_DWORD_DWORD:
                    case OPCODES.LWORD_OR_LWORD_LWORD:
                    case OPCODES.BOOL_XOR_BOOL_BOOL:
                    case OPCODES.BYTE_XOR_BYTE_BYTE:
                    case OPCODES.WORD_XOR_WORD_WORD:
                    case OPCODES.DWORD_XOR_DWORD_DWORD:
                    case OPCODES.LWORD_XOR_LWORD_LWORD:
                    case OPCODES.BOOL_NOT_BOOL:
                    case OPCODES.BYTE_NOT_BYTE:
                    case OPCODES.WORD_NOT_WORD:
                    case OPCODES.DWORD_NOT_DWORD:
                    case OPCODES.LWORD_NOT_LWORD:
                    case OPCODES.SINT_ADD_SINT_SINT:
                    case OPCODES.INT_ADD_INT_INT:
                    case OPCODES.DINT_ADD_DINT_DINT:
                    case OPCODES.LINT_ADD_LINT_LINT:
                    case OPCODES.USINT_ADD_USINT_USINT:
                    case OPCODES.UINT_ADD_UINT_UINT:
                    case OPCODES.UDINT_ADD_UDINT_UDINT:
                    case OPCODES.ULINT_ADD_ULINT_ULINT:
                    case OPCODES.REAL_ADD_REAL_REAL:
                    case OPCODES.LREAL_ADD_LREAL_LREAL:
                    case OPCODES.TIME_ADD_TIME_TIME:
                    case OPCODES.SINT_MUL_SINT_SINT:
                    case OPCODES.INT_MUL_INT_INT:
                    case OPCODES.DINT_MUL_DINT_DINT:
                    case OPCODES.LINT_MUL_LINT_LINT:
                    case OPCODES.USINT_MUL_USINT_USINT:
                    case OPCODES.UINT_MUL_UINT_UINT:
                    case OPCODES.UDINT_MUL_UDINT_UDINT:
                    case OPCODES.ULINT_MUL_ULINT_ULINT:
                    case OPCODES.REAL_MUL_REAL_REAL:
                    case OPCODES.LREAL_MUL_LREAL_LREAL:
                    case OPCODES.TOD_ADD_TOD_TIME: 
                    case OPCODES.DT_ADD_DT_TIME:   
                    case OPCODES.SINT_SUB_SINT_SINT:
                    case OPCODES.INT_SUB_INT_INT:
                    case OPCODES.DINT_SUB_DINT_DINT:
                    case OPCODES.LINT_SUB_LINT_LINT:
                    case OPCODES.USINT_SUB_USINT_USINT:
                    case OPCODES.UINT_SUB_UINT_UINT:
                    case OPCODES.UDINT_SUB_UDINT_UDINT:
                    case OPCODES.ULINT_SUB_ULINT_ULINT: 
                    case OPCODES.REAL_SUB_REAL_REAL:
                    case OPCODES.LREAL_SUB_LREAL_LREAL:
                    case OPCODES.TIME_SUB_TIME_TIME:
                    case OPCODES.SINT_DIV_SINT_SINT:
                    case OPCODES.INT_DIV_INT_INT:
                    case OPCODES.DINT_DIV_DINT_DINT:
                    case OPCODES.LINT_DIV_LINT_LINT:
                    case OPCODES.USINT_DIV_USINT_USINT:
                    case OPCODES.UINT_DIV_UINT_UINT:
                    case OPCODES.UDINT_DIV_UDINT_UDINT:
                    case OPCODES.ULINT_DIV_ULINT_ULINT:
                    case OPCODES.REAL_DIV_REAL_REAL:
                    case OPCODES.LREAL_DIV_LREAL_LREAL:
                    case OPCODES.TIME_SUB_DATE_DATE:
                    case OPCODES.TOD_SUB_TOD_TIME:
                    case OPCODES.TIME_SUB_TOD_TOD:
                    case OPCODES.DT_SUB_DT_TIME:
                    case OPCODES.TIME_SUB_DT_DT:
                    case OPCODES.TIME_MUL_TIME_SINT:
                    case OPCODES.TIME_MUL_TIME_INT:
                    case OPCODES.TIME_MUL_TIME_DINT:
                    case OPCODES.TIME_MUL_TIME_LINT:
                    case OPCODES.TIME_MUL_TIME_USINT:
                    case OPCODES.TIME_MUL_TIME_UINT:
                    case OPCODES.TIME_MUL_TIME_UDINT:
                    case OPCODES.TIME_MUL_TIME_ULINT:
                    case OPCODES.TIME_MUL_TIME_REAL:
                    case OPCODES.TIME_MUL_TIME_LREAL:
                    case OPCODES.TIME_DIV_TIME_SINT:
                    case OPCODES.TIME_DIV_TIME_INT:
                    case OPCODES.TIME_DIV_TIME_DINT:
                    case OPCODES.TIME_DIV_TIME_LINT:
                    case OPCODES.TIME_DIV_TIME_USINT:
                    case OPCODES.TIME_DIV_TIME_UINT:
                    case OPCODES.TIME_DIV_TIME_UDINT:
                    case OPCODES.TIME_DIV_TIME_ULINT:
                    case OPCODES.TIME_DIV_TIME_REAL:
                    case OPCODES.TIME_DIV_TIME_LREAL:  
                    case OPCODES.SINT_MOD_SINT_SINT:
                    case OPCODES.INT_MOD_INT_INT:
                    case OPCODES.DINT_MOD_DINT_DINT:
                    case OPCODES.LINT_MOD_LINT_LINT:
                    case OPCODES.USINT_MOD_USINT_USINT:
                    case OPCODES.UINT_MOD_UINT_UINT:
                    case OPCODES.UDINT_MOD_UDINT_UDINT:
                    case OPCODES.ULINT_MOD_ULINT_ULINT:
                    case OPCODES.SINT_EXPT_SINT_SINT:
                    case OPCODES.INT_EXPT_INT_INT:
                    case OPCODES.DINT_EXPT_DINT_DINT:
                    case OPCODES.LINT_EXPT_LINT_LINT:
                    case OPCODES.USINT_EXPT_USINT_USINT:
                    case OPCODES.UINT_EXPT_UINT_UINT:
                    case OPCODES.UDINT_EXPT_UDINT_UDINT:
                    case OPCODES.ULINT_EXPT_ULINT_ULINT:
                    case OPCODES.REAL_EXPT_REAL_REAL:
                    case OPCODES.LREAL_EXPT_LREAL_LREAL:
                    case OPCODES.LREAL_SQRT_LREAL:
                    case OPCODES.REAL_SQRT_REAL:
                    case OPCODES.LREAL_LN_LREAL:
                    case OPCODES.REAL_LN_REAL:
                    case OPCODES.LREAL_LOG_LREAL:
                    case OPCODES.REAL_LOG_REAL:
                    case OPCODES.LREAL_EXP_LREAL:
                    case OPCODES.REAL_EXP_REAL:
                    case OPCODES.LREAL_SIN_LREAL:
                    case OPCODES.REAL_SIN_REAL:
                    case OPCODES.LREAL_COS_LREAL:
                    case OPCODES.REAL_COS_REAL:
                    case OPCODES.LREAL_TAN_LREAL:
                    case OPCODES.REAL_TAN_REAL:
                    case OPCODES.LREAL_ASIN_LREAL:
                    case OPCODES.REAL_ASIN_REAL:
                    case OPCODES.LREAL_ACOS_LREAL:
                    case OPCODES.REAL_ACOS_REAL:
                    case OPCODES.LREAL_ATAN_LREAL:
                    case OPCODES.REAL_ATAN_REAL:
                    case OPCODES.SINT_ABS_SINT:
                    case OPCODES.INT_ABS_INT:
                    case OPCODES.DINT_ABS_DINT:
                    case OPCODES.LINT_ABS_LINT:
                    case OPCODES.USINT_ABS_USINT:
                    case OPCODES.UINT_ABS_UINT:
                    case OPCODES.UDINT_ABS_UDINT:
                    case OPCODES.ULINT_ABS_ULINT:
                    case OPCODES.REAL_ABS_REAL:
                    case OPCODES.LREAL_ABS_LREAL:
                    case OPCODES.BYTE_SHL_BYTE_UINT:
                    case OPCODES.WORD_SHL_WORD_UINT:
                    case OPCODES.DWORD_SHL_DWORD_UINT:
                    case OPCODES.LWORD_SHL_LWORD_UINT:
                    case OPCODES.BYTE_SHR_BYTE_UINT:
                    case OPCODES.WORD_SHR_WORD_UINT:
                    case OPCODES.DWORD_SHR_DWORD_UINT:
                    case OPCODES.LWORD_SHR_LWORD_UINT:
                    case OPCODES.BYTE_ROR_BYTE_UINT:
                    case OPCODES.WORD_ROR_WORD_UINT:
                    case OPCODES.DWORD_ROR_DWORD_UINT:
                    case OPCODES.LWORD_ROR_LWORD_UINT:
                    case OPCODES.BYTE_ROL_BYTE_UINT:
                    case OPCODES.WORD_ROL_WORD_UINT:
                    case OPCODES.DWORD_ROL_DWORD_UINT:
                    case OPCODES.LWORD_ROL_LWORD_UINT:
                    case OPCODES.SINT_MAX_SINT_SINT:
                    case OPCODES.INT_MAX_INT_INT:
                    case OPCODES.DINT_MAX_DINT_DINT:
                    case OPCODES.LINT_MAX_LINT_LINT:
                    case OPCODES.USINT_MAX_USINT_USINT:
                    case OPCODES.UINT_MAX_UINT_UINT:
                    case OPCODES.UDINT_MAX_UDINT_UDINT:
                    case OPCODES.ULINT_MAX_ULINT_ULINT:
                    case OPCODES.REAL_MAX_REAL_REAL:
                    case OPCODES.LREAL_MAX_LREAL_LREAL:
                    case OPCODES.TIME_MAX_TIME_TIME:
                    case OPCODES.DATE_MAX_DATE_DATE:
                    case OPCODES.DT_MAX_DT_DT:
                    case OPCODES.TOD_MAX_TOD_TOD:
                    case OPCODES.SINT_MIN_SINT_SINT:
                    case OPCODES.INT_MIN_INT_INT:
                    case OPCODES.DINT_MIN_DINT_DINT:
                    case OPCODES.LINT_MIN_LINT_LINT:
                    case OPCODES.USINT_MIN_USINT_USINT:
                    case OPCODES.UINT_MIN_UINT_UINT:
                    case OPCODES.UDINT_MIN_UDINT_UDINT:
                    case OPCODES.ULINT_MIN_ULINT_ULINT:
                    case OPCODES.REAL_MIN_REAL_REAL:
                    case OPCODES.LREAL_MIN_LREAL_LREAL:
                    case OPCODES.TIME_MIN_TIME_TIME:
                    case OPCODES.DATE_MIN_DATE_DATE:
                    case OPCODES.DT_MIN_DT_DT:
                    case OPCODES.TOD_MIN_TOD_TOD:
                    case OPCODES.SINT_LIMIT_SINT_SINT_SINT:
                    case OPCODES.INT_LIMIT_INT_INT_INT:
                    case OPCODES.DINT_LIMIT_DINT_DINT_DINT:
                    case OPCODES.LINT_LIMIT_LINT_LINT_LINT:
                    case OPCODES.USINT_LIMIT_USINT_USINT_USINT:
                    case OPCODES.UINT_LIMIT_UINT_UINT_UINT:
                    case OPCODES.UDINT_LIMIT_UDINT_UDINT_UDINT:
                    case OPCODES.ULINT_LIMIT_ULINT_ULINT_ULINT:
                    case OPCODES.REAL_LIMIT_REAL_REAL_REAL:
                    case OPCODES.LREAL_LIMIT_LREAL_LREAL_LREAL:
                    case OPCODES.TIME_LIMIT_TIME_TIME_TIME:
                    case OPCODES.DATE_LIMIT_DATE_DATE_DATE:
                    case OPCODES.DT_LIMIT_DT_DT_DT:
                    case OPCODES.TOD_LIMIT_TOD_TOD_TOD:
                    case OPCODES.BOOL_MUX_USINT_BOOL_BOOL:
                    case OPCODES.BYTE_MUX_USINT_BYTE_BYTE:
                    case OPCODES.WORD_MUX_USINT_WORD_WORD:
                    case OPCODES.DWORD_MUX_USINT_DWORD_DWORD:
                    case OPCODES.LWORD_MUX_USINT_LWORD_LWORD:
                    case OPCODES.SINT_MUX_USINT_SINT_SINT:
                    case OPCODES.INT_MUX_USINT_INT_INT:
                    case OPCODES.DINT_MUX_USINT_DINT_DINT:
                    case OPCODES.LINT_MUX_USINT_LINT_LINT:
                    case OPCODES.USINT_MUX_USINT_USINT_USINT:
                    case OPCODES.UINT_MUX_USINT_UINT_UINT:
                    case OPCODES.UDINT_MUX_USINT_UDINT_UDINT:
                    case OPCODES.ULINT_MUX_USINT_ULINT_ULINT:
                    case OPCODES.REAL_MUX_USINT_REAL_REAL:
                    case OPCODES.LREAL_MUX_USINT_LREAL_LREAL:
                    case OPCODES.TIME_MUX_USINT_TIME_TIME:
                    case OPCODES.DATE_MUX_USINT_DATE_DATE:
                    case OPCODES.TOD_MUX_USINT_TOD_TOD:
                    case OPCODES.DT_MUX_USINT_DT_DT:
                    case OPCODES.BOOL_GT_SINT_SINT:
                    case OPCODES.BOOL_GT_INT_INT:
                    case OPCODES.BOOL_GT_DINT_DINT:
                    case OPCODES.BOOL_GT_LINT_LINT:
                    case OPCODES.BOOL_GT_USINT_USINT:
                    case OPCODES.BOOL_GT_UINT_UINT:
                    case OPCODES.BOOL_GT_UDINT_UDINT:
                    case OPCODES.BOOL_GT_ULINT_ULINT:
                    case OPCODES.BOOL_GT_REAL_REAL:
                    case OPCODES.BOOL_GT_LREAL_LREAL:
                    case OPCODES.BOOL_GT_TIME_TIME:
                    case OPCODES.BOOL_GT_DATE_DATE:
                    case OPCODES.BOOL_GT_TOD_TOD:
                    case OPCODES.BOOL_GT_DT_DT:
                    case OPCODES.BOOL_GE_SINT_SINT:
                    case OPCODES.BOOL_GE_INT_INT:
                    case OPCODES.BOOL_GE_DINT_DINT:
                    case OPCODES.BOOL_GE_LINT_LINT:
                    case OPCODES.BOOL_GE_USINT_USINT:
                    case OPCODES.BOOL_GE_UINT_UINT:
                    case OPCODES.BOOL_GE_UDINT_UDINT:
                    case OPCODES.BOOL_GE_ULINT_ULINT:
                    case OPCODES.BOOL_GE_REAL_REAL:
                    case OPCODES.BOOL_GE_LREAL_LREAL:
                    case OPCODES.BOOL_GE_TIME_TIME:
                    case OPCODES.BOOL_GE_DATE_DATE:
                    case OPCODES.BOOL_GE_TOD_TOD:
                    case OPCODES.BOOL_GE_DT_DT:
                    case OPCODES.BOOL_LT_SINT_SINT:
                    case OPCODES.BOOL_LT_INT_INT:
                    case OPCODES.BOOL_LT_DINT_DINT:
                    case OPCODES.BOOL_LT_LINT_LINT:
                    case OPCODES.BOOL_LT_USINT_USINT:
                    case OPCODES.BOOL_LT_UINT_UINT:
                    case OPCODES.BOOL_LT_UDINT_UDINT:
                    case OPCODES.BOOL_LT_ULINT_ULINT:
                    case OPCODES.BOOL_LT_REAL_REAL:
                    case OPCODES.BOOL_LT_LREAL_LREAL:
                    case OPCODES.BOOL_LT_TIME_TIME:
                    case OPCODES.BOOL_LT_DATE_DATE:
                    case OPCODES.BOOL_LT_TOD_TOD:
                    case OPCODES.BOOL_LT_DT_DT:
                    case OPCODES.BOOL_LE_SINT_SINT:
                    case OPCODES.BOOL_LE_INT_INT:
                    case OPCODES.BOOL_LE_DINT_DINT:
                    case OPCODES.BOOL_LE_LINT_LINT:
                    case OPCODES.BOOL_LE_USINT_USINT:
                    case OPCODES.BOOL_LE_UINT_UINT:
                    case OPCODES.BOOL_LE_UDINT_UDINT:
                    case OPCODES.BOOL_LE_ULINT_ULINT:
                    case OPCODES.BOOL_LE_REAL_REAL:
                    case OPCODES.BOOL_LE_LREAL_LREAL:
                    case OPCODES.BOOL_LE_TIME_TIME:
                    case OPCODES.BOOL_LE_DATE_DATE:
                    case OPCODES.BOOL_LE_TOD_TOD:
                    case OPCODES.BOOL_LE_DT_DT:
                    case OPCODES.BOOL_EQ_BOOL_BOOL:
                    case OPCODES.BOOL_EQ_BYTE_BYTE:
                    case OPCODES.BOOL_EQ_WORD_WORD:
                    case OPCODES.BOOL_EQ_DWORD_DWORD:
                    case OPCODES.BOOL_EQ_LWORD_LWORD:
                    case OPCODES.BOOL_EQ_SINT_SINT:
                    case OPCODES.BOOL_EQ_INT_INT:
                    case OPCODES.BOOL_EQ_DINT_DINT:
                    case OPCODES.BOOL_EQ_LINT_LINT:
                    case OPCODES.BOOL_EQ_USINT_USINT:
                    case OPCODES.BOOL_EQ_UINT_UINT:
                    case OPCODES.BOOL_EQ_UDINT_UDINT:
                    case OPCODES.BOOL_EQ_ULINT_ULINT:
                    case OPCODES.BOOL_EQ_REAL_REAL:
                    case OPCODES.BOOL_EQ_LREAL_LREAL:
                    case OPCODES.BOOL_EQ_TIME_TIME:
                    case OPCODES.BOOL_EQ_DATE_DATE:
                    case OPCODES.BOOL_EQ_TOD_TOD:
                    case OPCODES.BOOL_EQ_DT_DT:
                    case OPCODES.BOOL_NE_BOOL_BOOL:
                    case OPCODES.BOOL_NE_BYTE_BYTE:
                    case OPCODES.BOOL_NE_WORD_WORD:
                    case OPCODES.BOOL_NE_DWORD_DWORD:
                    case OPCODES.BOOL_NE_LWORD_LWORD:
                    case OPCODES.BOOL_NE_SINT_SINT:
                    case OPCODES.BOOL_NE_INT_INT:
                    case OPCODES.BOOL_NE_DINT_DINT:
                    case OPCODES.BOOL_NE_LINT_LINT:
                    case OPCODES.BOOL_NE_USINT_USINT:
                    case OPCODES.BOOL_NE_UINT_UINT:
                    case OPCODES.BOOL_NE_UDINT_UDINT:
                    case OPCODES.BOOL_NE_ULINT_ULINT:
                    case OPCODES.BOOL_NE_REAL_REAL:
                    case OPCODES.BOOL_NE_LREAL_LREAL:
                    case OPCODES.BOOL_NE_TIME_TIME:
                    case OPCODES.BOOL_NE_DATE_DATE:
                    case OPCODES.BOOL_NE_TOD_TOD:
                    case OPCODES.BOOL_NE_DT_DT:
                    case OPCODES.BOOL_SEL_BOOL_BOOL_BOOL:
                    case OPCODES.BYTE_SEL_BOOL_BYTE_BYTE:
                    case OPCODES.WORD_SEL_BOOL_WORD_WORD:
                    case OPCODES.DWORD_SEL_BOOL_DWORD_DWORD:
                    case OPCODES.LWORD_SEL_BOOL_LWORD_LWORD:
                    case OPCODES.SINT_SEL_BOOL_SINT_SINT:
                    case OPCODES.INT_SEL_BOOL_INT_INT:
                    case OPCODES.DINT_SEL_BOOL_DINT_DINT:
                    case OPCODES.LINT_SEL_BOOL_LINT_LINT:
                    case OPCODES.USINT_SEL_BOOL_USINT_USINT:
                    case OPCODES.UINT_SEL_BOOL_UINT_UINT:
                    case OPCODES.UDINT_SEL_BOOL_UDINT_UDINT:
                    case OPCODES.ULINT_SEL_BOOL_ULINT_ULINT:
                    case OPCODES.REAL_SEL_BOOL_REAL_REAL:
                    case OPCODES.LREAL_SEL_BOOL_LREAL_LREAL:
                    case OPCODES.TIME_SEL_BOOL_TIME_TIME:
                    case OPCODES.DATE_SEL_BOOL_DATE_DATE:
                    case OPCODES.DT_SEL_BOOL_DT_DT:
                    case OPCODES.TOD_SEL_BOOL_TOD_TOD:
                    case OPCODES.BOOLS_TO_DINT:
                    case OPCODES.UDINT_RGB_DINT_DINT_DINT:
                    case OPCODES.FBD_CALL_ALARMANC:
                    case OPCODES.FBD_CALL_CMP:
                    case OPCODES.FBD_CALL_CTD:
                    case OPCODES.FBD_CALL_CTU:
                    case OPCODES.FBD_CALL_CTUD:
                    case OPCODES.FBD_CALL_DERIVATIVE:
                    case OPCODES.FBD_CALL_F_TRIG:
                    case OPCODES.FBD_CALL_HYSTERESIS:
                    case OPCODES.FBD_CALL_INTEGRAL:
                    case OPCODES.FBD_CALL_LAG:
                    case OPCODES.FBD_CALL_PID:
                    case OPCODES.FBD_CALL_PIDCAS:
                    case OPCODES.FBD_CALL_PIDOVR:
                    case OPCODES.FBD_CALL_R_TRIG:
                    case OPCODES.FBD_CALL_RAMP:
                    case OPCODES.FBD_CALL_RS:
                    case OPCODES.FBD_CALL_RTC:
                    case OPCODES.FBD_CALL_SELPRI:
                    case OPCODES.FBD_CALL_SELREAD:
                    case OPCODES.FBD_CALL_SEMA:
                    case OPCODES.FBD_CALL_SETPRI:
                    case OPCODES.FBD_CALL_SIG_GEN:
                    case OPCODES.FBD_CALL_SPLIT:
                    case OPCODES.FBD_CALL_SR:
                    case OPCODES.FBD_CALL_STACKIN:
                    case OPCODES.FBD_CALL_SWDOUT:
                    case OPCODES.FBD_CALL_SWSOUT:
                    case OPCODES.FBD_CALL_TOF:
                    case OPCODES.FBD_CALL_TON:
                    case OPCODES.FBD_CALL_TP:
                    case OPCODES.FBD_CALL_TPLS:
                    case OPCODES.FBD_CALL_TSTP:
                    case OPCODES.FBD_CALL_WKHOUR:
                    case OPCODES.FBD_CALL_TOTALIZER:
                    case OPCODES.FBD_CALL_RAMP_GEN:
                    case OPCODES.RETURN_VALUE:
                        for (int i = 0; i < Operator.NoOfArg; i++)
                        {
                            switch ((Token_Type)OperandList[i].Token)
                            {
                                case Token_Type.Token_Variable:
                                    OBJECT_LIST crf = new OBJECT_LIST();
                                    crf.ID = OperandList[i].Index;
                                    crf.Type = CRF_LOOKUP_Type.VARIABLE;
                                    crf.ID1 = (long)OperandList[i].PropertyNo;

                                    Lookup.Add(crf);
                                    break;
                            }
                            
                        }
                        break;  
                }
            }
            catch (Exception ex)
            {
                
            }
           

        }


        VALUE MIN(List<OPERAND> _operand, int _noofarg, OPCODES _opcode)
        {
            int i;
            switch (_opcode)
            {

                case OPCODES.SINT_MIN_SINT_SINT:
                    m_val.SINT = GetValue(_operand[1]).SINT;
                    for (i = 2; i < _noofarg; i++)
                    {
                        if (m_val.SINT > GetValue(_operand[i]).SINT)
                        {
                            m_val.SINT = GetValue(_operand[i]).SINT;
                        }
                    }
                    break;
                case OPCODES.INT_MIN_INT_INT:
                    m_val.INT = GetValue(_operand[1]).INT;
                    for (i = 2; i < _noofarg; i++)
                    {
                        if (m_val.INT > GetValue(_operand[i]).INT)
                        {
                            m_val.INT = GetValue(_operand[i]).INT;
                        }
                    }
                    break;
                case OPCODES.DINT_MIN_DINT_DINT:
                    m_val.DINT = GetValue(_operand[1]).DINT;
                    for (i = 2; i < _noofarg; i++)
                    {
                        if (m_val.DINT > GetValue(_operand[i]).DINT)
                        {
                            m_val.DINT = GetValue(_operand[i]).DINT;
                        }
                    }
                    break;
                case OPCODES.LINT_MIN_LINT_LINT:
                    m_val.LINT = GetValue(_operand[1]).LINT;
                    for (i = 2; i < _noofarg; i++)
                    {
                        if (m_val.LINT > GetValue(_operand[i]).LINT)
                        {
                            m_val.LINT = GetValue(_operand[i]).LINT;
                        }
                    }
                    break;
                case OPCODES.USINT_MIN_USINT_USINT:
                    m_val.USINT = GetValue(_operand[1]).USINT;
                    for (i = 2; i < _noofarg; i++)
                    {
                        if (m_val.USINT > GetValue(_operand[i]).USINT)
                        {
                            m_val.USINT = GetValue(_operand[i]).USINT;
                        }
                    }
                    break;
                case OPCODES.UINT_MIN_UINT_UINT:
                    m_val.UINT = GetValue(_operand[1]).UINT;
                    for (i = 2; i < _noofarg; i++)
                    {
                        if (m_val.UINT > GetValue(_operand[i]).UINT)
                        {
                            m_val.UINT = GetValue(_operand[i]).UINT;
                        }
                    }
                    break;
                case OPCODES.UDINT_MIN_UDINT_UDINT:
                    m_val.UDINT = GetValue(_operand[1]).UDINT;
                    for (i = 2; i < _noofarg; i++)
                    {
                        if (m_val.UDINT > GetValue(_operand[i]).UDINT)
                        {
                            m_val.UDINT = GetValue(_operand[i]).UDINT;
                        }
                    }
                    break;
                case OPCODES.ULINT_MIN_ULINT_ULINT:
                    m_val.ULINT = GetValue(_operand[1]).ULINT;
                    for (i = 2; i < _noofarg; i++)
                    {
                        if (m_val.ULINT > GetValue(_operand[i]).ULINT)
                        {
                            m_val.ULINT = GetValue(_operand[i]).ULINT;
                        }
                    }
                    break;
                case OPCODES.REAL_MIN_REAL_REAL:
                    m_val.REAL = GetValue(_operand[1]).REAL;
                    for (i = 2; i < _noofarg; i++)
                    {
                        if (m_val.REAL > GetValue(_operand[i]).REAL)
                        {
                            m_val.REAL = GetValue(_operand[i]).REAL;
                        }
                    }
                    break;
                case OPCODES.LREAL_MIN_LREAL_LREAL:
                    m_val.LREAL = GetValue(_operand[1]).LREAL;
                    for (i = 2; i < _noofarg; i++)
                    {
                        if (m_val.LREAL > GetValue(_operand[i]).LREAL)
                        {
                            m_val.LREAL = GetValue(_operand[i]).LREAL;
                        }
                    }
                    break;
                case OPCODES.TIME_MIN_TIME_TIME:
                    m_val.TIME = GetValue(_operand[1]).TIME;
                    for (i = 2; i < _noofarg; i++)
                    {
                        if (m_val.TIME > GetValue(_operand[i]).TIME)
                        {
                            m_val.TIME = GetValue(_operand[i]).TIME;
                        }
                    }
                    break;
                case OPCODES.DATE_MIN_DATE_DATE:
                    m_val.DATE = GetValue(_operand[1]).DATE;
                    for (i = 2; i < _noofarg; i++)
                    {
                        if (DATE_GT(m_val.DATE, GetValue(_operand[i]).DATE))
                        {
                            m_val.DATE = GetValue(_operand[i]).DATE;
                        }
                    }
                    break;
                case OPCODES.DT_MIN_DT_DT:
                    m_val.DT = GetValue(_operand[1]).DT;
                    for (i = 2; i < _noofarg; i++)
                    {
                        if (DT_GT(m_val.DT, GetValue(_operand[i]).DT))
                        {
                            m_val.DT = GetValue(_operand[i]).DT;
                        }
                    }
                    break;
                case OPCODES.TOD_MIN_TOD_TOD:
                    m_val.TOD = GetValue(_operand[1]).TOD;
                    for (i = 2; i < _noofarg; i++)
                    {
                        if (TOD_GT(m_val.TOD, GetValue(_operand[i]).TOD))
                        {
                            m_val.TOD = GetValue(_operand[i]).TOD;
                        }
                    }
                    break;
            }
            return m_val;
        }

        VALUE MAX(List<OPERAND> _operand, int _noofarg, OPCODES _opcode)
        {
            int i;
            switch (_opcode)
            {

                case OPCODES.SINT_MAX_SINT_SINT:
                    m_val.SINT = GetValue(_operand[1]).SINT;
                    for (i = 2; i < _noofarg; i++)
                    {
                        if (m_val.SINT < GetValue(_operand[i]).SINT)
                        {
                            m_val.SINT = GetValue(_operand[i]).SINT;
                        }
                    }
                    break;
                case OPCODES.INT_MAX_INT_INT:
                    m_val.INT = GetValue(_operand[1]).INT;
                    for (i = 2; i < _noofarg; i++)
                    {
                        if (m_val.INT < GetValue(_operand[i]).INT)
                        {
                            m_val.INT = GetValue(_operand[i]).INT;
                        }
                    }
                    break;
                case OPCODES.DINT_MAX_DINT_DINT:
                    m_val.DINT = GetValue(_operand[1]).DINT;
                    for (i = 2; i < _noofarg; i++)
                    {
                        if (m_val.DINT < GetValue(_operand[i]).DINT)
                        {
                            m_val.DINT = GetValue(_operand[i]).DINT;
                        }
                    }
                    break;
                case OPCODES.LINT_MAX_LINT_LINT:
                    m_val.LINT = GetValue(_operand[1]).LINT;
                    for (i = 2; i < _noofarg; i++)
                    {
                        if (m_val.LINT < GetValue(_operand[i]).LINT)
                        {
                            m_val.LINT = GetValue(_operand[i]).LINT;
                        }
                    }
                    break;
                case OPCODES.USINT_MAX_USINT_USINT:
                    m_val.USINT = GetValue(_operand[1]).USINT;
                    for (i = 2; i < _noofarg; i++)
                    {
                        if (m_val.USINT < GetValue(_operand[i]).USINT)
                        {
                            m_val.USINT = GetValue(_operand[i]).USINT;
                        }
                    }
                    break;
                case OPCODES.UINT_MAX_UINT_UINT:
                    m_val.UINT = GetValue(_operand[1]).UINT;
                    for (i = 2; i < _noofarg; i++)
                    {
                        if (m_val.UINT < GetValue(_operand[i]).UINT)
                        {
                            m_val.UINT = GetValue(_operand[i]).UINT;
                        }
                    }
                    break;
                case OPCODES.UDINT_MAX_UDINT_UDINT:
                    m_val.UDINT = GetValue(_operand[1]).UDINT;
                    for (i = 2; i < _noofarg; i++)
                    {
                        if (m_val.UDINT < GetValue(_operand[i]).UDINT)
                        {
                            m_val.UDINT = GetValue(_operand[i]).UDINT;
                        }
                    }
                    break;
                case OPCODES.ULINT_MAX_ULINT_ULINT:
                    m_val.ULINT = GetValue(_operand[1]).ULINT;
                    for (i = 2; i < _noofarg; i++)
                    {
                        if (m_val.ULINT < GetValue(_operand[i]).ULINT)
                        {
                            m_val.ULINT = GetValue(_operand[i]).ULINT;
                        }
                    }
                    break;
                case OPCODES.REAL_MAX_REAL_REAL:
                    m_val.REAL = GetValue(_operand[1]).REAL;
                    for (i = 2; i < _noofarg; i++)
                    {
                        if (m_val.REAL < GetValue(_operand[i]).REAL)
                        {
                            m_val.REAL = GetValue(_operand[i]).REAL;
                        }
                    }
                    break;
                case OPCODES.LREAL_MAX_LREAL_LREAL:
                    m_val.LREAL = GetValue(_operand[1]).LREAL;
                    for (i = 2; i < _noofarg; i++)
                    {
                        if (m_val.LREAL < GetValue(_operand[i]).LREAL)
                        {
                            m_val.LREAL = GetValue(_operand[i]).LREAL;
                        }
                    }
                    break;
                case OPCODES.TIME_MAX_TIME_TIME:
                    m_val.TIME = GetValue(_operand[1]).TIME;
                    for (i = 2; i < _noofarg; i++)
                    {
                        if (m_val.TIME < GetValue(_operand[i]).TIME)
                        {
                            m_val.TIME = GetValue(_operand[i]).TIME;
                        }
                    }
                    break;
                case OPCODES.DATE_MAX_DATE_DATE:
                    m_val.DATE = GetValue(_operand[1]).DATE;
                    for (i = 2; i < _noofarg; i++)
                    {
                        if (DATE_LT(m_val.DATE, GetValue(_operand[i]).DATE))
                        {
                            m_val.DATE = GetValue(_operand[i]).DATE;
                        }
                    }
                    break;
                case OPCODES.DT_MAX_DT_DT:
                    m_val.DT = GetValue(_operand[1]).DT;
                    for (i = 2; i < _noofarg; i++)
                    {
                        if (DT_LT(m_val.DT, GetValue(_operand[i]).DT))
                        {
                            m_val.DT = GetValue(_operand[i]).DT;
                        }
                    }
                    break;
                case OPCODES.TOD_MAX_TOD_TOD:
                    m_val.TOD = GetValue(_operand[1]).TOD;
                    for (i = 2; i < _noofarg; i++)
                    {
                        if (TOD_LT(m_val.TOD, GetValue(_operand[i]).TOD))
                        {
                            m_val.TOD = GetValue(_operand[i]).TOD;
                        }
                    }
                    break;
            }
            return m_val;
        }

        VALUE GT(List<OPERAND> _operand, int _noofarg, OPCODES _opcode)
        {
            int i;
            m_val.BOOL = true;
            switch (_opcode)
            {
                case OPCODES.BOOL_GT_BOOL_BOOL:

                    //for(i = 1 ; i < _noofarg-1 ; i++)
                    //{
                    //    if(!((int)(GetValue(_operand[i] ).BOOL) > (int)(GetValue(_operand[i+1] ).BOOL)))
                    //    {
                    //        m_val.BOOL= false;
                    //        break;
                    //    }
                    //}
                    break;
                case OPCODES.BOOL_GT_BYTE_BYTE:

                    for (i = 1; i < _noofarg - 1; i++)
                    {
                        if (!(GetValue(_operand[i]).BYTE > GetValue(_operand[i + 1]).BYTE))
                        {
                            m_val.BOOL = false;
                            break;
                        }
                    }
                    break;
                case OPCODES.BOOL_GT_WORD_WORD:

                    for (i = 1; i < _noofarg - 1; i++)
                    {
                        if (!(GetValue(_operand[i]).WORD > GetValue(_operand[i + 1]).WORD))
                        {
                            m_val.BOOL = false;
                            break;
                        }
                    }
                    break;
                case OPCODES.BOOL_GT_DWORD_DWORD:

                    for (i = 1; i < _noofarg - 1; i++)
                    {
                        if (!(GetValue(_operand[i]).DWORD > GetValue(_operand[i + 1]).DWORD))
                        {
                            m_val.BOOL = false;
                            break;
                        }
                    }
                    break;
                case OPCODES.BOOL_GT_LWORD_LWORD: break;
                case OPCODES.BOOL_GT_SINT_SINT:

                    for (i = 1; i < _noofarg - 1; i++)
                    {
                        if (!(GetValue(_operand[i]).SINT > GetValue(_operand[i + 1]).SINT))
                        {
                            m_val.BOOL = false;
                            break;
                        }
                    }
                    break;
                case OPCODES.BOOL_GT_INT_INT:

                    for (i = 1; i < _noofarg - 1; i++)
                    {
                        if (!(GetValue(_operand[i]).INT > GetValue(_operand[i + 1]).INT))
                        {
                            m_val.BOOL = false;
                            break;
                        }
                    }
                    break;
                case OPCODES.BOOL_GT_DINT_DINT:

                    for (i = 1; i < _noofarg - 1; i++)
                    {
                        if (!(GetValue(_operand[i]).DINT > GetValue(_operand[i + 1]).DINT))
                        {
                            m_val.BOOL = false;
                            break;
                        }
                    }
                    break;
                case OPCODES.BOOL_GT_LINT_LINT: break;
                case OPCODES.BOOL_GT_USINT_USINT:

                    for (i = 1; i < _noofarg - 1; i++)
                    {
                        if (!(GetValue(_operand[i]).USINT > GetValue(_operand[i + 1]).USINT))
                        {
                            m_val.BOOL = false;
                            break;
                        }
                    }
                    break;
                case OPCODES.BOOL_GT_UINT_UINT:

                    for (i = 1; i < _noofarg - 1; i++)
                    {
                        if (!(GetValue(_operand[i]).UINT > GetValue(_operand[i + 1]).UINT))
                        {
                            m_val.BOOL = false;
                            break;
                        }
                    }
                    break;
                case OPCODES.BOOL_GT_UDINT_UDINT:

                    for (i = 1; i < _noofarg - 1; i++)
                    {
                        if (!(GetValue(_operand[i]).UDINT > GetValue(_operand[i + 1]).UDINT))
                        {
                            m_val.BOOL = false;
                            break;
                        }
                    }
                    break;
                case OPCODES.BOOL_GT_ULINT_ULINT: break;
                case OPCODES.BOOL_GT_REAL_REAL:
                    for (i = 1; i < _noofarg - 1; i++)
                    {
                        if (!(GetValue(_operand[i]).REAL > GetValue(_operand[i + 1]).REAL))
                        {
                            m_val.BOOL = false;
                            break;
                        }
                    }
                    break;
                case OPCODES.BOOL_GT_LREAL_LREAL:
                    for (i = 1; i < _noofarg - 1; i++)
                    {
                        if (!(GetValue(_operand[i]).LREAL > GetValue(_operand[i + 1]).LREAL))
                        {
                            m_val.BOOL = false;
                            break;
                        }
                    }
                    break;
                case OPCODES.BOOL_GT_TIME_TIME:
                    for (i = 1; i < _noofarg - 1; i++)
                    {
                        if (!(GetValue(_operand[i]).TIME > GetValue(_operand[i + 1]).TIME))
                        {
                            m_val.BOOL = false;
                            break;
                        }
                    }
                    break;
                case OPCODES.BOOL_GT_DATE_DATE:
                    for (i = 1; i < _noofarg - 1; i++)
                    {
                        if (!DATE_GT(GetValue(_operand[i]).DATE, GetValue(_operand[i + 1]).DATE))
                        {
                            m_val.BOOL = false;
                            break;
                        }
                    }
                    break;
                case OPCODES.BOOL_GT_TOD_TOD:
                    for (i = 1; i < _noofarg - 1; i++)
                    {
                        if (!TOD_GT(GetValue(_operand[i]).TOD, GetValue(_operand[i + 1]).TOD))
                        {
                            m_val.BOOL = false;
                            break;
                        }
                    }
                    break;
                case OPCODES.BOOL_GT_DT_DT:
                    for (i = 1; i < _noofarg - 1; i++)
                    {
                        if (!DT_GT(GetValue(_operand[i]).DT, GetValue(_operand[i + 1]).DT))
                        {
                            m_val.BOOL = false;
                            break;
                        }
                    }
                    break;
            }
            return m_val;
        }

        VALUE GE(List<OPERAND> _operand, int _noofarg, OPCODES _opcode)
        {
            int i;
            m_val.BOOL = true;
            switch (_opcode)
            {
                case OPCODES.BOOL_GE_BOOL_BOOL:

                    //for(i = 1 ; i < _noofarg-1 ; i++)
                    //{
                    //    if(!(GetValue(_operand[i] ).BOOL >= GetValue(_operand[i+1] ).BOOL))
                    //    {
                    //        m_val.BOOL= false;
                    //        break;
                    //    }
                    //}
                    break;
                case OPCODES.BOOL_GE_BYTE_BYTE:

                    for (i = 1; i < _noofarg - 1; i++)
                    {
                        if (!(GetValue(_operand[i]).BYTE >= GetValue(_operand[i + 1]).BYTE))
                        {
                            m_val.BOOL = false;
                            break;
                        }
                    }
                    break;
                case OPCODES.BOOL_GE_WORD_WORD:

                    for (i = 1; i < _noofarg - 1; i++)
                    {
                        if (!(GetValue(_operand[i]).WORD >= GetValue(_operand[i + 1]).WORD))
                        {
                            m_val.BOOL = false;
                            break;
                        }
                    }
                    break;
                case OPCODES.BOOL_GE_DWORD_DWORD:

                    for (i = 1; i < _noofarg - 1; i++)
                    {
                        if (!(GetValue(_operand[i]).DWORD >= GetValue(_operand[i + 1]).DWORD))
                        {
                            m_val.BOOL = false;
                            break;
                        }
                    }
                    break;
                case OPCODES.BOOL_GE_LWORD_LWORD: break;
                case OPCODES.BOOL_GE_SINT_SINT:

                    for (i = 1; i < _noofarg - 1; i++)
                    {
                        if (!(GetValue(_operand[i]).SINT >= GetValue(_operand[i + 1]).SINT))
                        {
                            m_val.BOOL = false;
                            break;
                        }
                    }
                    break;
                case OPCODES.BOOL_GE_INT_INT:

                    for (i = 1; i < _noofarg - 1; i++)
                    {
                        if (!(GetValue(_operand[i]).INT >= GetValue(_operand[i + 1]).INT))
                        {
                            m_val.BOOL = false;
                            break;
                        }
                    }
                    break;
                case OPCODES.BOOL_GE_DINT_DINT:

                    for (i = 1; i < _noofarg - 1; i++)
                    {
                        if (!(GetValue(_operand[i]).DINT >= GetValue(_operand[i + 1]).DINT))
                        {
                            m_val.BOOL = false;
                            break;
                        }
                    }
                    break;
                case OPCODES.BOOL_GE_LINT_LINT: break;
                case OPCODES.BOOL_GE_USINT_USINT:

                    for (i = 1; i < _noofarg - 1; i++)
                    {
                        if (!(GetValue(_operand[i]).USINT >= GetValue(_operand[i + 1]).USINT))
                        {
                            m_val.BOOL = false;
                            break;
                        }
                    }
                    break;
                case OPCODES.BOOL_GE_UINT_UINT:

                    for (i = 1; i < _noofarg - 1; i++)
                    {
                        if (!(GetValue(_operand[i]).UINT >= GetValue(_operand[i + 1]).UINT))
                        {
                            m_val.BOOL = false;
                            break;
                        }
                    }
                    break;
                case OPCODES.BOOL_GE_UDINT_UDINT:

                    for (i = 1; i < _noofarg - 1; i++)
                    {
                        if (!(GetValue(_operand[i]).UDINT >= GetValue(_operand[i + 1]).UDINT))
                        {
                            m_val.BOOL = false;
                            break;
                        }
                    }
                    break;
                case OPCODES.BOOL_GE_ULINT_ULINT: break;
                case OPCODES.BOOL_GE_REAL_REAL:
                    for (i = 1; i < _noofarg - 1; i++)
                    {
                        if (!(GetValue(_operand[i]).REAL >= GetValue(_operand[i + 1]).REAL))
                        {
                            m_val.BOOL = false;
                            break;
                        }
                    }
                    break;
                case OPCODES.BOOL_GE_LREAL_LREAL:
                    for (i = 1; i < _noofarg - 1; i++)
                    {
                        if (!(GetValue(_operand[i]).LREAL >= GetValue(_operand[i + 1]).LREAL))
                        {
                            m_val.BOOL = false;
                            break;
                        }
                    }
                    break;
                case OPCODES.BOOL_GE_TIME_TIME:
                    for (i = 1; i < _noofarg - 1; i++)
                    {
                        if (!(GetValue(_operand[i]).TIME >= GetValue(_operand[i + 1]).TIME))
                        {
                            m_val.BOOL = false;
                            break;
                        }
                    }
                    break;
                case OPCODES.BOOL_GE_DATE_DATE:
                    for (i = 1; i < _noofarg - 1; i++)
                    {
                        if (!DATE_GE(GetValue(_operand[i]).DATE, GetValue(_operand[i + 1]).DATE))
                        {
                            m_val.BOOL = false;
                            break;
                        }
                    }
                    break;
                case OPCODES.BOOL_GE_TOD_TOD:
                    for (i = 1; i < _noofarg - 1; i++)
                    {
                        if (!TOD_GE(GetValue(_operand[i]).TOD, GetValue(_operand[i + 1]).TOD))
                        {
                            m_val.BOOL = false;
                            break;
                        }
                    }
                    break;
                case OPCODES.BOOL_GE_DT_DT:
                    for (i = 1; i < _noofarg - 1; i++)
                    {
                        if (!DT_GE(GetValue(_operand[i]).DT, GetValue(_operand[i + 1]).DT))
                        {
                            m_val.BOOL = false;
                            break;
                        }
                    }
                    break;
            }
            return m_val;
        }

        VALUE LT(List<OPERAND> _operand, int _noofarg, OPCODES _opcode)
        {
            int i;
            m_val.BOOL = true;
            switch (_opcode)
            {
                case OPCODES.BOOL_LT_BOOL_BOOL:

                    //for(i = 1 ; i < _noofarg-1 ; i++)
                    //{
                    //    if(!(GetValue(_operand[i] ).BOOL < GetValue(_operand[i+1] ).BOOL))
                    //    {
                    //        m_val.BOOL= false;
                    //        break;
                    //    }
                    //}
                    break;
                case OPCODES.BOOL_LT_BYTE_BYTE:

                    for (i = 1; i < _noofarg - 1; i++)
                    {
                        if (!(GetValue(_operand[i]).BYTE < GetValue(_operand[i + 1]).BYTE))
                        {
                            m_val.BOOL = false;
                            break;
                        }
                    }
                    break;
                case OPCODES.BOOL_LT_WORD_WORD:

                    for (i = 1; i < _noofarg - 1; i++)
                    {
                        if (!(GetValue(_operand[i]).WORD < GetValue(_operand[i + 1]).WORD))
                        {
                            m_val.BOOL = false;
                            break;
                        }
                    }
                    break;
                case OPCODES.BOOL_LT_DWORD_DWORD:

                    for (i = 1; i < _noofarg - 1; i++)
                    {
                        if (!(GetValue(_operand[i]).DWORD < GetValue(_operand[i + 1]).DWORD))
                        {
                            m_val.BOOL = false;
                            break;
                        }
                    }
                    break;
                case OPCODES.BOOL_LT_LWORD_LWORD: break;
                case OPCODES.BOOL_LT_SINT_SINT:

                    for (i = 1; i < _noofarg - 1; i++)
                    {
                        if (!(GetValue(_operand[i]).SINT < GetValue(_operand[i + 1]).SINT))
                        {
                            m_val.BOOL = false;
                            break;
                        }
                    }
                    break;
                case OPCODES.BOOL_LT_INT_INT:

                    for (i = 1; i < _noofarg - 1; i++)
                    {
                        if (!(GetValue(_operand[i]).INT < GetValue(_operand[i + 1]).INT))
                        {
                            m_val.BOOL = false;
                            break;
                        }
                    }
                    break;
                case OPCODES.BOOL_LT_DINT_DINT:

                    for (i = 1; i < _noofarg - 1; i++)
                    {
                        if (!(GetValue(_operand[i]).DINT < GetValue(_operand[i + 1]).DINT))
                        {
                            m_val.BOOL = false;
                            break;
                        }
                    }
                    break;
                case OPCODES.BOOL_LT_LINT_LINT: break;
                case OPCODES.BOOL_LT_USINT_USINT:

                    for (i = 1; i < _noofarg - 1; i++)
                    {
                        if (!(GetValue(_operand[i]).USINT < GetValue(_operand[i + 1]).USINT))
                        {
                            m_val.BOOL = false;
                            break;
                        }
                    }
                    break;
                case OPCODES.BOOL_LT_UINT_UINT:

                    for (i = 1; i < _noofarg - 1; i++)
                    {
                        if (!(GetValue(_operand[i]).UINT < GetValue(_operand[i + 1]).UINT))
                        {
                            m_val.BOOL = false;
                            break;
                        }
                    }
                    break;
                case OPCODES.BOOL_LT_UDINT_UDINT:

                    for (i = 1; i < _noofarg - 1; i++)
                    {
                        if (!(GetValue(_operand[i]).UDINT < GetValue(_operand[i + 1]).UDINT))
                        {
                            m_val.BOOL = false;
                            break;
                        }
                    }
                    break;
                case OPCODES.BOOL_LT_ULINT_ULINT: break;
                case OPCODES.BOOL_LT_REAL_REAL:
                    for (i = 1; i < _noofarg - 1; i++)
                    {
                        if (!(GetValue(_operand[i]).REAL < GetValue(_operand[i + 1]).REAL))
                        {
                            m_val.BOOL = false;
                            break;
                        }
                    }
                    break;
                case OPCODES.BOOL_LT_LREAL_LREAL:
                    for (i = 1; i < _noofarg - 1; i++)
                    {
                        if (!(GetValue(_operand[i]).LREAL < GetValue(_operand[i + 1]).LREAL))
                        {
                            m_val.BOOL = false;
                            break;
                        }
                    }
                    break;
                case OPCODES.BOOL_LT_TIME_TIME:
                    for (i = 1; i < _noofarg - 1; i++)
                    {
                        if (!(GetValue(_operand[i]).TIME < GetValue(_operand[i + 1]).TIME))
                        {
                            m_val.BOOL = false;
                            break;
                        }
                    }
                    break;
                case OPCODES.BOOL_LT_DATE_DATE:
                    for (i = 1; i < _noofarg - 1; i++)
                    {
                        if (!DATE_LT(GetValue(_operand[i]).DATE, GetValue(_operand[i + 1]).DATE))
                        {
                            m_val.BOOL = false;
                            break;
                        }
                    }
                    break;
                case OPCODES.BOOL_LT_TOD_TOD:
                    for (i = 1; i < _noofarg - 1; i++)
                    {
                        if (!TOD_LT(GetValue(_operand[i]).TOD, GetValue(_operand[i + 1]).TOD))
                        {
                            m_val.BOOL = false;
                            break;
                        }
                    }
                    break;
                case OPCODES.BOOL_LT_DT_DT:
                    for (i = 1; i < _noofarg - 1; i++)
                    {
                        if (!DT_LT(GetValue(_operand[i]).DT, GetValue(_operand[i + 1]).DT))
                        {
                            m_val.BOOL = false;
                            break;
                        }
                    }
                    break;
            }
            return m_val;
        }

        VALUE LE(List<OPERAND> _operand, int _noofarg, OPCODES _opcode)
        {
            int i;
            m_val.BOOL = true;
            switch (_opcode)
            {
                case OPCODES.BOOL_LE_BOOL_BOOL:

                    //for(i = 1 ; i < _noofarg-1 ; i++)
                    //{
                    //    if(!(GetValue(_operand[i] ).BOOL <= GetValue(_operand[i+1] ).BOOL))
                    //    {
                    //        m_val.BOOL= false;
                    //        break;
                    //    }
                    //}
                    break;
                case OPCODES.BOOL_LE_BYTE_BYTE:

                    for (i = 1; i < _noofarg - 1; i++)
                    {
                        if (!(GetValue(_operand[i]).BYTE <= GetValue(_operand[i + 1]).BYTE))
                        {
                            m_val.BOOL = false;
                            break;
                        }
                    }
                    break;
                case OPCODES.BOOL_LE_WORD_WORD:

                    for (i = 1; i < _noofarg - 1; i++)
                    {
                        if (!(GetValue(_operand[i]).WORD <= GetValue(_operand[i + 1]).WORD))
                        {
                            m_val.BOOL = false;
                            break;
                        }
                    }
                    break;
                case OPCODES.BOOL_LE_DWORD_DWORD:

                    for (i = 1; i < _noofarg - 1; i++)
                    {
                        if (!(GetValue(_operand[i]).DWORD <= GetValue(_operand[i + 1]).DWORD))
                        {
                            m_val.BOOL = false;
                            break;
                        }
                    }
                    break;
                case OPCODES.BOOL_LE_LWORD_LWORD: break;
                case OPCODES.BOOL_LE_SINT_SINT:

                    for (i = 1; i < _noofarg - 1; i++)
                    {
                        if (!(GetValue(_operand[i]).SINT <= GetValue(_operand[i + 1]).SINT))
                        {
                            m_val.BOOL = false;
                            break;
                        }
                    }
                    break;
                case OPCODES.BOOL_LE_INT_INT:

                    for (i = 1; i < _noofarg - 1; i++)
                    {
                        if (!(GetValue(_operand[i]).INT <= GetValue(_operand[i + 1]).INT))
                        {
                            m_val.BOOL = false;
                            break;
                        }
                    }
                    break;
                case OPCODES.BOOL_LE_DINT_DINT:

                    for (i = 1; i < _noofarg - 1; i++)
                    {
                        if (!(GetValue(_operand[i]).DINT <= GetValue(_operand[i + 1]).DINT))
                        {
                            m_val.BOOL = false;
                            break;
                        }
                    }
                    break;
                case OPCODES.BOOL_LE_LINT_LINT: break;
                case OPCODES.BOOL_LE_USINT_USINT:

                    for (i = 1; i < _noofarg - 1; i++)
                    {
                        if (!(GetValue(_operand[i]).USINT <= GetValue(_operand[i + 1]).USINT))
                        {
                            m_val.BOOL = false;
                            break;
                        }
                    }
                    break;
                case OPCODES.BOOL_LE_UINT_UINT:

                    for (i = 1; i < _noofarg - 1; i++)
                    {
                        if (!(GetValue(_operand[i]).UINT <= GetValue(_operand[i + 1]).UINT))
                        {
                            m_val.BOOL = false;
                            break;
                        }
                    }
                    break;
                case OPCODES.BOOL_LE_UDINT_UDINT:

                    for (i = 1; i < _noofarg - 1; i++)
                    {
                        if (!(GetValue(_operand[i]).UDINT <= GetValue(_operand[i + 1]).UDINT))
                        {
                            m_val.BOOL = false;
                            break;
                        }
                    }
                    break;
                case OPCODES.BOOL_LE_ULINT_ULINT: break;
                case OPCODES.BOOL_LE_REAL_REAL:
                    for (i = 1; i < _noofarg - 1; i++)
                    {
                        if (!(GetValue(_operand[i]).REAL <= GetValue(_operand[i + 1]).REAL))
                        {
                            m_val.BOOL = false;
                            break;
                        }
                    }
                    break;
                case OPCODES.BOOL_LE_LREAL_LREAL:
                    for (i = 1; i < _noofarg - 1; i++)
                    {
                        if (!(GetValue(_operand[i]).LREAL <= GetValue(_operand[i + 1]).LREAL))
                        {
                            m_val.BOOL = false;
                            break;
                        }
                    }
                    break;
                case OPCODES.BOOL_LE_TIME_TIME:
                    for (i = 1; i < _noofarg - 1; i++)
                    {
                        if (!(GetValue(_operand[i]).TIME <= GetValue(_operand[i + 1]).TIME))
                        {
                            m_val.BOOL = false;
                            break;
                        }
                    }
                    break;
                case OPCODES.BOOL_LE_DATE_DATE:
                    for (i = 1; i < _noofarg - 1; i++)
                    {
                        if (!DATE_LE(GetValue(_operand[i]).DATE, GetValue(_operand[i + 1]).DATE))
                        {
                            m_val.BOOL = false;
                            break;
                        }
                    }
                    break;
                case OPCODES.BOOL_LE_TOD_TOD:
                    for (i = 1; i < _noofarg - 1; i++)
                    {
                        if (!TOD_LE(GetValue(_operand[i]).TOD, GetValue(_operand[i + 1]).TOD))
                        {
                            m_val.BOOL = false;
                            break;
                        }
                    }
                    break;
                case OPCODES.BOOL_LE_DT_DT:
                    for (i = 1; i < _noofarg - 1; i++)
                    {
                        if (!DT_LE(GetValue(_operand[i]).DT, GetValue(_operand[i + 1]).DT))
                        {
                            m_val.BOOL = false;
                            break;
                        }
                    }
                    break;
            }
            return m_val;
        }

        VALUE MUX(List<OPERAND> _operand, int _noofarg)
        {
            int i;
            m_val.USINT = GetValue(_operand[1]).USINT;
            if (m_val.USINT < 1)
            {
                i = 1;
            }
            else
            {
                if (m_val.USINT > (_noofarg - 2))
                {
                    i = _noofarg - 2;
                }
                else
                {
                    i = m_val.USINT;
                }
            }
            m_val = GetValue(_operand[i + 1]);
            return m_val;
        }

        VALUE EQ(List<OPERAND> _operand, int _noofarg, OPCODES _opcode)
        {
            int i;
            m_val.BOOL = true;
            switch (_opcode)
            {
                case OPCODES.BOOL_EQ_BOOL_BOOL:
                    for (i = 1; i < _noofarg - 1; i++)
                    {
                        if (!(GetValue(_operand[i]).BOOL == GetValue(_operand[i + 1]).BOOL))
                        {
                            m_val.BOOL = false;
                            break;
                        }
                    }
                    break;
                case OPCODES.BOOL_EQ_BYTE_BYTE:
                    for (i = 1; i < _noofarg - 1; i++)
                    {
                        if (!(GetValue(_operand[i]).BYTE == GetValue(_operand[i + 1]).BYTE))
                        {
                            m_val.BOOL = false;
                            break;
                        }
                    }
                    break;
                case OPCODES.BOOL_EQ_WORD_WORD:
                    for (i = 1; i < _noofarg - 1; i++)
                    {
                        if (!(GetValue(_operand[i]).WORD == GetValue(_operand[i + 1]).WORD))
                        {
                            m_val.BOOL = false;
                            break;
                        }
                    }
                    break;
                case OPCODES.BOOL_EQ_DWORD_DWORD:
                    for (i = 1; i < _noofarg - 1; i++)
                    {
                        if (!(GetValue(_operand[i]).DWORD == GetValue(_operand[i + 1]).DWORD))
                        {
                            m_val.BOOL = false;
                            break;
                        }
                    }
                    break;
                case OPCODES.BOOL_EQ_LWORD_LWORD:
                    for (i = 1; i < _noofarg - 1; i++)
                    {
                        if (!(GetValue(_operand[i]).LWORD == GetValue(_operand[i + 1]).LWORD))
                        {
                            m_val.BOOL = false;
                            break;
                        }
                    }
                    break;
                case OPCODES.BOOL_EQ_SINT_SINT:
                    for (i = 1; i < _noofarg - 1; i++)
                    {
                        if (!(GetValue(_operand[i]).SINT == GetValue(_operand[i + 1]).SINT))
                        {
                            m_val.BOOL = false;
                            break;
                        }
                    }
                    break;
                case OPCODES.BOOL_EQ_INT_INT:
                    for (i = 1; i < _noofarg - 1; i++)
                    {
                        if (!(GetValue(_operand[i]).INT == GetValue(_operand[i + 1]).INT))
                        {
                            m_val.BOOL = false;
                            break;
                        }
                    }
                    break;
                case OPCODES.BOOL_EQ_DINT_DINT:
                    for (i = 1; i < _noofarg - 1; i++)
                    {
                        if (!(GetValue(_operand[i]).DINT == GetValue(_operand[i + 1]).DINT))
                        {
                            m_val.BOOL = false;
                            break;
                        }
                    }
                    break;
                case OPCODES.BOOL_EQ_LINT_LINT:
                    for (i = 1; i < _noofarg - 1; i++)
                    {
                        if (!(GetValue(_operand[i]).LINT == GetValue(_operand[i + 1]).LINT))
                        {
                            m_val.BOOL = false;
                            break;
                        }
                    }
                    break;
                case OPCODES.BOOL_EQ_USINT_USINT:
                    for (i = 1; i < _noofarg - 1; i++)
                    {
                        if (!(GetValue(_operand[i]).USINT == GetValue(_operand[i + 1]).USINT))
                        {
                            m_val.BOOL = false;
                            break;
                        }
                    }
                    break;
                case OPCODES.BOOL_EQ_UINT_UINT:
                    for (i = 1; i < _noofarg - 1; i++)
                    {
                        if (!(GetValue(_operand[i]).UINT == GetValue(_operand[i + 1]).UINT))
                        {
                            m_val.BOOL = false;
                            break;
                        }
                    }
                    break;
                case OPCODES.BOOL_EQ_UDINT_UDINT:
                    for (i = 1; i < _noofarg - 1; i++)
                    {
                        if (!(GetValue(_operand[i]).UDINT == GetValue(_operand[i + 1]).UDINT))
                        {
                            m_val.BOOL = false;
                            break;
                        }
                    }
                    break;
                case OPCODES.BOOL_EQ_ULINT_ULINT:
                    for (i = 1; i < _noofarg - 1; i++)
                    {
                        if (!(GetValue(_operand[i]).ULINT == GetValue(_operand[i + 1]).ULINT))
                        {
                            m_val.BOOL = false;
                            break;
                        }
                    }
                    break;
                case OPCODES.BOOL_EQ_REAL_REAL:
                    for (i = 1; i < _noofarg - 1; i++)
                    {
                        if (!(GetValue(_operand[i]).REAL == GetValue(_operand[i + 1]).REAL))
                        {
                            m_val.BOOL = false;
                            break;
                        }
                    }
                    break;
                case OPCODES.BOOL_EQ_LREAL_LREAL:
                    for (i = 1; i < _noofarg - 1; i++)
                    {
                        if (!(GetValue(_operand[i]).LREAL == GetValue(_operand[i + 1]).LREAL))
                        {
                            m_val.BOOL = false;
                            break;
                        }
                    }
                    break;
                case OPCODES.BOOL_EQ_TIME_TIME:
                    for (i = 1; i < _noofarg - 1; i++)
                    {
                        if (!(GetValue(_operand[i]).TIME == GetValue(_operand[i + 1]).TIME))
                        {
                            m_val.BOOL = false;
                            break;
                        }
                    }
                    break;
                case OPCODES.BOOL_EQ_DATE_DATE:
                    for (i = 1; i < _noofarg - 1; i++)
                    {
                        if (!(GetValue(_operand[i]).DATE.date == GetValue(_operand[i + 1]).DATE.date))
                        {
                            m_val.BOOL = false;
                            break;
                        }
                    }
                    break;
                case OPCODES.BOOL_EQ_TOD_TOD:
                    for (i = 1; i < _noofarg - 1; i++)
                    {
                        if (!(GetValue(_operand[i]).TOD.tod == GetValue(_operand[i + 1]).TOD.tod))
                        {
                            m_val.BOOL = false;
                            break;
                        }
                    }
                    break;
                case OPCODES.BOOL_EQ_DT_DT:
                    for (i = 1; i < _noofarg - 1; i++)
                    {
                        if (!(GetValue(_operand[i]).DT.dt == GetValue(_operand[i + 1]).DT.dt))
                        {
                            m_val.BOOL = false;
                            break;
                        }
                    }
                    break;
            }
            return m_val;
        }

        VALUE NE(List<OPERAND> _operand, OPCODES _opcode)
        {
            //	int i;
            m_val.BOOL = true;
            switch (_opcode)
            {
                case OPCODES.BOOL_NE_BOOL_BOOL:
                    if (GetValue(_operand[1]).BOOL == GetValue(_operand[2]).BOOL)
                    {
                        m_val.BOOL = false;
                    }
                    break;
                case OPCODES.BOOL_NE_BYTE_BYTE:
                    if ((GetValue(_operand[1]).BYTE == GetValue(_operand[2]).BYTE))
                    {
                        m_val.BOOL = false;
                    }
                    break;
                case OPCODES.BOOL_NE_WORD_WORD:
                    if ((GetValue(_operand[1]).WORD == GetValue(_operand[2]).WORD))
                    {
                        m_val.BOOL = false;
                    }
                    break;
                case OPCODES.BOOL_NE_DWORD_DWORD:
                    if ((GetValue(_operand[1]).DWORD == GetValue(_operand[2]).DWORD))
                    {
                        m_val.BOOL = false;
                    }
                    break;
                case OPCODES.BOOL_NE_LWORD_LWORD:
                    if ((GetValue(_operand[1]).LWORD == GetValue(_operand[2]).LWORD))
                    {
                        m_val.BOOL = false;
                    }
                    break;
                case OPCODES.BOOL_NE_SINT_SINT:
                    if ((GetValue(_operand[1]).SINT == GetValue(_operand[2]).SINT))
                    {
                        m_val.BOOL = false;
                    }
                    break;
                case OPCODES.BOOL_NE_INT_INT:
                    if ((GetValue(_operand[1]).INT == GetValue(_operand[2]).INT))
                    {
                        m_val.BOOL = false;
                    }
                    break;
                case OPCODES.BOOL_NE_DINT_DINT:
                    if ((GetValue(_operand[1]).DINT == GetValue(_operand[2]).DINT))
                    {
                        m_val.BOOL = false;
                    }
                    break;
                case OPCODES.BOOL_NE_LINT_LINT:
                    if ((GetValue(_operand[1]).LINT == GetValue(_operand[2]).LINT))
                    {
                        m_val.BOOL = false;
                    }
                    break;
                case OPCODES.BOOL_NE_USINT_USINT:
                    if ((GetValue(_operand[1]).USINT == GetValue(_operand[2]).USINT))
                    {
                        m_val.BOOL = false;
                    }
                    break;
                case OPCODES.BOOL_NE_UINT_UINT:
                    if ((GetValue(_operand[1]).UINT == GetValue(_operand[2]).UINT))
                    {
                        m_val.BOOL = false;
                    }
                    break;
                case OPCODES.BOOL_NE_UDINT_UDINT:
                    if ((GetValue(_operand[1]).UDINT == GetValue(_operand[2]).UDINT))
                    {
                        m_val.BOOL = false;
                    }
                    break;
                case OPCODES.BOOL_NE_ULINT_ULINT:
                    if ((GetValue(_operand[1]).ULINT == GetValue(_operand[2]).ULINT))
                    {
                        m_val.BOOL = false;
                    }
                    break;
                case OPCODES.BOOL_NE_REAL_REAL:
                    if ((GetValue(_operand[1]).REAL == GetValue(_operand[2]).REAL))
                    {
                        m_val.BOOL = false;
                    }
                    break;
                case OPCODES.BOOL_NE_LREAL_LREAL:
                    if ((GetValue(_operand[1]).LREAL == GetValue(_operand[2]).LREAL))
                    {
                        m_val.BOOL = false;
                    }
                    break;
                case OPCODES.BOOL_NE_TIME_TIME:
                    if ((GetValue(_operand[1]).TIME == GetValue(_operand[2]).TIME))
                    {
                        m_val.BOOL = false;
                    }
                    break;
                case OPCODES.BOOL_NE_DATE_DATE:
                    if ((GetValue(_operand[1]).DATE.date == GetValue(_operand[2]).DATE.date))
                    {
                        m_val.BOOL = false;
                    }
                    break;
                case OPCODES.BOOL_NE_TOD_TOD:
                    if ((GetValue(_operand[1]).TOD.tod == GetValue(_operand[2]).TOD.tod))
                    {
                        m_val.BOOL = false;
                    }
                    break;
                case OPCODES.BOOL_NE_DT_DT:
                    if ((GetValue(_operand[1]).DT.dt == GetValue(_operand[2]).DT.dt))
                    {
                        m_val.BOOL = false;
                    }
                    break;
            }
            return m_val;
        }

        VALUE LIMIT(List<OPERAND> _operand, OPCODES _opcode)
        {
            //	int i;
            switch (_opcode)
            {
                case OPCODES.SINT_LIMIT_SINT_SINT_SINT:
                    if (GetValue(_operand[1]).SINT < GetValue(_operand[2]).SINT)
                    {
                        m_val.SINT = GetValue(_operand[2]).SINT;
                    }
                    else
                    {
                        if (GetValue(_operand[1]).SINT > GetValue(_operand[3]).SINT)
                        {
                            m_val.SINT = GetValue(_operand[3]).SINT;
                        }
                        else
                        {
                            m_val.SINT = GetValue(_operand[1]).SINT;
                        }
                    }
                    break;
                case OPCODES.INT_LIMIT_INT_INT_INT:
                    if (GetValue(_operand[1]).INT < GetValue(_operand[2]).INT)
                    {
                        m_val.INT = GetValue(_operand[2]).INT;
                    }
                    else
                    {
                        if (GetValue(_operand[1]).INT > GetValue(_operand[3]).INT)
                        {
                            m_val.INT = GetValue(_operand[3]).INT;
                        }
                        else
                        {
                            m_val.INT = GetValue(_operand[1]).INT;
                        }
                    }
                    break;
                case OPCODES.DINT_LIMIT_DINT_DINT_DINT:
                    if (GetValue(_operand[1]).DINT < GetValue(_operand[2]).DINT)
                    {
                        m_val.DINT = GetValue(_operand[2]).DINT;
                    }
                    else
                    {
                        if (GetValue(_operand[1]).DINT > GetValue(_operand[3]).DINT)
                        {
                            m_val.DINT = GetValue(_operand[3]).DINT;
                        }
                        else
                        {
                            m_val.DINT = GetValue(_operand[1]).DINT;
                        }
                    }
                    break;
                case OPCODES.LINT_LIMIT_LINT_LINT_LINT:
                    if (GetValue(_operand[1]).LINT < GetValue(_operand[2]).LINT)
                    {
                        m_val.LINT = GetValue(_operand[2]).LINT;
                    }
                    else
                    {
                        if (GetValue(_operand[1]).LINT > GetValue(_operand[3]).LINT)
                        {
                            m_val.LINT = GetValue(_operand[3]).LINT;
                        }
                        else
                        {
                            m_val.LINT = GetValue(_operand[1]).LINT;
                        }
                    }
                    break;
                case OPCODES.USINT_LIMIT_USINT_USINT_USINT:
                    if (GetValue(_operand[1]).USINT < GetValue(_operand[2]).USINT)
                    {
                        m_val.USINT = GetValue(_operand[2]).USINT;
                    }
                    else
                    {
                        if (GetValue(_operand[1]).USINT > GetValue(_operand[3]).USINT)
                        {
                            m_val.USINT = GetValue(_operand[3]).USINT;
                        }
                        else
                        {
                            m_val.USINT = GetValue(_operand[1]).USINT;
                        }
                    }
                    break;
                case OPCODES.UINT_LIMIT_UINT_UINT_UINT:
                    if (GetValue(_operand[1]).UINT < GetValue(_operand[2]).UINT)
                    {
                        m_val.UINT = GetValue(_operand[2]).UINT;
                    }
                    else
                    {
                        if (GetValue(_operand[1]).UINT > GetValue(_operand[3]).UINT)
                        {
                            m_val.UINT = GetValue(_operand[3]).UINT;
                        }
                        else
                        {
                            m_val.UINT = GetValue(_operand[1]).UINT;
                        }
                    }
                    break;
                case OPCODES.UDINT_LIMIT_UDINT_UDINT_UDINT:
                    if (GetValue(_operand[1]).UDINT < GetValue(_operand[2]).UDINT)
                    {
                        m_val.UDINT = GetValue(_operand[2]).UDINT;
                    }
                    else
                    {
                        if (GetValue(_operand[1]).UDINT > GetValue(_operand[3]).UDINT)
                        {
                            m_val.UDINT = GetValue(_operand[3]).UDINT;
                        }
                        else
                        {
                            m_val.UDINT = GetValue(_operand[1]).UDINT;
                        }
                    }
                    break;
                case OPCODES.ULINT_LIMIT_ULINT_ULINT_ULINT:
                    if (GetValue(_operand[1]).ULINT < GetValue(_operand[2]).ULINT)
                    {
                        m_val.ULINT = GetValue(_operand[2]).ULINT;
                    }
                    else
                    {
                        if (GetValue(_operand[1]).ULINT > GetValue(_operand[3]).ULINT)
                        {
                            m_val.ULINT = GetValue(_operand[3]).ULINT;
                        }
                        else
                        {
                            m_val.ULINT = GetValue(_operand[1]).ULINT;
                        }
                    }
                    break;
                case OPCODES.REAL_LIMIT_REAL_REAL_REAL:
                    if (GetValue(_operand[1]).REAL < GetValue(_operand[2]).REAL)
                    {
                        m_val.REAL = GetValue(_operand[2]).REAL;
                    }
                    else
                    {
                        if (GetValue(_operand[1]).REAL > GetValue(_operand[3]).REAL)
                        {
                            m_val.REAL = GetValue(_operand[3]).REAL;
                        }
                        else
                        {
                            m_val.REAL = GetValue(_operand[1]).REAL;
                        }
                    }
                    break;
                case OPCODES.LREAL_LIMIT_LREAL_LREAL_LREAL:
                    if (GetValue(_operand[1]).LREAL < GetValue(_operand[2]).LREAL)
                    {
                        m_val.LREAL = GetValue(_operand[2]).LREAL;
                    }
                    else
                    {
                        if (GetValue(_operand[1]).LREAL > GetValue(_operand[3]).LREAL)
                        {
                            m_val.LREAL = GetValue(_operand[3]).LREAL;
                        }
                        else
                        {
                            m_val.LREAL = GetValue(_operand[1]).LREAL;
                        }
                    }
                    break;
                case OPCODES.TIME_LIMIT_TIME_TIME_TIME:
                    if (GetValue(_operand[1]).TIME < GetValue(_operand[2]).TIME)
                    {
                        m_val.TIME = GetValue(_operand[2]).TIME;
                    }
                    else
                    {
                        if (GetValue(_operand[1]).TIME > GetValue(_operand[3]).TIME)
                        {
                            m_val.TIME = GetValue(_operand[3]).TIME;
                        }
                        else
                        {
                            m_val.TIME = GetValue(_operand[1]).TIME;
                        }
                    }
                    break;
                case OPCODES.DATE_LIMIT_DATE_DATE_DATE:
                    if (DATE_LT(GetValue(_operand[1]).DATE, GetValue(_operand[2]).DATE))
                    {
                        m_val.DATE.date = GetValue(_operand[2]).DATE.date;
                    }
                    else
                    {
                        if (DATE_GT(GetValue(_operand[1]).DATE, GetValue(_operand[3]).DATE))
                        {
                            m_val.DATE.date = GetValue(_operand[3]).DATE.date;
                        }
                        else
                        {
                            m_val.DATE.date = GetValue(_operand[1]).DATE.date;
                        }
                    }
                    break;
                case OPCODES.DT_LIMIT_DT_DT_DT:
                    if (DT_LT(GetValue(_operand[1]).DT, GetValue(_operand[2]).DT))
                    {
                        m_val.DT.dt = GetValue(_operand[2]).DT.dt;
                    }
                    else
                    {
                        if (DT_GT(GetValue(_operand[1]).DT, GetValue(_operand[3]).DT))
                        {
                            m_val.DT.dt = GetValue(_operand[3]).DT.dt;
                        }
                        else
                        {
                            m_val.DT.dt = GetValue(_operand[1]).DT.dt;
                        }
                    }
                    break;
                case OPCODES.TOD_LIMIT_TOD_TOD_TOD:
                    if (TOD_LT(GetValue(_operand[1]).TOD, GetValue(_operand[2]).TOD))
                    {
                        m_val.TOD.tod = GetValue(_operand[2]).TOD.tod;
                    }
                    else
                    {
                        if (TOD_GT(GetValue(_operand[1]).TOD, GetValue(_operand[3]).TOD))
                        {
                            m_val.TOD.tod = GetValue(_operand[3]).TOD.tod;
                        }
                        else
                        {
                            m_val.TOD.tod = GetValue(_operand[1]).TOD.tod;
                        }
                    }
                    break;
            }
            return m_val;
        }

        VALUE AND(List<OPERAND> _operand, int _noofarg, OPCODES _opcode)
        {
            int i;

            switch (_opcode)
            {
                case OPCODES.BOOL_AND_BOOL_BOOL:
                    m_val.BOOL = true;
                    for (i = 1; i < _noofarg; i++)
                    {
                        m_val.BOOL = (GetValue(_operand[i]).BOOL && m_val.BOOL);
                    }
                    break;
                case OPCODES.BYTE_AND_BYTE_BYTE:
                    m_val.BYTE = 0xff;
                    for (i = 1; i < _noofarg; i++)
                    {
                        m_val.BYTE = (byte)((int)GetValue(_operand[i]).BYTE & (int)m_val.BYTE);
                    }
                    break;
                case OPCODES.WORD_AND_WORD_WORD:
                    m_val.WORD = 0xffff;
                    for (i = 1; i < _noofarg; i++)
                    {
                        m_val.WORD = (ushort)((int)GetValue(_operand[i]).WORD & (int)m_val.WORD);
                    }
                    break;
                case OPCODES.DWORD_AND_DWORD_DWORD:
                    m_val.DWORD = 0xffffffff;
                    for (i = 1; i < _noofarg; i++)
                    {
                        m_val.DWORD = (GetValue(_operand[i]).DWORD & m_val.DWORD);
                    }
                    break;
                case OPCODES.LWORD_AND_LWORD_LWORD:
                    m_val.LWORD = 0xffffffffffffffff;
                    for (i = 1; i < _noofarg; i++)
                    {
                        m_val.LWORD = (GetValue(_operand[i]).LWORD & m_val.LWORD);
                    }
                    break;
            }
            return m_val;

        }

        VALUE OR(List<OPERAND> _operand, int _noofarg, OPCODES _opcode)
        {
            int i;
            switch (_opcode)
            {
                case OPCODES.BOOL_OR_BOOL_BOOL:
                    m_val.BOOL = false;
                    for (i = 1; i < _noofarg; i++)
                    {
                        m_val.BOOL = (GetValue(_operand[i]).BOOL || m_val.BOOL);
                    }
                    break;
                case OPCODES.BYTE_OR_BYTE_BYTE:
                    m_val.BYTE = 0;
                    for (i = 1; i < _noofarg; i++)
                    {
                        m_val.BYTE = (byte)((uint)GetValue(_operand[i]).BYTE | (uint)m_val.BYTE);
                    }
                    break;
                case OPCODES.WORD_OR_WORD_WORD:
                    m_val.WORD = 0;
                    for (i = 1; i < _noofarg; i++)
                    {
                        m_val.WORD = (ushort)((uint)GetValue(_operand[i]).WORD | (uint)m_val.WORD);
                    }
                    break;
                case OPCODES.DWORD_OR_DWORD_DWORD:
                    m_val.DWORD = 0;
                    for (i = 1; i < _noofarg; i++)
                    {
                        m_val.DWORD = (GetValue(_operand[i]).DWORD | m_val.DWORD);
                    }
                    break;
                case OPCODES.LWORD_OR_LWORD_LWORD:
                    m_val.LWORD = 0;
                    for (i = 1; i < _noofarg; i++)
                    {
                        m_val.LWORD = (GetValue(_operand[i]).LWORD | m_val.LWORD);
                    }
                    break;
            }
            return m_val;

        }


        #region TIME Compare
        bool DT_GT(dt_t dt1, dt_t dt2)
        {
            if (dt1.Year > dt2.Year)
            {
                return true;
            }
            else
            {
                if (dt1.Year < dt2.Year)
                {
                    return false;
                }
                else
                {
                    if (dt1.Month > dt2.Month)
                    {
                        return true;
                    }
                    else
                    {
                        if (dt1.Month < dt2.Month)
                        {
                            return false;
                        }
                        else
                        {
                            if (dt1.Day > dt2.Day)
                            {
                                return true;
                            }
                            else
                            {
                                if (dt1.Day < dt2.Day)
                                {
                                    return false;
                                }
                                else
                                {
                                    if (dt1.Hour > dt2.Hour)
                                    {
                                        return true;
                                    }
                                    else
                                    {
                                        if (dt1.Hour < dt2.Hour)
                                        {
                                            return false;
                                        }
                                        else
                                        {
                                            if (dt1.Minute > dt2.Minute)
                                            {
                                                return true;
                                            }
                                            else
                                            {
                                                if (dt1.Minute < dt2.Minute)
                                                {
                                                    return false;
                                                }
                                                else
                                                {
                                                    if (dt1.Second > dt2.Second)
                                                    {
                                                        return true;
                                                    }
                                                    else
                                                    {
                                                        return false;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        bool DT_LT(dt_t dt1, dt_t dt2)
        {
            if (dt1.Year < dt2.Year)
            {
                return true;
            }
            else
            {
                if (dt1.Year > dt2.Year)
                {
                    return false;
                }
                else
                {
                    if (dt1.Month < dt2.Month)
                    {
                        return true;
                    }
                    else
                    {
                        if (dt1.Month > dt2.Month)
                        {
                            return false;
                        }
                        else
                        {
                            if (dt1.Day < dt2.Day)
                            {
                                return true;
                            }
                            else
                            {
                                if (dt1.Day > dt2.Day)
                                {
                                    return false;
                                }
                                else
                                {
                                    if (dt1.Hour < dt2.Hour)
                                    {
                                        return true;
                                    }
                                    else
                                    {
                                        if (dt1.Hour > dt2.Hour)
                                        {
                                            return false;
                                        }
                                        else
                                        {
                                            if (dt1.Minute < dt2.Minute)
                                            {
                                                return true;
                                            }
                                            else
                                            {
                                                if (dt1.Minute > dt2.Minute)
                                                {
                                                    return false;
                                                }
                                                else
                                                {
                                                    if (dt1.Second < dt2.Second)
                                                    {
                                                        return true;
                                                    }
                                                    else
                                                    {
                                                        return false;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        bool DT_GE(dt_t dt1, dt_t dt2)
        {
            if (dt1.Year > dt2.Year)
            {
                return true;
            }
            else
            {
                if (dt1.Year < dt2.Year)
                {
                    return false;
                }
                else
                {
                    if (dt1.Month > dt2.Month)
                    {
                        return true;
                    }
                    else
                    {
                        if (dt1.Month < dt2.Month)
                        {
                            return false;
                        }
                        else
                        {
                            if (dt1.Day > dt2.Day)
                            {
                                return true;
                            }
                            else
                            {
                                if (dt1.Day < dt2.Day)
                                {
                                    return false;
                                }
                                else
                                {
                                    if (dt1.Hour > dt2.Hour)
                                    {
                                        return true;
                                    }
                                    else
                                    {
                                        if (dt1.Hour < dt2.Hour)
                                        {
                                            return false;
                                        }
                                        else
                                        {
                                            if (dt1.Minute > dt2.Minute)
                                            {
                                                return true;
                                            }
                                            else
                                            {
                                                if (dt1.Minute < dt2.Minute)
                                                {
                                                    return false;
                                                }
                                                else
                                                {
                                                    if (dt1.Second >= dt2.Second)
                                                    {
                                                        return true;
                                                    }
                                                    else
                                                    {
                                                        return false;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        bool DT_LE(dt_t dt1, dt_t dt2)
        {
            if (dt1.Year < dt2.Year)
            {
                return true;
            }
            else
            {
                if (dt1.Year > dt2.Year)
                {
                    return false;
                }
                else
                {
                    if (dt1.Month < dt2.Month)
                    {
                        return true;
                    }
                    else
                    {
                        if (dt1.Month > dt2.Month)
                        {
                            return false;
                        }
                        else
                        {
                            if (dt1.Day < dt2.Day)
                            {
                                return true;
                            }
                            else
                            {
                                if (dt1.Day > dt2.Day)
                                {
                                    return false;
                                }
                                else
                                {
                                    if (dt1.Hour < dt2.Hour)
                                    {
                                        return true;
                                    }
                                    else
                                    {
                                        if (dt1.Hour > dt2.Hour)
                                        {
                                            return false;
                                        }
                                        else
                                        {
                                            if (dt1.Minute < dt2.Minute)
                                            {
                                                return true;
                                            }
                                            else
                                            {
                                                if (dt1.Minute > dt2.Minute)
                                                {
                                                    return false;
                                                }
                                                else
                                                {
                                                    if (dt1.Second <= dt2.Second)
                                                    {
                                                        return true;
                                                    }
                                                    else
                                                    {
                                                        return false;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        bool DATE_GT(date_type dt1, date_type dt2)
        {
            if (dt1.Year > dt2.Year)
            {
                return true;
            }
            else
            {
                if (dt1.Year < dt2.Year)
                {
                    return false;
                }
                else
                {
                    if (dt1.Month > dt2.Month)
                    {
                        return true;
                    }
                    else
                    {
                        if (dt1.Month < dt2.Month)
                        {
                            return false;
                        }
                        else
                        {
                            if (dt1.Day > dt2.Day)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
            }
        }

        bool DATE_LT(date_type dt1, date_type dt2)
        {
            if (dt1.Year < dt2.Year)
            {
                return true;
            }
            else
            {
                if (dt1.Year > dt2.Year)
                {
                    return false;
                }
                else
                {
                    if (dt1.Month < dt2.Month)
                    {
                        return true;
                    }
                    else
                    {
                        if (dt1.Month > dt2.Month)
                        {
                            return false;
                        }
                        else
                        {
                            if (dt1.Day < dt2.Day)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
            }
        }

        bool DATE_GE(date_type dt1, date_type dt2)
        {
            if (dt1.Year > dt2.Year)
            {
                return true;
            }
            else
            {
                if (dt1.Year < dt2.Year)
                {
                    return false;
                }
                else
                {
                    if (dt1.Month > dt2.Month)
                    {
                        return true;
                    }
                    else
                    {
                        if (dt1.Month < dt2.Month)
                        {
                            return false;
                        }
                        else
                        {
                            if (dt1.Day >= dt2.Day)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
            }
        }

        bool DATE_LE(date_type dt1, date_type dt2)
        {
            if (dt1.Year < dt2.Year)
            {
                return true;
            }
            else
            {
                if (dt1.Year > dt2.Year)
                {
                    return false;
                }
                else
                {
                    if (dt1.Month < dt2.Month)
                    {
                        return true;
                    }
                    else
                    {
                        if (dt1.Month > dt2.Month)
                        {
                            return false;
                        }
                        else
                        {
                            if (dt1.Day < dt2.Day)
                            {
                                return true;
                            }
                            else
                            {
                                if (dt1.Day >= dt2.Day)
                                {
                                    return false;
                                }
                                else
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
        }

        bool TOD_GT(tod_t dt1, tod_t dt2)
        {

            if (dt1.Hour > dt2.Hour)
            {
                return true;
            }
            else
            {
                if (dt1.Hour < dt2.Hour)
                {
                    return false;
                }
                else
                {
                    if (dt1.Minute > dt2.Minute)
                    {
                        return true;
                    }
                    else
                    {
                        if (dt1.Minute < dt2.Minute)
                        {
                            return false;
                        }
                        else
                        {
                            if (dt1.Second > dt2.Second)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
            }
        }


        bool TOD_LT(tod_t dt1, tod_t dt2)
        {
            if (dt1.Hour < dt2.Hour)
            {
                return true;
            }
            else
            {
                if (dt1.Hour > dt2.Hour)
                {
                    return false;
                }
                else
                {
                    if (dt1.Minute < dt2.Minute)
                    {
                        return true;
                    }
                    else
                    {
                        if (dt1.Minute > dt2.Minute)
                        {
                            return false;
                        }
                        else
                        {
                            if (dt1.Second < dt2.Second)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
            }
        }


        bool TOD_GE(tod_t dt1, tod_t dt2)
        {
            if (dt1.Hour > dt2.Hour)
            {
                return true;
            }
            else
            {
                if (dt1.Hour < dt2.Hour)
                {
                    return false;
                }
                else
                {
                    if (dt1.Minute > dt2.Minute)
                    {
                        return true;
                    }
                    else
                    {
                        if (dt1.Minute < dt2.Minute)
                        {
                            return false;
                        }
                        else
                        {
                            if (dt1.Second >= dt2.Second)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
            }
        }


        bool TOD_LE(tod_t dt1, tod_t dt2)
        {

            if (dt1.Hour < dt2.Hour)
            {
                return true;
            }
            else
            {
                if (dt1.Hour > dt2.Hour)
                {
                    return false;
                }
                else
                {
                    if (dt1.Minute < dt2.Minute)
                    {
                        return true;
                    }
                    else
                    {
                        if (dt1.Minute > dt2.Minute)
                        {
                            return false;
                        }
                        else
                        {
                            if (dt1.Second <= dt2.Second)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
            }
        }

        #endregion

#endif

    }
}
