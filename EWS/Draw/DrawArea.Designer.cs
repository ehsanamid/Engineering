namespace DCS.Draw
{
    partial class DrawArea
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // DrawArea
            // 
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "DrawArea";
            this.Load += new System.EventHandler(this.DrawArea_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawArea_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DrawArea_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DrawArea_KeyPress);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.DrawArea_MouseDoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DrawArea_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DrawArea_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DrawArea_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
        

	}
}
