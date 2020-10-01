using DCS;
using DCS.Compile;
using DCS.DCSTables;
using DCS.Draw;
using DCS.Project_Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
//using System.Xml;

namespace DCS.Forms
{
    
    public partial class GraphicalObjectExpressionForm : Form
    {
        public Dictionary<enumDynamicGraphicalProperty, string> AvailableProperties = new Dictionary<enumDynamicGraphicalProperty,string>();

        //DisplayObjectParameters parameters = new DisplayObjectParameters();
        bool Loaded = false;
        //int selectrow = -1;
        private List<string> types = new List<string>();
        //string _argumentstr;
        //string _expressionstr;
        //string _actionstr;
        int tabControlExpression_SelectedIndex = 0;
        //List<ConditionExpressions> ConditionExpressionslist = new List<ConditionExpressions>();
        string _selectedFieldType = "";

        public DisplayObjectParameters objDisplayObjectParameters = new DisplayObjectParameters();
        public DisplayObjectEventHandlers objDisplayObjectEventHandlers = new DisplayObjectEventHandlers();
        public DisplayObjectDynamicPropertys objDisplayObjectDynamicPropertys = new DisplayObjectDynamicPropertys();

        string _DisplayObjectParametersstr = "";
        public string DisplayObjectParametersstr
        {
            get
            {
                SerializeDeserialize<DisplayObjectParameters> sd;
                sd = new SerializeDeserialize<DisplayObjectParameters>();
                _DisplayObjectParametersstr = sd.SerializeData(objDisplayObjectParameters);
                return _DisplayObjectParametersstr;
            }
            set
            {
                try
                {
                    _DisplayObjectParametersstr = value;
                    objDisplayObjectParameters.list.Clear();
                    if (_DisplayObjectParametersstr != "")
                    {

                        SerializeDeserialize<DisplayObjectParameters> sd;
                        sd = new SerializeDeserialize<DisplayObjectParameters>();
                        objDisplayObjectParameters = sd.DeserializeData(_DisplayObjectParametersstr);
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }

        string _DisplayObjectEventHandlersstr = "";
        public string DisplayObjectEventHandlersstr
        {
            get
            {
                SerializeDeserialize<DisplayObjectEventHandlers> sd;
                sd = new SerializeDeserialize<DisplayObjectEventHandlers>();
                _DisplayObjectEventHandlersstr = sd.SerializeData(objDisplayObjectEventHandlers);
                return _DisplayObjectEventHandlersstr;
            }
            set
            {
                try
                {
                    _DisplayObjectEventHandlersstr = value;
                    objDisplayObjectEventHandlers.list.Clear();
                    if (_DisplayObjectEventHandlersstr != "")
                    {
                        SerializeDeserialize<DisplayObjectEventHandlers> sd;
                        sd = new SerializeDeserialize<DisplayObjectEventHandlers>();
                        objDisplayObjectEventHandlers = sd.DeserializeData(_DisplayObjectEventHandlersstr);
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }

        string _DisplayObjectDynamicPropertysstr = "";
        public string DisplayObjectDynamicPropertysstr
        {
            get
            {
                SerializeDeserialize<DisplayObjectDynamicPropertys> sd;
                sd = new SerializeDeserialize<DisplayObjectDynamicPropertys>();
                _DisplayObjectDynamicPropertysstr = sd.SerializeData(objDisplayObjectDynamicPropertys);
                return _DisplayObjectDynamicPropertysstr;
            }
            set
            {
                try
                {
                    _DisplayObjectDynamicPropertysstr = value;
                    objDisplayObjectDynamicPropertys.list.Clear();
                    if (_DisplayObjectDynamicPropertysstr != "")
                    {
                        SerializeDeserialize<DisplayObjectDynamicPropertys> sd;
                        sd = new SerializeDeserialize<DisplayObjectDynamicPropertys>();
                        objDisplayObjectDynamicPropertys = sd.DeserializeData(_DisplayObjectDynamicPropertysstr);
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }

        
        long ID;
        public GraphicalObjectExpressionForm()
        {
            InitializeComponent();
        }

       

        public GraphicalObjectExpressionForm(long id, string _parametersstr, string _graphicobjectpropertysstr, string _eventhandlersstr, List<string> _list)
        {
            InitializeComponent();
            DisplayObjectParametersstr = _parametersstr;
            DisplayObjectEventHandlersstr = _eventhandlersstr;
            DisplayObjectDynamicPropertysstr = _graphicobjectpropertysstr;
            types = _list;
            ID = id;
        }

       

        public void selectTabPage(int _tabindex)
        {
            tabControlExpression_SelectedIndex = _tabindex;
        }
        private void GraphicalObjectExpressionForm_Load(object sender, EventArgs e)
        {
            try
            {
                bool loop = false;
                FillcomboBoxType();
                foreach (string st in types)
                {
                    string[] sts = st.Split(new Char[] { ',' });
                    enumDynamicGraphicalProperty _dynamicgraphicalproperty = (enumDynamicGraphicalProperty)Enum.Parse(typeof(enumDynamicGraphicalProperty), sts[0]);
                    AvailableProperties.Add(_dynamicgraphicalproperty, sts[1]);

                    loop = false;
                    foreach (DisplayObjectDynamicProperty displayobjectdynamicproperty in objDisplayObjectDynamicPropertys.list)
                    {
                        if ((displayobjectdynamicproperty.ObjectType == _dynamicgraphicalproperty) && (displayobjectdynamicproperty.NoOfConditions > 0))
                        {
                            listBox1.Items.Add("->" + sts[1]);
                            loop = true;
                        }

                    }
                    if (!loop)
                    {
                        listBox1.Items.Add(sts[1]);
                    }
                }


                for (int i = 1; i <= 16; i++)
                {
                    comboBoxAccessLevel.Items.Add(i.ToString());
                }
                Loaded = true;
                comboBoxType.SelectedIndex = 0;
                comboBoxReference.SelectedIndex = 0;


                comboBoxEvent.SelectedIndex = 0;
                comboBoxAccessLevel.SelectedIndex = 0;
                //dataGridViewExpression.Columns[0].Width = 254;
                //dataGridViewExpression.Columns[1].Width = 86;
                //dataGridViewExpression.RowHeadersWidth = 30;
               // tabControlExpression.SelectedIndex = tabControlExpression_SelectedIndex;
                FillParameters();
                FillEventHandlers();
                listBox1.SelectedIndex = 0;
                updateExpGrid(ConvertListbox2DynamicGraphicalProperty((string)listBox1.SelectedItem));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void FillParameters()
        {
            foreach (DisplayObjectParameter _displayobjectparameter in objDisplayObjectParameters.list)
            {
                int rowId = dataGridViewArgument.Rows.Add();

                // Grab the new row!
                DataGridViewRow row = dataGridViewArgument.Rows[rowId];

                // Add the data
                row.Cells[0].Value = _displayobjectparameter.Name;
                row.Cells[1].Value =  _displayobjectparameter.Description;
                row.Cells[2].Value = _displayobjectparameter.Type;
                row.Cells[3].Value = _displayobjectparameter.Reference;
                row.Cells[4].Value = _displayobjectparameter.Assignment;
                
            }   
        }

        void FillEventHandlers()
        {
            foreach (DisplayObjectEventHandler _displayobjecteventhandler in objDisplayObjectEventHandlers.list)
            {
                int rowId = dataGridViewAction.Rows.Add();

                // Grab the new row!
                DataGridViewRow row = dataGridViewArgument.Rows[rowId];

                // Add the data
                row.Cells[0].Value = _displayobjecteventhandler.Event;
                row.Cells[1].Value = _displayobjecteventhandler.Handler;
                row.Cells[2].Value = _displayobjecteventhandler.Access;

            }
        }

        void FillcomboBoxType()
        {
            comboBoxType.Items.Clear();
            foreach (tblFunction tblfunction in tblSolution.m_tblSolution().m_tblFunctionCollection)
            {
                if (!tblfunction.IsFunction)
                {
                    if (checkBoxAll.Checked)
                    {
                        comboBoxType.Items.Add(tblfunction.FunctionName.ToUpper());
                    }
                    else
                    {
                        if (Common.IsSimpleType( tblfunction.Type ))
                        {
                            comboBoxType.Items.Add(tblfunction.FunctionName.ToUpper());
                        }
                    }
                }
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        

        private void dataGridViewArgument_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                textBoxName.Text = (string)dataGridViewArgument.Rows[e.RowIndex].Cells[0].Value;
                textBoxDescription.Text = (string)dataGridViewArgument.Rows[e.RowIndex].Cells[1].Value;
                comboBoxType.SelectedItem = (string)dataGridViewArgument.Rows[e.RowIndex].Cells[2].Value;
                comboBoxReference.SelectedItem = (string)dataGridViewArgument.Rows[e.RowIndex].Cells[3].Value;
                textBoxAssignment.Text = (string)dataGridViewArgument.Rows[e.RowIndex].Cells[4].Value;
            }
        }

        

        private void buttonUp_Click(object sender, EventArgs e)
        {

        }

        private void buttonDown_Click(object sender, EventArgs e)
        {

        }

        void updateExpGrid(enumDynamicGraphicalProperty _dynamicgraphicalproperty)
        {

            foreach (DisplayObjectDynamicProperty ex in objDisplayObjectDynamicPropertys.list)
            {
                if (ex.ObjectType == _dynamicgraphicalproperty)
                {
                    dataGridViewExpression.Rows.Clear();
                    foreach (DisplayObjectDynamicPropertyCondition condition in ex.ConditionList)
                    {
                        int rowId = dataGridViewExpression.Rows.Add();

                        // Grab the new row!
                        DataGridViewRow row = dataGridViewExpression.Rows[rowId];

                        // Add the data
                        row.Cells[0].Value = condition.If;
                        row.Cells[1].Value = condition.Then;
                        dataGridViewExpression.Rows[rowId].Selected = true;
                    }
                    return;
                }
            }
            dataGridViewExpression.Rows.Clear();
        }
        



        private void dataGridViewExpression_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                textBoxCondition.Text = (string)dataGridViewExpression.Rows[e.RowIndex].Cells[0].Value;
                textBoxValue.Text = (string)dataGridViewExpression.Rows[e.RowIndex].Cells[1].Value;
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlExpression.SelectedTab.Text  == "Expression")
            {
                updateExpGrid(ConvertListbox2DynamicGraphicalProperty((string)listBox1.SelectedItem));
            }

        }

        private bool CheckAssingmentIsValidValue(string str, string typestr)
        {
            ValueObj _valueobj = new ValueObj();

            if ((typestr.ToUpper() == "BOOL") && Common.IsValueBOOL(str, ref  _valueobj))
            {
                return true;
            }
            if ((typestr.ToUpper() == "BYTE") && Common.IsValueBYTE(str, ref  _valueobj))
            {
                return true;
            }
            if ((typestr.ToUpper() == "WORD") && Common.IsValueWORD(str, ref  _valueobj))
            {
                return true;
            }
            if ((typestr.ToUpper() == "DWORD") && Common.IsValueDWORD(str, ref  _valueobj))
            {
                return true;
            }
            if ((typestr.ToUpper() == "LWORD") && Common.IsValueLWORD(str, ref  _valueobj))
            {
                return true;
            }
            if ((typestr.ToUpper() == "SINT") && Common.IsValueSINT(str, ref  _valueobj))
            {
                return true;
            }
            if ((typestr.ToUpper() == "INT") && Common.IsValueINT(str, ref  _valueobj))
            {
                return true;
            }
            if ((typestr.ToUpper() == "DINT") && Common.IsValueDINT(str, ref  _valueobj))
            {
                return true;
            }
            if ((typestr.ToUpper() == "LINT") && Common.IsValueLINT(str, ref  _valueobj))
            {
                return true;
            }
            if ((typestr.ToUpper() == "USINT") && Common.IsValueUSINT(str, ref  _valueobj))
            {
                return true;
            }
            if ((typestr.ToUpper() == "UINT") && Common.IsValueUINT(str, ref  _valueobj))
            {
                return true;
            }
            if ((typestr.ToUpper() == "UDINT") && Common.IsValueUDINT(str, ref  _valueobj))
            {
                return true;
            }
            if ((typestr.ToUpper() == "ULINT") && Common.IsValueULINT(str, ref  _valueobj))
            {
                return true;
            }
            if ((typestr.ToUpper() == "REAL") && Common.IsValueREAL(str, ref  _valueobj))
            {
                return true;
            }
            if ((typestr.ToUpper() == "LREAL") && Common.IsValueLREAL(str, ref  _valueobj))
            {
                return true;
            }
            if ((typestr.ToUpper() == "COLOR") && Common.IsValueColor(str, ref  _valueobj))
            {
                return true;
            }
            if ((typestr.ToUpper() == "TIME") && Common.IsValueTIME(str, ref  _valueobj))
            {
                return true;
            }
            if ((typestr.ToUpper() == "DATE") && Common.IsValueDATE(str, ref  _valueobj))
            {
                return true;
            }
            if ((typestr.ToUpper() == "TOD") && Common.IsValueTOD(str, ref  _valueobj))
            {
                return true;
            }
            if ((typestr.ToUpper() == "DT") && Common.IsValueDT(str, ref  _valueobj))
            {
                return true;
            }
            return false;
        }

        private bool CheckAssingmentIsValidValue(string str)
        {
            string _valueobj = "";
            if ( Compiler.IsValueString(str, ref  _valueobj))
            {
                return true;
            }
            return false;
        }

        private bool CheckAssingment(string str, string typestr)
        {
            if (typestr.ToUpper() == "STRING")
            {
                return CheckAssingmentIsValidValue(str);
            }
            else
            {
                return CheckAssingmentIsValidValue(str, typestr);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text != "")
            {
                //VALUE _value = new VALUE();

                for (int i = 0; i < dataGridViewArgument.Rows.Count; i++)
                {
                    if (textBoxName.Text.ToUpper() == ((string)dataGridViewArgument.Rows[i].Cells[0].Value).ToUpper())
                    {
                        MessageBox.Show(textBoxName.Text + " already defined ");
                        break;
                    }
                }

                int rowId = dataGridViewArgument.Rows.Add();

                // Grab the new row!
                DataGridViewRow row = dataGridViewArgument.Rows[rowId];

                // Add the data
                row.Cells[0].Value = textBoxName.Text.ToUpper();
                row.Cells[1].Value = textBoxDescription.Text;
                row.Cells[2].Value = comboBoxType.SelectedItem;
                row.Cells[3].Value = (string)comboBoxReference.SelectedItem;
                
                row.Cells[4].Value = textBoxAssignment.Text.ToUpper();
                dataGridViewArgument.Rows[rowId].Selected = true;
                DisplayObjectParameter _displayobjectparameter = new DisplayObjectParameter();
                _displayobjectparameter.Name = textBoxName.Text.ToUpper();
                _displayobjectparameter.Description = textBoxDescription.Text;
                _displayobjectparameter.Type = (string)comboBoxType.SelectedItem;
                _displayobjectparameter.Reference = (string)comboBoxReference.SelectedItem;
                _displayobjectparameter.Assignment = textBoxAssignment.Text.ToUpper();
                objDisplayObjectParameters.list.Add(_displayobjectparameter);

            }
        }

        private void buttonAddExpression_Click(object sender, EventArgs e)
        {
            if ((textBoxCondition.Text != "") && (textBoxValue.Text != ""))
            {
                if (true)//(CheckAssingment(textBoxAssignment.Text, (string)comboBoxType.SelectedItem))
                {
                    int rowId = dataGridViewExpression.Rows.Add();

                    // Grab the new row!
                    DataGridViewRow row = dataGridViewExpression.Rows[rowId];

                    // Add the data
                    row.Cells[0].Value = textBoxCondition.Text.ToUpper();
                    row.Cells[1].Value = textBoxValue.Text;
                    dataGridViewExpression.Rows[rowId].Selected = true;


                    //string str = (string)comboBoxField.SelectedItem;
                    string str = (string)listBox1.SelectedItem;
                    bool found = false;

                    if (!str.StartsWith("->"))
                    {
                        //listBox1.SelectedItem = "->" + str;

                        for (int i = 0; i < listBox1.Items.Count; i++)
                        {
                            if ((string)listBox1.Items[i] == str)
                            {
                                listBox1.Items[i] = "->" + str;
                                break;
                            }
                        }
                    }

                    foreach (DisplayObjectDynamicProperty displayobjectdynamicproperty in objDisplayObjectDynamicPropertys.list)
                    {
                        if (displayobjectdynamicproperty.ObjectType == ConvertListbox2DynamicGraphicalProperty(str))
                        {
                            found = true;
                            DisplayObjectDynamicPropertyCondition _condition = new DisplayObjectDynamicPropertyCondition();
                            _condition.If = textBoxCondition.Text.ToUpper();
                            _condition.Then = textBoxValue.Text;
                            displayobjectdynamicproperty.ConditionList.Add(_condition);
                            break;
                        }
                    }
                    if (!found)
                    {
                        DisplayObjectDynamicProperty displayobjectdynamicproperty = new DisplayObjectDynamicProperty();
                        displayobjectdynamicproperty.ObjectType = ConvertListbox2DynamicGraphicalProperty(str);
                        displayobjectdynamicproperty.ReturnType = ConvertListbox2returnType(str);
                        DisplayObjectDynamicPropertyCondition _condition = new DisplayObjectDynamicPropertyCondition();
                        _condition.If = textBoxCondition.Text.ToUpper();
                        _condition.Then = textBoxValue.Text;
                        displayobjectdynamicproperty.ConditionList.Add(_condition);
                        objDisplayObjectDynamicPropertys.list.Add(displayobjectdynamicproperty);

                    }
                }
                else
                {
                    MessageBox.Show("Value " + textBoxAssignment.Text + " is not valid " + (string)comboBoxType.SelectedItem + " type");
                }

            }
        }

        private void buttonAddAction_Click(object sender, EventArgs e)
        {
            string str =((string)comboBoxEvent.SelectedItem);
            if (textBoxAction.Text != "")
            {
                for (int i = 0; i < dataGridViewAction.Rows.Count; i++)
                {
                    if (str.ToUpper() == ((string)dataGridViewAction.Rows[i].Cells[0].Value).ToUpper())
                    {
                        MessageBox.Show("Event " + str + " already defined ");
                        break;
                    }
                }

                int rowId = dataGridViewAction.Rows.Add();

                // Grab the new row!
                DataGridViewRow row = dataGridViewAction.Rows[rowId];

                // Add the data
                row.Cells[0].Value = str;
                row.Cells[1].Value = textBoxAction.Text;
                row.Cells[2].Value = comboBoxAccessLevel.SelectedItem;
                dataGridViewAction.Rows[rowId].Selected = true;
                DisplayObjectEventHandler displayobjecteventhandler = new DisplayObjectEventHandler();
                displayobjecteventhandler.Event = str;
                displayobjecteventhandler.Handler = textBoxAction.Text;
                displayobjecteventhandler.Access = (string)comboBoxAccessLevel.SelectedItem;
                objDisplayObjectEventHandlers.list.Add(displayobjecteventhandler);
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text != "")
            {
                int sel = dataGridViewArgument.SelectedRows[0].Index;
                for (int i = 0; i < dataGridViewArgument.Rows.Count; i++)
                {
                    if (sel != i)
                    {
                        if (textBoxName.Text.ToUpper() == ((string)dataGridViewArgument.Rows[i].Cells[0].Value).ToUpper())
                        {
                            MessageBox.Show(textBoxName.Text + " already defined ");
                            return;
                        }
                    }
                }
                string oldname = (string)dataGridViewArgument.SelectedRows[0].Cells[0].Value;
                dataGridViewArgument.SelectedRows[0].Cells[0].Value = textBoxName.Text.ToUpper();
                dataGridViewArgument.SelectedRows[0].Cells[1].Value = textBoxDescription.Text;
                dataGridViewArgument.SelectedRows[0].Cells[2].Value = (string)comboBoxType.SelectedItem;
                    dataGridViewArgument.SelectedRows[0].Cells[3].Value = (string)comboBoxReference.SelectedItem;
                dataGridViewArgument.SelectedRows[0].Cells[4].Value = (string)textBoxAssignment.Text.ToUpper();
                foreach (DisplayObjectParameter _displayobjectparameter in objDisplayObjectParameters.list)
                {
                    if (oldname.ToUpper() == _displayobjectparameter.Name.ToUpper())
                    {
                        _displayobjectparameter.Name = textBoxName.Text.ToUpper();
                        _displayobjectparameter.Description = textBoxDescription.Text;
                        _displayobjectparameter.Type = (string)comboBoxType.SelectedItem;
                            _displayobjectparameter.Reference = (string)comboBoxReference.SelectedItem;

                        _displayobjectparameter.Assignment = textBoxAssignment.Text.ToUpper();
                    }
                }
            }
            else
            {
                MessageBox.Show("Argument Name missing");
            }
        }

        private void buttonUpdateExpression_Click(object sender, EventArgs e)
        {
            if ((textBoxCondition.Text != "") && (textBoxValue.Text != ""))
            {
                if (true)//(CheckAssingment(textBoxAssignment.Text, (string)comboBoxType.SelectedItem))
                {
                    //string str = (string)comboBoxField.SelectedItem;
                    string str = (string)listBox1.SelectedItem;
                    int sel = dataGridViewExpression.SelectedRows[0].Index;
                    foreach (DisplayObjectDynamicProperty ex in objDisplayObjectDynamicPropertys.list)
                    {
                        if (ex.ObjectType == ConvertListbox2DynamicGraphicalProperty(str))
                        {
                            ex.ConditionList.RemoveAt(sel);
                            DisplayObjectDynamicPropertyCondition _conditionstruct = new DisplayObjectDynamicPropertyCondition();
                            _conditionstruct.If = textBoxCondition.Text.ToUpper();
                            _conditionstruct.Then= textBoxValue.Text;
                            dataGridViewExpression.SelectedRows[0].Cells[0].Value = textBoxCondition.Text.ToUpper();
                            dataGridViewExpression.SelectedRows[0].Cells[1].Value = textBoxValue.Text;
                            ex.ConditionList.Insert(sel, _conditionstruct);



                        }
                    }
                }
            }
        }

        private void buttonUpdateAction_Click(object sender, EventArgs e)
        {
            string str =((string)comboBoxEvent.SelectedItem);
            if (textBoxAction.Text != "")
            {
                int sel = dataGridViewArgument.SelectedRows[0].Index;
                
                for (int i = 0; i < dataGridViewAction.Rows.Count; i++)
                {
                    if (sel != i)
                    {
                        if (str.ToUpper() == ((string)dataGridViewAction.Rows[i].Cells[0].Value).ToUpper())
                        {
                            MessageBox.Show(str + " already assigned to other event handler ");
                            return;
                        }
                    }
                }
                string str1 = (string)dataGridViewAction.SelectedRows[0].Cells[0].Value;
                dataGridViewAction.SelectedRows[0].Cells[0].Value = (string)comboBoxEvent.SelectedItem;
                dataGridViewAction.SelectedRows[0].Cells[1].Value = (string)textBoxAction.Text;
                dataGridViewAction.SelectedRows[0].Cells[2].Value = (string)comboBoxAccessLevel.SelectedItem;

                foreach (DisplayObjectEventHandler displayobjecteventhandler in objDisplayObjectEventHandlers.list)
                {
                    if (str1.ToUpper() == displayobjecteventhandler.Event.ToUpper())
                    {
                        displayobjecteventhandler.Event = (string)comboBoxEvent.SelectedItem;
                        displayobjecteventhandler.Handler = (string)textBoxAction.Text;
                        displayobjecteventhandler.Access = (string)comboBoxAccessLevel.SelectedItem;
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("No event handler assigned to " + str);
            }
        }

        

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            string str = (string)dataGridViewArgument.SelectedRows[0].Cells[0].Value;
            foreach (DataGridViewRow item in this.dataGridViewArgument.SelectedRows)
            {
                dataGridViewArgument.Rows.RemoveAt(item.Index);
                textBoxName.Text = "";
            }
            if (dataGridViewArgument.Rows.Count > 0)
            {
                dataGridViewArgument.Rows[0].Selected = true;
            }
            foreach (DisplayObjectParameter displayobjectparameter in objDisplayObjectParameters.list)
            {
                if (displayobjectparameter.Name.ToUpper() == str.ToUpper())
                {
                    objDisplayObjectParameters.list.Remove(displayobjectparameter);
                    break;
                }
            }
        }

        private void buttonDeleteExpression_Click(object sender, EventArgs e)
        {
            string str = (string)listBox1.SelectedItem;
            foreach (DisplayObjectDynamicProperty ex in objDisplayObjectDynamicPropertys.list)
            {
                if (ex.ObjectType == ConvertListbox2DynamicGraphicalProperty(str))
                {
                    for (int i = 0; i < ex.ConditionList.Count; i++)
                    {
                        DisplayObjectDynamicPropertyCondition _condition = ex.ConditionList[i];
                        if (_condition.If.ToUpper() == ((string)dataGridViewExpression.SelectedRows[0].Cells[0].Value).ToUpper())
                        {
                            ex.ConditionList.RemoveAt(i);
                            foreach (DataGridViewRow item in this.dataGridViewArgument.SelectedRows)
                            {
                                dataGridViewExpression.Rows.RemoveAt(item.Index);
                            }
                            dataGridViewExpression.Rows[0].Selected = true;
                            return;

                        }
                    }

                }
            }     
        }

        private void buttonDeleteAction_Click(object sender, EventArgs e)
        {
            string str = (string)dataGridViewAction.SelectedRows[0].Cells[0].Value;
            foreach (DataGridViewRow item in this.dataGridViewAction.SelectedRows)
            {
                dataGridViewAction.Rows.RemoveAt(item.Index);
                //textBoxName.Text = "";
            }
            if (dataGridViewAction.Rows.Count > 0)
            {
                dataGridViewArgument.Rows[0].Selected = true;
            }
            foreach (DisplayObjectParameter displayobjectparameter in objDisplayObjectParameters.list)
            {
                if (displayobjectparameter.Name.ToUpper() == str.ToUpper())
                {
                    objDisplayObjectParameters.list.Remove(displayobjectparameter);
                    break;
                }
            }
        }

        string GetFieldType(string str)
        {
            foreach (string st in types)
            {
                string[] sts = st.Split(new Char[] { ',' });
                if (sts[0].ToUpper() == str.ToUpper())
                {
                    return sts[2];
                }
            }
            return "";
        }

        enumDynamicGraphicalProperty ConvertListbox2DynamicGraphicalProperty(string str)
        {
            if (str.StartsWith("->"))
            {
                str = str.Substring(2);
            }
            foreach (string st in types)
            {
                string[] sts = st.Split(new Char[] { ',' });
                if (sts[1].ToUpper() == str.ToUpper())
                {
                    return (enumDynamicGraphicalProperty)Enum.Parse(typeof(enumDynamicGraphicalProperty), sts[0]);
                }
            }
            return enumDynamicGraphicalProperty.Unknown;
        }

        string ConvertListbox2returnType(string str)
        {
            if (str.StartsWith("->"))
            {
                str = str.Substring(2);
            }
            foreach (string st in types)
            {
                string[] sts = st.Split(new Char[] { ',' });
                if (sts[1].ToUpper() == str.ToUpper())
                {
                    return sts[2];
                }
            }
            return "";
        }
        private void dataGridViewAction_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void checkBoxAll_Click(object sender, EventArgs e)
        {
            FillcomboBoxType();
        }

        private void moveUpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void moveDownToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewAction_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.contextMenuStrip1.Show(this.dataGridViewAction, e.Location);
                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void buttonSelectTag_Click(object sender, EventArgs e)
        {
            //"Reference",
            //"Value",
            //"Constant"
            bool ret = true;
            DialogResult result = DialogResult.OK;
            VarType _type;
            //do
            //{
                if (((string)comboBoxReference.SelectedItem == "Reference") || ((string)comboBoxReference.SelectedItem == "Value"))
                {
                    VariableForm varlistfrm = new VariableForm();

                    if (DialogResult.OK == varlistfrm.ShowDialog())
                    {
                        if ((string)comboBoxReference.SelectedItem == "Reference")
                        {
                            if (varlistfrm.IsReference)
                            {
                                _type = (VarType)varlistfrm.tblvariable.Type;
                                if ((string)comboBoxType.SelectedItem == _type.ToString())
                                {
                                    textBoxAssignment.Text = varlistfrm.Resultstr;
                                    ret = false;
                                }
                                else
                                {
                                    MessageBox.Show("Selected tag type doesn't match with selected type");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Selected tag is not reference", "Error");
                            }
                        }

                        if ((string)comboBoxReference.SelectedItem == "Value")
                        {
                            
                            if (varlistfrm.SubPropertyTxt != "")
                            {
                                _type = VarType.BOOL;
                            }
                            else
                            {
                                _type = (VarType)varlistfrm.tblformalparameter.Type;
                            }
                            if (!varlistfrm.IsReference)
                            {
                                if ((string)comboBoxType.SelectedItem == _type.ToString())
                                {
                                    textBoxAssignment.Text = varlistfrm.Resultstr;
                                    ret = false;
                                }
                                else
                                {
                                    MessageBox.Show("Selected tag type doesn't match with selected type");
                                }
                                
                            }
                            else
                            {
                                MessageBox.Show("Selected tag is not Value");
                            }
                        }
                        //if (result == DialogResult.Cancel)
                        //{

                        //    textBoxAssignment.Text = "";
                        //    ret = false;

                        //}
                    }
                    else
                    {
                        ret = false;
                    }
                }
            //} while (ret);

        }
        private void SetStartColor(Color newColor)
        {
            string startRGBText = newColor.ToString().TrimEnd(']').Substring(7);
            //comboBox_StartColor.Text = startRGBText;
            KnownColor kn = newColor.ToKnownColor();
            if (kn == 0)
            {
                textBoxValue.Text = newColor.ToString();
            }
            else
            {
                textBoxValue.Text = newColor.ToKnownColor().ToString();
            }
            // label_StartColor.Text = "Start Color: " + startRGBText;
            //panel_StartColor.BackColor = newColor;
        }


        private void button_SelectColor_Click(object sender, EventArgs e)
        {
            ColorDialog startColorDialog = new ColorDialog();
            startColorDialog.SolidColorOnly = false;
            //startColorDialog.Color = panel_Color.BackColor;
            if (startColorDialog.ShowDialog() == DialogResult.OK)
            {
                SetStartColor(startColorDialog.Color);
                //fillcolor = startColorDialog.Color;
                //FunctionThatRaisesEvent();
            }
        }

        private void comboBoxReference_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Loaded)
            {
                if (("Reference" == (string)comboBoxReference.SelectedItem) || ("Value" == (string)(comboBoxReference.SelectedItem)))
                {
                    buttonSelecttag.Enabled = true;
                }
                else
                {
                    buttonSelecttag.Enabled = false;
                }
            }
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (string st in types)
            {
                string[] sts = st.Split(new Char[] { ',' });
                if ((string)listBox1.SelectedItem == sts[1])
                {
                    _selectedFieldType = sts[2];
                    break;
                }
            }
            if (_selectedFieldType.ToUpper() == "COLOR")
            {
                button_SelectColor.Visible = true;
            }
            else
            {
                button_SelectColor.Visible = false;
            }
            if (Loaded)
            {
                updateExpGrid(ConvertListbox2DynamicGraphicalProperty((string)listBox1.SelectedItem));

            }
        }

        
        

        
    }
}
