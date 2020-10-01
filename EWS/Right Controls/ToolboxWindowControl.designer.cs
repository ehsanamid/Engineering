namespace EWS.RightControls
{
    partial class ToolboxWindowControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ToolboxWindowControl));
            this.imageListtoolbox = new System.Windows.Forms.ImageList(this.components);
            this.listViewToolbox = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // imageListtoolbox
            // 
            this.imageListtoolbox.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListtoolbox.ImageStream")));
            this.imageListtoolbox.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListtoolbox.Images.SetKeyName(0, "add_variable.png");
            this.imageListtoolbox.Images.SetKeyName(1, "BLOCK.png");
            this.imageListtoolbox.Images.SetKeyName(2, "COMMENT.png");
            this.imageListtoolbox.Images.SetKeyName(3, "F.png");
            this.imageListtoolbox.Images.SetKeyName(4, "select.png");
            this.imageListtoolbox.Images.SetKeyName(5, "add_wire.png");
            this.imageListtoolbox.Images.SetKeyName(6, "Mouse.bmp");
            this.imageListtoolbox.Images.SetKeyName(7, "Line.ico");
            this.imageListtoolbox.Images.SetKeyName(8, "Rect.ico");
            this.imageListtoolbox.Images.SetKeyName(9, "RoundRect.ico");
            this.imageListtoolbox.Images.SetKeyName(10, "Ellipse.ico");
            this.imageListtoolbox.Images.SetKeyName(11, "Bitmap.ico");
            this.imageListtoolbox.Images.SetKeyName(12, "Polyline.ico");
            this.imageListtoolbox.Images.SetKeyName(13, "Polygon.ico");
            this.imageListtoolbox.Images.SetKeyName(14, "Arc.ico");
            this.imageListtoolbox.Images.SetKeyName(15, "Triangle.ico");
            this.imageListtoolbox.Images.SetKeyName(16, "Arrow.ico");
            this.imageListtoolbox.Images.SetKeyName(17, "Pie.ico");
            this.imageListtoolbox.Images.SetKeyName(18, "ReportText.ico");
            this.imageListtoolbox.Images.SetKeyName(19, "radiobutton-icon.png");
            this.imageListtoolbox.Images.SetKeyName(20, "ComboBox.ico");
            this.imageListtoolbox.Images.SetKeyName(21, "Bargraph.ico");
            this.imageListtoolbox.Images.SetKeyName(22, "Graph.ico");
            this.imageListtoolbox.Images.SetKeyName(23, "ThermometerIcon.bmp");
            this.imageListtoolbox.Images.SetKeyName(24, "Block.ico");
            this.imageListtoolbox.Images.SetKeyName(25, "DigitalText.ico");
            this.imageListtoolbox.Images.SetKeyName(26, "AnalogText.ico");
            this.imageListtoolbox.Images.SetKeyName(27, "Button.ico");
            this.imageListtoolbox.Images.SetKeyName(28, "EditBox.ico");
            this.imageListtoolbox.Images.SetKeyName(29, "CheckBoxItem.ico");
            this.imageListtoolbox.Images.SetKeyName(30, "constants.png");
            // 
            // listViewToolbox
            // 
            this.listViewToolbox.AutoArrange = false;
            this.listViewToolbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewToolbox.FullRowSelect = true;
            this.listViewToolbox.LabelWrap = false;
            this.listViewToolbox.LargeImageList = this.imageListtoolbox;
            this.listViewToolbox.Location = new System.Drawing.Point(0, 2);
            this.listViewToolbox.MultiSelect = false;
            this.listViewToolbox.Name = "listViewToolbox";
            this.listViewToolbox.Size = new System.Drawing.Size(141, 361);
            this.listViewToolbox.SmallImageList = this.imageListtoolbox;
            this.listViewToolbox.StateImageList = this.imageListtoolbox;
            this.listViewToolbox.TabIndex = 0;
            this.listViewToolbox.UseCompatibleStateImageBehavior = false;
            this.listViewToolbox.View = System.Windows.Forms.View.Details;
            this.listViewToolbox.SelectedIndexChanged += new System.EventHandler(this.listViewToolbox_SelectedIndexChanged);
            this.listViewToolbox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewToolbox_MouseClick);
            // 
            // ToolboxWindowControl
            // 
            this.Controls.Add(this.listViewToolbox);
            this.Name = "ToolboxWindowControl";
            this.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.Size = new System.Drawing.Size(141, 365);
            this.ResumeLayout(false);

		}
		#endregion
        public System.Windows.Forms.ListView listViewToolbox;
        private System.Windows.Forms.ImageList imageListtoolbox;
    }
}