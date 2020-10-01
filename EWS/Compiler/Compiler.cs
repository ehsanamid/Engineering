using DCS.Compile.Operation;
using DCS.Compile.Token;
using DCS.Compile.Collection;
using DCS;
using DCS.DCSTables;
using DCS.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using DCS.Draw;
using System.Globalization;
using DCS.Tools;
using DCS.Project_Objects;

namespace DCS.Compile
{
    public struct TypeReference
    {
        public int type;
        public bool refernce;
        public TypeReference(int _type, bool _reference)
        {
            type = _type;
            refernce = _reference;
        }
    }

    public class Compiler
    {
        
        static Dictionary<int, int> compilervartypelist;
        ErrorInfo _errorinfo;
        static bool[,] typecounter = new bool[22, 50];
        public static int GetUnassignedTempVar(int _type)
        {
            int _ty = Compiler.CompilerVarTypeList[_type];
            for (int i = 0; i < 50; i++)
            {
                if (Compiler.typecounter[_ty, i] == false)
                {
                    Compiler.typecounter[_ty, i] = true;
                    return i;
                }
            }
            throw new Exception("very complex expression");
            //return -1;
        }

        public static void FreeAssignedTempVar(int _type, int _index)
        {
            try
            {
                int _ty = Compiler.CompilerVarTypeList[_type];

                Compiler.typecounter[_ty, _index] = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static Dictionary<int, int> CompilerVarTypeList
        {
            get
            {
                if (compilervartypelist == null)
                {
                    compilervartypelist = new Dictionary<int, int>();

                    compilervartypelist.Add((int)VarType.BOOL, 0);
                    compilervartypelist.Add((int)VarType.BYTE, 1);
                    compilervartypelist.Add((int)VarType.WORD, 2);
                    compilervartypelist.Add((int)VarType.DWORD, 3);
                    compilervartypelist.Add((int)VarType.LWORD, 4);
                    compilervartypelist.Add((int)VarType.SINT, 5);
                    compilervartypelist.Add((int)VarType.INT, 6);
                    compilervartypelist.Add((int)VarType.DINT, 7);
                    compilervartypelist.Add((int)VarType.LINT, 8);
                    compilervartypelist.Add((int)VarType.USINT, 9);
                    compilervartypelist.Add((int)VarType.UINT, 10);
                    compilervartypelist.Add((int)VarType.UDINT, 11);
                    compilervartypelist.Add((int)VarType.ULINT, 12);
                    compilervartypelist.Add((int)VarType.REAL, 13);
                    compilervartypelist.Add((int)VarType.LREAL, 14);
                    compilervartypelist.Add((int)VarType.DATE, 15);
                    compilervartypelist.Add((int)VarType.TOD, 16);
                    compilervartypelist.Add((int)VarType.DT, 17);
                    compilervartypelist.Add((int)VarType.STRING, 18);
                    compilervartypelist.Add((int)VarType.WSTRING, 19);
                    compilervartypelist.Add((int)VarType.TIME, 20);


                }
                return compilervartypelist;
            }
            //set
            //{
            //    stringvartypelist = value;
            //}
        }

        List<string> stringcollection = new List<string>();
        List<ValueObj> constantcollection = new List<ValueObj>();
        List<CToken> InfixTokenList = new List<CToken>();
        List<CToken> PRNTokenList = new List<CToken>();
        List<string> seperatedlist = new List<string>();

        //public int getfreeindex(int type)
        //{
        //    int i;
        //    i = tyoecounter[CompilerVarTypeList[type]];
        //    tyoecounter[CompilerVarTypeList[type]]++;
        //    return i;
        //}


        ///public bool Seperator(string _retsstring)
        bool Seperator(string m_strInput)
        {
            //char[] stringInput= m_strInput.ToArray ();
            int pt = m_strInput.Length;
            int i, j;
            string myseps = " ,+-*/() =:<>;";
            char[] seps = myseps.ToCharArray();

            string myseps1 = "\"";
            char[] seps1 = myseps1.ToCharArray();
            List<string> _Stack = new List<string>();
            //CStringArray _Stack;
            char cstr = m_strInput.ElementAt(1);
            //char cstr = m_strInput.GetBuffer(1);
            string strtmp = "";
            char ch;
            byte ch1;
            bool readingstring = false;
            //string ss = "\"";
            string ss1;
            seps[0] = '\t';
            m_strInput.ToLower();
            seperatedlist.Clear();
            //m_TokenList.RemoveAll();

            i = 0;

            //if (m_strInput == "")
            //{
            //    _retsstring = "Blank Expression";
            //    return false;
            //}

            while (i < m_strInput.Length)
            {
                ch = (char)m_strInput[i];
                ch1 = (byte)m_strInput[i];

                if (!readingstring)
                {
                    //if(cstr[i] == '"')
                    ss1 = m_strInput[i].ToString();
                    if (ss1 == "\"")
                    //if( IsSeperator( (char)m_strInput[i] ,seps1))
                    {
                        readingstring = true;
                        _Stack.Add((m_strInput[i].ToString()));
                    }
                    else
                    {
                        if (IsSeperator((char)m_strInput[i], seps))  // 1
                        {

                            if (_Stack.Count > 0)  // 2
                            {
                                j = 0;
                                strtmp = "";
                                do
                                {
                                    strtmp += _Stack.ElementAt(j++);
                                } while (j < _Stack.Count);
                                _Stack.Clear();
                                seperatedlist.Add(strtmp);
                            }  // 2
                            if (m_strInput[i] != ' ')  // 3
                            {
                                if (m_strInput[i] == '-') // 4
                                {
                                    //Homey-Changed 02/01/2014 
                                    //if((( i > 0) && ((m_strInput[i-1] == '(') ||(m_strInput[i-1] == '=')) ) || (i == 0)) 
                                    if (((i > 0) && ((m_strInput[i - 1] == '(') || (m_strInput[i - 1] == ',') || (m_strInput[i - 1] == '='))) || (i == 0))  // 5
                                    {
                                        _Stack.Add(m_strInput[i].ToString());
                                    }
                                    else // 5
                                    {
                                        seperatedlist.Add(m_strInput[i].ToString());
                                    } // 5
                                }
                                else // 4
                                {

                                    if (((i + 1) < ((int)m_strInput.Length)) && (((m_strInput[i] == ':') && (m_strInput[i + 1] == '=')) ||
                                        ((m_strInput[i] == '>') && (m_strInput[i + 1] == '=')) ||
                                        ((m_strInput[i] == '<') && (m_strInput[i + 1] == '=')) ||
                                        ((m_strInput[i] == '<') && (m_strInput[i + 1] == '>'))))
                                    {
                                        seperatedlist.Add((m_strInput[i].ToString()) + (m_strInput[i + 1].ToString()));
                                        i++;
                                    }
                                    else
                                    {
                                        seperatedlist.Add((m_strInput[i].ToString()));
                                    }
                                } // 4
                            }

                        }  // 1
                        else
                        {
                            _Stack.Add((m_strInput[i].ToString()));
                        }
                    }
                }
                else
                {
                    ss1 = m_strInput[i].ToString();
                    if (ss1 == "\"")
                    //if(m_strInput[i] == '\"')
                    {
                        readingstring = false;
                        _Stack.Add((m_strInput[i].ToString()));
                        j = 0;
                        strtmp = "";
                        do
                        {
                            strtmp += _Stack.ElementAt(j++);
                        } while (j < _Stack.Count);
                        _Stack.Clear();
                        seperatedlist.Add(strtmp);
                    }
                    else
                    {
                        _Stack.Add((m_strInput[i].ToString()));
                    }
                }
                i++;
            }
            if (_Stack.Count > 0)  // 2
            {
                j = 0;
                strtmp = "";
                do
                {
                    strtmp += _Stack.ElementAt(j++);
                } while (j < _Stack.Count);
                _Stack.Clear();
                seperatedlist.Add(strtmp);
            }  // 2


            return true;
        }
        private bool IsSeperator(char ch, char[] Seps)
        {
            if (!Seps.Contains(ch))
            //if( strchr( Seps, ch ) == NULL)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        private void PrintToken()
        {
            //string str;
            //CToken tok;
        }



        //char *seps   = {"0","1","2","3","4","5","6","7","8","9","a","b","c","d","e","f"};
        //private bool IsValue(string _str, ref ValueObj _valueobj)
        private bool CheckTokenIsValue(string _str)
        {
            ValueObj _valueobj = new ValueObj();
            _str = _str.ToLower();
            int len = 0;
            string tempstr = "";

            if ((_str == "true") || (_str == "false"))
            {
                _valueobj.ValueType = (int)VarType.BOOL;

                if (_str == "true")
                {
                    _valueobj.Val.BOOL = true;
                }
                else
                {
                    _valueobj.Val.BOOL = false;
                }
                // Add Index of constant to ConstantTokenType
                CTokenOperand tok = new CTokenOperand(_str);
                tok.m_token = Token_Type.Token_Constant;
                tok.m_Index = _valueobj.Val.LINT;
                tok.m_Type = _valueobj.ValueType;
                InfixTokenList.Add(tok);
                return true;
            }

            tempstr = "bool#";
            len = tempstr.Length;
            if ((_str.Length > len) && (_str.Substring(0, len) == tempstr))
            {
                string str1 = _str.Substring(len, _str.Length);
                //string str1 = _str.Mid(5,_str.Length);	
                if (Common.IsValueBOOL(str1, ref _valueobj))
                {
                    // Add Index of constant to ConstantTokenType
                    CTokenOperand tok = new CTokenOperand(_str);
                    tok.m_token = Token_Type.Token_Constant;
                    tok.m_Index = _valueobj.Val.LINT;
                    tok.m_Type = _valueobj.ValueType;
                    InfixTokenList.Add(tok);
                    return true;
                }
                else
                {
                    return false;
                }
            }

            tempstr = "byte#";
            len = tempstr.Length;
            if ((_str.Length > len) && (_str.Substring(0, len) == tempstr))
            {
                string str1 = _str.Substring(len, _str.Length);

                if (Common.CheckValue(str1, ref _valueobj))
                {
                    if (Common.IsValueBYTE(str1, ref _valueobj))
                    {
                        // Add Index of constant to ConstantTokenType
                        CTokenOperand tok = new CTokenOperand(_str);
                        tok.m_token = Token_Type.Token_Constant;
                        tok.m_Index = _valueobj.Val.LINT;
                        tok.m_Type = _valueobj.ValueType;
                        InfixTokenList.Add(tok);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            tempstr = "word#";
            len = tempstr.Length;
            if ((_str.Length > len) && (_str.Substring(0, len) == tempstr))
            {
                string str1 = _str.Substring(len, _str.Length);

                if (Common.CheckValue(str1, ref _valueobj))
                {
                    if (Common.IsValueWORD(str1, ref _valueobj))
                    {
                        // Add Index of constant to ConstantTokenType
                        CTokenOperand tok = new CTokenOperand(_str);
                        tok.m_token = Token_Type.Token_Constant;
                        tok.m_Index = _valueobj.Val.LINT;
                        tok.m_Type = _valueobj.ValueType;
                        InfixTokenList.Add(tok);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }

            tempstr = "dword#";
            len = tempstr.Length;
            if ((_str.Length > len) && (_str.Substring(0, len) == tempstr))
            {
                string str1 = _str.Substring(len, _str.Length);
                if (Common.CheckValue(str1, ref _valueobj))
                {
                    if (Common.IsValueDWORD(str1, ref _valueobj))
                    {
                        // Add Index of constant to ConstantTokenType
                        CTokenOperand tok = new CTokenOperand(_str);
                        tok.m_token = Token_Type.Token_Constant;
                        tok.m_Index = _valueobj.Val.LINT;
                        tok.m_Type = _valueobj.ValueType;
                        InfixTokenList.Add(tok);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }

            tempstr = "lword#";
            len = tempstr.Length;
            if ((_str.Length > len) && (_str.Substring(0, len) == tempstr))
            {
                string str1 = _str.Substring(len, _str.Length);
                if (Common.CheckValue(str1, ref _valueobj))
                {
                    if (Common.IsValueLWORD(str1, ref _valueobj))
                    {
                        // Add Index of constant to ConstantTokenType
                        CTokenOperand tok = new CTokenOperand(_str);
                        tok.m_token = Token_Type.Token_Constant;
                        tok.m_Index = _valueobj.Val.LINT;
                        tok.m_Type = _valueobj.ValueType;
                        InfixTokenList.Add(tok);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }

            tempstr = "sint#";
            len = tempstr.Length;
            if ((_str.Length > len) && (_str.Substring(0, len) == tempstr))
            {
                string str1 = _str.Substring(len, _str.Length);
                if (Common.CheckValue(str1, ref _valueobj))
                {
                    if (Common.IsValueSINT(str1, ref _valueobj))
                    {
                        // Add Index of constant to ConstantTokenType
                        CTokenOperand tok = new CTokenOperand(_str);
                        tok.m_token = Token_Type.Token_Constant;
                        tok.m_Index = _valueobj.Val.LINT;
                        tok.m_Type = _valueobj.ValueType;
                        InfixTokenList.Add(tok);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }

            tempstr = "int#";
            len = tempstr.Length;
            if ((_str.Length > len) && (_str.Substring(0, len) == tempstr))
            {
                string str1 = _str.Substring(len, _str.Length);
                if (Common.CheckValue(str1, ref _valueobj))
                {
                    if (Common.IsValueINT(str1, ref _valueobj))
                    {
                        // Add Index of constant to ConstantTokenType
                        CTokenOperand tok = new CTokenOperand(_str);
                        tok.m_token = Token_Type.Token_Constant;
                        tok.m_Index = _valueobj.Val.LINT;
                        tok.m_Type = _valueobj.ValueType;
                        InfixTokenList.Add(tok);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }

            tempstr = "dint#";
            len = tempstr.Length;
            if ((_str.Length > len) && (_str.Substring(0, len) == tempstr))
            {
                string str1 = _str.Substring(len, _str.Length);
                if (Common.CheckValue(str1, ref _valueobj))
                {
                    if (Common.IsValueDINT(str1, ref _valueobj))
                    {
                        // Add Index of constant to ConstantTokenType
                        CTokenOperand tok = new CTokenOperand(_str);
                        tok.m_token = Token_Type.Token_Constant;
                        tok.m_Index = _valueobj.Val.LINT;
                        tok.m_Type = _valueobj.ValueType;
                        InfixTokenList.Add(tok);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }

            tempstr = "lint#";
            len = tempstr.Length;
            if ((_str.Length > len) && (_str.Substring(0, len) == tempstr))
            {
                string str1 = _str.Substring(len, _str.Length);
                if (Common.CheckValue(str1, ref _valueobj))
                {
                    if (Common.IsValueLINT(str1, ref _valueobj))
                    {
                        // Add Index of constant to ConstantTokenType
                        CTokenOperand tok = new CTokenOperand(_str);
                        tok.m_token = Token_Type.Token_Constant;
                        tok.m_Index = _valueobj.Val.LINT;
                        tok.m_Type = _valueobj.ValueType;
                        InfixTokenList.Add(tok);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }

            tempstr = "usint#";
            len = tempstr.Length;
            if ((_str.Length > len) && (_str.Substring(0, len) == tempstr))
            {
                string str1 = _str.Substring(len, _str.Length);
                if (Common.CheckValue(str1, ref _valueobj))
                {
                    if (Common.IsValueUSINT(str1, ref _valueobj))
                    {
                        // Add Index of constant to ConstantTokenType
                        CTokenOperand tok = new CTokenOperand(_str);
                        tok.m_token = Token_Type.Token_Constant;
                        tok.m_Index = _valueobj.Val.LINT;
                        tok.m_Type = _valueobj.ValueType;
                        InfixTokenList.Add(tok);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }

            tempstr = "uint#";
            len = tempstr.Length;
            if ((_str.Length > len) && (_str.Substring(0, len) == tempstr))
            {
                string str1 = _str.Substring(len, _str.Length);
                if (Common.CheckValue(str1, ref _valueobj))
                {
                    if (Common.IsValueUINT(str1, ref _valueobj))
                    {
                        // Add Index of constant to ConstantTokenType
                        CTokenOperand tok = new CTokenOperand(_str);
                        tok.m_token = Token_Type.Token_Constant;
                        tok.m_Index = _valueobj.Val.LINT;
                        tok.m_Type = _valueobj.ValueType;
                        InfixTokenList.Add(tok);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }

            tempstr = "udint#";
            len = tempstr.Length;
            if ((_str.Length > len) && (_str.Substring(0, len) == tempstr))
            {
                string str1 = _str.Substring(len, _str.Length);
                if (Common.CheckValue(str1, ref _valueobj))
                {
                    if (Common.IsValueUDINT(str1, ref _valueobj))
                    {
                        // Add Index of constant to ConstantTokenType
                        CTokenOperand tok = new CTokenOperand(_str);
                        tok.m_token = Token_Type.Token_Constant;
                        tok.m_Index = _valueobj.Val.LINT;
                        tok.m_Type = _valueobj.ValueType;
                        InfixTokenList.Add(tok);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }

            tempstr = "ulint#";
            len = tempstr.Length;
            if ((_str.Length > len) && (_str.Substring(0, len) == tempstr))
            {
                string str1 = _str.Substring(len, _str.Length);
                if (Common.CheckValue(str1, ref _valueobj))
                {
                    if (Common.IsValueULINT(str1, ref _valueobj))
                    {
                        // Add Index of constant to ConstantTokenType
                        CTokenOperand tok = new CTokenOperand(_str);
                        tok.m_token = Token_Type.Token_Constant;
                        tok.m_Index = _valueobj.Val.LINT;
                        tok.m_Type = _valueobj.ValueType;
                        InfixTokenList.Add(tok);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }

            tempstr = "real#";
            len = tempstr.Length;
            if ((_str.Length > len) && (_str.Substring(0, len) == tempstr))
            {
                string str1 = _str.Substring(len, _str.Length);
                if (Common.CheckValue(str1, ref _valueobj))
                {
                    if (Common.IsValueREAL(str1, ref _valueobj))
                    {
                        // Add Index of constant to ConstantTokenType
                        CTokenOperand tok = new CTokenOperand(_str);
                        tok.m_token = Token_Type.Token_Constant;
                        tok.m_Index = _valueobj.Val.LINT;
                        tok.m_Type = _valueobj.ValueType;
                        InfixTokenList.Add(tok);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }
            tempstr = "lreal#";
            len = tempstr.Length;
            if ((_str.Length > len) && (_str.Substring(0, len) == tempstr))
            {
                string str1 = _str.Substring(len, _str.Length);
                if (Common.CheckValue(str1, ref _valueobj))
                {
                    if (Common.IsValueLREAL(str1, ref _valueobj))
                    {
                        // Add Index of constant to ConstantTokenType
                        CTokenOperand tok = new CTokenOperand(_str);
                        tok.m_token = Token_Type.Token_Constant;
                        tok.m_Index = _valueobj.Val.LINT;
                        tok.m_Type = _valueobj.ValueType;
                        InfixTokenList.Add(tok);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }


            tempstr = "time#";
            len = tempstr.Length;
            if ((_str.Length > len) && (_str.Substring(0, len) == tempstr))
            {
                string str1 = _str.Substring(len, _str.Length);
                if (Common.IsValueTIME(str1, ref _valueobj))
                {
                    // Add Index of constant to ConstantTokenType
                    CTokenOperand tok = new CTokenOperand(_str);
                    tok.m_token = Token_Type.Token_Constant;
                    tok.m_Index = _valueobj.Val.LINT;
                    tok.m_Type = _valueobj.ValueType;
                    InfixTokenList.Add(tok);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            tempstr = "t#";
            len = tempstr.Length;
            if ((_str.Length > len) && (_str.Substring(0, len) == tempstr))
            {
                string str1 = _str.Substring(len, _str.Length);
                if (Common.IsValueTIME(str1, ref _valueobj))
                {
                    // Add Index of constant to ConstantTokenType
                    CTokenOperand tok = new CTokenOperand(_str);
                    tok.m_token = Token_Type.Token_Constant;
                    tok.m_Index = _valueobj.Val.LINT;
                    tok.m_Type = _valueobj.ValueType;
                    InfixTokenList.Add(tok);
                    return true;
                }
                else
                {
                    return false;
                }
            }

            tempstr = "date#";
            len = tempstr.Length;
            if ((_str.Length > len) && (_str.Substring(0, len) == tempstr))
            {
                string str1 = _str.Substring(len, _str.Length);
                if (Common.CheckValue(str1, ref _valueobj))
                {
                    if (Common.IsValueDATE(str1, ref _valueobj))
                    {
                        // Add Index of constant to ConstantTokenType
                        CTokenOperand tok = new CTokenOperand(_str);
                        tok.m_token = Token_Type.Token_Constant;
                        tok.m_Index = _valueobj.Val.LINT;
                        tok.m_Type = _valueobj.ValueType;
                        InfixTokenList.Add(tok);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }

            tempstr = "tod#";
            len = tempstr.Length;
            if ((_str.Length > len) && (_str.Substring(0, len) == tempstr))
            {
                string str1 = _str.Substring(len, _str.Length);
                if (Common.CheckValue(str1, ref _valueobj))
                {
                    if (Common.IsValueTOD(str1, ref _valueobj))
                    {
                        // Add Index of constant to ConstantTokenType
                        CTokenOperand tok = new CTokenOperand(_str);
                        tok.m_token = Token_Type.Token_Constant;
                        tok.m_Index = _valueobj.Val.LINT;
                        tok.m_Type = _valueobj.ValueType;
                        InfixTokenList.Add(tok);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }

            tempstr = "dt#";
            len = tempstr.Length;
            if ((_str.Length > len) && (_str.Substring(0, len) == tempstr))
            {
                string str1 = _str.Substring(len, _str.Length);
                if (Common.CheckValue(str1, ref _valueobj))
                {
                    if (Common.IsValueDT(str1, ref _valueobj))
                    {
                        // Add Index of constant to ConstantTokenType
                        CTokenOperand tok = new CTokenOperand(_str);
                        tok.m_token = Token_Type.Token_Constant;
                        tok.m_Index = _valueobj.Val.LINT;
                        tok.m_Type = _valueobj.ValueType;
                        InfixTokenList.Add(tok);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }

            tempstr = "col#";
            len = tempstr.Length;
            if ((_str.Length > len) && (_str.Substring(0, len) == tempstr))
            {
                string str1 = _str.Substring(len, _str.Length);
                if (Common.IsValueColor(str1, ref _valueobj))
                {
                    // Add Index of constant to ConstantTokenType
                    CTokenOperand tok = new CTokenOperand(_str);
                    tok.m_token = Token_Type.Token_Constant;
                    tok.m_Index = _valueobj.Val.LINT;
                    tok.m_Type = _valueobj.ValueType;
                    InfixTokenList.Add(tok);
                    return true;
                }
                else
                {
                    return false;
                }
            }

            if (Common.CheckValue(_str, ref _valueobj))
            {
                // Add Index of constant to ConstantTokenType
                CTokenOperand tok = new CTokenOperand(_str);
                tok.m_token = Token_Type.Token_Constant;
                tok.m_Index = _valueobj.Val.LINT;
                tok.m_Type = _valueobj.ValueType;
                InfixTokenList.Add(tok);
                return true;
            }
            else
            {
                return false;
            }
            //return false;
        }
        static public bool IsValueString(string _str, ref string _str1)
        {
            //char * str = (char *) (LPCTSTR) _str.MakeLower();
            //char str ;
            //str = _str.GetBuffer();
            //int withDecimal = 0;
            //int isNegative = 0;
            //int i = 0;
            if ((_str.Substring(0, 1) == "\"") && (_str.Substring(_str.Length - 1, _str.Length) == "\""))
            {
                _str1 = _str.Substring(1, _str.Length - 2);
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool CheckTokenIsString(string _str)
        {
            string _str1;
            int ret;
            if ((_str.Substring(0, 1) == "\"") && (_str.Substring(_str.Length - 1, _str.Length) == "\""))
            {
                _str1 = _str.Substring(1, _str.Length - 2);
                if ((ret = Add2stringcollection(_str)) == -1)
                {
                    return false;
                }
                // Add index of string to stringtokenType
                CTokenOperand tok = new CTokenOperand(_str);
                tok.m_token = Token_Type.Token_String;
                tok.m_Index = ret;
                tok.m_Type = (int)VarType.STRING;
                InfixTokenList.Add(tok);
                return true;
            }
            else
            {
                return false;
            }

        }
        private bool StringIsBase2(string _str, ref ValueObj _valueobj)
        {
            //	char   *string, *stopstring;
            int i = 0;
            int j = 0;
            int len = _str.Length;
            char[] str;
            str = _str.ToCharArray();

            if ((len == 1) && (str[0] == '-'))
            {
                return false;
            }
            if (str[0] == '-')
            {
                j = 1;
            }
            else
            {
                j = 0;
            }
            for (i = j; i < len; i++)
            {
                if (!((str[i] == '0') || (str[i] == '1'))) // if1
                {
                    return false;
                }
            }
            char start = (char)str[j];
            int total = 0;
            for (i = j; i < len; i++)
            {
                start = (char)str[j];
                total = 0;
                while (start != null)
                {
                    total *= 2;
                    if (start++ == '1') total += 1;
                }
            }
            if (j == 1)
            {
                _valueobj.Val.DINT = -1 * total;
            }
            else
            {
                _valueobj.Val.DINT = total;
            }
            return false;
        }
        private bool StringIsBase8(string _str, ref ValueObj _valueobj)
        {
            //	char   *string, *stopstring;
            int i = 0;
            int j = 0;
            int len = _str.Length;
            char[] str;
            str = _str.ToCharArray();

            if ((len == 1) && (str[0] == '-'))
            {
                return false;
            }
            if (str[0] == '-')
            {
                j = 1;
            }
            else
            {
                j = 0;
            }
            for (i = j; i < len; i++)
            {
                if (!((str[i] == '0') || (str[i] == '1') || (str[i] == '2') || (str[i] == '3') || (str[i] == '4') || (str[i] == '5') || (str[i] == '6') || (str[i] == '7'))) // if1
                {
                    return false;
                }
            }
            char start = (char)str[j];
            int total = 0;
            for (i = j; i < len; i++)
            {
                start = (char)str[j];
                total = 0;
                while (start != null)
                {
                    total *= 8;
                    switch (start)
                    {
                        case '1':
                            total += 1;
                            break;
                        case '2':
                            total += 2;
                            break;
                        case '3':
                            total += 3;
                            break;
                        case '4':
                            total += 4;
                            break;
                        case '5':
                            total += 5;
                            break;
                        case '6':
                            total += 6;
                            break;
                        case '7':
                            total += 7;
                            break;

                        default:
                            break;
                    }

                }
            }
            if (j == 1)
            {
                _valueobj.Val.DINT = -1 * total;
            }
            else
            {
                _valueobj.Val.DINT = total;
            }
            return false;
        }
        private bool StringIsBase10(string _str, ref ValueObj _valueobj)
        {
            //	char   *string, *stopstring;
            int i = 0;
            int j = 0;
            int len = _str.Length;
            char[] str;
            str = _str.ToCharArray();

            if ((len == 1) && (str[0] == '-'))
            {
                return false;
            }
            if (str[0] == '-')
            {
                j = 1;
            }
            else
            {
                j = 0;
            }
            for (i = j; i < len; i++)
            {
                if (!((str[i] == '0') || (str[i] == '1') || (str[i] == '2') || (str[i] == '3') || (str[i] == '4') || (str[i] == '5') || (str[i] == '6') || (str[i] == '7'))) // if1
                {
                    return false;
                }
            }
            char start = (char)str[j];
            int total = 0;
            for (i = j; i < len; i++)
            {
                start = (char)str[j];
                total = 0;
                while (start != null)
                {
                    total *= 10;
                    switch (start)
                    {
                        case '1':
                            total += 1;
                            break;
                        case '2':
                            total += 2;
                            break;
                        case '3':
                            total += 3;
                            break;
                        case '4':
                            total += 4;
                            break;
                        case '5':
                            total += 5;
                            break;
                        case '6':
                            total += 6;
                            break;
                        case '7':
                            total += 7;
                            break;

                        default:
                            break;
                    }

                }
            }
            if (j == 1)
            {
                _valueobj.Val.DINT = -1 * total;
            }
            else
            {
                _valueobj.Val.DINT = total;
            }
            return false;
        }
        private bool StringIsBase16(string _str, ref ValueObj _valueobj)
        {
            //	char   *string, *stopstring;
            int i = 0;
            int j = 0;
            int len = _str.Length;
            char[] str;
            str = _str.ToCharArray();

            if ((len == 1) && (str[0] == '-'))
            {
                return false;
            }
            if (str[0] == '-')
            {
                j = 1;
            }
            else
            {
                j = 0;
            }
            for (i = j; i < len; i++)
            {
                if ((str[i] == '0') || (str[i] == '1')) // if1
                {
                    char start = (char)str[j];
                    int total = 0;
                    while (start != null)
                    {
                        total *= 2;
                        if (start++ == '1')
                            total += 1;
                    }
                }
            }
            return false;
        }
        private bool ProcessValueString(string _str, ref ValueObj _valueobj)
        {
            if (_str.Substring(0, 2) == "2#")
            {
                string str1 = _str.Substring(2, _str.Length);
                if (Common.IsValueBOOL(str1, ref _valueobj))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        bool CheckTokenIsFunction(string _str)
        {
            foreach (tblFunction _tblfunction in tblSolution.m_tblSolution().m_tblFunctionCollection)
            {
                if ((_tblfunction.IsFunction) && (_tblfunction.FunctionName.ToLower() == _str.ToLower()))
                {
                    // Add Index of constant to FunctionTokenType
                    if (_tblfunction.Extensible)
                    {
                        CTokenFunctionEX tok = new CTokenFunctionEX(_str);
                        tok.tblfunction = _tblfunction;
                        InfixTokenList.Add(tok);
                    }
                    else
                    {
                        CTokenFunction tok = new CTokenFunction(_str);
                        tok.tblfunction = _tblfunction;
                        InfixTokenList.Add(tok);
                    }
                    return true;
                }
            }
            return false;
        }


        bool IsFunction(string _str, ref tblFunction _tblfunction)
        {
            bool _found = false;
            foreach (tblFunction tblfunction in tblSolution.m_tblSolution().m_tblFunctionCollection)
            {
                if ((tblfunction.IsFunction) && (tblfunction.FunctionName.ToLower() == _str.ToLower()))
                {
                    _tblfunction = tblfunction;
                    _found = true;
                    break;
                }
            }
            return _found;
        }

        bool IsOperator(string _str)
        {
            if ((_str == "!") ||
                (_str == "*") ||
                (_str == "/") ||
                (_str == "%") ||
                (_str == "+") ||
                (_str == "-") ||
                (_str == ">") ||
                (_str == "<") ||
                (_str == "=") ||
                (_str == "<>") ||
                (_str == ">=") ||
                (_str == "<=") ||
                (_str == "or") ||
                (_str == "and") ||
                (_str == "xor") ||
                (_str == ":=") ||
                (_str == ";"))
                return true;
            return false;
        }

        bool IsSeperator(string _str)
        {
            if ((_str == ")") ||
                (_str == "(") ||
                (_str == ","))
                return true;

            return false;
        }

        public void SendOutput(string _str)
        {
            Console.WriteLine(_str.ToString() + "  ");
            Console.WriteLine();


            //	throw  exception(_str.GetBuffer());
        }

        public void SendOutput(char _str)
        {
            Console.WriteLine(_str);
            Console.WriteLine();
            //throw  exception(_str);
        }

        

        bool ChectTokenIsComma(string _str)
        {
            if (_str == ",")
            {
                // Add Index of constant to Comma TokenType
                CToken tok = new CToken(_str);
                tok.m_token = Token_Type.Token_Comma;
                InfixTokenList.Add(tok);
                return true;
                //
            }
            return false;
        }

        bool ChectTokenIsLeftParenthisis(string _str)
        {
            if (_str == "(")
            {
                // Add Index of constant to LeftParenthesisTokenType
                CToken tok = new CToken(_str);
                tok.m_token = Token_Type.Token_LeftParenthisis;
                InfixTokenList.Add(tok);
                return true;
                //
            }
            return false;
        }


        bool ChectTokenIsRightParenthisis(string _str)
        {
            if (_str == ")")
            {
                // Add Index of constant to LeftParenthesisTokenType
                CToken tok = new CToken(_str);
                tok.m_token = Token_Type.Token_RightParenthisis;
                InfixTokenList.Add(tok);
                return true;
            }
            return false;
        }

        bool ChectTokenIsSemicolon(string _str)
        {
            if (_str == ";")
            {
                CToken tok = new CToken(_str);
                tok.m_token = Token_Type.Token_Operator;
                InfixTokenList.Add(tok);
                return true;
            }
            return false;
        }


        bool ChectTokenIsOperator(string _str)
        {

            if ((_str == "!") ||
                (_str == "*") ||
                (_str == "/") ||
                (_str == "%") ||
                (_str == "+") ||
                (_str == "-") ||
                (_str == ">") ||
                (_str == "<") ||
                (_str == "=") ||
                (_str == "<>") ||
                (_str == ">=") ||
                (_str == "<=") ||
                (_str == "or") ||
                (_str == "and") ||
                (_str == "xor") ||
                (_str == ":="))
            {
                // Add Index of constant to OperatorTokenType

                CTokenOperator tok = new CTokenOperator(_str);
                InfixTokenList.Add(tok);
                return true;
            }
            return false;
        }

        bool CheckTokenIsVariable(string _str/*,tblDisplay _tbldispaly*/)
        {
            //tblController _tblcontroller, tblPou _tblpou
            
            foreach (tblController _tblcontroller in tblSolution.m_tblSolution().m_tblControllerCollection)
            {
                foreach(tblPou _tblpou in _tblcontroller.m_tblPouCollection)
                {
                    if(_tblpou.pouName == "GLOBAL")
                    {
                        if( CheckTokenIsVariable( _str,  _tblcontroller,  _tblpou)) 
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        bool CheckTokenIsVariable(string _str, tblController _tblcontroller, tblPou _tblpou)
        {
            tblVariable _tblvariable;
            tblFormalParameter _tblformalparameter;
            bool islocal;
            bool isglobal;

            try
            {
                if (_tblpou != null)
                {
                    //string str = "";
                    _str = _str.ToLower();
                    string[] varname = _str.Split(new Char[] { '.' });
                    int count = varname.Length;
                    if ( (islocal= (_tblpou.CheckVariableExistInPou(varname[0], out _tblvariable) != 0)) || (isglobal =  (_tblcontroller.GetGlobalPOU().CheckVariableExistInPou(varname[0], out _tblvariable) != 0)) )
                    {
                        OBJECT_LIST crf = new OBJECT_LIST();
                        crf.ID = _tblvariable.VarNameID;
                        crf.Type = CRF_LOOKUP_Type.VARIABLE;
                        crf.ID1 = _tblpou.pouID;
                        crf.Type1 = CRF_LOOKUP_Type.POU;
                        _tblpou.Lookup.Add(crf);
                        if (count == 1)
                        {
                            CTokenVariable tok = new CTokenVariable(_str);
                            //tok.m_token = Token_Type.Token_Variable;
                            tok.Fill(_tblvariable, null);
                            tok.IsReference = true;
                            tok.HasSubPropety = 0;
                            if (islocal)
                            {
                                tok.pouID = _tblpou.pouID;
                            }
                            else
                            {
                                tok.pouID = _tblcontroller.GetGlobalPOU().pouID;
                            }
                            tok.controllerID = _tblcontroller.ControllerID;
                            tok.ReferneceType = (VarType)_tblvariable.Type;
                            InfixTokenList.Add(tok);
                            return true;
                        }
                        else
                        {
                            tblFunction tblfunction = tblSolution.m_tblSolution().GetFunctionbyType(_tblvariable.Type);
                            long _id = tblfunction.returnPinIDofUDFB(varname[1]);
                            if (tblfunction.CheckFormalparameterExistInFunction(varname[1], out _tblformalparameter))
                            {
                                if (count == 2)
                                {
                                    CTokenVariable tok = new CTokenVariable(_str);
                                    //tok.m_token = Token_Type.Token_Variable;
                                    tok.Fill(_tblvariable, _tblformalparameter);
                                    tok.pouID = _id;
                                    tok.IsReference = false;
                                    tok.HasSubPropety = 0;
                                    if (islocal)
                                    {
                                        tok.pouID = _tblpou.pouID;
                                    }
                                    else
                                    {
                                        tok.pouID = _tblcontroller.GetGlobalPOU().pouID;
                                    }
                                    tok.controllerID = _tblcontroller.ControllerID;
                                    tok.ReferneceType = (VarType)_tblformalparameter.Type;
                                    InfixTokenList.Add(tok);
                                    return true;
                                }
                                else
                                {
                                    if (count == 3)
                                    {
                                        //str = str.Remove(str.Length - 1, 1);
                                        if (varname[1] == "mode")
                                        {
                                            uint i = 1;
                                            MODE tmode;
                                            for (byte k = 0; k < 32; k++)
                                            {
                                                tmode = (MODE)i;
                                                if ((tblfunction.Mode & i) != 0)
                                                {
                                                    if (varname[2] == tmode.ToString().ToLower())
                                                    {
                                                        CTokenVariable tok = new CTokenVariable(_str);
                                                        //tok.m_token = Token_Type.Token_Variable;
                                                        tok.Fill(_tblvariable, _tblformalparameter);
                                                        tok.IsReference = false;
                                                        tok.HasSubPropety = 1;
                                                        if (islocal)
                                                        {
                                                            tok.pouID = _tblpou.pouID;
                                                        }
                                                        else
                                                        {
                                                            tok.pouID = _tblcontroller.GetGlobalPOU().pouID;
                                                        }
                                                        tok.controllerID = _tblcontroller.ControllerID;
                                                        tok.SubProperty = k;
                                                        tok.ReferneceType = VarType.BOOL;
                                                        InfixTokenList.Add(tok);
                                                        return true;
                                                    }
                                                }
                                                i *= 2;
                                            }
                                        }
                                        if (varname[1] == "state")
                                        {
                                            uint i = 1;
                                            BlockState blockstate;
                                            for (byte k = 0; k < 32; k++)
                                            {
                                                blockstate = (BlockState)i;
                                                if ((tblfunction.state & i) != 0)
                                                {
                                                    if (varname[2] == blockstate.ToString().ToLower())
                                                    {
                                                        CTokenVariable tok = new CTokenVariable(_str);
                                                        //tok.m_token = Token_Type.Token_Variable;
                                                        tok.Fill(_tblvariable, _tblformalparameter);
                                                        tok.IsReference = false;
                                                        tok.HasSubPropety = 1;
                                                        if (islocal)
                                                        {
                                                            tok.pouID = _tblpou.pouID;
                                                        }
                                                        else
                                                        {
                                                            tok.pouID = _tblcontroller.GetGlobalPOU().pouID;
                                                        }
                                                        tok.controllerID = _tblcontroller.ControllerID;
                                                        tok.SubProperty = k;
                                                        tok.ReferneceType = VarType.BOOL;
                                                        InfixTokenList.Add(tok);
                                                        return true;
                                                    }
                                                }
                                                i *= 2;
                                            }
                                        }

                                        if ((varname[1] == "als") ||
                                            (varname[1] == "ala") ||
                                            (varname[1] == "alb") ||
                                            (varname[1] == "aeb"))
                                        {
                                            uint i = 1;
                                            AlarmStatus tstatus;
                                            for (byte k = 0; k < 32; k++)
                                            {
                                                tstatus = (AlarmStatus)i;
                                                if ((tblfunction.Status & i) != 0)
                                                {
                                                    if (varname[2] == tstatus.ToString().ToLower())
                                                    {
                                                        CTokenVariable tok = new CTokenVariable(_str);
                                                        //tok.m_token = Token_Type.Token_Variable;
                                                        tok.Fill(_tblvariable, _tblformalparameter);
                                                        tok.IsReference = false;
                                                        tok.HasSubPropety = 1;
                                                        if (islocal)
                                                        {
                                                            tok.pouID = _tblpou.pouID;
                                                        }
                                                        else
                                                        {
                                                            tok.pouID = _tblcontroller.GetGlobalPOU().pouID;
                                                        }
                                                        tok.controllerID = _tblcontroller.ControllerID;
                                                        tok.SubProperty = k;
                                                        tok.ReferneceType = VarType.BOOL;
                                                        InfixTokenList.Add(tok);
                                                        return true;
                                                    }
                                                }
                                                i *= 2;
                                            }

                                        }
                                    }
                                    else
                                    {
                                        return false;
                                    }
                                }

                            }

                        }
                    }

                }

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }

        bool CheckTokenIsFBDPin(string _str, tblController _tblcontroller, tblPou _tblpou,long _id, ref tblFormalParameter _tblformalparameter1)
        {
            tblVariable _tblvariable;
            tblFormalParameter _tblformalparameter;
            //byte _subproperty;
            //string _subpropertytxt;
            //bool _isrefernce;

            try
            {
                if (_tblpou != null)
                {
                    string str = "";
                    _str = _str.ToLower();
                    string[] varname = _str.Split(new Char[] { '.' });
                    int count = varname.Length;
                    if ((_tblpou.CheckVariableExistInPou(varname[0], out _tblvariable) != 0) || (_tblcontroller.GetGlobalPOU().CheckVariableExistInPou(varname[0], out _tblvariable) != 0))
                    {
                        if (count == 1)
                        {
                            CTokenFBDPin tok = new CTokenFBDPin(_str);
                            tok.tblformalparameterPin = _tblformalparameter1;
                            tok.tblvariable = _tblvariable;
                            tok.tblformalparameterVariable = null;
                            tok.IsReference = true;
                            tok.HasSubPropety = 0;
                            tok.ReferneceType = (VarType)_tblvariable.Type;
                            tok.PinID = _id;
                            InfixTokenList.Add(tok);

                            // Add Comma TokenType
                            CToken tok3 = new CToken(",");
                            tok3.m_token = Token_Type.Token_Comma;
                            InfixTokenList.Add(tok3);
                            return true;
                        }
                        else
                        {
                            //long _id = -1;
                            tblFunction tblfunction = tblSolution.m_tblSolution().GetFunctionbyType(_tblvariable.Type);
                            if (tblfunction.CheckFormalparameterExistInFunction(varname[1], out _tblformalparameter))
                            {
                                if (count == 2)
                                {

                                    CTokenFBDPin tok = new CTokenFBDPin(_str);
                                    //tok.m_token = Token_Type.Token_Variable;
                                    tok.tblformalparameterPin = _tblformalparameter1;
                                    tok.tblvariable = _tblvariable;
                                    tok.tblformalparameterVariable = _tblformalparameter;
                                    tok.IsReference = false;
                                    tok.HasSubPropety = 0;
                                    tok.PinID = _id;
                                    tok.ReferneceType = (VarType)_tblformalparameter.Type;
                                    InfixTokenList.Add(tok);
                                    // Add Comma TokenType
                                    CToken tok3 = new CToken(",");
                                    tok3.m_token = Token_Type.Token_Comma;
                                    InfixTokenList.Add(tok3);
                                    return true;
                                }
                                else
                                {
                                    if (count == 3)
                                    {
                                       // str = str.Remove(str.Length - 1, 1);
                                        if (varname[1] == "mode")
                                        {
                                            uint i = 1;
                                            MODE tmode;
                                            for (byte k = 0; k < 32; k++)
                                            {
                                                tmode = (MODE)i;
                                                if ((tblfunction.Mode & i) != 0)
                                                {
                                                    if (varname[2] == tmode.ToString().ToLower())
                                                    {
                                                        CTokenFBDPin tok = new CTokenFBDPin(_str);
                                                        //tok.m_token = Token_Type.Token_Variable;
                                                        tok.tblformalparameterPin = _tblformalparameter1;
                                                        tok.tblvariable = _tblvariable;
                                                        tok.tblformalparameterVariable = _tblformalparameter;
                                                        tok.IsReference = false;
                                                        tok.HasSubPropety = 1;
                                                        tok.SubProperty = k;
                                                        tok.PinID = _id;
                                                        tok.ReferneceType = VarType.BOOL;
                                                        InfixTokenList.Add(tok);
                                                        // Add Comma TokenType
                                                        CToken tok3 = new CToken(",");
                                                        tok3.m_token = Token_Type.Token_Comma;
                                                        InfixTokenList.Add(tok3);
                                                        return true;
                                                    }
                                                }
                                                i *= 2;
                                            }
                                        }
                                        if (varname[1] == "state")
                                        {
                                            uint i = 1;
                                            BlockState blockstate;
                                            for (byte k = 0; k < 32; k++)
                                            {
                                                blockstate = (BlockState)i;
                                                if ((tblfunction.state & i) != 0)
                                                {
                                                    if (varname[2] == blockstate.ToString().ToLower())
                                                    {
                                                        CTokenFBDPin tok = new CTokenFBDPin(_str);
                                                       // tok.m_token = Token_Type.Token_Variable;
                                                        tok.tblformalparameterPin = _tblformalparameter1;
                                                        tok.tblvariable = _tblvariable;
                                                        tok.tblformalparameterVariable = _tblformalparameter;
                                                        tok.IsReference = false;
                                                        tok.HasSubPropety = 1;
                                                        tok.SubProperty = k;
                                                        tok.ReferneceType = VarType.BOOL;
                                                        InfixTokenList.Add(tok);
                                                        // Add Comma TokenType
                                                        CToken tok3 = new CToken(",");
                                                        tok3.m_token = Token_Type.Token_Comma;
                                                        InfixTokenList.Add(tok3);
                                                        return true;
                                                    }
                                                }
                                                i *= 2;
                                            }
                                        }

                                        if ((varname[1] == "als") ||
                                            (varname[1] == "ala") ||
                                            (varname[1] == "alb") ||
                                            (varname[1] == "aeb"))
                                        {
                                            uint i = 1;
                                            AlarmStatus tstatus;
                                            for (byte k = 0; k < 32; k++)
                                            {
                                                tstatus = (AlarmStatus)i;
                                                if ((tblfunction.Status & i) != 0)
                                                {
                                                    if (varname[2] == tstatus.ToString().ToLower())
                                                    {
                                                        CTokenFBDPin tok = new CTokenFBDPin(_str);
                                                       // tok.m_token = Token_Type.Token_Variable;
                                                        tok.tblformalparameterPin = _tblformalparameter1;
                                                        tok.tblvariable = _tblvariable;
                                                        tok.tblformalparameterVariable = _tblformalparameter;
                                                        tok.IsReference = false;
                                                        tok.HasSubPropety = 1;
                                                        tok.SubProperty = k;
                                                        tok.ReferneceType = VarType.BOOL;
                                                        InfixTokenList.Add(tok);
                                                        // Add Comma TokenType
                                                        CToken tok3 = new CToken(",");
                                                        tok3.m_token = Token_Type.Token_Comma;
                                                        InfixTokenList.Add(tok3);
                                                        return true;
                                                    }
                                                }
                                                i *= 2;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        return false;
                                    }
                                }
                            }
                        }
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }

        bool CheckTokenIsFunctionBlockInstance(ref int i, tblDisplay _tbldispaly)
        {
            foreach (tblController _tblcontroller in tblSolution.m_tblSolution().m_tblControllerCollection)
            {
                foreach(tblPou _tblpou in _tblcontroller.m_tblPouCollection)
                {
                    if(_tblpou.pouName == "GLOBAL")
                    {
                        if( CheckTokenIsFunctionBlockInstance( ref i,  _tblcontroller,  _tblpou)) 
                        {
                            return true;
                        }
                    }
                }
            }
            return false;

        }

        bool CheckTokenIsFunctionBlockInstance(ref int i, tblController _tblcontroller, tblPou _tblpou)
        {
            long _id = -1;
            tblFormalParameter _tblformalparameter1 = new tblFormalParameter();
            int j = 0;
            string _str = seperatedlist[i];
            bool insideFBD = false;
            int count = 0;
            tblVariable _tblvariable = null;
            string[] varname = _str.Split(new Char[] { '.' });
            count = varname.Count();
            if ((varname != null) && (count == 1))  // name only
            {
                _tblpou.CheckVariableExistInPou(varname[0].ToLower(), out _tblvariable);
                if (_tblvariable == null)
                {
                    _tblcontroller.GetGlobalPOU().CheckVariableExistInPou(varname[0].ToLower(), out _tblvariable);
                }
                if (_tblvariable != null)
                {
                    OBJECT_LIST crf = new OBJECT_LIST();
                    crf.ID = _tblvariable.VarNameID;
                    crf.Type = CRF_LOOKUP_Type.VARIABLE;
                    crf.ID1 = _tblpou.pouID;
                    crf.Type1 = CRF_LOOKUP_Type.POU;
                    _tblpou.Lookup.Add(crf);

                    tblFunction _tblfunction = tblSolution.m_tblSolution().GetFunctionbyType(_tblvariable.Type);
                    if (_tblfunction.IsFunction)
                    {
                        if (_tblfunction.Extensible)
                        {
                            CTokenFunctionEXInstance tok = new CTokenFunctionEXInstance(_str);
                            tok.tblvariable = _tblvariable;
                            tok.tblfunction = _tblfunction;
                            InfixTokenList.Add(tok);
                        }
                        else
                        {
                            CTokenFunctionInstance tok = new CTokenFunctionInstance(_str);
                            tok.tblvariable = _tblvariable;
                            tok.tblfunction = _tblfunction;
                            InfixTokenList.Add(tok);
                        }
                    }
                    else
                    {
                        CTokenFunctionBlockInstance tok = new CTokenFunctionBlockInstance(_str);
                        tok.tblvariable = _tblvariable;
                        tok.tblfunction = _tblfunction;
                        InfixTokenList.Add(tok);
                        //insideFBD = true;
                        //insideFBDCounter = 0;
                        if (((seperatedlist.Count - (i + 1) - 2) % 4) == 0)
                        {
                            j = (seperatedlist.Count - (i + 1) - 2) / 4;
                            if ((seperatedlist[i + 1] == "(") && (seperatedlist[seperatedlist.Count - 2] == ")"))
                            {
                                insideFBD = true;
                                for (int k = 0; k < (j - 1); k++)
                                {
                                    if (seperatedlist[k * 4 + 5] != ",")
                                    {
                                        insideFBD = false;
                                        
                                        _errorinfo.str += " missing comma";
                                        MainForm.Instance().AddError2ErrorWindow(_errorinfo);
                                        return false;
                                    }
                                }
                                if (insideFBD)
                                {
                                    for (int k = 0; k < j; k++)
                                    {
                                        if (seperatedlist[k * 4 + 3] != ":=")
                                        {
                                            insideFBD = false;
                                            _errorinfo.str += " input assignement";
                                            MainForm.Instance().AddError2ErrorWindow(_errorinfo);
                                            return false; ;
                                        }
                                    }
                                    if (insideFBD)
                                    {

                                        CToken tok2 = new CToken("(");
                                        tok2.m_token = Token_Type.Token_LeftParenthisis;
                                        InfixTokenList.Add(tok2);

                                        for (int k = 0; k < j; k++)
                                        {
                                            if (!((IsFBDPin(seperatedlist[k * 4 + 2], _tblfunction,ref _id, ref _tblformalparameter1) && CheckTokenIsFBDPin(seperatedlist[k * 4 + 4], _tblcontroller, _tblpou,_id, ref _tblformalparameter1))))
                                            {
                                                insideFBD = false;
                                                _errorinfo.str += " Pin " + seperatedlist[k * 4 + 2] + " or Variable " + seperatedlist[k * 4 + 4] + " does not exist";
                                                MainForm.Instance().AddError2ErrorWindow(_errorinfo);
                                                return false;
                                            }
                                            else
                                            {

                                            }
                                        }
                                        if (insideFBD)
                                        {
                                            // Add Index of constant to RightParenthesisTokenType
                                            CToken tok4 = new CToken(")");
                                            tok4.m_token = Token_Type.Token_RightParenthisis;
                                            InfixTokenList.Add(tok4);
                                            i = seperatedlist.Count;
                                            return true;
                                        }

                                    }

                                }
                                else
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                _errorinfo.str += " ( or )";
                                MainForm.Instance().AddError2ErrorWindow(_errorinfo);
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }

                    }
                }
                return false;
            }
            return false;
        }



        //bool IsVariable(string _str, tblDisplay _tbldisplay, ref tblVariable _tblvariable, ref tblFormalParameter _tblformalparameter, ref byte _subproperty, ref string _subpropertytxt, ref bool _isrefernce)
        //{
        //    try
        //    {
        //        foreach (tblController tblcontroller in tblSolution.m_tblSolution().m_tblControllerCollection)
        //        {
        //            if (tblcontroller.GetGlobalPOU().IsVariable(_str, ref _tblvariable, ref _tblformalparameter, ref _subpropertytxt, ref _subproperty, ref _isrefernce))
        //            {
        //                return true;
        //            }
        //        }
        //        return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    return false;
        //}

        int op_preced(string str)
        {

            //1 14	()   []   ->   .   ::	Grouping, scope, array/member access
            if ((str == "[") || (str == "]"))
                return 14;
            //2 13	 !   ~   -   +   *   &   sizeof   type cast ++x   --x  	(most) unary operations, sizeof and type casts
            if ((str == "!"))
                return 13;
            //3 12	*   /   %	Multiplication, division, modulo
            if ((str == "*") || (str == "/"))
                return 12;
            //4 11	+   -	Addition and subtraction
            if ((str == "+") || (str == "-"))
                return 11;
            //5 10	<<   >>	Bitwise shift left and right

            //6  9	<   <=   >   >=	Comparisons: less-than, ...
            if ((str == "<") || (str == ">") || (str == "<=") || (str == ">="))
                return 9;
            //7  8 	==   !=	Comparisons: equal and not equal
            if ((str == "=") || (str == "<>"))
                return 8;
            //8  7	&	Bitwise AND
            //9  6	^	Bitwise exclusive OR
            //10 5	|	Bitwise inclusive (normal) OR
            //11 4	&&	Logical 
            if ((str == "and"))
                return 4;
            //12 3	||	Logical OR
            if ((str == "or"))
                return 3;
            //13 2	 ?:   =   +=   -=   *=   /=   %=   &=   |=   ^=   <<=   >>=	Conditional expression (ternary) and assignment operators
            if ((str == ":="))
                return 2;
            //14 1	,	Comma operator
            if ((str == ";"))
                return 1;
            return 0;
        }

        bool op_left_assoc(string str)
        {
            if ((str == "*") || (str == "/") || (str == "+") || (str == "-") ||
                (str == "<") || (str == ">") || (str == "<=") || (str == ">=") ||
                (str == "=") || (str == "<>") ||
                (str == "xor") || (str == "and") || (str == "or") ||
                (str == ";")
                )
                return true;
            //7  8 	==   !=	Comparisons: equal and not equal
            if ((str == ":="))
                return false;

            return false;
        }

        int op_arg_count(string str)
        {
            if ((str == "*") ||
                (str == "/") ||
                (str == "+") ||
                (str == "-") ||
                (str == ">") ||
                (str == "<") ||
                (str == "=") ||
                (str == "<>") ||
                (str == ">=") ||
                (str == "<=") ||
                (str == "or") ||
                (str == "and") ||
                (str == "xor") ||
                (str == ":="))
                return 2;

            return 0;
        }

        bool IsFBDPin(string _pinname, tblFunction _tblfunction,ref long _id, ref tblFormalParameter _tblFormalParameter)
        {
            bool ret = false;
            if (!_tblfunction.IsFunction && !_tblfunction.IsStandard)
            {
                foreach (tblPou tblpou in tblSolution.m_tblSolution().Dummytblcontroller.m_tblPouCollection)
                {
                    if (tblpou.pouName.ToUpper() == _tblfunction.FunctionName.ToUpper())
                    {
                        foreach (tblVariable tblvariable in tblpou.m_tblVariableCollection)
                        {
                            if (_pinname.ToUpper() == tblvariable.VarName.ToUpper())
                            {
                                _id = tblvariable.VarNameID;
                                break;
                            }
                        }
                        break;
                    }
                }
            }
            else
            {
                _id = -1;
            }
            foreach (tblFormalParameter tblformalparameter in _tblfunction.m_tblFormalParameterCollection)
            {
                if (tblformalparameter.PinName.ToLower() == _pinname.ToLower())
                {
                    _tblFormalParameter = tblformalparameter;
                    ret = true;
                    break;
                }
            }
            return ret;
        }

        //public int Add2constantcollection(ValueObj _valueobj)
        //{
        //    int ret;
        //    if ((ret = CheckValueExistInConstantCollection(_valueobj)) == -1)
        //    {
        //        ValueObj valueobj = new ValueObj();
        //        valueobj.Val.UDINT = _valueobj.Val.UDINT;
        //        valueobj.ValueType = _valueobj.ValueType;
        //        constantcollection.Add(valueobj);
        //        return constantcollection.Count - 1;
        //    }
        //    return ret;
        //}

        public int Add2stringcollection(string _tok)
        {
            int ret = -1;
            string str = "";
            if (_tok.Length > Common.MAX_STRING_SIZE)
            {
                str = _tok.Substring(0, Common.MAX_STRING_SIZE);
            }
            else
            {
                str = _tok;
            }
            if ((ret = CheckStringExistInStringCollection(str)) == -1)
            {
                stringcollection.Add(str);
                return stringcollection.Count - 1;

            }
            else
            {
                return ret;
            }
        }

        //public int CheckValueExistInConstantCollection(ValueObj _valueobj)
        //{
        //    for (int i = 0; i < (int)constantcollection.Count; i++)
        //    {
        //        if ((_valueobj.ValueType == constantcollection[i].ValueType) && (_valueobj.Val.UDINT == constantcollection[i].Val.UDINT))
        //        {
        //            return i;
        //        }
        //    }
        //    return -1;
        //}

        public int CheckStringExistInStringCollection(string str)
        {

            for (int i = 0; i < (int)stringcollection.Count; i++)
            {

                if (stringcollection[i] == str)
                {
                    return i;
                }
            }
            return -1;

        }

        bool Tokenize(tblController tblcontroller, tblPou tblpou)
        {
            bool _noerror = true;
   
           // ValueObj valueobj = new ValueObj();
           // bool ret1, ret3;
            bool ret2;
            int i = 0;
           // int j = 0;
            

            try
            {
                string strtok1;
                i = 0;
                while (i < seperatedlist.Count)
                {
                    strtok1 = seperatedlist[i];
                    if ((i < (seperatedlist.Count - 1)) && (seperatedlist[i + 1] == "(") && CheckTokenIsFunction(seperatedlist[i]))
                    {
                        i++;
                        continue;
                    }
                    if (ChectTokenIsComma(seperatedlist[i]))
                    {
                        i++;
                        continue;
                    }
                    if (ChectTokenIsOperator(seperatedlist[i]))
                    {
                        i++;
                        continue;
                    }
                    if (ChectTokenIsLeftParenthisis(seperatedlist[i]))
                    {
                        i++;
                        continue;
                    }
                    // If the token is a right parenthesis:CVar_ANY_ELEMENTARY
                    if (ChectTokenIsRightParenthisis(seperatedlist[i]))
                    {
                        i++;
                        continue;
                    }
                    if (ChectTokenIsSemicolon(seperatedlist[i]))
                    {
                        i++;
                        continue;
                    }
                    if (CheckTokenIsString(seperatedlist[i]))
                    {
                        i++;
                        continue;
                    }
                    if (ret2 = CheckTokenIsValue(seperatedlist[i].ToLower()))
                    {
                        i++;
                        continue;
                    }
                    if (!((i < (seperatedlist.Count - 1)) && (seperatedlist[i + 1] == "(")) && CheckTokenIsVariable(seperatedlist[i], tblcontroller, tblpou))
                    {
                        i++;
                        continue;
                    }
                    if (((i < (seperatedlist.Count - 1)) && ((seperatedlist[i + 1] == "("))) && (CheckTokenIsFunctionBlockInstance(ref i, tblcontroller, tblpou)))
                    {
                        i++;
                        continue;
                    }
                    //if ((i < (seperatedlist.Count - 1)) && (seperatedlist[i + 1] == "(") && CheckTokenIsFunction(seperatedlist[i]))
                    //{
                    //    i++;
                    //    continue;
                    //}
                    //if (ChectTokenIsComma(seperatedlist[i]))
                    //{
                    //    i++;
                    //    continue;
                    //}
                    //if (ChectTokenIsOperator(seperatedlist[i]))
                    //{
                    //    i++;
                    //    continue;
                    //}
                    //if (ChectTokenIsLeftParenthisis(seperatedlist[i] ))
                    //{
                    //    i++;
                    //    continue;
                    //}
                    //// If the token is a right parenthesis:CVar_ANY_ELEMENTARY
                    //if (ChectTokenIsRightParenthisis(seperatedlist[i]))
                    //{
                    //    i++;
                    //    continue;
                    //}
                    //if (ChectTokenIsSemicolon(seperatedlist[i]))
                    //{
                    //    i++;
                    //    continue;
                    //}
                    
                    _noerror = false;
                    break;
                }
                return _noerror;
            }
            catch (Exception ex)
            {
                DCS.Forms.MainForm.Instance().WriteToOutputWindows(ex.Message);
            }
            finally
            {
                seperatedlist.Clear();

            }
            return _noerror;
        }


        bool Tokenize(tblDisplay tbldisplay)
        {
            bool _noerror = true;

            // ValueObj valueobj = new ValueObj();
            // bool ret1, ret3;
            bool ret2;
            int i = 0;
            // int j = 0;
            string strtok;

            try
            {
                i = 0;
                while (i < seperatedlist.Count)
                {
                    strtok = seperatedlist[i];
                    if (CheckTokenIsString(seperatedlist[i]))
                    {
                        i++;
                        continue;
                    }
                    if (ret2 = CheckTokenIsValue(seperatedlist[i].ToLower()))
                    {
                        i++;
                        continue;
                    }
                    if (!((i < (seperatedlist.Count - 1)) && (seperatedlist[i + 1] == "(")) && CheckTokenIsVariable(seperatedlist[i]/*, tbldisplay*/))
                    {
                        i++;
                        continue;
                    }
                    if (((i < (seperatedlist.Count - 1)) && ((seperatedlist[i + 1] == "("))) && (CheckTokenIsFunctionBlockInstance(ref i, tbldisplay)))
                    {
                        i++;
                        continue;
                    }
                    if ((i < (seperatedlist.Count - 1)) && (seperatedlist[i + 1] == "(") && CheckTokenIsFunction(seperatedlist[i]))
                    {
                        i++;
                        continue;
                    }
                    if (ChectTokenIsComma(seperatedlist[i]))
                    {
                        i++;
                        continue;
                    }
                    if (ChectTokenIsOperator(seperatedlist[i]))
                    {
                        i++;
                        continue;
                    }
                    // If the token is a left parenthesis, then push it onto the stack.
                    if (ChectTokenIsLeftParenthisis(seperatedlist[i]))
                    {

                        i++;
                        continue;
                        //
                    }
                    // If the token is a right parenthesis:CVar_ANY_ELEMENTARY
                    if (ChectTokenIsRightParenthisis(seperatedlist[i]))
                    {
                        //
                        i++;
                        continue;
                    }
                    if (ChectTokenIsSemicolon(seperatedlist[i]))
                    {
                        i++;
                        continue;
                    }
                    _noerror = false;
                    break;
                }
                return _noerror;
            }
            catch (Exception ex)
            {
                DCS.Forms.MainForm.Instance().WriteToOutputWindows(ex.Message);
            }
            finally
            {
                seperatedlist.Clear();

            }

            return _noerror;
        }



        bool shunting_yard(string _retsstring)
        {

            Stack<int> _ArgCount = new Stack<int>();
            Stack<bool> _WereValues = new Stack<bool>();
            bool w;
            int argcount = 0;
            Stack<CToken> _Stack = new Stack<CToken>();
            int i = 0;
            int j = 0;
            //string strtok;
            //string str;
            //string str1;
            CToken tok;

            PRNTokenList.Clear();
            for (i = 0; i < InfixTokenList.Count; i++)
            {
                tok = InfixTokenList[i];
                // If the token is a number (identifier), then add it to the output queue.
                if ((tok.m_token == Token_Type.Token_String) || (tok.m_token == Token_Type.Token_Constant) || (tok.m_token == Token_Type.Token_Variable) || (tok.m_token == Token_Type.Token_FBDPin))
                {
                    PRNTokenList.Add(tok);

                    if (_WereValues.Count > 0)
                    {
                        _WereValues.Pop();
                        _WereValues.Push(true);
                    }
                }
                // If the token is a function token, then push it onto the stack.
                else
                {
                    if ((Token_Type.Token_Function == tok.m_token) ||
                        (Token_Type.Token_FunctionEX == tok.m_token) ||
                        (Token_Type.Token_FunctionInstance == tok.m_token) ||
                        (Token_Type.Token_FunctionEXInstance == tok.m_token) ||
                        (Token_Type.Token_FunctionBlockInstance == tok.m_token))
                    {
                        _Stack.Push(tok);
                        _ArgCount.Push(0);
                        // if (!_WereValues.empty())
                        if (_WereValues.Count > 0)
                        {
                            _WereValues.Pop();
                            _WereValues.Push(true);
                        }
                        _WereValues.Push(false);
                    }
                    // If the token is a function argument separator (e.g., a comma):
                    else
                    {
                        if (Token_Type.Token_Comma == tok.m_token)
                        {
                            j = _Stack.Count;
                            bool pe = false;
                            while (_Stack.Count > 0)
                            {
                                if (Token_Type.Token_LeftParenthisis == (_Stack.Peek()).m_token)
                                {
                                    pe = true;
                                    break;
                                }
                                else
                                {
                                    // Until the token at the top of the stack is a left parenthesis,
                                    // pop operators off the stack onto the output queue.
                                    ((CTokenOperator)_Stack.Peek()).NoOfOperands = op_arg_count((_Stack.Peek()).m_str);
                                    PRNTokenList.Add(_Stack.Peek());
                                    _Stack.Pop();
                                }
                            }
                            // If no left parentheses are encountered, either the separator was misplaced
                            // or parentheses were mismatched.
                            if (!pe)
                            {
                                DCS.Forms.MainForm.Instance().WriteToOutputWindows("Error: separator or parentheses mismatched", LogLevel.MAX);
                                return false;
                            }
                            w = _WereValues.Peek();
                            _WereValues.Pop();
                            if (w)
                            {
                                argcount = _ArgCount.Peek();
                                _ArgCount.Pop();
                                argcount++;
                                _ArgCount.Push(argcount);
                            }
                            _WereValues.Push(false);
                        }
                        // If the token is an operator, op1, then:
                        else
                        {
                            if (Token_Type.Token_Operator == tok.m_token)
                            {
                                //j = _Stack.GetCount();
                                while (_Stack.Count > 0)
                                {
                                    // While there is an operator token, op2, at the top of the stack
                                    // op1 is left-associative and its precedence is less than or equal to that of op2,
                                    // or op1 has precedence less than that of op2,
                                    // Let + and ^ be right associative.
                                    // Correct transformation from 1^2+3 is 12^3+
                                    // The differing operator priority decides pop / push
                                    // If 2 operators have equal priority then associativity decides.
                                    if ((Token_Type.Token_Operator == _Stack.Peek().m_token) &&
                                        (
                                        (op_left_assoc(tok.m_str) && (op_preced(tok.m_str) <= op_preced(_Stack.Peek().m_str))) ||
                                        (op_preced(tok.m_str) < op_preced(_Stack.Peek().m_str))
                                        )
                                        )
                                    {
                                        // Pop op2 off the stack, onto the output queue;
                                        ((CTokenOperator)_Stack.Peek()).NoOfOperands = op_arg_count(_Stack.Peek().m_str);
                                        PRNTokenList.Add(_Stack.Peek());
                                        _Stack.Pop();
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                // push op1 onto the stack.
                                if (tok.m_str != ";")
                                {
                                    _Stack.Push(tok);
                                }
                            }
                            // If the token is a left parenthesis, then push it onto the stack.
                            else
                            {
                                if (Token_Type.Token_LeftParenthisis == tok.m_token)
                                {
                                    _Stack.Push(tok);
                                }
                                // If the token is a right parenthesis:CVar_ANY_ELEMENTARY
                                else
                                {
                                    if (Token_Type.Token_RightParenthisis == tok.m_token)
                                    {
                                        bool pe = false;
                                        // Until the token at the top of the stack is a left parenthesis,
                                        // pop operators off the stack onto the output queue
                                        //j = _Stack.GetCount();
                                        while (_Stack.Count > 0)
                                        {
                                            //str = _Stack[j - 1];
                                            if (Token_Type.Token_LeftParenthisis == _Stack.Peek().m_token)
                                            {
                                                pe = true;
                                                break;
                                            }
                                            else
                                            {
                                                ((CTokenOperator)_Stack.Peek()).NoOfOperands = op_arg_count(_Stack.Peek().m_str);
                                                PRNTokenList.Add(_Stack.Peek());
                                                _Stack.Pop();
                                            }
                                        }
                                        // If the stack runs out without finding a left parenthesis, then there are mismatched parentheses.
                                        if (!pe)
                                        {
                                            //CParser::SendOutput(_T("Error: parentheses mismatched"));
                                            DCS.Forms.MainForm.Instance().WriteToOutputWindows("Error: parentheses mismatched", LogLevel.MAX);
                                            //CParser::SendOutput("Error: parentheses mismatched");
                                            return false;
                                        }
                                        // Pop the left parenthesis from the stack, but not onto the output queue.
                                        _Stack.Pop();

                                        // If the token at the top of the stack is a function token, pop it onto the output queue.
                                        if (_Stack.Count > 0)
                                        {
                                            if ((Token_Type.Token_Function == _Stack.Peek().m_token) ||
                                                (Token_Type.Token_FunctionEX == _Stack.Peek().m_token) ||
                                                (Token_Type.Token_FunctionInstance == _Stack.Peek().m_token) ||
                                                (Token_Type.Token_FunctionEXInstance == _Stack.Peek().m_token) ||
                                                (Token_Type.Token_FunctionBlockInstance == _Stack.Peek().m_token))
                                            {
                                                argcount = _ArgCount.Peek();
                                                _ArgCount.Pop();
                                                w = _WereValues.Peek();
                                                _WereValues.Pop();
                                                if (w)
                                                {
                                                    argcount++;
                                                }

                                                ((CTokenFunction)_Stack.Peek()).m_NoOfFunctionArguments = (byte)argcount;
                                                PRNTokenList.Add(_Stack.Peek());
                                                _Stack.Pop();
                                            }
                                        }
                                    }
                                    else
                                    {

                                        DCS.Forms.MainForm.Instance().WriteToOutputWindows("Error: Unknown token " + ((CTokenOperator)tok).m_str, LogLevel.MAX);
                                        return false; // Unknown token
                                    }
                                }
                            }
                        }
                    }
                }

            }
            //When there are no more tokens to read:
            //While there are still operator tokens in the stack:
            //j = _Stack.GetCount();
            while (_Stack.Count > 0)
            {
                //sc = stack[sl - 1];
                if ((Token_Type.Token_LeftParenthisis == _Stack.Peek().m_token) || (Token_Type.Token_RightParenthisis == _Stack.Peek().m_token))
                {
                    //CParser::SendOutput(_T("Error: parentheses mismatched"));
                    _retsstring = "Error: parentheses mismatched";
                    //CParser::SendOutput("Error: parentheses mismatched");
                    return false;
                }
                //str = _Stack[_Stack.GetCount()-1];
                if (Token_Type.Token_Operator == _Stack.Peek().m_token)
                {
                    ((CTokenOperator)_Stack.Peek()).NoOfOperands = op_arg_count(_Stack.Peek().m_str);
                    PRNTokenList.Add(_Stack.Peek());
                    _Stack.Pop();

                }
                else
                {
                    ((CTokenFunction)_Stack.Peek()).m_NoOfFunctionArguments = (byte)argcount;
                    PRNTokenList.Add(_Stack.Peek());
                    _Stack.Pop();
                }

                //_Stack.pop();
            }
            //wcout << " Output : ";
            //for (j = 0; j < PRNTokenList.GetCount(); j++)
            //{
            //    wcout << ((CToken*)PRNTokenList.GetAt(j))->m_str.GetString() << "  ";
            //}
            //wcout << endl;
            //wcout << endl;
            //wcout << endl;

            InfixTokenList.Clear();

            return true;
        }

        ////Homay-01/26/2014
        //public void ExceptionHandler(CompilerRunTimeEx ex)
        //{
        //    SendOutput(_T(ex.GetFullMessage()));
        //}




        //for checking an expression we must check:
        //number of operator arguments are correct
        //number of function arguments with fixed number of arguments are correct
        //for extensible functions which have variable number of arguments arguments must be more than 2




        bool ValidateNumberOfArguments(tblPou tblpou, string _retsstring)
        {
            bool _NoError = true;


            //VarType _vartype ;
            int i, j, count;
            CToken tok = new CToken();
            tok.m_token = Token_Type.Token_Constant;
            //Stack<int> _TokenTypestack = new Stack<int>();
            Stack<CToken> temptokenstack = new Stack<CToken>();
            //stack<gcroot<VarType>> _TokenTypestack;
            //count = m_TokenArray.GetCount();
            try
            {
                count = PRNTokenList.Count;
                for (i = 0; i < count; i++)
                {
                    if (_NoError == false)
                    {
                        break;
                    }
                    //tok = PRNTokenList[i];
                    //m_Tokenqueue.pop();
                    switch (PRNTokenList[i].m_token)
                    {
                        case Token_Type.Token_String:
                        case Token_Type.Token_Variable:
                        case Token_Type.Token_Constant:
                        case Token_Type.Token_FBDPin:
                            temptokenstack.Push(PRNTokenList[i]);
                            break;

                        case Token_Type.Token_Operator:

                            if (((CTokenOperator)PRNTokenList[i]).NoOfOperands > (int)temptokenstack.Count)
                            {
                                _NoError = false;
                                _errorinfo.str += ("operator " + PRNTokenList[i].m_str + " has wrong number of arguments");
                                MainForm.Instance().AddError2ErrorWindow(_errorinfo);
                                //DCS.Forms.MainForm.Instance().WriteToOutputWindows("operator " + PRNTokenList[i].m_str + " has wrong number of arguments", LogLevel.MAX);
                                return false;
                                //throw CompilerRunTimeEx(message);
                            }
                            for (j = 0; j < ((CTokenOperator)PRNTokenList[i]).NoOfOperands; j++)
                            {
                                temptokenstack.Pop();
                            }
                            if (PRNTokenList[i].m_str != ":=")
                            {
                                temptokenstack.Push(tok);
                            }


                            break;
                        case Token_Type.Token_FunctionBlockInstance:

                            if (((CTokenFunctionBlockInstance)PRNTokenList[i]).m_NoOfFunctionArguments > ((CTokenFunctionBlockInstance)PRNTokenList[i]).tblfunction.GetAllPossibleInputs())
                            {
                                //CParser::SendOutput(_T("function ")+((CTokenFunction*)tok)->m_tblfunction->FunctionName+_T(" has wrong number of arguments"));
                                _errorinfo.str += ("function block" + ((CTokenFunctionBlockInstance)PRNTokenList[i]).tblfunction.FunctionName + " has wrong number of arguments");
                                MainForm.Instance().AddError2ErrorWindow(_errorinfo);
                                //DCS.Forms.MainForm.Instance().WriteToOutputWindows("function block" + ((CTokenFunctionBlockInstance)PRNTokenList[i]).tblfunction.FunctionName + " has wrong number of arguments");
                                _NoError = false;
                                return false;
                            }
                            else
                            {
                                if (((CTokenFunctionBlockInstance)PRNTokenList[i]).m_NoOfFunctionArguments > temptokenstack.Count)
                                {
                                    _errorinfo.str += ("function block" + ((CTokenFunctionBlockInstance)PRNTokenList[i]).tblfunction.FunctionName + " has wrong number of arguments");
                                    MainForm.Instance().AddError2ErrorWindow(_errorinfo);
                                    //DCS.Forms.MainForm.Instance().WriteToOutputWindows("function block" + ((CTokenFunctionBlockInstance)PRNTokenList[i]).tblfunction.FunctionName + " has wrong number of arguments");
                                    _NoError = false;
                                    return false;
                                }
                                else
                                {
                                    for (j = 0; j < ((CTokenFunctionBlockInstance)PRNTokenList[i]).m_NoOfFunctionArguments; j++)
                                    {
                                        temptokenstack.Pop();
                                    }

                                    //temptokenstack.Push(tok);
                                }
                            }

                            break;
                        case Token_Type.Token_Function:
                            if (((CTokenFunction)PRNTokenList[i]).m_NoOfFunctionArguments != ((CTokenFunction)PRNTokenList[i]).tblfunction.GetNoOfInputs())
                            {
                                _errorinfo.str += ("function " + ((CTokenFunction)PRNTokenList[i]).tblfunction.FunctionName + " has wrong number of arguments");
                                MainForm.Instance().AddError2ErrorWindow(_errorinfo);
                                //DCS.Forms.MainForm.Instance().WriteToOutputWindows("function " + ((CTokenFunction)PRNTokenList[i]).tblfunction.FunctionName + " has wrong number of arguments");
                                _NoError = false;

                                return false;
                            }

                            for (j = 0; j < ((CTokenFunction)PRNTokenList[i]).m_NoOfFunctionArguments; j++)
                            {
                                temptokenstack.Pop();
                            }

                            temptokenstack.Push(tok);
                            break;

                        case Token_Type.Token_FunctionInstance:

                            if (((CTokenFunction)PRNTokenList[i]).m_NoOfFunctionArguments != ((CTokenFunction)PRNTokenList[i]).tblfunction.GetNoOfInputs())
                            {
                                _errorinfo.str += ("function " + ((CTokenFunction)PRNTokenList[i]).tblfunction.FunctionName + " has wrong number of arguments");
                                MainForm.Instance().AddError2ErrorWindow(_errorinfo);
                                //DCS.Forms.MainForm.Instance().WriteToOutputWindows("function " + ((CTokenFunction)PRNTokenList[i]).tblfunction.FunctionName + " has wrong number of arguments", LogLevel.MAX);
                                _NoError = false;
                                return false;
                            }

                            for (j = 0; j < ((CTokenFunction)PRNTokenList[i]).m_NoOfFunctionArguments; j++)
                            {
                                temptokenstack.Pop();
                            }

                            // temptokenstack.Push(tok);
                            break;

                        case Token_Type.Token_FunctionEX:
                            if ((((CTokenFunction)PRNTokenList[i]).m_NoOfFunctionArguments < ((CTokenFunction)PRNTokenList[i]).tblfunction.GetNoOfInputs()) ||
                                (((CTokenFunction)PRNTokenList[i]).m_NoOfFunctionArguments > (((CTokenFunction)PRNTokenList[i]).tblfunction.GetNoOfInputs()) + Common.MaxNumberOfExPins - 1))
                            {

                                _errorinfo.str += ("function " + ((CTokenFunction)PRNTokenList[i]).tblfunction.FunctionName + " has wrong number of arguments");
                                MainForm.Instance().AddError2ErrorWindow(_errorinfo);
                                //DCS.Forms.MainForm.Instance().WriteToOutputWindows("function " + ((CTokenFunction)PRNTokenList[i]).tblfunction.FunctionName + " has wrong number of arguments", 0);
                                _NoError = false;
                                return false;
                            }

                            for (j = 0; j < ((CTokenFunction)PRNTokenList[i]).m_NoOfFunctionArguments; j++)
                            {
                                temptokenstack.Pop();
                            }

                            temptokenstack.Push(tok);

                            break;
                        case Token_Type.Token_FunctionEXInstance:
                            if ((((CTokenFunction)PRNTokenList[i]).m_NoOfFunctionArguments < ((CTokenFunction)PRNTokenList[i]).tblfunction.GetNoOfInputs()) ||
                                (((CTokenFunction)PRNTokenList[i]).m_NoOfFunctionArguments > (((CTokenFunction)PRNTokenList[i]).tblfunction.GetNoOfInputs()) + Common.MaxNumberOfExPins - 1))
                            {
                                _errorinfo.str += ("function " + ((CTokenFunction)PRNTokenList[i]).tblfunction.FunctionName + " has wrong number of arguments");
                                MainForm.Instance().AddError2ErrorWindow(_errorinfo);
                                //DCS.Forms.MainForm.Instance().WriteToOutputWindows("function " + ((CTokenFunction)PRNTokenList[i]).tblfunction.FunctionName + " has wrong number of arguments", 0);
                                _NoError = false;

                                return false;
                            }

                            for (j = 0; j < ((CTokenFunction)PRNTokenList[i]).m_NoOfFunctionArguments; j++)
                            {
                                temptokenstack.Pop();
                            }

                            //temptokenstack.Push(tok);

                            break;
                    }
                }
                if (temptokenstack.Count > 1)
                {
                    temptokenstack.Clear();
                    _errorinfo.str += ("Unknown Error");
                    MainForm.Instance().AddError2ErrorWindow(_errorinfo);
                    //DCS.Forms.MainForm.Instance().WriteToOutputWindows("Unknown Error", 0);
                    _NoError = false;

                    return false;
                }

            }
            catch (Exception ex)
            {
                //ex.POULogic = _poulogic;
                //ex.Message += "[" + tok->m_str + "]";
                //throw ex;
                DCS.Forms.MainForm.Instance().WriteToOutputWindows(ex.Message, 0);
            }

            return _NoError;
        }

        bool ValidateArgumentsTypes(tblPou tblpou, int _returntype, string _retsstring)
        {

            bool _NoError = true;

            //int returntype = 0;
            int i, j, count;
            //CToken tok;
            int countsize;
            List<TypeReference> vartypelist = new List<TypeReference>();
            //VarType _vartype1;
            //VarType _vartype2;
            TypeReference _vartype = new TypeReference();

            Stack<TypeReference> temptokentypestack = new Stack<TypeReference>();
            //stack<VarType> _TokenTypestack;
            try
            {
                count = PRNTokenList.Count;
                for (i = 0; i < count; i++)
                {
                    if (_NoError == false)
                    {
                        break;
                    }


                    //m_Tokenqueue.pop();
                    switch (PRNTokenList[i].m_token)
                    {
                        case Token_Type.Token_String:
                        case Token_Type.Token_Variable:
                        case Token_Type.Token_Constant:
                        case Token_Type.Token_FBDPin:
                            temptokentypestack.Push(new TypeReference(PRNTokenList[i].GetTokenPinType(), PRNTokenList[i].IsReference));
                            break;
                        case Token_Type.Token_Operator:
                            vartypelist.Clear();
                            vartypelist.Add(new TypeReference());
                            vartypelist.Add(new TypeReference());

                            vartypelist[1] = temptokentypestack.Pop();
                            vartypelist[0] = temptokentypestack.Pop();
                            if (PRNTokenList[i].CheckArgumentValidity(ref vartypelist, ref _vartype, ref _retsstring))
                            {
                                if (PRNTokenList[i].m_str != ":=")
                                {
                                    temptokentypestack.Push(_vartype);
                                }
                            }
                            else
                            {
                                _NoError = false;
                            }

                            break;
                        case Token_Type.Token_FunctionBlockInstance:
                            vartypelist.Clear();
                            countsize = ((CTokenFunctionBlockInstance)PRNTokenList[i]).m_NoOfFunctionArguments;
                            for (j = 0; j < countsize; j++)
                            {
                                vartypelist.Add(new TypeReference());
                            }
                            for (j = countsize - 1; j >= 0; j--)
                            {
                                vartypelist[j] = temptokentypestack.Pop();
                            }
                            //if (!PRNTokenList[i].CheckArgumentValidity(ref vartypelist, ref _vartype, ref _retsstring))
                            //{
                            //    _NoError = false;
                            //}
                            for (j = 0; j < countsize; j++)
                            {
                                if (vartypelist[j].type == 0)
                                {
                                    _NoError = false;
                                    break;
                                }

                            }

                            break;
                        case Token_Type.Token_Function:
                            vartypelist.Clear();
                            countsize = ((CTokenFunction)PRNTokenList[i]).m_NoOfFunctionArguments;
                            for (j = 0; j < countsize; j++)
                            {
                                vartypelist.Add(new TypeReference());
                            }
                            for (j = countsize - 1; j >= 0; j--)
                            {
                                vartypelist[j] = temptokentypestack.Pop();
                            }
                            if (PRNTokenList[i].CheckArgumentValidity(ref vartypelist, ref _vartype, ref _retsstring))
                            {
                                ((CTokenFunction)PRNTokenList[i]).OverloadedType = _vartype.type;
                                temptokentypestack.Push(_vartype);
                            }
                            else
                            {
                                _NoError = false;
                            }
                            break;
                        case Token_Type.Token_FunctionEX:
                            vartypelist.Clear();
                            countsize = ((CTokenFunctionEX)PRNTokenList[i]).m_NoOfFunctionArguments;
                            for (j = 0; j < countsize; j++)
                            {
                                vartypelist.Add(new TypeReference());
                            }
                            for (j = countsize - 1; j >= 0; j--)
                            {
                                vartypelist[j] = temptokentypestack.Pop();
                            }
                            if (PRNTokenList[i].CheckArgumentValidity(ref vartypelist, ref _vartype, ref _retsstring))
                            {
                                ((CTokenFunctionEX)PRNTokenList[i]).OverloadedType = _vartype.type;
                                temptokentypestack.Push(_vartype);
                            }
                            else
                            {
                                _NoError = false;
                            }

                            break;
                        case Token_Type.Token_FunctionInstance:
                            vartypelist.Clear();
                            countsize = ((CTokenFunctionInstance)PRNTokenList[i]).m_NoOfFunctionArguments;
                            for (j = 0; j < countsize; j++)
                            {
                                vartypelist.Add(new TypeReference());
                            }
                            for (j = countsize - 1; j >= 0; j--)
                            {
                                vartypelist[j] = temptokentypestack.Pop();
                            }
                            if (PRNTokenList[i].CheckArgumentValidity(ref vartypelist, ref _vartype, ref _retsstring))
                            {
                                ((CTokenFunctionInstance)PRNTokenList[i]).OverloadedType = _vartype.type;
                                //temptokentypestack.Push(_vartype);
                            }
                            else
                            {
                                _NoError = false;
                            }

                            break;
                        case Token_Type.Token_FunctionEXInstance:
                            vartypelist.Clear();
                            countsize = ((CTokenFunctionEXInstance)PRNTokenList[i]).m_NoOfFunctionArguments;
                            for (j = 0; j < countsize; j++)
                            {
                                vartypelist.Add(new TypeReference());
                            }
                            for (j = countsize - 1; j >= 0; j--)
                            {
                                vartypelist[j] = temptokentypestack.Pop();
                            }
                            if (PRNTokenList[i].CheckArgumentValidity(ref vartypelist, ref _vartype, ref _retsstring))
                            {
                                ((CTokenFunctionEXInstance)PRNTokenList[i]).OverloadedType = _vartype.type;
                                //temptokentypestack.Push(_vartype);
                            }
                            else
                            {
                                _NoError = false;
                            }

                            break;
                    }
                }
                if (temptokentypestack.Count > 0)
                {

                    //returntype = (int)_TokenTypestack.top();
                    //_TokenTypestack.empty();
                    //if (_returntype != VarType.UNKNOWN)
                    //{
                    //    if (_NoError)
                    //    {
                    //        if (_returntype != returntype)
                    //        {
                    //            _retsstring = "Return Type Is not Correct";
                    //            _NoError = false;
                    //        }
                    //    }
                    //}
                }

                return _NoError;
            }
            catch (Exception ex)
            {
                //ex.POULogic = _poulogic;
                //ex.Message += "[" + tok->m_str + "]";
                //throw ex;
                DCS.Forms.MainForm.Instance().WriteToOutputWindows(ex.Message, 0);
            }

            return _NoError;

        }

        bool CompileExpression(tblController tblcontroller, tblPou tblpou, int _returntype, SimpleOperation simpleoperation, string _retsstring)
        {
            bool _NoError = true;
            int i, j, count;
            int countsize;
            List<CToken> operandlist = new List<CToken>();
            Stack<CToken> OperandStack = new Stack<CToken>();
            TICInstruction instruction;
            try
            {
                count = PRNTokenList.Count;
                for (i = 0; i < count; i++)
                {
                    if (_NoError == false)
                    {
                        break;
                    }
                    switch (PRNTokenList[i].m_token)
                    {
                        case Token_Type.Token_String:
                        case Token_Type.Token_Variable:
                        case Token_Type.Token_Constant:
                        case Token_Type.Token_FBDPin:
                            OperandStack.Push(PRNTokenList[i]);
                            break;
                        case Token_Type.Token_Operator:
                            operandlist.Clear();
                            operandlist.Add(new CToken());
                            operandlist.Add(new CToken());
                            operandlist[1] = OperandStack.Pop();
                            operandlist[0] = OperandStack.Pop();
                            instruction = new TICInstruction();
                            if (PRNTokenList[i].ReturnOperator(ref instruction, operandlist))
                            {
                                if (PRNTokenList[i].m_str != ":=")
                                {
                                    CTokenTempVariable tt = new CTokenTempVariable();
                                    tt.m_token = Token_Type.Token_TempValue;
                                    //tt.type = instruction.OperandList[0].type;
                                    tt.m_Type = instruction.Operator.ReturnType;
                                    tt.m_Index = instruction.OperandList[0].Index;
                                    OperandStack.Push(tt);
                                }
                                simpleoperation.instructionlist.Add(instruction);
                            }
                            else
                            {
                                _NoError = false;
                            }
                            break;
                        case Token_Type.Token_FunctionBlockInstance:
                            operandlist.Clear();
                            countsize = ((CTokenFunctionBlockInstance)PRNTokenList[i]).m_NoOfFunctionArguments;
                            for (j = 0; j < countsize; j++)
                            {
                                operandlist.Add(new CToken());
                            }
                            for (j = countsize - 1; j >= 0; j--)
                            {
                                operandlist[j] = OperandStack.Pop();
                            }
                            //operandlist.Add(PRNTokenList[i]);
                            instruction = new TICInstruction();
                            if (PRNTokenList[i].ReturnOperator(ref instruction, operandlist))
                            {

                                simpleoperation.instructionlist.Add(instruction);
                            }
                            else
                            {
                                _NoError = false;
                            }
                            break;
                        case Token_Type.Token_Function:
                            operandlist.Clear();
                            countsize = ((CTokenFunction)PRNTokenList[i]).m_NoOfFunctionArguments;
                            for (j = 0; j < countsize; j++)
                            {
                                operandlist.Add(new CToken());
                            }
                            for (j = countsize - 1; j >= 0; j--)
                            {
                                operandlist[j] = OperandStack.Pop();
                            }
                            instruction = new TICInstruction();
                            if (PRNTokenList[i].ReturnOperator(ref instruction, operandlist))
                            {
                                CTokenTempVariable tt = new CTokenTempVariable();
                                tt.m_token = Token_Type.Token_TempValue;
                                // tt.type = instruction.OperandList[0].type;
                                tt.m_Type = instruction.Operator.ReturnType;
                                tt.m_Index = instruction.OperandList[0].Index;
                                OperandStack.Push(tt);
                                simpleoperation.instructionlist.Add(instruction);
                            }
                            else
                            {
                                _NoError = false;
                            }
                            break;
                        case Token_Type.Token_FunctionEX:
                            operandlist.Clear();
                            countsize = ((CTokenFunctionEX)PRNTokenList[i]).m_NoOfFunctionArguments;
                            for (j = 0; j < countsize; j++)
                            {
                                operandlist.Add(new CToken());
                            }
                            for (j = countsize - 1; j >= 0; j--)
                            {
                                operandlist[j] = OperandStack.Pop();
                            }
                            instruction = new TICInstruction();
                            if (PRNTokenList[i].ReturnOperator(ref instruction, operandlist))
                            {
                                CTokenTempVariable tt = new CTokenTempVariable();
                                tt.m_token = Token_Type.Token_TempValue;
                                //tt.type = instruction.OperandList[0].type;
                                tt.m_Type = instruction.Operator.ReturnType;
                                tt.m_Index = instruction.OperandList[0].Index;
                                OperandStack.Push(tt);
                                simpleoperation.instructionlist.Add(instruction);
                            }
                            else
                            {
                                _NoError = false;
                            }
                            break;
                        case Token_Type.Token_FunctionInstance:
                            operandlist.Clear();
                            countsize = ((CTokenFunctionInstance)PRNTokenList[i]).m_NoOfFunctionArguments;
                            for (j = 0; j < countsize; j++)
                            {
                                operandlist.Add(new CToken());
                            }
                            for (j = countsize - 1; j >= 0; j--)
                            {
                                operandlist[j] = OperandStack.Pop();
                            }
                            instruction = new TICInstruction();
                            if (PRNTokenList[i].ReturnOperator(ref instruction, operandlist))
                            {

                                simpleoperation.instructionlist.Add(instruction);
                            }
                            else
                            {
                                _NoError = false;
                            }
                            break;
                        case Token_Type.Token_FunctionEXInstance:
                            operandlist.Clear();
                            countsize = ((CTokenFunctionEXInstance)PRNTokenList[i]).m_NoOfFunctionArguments;
                            for (j = 0; j < countsize; j++)
                            {
                                operandlist.Add(new CToken());
                            }
                            for (j = countsize - 1; j >= 0; j--)
                            {
                                operandlist[j] = OperandStack.Pop();
                            }
                            instruction = new TICInstruction();
                            if (PRNTokenList[i].ReturnOperator(ref instruction, operandlist))
                            {
                                simpleoperation.instructionlist.Add(instruction);
                            }
                            else
                            {
                                _NoError = false;
                            }
                            break;
                    }
                }
                if (OperandStack.Count == 1)
                {
                    instruction = new TICInstruction();
                    operandlist[0] = OperandStack.Pop();
                    ((CTokenTempVariable)operandlist[0]).AddRetrunOperator(ref instruction);
                    simpleoperation.instructionlist.Add(instruction);
                    //returntype = (int)_TokenTypestack.top();
                    //_TokenTypestack.empty();
                    //if (_returntype != VarType.UNKNOWN)
                    //{
                    //    if (_NoError)
                    //    {
                    //        if (_returntype != returntype)
                    //        {
                    //            _retsstring = "Return Type Is not Correct";
                    //            _NoError = false;
                    //        }
                    //    }
                    //}
                }

                return _NoError;
            }
            catch (Exception ex)
            {
                //ex.POULogic = _poulogic;
                //ex.Message += "[" + tok->m_str + "]";
                //throw ex;
                MessageBox.Show(ex.Message);
            }

            return _NoError;

        }

        bool extractOperations(SimpleOperation Parent, List<SimpleOperation> operations, StreamReader streamreader)
        {
            bool ret = true;
            string str = "";
            SimpleOperation simpleoperation = null;
            int linenumber = 0;
            string DebugString = "";
            //bool lastoperation = true;
            while (streamreader.Peek() >= 0)
            {
                str = streamreader.ReadLine();
                str = str.Trim();
                linenumber++;
                if (str.StartsWith("!"))
                {
                    if (str.StartsWith("!FBD"))
                    {
                        //strlog = "!FBD{FunctionBlock;" + str + ":" + drawobject.rectangle.Left.ToString() + "," + drawobject.rectangle.Top.ToString() +"}";
                        DebugString = str.Substring(4);
                        //string[] _strs = DebugString.Split(new Char[] { ',', '{', '}', ';', ':' });
                    }
                    continue;
                }
                else
                {
                    DebugString = linenumber.ToString();
                }
                if (str == "")
                {
                    continue;
                }
                if (IsIf(str))
                {
                    //lastoperation = false;
                    simpleoperation = new IfOperation();
                    simpleoperation.DebugInfo = "if at " + linenumber.ToString() + " : ";
                    ((IfOperation)simpleoperation).GetCondition(str);
                    extractOperations(simpleoperation, ((IfOperation)simpleoperation).ThenOperations, streamreader);
                    operations.Add(simpleoperation);
                }
                else
                {
                    if (IsElse(str))
                    {
                        //lastoperation = false;
                        Parent.DebugInfo = "if at " + linenumber.ToString() + " : ";

                        extractOperations(Parent, ((IfOperation)Parent).ElseOperations, streamreader);
                        ret = true;
                        return ret;
                    }
                    else
                    {
                        if ((IsEndif(str)) && (Parent is IfOperation))
                        {
                            //lastoperation = false;
                            ret = true;
                            return ret;
                            //break;
                        }
                        else
                        {
                            if (IsWhile(str))
                            {
                                //lastoperation = false;
                                simpleoperation = new WhileOperation();
                                simpleoperation.DebugInfo = "while at " + linenumber.ToString() + " : ";

                                ((WhileOperation)simpleoperation).GetCondition(str);
                                extractOperations(simpleoperation, ((WhileOperation)simpleoperation).WhileOperations, streamreader);
                                operations.Add(simpleoperation);
                            }
                            else
                            {
                                if ((IsWend(str)) && (Parent is WhileOperation))
                                {
                                    //lastoperation = false;
                                    ret = true;
                                    return ret;
                                    //break;
                                }
                                else
                                {
                                    simpleoperation = new SimpleOperation();
                                    simpleoperation.DebugInfo = DebugString;

                                    simpleoperation.OperationString = str;
                                    operations.Add(simpleoperation);
                                }
                            }
                        }
                    }
                }

            }
            return ret;

        }

        public bool CompileGraphicDispalyExpression(tblDisplay _tbldisplay, SimpleOperation simpleoperation, DisplayObjectParameters _Parameters)
        {
            bool ret = false;
            string _retsstring = "";
            int returntype = 0;
            string str1, str2, str3;
            if (Seperator(((SimpleOperation)simpleoperation).OperationString))
            {
                for (int i = 0; i < seperatedlist.Count; i++)
                {
                    //IEnumerable<List<string>> result = listOfListOfStrings.OrderBy(x => x.Length);
                    foreach (DisplayObjectParameter argst in _Parameters.list)
                    {
                        str1 = "@" + argst.Name;
                        str2 = argst.Assignment;
                        str3 = seperatedlist[i];
                        seperatedlist[i] = str3.Replace(str1, str2);
                    }
                }

                if (Tokenize(_tbldisplay))
                {
                    if (shunting_yard(_retsstring))
                    {
                        if (ValidateNumberOfArguments(null, _retsstring))
                        {
                            if (ValidateArgumentsTypes(null, returntype, _retsstring))
                            {
                                if (CompileExpression(null, null, returntype, simpleoperation, _retsstring))
                                {
                                    return true;
                                }
                                else
                                {
                                }
                            }
                            else
                            {
                            }
                        }
                        else
                        {
                        }
                    }
                    else
                    {
                    }
                }
                else
                {
                }
            }
            else
            {
            }
            return ret;

        }


        bool CompileSimplleOperation(tblController _tblcontroller, tblPou _tblpou, SimpleOperation simpleoperation, ref CrossReference lookup)
        {
            bool ret = false;
            string _retsstring = "";
            int returntype = 0;
            ErrorInfo _errorinfo = new ErrorInfo();
            _errorinfo.str = simpleoperation.DebugInfo;
            _errorinfo.ID = _tblpou.pouID;
            _errorinfo.type = _tblpou.Language;
            _errorinfo.ID_Type = CRF_LOOKUP_Type.POU;
            if (_errorinfo.type == PouLanguageType.FBD)
            {
                _retsstring = simpleoperation.DebugInfo;
                //strlog = "!FBD{FunctionBlock;" + str + ":" + drawobject.rectangle.Left.ToString() + "," + drawobject.rectangle.Top.ToString() +"}";
                string[] _strs = _retsstring.Split(new Char[] { ',', '{', '}', ';', ':' });
                if (_strs.Count() >= 4)
                {
                    _errorinfo.str = _strs[0] + " " + _strs[1];
                    _errorinfo.X = int.Parse(_strs[2]);
                    _errorinfo.Y = int.Parse(_strs[3]);
                }
            }
            if (Seperator(((SimpleOperation)simpleoperation).OperationString))
            {
                if (Tokenize(_tblcontroller, _tblpou))
                {
                    if (shunting_yard(_retsstring))
                    {
                        if (ValidateNumberOfArguments(_tblpou, _retsstring))
                        {
                            if (ValidateArgumentsTypes(_tblpou, returntype, _retsstring))
                            {
                                if (CompileExpression(_tblcontroller, _tblpou, returntype, simpleoperation, _retsstring))
                                {
                                    return true;
                                }
                                else
                                {
                                    DCS.Forms.MainForm.Instance().WriteToOutputWindows("Error compiling " + ((SimpleOperation)simpleoperation).OperationString, LogLevel.MAX);
                                }
                            }
                            else
                            {
                                DCS.Forms.MainForm.Instance().WriteToOutputWindows("Error compiling Types are not compatible" + ((SimpleOperation)simpleoperation).OperationString, LogLevel.MAX);
                            }
                        }
                        else
                        {
                            DCS.Forms.MainForm.Instance().WriteToOutputWindows("Error compiling wrong number of arguments" + ((SimpleOperation)simpleoperation).OperationString, LogLevel.MAX);
                        }
                    }
                    else
                    {
                        DCS.Forms.MainForm.Instance().WriteToOutputWindows("Error compiling wrong syntax" + ((SimpleOperation)simpleoperation).OperationString, LogLevel.MAX);
                    }
                }
                else
                {
                    _errorinfo = new ErrorInfo();
                    _errorinfo.ErrorNo = 0;
                    _errorinfo.str = "Unknown Token";
                    MainForm.Instance().AddError2ErrorWindow(_errorinfo);
                    //DCS.Forms.MainForm.Instance().WriteToOutputWindows("Tokenizer Error", LogLevel.MAX);
                }
            }
            else
            {
                DCS.Forms.MainForm.Instance().WriteToOutputWindows("Seperator Error");
            }



            return ret;

        }

        bool CompileOperations(tblController _tblcontroller, tblPou _tblpou, List<SimpleOperation> operations, ref CrossReference lookup)
        {
            bool ret = true;
            for (int i = 0; i < operations.Count; i++)
            {

                if (operations[i] is IfOperation)
                {
                    if (!CompileSimplleOperation(_tblcontroller, _tblpou, ((IfOperation)operations[i]).QString, ref lookup))
                    {
                        return false;
                    }
                    if (!CompileOperations(_tblcontroller, _tblpou, ((IfOperation)operations[i]).ThenOperations, ref  lookup))
                    {
                        return false;
                    }
                    if (!CompileOperations(_tblcontroller, _tblpou, ((IfOperation)operations[i]).ElseOperations, ref  lookup))
                    {
                        return false;
                    }
                }
                else
                {
                    if (operations[i] is SimpleOperation)
                    {
                        if (!CompileSimplleOperation(_tblcontroller, _tblpou, operations[i], ref  lookup))
                        {
                            return false;
                        }
                    }
                }
            }
            return ret;
        }


        public bool CompilePOU(tblPou _tblpou)
        {

            return CompilePOU(tblSolution.m_tblSolution().GetControllerFromID(_tblpou.ControllerID), _tblpou);

        }

        public bool CompilePOU(tblController _tblcontroller, tblPou _tblpou)
        {
            string filename;
            string Binfilename;
            //OPERAND _operand;
            bool ret = false;
            //int sz = 0;
            try
            {
                TimeSpan ts = new TimeSpan(DateTime.UtcNow.Ticks);
                double ms = ts.TotalMilliseconds;
                DCS.Forms.MainForm.Instance().WriteToOutputWindows("Compiling  " + _tblpou.pouName);

                _tblpou.Lookup.Clear();
                _tblpou.Lookup.Filename = "P" + _tblpou.pouID.ToString();
                // instructionlist.Clear();
                List<SimpleOperation> operations = new List<SimpleOperation>();
                //string str = "";
                filename = Common.ProjectPath + "\\LOGIC";
                filename += "\\";
                //filename += _tblcontroller.DomainID.ToString();
                //filename += "\\";
                filename += tblSolution.m_tblSolution().GetControllerFromID(_tblpou.ControllerID).ControllerName;
                filename += "\\";
                Binfilename = filename;
                filename += _tblpou.pouName + ".st";
                Binfilename += _tblpou.pouName + ".bi";
                //DCS.Forms.MainForm.Instance().WriteToOutputWindows("Open " + filename);

                //if (_tblpou.Type == (int) PROGRAM_LANGUAGE.ENUM_PROGRAM_LANGUAGE_FBD) 
                //{
                //    using (StreamReader streamreader = new StreamReader(filename))
                //    {
                //        ret = extractOperations(null, operations, streamreader);
                //    }
                //}


                if (File.Exists(filename))
                {
                    using (StreamReader streamreader = new StreamReader(filename))
                    {
                        ret = extractOperations(null, operations, streamreader);
                    }
                }

                TimeSpan ts2 = new TimeSpan(DateTime.UtcNow.Ticks);
                double ms2 = ts2.TotalMilliseconds;
                if (ret)
                {
                    ret = CompileOperations(_tblcontroller, _tblpou, operations, ref  _tblpou.Lookup);
                }
                else
                {
                    DCS.Forms.MainForm.Instance().WriteToOutputWindows("error in Compiling  " + _tblpou.pouName);
                    return false;
                }
                TimeSpan ts3 = new TimeSpan(DateTime.UtcNow.Ticks);
                double ms3 = ts3.TotalMilliseconds ;
                if (ret)
                {
                    try
                    {

                        FileStream _fs = null;
                        BinaryWriter bw = null;
                        if (_fs == null)
                        {
                            try
                            {
                                _fs = new FileStream(Binfilename, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write, System.IO.FileShare.None);
                                bw = new BinaryWriter(_fs);

                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                        }
                        StructFile sf;
                        //StructFile sf1;
                        //StructFile sf2;
                        DateTime datetime = DateTime.Now;

                        //sf1 = new StructFile(typeof(OPERATOR));
                        //sf2 = new StructFile(typeof(OPERAND));
                        LogicProgram logicprogram = new LogicProgram();
                        dt_t timestamp;
                        timestamp.dt = 0;
                        timestamp.res = 0;
                        timestamp.Year = (UInt16)datetime.Year;
                        timestamp.Month = (byte)datetime.Month;
                        timestamp.Day = (byte)datetime.Day;
                        timestamp.Hour = (byte)datetime.Hour;
                        timestamp.Minute = (byte)datetime.Minute;
                        timestamp.Second = (byte)datetime.Second;
                        logicprogram.TimeStamp = timestamp.dt;
                        logicprogram.Index = _tblpou.oIndex;
                        logicprogram.Size = GetOpertionsSize(operations);



                        sf = new StructFile(typeof(LogicProgram));
                        logicprogram.Signeture = 0x12345678;
                        logicprogram.Index = _tblpou.oIndex;
                        logicprogram.Type = 0;
                        logicprogram.ProgramType = 1;
                        logicprogram.ProgramLanguage = 0;
                        logicprogram.CycleTimeGroup = 0;

                        logicprogram.Signeture = Common.ntohi(logicprogram.Signeture);
                        logicprogram.Size = Common.ntohi(logicprogram.Size);
                        logicprogram.Index = Common.ntohi(logicprogram.Index);
                        logicprogram.Type = Common.ntohi(logicprogram.Type);
                        logicprogram.ProgramType = Common.ntohi(logicprogram.ProgramType);
                        logicprogram.ProgramLanguage = Common.ntohi(logicprogram.ProgramLanguage);
                        logicprogram.CycleTimeGroup = Common.ntohi(logicprogram.CycleTimeGroup);
                        sf.WriteStructure(bw, (object)logicprogram);

                        for (int i = 0; i < operations.Count; i++)
                        {
                            operations[i].Write2File(bw);
                        }


                        bw.Close();
                        bw = null;
                        _fs.Close();

                        _tblpou.Lookup.Save();
                        TimeSpan ts1 = new TimeSpan(DateTime.UtcNow.Ticks);
                        double ms1 = ts1.TotalMilliseconds;

                        DCS.Forms.MainForm.Instance().WriteToOutputWindows(_tblpou.pouName + " compiled successfully. duration :" + (ms1-ms).ToString() + " ms " + (ms2-ms).ToString() + " 2ms " + (ms3-ms).ToString() + " 3ms ");

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    DCS.Forms.MainForm.Instance().WriteToOutputWindows(_tblpou.pouName + " not compiled");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            return ret;
        }

        private int GetOpertionsSize(List<SimpleOperation> operations)
        {
            int logicprogramSize = 0;
            for (int i = 0; i < operations.Count; i++)
            {
                logicprogramSize += operations[i].Size();
            }
            return logicprogramSize;
        }

        public bool CompileController(tblController _tblcontroller)
        {
            bool ret = true;

            for (int i = 0; i < _tblcontroller.m_tblPouCollection.Count; i++)
            {
                if (_tblcontroller.m_tblPouCollection[i].pouName != "GLOBAL")
                {
                    //if (CompilePOU(_tblcontroller, _tblcontroller.m_tblPouCollection[i]))
                    if (CompilePOU(_tblcontroller.m_tblPouCollection[i]))
                    {

                    }
                    else
                    {
                        ret = false;
                    }
                }
            }

            return ret;
        }
        bool IsIf(string _str)
        {
            bool ret = false;
            _str = _str.ToLower();
            _str = _str.Trim();
            if (_str.StartsWith("if"))
            {
                ret = true;
            }

            return ret;
        }
        bool IsElse(string _str)
        {
            bool ret = false;
            _str = _str.ToLower();
            _str = _str.Trim();
            if (_str.StartsWith("else"))
            {
                ret = true;
            }

            return ret;
        }
        bool IsEndif(string _str)
        {
            bool ret = false;
            _str = _str.ToLower();
            _str = _str.Trim();
            if (_str.EndsWith(";"))
            {
                _str = _str.Substring(0, _str.Length - 1);
            }
            _str = _str.Trim();
            if (_str.StartsWith("end if"))
            {
                ret = true;
            }

            return ret;
        }
        bool IsWhile(string _str)
        {
            bool ret = false;
            _str = _str.ToLower();
            _str = _str.Trim();
            if (_str.StartsWith("while"))
            {
                ret = true;
            }

            return ret;
        }
        bool IsWend(string _str)
        {
            bool ret = false;
            _str = _str.ToLower();
            _str = _str.Trim();
            if (_str.StartsWith("end_while"))
            {
                ret = true;
            }

            return ret;
        }

        //public Compiler(MainForm _parent)
        //{
        //    DCS.Forms.MainForm.Instance() = _parent;
        //}

        public Compiler()
        {
            //DCS.Forms.MainForm.Instance() = null;// Common.Static_mainform;
        }
    }
}


/*
bool Tokenize(tblDisplay tblDisplay)
        {
            bool _noerror = true;
            tblVariable _tblvariable = new tblVariable();
            tblFormalParameter _tblformalparameter = new tblFormalParameter();
            tblFormalParameter _tblformalparameter1 = new tblFormalParameter();
            tblFunction _tblfunction = new tblFunction();
            bool insideFBD = false;
            ValueObj valueobj = new ValueObj();
            bool ret1, ret2, ret3;
            int i = 0;
            int j = 0;
            string strtok;
            string str = "";
            byte _subproperty = 0;
            string _subpropertytxt = "";
            bool _isrefernce = false;
            int ret;

            try
            {
                i = 0;
                while (i < seperatedlist.Count)
                {
                    strtok = seperatedlist[i];
                    if (ret1 = IsValueString(seperatedlist[i], ref str))
                    {
                        if ((ret = Add2stringcollection(strtok)) == -1)
                        {
                            _noerror = false;
                            break;
                        }
                        // Add index of string to stringtokenType
                        CTokenOperand tok = new CTokenOperand(_str);
                        tok.m_token = Token_Type.Token_String;
                        tok.m_Index = ret;
                        tok.m_Type = (int)VarType.STRING;
                        InfixTokenList.Add(tok);
                    }
                    else
                    {
                        if (ret2 = IsValue(seperatedlist[i].ToLower()))
                        {
                            // Add Index of constant to ConstantTokenType
                            CTokenOperand tok = new CTokenOperand(_str);
                            tok.m_token = Token_Type.Token_Constant;
                            tok.m_Index = valueobj.Val.LINT;
                            tok.m_Type = valueobj.ValueType;
                            InfixTokenList.Add(tok);
                        }
                        else
                        {
                            if (!((i < (seperatedlist.Count - 1)) && (seperatedlist[i + 1] == "(")) && (ret3 = IsVariable(seperatedlist[i], tblDisplay, ref _tblvariable, ref _tblformalparameter, ref  _subproperty, ref _subpropertytxt, ref _isrefernce)))
                            {
                                CTokenVariable tok = new CTokenVariable(seperatedlist[i]);
                                tok.m_token = Token_Type.Token_Variable;
                                tok.Fill(_tblvariable, _tblformalparameter);
                                if (_isrefernce)
                                {
                                    tok.IsReference = true;
                                    tok.HasSubPropety = 0;
                                    tok.ReferneceType = (VarType)_tblvariable.Type;
                                }
                                else
                                {
                                    tok.IsReference = false;
                                    if (_subpropertytxt != "")
                                    {
                                        tok.HasSubPropety = 1;
                                        tok.SubProperty = _subproperty;
                                    }
                                    else
                                    {
                                        tok.HasSubPropety = 0;
                                        tok.SubProperty = _subproperty;
                                    }
                                }
                                InfixTokenList.Add(tok);
                                //
                            }
                            else
                            {


                                if (IsFunction(seperatedlist[i], ref _tblfunction) && (i < (seperatedlist.Count - 1)) && (seperatedlist[i + 1] == "("))
                                {
                                    // Add Index of constant to FunctionTokenType
                                    if (_tblfunction.Extensible)
                                    {
                                        CTokenFunctionEX tok = new CTokenFunctionEX(seperatedlist[i]);
                                        tok.tblfunction = _tblfunction;
                                        InfixTokenList.Add(tok);
                                    }
                                    else
                                    {
                                        CTokenFunction tok = new CTokenFunction(seperatedlist[i]);
                                        tok.tblfunction = _tblfunction;
                                        InfixTokenList.Add(tok);
                                    }
                                    //
                                }
                                // If the token is a function argument separator (e.g., a comma):
                                else
                                {
                                    if (seperatedlist[i] == ",")
                                    {
                                        // Add Index of constant to Comma TokenType
                                        CToken tok = new CToken(seperatedlist[i]);
                                        tok.m_token = Token_Type.Token_Comma;
                                        InfixTokenList.Add(tok);

                                        //
                                    }
                                    // If the token is an operator, op1, then:
                                    else
                                    {
                                        if (IsOperator(seperatedlist[i]))
                                        {
                                            // Add Index of constant to OperatorTokenType
                                            if (seperatedlist[i] != ";")
                                            {
                                                CTokenOperator tok = new CTokenOperator(seperatedlist[i]);
                                                InfixTokenList.Add(tok);
                                            }
                                            //
                                        }
                                        // If the token is a left parenthesis, then push it onto the stack.
                                        else
                                        {
                                            if (seperatedlist[i] == "(")
                                            {
                                                // Add Index of constant to LeftParenthesisTokenType
                                                CToken tok = new CToken(seperatedlist[i]);
                                                tok.m_token = Token_Type.Token_LeftParenthisis;
                                                InfixTokenList.Add(tok);
                                                //
                                            }
                                            // If the token is a right parenthesis:CVar_ANY_ELEMENTARY
                                            else
                                            {
                                                if (seperatedlist[i] == ")")
                                                {
                                                    // Add Index of constant to RightParenthesisTokenType
                                                    CToken tok = new CToken(seperatedlist[i]);
                                                    tok.m_token = Token_Type.Token_RightParenthisis;
                                                    InfixTokenList.Add(tok);
                                                    //
                                                }
                                                else
                                                {
                                                    if (seperatedlist[i] == ";")
                                                    {
                                                        CToken tok = new CToken(seperatedlist[i]);
                                                        tok.m_token = Token_Type.Token_Operator;
                                                        InfixTokenList.Add(tok);
                                                    }
                                                    else
                                                    {
                                                        _noerror = false;
                                                        //throw CompilerRunTimeEx(" has error in [" + page_stack->Pop() + "], Unknown token :[" + m_TokenList[i] + "]");

                                                        //_retsstring = msg;
                                                        break;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }

                            }
                        }

                    }
                    //}

                    i++;
                }
                return _noerror;
            }
            catch (Exception ex)
            {
                DCS.Forms.MainForm.Instance().WriteToOutputWindows(ex.Message);
            }
            finally
            {
                seperatedlist.Clear();

            }

            return _noerror;
        }


*/