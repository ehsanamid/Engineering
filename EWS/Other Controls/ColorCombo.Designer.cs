namespace EWS.OtherControls
{
    partial class ColorCombo
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
            this.label_StartColor = new System.Windows.Forms.Label();
            this.button_SelectStartColor = new System.Windows.Forms.Button();
            this.panelColor1 = new System.Windows.Forms.Panel();
            this.labelColor1 = new System.Windows.Forms.Label();
            this.panel_StartColor = new System.Windows.Forms.Panel();
            this.panelColor1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_StartColor
            // 
            this.label_StartColor.Location = new System.Drawing.Point(2, 1);
            this.label_StartColor.Name = "label_StartColor";
            this.label_StartColor.Size = new System.Drawing.Size(57, 17);
            this.label_StartColor.TabIndex = 41;
            this.label_StartColor.Text = "Start Color";
            // 
            // button_SelectStartColor
            // 
            this.button_SelectStartColor.BackColor = System.Drawing.Color.DarkGray;
            this.button_SelectStartColor.Image = global::ENG.Properties.Resources.down;
            this.button_SelectStartColor.Location = new System.Drawing.Point(141, 17);
            this.button_SelectStartColor.Margin = new System.Windows.Forms.Padding(0);
            this.button_SelectStartColor.Name = "button_SelectStartColor";
            this.button_SelectStartColor.Size = new System.Drawing.Size(19, 23);
            this.button_SelectStartColor.TabIndex = 44;
            this.button_SelectStartColor.UseVisualStyleBackColor = false;
            this.button_SelectStartColor.Click += new System.EventHandler(this.button_SelectStartColor_Click);
            // 
            // panelColor1
            // 
            this.panelColor1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelColor1.Controls.Add(this.labelColor1);
            this.panelColor1.Controls.Add(this.panel_StartColor);
            this.panelColor1.Location = new System.Drawing.Point(2, 18);
            this.panelColor1.Margin = new System.Windows.Forms.Padding(0);
            this.panelColor1.Name = "panelColor1";
            this.panelColor1.Size = new System.Drawing.Size(142, 21);
            this.panelColor1.TabIndex = 50;
            // 
            // labelColor1
            // 
            this.labelColor1.AutoSize = true;
            this.labelColor1.Location = new System.Drawing.Point(21, 2);
            this.labelColor1.Name = "labelColor1";
            this.labelColor1.Size = new System.Drawing.Size(35, 13);
            this.labelColor1.TabIndex = 43;
            this.labelColor1.Text = "label2";
            // 
            // panel_StartColor
            // 
            this.panel_StartColor.BackColor = System.Drawing.Color.Black;
            this.panel_StartColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_StartColor.Location = new System.Drawing.Point(0, 0);
            this.panel_StartColor.Margin = new System.Windows.Forms.Padding(0);
            this.panel_StartColor.Name = "panel_StartColor";
            this.panel_StartColor.Size = new System.Drawing.Size(21, 21);
            this.panel_StartColor.TabIndex = 42;
            this.panel_StartColor.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_StartColor_Paint);
            // 
            // ColorCombo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelColor1);
            this.Controls.Add(this.button_SelectStartColor);
            this.Controls.Add(this.label_StartColor);
            this.Name = "ColorCombo";
            this.Size = new System.Drawing.Size(162, 42);
            this.Load += new System.EventHandler(this.ShapeFillfrm_Load);
            this.EnabledChanged += new System.EventHandler(this.ColorCombo_EnabledChanged);
            this.VisibleChanged += new System.EventHandler(this.ColorCombo_VisibleChanged);
            this.panelColor1.ResumeLayout(false);
            this.panelColor1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_StartColor;
        private System.Windows.Forms.Button button_SelectStartColor;
        private System.Windows.Forms.Panel panelColor1;
        private System.Windows.Forms.Label labelColor1;
        private System.Windows.Forms.Panel panel_StartColor;

    }
}