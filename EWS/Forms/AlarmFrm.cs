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



    public partial class AlarmFrm : Form
    {
        BindingList<tblBlockAlarmStatusText> _combo = new BindingList<tblBlockAlarmStatusText>();
        public bool updated = false;
        int selectedIndex = 0;
        int rowIndex;
        //MainForm mainewsform;
        //tblVariable tblvariable;
        private VariableGrid variablegrid;
        public  VariableGrid Refvariablegrid;
       // AlarmObject selectedalarmobject;
        // List<AlarmObject> AlarmObjectList = new List<AlarmObject>();
        // public AlarmFrm(MainForm _mainewsform, tblVariable _tblvariable)
        //{
        //   mainewsform = _mainewsform;
        //    tblvariable = _tblvariable;
        //    InitializeComponent();
        //}

        public AlarmFrm(VariableGrid _variablegrid)
        {
            // mainewsform = null;
            Refvariablegrid = _variablegrid;
            variablegrid = new VariableGrid(_variablegrid);
            InitializeComponent();
            

        }
        //private void CopyFromRef()
        //{
        //    variablegrid.VarNameID = Refvariablegrid.VarNameID;
        //    variablegrid.Type = Refvariablegrid.Type;
        //    variablegrid.ConnectedtoChannel = Refvariablegrid.ConnectedtoChannel;
        //    foreach (AlarmObject alarmobject in Refvariablegrid.m_AlarmCollection)
        //    {
        //        AlarmObject _alarmobject = new AlarmObject();
        //        _alarmobject.Status = alarmobject.Status;

        //        _alarmobject.ID = alarmobject.ID;
        //        _alarmobject.VarNameID = alarmobject.VarNameID;
        //        _alarmobject.Status = (AlarmStatus)alarmobject.Status;
        //        _alarmobject.Type = (AlarmGroupType)alarmobject.Type;
        //        _alarmobject._IAlarmGroup = alarmobject._IAlarmGroup;
        //        _alarmobject.EnableTagID = alarmobject.EnableTagID;
        //        _alarmobject.EnableTagDirection = alarmobject.EnableTagDirection;
        //        _alarmobject.EnableTagDelayOn = alarmobject.EnableTagDelayOn;
        //        _alarmobject.EnableTagDirection = alarmobject.EnableTagDirection;
        //        _alarmobject.EnableTagDelayOn = alarmobject.EnableTagDelayOn;
        //        _alarmobject.EnableTagDealyOff = alarmobject.EnableTagDealyOff;
        //        _alarmobject.DelayOn = alarmobject.DelayOn;
        //        _alarmobject.DelayOff = alarmobject.DelayOff;
        //        _alarmobject.SourceAlarmTagID = alarmobject.SourceAlarmTagID;
        //        _alarmobject.FirstOutGroupID = alarmobject.FirstOutGroupID;
        //        _alarmobject.hysteresis = alarmobject.hysteresis;
        //        _alarmobject.UpperLevelGroupID = alarmobject.UpperLevelGroupID;

        //        variablegrid.m_AlarmCollection.Add(_alarmobject);
            
        //    }

        //}

        private void CopyToRef()
        {
            
            foreach (AlarmObject alarmobject in variablegrid.m_AlarmCollection)
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
                             _alarmobject._IAlarmGroup =  alarmobject.InitAlarmGroup(alarmobject._IAlarmGroup.ID);
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
            bool found;
            List<string> stringArray = new List<string>();
            try
            {
                

                comboBoxsAlarmState.DataSource = _combo;
                comboBoxsAlarmState.DisplayMember = "Decsription";
                comboBoxsAlarmState.ValueMember = "ID";
                int index;
                foreach (AlarmObject alarmobject in variablegrid.m_AlarmCollection)
                {
                    index = index = dataGridView1.Rows.Add();
                    DataGridViewRow row = dataGridView1.Rows[index];
                    //row.Cells[0].Value = index;
                    row.Cells[0].Value = alarmobject.StatusTxt;
                    row.Cells[1].Value = "";
                }

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
                    found = false;
                    foreach (AlarmObject alarmobject in variablegrid.m_AlarmCollection)
                    {
                        if (x.ToUpper() == alarmobject.StatusTxt.ToUpper())
                        {
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        foreach (tblBlockAlarmStatusText tblblockalarmstatustext in tblSolution.m_tblSolution().m_tblBlockAlarmStatusTextCollection)
                        {
                            if (x.Equals(tblblockalarmstatustext.Txt))
                            {
                                _combo.Add(tblblockalarmstatustext);
                                break;
                            }
                        }
                    }
                }


                //dataGridView1.Columns[0].Width = 37;
                dataGridView1.Columns[0].Width = 86;
                dataGridView1.Columns[1].Width = 154;
                dataGridView1.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonADD_Click(object sender, EventArgs e)
        {
            int index = 0;

            index = dataGridView1.Rows.Add();
            AlarmObject alarmobject = new AlarmObject();
            alarmobject.VarNameID = variablegrid.VarNameID;
            alarmobject.StatusTxt = ((tblBlockAlarmStatusText)comboBoxsAlarmState.SelectedItem).Txt;
            variablegrid.m_AlarmCollection.Add(alarmobject);
            DataGridViewRow row = dataGridView1.Rows[index];
           // row.Cells[0].Value = index;
            row.Cells[0].Value = ((tblBlockAlarmStatusText)comboBoxsAlarmState.SelectedItem).Txt;
            row.Cells[1].Value = ((tblBlockAlarmStatusText)comboBoxsAlarmState.SelectedItem).Decsription;
            //alarmobject.Status = (AlarmStatus)((tblBlockAlarmStatusText)comboBoxsAlarmState.SelectedItem).Bit;
            propertyGrid1.SelectedObject = alarmobject;

            _combo.RemoveAt(comboBoxsAlarmState.SelectedIndex);
            comboBoxsAlarmState.DataSource = null;
            comboBoxsAlarmState.DataSource = _combo;
            comboBoxsAlarmState.DisplayMember = "Decsription";
            comboBoxsAlarmState.ValueMember = "ID";
            //comboBoxsAlarmState.Items.Remove(comboBoxsAlarmState.SelectedItem);
            updated = true;
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
            string _statustxt = "";
            if (e.RowIndex == -1)
            {

            }
            else
            {
                selectedIndex = e.RowIndex;
                _statustxt = (string)this.dataGridView1.Rows[e.RowIndex].Cells[0].Value;
                foreach (AlarmObject alarmobject in variablegrid.m_AlarmCollection)
                {
                    if (alarmobject.StatusTxt == _statustxt)
                    {
                        propertyGrid1.SelectedObject = alarmobject;
                    }
                }

            }
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string _statustxt = "";
            if (rowIndex == -1)
            {

            }
            else
            {
                selectedIndex = rowIndex;
                _statustxt = (string)this.dataGridView1.Rows[rowIndex].Cells[0].Value;
                dataGridView1.Rows.RemoveAt(rowIndex);

                foreach (tblBlockAlarmStatusText tblblockalarmstatustext in tblSolution.m_tblSolution().m_tblBlockAlarmStatusTextCollection)
                {
                    if (_statustxt.Equals(tblblockalarmstatustext.Txt))
                    {
                        _combo.Add(tblblockalarmstatustext);
                        break;
                    }
                }
                dataGridView1.ClearSelection();
                propertyGrid1.SelectedObject = null;
                updated = true;
            }
        }

        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.dataGridView1.Rows[e.RowIndex].Selected = true;
                this.rowIndex = e.RowIndex;
                this.dataGridView1.CurrentCell = this.dataGridView1.Rows[e.RowIndex].Cells[0];
                this.contextMenuStrip1.Show(this.dataGridView1, e.Location);
                contextMenuStrip1.Show(Cursor.Position);
            }




        }
    }
}
