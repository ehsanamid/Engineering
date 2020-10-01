using DCS;
using DCS.Compile;
using DCS.DCSTables;
using DCS.Draw;
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

    struct conditionstruct
    {
        public string condition;
        public string value;
    }

    struct ConditionExpressions
    {
        public string FieldName;
        public string FieldType;
        public List<conditionstruct> conditionlist;
    }


    public partial class ExpressionArgumentForm : Form
    {
        bool Loaded = false;
        //int selectrow = -1;
        private List<string> types = new List<string>();
        string _argumentstr;
        string _expressionstr;
        string _actionstr;
        int tabControlExpression_SelectedIndex = 0;
        List<ConditionExpressions> ConditionExpressionslist = new List<ConditionExpressions>();
        string _selectedFieldType = "";
        public string Argumentstr
        {
            get
            {
                XmlDocument dom = new XmlDocument();

                XmlElement ArgumentsElement = dom.CreateElement("Arguments");
                dom.AppendChild(ArgumentsElement);
                for (int rowno = 0; rowno < dataGridViewArgument.Rows.Count; rowno++)
                {
                    XmlElement ArgumentElement = dom.CreateElement("Argument");
                    ArgumentsElement.AppendChild(ArgumentElement);

                    XmlElement NameElement = dom.CreateElement("Name");
                    NameElement.InnerText = (string)dataGridViewArgument.Rows[rowno].Cells[0].Value.ToString().ToUpper();
                    ArgumentElement.AppendChild(NameElement);
                    XmlElement TypeElement = dom.CreateElement("Type");
                    TypeElement.InnerText = (string)dataGridViewArgument.Rows[rowno].Cells[1].Value.ToString().ToUpper();
                    ArgumentElement.AppendChild(TypeElement);
                    XmlElement ReferenceElement = dom.CreateElement("Reference");
                    ReferenceElement.InnerText = (string)dataGridViewArgument.Rows[rowno].Cells[2].Value.ToString();
                    ArgumentElement.AppendChild(ReferenceElement);
                    XmlElement InputElement = dom.CreateElement("Input");
                    InputElement.InnerText = (string)dataGridViewArgument.Rows[rowno].Cells[3].Value.ToString().ToUpper();
                    ArgumentElement.AppendChild(InputElement);
                }
                _argumentstr = dom.InnerXml;
                return _argumentstr;
            }
            set
            {
                _argumentstr = value;
                if (_argumentstr != "")
                {
                    XmlDocument doc = new XmlDocument();

                    doc.LoadXml(_argumentstr);
                    XmlNode myNode = doc.DocumentElement;
                    XmlNode ArgumentsNodes = doc.SelectSingleNode("Arguments");
                    if (ArgumentsNodes != null)
                    {
                        XmlNodeList xnList = ArgumentsNodes.SelectNodes("Argument");
                        foreach (XmlNode ArgumentNode in xnList)
                        //foreach (XmlNode argumentsnode in ArgumentsNodes.ChildNodes)
                        {
                            //XmlNode ArgumentNode = argumentsnode.SelectSingleNode("Argument");
                            int rowId = dataGridViewArgument.Rows.Add();

                            DataGridViewRow row = dataGridViewArgument.Rows[rowId];

                            if (ArgumentNode["Name"] != null)
                                row.Cells[0].Value = ArgumentNode["Name"].InnerText;
                            if (ArgumentNode["Type"] != null)
                                row.Cells[1].Value = ArgumentNode["Type"].InnerText;
                            if (ArgumentNode["Reference"] != null)
                                row.Cells[2].Value = ArgumentNode["Reference"].InnerText;
                            if (ArgumentNode["Input"] != null)
                                row.Cells[3].Value = ArgumentNode["Input"].InnerText;
                            else
                                row.Cells[3].Value = "";
                            dataGridViewArgument.Rows[rowId].Selected = true;
                        }
                    }
                }

            }
        }

        public string Expressionstr
        {
            get
            {
                XmlDocument dom = new XmlDocument();
                XmlElement ExpressionsElement = dom.CreateElement("Expressions");
                dom.AppendChild(ExpressionsElement);
                foreach (ConditionExpressions ex in ConditionExpressionslist)
                {
                    XmlElement ExpressionElement = dom.CreateElement("Expression");
                    ExpressionsElement.AppendChild(ExpressionElement);

                    XmlElement FieldNameElement = dom.CreateElement("FieldName");
                    FieldNameElement.InnerText = ex.FieldName.ToUpper();
                    ExpressionElement.AppendChild(FieldNameElement);

                    XmlElement FieldTypeElement = dom.CreateElement("FieldType");
                    FieldTypeElement.InnerText = ex.FieldType.ToUpper();
                    ExpressionElement.AppendChild(FieldTypeElement);
                    foreach (conditionstruct condition in ex.conditionlist)
                    {
                        XmlElement FieldConditionsElement = dom.CreateElement("FieldConditions");
                        ExpressionElement.AppendChild(FieldConditionsElement);

                        XmlElement ConditionElement = dom.CreateElement("Condition");
                        ConditionElement.InnerText = condition.condition;
                        FieldConditionsElement.AppendChild(ConditionElement);

                        XmlElement ValueElement = dom.CreateElement("Value");
                        ValueElement.InnerText = condition.value;
                        FieldConditionsElement.AppendChild(ValueElement);
                    }

                }
                _expressionstr = dom.InnerXml;
                return _expressionstr;
            }
            set
            {
                _expressionstr = value;
                if (_expressionstr != "")
                {
                    XmlDocument doc = new XmlDocument();

                    doc.LoadXml(_expressionstr);
                    XmlNode myNode = doc.DocumentElement;

                    XmlNode ExpressionsNodes = doc.SelectSingleNode("Expressions");
                    if (ExpressionsNodes != null)
                    {
                        XmlNodeList xnList = ExpressionsNodes.SelectNodes("Expression");
                        foreach (XmlNode expressionnode in xnList)
                        {
                            //XmlNode expressionnode = expressionsnodes.SelectSingleNode("Expression");


                            ConditionExpressions ex = new ConditionExpressions();
                            ex.conditionlist = new List<conditionstruct>();
                            ex.FieldName = expressionnode["FieldName"].InnerText;
                            ex.FieldType = expressionnode["FieldType"].InnerText;
                            ex.conditionlist = new List<conditionstruct>();

                            XmlNodeList xnList1 = expressionnode.SelectNodes("FieldConditions");
                            foreach (XmlNode conditions in xnList1)
                            {
                                conditionstruct _conditionstruct = new Forms.conditionstruct();
                                _conditionstruct.condition = conditions["Condition"].InnerText;
                                _conditionstruct.value = conditions["Value"].InnerText;
                                ex.conditionlist.Add(_conditionstruct);
                            }
                            ConditionExpressionslist.Add(ex);
                        }
                    }
                }
            }
        }


        public string Actionstr
        {
            get
            {
                XmlDocument dom = new XmlDocument();
                XmlElement ArgumentsElement = dom.CreateElement("Actions");
                dom.AppendChild(ArgumentsElement);
                for (int rowno = 0; rowno < dataGridViewAction.Rows.Count; rowno++)
                {
                    XmlElement ArgumentElement = dom.CreateElement("Action");
                    ArgumentsElement.AppendChild(ArgumentElement);

                    XmlElement EventElement = dom.CreateElement("Event");
                    EventElement.InnerText = (string)dataGridViewAction.Rows[rowno].Cells[0].Value.ToString().ToUpper();
                    ArgumentElement.AppendChild(EventElement);
                    XmlElement HandlerElement = dom.CreateElement("Handler");
                    HandlerElement.InnerText = (string)dataGridViewAction.Rows[rowno].Cells[1].Value.ToString().ToUpper();
                    ArgumentElement.AppendChild(HandlerElement);
                    XmlElement AccessLevelElement = dom.CreateElement("AccessLevel");
                    AccessLevelElement.InnerText = (string)dataGridViewAction.Rows[rowno].Cells[2].Value.ToString().ToUpper();
                    ArgumentElement.AppendChild(AccessLevelElement);
                }

                _actionstr = dom.InnerXml;
                return _actionstr;
            }
            set
            {
                _actionstr = value;
                if (_actionstr != "")
                {
                    XmlDocument doc = new XmlDocument();

                    doc.LoadXml(_actionstr);
                    XmlNode myNode = doc.DocumentElement;
                    XmlNode ActionsNodes = doc.SelectSingleNode("Actions");
                    if (ActionsNodes != null)
                    {
                        XmlNodeList xnList = ActionsNodes.SelectNodes("Action");
                        foreach (XmlNode ActionNode in xnList)
                        {
                            int rowId = dataGridViewAction.Rows.Add();

                            DataGridViewRow row = dataGridViewAction.Rows[rowId];

                            if (ActionNode["Event"] != null)
                                row.Cells[0].Value = ActionNode["Event"].InnerText;
                            if (ActionNode["Handler"] != null)
                                row.Cells[1].Value = ActionNode["Handler"].InnerText;
                            if (ActionNode["AccessLevel"] != null)
                                row.Cells[2].Value = ActionNode["AccessLevel"].InnerText;
                            dataGridViewAction.Rows[rowId].Selected = true;
                        }
                    }
                }
            }
        }

        long ID;
        public ExpressionArgumentForm()
        {
            InitializeComponent();
        }

        public ExpressionArgumentForm(long id, string _argument, string _expressions, string _actions, List<string> _list)
        {
            InitializeComponent();
            Argumentstr = _argument;
            Expressionstr = _expressions;
            Actionstr = _actions;
            types = _list;
            ID = id;
        }

        public void selectTabPage(int _tabindex)
        {
            tabControlExpression_SelectedIndex = _tabindex;
        }
        private void ExpressionArgumentForm_Load(object sender, EventArgs e)
        {
            FillcomboBoxType();
            foreach (string st in types)
            {
                string[] sts = st.Split(new Char[] { ',' });
                comboBoxField.Items.Add(sts[0]);
            }

            for (int i = 1; i <= 16; i++)
            {
                comboBoxAccessLevel.Items.Add(i.ToString());
            }
            Loaded = true;
            comboBoxType.SelectedIndex = 0;
            comboBoxReference.SelectedIndex = 0;
            comboBoxField.SelectedIndex = 0;

            comboBoxEvent.SelectedIndex = 0;
            comboBoxAccessLevel.SelectedIndex = 0;
            //dataGridViewExpression.Columns[0].Width = 254;
            //dataGridViewExpression.Columns[1].Width = 86;
            //dataGridViewExpression.RowHeadersWidth = 30;
            tabControlExpression.SelectedIndex = tabControlExpression_SelectedIndex;
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
                        if (Common.IsSimpleType(tblfunction.Type))
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
                comboBoxType.SelectedItem = (string)dataGridViewArgument.Rows[e.RowIndex].Cells[1].Value;
                comboBoxReference.SelectedItem = (string)dataGridViewArgument.Rows[e.RowIndex].Cells[2].Value;
                textBoxAssignment.Text = (string)dataGridViewArgument.Rows[e.RowIndex].Cells[3].Value;
            }
        }



        private void buttonUp_Click(object sender, EventArgs e)
        {

        }

        private void buttonDown_Click(object sender, EventArgs e)
        {

        }

        void updateExpGrid()
        {
            string str = (string)comboBoxField.SelectedItem;
            foreach (ConditionExpressions ex in ConditionExpressionslist)
            {
                if (ex.FieldName.ToUpper() == str.ToUpper())
                {
                    dataGridViewExpression.Rows.Clear();
                    foreach (conditionstruct condition in ex.conditionlist)
                    {
                        int rowId = dataGridViewExpression.Rows.Add();

                        // Grab the new row!
                        DataGridViewRow row = dataGridViewExpression.Rows[rowId];

                        // Add the data
                        row.Cells[0].Value = condition.condition;
                        row.Cells[1].Value = condition.value;
                        dataGridViewExpression.Rows[rowId].Selected = true;
                    }
                    return;
                }
            }
            dataGridViewExpression.Rows.Clear();
        }
        private void comboBoxField_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (string st in types)
            {
                string[] sts = st.Split(new Char[] { ',' });
                if ((string)comboBoxField.SelectedItem == sts[0])
                {
                    _selectedFieldType = sts[1];
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
                updateExpGrid();

            }
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
            if (tabControlExpression.SelectedTab.Text == "Expression")
            {
                updateExpGrid();
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
            if (Compiler.IsValueString(str, ref  _valueobj))
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
                row.Cells[1].Value = comboBoxType.SelectedItem;
                row.Cells[2].Value = comboBoxReference.SelectedItem;
                row.Cells[3].Value = textBoxAssignment.Text.ToUpper();
                dataGridViewArgument.Rows[rowId].Selected = true;
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


                    string str = (string)comboBoxField.SelectedItem;
                    bool found = false;
                    foreach (ConditionExpressions ex in ConditionExpressionslist)
                    {
                        if (ex.FieldName.ToUpper() == str.ToUpper())
                        {
                            found = true;
                            conditionstruct _conditionstruct = new conditionstruct();
                            _conditionstruct.condition = textBoxCondition.Text.ToUpper();
                            _conditionstruct.value = textBoxValue.Text;
                            ex.conditionlist.Add(_conditionstruct);

                        }
                    }
                    if (!found)
                    {
                        ConditionExpressions ex = new ConditionExpressions();
                        ex.FieldName = str;
                        ex.FieldType = GetFieldType(str);
                        ex.conditionlist = new List<conditionstruct>();
                        conditionstruct _conditionstruct = new conditionstruct();
                        _conditionstruct.condition = textBoxCondition.Text.ToUpper();
                        _conditionstruct.value = textBoxValue.Text;
                        ex.conditionlist.Add(_conditionstruct);
                        ConditionExpressionslist.Add(ex);

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
            string str = ((string)comboBoxEvent.SelectedItem);
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

                dataGridViewArgument.SelectedRows[0].Cells[0].Value = textBoxName.Text.ToUpper();
                dataGridViewArgument.SelectedRows[0].Cells[1].Value = (string)comboBoxType.SelectedItem;
                dataGridViewArgument.SelectedRows[0].Cells[2].Value = (string)comboBoxReference.SelectedItem;
                dataGridViewArgument.SelectedRows[0].Cells[3].Value = (string)textBoxAssignment.Text.ToUpper();
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
                    string str = (string)comboBoxField.SelectedItem;
                    int sel = dataGridViewExpression.SelectedRows[0].Index;
                    foreach (ConditionExpressions ex in ConditionExpressionslist)
                    {
                        if (ex.FieldName.ToUpper() == str.ToUpper())
                        {
                            //for (int i = 0; i < ex.conditionlist.Count; i++)

                            //conditionstruct _conditionstruct = ex.conditionlist[sel];
                            ex.conditionlist.RemoveAt(sel);

                            conditionstruct _conditionstruct = new conditionstruct();
                            // ex.conditionlist.Insert(sel, _conditionstruct);
                            //  if (_conditionstruct.condition.ToUpper() == ((string)dataGridViewExpression.SelectedRows[0].Cells[0].Value).ToUpper())

                            _conditionstruct.condition = textBoxCondition.Text.ToUpper();
                            _conditionstruct.value = textBoxValue.Text;
                            dataGridViewExpression.SelectedRows[0].Cells[0].Value = textBoxCondition.Text.ToUpper();
                            dataGridViewExpression.SelectedRows[0].Cells[1].Value = textBoxValue.Text;
                            ex.conditionlist.Insert(sel, _conditionstruct);

                        }
                    }
                }
            }
        }

        private void buttonUpdateAction_Click(object sender, EventArgs e)
        {
            string str = ((string)comboBoxEvent.SelectedItem);
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

                dataGridViewAction.SelectedRows[0].Cells[0].Value = textBoxName.Text.ToUpper();
                dataGridViewAction.SelectedRows[0].Cells[1].Value = (string)comboBoxType.SelectedItem;
                dataGridViewAction.SelectedRows[0].Cells[2].Value = (string)comboBoxReference.SelectedItem;
            }
            else
            {
                MessageBox.Show("No event handler assigned to " + str);
            }
        }



        private void buttonDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.dataGridViewArgument.SelectedRows)
            {
                dataGridViewArgument.Rows.RemoveAt(item.Index);
                textBoxName.Text = "";
            }
            if (dataGridViewArgument.Rows.Count > 0)
            {
                dataGridViewArgument.Rows[0].Selected = true;
            }
        }

        private void buttonDeleteExpression_Click(object sender, EventArgs e)
        {
            string str = (string)comboBoxField.SelectedItem;
            foreach (ConditionExpressions ex in ConditionExpressionslist)
            {
                if (ex.FieldName.ToUpper() == str.ToUpper())
                {
                    for (int i = 0; i < ex.conditionlist.Count; i++)
                    {
                        conditionstruct _conditionstruct = ex.conditionlist[i];
                        if (_conditionstruct.condition.ToUpper() == ((string)dataGridViewExpression.SelectedRows[0].Cells[0].Value).ToUpper())
                        {
                            ex.conditionlist.RemoveAt(i);
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
            foreach (DataGridViewRow item in this.dataGridViewAction.SelectedRows)
            {
                dataGridViewAction.Rows.RemoveAt(item.Index);
                //textBoxName.Text = "";
            }
            if (dataGridViewAction.Rows.Count > 0)
            {
                dataGridViewArgument.Rows[0].Selected = true;
            }
        }

        string GetFieldType(string str)
        {
            foreach (string st in types)
            {
                string[] sts = st.Split(new Char[] { ',' });
                if (sts[0].ToUpper() == str.ToUpper())
                {
                    return sts[1];
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
                if ((comboBoxReference.SelectedItem == "Reference") || (comboBoxReference.SelectedItem == "Value"))
                {
                    buttonSelecttag.Enabled = true;
                }
                else
                {
                    buttonSelecttag.Enabled = false;
                }
            }
        }




    }
}
