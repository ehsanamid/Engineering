using DCS;
using DCS.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace DCS.Compile.Operation
{
    public class SimpleOperation
    {
        ErrorInfo _errorinfo = new ErrorInfo();
        public ErrorInfo errorinfo
        {
            get
            {
                return _errorinfo;
            }
            set
            {
                _errorinfo = value;
            }
        }
        private string debuginfo;
        public string DebugInfo
        {
            get
            {
                return debuginfo;
            }
            set
            {
                debuginfo = value;
            }
        }
        string operationstring = "";
        public List<TICInstruction> instructionlist = new List<TICInstruction>();

        public string OperationString
        {
            get
            {
                return operationstring;
            }
            set
            {
                operationstring = value;
            }
        }

        public SimpleOperation()
        {
            
        }

        public virtual int Size1()
        {
            int s = 0;
            int count = instructionlist.Count;
            foreach (TICInstruction instruction in instructionlist)
            {
                s += instruction.Size();
            }


             OPERATION op = new OPERATION();
            s += Marshal.SizeOf(op);
            return s;
        }

        public virtual int Size()
        {
            int logicprogramSize = 0;
            StructFile sf1 = new StructFile(typeof(OPERATOR));
            StructFile sf2 = new StructFile(typeof(OPERAND));
            OPERATION op = new OPERATION();
            logicprogramSize += Marshal.SizeOf(op);

            for (int j = 0; j < instructionlist.Count; j++)
            {
                logicprogramSize += sf1.SizeofStructure((object)instructionlist[j].Operator);

                for (int k = 0; k < instructionlist[j].OperandList.Count; k++)
                {
                    logicprogramSize += sf2.SizeofStructure((object)instructionlist[j].OperandList[k]);
                }
            }
               
           
            return logicprogramSize;
        }
        public virtual bool Write2File(BinaryWriter bw)
        {

            if (Write2File_OPERATION(bw))
            {
                if (Write2File_Instructions(bw))
                {
                    return true;
                }
            }
            return false;
            
        }

        public virtual bool Write2Buffer(ref List<byte> bf)
        {

            if (Write2Buffer_OPERATION(ref bf))
            {
                if (Write2buffer_Instructions(ref bf))
                {
                    return true;
                }
            }
            return false;

        }

        public virtual bool Write2File_Instructions(BinaryWriter bw)
        {
            try
            {
                StructFile sf_operator;
                OPERAND _operand;
                for (int j = 0; j < instructionlist.Count; j++)
                {
                    sf_operator = new StructFile(typeof(OPERATOR));
                    OPERATOR _operator = instructionlist[j].Operator;
                    _operator.ReturnType = Common.ntohi(_operator.ReturnType);
                    _operator.OpCode = Common.ntohi(_operator.OpCode);
                    _operator.Res2 = 2;
                    _operator.Res3 = 3;
                    sf_operator.WriteStructure(bw, (object)_operator);

                    for (int k = 0; k < instructionlist[j].OperandList.Count; k++)
                    {
                        sf_operator = new StructFile(typeof(OPERAND));
                        _operand = instructionlist[j].OperandList[k];
                        _operand.Index = Common.ntohl(_operand.Index);
                        instructionlist[j].OperandList[k] = _operand;
                        sf_operator.WriteStructure(bw, (object)instructionlist[j].OperandList[k]);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }


        public virtual bool Write2buffer_Instructions(ref List<byte> bf)
        {
            try
            {
                StructFile sf_operator;
                OPERAND _operand;
                for (int j = 0; j < instructionlist.Count; j++)
                {
                    sf_operator = new StructFile(typeof(OPERATOR));
                    OPERATOR _operator = instructionlist[j].Operator;
                    //_operator.ReturnType = Common.ntohi(_operator.ReturnType);
                    //_operator.OpCode = Common.ntohi(_operator.OpCode);
                    _operator.Res2 = 2;
                    _operator.Res3 = 3;
                    sf_operator.WriteStructure(ref bf, (object)_operator);

                    for (int k = 0; k < instructionlist[j].OperandList.Count; k++)
                    {
                        sf_operator = new StructFile(typeof(OPERAND));
                        _operand = instructionlist[j].OperandList[k];
                        //_operand.Index = Common.ntohl(_operand.Index);
                        instructionlist[j].OperandList[k] = _operand;
                        sf_operator.WriteStructure(ref bf, (object)instructionlist[j].OperandList[k]);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }


        public virtual bool Write2Buffer_OPERATION(ref List<byte> bf)
        {
            try
            {
                OPERATION _operation = new OPERATION();
                StructFile sf_operation = new StructFile(typeof(OPERATION));
                _operation.Size1 = Size();
                _operation.Size2 = 0;
                _operation.Size3 = 0;
                _operation.operationType = (int)OPERATION_TYPE.SIMPLE_OPERATION;
                //_operation.Size1 = Common.ntohi(_operation.Size1);
                //_operation.Size2 = Common.ntohi(_operation.Size2);
                //_operation.Size3 = Common.ntohi(_operation.Size3);
                sf_operation.WriteStructure(ref bf, (object)_operation);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public virtual bool Write2File_OPERATION(BinaryWriter bw)
        {
            try
            {
                OPERATION _operation = new OPERATION();
                StructFile sf_operation = new StructFile(typeof(OPERATION));
                _operation.Size1 = Size();
                _operation.Size2 = 0;
                _operation.Size3 = 0;
                _operation.operationType = (int)OPERATION_TYPE.SIMPLE_OPERATION;
                _operation.Size1 = Common.ntohi(_operation.Size1);
                _operation.Size2 = Common.ntohi(_operation.Size2);
                _operation.Size3 = Common.ntohi(_operation.Size3);
                sf_operation.WriteStructure(bw, (object)_operation);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

#if OWSAPP
        public VALUE RUNCondition()
        {
            VALUE m_val = new VALUE();
            m_val.BOOL = false;
            for (int i = 0; i < instructionlist.Count; i++)
            {
                m_val.BOOL = instructionlist[i].RunInstruction().BOOL;
            }
            return m_val;
        }
        public void ScanCondition(ref CrossReference lookup)
        {
            for (int i = 0; i < instructionlist.Count; i++)
            {
                instructionlist[i].ScanInstruction(ref lookup);
            }
        }
#endif

        
    }
}
