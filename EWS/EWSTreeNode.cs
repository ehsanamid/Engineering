using DCS;
using DCS.DCSTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using DocToolkit.Project_Objects;

namespace DCS
{
    public class EWSTreeNode : TreeNode
    {
        private TREE_NODE_TYPE _nodetype = TREE_NODE_TYPE.ROOT;
        public TREE_NODE_TYPE Nodetype
        {
            get
            {
                return _nodetype;
            }
            set
            {
                _nodetype = value;
            }
        }
        private long _nodeid = -1;
        public long NodeID
        {
            get
            {
                return _nodeid;
            }
            set
            {
                _nodeid = value;
            }
        }
        private SQLiteTable _sqlobject;
        public SQLiteTable sqlobject
        {
            get
            {
                return _sqlobject;
            }
            set
            {
                _sqlobject = value;
            }
        }
        public EWSTreeNode(string _name) : base(_name)
        {
            //base.Name = _name;
           
        }

        public EWSTreeNode(string _name, int imageIndex,int selectedImageIndex)
            : base(_name, imageIndex,selectedImageIndex)
        {
            //base.Name = _name;

        }
        ~EWSTreeNode()
        {
           
        }

        
    }
}
