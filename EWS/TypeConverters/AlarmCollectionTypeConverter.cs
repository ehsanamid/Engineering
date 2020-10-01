using DCS.Forms;
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
using DCS.TableObject;

namespace DCS.TypeConverters
{

    public class AlarmCollectionTypeConverter : TypeConverter
    {
        // Overrides the ConvertTo method of TypeConverter.
        public override object ConvertTo(ITypeDescriptorContext context,CultureInfo culture, object value, Type destinationType)
        {
            AlarmCollection v = value as AlarmCollection;
                string str= "";
            foreach(AlarmObject alarmobject in v)
            {
                str += alarmobject.StatusTxt;
                str += ",";
            }
            if (destinationType == typeof(string))
            {
                return str;
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }

    class AlarmCollectionTypeEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            var svc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
            AlarmCollection _AlarmCollection = (AlarmCollection)value; 
            string text = "";// value as string;
            if (svc != null && text != null)
            {
                using (AlarmForm form = new AlarmForm(_AlarmCollection.m_VarNameID_VariableGrid))
                {
                    form.Value = text;
                    if (svc.ShowDialog(form) == DialogResult.OK)
                    {
                        if (form.updated)
                        {
                           ((VariableGrid)((DCS.Tools.ObjectWrapper)(context.Instance)).SelectedObject).Modified = true;
                           ((MainForm)((System.Windows.Forms.Control)(svc)).TopLevelControl).UpateVariableFromPropertygrid();
                        }
                        return form.Refvariablegrid.m_AlarmCollection;
                    }
                }
            }

            return value;
        }
    }
}
