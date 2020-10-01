using DCS.ProjectObjects;
using DCS;
using DCS.DCSTables;
using DCS.Tools;
using DCS.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Windows.Forms;

namespace DCS.Forms
{
    public partial class VariableForm : Form
    {
        class Node
        {
            public string Name { get; private set; }
            public string Description { get; private set; }
            public string Type { get; private set; }
            public string Area { get; private set; }
            public List<Node> Children { get; private set; }
            public Node(string name, string description, string type, string area)
            {
                this.Name = name;
                this.Description = description;
                this.Type = type;
                this.Area = area;
                this.Children = new List<Node>();
            }
        }



        
        List<Filter> filters = new List<Filter>();
        List<Filter> typefilter = new List<Filter>();
        List<Filter> namefilter = new List<Filter>();
        List<Filter> descriptionfilter = new List<Filter>();
        List<Filter> areafilter = new List<Filter>();
        bool Loaded = false;
        private List<Node> data = new List<Node>();
        private List<NameID> possibletypes = new List<NameID>();
        List<bool> Filteredproperty = new List<bool>();
        Node tag;
        Node property;
        Node subperoprty;

       // int TagType = 0;
        List<string> list = new List<string>();
        List<tblVariable> tblvariablelist = new List<tblVariable>();
        //private bool _isobject = false;
        string _subpropertytxt = "";
        public string SubPropertyTxt
        {
            get
            {
                return _subpropertytxt;
            }
        }
        byte _subproperty;
        public byte SubProperty
        {
            get
            {
                return _subproperty;
            }
        }

        bool _isrefernce;
        public bool IsReference
        {
            get
            {
                return _isrefernce;
            }

        }

        public string Resultstr
        {
            get
            {
                return textBox1.Text;
            }

        }
        //public string stringproperty;
        //public bool IsObject
        //{
        //    get
        //    {
        //        return _isobject;
        //    }
        //}

        //private bool _isconstant = false;
        //public bool IsConstant
        //{
        //    get
        //    {
        //        return _isconstant;
        //    }
        //}

        //private bool _isextendedproperty = false;
        //public bool IsExtendedProperty
        //{
        //    get
        //    {
        //        if (_subpropertytxt == "")
        //        {
        //            return false;
        //        }
        //        else
        //        {
        //            return true;
        //        }
        //    }
        //}

        //private TemporayVariable tempvar;
        //public TemporayVariable TempVar;
        private tblVariable _tblvariable = new tblVariable();
        public tblVariable tblvariable
        {
            get
            {
                return _tblvariable;
            }
            
        }
        private tblFormalParameter _tblformalparameter = new tblFormalParameter();
        public tblFormalParameter tblformalparameter
        {
            get
            {
                return _tblformalparameter;
            }
            
        }
        tblPou globalPOU;
        tblPou localPOU;

        private List<string> _availabletype = new List<string>();
        public List<long> _availableareas = new List<long>();

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

