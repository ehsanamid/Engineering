using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DCS.TypeConverters
{
    public class ImageEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(
            ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        public override object EditValue(ITypeDescriptorContext context,
            IServiceProvider provider, object value)
        {
            OpenFileDialog _file = new OpenFileDialog();

            _file.Multiselect = false;

            _file.Filter = "Image Files(.bmp, .png, .jpg, .gif)|*.bmp|*.jpg|*.png";

            if (_file.ShowDialog() == DialogResult.OK)
            {
                char separator = '\\';
                string[] fileNames = _file.FileName.Split(separator);

                separator = '.';
                string[] extensions = fileNames[fileNames.Length - 1].Split(separator);

                if (extensions[1] == "bmp" || extensions[1] == "jpg" || extensions[1] == "jpeg" || extensions[1] == "png" || extensions[1] == "gif" || extensions[1] == "ico")
                {
                    return fileNames[fileNames.Length - 1];
                }
                else
                {
                    MessageBox.Show("wrong file is selected");
                    return null;
                }
            }
            else
                return null;
        }
    }
}
