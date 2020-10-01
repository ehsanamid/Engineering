namespace DockSample
{
    partial class BlockExplorer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BlockExplorer));
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.ImageIndex = 9;
            this.treeView1.LineColor = System.Drawing.Color.Black;
            this.treeView1.Size = new System.Drawing.Size(212, 294);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            this.imageList1.Images.SetKeyName(4, "");
            this.imageList1.Images.SetKeyName(5, "");
            this.imageList1.Images.SetKeyName(6, "");
            this.imageList1.Images.SetKeyName(7, "");
            this.imageList1.Images.SetKeyName(8, "");
            this.imageList1.Images.SetKeyName(9, "");
            // 
            // BlockExplorer
            // 
            this.ClientSize = new System.Drawing.Size(212, 322);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BlockExplorer";
            this.TabText = "Block Explorer";
            this.Text = "Block Explorer";
            this.Load += new System.EventHandler(this.BlockExplorer_Load);
            this.Shown += new System.EventHandler(this.BlockExplorer_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        
    }
}