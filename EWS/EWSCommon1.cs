using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Data.SQLite;
using DCS.DCSTables;
using System.Reflection;


namespace DCS
{


    

    public enum ItemType : byte
    {
        UNKNOWN = 0,
        VARIABLE,
        BOARD,
        FCS,
        HMI,
    }
    public enum Token_Type : byte
    {
        Token_Unknown = 1,

        Token_Number,
        Token_Operator,
        Token_Variable,
        Token_Constant,
        //Token_Value,
        Token_String,
        Token_TempValue,
        Token_Comma,
        Token_LeftParenthisis,
        Token_RightParenthisis,
        Token_TempString,
        Token_Function,
        Token_FunctionEX,
        Token_FunctionInstance,
        Token_FunctionEXInstance,
        Token_FunctionBlockInstance,
        Token_Semicolumn,
        Token_UserDefinedFunction,
        Token_FBDPin,
        Token_FBID,
    }

    public enum FunctionGroup : int
    {
        TYPE_CONVERSION = 0,
        NUMERICAL,
        ARITHMETIC,
        BITWISE,
        CHARACTER_STRING,
        TIME,
        BIT_SHIFT,
        COMPARISON,
        SELECTION,
        ADDITIONAL,
        FLIP_FLOP,
        EDGE_DETECTION,
        COUNTER,
        TIMER,
        USER_DEFINED,
        KTC_DEFINED,
        BASIC_TYPES,
    }



    public enum VarType : uint//: unsigned int
    {

        UNKNOWN = 0, // Not defined
        BOOL = 0x00000001,//Boolean 
        BYTE = 0x00000002,//Bit string of length 8 
        WORD = 0x00000004,//Bit string of length 16 
        DWORD = 0x00000008,//Bit string of length 32 
        LWORD = 0x00000010,//Bit string of length 64 
        SINT = 0x00000020,//Short integer 
        INT = 0x00000040,//Integer 
        DINT = 0x00000080,//Double integer 
        LINT = 0x00000100,//Long integer 
        USINT = 0x00000200,//Unsigned short integer 
        UINT = 0x00000400,//Unsigned integer 
        UDINT = 0x00000800,//Unsigned double integer 
        ULINT = 0x00001000,//Unsigned long integer 
        REAL = 0x00002000,//Real numbers 
        LREAL = 0x00004000,//Long real numbers 
        DATE = 0x00008000,// calendar date 
        TOD = 0x00010000,//clock time
        DT = 0x00020000,//time and date
        STRING = 0x00040000,//Variable-length character string 
        WSTRING = 0x00080000,//Variable-length character string 
        TIME = 0x00100000,//Duration 
        ANY = 0x7FFFFFFF,//ANY_ELEMENTARY,ANY_DERIVED
        ANY_ELEMENTARY = 0x001BFFFF,//ANY_MAGNITUDE,ANY_BIT,ANY_DATE
        ANY_MAGNITUDE = 0x00107FE0,//ANY_NUM - TIME
        ANY_BIT = 0x0000001F,//LWORD, DWORD, WORD, BYTE, BOOL
        ANY_NUM = 0x00007FE0,//ANY_INT,ANY_REAL
        ANY_DATE = 0x00038000,//DATE, TOD, DT
        ANY_INT = 0x00001FE0,//LINT, DINT, INT, SINT, ULINT, UDINT, UINT, USINT
        ANY_REAL = 0x00006000,// LREAL, REAL
        ANY_FUNCTION = 0x00200000,// Functions
        ANY_USERFUN = 0x00300000,// User Defined Functions
        ANY_DERIVED = 0x7FE00000,//
        CTD = 0x7FE00000 + 1,
        CTU = 0x7FE00000 + 2,
        CTUD = 0x7FE00000 + 3,
        DERIVATIVE = 0x7FE00000 + 4,
        F_TRIG = 0x7FE00000 + 5,
        HYSTERESIS = 0x7FE00000 + 6,
        INTEGRAL = 0x7FE00000 + 7,
        PID = 0x7FE00000 + 8,
        R_TRIG = 0x7FE00000 + 9,
        RS = 0x7FE00000 + 10,
        RTC = 0x7FE00000 + 11,
        SEMA = 0x7FE00000 + 12,
        SR = 0x7FE00000 + 13,
        TOFF = 0x7FE00000 + 14,
        TON = 0x7FE00000 + 15,
        TP = 0x7FE00000 + 16,
        RAMP = 0x7FE00000 + 17,
        AVERAGE = 0x7FE00000 + 18,
        BLINK = 0x7FE00000 + 19,
        LIM_ALR = 0x7FE00000 + 21,
        PIDCAS = 0x7FE00000 + 29,
        PIDOVR = 0x7FE00000 + 30,
        SPLIT = 0x7FE00000 + 31,
        ALARMANC = 0x7FE00000 + 32,
        CMP = 0x7FE00000 + 33,
        LAG = 0x7FE00000 + 34,
        SELPRI = 0x7FE00000 + 35,
        SELREAD = 0x7FE00000 + 36,
        SETPRI = 0x7FE00000 + 37,
        SIG_GEN = 0x7FE00000 + 38,
        STACKIN = 0x7FE00000 + 39,
        SWDOUT = 0x7FE00000 + 40,
        SWSOUT = 0x7FE00000 + 41,
        TPLS = 0x7FE00000 + 42,
        TSTP = 0x7FE00000 + 43,
        WKHOUR = 0x7FE00000 + 44,
        TOTALIZER = 0x7FE00000 + 45,
        USERDEFUNED = 0x7FE00000 + 90,

    }
    // 1 variable  2   function  3   extensible function   4 function block
    public enum FBDBlockType
    {
        Variable = 1,
        Function,
        FunctionEX,
        FunctionBlock,
    }

