using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewCompiler.Collection
{
    class CVariableList
    {
        private List<CVariable> M_Variables;
        public List<CVariable> m_Variables
        {
            get { return M_Variables; }
            set { M_Variables= value; }
        }

        public CVariableList()
        { 
            M_Variables = new List<CVariable>();
        }
        public ~CVariableList()
        {
        }

        public bool Lookup(String _str, CVariable _var)
        {
            for (int i = 0; i < (int)m_Variables.Count ; i++)
            {
                
                
                if (m_Variables[i].m_VarName.ToLower() == _str.ToLower())
                {
                    _var = m_Variables[i];
                    return true;
                }
            }
            return false;
        }

        public bool Lookup(String _str, int _varindex)
        {
            _varindex = -1;
            for (int i = 0; i < (int)m_Variables.Count ; i++)
            {
                if (m_Variables[i].m_VarName.ToLower() == _str.ToLower())
                {
                    _varindex = i;
                    return true;
                }
            }
            return false;
        }


        public bool Add(CVariable _var)
        {
            m_Variables.Add(_var);
            return true;
        }

        public int Count()
        {
            return m_Variables.Count;
        }
        //
        //DBKernel::VarType CVariableList::GetVarType(int _index)
        //{
        //	return m_Variables[_index]->m_VarType;
        //}

    }
}

