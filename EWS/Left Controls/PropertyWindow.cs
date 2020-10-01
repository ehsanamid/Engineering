using DCS;
using DCS.Forms;
using DCS.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;



namespace DCS.LeftControls
{
    public partial class PropertyWindow : ToolWindow
    {
        //MainForm mainform;


        public PropertyWindow()
        {
            InitializeComponent();
            //comboBox.SelectedIndex = 0;
            //propertyGrid.SelectedObject = propertyGrid;
        }

        public FilteredPropertyGrid propertyGridComponemt
        {
            get
            {
                return propertyGrid;
            }
        }

        private void propertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            MainForm.Instance().UpateDocPagefromPropertyGrid();
        }
    }
}