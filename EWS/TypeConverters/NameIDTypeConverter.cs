using DCS.DCSTables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace DCS.TypeConverters
{


    [TypeConverter(typeof(NameIDTypeConverter))]
    public interface INameID
    {
        long ID { get; set; }
        Type Type { get; set; }
        string Name { get; set; }
    }

    class NameIDTypeConverter : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            // we only know how to convert from to a string
            if (typeof(string) == destinationType)
            {
                return true;
            }
            else
            {
                if (typeof(long) == destinationType)
                {
                    return true;
                }
            }
            return false;
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (typeof(string) == destinationType)
            {
                // just use the benchmark name
                INameID inameid = value as INameID;
                if (inameid != null)
                    return inameid.Name;
            }
            if (typeof(long) == destinationType)
            {
                // just use the benchmark name
                INameID inameid = value as INameID;
                if (inameid != null)
                    return inameid.ID;
            }
            return "(none)";
        }
    }

    
}
