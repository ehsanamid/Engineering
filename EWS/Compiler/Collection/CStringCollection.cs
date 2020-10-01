using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DCS;

namespace DCS.Compile.Collection
{
    public class CStringCollection
    {
        private List<string> _stringcollectionlist;
        public List<string> StringCollectionList
        {
            get { return _stringcollectionlist; }
            set { _stringcollectionlist = value; }
        }

        //private CBuffer M_8localbuff;
        //public CBuffer m_8localbuff
        //{
        //    get { return M_8localbuff; }
        //    set { M_8localbuff = value; }
        //}

        //private CBuffer M_6localbuff;
        //public CBuffer m_6localbuff
        //{
        //    get { return M_6localbuff; }
        //    set { M_6localbuff = value; }
        //}

        public CStringCollection()
        {
            //m_8localbuff = new CBuffer();
            //m_6localbuff = new CBuffer();
            _stringcollectionlist = new List<string>();
        }
        
        public int Add(string _tok)
        {
            //int j = 0;
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
            if ((ret = CheckStringExist(str)) == -1)
            {
                this._stringcollectionlist.Add(str);
                return _stringcollectionlist.Count - 1;

            }
            else
            {
                //delete _obj;
                //  _obj = null;
                return ret;
            }
           // return 0;

        }

       

        public int CheckStringExist(string str)
        {

            for (int i = 0; i < (int)_stringcollectionlist.Count; i++)
            {

                if (_stringcollectionlist[i] == str)
                {
                    return i;
                }
            }
            return -1;

        }



        public int GetCount()
        {
            return (int)_stringcollectionlist.Count;
        }


        
        public bool Save()
        {
            //int j = 0;

            //try
            //{
            //    STRINGOBJ _strobj = new STRINGOBJ();
            //    int ptr = 0;
            //    int jj = 0;
            //    if (GetCount() > 0)
            //    {
            //        for (int i = 0; i < GetCount(); i++)
            //        {
                        
            //            m_List[i].Val.CopyTo(_strobj.Val ,0);

            //            _strobj.Len = m_List[i].Len;
            //            m_8localbuff.Add(_strobj.Val, _strobj.Len );
            //            m_6localbuff.Add(_strobj.Val, _strobj.Len);
                       
            //        }
            //    }
            //    return true;
            //}
            //catch (Exception ex)
            //{

            //    throw new Exception();
            //}
            return true;
        }

    }
}