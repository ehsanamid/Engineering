//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Data.SqlClient;
using System.Text;
using System.Drawing;
using System.Diagnostics;
using System.IO;
using System.Drawing.Drawing2D;


namespace DCS.DCSTables
{
	
	
	public partial class tblSymbolStatus 
    {
        
        public void LoadSymbolFile(string fullpath)
        {
            Trace.WriteLine(fullpath);
            using (FileStream fs = File.Open(fullpath, FileMode.Open))
            {
                byte[] b = new byte[1024];
                UTF8Encoding temp = new UTF8Encoding(true);

                var cvt = new FontConverter(); 
                //int ff;
                int i1;
                byte bPen;
                byte bBrush;
                int brushStyle;
                long lfHeight;
                long lfWidth;
                long lfEscapement;
                long lfOrientation;
                long lfWeight;
                bool lfItalic;
                bool lfUnderline;
                bool lfStrikeOut;
                byte lfCharSet;
                byte lfOutPrecision;
                byte lfClipPrecision;
                byte lfQuality;
                byte lfPitchAndFamily;
                string lfFaceName;
                Font ManagedFont;
                Color cc;
                
                int noofstaticobjects = 0;
                fs.Read(b, 0, 1);
                fs.Read(b, 0, 1);
                noofstaticobjects = b[0];
                
                //int OPM;
                int start, len;
                STATIC_OBJ_TYPE OBJ = STATIC_OBJ_TYPE.ID_BITMAP;
                for (int i = 0; i < noofstaticobjects; i++)
                {
                    fs.Read(b, 0, 1);

                    OBJ = (STATIC_OBJ_TYPE)b[0];

                    
                    switch (OBJ)
                    {

                        case STATIC_OBJ_TYPE.ID_BITMAP:
                            #region Bitmap
                            tblSymbolBitmap tblbitmap = new tblSymbolBitmap();
                            tblbitmap.SymbolStatusID = this.SymbolStatusID;

                            
                            fs.Read(b, 0, 100);
                            start = 0;
                            len = 0;
                            while (b[len] != 0)
                            {
                                len++;
                            }
                            tblbitmap.BitmapName = Encoding.UTF8.GetString(b, start, len);
                            fs.Read(b, 0, sizeof(int));
                            tblbitmap.left = BitConverter.ToInt32(b, 0);

                            fs.Read(b, 0, sizeof(int));
                            tblbitmap.top = BitConverter.ToInt32(b, 0);

                            fs.Read(b, 0, sizeof(int));
                            tblbitmap.right = BitConverter.ToInt32(b, 0);

                            fs.Read(b, 0, sizeof(int));
                            tblbitmap.bottom = BitConverter.ToInt32(b, 0);

                            fs.Read(b, 0, sizeof(int));

                            tblbitmap.Transparent = BitConverter.ToBoolean(b, 0);
                            fs.Read(b, 0, sizeof(int));
                            tblbitmap.Insert();
                            break;
                            #endregion

                        case STATIC_OBJ_TYPE.ID_RECT:
                        case STATIC_OBJ_TYPE.ID_ELLIPS:
                            #region Rect & Ellips
                            tblSymbolRect tblrect = new tblSymbolRect();
                            tblrect.SymbolStatusID = this.SymbolStatusID;
                            tblrect.Type = (int)OBJ;
                            //fs.Read(b, 0, 20);
                            #region Head_Param

                            #region bBrush&bPen
                            fs.Read(b, 0, sizeof(int));
                            bBrush = b[0];
                            bPen = b[1];
                            if (bBrush >= 2)
                            {
                                tblrect.Blinking = true;
                            }
                            else
                            {
                                tblrect.Blinking = false;
                            }
                            if (bPen >= 2)
                            {
                                tblrect.BoarderBlinking = true;
                            }
                            else
                            {
                                tblrect.BoarderBlinking = false;
                            }
                            #endregion


                            #region PenStyle
                            fs.Read(b, 0, sizeof(int));
                            tblrect.BorderDashStyle = BitConverter.ToInt32(b, 0);
                            #endregion
                            #region PenWidth
                            fs.Read(b, 0, sizeof(int));
                            fs.Read(b, 0, sizeof(int));
                            tblrect.BorderWidth = BitConverter.ToInt32(b, 0);
                            #endregion
                            #region PenColor
                            fs.Read(b, 0, sizeof(int));
                            i1 = BitConverter.ToInt32(b, 0);
                            cc = Color.FromArgb((i1) & 0xff, (i1 >> 8) & 0xff, (i1 >> 16) & 0xff);
                            i1 = cc.ToArgb();
                            tblrect.BorderColor1 = cc;
                            tblrect.BorderColor2 = Color.Transparent;
                            #endregion


                            #region BrushStyle
                            fs.Read(b, 0, sizeof(int));

                            brushStyle = BitConverter.ToInt32(b, 0);
                            if (bBrush == 0)
                            {
                                tblrect.FillType = 0;
                            }
                            else
                            {
                                if (brushStyle == 0)
                                {
                                    tblrect.FillType = 1;
                                }
                                else
                                {
                                    tblrect.FillType = 2;
                                }

                            }
                            #endregion
                            #region BrushColor
                            fs.Read(b, 0, sizeof(int));
                            i1 = BitConverter.ToInt32(b, 0);
                            cc = Color.FromArgb((i1) & 0xff, (i1 >> 8) & 0xff, (i1 >> 16) & 0xff);
                            i1 = cc.ToArgb();
                            tblrect.FillColor11 = cc;
                            tblrect.FillColor12 = Color.Transparent;
                            tblrect.FillColor21 = cc;
                            tblrect.FillColor22 = Color.Transparent;
                            #endregion
                            #region BrushHatch
                            fs.Read(b, 0, sizeof(int));
                            tblrect.HachStyle = BitConverter.ToInt32(b, 0);
                            #endregion
                            #endregion

                            #region Rect
                            fs.Read(b, 0, sizeof(int));
                            tblrect.Left = BitConverter.ToInt32(b, 0);
                            fs.Read(b, 0, sizeof(int));
                            tblrect.Top = BitConverter.ToInt32(b, 0);
                            fs.Read(b, 0, sizeof(int));
                            tblrect.Width = BitConverter.ToInt32(b, 0) - tblrect.Left;
                            fs.Read(b, 0, sizeof(int));
                            tblrect.Height = BitConverter.ToInt32(b, 0) - tblrect.Top;
                            #endregion


                            fs.Read(b, 0, sizeof(int));

                            fs.Read(b, 0, sizeof(int));
                            tblrect.Insert();
                            break;
                            #endregion

                        case STATIC_OBJ_TYPE.ID_ROUNDRECT:
                            #region Rounded Rect
                            tblSymbolRect tblroundedrect = new tblSymbolRect();
                            tblroundedrect.SymbolStatusID = this.SymbolStatusID;
                            tblroundedrect.Type = (int)OBJ;
                            //fs.Read(b, 0, 20);
                            #region Head_Param

                            #region bBrush&bPen
                            fs.Read(b, 0, sizeof(int));
                            bBrush = b[0];
                            bPen = b[1];
                            if (bBrush >= 2)
                            {
                                tblroundedrect.Blinking = true;
                            }
                            else
                            {
                                tblroundedrect.Blinking = false;
                            }
                            if (bPen >= 2)
                            {
                                tblroundedrect.BoarderBlinking = true;
                            }
                            else
                            {
                                tblroundedrect.BoarderBlinking = false;
                            }
                            #endregion


                            #region PenStyle
                            fs.Read(b, 0, sizeof(int));
                            tblroundedrect.BorderDashStyle = BitConverter.ToInt32(b, 0);
                            #endregion
                            #region PenWidth
                            fs.Read(b, 0, sizeof(int));
                            fs.Read(b, 0, sizeof(int));
                            tblroundedrect.BorderWidth = BitConverter.ToInt32(b, 0);
                            #endregion
                            #region PenColor
                            fs.Read(b, 0, sizeof(int));
                            i1 = BitConverter.ToInt32(b, 0);
                            cc = Color.FromArgb((i1) & 0xff, (i1 >> 8) & 0xff, (i1 >> 16) & 0xff);
                            i1 = cc.ToArgb();
                            tblroundedrect.BorderColor1 = cc;
                            tblroundedrect.BorderColor2 = Color.Transparent;
                            #endregion


                            #region BrushStyle
                            fs.Read(b, 0, sizeof(int));

                            brushStyle = BitConverter.ToInt32(b, 0);
                            if (bBrush == 0)
                            {
                                tblroundedrect.FillType = 0;
                            }
                            else
                            {
                                if (brushStyle == 0)
                                {
                                    tblroundedrect.FillType = 1;
                                }
                                else
                                {
                                    tblroundedrect.FillType = 2;
                                }

                            }
                            #endregion
                            #region BrushColor
                            fs.Read(b, 0, sizeof(int));
                            i1 = BitConverter.ToInt32(b, 0);
                            cc = Color.FromArgb((i1) & 0xff, (i1 >> 8) & 0xff, (i1 >> 16) & 0xff);
                            i1 = cc.ToArgb();
                            tblroundedrect.FillColor11 = cc;
                            tblroundedrect.FillColor12 = Color.Transparent;
                            tblroundedrect.FillColor21 = cc;
                            tblroundedrect.FillColor22 = Color.Transparent;
                            #endregion
                            #region BrushHatch
                            fs.Read(b, 0, sizeof(int));
                            tblroundedrect.HachStyle = BitConverter.ToInt32(b, 0);
                            #endregion
                            #endregion

                            #region Rect
                            fs.Read(b, 0, sizeof(int));
                            tblroundedrect.Left = BitConverter.ToInt32(b, 0);
                            fs.Read(b, 0, sizeof(int));
                            tblroundedrect.Top = BitConverter.ToInt32(b, 0);
                            fs.Read(b, 0, sizeof(int));
                            tblroundedrect.Width = BitConverter.ToInt32(b, 0) - tblroundedrect.Left;
                            fs.Read(b, 0, sizeof(int));
                            tblroundedrect.Height = BitConverter.ToInt32(b, 0) - tblroundedrect.Top;
                            #endregion

                            fs.Read(b, 0, sizeof(int));
                            tblroundedrect.RoundnessX = BitConverter.ToInt32(b, 0);
                            fs.Read(b, 0, sizeof(int));
                            tblroundedrect.RoundnessY = BitConverter.ToInt32(b, 0);

                            fs.Read(b, 0, sizeof(int));
                            fs.Read(b, 0, sizeof(int));
                            tblroundedrect.Insert();
                            break;
                            #endregion
                        case STATIC_OBJ_TYPE.ID_CHORD: break;
                        case STATIC_OBJ_TYPE.ID_PIE: break;
                        case STATIC_OBJ_TYPE.ID_CURVE:
                        case STATIC_OBJ_TYPE.ID_POLYGON:
                        case STATIC_OBJ_TYPE.ID_POLYLINE:
                            #region Polyline
                            tblSymbolPolyline tblpolyline = new tblSymbolPolyline();
                            tblpolyline.SymbolStatusID = this.SymbolStatusID;
                            tblpolyline.Type = (int)OBJ;
                            //fs.Read(b, 0, 20);
                            #region Head_Param

                            #region bBrush&bPen
                            fs.Read(b, 0, sizeof(int));
                            bBrush = b[0];
                            bPen = b[1];
                            if (bBrush >= 2)
                            {
                                tblpolyline.Blinking = true;
                            }
                            else
                            {
                                tblpolyline.Blinking = false;
                            }
                            if (bPen >= 2)
                            {
                                tblpolyline.BorderBlinking = true;
                            }
                            else
                            {
                                tblpolyline.BorderBlinking = false;
                            }
                            #endregion


                            #region PenStyle
                            fs.Read(b, 0, sizeof(int));
                            tblpolyline.BorderDashStyle = BitConverter.ToInt32(b, 0);
                            #endregion
                            #region PenWidth
                            fs.Read(b, 0, sizeof(int));
                            fs.Read(b, 0, sizeof(int));
                            tblpolyline.BorderWidth = BitConverter.ToInt32(b, 0);
                            #endregion
                            #region PenColor
                            fs.Read(b, 0, sizeof(int));
                            i1 = BitConverter.ToInt32(b, 0);
                            cc = Color.FromArgb((i1) & 0xff, (i1 >> 8) & 0xff, (i1 >> 16) & 0xff);
                            i1 = cc.ToArgb();
                            tblpolyline.BorderColor1 = cc;
                            tblpolyline.BorderColor2 = Color.Transparent;
                            #endregion


                            #region BrushStyle
                            fs.Read(b, 0, sizeof(int));

                            brushStyle = BitConverter.ToInt32(b, 0);
                            if (bBrush == 0)
                            {
                                tblpolyline.FillType = 0;
                            }
                            else
                            {
                                if (brushStyle == 0)
                                {
                                    tblpolyline.FillType = 1;
                                }
                                else
                                {
                                    tblpolyline.FillType = 2;
                                }

                            }
                            #endregion
                            #region BrushColor
                            fs.Read(b, 0, sizeof(int));
                            i1 = BitConverter.ToInt32(b, 0);
                            cc = Color.FromArgb((i1) & 0xff, (i1 >> 8) & 0xff, (i1 >> 16) & 0xff);
                            i1 = cc.ToArgb();
                            tblpolyline.FillColor11 = cc;
                            tblpolyline.FillColor12 = Color.Transparent;
                            tblpolyline.FillColor21 = cc;
                            tblpolyline.FillColor22 = Color.Transparent;
                            #endregion
                            #region BrushHatch
                            fs.Read(b, 0, sizeof(int));
                            tblpolyline.HachStyle = BitConverter.ToInt32(b, 0);
                            #endregion
                            #endregion

                            #region points
                            fs.Read(b, 0, sizeof(int));
                            tblpolyline.NoPoints = BitConverter.ToInt32(b, 0);

                            fs.Read(b, 0, sizeof(int));

                            #endregion


                            fs.Read(b, 0, sizeof(int));
                            fs.Read(b, 0, sizeof(int));

                            tblpolyline.Insert();
                            for (int counter = 0; counter < tblpolyline.NoPoints; counter++)
                            {
                                tblSymbolPointsPolyline tblpointspolyline = new tblSymbolPointsPolyline();
                                tblpointspolyline.m_PolylineID_tblSymbolPolyline = tblpolyline;
                                tblpointspolyline.PolylineID = tblpolyline.PolylineID;
                                fs.Read(b, 0, sizeof(int));
                                tblpointspolyline.PtX = BitConverter.ToInt32(b, 0);
                                fs.Read(b, 0, sizeof(int));
                                tblpointspolyline.PtY = BitConverter.ToInt32(b, 0);
                                tblpointspolyline.Insert();
                            }

                            break;

                            #endregion
                        case STATIC_OBJ_TYPE.ID_LINE:
                            #region Line
                            tblSymbolLine tblline = new tblSymbolLine();
                            tblline.SymbolStatusID = this.SymbolStatusID;

                            //fs.Read(b, 0, 20);

                            #region Head_Param

                            #region bBrush&bPen
                            fs.Read(b, 0, sizeof(int));
                            bBrush = b[0];
                            bPen = b[1];
                            if (bBrush >= 2)
                            {
                                tblline.Blinking = true;
                            }
                            else
                            {
                                tblline.Blinking = false;
                            }
                            if (bPen >= 2)
                            {
                                tblline.BoarderBlinking = true;
                            }
                            else
                            {
                                tblline.BoarderBlinking = false;
                            }
                            #endregion


                            #region PenStyle
                            fs.Read(b, 0, sizeof(int));
                            tblline.BorderDashStyle = BitConverter.ToInt32(b, 0);
                            #endregion
                            #region PenWidth
                            fs.Read(b, 0, sizeof(int));
                            fs.Read(b, 0, sizeof(int));
                            tblline.BorderWidth = BitConverter.ToInt32(b, 0);
                            #endregion
                            #region PenColor
                            fs.Read(b, 0, sizeof(int));
                            i1 = BitConverter.ToInt32(b, 0);
                            cc = Color.FromArgb((i1) & 0xff, (i1 >> 8) & 0xff, (i1 >> 16) & 0xff);
                            i1 = cc.ToArgb();
                            tblline.BorderColor1 = cc;
                            tblline.BorderColor2 = Color.Transparent;
                            #endregion


                            #region BrushStyle
                            fs.Read(b, 0, sizeof(int));

                            brushStyle = BitConverter.ToInt32(b, 0);
                            if (bBrush == 0)
                            {
                                tblline.FillType = 0;
                            }
                            else
                            {
                                if (brushStyle == 0)
                                {
                                    tblline.FillType = 1;
                                }
                                else
                                {
                                    tblline.FillType = 2;
                                }

                            }
                            #endregion
                            #region BrushColor
                            fs.Read(b, 0, sizeof(int));
                            i1 = BitConverter.ToInt32(b, 0);
                            cc = Color.FromArgb((i1) & 0xff, (i1 >> 8) & 0xff, (i1 >> 16) & 0xff);
                            i1 = cc.ToArgb();
                            tblline.FillColor11 = cc;
                            tblline.FillColor12 = Color.Transparent;
                            tblline.FillColor21 = cc;
                            tblline.FillColor22 = Color.Transparent;
                            #endregion
                            #region BrushHatch
                            fs.Read(b, 0, sizeof(int));
                            tblline.HachStyle = BitConverter.ToInt32(b, 0);
                            #endregion
                            #endregion
                            
                            #region points

                            fs.Read(b, 0, sizeof(int));
                            tblline.Left = BitConverter.ToInt32(b, 0);
                            fs.Read(b, 0, sizeof(int));
                            tblline.Top = BitConverter.ToInt32(b, 0);

                            fs.Read(b, 0, sizeof(int));
                            tblline.Right = BitConverter.ToInt32(b, 0);
                            fs.Read(b, 0, sizeof(int));
                            tblline.Bottom = BitConverter.ToInt32(b, 0);

                            #endregion


                            fs.Read(b, 0, sizeof(int));
                            if ((int)b[0] != 0)
                            {
                                tblline.EndCap = (int)LineCap.ArrowAnchor;
                                tblline.StartCap = (int)LineCap.NoAnchor;
                            }
                            else
                            {
                                tblline.EndCap = (int)LineCap.NoAnchor;
                                tblline.StartCap = (int)LineCap.NoAnchor;
                            }

                            tblline.LinePaternScale = 2;
                            tblline.ArrowSize = tblline.BorderWidth * 5;
                            fs.Read(b, 0, sizeof(int));
                            tblline.Insert();
                            break;
                            #endregion
                        case STATIC_OBJ_TYPE.ID_ARC: break;
                        case STATIC_OBJ_TYPE.ID_TEXT:
                            #region Text
                            tblSymbolADText tbladtext = new tblSymbolADText();
                            tbladtext.SymbolStatusID = this.SymbolStatusID;
                            //fs.Read(b, 0, 20);

                            fs.Read(b, 0, sizeof(int));
                            tbladtext.Left = BitConverter.ToInt32(b, 0);
                            fs.Read(b, 0, sizeof(int));
                            tbladtext.Top = BitConverter.ToInt32(b, 0);
                            fs.Read(b, 0, sizeof(int));
                            tbladtext.Bottom = BitConverter.ToInt32(b, 0);
                            fs.Read(b, 0, sizeof(int));
                            tbladtext.Right = BitConverter.ToInt32(b, 0);
                            

                            fs.Read(b, 0, 100);
                            len = 0;
                            while (b[len] != 0)
                            {
                                len++;
                            }
                            //tbladtext.TextValue = Encoding.UTF8.GetString(b, 0, len);
                            tbladtext.TextValueDefult = Encoding.UTF8.GetString(b, 0, len);


                            fs.Read(b, 0, sizeof(int));
                            lfHeight = BitConverter.ToInt32(b, 0);
                            fs.Read(b, 0, sizeof(int));
                            lfWidth = BitConverter.ToInt32(b, 0);
                            fs.Read(b, 0, sizeof(int));
                            lfEscapement = BitConverter.ToInt32(b, 0);
                            fs.Read(b, 0, sizeof(int));
                            lfOrientation = BitConverter.ToInt32(b, 0);
                            fs.Read(b, 0, sizeof(int));
                            lfWeight = BitConverter.ToInt32(b, 0);
                            fs.Read(b, 0, sizeof(int));
                            lfItalic = Convert.ToBoolean(b[0]);
                            lfUnderline = Convert.ToBoolean(b[1]);
                            lfStrikeOut = Convert.ToBoolean(b[2]);
                            lfCharSet = b[3];
                            fs.Read(b, 0, sizeof(int));
                            lfOutPrecision = b[0];
                            lfClipPrecision = b[1];
                            lfQuality = b[2];
                            lfPitchAndFamily = b[3];

                            fs.Read(b, 0, 32);
                            len = 0;
                            while (b[len] != 0)
                            {
                                len++;
                            }
                            lfFaceName = Encoding.UTF8.GetString(b, 0, len);
                            FontStyle fontStyle = ((lfWeight == 700) ? FontStyle.Bold : FontStyle.Regular) |
                                                        ((bool)lfItalic ? FontStyle.Italic : FontStyle.Regular) |
                                                        ((bool)lfUnderline ? FontStyle.Underline : FontStyle.Regular) |
                                                        ((bool)lfStrikeOut ? FontStyle.Strikeout : FontStyle.Regular);

                            ManagedFont = new Font(lfFaceName, System.Math.Abs(lfHeight) - 3, fontStyle);

                             cvt = new FontConverter();
                            
                            
                            
                            tbladtext.Font = cvt.ConvertToString(ManagedFont);
                            fs.Read(b, 0, sizeof(int));
                            i1 = BitConverter.ToInt32(b, 0);
                            cc = Color.FromArgb((i1) & 0xff, (i1 >> 8) & 0xff, (i1 >> 16) & 0xff);
                            i1 = cc.ToArgb();
                            tbladtext.TextColorDefult = cc;
                            i1 = BitConverter.ToInt32(b, 0);
                            i1 = (i1) & 0xff + (i1 >> 8) & 0xff + (i1 >> 16) & 0xff;
                            //tbladtext.TextColor = i1.ToString();

                            fs.Read(b, 0, sizeof(int));

                            fs.Read(b, 0, sizeof(int));
                            //tbladtext.TextBlinking = Convert.ToBoolean(b[0]).ToString();
                            tbladtext.TextBlinkingDefult = Convert.ToBoolean(b[0]);
                            fs.Read(b, 0, sizeof(int));
                            tbladtext.Insert();
                            break;
                            #endregion
                        case STATIC_OBJ_TYPE.ID_BARGRAPH: break;

                        case STATIC_OBJ_TYPE.ID_ANATEXT: break;
                        case STATIC_OBJ_TYPE.ID_EDITBOX: break;

                        case STATIC_OBJ_TYPE.ID_BUTTON: break;
                        case STATIC_OBJ_TYPE.ID_DIGTEXT: break;
                    }
                }

            }
            
        }
	}
	
	
	public partial class tblSymbolStatusCollection 
    {
        

