
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Text;
//using DocToolkit.Project_Objects;
using System.Drawing;
using DCS.DCSTables;
using DocToolkit;
using DCS.Forms;
using DCS.TypeConverters;


namespace DCS.Draw.FBD
{

    public enum Pin_Fields
    {
        PinName,
        Type,
        Class,
    }

    public class PinPort
    {
        public PinPort()
        {
            portrectangle.X = PortCenterPoint.X - Common.Portsize;
            portrectangle.Y = PortCenterPoint.Y - Common.Portsize;
            portrectangle.Height = Common.Portsize * 2 + 1;
            portrectangle.Width = Common.Portsize * 2 + 1;

        }

        Point portcenterpoint = new Point();
        public Point PortCenterPoint
        {
            get
            {
                return portcenterpoint;
            }
            set
            {
                portcenterpoint = value;
                portrectangle.X = portcenterpoint.X - Common.Portsize;
                portrectangle.Y = portcenterpoint.Y - Common.Portsize;
                portrectangle.Height = Common.Portsize * 2 + 1;
                portrectangle.Width = Common.Portsize * 2 + 1;
            }
        }

        Rectangle portrectangle = new Rectangle();
        public Rectangle PortRectangle
        {
            get
            {
                return portrectangle;
            }
            set
            {
                portrectangle = value;
            }
        }

        List<Guid> _wireconnectionid = new List<Guid>();
        [Browsable(false)]
        [ReadOnly(false)]
        public List<Guid> WireConnectionID
        {
            get
            {
                return _wireconnectionid;
            }
            set
            {
                _wireconnectionid = value;
            }
        }
        private bool _Connected;
        [DisplayName("Connected")]
        [Category("Column")]
        [Browsable(false)]
        [ReadOnly(true)]
        public bool Connected
        {
            get
            {
                if (_wireconnectionid.Count > 0)
                {
                    _Connected = true;
                }
                else
                {
                    _Connected = false;
                }
                return _Connected;

            }
        }

        public void AddConnectionToPort(Guid _guid)
        {
            WireConnectionID.Add(_guid);
        }

        public void RemoveConnection(Guid wireguid)
        {
            for (int i = 0; i < WireConnectionID.Count; i++)
            {
                if (WireConnectionID[i] == wireguid)
                {
                    WireConnectionID.RemoveAt(i);
                    break;
                }
            }
        }

        public bool PointOverPort(Point pt)
        {
            bool ret = false;
            ret = PortRectangle.Contains(pt);
            
            return ret;
        }
    }

    public class FBDPin
    {

        tblFormalParameter tblformalparameter ;

        //FBDboxObject Parent;
        
        public PinPort mPinPort = new PinPort();
        private int _PinNo;
        public int PinNo
        {
            get
            {
                return _PinNo;
            }
            set
            {
                _PinNo = value;
            }
        }

        public List<Guid> WireConnectionID
        {
            get
            {
                return mPinPort.WireConnectionID;
            }
            set
            {
                mPinPort.WireConnectionID = value;
            }
        }
        public bool Connected
        {
            get
            {
                
                return mPinPort.Connected;

            }
        }
        int _objecttype;
        public int ObjectType
        {
            get
            {
                return _objecttype;
            }
        }
        public int PinType
        {
            get
            {
                return tblformalparameter.Type;
            }
            set
            {
                tblformalparameter.Type = value;
            }

        }

        //public long  ConnectionID
        //{
        //    get
        //    {

        //        return mPinPort.WireConnectionID[0];

        //    }
        //}

        public Guid ConnectionGuid
        {
            get
            {

                return mPinPort.WireConnectionID[0];

            }
        }

        public string InitialValue
        {
            get
            {
                return tblformalparameter.InitializeValue;
            }
            set
            {
                tblformalparameter.InitializeValue = value;
            }
        }
        Rectangle pinrect = new Rectangle();
        public Rectangle PinRect
        {
            get
            {
                //if (LeftConnection)
                //{
                //    return new System.Drawing.Rectangle(X, Y - Common.BaseSize * Common.UnitSize / 2, Parent.BoxWidth / 2, Common.BaseSize * Common.UnitSize); ;
                //}
                //else
                //{
                //    return new System.Drawing.Rectangle(X - Parent.BoxWidth / 2, Y - Common.BaseSize * Common.UnitSize / 2, Parent.BoxWidth / 2, Common.BaseSize * Common.UnitSize);
                //}

                return pinrect;
            }
            set
            {
                pinrect = value;
            }
        }


