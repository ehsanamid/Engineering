// (c) 2004-2005 Wout de Zeeuw

using System;
using System.Collections;
using System.Resources;
using System.Windows.Forms;

namespace DCS.CustomPropertyGrid
{
	/// <summary>
	/// Allows tabbing through items and has globalized tooltips.
	/// </summary>
	public class FlexiblePropertyGrid : PropertyGrid
	{
	    private ResourceManager rm = null;
	    private bool expandOnTab = false;

        /// <summary>
        /// Constructor.
        /// </summary>
        public FlexiblePropertyGrid()
            : base()
        {
	        Refresh();
	    }
        
        /// <summary>
        /// Gets or sets whether to expand an item when pressing tab.
        /// </summary>
        /// <remarks>
        /// When <c>true</c> items are also unexpanded when pressing shift-tab.
        /// Note that the enter key will always work to expand.
        /// </remarks>
        public bool ExpandOnTab {
        	get {
        		return expandOnTab;
        	}
        	set {
        		expandOnTab = value;
        	}
        }

	    /// <summary>
	    /// Refresh.
	    /// </summary>
	    /// <remarks>
	    /// Sets up globalized tooltips for "Categorized" and
	    /// "Alphabetic".
	    /// </remarks>
	    public override void Refresh() {
	        if (rm == null) {
	            rm = new ResourceManager(this.GetType());
	        }
	        // Find ToolBar in Controls.
	        foreach (Control control in Controls) {
	            if (control is ToolBar) {
	                ToolBar toolBar = control as ToolBar;
	                foreach (ToolBarButton button in toolBar.Buttons) {
	                    // Hacked, but no other way to do it.
	                    // As soon as MS decides to change the implementation
	                    // this will break ofcourse.
	                    switch (button.ImageIndex) {
	                        case 0 :
	                            button.ToolTipText = rm.GetString("Alphabetic.ToolTip");
	                            break;
	                        case 1 :
	                            button.ToolTipText = rm.GetString("Categorized.ToolTip");
	                            break;
	                        case 3 :
	                            button.ToolTipText = rm.GetString("PropertyPages.ToolTip");
	                            break;
	                    }
	                }
	            }
	        }
	        base.Refresh();
	    }

	    protected override void OnPropertyValueChanged(
           PropertyValueChangedEventArgs e
       ) {
            base.OnPropertyValueChanged(e);
       }

		// Do special processing for Tab key.
		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			if ((keyData == Keys.Tab) || (keyData == (Keys.Tab | Keys.Shift)))
			{
			    GridItem selectedItem = SelectedGridItem;
				GridItem root = selectedItem;
				while (root.Parent != null) {
					root = root.Parent;
				}
				// Find all expanded items and put them in a list.
				ArrayList items = new ArrayList();
				AddExpandedItems(root, items);
			    if (selectedItem != null) {
			        // Find selectedItem.
			        int foundIndex = items.IndexOf(selectedItem);
			        if ((keyData & Keys.Shift) == Keys.Shift) {
			            foundIndex--;
    			        if (foundIndex < 0) {
    			            foundIndex = items.Count - 1;
    			        }
						SelectedGridItem = (GridItem)items[foundIndex];
						if (expandOnTab && (SelectedGridItem.GridItems.Count > 0))
						{
							SelectedGridItem.Expanded = false;
						}
			        } else {
    			        foundIndex++;
    			        if (foundIndex >= items.Count) {
			            	foundIndex = 0;
    			        }
						SelectedGridItem = (GridItem)items[foundIndex];
						if (expandOnTab && (SelectedGridItem.GridItems.Count > 0))
						{
							SelectedGridItem.Expanded = true;
						}
			        }

				    return true;
			    }
			}

			return base.ProcessCmdKey(ref msg, keyData);
		}

		private void AddExpandedItems(GridItem parent, IList items) {
			if (parent.PropertyDescriptor != null) {
				items.Add(parent);
			}
			if (parent.Expanded) {
				foreach (GridItem child in parent.GridItems) {
					AddExpandedItems(child, items);
				}
			}
		}
	}
}

