
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Data;
	using System.Data.SQLite;
	using System.Text;
namespace DCS.DCSTables
{

    public partial class tblBoardType 
	{
        
        #region Related Objects
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
        #endregion
		
	}

    public partial class tblBoardTypeCollection 
	
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
            //SQLiteConnection _SqlConnectionConnection = new SQLiteConnection(Common.ConnectionString);
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
                myCommand.CommandText = @"SELECT * FROM [tblBoardtypes] ;";
                myCommand.Connection = Common.Conn;
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    idlist.Add(myReader.GetInt64(myReader.GetOrdinal("BoardTypeNameID")));

                }

                myReader.Close();
                myCommand.Dispose();
                //_SqlConnectionConnection.Close();
                int count = idlist.Count;
                foreach (long id in idlist)// (int i = 0; i < count ; i++)
                {
                    tblBoardType tblboardtype = new tblBoardType();
                    tblboardtype.BoardTypeNameID = id;// idlist[i];
                    tblboardtype.m_SolutionID_tblSolution = this.m_SolutionID_tblSolution;
                    tblboardtype.Select();
                   
                    this.Add(tblboardtype);
                }
                //"SELECT [FunctionName], [Description], [Type], [IsStandard], [FunctionGroup], [Extensible], [IsFunction], [Body], [Language] FROM [tblFunction] WHERE [FunctionID]=@FunctionID ";
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
