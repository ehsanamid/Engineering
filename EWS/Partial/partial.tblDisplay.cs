using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Text;
using DockSample;
using DCS.DCSTables;
using DocToolkit;
using System.Drawing;
using System.IO;
using System.Drawing.Drawing2D;
using System.Diagnostics;
using DCS.Tools;
using DCS.Draw;
using System.Windows.Forms;
using DCS.TabPages;
using DCS.TableObject;


namespace DCS.DCSTables
{

    public partial class tblDisplay
    {
        
        #region Graphical Members
        //private DrawingDoc _drawingdoc;
        //public DrawingDoc m_DrawingDoc
        //{
        //    get { return _drawingdoc; }
        //    set { _drawingdoc = value; }
        //}
        #endregion

        private PageList _pages;
        public PageList Pages
        {
            get
            {
                return _pages;
            }
            set
            {
                _pages = value;
            }
        }


        public CrossReference crossreference = new CrossReference();

        #region Public Methods

        
        public int m_x;
        public int m_y;
        //public static int GetDisplayID(string ConnectionString, string displayname)
        //{
        //    int ret = -1;
        //    int count = 0;
        //    try
        //    {
        //        if (Common.Conn == null)
        //        {
        //            Common.Conn = new SQLiteConnection(Common.ConnectionString+"; Password="+Common.PassString+Common.WordString+";");
        //            Common.Conn.Open();
        //        }
        //        SQLiteCommand Com = Common.Conn.CreateCommand();
        //        //SELECT [DisplayName],  [DomainID], [FullPath], [ParrentDisplay], [IsDisplay], [oIndex], [BackColor], [Grid], [Grid_X], [Grid_Y], [Snap], [Snap_X], [Snap_Y], [Footer], [Prepair], [Approved], [DocNo], [SheetNo], [Description], [Revision], [LastUpdate] FROM [tblDisplay] WHERE [DisplayID]=@DisplayID
        //        Com.CommandText = "SELECT [DisplayID] FROM [tblDisplay] WHERE [DisplayName]= '" + displayname + "'";
        //        //Com.Parameters.AddRange(GetSqlParameters());
        //        //Conn.Open();
        //        SQLiteDataReader rs = Com.ExecuteReader();
        //        while (rs.Read())
        //        {

        //            ret = rs.GetInt32(rs.GetOrdinal("DisplayID"));
        //            count++;
        //        }
        //        rs.Close();
        //        //Conn.Close();
        //        rs.Dispose();
        //        Com.Dispose();
        //        //Conn.Dispose();
        //    }
        //    catch (System.Exception)
        //    {

        //    }
        //    if (count == 1)
        //    {
        //        return ret;
        //    }
        //    if (count > 1)
        //    {
        //        return -1 * count;
        //    }
        //    return -1;
        //}

        public static bool GetNewDisplayName(long _domainid, ref string strDisplayName)
        {


            if (Common.Conn == null)
            {
                Common.Conn = new SQLiteConnection(Common.ConnectionString);
                Common.Conn.Open();
            }

            int No = 1;
            string str = strDisplayName;
            string str1 = "dd";
            bool findnewname = false;
            SQLiteDataReader myReader = null;
            SQLiteCommand myCommand = new SQLiteCommand();
            //if (_SqlConnectionConnection.State == System.Data.ConnectionState.Open)
            //    _SqlConnectionConnection.Close();
            //_SqlConnectionConnection.ConnectionString = Common.ConnectionString;
            //_SqlConnectionConnection.Open();
            try
            {
                findnewname = false;
                No = 1;
                while (findnewname == false)
                {
                    myReader = null;
                    str1 = str + No.ToString();
                    //myCommand = new SqlCommand("Select Name from tblDomain where (Name = " + i.ToString() + ")", conn);
                    myCommand.CommandText = "Select DisplayName,DomainID from tblDisplay where (DisplayName = '" + str1 + "' and DomainID = '" + _domainid + "')";
                    myCommand.Connection = Common.Conn;
                    myReader = myCommand.ExecuteReader();
                    if (myReader.HasRows == false)
                    {
                        findnewname = true;
                    }
                    else
                    {
                        No++;
                    }
                    myReader.Close();
                    myCommand.Dispose();

                }
                strDisplayName = str1;
            }
            catch (SQLiteException ae)
            {
                System.Windows.Forms.MessageBox.Show(ae.Message);
                return false;
            }

            //_SqlConnectionConnection.Close();
            return true;
        }
        //delete from tblline;
        //delete from tblpolyline;
        //delete from tblrect;
        //delete from tbltext  ;
        //delete from tblbitmap;

