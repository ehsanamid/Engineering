namespace DCS.Forms
{
    partial class VarListFilterfrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VarListFilterfrm));
            this.triStateTreeView1 = new DockSample.TriStateTreeView();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonTextFilter = new System.Windows.Forms.Button();
            this.buttonClearFilter = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // triStateTreeView1
            // 
            this.triStateTreeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.triStateTreeView1.CheckBoxes = true;
            this.triStateTreeView1.Location = new System.Drawing.Point(1, 55);
            this.triStateTreeView1.Margin = new System.Windows.Forms.Padding(1);
            this.triStateTreeView1.Name = "triStateTreeView1";
            this.triStateTreeView1.Size = new System.Drawing.Size(184, 162);
            this.triStateTreeView1.TabIndex = 0;
            this.triStateTreeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.triStateTreeView1_AfterSelect);
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(25, 233);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(52, 21);
            this.buttonOk.TabIndex = 1;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(107, 233);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(52, 21);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonTextFilter
            // 
            this.buttonTextFilter.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonTextFilter.FlatAppearance.BorderSize = 0;
            this.buttonTextFilter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonTextFilter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.buttonTextFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTextFilter.Image = ((System.Drawing.Image)(resources.GetObject("buttonTextFilter.Image")));
            this.buttonTextFilter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonTextFilter.Location = new System.Drawing.Point(6, 30);
            this.buttonTextFilter.Name = "buttonTextFilter";
            this.buttonTextFilter.Size = new System.Drawing.Size(127, 21);
            this.buttonTextFilter.TabIndex = 4;
            this.buttonTextFilter.Text = "Text Filter";
            this.buttonTextFilter.UseVisualStyleBackColor = false;
            this.buttonTextFilter.Click += new System.EventHandler(this.buttonTextFilter_Click);
            // 
            // buttonClearFilter
            // 
            this.buttonClearFilter.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonClearFilter.FlatAppearance.BorderSize = 0;
            this.buttonClearFilter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonClearFilter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.buttonClearFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClearFilter.Image = ((System.Drawing.Image)(resources.GetObject("buttonClearFilter.Image")));
            this.buttonClearFilter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonClearFilter.Location = new System.Drawing.Point(6, 3);
            this.buttonClearFilter.Name = "buttonClearFilter";
            this.buttonClearFilter.Size = new System.Drawing.Size(127, 21);
            this.buttonClearFilter.TabIndex = 4;
            this.buttonClearFilter.Text = "Clear Filter";
            this.buttonClearFilter.UseVisualStyleBackColor = false;
            this.buttonClearFilter.Click += new System.EventHandler(this.buttonClearFilter_Click);
            // 
            // VarListFilterfrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(187, 260);
            this.Controls.Add(this.buttonClearFilter);
            this.Controls.Add(this.buttonTextFilter);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.triStateTreeView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VarListFilterfrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "VarListFilterfrm";
            this.Load += new System.EventHandler(this.VarListFilterfrm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DockSample.TriStateTreeView triStateTreeView1;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonTextFilter;
        private System.Windows.Forms.Button buttonClearFilter;
    }
}