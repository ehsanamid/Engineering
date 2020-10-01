using DCS;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Xml;



namespace DCS.Draw
{
    public class ShapeFill
    {
        VALUE m_val = new VALUE();
        DrawGraphic parent;
        public ShapeFill(DrawGraphic _parent)
        {
            parent = _parent;
        }
        public ShapeFill(ShapeFill tocopy)
        {
            this.FillColor = tocopy.FillColor;
            //blinking = tocopy.Blinking;
            //fillcolor11 = tocopy.fillcolor11;
            //fillcolor21 = tocopy.fillcolor21;
            //fillcolor12 = tocopy.fillcolor12;
            //fillcolor22 = tocopy.fillcolor22;
            //filltype = tocopy.filltype;
            //fillgradienttype = tocopy.fillgradienttype;
            //hatchstyle = tocopy.hatchstyle;
        }

        public bool HasFillColorExpression = false;
        string fillcolor = "";
        public string FillColor
        {
            get
            {
                XmlDocument dom = new XmlDocument();

                XmlElement FillColorElement = dom.CreateElement("FillColor");
                dom.AppendChild(FillColorElement);


                XmlElement fillcolor11Element = dom.CreateElement("fillcolor11");
                fillcolor11Element.InnerText = Common.ConvertColorToString(fillcolor11);
                FillColorElement.AppendChild(fillcolor11Element);

                XmlElement fillcolor12Element = dom.CreateElement("fillcolor12");
                fillcolor12Element.InnerText = Common.ConvertColorToString(fillcolor12);
                FillColorElement.AppendChild(fillcolor12Element);

                XmlElement fillcolor21Element = dom.CreateElement("fillcolor21");
                fillcolor21Element.InnerText = Common.ConvertColorToString(fillcolor21);
                FillColorElement.AppendChild(fillcolor21Element);

                XmlElement fillcolor22Element = dom.CreateElement("fillcolor22");
                fillcolor22Element.InnerText = Common.ConvertColorToString(fillcolor22);
                FillColorElement.AppendChild(fillcolor22Element);

                XmlElement blinkingElement = dom.CreateElement("blinking");
                blinkingElement.InnerText = blinking.ToString();
                FillColorElement.AppendChild(blinkingElement);

                XmlElement filltypeElement = dom.CreateElement("filltype");
                filltypeElement.InnerText = filltype.ToString();
                FillColorElement.AppendChild(filltypeElement);

                XmlElement fillgradienttypeElement = dom.CreateElement("fillgradienttype");
                fillgradienttypeElement.InnerText = fillgradienttype.ToString();
                FillColorElement.AppendChild(fillgradienttypeElement);

                XmlElement hatchstyleElement = dom.CreateElement("hatchstyle");
                hatchstyleElement.InnerText = hatchstyle.ToString();
                FillColorElement.AppendChild(hatchstyleElement);

                fillcolor = dom.InnerXml;
                return fillcolor;
            }
            set
            {
                fillcolor = value;
                if (fillcolor != "")
                {
                    XmlDocument doc = new XmlDocument();

                    doc.LoadXml(fillcolor);
                    XmlNode myNode = doc.DocumentElement;
                    XmlNode FillColorNode = doc.SelectSingleNode("FillColor");
                    if (FillColorNode != null)
                    {

                        if (FillColorNode["fillcolor11"] != null)
                            fillcolor11 = Common.ConvertStringToColor(FillColorNode["fillcolor11"].InnerText);
                        if (FillColorNode["fillcolor12"] != null)
                            fillcolor12 = Common.ConvertStringToColor(FillColorNode["fillcolor12"].InnerText);
                        if (FillColorNode["fillcolor21"] != null)
                            fillcolor21 = Common.ConvertStringToColor(FillColorNode["fillcolor21"].InnerText);
                        if (FillColorNode["fillcolor22"] != null)
                            fillcolor22 = Common.ConvertStringToColor(FillColorNode["fillcolor22"].InnerText);
                        if (FillColorNode["blinking"] != null)
                            blinking = bool.Parse(FillColorNode["blinking"].InnerText);
                        if (FillColorNode["filltype"] != null)
                            filltype = (FillTypePatern)Enum.Parse(typeof(FillTypePatern), FillColorNode["filltype"].InnerText);
                        if (FillColorNode["fillgradienttype"] != null)
                            fillgradienttype = (FillGradientType)Enum.Parse(typeof(FillGradientType), FillColorNode["fillgradienttype"].InnerText);
                        if (FillColorNode["hatchstyle"] != null)
                            hatchstyle = (HatchStyle)Enum.Parse(typeof(HatchStyle), FillColorNode["hatchstyle"].InnerText);

                    }
                }

            }
        }