        public int ClearContent()
        {
            try
            {
                if (Common.Conn == null)
                {
                    Common.Conn = new SQLiteConnection(Common.ConnectionString);
                    Common.Conn.Open();
                }
                SQLiteCommand Com = Common.Conn.CreateCommand();
                SQLiteCommand ComSync = Common.Conn.CreateCommand();
                Com.CommandText = "delete from tblline where DisplayID = " + DisplayID;
                ComSync.CommandText = "PRAGMA foreign_keys=ON";
                Com.Parameters.AddRange(GetSqlParameters());
                //Conn.Open();
                ComSync.ExecuteNonQuery();
                int rowseffected = Com.ExecuteNonQuery();
                Com.CommandText = "delete from tblpolyline where DisplayID = " + DisplayID;
                rowseffected = Com.ExecuteNonQuery();
                Com.CommandText = "delete from tblrect where DisplayID = " + DisplayID;
                rowseffected = Com.ExecuteNonQuery();
                Com.CommandText = "delete from tblline where DisplayID = " + DisplayID;
                rowseffected = Com.ExecuteNonQuery();
                Com.CommandText = "delete from tblbitmap where DisplayID = " + DisplayID;
                rowseffected = Com.ExecuteNonQuery();
                Com.CommandText = "delete from tbladtext where DisplayID = " + DisplayID;
                rowseffected = Com.ExecuteNonQuery();
                //Conn.Close();
                ComSync.Dispose();
                Com.Dispose();
                //Conn.Dispose();
                return rowseffected;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return 0;
        }


        public void LoadDisplay(TabGraphicPageControl tabdisplaypagecontrol)
        {

            //GraphicsList graphicslist = new Draw.GraphicsList();
            Pages = new PageList(tabdisplaypagecontrol);
            

            foreach (tblBitmap tblbitmap in m_tblBitmapCollection)
            {
                DrawImage obj = new DrawImage(Pages);
                obj.Load(tblbitmap);
                Pages.GraphicPagesList[Pages.ActivePageNo].Add(obj);
            }
            foreach (tblADText tbladtext in m_tblADTextCollection)
            {

                DrawText obj = new DrawText(Pages);
                obj.Load(tbladtext);
                Pages.GraphicPagesList[Pages.ActivePageNo].Add(obj);
            }
            foreach (tblLine tblline in m_tblLineCollection)
            {
                DrawLine obj = new DrawLine(Pages);
                obj.Load(tblline);
                Pages.GraphicPagesList[Pages.ActivePageNo].Add(obj);
            }
            foreach (tblRect tblrect in m_tblRectCollection)
            {
                switch ((STATIC_OBJ_TYPE)tblrect.Type)
                {
                    case STATIC_OBJ_TYPE.ID_ELLIPS:
                        DrawEllipse drawellipse = new DrawEllipse(Pages);
                        drawellipse.Load(tblrect);
                        Pages.GraphicPagesList[Pages.ActivePageNo].Add(drawellipse);
                        break;
                    case STATIC_OBJ_TYPE.ID_ROUNDRECT:
                    case STATIC_OBJ_TYPE.ID_RECT:
                        DrawRectangle drawrectangle = new DrawRectangle(Pages);
                        drawrectangle.Load(tblrect);
                        Pages.GraphicPagesList[Pages.ActivePageNo].Add(drawrectangle);
                        break;
                }
            }
            foreach (tblPolyline tblpolyline in m_tblPolylineCollection)
            {
                DrawPolyLine drawpolyline = new DrawPolyLine(Pages);
                drawpolyline.Load(tblpolyline);
                Pages.GraphicPagesList[Pages.ActivePageNo].Add(drawpolyline);
            }
            foreach (tblPolygon tblpolygon in m_tblPolygonCollection)
            {
                DrawPolygon drawpolygon = new DrawPolygon(Pages);
                drawpolygon.Load(tblpolygon);
                Pages.GraphicPagesList[Pages.ActivePageNo].Add(drawpolygon);
            }
            foreach (tblCurve tblcurve in m_tblCurveCollection)
            {
                DrawCurve drawcurve = new DrawCurve(Pages);
                drawcurve.Load(tblcurve);
                Pages.GraphicPagesList[Pages.ActivePageNo].Add(drawcurve);
            }
            Pages.GraphicPagesList[Pages.ActivePageNo].SortoIndex();
        }

        public void ClearDisplayCollections()
        {
            m_tblADTextCollection.Clear();
            m_tblBargraphCollection.Clear();
            m_tblBiasCollection.Clear();
            m_tblBitmapCollection.Clear();
            m_tblBlockCollection.Clear();
            m_tblButtonCollection.Clear();
            m_tblCurveCollection.Clear();
            m_tblEditBoxCollection.Clear();
            m_tblEllipseCollection.Clear();
            m_tblLineCollection.Clear();
            m_tblMeterCollection.Clear();
            m_tblNavigationCollection.Clear();
            m_tblPolygonCollection.Clear();
            m_tblPolylineCollection.Clear();
            m_tblRectCollection.Clear();
            m_tblTextCollection.Clear();
            m_tblTrendCollection.Clear();

            m_tblADTextCollection = null;
            m_tblBargraphCollection = null;
            m_tblBiasCollection = null;
            m_tblBitmapCollection = null;
            m_tblBlockCollection = null;
            m_tblButtonCollection = null;
            m_tblCurveCollection = null;
            m_tblEditBoxCollection = null;
            m_tblEllipseCollection = null;
            m_tblLineCollection = null;
            m_tblMeterCollection = null;
            m_tblNavigationCollection = null;
            m_tblPolygonCollection = null;
            m_tblPolylineCollection = null;
            m_tblRectCollection = null;
            m_tblTextCollection = null;
            m_tblTrendCollection = null;
        }

#if EWSAPP
        public bool SaveDisplay()
        {
            bool ret = true;
            string str = "";


            //m_tblLineCollection.Clear();
            //m_tblBitmapCollection.Clear();
            //m_tblRectCollection.Clear();
            //m_tblPolylineCollection.Clear();
            //m_tblADTextCollection.Clear();
            int i = 0;
            // this.Update();
            foreach (DrawObject o in Pages.GraphicPagesList[0].List)
            {
                i++;
                if (o.Dirty)
                {
                    str = o.GetType().ToString();
                    switch (str)
                    {
                        case "DCS.Draw.Curve":
                            o.Save(this.DisplayID, Pages.ActivePageNo);
                            break;
                        case "DCS.Draw.DrawEllipse":
                            o.Save(this.DisplayID, i);
                            break;
                        case "DCS.Draw.DrawImage":
                            o.Save(this.DisplayID, i);
                            break;
                        case "DCS.Draw.DrawLine":
                            o.Save(this.DisplayID, i);
                            break;
                        case "DCS.Draw.DrawPolyLine":
                            o.Save(this.DisplayID, i);
                            break;
                        case "DCS.Draw.DrawPolygon":
                            o.Save(this.DisplayID, i);
                            break;
                        case "DCS.Draw.DrawCurve":
                            o.Save(this.DisplayID, i);
                            break;
                        case "DCS.Draw.DrawRectangle":
                            o.Save(this.DisplayID, i);
                            break;
                        case "DCS.Draw.DrawText":
                            o.Save(this.DisplayID, i);
                            break;
                    }
                }
            }

            foreach (DeleteListStruc deleteliststruc in Pages.Parenttabgraphicpagecontrol.DeleteList)
            {
                if (deleteliststruc.ID != -1)
                {
                    switch ((STATIC_OBJ_TYPE)deleteliststruc.Type)
                    {
                        case STATIC_OBJ_TYPE.ID_BITMAP:
                            tblBitmap tblbitmap = new tblBitmap();
                            tblbitmap.ID = deleteliststruc.ID;
                            tblbitmap.Delete();
                            break;
                        case STATIC_OBJ_TYPE.ID_ANATEXT:
                        case STATIC_OBJ_TYPE.ID_TEXT:
                            tblADText tbladtext = new tblADText();
                            tbladtext.ID = deleteliststruc.ID;
                            tbladtext.Delete();
                            break;
                        case STATIC_OBJ_TYPE.ID_LINE:
                            tblLine tblline = new tblLine();
                            tblline.ID = deleteliststruc.ID;
                            tblline.Delete();
                            break;
                        case STATIC_OBJ_TYPE.ID_ELLIPS:
                        case STATIC_OBJ_TYPE.ID_ROUNDRECT:
                        case STATIC_OBJ_TYPE.ID_RECT:
                            tblRect tblRect = new tblRect();
                            tblRect.ID = deleteliststruc.ID;
                            tblRect.Delete();
                            break;
                        case STATIC_OBJ_TYPE.ID_POLYLINE:
                            tblPolyline tblpolyline = new tblPolyline();
                            tblpolyline.ID = deleteliststruc.ID;
                            tblpolyline.Delete();
                            break;
                        case STATIC_OBJ_TYPE.ID_POLYGON:
                            tblPolygon tblpolygon = new tblPolygon();
                            tblpolygon.ID = deleteliststruc.ID;
                            tblpolygon.Delete();
                            break;
                        case STATIC_OBJ_TYPE.ID_CURVE:
                            tblCurve tblcurve = new tblCurve();
                            tblcurve.ID = deleteliststruc.ID;
                            tblcurve.Delete();
                            break;

                    }


                }
            }
            Pages.Parenttabgraphicpagecontrol.DeleteList.Clear();

            return ret;
        }

#endif
        
        #endregion

#if EWSAPP
        public void DisplayObjectCopy(DisplayObject tocopy)
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
#endif
    }

