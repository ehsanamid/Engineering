using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DCS.Compile.Operation
{
    class WhileOperation : SimpleOperation
    {
        public WhileOperation()
        {
            
        }
        string qstring = "";
        public string QString
        {
            get
            {
                return qstring;
            }
            set
            {
                qstring = value;
            }
        }

        public bool GetCondition(string _str)
        {
            bool ret = false;
            string str = _str.Substring(5);
            str = str.ToLower();
            str = str.Trim();
            if (str.EndsWith(";"))
            {
                str = str.Substring(0, str.Length - 1);
            }
            str = str.Trim();
            if (str.EndsWith("do"))
            {
                QString = str.Substring(0, str.Length - 2);
                QString = QString.Trim();
                ret = true;
            }
            return ret;
        }

        public List<SimpleOperation> WhileOperations = new List<SimpleOperation>();
    }
}
