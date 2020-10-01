
using DCS.TypeConverters;
using DCS.DCSTables;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing.Design;
using System.Text;
using System.Windows.Forms;
using DCS.TableObject;
#if OWSAPP
using ENG.Types;
#endif
namespace DCS.DCSTables
{


    public partial class tblVariable
    {
#if OWSAPP
		public CANY RealTimeData;// = new CANY();
#endif       
        /// <remarks>Represents the foreign key object</remarks>
        private List<tblVariable> _tblFInstanceVariableList = null;

        [Description("Represents the foreign key object of the type pouID")]
        public List<tblVariable> m_tblFInstanceVariableList
        {
            get
            {
                if (_tblFInstanceVariableList == null)
                {
                    _tblFInstanceVariableList = new List<tblVariable>();
                    LoadLinkedVariable();
                }
                return _tblFInstanceVariableList;
            }
            set
            {
                _tblFInstanceVariableList = value;
            }
        }

        public bool LoadLinkedVariable()
        {
            bool ret = true;

            try
            {
                m_tblFInstanceVariableList.Clear();
                List<long> idlist = new List<long>();
                if (Common.Conn == null)
                {
                    Common.Conn = new SQLiteConnection(Common.ConnectionString);
                    Common.Conn.Open();
                }
                SQLiteDataReader myReader = null;
                SQLiteCommand myCommand = Common.Conn.CreateCommand();
                myReader = null;
                myCommand.CommandText = @"SELECT * FROM [tblVariable]  WHERE [ParentVarID]= " + this.VarNameID + ";";
                myCommand.Connection = Common.Conn;
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    idlist.Add(myReader.GetInt64(myReader.GetOrdinal("VarNameID")));
                }

                myReader.Close();
                myCommand.Dispose();

                foreach (long id in idlist)// (int i = 0; i < count ; i++)
                {
                    tblVariable tblvariable = new tblVariable();
                    tblvariable.VarNameID = id;
                    tblvariable.Select();
                    m_tblFInstanceVariableList.Add(tblvariable);
                }
            }
            catch (SQLiteException ae)
            {
                MessageBox.Show(ae.Message);
                return false;
                
            }
            return ret;
        }

