using DCS.Forms;
using DCS.Draw;
using DCS.Tools;
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
    

    public class ShapeFillTypeConverter : TypeConverter
    {
        // Overrides the ConvertTo method of TypeConverter.
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            ShapeFill v = value as ShapeFill;
            //foreach (AlarmObject alarmobject in v)
            //{
            //    str += alarmobject.StatusTxt;
            //    str += ",";
            //}
            if (destinationType == typeof(string))
            {
                return v.FillColor;
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }

    class ShapeFillTypeEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            ShapeFillfrm form = new ShapeFillfrm((ShapeFill)value);
            if (form.ShowDialog() == DialogResult.OK)
            {
                Common.LastFillColor = form.tempshapefill.FillColor;
                return form.tempshapefill;
            }
            return (ShapeFill)value;
        }
    }

    public class ShapeOutlineTypeConverter : TypeConverter
    {
        // Overrides the ConvertTo method of TypeConverter.
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            ShapeOutline v = value as ShapeOutline;
            if (destinationType == typeof(string))
            {
                return v.LineStyle;
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }

    class ShapeOutlineTypeEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            ShapeOutlinefrm form = new ShapeOutlinefrm((ShapeOutline)value);
            if (form.ShowDialog() == DialogResult.OK)
            {
                Common.LastLineStyle = form.tempshapeoutline.LineStyle;
                return form.tempshapeoutline;
            }
            return (ShapeOutline)value;
        }
    }

    public class ExpressionTypeConverter : TypeConverter
    {
        // Overrides the ConvertTo method of TypeConverter.
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            //string v = value as string;
            
            //if (destinationType == typeof(string))
            //{
            //    return v;
            //}
            //return base.ConvertTo(context, culture, value, destinationType);
            return "Expression";
        }


    }

    class ExpressionTypeEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            DrawGraphic drawgraphic = (DrawGraphic)((ObjectWrapper)context.Instance).SelectedObject;
            long id = drawgraphic.Parentpagelist.Parenttabgraphicpagecontrol.ID;
            //ExpressionArgumentForm form = new ExpressionArgumentForm(id,drawgraphic.drawexpressionCollection.Argumentstr, drawgraphic.drawexpressionCollection.Expressionstr, drawgraphic.drawexpressionCollection.Actionstr, drawgraphic.Propertylist);
            GraphicalObjectExpressionForm form = new GraphicalObjectExpressionForm(id,  drawgraphic.drawexpressionCollection.DisplayObjectParametersstr,  drawgraphic.drawexpressionCollection.DisplayObjectDynamicPropertysstr,  drawgraphic.drawexpressionCollection.DisplayObjectEventHandlersstr, drawgraphic.Propertylist);
            form.selectTabPage(1);
            if (form.ShowDialog() == DialogResult.OK)
            {
                drawgraphic.drawexpressionCollection.DisplayObjectParametersstr         = form.DisplayObjectParametersstr;
                drawgraphic.drawexpressionCollection.DisplayObjectDynamicPropertysstr   = form.DisplayObjectDynamicPropertysstr;
                drawgraphic.drawexpressionCollection.DisplayObjectEventHandlersstr      = form.DisplayObjectEventHandlersstr;
                return drawgraphic.drawexpressionCollection;
                //return form.Expressionstr;
            }
            return drawgraphic.drawexpressionCollection;
            //return (string)value;
        }
    }
/*    
    public class ArgumentypeConverter : TypeConverter
    {
        // Overrides the ConvertTo method of TypeConverter.
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            string v = value as string;

            if (destinationType == typeof(string))
            {
                return v;
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }

    class ArgumentTypeEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            DrawGraphic drawgraphic = (DrawGraphic)((ObjectWrapper)context.Instance).SelectedObject;

            ExpressionArgumentForm form = new ExpressionArgumentForm(drawgraphic.drawexpressionCollection.Argumentstr, drawgraphic.drawexpressionCollection.Expressionstr, drawgraphic.drawexpressionCollection.Actionstr, drawgraphic.Propertylist);
            form.selectTabPage(0);

            if (form.ShowDialog() == DialogResult.OK)
            {
                drawgraphic.drawexpressionCollection.Argumentstr = form.Argumentstr;
                drawgraphic.drawexpressionCollection.Expressionstr = form.Expressionstr;
                drawgraphic.drawexpressionCollection.Actionstr = form.Actionstr;
                return form.Argumentstr;
            }

            return (string)value;
        }
        
    }

    public class ActionTypeConverter : TypeConverter
    {
        // Overrides the ConvertTo method of TypeConverter.
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            string v = value as string;

            if (destinationType == typeof(string))
            {
                return v;
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }

    class ActionTypeEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            DrawGraphic drawgraphic = (DrawGraphic)((ObjectWrapper)context.Instance).SelectedObject;

            ExpressionArgumentForm form = new ExpressionArgumentForm(drawgraphic.drawexpressionCollection.Argumentstr, drawgraphic.drawexpressionCollection.Expressionstr, drawgraphic.drawexpressionCollection.Actionstr, drawgraphic.Propertylist);

            form.selectTabPage(2);
            if (form.ShowDialog() == DialogResult.OK)
            {
                drawgraphic.drawexpressionCollection.Argumentstr = form.Argumentstr;
                drawgraphic.drawexpressionCollection.Expressionstr = form.Expressionstr;
                drawgraphic.drawexpressionCollection.Actionstr = form.Actionstr;
                return form.Actionstr;
            }

            return (string)value;
        }
        
    }
*/
}
