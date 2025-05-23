using System;
using System.Collections.Generic;
using System.Text;
using Maticsoft.DBUtility;
using System.Data.SqlClient;
using System.Data;
using Pbzx.IDAL;

namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类:Challenge_type
    /// </summary>
    public partial class Challenge_type : IChallenge_type
    {
        public Challenge_type()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int T_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Challenge_type");
            strSql.Append(" where T_id=@T_id");
            SqlParameter[] parameters = {
					new SqlParameter("@T_id", SqlDbType.Int,4)
};
            parameters[0].Value = T_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.Challenge_type model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Challenge_type(");
            strSql.Append("T_cond,T_state,T_lottID)");
            strSql.Append(" values (");
            strSql.Append("@T_cond,@T_state,@T_lottID)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@T_cond", SqlDbType.NVarChar,20),
					new SqlParameter("@T_state", SqlDbType.NVarChar,10),
					new SqlParameter("@T_lottID", SqlDbType.Int,4)};
            parameters[0].Value = model.T_cond;
            parameters[1].Value = model.T_state;
            parameters[2].Value = model.T_lottID;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Pbzx.Model.Challenge_type model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Challenge_type set ");
            strSql.Append("T_cond=@T_cond,");
            strSql.Append("T_state=@T_state,");
            strSql.Append("T_lottID=@T_lottID");
            strSql.Append(" where T_id=@T_id");
            SqlParameter[] parameters = {
					new SqlParameter("@T_cond", SqlDbType.NVarChar,20),
					new SqlParameter("@T_state", SqlDbType.NVarChar,10),
					new SqlParameter("@T_lottID", SqlDbType.Int,4),
					new SqlParameter("@T_id", SqlDbType.Int,4)};
            parameters[0].Value = model.T_cond;
            parameters[1].Value = model.T_state;
            parameters[2].Value = model.T_lottID;
            parameters[3].Value = model.T_id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int T_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Challenge_type ");
            strSql.Append(" where T_id=@T_id");
            SqlParameter[] parameters = {
					new SqlParameter("@T_id", SqlDbType.Int,4)
};
            parameters[0].Value = T_id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string T_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Challenge_type ");
            strSql.Append(" where T_id in (" + T_idlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.Challenge_type GetModel(int T_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 T_id,T_cond,T_state,T_lottID from Challenge_type ");
            strSql.Append(" where T_id=@T_id");
            SqlParameter[] parameters = {
					new SqlParameter("@T_id", SqlDbType.Int,4)
};
            parameters[0].Value = T_id;

            Pbzx.Model.Challenge_type model = new Pbzx.Model.Challenge_type();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["T_id"].ToString() != "")
                {
                    model.T_id = int.Parse(ds.Tables[0].Rows[0]["T_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["T_cond"] != null)
                {
                    model.T_cond = ds.Tables[0].Rows[0]["T_cond"].ToString();
                }
                if (ds.Tables[0].Rows[0]["T_state"] != null)
                {
                    model.T_state = ds.Tables[0].Rows[0]["T_state"].ToString();
                }
                if (ds.Tables[0].Rows[0]["T_lottID"].ToString() != "")
                {
                    model.T_lottID = int.Parse(ds.Tables[0].Rows[0]["T_lottID"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select T_id,T_cond,T_state,T_lottID ");
            strSql.Append(" FROM Challenge_type ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" T_id,T_cond,T_state,T_lottID ");
            strSql.Append(" FROM Challenge_type ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "Challenge_type";
            parameters[1].Value = "T_id";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  Method
    }
}
