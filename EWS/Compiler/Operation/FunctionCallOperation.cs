using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DCS.Compile.Operation
{
    class FunctionCallOperation : SimpleOperation
    {
        public FunctionCallOperation()
        {
            
        }
        string functioncallstring = "";



        public string FunctionCallString
        {
            get
            {
                return functioncallstring;
            }
            set
            {
                functioncallstring = value;
            }
        }
    }
}
