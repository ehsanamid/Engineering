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


    [StructLayout(LayoutKind.Explicit, Size = 4, Pack = 1)]
    public struct date_type
    {
        [FieldOffset(0)]
        public short Year;

        [FieldOffset(2)]
        public sbyte Month;

        [FieldOffset(3)]
        public sbyte Day;

        [FieldOffset(0)]
        public uint date;

    }

    [StructLayout(LayoutKind.Explicit, Size = 4, Pack = 1)]
    public struct tod_t
    {
        [FieldOffset(0)]
        public sbyte Hour;

        [FieldOffset(1)]
        public sbyte Minute;

        [FieldOffset(2)]
        public sbyte Second;

        [FieldOffset(3)]
        public sbyte res;

        [FieldOffset(0)]
        public uint tod;

    }

    [StructLayout(LayoutKind.Explicit, Size = 8, Pack = 1)]
    public struct dt_t
    {
        [FieldOffset(0)]
        public UInt16 Year;
        [FieldOffset(2)]
        public byte Month;
        [FieldOffset(3)]
        public byte Day;
        [FieldOffset(4)]
        public byte Hour;
        [FieldOffset(5)]
        public byte Minute;
        [FieldOffset(6)]
        public byte Second;
        [FieldOffset(7)]
        public byte res;

        [FieldOffset(0)]
        public UInt64 dt;
    }

    [StructLayout(LayoutKind.Explicit, Size = 8)]
    public struct VALUE
    {
        [FieldOffset(0)]
        public bool BOOL;

        [FieldOffset(0)]
        public sbyte SINT;

        [FieldOffset(0)]
        public short INT;

        [FieldOffset(0)]
        public int DINT;

        [FieldOffset(0)]
        public long LINT;

        [FieldOffset(0)]
        public byte USINT;

        [FieldOffset(0)]
        public ushort UINT;

        [FieldOffset(0)]
        public uint UDINT;

        [FieldOffset(0)]
        public ulong ULINT;

        [FieldOffset(0)]
        public float REAL;

        [FieldOffset(0)]
        public double LREAL;

        [FieldOffset(0)]
        public uint TIME;

        [FieldOffset(0)]
        public byte BYTE;

        [FieldOffset(0)]
        public ushort WORD;

        [FieldOffset(0)]
        public uint DWORD;

        [FieldOffset(0)]
        public ulong LWORD;

        [FieldOffset(0)]
        public date_type DATE;

        [FieldOffset(0)]
        public tod_t TOD;

        [FieldOffset(0)]
        public dt_t DT;

    }

    //public struct STRINGOBJ
    //{
    //    public byte[] Val = new byte[Common.MAX_STRING_SIZE];
    //    public int Len;
    //}


    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct MessagePacket
    {
        public long Index;//Index of variable


        public byte CAT;   // Message Category
        public byte ID;    // Message ID
        public byte StationNo;
        public byte res;
    }

    public struct ValueObj
    {
        public VALUE Val;
        public int ValueType;
        public void Reorder(ref ValueObj valueobj)
        {
            //valueobj.Val.UDINT			= bswap_32(Val.UDINT);
            valueobj.Val.UDINT = Common.bswap_32(Val.UDINT);
            //  valueobj.ValueType = (VarType)Enum.Parse(typeof(VarType), Common.bswap_32((int)ValueType);
            valueobj.ValueType = (int)Enum.ToObject(typeof(VarType), Common.bswap_32((uint)ValueType));
        }
    }

    
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct OPERAND
    {
        public long Index;//Index of variable
        public long PinID;//id of pin
        public int type;  // Constant type
        //public Token_Type Token;

       
        public byte Token;
        public byte PropertyNo;
        public byte PinNo;
        public byte HasSubPropety;
        public byte SubProperty;
        public byte IsReference;
        public byte Res3;
        public byte Res4;


        //public void ntoh()
        //{
        //    Index = Common.ntohl(Index);
        //    //Nodeno = Common.ntohi(Nodeno);
        //    //type = Common.ntohi(type);

        //}
    }


    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct OPERATOR
    {
        public int ReturnType;
        public int OpCode;
        //public int Size1;
        //public int Size2;
        //public int Size3;
        public byte NoOfArg;
        //public byte operationType;
        public byte Res1;
        public byte Res2;
        public byte Res3;

        //public void ntoh()
        //{
        //    ReturnType = Common.ntohi(ReturnType);
        //    OpCode = Common.ntohi(OpCode);
        //}

    }
    
    public struct OPERATION
    {
        public int Size1;
        public int Size2;
        public int Size3;
        public byte operationType;
        public byte Res1;
        public byte Res2;
        public byte Res3;

    }
   

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ApplicationCode
    {
        public uint TagetVer;		//0
        public int ApplicationVersion;				//1
        public int BufferSize;						//2
        public int NoOfConstants;					//3
        public int NoOfStrings;					//4
        public int NoOfInternalsConstant;			//5
        public int NoOfInternalsString;			//6
        public int NoOfPrograms;					//7
        public int NoOfUserDefinedFunctions;		//8
        public int NoOfUserDefinedFunctionBlocks;	//9
        public int UserDef10;						//10
        public int UserDef11;						//11
        public int UserDef12;						//12
        public int UserDef13;						//13
        public int UserDef14;						//14
        public int UserDef15;						//15
        public void Reorder(out ApplicationCode appcode)
        {
            appcode.TagetVer = Common.bswap_32(TagetVer);
            appcode.ApplicationVersion = (int)Common.bswap_32((uint)ApplicationVersion);
            appcode.BufferSize = (int)Common.bswap_32((uint)BufferSize);
            appcode.NoOfConstants = (int)Common.bswap_32((uint)NoOfConstants);
            appcode.NoOfStrings = (int)Common.bswap_32((uint)NoOfStrings);
            appcode.NoOfInternalsConstant = (int)Common.bswap_32((uint)NoOfInternalsConstant);
            appcode.NoOfInternalsString = (int)Common.bswap_32((uint)NoOfInternalsString);
            appcode.NoOfPrograms = (int)Common.bswap_32((uint)NoOfPrograms);
            appcode.NoOfUserDefinedFunctions = (int)Common.bswap_32((uint)NoOfUserDefinedFunctions);
            appcode.NoOfUserDefinedFunctionBlocks = (int)Common.bswap_32((uint)NoOfUserDefinedFunctionBlocks);
            appcode.UserDef10 = (int)Common.bswap_32((uint)UserDef10);
            appcode.UserDef11 = (int)Common.bswap_32((uint)UserDef11);
            appcode.UserDef12 = (int)Common.bswap_32((uint)UserDef12);
            appcode.UserDef13 = (int)Common.bswap_32((uint)UserDef13);
            appcode.UserDef14 = (int)Common.bswap_32((uint)UserDef14);
            appcode.UserDef15 = (int)Common.bswap_32((uint)UserDef15);
        }


    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct LogicProgram
    {

        public int Signeture;
        public UInt64 TimeStamp;
        //public byte[] Name;
        public int Index;
        public int Size;
        public int Type;
        public int ProgramType;	// Function,Function Block,Program , OWS expression  POUTYPE
        public int ProgramLanguage;	// SFC , FBD , ST , IL , LD    PROGRAM_LANGUAGE
        public int CycleTimeGroup;

    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct DrawExpressionCollectionCode
    {
        public long ID;		//0
        public int NoOfDynamicProperties;				//1
        public int BufferSize;						//2
        public int NoOfConstants;					//3
        public int NoOfStrings;					//4
        public int NoOfInternalsConstant;			//5
        public int NoOfInternalsString;			//6
        public int IsValid;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ExpressionCode
    {
        public int Property;
        public int Size;
        public int ReturnType;
        public int ExecutionType;
        public int IsColor;
        public int IsString;
        public int NoOfConditions;
        public int IsValid;
    }
    
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct STRINGOBJ
    {
        //public byte[] Val = new byte[Common.MAX_STRING_SIZE];
        public byte Val00;
        public byte Val01;
        public byte Val02;
        public byte Val03;
        public byte Val04;
        public byte Val05;
        public byte Val06;
        public byte Val07;
        public byte Val08;
        public byte Val09;
        public byte Val10;
        public byte Val11;
        public byte Val12;
        public byte Val13;
        public byte Val14;
        public byte Val15;


        public int Len;

        public void ToCopy(STRINGOBJ tocopy)
        {
            Len     = tocopy.Len;
            Val00 = tocopy.Val00;
            Val01 = tocopy.Val01;
            Val02 = tocopy.Val02;
            Val03 = tocopy.Val03;
            Val04 = tocopy.Val04;
            Val05 = tocopy.Val05;
            Val06 = tocopy.Val06;
            Val07 = tocopy.Val07;
            Val08 = tocopy.Val08;
            Val09 = tocopy.Val09;
            Val10 = tocopy.Val10;
            Val11 = tocopy.Val11;
            Val12 = tocopy.Val12;
            Val13 = tocopy.Val13;
            Val14 = tocopy.Val14;
            Val15 = tocopy.Val15;
        }

        public string getStringValue()
        {
            string str = "";
            try
            {
                byte[] Val = new byte[Common.MAX_STRING_SIZE];
                Val[00] = Val00;
                Val[01] = Val01;
                Val[02] = Val02;
                Val[03] = Val03;
                Val[04] = Val04;
                Val[05] = Val05;
                Val[06] = Val06;
                Val[07] = Val07;
                Val[08] = Val08;
                Val[09] = Val09;
                Val[10] = Val10;
                Val[11] = Val11;
                Val[12] = Val12;
                Val[13] = Val13;
                Val[14] = Val14;
                Val[15] = Val15;
                 str = System.Text.Encoding.Default.GetString(Val);
            }
            catch (Exception ex)
            {
            }
            return str;
        }
    }


    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public  struct ConditionCode
    {
        public VALUE Value;
        public STRINGOBJ StrValue;
        //public byte[] Val;

        //public int Len;
        public int Size;


        //public fixed byte Val[16];
    }

    //[StructLayout(LayoutKind.Sequential, Pack = 1)]
    //public struct CRF_LOOKUP
    //{
    //    public string Tag;
    //    public CRF_LOOKUP_Type Type;
    //    public int VarType;
    //    public long ID;
    //    public CRF_LOOKUP_Type Type1;
    //    public long ID1;
    //    public CRF_LOOKUP_Type Type2;
    //    public long ID2;
    //    public CRF_LOOKUP_Type Type3;
    //    public long ID3;
    //    public CRF_LOOKUP_Type Type4;
    //    public long ID4;
    //    public int PropertyNo;
        

    //}

    public struct ErrorInfo
    {
        public string str;
        public PouLanguageType type;
        public int X;
        public int Y;
        public int LineNumber;
        public int ErrorNo;
        public long ID;
        public CRF_LOOKUP_Type ID_Type;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct OBJECT_LIST
    {
        public CRF_LOOKUP_Type Type;
        public long ID;
        public CRF_LOOKUP_Type Type1;
        public long ID1;
        public CRF_LOOKUP_Type Type2;
        public long ID2;
        public CRF_LOOKUP_Type Type3;
        public long ID3;
        public bool status;

    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct COMMessage
    {
        public int StationNo;
        public int Len;
        public ID_COM_MESSAGE ID;
        public SID_COM_MESSAGE SID;
        public byte Res1;
        public byte Res2;

    }


    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct OBJECT_UPDATE
    {
        public long ID;
        public VALUE Value;
        public int Type;
        public byte Type1;
        public byte Type2;
        public byte Type3;
        public byte Type4;

    }

}
