using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENG.Compiler.Token;

namespace ENG_Compiler_Collection
{
    class CTokenCollection
    {
        private List<CToken> M_Tokens;
        public List<CToken> m_Tokens
        {
            get { return M_Tokens; }
            set { M_Tokens = value; }
        }
        public CTokenCollection()
        {

        }




        public bool Add(CToken _tok)
        {
            m_Tokens.Add (_tok);
            return true;
        }

        public int GetCount()
        {
            return m_Tokens.Count ;
        }
        public CToken Get(int i)
        {
            
            return m_Tokens[i];
        }
        public bool ClearAll()
        {
            m_Tokens.Clear()  ;
            
            return true;
        }
    }
}


