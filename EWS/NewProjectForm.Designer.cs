namespace DocToolkit.Forms
{
    partial class NewProjectForm
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
            this.textboxProjectName = new System.Windows.Forms.TextBox();
            this.textboxConfiguratorName = new System.Windows.Forms.TextBox();
            this.NameLabel = new System.Windows.Forms.Label();
            this.ConfiguratorLabel = new System.Windows.Forms.Label();
            this.textboxProjectPath = new System.Windows.Forms.TextBox();
            this.PathLabel = new System.Windows.Forms.Label();
            this.FolderBrowse = new System.Windows.Forms.Button();
            this.textboxDescription = new System.Windows.Forms.TextBox();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.OK = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textboxProjectName
            // 
            this.textboxProjectName.Location = new System.Drawing.Point(123, 12);
            this.textboxProjectName.Name = "textboxProjectName";
            this.textboxProjectName.Size = new System.Drawing.Size(196, 20);
            this.textboxProjectName.TabIndex = 0;
            // 
            // textboxConfiguratorName
            // 
            this.textboxConfiguratorName.Location = new System.Drawing.Point(123, 64);
            this.textboxConfiguratorName.Name = "textboxConfiguratorName";
            this.textboxConfiguratorName.Size = new System.Drawing.Size(196, 20);
            this.textboxConfiguratorName.TabIndex = 1;
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(22, 15);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(71, 13);
            this.NameLabel.TabIndex = 2;
            this.NameLabel.Text = "Project Name";
            // 
            // ConfiguratorLabel
            // 
            this.ConfiguratorLabel.AutoSize = true;
            this.ConfiguratorLabel.Location = new System.Drawing.Point(22, 67);
            this.ConfiguratorLabel.Name = "ConfiguratorLabel";
            this.ConfiguratorLabel.Size = new System.Drawing.Size(95, 13);
            this.ConfiguratorLabel.TabIndex = 2;
            this.ConfiguratorLabel.Text = "Configurator Name";
            // 
            // textboxProjectPath
            // 
            this.textboxProjectPath.Location = new System.Drawing.Point(123, 38);
            this.textboxProjectPath.Name = "textboxProjectPath";
            this.textboxProjectPath.Size = new System.Drawing.Size(196, 20);
            this.textboxProjectPath.TabIndex = 1;
            // 
            // PathLabel
            // 
            this.PathLabel.AutoSize = true;
            this.PathLabel.Location = new System.Drawing.Point(22, 41);
            this.PathLabel.Name = "PathLabel";
            this.PathLabel.Size = new System.Drawing.Size(65, 13);
            this.PathLabel.TabIndex = 2;
            this.PathLabel.Text = "Project Path";
            // 
            // FolderBrowse
            // 
            this.FolderBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FolderBrowse.Location = new System.Drawing.Point(330, 37);
            this.FolderBrowse.Name = "FolderBrowse";
            this.FolderBrowse.Size = new System.Drawing.Size(27, 20);
            this.FolderBrowse.TabIndex = 3;
            this.FolderBrowse.Text = "...";
            this.FolderBrowse.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.FolderBrowse.UseVisualStyleBackColor = true;
            this.FolderBrowse.Click += new System.EventHandler(this.FolderBrowse_Click);
            // 
            // textboxDescription
            // 
            this.textboxDescription.Location = new System.Drawing.Point(88, 92);
            this.textboxDescription.Multiline = true;
            this.textboxDescription.Name = "textboxDescription";
            this.textboxDescription.Size = new System.Drawing.Size(231, 51);
            this.textboxDescription.TabIndex = 1;
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.AutoSize = true;
            this.DescriptionLabel.Location = new System.Drawing.Point(22, 108);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(60, 13);
            this.DescriptionLabel.TabIndex = 2;
            this.DescriptionLabel.Text = "Description";
            // 
            // OK
            // 
            this.OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK.Location = new System.Drawing.Point(111, 149);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(67, 25);
            this.OK.TabIndex = 4;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // Cancel
            // 
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Location = new System.Drawing.Point(194, 149);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(67, 25);
            this.Cancel.TabIndex = 4;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // NewProjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 182);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.FolderBrowse);
            this.Controls.Add(this.PathLabel);
            this.Controls.Add(this.DescriptionLabel);
            this.Controls.Add(this.ConfiguratorLabel);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.textboxProjectPath);
            this.Controls.Add(this.textboxDescription);
            this.Controls.Add(this.textboxConfiguratorName);
            this.Controls.Add(this.textboxProjectName);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "NewProjectForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Project";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox textboxProjectName;
        public bool returnStatus;
        private System.Windows.Forms.TextBox textboxConfiguratorName;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label ConfiguratorLabel;
        public System.Windows.Forms.TextBox textboxProjectPath;
        private System.Windows.Forms.Label PathLabel;
        private System.Windows.Forms.Button FolderBrowse;
        private System.Windows.Forms.TextBox textboxDescription;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button Cancel;
    }
}