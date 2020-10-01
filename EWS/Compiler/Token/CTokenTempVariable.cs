using DCS;
using DCS.DCSTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DCS.Compile.Token
{
    class CTokenTempVariable : CTokenOperand
    {
        //public int type;
        //public long index;
        public CTokenTempVariable()
        {
            m_token = Token_Type.Token_TempValue;

        }


        public CTokenTempVariable(String _str)
            : base(_str)
        {
            m_token = Token_Type.Token_TempValue;
        }

        public void AddRetrunOperator(ref TICInstruction _instruction)
        {
            _instruction.Operator.NoOfArg = 1;
            _instruction.Operator.OpCode = (int)OPCODES.RETURN_VALUE;
            _instruction.Operator.ReturnType = m_Type;
            _instruction.OperandList.Add(GetFinalOperator(this));


        }
        //public void Print()
        //{
        //    Console .WriteLine (m_str);
        //    Console .WriteLine(m_VarName);
        //    Console .WriteLine(m_Property);
        //    Console .WriteLine ();
        //}


        //public override int GetTokenPinType()
        //{
        //    return type;
        //}
    }
}



