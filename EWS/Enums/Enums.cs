using System;
using System.Collections.Generic;
using System.Text;

namespace EWS_Ver6
{
    public enum Targets
    {
        Intel, V095, A15x
    }

    public enum PrinterType
    {
        None, Columns_80, Columns_120
    }
    
    public enum _REPORTFUNCTION : int
    {
        Count = 0,
        Average,
        Intgral,
        Min,
        Max,
        OnTime,
        OffTime,
        GetDate,
        GetRowNumber

    }
    public enum _reportLanguage : int
    {
        _LATIN = 0,
        _PERSIAN
    }

    public enum _PageOrientation
    {
        Portrait,
        Landscape
    }

    public enum _ReportPageSize
    {
        A4,
        A3
    }

    public enum _IMAGELIST : int
    {
        _IMAGELIST_0 = 0,
        _IMAGELIST_1,
        _IMAGELIST_2_USERS,
        _IMAGELIST_3,
        _IMAGELIST_4,
        _IMAGELIST_5_DELETEUSER,
        _IMAGELIST_6_DELETE,
        _IMAGELIST_7_DISPLAY,
        _IMAGELIST_8_PROJECT,
        _IMAGELIST_9,
        _IMAGELIST_10_,
        _IMAGELIST_11,
        _IMAGELIST_12,
        _IMAGELIST_13_BOARD,
        _IMAGELIST_14_IO,
        _IMAGELIST_15_CPU,
        _IMAGELIST_16_POINTS,
        _IMAGELIST_17_FOLDER,
        _IMAGELIST_18_STATS,
        _IMAGELIST_19_CHIPS12,
        _IMAGELIST_20_TOOLS,
        _IMAGELIST_21_NETWORK,
        _IMAGELIST_22_TASKLISTWINDOW,
        _IMAGELIST_23_REPORT,
        _IMAGELIST_24_REPORTPRINTPREVIEW,
        _IMAGELIST_25_REPORTFOLDER,
        _IMAGELIST_26_,
        _IMAGELIST_27_,
        _IMAGELIST_28_REPORTROOT
    }

    public enum ValueType
    {
        Digital = 1,
        Analog,
        Color,
        String,
        Point,
        BilinkingType,
        None
    }
}
