using System;
using System.Collections.Generic;
using System.Text;
using Maticsoft.DBUtility;
using System.Data;
using Pbzx.IDAL;
using System.Data.SqlClient;

namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类:PlatformPublic_UserWinning
    /// </summary>
    public partial class PlatformPublic_UserWinning : IPlatformPublic_UserWinning
    {
        public PlatformPublic_UserWinning()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("u_id", "PlatformPublic_UserWinning");
        }
        public bool Exists(string Qnum,string platform)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PlatformPublic_UserWinning");
            strSql.Append(" where u_wItem= @Qnum");
            strSql.Append(" and u_platform=@platform");
            SqlParameter[] parameters = {
					new SqlParameter("@Qnum", SqlDbType.NVarChar,50),
                    new SqlParameter("@platform",SqlDbType.NVarChar,50)
				};
            parameters[0].Value = Qnum;
            parameters[1].Value = platform;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int u_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PlatformPublic_UserWinning");
            strSql.Append(" where u_id=@u_id ");
            SqlParameter[] parameters = {
					new SqlParameter("@u_id", SqlDbType.Int,4)};
            parameters[0].Value = u_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(Pbzx.Model.PlatformPublic_UserWinning model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PlatformPublic_UserWinning(");
            strSql.Append("u_id,u_name,u_issue,u_time,u_lottId,u_wItem,u_wContent,u_Monery,u_coin,u_platform)");
            strSql.Append(" values (");
            strSql.Append("@u_id,@u_name,@u_issue,@u_time,@u_lottId,@u_wItem,@u_wContent,@u_Monery,@u_coin,@u_platform)");
            SqlParameter[] parameters = {
					new SqlParameter("@u_id", SqlDbType.Int,4),
					new SqlParameter("@u_name", SqlDbType.NVarChar,50),
					new SqlParameter("@u_issue", SqlDbType.Int,4),
					new SqlParameter("@u_time", SqlDbType.DateTime),
					new SqlParameter("@u_lottId", SqlDbType.Int,4),
					new SqlParameter("@u_wItem", SqlDbType.NVarChar,50),
					new SqlParameter("@u_wContent", SqlDbType.NVarChar,50),
					new SqlParameter("@u_Monery", SqlDbType.Money,8),
					new SqlParameter("@u_coin", SqlDbType.Int,4),
					new SqlParameter("@u_platform", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.u_id;
            parameters[1].Value = model.u_name;
            parameters[2].Value = model.u_issue;
            parameters[3].Value = model.u_time;
            parameters[4].Value = model.u_lottId;
            parameters[5].Value = model.u_wItem;
            parameters[6].Value = model.u_wContent;
            parameters[7].Value = model.u_Monery;
            parameters[8].Value = model.u_coin;
            parameters[9].Value = model.u_platform;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Pbzx.Model.PlatformPublic_UserWinning model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PlatformPublic_UserWinning set ");
            strSql.Append("u_name=@u_name,");
            strSql.Append("u_issue=@u_issue,");
            strSql.Append("u_time=@u_time,");
            strSql.Append("u_lottId=@u_lottId,");
            strSql.Append("u_wItem=@u_wItem,");
            strSql.Append("u_wContent=@u_wContent,");
            strSql.Append("u_Monery=@u_Monery,");
            strSql.Append("u_coin=@u_coin,");
            strSql.Append("u_platform=@u_platform");
            strSql.Append(" where u_id=@u_id ");
            SqlParameter[] parameters = {
					new SqlParameter("@u_name", SqlDbType.NVarChar,50),
					new SqlParameter("@u_issue", SqlDbType.Int,4),
					new SqlParameter("@u_time", SqlDbType.DateTime),
					new SqlParameter("@u_lottId", SqlDbType.Int,4),
					new SqlParameter("@u_wItem", SqlDbType.NVarChar,50),
					new SqlParameter("@u_wContent", SqlDbType.NVarChar,50),
					new SqlParameter("@u_Monery", SqlDbType.Money,8),
					new SqlParameter("@u_coin", SqlDbType.Int,4),
					new SqlParameter("@u_platform", SqlDbType.NVarChar,50),
					new SqlParameter("@u_id", SqlDbType.Int,4)};
            parameters[0].Value = model.u_name;
            parameters[1].Value = model.u_issue;
            parameters[2].Value = model.u_time;
            parameters[3].Value = model.u_lottId;
            parameters[4].Value = model.u_wItem;
            parameters[5].Value = model.u_wContent;
            parameters[6].Value = model.u_Monery;
            parameters[7].Value = model.u_coin;
            parameters[8].Value = model.u_platform;
            parameters[9].Value = model.u_id;

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
        public bool Delete(int u_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PlatformPublic_UserWinning ");
            strSql.Append(" where u_id=@u_id ");
            SqlParameter[] parameters = {
					new SqlParameter("@u_id", SqlDbType.Int,4)};
            parameters[0].Value = u_id;

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
        public bool DeleteList(string u_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PlatformPublic_UserWinning ");
            strSql.Append(" where u_id in (" + u_idlist + ")  ");
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
        public Pbzx.Model.PlatformPublic_UserWinning GetModel(int u_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 u_id,u_name,u_issue,u_time,u_lottId,u_wItem,u_wContent,u_Monery,u_coin,u_platform from PlatformPublic_UserWinning ");
            strSql.Append(" where u_id=@u_id ");
            SqlParameter[] parameters = {
					new SqlParameter("@u_id", SqlDbType.Int,4)};
            parameters[0].Value = u_id;

            Pbzx.Model.PlatformPublic_UserWinning model = new Pbzx.Model.PlatformPublic_UserWinning();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["u_id"].ToString() != "")
                {
                    model.u_id = int.Parse(ds.Tables[0].Rows[0]["u_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["u_name"] != null)
                {
                    model.u_name = ds.Tables[0].Rows[0]["u_name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["u_issue"].ToString() != "")
                {
                    model.u_issue = int.Parse(ds.Tables[0].Rows[0]["u_issue"].ToString());
                }
                if (ds.Tables[0].Rows[0]["u_time"].ToString() != "")
                {
                    model.u_time = DateTime.Parse(ds.Tables[0].Rows[0]["u_time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["u_lottId"].ToString() != "")
                {
                    model.u_lottId = int.Parse(ds.Tables[0].Rows[0]["u_lottId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["u_wItem"] != null)
                {
                    model.u_wItem = ds.Tables[0].Rows[0]["u_wItem"].ToString();
                }
                if (ds.Tables[0].Rows[0]["u_wContent"] != null)
                {
                    model.u_wContent = ds.Tables[0].Rows[0]["u_wContent"].ToString();
                }
                if (ds.Tables[0].Rows[0]["u_Monery"].ToString() != "")
                {
                    model.u_Monery = decimal.Parse(ds.Tables[0].Rows[0]["u_Monery"].ToString());
                }
                if (ds.Tables[0].Rows[0]["u_coin"].ToString() != "")
                {
                    model.u_coin = int.Parse(ds.Tables[0].Rows[0]["u_coin"].ToString());
                }
                if (ds.Tables[0].Rows[0]["u_platform"] != null)
                {
                    model.u_platform = ds.Tables[0].Rows[0]["u_platform"].ToString();
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
            strSql.Append("select u_id,u_name,u_issue,u_time,u_lottId,u_wItem,u_wContent,u_Monery,u_coin,u_platform ");
            strSql.Append(" FROM PlatformPublic_UserWinning ");
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
            strSql.Append(" u_id,u_name,u_issue,u_time,u_lottId,u_wItem,u_wContent,u_Monery,u_coin,u_platform ");
            strSql.Append(" FROM PlatformPublic_UserWinning ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(string columnName, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(" sum( " + columnName+") ");

            strSql.Append(" FROM PlatformPublic_UserWinning ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" group by "+columnName);
            strSql.Append(" order by " + columnName);
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
            parameters[0].Value = "PlatformPublic_UserWinning";
            parameters[1].Value = "u_id";
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
