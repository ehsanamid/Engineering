namespace EWS.OtherControls
{
    partial class FloatControl
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
            this.panelControl = new System.Windows.Forms.Panel();
            this.buttonLeftClose = new System.Windows.Forms.Button();
            this.PanelTitle = new System.Windows.Forms.Label();
            this.panelInside = new System.Windows.Forms.Panel();
            this.panelControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl
            // 
            this.panelControl.Controls.Add(this.panelInside);
            this.panelControl.Controls.Add(this.buttonLeftClose);
            this.panelControl.Controls.Add(this.PanelTitle);
            this.panelControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl.Location = new System.Drawing.Point(0, 0);
            this.panelControl.Name = "panelControl";
            this.panelControl.Size = new System.Drawing.Size(183, 255);
            this.panelControl.TabIndex = 0;
            // 
            // buttonLeftClose
            // 
            this.buttonLeftClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLeftClose.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonLeftClose.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonLeftClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLeftClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLeftClose.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.buttonLeftClose.Location = new System.Drawing.Point(162, 0);
            this.buttonLeftClose.Name = "buttonLeftClose";
            this.buttonLeftClose.Size = new System.Drawing.Size(21, 21);
            this.buttonLeftClose.TabIndex = 23;
            this.buttonLeftClose.Text = "X";
            this.buttonLeftClose.UseVisualStyleBackColor = false;
            this.buttonLeftClose.Click += new System.EventHandler(this.buttonLeftClose_Click);
            this.buttonLeftClose.MouseEnter += new System.EventHandler(this.buttonLeftClose_MouseEnter);
            this.buttonLeftClose.MouseLeave += new System.EventHandler(this.buttonLeftClose_MouseLeave);
            // 
            // PanelTitle
            // 
            this.PanelTitle.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.PanelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelTitle.Location = new System.Drawing.Point(0, 0);
            this.PanelTitle.Name = "PanelTitle";
            this.PanelTitle.Size = new System.Drawing.Size(183, 25);
            this.PanelTitle.TabIndex = 0;
            this.PanelTitle.Text = "label1";
            this.PanelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PanelTitle.MouseEnter += new System.EventHandler(this.PanelTitle_MouseEnter);
            this.PanelTitle.MouseLeave += new System.EventHandler(this.PanelTitle_MouseLeave);
            // 
            // panelInside
            // 
            this.panelInside.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelInside.Location = new System.Drawing.Point(0, 25);
            this.panelInside.Name = "panelInside";
            this.panelInside.Size = new System.Drawing.Size(183, 230);
            this.panelInside.TabIndex = 24;
            // 
            // FloatControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl);
            this.Name = "FloatControl";
            this.Size = new System.Drawing.Size(183, 255);
            this.panelControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelControl;
        private System.Windows.Forms.Label PanelTitle;
        private System.Windows.Forms.Button buttonLeftClose;
        private System.Windows.Forms.Panel panelInside;
    }
}
