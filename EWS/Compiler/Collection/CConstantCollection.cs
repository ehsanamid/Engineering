using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.InteropServices;
using DCS;

namespace DCS.Compile.Collection
{
    class CConstantCollection
    {
        private List<ValueObj> m_List;

        //private CBuffer m_8localbuff;
        //private CBuffer m_6localbuff;
        ////public CBuffer m_8localbuff
        ////{
        ////    get
        ////    {
        ////        return M_8localbuff;
        ////    }
        ////    set
        ////    {
        ////        M_8localbuff = value;
        ////    }
        ////}
        ////public CBuffer m_6localbuff
        ////{
        ////    get
        ////    {
        ////        return M_6localbuff;
        ////    }
        ////    set
        ////    {
        ////        M_6localbuff = value;
        ////    }
        ////}
        //------------------------------
        public CConstantCollection()
        {
            //m_8localbuff = new CBuffer();
            //m_6localbuff = new CBuffer();
        }





        public int Add(ValueObj _valueobj)
        {
            int ret;
            if ((ret = CheckValueExist(_valueobj)) == -1)
            {
                ValueObj valueobj = new ValueObj();
                valueobj.Val.UDINT = _valueobj.Val.UDINT;
                valueobj.ValueType = _valueobj.ValueType;
                this.m_List.Add(valueobj);
                return m_List.Count  - 1;
            }
            return ret;
        }


        public int CheckValueExist(ValueObj _valueobj)
        {
            for (int i = 0; i < (int)m_List.Count ; i++)
            {
                if ((_valueobj.ValueType == m_List[i].ValueType) && (_valueobj.Val.UDINT == m_List[i].Val.UDINT))
                {
                    return i;
                }
            }
            return -1;
        }

        public ValueObj Get(int i)
        {
            return m_List[i];
        }

        public int GetCount()
        {
            return (int)m_List.Count ;
        }

       

        public bool Save()
        {
            //ValueObj [] _valobj8;
            //ValueObj[] _valobj6;
            //int ptr = 0;
            //ValueObj vobj;
            //int j = Marshal .SizeOf(vobj);
            //  //  sizeof(ValueObj);
            //VALUE e;
            //j = Marshal.SizeOf(e);
            //if (GetCount() > 0)
            //{
            //    for (int i = 0; i < GetCount(); i++)
            //    {
            //        _valobj8[i].ValueType = m_List[i].ValueType;
            //        _valobj8[i].Val.DINT = m_List[i].Val.DINT;

            //        /*memcpy(_buffer+ptr,(byte*)&_valobj,sizeof(VALUEOBJ));
            //        ptr += sizeof(VALUEOBJ);*/

            //        m_8localbuff.Add(((char)_valobj8), j);
            //        _valobj8[i].Reorder(_valobj6[i]);
            //        m_6localbuff.Add((char)_valobj6, j);
            //    }
            //}
            return true;
        }

    }
}


