using DCS.Compile;
using DCS.DCSTables;
using DCS.Forms;
using DCS.Tools;
//using DocToolkit.Project_Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DCS.TableObject;

namespace DCS.TabPages
{
    public partial class TabSTPageControl : TabTextPageControl
    {
        private tblPou _tblpou;
        public tblPou tblpou
        {
            get
            {
                return _tblpou;
            }
            set
            {
                _tblpou = value;
            }
        }

#if EWSAPP
        private POUObject _pouobject;
        public POUObject PouObject
        {
            get
            {
                return _pouobject;
            }

        }

#endif

        private tblController _tblcontroller;
        public tblController tblcontroller
        {
            get
            {
                return _tblcontroller;
            }
            set
            {
                _tblcontroller = value;
            }
        }

        public TabSTPageControl( long id)
            : base( id)
        {

            InitializeComponent();

            TabPageType = TABPAGETYPE.ST;
            //_drawarea = new DrawArea(this);
            tblpou = tblSolution.m_tblSolution().GetPouFromID(ID);
#if EWSAPP
            _pouobject = new POUObject(_tblpou); 
#endif
            tblcontroller = tblSolution.m_tblSolution().GetControllerobjectofPOUID(ID);
        }

        
        //private ImageList imageList1;

        private void InitializeComponent()
        {
            
            
        }
        

        public override void CloseTabPage()
        {
            if (Dirty)
            {
                if (DialogResult.Yes == MessageBox.Show("Do you want to save?", "Save", MessageBoxButtons.YesNoCancel))
                {
                    SaveTabPage();
                }
            }
        }
        

        
       
        #region Load
        public override bool LoadTabPage()
        {
            bool ret = false;
            ret = tblSolution.m_tblSolution().GetPouFromID(ID).LoadST(m_textboxControl);

            return ret;
        }

        
        #endregion

        #region Save
#if EWSAPP
        public override bool SaveTabPage()
        {
            // bool ret = false;
            tblpou.POUObjectCopy(PouObject);
            tblpou.Update();
            tblcontroller.SavePouDB();
            Dirty = !tblSolution.m_tblSolution().GetPouFromID(ID).SaveST(m_textboxControl);

            return !Dirty;
        } 
#endif

        

        public override bool PrintTabPage()
        {
            bool ret = false;
            

            return ret;
        }


#if EWSAPP
        public override bool CompileTabPage()
        {
            bool ret = false;
            Compiler compiler = new Compiler(/*mainForm*/);
            ret = compiler.CompilePOU(tblSolution.m_tblSolution().GetPouFromID(ID));
            return ret;
        } 
#endif
        
        

        
        #endregion

#if EWSAPP
        public override void UpdatePropertyGrid()
        {
            MainForm.Instance().m_propertyGrid.SelectedObject = PouObject;
            MainForm.Instance().m_propertyGrid.HiddenProperties = PouObject.PropertyGridFilterH();
            MainForm.Instance().m_propertyGrid.BrowsableProperties = PouObject.PropertyGridFilterS();
            MainForm.Instance().m_propertyGrid.Refresh();
        }

#endif
        
    }
}


