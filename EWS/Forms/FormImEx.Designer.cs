namespace DCS.Forms
{
    partial class FormImEx
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormImEx));
            this.textBoxEXfimename = new System.Windows.Forms.TextBox();
            this.buttonSelectFilename = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonRemove = new System.Windows.Forms.RadioButton();
            this.radioButtonExport = new System.Windows.Forms.RadioButton();
            this.radioButtonUpdate = new System.Windows.Forms.RadioButton();
            this.radioButtonAdd = new System.Windows.Forms.RadioButton();
            this.comboBoxseletedTable = new System.Windows.Forms.ComboBox();
            this.comboBoxSelect1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxSelect2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxEXfimename
            // 
            this.textBoxEXfimename.Location = new System.Drawing.Point(12, 156);
            this.textBoxEXfimename.Name = "textBoxEXfimename";
            this.textBoxEXfimename.Size = new System.Drawing.Size(359, 20);
            this.textBoxEXfimename.TabIndex = 3;
            // 
            // buttonSelectFilename
            // 
            this.buttonSelectFilename.Location = new System.Drawing.Point(377, 154);
            this.buttonSelectFilename.Name = "buttonSelectFilename";
            this.buttonSelectFilename.Size = new System.Drawing.Size(25, 23);
            this.buttonSelectFilename.TabIndex = 4;
            this.buttonSelectFilename.Text = "...";
            this.buttonSelectFilename.UseVisualStyleBackColor = true;
            this.buttonSelectFilename.Click += new System.EventHandler(this.buttonSelectFilename_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Image = ((System.Drawing.Image)(resources.GetObject("buttonCancel.Image")));
            this.buttonCancel.Location = new System.Drawing.Point(266, 199);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(26, 26);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Image = ((System.Drawing.Image)(resources.GetObject("buttonOK.Image")));
            this.buttonOK.Location = new System.Drawing.Point(120, 199);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(26, 26);
            this.buttonOK.TabIndex = 5;
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonRemove);
            this.groupBox1.Controls.Add(this.radioButtonExport);
            this.groupBox1.Controls.Add(this.radioButtonUpdate);
            this.groupBox1.Controls.Add(this.radioButtonAdd);
            this.groupBox1.Location = new System.Drawing.Point(18, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(117, 117);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Action";
            // 
            // radioButtonRemove
            // 
            this.radioButtonRemove.AutoSize = true;
            this.radioButtonRemove.Location = new System.Drawing.Point(6, 90);
            this.radioButtonRemove.Name = "radioButtonRemove";
            this.radioButtonRemove.Size = new System.Drawing.Size(65, 17);
            this.radioButtonRemove.TabIndex = 3;
            this.radioButtonRemove.TabStop = true;
            this.radioButtonRemove.Text = "Remove";
            this.radioButtonRemove.UseVisualStyleBackColor = true;
            // 
            // radioButtonExport
            // 
            this.radioButtonExport.AutoSize = true;
            this.radioButtonExport.Location = new System.Drawing.Point(7, 67);
            this.radioButtonExport.Name = "radioButtonExport";
            this.radioButtonExport.Size = new System.Drawing.Size(55, 17);
            this.radioButtonExport.TabIndex = 2;
            this.radioButtonExport.TabStop = true;
            this.radioButtonExport.Text = "Export";
            this.radioButtonExport.UseVisualStyleBackColor = true;
            // 
            // radioButtonUpdate
            // 
            this.radioButtonUpdate.AutoSize = true;
            this.radioButtonUpdate.Location = new System.Drawing.Point(7, 44);
            this.radioButtonUpdate.Name = "radioButtonUpdate";
            this.radioButtonUpdate.Size = new System.Drawing.Size(60, 17);
            this.radioButtonUpdate.TabIndex = 1;
            this.radioButtonUpdate.TabStop = true;
            this.radioButtonUpdate.Text = "Update";
            this.radioButtonUpdate.UseVisualStyleBackColor = true;
            // 
            // radioButtonAdd
            // 
            this.radioButtonAdd.AutoSize = true;
            this.radioButtonAdd.Location = new System.Drawing.Point(7, 20);
            this.radioButtonAdd.Name = "radioButtonAdd";
            this.radioButtonAdd.Size = new System.Drawing.Size(44, 17);
            this.radioButtonAdd.TabIndex = 0;
            this.radioButtonAdd.TabStop = true;
            this.radioButtonAdd.Text = "Add";
            this.radioButtonAdd.UseVisualStyleBackColor = true;
            // 
            // comboBoxseletedTable
            // 
            this.comboBoxseletedTable.FormattingEnabled = true;
            this.comboBoxseletedTable.Items.AddRange(new object[] {
            "Controller",
            "POU",
            "Board",
            "Channel",
            "Variable",
            "BOOL",
            "REAL",
            "HMI",
            "Alarm",
            "Function",
            "FormalParameter"});
            this.comboBoxseletedTable.Location = new System.Drawing.Point(236, 27);
            this.comboBoxseletedTable.Name = "comboBoxseletedTable";
            this.comboBoxseletedTable.Size = new System.Drawing.Size(121, 21);
            this.comboBoxseletedTable.TabIndex = 0;
            this.comboBoxseletedTable.SelectedIndexChanged += new System.EventHandler(this.comboBoxseletedTable_SelectedIndexChanged);
            // 
            // comboBoxSelect1
            // 
            this.comboBoxSelect1.FormattingEnabled = true;
            this.comboBoxSelect1.Location = new System.Drawing.Point(236, 57);
            this.comboBoxSelect1.Name = "comboBoxSelect1";
            this.comboBoxSelect1.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSelect1.TabIndex = 1;
            this.comboBoxSelect1.Visible = false;
            this.comboBoxSelect1.SelectedValueChanged += new System.EventHandler(this.comboBoxSelect1_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(147, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Table Name";
            // 
            // comboBoxSelect2
            // 
            this.comboBoxSelect2.FormattingEnabled = true;
            this.comboBoxSelect2.Location = new System.Drawing.Point(236, 88);
            this.comboBoxSelect2.Name = "comboBoxSelect2";
            this.comboBoxSelect2.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSelect2.TabIndex = 2;
            this.comboBoxSelect2.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(147, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Table";
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(147, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Table";
            this.label3.Visible = false;
            // 
            // FormImEx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 237);
            this.Controls.Add(this.comboBoxSelect2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxSelect1);
            this.Controls.Add(this.comboBoxseletedTable);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonSelectFilename);
            this.Controls.Add(this.textBoxEXfimename);
            this.Name = "FormImEx";
            this.Text = "FormImEx";
            this.Load += new System.EventHandler(this.FormImEx_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxEXfimename;
        private System.Windows.Forms.Button buttonSelectFilename;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonUpdate;
        private System.Windows.Forms.RadioButton radioButtonAdd;
        private System.Windows.Forms.ComboBox comboBoxseletedTable;
        private System.Windows.Forms.RadioButton radioButtonExport;
        private System.Windows.Forms.RadioButton radioButtonRemove;
        private System.Windows.Forms.ComboBox comboBoxSelect1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxSelect2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}