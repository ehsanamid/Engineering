namespace DCS.Forms
{
    partial class UDFPinForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UDFPinForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.tabControlUDFPinDef = new System.Windows.Forms.TabControl();
            this.tabPageInput = new System.Windows.Forms.TabPage();
            this.dataGridViewInput = new System.Windows.Forms.DataGridView();
            this.ColumnInputName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnInputDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnInputType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnInputClass = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnInputInitialValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStripInput = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addInputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteInputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveInputUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveInputDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPageOutput = new System.Windows.Forms.TabPage();
            this.dataGridViewOutput = new System.Windows.Forms.DataGridView();
            this.ColumnOutputName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOutputDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOutputType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnOutputClass = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnOutputInitialValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStripOutput = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addOutputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteOutputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveOutputUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveOutputDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPageLocal = new System.Windows.Forms.TabPage();
            this.dataGridViewLocal = new System.Windows.Forms.DataGridView();
            this.ColumnLocalName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLocalDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLocalType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnLocalClass = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnLocalInitialValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStripLocal = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addLocalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteLocalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonHelp = new System.Windows.Forms.Button();
            this.tabControlUDFPinDef.SuspendLayout();
            this.tabPageInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInput)).BeginInit();
            this.contextMenuStripInput.SuspendLayout();
            this.tabPageOutput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOutput)).BeginInit();
            this.contextMenuStripOutput.SuspendLayout();
            this.tabPageLocal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLocal)).BeginInit();
            this.contextMenuStripLocal.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Image = ((System.Drawing.Image)(resources.GetObject("buttonCancel.Image")));
            this.buttonCancel.Location = new System.Drawing.Point(434, 237);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(26, 26);
            this.buttonCancel.TabIndex = 12;
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.Image = ((System.Drawing.Image)(resources.GetObject("buttonOk.Image")));
            this.buttonOk.Location = new System.Drawing.Point(196, 237);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(26, 26);
            this.buttonOk.TabIndex = 11;
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // tabControlUDFPinDef
            // 
            this.tabControlUDFPinDef.Controls.Add(this.tabPageInput);
            this.tabControlUDFPinDef.Controls.Add(this.tabPageOutput);
            this.tabControlUDFPinDef.Controls.Add(this.tabPageLocal);
            this.tabControlUDFPinDef.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControlUDFPinDef.Location = new System.Drawing.Point(0, 0);
            this.tabControlUDFPinDef.Name = "tabControlUDFPinDef";
            this.tabControlUDFPinDef.SelectedIndex = 0;
            this.tabControlUDFPinDef.Size = new System.Drawing.Size(687, 231);
            this.tabControlUDFPinDef.TabIndex = 13;
            // 
            // tabPageInput
            // 
            this.tabPageInput.Controls.Add(this.dataGridViewInput);
            this.tabPageInput.Location = new System.Drawing.Point(4, 22);
            this.tabPageInput.Name = "tabPageInput";
            this.tabPageInput.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageInput.Size = new System.Drawing.Size(679, 205);
            this.tabPageInput.TabIndex = 0;
            this.tabPageInput.Text = "Input Connections";
            this.tabPageInput.UseVisualStyleBackColor = true;
            // 
            // dataGridViewInput
            // 
            this.dataGridViewInput.AllowUserToAddRows = false;
            this.dataGridViewInput.AllowUserToResizeRows = false;
            this.dataGridViewInput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInput.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnInputName,
            this.ColumnInputDesc,
            this.ColumnInputType,
            this.ColumnInputClass,
            this.ColumnInputInitialValue});
            this.dataGridViewInput.ContextMenuStrip = this.contextMenuStripInput;
            this.dataGridViewInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridViewInput.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewInput.MultiSelect = false;
            this.dataGridViewInput.Name = "dataGridViewInput";
            this.dataGridViewInput.Size = new System.Drawing.Size(673, 205);
            this.dataGridViewInput.TabIndex = 0;
            this.dataGridViewInput.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewInput_CellValueChanged);
            // 
            // ColumnInputName
            // 
            this.ColumnInputName.HeaderText = "Name";
            this.ColumnInputName.Name = "ColumnInputName";
            // 
            // ColumnInputDesc
            // 
            this.ColumnInputDesc.HeaderText = "Description";
            this.ColumnInputDesc.Name = "ColumnInputDesc";
            this.ColumnInputDesc.Width = 229;
            // 
            // ColumnInputType
            // 
            dataGridViewCellStyle15.NullValue = "BOOL";
            this.ColumnInputType.DefaultCellStyle = dataGridViewCellStyle15;
            this.ColumnInputType.HeaderText = "Type";
            this.ColumnInputType.Name = "ColumnInputType";
            this.ColumnInputType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnInputType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ColumnInputClass
            // 
            dataGridViewCellStyle16.NullValue = "Input";
            this.ColumnInputClass.DefaultCellStyle = dataGridViewCellStyle16;
            this.ColumnInputClass.HeaderText = "Class";
            this.ColumnInputClass.Items.AddRange(new object[] {
            "Input",
            "InOut",
            "Reference"});
            this.ColumnInputClass.Name = "ColumnInputClass";
            this.ColumnInputClass.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnInputClass.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ColumnInputInitialValue
            // 
            this.ColumnInputInitialValue.HeaderText = "Initial Value";
            this.ColumnInputInitialValue.Name = "ColumnInputInitialValue";
            // 
            // contextMenuStripInput
            // 
            this.contextMenuStripInput.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addInputToolStripMenuItem,
            this.deleteInputToolStripMenuItem,
            this.moveInputUpToolStripMenuItem,
            this.moveInputDownToolStripMenuItem});
            this.contextMenuStripInput.Name = "contextMenuStrip1";
            this.contextMenuStripInput.Size = new System.Drawing.Size(139, 92);
            this.contextMenuStripInput.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripInput_Opening);
            // 
            // addInputToolStripMenuItem
            // 
            this.addInputToolStripMenuItem.Name = "addInputToolStripMenuItem";
            this.addInputToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.addInputToolStripMenuItem.Text = "Add";
            this.addInputToolStripMenuItem.Click += new System.EventHandler(this.addInputToolStripMenuItem_Click);
            // 
            // deleteInputToolStripMenuItem
            // 
            this.deleteInputToolStripMenuItem.Name = "deleteInputToolStripMenuItem";
            this.deleteInputToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.deleteInputToolStripMenuItem.Text = "Delete";
            this.deleteInputToolStripMenuItem.Click += new System.EventHandler(this.deleteInputToolStripMenuItem_Click);
            // 
            // moveInputUpToolStripMenuItem
            // 
            this.moveInputUpToolStripMenuItem.Name = "moveInputUpToolStripMenuItem";
            this.moveInputUpToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.moveInputUpToolStripMenuItem.Text = "Move Up";
            this.moveInputUpToolStripMenuItem.Click += new System.EventHandler(this.moveInputUpToolStripMenuItem_Click);
            // 
            // moveInputDownToolStripMenuItem
            // 
            this.moveInputDownToolStripMenuItem.Name = "moveInputDownToolStripMenuItem";
            this.moveInputDownToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.moveInputDownToolStripMenuItem.Text = "Move Down";
            this.moveInputDownToolStripMenuItem.Click += new System.EventHandler(this.moveInputDownToolStripMenuItem_Click);
            // 
            // tabPageOutput
            // 
            this.tabPageOutput.Controls.Add(this.dataGridViewOutput);
            this.tabPageOutput.Location = new System.Drawing.Point(4, 22);
            this.tabPageOutput.Name = "tabPageOutput";
            this.tabPageOutput.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOutput.Size = new System.Drawing.Size(679, 205);
            this.tabPageOutput.TabIndex = 1;
            this.tabPageOutput.Text = "Output Connections";
            this.tabPageOutput.UseVisualStyleBackColor = true;
            // 
            // dataGridViewOutput
            // 
            this.dataGridViewOutput.AllowUserToAddRows = false;
            this.dataGridViewOutput.AllowUserToResizeRows = false;
            this.dataGridViewOutput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOutput.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnOutputName,
            this.ColumnOutputDesc,
            this.ColumnOutputType,
            this.ColumnOutputClass,
            this.ColumnOutputInitialValue});
            this.dataGridViewOutput.ContextMenuStrip = this.contextMenuStripOutput;
            this.dataGridViewOutput.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridViewOutput.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewOutput.MultiSelect = false;
            this.dataGridViewOutput.Name = "dataGridViewOutput";
            this.dataGridViewOutput.Size = new System.Drawing.Size(673, 205);
            this.dataGridViewOutput.TabIndex = 0;
            this.dataGridViewOutput.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewOutput_CellValueChanged);
            // 
            // ColumnOutputName
            // 
            this.ColumnOutputName.HeaderText = "Name";
            this.ColumnOutputName.Name = "ColumnOutputName";
            // 
            // ColumnOutputDesc
            // 
            this.ColumnOutputDesc.HeaderText = "Description";
            this.ColumnOutputDesc.Name = "ColumnOutputDesc";
            this.ColumnOutputDesc.Width = 229;
            // 
            // ColumnOutputType
            // 
            dataGridViewCellStyle17.NullValue = "BOOL";
            this.ColumnOutputType.DefaultCellStyle = dataGridViewCellStyle17;
            this.ColumnOutputType.HeaderText = "Type";
            this.ColumnOutputType.Name = "ColumnOutputType";
            this.ColumnOutputType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnOutputType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ColumnOutputClass
            // 
            dataGridViewCellStyle18.NullValue = "Output";
            this.ColumnOutputClass.DefaultCellStyle = dataGridViewCellStyle18;
            this.ColumnOutputClass.HeaderText = "Class";
            this.ColumnOutputClass.Items.AddRange(new object[] {
            "Output"});
            this.ColumnOutputClass.Name = "ColumnOutputClass";
            this.ColumnOutputClass.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnOutputClass.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ColumnOutputInitialValue
            // 
            this.ColumnOutputInitialValue.HeaderText = "Initial Value";
            this.ColumnOutputInitialValue.Name = "ColumnOutputInitialValue";
            // 
            // contextMenuStripOutput
            // 
            this.contextMenuStripOutput.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addOutputToolStripMenuItem,
            this.deleteOutputToolStripMenuItem,
            this.moveOutputUpToolStripMenuItem,
            this.moveOutputDownToolStripMenuItem});
            this.contextMenuStripOutput.Name = "contextMenuStrip1";
            this.contextMenuStripOutput.Size = new System.Drawing.Size(139, 92);
            this.contextMenuStripOutput.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripOutput_Opening);
            // 
            // addOutputToolStripMenuItem
            // 
            this.addOutputToolStripMenuItem.Name = "addOutputToolStripMenuItem";
            this.addOutputToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.addOutputToolStripMenuItem.Text = "Add";
            this.addOutputToolStripMenuItem.Click += new System.EventHandler(this.addOutputToolStripMenuItem_Click);
            // 
            // deleteOutputToolStripMenuItem
            // 
            this.deleteOutputToolStripMenuItem.Name = "deleteOutputToolStripMenuItem";
            this.deleteOutputToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.deleteOutputToolStripMenuItem.Text = "Delete";
            this.deleteOutputToolStripMenuItem.Click += new System.EventHandler(this.deleteOutputToolStripMenuItem_Click);
            // 
            // moveOutputUpToolStripMenuItem
            // 
            this.moveOutputUpToolStripMenuItem.Name = "moveOutputUpToolStripMenuItem";
            this.moveOutputUpToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.moveOutputUpToolStripMenuItem.Text = "Move Up";
            this.moveOutputUpToolStripMenuItem.Click += new System.EventHandler(this.moveOutputUpToolStripMenuItem_Click);
            // 
            // moveOutputDownToolStripMenuItem
            // 
            this.moveOutputDownToolStripMenuItem.Name = "moveOutputDownToolStripMenuItem";
            this.moveOutputDownToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.moveOutputDownToolStripMenuItem.Text = "Move Down";
            this.moveOutputDownToolStripMenuItem.Click += new System.EventHandler(this.moveOutputDownToolStripMenuItem_Click);
            // 
            // tabPageLocal
            // 
            this.tabPageLocal.Controls.Add(this.dataGridViewLocal);
            this.tabPageLocal.Location = new System.Drawing.Point(4, 22);
            this.tabPageLocal.Name = "tabPageLocal";
            this.tabPageLocal.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLocal.Size = new System.Drawing.Size(679, 205);
            this.tabPageLocal.TabIndex = 2;
            this.tabPageLocal.Text = "Local Variables";
            this.tabPageLocal.UseVisualStyleBackColor = true;
            // 
            // dataGridViewLocal
            // 
            this.dataGridViewLocal.AllowUserToAddRows = false;
            this.dataGridViewLocal.AllowUserToResizeRows = false;
            this.dataGridViewLocal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLocal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnLocalName,
            this.ColumnLocalDesc,
            this.ColumnLocalType,
            this.ColumnLocalClass,
            this.ColumnLocalInitialValue});
            this.dataGridViewLocal.ContextMenuStrip = this.contextMenuStripLocal;
            this.dataGridViewLocal.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridViewLocal.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewLocal.MultiSelect = false;
            this.dataGridViewLocal.Name = "dataGridViewLocal";
            this.dataGridViewLocal.Size = new System.Drawing.Size(673, 205);
            this.dataGridViewLocal.TabIndex = 0;
            this.dataGridViewLocal.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewLocal_CellValueChanged);
            // 
            // ColumnLocalName
            // 
            this.ColumnLocalName.HeaderText = "Name";
            this.ColumnLocalName.Name = "ColumnLocalName";
            // 
            // ColumnLocalDesc
            // 
            this.ColumnLocalDesc.HeaderText = "Description";
            this.ColumnLocalDesc.Name = "ColumnLocalDesc";
            this.ColumnLocalDesc.Width = 229;
            // 
            // ColumnLocalType
            // 
            dataGridViewCellStyle13.NullValue = "BOOL";
            this.ColumnLocalType.DefaultCellStyle = dataGridViewCellStyle13;
            this.ColumnLocalType.HeaderText = "Type";
            this.ColumnLocalType.Name = "ColumnLocalType";
            this.ColumnLocalType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnLocalType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ColumnLocalClass
            // 
            dataGridViewCellStyle14.NullValue = "Local";
            this.ColumnLocalClass.DefaultCellStyle = dataGridViewCellStyle14;
            this.ColumnLocalClass.HeaderText = "Class";
            this.ColumnLocalClass.Items.AddRange(new object[] {
            "Local"});
            this.ColumnLocalClass.Name = "ColumnLocalClass";
            this.ColumnLocalClass.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnLocalClass.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ColumnLocalInitialValue
            // 
            this.ColumnLocalInitialValue.HeaderText = "Initial Value";
            this.ColumnLocalInitialValue.Name = "ColumnLocalInitialValue";
            // 
            // contextMenuStripLocal
            // 
            this.contextMenuStripLocal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addLocalToolStripMenuItem,
            this.deleteLocalToolStripMenuItem});
            this.contextMenuStripLocal.Name = "contextMenuStrip1";
            this.contextMenuStripLocal.Size = new System.Drawing.Size(108, 48);
            this.contextMenuStripLocal.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripLocal_Opening);
            // 
            // addLocalToolStripMenuItem
            // 
            this.addLocalToolStripMenuItem.Name = "addLocalToolStripMenuItem";
            this.addLocalToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.addLocalToolStripMenuItem.Text = "Add";
            this.addLocalToolStripMenuItem.Click += new System.EventHandler(this.addLocalToolStripMenuItem_Click);
            // 
            // deleteLocalToolStripMenuItem
            // 
            this.deleteLocalToolStripMenuItem.Name = "deleteLocalToolStripMenuItem";
            this.deleteLocalToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteLocalToolStripMenuItem.Text = "Delete";
            this.deleteLocalToolStripMenuItem.Click += new System.EventHandler(this.deleteLocalToolStripMenuItem_Click);
            // 
            // buttonHelp
            // 
            this.buttonHelp.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonHelp.Image = global::DCS.Properties.Resources.help;
            this.buttonHelp.Location = new System.Drawing.Point(654, 243);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(26, 26);
            this.buttonHelp.TabIndex = 12;
            this.buttonHelp.UseVisualStyleBackColor = true;
            this.buttonHelp.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // UDFPinForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 275);
            this.Controls.Add(this.tabControlUDFPinDef);
            this.Controls.Add(this.buttonHelp);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Name = "UDFPinForm";
            this.Text = "Pin Connections";
            this.Load += new System.EventHandler(this.UDFPinForm_Load);
            this.tabControlUDFPinDef.ResumeLayout(false);
            this.tabPageInput.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInput)).EndInit();
            this.contextMenuStripInput.ResumeLayout(false);
            this.tabPageOutput.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOutput)).EndInit();
            this.contextMenuStripOutput.ResumeLayout(false);
            this.tabPageLocal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLocal)).EndInit();
            this.contextMenuStripLocal.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.TabControl tabControlUDFPinDef;

        private System.Windows.Forms.TabPage tabPageInput;
        private System.Windows.Forms.TabPage tabPageOutput;
        private System.Windows.Forms.TabPage tabPageLocal;

        private System.Windows.Forms.DataGridView dataGridViewInput;
        private System.Windows.Forms.DataGridView dataGridViewOutput;
        private System.Windows.Forms.DataGridView dataGridViewLocal;

        private System.Windows.Forms.ContextMenuStrip contextMenuStripInput;
        private System.Windows.Forms.ToolStripMenuItem addInputToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteInputToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveInputUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveInputDownToolStripMenuItem;

        private System.Windows.Forms.ContextMenuStrip contextMenuStripOutput;
        private System.Windows.Forms.ToolStripMenuItem addOutputToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteOutputToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveOutputUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveOutputDownToolStripMenuItem;

        private System.Windows.Forms.ContextMenuStrip contextMenuStripLocal;
        private System.Windows.Forms.ToolStripMenuItem addLocalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteLocalToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnInputName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnInputDesc;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnInputType;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnInputClass;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnInputInitialValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOutputName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOutputDesc;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnOutputType;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnOutputClass;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOutputInitialValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLocalName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLocalDesc;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnLocalType;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnLocalClass;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLocalInitialValue;
        private System.Windows.Forms.Button buttonHelp;
    }
}