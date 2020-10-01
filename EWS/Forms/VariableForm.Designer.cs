namespace DCS.Forms
{
    partial class VariableForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VariableForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButtonLocal = new System.Windows.Forms.RadioButton();
            this.radioButtonGlobal = new System.Windows.Forms.RadioButton();
            this.buttonSetting = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonFilter = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageVariable = new System.Windows.Forms.TabPage();
            this.tabPageLCU = new System.Windows.Forms.TabPage();
            this.treeListView1 = new BrightIdeasSoftware.TreeListView();
            this.treeListView2 = new BrightIdeasSoftware.TreeListView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageVariable.SuspendLayout();
            this.tabPageLCU.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeListView2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioButtonLocal);
            this.panel1.Controls.Add(this.radioButtonGlobal);
            this.panel1.Controls.Add(this.buttonSetting);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.comboBoxType);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.buttonFilter);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(629, 39);
            this.panel1.TabIndex = 1;
            // 
            // radioButtonLocal
            // 
            this.radioButtonLocal.AutoSize = true;
            this.radioButtonLocal.Location = new System.Drawing.Point(339, 12);
            this.radioButtonLocal.Name = "radioButtonLocal";
            this.radioButtonLocal.Size = new System.Drawing.Size(51, 17);
            this.radioButtonLocal.TabIndex = 9;
            this.radioButtonLocal.TabStop = true;
            this.radioButtonLocal.Text = "Local";
            this.radioButtonLocal.UseVisualStyleBackColor = true;
            // 
            // radioButtonGlobal
            // 
            this.radioButtonGlobal.AutoSize = true;
            this.radioButtonGlobal.Location = new System.Drawing.Point(277, 10);
            this.radioButtonGlobal.Name = "radioButtonGlobal";
            this.radioButtonGlobal.Size = new System.Drawing.Size(55, 17);
            this.radioButtonGlobal.TabIndex = 8;
            this.radioButtonGlobal.TabStop = true;
            this.radioButtonGlobal.Text = "Global";
            this.radioButtonGlobal.UseVisualStyleBackColor = true;
            // 
            // buttonSetting
            // 
            this.buttonSetting.Image = global::DCS.Properties.Resources.LCU;
            this.buttonSetting.Location = new System.Drawing.Point(589, 6);
            this.buttonSetting.Name = "buttonSetting";
            this.buttonSetting.Size = new System.Drawing.Size(16, 23);
            this.buttonSetting.TabIndex = 7;
            this.buttonSetting.UseVisualStyleBackColor = true;
            this.buttonSetting.Click += new System.EventHandler(this.buttonSetting_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(431, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Type :";
            // 
            // comboBoxType
            // 
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Location = new System.Drawing.Point(470, 8);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(98, 21);
            this.comboBoxType.TabIndex = 4;
            this.comboBoxType.SelectedValueChanged += new System.EventHandler(this.comboBoxType_SelectedValueChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 9);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(199, 20);
            this.textBox1.TabIndex = 2;
            // 
            // buttonFilter
            // 
            this.buttonFilter.BackColor = System.Drawing.SystemColors.Control;
            this.buttonFilter.ImageIndex = 0;
            this.buttonFilter.ImageList = this.imageList1;
            this.buttonFilter.Location = new System.Drawing.Point(240, 5);
            this.buttonFilter.Name = "buttonFilter";
            this.buttonFilter.Size = new System.Drawing.Size(30, 27);
            this.buttonFilter.TabIndex = 0;
            this.buttonFilter.UseVisualStyleBackColor = false;
            this.buttonFilter.Click += new System.EventHandler(this.buttonFilter_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.White;
            this.imageList1.Images.SetKeyName(0, "Filter.png");
            this.imageList1.Images.SetKeyName(1, "Filtered.png");
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonCancel);
            this.panel2.Controls.Add(this.buttonOK);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 223);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(629, 38);
            this.panel2.TabIndex = 2;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Image = ((System.Drawing.Image)(resources.GetObject("buttonCancel.Image")));
            this.buttonCancel.Location = new System.Drawing.Point(415, 6);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(26, 26);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Image = ((System.Drawing.Image)(resources.GetObject("buttonOK.Image")));
            this.buttonOK.Location = new System.Drawing.Point(159, 6);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(26, 26);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tabControl1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 39);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(629, 184);
            this.panel3.TabIndex = 3;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageVariable);
            this.tabControl1.Controls.Add(this.tabPageLCU);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(629, 184);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageVariable
            // 
            this.tabPageVariable.Controls.Add(this.treeListView1);
            this.tabPageVariable.Location = new System.Drawing.Point(4, 22);
            this.tabPageVariable.Name = "tabPageVariable";
            this.tabPageVariable.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageVariable.Size = new System.Drawing.Size(621, 158);
            this.tabPageVariable.TabIndex = 0;
            this.tabPageVariable.Text = "Variable";
            this.tabPageVariable.UseVisualStyleBackColor = true;
            // 
            // tabPageLCU
            // 
            this.tabPageLCU.Controls.Add(this.treeListView2);
            this.tabPageLCU.Location = new System.Drawing.Point(4, 22);
            this.tabPageLCU.Name = "tabPageLCU";
            this.tabPageLCU.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLCU.Size = new System.Drawing.Size(621, 158);
            this.tabPageLCU.TabIndex = 1;
            this.tabPageLCU.Text = "LCU";
            this.tabPageLCU.UseVisualStyleBackColor = true;
            // 
            // treeListView1
            // 
            this.treeListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListView1.FullRowSelect = true;
            this.treeListView1.Location = new System.Drawing.Point(3, 3);
            this.treeListView1.Name = "treeListView1";
            this.treeListView1.OwnerDraw = true;
            this.treeListView1.ShowGroups = false;
            this.treeListView1.Size = new System.Drawing.Size(615, 152);
            this.treeListView1.TabIndex = 0;
            this.treeListView1.UseCompatibleStateImageBehavior = false;
            this.treeListView1.View = System.Windows.Forms.View.Details;
            this.treeListView1.VirtualMode = true;
            this.treeListView1.ColumnRightClick += new BrightIdeasSoftware.ColumnRightClickEventHandler(this.treeListView1_ColumnRightClick);
            this.treeListView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.treeListView1_ColumnClick);
            this.treeListView1.ColumnWidthChanged += new System.Windows.Forms.ColumnWidthChangedEventHandler(this.treeListView1_ColumnWidthChanged);
            this.treeListView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.treeListView1_MouseClick);
            this.treeListView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.treeListView1_MouseDoubleClick);
            // 
            // treeListView2
            // 
            this.treeListView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListView2.Location = new System.Drawing.Point(3, 3);
            this.treeListView2.Name = "treeListView2";
            this.treeListView2.OwnerDraw = true;
            this.treeListView2.ShowGroups = false;
            this.treeListView2.Size = new System.Drawing.Size(615, 152);
            this.treeListView2.TabIndex = 0;
            this.treeListView2.UseCompatibleStateImageBehavior = false;
            this.treeListView2.View = System.Windows.Forms.View.Details;
            this.treeListView2.VirtualMode = true;
            // 
            // VariableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 261);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VariableForm";
            this.Text = "Variable";
            this.Load += new System.EventHandler(this.Variable_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPageVariable.ResumeLayout(false);
            this.tabPageLCU.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeListView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeListView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonFilter;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Panel panel3;
        private BrightIdeasSoftware.TreeListView treeListView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageVariable;
        private System.Windows.Forms.TabPage tabPageLCU;
        private BrightIdeasSoftware.TreeListView treeListView2;
        private System.Windows.Forms.Button buttonSetting;
        private System.Windows.Forms.RadioButton radioButtonLocal;
        private System.Windows.Forms.RadioButton radioButtonGlobal;

    }
}