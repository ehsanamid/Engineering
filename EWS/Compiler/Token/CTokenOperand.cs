
using DCS;
using DCS.DCSTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DCS.Compile.Token
{
    class CTokenOperand: CToken
    {
        private long index;
        private int _type;

        public CTokenOperand()
        {
            
        }

        public CTokenOperand(string _str): base(_str)
        {
            //m_token = Token_Variable;
            //m_PropertyType = UNKNOWN;
        }

        

        public long m_Index
        {
            get
            {
                return index;
            }
            set
            {
                index = value;
            }
        }

        public int m_Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
            }
        }
        public override int GetTokenPinType()
        {
            return m_Type;
        }
    }
}

