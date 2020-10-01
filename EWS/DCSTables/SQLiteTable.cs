using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DCS.DCSTables
{
    public class SQLiteTable : Object
    {
        static List<string> Headers = new List<string>();
        string headerstring = "";
        public string headerString
        {
            set
            {
                headerstring = value;
                Headers.Clear();
                string[] headers = headerstring.Split(new Char[] { ',' });
                for (int i = 0; i < headers.Count(); i++)
                {
                    Headers.Add(headers[i].ToLower());
                }
            }

        }
        public SQLiteTable() 
        {

        }

        public virtual bool PreDeleteTriger()
        {

            return true;
        }
        public virtual bool PostDeleteTriger()
        {

            return true;
        }
        public virtual bool PreInsertTriger()
        {

            return true;
        }
        public virtual bool PostInsertTriger()
        {

            return true;
        }
        public virtual bool PreUpdateTriger()
        {

            return true;
        }
        public virtual bool PostUpdateTriger()
        {

            return true;
        }

        //public void ImportStrings(string _header, List<string> importtext)
        //{
        //    hearderString = _header;
        //    foreach (string str in importtext)
        //    {
        //        string[] _strs = str.Split(new Char[] { ',' });
        //        AddFromString(_strs);
        //    }
        //}

        public virtual void AddFromString(string[] _row,string arg1,ref string arg2)
        {
            arg2 = "";
        }

        public int ColumnExistInHeader(string item)
        {
            int i;
            for (i = 0; i < Headers.Count(); i++)
            {
                if (Headers[i] == item.ToLower())
                {
                    return i;
                }
            }
            return -1;
        }
        public virtual void PreAddFromString(ref string arg2)
        {

        }

        public virtual void PostAddFromString(ref string arg2)
        {

        }

    }

    public class SQLiteTableCollection : System.Collections.CollectionBase
    {
        public virtual bool Load()
        {

            return false;
        }
    }
}