        public Point PortCenterPoint
        {
            get
            {
                return mPinPort.PortCenterPoint;
            }
            set
            {
                mPinPort.PortCenterPoint = value;
            }
        }

        bool _isobject;
        public bool IsObject
        {
            get
            {
                return _isobject;
            }
            set
            {
                _isobject = value;
            }
        }

        public string PinName
        {
            get
            {
                if (!IsObject)
                {
                    return tblformalparameter.PinName;
                }
                else
                {
                    return "";
                }
            }
            
        }
        

        public void AddConnectionToPort(Guid _guid)
        {
            mPinPort.AddConnectionToPort(_guid);
        }

        public Guid GetRightGUID()
        {
            if (mPinPort.WireConnectionID.Count == 1)
            {
                return mPinPort.WireConnectionID[0];
            }
            else
            {
                return Guid.Empty;
            }
        }
        
        public bool PointOverPort(Point pt)
        {
            bool ret = false;
            ret = mPinPort.PortRectangle.Contains(pt);
            return ret;
        }

        public FBDPin()
        {

        }
        public FBDPin(tblFormalParameter _tblformalparameter, int _pinno)
        {
            _isobject = false;
            tblformalparameter = new tblFormalParameter(_tblformalparameter);
            _PinNo = _pinno;
        }

        public FBDPin(int _type, int _pinno)
        {
            _isobject = true;
            _objecttype = _type;
            _PinNo = _pinno;
        }
        //public FBDPin(FBDboxObject _parent)
        //{
        //   // Parent = _parent;
        //}

        public void RemoveConnection(Guid wireguid)
        {
            mPinPort.RemoveConnection(wireguid);
        }
        public bool IsInorInOut()
        {
            bool ret = false;
            if ((tblformalparameter.Class == (short)VarClass.Input) || (tblformalparameter.Class == (short)VarClass.InOut))
                ret = true;
            return ret;
        }

        public bool IsExtendablePin()
        {
            return tblformalparameter.Extensible;
        }

        bool visible;
        public bool Visible
        {
            get
            {
                return visible;
            }
            set
            {
                visible = value;
            }
        }



    }

    [TypeConverter(typeof(FBDObjectPinConverter))]
    public class FBDObjectPin : Object
    {

        #region Memebers

        public Point ConnectionPoint = new Point();
        //public Rectangle NameRect = new Rectangle();
        //public List<int> WireArray = new List<int>();

        public tblFormalParameter tblformalparameter = new tblFormalParameter();
        
        private int _PinNo;

        [DisplayName("Pin No")]
        [Category("Column")]
        [Browsable(false)]
        [ReadOnly(true)]
        public int PinNo
        {
            get
            {
                return _PinNo;
            }
            set
            {
                _PinNo = value;
            }
        }
        
        [Browsable(false)]
        [ReadOnly(true)]
        public Rectangle NameRect
        {
            get
            {
                if (LeftConnection)
                {
                    return new System.Drawing.Rectangle(X, Y - Common.BaseSize * Common.UnitSize / 2, Parent.BoxWidth / 2, Common.BaseSize * Common.UnitSize); ;
                }
                else
                {
                    return new System.Drawing.Rectangle(X - Parent.BoxWidth / 2, Y - Common.BaseSize * Common.UnitSize / 2, Parent.BoxWidth / 2, Common.BaseSize * Common.UnitSize);
                }
 
                
            }
        }

        private int _visiblepinno;
        [Browsable(false)]
        [ReadOnly(true)]
        public int VisiblePinNo
        {
            get
            {
                _visiblepinno = 0;
                for (int i = 0; i < _PinNo; i++)
                {
                    if (Parent.PinCollectionInput[i].Visible)
                    {
                        _visiblepinno++;
                    }
                }
                return _visiblepinno;
            }
        }

        private int _XOffset;
        [Browsable(false)]
        [ReadOnly(true)]
        public int XOffset
        {
            get
            {
                if (LeftConnection)
                {
                    _XOffset = 0;
                }
                else
                {
                    _XOffset = Parent.BoxWidth;
                }
                return _XOffset;
            }
        }

