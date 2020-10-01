using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCS.Tools
{
    /// <summary>
    /// Summary description for BinFile.
    /// </summary>
    public class StructBytes
    {
        private object _oStruct = null;
        private System.Type _oType = null;
       //FileStream _fs;

        public StructBytes(System.Type type)
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

        public byte[] StructToByteArray(object oStruct)
        {
            try
            {
                _oStruct = oStruct;
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


       
    }
}
