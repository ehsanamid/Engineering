
using DCS.TypeConverters;
using DCS.DCSTables;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing.Design;
using System.Text;
using System.Windows.Forms;
using DCS;
namespace DCS.DCSTables
{



#if EWSAPP


    public class VariableGrid
    {
        bool modified = false;
        [Browsable(false)]
        public bool Modified
        {
            get
            {
                return modified;
            }
            set
            {
                modified = value;
            }
        }

        #region Class Memebers


        /// <remarks>SQL Type:System.String</remarks>
        private string _VarName;

        [DisplayName("Var Name")]
        [Category("Basic")]
        public string VarName
        {
            get
            {
                return _VarName;
            }
            set
            {
                _VarName = value;
            }
        }

        /// <remarks>SQL Type:System.Int64</remarks>
        private long _VarNameID;

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
        private long _pouID;

        [Browsable(false)]
        public long pouID
        {
            get
            {
                return _pouID;
            }
            set
            {
                _pouID = value;
                _pouname = tblSolution.m_tblSolution().GetPouFromID(_pouID).pouName;
            }
        }

        /// <remarks>SQL Type:System.String</remarks>
        private string _Description;

        [DisplayName("Description")]
        [Category("Basic")]
        public string Description
        {
            get
            {
                return _Description;
            }
            set
            {
                _Description = value;
            }
        }

        /// <remarks>SQL Type:System.String</remarks>
        private string _InitialVal;

        [DisplayName("Initial Val")]
        [Category("Basic")]
        public string InitialVal
        {
            get
            {
                return _InitialVal;
            }
            set
            {
                _InitialVal = value;
            }
        }

        /// <remarks>SQL Type:System.Int32</remarks>
        private int _Type;

        [Browsable(false)]
        public int Type
        {
            get
            {
                return _Type;
            }
            set
            {
                _Type = value;
                _TypeName = tblSolution.m_tblSolution().VarTypeStringList[_Type];
            }
        }


        /// <remarks>SQL Type:System.Int32</remarks>
        private int _Option;

        [DisplayName("Option")]
        [Category("Basic")]
        public VarOption Option
        {
            get
            {
                return (VarOption)_Option;
            }
            set
            {
                _Option = (int)value;
            }
        }



        /// <remarks>SQL Type:System.Int64</remarks>
        private long _PlantStructureID;

        [Browsable(false)]
        public long PlantStructureID
        {
            get
            {
                return _PlantStructureID;
            }
            set
            {
                _PlantStructureID = value;
                _PlantStructureName = tblSolution.m_tblSolution().AreaStringList[_PlantStructureID];
            }
        }





        /// <remarks>SQL Type:System.Int64</remarks>
        private long _DispalyID;

        [Browsable(false)]
        public long DispalyID
        {
            get
            {
                return _DispalyID;
            }
            set
            {
                _DispalyID = value;
            }
        }

        /// <remarks>SQL Type:System.Int64</remarks>
        private long _UsedPOUID;

        [Browsable(false)]
        public long UsedPOUID
        {
            get
            {
                return _UsedPOUID;
            }
            set
            {
                _UsedPOUID = value;
            }
        }

        /// <remarks>SQL Type:System.Boolean</remarks>
        private bool _ConnectedtoChannel;

        [DisplayName("Connectedto Channel")]
        [Category("Advance")]
        [ReadOnly(true)]
        public bool ConnectedtoChannel
        {
            get
            {
                return _ConnectedtoChannel;
            }
            set
            {
                _ConnectedtoChannel = value;
            }
        }

        /// <remarks>SQL Type:System.Int64</remarks>
        private long _ALB;

        [DisplayName("ALB")]
        [Category("Column")]
        [Browsable(false)]
        public long ALB
        {
            get
            {
                return _ALB;
            }
            set
            {
                _ALB = value;
            }
        }

        /// <remarks>SQL Type:System.Int64</remarks>
        private long _AEB;

        [DisplayName("AEB")]
        [Category("Column")]
        [Browsable(false)]
        public long AEB
        {
            get
            {
                return _AEB;
            }
            set
            {
                _AEB = value;
            }
        }

        /// <remarks>SQL Type:System.Int32</remarks>
        private int _SampleTime;

        [DisplayName("Sample Time")]
        [Category("Column")]
        public int SampleTime
        {
            get
            {
                return _SampleTime;
            }
            set
            {
                _SampleTime = value;
            }
        }

        /// <remarks>SQL Type:System.Boolean</remarks>
        private bool _RTT;

        [DisplayName("RTT")]
        [Category("Column")]
        public bool RTT
        {
            get
            {
                return _RTT;
            }
            set
            {
                _RTT = value;
            }
        }

        /// <remarks>SQL Type:System.Int32</remarks>
        private int _Interval;

        [DisplayName("Interval")]
        [Category("Column")]
        public int Interval
        {
            get
            {
                return _Interval;
            }
            set
            {
                _Interval = value;
            }
        }