    public enum VarClass //: unsigned char
    {
        Input = 0x0001,	//Input Variable
        Output = 0x0002,	    //Output Variable
        InOut = 0x0004,	    //Reference Variable
        External = 0x0008,	    //External Variable 
        Local = 0x0010,	    //Local Variable not accessable outside of Function or Function block
        Global = 0x0020,	    //Global Variable
        Access = 0x0040,     // Access Variable
        Internal = 0x0080,	    //Internal Variable which are same as input,output or inout pins but does not show in FBD diagram
        Child = 0x0100,	    //All variables related to Instance of Function or Functionblock
        FunctionInstanse = 0x0200,
        LinkInstance = 0x0400,
        FBInstance = 0x0800,
        UDFBInstance = 0x1000,
        Count
    }

    public enum StationType //: unsigned char
    {
        LCU = 0x00000000,	// LCU Station
        OWS = 0x00008000,    // OWS Station
        DUMMY = -1,
    }

    public enum ShowVariableMode
    {
        Normal,
        Compact,
        WideLeft,
        WideRight,
    }

    public enum VarOption
    {
        NonRetain = 0,	//Non Retain Variable
        Retain,	    //Retain Variable
    }

    

    public enum OPERATION_TYPE
    {
        SIMPLE_OPERATION = 1,
        IF_OPERATION,
        IF_ELSE_OPERATION,

    }

    public enum PROGRAM_LANGUAGE //: unsigned char
    {
        ENUM_PROGRAM_LANGUAGE_UNKNOWN = 0,
        ENUM_PROGRAM_LANGUAGE_IL,
        ENUM_PROGRAM_LANGUAGE_FBD,
        ENUM_PROGRAM_LANGUAGE_LD,
        ENUM_PROGRAM_LANGUAGE_ST,
        ENUM_PROGRAM_LANGUAGE_SFC,
        ENUM_PROGRAM_LANGUAGE_C

    }

    public enum PROGRAM_CYCLETIME_GROUP //: unsigned char
    {
        VERYSLOW = 1,
        SLOW,
        MEDIUM,
        FAST,
        VERYFAST,


    }
    public enum POUTYPE //: unsigned char
    {
        PROGRAM = 0,
        FUNCTION,
        FUNCTIONBLOCK,
        HMIEXPRESSION,
    }

    