        private int _YOffset;
        [Browsable(false)]
        [ReadOnly(true)]
        public int YOffset
        {
            get
            {
                if (LeftConnection)
                {
                    _YOffset = Parent.BoxHeadHeight + Common.UnitSize * Common.BaseSize * (VisiblePinNo/*_PinNo*/) + Common.UnitSize * Common.BaseSize / 2;
                }
                else
                {
                    _YOffset = Parent.BoxHeight - Common.UnitSize * Common.BaseSize * (Parent.PinCollectionOutput.Count - VisiblePinNo/*_PinNo*/ - 1) - Common.UnitSize * Common.BaseSize / 2;
                }
                return _YOffset;
            }
        }

        [Browsable(false)]
        [ReadOnly(true)]
        public int X
        {
            get
            {
                return XOffset + Parent._rectangle.X;
            }
        }

        [Browsable(false)]
        [ReadOnly(true)]
        public int Y
        {
            get
            {
                return YOffset + Parent._rectangle.Y; ;
            }
        }
        private bool _Connected;

        [DisplayName("Connected")]
        [Category("Column")]
        [Browsable(false)]
        [ReadOnly(true)]
        public bool Connected
        {
            get
            {
                if (_wireconnectionid.Count > 0)
                {
                    _Connected = true;
                }
                else
                {
                    _Connected = false;
                }
                return _Connected;

            }
        }