        private tblPou otherpou
        {
            get
            {
                if (true != radioButtonGlobal.Checked)
                {
                    return globalPOU;
                }
                else
                {
                    return localPOU;
                }
            }
        }
        public VariableForm( long _pouid)
        {
            try
            {
                
                InitializeComponent();
                tblvariable.VarNameID = -1;
                localPOU = tblSolution.m_tblSolution().GetPouFromID(_pouid);
                if (localPOU.Type == POUTYPE.PROGRAM)
                {
                    globalPOU = tblSolution.m_tblSolution().GetGlobaltblPouObjectFromID(_pouid);
                    //radioButtonGlobal.Checked = true;

                    radioButtonGlobal.Checked = !Common.Variable_LocalSelected;
                    radioButtonLocal.Checked = Common.Variable_LocalSelected;
                }
                else
                {
                    radioButtonGlobal.Enabled = false;
                    radioButtonLocal.Checked = true;
                }
                //SetTestData();

                // set the delegate that the tree uses to know if a node is expandable
                this.treeListView1.CanExpandGetter = x => (x as Node).Children.Count > 0;
                // set the delegate that the tree uses to know the children of a node
                this.treeListView1.ChildrenGetter = x => (x as Node).Children;

                // create the tree columns and set the delegates to print the desired object proerty
                var NameCol = new BrightIdeasSoftware.OLVColumn("Name", "Name");
                NameCol.AspectGetter = x => (x as Node).Name;

                var Descriptioncol = new BrightIdeasSoftware.OLVColumn("Description", "Description");
                Descriptioncol.AspectGetter = x => (x as Node).Description;

                var Typecol = new BrightIdeasSoftware.OLVColumn("Type", "Type");
                Typecol.AspectGetter = x => (x as Node).Type;

                var Areacol = new BrightIdeasSoftware.OLVColumn("Area", "Area");
                Areacol.AspectGetter = x => (x as Node).Area;

                // add the columns to the tree
                this.treeListView1.Columns.Add(NameCol);
                this.treeListView1.Columns.Add(Descriptioncol);
                this.treeListView1.Columns.Add(Typecol);
                this.treeListView1.Columns.Add(Areacol);

                if (Common.Variable_NameColWidth > 0)
                {
                    this.treeListView1.Columns[0].Width = Common.Variable_NameColWidth;
                }
                if (Common.Variable_DescriptionColWidth > 0)
                {
                    this.treeListView1.Columns[1].Width = Common.Variable_DescriptionColWidth;
                }
                if (Common.Variable_TypeColWidth > 0)
                {
                    this.treeListView1.Columns[2].Width = Common.Variable_TypeColWidth;
                }
                if (Common.Variable_IDColWidth > 0)
                {
                    this.treeListView1.Columns[3].Width = Common.Variable_IDColWidth;
                }

                //this.button1.Width = this.treeListView1.Columns[0].Width;
                //button1.Height = treeListView1.TopItem.Bounds.Top;
                //listView.Items[0].Bounds.Top
                // int ggg = treeListView1.TopItem.Bounds.Top;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public VariableForm()
        {
            try
            {
                //mainewsform = _mainewsform;
                InitializeComponent();
                tblvariable.VarNameID = -1;
                localPOU = null;
                globalPOU = null;
                //radioButtonGlobal.Checked = true;

                radioButtonGlobal.Checked = !Common.Variable_LocalSelected;
                radioButtonLocal.Checked = Common.Variable_LocalSelected;

                //SetTestData();

                // set the delegate that the tree uses to know if a node is expandable
                this.treeListView1.CanExpandGetter = x => (x as Node).Children.Count > 0;
                // set the delegate that the tree uses to know the children of a node
                this.treeListView1.ChildrenGetter = x => (x as Node).Children;

                // create the tree columns and set the delegates to print the desired object proerty
                var NameCol = new BrightIdeasSoftware.OLVColumn("Name", "Name");
                NameCol.AspectGetter = x => (x as Node).Name;

                var Descriptioncol = new BrightIdeasSoftware.OLVColumn("Description", "Description");
                Descriptioncol.AspectGetter = x => (x as Node).Description;

                var Typecol = new BrightIdeasSoftware.OLVColumn("Type", "Type");
                Typecol.AspectGetter = x => (x as Node).Type;

                var Areacol = new BrightIdeasSoftware.OLVColumn("Area", "Area");
                Areacol.AspectGetter = x => (x as Node).Area;

                // add the columns to the tree
                this.treeListView1.Columns.Add(NameCol);
                this.treeListView1.Columns.Add(Descriptioncol);
                this.treeListView1.Columns.Add(Typecol);
                this.treeListView1.Columns.Add(Areacol);

                if (Common.Variable_NameColWidth > 0)
                {
                    this.treeListView1.Columns[0].Width = Common.Variable_NameColWidth;
                }
                if (Common.Variable_DescriptionColWidth > 0)
                {
                    this.treeListView1.Columns[1].Width = Common.Variable_DescriptionColWidth;
                }
                if (Common.Variable_TypeColWidth > 0)
                {
                    this.treeListView1.Columns[2].Width = Common.Variable_TypeColWidth;
                }
                if (Common.Variable_IDColWidth > 0)
                {
                    this.treeListView1.Columns[3].Width = Common.Variable_IDColWidth;
                }

                //this.button1.Width = this.treeListView1.Columns[0].Width;
                //button1.Height = treeListView1.TopItem.Bounds.Top;
                //listView.Items[0].Bounds.Top
                // int ggg = treeListView1.TopItem.Bounds.Top;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void ScanAvailableTypesinPOU()
        {
            try
            {
                _availabletype.Clear();
                bool f = false;
                List<int> _type = new List<int>();
                foreach (tblVariable _tblvar in tblvariablelist)
                {
                    if(Common.IsSimpleType(_tblvar.Type))
                    {
                    f = false;
                    foreach (int t in _type)
                    {
                        if (_tblvar.Type == t)
                        {
                            f = true;
                        }
                    }
                    if (!f)
                    {
                        _type.Add(_tblvar.Type);
                    }
                    }
                }
                _type.Sort();
                possibletypes.Clear();
                possibletypes.Add(new NameID("All", 0));
                for (int i = 0; i < _type.Count; i++)
                {
                    possibletypes.Add(new NameID(tblSolution.m_tblSolution().VarTypeStringList[_type[i]], _type[i]));
                }
                comboBoxType.DataSource = possibletypes;
                comboBoxType.DisplayMember = "Name";  // the Name property in Choice class
                comboBoxType.ValueMember = "ID";  // ditto for the Value property
                comboBoxType.FlatStyle = FlatStyle.Popup;
                comboBoxType.SelectedIndex = 0;
                for (int i = 0; i < _type.Count; i++)
                {
                    if (Common.Variable_LastSelectedType == _type[i])
                    {
                        comboBoxType.SelectedValue = Common.Variable_LastSelectedType;
                        break;
                    }
                }
                if (_type.Count > 0)
                {
                    Common.Variable_LastSelectedType = (int)comboBoxType.SelectedValue;
                }
                typefilter.Clear();
                if (Common.Variable_LastSelectedType != 0)
                {
                    typefilter.Add(new Filter(OpEnum.Equals, "Type", (int)comboBoxType.SelectedValue));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }


        private void ScanAvailableAreasinPOU()
        {
            try
            {
                _availableareas.Clear();
                bool f = false;
                foreach (tblVariable _tblvar in tblvariablelist)
                {
                    f = false;
                    foreach (long l in _availableareas)
                    {
                        if (_tblvar.PlantStructureID == l)
                        {
                            f = true;
                        }
                    }
                    if (!f)
                    {
                        _availableareas.Add(_tblvar.PlantStructureID);
                    }
                }
                //_type.Sort();

                Common.Variable_LastSelectedArea = (int)comboBoxType.SelectedValue;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void PrepareChildRows(tblVariable tblvariable,string _area)
        {
            try
            {
                string str;
                string str1;
                int mode;
                int state;
                int status;
                int bitno;
                tblFunction tblfunction = tblSolution.m_tblSolution().GetFunctionbyType(tblvariable.Type);
                mode = tblfunction.Mode;
                state = tblfunction.state;
                status = tblfunction.Status;
                for (int i = 0; i < tblfunction.m_tblFormalParameterCollection.Count; i++)
                {
                    str = tblfunction.m_tblFormalParameterCollection[i].PinName;
                    switch (str)
                    {
                        case "Mode":
                            if (Common.Variable_ShowMode && (mode != 0))
                            {
                                str1 = tblvariable.VarName + "." + str;
                                property = new Node(str1,
                                                    tblfunction.m_tblFormalParameterCollection[i].Description,
                                                    tblSolution.m_tblSolution().VarTypeStringList[tblfunction.m_tblFormalParameterCollection[i].Type],
                                                    _area);

                                for (int j = 0; j < tblSolution.m_tblSolution().m_tblBlockModeTextCollection.Count; j++)
                                {
                                    bitno = tblSolution.m_tblSolution().m_tblBlockModeTextCollection[j].Bit;
                                    if (Common.IsBitSet(mode, bitno))
                                    {
                                        subperoprty = new Node(str1 + "." + tblSolution.m_tblSolution().m_tblBlockModeTextCollection[j].Txt,
                                                                 tblSolution.m_tblSolution().m_tblBlockModeTextCollection[j].Decsription,
                                                                 "BOOL",
                                                                 _area);
                                        property.Children.Add(subperoprty);
                                    }
                                }
                                tag.Children.Add(property);
                            }
                            break;
                        case "State":
                            if (Common.Variable_ShowState && (state != 0))
                            {
                                str1 = tblvariable.VarName + "." + str;
                                property = new Node(str1,
                                                    tblfunction.m_tblFormalParameterCollection[i].Description,
                                                    tblSolution.m_tblSolution().VarTypeStringList[tblfunction.m_tblFormalParameterCollection[i].Type],
                                                    _area);

                                for (int j = 0; j < tblSolution.m_tblSolution().m_tblBlockStateTextCollection.Count; j++)
                                {
                                    bitno = tblSolution.m_tblSolution().m_tblBlockStateTextCollection[j].Bit;
                                    if (Common.IsBitSet(state, bitno))
                                    {
                                        subperoprty = new Node(str1 + "." + tblSolution.m_tblSolution().m_tblBlockStateTextCollection[j].Txt,
                                                                 tblSolution.m_tblSolution().m_tblBlockStateTextCollection[j].Decsription,
                                                                 "BOOL",
                                                                 _area);
                                        property.Children.Add(subperoprty);
                                    }
                                }
                                tag.Children.Add(property);
                            }
                            break;
                        case "ALS":
                            if (Common.Variable_ShowALS && (status != 0))
                            {
                                str1 = tblvariable.VarName + "." + str;
                                property = new Node(str1,
                                                    tblfunction.m_tblFormalParameterCollection[i].Description,
                                                    tblSolution.m_tblSolution().VarTypeStringList[tblfunction.m_tblFormalParameterCollection[i].Type],
                                                    _area);

                                for (int j = 0; j < tblSolution.m_tblSolution().m_tblBlockAlarmStatusTextCollection.Count; j++)
                                {
                                    bitno = tblSolution.m_tblSolution().m_tblBlockAlarmStatusTextCollection[j].Bit;
                                    if (Common.IsBitSet(status, bitno))
                                    {
                                        subperoprty = new Node(str1 + "." + tblSolution.m_tblSolution().m_tblBlockAlarmStatusTextCollection[j].Txt,
                                                                 tblSolution.m_tblSolution().m_tblBlockAlarmStatusTextCollection[j].Decsription,
                                                                 "BOOL",
                                                                 _area);
                                        property.Children.Add(subperoprty);
                                    }
                                }
                                tag.Children.Add(property);
                            }
                            break;
                        case "ALA":
                            if (Common.Variable_ShowALA && (status != 0))
                            {
                                str1 = tblvariable.VarName + "." + str;
                                property = new Node(str1,
                                                    tblfunction.m_tblFormalParameterCollection[i].Description,
                                                    tblSolution.m_tblSolution().VarTypeStringList[tblfunction.m_tblFormalParameterCollection[i].Type],
                                                    _area);

                                for (int j = 0; j < tblSolution.m_tblSolution().m_tblBlockAlarmStatusTextCollection.Count; j++)
                                {
                                    bitno = tblSolution.m_tblSolution().m_tblBlockAlarmStatusTextCollection[j].Bit;
                                    if (Common.IsBitSet(status, bitno))
                                    {
                                        subperoprty = new Node(str1 + "." + tblSolution.m_tblSolution().m_tblBlockAlarmStatusTextCollection[j].Txt,
                                                                 tblSolution.m_tblSolution().m_tblBlockAlarmStatusTextCollection[j].Decsription,
                                                                 "BOOL",
                                                                 _area);
                                        property.Children.Add(subperoprty);
                                    }
                                }
                                tag.Children.Add(property);
                            }
                            break;
                        case "ALB":
                            if (Common.Variable_ShowALB && (status != 0))
                            {
                                str1 = tblvariable.VarName + "." + str;
                                property = new Node(str1,
                                                    tblfunction.m_tblFormalParameterCollection[i].Description,
                                                    tblSolution.m_tblSolution().VarTypeStringList[tblfunction.m_tblFormalParameterCollection[i].Type],
                                                    _area);

                                for (int j = 0; j < tblSolution.m_tblSolution().m_tblBlockAlarmStatusTextCollection.Count; j++)
                                {
                                    bitno = tblSolution.m_tblSolution().m_tblBlockAlarmStatusTextCollection[j].Bit;
                                    if (Common.IsBitSet(status, bitno))
                                    {
                                        subperoprty = new Node(str1 + "." + tblSolution.m_tblSolution().m_tblBlockAlarmStatusTextCollection[j].Txt,
                                                                 tblSolution.m_tblSolution().m_tblBlockAlarmStatusTextCollection[j].Decsription,
                                                                 "BOOL",
                                                                 _area);
                                        property.Children.Add(subperoprty);
                                    }
                                }
                                tag.Children.Add(property);
                            }
                            break;
                        case "AEB":
                            if (Common.Variable_ShowAEB && (status != 0))
                            {
                                str1 = tblvariable.VarName + "." + str;
                                property = new Node(str1,
                                                    tblfunction.m_tblFormalParameterCollection[i].Description,
                                                    tblSolution.m_tblSolution().VarTypeStringList[tblfunction.m_tblFormalParameterCollection[i].Type],
                                                    _area);

                                for (int j = 0; j < tblSolution.m_tblSolution().m_tblBlockAlarmStatusTextCollection.Count; j++)
                                {
                                    bitno = tblSolution.m_tblSolution().m_tblBlockAlarmStatusTextCollection[j].Bit;
                                    if (Common.IsBitSet(status, bitno))
                                    {
                                        subperoprty = new Node(str1 + "." + tblSolution.m_tblSolution().m_tblBlockAlarmStatusTextCollection[j].Txt,
                                                                 tblSolution.m_tblSolution().m_tblBlockAlarmStatusTextCollection[j].Decsription,
                                                                 "BOOL",
                                                                 _area);
                                        property.Children.Add(subperoprty);
                                    }
                                }
                                tag.Children.Add(property);
                            }
                            break;
                        case "OPN":
                            if (Common.Variable_ShowOPN)
                            {
                                str1 = tblvariable.VarName + "." + str;
                                property = new Node(str1,
                                                    tblfunction.m_tblFormalParameterCollection[i].Description,
                                                    tblSolution.m_tblSolution().VarTypeStringList[tblfunction.m_tblFormalParameterCollection[i].Type],
                                                    _area);
                                tag.Children.Add(property);
                            }
                            break;
                        case "OPH":
                            if (Common.Variable_ShowOPH)
                            {
                                str1 = tblvariable.VarName + "." + str;
                                property = new Node(str1,
                                                    tblfunction.m_tblFormalParameterCollection[i].Description,
                                                    tblSolution.m_tblSolution().VarTypeStringList[tblfunction.m_tblFormalParameterCollection[i].Type],
                                                    _area);
                                tag.Children.Add(property);
                            }
                            break;
                        case "OPM":
                            if (Common.Variable_ShowOPM)
                            {
                                str1 = tblvariable.VarName + "." + str;
                                property = new Node(str1,
                                                    tblfunction.m_tblFormalParameterCollection[i].Description,
                                                    tblSolution.m_tblSolution().VarTypeStringList[tblfunction.m_tblFormalParameterCollection[i].Type],
                                                    _area);
                                tag.Children.Add(property);
                            }
                            break;
                        case "MNN":
                            if (Common.Variable_ShowMNN)
                            {
                                str1 = tblvariable.VarName + "." + str;
                                property = new Node(str1,
                                                    tblfunction.m_tblFormalParameterCollection[i].Description,
                                                    tblSolution.m_tblSolution().VarTypeStringList[tblfunction.m_tblFormalParameterCollection[i].Type],
                                                    _area);
                                tag.Children.Add(property);
                            }
                            break;
                        default:
                            str1 = tblvariable.VarName + "." + str;
                            property = new Node(str1,
                                                tblfunction.m_tblFormalParameterCollection[i].Description,
                                                tblSolution.m_tblSolution().VarTypeStringList[tblfunction.m_tblFormalParameterCollection[i].Type],
                                                _area);
                            tag.Children.Add(property);
                            break;
                    }



                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void writecollectiontolist()
        {
            try
            {
                tblvariablelist.Clear();
                if (selectedpou != null)
                {
                    foreach (tblVariable _tblvar in selectedpou.m_tblVariableCollection)
                    {
                        if (!Common.IsFunctionType(_tblvar.Type))
                        {
                            this.tblvariablelist.Add(_tblvar);
                        }
                    }
                }
                else
                {
                    foreach (tblController _tblcontroller in tblSolution.m_tblSolution().m_tblControllerCollection)
                    {
                        foreach (long id in MainForm.Instance().lcuList)
                        {
                            if (_tblcontroller.ControllerID == id)
                            {
                                foreach (tblVariable _tblvar in _tblcontroller.GetGlobalPOU().m_tblVariableCollection)
                                {
                                    if (!Common.IsFunctionType(_tblvar.Type))
                                    {
                                        this.tblvariablelist.Add(_tblvar);
                                    }
                                }
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void FillDataset()
        {
            try
            {
               
                FillFilters();
                data.Clear();
                if (filters.Count > 0)
                {
                    var deleg = ExpressionBuilder.GetExpression<tblVariable>(filters).Compile();
                    List<tblVariable> tblvariablelist1 = tblvariablelist.Where(deleg).ToList();
                    foreach (tblVariable _tblvar in tblvariablelist1)
                    {
                        {
                            tag = new Node(_tblvar.VarName,
                                           _tblvar.Description,
                                           tblSolution.m_tblSolution().VarTypeStringList[_tblvar.Type],
                                           tblSolution.m_tblSolution().AreaStringList[_tblvar.PlantStructureID]);
                            PrepareChildRows(_tblvar, tblSolution.m_tblSolution().AreaStringList[_tblvar.PlantStructureID]);
                            data.Add(tag);
                        }

                    }
                }
                else
                {
                    foreach (tblVariable _tblvar in tblvariablelist)
                    {
                        {
                            tag = new Node(_tblvar.VarName,
                                           _tblvar.Description,
                                           tblSolution.m_tblSolution().VarTypeStringList[_tblvar.Type],
                                           tblSolution.m_tblSolution().AreaStringList[_tblvar.PlantStructureID]);
                            PrepareChildRows(_tblvar, tblSolution.m_tblSolution().AreaStringList[_tblvar.PlantStructureID]);
                            data.Add(tag);
                        }

                    }
                }
                
                
                treeListView1.Roots = data;
                treeListView1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool Filterd(tblVariable _tblvar)
        {
            bool ret = true;

            //if (_tblvar.Type == (int)comboBoxType.SelectedValue)
            //{
            //    return false;
            //}
            return ret;
        }
        
        private void Variable_Load(object sender, EventArgs e)
        {
            try
            {
                writecollectiontolist();
                ScanAvailableTypesinPOU();
                ScanAvailableAreasinPOU();
                FillDataset();
                Loaded = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void treeListView1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                ListViewItem li = treeListView1.SelectedItem;
                textBox1.Text = li.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBoxType_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (Loaded)
                {
                    Common.Variable_LastSelectedType = (int)comboBoxType.SelectedValue;
                    typefilter.Clear();
                    if (Common.Variable_LastSelectedType != 0)
                    {
                        typefilter.Add(new Filter(OpEnum.Equals, "Type", (int)comboBoxType.SelectedValue));
                    }
                    FillDataset();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void treeListView1_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
        {
            try
            {
                if (Loaded)
                {
                    Common.Variable_NameColWidth = this.treeListView1.Columns[0].Width;
                    Common.Variable_DescriptionColWidth = this.treeListView1.Columns[1].Width;
                    Common.Variable_TypeColWidth = this.treeListView1.Columns[2].Width;
                    Common.Variable_IDColWidth = this.treeListView1.Columns[3].Width;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            try
            {
                string str = textBox1.Text;
                if (selectedpou == null)
                {
                    foreach (tblController _tblcontroller in tblSolution.m_tblSolution().m_tblControllerCollection)
                    {
                        foreach (tblPou _tblpou in _tblcontroller.m_tblPouCollection)
                        {
                            if (_tblpou.pouName == "GLOBAL")
                            {
                                if (_tblpou.IsVariable(str, ref _tblvariable, ref _isrefernce, ref _tblformalparameter, ref _subpropertytxt, ref _subproperty))
                                {
                                    MainForm.Instance().m_propertyGrid.SelectedObject = _tblvariable;
                                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                                    Close();
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (selectedpou.IsVariable(str, ref _tblvariable, ref _isrefernce, ref _tblformalparameter, ref _subpropertytxt, ref _subproperty))
                    {
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        Close();
                    }
                    else
                    {
                        if (otherpou.IsVariable(str, ref _tblvariable, ref _isrefernce, ref _tblformalparameter, ref _subpropertytxt, ref _subproperty))
                        {
                            this.DialogResult = System.Windows.Forms.DialogResult.OK;
                            Close();
                        }
                        else
                        {
                            DialogResult res = MessageBox.Show(str + " is not valid item", "Invalid Entry", MessageBoxButtons.RetryCancel);
                            if (res == DialogResult.Cancel)
                            {
                                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                                Close();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void buttonFilter_Click(object sender, EventArgs e)
        {
            try
            {
                VariableFilter variablefilter = new VariableFilter();
                if (DialogResult.OK == variablefilter.ShowDialog())
                {
                    FillDataset();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void treeListView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {

        }

        private void treeListView1_ColumnRightClick(object sender, ColumnClickEventArgs e)
        {
            try
            {

                DialogResult res;
                CustomTextFilter customtextfilter;
                switch (e.Column)
                {
                    case 0:
                        if (namefilter.Count == 0)
                        {
                            customtextfilter = new CustomTextFilter();
                        }
                        else
                        {
                            customtextfilter = new CustomTextFilter(namefilter[0].Operation, namefilter[0].Value);
                        }

                        res = customtextfilter.ShowDialog();
                        if (res == DialogResult.OK)
                        {
                            namefilter.Clear();
                            if (customtextfilter.ClearFilter)
                            {
                                treeListView1.Columns[0].Text = "Name";
                            }
                            else
                            {
                                namefilter.Add(customtextfilter.filter);
                                treeListView1.Columns[0].Text = "*Name*";
                            }
                            FillDataset();
                        }
                        break;

                    case 3:
                        AreaSelectForm areaselectform;
                        // if (areafilter.Count == 0)
                        {
                            areaselectform = new AreaSelectForm(this);
                        }
                        // else
                        {
                            //    customtextfilter = new CustomTextFilter(namefilter[0].Operation, namefilter[0].Value);
                        }

                        res = areaselectform.ShowDialog();
                        if (res == DialogResult.OK)
                        {
                            areafilter.Clear();
                            if (areaselectform.ClearFilter)
                            {
                                treeListView1.Columns[3].Text = "Area";
                            }
                            else
                            {
                                areafilter.Add(areaselectform.filter);
                                treeListView1.Columns[3].Text = "*Area = " + tblSolution.m_tblSolution().AreaStringList[(long)areaselectform.filter.Value] + "*";
                            }

                            FillDataset();
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void FillFilters()
        {
            try
            {
                filters.Clear();
                foreach (Filter f in namefilter)
                {
                    filters.Add(f);
                }
                foreach (Filter f in descriptionfilter)
                {
                    filters.Add(f);
                }
                foreach (Filter f in typefilter)
                {
                    filters.Add(f);
                }
                foreach (Filter f in areafilter)
                {
                    filters.Add(f);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void radioButtonGlobal_CheckedChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    if (Loaded)
            //    {
            //        Common.Variable_LocalSelected = !radioButtonGlobal.Checked;
            //        writecollectiontolist();
            //        ScanAvailableTypesinPOU();
            //        ScanAvailableAreasinPOU();
            //        FillDataset();
            //        Loaded = true;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void radioButtonLocal_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                //if (Loaded)
                //{
                //    Common.Variable_LocalSelected = !radioButtonGlobal.Checked;
                //    writecollectiontolist();
                //    ScanAvailableTypesinPOU();
                //    ScanAvailableAreasinPOU();
                //    FillDataset();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void radioButtonLocal_Click(object sender, EventArgs e)
        {
            try
            {
                //if (Loaded)
                {
                    Loaded = false;
                    Common.Variable_LocalSelected = !radioButtonGlobal.Checked;
                    writecollectiontolist();
                    ScanAvailableTypesinPOU();
                    ScanAvailableAreasinPOU();
                    FillDataset();
                    Loaded = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void treeListView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {

                string str = textBox1.Text;
                if (selectedpou == null)
                {
                    foreach (tblController _tblcontroller in tblSolution.m_tblSolution().m_tblControllerCollection)
                    {
                        foreach (tblPou _tblpou in _tblcontroller.m_tblPouCollection)
                        {
                            if (_tblpou.pouName == "GLOBAL")
                            {
                                if (_tblpou.IsVariable(str, ref _tblvariable, ref _isrefernce, ref _tblformalparameter, ref _subpropertytxt, ref _subproperty))
                                {
                                   // MainForm.Instance().m_propertyGrid.SelectedObject = _tblvariable;
                                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                                    Close();
                                }
                            }
                        }
                    }
                }
                else
                {

                    if (selectedpou.IsVariable(str, ref _tblvariable, ref _isrefernce, ref _tblformalparameter, ref _subpropertytxt, ref _subproperty))
                    {
                        MainForm.Instance().m_propertyGrid.SelectedObject = _tblvariable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void radioButtonGlobal_Click(object sender, EventArgs e)
        {
            try
            {
                //if (Loaded)
                {
                    Loaded = false;
                    Common.Variable_LocalSelected = !radioButtonGlobal.Checked;
                    writecollectiontolist();
                    ScanAvailableTypesinPOU();
                    ScanAvailableAreasinPOU();
                    FillDataset();
                    Loaded = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonSetting_Click(object sender, EventArgs e)
        {

        }
    }

}

