using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DCS.Compile.Operation
{
    class FunctionBlockCallOperation : SimpleOperation
    {
        public FunctionBlockCallOperation()
        {
            
        }

        string functionblockcallstring = "";



        public string FunctionBlockCallString
        {
            get
            {
                return functionblockcallstring;
            }
            set
            {
                functionblockcallstring = value;
            }
        }
    }
}
