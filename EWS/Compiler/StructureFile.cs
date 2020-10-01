using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace DCS.Compile
{
    public class StructFile
    {
        private object _oStruct = null;
        private System.Type _oType = null;
        //private string _File = null;
        //FileStream _fs;

        public StructFile(System.Type type)
        {
            // _fs = __fs;
            _oType = type;
        }

        public int SizeofStructure(object oStruct)
        {
           
            try
            {
                _oStruct = oStruct;

                return Marshal.SizeOf(_oStruct);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return 0;
        }

        private byte[] StructToByteArray()
        {
            try
            {
                // This function copys the structure data into a byte[]
                byte[] buffer = new byte[Marshal.SizeOf(_oStruct)];									//Set the buffer ot the correct size

                GCHandle h = GCHandle.Alloc(buffer, GCHandleType.Pinned);					//Allocate the buffer to memory and pin it so that GC cannot use the space (Disable GC)
                Marshal.StructureToPtr(_oStruct, h.AddrOfPinnedObject(), false);				// copy the struct into int byte[] mem alloc 
                h.Free();																								//Allow GC to do its job

                return buffer;																							// return the byte[] . After all thats why we are here right.
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool WriteStructure(ref List<byte> bf, object oStruct)
        {
            _oStruct = oStruct;
            try
            {
                byte[] buf = StructToByteArray();

                for (int i = 0; i < buf.Length; i++)
                {
                    bf.Add(buf[i]);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool WriteStructure(BinaryWriter bw, object oStruct)
        {
            _oStruct = oStruct;
            try
            {
                byte[] buf = StructToByteArray();

                //BinaryWriter bw = new BinaryWriter(_fs);

                bw.Write(buf);

                //bw.Close();
                //bw = null;

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        // this method is for test and later I should modufy StructToByteArray and use it 
        public byte[] ReturnBufferStructure(object oStruct)
        {
            _oStruct = oStruct;
            try
            {
                byte[] buf = StructToByteArray();



                return buf;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
    }
}
