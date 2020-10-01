using DCS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DCS.Forms
{
    public partial class VariableFilter : Form
    {
        public VariableFilter()
        {
            InitializeComponent();

            this.checkBoxVariable_ShowMode.Checked = Common.Variable_ShowMode;
            this.checkBoxVariable_ShowState.Checked = Common.Variable_ShowState;
            this.checkBoxVariable_ShowALS.Checked = Common.Variable_ShowALS;
            this.checkBoxVariable_ShowALA.Checked = Common.Variable_ShowALA;
            this.checkBoxVariable_ShowALB.Checked = Common.Variable_ShowALB;
            this.checkBoxVariable_ShowAEB.Checked = Common.Variable_ShowAEB;
            this.checkBoxVariable_ShowOPN.Checked = Common.Variable_ShowOPN;
            this.checkBoxVariable_ShowOPH.Checked = Common.Variable_ShowOPH;
            this.checkBoxVariable_ShowOPM.Checked = Common.Variable_ShowOPM;
            this.checkBoxVariable_ShowMNN.Checked = Common.Variable_ShowMNN;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            Common.Variable_ShowMode = this.checkBoxVariable_ShowMode.Checked;
            Common.Variable_ShowState = this.checkBoxVariable_ShowState.Checked;
            Common.Variable_ShowALS = this.checkBoxVariable_ShowALS.Checked;
            Common.Variable_ShowALA = this.checkBoxVariable_ShowALA.Checked;
            Common.Variable_ShowALB = this.checkBoxVariable_ShowALB.Checked;
            Common.Variable_ShowAEB = this.checkBoxVariable_ShowAEB.Checked;
            Common.Variable_ShowOPN = this.checkBoxVariable_ShowOPN.Checked;
            Common.Variable_ShowOPH = this.checkBoxVariable_ShowOPH.Checked;
            Common.Variable_ShowOPM = this.checkBoxVariable_ShowOPM.Checked;
            Common.Variable_ShowMNN = this.checkBoxVariable_ShowMNN.Checked;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void buttonName_Click(object sender, EventArgs e)
        {

        }

        private void buttonDescription_Click(object sender, EventArgs e)
        {

        }

        private void buttonArea_Click(object sender, EventArgs e)
        {

        }

        
    }
}