        public bool DeleteLinkedVariable()
        {

            try
            {
                if (Common.Conn == null)
                {
                    Common.Conn = new SQLiteConnection(Common.ConnectionString);
                    Common.Conn.Open();
                }
                this.PreDeleteTriger();
                SQLiteCommand Com = Common.Conn.CreateCommand();
                SQLiteCommand ComSync = Common.Conn.CreateCommand();
                Com.CommandText = tblVariable.SQL_Delete;
                ComSync.CommandText = @"Delete FROM [tblVariable]  WHERE [ParentVarID]= " + this.VarNameID + ";";
                Com.Parameters.AddRange(GetSqlParameters());
                ComSync.ExecuteNonQuery();
                int rowseffected = Com.ExecuteNonQuery();
                ComSync.Dispose();
                Com.Dispose();
                this.PostDeleteTriger();
                return true;
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }

        public override bool PreDeleteTriger()
        {
            // if (!Common.IsSimpleType(this.Type) )
            {
                if (Common.Conn == null)
                {
                    Common.Conn = new SQLiteConnection(Common.ConnectionString);
                    Common.Conn.Open();
                }

                SQLiteCommand Com = Common.Conn.CreateCommand();
                SQLiteCommand ComSync = Common.Conn.CreateCommand();
                Com.CommandText = "DELETE FROM [tblVariable] WHERE [ParentVarID]=" + this.VarNameID + ";";
                ComSync.CommandText = "PRAGMA foreign_keys=ON";

                ComSync.ExecuteNonQuery();
                int rowseffected = Com.ExecuteNonQuery();
                ComSync.Dispose();
                Com.Dispose();

                return true;

            }
            //return true;
        }
        

        #region Public Methods

#if OWSAPP
        public void InitCANY()
        {
            switch ((VarType)this.Type)
            {
                case VarType.BOOL:
                    RealTimeData = new CBOOL();
                    break;
                case VarType.REAL:
                    RealTimeData = new CREAL();
                    break;
                default:
                    RealTimeData = new CANY();
                    break;
            }
        }
#endif
        public void setInitPinState()
        {
            InitialVal = "";
            PinState = "";
            if (this.Type != 0)
            {
                tblFunction _tblfunction = tblSolution.m_tblSolution().GetFunctionFromType(this.Type);
                if (_tblfunction != null)
                {
                    for (int i = 0; i < _tblfunction.m_tblFormalParameterCollection.Count; i++)
                    {
                        InitialVal += _tblfunction.m_tblFormalParameterCollection[i].InitializeValue;
                        InitialVal += ";";
                        if ((_tblfunction.m_tblFormalParameterCollection[i].Class == (int)VarClass.Input) ||
                            (_tblfunction.m_tblFormalParameterCollection[i].Class == (int)VarClass.InOut) ||
                            (_tblfunction.m_tblFormalParameterCollection[i].Class == (int)VarClass.Output))
                        {
                            PinState += "TRUE";
                            PinState += ";";
                        }
                        else
                        {
                            PinState += "FALSE";
                            PinState += ";";
                        }
                    }
                    // InitialVal.Remove(InitialVal.Length - 1);
                }
            }
        }



        

        public bool HasLinkedVariable()
        {
            if (Common.IsFunctionType(this.Type))
            {
                return true;
            }
            return false;
        }

        public tblVariable ReturnOutputVariableofFunction()
        {
            if (HasLinkedVariable())
            {
                LoadLinkedVariable();
                foreach (tblVariable _tblvariable in m_tblFInstanceVariableList)
                {
                    if (_tblvariable.Class == (int)VarClass.Output)
                    {
                        return _tblvariable;
                    }
                }
            }
            return null;
        }


        //public static bool checkVariableName(long __domainid,long __controllerid,long __pouid,string __instansename)
        public static bool checkVariableName(string __instansename, long __pouid)
        {

            //select  varname from tblvariable,tblpou,tblcontroller,tbldomain where [tbldomain].[DomainID] = [tblcontroller].[DomainID] and [tblcontroller].[ControllerID] = [tblpou].[pouID] and [tblpou].[pouID] = [tblvariable].[pouID] and [tblvariable].[VarName] = "ddd"; 
            bool ret = false;
            SQLiteConnection _SqlConnectionConnection = new SQLiteConnection(Common.ConnectionString);
            SQLiteDataReader myReader = null;
            SQLiteCommand myCommand = new SQLiteCommand();
            if (_SqlConnectionConnection.State == System.Data.ConnectionState.Open)
                _SqlConnectionConnection.Close();
            _SqlConnectionConnection.ConnectionString = Common.ConnectionString;
            _SqlConnectionConnection.Open();
            //SELECT [VarName], [pouID], [Description], [InitialVal], [Type], [Class], [Option], [oIndex], [LocalIndex], [UniqueName] FROM [tblVariable] WHERE [VarNameID]=@VarNameID ";
            try
            {
                myReader = null;
                //myCommand.CommandText = @"SELECT tblVariable.VarName FROM (tblVariable INNER JOIN tblPou ON tblVariable.pouID = tblPou.pouID)  INNER JOIN tblController ON tblPou.ControllerID = tblController.ControllerID WHERE (((tblVariable.VarName)='" + __instansename +"') AND ((tblPou.pouID)= " + __pouid + ") AND ((tblController.ControllerID)= "+ __controllerid +") AND ((tblController.DomainID)=" + __domainid+ "));";
                myCommand.CommandText = @"SELECT tblVariable.VarName FROM tblVariable WHERE ( ((tblVariable.VarName)='" + __instansename + "') AND ((tblVariable.pouID)= " + __pouid + "));";
                myCommand.Connection = _SqlConnectionConnection;
                myReader = myCommand.ExecuteReader();
                if (myReader.Read())
                {
                    ret = true;
                }

                myReader.Close();
                myCommand.Dispose();
                _SqlConnectionConnection.Close();


            }
            catch (SQLiteException ae)
            {
                System.Windows.Forms.MessageBox.Show(ae.Message);
                return false;
            }

            return ret;
        }
#if EWSAPP

        public void CopyVariableGrid(VariableGrid tocopy)
        {
            this.VarName = tocopy.VarName;
            this.VarNameID = tocopy.VarNameID;
            this.pouID = tocopy.pouID;
            this.Description = tocopy.Description;
            this.InitialVal = tocopy.InitialVal;
            this.Type = tocopy.Type;
            this.Option = (int)tocopy.Option;
            this.PlantStructureID = tocopy.PlantStructureID;
            this.DispalyID = tocopy.DispalyID;
            this.AEB = tocopy.AEB;
            this.ALB = tocopy.ALB;
            this.SampleTime = tocopy.SampleTime;
            this.RTT = tocopy.RTT;
            this.Interval = tocopy.Interval;
            this.Archive = tocopy.Archive;
            this.ArchiveInterval = tocopy.ArchiveInterval;
            bool found = false;
            tblAlarm tblaralm;
            int count = m_tblAlarmCollection.Count;
            for (int i = count - 1; i >= 0; i--)
            {
                found = false;
                tblaralm = m_tblAlarmCollection[i];
                foreach (AlarmObject alarmobject in tocopy.m_AlarmCollection)
                {
                    if (tblaralm.ID == alarmobject.ID)
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    tblaralm.Delete();
                    m_tblAlarmCollection.Remove(tblaralm);
                }
            }

            foreach (AlarmObject alarmobject in tocopy.m_AlarmCollection)
            {
                if (alarmobject.ID == -1)
                {
                    tblAlarm tblalarm = new tblAlarm();
                    tblalarm.AlarmObjectCopy(alarmobject);
                    tblalarm.Insert();
                    m_tblAlarmCollection.Add(tblalarm);
                }
                else
                {
                    foreach (tblAlarm tblalarm in m_tblAlarmCollection)
                    {
                        if (tblalarm.ID == alarmobject.ID)
                        {
                            tblalarm.AlarmObjectCopy(alarmobject);
                            tblalarm.Update();
                        }
                    }
                }

            }
        }

#endif




        #endregion


    }

