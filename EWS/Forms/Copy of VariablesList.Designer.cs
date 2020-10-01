namespace DCS.Forms
{
    partial class VariablesListCopy
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VariablesListCopy));
            this.bindingSource_main = new System.Windows.Forms.BindingSource(this.components);
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.textBoxInstanceName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxController = new System.Windows.Forms.ComboBox();
            this.comboBoxPOU = new System.Windows.Forms.ComboBox();
            this.comboBoxDomain = new System.Windows.Forms.ComboBox();
            this.labelDomain = new System.Windows.Forms.Label();
            this.labelController = new System.Windows.Forms.Label();
            this.labelProgram = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.comboBoxProperty = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.advancedDataGridView_main = new Zuby.ADGV.AdvancedDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_main)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView_main)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Enabled = false;
            this.buttonOK.Location = new System.Drawing.Point(117, 10);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(105, 28);
            this.buttonOK.TabIndex = 8;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(394, 10);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(105, 28);
            this.buttonCancel.TabIndex = 9;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // textBoxInstanceName
            // 
            this.textBoxInstanceName.AutoCompleteCustomSource.AddRange(new string[] {
            "dwer",
            "qwd",
            "asdr",
            "zxsd",
            "cdf"});
            this.textBoxInstanceName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBoxInstanceName.Location = new System.Drawing.Point(59, 39);
            this.textBoxInstanceName.Name = "textBoxInstanceName";
            this.textBoxInstanceName.Size = new System.Drawing.Size(150, 20);
            this.textBoxInstanceName.TabIndex = 11;
            this.textBoxInstanceName.TextChanged += new System.EventHandler(this.textBoxInstanceName_TextChanged);
            this.textBoxInstanceName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxInstanceName_KeyPress);
            this.textBoxInstanceName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxInstanceName_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Name :";
            // 
            // comboBoxController
            // 
            this.comboBoxController.FormattingEnabled = true;
            this.comboBoxController.Location = new System.Drawing.Point(276, 12);
            this.comboBoxController.Name = "comboBoxController";
            this.comboBoxController.Size = new System.Drawing.Size(142, 21);
            this.comboBoxController.TabIndex = 13;
            // 
            // comboBoxPOU
            // 
            this.comboBoxPOU.FormattingEnabled = true;
            this.comboBoxPOU.Location = new System.Drawing.Point(480, 12);
            this.comboBoxPOU.Name = "comboBoxPOU";
            this.comboBoxPOU.Size = new System.Drawing.Size(142, 21);
            this.comboBoxPOU.TabIndex = 13;
            this.comboBoxPOU.SelectedIndexChanged += new System.EventHandler(this.comboBoxPOU_SelectedIndexChanged);
            // 
            // comboBoxDomain
            // 
            this.comboBoxDomain.FormattingEnabled = true;
            this.comboBoxDomain.Location = new System.Drawing.Point(59, 12);
            this.comboBoxDomain.Name = "comboBoxDomain";
            this.comboBoxDomain.Size = new System.Drawing.Size(150, 21);
            this.comboBoxDomain.TabIndex = 13;
            // 
            // labelDomain
            // 
            this.labelDomain.AutoSize = true;
            this.labelDomain.Location = new System.Drawing.Point(7, 15);
            this.labelDomain.Name = "labelDomain";
            this.labelDomain.Size = new System.Drawing.Size(49, 13);
            this.labelDomain.TabIndex = 6;
            this.labelDomain.Text = "Domain :";
            // 
            // labelController
            // 
            this.labelController.AutoSize = true;
            this.labelController.Location = new System.Drawing.Point(217, 15);
            this.labelController.Name = "labelController";
            this.labelController.Size = new System.Drawing.Size(57, 13);
            this.labelController.TabIndex = 6;
            this.labelController.Text = "Controller :";
            // 
            // labelProgram
            // 
            this.labelProgram.AutoSize = true;
            this.labelProgram.Location = new System.Drawing.Point(426, 15);
            this.labelProgram.Name = "labelProgram";
            this.labelProgram.Size = new System.Drawing.Size(52, 13);
            this.labelProgram.TabIndex = 6;
            this.labelProgram.Text = "Program :";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonOK);
            this.panel1.Controls.Add(this.buttonCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 367);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(644, 49);
            this.panel1.TabIndex = 14;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.comboBoxController);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.comboBoxPOU);
            this.panel2.Controls.Add(this.labelDomain);
            this.panel2.Controls.Add(this.comboBoxProperty);
            this.panel2.Controls.Add(this.comboBoxDomain);
            this.panel2.Controls.Add(this.labelController);
            this.panel2.Controls.Add(this.labelProgram);
            this.panel2.Controls.Add(this.textBoxInstanceName);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(644, 74);
            this.panel2.TabIndex = 15;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // comboBoxProperty
            // 
            this.comboBoxProperty.FormattingEnabled = true;
            this.comboBoxProperty.Location = new System.Drawing.Point(215, 38);
            this.comboBoxProperty.Name = "comboBoxProperty";
            this.comboBoxProperty.Size = new System.Drawing.Size(86, 21);
            this.comboBoxProperty.TabIndex = 13;
            this.comboBoxProperty.SelectedValueChanged += new System.EventHandler(this.comboBoxProperty_SelectedValueChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.advancedDataGridView_main);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 74);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(644, 293);
            this.panel3.TabIndex = 16;
            // 
            // advancedDataGridView_main
            // 
            this.advancedDataGridView_main.AllowUserToAddRows = false;
            this.advancedDataGridView_main.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.advancedDataGridView_main.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.advancedDataGridView_main.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.advancedDataGridView_main.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advancedDataGridView_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advancedDataGridView_main.FilterAndSortEnabled = true;
            this.advancedDataGridView_main.Location = new System.Drawing.Point(0, 0);
            this.advancedDataGridView_main.Name = "advancedDataGridView_main";
            this.advancedDataGridView_main.ReadOnly = true;
            this.advancedDataGridView_main.RowHeadersVisible = false;
            this.advancedDataGridView_main.Size = new System.Drawing.Size(644, 293);
            this.advancedDataGridView_main.TabIndex = 0;
            this.advancedDataGridView_main.SortStringChanged += new System.EventHandler(this.advancedDataGridView_main_SortStringChanged);
            this.advancedDataGridView_main.FilterStringChanged += new System.EventHandler(this.advancedDataGridView_main_FilterStringChanged);
            this.advancedDataGridView_main.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.advancedDataGridView_main_CellClick);
            this.advancedDataGridView_main.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.advancedDataGridView_main_CellDoubleClick);
            // 
            // VariablesList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 416);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VariablesList";
            this.Text = "Variables";
            this.Load += new System.EventHandler(this.VariablesList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_main)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView_main)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource bindingSource_main;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox textBoxInstanceName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxController;
        private System.Windows.Forms.ComboBox comboBoxPOU;
        private System.Windows.Forms.ComboBox comboBoxDomain;
        private System.Windows.Forms.Label labelDomain;
        private System.Windows.Forms.Label labelController;
        private System.Windows.Forms.Label labelProgram;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private Zuby.ADGV.AdvancedDataGridView advancedDataGridView_main;
        private System.Windows.Forms.ComboBox comboBoxProperty;

    }
}