        public bool HasBlinkingExpression = false;
        bool blinking = false;
        public bool Blinking
        {
            get
            {
                if (HasBlinkingExpression)
                {

#if OWSAPP
                    if (parent.drawexpressionCollection.RunField(enumDynamicGraphicalProperty.Blinking, ref m_val))
                    {
                        return m_val.BOOL;
                    } 
#endif
                    return blinking;
                }
                else
                {
                    return blinking;
                }
                
            }
            set
            {
                blinking = value;
            }
        }


        public bool HasFillColor11Expression = false;
        Color fillcolor11 = Color.Red;
        public Color FillColor11
        {
            get
            {
                if (HasFillColor11Expression)
                {

#if OWSAPP
                    if (parent.drawexpressionCollection.RunField(enumDynamicGraphicalProperty.Color1, ref m_val))
                    {

                        return Color.FromArgb(m_val.DINT);
                    }
#endif

                    return fillcolor11;
                }
                else
                {
                    return fillcolor11;
                }
            }
            set
            {
                fillcolor11 = value;
            }
        }

        public bool HasFillColor21Expression = false;
        Color fillcolor21 = Color.Red;
        public Color FillColor21
        {
            get
            {

                if (HasFillColor21Expression)
                {

#if OWSAPP
                    if (parent.drawexpressionCollection.RunField(enumDynamicGraphicalProperty.Color2, ref m_val))
                    {

                        return Color.FromArgb(m_val.DINT);
                    }
#endif

                    return fillcolor21;
                }
                else
                {
                    return fillcolor21;
                }
            }
            set
            {
                fillcolor21 = value;
            }
        }

        public bool HasFillColor12Expression = false;
        Color fillcolor12 = Color.Red;
        public Color FillColor12
        {
            get
            {
                return fillcolor12;
            }
            //set
            //{
            //    fillcolor12 = value;
            //}
        }

        public bool HasFillColor22Expression = false;
        Color fillcolor22 = Color.Red;
        public Color FillColor22
        {
            get
            {
                return fillcolor22;
            }
            //set
            //{
            //    fillcolor22 = value;
            //}
        }


        public bool HasFillTypeExpression = false;
        FillTypePatern filltype = FillTypePatern.Transparent;
        public FillTypePatern FillType
        {
            get
            {
                return filltype;
            }
            set
            {
                filltype = value;
            }
        }

        public bool HasFillgradienttypeExpression = false;
        FillGradientType fillgradienttype = FillGradientType.Buttom2Top;
        public FillGradientType Fillgradienttype
        {
            get
            {
                return fillgradienttype;
            }
            set
            {
                fillgradienttype = value;
            }
        }

        HatchStyle hatchstyle = HatchStyle.Cross;
        public HatchStyle hatchStyle
        {
            get
            {
                return hatchstyle;
            }
            //set
            //{
            //    hatchstyle = value;
            //}
        }



        /// <summary>
        /// ////////////////////////////////////////////////////
        /// 
        //HatchStyle hatchstyle = HatchStyle.Cross;
        /// /////////////////////////////////////////////////////
        /// </summary>
        /// <param name="dom"></param>
        /// <param name="node"></param>


        //public void ObjectToXml(ref XmlDataDocument dom, XmlElement node)
        //{
        //    XmlElement elem;

        //    elem = dom.CreateElement("FillColor11");
        //    elem.InnerText = fillcolor11.ToString();
        //    node.AppendChild(elem);

        //    elem = dom.CreateElement("FillColor12");
        //    elem.InnerText = fillcolor12.ToString();
        //    node.AppendChild(elem);
            
        //    elem = dom.CreateElement("FillColor21");
        //    elem.InnerText = fillcolor21.ToString();
        //    node.AppendChild(elem);

        //    elem = dom.CreateElement("FillColor22");
        //    elem.InnerText = fillcolor22.ToString();
        //    node.AppendChild(elem);


        //    elem = dom.CreateElement("Blinking");
        //    elem.InnerText = blinking.ToString();
        //    node.AppendChild(elem);

        //    elem = dom.CreateElement("FillTypePatern");
        //    elem.InnerText = filltype.ToString();
        //    node.AppendChild(elem);

        //    elem = dom.CreateElement("FillGradientType");
        //    elem.InnerText = _fillgradienttype.ToString();
        //    node.AppendChild(elem);

        //    elem = dom.CreateElement("HatchStyle");
        //    elem.InnerText = hatchstyle.ToString();
        //    node.AppendChild(elem);

            
        //}
    }
}
