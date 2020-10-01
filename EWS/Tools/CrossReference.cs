using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using DCS.Compile;

namespace DCS.Tools
{
    public class CrossReference
    {
        public CrossReference()
        {
            Lookup = new List<OBJECT_LIST>();
        }
        public List<OBJECT_LIST> Lookup;
        public string Filename;
        public  bool Load()
        {

            FileStream _fs = null;
            BinaryReader bw = null;
            if (_fs == null)
            {
                _fs = new FileStream(Filename, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Read, System.IO.FileShare.None);
                bw = new BinaryReader(_fs);
                int size = Marshal.SizeOf(typeof(OBJECT_LIST));
                byte[] bytes = new byte[size];

                while (true)
                {
                    if (bw.Read(bytes, 0, size) != size) // can't build this structure!
                    {
                        return false;
                    }
                    else
                    {
                        GCHandle handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
                        OBJECT_LIST crf_lookup = (OBJECT_LIST)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(OBJECT_LIST));
                        Lookup.Add(crf_lookup);
                    }
                }

            }
            return true;
        }
        public bool Save()
        {
            bool ret = false;
            try
            {
                FileStream _fs = null;
                BinaryWriter bw = null;
                if (_fs == null)
                {
                    _fs = new FileStream(Filename, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write, System.IO.FileShare.None);
                    bw = new BinaryWriter(_fs);

                }
                StructFile sf;
                sf = new StructFile(typeof(OBJECT_LIST));
                foreach (OBJECT_LIST crf in Lookup)
                {
                    sf.WriteStructure(bw, (object)crf);
                }


                bw.Close();
                bw = null;
                _fs.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            return ret;
        }
        public OBJECT_LIST Search(string tag)
        {
            OBJECT_LIST crf = new OBJECT_LIST();
            return crf;
        }

        public void Clear()
        {
            Lookup.Clear();
        }

        public void Add(OBJECT_LIST crf)
        {
            foreach (OBJECT_LIST _crf in Lookup)
            {
                if ((crf.ID == _crf.ID) && (crf.Type == _crf.Type))
                {
                    return;
                }
            }
            Lookup.Add(crf);
        }
        
    }
}
