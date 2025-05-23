using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Pbzx.Model;

namespace Pbzx.SQLServerDAL
{

        public class HelpDal : DBAccess
        {
            public int SelectMaxID(string tableName, string fieldName)
            {
                SqlParameter[] parms ={
                new SqlParameter("@TableName",tableName),
                new SqlParameter("@FieldName",fieldName)
            };

                using (SqlDataReader dr = base.ExecuteReader(StoredProcedureName.sp_SelectMaxID, parms))
                {
                    if (dr.Read())
                    {
                        return dr.GetInt32(0);
                    }
                    else
                        return -1;
                }
            }
        }
}
