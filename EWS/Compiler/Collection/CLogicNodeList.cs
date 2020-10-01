using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace NewCompiler.Collection
{
    class CLogicNodeList
    {
        private CParser M_Parent;
        public CParser m_Parent
        {
            get
            {
                return M_Parent;
            }
            set
            {
                M_Parent = value;
            }
        }
        private List <CLogicNode> M_List;
        public List<CLogicNode> m_List
        {
            get
            {
                return M_List;
            }
            set
            {
                M_List = value;
            }
        }
        private CLogicNode M_OWS;
        public CLogicNode m_OWS
        {
            get
            {
                return M_OWS;
            }
            set
            {
                M_OWS = value;
            }
        }

        public CLogicNodeList(CParser _parent)
        {
            m_Parent = _parent;
            m_OWS = new CLogicNode(this);
            int a = -1;
            m_OWS.m_NodeNo = (byte)a ;
        }
        public ~CLogicNodeList()
        {
        }

        public bool Add(CLogicNode _obj)
        {
            m_List.Add(_obj );
            return true;
        }

        public void Load()
        {

        }

        public int GetNoOfNodes()
        {
            return m_List.Count;
        }

        public string GetProjectPath()
        {
            return m_Parent.FullPath;
        }
        public CLogicNode Get(int _index)
        {
            return m_List[_index];
        }

        //CVariable* CLogicNodeList::ReturnVar(int _nodeno,int _index)
        //{
        //	for(int k = 0 ; k < GetNoOfNodes() ; k++)
        //	{
        //		if(Get(k)->m_NodeNo == _nodeno)
        //		{
        //			for(int m = 0 ; m < Get(k)->GetNoOfPrograms() ; m++)
        //			{
        //				for(int n = 0 ; n < Get(k)->GetPOU(m)->m_variableList->Count() ; n++)
        //				{
        //					if(Get(k)->GetPOU(m)->m_variableList->m_Variables[n]->m_oIndex == _index)
        //					{
        //						return Get(k)->GetPOU(m)->m_variableList->m_Variables[n];
        //					}
        //				}
        //			}
        //		}
        //	}
        //	return NULL;
        //}
    }
}