    public enum POUEXECUTIONTYPE //: unsigned char
    {
        INITIALIZE = 0,
        FAST,
        NORMAL,
        SLOW,
        TRIGGER,
        UDFunction,
        UDFunctionBlock,
    }


    
    public enum STATIC_OBJ_TYPE : short
    {
        ID_BITMAP = 0,
        ID_ELLIPS = 1,
        ID_CHORD = 2,
        ID_PIE = 3,
        ID_POLYGON = 4,
        ID_POLYLINE = 5,
        ID_RECT = 6,
        ID_LINE = 7,
        ID_ARC = 8,
        ID_TEXT = 9,
        ID_BARGRAPH = 10,
        ID_ROUNDRECT = 11,
        ID_ANATEXT = 12,
        ID_EDITBOX = 13,
        ID_CURVE = 14,
        ID_BUTTON = 15,
        ID_DIGTEXT = 16,
        ID_FBDBox = 17,
        ID_FBDWire = 18,
        ID_FBDBoxVariable = 19,
        ID_FBDBoxFunction = 20,
        ID_FBDBoxFunctionEx = 21,
        ID_FBDBoxFunctionBlock = 22,
        ID_FBDBoxConstant = 23,
        ID_FBDBoxLabel = 24,
        ID_COMMENT = 25,
        ID_Pointer = 26,
        ID_Triangle = 27,
        ID_Pie = 28,
        ID_Radibotton = 29,
        ID_Combobox =30,
        ID_Trend = 31,
        ID_Guage = 32,
        ID_Block = 33,
        ID_Editbox = 34,
        ID_Checkbox = 35,
        ID_Initial_Step,
        ID_Step,
        ID_Transition,
        ID_AND,
        ID_AND_UCorner,
        ID_AND_DCorner,
        ID_OR,
        ID_OR_UCorner,
        ID_OR_DCorner,
        ID_Jump,
        ID_Comment,

    }

    public enum LAYERS
    {
        [Description("Layer 1")]
        Layer1 = 0,
        [Description("Layer 2")]
        Layer2,
        [Description("Layer 3")]
        Layer3,
        [Description("Layer 4")]
        Layer4,
        [Description("Layer 5")]
        Layer5,
        [Description("Layer 6")]
        Layer6 ,
        [Description("Layer 7")]
        Layer7,
        [Description("Layer 8")]
        Layer8,
    }
    public enum FillTypePatern
    {
        [Description("Transparent")]
        Transparent,
        [Description("Filled")]
        Solid,
        [Description("Filled Hatch")]
        Hatched,
        [Description("Gradient Fill")]
        Gradient
    }

    public enum FillGradientType
    {
        Left2Right,
        Right2Left,
        Top2Buttom,
        Buttom2Top,
        ToVCenter,
        FromVCenter,
        ToHCenter,
        FromHCenter,
        NW2SE,
        SE2NW,
        SW2NE,
        NE2SW,
    };

    public enum TextFormat
    {
        [Description("xxx")]
        Zero,
        [Description("xxx.x")]
        One,
        [Description("xxx.xx")]
        Two,
        [Description("xxx.xxx")]
        three,
        [Description("xxx.xxxx")]
        Four,
        [Description("xxx.xxxxx")]
        Five,
        [Description("xxx.xxxxxx")]
        Six,
        [Description("xxx.xxxxxxx")]
        Seven,
        [Description("hh:mm:ss")]
        Hour,
        [Description("dd-mm-yy")]
        Date
    }

    public enum TextOrientation
    {
        [Description("0")]
        D0 = 0,
        [Description("90")]
        D90 = 90,
        [Description("180")]
        D180 = 180,
        [Description("270")]
        D270 = 270
    }

    public enum TextAlignment
    {
        [Description("Left Top")]
        LeftTop,
        [Description("Left Center")]
        LeftCenter,
        [Description("Left Bottom")]
        LeftBottom,
        [Description("Center Top")]
        CenterTop,
        [Description("Center Center")]
        CenterCenter,
        [Description("Center Bottom")]
        CenterBottom,
        [Description("Right Top")]
        RightTop,
        [Description("Right Center")]
        RightCenter,
        [Description("Right Bottom")]
        RightBottom,
    }

    //public enum Token_Type //: char
    //{
    //    Token_Unknown = 1,
    //    Token_Function,
    //    Token_Number,
    //    Token_Operator,
    //    Token_Variable,
    //    Token_Constant,
    //    //Token_Value,
    //    Token_String,
    //    Token_TempValue,
    //    Token_Comma,
    //    Token_LeftParenthisis,
    //    Token_RightParenthisis,
    //    Token_TempString,
    //    Token_FBInstance,
    //    Token_Semicolumn,
    //    Token_UserDefinedFunction,


    //}

    public enum Targets
    {
        Intel, V095, A15x
    }

    public enum PrinterType
    {
        None, Columns_80, Columns_120
    }

    public enum REPORTFUNCTION : int
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
    public enum reportLanguage : int
    {
        LATIN = 0,
        PERSIAN
    }

    public enum PageOrientation
    {
        Portrait,
        Landscape
    }

    public enum ReportPageSize
    {
        A4,
        A3
    }



