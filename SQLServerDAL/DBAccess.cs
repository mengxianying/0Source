using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Maticsoft.DBUtility;
using Pbzx.Model;

namespace Pbzx.SQLServerDAL
{
    public abstract class DBAccess
    {
        public DataSet GetDataSet(StoredProcedureName storedProcedureName, params SqlParameter[] cmdParms)
        {
            return SQLHelper.GetDataSet(DbHelperSQL.ConnectionString, CommandType.StoredProcedure, storedProcedureName.ToString(), cmdParms);
        }

        public int ExecuteNonQuery(StoredProcedureName storedProcedureName, params SqlParameter[] cmdParms)
        {
            return SQLHelper.ExecuteNonQuery(DbHelperSQL.ConnectionString, CommandType.StoredProcedure, storedProcedureName.ToString(), cmdParms);
        }

        public SqlDataReader ExecuteReader(StoredProcedureName storedProcedureName, params SqlParameter[] cmdParms)
        {
            return SQLHelper.ExecuteReader(DbHelperSQL.ConnectionString, CommandType.StoredProcedure, storedProcedureName.ToString(), cmdParms);
        }
    }
}
