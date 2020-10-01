using DCS;
using DCS.DCSTables;
using DCS.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DCS.TableObject;

namespace DCS.Forms
{



    public partial class AlarmForm : Form
    {
        //long alb;
        //long aeb;
        public bool updated = false;
        //bool loaded = false;
        //int selectedIndex = 0;
        //int rowIndex;
        //MainForm mainewsform;
        //tblVariable tblvariable;
        private VariableGrid variablegrid;
        public VariableGrid Refvariablegrid;
        //AlarmObject selectedalarmobject;
        // List<AlarmObject> AlarmObjectList = new List<AlarmObject>();
        // public AlarmFrm(MainForm _mainewsform, tblVariable _tblvariable)
        //{
        //   mainewsform = _mainewsform;
        //    tblvariable = _tblvariable;
        //    InitializeComponent();
        //}

        public AlarmForm(VariableGrid _variablegrid)
        {
            // mainewsform = null;
            Refvariablegrid = _variablegrid;
            variablegrid = new VariableGrid(_variablegrid);
            InitializeComponent();


        }
        

        private void CopyToRef()
        {
            foreach (AlarmObject alarmobject in variablegrid.m_AlarmCollection)
            {
                if ((alarmobject.removed) && (alarmobject.ID != -1))
                {
                    foreach (AlarmObject _alarmobject in Refvariablegrid.m_AlarmCollection)
                    {
                        if (_alarmobject.ID == alarmobject.ID)
                        {
                            Refvariablegrid.m_AlarmCollection.Remove(_alarmobject);
                            break;
                        }
                    }
                }
            }

            foreach (AlarmObject alarmobject in variablegrid.m_AlarmCollection)
            {
                if (!alarmobject.removed)
                {
                    if (alarmobject.ID == -1)
                    {
                        Refvariablegrid.m_AlarmCollection.Add(alarmobject);
                    }
                    else
                    {
                        foreach (AlarmObject _alarmobject in Refvariablegrid.m_AlarmCollection)
                        {
                            if (_alarmobject.ID == alarmobject.ID)
                            {
                                //_alarmobject.StatusBit = alarmobject.StatusBit;

                                _alarmobject.StatusBit = (AlarmStatusBit)alarmobject.StatusBit;
                                _alarmobject.Type = (AlarmGroupType)alarmobject.Type;
                                //_alarmobject._IAlarmGroup = alarmobject._IAlarmGroup;
                                _alarmobject._IAlarmGroup = alarmobject.InitAlarmGroup(alarmobject._IAlarmGroup.ID);
                                _alarmobject.EnableTagID = alarmobject.EnableTagID;
                                _alarmobject.EnableTagDirection = alarmobject.EnableTagDirection;
                                _alarmobject.EnableTagDelayOn = alarmobject.EnableTagDelayOn;
                                _alarmobject.EnableTagDirection = alarmobject.EnableTagDirection;
                                _alarmobject.EnableTagDelayOn = alarmobject.EnableTagDelayOn;
                                _alarmobject.EnableTagDealyOff = alarmobject.EnableTagDealyOff;
                                _alarmobject.DelayOn = alarmobject.DelayOn;
                                _alarmobject.DelayOff = alarmobject.DelayOff;
                                _alarmobject.SourceAlarmTagID = alarmobject.SourceAlarmTagID;
                                _alarmobject.FirstOutGroupID = alarmobject.FirstOutGroupID;
                                _alarmobject.hysteresis = alarmobject.hysteresis;
                                _alarmobject.UpperLevelGroupID = alarmobject.UpperLevelGroupID;
                            }
                        }
                    }
                }
            }
        }


        //stringArray.Add("NR");
        //stringArray.Add("AB");
        //stringArray.Add("RHI");
        //stringArray.Add("RLO");
        //stringArray.Add("HH");
        //stringArray.Add("LL");
        //stringArray.Add("Hi");
        //stringArray.Add("Lo");
        //stringArray.Add("VLP");
        //stringArray.Add("VLN");
        //stringArray.Add("DVP");
        //stringArray.Add("DVN");
        //stringArray.Add("ODC");
        //stringArray.Add("IDC");
        //stringArray.Add("ASP");
        //stringArray.Add("ASN");
        //stringArray.Add("ABN");
        //stringArray.Add("ERR");
        //stringArray.Add("CHF");
        //stringArray.Add("BRF");
        //stringArray.Add("NEF");
        //stringArray.Add("PRT"); 



