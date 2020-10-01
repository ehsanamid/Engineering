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
    public partial class AddPouForm : Form
    {
        
        private static readonly List<NameID> possiblelangaue = new List<NameID>();
        private static readonly List<NameID> possibletypes = new List<NameID>();
        //private int ControllerID;
        public tblController controller;
        public tblPou m_tblpou;
        POUTYPE poutype;
        public AddPouForm( tblController _controller,POUTYPE _poutype)
        {
            
            controller = _controller;
            poutype = _poutype;
            //ControllerID = _controller.ControllerID;
            InitializeComponent();
            LoadPouTypes();
            LoadVarProgrammingLanguage();
            
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

        private void LoadPouTypes()
        {
            possibletypes.Add(new NameID(Enum.GetName(typeof(POUTYPE), POUTYPE.PROGRAM), (int)POUTYPE.PROGRAM));
            possibletypes.Add(new NameID(Enum.GetName(typeof(POUTYPE), POUTYPE.FUNCTION), (int)POUTYPE.FUNCTION));
            possibletypes.Add(new NameID(Enum.GetName(typeof(POUTYPE), POUTYPE.FUNCTIONBLOCK), (int)POUTYPE.FUNCTIONBLOCK));
                
            comboBoxPOUtype.DataSource = possibletypes;
            comboBoxPOUtype.DisplayMember = "Name";  // the Name property in Choice class
            comboBoxPOUtype.ValueMember = "ID";  // ditto for the Value property
            comboBoxPOUtype.FlatStyle = FlatStyle.Popup;
            comboBoxPOUtype.SelectedIndex = (int)poutype;
            comboBoxPOUtype.Enabled = false;

        }

        private void LoadVarProgrammingLanguage()
        {

            possiblelangaue.Add(new NameID(Enum.GetName(typeof(PouLanguageType), PouLanguageType.FBD), (int)PouLanguageType.FBD));
            possiblelangaue.Add(new NameID(Enum.GetName(typeof(PouLanguageType), PouLanguageType.IL), (int)PouLanguageType.IL));
            possiblelangaue.Add(new NameID(Enum.GetName(typeof(PouLanguageType), PouLanguageType.LD), (int)PouLanguageType.LD));
            possiblelangaue.Add(new NameID(Enum.GetName(typeof(PouLanguageType), PouLanguageType.ST), (int)PouLanguageType.ST));
            possiblelangaue.Add(new NameID(Enum.GetName(typeof(PouLanguageType), PouLanguageType.SFC), (int)PouLanguageType.SFC));
            
           
            comboBoxProgrammingLanguage.DataSource = possiblelangaue;
            comboBoxProgrammingLanguage.DisplayMember = "Name";  // the Name property in Choice class
            comboBoxProgrammingLanguage.ValueMember = "ID";  // ditto for the Value property
            comboBoxProgrammingLanguage.FlatStyle = FlatStyle.Flat;

        }

        

        private void buttonok_Click(object sender, EventArgs e)
        {
            m_tblpou = new tblPou();
            m_tblpou.pouName = textBoxName.Text;
            m_tblpou.Description = textBoxDescription.Text;
            m_tblpou.Type = (POUTYPE )comboBoxPOUtype.SelectedValue;
            m_tblpou.Language = (PouLanguageType)comboBoxProgrammingLanguage.SelectedValue;
            m_tblpou.ControllerID = controller.ControllerID;
            m_tblpou.m_ControllerID_tblController = controller;
            int ret = m_tblpou.Insert();
            if (ret == 0)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                controller.m_tblPouCollection.Add(m_tblpou);
                Close();
            }
            else
            {
                if (ret == 2627)
                {
                    MessageBox.Show("POU Name exits in this controller select another name", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Database Error", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                }
            }


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

        private void comboBoxClass_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