        /// <remarks>SQL Type:System.Boolean</remarks>
        private bool _Archive;

        [DisplayName("Archive")]
        [Category("Column")]
        public bool Archive
        {
            get
            {
                return _Archive;
            }
            set
            {
                _Archive = value;
            }
        }

        /// <remarks>SQL Type:System.Int32</remarks>
        private int _ArchiveInterval;

        [DisplayName("Archive Interval")]
        [Category("Column")]
        public int ArchiveInterval
        {
            get
            {
                return _ArchiveInterval;
            }
            set
            {
                _ArchiveInterval = value;
            }
        }

        /// <remarks>SQL Type:System.Int64</remarks>
        private string _pouname;

        [DisplayName("pou Name")]
        [Category("Basic")]
        [ReadOnly(true)]
        public string pouName
        {
            get
            {
                return _pouname;
            }
            set
            {
                _pouname = value;
            }
        }


        /// <remarks>SQL Type:System.Int32</remarks>
        private string _TypeName;

        [DisplayName("Type")]
        [Category("Basic")]
        [ReadOnly(true)]
        public string TypeName
        {
            get
            {
                return _TypeName;
            }
            set
            {
                _TypeName = value;
            }
        }


        private string _PlantStructureName = "";
        [Editor(typeof(PlantstructureEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(TypeConverter))]  //[TypeConverter(typeof(ExpandableObjectConverter))]
        [Category("Advance")]
        public string PlantStructureName
        {
            get
            {
                return _PlantStructureName;
            }
            set
            {
                _PlantStructureName = value;
                _PlantStructureID = tblSolution.m_tblSolution().AreaLongList[_PlantStructureName];
            }
        }

        private AlarmCollection _AlarmCollection;
        [DisplayName("Alarm Setting")]
        [Description("Alarm Collection Setting")]
        [Editor(typeof(AlarmCollectionTypeEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(AlarmCollectionTypeConverter))]  //[TypeConverter(typeof(ExpandableObjectConverter))]
        [Category("Advance")]
        public AlarmCollection m_AlarmCollection
        {
            get
            {
                if (_AlarmCollection == null)
                {
                    _AlarmCollection = new AlarmCollection(this);
                }
                return _AlarmCollection;
            }
            set
            {
                _AlarmCollection = value;
            }
        }

        #endregion

        public VariableGrid(tblVariable tocopy)
        {
            try
            {
                this.VarName = tocopy.VarName;
                this.VarNameID = tocopy.VarNameID;
                this.pouID = tocopy.pouID;
                this.Description = tocopy.Description;
                this.InitialVal = tocopy.InitialVal;
                this.Type = tocopy.Type;
                this.Option = (VarOption)tocopy.Option;
                this.PlantStructureID = tocopy.PlantStructureID;
                this.DispalyID = tocopy.DispalyID;
                this.AEB = tocopy.AEB;
                this.ALB = tocopy.ALB;
                this.SampleTime = tocopy.SampleTime;
                this.RTT = tocopy.RTT;
                this.Interval = tocopy.Interval;
                this.Archive = tocopy.Archive;
                this.ArchiveInterval = tocopy.ArchiveInterval;

                foreach (tblAlarm tblalarm in tocopy.m_tblAlarmCollection)
                {
                    AlarmObject alarmobject = new AlarmObject(tblalarm);
                    this.m_AlarmCollection.Add(alarmobject);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }



        public VariableGrid(VariableGrid tocopy)
        {
            this.VarNameID = tocopy.VarNameID;
            this.Type = tocopy.Type;
            this.ConnectedtoChannel = tocopy.ConnectedtoChannel;
            this.AEB = tocopy.AEB;
            this.ALB = tocopy.ALB;
            this.SampleTime = tocopy.SampleTime;
            this.RTT = tocopy.RTT;
            this.Interval = tocopy.Interval;
            this.Archive = tocopy.Archive;
            this.ArchiveInterval = tocopy.ArchiveInterval;
            foreach (AlarmObject alarmobject in tocopy.m_AlarmCollection)
            {
                AlarmObject _alarmobject = new AlarmObject();
                //_alarmobject.StatusBit = alarmobject.StatusBit;

                _alarmobject.ID = alarmobject.ID;
                _alarmobject.VarNameID = alarmobject.VarNameID;
                _alarmobject.StatusBit = (AlarmStatusBit)alarmobject.StatusBit;
                _alarmobject.Type = (AlarmGroupType)alarmobject.Type;
                _alarmobject._IAlarmGroup = _alarmobject.InitAlarmGroup(alarmobject._IAlarmGroup.ID);
                //_alarmobject._IAlarmGroup = alarmobject._IAlarmGroup;
                _alarmobject.EnableTagID = alarmobject.EnableTagID;
                _alarmobject.EnableTagDirection = alarmobject.EnableTagDirection;
                _alarmobject.EnableTagDelayOn = alarmobject.EnableTagDelayOn;
                _alarmobject.EnableTagDealyOff = alarmobject.EnableTagDealyOff;
                _alarmobject.DelayOn = alarmobject.DelayOn;
                _alarmobject.DelayOff = alarmobject.DelayOff;
                _alarmobject.SourceAlarmTagID = alarmobject.SourceAlarmTagID;
                _alarmobject.FirstOutGroupID = alarmobject.FirstOutGroupID;
                _alarmobject.hysteresis = alarmobject.hysteresis;
                _alarmobject.UpperLevelGroupID = alarmobject.UpperLevelGroupID;

                this.m_AlarmCollection.Add(_alarmobject);

            }


        }



    }

    public class BoolVariableGrid : VariableGrid
    {
        bool loaded = false;
        [Browsable(false)]
        public bool Loaded
        {
            get
            {
                return loaded;
            }
            set
            {
                loaded = value;
            }
        }
        /// <remarks>SQL Type:System.Int64</remarks>


        /// <remarks>SQL Type:System.String</remarks>
        private string _Text0;

        [DisplayName("Text 0")]
        [Category("Boolean")]
        public string Text0
        {
            get
            {
                return _Text0;
            }
            set
            {
                _Text0 = value;
            }
        }

        /// <remarks>SQL Type:System.String</remarks>
        private string _Text1;

        [DisplayName("Text 1")]
        [Category("Boolean")]
        public string Text1
        {
            get
            {
                return _Text1;
            }
            set
            {
                _Text1 = value;
            }
        }

        public BoolVariableGrid(tblVariable tocopy)
            : base(tocopy)
        {
            try
            {
                tblBOOL tblbool = new tblBOOL();
                tblbool.VarNameID = this.VarNameID;
                tblbool.SelectVarID();
                this.Text0 = tblbool.Text0;
                this.Text1 = tblbool.Text1;
                Loaded = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }

    public class RealVariableGrid : VariableGrid
    {

        bool loaded = false;
        [Browsable(false)]
        public bool Loaded
        {
            get
            {
                return loaded;
            }
            set
            {
                loaded = value;
            }
        }


        /// <remarks>SQL Type:System.String</remarks>
        private string _UNI;

        [DisplayName("Unit")]
        [Description("Instrument Unit")]
        [Category("REAL")]
        public string UNI
        {
            get
            {
                return _UNI;
            }
            set
            {
                _UNI = value;
            }
        }

        /// <remarks>SQL Type:System.Int32</remarks>
        private int _FOR;

        [DisplayName("Format")]
        [Description("dispaly Format")]
        [Category("REAL")]
        public int FOR
        {
            get
            {
                return _FOR;
            }
            set
            {
                _FOR = value;
            }
        }

        /// <remarks>SQL Type:System.Single</remarks>
        private float _IRL;

        [DisplayName("IRL")]
        [Description("Instrument Range Low")]
        [Category("REAL")]
        public float IRL
        {
            get
            {
                return _IRL;
            }
            set
            {
                _IRL = value;
            }
        }

        /// <remarks>SQL Type:System.Single</remarks>
        private float _IRH;

        [DisplayName("IRH")]
        [Description("Instrument Range High")]
        [Category("REAL")]
        public float IRH
        {
            get
            {
                return _IRH;
            }
            set
            {
                _IRH = value;
            }
        }

        /// <remarks>SQL Type:System.Single</remarks>
        private float _LL;

        [DisplayName("LL")]
        [Description("Low Low Level")]
        [Category("REAL")]
        public float LL
        {
            get
            {
                return _LL;
            }
            set
            {
                _LL = value;
            }
        }

        /// <remarks>SQL Type:System.Single</remarks>
        private float _HH;

        [DisplayName("HH")]
        [Description("High High Level")]
        [Category("REAL")]
        public float HH
        {
            get
            {
                return _HH;
            }
            set
            {
                _HH = value;
            }
        }

        /// <remarks>SQL Type:System.Single</remarks>
        private float _L;

        [DisplayName("L")]
        [Description("Low Level")]
        [Category("REAL")]
        public float L
        {
            get
            {
                return _L;
            }
            set
            {
                _L = value;
            }
        }

        /// <remarks>SQL Type:System.Single</remarks>
        private float _H;

        [DisplayName("H")]
        [Description("High Level")]
        [Category("REAL")]
        public float H
        {
            get
            {
                return _H;
            }
            set
            {
                _H = value;
            }
        }


        public RealVariableGrid(tblVariable tocopy)
            : base(tocopy)
        {
            try
            {
                tblREAL tblreal = new tblREAL();
                tblreal.VarNameID = this.VarNameID;
                tblreal.SelectVarID();
                this.UNI = tblreal.UNI;
                this.FOR = tblreal.FOR;
                this.IRL = tblreal.IRL;
                this.IRH = tblreal.IRH;
                this.LL = tblreal.LL;
                this.HH = tblreal.HH;
                this.L = tblreal.L;
                this.H = tblreal.H;
                Loaded = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    } 
#endif
}
