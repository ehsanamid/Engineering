namespace DockSample
{
    partial class VarExplorer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VarExplorer));
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            //this.dataGridViewVar = new System.Windows.Forms.DataGridView();
            //this.gridGroupingControl1 = new Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripComboBoxDomain = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripComboBoxController = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripComboBoxProgram = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            //((System.ComponentModel.ISupportInitialize)(this.dataGridViewVar)).BeginInit();
            //((System.ComponentModel.ISupportInitialize)(this.gridGroupingControl1)).BeginInit();
            
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridGroupingControl1
            // 
           

            //// 
            //// dataGridViewVar
            //// 
            //this.dataGridViewVar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            //this.dataGridViewVar.Location = new System.Drawing.Point(247, 55);
            //this.dataGridViewVar.Name = "dataGridViewVar";
            //this.dataGridViewVar.Size = new System.Drawing.Size(335, 272);
            //this.dataGridViewVar.TabIndex = 3;
            //this.dataGridViewVar.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewVar_CellContentClick);
            //this.dataGridViewVar.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewVar_ColumnHeaderMouseClick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonAdd,
            this.toolStripButtonEdit,
            this.toolStripButtonDelete,
            this.toolStripSeparator1,
            this.toolStripComboBoxDomain,
            this.toolStripComboBoxController,
            this.toolStripComboBoxProgram,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 4);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(644, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonAdd
            // 
            this.toolStripButtonAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAdd.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAdd.Image")));
            this.toolStripButtonAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAdd.Name = "toolStripButtonAdd";
            this.toolStripButtonAdd.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonAdd.Text = "Add";
            this.toolStripButtonAdd.Click += new System.EventHandler(this.toolStripButtonAdd_Click);
            // 
            // toolStripButtonEdit
            // 
            this.toolStripButtonEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonEdit.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonEdit.Image")));
            this.toolStripButtonEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEdit.Name = "toolStripButtonEdit";
            this.toolStripButtonEdit.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonEdit.Text = "toolStripButtonEdit";
            // 
            // toolStripButtonDelete
            // 
            this.toolStripButtonDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDelete.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonDelete.Image")));
            this.toolStripButtonDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDelete.Name = "toolStripButtonDelete";
            this.toolStripButtonDelete.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonDelete.Text = "Delete";
            this.toolStripButtonDelete.Click += new System.EventHandler(this.toolStripButtonDelete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripComboBoxDomain
            // 
            this.toolStripComboBoxDomain.Name = "toolStripComboBoxDomain";
            this.toolStripComboBoxDomain.Size = new System.Drawing.Size(121, 25);
            this.toolStripComboBoxDomain.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBoxDomain_SelectedIndexChanged);
            this.toolStripComboBoxDomain.Click += new System.EventHandler(this.toolStripComboBoxDomain_Click);
            // 
            // toolStripComboBoxController
            // 
            this.toolStripComboBoxController.Name = "toolStripComboBoxController";
            this.toolStripComboBoxController.Size = new System.Drawing.Size(121, 25);
            this.toolStripComboBoxController.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBoxController_SelectedIndexChanged);
            this.toolStripComboBoxController.Click += new System.EventHandler(this.toolStripComboBoxController_Click);
            // 
            // toolStripComboBoxProgram
            // 
            this.toolStripComboBoxProgram.Name = "toolStripComboBoxProgram";
            this.toolStripComboBoxProgram.Size = new System.Drawing.Size(121, 25);
            this.toolStripComboBoxProgram.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBoxProgram_SelectedIndexChanged);
            this.toolStripComboBoxProgram.Click += new System.EventHandler(this.toolStripComboBoxProgram_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "Refresh";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // VarExplorer
            // 
            this.ClientSize = new System.Drawing.Size(644, 393);
            //this.Controls.Add(this.dataGridViewVar);
            //this.Controls.Add(this.gridGroupingControl1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VarExplorer";
            this.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.Load += new System.EventHandler(this.VarExplorer_Load);
            //((System.ComponentModel.ISupportInitialize)(this.gridGroupingControl1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        private System.Windows.Forms.ToolTip toolTip;
        //private System.Windows.Forms.DataGridView dataGridViewVar;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonAdd;
        private System.Windows.Forms.ToolStripButton toolStripButtonDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxDomain;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxController;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxProgram;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButtonEdit;
       
    }
}