    public partial class tblDisplayCollection
    {

        


        public override bool Load(/*long _domainid*/)
        {
            bool ret = true;
            List<long> idlist = new List<long>();
            if (Common.Conn == null)
            {
                Common.Conn = new SQLiteConnection(Common.ConnectionString);
                Common.Conn.Open();
            }
            SQLiteDataReader myReader = null;
            SQLiteCommand myCommand = new SQLiteCommand();
            //if (_SqlConnectionConnection.State == System.Data.ConnectionState.Open)
            //    _SqlConnectionConnection.Close();
            //_SqlConnectionConnection.ConnectionString = Common.ConnectionString;
            //_SqlConnectionConnection.Open();

            try
            {
                myReader = null;
                myCommand.CommandText = @"SELECT * FROM [tblDisplay]  WHERE [SolutionID]= " + this.m_SolutionID_tblSolution.SolutionID + " order by oIndex;";
                myCommand.Connection = Common.Conn;
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    idlist.Add(myReader.GetInt64(myReader.GetOrdinal("DisplayID")));
                }

                myReader.Close();
                myCommand.Dispose();
                //_SqlConnectionConnection.Close();

                foreach (long id in idlist)// (int i = 0; i < count ; i++)
                {
                    tblDisplay tbldisplay = new tblDisplay();

                    tbldisplay.DisplayID = id;
                    tbldisplay.m_SolutionID_tblSolution = this.m_SolutionID_tblSolution;
                    tbldisplay.Select();
                   // tbldisplay.LoadPicFile();
                    //tbldisplay.m_tblPouCollection.Load(_connectionstring, tbldisplay.DisplayID);
                    this.Add(tbldisplay);
                }

            }
            catch (SQLiteException ae)
            {
                System.Windows.Forms.MessageBox.Show(ae.Message);
                return false;
            }

            return ret;
        }

        [Description("Search collection for DisplayID and returns display.")]
        public tblDisplay SearchID(long _id)
        {
            foreach (tblDisplay tbldisplay in List)
            {
                if (tbldisplay.DisplayID == _id)
                {
                    return tbldisplay;
                }
            }
            return null;
        }
    }


}
