using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using DocToolkit.Project_Objects;
using DCS.Tools;
using DCS.DCSTables;

//using System.CodeDom.Compiler;


namespace DCS.Forms
{
    public partial class AddVariableForm : Form
    {
        public MainForm frm;
        private static readonly List<NameID> possibleclasses = new List<NameID>();
        private static readonly List<NameID> possibletypes = new List<NameID>();
        private static readonly List<NameID> possibleoption = new List<NameID>();
        public int VarID;
        private bool global;
        private int PouID;
       // tblVariable _tblvariable;
        public AddVariableForm(MainForm _frm, bool _global, int _pouid)
        {
            frm = _frm;
            global = _global;
            PouID = _pouid;
            InitializeComponent();
            LoadVarTypes();
            LoadVarClass();
            LoadVarOption();
        }
        //[DisplayName("ConnectionString")]
        //[Category("Uplink")]
        //public string ConnectionString
        //{
        //    get
        //    {
        //        try
        //        {
        //            return frm.ConnectionString;
        //        }
        //        catch (System.Exception err)
        //        {
        //            throw new Exception("Error getting connect string", err);
        //        }
        //    }

        //}

        private void LoadVarTypes()
        {
            //for (int i = 0; i < tblSolution.m_tblSolution().m_tblVarTypeCollection.Count; i++)
            //{
            //    if (tblSolution.m_tblSolution().m_tblVarTypeCollection[i].Generic == 0)
            //    {
            //        possibletypes.Add(new NameID(tblSolution.m_tblSolution().m_tblVarTypeCollection[i].TypeName, tblSolution.m_tblSolution().m_tblVarTypeCollection[i].Value));
            //    }

            //}
            //comboBoxType.DataSource = possibletypes;
            //comboBoxType.DisplayMember = "Name";  // the Name property in Choice class
            //comboBoxType.ValueMember = "ID";  // ditto for the Value property
            //comboBoxType.FlatStyle = FlatStyle.Popup;
        }

        private void LoadVarClass()
        {
            //if (global == true)
            //{
            //    possibleclasses.Add(new NameID(Enum.GetName(typeof(VarClass), VarClass.Global), (int)VarClass.Global));
            //}
            //else
            //{
            //    possibleclasses.Add(new NameID(Enum.GetName(typeof(VarClass), VarClass.Input), (int)VarClass.Input));
            //    possibleclasses.Add(new NameID(Enum.GetName(typeof(VarClass), VarClass.Output), (int)VarClass.Output));
            //    possibleclasses.Add(new NameID(Enum.GetName(typeof(VarClass), VarClass.InOut), (int)VarClass.InOut));
            //    possibleclasses.Add(new NameID(Enum.GetName(typeof(VarClass), VarClass.External), (int)VarClass.External));
            //    possibleclasses.Add(new NameID(Enum.GetName(typeof(VarClass), VarClass.Local), (int)VarClass.Local));
            //    possibleclasses.Add(new NameID(Enum.GetName(typeof(VarClass), VarClass.Access), (int)VarClass.Access));
            //}
            //comboBoxClass.DataSource = possibleclasses;
            //comboBoxClass.DisplayMember = "Name";  // the Name property in Choice class
            //comboBoxClass.ValueMember = "ID";  // ditto for the Value property
            //comboBoxClass.FlatStyle = FlatStyle.Flat;

        }

        private void LoadVarOption()
        {
            //possibleoption.Add(new NameID(Enum.GetName(typeof(VarOption), VarOption.NonRetain), (int)VarOption.NonRetain));
            //possibleoption.Add(new NameID(Enum.GetName(typeof(VarOption), VarOption.Retain), (int)VarOption.Retain));

            //comboBoxOption.DataSource = possibleoption;
            //comboBoxOption.DisplayMember = "Name";  // the Name property in Choice class
            //comboBoxOption.ValueMember = "ID";  // ditto for the Value property
            //comboBoxOption.FlatStyle = FlatStyle.Flat;

        }

        private void buttonok_Click(object sender, EventArgs e)
        {
            //_tblvariable = new tblVariable();
            //_tblvariable.VarName = textBoxName.Text;
            //_tblvariable.Description = textBoxDescription.Text;
            //_tblvariable.Class = (VarClass)comboBoxClass.SelectedValue;
            //_tblvariable.Type = (int)comboBoxType.SelectedValue;
            //_tblvariable.Option = (int)comboBoxOption.SelectedValue;
            //_tblvariable.InitialVal = textBoxInit.Text;
            //_tblvariable.Solution_tblSolution = tblSolution.m_tblSolution();
            //_tblvariable.pouID = this.PouID;
            //int ret = _tblvariable.Insert();
            //if (ret == 0)
            //{
            //    this.DialogResult = System.Windows.Forms.DialogResult.OK;
            //    Close();
            //}
            //else
            //{
            //    if (ret == 2627)
            //    {
            //        MessageBox.Show("Name exits in database", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            //    }
            //    else
            //    {
            //        MessageBox.Show("Database Error", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            //    }
            //}


        }

        private void buttoncancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                Close();
        }

        private void VariableForm_Load(object sender, EventArgs e)
        {
            buttonok.Enabled = false;
            
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
           
            //if (MainForm.IsValidVariableName(textBoxName.Text))
            //{
            //    buttonok.Enabled = true;
            //}
            //else
            //{
            //    buttonok.Enabled = false;
            //}
           
           
        }
    }
}