    public enum PROJECT_IMAGELIST : int
    {
        UNKNOWN = 0,
        AREA,
        BLOCK,
        CONTROLLER,
        DISPLAY,
        DOMAIN,
        IOCARD,
        IORACK,
        PCIOCARD,
        PROGRAM,
        SOLUTION,
        PROJECTCONTROL,
        UNIT,
        USERGROUP,
        USER,
        REPORT,
        FOLDER,

    }

    public enum PROGRAM_IMAGELIST : int
    {
        UNKNOWN = 0,
        IL,
        FBD,
        LD,
        ST,
        SFC,
        C

    }

    public enum TREE_NODE_TYPE : int
    {
        ROOT = 0,
        PROJECT,
        DOMAINArea,
        CONTROLLER,
        IORACK,
        IOBOARD,
        PROGRAM,
        PROGRAMS,
        REPORT,
        DISPALYGROUP,
        DISPLAY,
        BLOCKGROUP,
        BLOCK,
        USERGROUP,
        USER,
        DATATYPES,
        FUNCTIONS,
        FUNCTIONBLOCKS,
        DATATYPE,
        FUNCTION,
        FUNCTIONBLOCK,
        RESOURCES,
        RESOURCE,
        ST,
        FBD,
        SFC,
        Root,
        Area,
        Zone,
        Unit,
        Package,
        LCU,
        OWS,
        VARIABLE,
        GENERAL,
        ALARM_GROUP,
        MEASUERMENT_UNITS,
        FCS_Group,
        ObjectFollder,
        PropertyFolder,
    }


    public enum CONTROLLER_TYPE : int
    {
        CPU_TYPE_A15 = 0x0001,
        CPU_TYPE_V095 = 0x0002,
        CPU_TYPE_Intel = 0x0004,
        CPU_TYPE_EPPC405 = 0x0008,
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

    public enum PouLanguageType : int
    {
        Unknown = 0,
        IL,
        FBD,
        LD,
        ST,
        SFC,
        C
    }


    public enum TABPAGETYPE
    {
        [Description("Process Display Page")]
        DISPLAY = 0,	//Process Display Page
        [Description("Block for Process Display")]
        BLOCK,	        //Block for Process Display
        [Description("Function Block page")]
        FBD,	        //Function Block Language page
        [Description("Structured Text page")]
        ST,	            //Structured Text Language page
        [Description("Sequential Function Chart page")]
        SFC,	        //Sequential Function Chart Language page
        [Description("IL Language page")]
        IL,	            //IL Language page
        [Description("LD Chart page")]
        LD,	        //LD Chart Language page
        [Description("Report Page")]
        REPORT,	        //Report Page
        [Description("Variable list")]
        VARIABLE,         // Variable list
        [Description("Alarm Group")]
        ALARM_GROUP,      // Alarm Group
        [Description("IO Board")]
        BOARD,            // IO Board
        [Description("Modbus Salve")]
        MODBUS_SALVE,     // Modbus Salve
        [Description("User defined Function")]
        UD_FUNCTION,     // User defined Function
        [Description("User defined Function Block")]
        UD_FUNCTIONBLOCK,     // User defined Function Block
        [Description("User defined Function ST")]
        UD_ST_FUNCTION,     // User defined Function ST
        [Description("User defined Function Block ST")]
        UD_ST_FUNCTIONBLOCK,     // User defined Function Block ST
        [Description("Plant Structure")]
        PLANT_STRUCTURE,     // Plant Structure
    }
    public enum BOARDTYPES : int
    {
        UNKNOWN = 0,
        TYPE_DI,
        TYPE_DO,
        TYPE_DIO,
        TYPE_AI,
        TYPE_AO,
        TYPE_AIO,
        TYPE_TEMP,
    }

    public enum CHANNELTYPES : int
    {
        UNKNOWN = 0,
        TYPE_DI,
        TYPE_DO,
        TYPE_AI,
        TYPE_AO,
        TYPE_TEMP,
    }

    //public enum VarOption : int
    //{
    //    NonRetain = 0,	//Non Retain Variable
    //    Retain,	    //Retain Variable
    //}

    public enum ProcessDisplaytreeElementType : int
    {
        Domain = 0,
        Display,
        Folder,
    }

   public enum LogLevel
    {
        [Description("Minimum Log")]
        MIN = 0,
        [Description("Medium Log")]
        MED = 1,
        [Description("Maximum Log")]
        MAX = 2,
    }

