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
using System.Drawing;
using System.Text.RegularExpressions;
using System.Globalization;
using DCS.Forms;


namespace DCS
{

    
    public  class Common
    {
        public static string LastFillColor = "";
        public static string LastLineStyle = "";
        public static int MaxNumberOfExPins = 12;
        public static int UnitSize = 8;
        public static int BaseSize = 4;
        public static int MAX_STRING_SIZE = 16;
        public static StreamWriter errorlogfile;
        public static string ConnectionStringR = "";
        public static string ConnectionString = "";
        public static string PassString = "1234";
        public static string WordString = "5678";
        public static bool AutoLoad = true;
        public static long LogLevel;
        public static int Portsize = 3;
        public static int Variable_LastSelectedType;
        public static string Variable_LastSelectedFilter = "";
        public static string ProjectPath = "";
        public static bool Blinking = false;
        public static bool Variable_ShowMode;
        public static bool Variable_ShowState;
        public static bool Variable_ShowALS;
        public static bool Variable_ShowALA;
        public static bool Variable_ShowALB;
        public static bool Variable_ShowAEB;
        public static bool Variable_ShowOPN;
        public static bool Variable_ShowOPH;
        public static bool Variable_ShowOPM;
        public static bool Variable_ShowMNN;
        public static int Variable_NameColWidth;
        public static int Variable_DescriptionColWidth;
        public static int Variable_TypeColWidth;
        public static int Variable_IDColWidth;
        public static bool Variable_LocalSelected;
        public static long Variable_LastSelectedArea;
        public static int Variable_NextShow;    // 0 : Never keep last state
                                                // 1 : Keep last state in when application running
                                                // 2 : Keep forever
        public static int TabPageGridAlarmGroupControl_RowColWidth;
        public static int TabPageGridAlarmGroupControl_NameColWidth;
        public static int TabPageGridAlarmGroupControl_TypeColWidth;
        public static int TabPageGridAlarmGroupControl_ArchiveColWidth;
        public static int TabPageGridAlarmGroupControl_RetriggerColWidth;
        public static int TabPageGridAlarmGroupControl_PrintColWidth;

        public static int TabVariableGridPageControl_NameColWidth;
        public static int TabVariableGridPageControl_DescriptionColWidth;
        public static int TabVariableGridPageControl_POUColWidth;
        public static int TabVariableGridPageControl_TypeColWidth;
        public static int TabVariableGridPageControl_InitialValColWidth;
        public static int TabVariableGridPageControl_GroupColWidth;
        public static string DatabaseName = "";
        public static string SelectedFunctionCategory = "All";
        public static string SelectedFunctionBlockCategory = "All";
        public static SQLiteConnection Conn = null;
        
        public static Point ConvertStringToPoint(string s)
        {
            Regex r = new Regex(@"\d+");
            MatchCollection mc = r.Matches(s);

            return new Point(int.Parse(mc[0].ToString()), int.Parse(mc[1].ToString())); ;
        }



