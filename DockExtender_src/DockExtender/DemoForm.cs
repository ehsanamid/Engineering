// Copyright 2007 Herre Kuijpers - <herre@xs4all.nl>
//
// This source file(s) may be redistributed, altered and customized
// by any means PROVIDING the authors name and all copyright
// notices remain intact.
// THIS SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED. USE IT AT YOUR OWN RISK. THE AUTHOR ACCEPTS NO
// LIABILITY FOR ANY DATA DAMAGE/LOSS THAT THIS PRODUCT MAY CAUSE.
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ControlExtenders;

namespace DockExtenderApp
{
    public partial class DemoForm : Form
    {
        DockExtender dockExtender;

        // just to show some content
        string someText = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).";
        string[] someWords;
        Random rnd;

        public DemoForm()
        {
            // initialization
            InitializeComponent();
            label1.Text = someText;
            someWords = someText.Split(' ');
            rnd = new Random(-1);
            SetupTree();
            SetupList();


             //start docking here
            dockExtender = new DockExtender(this);

            IFloaty floaty;
            floaty = dockExtender.Attach(toolStrip1, toolStrip1, null);
            floaty.DockOnInside = false; // dock to outside
            floaty.Docking += new EventHandler(floaty_Docking);

            floaty = dockExtender.Attach(panelBottom, labelBottom, splitterBottom);
            floaty.Docking += new EventHandler(floaty_Docking);

            floaty = dockExtender.Attach(panelLeft, labelLeft, splitterLeft);
            floaty.Text = "Left Panel";
            floaty.Docking += new EventHandler(floaty_Docking);
            // that's it, docking has been setup for the 2 panels and the toolstrip!


            // setup a menu dynamically to show the panel again (if it was closed)
            foreach (Floaty f in dockExtender.Floaties)
            {
                ToolStripItem item = menuView.DropDownItems.Add(f.Text);
                item.MouseUp += new MouseEventHandler(item_MouseUp);
                item.Tag = f;  
            }
        }

        // make sure the ZOrder of the other main (non-dockable) controls remain
        void floaty_Docking(object sender, EventArgs e)
        {
            // make sure the ZOrder remains intact
            listView1.BringToFront();
            menuStrip1.SendToBack();
            statusStrip1.SendToBack();
            this.BringToFront();
        }


        #region fill content of some controls
        private void SetupTree()
        {
            for (int i = 0; i < 20; i++)
            {
                TreeNode n = treeView1.Nodes.Add(someWords[rnd.Next(someWords.Length - 1)]);
                SetupBranch(n, 3);
            }
        }

        private void SetupBranch(TreeNode node, int depth)
        {
            if (depth == 0) return;
            for (int i = 0; i < 3; i++)
            {
                TreeNode n = node.Nodes.Add(someWords[rnd.Next(someWords.Length - 1)]);
                SetupBranch(n, depth - 1);
            }
        }

        private void SetupList()
        {
            for (int i = 0; i < 5; i++)
                listView1.Columns.Add(someWords[rnd.Next(someWords.Length - 1)]);

            for (int i = 0; i < 100; i++)
            {
                ListViewItem item = listView1.Items.Add(someWords[rnd.Next(someWords.Length - 1)]);
                for (int j = 0; j < 4; j++)
                {
                    item.SubItems.Add(someWords[rnd.Next(someWords.Length - 1)]);
                }
            }

        }
        #endregion fill content of some controls

        void item_MouseUp(object sender, MouseEventArgs e)
        {
            ToolStripItem item = sender as ToolStripItem;
            Floaty floaty = item.Tag as Floaty;
            floaty.Show();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonBottomClose_Click(object sender, EventArgs e)
        {
            dockExtender.Hide(panelBottom);
        }

        private void buttonLeftClose_Click(object sender, EventArgs e)
        {
            dockExtender.Hide(panelLeft);
        }

        private void labelLeft_VisibleChanged(object sender, EventArgs e)
        {   
            //smart handle, will show/hide the x-button accoordingly
            buttonLeftClose.Visible = labelLeft.Visible;
        }

        private void labelBottom_VisibleChanged(object sender, EventArgs e)
        {
            buttonBottomClose.Visible = labelBottom.Visible;
        }

        private void buttonLeftClose_MouseEnter(object sender, EventArgs e)
        {

        }

    }
}