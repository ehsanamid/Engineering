using DCS.DCSTables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DCS.DCSTables
{

#if EWSAPP
    public class POUObject
    {
        private string _pouName = "";

        [DisplayName("pou Name")]
        [Category("Column")]
        public string pouName
        {
            get
            {
                return _pouName;
            }
            set
            {
                _pouName = value;
            }
        }


        /// <remarks>SQL Type:System.String</remarks>
        private string _Description = "";

        [DisplayName("Description")]
        [Category("Column")]
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

        /// <remarks>SQL Type:DCS.POUTYPE</remarks>
        private DCS.POUTYPE _Type;

        [DisplayName("Type")]
        [Category("Column")]
        [ReadOnly(true)]
        public DCS.POUTYPE Type
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

        /// <remarks>SQL Type:DCS.PouLanguageType</remarks>
        private DCS.PouLanguageType _Language;

        [DisplayName("Language")]
        [Category("Column")]
        [ReadOnly(true)]
        public DCS.PouLanguageType Language
        {
            get
            {
                return _Language;
            }
            set
            {
                _Language = value;
            }
        }


        /// <remarks>SQL Type:DCS.POUEXECUTIONTYPE</remarks>
        private DCS.POUEXECUTIONTYPE _executiontype;

        [DisplayName("executiontype")]
        [Category("Column")]
        public DCS.POUEXECUTIONTYPE executiontype
        {
            get
            {
                return _executiontype;
            }
            set
            {
                _executiontype = value;
            }
        }

        /// <remarks>SQL Type:System.Int64</remarks>
        private long _triggerSignalID = -1;

        [DisplayName("trigger Signal ID")]
        [Category("Column")]
        public long triggerSignalID
        {
            get
            {
                return _triggerSignalID;
            }
            set
            {
                _triggerSignalID = value;
            }
        }
        public POUObject(tblPou tocopy)
        {
            pouName = tocopy.pouName;
            Description = tocopy.Description;
            Type = tocopy.Type;
            triggerSignalID = tocopy.triggerSignalID;
            executiontype = tocopy.executiontype;
            Language = tocopy.Language;
        }
    } 
#endif
}
