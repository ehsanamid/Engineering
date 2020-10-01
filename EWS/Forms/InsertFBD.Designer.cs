namespace DCS.Forms
{
    partial class InsertFBD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InsertFBD));
            this.label2 = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.numericUpDownNoOfInputs = new System.Windows.Forms.NumericUpDown();
            this.textBoxInstanceName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.comboBoxFunctionGroup = new System.Windows.Forms.ComboBox();
            this.listBoxFunctions = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNoOfInputs)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(267, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "No Of Inputs :";
            this.label2.Visible = false;
            // 
            // buttonOK
            // 
            this.buttonOK.Enabled = false;
            this.buttonOK.Location = new System.Drawing.Point(107, 388);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(105, 28);
            this.buttonOK.TabIndex = 5;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(315, 388);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(105, 28);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // numericUpDownNoOfInputs
            // 
            this.numericUpDownNoOfInputs.Location = new System.Drawing.Point(344, 69);
            this.numericUpDownNoOfInputs.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numericUpDownNoOfInputs.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownNoOfInputs.Name = "numericUpDownNoOfInputs";
            this.numericUpDownNoOfInputs.Size = new System.Drawing.Size(99, 20);
            this.numericUpDownNoOfInputs.TabIndex = 4;
            this.numericUpDownNoOfInputs.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownNoOfInputs.Visible = false;
            // 
            // textBoxInstanceName
            // 
            this.textBoxInstanceName.Enabled = false;
            this.textBoxInstanceName.Location = new System.Drawing.Point(66, 10);
            this.textBoxInstanceName.MaxLength = 32;
            this.textBoxInstanceName.Name = "textBoxInstanceName";
            this.textBoxInstanceName.Size = new System.Drawing.Size(166, 20);
            this.textBoxInstanceName.TabIndex = 0;
            this.textBoxInstanceName.WordWrap = false;
            this.textBoxInstanceName.TextChanged += new System.EventHandler(this.textBoxInstanceName_TextChanged);
            this.textBoxInstanceName.Leave += new System.EventHandler(this.textBoxInstanceName_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Name :";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(29, 290);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(233, 75);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // comboBoxFunctionGroup
            // 
            this.comboBoxFunctionGroup.FormattingEnabled = true;
            this.comboBoxFunctionGroup.Location = new System.Drawing.Point(66, 68);
            this.comboBoxFunctionGroup.Name = "comboBoxFunctionGroup";
            this.comboBoxFunctionGroup.Size = new System.Drawing.Size(195, 21);
            this.comboBoxFunctionGroup.TabIndex = 2;
            this.comboBoxFunctionGroup.SelectedIndexChanged += new System.EventHandler(this.comboBoxFunctionGroup_SelectedIndexChanged);
            // 
            // listBoxFunctions
            // 
            this.listBoxFunctions.FormattingEnabled = true;
            this.listBoxFunctions.Location = new System.Drawing.Point(29, 98);
            this.listBoxFunctions.Name = "listBoxFunctions";
            this.listBoxFunctions.Size = new System.Drawing.Size(233, 186);
            this.listBoxFunctions.TabIndex = 3;
            this.listBoxFunctions.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listBoxFunctions_MouseClick);
            this.listBoxFunctions.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBoxFunctions_MouseDoubleClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Category :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Description :";
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(66, 38);
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(454, 20);
            this.textBoxDescription.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Location = new System.Drawing.Point(269, 98);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(251, 267);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Preview";
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(245, 248);
            this.panel1.TabIndex = 0;
            // 
            // InsertFBD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 424);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.listBoxFunctions);
            this.Controls.Add(this.comboBoxFunctionGroup);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.textBoxInstanceName);
            this.Controls.Add(this.numericUpDownNoOfInputs);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InsertFBD";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Function";
            this.Load += new System.EventHandler(this.Block_Properties_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNoOfInputs)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.NumericUpDown numericUpDownNoOfInputs;
        private System.Windows.Forms.TextBox textBoxInstanceName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ComboBox comboBoxFunctionGroup;
        private System.Windows.Forms.ListBox listBoxFunctions;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;

    }
}