    public partial class tblVariableCollection 
    {


        public override bool Load()
        {
            bool ret = true;
            //List<long> idlist = new List<long>();

            if (Common.Conn == null)
            {
                Common.Conn = new SQLiteConnection(Common.ConnectionString);
                Common.Conn.Open();
            }
            SQLiteTransaction tr = Common.Conn.BeginTransaction();
            SQLiteDataReader myReader = null;
            SQLiteCommand myCommand = new SQLiteCommand();
            try
            {
                myReader = null;
                myCommand.CommandText = @"SELECT * FROM [tblVariable]  WHERE [pouID]= " + m_pouID_tblPou.pouID + ";";
                myCommand.Connection = Common.Conn;
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    //idlist.Add(myReader.GetInt64(myReader.GetOrdinal("VarNameID")));
                    tblVariable tblvariable = new tblVariable();
                    tblvariable.m_pouID_tblPou = m_pouID_tblPou;
                    tblvariable.AddFromRecordSet(myReader);
#if OWSAPP
                    tblvariable.InitCANY(); 
#endif
                    this.Add(tblvariable);
                }

                myReader.Close();
                myCommand.Dispose();
                //_SqlConnectionConnection.Close();

                //foreach (long id in idlist)// (int i = 0; i < count ; i++)
                //{
                //    tblVariable tblvariable = new tblVariable();
                //    tblvariable.VarNameID = id;
                //    tblvariable.m_pouID_tblPou = m_pouID_tblPou;
                //    tblvariable.Select();
                //    this.Add(tblvariable);
                //}
                tr.Commit();
            }
            catch (SQLiteException ae)
            {
                MessageBox.Show(ae.Message.ToString());
                return false;
                // 
            }

            return ret;
        }
        public bool SearchForVarName(string _varname, ref long _id, ref int _type)
        {
            foreach (tblVariable tblvariable in List)
            {
                if (tblvariable.VarName.ToLower() == _varname.ToLower())
                {
                    _id = tblvariable.VarNameID;
                    _type = tblvariable.Type;
                    return true;
                }
            }
            return false;
        }
    }


}
