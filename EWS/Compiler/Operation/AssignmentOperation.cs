using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DCS.Compile.Operation
{
    public class AssignmentOperation : SimpleOperation
    {

        string assignmentstring;

        public AssignmentOperation()
        {
            
        }
    
        public string AssignmentString
        {
            get
            {
                return assignmentstring;
            }
            set
            {
                assignmentstring = value;
            }
        }
    }
}
