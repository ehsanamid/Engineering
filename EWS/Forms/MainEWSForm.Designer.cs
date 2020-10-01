using DCS.LeftControls;
using DCS.Tools;
using DCS.TabPages;
namespace DCS.Forms
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.newprojectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openprojectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importDisplayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importSymbolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unselectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.moveToFrontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveToBackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.documentationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imporExportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuView = new System.Windows.Forms.ToolStripMenuItem();
            this.windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCompile = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCompileAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonOfflineDownload = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonOnlineDownload = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.imageListTabControl = new System.Windows.Forms.ImageList(this.components);
            this.imageListtoolbox = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStripFBD = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.propertyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pinsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dockPanel = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.vS2005Theme1 = new WeifenLuo.WinFormsUI.Docking.VS2005Theme();
            this.cutGraphicPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyGraphicPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteGraphicPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteGraphicPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolGraphicPageStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.moveToFrontGraphicPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveToBackGraphicPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GraphicPagectxMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolGraphicPageStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.propertyGraphicPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vS2012ToolStripExtender1 = new DockSample.VSToolStripExtender(this.components);
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.contextMenuStripFBD.SuspendLayout();
            this.GraphicPagectxMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.editToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.menuView,
            this.windowToolStripMenuItem,
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.MdiWindowListItem = this.windowToolStripMenuItem;
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(858, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.menuStrip1_KeyDown);
            this.menuStrip1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.menuStrip1_KeyUp);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newprojectToolStripMenuItem,
            this.openprojectToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.printToolStripMenuItem,
            this.importDisplayToolStripMenuItem,
            this.importSymbolsToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItem2.Text = "File";
            // 
            // newprojectToolStripMenuItem
            // 
            this.newprojectToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newprojectToolStripMenuItem.Image")));
            this.newprojectToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Silver;
            this.newprojectToolStripMenuItem.Name = "newprojectToolStripMenuItem";
            this.newprojectToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.newprojectToolStripMenuItem.Text = "New Project";
            this.newprojectToolStripMenuItem.Click += new System.EventHandler(this.newprojectToolStripMenuItem_Click);
            // 
            // openprojectToolStripMenuItem
            // 
            this.openprojectToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openprojectToolStripMenuItem.Image")));
            this.openprojectToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Silver;
            this.openprojectToolStripMenuItem.Name = "openprojectToolStripMenuItem";
            this.openprojectToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.openprojectToolStripMenuItem.Text = "Open Project";
            this.openprojectToolStripMenuItem.Click += new System.EventHandler(this.openprojectToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Silver;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.printToolStripMenuItem.Text = "Print";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // importDisplayToolStripMenuItem
            // 
            this.importDisplayToolStripMenuItem.Name = "importDisplayToolStripMenuItem";
            this.importDisplayToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.importDisplayToolStripMenuItem.Text = "Import Displays";
            this.importDisplayToolStripMenuItem.Click += new System.EventHandler(this.importDisplayToolStripMenuItem_Click);
            // 
            // importSymbolsToolStripMenuItem
            // 
            this.importSymbolsToolStripMenuItem.Name = "importSymbolsToolStripMenuItem";
            this.importSymbolsToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.importSymbolsToolStripMenuItem.Text = "Import Symbols";
            this.importSymbolsToolStripMenuItem.Click += new System.EventHandler(this.importSymbolsToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.exportToolStripMenuItem.Text = "Export...";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(155, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectAllToolStripMenuItem,
            this.unselectAllToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.deleteAllToolStripMenuItem,
            this.toolStripMenuItem3,
            this.moveToFrontToolStripMenuItem,
            this.moveToBackToolStripMenuItem,
            this.toolStripMenuItem5,
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.toolStripMenuItem4,
            this.propertiesToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.selectAllToolStripMenuItem.Text = "Select All";
            // 
            // unselectAllToolStripMenuItem
            // 
            this.unselectAllToolStripMenuItem.Name = "unselectAllToolStripMenuItem";
            this.unselectAllToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.unselectAllToolStripMenuItem.Text = "Unselect All";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            // 
            // deleteAllToolStripMenuItem
            // 
            this.deleteAllToolStripMenuItem.Name = "deleteAllToolStripMenuItem";
            this.deleteAllToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.deleteAllToolStripMenuItem.Text = "Delete All";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(146, 6);
            // 
            // moveToFrontToolStripMenuItem
            // 
            this.moveToFrontToolStripMenuItem.Name = "moveToFrontToolStripMenuItem";
            this.moveToFrontToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.moveToFrontToolStripMenuItem.Text = "Move to Front";
            // 
            // moveToBackToolStripMenuItem
            // 
            this.moveToBackToolStripMenuItem.Name = "moveToBackToolStripMenuItem";
            this.moveToBackToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.moveToBackToolStripMenuItem.Text = "Move to Back";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(146, 6);
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("undoToolStripMenuItem.Image")));
            this.undoToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Silver;
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("redoToolStripMenuItem.Image")));
            this.redoToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Silver;
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.redoToolStripMenuItem.Text = "Redo";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(146, 6);
            // 
            // propertiesToolStripMenuItem
            // 
            this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.propertiesToolStripMenuItem.Text = "Properties";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.documentationToolStripMenuItem,
            this.generateAllToolStripMenuItem,
            this.imporExportToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // documentationToolStripMenuItem
            // 
            this.documentationToolStripMenuItem.Name = "documentationToolStripMenuItem";
            this.documentationToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.documentationToolStripMenuItem.Text = "Documentation";
            // 
            // generateAllToolStripMenuItem
            // 
            this.generateAllToolStripMenuItem.Name = "generateAllToolStripMenuItem";
            this.generateAllToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.generateAllToolStripMenuItem.Text = "Generate All";
            this.generateAllToolStripMenuItem.Click += new System.EventHandler(this.generateAllToolStripMenuItem_Click);
            // 
            // imporExportToolStripMenuItem
            // 
            this.imporExportToolStripMenuItem.Name = "imporExportToolStripMenuItem";
            this.imporExportToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.imporExportToolStripMenuItem.Text = "Impor/Export";
            this.imporExportToolStripMenuItem.Click += new System.EventHandler(this.imporExportToolStripMenuItem_Click);
            // 
            // menuView
            // 
            this.menuView.Name = "menuView";
            this.menuView.Size = new System.Drawing.Size(44, 20);
            this.menuView.Text = "View";
            // 
            // windowToolStripMenuItem
            // 
            this.windowToolStripMenuItem.Name = "windowToolStripMenuItem";
            this.windowToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.windowToolStripMenuItem.Text = "Window";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.fileToolStripMenuItem.Text = "Help";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonSave,
            this.toolStripButtonCompile,
            this.toolStripButtonCompileAll,
            this.toolStripSeparator2,
            this.toolStripButtonOfflineDownload,
            this.toolStripButtonOnlineDownload});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(858, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // toolStripButtonSave
            // 
            this.toolStripButtonSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSave.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSave.Image")));
            this.toolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSave.Name = "toolStripButtonSave";
            this.toolStripButtonSave.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonSave.Text = "toolStripButtonSave";
            this.toolStripButtonSave.ToolTipText = "Save";
            this.toolStripButtonSave.Click += new System.EventHandler(this.toolStripButtonSave_Click);
            // 
            // toolStripButtonCompile
            // 
            this.toolStripButtonCompile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonCompile.Image = global::DCS.Properties.Resources.Compile;
            this.toolStripButtonCompile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCompile.Name = "toolStripButtonCompile";
            this.toolStripButtonCompile.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonCompile.Text = "toolStripButtonCompile";
            this.toolStripButtonCompile.ToolTipText = "Compile";
            this.toolStripButtonCompile.Click += new System.EventHandler(this.toolStripButtonCompile_Click);
            // 
            // toolStripButtonCompileAll
            // 
            this.toolStripButtonCompileAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonCompileAll.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonCompileAll.Image")));
            this.toolStripButtonCompileAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCompileAll.Name = "toolStripButtonCompileAll";
            this.toolStripButtonCompileAll.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonCompileAll.Text = "toolStripButtonCompileAll";
            this.toolStripButtonCompileAll.ToolTipText = "Compile All";
            this.toolStripButtonCompileAll.Click += new System.EventHandler(this.toolStripButtonCompileAll_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonOfflineDownload
            // 
            this.toolStripButtonOfflineDownload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonOfflineDownload.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonOfflineDownload.Image")));
            this.toolStripButtonOfflineDownload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonOfflineDownload.Name = "toolStripButtonOfflineDownload";
            this.toolStripButtonOfflineDownload.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonOfflineDownload.Text = "Offline Download";
            this.toolStripButtonOfflineDownload.Click += new System.EventHandler(this.toolStripButtonOfflineDownload_Click);
            // 
            // toolStripButtonOnlineDownload
            // 
            this.toolStripButtonOnlineDownload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonOnlineDownload.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonOnlineDownload.Image")));
            this.toolStripButtonOnlineDownload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonOnlineDownload.Name = "toolStripButtonOnlineDownload";
            this.toolStripButtonOnlineDownload.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonOnlineDownload.Text = "line Download";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 366);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(858, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // imageListTabControl
            // 
            this.imageListTabControl.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListTabControl.ImageStream")));
            this.imageListTabControl.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListTabControl.Images.SetKeyName(0, "close11.png");
            this.imageListTabControl.Images.SetKeyName(1, "close3.png");
            // 
            // imageListtoolbox
            // 
            this.imageListtoolbox.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageListtoolbox.ImageSize = new System.Drawing.Size(16, 16);
            this.imageListtoolbox.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // contextMenuStripFBD
            // 
            this.contextMenuStripFBD.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem1,
            this.deleteToolStripMenuItem2,
            this.propertyToolStripMenuItem,
            this.toolStripSeparator3,
            this.pinsToolStripMenuItem});
            this.contextMenuStripFBD.Name = "contextMenuStripFBD";
            this.contextMenuStripFBD.Size = new System.Drawing.Size(184, 142);
            // 
            // copyToolStripMenuItem1
            // 
            this.copyToolStripMenuItem1.Name = "copyToolStripMenuItem1";
            this.copyToolStripMenuItem1.Size = new System.Drawing.Size(183, 22);
            this.copyToolStripMenuItem1.Text = "Copy";
            // 
            // deleteToolStripMenuItem2
            // 
            this.deleteToolStripMenuItem2.Name = "deleteToolStripMenuItem2";
            this.deleteToolStripMenuItem2.Size = new System.Drawing.Size(183, 22);
            this.deleteToolStripMenuItem2.Text = "Delete";
            // 
            // propertyToolStripMenuItem
            // 
            this.propertyToolStripMenuItem.Name = "propertyToolStripMenuItem";
            this.propertyToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.propertyToolStripMenuItem.Text = "ImporExportSelected";
            // 
            // pinsToolStripMenuItem
            // 
            this.pinsToolStripMenuItem.Name = "pinsToolStripMenuItem";
            this.pinsToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.pinsToolStripMenuItem.Text = "Edit Pins";
            this.pinsToolStripMenuItem.Click += new System.EventHandler(this.pinsToolStripMenuItem_Click);
            // 
            // dockPanel
            // 
            this.dockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPanel.DockBackColor = System.Drawing.SystemColors.AppWorkspace;
            this.dockPanel.DockBottomPortion = 150D;
            this.dockPanel.DockLeftPortion = 200D;
            this.dockPanel.DockRightPortion = 200D;
            this.dockPanel.DockTopPortion = 150D;
            this.dockPanel.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.dockPanel.Location = new System.Drawing.Point(0, 49);
            this.dockPanel.Name = "dockPanel";
            this.dockPanel.RightToLeftLayout = true;
            this.dockPanel.Size = new System.Drawing.Size(858, 317);
            this.dockPanel.TabIndex = 3;
            // 
            // cutGraphicPageToolStripMenuItem
            // 
            this.cutGraphicPageToolStripMenuItem.Name = "cutGraphicPageToolStripMenuItem";
            this.cutGraphicPageToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cutGraphicPageToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.cutGraphicPageToolStripMenuItem.Text = "&Cut";
            this.cutGraphicPageToolStripMenuItem.Click += new System.EventHandler(this.cutGraphicPageToolStripMenuItem_Click);
            // 
            // copyGraphicPageToolStripMenuItem
            // 
            this.copyGraphicPageToolStripMenuItem.Name = "copyGraphicPageToolStripMenuItem";
            this.copyGraphicPageToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyGraphicPageToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.copyGraphicPageToolStripMenuItem.Text = "C&opy";
            this.copyGraphicPageToolStripMenuItem.Click += new System.EventHandler(this.copyGraphicPageToolStripMenuItem_Click);
            // 
            // pasteGraphicPageToolStripMenuItem
            // 
            this.pasteGraphicPageToolStripMenuItem.Name = "pasteGraphicPageToolStripMenuItem";
            this.pasteGraphicPageToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteGraphicPageToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.pasteGraphicPageToolStripMenuItem.Text = "&Paste";
            this.pasteGraphicPageToolStripMenuItem.Click += new System.EventHandler(this.pasteGraphicPageToolStripMenuItem_Click);
            // 
            // deleteGraphicPageToolStripMenuItem
            // 
            this.deleteGraphicPageToolStripMenuItem.Name = "deleteGraphicPageToolStripMenuItem";
            this.deleteGraphicPageToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.deleteGraphicPageToolStripMenuItem.Text = "&Delete";
            this.deleteGraphicPageToolStripMenuItem.Click += new System.EventHandler(this.deleteGraphicPageToolStripMenuItem_Click);
            // 
            // toolGraphicPageStripMenuItem6
            // 
            this.toolGraphicPageStripMenuItem6.Name = "toolGraphicPageStripMenuItem6";
            this.toolGraphicPageStripMenuItem6.Size = new System.Drawing.Size(180, 6);
            // 
            // moveToFrontGraphicPageToolStripMenuItem
            // 
            this.moveToFrontGraphicPageToolStripMenuItem.Name = "moveToFrontGraphicPageToolStripMenuItem";
            this.moveToFrontGraphicPageToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.moveToFrontGraphicPageToolStripMenuItem.Text = "Move to Front";
            this.moveToFrontGraphicPageToolStripMenuItem.Click += new System.EventHandler(this.moveToFrontGraphicPageToolStripMenuItem_Click);
            // 
            // moveToBackGraphicPageToolStripMenuItem
            // 
            this.moveToBackGraphicPageToolStripMenuItem.Name = "moveToBackGraphicPageToolStripMenuItem";
            this.moveToBackGraphicPageToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.moveToBackGraphicPageToolStripMenuItem.Text = "Move to Back";
            this.moveToBackGraphicPageToolStripMenuItem.Click += new System.EventHandler(this.moveToBackGraphicPageToolStripMenuItem_Click);
            // 
            // GraphicPagectxMenu
            // 
            this.GraphicPagectxMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutGraphicPageToolStripMenuItem,
            this.copyGraphicPageToolStripMenuItem,
            this.pasteGraphicPageToolStripMenuItem,
            this.deleteGraphicPageToolStripMenuItem,
            this.toolGraphicPageStripMenuItem6,
            this.moveToFrontGraphicPageToolStripMenuItem,
            this.moveToBackGraphicPageToolStripMenuItem,
            this.toolGraphicPageStripSeparator3,
            this.propertyGraphicPageToolStripMenuItem});
            this.GraphicPagectxMenu.Name = "ctxtMenu";
            this.GraphicPagectxMenu.Size = new System.Drawing.Size(184, 170);
            // 
            // toolGraphicPageStripSeparator3
            // 
            this.toolGraphicPageStripSeparator3.Name = "toolGraphicPageStripSeparator3";
            this.toolGraphicPageStripSeparator3.Size = new System.Drawing.Size(180, 6);
            // 
            // propertyGraphicPageToolStripMenuItem
            // 
            this.propertyGraphicPageToolStripMenuItem.Name = "propertyGraphicPageToolStripMenuItem";
            this.propertyGraphicPageToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.propertyGraphicPageToolStripMenuItem.Text = "ImporExportSelected";
            this.propertyGraphicPageToolStripMenuItem.Click += new System.EventHandler(this.propertyGraphicPageToolStripMenuItem_Click);
            // 
            // vS2012ToolStripExtender1
            // 
            this.vS2012ToolStripExtender1.DefaultRenderer = null;
            this.vS2012ToolStripExtender1.VS2012Renderer = null;
            this.vS2012ToolStripExtender1.VS2013Renderer = null;
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.cutToolStripMenuItem.Text = "Cut";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(180, 6);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 388);
            this.Controls.Add(this.dockPanel);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MdiChildActivate += new System.EventHandler(this.MainForm_MdiChildActivate);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainForm_KeyPress);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contextMenuStripFBD.ResumeLayout(false);
            this.GraphicPagectxMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem newprojectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openprojectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importDisplayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importSymbolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unselectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem moveToFrontGraphicPageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveToBackGraphicPageToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
        private System.Windows.Forms.ImageList imageListTabControl;
        private System.Windows.Forms.ToolStripMenuItem menuView;
        private System.Windows.Forms.ImageList imageListtoolbox;
        private System.Windows.Forms.ToolStripButton toolStripButtonSave;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripFBD;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem propertyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pinsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem documentationToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButtonCompile;
        private System.Windows.Forms.ToolStripButton toolStripButtonCompileAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButtonOfflineDownload;
        private System.Windows.Forms.ToolStripButton toolStripButtonOnlineDownload;
        private System.Windows.Forms.ToolStripMenuItem generateAllToolStripMenuItem;
        private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel;
        private WeifenLuo.WinFormsUI.Docking.VS2005Theme vS2005Theme1;
        private DockSample.VSToolStripExtender vS2012ToolStripExtender1;
        private System.Windows.Forms.ToolStripMenuItem windowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cutGraphicPageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyGraphicPageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteGraphicPageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteGraphicPageToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolGraphicPageStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem moveToFrontToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveToBackToolStripMenuItem;
        public System.Windows.Forms.ContextMenuStrip GraphicPagectxMenu;
        private System.Windows.Forms.ToolStripSeparator toolGraphicPageStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem propertyGraphicPageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imporExportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}