        public static Color ConvertStringToColor(string s)
        {
            try
            {
                Color c = Color.White;

                Regex r = new Regex(@"\[.*\]");
                Match m = r.Match(s);

                //Get string and strip brackets
                string str = m.ToString();
                str = str.Substring(1, str.Length - 2);

                //Values are stored in 2 different formats
                //  1. Color [Black]
                //  2. Color [A=255,R=0,G=0,B=0]
                if (str.StartsWith("A="))
                {
                    r = new Regex(@"\d+");
                    MatchCollection mc = r.Matches(str);

                    c = Color.FromArgb(int.Parse(mc[0].ToString()),
                        int.Parse(mc[1].ToString()),
                        int.Parse(mc[2].ToString()),
                        int.Parse(mc[3].ToString()));
                }
                else
                    c = Color.FromName(str);

                return c;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            return Color.White;
        }

        /// <summary>
        /// Coverts a Color to a string "Color [A=n,R=n,G=n,B=n]"
        /// </summary>
        /// <param name="clr"></param>
        /// <returns></returns>
        public static string ConvertColorToString(Color clr)
        {
            try
            {
                string ret = "Color [";

                if (clr.IsKnownColor)
                    ret += clr.ToKnownColor();
                else
                    ret += "A=" + clr.A.ToString() + "," +
                          "R=" + clr.R.ToString() + "," +
                          "G=" + clr.G.ToString() + "," +
                          "B=" + clr.B.ToString();

                return ret += "]";
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            return "";
        }

        /// <summary>
        /// Converts a string "n,n,n,n" to a Rectangle
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static Rectangle ConvertStringToRectangle(string str)
        {
            try
            {
                Rectangle rct = new Rectangle();
                Regex r = new Regex(@"\d+");

                MatchCollection mc = r.Matches(str);

                rct.X = int.Parse(mc[0].ToString());
                rct.Y = int.Parse(mc[1].ToString());
                rct.Width = int.Parse(mc[2].ToString());
                rct.Height = int.Parse(mc[3].ToString());

                return rct;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            return new Rectangle();
        }

        public static string DatabaseFullName
        {

            get
            {
                try
                {
                    return ProjectPath + /*"\\\\" +*/ DatabaseName + ".Sqlite";
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
                return "";
            }
        }
        
        public static uint bswap_32(uint x)
        {
            return ((uint)((((uint)(x) & (uint)0x000000ffUL) << 24) | (((uint)(x) & (uint)0x0000ff00UL) << 8) | (((uint)(x) & (uint)0x00ff0000UL) >> 8) | (((uint)(x) & (uint)0xff000000UL) >> 24)));
        }
        public static bool IsSimpleType(int _type)
        {
            try
            {

                switch ((VarType)_type)
                {
                    case VarType.UNKNOWN:
                    case VarType.BOOL:
                    case VarType.BYTE:
                    case VarType.WORD:
                    case VarType.DWORD:
                    case VarType.LWORD:
                    case VarType.SINT:
                    case VarType.INT:
                    case VarType.DINT:
                    case VarType.LINT:
                    case VarType.USINT:
                    case VarType.UINT:
                    case VarType.UDINT:
                    case VarType.ULINT:
                    case VarType.REAL:
                    case VarType.LREAL:
                    case VarType.DATE:
                    case VarType.TOD:
                    case VarType.DT:
                    case VarType.STRING:
                    case VarType.WSTRING:
                    case VarType.TIME:
                        return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            return false;
        }

        public static bool IsStandardFBType(VarType _type)
        {
            try
            {
                switch (_type)
                {
                    case VarType.CTD:
                    case VarType.CTU:
                    case VarType.CTUD:
                    case VarType.DERIVATIVE:
                    case VarType.F_TRIG:
                    case VarType.HYSTERESIS:
                    case VarType.INTEGRAL:
                    case VarType.PID:
                    case VarType.R_TRIG:
                    case VarType.RS:
                    case VarType.RTC:
                    case VarType.SEMA:
                    case VarType.SR:
                    case VarType.TOFF:
                    case VarType.TON:
                    case VarType.TP:
                    case VarType.RAMP:
                    case VarType.AVERAGE:
                    case VarType.BLINK:
                    case VarType.CMP:
                    case VarType.LIM_ALR:
                    case VarType.STACKIN:
                    case VarType.PIDCAS://Homay-02/03/2014
                    case VarType.PIDOVR://Homay-02/03/2014
                    case VarType.SPLIT://Homay-02/03/2014
                    case VarType.TOTALIZER://Homay-02/03/2014
                        return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            return false;
        }
        public static bool IsUserdefinedFBType(VarType _type)
        {
            try
            {
                if ((int)_type > (int)VarType.USERDEFUNED)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            return false;
        }
        

        public static bool IsSingleType(int _vartype)
        {
            try
            {
                switch ((VarType)_vartype)
                {
                    case VarType.BOOL:
                    case VarType.BYTE:
                    case VarType.WORD:
                    case VarType.DWORD:
                    case VarType.LWORD:
                    case VarType.SINT:
                    case VarType.INT:
                    case VarType.DINT:
                    case VarType.LINT:
                    case VarType.USINT:
                    case VarType.UINT:
                    case VarType.UDINT:
                    case VarType.ULINT:
                    case VarType.REAL:
                    case VarType.LREAL:
                    case VarType.DATE:
                    case VarType.TOD:
                    case VarType.DT:
                    case VarType.STRING:
                    case VarType.WSTRING:
                    case VarType.TIME:
                        return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            return false;
        }

        public static bool IsFunctionType(int _vartype)
        {
            try
            {
                if ((_vartype >= 2097154) && (_vartype < 2145386497))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            return false;
        }


        public static int IsSamePatern(int v1, int v2, int patern)
        {
            try
            {
                if ((v1 & v2 & patern) != 0)
                {
                    if (v1 == v2)
                    {
                        return v1;

                    }
                    else
                    {
                        if (Common.IsSimpleType(v1))
                        {
                            return v1;

                        }
                        else
                        {
                            return v2;

                        }
                    }
                }
                return 0;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            return 0;
        }
        public static int ReturnType(int v1, int v2)
        {
            try
            {
                if (Common.IsSimpleType(v1))
                {
                    return v1;

                }
                else
                {
                    return v2;

                }

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            return 0;
        }

        public static int ntohi(int x)
        {
            try
            {
                byte[] bytes = BitConverter.GetBytes(x);
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(bytes);
                return BitConverter.ToInt32(bytes, 0);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            return 0;
        }

        public static long ntohl(long x)
        {
            try
            {
                byte[] bytes = BitConverter.GetBytes(x);
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(bytes);
                return BitConverter.ToInt64(bytes, 0);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            return 0;
        }

        public static short ntohs(short x)
        {
            try
            {
                byte[] bytes = BitConverter.GetBytes(x);
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(bytes);
                return BitConverter.ToInt16(bytes, 0);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            return 0;
        }

        public static float ntohf(float x)
        {
            try
            {
                byte[] bytes = BitConverter.GetBytes(x);
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(bytes);
                return BitConverter.ToSingle(bytes, 0);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            return 0;
        }

        public static string convertType2StringHeader<T>(T obj,  string[] _exclude)
        {
            try
            {
                string str = "";
                foreach (var prop in obj.GetType().GetProperties())
                {
                    if (!_exclude.Contains(prop.Name))
                    {
                        str += prop.Name;
                        str += ",";
                    }
                }
                str = str.Remove(str.Length - 1);
                //writer.WriteLine(str);
                return str;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            return "";
        }

        public static string GetType2StringHeader<T>(T obj, string firstcoumn, string[] _exclude)
        {
            try
            {
                string str = "";
                if (firstcoumn != "")
                {
                    foreach (var prop in obj.GetType().GetProperties())
                    {
                        if (firstcoumn == prop.Name)
                        {
                            str += prop.Name;
                            str += ",";
                            break;
                        }
                    }
                }

                foreach (var prop in obj.GetType().GetProperties())
                {
                    if ((firstcoumn != prop.Name) && !(_exclude.Contains(prop.Name)))
                    {
                        str += prop.Name;
                        str += ",";
                    }
                }
                return str;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            return "";
        }

        public static string convertType2String<T>(T obj, string[] _exclude)
        {
            try
            {
                bool ret = true;
                string str = "";
                foreach (var prop in obj.GetType().GetProperties())
                {
                    if (!_exclude.Contains(prop.Name))
                    {
                        Type t = obj.GetType();
                        PropertyInfo p = t.GetProperty(prop.Name);
                        Type t1 = p.PropertyType; // t will be System.String

                        if (t1 == typeof(bool))
                        {
                            str += ((bool)prop.GetValue(obj, null)).ToString();
                            str += ",";
                            continue;
                        }

                        if (t1 == typeof(int))
                        {
                            str += ((int)prop.GetValue(obj, null)).ToString();
                            str += ",";
                            continue;
                        }

                        if (t1 == typeof(long))
                        {
                            str += ((long)prop.GetValue(obj, null)).ToString();
                            str += ",";
                            continue;
                        }

                        if (t1 == typeof(string))
                        {
                            str += (string)prop.GetValue(obj, null);
                            str += ",";
                            continue;
                        }

                        if (t1 == typeof(DCS.POUTYPE))
                        {
                            str += (int)prop.GetValue(obj, null);
                            str += ",";
                            continue;
                        }

                        if (t1 == typeof(DCS.POUEXECUTIONTYPE))
                        {
                            str += (int)prop.GetValue(obj, null);
                            str += ",";
                            continue;
                        }

                        if (t1 == typeof(DCS.PouLanguageType))
                        {
                            str += (int)prop.GetValue(obj, null);
                            str += ",";
                            continue;
                        }

                        str += "0,";
                        ret = false;


                    }
                }
                str = str.Remove(str.Length - 1);
                return str;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            return "";
        }

        public static string GetType2String<T>(T obj, string firstcoumn, string[] _exclude )
        {
            try
            {
                string str = "";
                if (firstcoumn != "")
                {
                    foreach (var prop in obj.GetType().GetProperties())
                    {
                        if (firstcoumn == prop.Name)
                        {
                            Type t = obj.GetType();
                            PropertyInfo p = t.GetProperty(prop.Name);
                            Type t1 = p.PropertyType; // t will be System.String
                            if (t1 == typeof(bool))
                            {
                                str += ((bool)prop.GetValue(obj, null)).ToString();
                                str += ",";
                            }
                            else
                            {
                                if (t1 == typeof(int))
                                {
                                    str += ((int)prop.GetValue(obj, null)).ToString();
                                    str += ",";
                                }
                                else
                                {
                                    if (t1 == typeof(long))
                                    {
                                        str += ((long)prop.GetValue(obj, null)).ToString();
                                        str += ",";
                                    }
                                    else
                                    {
                                        if (t1 == typeof(string))
                                        {
                                            str += (string)prop.GetValue(obj, null);
                                            str += ",";
                                        }
                                        else
                                        {
                                            if (t1 == typeof(Single))
                                            {
                                                str += (float)prop.GetValue(obj, null);
                                                str += ",";
                                            }
                                            else
                                            {
                                                str += "0,";

                                            }

                                        }
                                    }
                                }
                            }
                            break;
                        }

                    }
                }
                foreach (var prop in obj.GetType().GetProperties())
                {
                    if ((firstcoumn != prop.Name) && !(_exclude.Contains(prop.Name)))
                    {
                        Type t = obj.GetType();
                        PropertyInfo p = t.GetProperty(prop.Name);
                        Type t1 = p.PropertyType; // t will be System.String
                        if (t1 == typeof(bool))
                        {
                            str += ((bool)prop.GetValue(obj, null)).ToString();
                            str += ",";
                        }
                        else
                        {
                            if (t1 == typeof(int))
                            {
                                str += ((int)prop.GetValue(obj, null)).ToString();
                                str += ",";
                            }
                            else
                            {
                                if (t1 == typeof(long))
                                {
                                    str += ((long)prop.GetValue(obj, null)).ToString();
                                    str += ",";
                                }
                                else
                                {
                                    if (t1 == typeof(string))
                                    {
                                        str += (string)prop.GetValue(obj, null);
                                        str += ",";
                                    }
                                    else
                                    {
                                        if (t1 == typeof(Single))
                                        {
                                            str += (float)prop.GetValue(obj, null);
                                            str += ",";
                                        }
                                        else
                                        {
                                            str += "0,";

                                        }

                                    }
                                }
                            }
                        }
                    }

                }

                return str;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            return "";
        }

        //public static bool IsBitSet<T>(this T t, int pos) where T : struct, IConvertible
        //{
        //    var value = t.ToInt64(System.Globalization.CultureInfo.CurrentCulture);
        //    return (value & (1 << pos)) != 0;
        //}
        public static bool IsBitSet(int t, int pos) 
        {
            try
            {
                // var value = t.ToInt64(System.Globalization.CultureInfo.CurrentCulture);
                return (t & (1 << pos)) != 0;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            return false;
        }
        public static bool IsBitSet(long t, int pos)
        {
            try
            {
                // var value = t.ToInt64(System.Globalization.CultureInfo.CurrentCulture);
                return (t & (1 << pos)) != 0;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            return true;
        }

        public static long SetBit(long t, int pos,bool _val)
        {
            try
            {
                if (_val)
                {
                    return t |= (1 << pos);
                }
                else
                {
                    return t &= ~(1 << pos);
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            return 0;
        }

        public static bool IsSerializable(object obj)
        {

            try
            {
                MemoryStream mem = new MemoryStream();
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bin = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                bin.Serialize(mem, obj);
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Your object cannot be serialized." +
                                 " The reason is: " + ex.ToString());
                return false;
            }
        }

        public static bool CheckValue(string _str, ref ValueObj _valueobj)
        {
            try
            {
                _valueobj.Val.DINT = int.Parse(_str, NumberStyles.Integer);
                _valueobj.ValueType = (int)VarType.DINT;
                return true;
            }
            catch (FormatException)
            {

            }
            try
            {
                _valueobj.Val.REAL = float.Parse(_str, NumberStyles.Float);
                _valueobj.ValueType = (int)VarType.REAL;
                return true;
            }
            catch (FormatException)
            {

            }

            return false;

        }

        static public bool IsValueColor(string _str, ref ValueObj _valueobj)
        {
            try
            {
                if (_str == "aliceblue") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0xF0F8FF; return true; }
                if (_str == "antiquewhite") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0xFAEBD7; return true; }
                if (_str == "aqua") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0x00FFFF; return true; }
                if (_str == "aquamarine") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0x7FFFD4; return true; }
                if (_str == "azure") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0xF0FFFF; return true; }
                if (_str == "beige") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0xF5F5DC; return true; }
                if (_str == "bisque") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0xFFE4C4; return true; }
                if (_str == "black") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0x000000; return true; }
                if (_str == "blanchedalmond") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0xFFEBCD; return true; }
                if (_str == "blue") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0x0000FF; return true; }
                if (_str == "blueviolet") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0x8A2BE2; return true; }
                if (_str == "brown") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0xA52A2A; return true; }
                if (_str == "burlywood") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0xDEB887; return true; }
                if (_str == "cadetblue") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0x5F9EA0; return true; }
                if (_str == "chartreuse") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0x7FFF00; return true; }
                if (_str == "chocolate") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0xD2691E; return true; }
                if (_str == "coral") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0xFF7F50; return true; }
                if (_str == "cornflowerblue") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0x6495ED; return true; }
                if (_str == "cornsilk") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0xFFF8DC; return true; }
                if (_str == "crimson") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0xDC143C; return true; }
                if (_str == "cyan") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0x00FFFF; return true; }
                if (_str == "darkblue") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0x00008B; return true; }
                if (_str == "darkcyan") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0x008B8B; return true; }
                if (_str == "darkgoldenrod") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0xB8860B; return true; }
                if (_str == "darkgray") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0xA9A9A9; return true; }
                if (_str == "darkgreen") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0x006400; return true; }
                if (_str == "darkkhaki") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0xBDB76B; return true; }
                if (_str == "darkmagenta") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0x8B008B; return true; }
                if (_str == "darkolivegreen") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0x556B2F; return true; }
                if (_str == "darkorange") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0xFF8C00; return true; }
                if (_str == "darkorchid") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0x9932CC; return true; }
                if (_str == "darkred") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0x8B0000; return true; }
                if (_str == "darksalmon") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0xE9967A; return true; }
                if (_str == "darkseagreen") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0x8FBC8F; return true; }
                if (_str == "darkslateblue") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0x483D8B; return true; }
                if (_str == "darkslategray") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0x2F4F4F; return true; }
                if (_str == "darkturquoise") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0x00CED1; return true; }
                if (_str == "darkviolet") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0x9400D3; return true; }
                if (_str == "deeppink") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0xFF1493; return true; }
                if (_str == "deepskyblue") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0x00BFFF; return true; }
                if (_str == "dimgray") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0x404040; return true; }
                if (_str == "dimgrey") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0x404040; return true; }
                if (_str == "dodgerblue") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0x1E90FF; return true; }
                if (_str == "firebrick") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0xB22222; return true; }
                if (_str == "floralwhite") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0xFFFAF0; return true; }
                if (_str == "forestgreen") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0x228B22; return true; }
                if (_str == "fuchsia") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0xFF00FF; return true; }
                if (_str == "gainsboro") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0xDCDCDC; return true; }
                if (_str == "ghostwhite") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0xF8F8FF; return true; }
                if (_str == "gold") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0xFFD700; return true; }
                if (_str == "goldenrod") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0xDAA520; return true; }
                if (_str == "gray") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0x808080; return true; }
                if (_str == "green") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0x008000; return true; }
                if (_str == "greenyellow") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0xADFF2F; return true; }
                if (_str == "honeydew") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0xF0FFF0; return true; }
                if (_str == "hotpink") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0xFF69B4; return true; }
                if (_str == "indianred") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0xCD5C5C; return true; }
                if (_str == "indigo") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0x4B0082; return true; }
                if (_str == "ivory") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0xFFFFF0; return true; }
                if (_str == "khaki") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0xF0E68C; return true; }
                if (_str == "lavender") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0xE6E6FA; return true; }
                if (_str == "lavenderblush") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0xFFF0F5; return true; }
                if (_str == "lawngreen") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0x7CFC00; return true; }
                if (_str == "lemonchiffon") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0xFFFACD; return true; }
                if (_str == "lightblue") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0xADD8E6; return true; }
                if (_str == "lightcoral") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0xF08080; return true; }
                if (_str == "lightcyan") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0xE0FFFF; return true; }
                if (_str == "lightgoldenrodyellow") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0xFAFAD2; return true; }
                if (_str == "lightgray") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0xD3D3D3; return true; }
                if (_str == "lightgreen") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0x90EE90; return true; }
                if (_str == "lightpink") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0xFFB6C1; return true; }
                if (_str == "lightsalmon") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0xFFA07A; return true; }
                if (_str == "lightseagreen") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0x20B2AA; return true; }
                if (_str == "lightskyblue") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0x87CEFA; return true; }
                if (_str == "lightslategray") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0x778899; return true; }
                if (_str == "lightsteelblue") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0xB0C4DE; return true; }
                if (_str == "lightyellow") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0xFFFFE0; return true; }
                if (_str == "lime") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0x00FF00; return true; }
                if (_str == "limegreen") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0x32CD32; return true; }
                if (_str == "linen") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0xFAF0E6; return true; }
                if (_str == "magenta") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0xFF00FF; return true; }
                if (_str == "maroon") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0x800000; return true; }
                if (_str == "mediumaquamarine") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0x66CDAA; return true; }
                if (_str == "mediumblue") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0x0000CD; return true; }
                if (_str == "mediumorchid") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0xBA55D3; return true; }
                if (_str == "mediumpurple") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0x9370DB; return true; }
                if (_str == "mediumseagreen") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0x3CB371; return true; }
                if (_str == "mediumslateblue") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0x7B68EE; return true; }
                if (_str == "mediumspringgreen") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0x00FA9A; return true; }
                if (_str == "mediumturquoise") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0x48D1CC; return true; }
                if (_str == "mediumvioletred") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0xC71585; return true; }
                if (_str == "midnightblue") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0x191970; return true; }
                if (_str == "mintcream") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0xF5FFFA; return true; }
                if (_str == "mistyrose") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0xFFE4E1; return true; }
                if (_str == "moccasin") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0xFFE4B5; return true; }
                if (_str == "navajowhite") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0xFFDEAD; return true; }
                if (_str == "navy") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0x000080; return true; }
                if (_str == "oldlace") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0xFDF5E6; return true; }
                if (_str == "olive") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0x808000; return true; }
                if (_str == "olivedrab") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0x6B8E23; return true; }
                if (_str == "orange") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0xFFA500; return true; }
                if (_str == "orangered") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0xFF4500; return true; }
                if (_str == "orchid") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0xDA70D6; return true; }
                if (_str == "palegoldenrod") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0xEEE8AA; return true; }
                if (_str == "palegreen") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0x98FB98; return true; }
                if (_str == "paleturquoise") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0xAFEEEE; return true; }
                if (_str == "palevioletred") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0xDB7093; return true; }
                if (_str == "papayawhip") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0xFFEFD5; return true; }
                if (_str == "peachpuff") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0xFFDAB9; return true; }
                if (_str == "peru") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0xCD853F; return true; }
                if (_str == "pink") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0xFFC0CB; return true; }
                if (_str == "plum") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0xDDA0DD; return true; }
                if (_str == "powderblue") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0xB0E0E6; return true; }
                if (_str == "purple") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0x800080; return true; }
                if (_str == "red") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0xFF0000; return true; }
                if (_str == "rosybrown") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0xBC8F8F; return true; }
                if (_str == "royalblue") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0x4169E1; return true; }
                if (_str == "saddlebrown") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0x8B4513; return true; }
                if (_str == "salmon") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0xFA8072; return true; }
                if (_str == "sandybrown") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0xF4A460; return true; }
                if (_str == "seagreen") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0x2E8B57; return true; }
                if (_str == "seashell") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0xFFF5EE; return true; }
                if (_str == "sienna") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0xA0522D; return true; }
                if (_str == "silver") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0xC0C0C0; return true; }
                if (_str == "skyblue") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0x87CEEB; return true; }
                if (_str == "slateblue") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0x6A5ACD; return true; }
                if (_str == "slategray") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0x708090; return true; }
                if (_str == "snow") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0xFFFAFA; return true; }
                if (_str == "springgreen") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0x00FF7F; return true; }
                if (_str == "steelblue") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0x4682B4; return true; }
                if (_str == "tan") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0xD2B48C; return true; }
                if (_str == "teal") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0x008080; return true; }
                if (_str == "thistle") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0xD8BFD8; return true; }
                if (_str == "tomato") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0xFF6347; return true; }
                if (_str == "turquoise") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0x40E0D0; return true; }
                if (_str == "violet") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0xEE82EE; return true; }
                if (_str == "wheat") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0xF5DEB3; return true; }
                if (_str == "white") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0xFFFFFF; return true; }
                if (_str == "whitesmoke") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0xF5F5F5; return true; }
                if (_str == "yellow") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0xFFFF00; return true; }
                if (_str == "yellowgreen") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0x9ACD32; return true; }
                if (_str == "transparent") { _valueobj.ValueType = (int)VarType.UDINT; _valueobj.Val.UDINT = 0xffffffff; return true; }

                //SendOutput("Error: definition of BOOL value is incorrect :" + _str);
                return false;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            return false;
        }
        

       public static  bool IsValueBOOL(string _str, ref ValueObj _valueobj)
        {
            try
            {
                if ((_str == "0") || (_str == "false"))
                {
                    _valueobj.ValueType = (int)VarType.BOOL;
                    _valueobj.Val.BOOL = false;
                    return true;
                }
                if ((_str == "1") || (_str == "true"))
                {
                    _valueobj.ValueType = (int)VarType.BOOL;
                    _valueobj.Val.BOOL = true;
                    return true;
                }
                //SendOutput("Error: definition of BOOL value is incorrect :" + _str);
                return false;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            return false;
        }
        static public bool IsValueBYTE(string _str, ref ValueObj _valueobj)
        {
            return true;
        }
        static public bool IsValueWORD(string _str, ref ValueObj _valueobj)
        {
            return true;
        }
        static public bool IsValueDWORD(string _str, ref ValueObj _valueobj)
        {
            return true;
        }
        static public bool IsValueLWORD(string _str, ref ValueObj _valueobj) { return true; }
        static public bool IsValueSINT(string _str, ref ValueObj _valueobj) { return true; }
        static public bool IsValueINT(string _str, ref ValueObj _valueobj) { return true; }
        static public bool IsValueLINT(string _str, ref ValueObj _valueobj) { return true; }
        static public bool IsValueUSINT(string _str, ref ValueObj _valueobj) { return true; }
        static public bool IsValueUINT(string _str, ref ValueObj _valueobj) { return true; }
        static public bool IsValueUDINT(string _str, ref ValueObj _valueobj) { return true; }
        static public bool IsValueULINT(string _str, ref ValueObj _valueobj) { return true; }
        static public bool IsValueLREAL(string _str, ref ValueObj _valueobj) { return true; }
        static public bool IsValueTIME(string _str, ref ValueObj _valueobj)
        {
            try
            {
                VALUE _val = new VALUE();

                bool noerror = true;
                string str = "";
                int i;
                int j;
                //int k;
                float _day = 0;
                float _hour = 0;
                float _minute = 0;
                float _second = 0;
                float _milisecond = 0;
                float temp = 0;
                _valueobj.ValueType = (int)VarType.TIME;

                int len = _str.Length;
                if (len >= 2)
                {
                    j = 0;
                    i = j;

                    // k = 0;
                    while ((_str[i] != 'd') && (i < len))
                    {
                        str += _str[i];
                        i++;
                    }

                    if (i < len)
                    {
                        _val.DWORD = 0;
                        if (CheckValue(str, ref _valueobj))
                        {
                            if (_valueobj.ValueType == (int)VarType.REAL)
                            {
                                _day = _val.REAL;
                            }
                            else
                            {
                                _day = (float)_val.DINT;
                            }
                            i++;
                            j = i;
                        }
                        else
                        {
                            noerror = false;
                        }
                    }
                    else
                    {
                        i = j;
                    }
                    if (noerror)
                    {
                        //i = j;
                        str = "";
                        // k = 0;
                        while ((_str[i] != 'h') && (i < len))
                        {
                            str += _str[i];
                            i++;
                        }

                        if (i < len)
                        {
                            if (CheckValue(str, ref _valueobj))
                            {
                                if (_valueobj.ValueType == (int)VarType.REAL)
                                {
                                    _hour = _val.REAL;
                                }
                                else
                                {
                                    _hour = (float)_val.DINT;
                                }
                                i++;
                                j = i;
                            }
                            else
                            {
                                noerror = false;
                            }
                        }
                        else
                        {
                            i = j;
                        }
                    }

                    if (noerror)
                    {

                        str = "";
                        // k = 0;
                        while ((_str[i] != 'm') && (i < len))
                        {
                            str += _str[i];
                            i++;
                        }

                        if (i < len)
                        {
                            if (CheckValue(str, ref _valueobj))
                            {
                                if (_valueobj.ValueType == (int)VarType.REAL)
                                {
                                    _minute = _val.REAL;
                                }
                                else
                                {
                                    _minute = (float)_val.DINT;
                                }
                                i++;
                                j = i;
                            }
                            else
                            {
                                noerror = false;
                            }
                        }
                        else
                        {
                            i = j;
                        }
                    }

                    if (noerror)
                    {

                        str = "";
                        // k = 0;
                        while ((_str[i] != 's') && (i < len))
                        {
                            str += _str[i];
                            i++;
                        }

                        if (i < len)
                        {
                            if (CheckValue(str, ref _valueobj))
                            {
                                if (_valueobj.ValueType == (int)VarType.REAL)
                                {
                                    _second = _val.REAL;
                                }
                                else
                                {
                                    _second = (float)_val.DINT;
                                }
                                i++;
                                j = i;
                            }
                            else
                            {
                                noerror = false;
                            }
                        }
                        else
                        {
                            i = j;
                        }
                    }

                    if (noerror)
                    {

                        str = "";
                        while ((_str[i] != 'm') && (_str[i] != 's') && (i < len))
                        {
                            str += _str[i];
                            i++;
                        }

                        if (i < len)
                        {
                            if (CheckValue(str, ref _valueobj))
                            {
                                if (_valueobj.ValueType == (int)VarType.REAL)
                                {
                                    _milisecond = _val.REAL;
                                }
                                else
                                {
                                    _milisecond = (float)_val.DINT;
                                }
                                i++;
                                j = i;
                            }
                            else
                            {
                                noerror = false;
                            }
                        }
                        else
                        {
                            i = j;
                        }
                    }

                    if (noerror)
                    {
                        //temp = _day;
                        //temp *= 24;
                        //temp += _hour;
                        //temp *= 60;
                        //temp += _minute;
                        //temp *= 60;
                        //temp += _second;
                        //temp *= 1000;
                        //temp += _milisecond;
                        temp = ((((((_day * 24) + _hour) * 60) + _minute) * 60) + _second) * 1000;// + _milisecond; 
                        _valueobj.Val.TIME = (uint)temp;
                        _valueobj.ValueType = (int)VarType.TIME;
                        return true;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            return false;
        }
        static public bool IsValueDATE(string _str, ref ValueObj _valueobj)
        {
            return true;
        }
        static public bool IsValueTOD(string _str, ref ValueObj _valueobj)
        {
            return true;
        }
        static public bool IsValueDT(string _str, ref ValueObj _valueobj)
        {
            return true;
        }

        static public bool IsValueDINT(string _str, ref ValueObj _valueobj)
        {
            try
            {
                _valueobj.Val.DINT = int.Parse(_str, NumberStyles.Integer);
                _valueobj.ValueType = (int)VarType.DINT;
                return true;
            }
            catch (FormatException)
            {

            }
            return false;
        }

        static public bool IsValueREAL(string _str, ref ValueObj _valueobj)
        {
            try
            {
                _valueobj.Val.REAL = float.Parse(_str, NumberStyles.Float);
                _valueobj.ValueType = (int)VarType.REAL;
                return true;
            }
            catch (FormatException)
            {

            }

            return false;
        }
        static public void RenameFile(string newfilename, string oldfilename)
        {
            if (File.Exists(oldfilename))
            {
                File.Copy(oldfilename, newfilename, true);
                File.Delete(oldfilename);
            }
        }

        static public void RemoveFile(string filename)
        {
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }
        }

        static public void CreateFolder(string foldername)
        {

            bool exists = System.IO.Directory.Exists(foldername);

            if (!exists)
            {
                System.IO.Directory.CreateDirectory(foldername);
            }
        
        }
        static public bool CheckNameIsValid(string str)
        {

            return true;
        }

        public static void CheckFolderExist(string foldername)
        {
            bool exists = System.IO.Directory.Exists(foldername);

            if (!exists)
            {
                System.IO.Directory.CreateDirectory(foldername);
            }
        }

        //public static T ToEnum<T>(this string value, T defaultValue)
        //{
        //    if (string.IsNullOrEmpty(value))
        //    {
        //        return defaultValue;
        //    }

        //    T result;
        //    return Enum.TryParse<T>(value, true, out result) ? result : defaultValue;
        //}

    }

   

    public static class FontXmlConverter
    {
        public static string ConvertToString(Font font)
        {
            try
            {
                if (font != null)
                {
                    TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
                    return converter.ConvertToString(font);
                }
                else
                    return null;
            }
            catch { System.Diagnostics.Debug.WriteLine("Unable to convert"); }
            return null;
        }
        public static Font ConvertToFont(string fontString)
        {
            try
            {
                TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
                return (Font)converter.ConvertFromString(fontString);
            }
            catch { System.Diagnostics.Debug.WriteLine("Unable to convert"); }
            return null;
        }
    }

    public class TemporayVariable
    {
        public tblVariable tblvariable;
        public tblFormalParameter tblformalparameter;
        public TemporayVariable()
        {
            tblvariable = new tblVariable();
            tblformalparameter = new tblFormalParameter();

        }
        //public long domainid;
        //public long controllerid;
        //public long pouid;
        //public long varid;
        //public int vartype;
        //public int varclass;
        //public string name;
        //public string description;
        //public string PropertyName;
        //public int PropertyType;
        //public int PropertyNo;
        public long id;
    }



   
    



    public class LCUPINDEF
    {
        //fixed int arrayInt[100]; // works properly 
        //byte Name[Common.MAX_STRING_SIZE];
        //fixed byte InitVal[Common.MAX_STRING_SIZE];
        public byte[] Name = new byte[Common.MAX_STRING_SIZE];
        public byte[] InitVal = new byte[Common.MAX_STRING_SIZE];
        public VarType m_type;
        public VarClass m_class;
        public VarOption m_option;
        public char m_pinno;
        public char m_res1;
        public char m_res2;
        public char m_res3;
    }

    public class LCUFBDEF
    {
        public byte[] Name = new byte[Common.MAX_STRING_SIZE];

        public VarType m_type;
        public LCUPINDEF m_pins = new LCUPINDEF();
        public char m_noofPins;
        public char m_res2;
        public char m_res3;
        public char m_res4;

    }


    public class NameID
    {
        public string Name { get; private set; }
        public int ID { get; private set; }
        public NameID(string name, int value)
        {
            Name = name;
            ID = value;
        }
    }
    public class NameLongID
    {
        public string Name { get; private set; }
        public int ID { get; private set; }
        public NameLongID(string name, int value)
        {
            Name = name;
            ID = value;
        }
    }
    
    public class DeleteListStruc
    {
        public long ID;
        public STATIC_OBJ_TYPE Type;
        public DeleteListStruc(long _id, STATIC_OBJ_TYPE _type)
        {
            ID = _id;
            Type = _type;
        }
    }
}
