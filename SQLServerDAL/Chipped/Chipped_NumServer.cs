using System;
using System.Collections.Generic;
using System.Text;
using Pbzx.IDAL;
using System.Data;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using Pbzx.Model;
namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类:Chipped_Num
    /// </summary>
    public partial class Chipped_Num : IChipped_Num
    {
        public Chipped_Num()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int N_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Chipped_Num");
            strSql.Append(" where N_id=@N_id");
            SqlParameter[] parameters = {
					new SqlParameter("@N_id", SqlDbType.Int,4)
};
            parameters[0].Value = N_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.Chipped_Num model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Chipped_Num(");
            strSql.Append("N_InId,N_RnId,N_num)");
            strSql.Append(" values (");
            strSql.Append("@N_InId,@N_RnId,@N_num)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@N_InId", SqlDbType.Int,4),
					new SqlParameter("@N_RnId", SqlDbType.Int,4),
					new SqlParameter("@N_num", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.N_InId;
            parameters[1].Value = model.N_RnId;
            parameters[2].Value = model.N_num;

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
        public bool Update(Pbzx.Model.Chipped_Num model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Chipped_Num set ");
            strSql.Append("N_InId=@N_InId,");
            strSql.Append("N_RnId=@N_RnId,");
            strSql.Append("N_num=@N_num");
            strSql.Append(" where N_id=@N_id");
            SqlParameter[] parameters = {
					new SqlParameter("@N_InId", SqlDbType.Int,4),
					new SqlParameter("@N_RnId", SqlDbType.Int,4),
					new SqlParameter("@N_num", SqlDbType.NVarChar,50),
					new SqlParameter("@N_id", SqlDbType.Int,4)};
            parameters[0].Value = model.N_InId;
            parameters[1].Value = model.N_RnId;
            parameters[2].Value = model.N_num;
            parameters[3].Value = model.N_id;

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
        public bool Delete(int N_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Chipped_Num ");
            strSql.Append(" where N_id=@N_id");
            SqlParameter[] parameters = {
					new SqlParameter("@N_id", SqlDbType.Int,4)
};
            parameters[0].Value = N_id;

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
        public bool DeleteRn(int N_RnId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Chipped_Num ");
            strSql.Append(" where N_RnId=@N_RnId");
            SqlParameter[] parameters = {
					new SqlParameter("@N_RnId", SqlDbType.Int,4)
};
            parameters[0].Value = N_RnId;

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
        public bool DeleteList(string N_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Chipped_Num ");
            strSql.Append(" where N_id in (" + N_idlist + ")  ");
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
        public Pbzx.Model.Chipped_Num GetModel(int N_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 N_id,N_InId,N_RnId,N_num from Chipped_Num ");
            strSql.Append(" where N_id=@N_id");
            SqlParameter[] parameters = {
					new SqlParameter("@N_id", SqlDbType.Int,4)
};
            parameters[0].Value = N_id;

            Pbzx.Model.Chipped_Num model = new Pbzx.Model.Chipped_Num();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["N_id"].ToString() != "")
                {
                    model.N_id = int.Parse(ds.Tables[0].Rows[0]["N_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_InId"].ToString() != "")
                {
                    model.N_InId = int.Parse(ds.Tables[0].Rows[0]["N_InId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_RnId"].ToString() != "")
                {
                    model.N_RnId = int.Parse(ds.Tables[0].Rows[0]["N_RnId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["N_num"] != null)
                {
                    model.N_num = ds.Tables[0].Rows[0]["N_num"].ToString();
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
            strSql.Append("select N_id,N_InId,N_RnId,N_num ");
            strSql.Append(" FROM Chipped_Num ");
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
            strSql.Append(" N_id,N_InId,N_RnId,N_num ");
            strSql.Append(" FROM Chipped_Num ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  Method
    }
}

