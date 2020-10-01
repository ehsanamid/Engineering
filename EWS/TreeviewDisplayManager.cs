using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocToolkit
{
    class TreeviewDisplayManager : TreeviewManager
    {
        
        public TreeviewDisplayManager(ref TreeView _tree, string rootname) : base(ref _tree,rootname)
        {
            
           // TreeviewManager(ref _tree,rootname);
        }

        //public void Init(string rootname)
        //{
        //    m_rootName = rootname;
        //    m_tree.Nodes.Add(m_rootName);

        //}
    }
}