    public enum MODE
    {
        [Description("Mode Unknown")]
        UNK = 0x00000000,
        [Description("Mode Manual")]
        MAN = 0x00000001,
        [Description("Mode Automatic")]
        AUT = 0x00000002,
        [Description("Mode Cascade")]
        CAS = 0x00000004,
        [Description("Mode Track")]
        TRK = 0x0008,	// Track 
        [Description("Mode Master Direct ")]
        MDR = 0x0010,	// Master Direct 
        [Description("Mode INI")]
        INI = 0x0020,
    }

    public enum BlockMode : uint//: unsigned char
    {
        MAN = 0x0001,    // Manual 
        AUT = 0x0002,	// Automatic 
        CAS = 0x0004,	// Cascade 
        TRK = 0x0008,	// Track 
        MDR = 0x0010,	// Master Direct 
        INI = 0x0020,
    }


    public enum BlockState //: unsigned char
    {
        [Description("RUN")]
        RUN = 0x00000001,
        [Description("STOP")]
        STP = 0x00000002,
        [Description("PAUSE")]
        PAS = 0x00000004,
        [Description("Time Out")]
        TOU = 0x00000008,
        [Description("SIM")]
        SIM = 0x00000010,
        [Description("Wait For Feedback")]
        WFF = 0x00000020,
        [Description("Lock variable")]
        LOK = 0x00010000,

    };
    public enum AlarmStatus
    {
		//[Description("Status No Alarm")]
        None = 0x00000000,
        [Description("Status Normal")]
        NR = 0x00000001,
        [Description("Status Abnormal")]
        AB = 0x00000002,
        [Description("Status Range High")]
        RHI = 0x00000004,
        [Description("Status Range Low")]
        RLO = 0x00000008,
        [Description("Status High High")]
        HH = 0x00000010,
        [Description("Status Low Low")]
        LL = 0x00000020,
        [Description("Status High")]
        Hi = 0x00000040,
        [Description("Status Low")]
        Li = 0x00000080,
        [Description("Positive Velocity")]
        VLP = 0x00000100,
        [Description("Negative Velocity")]
        VLN = 0x00000200,
        [Description("Positive Deviation")]
        DVP = 0x00000400,
        [Description("Negative Deviation")]
        DVN = 0x00000800,
        [Description("Output Disconnect")]
        ODC = 0x00001000,
        [Description("Input Disconnect")]
        IDC = 0x00002000,
        [Description("No Positive Feedback")]
        ASP = 0x00004000,
        [Description("No Negative Feedback")]
        ASN = 0x00008000,
        [Description("??? Error")]
        ABN = 0x00010000,
        [Description("General Error")]
        ERR = 0x00020000,
        [Description("Channel Error")]
        CHF = 0x00040000,
        [Description("Board Error")]
        BRF = 0x00080000,
        [Description("Node Error")]
        NEF = 0x00100000,
        [Description("Parity Error ")]
        PRT = 0x00200000,
        [Description("Communication Error")]
        COM = 0x00400000,

    }

    public enum AlarmStatusBit
    {
        // [Description("Status Normal")]
        NR_BIT = 0,
        // [Description("Status Abnormal")]
        AB_BIT = 1,
        // [Description("Status Range High")]
        RHI_BIT = 2,
        // [Description("Status Range Low")]
        RLO_BIT = 3,
        // [Description("Status High High")]
        HH_BIT = 4,
        // [Description("Status Low Low")]
        LL_BIT = 5,
        // [Description("Status High")]
        Hi_BIT = 6,
        // [Description("Status Low")]
        Lo_BIT = 7,
        // [Description("Positive Velocity")]
        VLP_BIT = 8,
        // [Description("Negative Velocity")]
        VLN_BIT = 9,
        // [Description("Positive Deviation")]
        DVP_BIT = 10,
        // [Description("Negative Deviation")]
        DVN_BIT = 11,
        // [Description("Output Disconnect")]
        ODC_BIT = 12,
        // [Description("Input Disconnect")]
        IDC_BIT = 13,
        // [Description("No Positive Feedback")]
        ASP_BIT = 14,
        // [Description("No Negative Feedback")]
        ASN_BIT = 15,
        // [Description("??? Error")]
        ABN_BIT = 16,
        // [Description("General Error")]
        ERR_BIT = 17,
        // [Description("Channel Error")]
        CHF_BIT = 18,
        // [Description("Board Error")]
        BRF_BIT = 19,
        // [Description("Node Error")]
        NEF_BIT = 20,
        // [Description("Parity Error ")]
        PRT_BIT = 21,
        // [Description("Communication Error")]
        COM_BIT = 22,

    }

     

