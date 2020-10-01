
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
namespace DCS.DCSTables
{

    public partial class tblSymbols 
	{
        
        //private tblSolution _SolutionID_tblSolution;

        //[Description("Represents the foreign key object of the type SolutionID")]
        //public tblSolution m_SolutionID_tblSolution
        //{
        //    get
        //    {
        //        return _SolutionID_tblSolution;
        //    }
        //    set
        //    {
        //        _SolutionID_tblSolution = value;
        //    }
        //}

        public void LoadSymbolFiles()
        {
            string path = Common.ProjectPath + "Blocks" + this.FullPath ;
            
            string nostr;
            byte no = 0; ;
            string symbloname;
            string[] filePaths = Directory.GetFiles(path, "*.blk");

            foreach (string str in filePaths)
            {
                symbloname = str.Substring(0, str.Length - 4);
                nostr = str.Substring(str.Length - 7,3);
                try
                {
                    no = byte.Parse(nostr);
                }
                catch (FormatException e)
                {
                    Trace.WriteLine(e.Message);
                }
                tblSymbolStatus tblsymbolstatus = new tblSymbolStatus();
                tblsymbolstatus.m_SymbolID_tblSymbols = this;
                tblsymbolstatus.SymbolID = this.SymbolID;
                tblsymbolstatus.StatusNo = no;
                tblsymbolstatus.Insert();
                tblsymbolstatus.LoadSymbolFile(str);
                this.m_tblSymbolStatusCollection.Add(tblsymbolstatus);

                
            }

            

        }
        
	}

    public partial class tblSymbolsCollection 
	{
        

        /// <remarks>Represents the foreign key object</remarks>
        //private tblSolution _SolutionID_tblSolution;

        //[Description("Represents the foreign key object of the type SolutionID")]
        //public tblSolution m_SolutionID_tblSolution
        //{
        //    get
        //    {
        //        return _SolutionID_tblSolution;
        //    }
        //    set
        //    {
        //        _SolutionID_tblSolution = value;
        //    }
        //}


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
                myCommand.CommandText = @"SELECT * FROM [tblSymbols] ";
                myCommand.Connection = _SqlConnectionConnection;
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    idlist.Add(myReader.GetInt64(myReader.GetOrdinal("SymbolID")));
                }

                myReader.Close();
                myCommand.Dispose();
                _SqlConnectionConnection.Close();

                foreach (long id in idlist)// (int i = 0; i < count ; i++)
                {
                    tblSymbols tblsymbols = new tblSymbols();
                    tblsymbols.SymbolID = id;
                    tblsymbols.m_SolutionID_tblSolution = this.m_SolutionID_tblSolution;
                    tblsymbols.Select();
                    //tblsymbols.m_tblSymbolStatusCollection.Load();
                    this.Add(tblsymbols);
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
