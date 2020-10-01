using DCS;
using DCS.DCSTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DCS.Compile.Token
{
    class CTokenFunctionBlockInstance: CTokenFunction
    {
  

        public  CTokenFunctionBlockInstance()
        {
            m_token =Token_Type.Token_FunctionBlockInstance;
	        //tblfunction =new  DBKernel.Model .Function ();
        }
        public  CTokenFunctionBlockInstance(string _str)
        {
            m_token = Token_Type.Token_FunctionBlockInstance;
        }


        public override bool CheckArgumentValidity(ref List<TypeReference> _vartypelist, ref TypeReference retval, ref string _retsstring)
       {
           //bool _NoError = true;

           for (int i = 0; i < tblfunction.GetNoOfInputs(); i++)
           {
               if ((tblfunction.m_tblFormalParameterCollection[i].Class == 0) || (tblfunction.m_tblFormalParameterCollection[i].Class == 2))
               {
                   if (!((int)tblfunction.m_tblFormalParameterCollection[i].Type == (int)_vartypelist[i].type))
                   {
                       //CParser::SendOutput(_T("Incorrect argument type in function ")+ tblfunction->FunctionName);Homay-2/7/2014							
                       String message = "Incorrect argument type in function " + tblfunction.FunctionName + " " + tblfunction.m_tblFormalParameterCollection[i].PinName;
                       //throw new CompilerRunTimeEx(message);
                       //return UNKNOWN;Homay-2/7/2014
                       return false;
                   }
               }
           }
           
           
           return true;
       }
        public override bool ReturnOperator(ref TICInstruction _instruction, List<CToken> tokenlist)
        {

            OPERAND op = new OPERAND();
            //CToken tok;
            op.Index = this.tblvariable.VarNameID;
            _instruction.OperandList.Add(op);
            _instruction.Operator.NoOfArg = 1;

            if (!tblfunction.IsStandard)
            {
                op = new OPERAND();
                op.Token = (byte)Token_Type.Token_FBID;
                op.type = (int)VarType.ULINT;
                op.Index = tblfunction.UDPouID;
                op.PropertyNo = 0;
                //op.type = _instruction.Operator.ReturnType;
                _instruction.OperandList.Add(op);

                _instruction.Operator.NoOfArg++;


            }


            for (int i = 0; i < tokenlist.Count; i++)
            {
                _instruction.OperandList.Add(GetFinalOperator(tokenlist[i]));
                _instruction.Operator.NoOfArg++;
            }
            //_instruction.Operator.NoOfArg = (byte)(tokenlist.Count+1);
            switch (tblfunction.FunctionName.ToLower())
            {
                case "alarmanc":
                    _instruction.Operator.OpCode = (int)OPCODES.FBD_CALL_ALARMANC;
                    break;
                case "blink":
                    _instruction.Operator.OpCode = (int)OPCODES.FBD_CALL_BLINK;
                    break;
                case "cmp":
                    _instruction.Operator.OpCode = (int)OPCODES.FBD_CALL_CMP;
                    break;
                case "ctd": 
                    _instruction.Operator.OpCode = (int)OPCODES.FBD_CALL_CTD; 
                    break;
                case "ctu": 
                    _instruction.Operator.OpCode = (int)OPCODES.FBD_CALL_CTU; 
                    break;
                case "ctud": 
                    _instruction.Operator.OpCode = (int)OPCODES.FBD_CALL_CTUD; 
                    break;
                case "derivative": 
                    _instruction.Operator.OpCode = (int)OPCODES.FBD_CALL_DERIVATIVE;
                    break;
                case "f_trig": 
                    _instruction.Operator.OpCode = (int)OPCODES.FBD_CALL_F_TRIG; 
                    break;
                case "hysteresis": 
                    _instruction.Operator.OpCode = (int)OPCODES.FBD_CALL_HYSTERESIS;
                    break;
                case "integral": 
                    _instruction.Operator.OpCode = (int)OPCODES.FBD_CALL_INTEGRAL;
                    break;
                case "lag": 
                    _instruction.Operator.OpCode = (int)OPCODES.FBD_CALL_LAG; 
                    break;
                case "pid": 
                    _instruction.Operator.OpCode = (int)OPCODES.FBD_CALL_PID; 
                    break;
                case "pidcas": 
                    _instruction.Operator.OpCode = (int)OPCODES.FBD_CALL_PIDCAS;
                    break;
                case "pidovr": 
                    _instruction.Operator.OpCode = (int)OPCODES.FBD_CALL_PIDOVR;
                    break;
                case "r_trig": 
                    _instruction.Operator.OpCode = (int)OPCODES.FBD_CALL_R_TRIG;
                    break;
                case "ramp": 
                    _instruction.Operator.OpCode = (int)OPCODES.FBD_CALL_RAMP;
                    break;
                case "rs": 
                    _instruction.Operator.OpCode = (int)OPCODES.FBD_CALL_RS; 
                    break;
                case "rtc": 
                    _instruction.Operator.OpCode = (int)OPCODES.FBD_CALL_RTC;
                    break;
                case "selpri": 
                    _instruction.Operator.OpCode = (int)OPCODES.FBD_CALL_SELPRI; 
                    break;
                case "selread":
                    _instruction.Operator.OpCode = (int)OPCODES.FBD_CALL_SELREAD; 
                    break;
                case "sema": 
                    _instruction.Operator.OpCode = (int)OPCODES.FBD_CALL_SEMA; 
                    break;
                case "setpri": 
                    _instruction.Operator.OpCode = (int)OPCODES.FBD_CALL_SETPRI; 
                    break;
                case "sig_gen": 
                    _instruction.Operator.OpCode = (int)OPCODES.FBD_CALL_SIG_GEN; 
                    break;
                case "split": 
                    _instruction.Operator.OpCode = (int)OPCODES.FBD_CALL_SPLIT; 
                    break;
                case "sr": 
                    _instruction.Operator.OpCode = (int)OPCODES.FBD_CALL_SR; 
                    break;
                case "stackin": 
                    _instruction.Operator.OpCode = (int)OPCODES.FBD_CALL_STACKIN; 
                    break;
                case "swdout": 
                    _instruction.Operator.OpCode = (int)OPCODES.FBD_CALL_SWDOUT; 
                    break;
                case "swsout": 
                    _instruction.Operator.OpCode = (int)OPCODES.FBD_CALL_SWSOUT;
                    break;
                case "tof": 
                    _instruction.Operator.OpCode = (int)OPCODES.FBD_CALL_TOF;
                    break;
                case "ton": 
                    _instruction.Operator.OpCode = (int)OPCODES.FBD_CALL_TON; 
                    break;
                case "tp": 
                    _instruction.Operator.OpCode = (int)OPCODES.FBD_CALL_TP; 
                    break;
                case "tpls": 
                    _instruction.Operator.OpCode = (int)OPCODES.FBD_CALL_TPLS; 
                    break;
                case "tstp": 
                    _instruction.Operator.OpCode = (int)OPCODES.FBD_CALL_TSTP; 
                    break;
                case "wkhour": 
                    _instruction.Operator.OpCode = (int)OPCODES.FBD_CALL_WKHOUR;
                    break;
                case "totalizer": 
                    _instruction.Operator.OpCode = (int)OPCODES.FBD_CALL_TOTALIZER; 
                    break;
                case "ramp_gen": 
                    _instruction.Operator.OpCode = (int)OPCODES.FBD_CALL_RAMP_GEN; 
                    break;
                default:
                    _instruction.Operator.OpCode = (int)OPCODES.CALLFB;
                    break;
            }

            

            return true;
            //-----------------------------------------------------------------------------
        }
        
        //public override int GetTokenPinType()
       //{
       //    return (int)VarType.UNKNOWN;
       //}
    }
}
//--------------------------------------