        private void AlarmFrm_Load(object sender, EventArgs e)
        {
            //bool found;
            List<string> stringArray = new List<string>();
            try
            {
                int index;
                //foreach (AlarmObject alarmobject in variablegrid.m_AlarmCollection)
                //{
                //    index = index = dataGridView1.Rows.Add();
                //    DataGridViewRow row = dataGridView1.Rows[index];
                //    //row.Cells[0].Value = index;
                //    row.Cells[0].Value = alarmobject.StatusTxt;
                //    row.Cells[1].Value = "";
                //}

                switch ((VarType)variablegrid.Type)
                {
                    case VarType.BOOL:
                        stringArray.Add("NR");
                        stringArray.Add("AB");
                        stringArray.Add("ODC");
                        stringArray.Add("IDC");
                        stringArray.Add("CHF");
                        stringArray.Add("BRF");
                        stringArray.Add("NEF");

                        break;
                    case VarType.REAL:
                        stringArray.Add("NR");
                        stringArray.Add("RHI");
                        stringArray.Add("RLO");
                        stringArray.Add("HH");
                        stringArray.Add("LL");
                        stringArray.Add("Hi");
                        stringArray.Add("Lo");
                        stringArray.Add("VLP");
                        stringArray.Add("VLN");
                        stringArray.Add("DVP");
                        stringArray.Add("DVN");
                        stringArray.Add("ODC");
                        stringArray.Add("IDC");
                        stringArray.Add("CHF");
                        stringArray.Add("BRF");
                        stringArray.Add("NEF");
                        break;
                }

                foreach (string x in stringArray)
                {
                    foreach (tblBlockAlarmStatusText tblblockalarmstatustext in tblSolution.m_tblSolution().m_tblBlockAlarmStatusTextCollection)
                    {
                        if (x.Equals(tblblockalarmstatustext.Txt))
                        {
                            index = dataGridView1.Rows.Add();

                            DataGridViewRow row = dataGridView1.Rows[index];

                            row.Cells[0].Value = tblblockalarmstatustext.Txt;
                            row.Cells[1].Value = tblblockalarmstatustext.Decsription;
                            row.Cells[4].Value = tblblockalarmstatustext.Bit;
                            if (Common.IsBitSet(variablegrid.ALB, tblblockalarmstatustext.Bit))
                            {
                                row.Cells[2].Value = true;
                                row.Cells[3].ReadOnly = false;
                                if (Common.IsBitSet(variablegrid.AEB, tblblockalarmstatustext.Bit))
                                {
                                    row.Cells[3].Value = true;
                                }
                                else
                                {
                                    row.Cells[3].Value = false;
                                }
                            }
                            else
                            {
                                row.Cells[2].Value = false;
                                row.Cells[3].ReadOnly = true;
                                row.Cells[3].Value = false;
                            }

                        }
                    }
                }
               
                //dataGridView1.Columns[0].Width = 37;
                dataGridView1.Columns[0].Width = 40;
                dataGridView1.Columns[1].Width = 154;
                dataGridView1.Columns[2].Width = 40;
                dataGridView1.Columns[3].Width = 40;
                dataGridView1.ClearSelection();
                //loaded = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        string _value;
        public string Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            updated = false;
            Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (updated)
            {
                CopyToRef();
                Refvariablegrid.AEB = variablegrid.AEB;
                Refvariablegrid.ALB = variablegrid.ALB;
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {

            updated = true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.EndEdit();
            if ((e.ColumnIndex == 0) || (e.ColumnIndex == 1))
            {
                CheckBoxClicked(e.ColumnIndex, e.RowIndex);
            }
        }

        private void dataGridView1_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {

        }

        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            bool _valbefore = false;
            if ((e.ColumnIndex == 2) || (e.ColumnIndex == 3))
            {
                _valbefore = (bool)this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            }
            dataGridView1.EndEdit();
            bool _valafter = false;
            if ((e.ColumnIndex == 2) || (e.ColumnIndex == 3))
            {
                _valafter = (bool)this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            }
            if (_valafter != _valbefore)
            {
                updated = true;
            }
            CheckBoxClicked(e.ColumnIndex, e.RowIndex);
        }
        void CheckBoxClicked(int _c, int _r)
        {
            string _statustxt = "";
            bool _found = false;
            switch (_c)
            {
                case 0:
                case 1:
                    if ((bool)this.dataGridView1.Rows[_r].Cells[3].Value)
                    {
                        _statustxt = (string)this.dataGridView1.Rows[_r].Cells[0].Value;
                        foreach (AlarmObject alarmobject in variablegrid.m_AlarmCollection)
                        {
                            if (alarmobject.StatusTxt == _statustxt)
                            {
                                propertyGrid1.SelectedObject = alarmobject;
                                _found = true;
                                break;
                            }
                        }

                    }
                    else
                    {
                        propertyGrid1.SelectedObject = null;
                    }
                    break;
                case 2:

                    if ((bool)this.dataGridView1.Rows[_r].Cells[_c].Value)
                    {
                        this.dataGridView1.Rows[_r].Cells[3].ReadOnly = false;
                       
                    }
                    else
                    {
                        this.dataGridView1.Rows[_r].Cells[3].ReadOnly = true;
                        this.dataGridView1.Rows[_r].Cells[3].Value = false;
                        _statustxt = (string)this.dataGridView1.Rows[_r].Cells[0].Value;
                        foreach (AlarmObject alarmobject in variablegrid.m_AlarmCollection)
                        {
                            if (alarmobject.StatusTxt == _statustxt)
                            {
                                alarmobject.removed = true;
                                //variablegrid.m_AlarmCollection.Remove(alarmobject);
                                break;
                            }
                        }
                        propertyGrid1.SelectedObject = null;
                    }
                    break;
                case 3:
                    if ((bool)this.dataGridView1.Rows[_r].Cells[_c].Value)
                    {
                        _statustxt = (string)this.dataGridView1.Rows[_r].Cells[0].Value;
                        foreach (AlarmObject alarmobject in variablegrid.m_AlarmCollection)
                        {
                            if (alarmobject.StatusTxt == _statustxt)
                            {
                                alarmobject.removed = false;
                                propertyGrid1.SelectedObject = alarmobject;
                                _found = true;
                                break;
                            }
                        }
                        if (!_found)
                        {
                            foreach (tblBlockAlarmStatusText tblblockalarmstatustext in tblSolution.m_tblSolution().m_tblBlockAlarmStatusTextCollection)
                            {
                                if (_statustxt.Equals(tblblockalarmstatustext.Txt))
                                {
                                    AlarmObject _alarmobject = new AlarmObject();
                                    _alarmobject.StatusBit = (AlarmStatusBit)tblblockalarmstatustext.Bit;
                                    _alarmobject.VarNameID = variablegrid.VarNameID;
                                    
                                    _alarmobject.ID = -1;
                                    propertyGrid1.SelectedObject = _alarmobject;
                                    variablegrid.m_AlarmCollection.Add(_alarmobject);
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        _statustxt = (string)this.dataGridView1.Rows[_r].Cells[0].Value;
                        foreach (AlarmObject alarmobject in variablegrid.m_AlarmCollection)
                        {
                            if (alarmobject.StatusTxt == _statustxt)
                            {
                                alarmobject.removed = true;
                                //variablegrid.m_AlarmCollection.Remove(alarmobject);
                                break;
                            }
                        }
                        propertyGrid1.SelectedObject = null;
                    }
                    break;
            }
            if ((_c == 2) || (_c == 3))
            {
                variablegrid.ALB = Common.SetBit(variablegrid.ALB, (int)this.dataGridView1.Rows[_r].Cells[4].Value, (bool)this.dataGridView1.Rows[_r].Cells[2].Value);
                variablegrid.AEB = Common.SetBit(variablegrid.AEB, (int)this.dataGridView1.Rows[_r].Cells[4].Value, (bool)this.dataGridView1.Rows[_r].Cells[3].Value);
            }
        }

        //private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        //{

        //}

        //private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        //{
        //    dataGridView1.EndEdit();
        //}
        //private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        //{
        //    bool bo = (bool)this.dataGridView1.Rows[1].Cells[3].Value;
        //}
    }
}
