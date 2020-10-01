using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCS.Project_Objects
{

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class DisplayObjectEventHandlers
    {

        public List<DisplayObjectEventHandler> list = new List<DisplayObjectEventHandler>();
        
        //public void Copy(DisplayObjectEventHandlers _displayobjecteventhandlers)
        //{
        //    this.list.Clear();
        //    foreach (DisplayObjectEventHandler doh in _displayobjecteventhandlers.list)
        //    {
        //        DisplayObjectEventHandler _displayobjecteventhandler = new DisplayObjectEventHandler();
        //        _displayobjecteventhandler.Access = doh.Access;
        //        _displayobjecteventhandler.Event = doh.Event;
        //        _displayobjecteventhandler.Handler = doh.Handler;
        //        _displayobjecteventhandler.Type = doh.Type;
        //        this.list.Add(_displayobjecteventhandler);

        //    }
        //}
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class DisplayObjectEventHandler
    {

        private string eventField;
        /// <remarks/>
        public string Event
        {
            get
            {
                return this.eventField;
            }
            set
            {
                this.eventField = value;
            }
        }

        private string handlerField;
        /// <remarks/>
        public string Handler
        {
            get
            {
                return this.handlerField;
            }
            set
            {
                this.handlerField = value;
            }
        }
        private string typeField;
        /// <remarks/>
        public string Type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        private string accessField;
        /// <remarks/>
        public string Access
        {
            get
            {
                return this.accessField;
            }
            set
            {
                this.accessField = value;
            }
        }
    }


}
