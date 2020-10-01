using DCS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace DCS.Compile.Operation
{
    class IfOperation : SimpleOperation
    {
        
        
        public IfOperation()
        {
            
        }
        public SimpleOperation QString = new SimpleOperation();
        

        public List<SimpleOperation> ThenOperations = new List<SimpleOperation>();

        public List<SimpleOperation> ElseOperations = new List<SimpleOperation>();
        public bool GetCondition(string _str)
        {
            bool ret = false;
            string str = _str.Substring(2);
            str = str.ToLower();
            str = str.Trim();
            if (str.EndsWith(";"))
            {
                str = str.Substring(0, str.Length - 1);
            }
            str = str.Trim();
            if (str.EndsWith("then"))
            {
                QString.OperationString = str.Substring(0, str.Length - 4);
                QString.OperationString = QString.OperationString.Trim();
                ret = true;
            }
            return ret;
        }

        public override int Size1()
        {
            int s = QString.Size1();
            //int count = ThenOperations.Count;
            if (ThenOperations != null)
            {
                foreach (SimpleOperation sp in ThenOperations)
                {
                    s += sp.Size1();
                }
            }
            if (ElseOperations != null)
            {
                foreach (SimpleOperation sp in ElseOperations)
                {
                    s += sp.Size1();
                }
            }
            return s;
        }


        public override int Size()
        {
            int logicprogramSize = 0;
            OPERATION op = new OPERATION();
            logicprogramSize += Marshal.SizeOf(op);
            logicprogramSize += QSize();
            logicprogramSize += ThenSize();
            logicprogramSize += ElseSize();
            return logicprogramSize;
        }


        public int QSize()
        {
            return QString.Size();
        }

        public int ThenSize()
        {
            int logicprogramSize = 0;

            if (ThenOperations != null)
            {
                foreach (SimpleOperation sp in ThenOperations)
                {
                    logicprogramSize += sp.Size();
                }
            }
            return logicprogramSize;
        }
        public int ElseSize()
        {
            int logicprogramSize = 0;

            if (ElseOperations != null)
            {
                foreach (SimpleOperation sp in ElseOperations)
                {
                    logicprogramSize += sp.Size();
                }
            }
            
            return logicprogramSize;
        }
        public override bool Write2File(BinaryWriter bw)
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

        public override bool Write2File_Instructions(BinaryWriter bw)
        {
            try
            {
                QString.Write2File(bw);
                if (ThenOperations != null)
                {
                    foreach (SimpleOperation sp in ThenOperations)
                    {
                        sp.Write2File(bw);
                    }
                }
                if (ElseOperations != null)
                {
                    foreach (SimpleOperation sp in ElseOperations)
                    {
                        sp.Write2File(bw);
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
        public override bool Write2File_OPERATION(BinaryWriter bw)
        {
            try
            {
                OPERATION _operation = new OPERATION();
                StructFile sf_operation = new StructFile(typeof(OPERATION));
                _operation.Size1 = QSize();
                _operation.Size2 = ThenSize();
                _operation.Size3 = ElseSize();
                _operation.operationType = (int)OPERATION_TYPE.IF_ELSE_OPERATION;
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
        
    }
}
