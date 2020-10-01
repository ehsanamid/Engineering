using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewCompiler.Collection
{
    class CLogicNode
    {
        private List<CPOULogic> M_ProgramLogics;
        public List<CPOULogic> m_ProgramLogics
        {
            get
            {
                return M_ProgramLogics;
            }
            set
            {
                M_ProgramLogics = value;
                // foreach( vector	<CPOULogic> obj in M_ProgramLogics)
                // {
                //  obj =value ;
                //}
            }
        }
        private List<CPOULogic> M_UDFunctionBlockLogics;
        public List<CPOULogic> m_UDFunctionBlockLogics
        {
            get
            {
                return M_UDFunctionBlockLogics;
            }
            set
            {
                
                    M_UDFunctionBlockLogics = value;
               
            }
        }
        private List <CPOULogic> M_UDFunctionLogics;
        public List<CPOULogic> m_UDFunctionLogics
        {
            get
            {
                return M_UDFunctionLogics;
            }
            set
            {
                
                    M_UDFunctionLogics = value;
            }
        }
        private String M_DomainName;
        public string m_DomainName
        {
            get
            {
                return M_DomainName;
            }
            set
            {
                M_DomainName = value;
            }
        }
        private String M_NodeName;
        public string m_NodeName
        {
            get
            {
                return M_NodeName;
            }
            set
            {
                M_NodeName = value;
            }
        }
        private byte M_NodeType;
        public byte m_NodeType
        {
            get
            {
                return M_NodeType;
            }
            set
            {
                M_NodeType = value;
            }
        }
        private byte M_NodeNo;
        public byte m_NodeNo
        {
            get
            {
                return M_NodeNo;
            }
            set
            {
                M_NodeNo = value;
            }
        }
        private long M_NodeID;
        public long m_NodeID
        {
            get
            {
                return M_NodeID;
            }
            set
            {
                M_NodeID = value;
            }
        }
        private CLogicNodeList M_Parent;
        public CLogicNodeList m_Parent
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
        private CConstantCollection M_NodeConstantCollection;
        public CConstantCollection m_NodeConstantCollection
        {
            get
            {
                return M_NodeConstantCollection;
            }
            set
            {
                M_NodeConstantCollection = value;
            }
        }
        private CStringCollection M_NodeStringCollection;
        public CStringCollection m_NodeStringCollection
        {
            get
            {
                return M_NodeStringCollection;
            }
            set
            {
                M_NodeStringCollection = value;
            }
        }
        private CBuffer M_6Buffer;
        public CBuffer m_6Buffer
        {
            get
            {
                return M_6Buffer;
            }
            set
            {
                M_6Buffer = value;
            }
        }
        private CBuffer M_8Buffer;
        public CBuffer m_8Buffer
        {
            get
            {
                return M_8Buffer;
            }
            set
            {
                M_8Buffer = value;
            }
        }

        public CLogicNode(CLogicNodeList _parent)
        {
            m_Parent = _parent;
            m_NodeConstantCollection = new CConstantCollection();
            m_NodeStringCollection = new CStringCollection();
            m_6Buffer = new CBuffer();
            m_8Buffer = new CBuffer();
        }


        public ~CLogicNode()
        {


            m_NodeConstantCollection = null;
            m_NodeStringCollection = null;
            m_6Buffer = null;
            m_8Buffer = null;
        }

        public bool Add(CPOULogic _obj)
        {
            m_ProgramLogics.Add (_obj);
            return true;
        }

        public bool AddUserDefinedFunctionBlock(CPOULogic _obj)
        {
            m_UDFunctionBlockLogics.Add (_obj);
            return true;
        }

        public bool AddUserDefinedFunction(CPOULogic _obj)
        {
            m_UDFunctionLogics.Add (_obj);
            return true;
        }

        public void Load()
        {

        }

        public int GetNoOfPrograms()
        {
            return (int)m_ProgramLogics.Count ;
        }

        public int GetNoOfUDFunctionBlocks()
        {
            return (int)m_UDFunctionBlockLogics.Count;
        }

        public int GetNoOfUDFunctions()
        {
            return (int)m_UDFunctionLogics.Count ;
        }

        public string GetProjectPath()
        {
            return m_Parent.GetProjectPath();
        }

        public CPOULogic GetPOU(int _index)
        {
            return m_ProgramLogics[_index];
        }

        public CPOULogic GetUDFunctionBlock(int _index)
        {
            return m_UDFunctionBlockLogics[_index];
        }
    }
}

//--------------------------------
