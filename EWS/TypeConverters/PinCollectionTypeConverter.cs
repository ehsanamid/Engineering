using DCS.Draw.FBD;
using DCS.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DCS.TypeConverters
{

    // This is a special type converter which will be associated with the Employee class.
    // It converts an Employee object to string representation for use in a property grid.

    /// <summary>
    /// Summary description for CollectionPropertyDescriptor.
    /// </summary>
    public class FBDPinCollectionPropertyDescriptor : PropertyDescriptor
    {
        private FBDObjectPinCollection collection = null;
        private int index = -1;

        public FBDPinCollectionPropertyDescriptor(FBDObjectPinCollection coll, int idx) :
            base("#" + idx.ToString(), null)
        {
            this.collection = coll;
            this.index = idx;
        }

        public override AttributeCollection Attributes
        {
            get
            {
                return new AttributeCollection(null);
            }
        }

        public override bool CanResetValue(object component)
        {
            return true;
        }

        public override Type ComponentType
        {
            get
            {
                return this.collection.GetType();
            }
        }

        public override string DisplayName
        {
            get
            {
                FBDObjectPin emp = this.collection[index];
                //return emp.FirstName + " " + emp.LastName;
                return emp.tblformalparameter.PinName;
            }
        }

        public override string Description
        {
            get
            {
                FBDObjectPin emp = this.collection[index];
                StringBuilder sb = new StringBuilder();
                sb.Append("Name=");
                sb.Append(emp.tblformalparameter.PinName);
                sb.Append("\nDescription=");
                sb.Append(emp.tblformalparameter.Description);
                sb.Append("\nClass=");
                sb.Append(emp.tblformalparameter.Class);
                sb.Append(" , Type=");
                sb.Append(emp.tblformalparameter.Type);
                sb.Append("\nVisible=");
                sb.Append(emp.Visible);
                sb.Append("\nInital Value=");
                sb.Append(emp.tblformalparameter.InitializeValue);
                //sb.Append(" years old, working for ");
                //sb.Append(emp.Department);
                //sb.Append(" as ");
                //sb.Append(emp.Role);

                return sb.ToString();
            }
        }

        public override object GetValue(object component)
        {
            return this.collection[index];
        }

        public override bool IsReadOnly
        {
            get { return false; }
        }

        public override string Name
        {
            get { return "#" + index.ToString(); }
        }

        public override Type PropertyType
        {
            get { return this.collection[index].GetType(); }
        }

        public override void ResetValue(object component)
        {
        }

        public override bool ShouldSerializeValue(object component)
        {
            return true;
        }

        public override void SetValue(object component, object value)
        {
            // this.collection[index] = value;
        }
    }
    internal class EmployeeConverter : ExpandableObjectConverter
    {
        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destType)
        {
            if (destType == typeof(string) && value is FBDObjectPin)
            {
                // Cast the value to an Employee type
                FBDObjectPin emp = (FBDObjectPin)value;

                // Return department and department role separated by comma.
                //return emp.Department + ", " + emp.Role;
                return emp.tblformalparameter.PinName;
            }
            return base.ConvertTo(context, culture, value, destType);
        }
    }

    internal class FBDObjectPinConverter : ExpandableObjectConverter
    {
        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destType)
        {
            if (destType == typeof(string) && value is FBDObjectPin)
            {
                // Return department and department role separated by comma.
                return ((FBDObjectPin)value).tblformalparameter.PinName;
            }
            return base.ConvertTo(context, culture, value, destType);
        }
    }


    internal class PinCollectionTypeConverter : ExpandableObjectConverter
    {
        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destType)
        {
            if (destType == typeof(string) && value is FBDObjectPinCollection)
            {
                // Return department and department role separated by comma.
                return "FBD Pin data";
            }
            return base.ConvertTo(context, culture, value, destType);
        }
    }

    internal class FBDboxObjectTypeConverter : ExpandableObjectConverter
    {
        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destType)
        {
            if (destType == typeof(string) && value is FBDboxObject)
            {
                // Return department and department role separated by comma.
                return "FBD object";
            }
            return base.ConvertTo(context, culture, value, destType);
        }
    }
}
