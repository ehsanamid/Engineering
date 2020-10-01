using DCS.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace DCS.TypeConverters
{
    
    class PlantstructureEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            var svc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
            string text = value as string;
            if (svc != null && text != null)
            {
                using (PlantstructureSelectForm form = new PlantstructureSelectForm())
                {
                    form.Value = text;
                    if (svc.ShowDialog(form) == DialogResult.OK)
                    {
                        return form.Value;
                    }
                }
            }

            return value;
        }
    }
}
