using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using DCS.DCSTables;
using System.IO;

namespace DCS.DCSTables
{
    

    public sealed class Global
    {
        /// <summary>
        /// This is an expensive resource.
        /// We need to only store it in one place.
        /// </summary>
        //private tblSolution _tblsolution;
        //public tblSolution m_tblSolution
        //{
        //    get
        //    {
        //        return _tblsolution;
        //    }
        //    set
        //    {
        //        _tblsolution = value;
        //    }
        //}

        /// <summary>
        /// Allocate ourselves.
        /// We have a private constructor, so no one else can.
        /// </summary>
        static readonly Global _ews = new Global();

        /// <summary>
        /// Access SiteStructure.Instance to get the singleton object.
        /// Then call methods on that instance.
        /// </summary>
        public static Global EWS
        {
            get { return _ews; }
        }

        /// <summary>
        /// This is a private constructor, meaning no outsiders have access.
        /// </summary>
        private Global()
        {
            //SQLiteConnectionStringBuilder connectionbuilder = new SQLiteConnectionStringBuilder();
            //connectionbuilder.DataSource = Common.DatabaseFullName;
            //Common.ConnectionString = connectionbuilder.ConnectionString;
           // _tblsolution = new tblSolution();

        }
        //public static bool IsSimpleType(int _vt)
        //{
        //    switch ((VarType)_vt)
        //    {
        //        case VarType.BOOL:
        //        case VarType.BYTE:
        //        case VarType.WORD:
        //        case VarType.DWORD:
        //        case VarType.LWORD:
        //        case VarType.SINT:
        //        case VarType.INT:
        //        case VarType.DINT:
        //        case VarType.LINT:
        //        case VarType.USINT:
        //        case VarType.UINT:
        //        case VarType.UDINT:
        //        case VarType.ULINT:
        //        case VarType.REAL:
        //        case VarType.LREAL:
        //        case VarType.DATE:
        //        case VarType.TOD:
        //        case VarType.DT:
        //        case VarType.STRING:
        //        case VarType.WSTRING:
        //        case VarType.TIME:
        //            return true;
        //    }
        //    return false;
        //}

        
    }
}
