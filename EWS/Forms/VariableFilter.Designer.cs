namespace DCS.Forms
{
    partial class VariableFilter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VariableFilter));
            this.tabControlProperty = new System.Windows.Forms.TabControl();
            this.tabPageProperty = new System.Windows.Forms.TabPage();
            this.checkBoxVariable_ShowMode = new System.Windows.Forms.CheckBox();
            this.checkBoxVariable_ShowState = new System.Windows.Forms.CheckBox();
            this.checkBoxVariable_ShowALS = new System.Windows.Forms.CheckBox();
            this.checkBoxVariable_ShowALA = new System.Windows.Forms.CheckBox();
            this.checkBoxVariable_ShowALB = new System.Windows.Forms.CheckBox();
            this.checkBoxVariable_ShowAEB = new System.Windows.Forms.CheckBox();
            this.checkBoxVariable_ShowOPN = new System.Windows.Forms.CheckBox();
            this.checkBoxVariable_ShowOPH = new System.Windows.Forms.CheckBox();
            this.checkBoxVariable_ShowOPM = new System.Windows.Forms.CheckBox();
            this.checkBoxVariable_ShowMNN = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.tabControlProperty.SuspendLayout();
            this.tabPageProperty.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlProperty
            // 
            this.tabControlProperty.Controls.Add(this.tabPageProperty);
            this.tabControlProperty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlProperty.Location = new System.Drawing.Point(0, 0);
            this.tabControlProperty.Name = "tabControlProperty";
            this.tabControlProperty.SelectedIndex = 0;
            this.tabControlProperty.Size = new System.Drawing.Size(476, 242);
            this.tabControlProperty.TabIndex = 0;
            // 
            // tabPageProperty
            // 
            this.tabPageProperty.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageProperty.Controls.Add(this.checkBoxVariable_ShowMode);
            this.tabPageProperty.Controls.Add(this.checkBoxVariable_ShowState);
            this.tabPageProperty.Controls.Add(this.checkBoxVariable_ShowALS);
            this.tabPageProperty.Controls.Add(this.checkBoxVariable_ShowALA);
            this.tabPageProperty.Controls.Add(this.checkBoxVariable_ShowALB);
            this.tabPageProperty.Controls.Add(this.checkBoxVariable_ShowAEB);
            this.tabPageProperty.Controls.Add(this.checkBoxVariable_ShowOPN);
            this.tabPageProperty.Controls.Add(this.checkBoxVariable_ShowOPH);
            this.tabPageProperty.Controls.Add(this.checkBoxVariable_ShowOPM);
            this.tabPageProperty.Controls.Add(this.checkBoxVariable_ShowMNN);
            this.tabPageProperty.Location = new System.Drawing.Point(4, 22);
            this.tabPageProperty.Name = "tabPageProperty";
            this.tabPageProperty.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageProperty.Size = new System.Drawing.Size(468, 216);
            this.tabPageProperty.TabIndex = 1;
            this.tabPageProperty.Text = "Peroperty";
            // 
            // checkBoxVariable_ShowMode
            // 
            this.checkBoxVariable_ShowMode.AutoSize = true;
            this.checkBoxVariable_ShowMode.Location = new System.Drawing.Point(23, 16);
            this.checkBoxVariable_ShowMode.Name = "checkBoxVariable_ShowMode";
            this.checkBoxVariable_ShowMode.Size = new System.Drawing.Size(113, 17);
            this.checkBoxVariable_ShowMode.TabIndex = 0;
            this.checkBoxVariable_ShowMode.Text = "Show Block Mode";
            this.checkBoxVariable_ShowMode.UseVisualStyleBackColor = true;
            // 
            // checkBoxVariable_ShowState
            // 
            this.checkBoxVariable_ShowState.AutoSize = true;
            this.checkBoxVariable_ShowState.Location = new System.Drawing.Point(23, 39);
            this.checkBoxVariable_ShowState.Name = "checkBoxVariable_ShowState";
            this.checkBoxVariable_ShowState.Size = new System.Drawing.Size(111, 17);
            this.checkBoxVariable_ShowState.TabIndex = 0;
            this.checkBoxVariable_ShowState.Text = "Show Block State";
            this.checkBoxVariable_ShowState.UseVisualStyleBackColor = true;
            // 
            // checkBoxVariable_ShowALS
            // 
            this.checkBoxVariable_ShowALS.AutoSize = true;
            this.checkBoxVariable_ShowALS.Location = new System.Drawing.Point(23, 62);
            this.checkBoxVariable_ShowALS.Name = "checkBoxVariable_ShowALS";
            this.checkBoxVariable_ShowALS.Size = new System.Drawing.Size(145, 17);
            this.checkBoxVariable_ShowALS.TabIndex = 0;
            this.checkBoxVariable_ShowALS.Text = "Show Block Alarm Status";
            this.checkBoxVariable_ShowALS.UseVisualStyleBackColor = true;
            // 
            // checkBoxVariable_ShowALA
            // 
            this.checkBoxVariable_ShowALA.AutoSize = true;
            this.checkBoxVariable_ShowALA.Location = new System.Drawing.Point(23, 85);
            this.checkBoxVariable_ShowALA.Name = "checkBoxVariable_ShowALA";
            this.checkBoxVariable_ShowALA.Size = new System.Drawing.Size(184, 17);
            this.checkBoxVariable_ShowALA.TabIndex = 0;
            this.checkBoxVariable_ShowALA.Text = "Show Block Acknowledge Status";
            this.checkBoxVariable_ShowALA.UseVisualStyleBackColor = true;
            // 
            // checkBoxVariable_ShowALB
            // 
            this.checkBoxVariable_ShowALB.AutoSize = true;
            this.checkBoxVariable_ShowALB.Location = new System.Drawing.Point(23, 108);
            this.checkBoxVariable_ShowALB.Name = "checkBoxVariable_ShowALB";
            this.checkBoxVariable_ShowALB.Size = new System.Drawing.Size(194, 17);
            this.checkBoxVariable_ShowALB.TabIndex = 0;
            this.checkBoxVariable_ShowALB.Text = "Show Block Alarm Detection Status";
            this.checkBoxVariable_ShowALB.UseVisualStyleBackColor = true;
            // 
            // checkBoxVariable_ShowAEB
            // 
            this.checkBoxVariable_ShowAEB.AutoSize = true;
            this.checkBoxVariable_ShowAEB.Location = new System.Drawing.Point(23, 131);
            this.checkBoxVariable_ShowAEB.Name = "checkBoxVariable_ShowAEB";
            this.checkBoxVariable_ShowAEB.Size = new System.Drawing.Size(200, 17);
            this.checkBoxVariable_ShowAEB.TabIndex = 0;
            this.checkBoxVariable_ShowAEB.Text = "Show Block Alarm Generation Status";
            this.checkBoxVariable_ShowAEB.UseVisualStyleBackColor = true;
            // 
            // checkBoxVariable_ShowOPN
            // 
            this.checkBoxVariable_ShowOPN.AutoSize = true;
            this.checkBoxVariable_ShowOPN.Location = new System.Drawing.Point(244, 16);
            this.checkBoxVariable_ShowOPN.Name = "checkBoxVariable_ShowOPN";
            this.checkBoxVariable_ShowOPN.Size = new System.Drawing.Size(123, 17);
            this.checkBoxVariable_ShowOPN.TabIndex = 0;
            this.checkBoxVariable_ShowOPN.Text = "Show Operator Note";
            this.checkBoxVariable_ShowOPN.UseVisualStyleBackColor = true;
            // 
            // checkBoxVariable_ShowOPH
            // 
            this.checkBoxVariable_ShowOPH.AutoSize = true;
            this.checkBoxVariable_ShowOPH.Location = new System.Drawing.Point(244, 39);
            this.checkBoxVariable_ShowOPH.Name = "checkBoxVariable_ShowOPH";
            this.checkBoxVariable_ShowOPH.Size = new System.Drawing.Size(122, 17);
            this.checkBoxVariable_ShowOPH.TabIndex = 0;
            this.checkBoxVariable_ShowOPH.Text = "Show Operator Help";
            this.checkBoxVariable_ShowOPH.UseVisualStyleBackColor = true;
            // 
            // checkBoxVariable_ShowOPM
            // 
            this.checkBoxVariable_ShowOPM.AutoSize = true;
            this.checkBoxVariable_ShowOPM.Location = new System.Drawing.Point(244, 62);
            this.checkBoxVariable_ShowOPM.Name = "checkBoxVariable_ShowOPM";
            this.checkBoxVariable_ShowOPM.Size = new System.Drawing.Size(143, 17);
            this.checkBoxVariable_ShowOPM.TabIndex = 0;
            this.checkBoxVariable_ShowOPM.Text = "Show Operator Message";
            this.checkBoxVariable_ShowOPM.UseVisualStyleBackColor = true;
            // 
            // checkBoxVariable_ShowMNN
            // 
            this.checkBoxVariable_ShowMNN.AutoSize = true;
            this.checkBoxVariable_ShowMNN.Location = new System.Drawing.Point(244, 85);
            this.checkBoxVariable_ShowMNN.Name = "checkBoxVariable_ShowMNN";
            this.checkBoxVariable_ShowMNN.Size = new System.Drawing.Size(144, 17);
            this.checkBoxVariable_ShowMNN.TabIndex = 0;
            this.checkBoxVariable_ShowMNN.Text = "Show Maintenance Note";
            this.checkBoxVariable_ShowMNN.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonCancel);
            this.panel1.Controls.Add(this.buttonOK);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 198);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(476, 44);
            this.panel1.TabIndex = 1;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Image = ((System.Drawing.Image)(resources.GetObject("buttonCancel.Image")));
            this.buttonCancel.Location = new System.Drawing.Point(321, 9);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(26, 26);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Image = ((System.Drawing.Image)(resources.GetObject("buttonOK.Image")));
            this.buttonOK.Location = new System.Drawing.Point(113, 9);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(26, 26);
            this.buttonOK.TabIndex = 2;
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // VariableFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 242);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControlProperty);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VariableFilter";
            this.Text = "Filter";
            this.tabControlProperty.ResumeLayout(false);
            this.tabPageProperty.ResumeLayout(false);
            this.tabPageProperty.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlProperty;
        private System.Windows.Forms.TabPage tabPageProperty;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.CheckBox checkBoxVariable_ShowMode ;
        private System.Windows.Forms.CheckBox checkBoxVariable_ShowState;
        private System.Windows.Forms.CheckBox checkBoxVariable_ShowALS ;
        private System.Windows.Forms.CheckBox checkBoxVariable_ShowALA ;
        private System.Windows.Forms.CheckBox checkBoxVariable_ShowALB ;
        private System.Windows.Forms.CheckBox checkBoxVariable_ShowAEB ;
        private System.Windows.Forms.CheckBox checkBoxVariable_ShowOPN ;
        private System.Windows.Forms.CheckBox checkBoxVariable_ShowOPH ;
        private System.Windows.Forms.CheckBox checkBoxVariable_ShowOPM ;
        private System.Windows.Forms.CheckBox checkBoxVariable_ShowMNN;
    }
}