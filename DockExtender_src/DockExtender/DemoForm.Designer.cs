namespace DockExtenderApp
{
    partial class DemoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DemoForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuView = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panelBottomInner = new System.Windows.Forms.Panel();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.buttonBottomClose = new System.Windows.Forms.Button();
            this.labelBottom = new System.Windows.Forms.Label();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.buttonLeftClose = new System.Windows.Forms.Button();
            this.panelLeftInner = new System.Windows.Forms.Panel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.label1 = new System.Windows.Forms.Label();
            this.labelLeft = new System.Windows.Forms.Label();
            this.splitterLeft = new System.Windows.Forms.Splitter();
            this.splitterBottom = new System.Windows.Forms.Splitter();
            this.listView1 = new System.Windows.Forms.ListView();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.panelBottomInner.SuspendLayout();
            this.panelLeft.SuspendLayout();
            this.panelLeftInner.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.menuView});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(677, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.closeToolStripMenuItem.Text = "&Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // menuView
            // 
            this.menuView.Name = "menuView";
            this.menuView.Size = new System.Drawing.Size(44, 20);
            this.menuView.Text = "View";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripLabel1,
            this.toolStripSeparator1,
            this.toolStripComboBox1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(677, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "Toolstrip";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton2";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(55, 22);
            this.toolStripLabel1.Text = "Drag Me!";
            this.toolStripLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 25);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 485);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(677, 22);
            this.statusStrip1.TabIndex = 12;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.SystemColors.Control;
            this.panelBottom.Controls.Add(this.panelBottomInner);
            this.panelBottom.Controls.Add(this.buttonBottomClose);
            this.panelBottom.Controls.Add(this.labelBottom);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(250, 295);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(427, 190);
            this.panelBottom.TabIndex = 17;
            // 
            // panelBottomInner
            // 
            this.panelBottomInner.AutoScroll = true;
            this.panelBottomInner.BackColor = System.Drawing.Color.Transparent;
            this.panelBottomInner.Controls.Add(this.monthCalendar1);
            this.panelBottomInner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBottomInner.Location = new System.Drawing.Point(0, 22);
            this.panelBottomInner.Name = "panelBottomInner";
            this.panelBottomInner.Size = new System.Drawing.Size(427, 168);
            this.panelBottomInner.TabIndex = 19;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.monthCalendar1.Location = new System.Drawing.Point(0, 0);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 29;
            // 
            // buttonBottomClose
            // 
            this.buttonBottomClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBottomClose.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonBottomClose.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonBottomClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBottomClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBottomClose.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.buttonBottomClose.Location = new System.Drawing.Point(403, 0);
            this.buttonBottomClose.Name = "buttonBottomClose";
            this.buttonBottomClose.Size = new System.Drawing.Size(21, 21);
            this.buttonBottomClose.TabIndex = 28;
            this.buttonBottomClose.Text = "X";
            this.buttonBottomClose.UseVisualStyleBackColor = false;
            this.buttonBottomClose.Click += new System.EventHandler(this.buttonBottomClose_Click);
            // 
            // labelBottom
            // 
            this.labelBottom.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelBottom.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelBottom.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelBottom.Location = new System.Drawing.Point(0, 0);
            this.labelBottom.Name = "labelBottom";
            this.labelBottom.Size = new System.Drawing.Size(427, 22);
            this.labelBottom.TabIndex = 27;
            this.labelBottom.Text = "Bottom Panel";
            this.labelBottom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelBottom.VisibleChanged += new System.EventHandler(this.labelBottom_VisibleChanged);
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.SystemColors.Control;
            this.panelLeft.Controls.Add(this.buttonLeftClose);
            this.panelLeft.Controls.Add(this.panelLeftInner);
            this.panelLeft.Controls.Add(this.labelLeft);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 49);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(247, 436);
            this.panelLeft.TabIndex = 18;
            // 
            // buttonLeftClose
            // 
            this.buttonLeftClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLeftClose.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonLeftClose.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonLeftClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLeftClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLeftClose.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.buttonLeftClose.Location = new System.Drawing.Point(223, 0);
            this.buttonLeftClose.Name = "buttonLeftClose";
            this.buttonLeftClose.Size = new System.Drawing.Size(21, 21);
            this.buttonLeftClose.TabIndex = 22;
            this.buttonLeftClose.Text = "X";
            this.buttonLeftClose.UseVisualStyleBackColor = false;
            this.buttonLeftClose.Click += new System.EventHandler(this.buttonLeftClose_Click);
            this.buttonLeftClose.MouseEnter += new System.EventHandler(this.buttonLeftClose_MouseEnter);
            // 
            // panelLeftInner
            // 
            this.panelLeftInner.AutoScroll = true;
            this.panelLeftInner.BackColor = System.Drawing.Color.Transparent;
            this.panelLeftInner.Controls.Add(this.treeView1);
            this.panelLeftInner.Controls.Add(this.splitter1);
            this.panelLeftInner.Controls.Add(this.label1);
            this.panelLeftInner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLeftInner.Location = new System.Drawing.Point(0, 22);
            this.panelLeftInner.Name = "panelLeftInner";
            this.panelLeftInner.Size = new System.Drawing.Size(247, 414);
            this.panelLeftInner.TabIndex = 16;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(247, 257);
            this.treeView1.TabIndex = 3;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 257);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(247, 3);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Location = new System.Drawing.Point(0, 260);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(247, 154);
            this.label1.TabIndex = 1;
            // 
            // labelLeft
            // 
            this.labelLeft.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelLeft.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLeft.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelLeft.Location = new System.Drawing.Point(0, 0);
            this.labelLeft.Name = "labelLeft";
            this.labelLeft.Size = new System.Drawing.Size(247, 22);
            this.labelLeft.TabIndex = 23;
            this.labelLeft.Text = "Left Panel";
            this.labelLeft.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelLeft.VisibleChanged += new System.EventHandler(this.labelLeft_VisibleChanged);
            // 
            // splitterLeft
            // 
            this.splitterLeft.Location = new System.Drawing.Point(247, 49);
            this.splitterLeft.Name = "splitterLeft";
            this.splitterLeft.Size = new System.Drawing.Size(3, 436);
            this.splitterLeft.TabIndex = 19;
            this.splitterLeft.TabStop = false;
            // 
            // splitterBottom
            // 
            this.splitterBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitterBottom.Location = new System.Drawing.Point(250, 292);
            this.splitterBottom.Name = "splitterBottom";
            this.splitterBottom.Size = new System.Drawing.Size(427, 3);
            this.splitterBottom.TabIndex = 20;
            this.splitterBottom.TabStop = false;
            // 
            // listView1
            // 
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(250, 49);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(427, 243);
            this.listView1.TabIndex = 21;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // DemoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 507);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.splitterBottom);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.splitterLeft);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "DemoForm";
            this.Text = "Dock Extender Demo";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.panelBottomInner.ResumeLayout(false);
            this.panelLeft.ResumeLayout(false);
            this.panelLeftInner.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuView;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelBottomInner;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelLeftInner;
        private System.Windows.Forms.Splitter splitterLeft;
        private System.Windows.Forms.Splitter splitterBottom;
        private System.Windows.Forms.Button buttonLeftClose;
        private System.Windows.Forms.Label labelLeft;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonBottomClose;
        private System.Windows.Forms.Label labelBottom;
        private System.Windows.Forms.TreeView treeView1;
    }
}

