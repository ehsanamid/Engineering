using DCS;
using DCS.DCSTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DCS.Compile.Token
{
    class CTokenFBDPin:CTokenOperand 
    {
        private VarType referencetype;
        public VarType ReferneceType
        {
            get
            {
                return referencetype;
            }
            set
            {
                referencetype = value;
            }
        }
        private tblFormalParameter _tblformalparameter;
        public tblFormalParameter tblformalparameter
        {
            get
            {
                return _tblformalparameter;
            }
            set
            {
                _tblformalparameter = value;
            }
        }

        private tblVariable _tblvariable;
        public tblVariable tblvariable
        {
            get
            {
                return _tblvariable;
            }
            set
            {
                _tblvariable = value;
            }
        }
        
        private byte subproperty;
        public byte SubProperty
        {
            get
            {
                return subproperty;
            }
            set
            {
                subproperty = value;
            }
        }

        private byte hassubpropety;
        public byte HasSubPropety
        {
            get
            {
                return hassubpropety;
            }
            set
            {
                hassubpropety = value;
            }
        }

        private long pinid;
        public long PinID
        {
            get
            {
                return pinid;
            }
            set
            {
                pinid = value;
            }
        }

        public tblFormalParameter tblformalparameterPin = new tblFormalParameter();
        public tblFormalParameter tblformalparameterVariable = new tblFormalParameter();
        
        public CTokenFBDPin()
        {
            m_token = Token_Type.Token_FBDPin;    
        }


        public CTokenFBDPin(String _str)
            : base(_str)
        {
            m_token = Token_Type.Token_FBDPin;
        }

        

        
        public override int GetTokenPinType()
        {
            if (HasSubPropety == 0)
            {
                if ((tblformalparameterVariable.Type & tblformalparameterPin.Type) == 0)
                {
                    return 0;
                }
                else
                {
                    return tblformalparameterVariable.Type;
                }
            }
            else
            {
                return (int)VarType.BOOL;
            }
        }
    }
}



