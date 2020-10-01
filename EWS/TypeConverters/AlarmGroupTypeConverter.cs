using DCS.DCSTables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using DCS.TableObject;

namespace DCS.TypeConverters
{

    public class IAlarmGroup : INameID
    {
        public IAlarmGroup()
        {
            this.ID = 0;
            this.Type = this.GetType();
            this.Name = "Primary Benchmark";
        }

        public IAlarmGroup(long id, string name)
        {
            this.ID = id;
            this.Type = this.GetType();
            this.Name = name;
        }

        public long ID { get; set; }
        public Type Type { get; set; }
        public string Name { get; set; }
    }

    
    class AlarmGroupTypeEditor : UITypeEditor
    {
        private IWindowsFormsEditorService _editorService;

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            // drop down mode (we'll host a listbox in the drop down)
            return UITypeEditorEditStyle.DropDown;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            _editorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));

            // use a list box
            ListBox lb = new ListBox();
            lb.SelectionMode = SelectionMode.One;
            lb.SelectedValueChanged += OnListBoxSelectedValueChanged;

            // use the IBenchmark.Name property for list box display
            lb.DisplayMember = "Name";

            // get the analytic object from context
            // this is how we get the list of possible benchmarks
            AlarmObject alarmobject = (AlarmObject)context.Instance;
            foreach (IAlarmGroup ialarmgroup in alarmobject.AlarmGroups)
            {
                // we store benchmarks objects directly in the listbox
                int index = lb.Items.Add(ialarmgroup);
                if (ialarmgroup.Equals(value))
                {
                    lb.SelectedIndex = index;
                }
            }

            // show this model stuff
            _editorService.DropDownControl(lb);
            if (lb.SelectedItem == null) // no selection, return the passed-in value as is
                return value;

            return lb.SelectedItem;
        }

        private void OnListBoxSelectedValueChanged(object sender, EventArgs e)
        {
            // close the drop down as soon as something is clicked
            _editorService.CloseDropDown();
        }
    }
}
