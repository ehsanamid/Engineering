using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace DCS.Project_Objects
{

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class DisplayObjectParameters
    {

        public List<DisplayObjectParameter> list = new List<DisplayObjectParameter>();
        
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class DisplayObjectParameter
    {
        

        private string nameField;
        /// <remarks/>
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
        private string descriptionField;
        /// <remarks/>
        public string Description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
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
        private string referenceField;
        /// <remarks/>
        public string Reference
        {
            get
            {
                return this.referenceField;
            }
            set
            {
                this.referenceField = value;
            }
        }
        private string assignmentField;
        /// <remarks/>
        public string Assignment
        {
            get
            {
                return this.assignmentField;
            }
            set
            {
                this.assignmentField = value;
            }
        }
        private byte indexField;
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte Index
        {
            get
            {
                return this.indexField;
            }
            set
            {
                this.indexField = value;
            }
        }
    }


}