        [Browsable(false)]
        [ReadOnly(true)]
        public bool LeftConnection
        {
            get
            {

                if (tblformalparameter.Class == (short)VarClass.Output)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        bool _Visible;
        [Browsable(true)]
        [ReadOnly(false)]
        public bool Visible
        {
            get
            {

                return _Visible;
            }
            set
            {
                _Visible = value;
                int count = 0;
                foreach (FBDObjectPin fbdobjectpin in Parent.PinCollectionInput)
                {
                    if (fbdobjectpin.Visible)
                    {
                        count++;
                    }
                }
                Parent.NoOfVisibleInputs = count;
                //Parent.UpdatePins();

            }
        }

        [DisplayName("Initialize Value")]
        [Category("Column")]
        public string InitializeValue
        {
            get
            {
                return tblformalparameter.InitializeValue;
            }
            set
            {
                tblformalparameter.InitializeValue = value;
            }
        }

        //List<string> _wireconnection = new List<string>();
        //[Browsable(true)]
        //[ReadOnly(false)]
        //public List<string> WireConnection
        //{
        //    get
        //    {
        //        return _wireconnection;
        //    }
        //    set
        //    {
        //        _wireconnection = value;
        //    }
        //}

        List<long> _wireconnectionid = new List<long>();
        [Browsable(false)]
        [ReadOnly(false)]
        public List<long> WireConnectionID
        {
            get
            {
                return _wireconnectionid;
            }
            set
            {
                _wireconnectionid = value;
            }
        }


        private string _othersidepinname = "";
        [Browsable(false)]
        public string OtherSidePinName
        {
            get
            {
                try
                {
                    return _othersidepinname;
                }
                catch (System.Exception err)
                {
                    throw new Exception("Error getting PinName", err);
                }
            }
            set
            {
                _othersidepinname = value;
            }
        }

        private string _fullpinname = "";
        [Browsable(false)]
        public string FullPinName
        {
            get
            {
                try
                {
                    return _fullpinname;
                }
                catch (System.Exception err)
                {
                    throw new Exception("Error getting PinName", err);
                }
            }
            set
            {
                _fullpinname = value;
            }
        }

        #endregion



        #region Public Methods

        
        public void SetVisible(bool _visible)
        {
            _Visible = _visible;
        }
        #endregion

        #region Private Methods


        #endregion
        //DrawFBDBox Parent;
        FBDboxObject Parent;
        public FBDObjectPin(FBDboxObject _parent, int _oindex, string _pinname, int _type, short _class, bool _visible,bool _extensible)
        {
            Parent = _parent;
            tblformalparameter.oIndex = _oindex;
            tblformalparameter.PinName = _pinname;
            tblformalparameter.Type = _type;
            tblformalparameter.Class = _class;
            
            tblformalparameter.Extensible = _extensible;
            _Visible = _visible;
        }

        public FBDObjectPin(FBDboxObject _parent, tblFormalParameter _tblformalparameter, bool _visible)
        {
            Parent = _parent;
            tblformalparameter.Class = _tblformalparameter.Class;
            tblformalparameter.Description = _tblformalparameter.Description;
            tblformalparameter.Extensible = _tblformalparameter.Extensible;
            tblformalparameter.oIndex = _tblformalparameter.oIndex;
            tblformalparameter.PinID = _tblformalparameter.PinID;
            tblformalparameter.PinName = _tblformalparameter.PinName;
            tblformalparameter.Type = _tblformalparameter.Type;
            tblformalparameter.InitializeValue = _tblformalparameter.InitializeValue;
            _Visible = _visible;

            //_oIndex = _oindex;
            //_PinName = _pinname;
            //_Type = _type;
            //_Class = _class;
            //_Visible = _visible;
            //_Extensible = _extensible;
        }

    }

    public class FBDObjectPinCollection : CollectionBase, ICustomTypeDescriptor
    {
        [Description("Get elememt from the collection.")]
        public FBDObjectPin this[int index]
        {
            get
            {
                return ((FBDObjectPin)List[index]);
            }
            set
            {
                List[index] = value;
            }
        }

        [Description("Adds a new tblFormalParameter to the collection.")]
        public int Add(FBDObjectPin item)
        {
            int newindex = List.Add(item);
            return newindex;
        }

        [Description("Removes a tblFormalParameter from the collection.")]
        public void Remove(FBDObjectPin item)
        {
            List.Remove(item);
        }

        [Description("Inserts an tblFormalParameter into the collection at the specified index.")]
        public void Insert(int index, FBDObjectPin item)
        {
            List.Insert(index, item);
        }

        [Description("Returns the index value of the tblFormalParameter class in the collection.")]
        public int IndexOf(FBDObjectPin item)
        {
            return List.IndexOf(item);
        }

        [Description("Returns true if the tblFormalParameter class is present in the collection.")]
        public bool Contains(FBDObjectPin item)
        {
            return List.Contains(item);
        }

        //DrawFBDBox Parent;
        //public FBDObjectPinCollection(DrawFBDBox _parent)
        //{
        //    Parent = _parent;
        //}

       
        FBDboxObject Parent;
        public FBDObjectPinCollection(FBDboxObject _parent)
        {
            Parent = _parent;
        }

        // Implementation of interface ICustomTypeDescriptor 
        #region ICustomTypeDescriptor impl

        public String GetClassName()
        {
            return TypeDescriptor.GetClassName(this, true);
        }

        public AttributeCollection GetAttributes()
        {
            return TypeDescriptor.GetAttributes(this, true);
        }

        public String GetComponentName()
        {
            return TypeDescriptor.GetComponentName(this, true);
        }

        public TypeConverter GetConverter()
        {
            return TypeDescriptor.GetConverter(this, true);
        }

        public EventDescriptor GetDefaultEvent()
        {
            return TypeDescriptor.GetDefaultEvent(this, true);
        }

        public PropertyDescriptor GetDefaultProperty()
        {
            return TypeDescriptor.GetDefaultProperty(this, true);
        }

        public object GetEditor(Type editorBaseType)
        {
            return TypeDescriptor.GetEditor(this, editorBaseType, true);
        }

        public EventDescriptorCollection GetEvents(Attribute[] attributes)
        {
            return TypeDescriptor.GetEvents(this, attributes, true);
        }

        public EventDescriptorCollection GetEvents()
        {
            return TypeDescriptor.GetEvents(this, true);
        }

        public object GetPropertyOwner(PropertyDescriptor pd)
        {
            return this;
        }


        /// <summary>
        /// Called to get the properties of this type. Returns properties with certain
        /// attributes. this restriction is not implemented here.
        /// </summary>
        /// <param name="attributes"></param>
        /// <returns></returns>
        public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {
            return GetProperties();
        }

        /// <summary>
        /// Called to get the properties of this type.
        /// </summary>
        /// <returns></returns>
        public PropertyDescriptorCollection GetProperties()
        {
            // Create a collection object to hold property descriptors
            PropertyDescriptorCollection pds = new PropertyDescriptorCollection(null);

            // Iterate the list of employees
            for (int i = 0; i < this.List.Count; i++)
            {
                // Create a property descriptor for the employee item and add to the property descriptor collection
                FBDPinCollectionPropertyDescriptor pd = new FBDPinCollectionPropertyDescriptor(this, i);
                pds.Add(pd);
            }
            // return the property descriptor collection
            return pds;
        }

        #endregion
    }


    public class FBDboxObject : Object
    {

        private FBDObjectPinCollection _PinCollectionInput;
        [Description("Represents collection of input pins for graphical use")]
        [TypeConverter(typeof(PinCollectionTypeConverter))]

        public FBDObjectPinCollection PinCollectionInput
        {
            get
            {

                return _PinCollectionInput;

            }
            set
            {
                _PinCollectionInput = value;
            }
        }



        private FBDObjectPinCollection _PinCollectionOutput;
        [Description("Represents collection of Output pins for graphical use")]
        [TypeConverter(typeof(PinCollectionTypeConverter))]
        public FBDObjectPinCollection PinCollectionOutput
        {
            get
            {

                return _PinCollectionOutput;

            }
            set
            {
                _PinCollectionOutput = value;
            }

        }


        //private List<FBDObjectPin> _PinCollectionInput = new List<FBDObjectPin>();
        //[Description("Represents collection of input pins for graphical use")]
        //public List<FBDObjectPin> PinCollectionInput
        //{
        //    get
        //    {

        //        return _PinCollectionInput;

        //    }
        //    set
        //    {
        //        _PinCollectionInput = value;
        //    }
        //}

        //private List<FBDObjectPin> _PinCollectionOutput = new List<FBDObjectPin>();
        //[Description("Represents collection of output pins for graphical use")]
        //public List<FBDObjectPin> PinCollectionOutput
        //{
        //    get
        //    {

        //        return _PinCollectionOutput;

        //    }
        //    set
        //    {
        //        _PinCollectionOutput = value;
        //    }
        //}

        DrawFBDBox DrawFunctionParent;
        public FBDboxObject(DrawFBDBox _parent)
        {
            DrawFunctionParent = _parent;
            
            PinCollectionInput = new FBDObjectPinCollection(this);
            PinCollectionOutput = new FBDObjectPinCollection(this);
        }

        public void AddInputPin(int _oindex, string _pinname, int _type, short _class, bool visible, bool extensible)
        {
            PinCollectionInput.Add(new FBDObjectPin(this, _oindex, _pinname, _type, _class, visible, extensible));
        }

        public void AddOutputPin(int _oindex, string _pinname, int _type, short _class, bool visible, bool extensible)
        {
            PinCollectionOutput.Add(new FBDObjectPin(this, _oindex, _pinname, _type, _class, visible, extensible));
        }

        public void AddInputPin(tblFormalParameter _tblformalparameter, bool _visible)
        {
            PinCollectionInput.Add(new FBDObjectPin(this, _tblformalparameter, _visible));
        }

        public void AddOutputPin(tblFormalParameter _tblformalparameter, bool _visible)
        {
            PinCollectionOutput.Add(new FBDObjectPin(this, _tblformalparameter, _visible));
        }
        public Rectangle _rectangle
        {
            get
            {
                return DrawFunctionParent.rectangle;
            }
        }
        

        
        
        public int BoxWidth
        {
            get
            {
                return DrawFunctionParent.BoxWidth();
            }
        }

        private int noofvisibleinputs;
        public int NoOfVisibleInputs
        {
            get
            {
                int count = 0;
                foreach (FBDObjectPin fbdpin in PinCollectionInput)
                {
                    if (fbdpin.Visible)
                    {
                        count++;
                    }
                }
                noofvisibleinputs = count;
                return noofvisibleinputs;
            }
            set
            {
                noofvisibleinputs = value;
            }
        }

        public int BoxHeight
        {
            get
            {
                return DrawFunctionParent.BoxHeight();  
            }
        }

        [DisplayName("Size of Head in function or function block in which function name and instance are written")]
        [Category("Column")]
        public int BoxHeadHeight
        {
            get
            {
                return DrawFunctionParent.BoxHeadHeight();
            }
        }

        //public int NoOfExtendablePins
        //{
        //    get
        //    {
        //        return DrawFunctionParent.NoOfExtendablePins;
        //    }

        //}

        //public void UpdatePins()
        //{
        //    int j = 0;
        //    int k = 0;
        //    int pinno = 0;

        //    if (DrawFunctionParent.IsFunction)
        //    {
        //        if (DrawFunctionParent.Extensible)   // extensible function
        //        {
        //            for (j = 0; j < PinCollectionInput.Count; j++)
        //            {
        //                if ((PinCollectionInput[j].Class == VarClass.Input) || (PinCollectionInput[j].Class == VarClass.InOut))
        //                {
        //                    if (PinCollectionInput[j].Extensible == false)
        //                    {
        //                        PinCollectionInput[j].PinNo = pinno++;
        //                        k++;
        //                    }
        //                    else
        //                    {
        //                        if ((j - k) < NoOfExtendablePins)
        //                        {
        //                            PinCollectionInput[j].PinNo = pinno++;
        //                            PinCollectionInput[j].SetVisible(true);
        //                        }
        //                        else
        //                        {
        //                            PinCollectionInput[j].SetVisible(false);
        //                        }
        //                    }

        //                }
        //            }                   
        //            pinno = 0;
        //            for (j = 0; j < PinCollectionOutput.Count; j++)
        //            {
        //                if ((PinCollectionOutput[j].Class == VarClass.Output))
        //                {
        //                    PinCollectionOutput[j].PinNo = pinno++;
        //                }
        //            }
        //        }
        //        else
        //        {
        //            for (j = 0; j < PinCollectionInput.Count; j++)
        //            {
        //                if ((PinCollectionInput[j].Class == VarClass.Input) || (PinCollectionInput[j].Class == VarClass.InOut))
        //                {
        //                    PinCollectionInput[j].PinNo = pinno++;
        //                }
        //            }
        //            pinno = 0;
        //            for (j = 0; j < PinCollectionOutput.Count; j++)
        //            {
        //                if ((PinCollectionOutput[j].Class == VarClass.Output))
        //                {
        //                    PinCollectionOutput[j].PinNo = pinno++;
        //                }
        //            }
        //        }
        //    }
        //    else
        //    {
        //        for (j = 0; j < PinCollectionInput.Count; j++)
        //        {
        //            if ((PinCollectionInput[j].Class == VarClass.Input) || (PinCollectionInput[j].Class == VarClass.InOut))
        //            {
        //                PinCollectionInput[j].PinNo = pinno++;
        //                k++;
        //            }
        //        }
        //        for (j = 0; j < PinCollectionInput.Count; j++)
        //        {
        //            if ((PinCollectionInput[j].Class == VarClass.Internal) && (PinCollectionInput[j].Visible))
        //            {
        //                PinCollectionInput[j].PinNo = pinno++;
        //            }
        //        }

        //        pinno = 0;

        //        for (j = 0; j < PinCollectionOutput.Count; j++)
        //        {
        //            if ((PinCollectionOutput[j].Class == VarClass.Output))
        //            {
        //                PinCollectionOutput[j].PinNo = pinno++;
        //            }
        //        }
        //    }
        //    //for (j = 0; j < PinCollectionInput.Count; j++)
        //    //{
        //    //    if ((PinCollectionInput[j].Class == VarClass.Input) || (PinCollectionInput[j].Class == VarClass.InOut))
        //    //    {
        //    //        if (PinCollectionInput[j].Extensible == false)
        //    //        {
        //    //            PinCollectionInput[j].PinNo = pinno++;
        //    //            k++;
        //    //        }
        //    //        else
        //    //        {
        //    //            //for (k = 0; k < NoOfExtendablePins; k++)
        //    //            //{
        //    //            //    PinCollectionInput[j].PinNo = pinno++;
        //    //            //}
        //    //            if ((j - k) < NoOfExtendablePins)
        //    //            {
        //    //                PinCollectionInput[j].PinNo = pinno++;
        //    //            }
        //    //        }

        //    //    }
        //    //}
        //    //for (j = 0; j < PinCollectionInput.Count; j++)
        //    //{
        //    //    if ((PinCollectionInput[j].Class == VarClass.Internal) && (PinCollectionInput[j].Visible))
        //    //    {
        //    //        PinCollectionInput[j].PinNo = pinno++;
        //    //    }
        //    //}

        //    //pinno = 0;

        //    //for (j = 0; j < PinCollectionOutput.Count; j++)
        //    //{
        //    //    if ((PinCollectionOutput[j].Class == VarClass.Output))
        //    //    {
        //    //        PinCollectionOutput[j].PinNo = pinno++;
        //    //    }
        //    //}

        //}


    }


}
