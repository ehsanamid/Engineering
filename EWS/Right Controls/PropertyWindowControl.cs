using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WinFormsUI.Docking;
using EWS.Forms;
//using DocToolkit.Project_Objects;

namespace EWS.RightControls
{


    public delegate bool UpdateTabPageDelegate(int indx);

    public partial class PropertyWindowControl : UserControl
    {
        public MainForm mainform;
        UpdateTabPageDelegate updatetabpagedelegate;
        public PropertyWindowControl(MainForm _parent)
        {
            InitializeComponent();
            mainform = _parent;
          //  updatetabpagedelegate = new UpdateTabPageDelegate(mainform.UpateDisplayFromPropertygrid);
        }
        public PropertyWindowControl(/*MainForm _frm*/)
        {
            InitializeComponent();
        }

        //public void SetParent(MainForm _parent)
        //{
        //    mainform = _parent;
        //    updatetabpagedelegate = new UpdateTabPageDelegate(mainform.UpateDisplayFromPropertygrid);
        //}

        


        private void propertyGridComponemt_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            //int i = mainform.TabControlMain.SelectedIndex;
            //if (updatetabpagedelegate != null)
            //{
            //    bool closeIt = updatetabpagedelegate(i);
            //}
        }

       
    }
}