namespace DCS.LeftControls
{
    partial class ToolboxWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ToolboxWindow));
            this.imageListtoolbox = new System.Windows.Forms.ImageList(this.components);
            this.listViewToolbox = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // imageListtoolbox
            // 
            this.imageListtoolbox.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListtoolbox.ImageStream")));
            this.imageListtoolbox.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListtoolbox.Images.SetKeyName(0, "Bitmap.ico");
            this.imageListtoolbox.Images.SetKeyName(1, "Ellipse.ico");
            this.imageListtoolbox.Images.SetKeyName(2, "ThermometerIcon.bmp");
            this.imageListtoolbox.Images.SetKeyName(3, "Pie.ico");
            this.imageListtoolbox.Images.SetKeyName(4, "Polygon.ico");
            this.imageListtoolbox.Images.SetKeyName(5, "Polyline.ico");
            this.imageListtoolbox.Images.SetKeyName(6, "Rect.ico");
            this.imageListtoolbox.Images.SetKeyName(7, "Line.ico");
            this.imageListtoolbox.Images.SetKeyName(8, "Arc.ico");
            this.imageListtoolbox.Images.SetKeyName(9, "Text.png");
            this.imageListtoolbox.Images.SetKeyName(10, "Bargraph.ico");
            this.imageListtoolbox.Images.SetKeyName(11, "RoundRect.ico");
            this.imageListtoolbox.Images.SetKeyName(12, "AnalogText.ico");
            this.imageListtoolbox.Images.SetKeyName(13, "EditBox.ico");
            this.imageListtoolbox.Images.SetKeyName(14, "Curve.png");
            this.imageListtoolbox.Images.SetKeyName(15, "Button.ico");
            this.imageListtoolbox.Images.SetKeyName(16, "DigitalText.ico");
            this.imageListtoolbox.Images.SetKeyName(17, "BLOCK.png");
            this.imageListtoolbox.Images.SetKeyName(18, "add_wire.png");
            this.imageListtoolbox.Images.SetKeyName(19, "add_variable.png");
            this.imageListtoolbox.Images.SetKeyName(20, "F.png");
            this.imageListtoolbox.Images.SetKeyName(21, "FBDx.ico");
            this.imageListtoolbox.Images.SetKeyName(22, "FBD.ico");
            this.imageListtoolbox.Images.SetKeyName(23, "constants.png");
            this.imageListtoolbox.Images.SetKeyName(24, "label.png");
            this.imageListtoolbox.Images.SetKeyName(25, "COMMENT.png");
            this.imageListtoolbox.Images.SetKeyName(26, "Pointer.png");
            this.imageListtoolbox.Images.SetKeyName(27, "Triangle.ico");
            this.imageListtoolbox.Images.SetKeyName(28, "Pie.png");
            this.imageListtoolbox.Images.SetKeyName(29, "radiobutton-icon.png");
            this.imageListtoolbox.Images.SetKeyName(30, "ComboBox.ico");
            this.imageListtoolbox.Images.SetKeyName(31, "Trend.png");
            this.imageListtoolbox.Images.SetKeyName(32, "Graph.ico");
            this.imageListtoolbox.Images.SetKeyName(33, "Block.ico");
            this.imageListtoolbox.Images.SetKeyName(34, "Editbox.png");
            this.imageListtoolbox.Images.SetKeyName(35, "CheckBoxItem.ico");
            this.imageListtoolbox.Images.SetKeyName(36, "IStep.png");
            this.imageListtoolbox.Images.SetKeyName(37, "Step.png");
            this.imageListtoolbox.Images.SetKeyName(38, "Transition.png");
            this.imageListtoolbox.Images.SetKeyName(39, "AND.png");
            this.imageListtoolbox.Images.SetKeyName(40, "ANDUCorner.png");
            this.imageListtoolbox.Images.SetKeyName(41, "ANDDCorner.png");
            this.imageListtoolbox.Images.SetKeyName(42, "OR.png");
            this.imageListtoolbox.Images.SetKeyName(43, "ORUCorner.png");
            this.imageListtoolbox.Images.SetKeyName(44, "ORDCorner.png");
            this.imageListtoolbox.Images.SetKeyName(45, "Jump.png");
            this.imageListtoolbox.Images.SetKeyName(46, "select.png");
            this.imageListtoolbox.Images.SetKeyName(47, "Mouse.bmp");
            this.imageListtoolbox.Images.SetKeyName(48, "Arrow.ico");
            this.imageListtoolbox.Images.SetKeyName(49, "ReportText.ico");
            this.imageListtoolbox.Images.SetKeyName(50, "");
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
            this.listViewToolbox.Size = new System.Drawing.Size(221, 361);
            this.listViewToolbox.SmallImageList = this.imageListtoolbox;
            this.listViewToolbox.StateImageList = this.imageListtoolbox;
            this.listViewToolbox.TabIndex = 0;
            this.listViewToolbox.UseCompatibleStateImageBehavior = false;
            this.listViewToolbox.View = System.Windows.Forms.View.Details;
            this.listViewToolbox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewToolbox_MouseClick);
            // 
            // ToolboxWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(221, 365);
            this.Controls.Add(this.listViewToolbox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HideOnClose = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ToolboxWindow";
            this.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockLeftAutoHide;
            this.TabText = "Toolbox";
            this.Text = "Toolbox";
            this.ResumeLayout(false);

        }
        #endregion
        public System.Windows.Forms.ListView listViewToolbox;
        private System.Windows.Forms.ImageList imageListtoolbox;

    }
}