using EWS;
using EWS.DCSTables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ENG.Forms
{
    public partial class Variable : Form
    {
        class Node
        {
            public string Name { get; private set; }
            public string Column1 { get; private set; }
            public string Column2 { get; private set; }
            public string Column3 { get; private set; }
            public List<Node> Children { get; private set; }
            public Node(string name, string col1, string col2, string col3)
            {
                this.Name = name;
                this.Column1 = col1;
                this.Column2 = col2;
                this.Column3 = col3;
                this.Children = new List<Node>();
            }
        }
        private List<Node> data = new List<Node>();
        private List<NameID> possibletypes = new List<NameID>();
        int TagType = 0;
        List<string> list = new List<string>();
        private DataTable _dataTable = null;
        private DataSet _dataSet = null;
        private bool _isobject = false;
        public string stringproperty;
        public bool IsObject
        {
            get
            {
                return _isobject;
            }
        }

        private bool _isconstant = false;
        public bool IsConstant
        {
            get
            {
                return _isconstant;
            }
        }

        private bool _isextendedproperty = false;
        public bool IsExtendedProperty
        {
            get
            {
                return _isextendedproperty;
            }
        }

        //private TemporayVariable tempvar;
        //public TemporayVariable TempVar;
        private tblVariable _tblvariable = new tblVariable();
        public tblVariable tblvariable
        {
            get
            {
                return _tblvariable;
            }
            set
            {
                _tblvariable = value;
            }
        }
        private tblFormalParameter _tblformalparameter = new tblFormalParameter();
        public tblFormalParameter tblformalparameter
        {
            get
            {
                return _tblformalparameter;
            }
            set
            {
                _tblformalparameter = value;
            }
        }
        tblPou globalPOU;
        tblPou localPOU;

        private List<string> _availabletype = new List<string>();

        private tblPou selectedpou
        {
            get
            {
                if (true == radioButtonGlobal.Checked)
                {
                    return globalPOU;
                }
                else
                {
                    return localPOU;
                }
            }
        }

        public Variable(long _pouid)
        {
            InitializeComponent();
            tblvariable.VarNameID = -1;
            localPOU = Global.Instance.m_tblSolution.GetPouFromID(_pouid);
            globalPOU = Global.Instance.m_tblSolution.GetGlobaltblPouObjectFromID(_pouid);
            radioButtonGlobal.Checked = true;

            _dataTable = new DataTable();
            _dataSet = new DataSet();

            //initialize bindingsource
            bindingSource_main.DataSource = _dataSet;

            ScanAvailableTypesinPOU();

            SetTestData();

            // set the delegate that the tree uses to know if a node is expandable
            this.treeListView1.CanExpandGetter = x => (x as Node).Children.Count > 0;
            // set the delegate that the tree uses to know the children of a node
            this.treeListView1.ChildrenGetter = x => (x as Node).Children;

            // create the tree columns and set the delegates to print the desired object proerty
            var NameCol = new BrightIdeasSoftware.OLVColumn("Name", "Name");
            NameCol.AspectGetter = x => (x as Node).Name;

            var Descriptioncol = new BrightIdeasSoftware.OLVColumn("Description", "Description");
            Descriptioncol.AspectGetter = x => (x as Node).Column1;

            var Typecol = new BrightIdeasSoftware.OLVColumn("Type", "Type");
            Typecol.AspectGetter = x => (x as Node).Column2;

            var IDcol = new BrightIdeasSoftware.OLVColumn("ID", "ID");
            IDcol.AspectGetter = x => (x as Node).Column3;

            // add the columns to the tree
            this.treeListView1.Columns.Add(NameCol);
            this.treeListView1.Columns.Add(Descriptioncol);
            this.treeListView1.Columns.Add(Typecol);
            this.treeListView1.Columns.Add(IDcol);
            
        }

        private void ScanAvailableTypesinPOU()
        {
            _availabletype.Clear();
            bool f = false;
            List<int> _type = new List<int>();
            foreach (tblVariable _tblvar in selectedpou.m_tblVariableCollection)
            {
                f  = false;
                foreach(int t in _type)
                {
                    if (_tblvar.Type == t)
                    {
                        f = true;
                    }
                }
                if(!f)
                {
                    _type.Add(_tblvar.Type);
                }
            }
            _type.Sort();
            /*
             * 
             * 
             * 
             *  possibletypes.Add(new NameID(Enum.GetName(typeof(POUTYPE), POUTYPE.PROGRAM), (int)POUTYPE.PROGRAM));
            possibletypes.Add(new NameID(Enum.GetName(typeof(POUTYPE), POUTYPE.FUNCTION), (int)POUTYPE.FUNCTION));
            possibletypes.Add(new NameID(Enum.GetName(typeof(POUTYPE), POUTYPE.FUNCTIONBLOCK), (int)POUTYPE.FUNCTIONBLOCK));
                
            comboBoxPOUtype.DataSource = possibletypes;
            comboBoxPOUtype.DisplayMember = "Name";  // the Name property in Choice class
            comboBoxPOUtype.ValueMember = "ID";  // ditto for the Value property
            comboBoxPOUtype.FlatStyle = FlatStyle.Popup;
            comboBoxPOUtype.SelectedIndex = (int)poutype;
             * */
            for(int i = 0 ; i < _type.Count ; i++)
            {
                possibletypes.Add(new NameID(Global.Instance.m_tblSolution.VarTypeStringList[_type[i]], _type[i]));
            }
            comboBoxType.DataSource = possibletypes;
            comboBoxType.DisplayMember = "Name";  // the Name property in Choice class
            comboBoxType.ValueMember = "ID";  // ditto for the Value property
            comboBoxType.FlatStyle = FlatStyle.Popup;
            comboBoxType.SelectedIndex = (int)poutype;
            list.Add(_tblvar.VarName);
                    object[] newrow = new object[] { 
                                                                        _tblvar.VarName, 
                                                                            _tblvar.Description,
                                                                            Global.Instance.m_tblSolution.VarTypeStringList[_tblvar.Type],
                                                                           // ((VarClass)tblvariable.Class).ToString(),
                                                                            ((long)_tblvar.VarNameID)
                                                                        };
                    _dataTable.Rows.Add(newrow);
                }
            }
        }
        private void SetTestData()
        {
            _dataTable = _dataSet.Tables.Add("Variables");
            _dataTable.Columns.Add("Name", typeof(string));
            _dataTable.Columns.Add("Description", typeof(string));
            _dataTable.Columns.Add("Type", typeof(string));
            _dataTable.Columns.Add("ID", typeof(long));


            bindingSource_main.DataMember = _dataTable.TableName;

        }

        

        private void FillDataset()
        {
            try
            {
                
                int i = 0;
                foreach (tblVariable _tblvar in selectedpou.m_tblVariableCollection)
                {
                    if (Common.IsSimpleType(_tblvar.Type))
                    {
                        list.Add(_tblvar.VarName);
                        object[] newrow = new object[] { 
                                                                        _tblvar.VarName, 
                                                                            _tblvar.Description,
                                                                            Global.Instance.m_tblSolution.VarTypeStringList[_tblvar.Type],
                                                                           // ((VarClass)tblvariable.Class).ToString(),
                                                                            ((long)_tblvar.VarNameID)
                                                                        };
                        _dataTable.Rows.Add(newrow);
                    }
                }
                BindingSourceToGrid();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void BindingSourceToGrid()
        {
            string namestr;
            Node tag;
            Node property;
            Node subperoprty;
            for (int i = 0; i < bindingSource_main.Count; i++)
            {
                namestr = ((DataRowView)bindingSource_main.List[i])[0].ToString();
                tag = new Node(namestr,
                                                                        ((DataRowView)bindingSource_main.List[i])[1].ToString(),
                                                                        ((DataRowView)bindingSource_main.List[i])[2].ToString(),
                                                                       ((DataRowView)bindingSource_main.List[i])[3].ToString()
                                                                  );

                property = new Node(namestr + ".Mode", "Block Mode", "DINT", "-");
                tag.Children.Add(property);
                property = new Node(namestr + ".State", "Block State", "DINT", "-");
                tag.Children.Add(property);
                data.Add(tag);
            }
            this.treeListView1.Roots = data;
            
        }

        private void Variable_Load(object sender, EventArgs e)
        {
            FillDataset();
        }

        private void treeListView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem li = treeListView1.SelectedItem;
        }
    }

}


    /*
    private List<Node> data;
        //private BrightIdeasSoftware.TreeListView treeListView;

        public Form1()
        {
            InitializeComponent();
            AddTree();
            InitializeData();
            FillTree();
        }

        // private methods
        private void FillTree()
        {
            // set the delegate that the tree uses to know if a node is expandable
            this.treeListView1.CanExpandGetter = x => (x as Node).Children.Count > 0;
            // set the delegate that the tree uses to know the children of a node
            this.treeListView1.ChildrenGetter = x => (x as Node).Children;

            // create the tree columns and set the delegates to print the desired object proerty
            var nameCol = new BrightIdeasSoftware.OLVColumn("Name", "Name");
            nameCol.AspectGetter = x => (x as Node).Name;

            var col1 = new BrightIdeasSoftware.OLVColumn("Column1", "Column1");
            col1.AspectGetter = x => (x as Node).Column1;

            var col2 = new BrightIdeasSoftware.OLVColumn("Column2", "Column2");
            col2.AspectGetter = x => (x as Node).Column2;

            var col3 = new BrightIdeasSoftware.OLVColumn("Column3", "Column3");
            col3.AspectGetter = x => (x as Node).Column3;

            // add the columns to the tree
            this.treeListView1.Columns.Add(nameCol);
            this.treeListView1.Columns.Add(col1);
            this.treeListView1.Columns.Add(col2);
            this.treeListView1.Columns.Add(col3);

            // set the tree roots
            this.treeListView1.Roots = data;
        }

        private void InitializeData()
        {
            // create fake nodes
            var parent1 = new Node("PARENT1", "-", "-", "-");
            Node node1 = new Node("new", "new", "new", "new");
            node1.Children.Add(new Node("CHILD_1_1", "A", "X", "1"));
            parent1.Children.Add(node1);
            parent1.Children.Add(new Node("CHILD_1_2", "A", "Y", "2"));
            parent1.Children.Add(new Node("CHILD_1_3", "A", "Z", "3"));

            var parent2 = new Node("PARENT2", "-", "-", "-");
            parent2.Children.Add(new Node("CHILD_2_1", "B", "W", "7"));
            parent2.Children.Add(new Node("CHILD_2_2", "B", "Z", "8"));
            parent2.Children.Add(new Node("CHILD_2_3", "B", "J", "9"));

            var parent3 = new Node("PARENT3", "-", "-", "-");
            parent3.Children.Add(new Node("CHILD_3_1", "C", "R", "10"));
            parent3.Children.Add(new Node("CHILD_3_2", "C", "T", "12"));
            parent3.Children.Add(new Node("CHILD_3_3", "C", "H", "14"));

            data = new List<Node> { parent1, parent2, parent3 };
        }

        private void AddTree()
        {
            //treeListView1 = new BrightIdeasSoftware.TreeListView();
            //treeListView.Dock = DockStyle.Fill;
            //this.Controls.Add(treeListView1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    */