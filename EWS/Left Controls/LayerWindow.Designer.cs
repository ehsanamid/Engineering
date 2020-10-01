namespace DCS.LeftControls
{
    partial class LayerWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LayerWindow));
            this.dataGridViewLayer = new System.Windows.Forms.DataGridView();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEnable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnLock = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLayer)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewLayer
            // 
            this.dataGridViewLayer.AllowUserToAddRows = false;
            this.dataGridViewLayer.AllowUserToDeleteRows = false;
            this.dataGridViewLayer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLayer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnName,
            this.ColumnDescription,
            this.ColumnEnable,
            this.ColumnLock});
            this.dataGridViewLayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewLayer.Location = new System.Drawing.Point(0, 2);
            this.dataGridViewLayer.Name = "dataGridViewLayer";
            this.dataGridViewLayer.Size = new System.Drawing.Size(255, 361);
            this.dataGridViewLayer.TabIndex = 0;
            this.dataGridViewLayer.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewLayer_CellContentClick);
            // 
            // ColumnName
            // 
            this.ColumnName.HeaderText = "Name";
            this.ColumnName.Name = "ColumnName";
            // 
            // ColumnDescription
            // 
            this.ColumnDescription.HeaderText = "Description";
            this.ColumnDescription.Name = "ColumnDescription";
            // 
            // ColumnEnable
            // 
            this.ColumnEnable.HeaderText = "Enable";
            this.ColumnEnable.Name = "ColumnEnable";
            // 
            // ColumnLock
            // 
            this.ColumnLock.HeaderText = "Lock";
            this.ColumnLock.Name = "ColumnLock";
            // 
            // LayerWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(255, 365);
            this.Controls.Add(this.dataGridViewLayer);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HideOnClose = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LayerWindow";
            this.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockBottomAutoHide;
            this.TabText = "Layer";
            this.Text = "Layer";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLayer)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.DataGridView dataGridViewLayer;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDescription;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnEnable;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnLock;

    }
}