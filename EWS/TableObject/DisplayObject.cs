using DCS.DCSTables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DCS.TableObject
{
#if EWSAPP
    public class DisplayObject
    {
        public DisplayObject(tblDisplay tocopy)
        {
            DisplayName = tocopy.DisplayName;
            Description = tocopy.Description;
            BackColor = tocopy.BackColor;
            Grid = tocopy.Grid;
            Grid_X = tocopy.Grid_X;
            Grid_Y = tocopy.Grid_Y;
            Snap = tocopy.Snap;
            Snap_X = tocopy.Snap_X;
            Snap_Y = tocopy.Snap_Y;
            Footer = tocopy.Footer;
            Prepair = tocopy.Prepair;
            Approved = tocopy.Approved;
            DocNo = tocopy.DocNo;
            SheetNo = tocopy.SheetNo;
            Description = tocopy.Description;
            Revision = tocopy.Revision;
            LastUpdate = tocopy.LastUpdate;
            Layer1Enable = tocopy.Layer1Enable;
            Layer1Lock = tocopy.Layer1Lock;
            Layer2Enable = tocopy.Layer2Enable;
            Layer2Lock = tocopy.Layer2Lock;
            Layer3Enable = tocopy.Layer3Enable;
            Layer3Lock = tocopy.Layer3Lock;
            Layer4Enable = tocopy.Layer4Enable;
            Layer4Lock = tocopy.Layer4Lock;
            Layer5Enable = tocopy.Layer5Enable;
            Layer5Lock = tocopy.Layer5Lock;
            Layer6Enable = tocopy.Layer6Enable;
            Layer6Lock = tocopy.Layer6Lock;
            Layer7Enable = tocopy.Layer7Enable;
            Layer7Lock = tocopy.Layer7Lock;
            Layer8Enable = tocopy.Layer8Enable;
            Layer8Lock = tocopy.Layer8Lock;
            TopPageID = tocopy.TopPageID;
            DownPageID = tocopy.DownPageID;
            LeftPageID = tocopy.LeftPageID;
            RightPageID = tocopy.RightPageID;
            Height = tocopy.Height;
            Width = tocopy.Width;

        }
        /// <remarks>SQL Type:System.String</remarks>
        private string _DisplayName = "";

        [DisplayName("Display Name")]
        [Category("General")]
        public string DisplayName
        {
            get
            {
                return _DisplayName;
            }
            set
            {
                _DisplayName = value;
            }
        }

        /// <remarks>SQL Type:System.Drawing.Color</remarks>
        private System.Drawing.Color _BackColor;

        [DisplayName("Back Color")]
        [Category("View")]
        public System.Drawing.Color BackColor
        {
            get
            {
                return _BackColor;
            }
            set
            {
                _BackColor = value;
            }
        }

        /// <remarks>SQL Type:System.Boolean</remarks>
        private bool _Grid;

        [DisplayName("Grid")]
        [Category("Drawing")]
        public bool Grid
        {
            get
            {
                return _Grid;
            }
            set
            {
                _Grid = value;
            }
        }

        /// <remarks>SQL Type:System.Int16</remarks>
        private short _Grid_X;

        [DisplayName("Grid_X")]
        [Category("Drawing")]
        public short Grid_X
        {
            get
            {
                return _Grid_X;
            }
            set
            {
                _Grid_X = value;
            }
        }

        /// <remarks>SQL Type:System.Int16</remarks>
        private short _Grid_Y;

        [DisplayName("Grid_Y")]
        [Category("Drawing")]
        public short Grid_Y
        {
            get
            {
                return _Grid_Y;
            }
            set
            {
                _Grid_Y = value;
            }
        }

        /// <remarks>SQL Type:System.Boolean</remarks>
        private bool _Snap;

        [DisplayName("Snap")]
        [Category("Drawing")]
        public bool Snap
        {
            get
            {
                return _Snap;
            }
            set
            {
                _Snap = value;
            }
        }

        /// <remarks>SQL Type:System.Int16</remarks>
        private short _Snap_X;

        [DisplayName("Snap_X")]
        [Category("Drawing")]
        public short Snap_X
        {
            get
            {
                return _Snap_X;
            }
            set
            {
                _Snap_X = value;
            }
        }

        /// <remarks>SQL Type:System.Int16</remarks>
        private short _Snap_Y;

        [DisplayName("Snap_Y")]
        [Category("Drawing")]
        public short Snap_Y
        {
            get
            {
                return _Snap_Y;
            }
            set
            {
                _Snap_Y = value;
            }
        }

        /// <remarks>SQL Type:System.Boolean</remarks>
        private bool _Footer;

        [DisplayName("Footer")]
        [Category("Footer")]
        public bool Footer
        {
            get
            {
                return _Footer;
            }
            set
            {
                _Footer = value;
            }
        }

        /// <remarks>SQL Type:System.String</remarks>
        private string _Prepair = "";

        [DisplayName("Prepair")]
        [Category("Footer")]
        public string Prepair
        {
            get
            {
                return _Prepair;
            }
            set
            {
                _Prepair = value;
            }
        }

        /// <remarks>SQL Type:System.String</remarks>
        private string _Approved = "";

        [DisplayName("Approved")]
        [Category("Footer")]
        public string Approved
        {
            get
            {
                return _Approved;
            }
            set
            {
                _Approved = value;
            }
        }

        /// <remarks>SQL Type:System.String</remarks>
        private string _DocNo = "";

        [DisplayName("Doc No")]
        [Category("Footer")]
        public string DocNo
        {
            get
            {
                return _DocNo;
            }
            set
            {
                _DocNo = value;
            }
        }

        /// <remarks>SQL Type:System.String</remarks>
        private string _SheetNo = "";

        [DisplayName("Sheet No")]
        [Category("Footer")]
        public string SheetNo
        {
            get
            {
                return _SheetNo;
            }
            set
            {
                _SheetNo = value;
            }
        }

        /// <remarks>SQL Type:System.String</remarks>
        private string _Description = "";

        [DisplayName("Description")]
        [Category("General")]
        public string Description
        {
            get
            {
                return _Description;
            }
            set
            {
                _Description = value;
            }
        }

        /// <remarks>SQL Type:System.Int32</remarks>
        private int _Revision;

        [DisplayName("Revision")]
        [Category("Document")]
        public int Revision
        {
            get
            {
                return _Revision;
            }
            set
            {
                _Revision = value;
            }
        }

        /// <remarks>SQL Type:System.Int64</remarks>
        private long _LastUpdate = -1;

        [DisplayName("Last Update")]
        [Category("Document")]
        public long LastUpdate
        {
            get
            {
                return _LastUpdate;
            }
            set
            {
                _LastUpdate = value;
            }
        }

        

        /// <remarks>SQL Type:System.Boolean</remarks>
        private bool _Layer1Enable;

        [DisplayName("Layer 1 Enable")]
        [Category("Layer")]
        public bool Layer1Enable
        {
            get
            {
                return _Layer1Enable;
            }
            set
            {
                _Layer1Enable = value;
            }
        }

        /// <remarks>SQL Type:System.Boolean</remarks>
        private bool _Layer1Lock;

        [DisplayName("Layer 1 Lock")]
        [Category("Layer")]
        public bool Layer1Lock
        {
            get
            {
                return _Layer1Lock;
            }
            set
            {
                _Layer1Lock = value;
            }
        }

        
        /// <remarks>SQL Type:System.Boolean</remarks>
        private bool _Layer2Enable;

        [DisplayName("Layer 2 Enable")]
        [Category("Layer")]
        public bool Layer2Enable
        {
            get
            {
                return _Layer2Enable;
            }
            set
            {
                _Layer2Enable = value;
            }
        }

        /// <remarks>SQL Type:System.Boolean</remarks>
        private bool _Layer2Lock;

        [DisplayName("Layer 2 Lock")]
        [Category("Layer")]
        public bool Layer2Lock
        {
            get
            {
                return _Layer2Lock;
            }
            set
            {
                _Layer2Lock = value;
            }
        }

        
        /// <remarks>SQL Type:System.Boolean</remarks>
        private bool _Layer3Enable;

        [DisplayName("Layer 3 Enable")]
        [Category("Layer")]
        public bool Layer3Enable
        {
            get
            {
                return _Layer3Enable;
            }
            set
            {
                _Layer3Enable = value;
            }
        }

        /// <remarks>SQL Type:System.Boolean</remarks>
        private bool _Layer3Lock;

        [DisplayName("Layer 3 Lock")]
        [Category("Layer")]
        public bool Layer3Lock
        {
            get
            {
                return _Layer3Lock;
            }
            set
            {
                _Layer3Lock = value;
            }
        }

        

        /// <remarks>SQL Type:System.Boolean</remarks>
        private bool _Layer4Enable;

        [DisplayName("Layer 4 Enable")]
        [Category("Layer")]
        public bool Layer4Enable
        {
            get
            {
                return _Layer4Enable;
            }
            set
            {
                _Layer4Enable = value;
            }
        }

        /// <remarks>SQL Type:System.Boolean</remarks>
        private bool _Layer4Lock;

        [DisplayName("Layer 4 Lock")]
        [Category("Layer")]
        public bool Layer4Lock
        {
            get
            {
                return _Layer4Lock;
            }
            set
            {
                _Layer4Lock = value;
            }
        }

        
        /// <remarks>SQL Type:System.Boolean</remarks>
        private bool _Layer5Enable;

        [DisplayName("Layer 5 Enable")]
        [Category("Layer")]
        public bool Layer5Enable
        {
            get
            {
                return _Layer5Enable;
            }
            set
            {
                _Layer5Enable = value;
            }
        }

        /// <remarks>SQL Type:System.Boolean</remarks>
        private bool _Layer5Lock;

        [DisplayName("Layer 5 Lock")]
        [Category("Layer")]
        public bool Layer5Lock
        {
            get
            {
                return _Layer5Lock;
            }
            set
            {
                _Layer5Lock = value;
            }
        }

        

        /// <remarks>SQL Type:System.Boolean</remarks>
        private bool _Layer6Enable;

        [DisplayName("Layer 6 Enable")]
        [Category("Layer")]
        public bool Layer6Enable
        {
            get
            {
                return _Layer6Enable;
            }
            set
            {
                _Layer6Enable = value;
            }
        }

        /// <remarks>SQL Type:System.Boolean</remarks>
        private bool _Layer6Lock;

        [DisplayName("Layer 6 Lock")]
        [Category("Layer")]
        public bool Layer6Lock
        {
            get
            {
                return _Layer6Lock;
            }
            set
            {
                _Layer6Lock = value;
            }
        }

        

        /// <remarks>SQL Type:System.Boolean</remarks>
        private bool _Layer7Enable;

        [DisplayName("Layer 7 Enable")]
        [Category("Layer")]
        public bool Layer7Enable
        {
            get
            {
                return _Layer7Enable;
            }
            set
            {
                _Layer7Enable = value;
            }
        }

        /// <remarks>SQL Type:System.Boolean</remarks>
        private bool _Layer7Lock;

        [DisplayName("Layer 7 Lock")]
        [Category("Layer")]
        public bool Layer7Lock
        {
            get
            {
                return _Layer7Lock;
            }
            set
            {
                _Layer7Lock = value;
            }
        }

        
        /// <remarks>SQL Type:System.Boolean</remarks>
        private bool _Layer8Enable;

        [DisplayName("Layer 8 Enable")]
        [Category("Layer")]
        public bool Layer8Enable
        {
            get
            {
                return _Layer8Enable;
            }
            set
            {
                _Layer8Enable = value;
            }
        }

        /// <remarks>SQL Type:System.Boolean</remarks>
        private bool _Layer8Lock;

        [DisplayName("Layer 8 Lock")]
        [Category("Layer")]
        public bool Layer8Lock
        {
            get
            {
                return _Layer8Lock;
            }
            set
            {
                _Layer8Lock = value;
            }
        }

        /// <remarks>SQL Type:System.Int64</remarks>
        private long _TopPageID = -1;

        [DisplayName("Top Page ID")]
        [Category("Navigation")]
        public long TopPageID
        {
            get
            {
                return _TopPageID;
            }
            set
            {
                _TopPageID = value;
            }
        }

        /// <remarks>SQL Type:System.Int64</remarks>
        private long _DownPageID = -1;

        [DisplayName("Down Page ID")]
        [Category("Navigation")]
        public long DownPageID
        {
            get
            {
                return _DownPageID;
            }
            set
            {
                _DownPageID = value;
            }
        }

        /// <remarks>SQL Type:System.Int64</remarks>
        private long _LeftPageID = -1;

        [DisplayName("Left Page ID")]
        [Category("Navigation")]
        public long LeftPageID
        {
            get
            {
                return _LeftPageID;
            }
            set
            {
                _LeftPageID = value;
            }
        }

        /// <remarks>SQL Type:System.Int64</remarks>
        private long _RightPageID = -1;

        [DisplayName("Right Page ID")]
        [Category("Navigation")]
        public long RightPageID
        {
            get
            {
                return _RightPageID;
            }
            set
            {
                _RightPageID = value;
            }
        }

        /// <remarks>SQL Type:System.Int32</remarks>
        private int _Height;

        [DisplayName("Height")]
        [Category("Column")]
        public int Height
        {
            get
            {
                return _Height;
            }
            set
            {
                _Height = value;
            }
        }

        /// <remarks>SQL Type:System.Int32</remarks>
        private int _Width;

        [DisplayName("Width")]
        [Category("Column")]
        public int Width
        {
            get
            {
                return _Width;
            }
            set
            {
                _Width = value;
            }
        }

    } 
#endif
}
