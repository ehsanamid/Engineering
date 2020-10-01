using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO ;
using EWS.DCSTables;
using EWS;

namespace ENG.Compiler.Token
{
    class TokenFBDInputPin :CToken
    {

        
        
        public TokenFBDInputPin (string _str )

        {
            m_str = _str;
            m_token = Token_Type.Token_Unknown;
        }
        public TokenFBDInputPin()
        {
            m_str = "";
            m_token = Token_Type.Token_Unknown;
        }

        
    //    public CToken oprator( CToken param)
    //{
    //    return this;
    //}

        
    }
}