    public enum AlarmGroupType
    {
        [Description("Event")]
        Event = 0,
        [Description("Self Acknowledge")]
        SelfAcknowledge = 1,
        [Description("Acknowledge on Set")]
        AcknowledgeOnSet = 2,
        [Description("Acknowledge on Set/Reset")]
        AcknowledgeOnSetReset = 3,
    }

    //public enum BlockState : uint//: unsigned char
    //{
    //    //[Description("RUN")]
    //    RUN = 0x00000001,
    //    //[Description("STOP")]
    //    STP = 0x00000002,
    //    //[Description("PAUSE")]
    //    PAS = 0x00000004,
    //    //[Description("Time Out")]
    //    TOU = 0x00000008,
    //    //[Description("SIM")]
    //    SIM = 0x00000010,
    //    //[Description("Wait For Feedback")]
    //    WFF = 0x00000020,
    //    //[Description("Lock Tag")]
    //    LOK = 0x00010000,
    //}

    public enum BlockStateBIT //: unsigned char
    {
        //[Description("RUN")]
        RUN = 0,
        //[Description("STOP")]
        STP = 1,
        //[Description("PAUSE")]
        PAS = 2,
        //[Description("Time Out")]
        TOU = 3,
        //[Description("SIM")]
        SIM = 4,
        //[Description("Wait For Feedback")]
        WFF = 5,
        //[Description("Lock variable")]
        LOK = 16,

    };

    public enum Prop_ANY
    {
        Mode_Property = 0,
        State_Property,
        ALS_Property,
        ALA_Property,
        ALB_Property,
        AEB_Property,
        OPN_Property,
        OPH_Property,
        OPM_Property,
        MNN_Property,
    };

    public enum Prop_BOOL
    {
        VAL_BOOL_Property = 10,
    };
    public enum Prop_BYTE
    {
        VAL_BYTE_Property = 10,
    };
    public enum Prop_DATE
    {
        VAL_DATE_Property = 10,
    };
    public enum Prop_DINT
    {
        VAL_DINT_Property = 10,
    };
    public enum Prop_DT
    {
        VAL_DT_Property = 10,
    };
    public enum Prop_DWORD
    {
        VAL_DWORD_Property = 10,
    };
    public enum Prop_INT
    {
        VAL_INT_Property = 10,
    };
    public enum Prop_LINT
    {
        VAL_LINT_Property = 10,
    };
    public enum Prop_LREAL
    {
        VAL_LREAL_Property = 10,
    };
    public enum Prop_LWORD
    {
        VAL_LWORD_Property = 10,
    };

