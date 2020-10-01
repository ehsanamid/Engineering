namespace DCS.Forms
{
    partial class AlarmGroupFrom
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.NameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeCol = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ArchiveCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.RetriggerCol = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.PrintCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.delteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NameCol,
            this.TypeCol,
            this.ArchiveCol,
            this.RetriggerCol,
            this.PrintCol});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(592, 228);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_CellBeginEdit);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.ColumnHeaderCellChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dataGridView1_ColumnHeaderCellChanged);
            this.dataGridView1.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dataGridView1_ColumnWidthChanged);
            this.dataGridView1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowEnter);
            this.dataGridView1.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView1_RowsAdded);
            // 
            // NameCol
            // 
            this.NameCol.HeaderText = "Name";
            this.NameCol.Name = "NameCol";
            // 
            // TypeCol
            // 
            this.TypeCol.HeaderText = "Type";
            this.TypeCol.Items.AddRange(new object[] {
            "Self Acknowledge",
            "Acknowledge on Set",
            "Acknowledge on Set/Reset",
            "Event"});
            this.TypeCol.Name = "TypeCol";
            // 
            // ArchiveCol
            // 
            this.ArchiveCol.HeaderText = "Archive";
            this.ArchiveCol.Name = "ArchiveCol";
            // 
            // RetriggerCol
            // 
            this.RetriggerCol.HeaderText = "Retrigger";
            this.RetriggerCol.Items.AddRange(new object[] {
            "No",
            "1 Minute",
            "10 Minute",
            "1 Hour"});
            this.RetriggerCol.Name = "RetriggerCol";
            this.RetriggerCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // PrintCol
            // 
            this.PrintCol.HeaderText = "Print";
            this.PrintCol.Name = "PrintCol";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.delteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(102, 26);
            // 
            // delteToolStripMenuItem
            // 
            this.delteToolStripMenuItem.Name = "delteToolStripMenuItem";
            this.delteToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.delteToolStripMenuItem.Text = "Delte";
            this.delteToolStripMenuItem.Click += new System.EventHandler(this.delteToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(592, 228);
            this.panel1.TabIndex = 1;
            // 
            // AlarmGroupFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 284);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AlarmGroupFrom";
            this.Text = "AlarmGroupFrm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameCol;
        private System.Windows.Forms.DataGridViewComboBoxColumn TypeCol;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ArchiveCol;
        private System.Windows.Forms.DataGridViewComboBoxColumn RetriggerCol;
        private System.Windows.Forms.DataGridViewCheckBoxColumn PrintCol;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem delteToolStripMenuItem;
    }
}