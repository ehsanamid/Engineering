namespace DCS.Forms
{
    partial class ExpressionArgumentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExpressionArgumentForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.tabControlExpression = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.buttonSelecttag = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxAssignment = new System.Windows.Forms.TextBox();
            this.checkBoxAll = new System.Windows.Forms.CheckBox();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.comboBoxReference = new System.Windows.Forms.ComboBox();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.dataGridViewArgument = new System.Windows.Forms.DataGridView();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRef = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnInputArgument = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button_SelectColor = new System.Windows.Forms.Button();
            this.textBoxValue = new System.Windows.Forms.TextBox();
            this.textBoxCondition = new System.Windows.Forms.TextBox();
            this.buttonUpdateExpression = new System.Windows.Forms.Button();
            this.buttonDeleteExpression = new System.Windows.Forms.Button();
            this.buttonAddExpression = new System.Windows.Forms.Button();
            this.dataGridViewExpression = new System.Windows.Forms.DataGridView();
            this.ColumnCondition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxField = new System.Windows.Forms.ComboBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxAction = new System.Windows.Forms.TextBox();
            this.comboBoxAccessLevel = new System.Windows.Forms.ComboBox();
            this.comboBoxEvent = new System.Windows.Forms.ComboBox();
            this.buttonUpdateAction = new System.Windows.Forms.Button();
            this.buttonDeleteAction = new System.Windows.Forms.Button();
            this.buttonAddAction = new System.Windows.Forms.Button();
            this.dataGridViewAction = new System.Windows.Forms.DataGridView();
            this.ColumnEvent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAccessLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.moveUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.tabControlExpression.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewArgument)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExpression)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAction)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonCancel);
            this.panel1.Controls.Add(this.buttonOK);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 205);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(481, 35);
            this.panel1.TabIndex = 0;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Image = ((System.Drawing.Image)(resources.GetObject("buttonCancel.Image")));
            this.buttonCancel.Location = new System.Drawing.Point(355, 4);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(26, 26);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Image = ((System.Drawing.Image)(resources.GetObject("buttonOK.Image")));
            this.buttonOK.Location = new System.Drawing.Point(99, 4);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(26, 26);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // tabControlExpression
            // 
            this.tabControlExpression.Controls.Add(this.tabPage1);
            this.tabControlExpression.Controls.Add(this.tabPage2);
            this.tabControlExpression.Controls.Add(this.tabPage3);
            this.tabControlExpression.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlExpression.Location = new System.Drawing.Point(0, 0);
            this.tabControlExpression.Name = "tabControlExpression";
            this.tabControlExpression.SelectedIndex = 0;
            this.tabControlExpression.Size = new System.Drawing.Size(481, 205);
            this.tabControlExpression.TabIndex = 1;
            this.tabControlExpression.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.buttonSelecttag);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.textBoxAssignment);
            this.tabPage1.Controls.Add(this.checkBoxAll);
            this.tabPage1.Controls.Add(this.buttonUpdate);
            this.tabPage1.Controls.Add(this.buttonDelete);
            this.tabPage1.Controls.Add(this.buttonAdd);
            this.tabPage1.Controls.Add(this.comboBoxReference);
            this.tabPage1.Controls.Add(this.comboBoxType);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.textBoxName);
            this.tabPage1.Controls.Add(this.dataGridViewArgument);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(473, 179);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Arguments";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // buttonSelecttag
            // 
            this.buttonSelecttag.Location = new System.Drawing.Point(436, 6);
            this.buttonSelecttag.Name = "buttonSelecttag";
            this.buttonSelecttag.Size = new System.Drawing.Size(22, 20);
            this.buttonSelecttag.TabIndex = 9;
            this.buttonSelecttag.Text = "...";
            this.buttonSelecttag.UseVisualStyleBackColor = true;
            this.buttonSelecttag.Click += new System.EventHandler(this.buttonSelectTag_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(170, 10);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "Assignment";
            // 
            // textBoxAssignment
            // 
            this.textBoxAssignment.Location = new System.Drawing.Point(235, 6);
            this.textBoxAssignment.Name = "textBoxAssignment";
            this.textBoxAssignment.Size = new System.Drawing.Size(195, 20);
            this.textBoxAssignment.TabIndex = 2;
            // 
            // checkBoxAll
            // 
            this.checkBoxAll.AutoSize = true;
            this.checkBoxAll.Location = new System.Drawing.Point(211, 34);
            this.checkBoxAll.Name = "checkBoxAll";
            this.checkBoxAll.Size = new System.Drawing.Size(69, 17);
            this.checkBoxAll.TabIndex = 6;
            this.checkBoxAll.Text = "All Types";
            this.checkBoxAll.UseVisualStyleBackColor = true;
            this.checkBoxAll.Click += new System.EventHandler(this.checkBoxAll_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(409, 91);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(56, 23);
            this.buttonUpdate.TabIndex = 5;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(409, 120);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(56, 23);
            this.buttonDelete.TabIndex = 6;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(409, 62);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(56, 23);
            this.buttonAdd.TabIndex = 4;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // comboBoxReference
            // 
            this.comboBoxReference.FormattingEnabled = true;
            this.comboBoxReference.Items.AddRange(new object[] {
            "Reference",
            "Value",
            "Constant"});
            this.comboBoxReference.Location = new System.Drawing.Point(345, 30);
            this.comboBoxReference.Name = "comboBoxReference";
            this.comboBoxReference.Size = new System.Drawing.Size(85, 21);
            this.comboBoxReference.TabIndex = 4;
            this.comboBoxReference.SelectedIndexChanged += new System.EventHandler(this.comboBoxReference_SelectedIndexChanged);
            // 
            // comboBoxType
            // 
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Location = new System.Drawing.Point(51, 31);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(113, 21);
            this.comboBoxType.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(288, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Reference";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Type";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(50, 6);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(114, 20);
            this.textBoxName.TabIndex = 0;
            // 
            // dataGridViewArgument
            // 
            this.dataGridViewArgument.AllowUserToAddRows = false;
            this.dataGridViewArgument.AllowUserToDeleteRows = false;
            this.dataGridViewArgument.AllowUserToResizeRows = false;
            this.dataGridViewArgument.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewArgument.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnName,
            this.ColumnType,
            this.ColumnRef,
            this.ColumnInputArgument});
            this.dataGridViewArgument.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewArgument.Location = new System.Drawing.Point(4, 62);
            this.dataGridViewArgument.MultiSelect = false;
            this.dataGridViewArgument.Name = "dataGridViewArgument";
            this.dataGridViewArgument.RowHeadersWidth = 30;
            this.dataGridViewArgument.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewArgument.Size = new System.Drawing.Size(399, 113);
            this.dataGridViewArgument.TabIndex = 3;
            this.dataGridViewArgument.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewArgument_CellMouseClick);
            // 
            // ColumnName
            // 
            this.ColumnName.Frozen = true;
            this.ColumnName.HeaderText = "Name";
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.Width = 110;
            // 
            // ColumnType
            // 
            this.ColumnType.Frozen = true;
            this.ColumnType.HeaderText = "ColumnType";
            this.ColumnType.Name = "ColumnType";
            this.ColumnType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnType.Width = 70;
            // 
            // ColumnRef
            // 
            this.ColumnRef.Frozen = true;
            this.ColumnRef.HeaderText = "Reference";
            this.ColumnRef.Name = "ColumnRef";
            this.ColumnRef.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnRef.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnRef.Width = 65;
            // 
            // ColumnInputArgument
            // 
            this.ColumnInputArgument.HeaderText = "Input";
            this.ColumnInputArgument.Name = "ColumnInputArgument";
            this.ColumnInputArgument.Width = 120;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button_SelectColor);
            this.tabPage2.Controls.Add(this.textBoxValue);
            this.tabPage2.Controls.Add(this.textBoxCondition);
            this.tabPage2.Controls.Add(this.buttonUpdateExpression);
            this.tabPage2.Controls.Add(this.buttonDeleteExpression);
            this.tabPage2.Controls.Add(this.buttonAddExpression);
            this.tabPage2.Controls.Add(this.dataGridViewExpression);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.comboBoxField);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(473, 179);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Expression";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button_SelectColor
            // 
            this.button_SelectColor.Location = new System.Drawing.Point(391, 6);
            this.button_SelectColor.Margin = new System.Windows.Forms.Padding(0);
            this.button_SelectColor.Name = "button_SelectColor";
            this.button_SelectColor.Size = new System.Drawing.Size(26, 23);
            this.button_SelectColor.TabIndex = 45;
            this.button_SelectColor.Text = "...";
            this.button_SelectColor.Click += new System.EventHandler(this.button_SelectColor_Click);
            // 
            // textBoxValue
            // 
            this.textBoxValue.Location = new System.Drawing.Point(288, 6);
            this.textBoxValue.Name = "textBoxValue";
            this.textBoxValue.Size = new System.Drawing.Size(100, 20);
            this.textBoxValue.TabIndex = 1;
            // 
            // textBoxCondition
            // 
            this.textBoxCondition.Location = new System.Drawing.Point(54, 31);
            this.textBoxCondition.Name = "textBoxCondition";
            this.textBoxCondition.Size = new System.Drawing.Size(405, 20);
            this.textBoxCondition.TabIndex = 2;
            // 
            // buttonUpdateExpression
            // 
            this.buttonUpdateExpression.Location = new System.Drawing.Point(409, 91);
            this.buttonUpdateExpression.Name = "buttonUpdateExpression";
            this.buttonUpdateExpression.Size = new System.Drawing.Size(56, 23);
            this.buttonUpdateExpression.TabIndex = 5;
            this.buttonUpdateExpression.Text = "Update";
            this.buttonUpdateExpression.UseVisualStyleBackColor = true;
            this.buttonUpdateExpression.Click += new System.EventHandler(this.buttonUpdateExpression_Click);
            // 
            // buttonDeleteExpression
            // 
            this.buttonDeleteExpression.Location = new System.Drawing.Point(409, 120);
            this.buttonDeleteExpression.Name = "buttonDeleteExpression";
            this.buttonDeleteExpression.Size = new System.Drawing.Size(56, 23);
            this.buttonDeleteExpression.TabIndex = 6;
            this.buttonDeleteExpression.Text = "Delete";
            this.buttonDeleteExpression.UseVisualStyleBackColor = true;
            this.buttonDeleteExpression.Click += new System.EventHandler(this.buttonDeleteExpression_Click);
            // 
            // buttonAddExpression
            // 
            this.buttonAddExpression.Location = new System.Drawing.Point(409, 62);
            this.buttonAddExpression.Name = "buttonAddExpression";
            this.buttonAddExpression.Size = new System.Drawing.Size(56, 23);
            this.buttonAddExpression.TabIndex = 4;
            this.buttonAddExpression.Text = "Add";
            this.buttonAddExpression.UseVisualStyleBackColor = true;
            this.buttonAddExpression.Click += new System.EventHandler(this.buttonAddExpression_Click);
            // 
            // dataGridViewExpression
            // 
            this.dataGridViewExpression.AllowUserToAddRows = false;
            this.dataGridViewExpression.AllowUserToDeleteRows = false;
            this.dataGridViewExpression.AllowUserToResizeRows = false;
            this.dataGridViewExpression.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewExpression.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnCondition,
            this.ColumnValue});
            this.dataGridViewExpression.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewExpression.Location = new System.Drawing.Point(4, 62);
            this.dataGridViewExpression.MultiSelect = false;
            this.dataGridViewExpression.Name = "dataGridViewExpression";
            this.dataGridViewExpression.RowHeadersWidth = 30;
            this.dataGridViewExpression.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewExpression.Size = new System.Drawing.Size(399, 113);
            this.dataGridViewExpression.TabIndex = 3;
            this.dataGridViewExpression.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewExpression_CellMouseClick);
            // 
            // ColumnCondition
            // 
            this.ColumnCondition.HeaderText = "Condition";
            this.ColumnCondition.Name = "ColumnCondition";
            this.ColumnCondition.Width = 283;
            // 
            // ColumnValue
            // 
            this.ColumnValue.HeaderText = "Value";
            this.ColumnValue.Name = "ColumnValue";
            this.ColumnValue.Width = 84;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(246, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Value";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Condition";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Field";
            // 
            // comboBoxField
            // 
            this.comboBoxField.FormattingEnabled = true;
            this.comboBoxField.Location = new System.Drawing.Point(56, 6);
            this.comboBoxField.Name = "comboBoxField";
            this.comboBoxField.Size = new System.Drawing.Size(121, 21);
            this.comboBoxField.TabIndex = 0;
            this.comboBoxField.SelectedIndexChanged += new System.EventHandler(this.comboBoxField_SelectedIndexChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.textBoxAction);
            this.tabPage3.Controls.Add(this.comboBoxAccessLevel);
            this.tabPage3.Controls.Add(this.comboBoxEvent);
            this.tabPage3.Controls.Add(this.buttonUpdateAction);
            this.tabPage3.Controls.Add(this.buttonDeleteAction);
            this.tabPage3.Controls.Add(this.buttonAddAction);
            this.tabPage3.Controls.Add(this.dataGridViewAction);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(473, 179);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Action";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(221, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Access Level";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 35);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Action";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Event";
            // 
            // textBoxAction
            // 
            this.textBoxAction.Location = new System.Drawing.Point(50, 31);
            this.textBoxAction.Name = "textBoxAction";
            this.textBoxAction.Size = new System.Drawing.Size(309, 20);
            this.textBoxAction.TabIndex = 2;
            // 
            // comboBoxAccessLevel
            // 
            this.comboBoxAccessLevel.FormattingEnabled = true;
            this.comboBoxAccessLevel.Location = new System.Drawing.Point(294, 6);
            this.comboBoxAccessLevel.Name = "comboBoxAccessLevel";
            this.comboBoxAccessLevel.Size = new System.Drawing.Size(65, 21);
            this.comboBoxAccessLevel.TabIndex = 1;
            // 
            // comboBoxEvent
            // 
            this.comboBoxEvent.FormattingEnabled = true;
            this.comboBoxEvent.Items.AddRange(new object[] {
            "LMouseDoubleClick",
            "LMouseClick",
            "RMouseClick",
            "MouseDown",
            "MouseUp",
            "F1",
            "F2",
            "F3",
            "F4",
            "F5",
            "F6",
            "F7",
            "F8",
            "F9",
            "F10",
            "F11",
            "F12",
            "UpArrow",
            "DownArrow",
            "LeftArrow",
            "RightArrow",
            "Enter",
            "PgUp",
            "PgDn",
            "Home",
            "End"});
            this.comboBoxEvent.Location = new System.Drawing.Point(50, 6);
            this.comboBoxEvent.Name = "comboBoxEvent";
            this.comboBoxEvent.Size = new System.Drawing.Size(131, 21);
            this.comboBoxEvent.TabIndex = 0;
            // 
            // buttonUpdateAction
            // 
            this.buttonUpdateAction.Location = new System.Drawing.Point(409, 91);
            this.buttonUpdateAction.Name = "buttonUpdateAction";
            this.buttonUpdateAction.Size = new System.Drawing.Size(56, 23);
            this.buttonUpdateAction.TabIndex = 5;
            this.buttonUpdateAction.Text = "Update";
            this.buttonUpdateAction.UseVisualStyleBackColor = true;
            this.buttonUpdateAction.Click += new System.EventHandler(this.buttonUpdateAction_Click);
            // 
            // buttonDeleteAction
            // 
            this.buttonDeleteAction.Location = new System.Drawing.Point(409, 120);
            this.buttonDeleteAction.Name = "buttonDeleteAction";
            this.buttonDeleteAction.Size = new System.Drawing.Size(56, 23);
            this.buttonDeleteAction.TabIndex = 6;
            this.buttonDeleteAction.Text = "Delete";
            this.buttonDeleteAction.UseVisualStyleBackColor = true;
            this.buttonDeleteAction.Click += new System.EventHandler(this.buttonDeleteAction_Click);
            // 
            // buttonAddAction
            // 
            this.buttonAddAction.Location = new System.Drawing.Point(409, 62);
            this.buttonAddAction.Name = "buttonAddAction";
            this.buttonAddAction.Size = new System.Drawing.Size(56, 23);
            this.buttonAddAction.TabIndex = 4;
            this.buttonAddAction.Text = "Add";
            this.buttonAddAction.UseVisualStyleBackColor = true;
            this.buttonAddAction.Click += new System.EventHandler(this.buttonAddAction_Click);
            // 
            // dataGridViewAction
            // 
            this.dataGridViewAction.AllowUserToAddRows = false;
            this.dataGridViewAction.AllowUserToDeleteRows = false;
            this.dataGridViewAction.AllowUserToResizeRows = false;
            this.dataGridViewAction.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAction.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnEvent,
            this.ColumnAction,
            this.ColumnAccessLevel});
            this.dataGridViewAction.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewAction.Location = new System.Drawing.Point(4, 62);
            this.dataGridViewAction.MultiSelect = false;
            this.dataGridViewAction.Name = "dataGridViewAction";
            this.dataGridViewAction.RowHeadersWidth = 30;
            this.dataGridViewAction.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAction.Size = new System.Drawing.Size(399, 113);
            this.dataGridViewAction.TabIndex = 3;
            this.dataGridViewAction.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewAction_CellMouseClick);
            this.dataGridViewAction.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewAction_CellMouseUp);
            // 
            // ColumnEvent
            // 
            this.ColumnEvent.HeaderText = "Event";
            this.ColumnEvent.Name = "ColumnEvent";
            this.ColumnEvent.Width = 110;
            // 
            // ColumnAction
            // 
            this.ColumnAction.HeaderText = "Action";
            this.ColumnAction.Name = "ColumnAction";
            this.ColumnAction.Width = 207;
            // 
            // ColumnAccessLevel
            // 
            this.ColumnAccessLevel.HeaderText = "Access";
            this.ColumnAccessLevel.Name = "ColumnAccessLevel";
            this.ColumnAccessLevel.Width = 50;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moveUpToolStripMenuItem,
            this.moveDownToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(139, 48);
            // 
            // moveUpToolStripMenuItem
            // 
            this.moveUpToolStripMenuItem.Image = global::DCS.Properties.Resources.moveUp;
            this.moveUpToolStripMenuItem.Name = "moveUpToolStripMenuItem";
            this.moveUpToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.moveUpToolStripMenuItem.Text = "Move Up";
            this.moveUpToolStripMenuItem.Click += new System.EventHandler(this.moveUpToolStripMenuItem_Click);
            // 
            // moveDownToolStripMenuItem
            // 
            this.moveDownToolStripMenuItem.Image = global::DCS.Properties.Resources.moveDown;
            this.moveDownToolStripMenuItem.Name = "moveDownToolStripMenuItem";
            this.moveDownToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.moveDownToolStripMenuItem.Text = "Move Down";
            this.moveDownToolStripMenuItem.Click += new System.EventHandler(this.moveDownToolStripMenuItem_Click);
            // 
            // ExpressionArgumentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 240);
            this.Controls.Add(this.tabControlExpression);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ExpressionArgumentForm";
            this.Text = "ExpressionArgumentForm";
            this.Load += new System.EventHandler(this.ExpressionArgumentForm_Load);
            this.panel1.ResumeLayout(false);
            this.tabControlExpression.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewArgument)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExpression)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAction)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControlExpression;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.DataGridView dataGridViewArgument;
        private System.Windows.Forms.ComboBox comboBoxReference;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.ComboBox comboBoxField;
        private System.Windows.Forms.Button buttonUpdateExpression;
        private System.Windows.Forms.Button buttonDeleteExpression;
        private System.Windows.Forms.Button buttonAddExpression;
        private System.Windows.Forms.DataGridView dataGridViewExpression;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxValue;
        private System.Windows.Forms.TextBox textBoxCondition;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonUpdateAction;
        private System.Windows.Forms.Button buttonDeleteAction;
        private System.Windows.Forms.Button buttonAddAction;
        private System.Windows.Forms.DataGridView dataGridViewAction;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxAction;
        private System.Windows.Forms.ComboBox comboBoxAccessLevel;
        private System.Windows.Forms.ComboBox comboBoxEvent;
        private System.Windows.Forms.CheckBox checkBoxAll;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem moveUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveDownToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCondition;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnEvent;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAction;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAccessLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRef;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnInputArgument;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxAssignment;
        private System.Windows.Forms.Button buttonSelecttag;
        private System.Windows.Forms.Button button_SelectColor;
    }
}