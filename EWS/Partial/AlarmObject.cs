//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DCS.TypeConverters;
using System.Drawing.Design;


namespace DCS.DCSTables
{

#if EWSAPP

    public class AlarmObject
    {
        //public AlarmObject( )
        //{

        //}
        public AlarmObject(tblAlarm tocopy)
        {
            AlarmGroups = new List<IAlarmGroup>();
            FillAlarmGroups();
            ID = tocopy.ID;
            VarNameID = tocopy.VarNameID;
            StatusBit = (AlarmStatusBit)tocopy.StatusBit;
            Type = (AlarmGroupType)tocopy.Type;
            //AlarmGroupID = tocopy.AlarmGroupID;

            this._IAlarmGroup = InitAlarmGroup(tocopy.AlarmGroupID);
            EnableTagID = tocopy.EnableTagID;
            EnableTagDirection = tocopy.EnableTagDirection;
            EnableTagDelayOn = tocopy.EnableTagDelayOn;
            EnableTagDirection = tocopy.EnableTagDirection;
            EnableTagDelayOn = tocopy.EnableTagDelayOn;
            EnableTagDealyOff = tocopy.EnableTagDealyOff;
            DelayOn = tocopy.DelayOn;
            DelayOff = tocopy.DelayOff;
            SourceAlarmTagID = tocopy.SourceAlarmTagID;
            FirstOutGroupID = tocopy.FirstOutGroupID;
            hysteresis = tocopy.hysteresis;
            UpperLevelGroupID = tocopy.UpperLevelGroupID;
        }

        public AlarmObject()
        {
            AlarmGroups = new List<IAlarmGroup>();
            FillAlarmGroups();
            foreach (tblAlarmGroup tblalarmgroup in tblSolution.m_tblSolution().m_tblAlarmGroupCollection)
            {
                if (tblalarmgroup.Name == "Low")
                {
                    this._IAlarmGroup = InitAlarmGroup(tblalarmgroup.ID);
                    break;
                }
            }


        }

        public bool removed = false;
        // define a custom UI type editor so we can display our list of benchmark
        [DisplayName("Alarm Group")]
        [Category("Advance")]
        [Editor(typeof(AlarmGroupTypeEditor), typeof(UITypeEditor))]
        public IAlarmGroup _IAlarmGroup { get; set; }

        [Browsable(false)] // don't show in the property grid        
        public List<IAlarmGroup> AlarmGroups { get; private set; }

        public void FillAlarmGroups()
        {
            IAlarmGroup ialarmgroup;
            foreach (tblAlarmGroup tblalarmgroup in tblSolution.m_tblSolution().m_tblAlarmGroupCollection)
            {
                ialarmgroup = new IAlarmGroup(tblalarmgroup.ID, tblalarmgroup.Name);
                if (!this.AlarmGroups.Contains(ialarmgroup))
                {
                    this.AlarmGroups.Add(ialarmgroup);
                }
            }
        }

        public IAlarmGroup InitAlarmGroup(long _id)
        {
            //foreach (IAlarmGroup alarmgroup in AlarmGroups)
            foreach (tblAlarmGroup tblalarmgroup in tblSolution.m_tblSolution().m_tblAlarmGroupCollection)
            {
                if (tblalarmgroup.ID == _id)
                {
                    IAlarmGroup ialarmgroup = new IAlarmGroup();
                    ialarmgroup.ID = tblalarmgroup.ID;
                    ialarmgroup.Name = tblalarmgroup.Name;
                    return ialarmgroup;
                }
            }
            return null;
        }


        private long _ID = -1;

