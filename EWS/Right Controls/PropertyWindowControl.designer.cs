using EWS_PropertyGrid;
namespace EWS.RightControls
{
    partial class PropertyWindowControl
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
            this.propertyGridComponemt = new EWS_PropertyGrid.FilteredPropertyGrid();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // propertyGridComponemt
            // 
            this.propertyGridComponemt.BrowsableProperties = null;
            this.propertyGridComponemt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridComponemt.HiddenAttributes = null;
            this.propertyGridComponemt.HiddenProperties = null;
            this.propertyGridComponemt.LineColor = System.Drawing.SystemColors.ScrollBar;
            this.propertyGridComponemt.Location = new System.Drawing.Point(0, 3);
            this.propertyGridComponemt.Name = "propertyGridComponemt";
            this.propertyGridComponemt.Size = new System.Drawing.Size(208, 283);
            this.propertyGridComponemt.TabIndex = 0;
            this.propertyGridComponemt.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGridComponemt_PropertyValueChanged);
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.Text = "File";
            // 
            // PropertyWindowControl
            // 
            this.Controls.Add(this.propertyGridComponemt);
            this.Name = "PropertyWindowControl";
            this.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.Size = new System.Drawing.Size(208, 289);
            this.ResumeLayout(false);

		}
		#endregion
        
        
        public FilteredPropertyGrid propertyGridComponemt;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
    }
}