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
       [Serializable]
    public class ShapeOutline
    {
        VALUE m_val = new VALUE();
        public bool HasLineStyleExpression = false;
        string _linestyle;
        public string LineStyle
        {
            get
            {
                XmlDocument dom = new XmlDocument();

                XmlElement FillColorElement = dom.CreateElement("LineStyle");
                dom.AppendChild(FillColorElement);


                XmlElement boardercolor1Element = dom.CreateElement("boardercolor1");
                boardercolor1Element.InnerText = Common.ConvertColorToString(boardercolor1);
                FillColorElement.AppendChild(boardercolor1Element);

                XmlElement boardercolor2Element = dom.CreateElement("boardercolor2");
                boardercolor2Element.InnerText = Common.ConvertColorToString(boardercolor2);
                FillColorElement.AppendChild(boardercolor2Element);

                XmlElement boarderwidthElement = dom.CreateElement("boarderwidth");
                boarderwidthElement.InnerText = boarderwidth.ToString();
                FillColorElement.AppendChild(boarderwidthElement);

                XmlElement boarderblinkingElement = dom.CreateElement("boarderblinking");
                boarderblinkingElement.InnerText = boarderblinking.ToString();
                FillColorElement.AppendChild(boarderblinkingElement);

                XmlElement boarderdashstyleElement = dom.CreateElement("boarderdashstyle");
                boarderdashstyleElement.InnerText = boarderdashstyle.ToString();
                FillColorElement.AppendChild(boarderdashstyleElement);

                XmlElement boarderlinepaternscaleElement = dom.CreateElement("boarderlinepaternscale");
                boarderlinepaternscaleElement.InnerText = boarderlinepaternscale.ToString();
                FillColorElement.AppendChild(boarderlinepaternscaleElement);

                XmlElement _startlinecapElement = dom.CreateElement("_startlinecap");
                _startlinecapElement.InnerText = _startlinecap.ToString();
                FillColorElement.AppendChild(_startlinecapElement);

                XmlElement _endlinecapElement = dom.CreateElement("_endlinecap");
                _endlinecapElement.InnerText = _endlinecap.ToString();
                FillColorElement.AppendChild(_endlinecapElement);

                _linestyle = dom.InnerXml;
                return _linestyle;
            }
            set
            {
                _linestyle = value;
                if (_linestyle != "")
                {
                    XmlDocument doc = new XmlDocument();

                    doc.LoadXml(_linestyle);
                    XmlNode myNode = doc.DocumentElement;
                    XmlNode LineStyleNode = doc.SelectSingleNode("LineStyle");
                    if (LineStyleNode != null)
                    {

                        if (LineStyleNode["boardercolor1"] != null)
                            boardercolor1 = Common.ConvertStringToColor(LineStyleNode["boardercolor1"].InnerText);
                        if (LineStyleNode["boardercolor2"] != null)
                            boardercolor2 = Common.ConvertStringToColor(LineStyleNode["boardercolor2"].InnerText);
                        if (LineStyleNode["boarderwidth"] != null)
                            boarderwidth = int.Parse(LineStyleNode["boarderwidth"].InnerText);
                        if (LineStyleNode["boarderblinking"] != null)
                            boarderblinking = bool.Parse(LineStyleNode["boarderblinking"].InnerText);
                        if (LineStyleNode["boarderdashstyle"] != null)
                            boarderdashstyle = (DashStyle)Enum.Parse(typeof(DashStyle), LineStyleNode["boarderdashstyle"].InnerText);
                        if (LineStyleNode["boarderlinepaternscale"] != null)
                            boarderlinepaternscale = int.Parse(LineStyleNode["boarderlinepaternscale"].InnerText);
                        if (LineStyleNode["_startlinecap"] != null)
                            _startlinecap = (LineCap)Enum.Parse(typeof(LineCap), LineStyleNode["_startlinecap"].InnerText);
                        if (LineStyleNode["_endlinecap"] != null)
                            _endlinecap = (LineCap)Enum.Parse(typeof(LineCap), LineStyleNode["_endlinecap"].InnerText);

                    }
                }

            }
        }

        bool showcaps = false;
        public bool ShowCaps
        {
            get
            {
                return showcaps;
            }
            set
            {
                showcaps = value;
            }
        }

        public float[] cuspat = new float[6];

        public bool HasBoarderColor1Expression = false;
        protected Color boardercolor1 = Color.Red;
        public Color BoarderColor1
        {
            get
            {
                if (HasBoarderColor1Expression)
                {

#if OWSAPP
                    if (parent.drawexpressionCollection.RunField(enumDynamicGraphicalProperty.BorderColor, ref m_val))
                    {

                        return Color.FromArgb(m_val.DINT);
                    } 
#endif
                   
                    return boardercolor1;
                }
                else
                {
                    return boardercolor1;
                }
            }
            set
            {
                boardercolor1 = value;
            }
        }

        public bool HasBoarderColor2Expression = false;
        protected Color boardercolor2 = Color.Red;
        public Color BoarderColor2
        {
            get
            {
                return boardercolor2;
            }
            set
            {
                boardercolor2 = value;
            }
        }

        public bool HasBoarderWidthExpression = false;
        protected int boarderwidth = 1;
        public int BoarderWidth
        {
            get
            {
                if (HasBoarderWidthExpression)
                {

#if OWSAPP
                    if (parent.drawexpressionCollection.RunField(enumDynamicGraphicalProperty.BorderWidth, ref m_val))
                    {
                        return m_val.DINT;
                    } 
#endif
                    return boarderwidth;
                }
                else
                {
                    return boarderwidth;
                }
            }
            set
            {
                boarderwidth = value;
            }
        }

        public bool HasBoarderBlinkingExpression = false;
        protected bool boarderblinking = false;
        public bool BoarderBlinking
        {
            get
            {
                if (HasBoarderBlinkingExpression)
                {

#if OWSAPP
                    if (parent.drawexpressionCollection.RunField(enumDynamicGraphicalProperty.BorderBlinking, ref m_val))
                    {
                        return m_val.BOOL;
                    } 
#endif
                    return boarderblinking;
                }
                else
                {
                    return boarderblinking;
                }
            }
            set
            {
                boarderblinking = value;
            }
        }

        public bool HasBoarderDashStyleExpression = false;
        protected DashStyle boarderdashstyle = DashStyle.Solid;
        public DashStyle BoarderDashStyle
        {
            get
            {
                return boarderdashstyle;
            }
            set
            {
                boarderdashstyle = value;
                if (cuspat != null)
                {
                    cuspat = null;
                }
                //cuspat = new float[6];
                switch (BoarderDashStyle)
                {
                    case DashStyle.Dot:
                        cuspat = new float[4];
                        cuspat[0] = BoarderLinePaternScale;
                        cuspat[1] = BoarderLinePaternScale;
                        cuspat[2] = BoarderLinePaternScale;
                        cuspat[3] = BoarderLinePaternScale;
                        break;
                    case DashStyle.DashDotDot:
                        cuspat = new float[6];
                        cuspat[0] = BoarderLinePaternScale * 5;
                        cuspat[1] = BoarderLinePaternScale;
                        cuspat[2] = BoarderLinePaternScale;
                        cuspat[3] = BoarderLinePaternScale;
                        cuspat[4] = BoarderLinePaternScale;
                        cuspat[5] = BoarderLinePaternScale;
                        break;
                    case DashStyle.DashDot:
                        cuspat = new float[4];
                        cuspat[0] = BoarderLinePaternScale * 5;
                        cuspat[1] = BoarderLinePaternScale;
                        cuspat[2] = BoarderLinePaternScale;
                        cuspat[3] = BoarderLinePaternScale;
                        break;
                    case DashStyle.Dash:
                        cuspat = new float[2];
                        cuspat[0] = BoarderLinePaternScale * 5;
                        cuspat[1] = BoarderLinePaternScale;
                        break;
                }
            }
        }

        protected int boarderlinepaternscale = 1;
        public int BoarderLinePaternScale
        {
            get
            {
                return boarderlinepaternscale;
            }
            set
            {
                boarderlinepaternscale = value;
                if (boarderlinepaternscale == 0)
                {
                    boarderlinepaternscale = 1;
                }
                if (cuspat != null)
                {
                    cuspat = null;
                }
                //cuspat = new float[6];
                switch (BoarderDashStyle)
                {
                    case DashStyle.Dot:
                        cuspat = new float[4];
                        cuspat[0] = BoarderLinePaternScale;
                        cuspat[1] = BoarderLinePaternScale;
                        cuspat[2] = BoarderLinePaternScale;
                        cuspat[3] = BoarderLinePaternScale;
                        break;
                    case DashStyle.DashDotDot:
                        cuspat = new float[6];
                        cuspat[0] = BoarderLinePaternScale * 5;
                        cuspat[1] = BoarderLinePaternScale;
                        cuspat[2] = BoarderLinePaternScale;
                        cuspat[3] = BoarderLinePaternScale;
                        cuspat[4] = BoarderLinePaternScale;
                        cuspat[5] = BoarderLinePaternScale;
                        break;
                    case DashStyle.DashDot:
                        cuspat = new float[4];
                        cuspat[0] = BoarderLinePaternScale * 5;
                        cuspat[1] = BoarderLinePaternScale;
                        cuspat[2] = BoarderLinePaternScale;
                        cuspat[3] = BoarderLinePaternScale;
                        break;
                    case DashStyle.Dash:
                        cuspat = new float[2];
                        cuspat[0] = BoarderLinePaternScale * 5;
                        cuspat[1] = BoarderLinePaternScale;
                        break;
                }
            }
        }
        LineCap _startlinecap = LineCap.NoAnchor;
        public LineCap StartLineCap
        {
            get
            {
                return _startlinecap;
            }
            set
            {
                _startlinecap = value;
            }
        }
        LineCap _endlinecap = LineCap.NoAnchor;
        public LineCap EndLineCap
        {
            get
            {
                return _endlinecap;
            }
            set
            {
                _endlinecap = value;
            }
        }

        DrawGraphic parent;
        public ShapeOutline(DrawGraphic _parent)
        {
            parent = _parent;
        }
        public ShapeOutline(ShapeOutline tocopy)
        {
            this.LineStyle = tocopy.LineStyle;
        }
    }
}