    public enum Prop_REAL
    {
        VAL_REAL_Property = 10,
        RHI_REAL_Property = 11,
        RLO_REAL_Property = 12,
        HH_REAL_Property = 13,
        LL_REAL_Property = 14,
        HI_REAL_Property = 15,
        LO_REAL_Property = 16,
        VLP_REAL_Property = 17,
        VLN_REAL_Property = 18,
        DVP_REAL_Property = 19,
        DVN_REAL_Property = 20,
    };
    public enum Prop_SINT
    {
        VAL_SINT_Property = 10,
    };
    public enum Prop_STRING
    {
        VAL_STRING_Property = 10,
    };
    public enum Prop_TIME
    {
        VAL_TIME_Property = 10,
    };
    public enum Prop_TOD
    {
        VAL_TOD_Property = 10,
    };
    public enum Prop_UDINT
    {
        VAL_UDINT_Property = 10,
    };
    public enum Prop_UINT
    {
        VAL_UINT_Property = 10,
    };
    public enum Prop_ULINT
    {
        VAL_ULINT_Property = 10,
    };
    public enum Prop_USINT
    {
        VAL_USINT_Property = 10,
    };
    public enum Prop_WORD
    {
        VAL_WORD_Property = 10,
    };
    public enum Prop_WSTRING
    {
        VAL_WSTRING_Property = 10,
    };
    public enum Prop_ALARMANC
    {
        ALARM_ALARMANC_Property = 10,
        ACK_ALARMANC_Property = 11,
        RESET_ALARMANC_Property = 12,
        LT_ALARMANC_Property = 13,
        FASTBLINKING_ALARMANC_Property = 14,
        SLOWBLINKING_ALARMANC_Property = 15,
        Q_ALARMANC_Property = 16,
    };
    public enum Prop_CMP
    {
        VAL1_CMP_Property = 10,
        VAL2_CMP_Property = 11,
        LT_CMP_Property = 12,
        EQ_CMP_Property = 13,
        GT_CMP_Property = 14,
    };
    public enum Prop_CTD
    {
        CD_CTD_Property = 10,
        LD_CTD_Property = 11,
        PV_CTD_Property = 12,
        Q_CTD_Property = 13,
        CV_CTD_Property = 14,
    };
    public enum Prop_CTU
    {
        CU_CTU_Property = 10,
        R_CTU_Property = 11,
        PV_CTU_Property = 12,
        Q_CTU_Property = 13,
        CV_CTU_Property = 14,
    };
    public enum Prop_CTUD
    {
        CU_CTUD_Property = 10,
        CD_CTUD_Property = 11,
        R_CTUD_Property = 12,
        LD_CTUD_Property = 13,
        PV_CTUD_Property = 14,
        QU_CTUD_Property = 15,
        QD_CTUD_Property = 16,
        CV_CTUD_Property = 17,
    };
    public enum Prop_DERIVATIVE
    {
        RUN_DERIVATIVE_Property = 10,
        XIN_DERIVATIVE_Property = 11,
        CYCLE_DERIVATIVE_Property = 12,
        XOUT_DERIVATIVE_Property = 13,
    };
    public enum Prop_F_TRIG
    {
        CLK_F_TRIG_Property = 10,
        Q_F_TRIG_Property = 11,
    };
    public enum Prop_HYSTERESIS
    {
        XIN1_HYSTERESIS_Property = 10,
        XIN2_HYSTERESIS_Property = 11,
        EPS_HYSTERESIS_Property = 12,
        Q_HYSTERESIS_Property = 13,
    };
    public enum Prop_INTEGRAL
    {
        RUN_INTEGRAL_Property = 10,
        R1_INTEGRAL_Property = 11,
        XIN_INTEGRAL_Property = 12,
        X0_INTEGRAL_Property = 13,
        CYCLE_INTEGRAL_Property = 14,
        Q_INTEGRAL_Property = 15,
        XOUT_INTEGRAL_Property = 16,
    };
    public enum Prop_LAG
    {
        L_LAG_Property = 10,
        Z_LAG_Property = 11,
        P_LAG_Property = 12,
        I_LAG_Property = 13,
        O_LAG_Property = 14,
    };
    public enum Prop_PID
    {
        PV_PID_Property = 10,
        CV_PID_Property = 11,
        CSP_PID_Property = 12,
        TRE_PID_Property = 13,
        Reverse_PID_Property = 14,
        KP_PID_Property = 15,
        KI_PID_Property = 16,
        KD_PID_Property = 17,
        TRI_PID_Property = 18,
        OLH_PID_Property = 19,
        OLL_PID_Property = 20,
        MSP_PID_Property = 21,
        SP_PID_Property = 22,
        CALM_PID_Property = 23,
        RstL_PID_Property = 24,
        RstH_PID_Property = 25,
        P0S_PID_Property = 26,
        PSV_PID_Property = 27,
        STR_PID_Property = 28,
        OTR_PID_Property = 29,
        OSC_PID_Property = 30,
        OSH_PID_Property = 31,
        OSL_PID_Property = 32,
        INR_PID_Property = 33,
        INRH_PID_Property = 34,
        INRL_PID_Property = 35,
        WU_PID_Property = 36,
        OMO_PID_Property = 37,
    };
    public enum Prop_RAMP
    {
        RUN_RAMP_Property = 10,
        X0_RAMP_Property = 11,
        X1_RAMP_Property = 12,
        TR_RAMP_Property = 13,
        CYCLE_RAMP_Property = 14,
        BUSY_RAMP_Property = 15,
        XOUT_RAMP_Property = 16,
    };
    public enum Prop_RS
    {
        S_RS_Property = 10,
        R1_RS_Property = 11,
        Q1_RS_Property = 12,
    };
    public enum Prop_R_TRIG
    {
        CLK_R_TRIG_Property = 10,
        Q_R_TRIG_Property = 11,
    };
    public enum Prop_SEMA
    {
        CLAIM_SEMA_Property = 10,
        RELEASE_SEMA_Property = 11,
        BUSY_SEMA_Property = 12,
    };
    public enum Prop_SIG_GEN
    {
        SINE_SIG_GEN_Property = 10,
        PERIOD_SIG_GEN_Property = 11,
        MAXIMUM_SIG_GEN_Property = 12,
        PULSE_SIG_GEN_Property = 13,
        UP_SIG_GEN_Property = 14,
        END_SIG_GEN_Property = 15,
        RUN_SIG_GEN_Property = 16,
    };
    public enum Prop_SPLIT
    {
        CV1_SPLIT_Property = 10,
        CV2_SPLIT_Property = 11,
        AUTMAN_SPLIT_Property = 12,
        SPL_SPLIT_Property = 13,
        SPH_SPLIT_Property = 14,
        MV1_SPLIT_Property = 15,
        MV2_SPLIT_Property = 16,
        MSL1_SPLIT_Property = 17,
        MSL2_SPLIT_Property = 18,
        MSH1_SPLIT_Property = 19,
        MSH2_SPLIT_Property = 20,
        AUT_CMD_SPLIT_Property = 21,
        MANUAL_CMD_SPLIT_Property = 22,
    };
    public enum Prop_SR
    {
        S1_SR_Property = 10,
        R_SR_Property = 11,
        Q1_SR_Property = 12,
    };
    public enum Prop_STACKIN
    {
        IN_STACKIN_Property = 10,
        OUT_STACKIN_Property = 11,
        Q_STACKIN_Property = 12,
        PUSH_STACKIN_Property = 13,
        POP_STACKIN_Property = 14,
        R1_STACKIN_Property = 15,
        N_STACKIN_Property = 16,
        EMPTY_STACKIN_Property = 17,
        OFLO_STACKIN_Property = 18,
    };
    public enum Prop_TOF
    {
        IN_TOF_Property = 10,
        PT_TOF_Property = 11,
        Q_TOF_Property = 12,
        ET_TOF_Property = 13,
    };
    public enum Prop_TON
    {
        IN_TON_Property = 10,
        PT_TON_Property = 11,
        Q_TON_Property = 12,
        ET_TON_Property = 13,
    };
    public enum Prop_TP
    {
        IN_TP_Property = 10,
        PT_TP_Property = 11,
        Q_TP_Property = 12,
        ET_TP_Property = 13,
    };
    public enum Prop_WKHOUR
    {
        INPUT_WKHOUR_Property = 10,
        RESET_WKHOUR_Property = 11,
        RUN_WKHOUR_Property = 12,
        ENABLE_WKHOUR_Property = 13,
        TIME_WKHOUR_Property = 14,
    };


