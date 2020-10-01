using DCS.DCSTables;
using DCS.Forms;
//using DocToolkit.Project_Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using System.Diagnostics;

namespace DCS.TabPages
{
    public partial class TabPlantStructurePageControl : TabPageControl
    {
        
        public TabPlantStructurePageControl()
            : base()
        {
            InitializeComponent();

        }




        public TabPlantStructurePageControl(long id)
            : base(id)
        {
            InitializeComponent();
            TabPageType = TABPAGETYPE.PLANT_STRUCTURE;
            ID = id;
            
        }

        
        //private ImageList imageList1;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TabPlantStructurePageControl));
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnLocation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnID,
            this.columnName,
            this.columnDescription,
            this.columnType,
            this.columnLocation});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(721, 246);
            this.listView1.SmallImageList = this.imageList1;
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.listView1_ColumnWidthChanging);
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // columnName
            // 
            this.columnName.Text = "Name";
            this.columnName.Width = 104;
            // 
            // columnID
            // 
            this.columnID.Text = "ID";
            this.columnID.Width = 0;
            // 
            // columnDescription
            // 
            this.columnDescription.Text = "Description";
            this.columnDescription.Width = 135;
            // 
            // columnType
            // 
            this.columnType.Text = "Type";
            // 
            // columnLocation
            // 
            this.columnLocation.Text = "Location";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "FolderListIcon.png");
            this.imageList1.Images.SetKeyName(1, "OWS.png");
            this.imageList1.Images.SetKeyName(2, "Package.png");
            this.imageList1.Images.SetKeyName(3, "46.png");
            // 
            // TabPlantStructurePageControl
            // 
            this.ClientSize = new System.Drawing.Size(721, 246);
            this.Controls.Add(this.listView1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "TabPlantStructurePageControl";
            this.Activated += new System.EventHandler(this.TabPageControl_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TabPageControl_FormClosing);
            this.ResumeLayout(false);

        }

        private ColumnHeader columnName;
        private ColumnHeader columnDescription;
        private ColumnHeader columnType;
        private ColumnHeader columnLocation;
        private ImageList imageList1;
        private IContainer components;
        private ColumnHeader columnID;
        

        
        private ListView listView1;
        public ListView plantstructurelistview
        {
            get
            {
                return listView1;
            }
        }
        



        #region virtual
        public override void CloseTabPage()
        {
            MainForm.Instance().tabplantstructurepagecontrol = null;
        }
        public override bool LoadTabPage()
        {
            bool ret = false;
            

            return ret;
        }

        public override bool SaveTabPage()
        {
            bool ret = false;
            Dirty = false;
            return ret;
        }

        public override bool SaveTabPage(long controllerID)
        {
            bool ret = false;
            

            return ret;
        }


        public override bool PrintTabPage()
        {
            bool ret = false;
            

            return ret;
        }


       


        
        #endregion

        private void TabPageControl_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseTabPage();
        }

      
        

        private void TabPageControl_Activated(object sender, EventArgs e)
        {
            UpdatePropertyGrid();
            MainForm.Instance().UpdateToolbox();
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                long id = long.Parse(listView1.SelectedItems[0].SubItems[0].Text);
                //MessageBox.Show(listView1.SelectedItems[0].SubItems[0].Text);


                foreach (tblPlantStructure tblplantstructure in tblSolution.m_tblSolution().m_tblPlantStructureCollection)
                {
                    if ((id == tblplantstructure.ID) && (!tblplantstructure.IsObject) && (!tblplantstructure.IsFolder))
                    {
                        Process process = new Process();
                        ProcessStartInfo startInfo = new ProcessStartInfo();
                        process.StartInfo = startInfo;
                        startInfo.FileName = "Acrobat.exe";
                        startInfo.Arguments = @"/A page=2 "+tblplantstructure.PropertyPath;//\\His50400\project_data\Files\ANSIISA–182.pdf";
                        

                        process.Start();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listView1_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                e.NewWidth = 0;
                e.Cancel = true;
            }
        }

        
    }
}