        [DisplayName("ID")]
        [Category("Primary Key")]
        [Browsable(false)]
        public long ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
            }
        }

        /// <remarks>SQL Type:System.Int64</remarks>
        private long _VarNameID;

        [DisplayName("Var Name ID")]
        [Category("Foreign Key")]
        [Browsable(false)]
        public long VarNameID
        {
            get
            {
                return _VarNameID;
            }
            set
            {
                _VarNameID = value;
            }
        }

        /// <remarks>SQL Type:System.Int64</remarks>
        private AlarmStatusBit _StatusBit;

        [DisplayName("Status")]
        [Category("Column")]
        [ReadOnly(true)]
        public AlarmStatusBit StatusBit
        {
            get
            {
                return _StatusBit;
            }
            set
            {
                _StatusBit = value;
                _StatusTxt = _StatusBit.ToString();
            }
        }

        /// <remarks>SQL Type:System.Int32</remarks>
        private AlarmGroupType _Type;

        [DisplayName("Type")]
        [Category("Basic")]
        [Browsable(false)]
        public AlarmGroupType Type
        {
            get
            {
                return _Type;
            }
            set
            {
                _Type = value;
            }
        }

        /*
        /// <remarks>SQL Type:System.Int64</remarks>
        private long _AlarmGroupID;

        [DisplayName("Alarm Group ID")]
        [Category("Column")]
        [Browsable(false)]
        public long AlarmGroupID
        {
            get
            {
                return _AlarmGroupID;
            }
            set
            {
                _AlarmGroupID = value;
            }
        }
        */
        /// <remarks>SQL Type:System.Int64</remarks>
        private long _EnableTagID;

        [DisplayName("Enable Tag ID")]
        [Category("Column")]
        [Browsable(false)]
        public long EnableTagID
        {
            get
            {
                return _EnableTagID;
            }
            set
            {
                _EnableTagID = value;
            }
        }

        /// <remarks>SQL Type:System.Boolean</remarks>
        private bool _EnableTagDirection;

        [DisplayName("Enable Tag Direction")]
        [Category("Advance")]
        public bool EnableTagDirection
        {
            get
            {
                return _EnableTagDirection;
            }
            set
            {
                _EnableTagDirection = value;
            }
        }

        /// <remarks>SQL Type:System.Int32</remarks>
        private int _EnableTagDelayOn;

        [DisplayName("Enable Tag Delay On sec")]
        [Category("Suppression")]
        public int EnableTagDelayOn
        {
            get
            {
                return _EnableTagDelayOn;
            }
            set
            {
                _EnableTagDelayOn = value;
            }
        }

        /// <remarks>SQL Type:System.Int32</remarks>
        private int _EnableTagDealyOff;

        [DisplayName("Enable Tag Dealy Off sec")]
        [Category("Suppression")]
        public int EnableTagDealyOff
        {
            get
            {
                return _EnableTagDealyOff;
            }
            set
            {
                _EnableTagDealyOff = value;
            }
        }

        /// <remarks>SQL Type:System.Int32</remarks>
        private int _DelayOn;

        [DisplayName("Delay On sec")]
        [Category("Basic")]
        public int DelayOn
        {
            get
            {
                return _DelayOn;
            }
            set
            {
                _DelayOn = value;
            }
        }

        /// <remarks>SQL Type:System.Int32</remarks>
        private int _DelayOff;

        [DisplayName("Delay Off sec")]
        [Category("Basic")]
        public int DelayOff
        {
            get
            {
                return _DelayOff;
            }
            set
            {
                _DelayOff = value;
            }
        }

        /// <remarks>SQL Type:System.Int64</remarks>
        private long _SourceAlarmTagID;

        [DisplayName("Source Alarm Tag ID")]
        [Category("Column")]
        [Browsable(false)]
        public long SourceAlarmTagID
        {
            get
            {
                return _SourceAlarmTagID;
            }
            set
            {
                _SourceAlarmTagID = value;
            }
        }

        /// <remarks>SQL Type:System.Int64</remarks>
        private long _FirstOutGroupID;

        [DisplayName("First Out Group ID")]
        [Category("Column")]
        [Browsable(false)]
        public long FirstOutGroupID
        {
            get
            {
                return _FirstOutGroupID;
            }
            set
            {
                _FirstOutGroupID = value;
            }
        }

        /// <remarks>SQL Type:System.Single</remarks>
        private float _hysteresis;

        [DisplayName("hysteresis")]
        [Category("Basic")]
        public float hysteresis
        {
            get
            {
                return _hysteresis;
            }
            set
            {
                _hysteresis = value;
            }
        }

        /// <remarks>SQL Type:System.Int64</remarks>
        private long _UpperLevelGroupID;

        [DisplayName("Upper Level Group ID")]
        [Category("Column")]
        [Browsable(false)]
        public long UpperLevelGroupID
        {
            get
            {
                return _UpperLevelGroupID;
            }
            set
            {
                _UpperLevelGroupID = value;
            }
        }


        private string _StatusTxt = "";

        [DisplayName("State")]
        [Category("Basic")]
        [Browsable(false)]
        public string StatusTxt
        {
            get
            {
                return _StatusTxt;
            }
            set
            {
                _StatusTxt = value;
                _StatusBit = (AlarmStatusBit)Enum.Parse(typeof(AlarmStatusBit), _StatusTxt);
            }
        }




        //private string _AlarmGroupName = "";

        //[DisplayName("Alarm Group ")]
        //[Category("Advance")]
        //public string AlarmGroupName
        //{
        //    get
        //    {
        //        return _AlarmGroupName;
        //    }
        //    set
        //    {
        //        _AlarmGroupName = value;
        //    }
        //}



        private string _EnableTagName = "";

        [DisplayName("Enable Tag ")]
        [Category("Suppression")]
        public string EnableTagName
        {
            get
            {
                return _EnableTagName;
            }
            set
            {
                _EnableTagName = value;
            }
        }


        /// <remarks>SQL Type:System.Int64</remarks>
        private string _SourceAlarmTagName = "";

        [DisplayName("Source Alarm Tag ID")]
        [Category("Advance")]
        public string SourceAlarmTagName
        {
            get
            {
                return _SourceAlarmTagName;
            }
            set
            {
                _SourceAlarmTagName = value;
            }
        }

        /// <remarks>SQL Type:System.Int64</remarks>
        private string _FirstOutGroupName = "";

        [DisplayName("First Out Group")]
        [Category("First Out")]
        public string FirstOutGroupName
        {
            get
            {
                return _FirstOutGroupName;
            }
            set
            {
                _FirstOutGroupName = value;
            }
        }

        /// <remarks>SQL Type:System.Int64</remarks>
        private string _UpperLevelGroupName = "";

        [DisplayName("Upper Level Group")]
        [Category("Roll Up")]
        public string UpperLevelGroupName
        {
            get
            {
                return _UpperLevelGroupName;
            }
            set
            {
                _UpperLevelGroupName = value;
            }
        }
    }

    public partial class AlarmCollection : System.Collections.CollectionBase
    {

        private VariableGrid _VarNameID_VariableGrid;

        [Description("Represents the foreign key object of the type VarNameID")]
        public VariableGrid m_VarNameID_VariableGrid
        {
            get
            {
                return _VarNameID_VariableGrid;
            }
            set
            {
                _VarNameID_VariableGrid = value;
            }
        }

        [Description("Constructor")]
        public AlarmCollection(VariableGrid _parent)
        {
            _VarNameID_VariableGrid = _parent;
        }


        [Description("Gets a  tblAlarm from the collection.")]
        public AlarmObject this[int index]
        {
            get
            {
                return ((AlarmObject)(List[index]));
            }
            set
            {
                List[index] = value;
            }
        }

        [Description("Gets a  tblAlarm from the collection.")]
        public AlarmObject Get(int index)
        {
            return ((AlarmObject)(List[index]));
        }

        [Description("Adds a new tblAlarm to the collection.")]
        public void Add(AlarmObject item)
        {
            List.Add(item);
        }

        [Description("Removes a tblAlarm from the collection.")]
        public void Remove(AlarmObject item)
        {
            List.Remove(item);
        }

        [Description("Inserts an tblAlarm into the collection at the specified index.")]
        public void Insert(int index, AlarmObject item)
        {
            List.Insert(index, item);
        }

        [Description("Returns the index value of the tblAlarm class in the collection.")]
        public int IndexOf(AlarmObject item)
        {
            return List.IndexOf(item);
        }

        [Description("Returns true if the tblAlarm class is present in the collection.")]
        public bool Contains(AlarmObject item)
        {
            return List.Contains(item);
        }
    }


#endif
}