    public enum enumDynamicGraphicalProperty
    {
        [Description("BOOL"),
        Category("BOOL")]
        Unknown = 0,
        [Description("DINT"),
        Category("DINT")]
        BorderWidth = 1,
        [Description("Color"),
        Category("Color")]
        BorderColor,
        [Description("Color1"),
        Category("Color")]
        Color1,
        [Description("Color2"),
        Category("Color")]
        Color2,
        [Description("Text Color"),
        Category("Color")]
        TextColor,
        [Description("BOOL"),
        Category("BOOL")]
        BorderBlinking,
        [Description("BOOL"),
        Category("BOOL")]
        Blinking,
        [Description("BOOL"),
        Category("BOOL")]
        TextBlinking,
        [Description("STRING"),
        Category("STRING")]
        Text,
        [Description("BOOL"),
        Category("BOOL")]
        Visible,
    }

    

    public enum ID_COM_MESSAGE : byte
    {
        [Description("Point Request"),
        Category("Point")]
        ID_POINT = 1,
        [Description("Keep Alive"),
        Category("Network")]
        ID_KEEPALIVE,
        [Description("Station Status"),
        Category("Network")]
        ID_STATION,

    }

    public enum SID_COM_MESSAGE : byte
    {
        [Description("Point Request"),
        Category("ID_POINT")]
        ID_POINT_REQUEST = 1,
        [Description("Station ON"),
        Category("ID_STATION")]
        ID_STATION_ON,
        [Description("Station OFF"),
        Category("ID_STATION")]
        ID_STATION_OFF,
        [Description("Point Update"),
        Category("ID_POINT")]
        ID_POINT_PROPERTY_UPDATE,
        [Description("Point Update"),
        Category("ID_POINT")]
        ID_POINT_SUBPROPERTY_UPDATE,
    }

    public enum CRF_LOOKUP_Type
    {
        VARIABLE,
        LCU,
        BOARD,
        HMI,
        POU,
        Channel,
    }

    public enum TBLPLANTSTRUCTURE_TYPE
    {           
        Area = 2,
        Zone = 3,
        Unit = 4,
        Package = 5,
        LCU = 6,
        OWS = 7,        
    }

    public enum EXPLORER_ACCESS
    {
        NoAccess = 0,
        ViewOnly = 1,
        Full =2,
    }
}
