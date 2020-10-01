using DCS.Tools;
namespace DCS.Forms
{
    partial class ShapeOutlinefrm
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
            this.labelStrartCap = new System.Windows.Forms.Label();
            this.labelEndCap = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.comboBoxStartCap = new System.Windows.Forms.ComboBox();
            this.comboBoxEndCap = new System.Windows.Forms.ComboBox();
            this.comboBoxDash = new System.Windows.Forms.ComboBox();
            this.colorComboStartColor = new DCS.Tools.ColorCombo();
            this.panelSample = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxBlinking = new System.Windows.Forms.CheckBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.TabPageShapeFillColor.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
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
            this.tabPage1.Controls.Add(this.labelStrartCap);
            this.tabPage1.Controls.Add(this.labelEndCap);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.numericUpDown1);
            this.tabPage1.Controls.Add(this.comboBoxStartCap);
            this.tabPage1.Controls.Add(this.comboBoxEndCap);
            this.tabPage1.Controls.Add(this.comboBoxDash);
            this.tabPage1.Controls.Add(this.colorComboStartColor);
            this.tabPage1.Controls.Add(this.panelSample);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.checkBoxBlinking);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(469, 249);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Color";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // labelStrartCap
            // 
            this.labelStrartCap.AutoSize = true;
            this.labelStrartCap.Location = new System.Drawing.Point(8, 152);
            this.labelStrartCap.Name = "labelStrartCap";
            this.labelStrartCap.Size = new System.Drawing.Size(51, 13);
            this.labelStrartCap.TabIndex = 4;
            this.labelStrartCap.Text = "Start Cap";
            // 
            // labelEndCap
            // 
            this.labelEndCap.AutoSize = true;
            this.labelEndCap.Location = new System.Drawing.Point(123, 152);
            this.labelEndCap.Name = "labelEndCap";
            this.labelEndCap.Size = new System.Drawing.Size(48, 13);
            this.labelEndCap.TabIndex = 6;
            this.labelEndCap.Text = "End Cap";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Dash Pattern";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(193, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Width";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(239, 55);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown1.TabIndex = 9;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // comboBoxStartCap
            // 
            this.comboBoxStartCap.FormattingEnabled = true;
            this.comboBoxStartCap.Location = new System.Drawing.Point(6, 168);
            this.comboBoxStartCap.Name = "comboBoxStartCap";
            this.comboBoxStartCap.Size = new System.Drawing.Size(84, 21);
            this.comboBoxStartCap.TabIndex = 5;
            this.comboBoxStartCap.SelectedIndexChanged += new System.EventHandler(this.comboBoxStartCap_SelectedIndexChanged);
            // 
            // comboBoxEndCap
            // 
            this.comboBoxEndCap.FormattingEnabled = true;
            this.comboBoxEndCap.Location = new System.Drawing.Point(121, 168);
            this.comboBoxEndCap.Name = "comboBoxEndCap";
            this.comboBoxEndCap.Size = new System.Drawing.Size(84, 21);
            this.comboBoxEndCap.TabIndex = 7;
            this.comboBoxEndCap.SelectedIndexChanged += new System.EventHandler(this.comboBoxEndCap_SelectedIndexChanged);
            // 
            // comboBoxDash
            // 
            this.comboBoxDash.FormattingEnabled = true;
            this.comboBoxDash.Location = new System.Drawing.Point(6, 114);
            this.comboBoxDash.Name = "comboBoxDash";
            this.comboBoxDash.Size = new System.Drawing.Size(148, 21);
            this.comboBoxDash.TabIndex = 3;
            this.comboBoxDash.SelectedIndexChanged += new System.EventHandler(this.comboBoxDash_SelectedIndexChanged);
            // 
            // colorComboStartColor
            // 
            this.colorComboStartColor.FillColor = System.Drawing.Color.Empty;
            this.colorComboStartColor.LabelColor = "Empty";
            this.colorComboStartColor.Location = new System.Drawing.Point(8, 37);
            this.colorComboStartColor.Name = "colorComboStartColor";
            this.colorComboStartColor.Size = new System.Drawing.Size(173, 53);
            this.colorComboStartColor.TabIndex = 1;
            this.colorComboStartColor.Title = "Start Color";
            // 
            // panelSample
            // 
            this.panelSample.Location = new System.Drawing.Point(228, 142);
            this.panelSample.Name = "panelSample";
            this.panelSample.Size = new System.Drawing.Size(199, 81);
            this.panelSample.TabIndex = 40;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(225, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 39;
            this.label1.Text = "Sample";
            // 
            // checkBoxBlinking
            // 
            this.checkBoxBlinking.Location = new System.Drawing.Point(8, 14);
            this.checkBoxBlinking.Name = "checkBoxBlinking";
            this.checkBoxBlinking.Size = new System.Drawing.Size(63, 17);
            this.checkBoxBlinking.TabIndex = 0;
            this.checkBoxBlinking.Text = "Blinking";
            this.checkBoxBlinking.UseVisualStyleBackColor = true;
            this.checkBoxBlinking.CheckedChanged += new System.EventHandler(this.checkBoxBlinking_CheckedChanged);
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
            // ShapeOutlinefrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 317);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.TabPageShapeFillColor);
            this.Name = "ShapeOutlinefrm";
            this.Text = "ShapeFillfrm";
            this.Load += new System.EventHandler(this.ShapeFillfrm_Load);
            this.TabPageShapeFillColor.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabPageShapeFillColor;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panelSample;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxBlinking;
        private ColorCombo colorComboStartColor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.ComboBox comboBoxDash;
        private System.Windows.Forms.Label labelStrartCap;
        private System.Windows.Forms.Label labelEndCap;
        private System.Windows.Forms.ComboBox comboBoxStartCap;
        private System.Windows.Forms.ComboBox comboBoxEndCap;
    }
}