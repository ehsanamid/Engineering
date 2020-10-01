using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DCS.Draw
{

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class GraphicalObject
    {

        private GraphicalObjectParameter[] parameterField;

        private GraphicalObjectGraphicObjectProperty[] graphicObjectPropertyField;

        private GraphicalObjectEventHandler[] eventHandlerField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Parameter")]
        public GraphicalObjectParameter[] Parameter
        {
            get
            {
                return this.parameterField;
            }
            set
            {
                this.parameterField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("GraphicObjectProperty")]
        public GraphicalObjectGraphicObjectProperty[] GraphicObjectProperty
        {
            get
            {
                return this.graphicObjectPropertyField;
            }
            set
            {
                this.graphicObjectPropertyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("EventHandler")]
        public GraphicalObjectEventHandler[] EventHandler
        {
            get
            {
                return this.eventHandlerField;
            }
            set
            {
                this.eventHandlerField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class GraphicalObjectParameter
    {

        private string nameField;

        private string typeField;

        private string referenceField;

        private string assignmentField;

        private byte indexField;

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

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class GraphicalObjectGraphicObjectProperty
    {

        private string objectTypeField;

        private string returnTypeField;

        private GraphicalObjectGraphicObjectPropertyCondition[] conditionField;

        /// <remarks/>
        public string ObjectType
        {
            get
            {
                return this.objectTypeField;
            }
            set
            {
                this.objectTypeField = value;
            }
        }

        /// <remarks/>
        public string ReturnType
        {
            get
            {
                return this.returnTypeField;
            }
            set
            {
                this.returnTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Condition")]
        public GraphicalObjectGraphicObjectPropertyCondition[] Condition
        {
            get
            {
                return this.conditionField;
            }
            set
            {
                this.conditionField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class GraphicalObjectGraphicObjectPropertyCondition
    {

        private string ifField;

        private string thenField;

        private byte indexField;

        /// <remarks/>
        public string @if
        {
            get
            {
                return this.ifField;
            }
            set
            {
                this.ifField = value;
            }
        }

        /// <remarks/>
        public string then
        {
            get
            {
                return this.thenField;
            }
            set
            {
                this.thenField = value;
            }
        }

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

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class GraphicalObjectEventHandler
    {

        private string eventField;

        private string typeField;

        private string accessField;

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
