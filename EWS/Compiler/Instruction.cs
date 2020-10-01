using DCS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace DCS.Compile
{
    public class Instruction
    {
        public List<OPERAND> OperandList = new List<OPERAND>();
        public OPERATOR Operator = new OPERATOR();
        public Instruction()
        {

        }
        public int Size()
        {
           // OPERATION op = new OPERATION();
            int s = 0;
            //s = Marshal.SizeOf(op);
            s = Marshal.SizeOf(Operator);
            if (OperandList.Count > 0)
            {
                s += (OperandList.Count * Marshal.SizeOf(OperandList[0]));
            }

            return s;
        }

    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                   