using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EWS.Filter
{
    public class Filter
    {
        public string PropertyName { get; set; }
        public Op Operation { get; set; }
        public object Value { get; set; }
        public Filter(Op _operation,string _propertyname, object _value )
        {
            Operation = _operation;
            Value = _value;
            PropertyName = _propertyname;
        }
        public Filter()
        {
            
        }
    }

    public enum Op
    {
        Equals,
        GreaterThan,
        LessThan,
        GreaterThanOrEqual,
        LessThanOrEqual,
        Contains,
        StartsWith,
        EndsWith
    }
}
