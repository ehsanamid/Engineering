using System;
//using DocToolkit.Project_Objects;
using System.Data;
using System.Data.SqlClient;

//using DocToolkit;

namespace DCS.Tools
{
    public class DCSSolution
	{
		
        public static SqlParameter AddSqlParm(string ParmName, object Value, SqlDbType Sqltype)
        {
            return AddSqlParm(ParmName, Value, Sqltype, -1);
        }

        public static SqlParameter AddSqlParm(string ParmName, object Value, SqlDbType Sqltype, int SqlSize)
        {

            SqlParameter genSqlData;
            if ((SqlSize == -1))
                genSqlData = new SqlParameter(ParmName, Sqltype);
            else
                genSqlData = new SqlParameter(ParmName, Sqltype, SqlSize);
            if ((Value == null))
                genSqlData.Value = DBNull.Value;
            else
                genSqlData.Value = Value;
            return genSqlData;
        }
        public enum SQL_String : int
        {
            _SQL_Select = 0,
            _SQL_Insert,
            _SQL_Update,
            _SQL_Delete,
            _SQL_Rename
        }

		#region Constructor


		public DCSSolution()
		{
           
		}
		

		#endregion
		

	}

	

}
