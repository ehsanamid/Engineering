using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DCS.Tools
{
    public class Filter
    {
        public string PropertyName { get; set; }
        public OpEnum Operation { get; set; }
        public object Value { get; set; }
        public Filter(OpEnum _operation, string _propertyname, object _value)
        {
            Operation = _operation;
            Value = _value;
            PropertyName = _propertyname;
        }
        public Filter()
        {
            
        }
    }

    public enum OpEnum
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