        public override bool Load()
        {
            bool ret = true;
            List<long> idlist = new List<long>();
            SQLiteConnection _SqlConnectionConnection = new SQLiteConnection(Common.ConnectionString);
            SQLiteDataReader myReader = null;
            SQLiteCommand myCommand = new SQLiteCommand();
            if (_SqlConnectionConnection.State == System.Data.ConnectionState.Open)
                _SqlConnectionConnection.Close();
            _SqlConnectionConnection.ConnectionString = Common.ConnectionString;
            _SqlConnectionConnection.Open();

            try
            {
                myReader = null;
                myCommand.CommandText = @"SELECT * FROM [tblSymbolStatus] WHERE [SymbolID]= " + this.m_SymbolID_tblSymbols.SymbolID + " order by StatusNo;";
                myCommand.Connection = _SqlConnectionConnection;
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    idlist.Add(myReader.GetInt64(myReader.GetOrdinal("SymbolStatusID")));
                }

                myReader.Close();
                myCommand.Dispose();
                _SqlConnectionConnection.Close();

                foreach (long id in idlist)// (int i = 0; i < count ; i++)
                {
                    tblSymbolStatus tblsymbolstatus = new tblSymbolStatus();
                    tblsymbolstatus.SymbolStatusID = id;
                    tblsymbolstatus.m_SymbolID_tblSymbols = this.m_SymbolID_tblSymbols;
                    tblsymbolstatus.Select();

                    this.Add(tblsymbolstatus);
                }

            }
            catch (SQLiteException ae)
            {
                System.Windows.Forms.MessageBox.Show(ae.Message);
                return false;
            }



            return ret;
        }
	}
}