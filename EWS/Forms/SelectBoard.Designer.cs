namespace DCS.Forms
{
    partial class SelectBoard
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
            this.comboBoxBoardGroup = new System.Windows.Forms.ComboBox();
            this.comboBoxBoardType = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCANCEL = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelBoardDescription = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxBoardGroup
            // 
            this.comboBoxBoardGroup.FormattingEnabled = true;
            this.comboBoxBoardGroup.Location = new System.Drawing.Point(331, 15);
            this.comboBoxBoardGroup.Name = "comboBoxBoardGroup";
            this.comboBoxBoardGroup.Size = new System.Drawing.Size(136, 21);
            this.comboBoxBoardGroup.TabIndex = 0;
            // 
            // comboBoxBoardType
            // 
            this.comboBoxBoardType.FormattingEnabled = true;
            this.comboBoxBoardType.Location = new System.Drawing.Point(87, 47);
            this.comboBoxBoardType.Name = "comboBoxBoardType";
            this.comboBoxBoardType.Size = new System.Drawing.Size(135, 21);
            this.comboBoxBoardType.TabIndex = 1;
            this.comboBoxBoardType.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(87, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(136, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Board Name";
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(103, 139);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(88, 27);
            this.buttonOK.TabIndex = 4;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCANCEL
            // 
            this.buttonCANCEL.Location = new System.Drawing.Point(297, 137);
            this.buttonCANCEL.Name = "buttonCANCEL";
            this.buttonCANCEL.Size = new System.Drawing.Size(88, 27);
            this.buttonCANCEL.TabIndex = 5;
            this.buttonCANCEL.Text = "Cancel";
            this.buttonCANCEL.UseVisualStyleBackColor = true;
            this.buttonCANCEL.Click += new System.EventHandler(this.buttonCANCEL_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(258, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Board Group";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Board Type";
            // 
            // labelBoardDescription
            // 
            this.labelBoardDescription.AutoSize = true;
            this.labelBoardDescription.Location = new System.Drawing.Point(92, 87);
            this.labelBoardDescription.Name = "labelBoardDescription";
            this.labelBoardDescription.Size = new System.Drawing.Size(58, 13);
            this.labelBoardDescription.TabIndex = 8;
            this.labelBoardDescription.Text = "description";
            // 
            // SelectBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 182);
            this.Controls.Add(this.labelBoardDescription);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonCANCEL);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.comboBoxBoardType);
            this.Controls.Add(this.comboBoxBoardGroup);
            this.Name = "SelectBoard";
            this.Text = "Add New Board";
            this.Load += new System.EventHandler(this.SelectBoard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxBoardGroup;
        private System.Windows.Forms.ComboBox comboBoxBoardType;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCANCEL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelBoardDescription;
    }
}