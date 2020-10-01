using DCS.Tools;
namespace DCS.Forms
{
    partial class ShapeFillfrm
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
            this.TabPageShapeFillColor = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.styleList1 = new DCS.Tools.StyleList();
            this.colorComboEndColor = new DCS.Tools.ColorCombo();
            this.colorComboStartColor = new DCS.Tools.ColorCombo();
            this.panelSample = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxBlinking = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonPattern = new System.Windows.Forms.RadioButton();
            this.radioButtonGradient = new System.Windows.Forms.RadioButton();
            this.radioButtonSolid = new System.Windows.Forms.RadioButton();
            this.radioButtonNoFill = new System.Windows.Forms.RadioButton();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.TabPageShapeFillColor.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabPageShapeFillColor
            // 
            this.TabPageShapeFillColor.Controls.Add(this.tabPage1);
            this.TabPageShapeFillColor.Location = new System.Drawing.Point(6, 6);
            this.TabPageShapeFillColor.Name = "TabPageShapeFillColor";
            this.TabPageShapeFillColor.SelectedIndex = 0;
            this.TabPageShapeFillColor.Size = new System.Drawing.Size(477, 275);
            this.TabPageShapeFillColor.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.colorComboEndColor);
            this.tabPage1.Controls.Add(this.colorComboStartColor);
            this.tabPage1.Controls.Add(this.panelSample);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.checkBoxBlinking);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(469, 249);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Color";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoScrollMinSize = new System.Drawing.Size(0, 49);
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.styleList1);
            this.panel1.Location = new System.Drawing.Point(29, 142);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(194, 101);
            this.panel1.TabIndex = 54;
            // 
            // styleList1
            // 
            this.styleList1.Location = new System.Drawing.Point(3, 4);
            this.styleList1.Margin = new System.Windows.Forms.Padding(0);
            this.styleList1.Name = "styleList1";
            this.styleList1.Size = new System.Drawing.Size(162, 100);
            this.styleList1.TabIndex = 0;
            this.styleList1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.styleList1_MouseClick);
            // 
            // colorComboEndColor
            // 
            this.colorComboEndColor.FillColor = System.Drawing.Color.Empty;
            this.colorComboEndColor.LabelColor = "Empty";
            this.colorComboEndColor.Location = new System.Drawing.Point(121, 87);
            this.colorComboEndColor.Name = "colorComboEndColor";
            this.colorComboEndColor.Size = new System.Drawing.Size(173, 53);
            this.colorComboEndColor.TabIndex = 1;
            this.colorComboEndColor.Title = "Start Color";
            // 
            // colorComboStartColor
            // 
            this.colorComboStartColor.FillColor = System.Drawing.Color.Empty;
            this.colorComboStartColor.LabelColor = "Empty";
            this.colorComboStartColor.Location = new System.Drawing.Point(121, 32);
            this.colorComboStartColor.Name = "colorComboStartColor";
            this.colorComboStartColor.Size = new System.Drawing.Size(173, 53);
            this.colorComboStartColor.TabIndex = 0;
            this.colorComboStartColor.Title = "Start Color";
            // 
            // panelSample
            // 
            this.panelSample.Location = new System.Drawing.Point(300, 142);
            this.panelSample.Name = "panelSample";
            this.panelSample.Size = new System.Drawing.Size(93, 81);
            this.panelSample.TabIndex = 40;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(300, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 39;
            this.label1.Text = "Sample";
            // 
            // checkBoxBlinking
            // 
            this.checkBoxBlinking.Location = new System.Drawing.Point(133, 14);
            this.checkBoxBlinking.Name = "checkBoxBlinking";
            this.checkBoxBlinking.Size = new System.Drawing.Size(63, 17);
            this.checkBoxBlinking.TabIndex = 37;
            this.checkBoxBlinking.Text = "Blinking";
            this.checkBoxBlinking.UseVisualStyleBackColor = true;
            this.checkBoxBlinking.CheckedChanged += new System.EventHandler(this.checkBoxBlinking_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonPattern);
            this.groupBox1.Controls.Add(this.radioButtonGradient);
            this.groupBox1.Controls.Add(this.radioButtonSolid);
            this.groupBox1.Controls.Add(this.radioButtonNoFill);
            this.groupBox1.Location = new System.Drawing.Point(6, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(109, 114);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fill";
            // 
            // radioButtonPattern
            // 
            this.radioButtonPattern.AutoSize = true;
            this.radioButtonPattern.Location = new System.Drawing.Point(5, 71);
            this.radioButtonPattern.Name = "radioButtonPattern";
            this.radioButtonPattern.Size = new System.Drawing.Size(56, 17);
            this.radioButtonPattern.TabIndex = 3;
            this.radioButtonPattern.TabStop = true;
            this.radioButtonPattern.Tag = "radioButtonC";
            this.radioButtonPattern.Text = "Patern";
            this.radioButtonPattern.UseVisualStyleBackColor = true;
            this.radioButtonPattern.Click += new System.EventHandler(this.radioButtonPattern_Click);
            // 
            // radioButtonGradient
            // 
            this.radioButtonGradient.AutoSize = true;
            this.radioButtonGradient.Location = new System.Drawing.Point(5, 52);
            this.radioButtonGradient.Name = "radioButtonGradient";
            this.radioButtonGradient.Size = new System.Drawing.Size(65, 17);
            this.radioButtonGradient.TabIndex = 2;
            this.radioButtonGradient.TabStop = true;
            this.radioButtonGradient.Tag = "radioButtonC";
            this.radioButtonGradient.Text = "Gradient";
            this.radioButtonGradient.UseVisualStyleBackColor = true;
            this.radioButtonGradient.Click += new System.EventHandler(this.radioButtonGradiant_Click);
            // 
            // radioButtonSolid
            // 
            this.radioButtonSolid.AutoSize = true;
            this.radioButtonSolid.Location = new System.Drawing.Point(5, 33);
            this.radioButtonSolid.Name = "radioButtonSolid";
            this.radioButtonSolid.Size = new System.Drawing.Size(48, 17);
            this.radioButtonSolid.TabIndex = 1;
            this.radioButtonSolid.TabStop = true;
            this.radioButtonSolid.Tag = "radioButtonC";
            this.radioButtonSolid.Text = "Solid";
            this.radioButtonSolid.UseVisualStyleBackColor = true;
            this.radioButtonSolid.Click += new System.EventHandler(this.radioButtonSolid_Click);
            // 
            // radioButtonNoFill
            // 
            this.radioButtonNoFill.AutoSize = true;
            this.radioButtonNoFill.Location = new System.Drawing.Point(5, 14);
            this.radioButtonNoFill.Name = "radioButtonNoFill";
            this.radioButtonNoFill.Size = new System.Drawing.Size(54, 17);
            this.radioButtonNoFill.TabIndex = 0;
            this.radioButtonNoFill.TabStop = true;
            this.radioButtonNoFill.Tag = "radioButtonC";
            this.radioButtonNoFill.Text = "No Fill";
            this.radioButtonNoFill.UseVisualStyleBackColor = true;
            this.radioButtonNoFill.Click += new System.EventHandler(this.radioButtonNoFill_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(341, 287);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(72, 21);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(81, 287);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(72, 21);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "Ok";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // ShapeFillfrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 317);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.TabPageShapeFillColor);
            this.Name = "ShapeFillfrm";
            this.Text = "ShapeFillfrm";
            this.Load += new System.EventHandler(this.ShapeFillfrm_Load);
            this.TabPageShapeFillColor.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabPageShapeFillColor;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonSolid;
        private System.Windows.Forms.RadioButton radioButtonNoFill;
        private System.Windows.Forms.Panel panelSample;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxBlinking;
        private System.Windows.Forms.RadioButton radioButtonPattern;
        private System.Windows.Forms.RadioButton radioButtonGradient;
        private ColorCombo colorComboStartColor;
        private ColorCombo colorComboEndColor;
        private System.Windows.Forms.Panel panel1;
        private StyleList styleList1;
    }
}