using System;
using System.Collections.Generic;
using System.Text;
using Pbzx.IDAL;
using Pbzx.Model;
using System.Data;
using Maticsoft.DBUtility;
using System.Data.SqlClient;

namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类Market_CancelIndent。
    /// </summary>
    public class Market_CancelIndentServer: IMarket_CancelIndent
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int CancelID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Market_CancelIndent");
            strSql.Append(" where CancelID=@CancelID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CancelID", SqlDbType.Int,4)};
            parameters[0].Value = CancelID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <param name="name">会员名</param>
        /// <param name="Item">项目ID</param>
        /// <returns></returns>
        public bool Exists(string name, int Item)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Market_CancelIndent");
            strSql.Append(" where CancelName=@name and CancelItem=@Item ");
            SqlParameter[] parameters = {
                    new SqlParameter("@name",SqlDbType.NVarChar,50),
					new SqlParameter("@Item", SqlDbType.Int,4)};
            parameters[0].Value = name;
            parameters[1].Value = Item;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.Market_CancelIndent model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Market_CancelIndent(");
            strSql.Append("CancelIndent,CTime,CApprove,CancelName,CancelItem,CancelSake,Other,approveTime)");
            strSql.Append(" values (");
            strSql.Append("@CancelIndent,@CTime,@CApprove,@CancelName,@CancelItem,@CancelSake,@Other,@approveTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@CancelIndent", SqlDbType.Int,4),
					new SqlParameter("@CTime", SqlDbType.DateTime),
					new SqlParameter("@CApprove", SqlDbType.Int,4),
					new SqlParameter("@CancelName", SqlDbType.NVarChar,50),
					new SqlParameter("@CancelItem", SqlDbType.Int,4),
					new SqlParameter("@CancelSake", SqlDbType.NVarChar,100),
					new SqlParameter("@Other", SqlDbType.NVarChar,150),
					new SqlParameter("@approveTime", SqlDbType.DateTime)};
            parameters[0].Value = model.CancelIndent;
            parameters[1].Value = model.CTime;
            parameters[2].Value = model.CApprove;
            parameters[3].Value = model.CancelName;
            parameters[4].Value = model.CancelItem;
            parameters[5].Value = model.CancelSake;
            parameters[6].Value = model.Other;
            parameters[7].Value = model.approveTime;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Pbzx.Model.Market_CancelIndent model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Market_CancelIndent set ");
            strSql.Append("CancelIndent=@CancelIndent,");
            strSql.Append("CTime=@CTime,");
            strSql.Append("CApprove=@CApprove,");
            strSql.Append("CancelName=@CancelName,");
            strSql.Append("CancelItem=@CancelItem,");
            strSql.Append("CancelSake=@CancelSake,");
            strSql.Append("Other=@Other,");
            strSql.Append("approveTime=@approveTime");
            strSql.Append(" where CancelID=@CancelID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CancelID", SqlDbType.Int,4),
					new SqlParameter("@CancelIndent", SqlDbType.Int,4),
					new SqlParameter("@CTime", SqlDbType.DateTime),
					new SqlParameter("@CApprove", SqlDbType.Int,4),
					new SqlParameter("@CancelName", SqlDbType.NVarChar,50),
					new SqlParameter("@CancelItem", SqlDbType.Int,4),
					new SqlParameter("@CancelSake", SqlDbType.NVarChar,100),
					new SqlParameter("@Other", SqlDbType.NVarChar,150),
					new SqlParameter("@approveTime", SqlDbType.DateTime)};
            parameters[0].Value = model.CancelID;
            parameters[1].Value = model.CancelIndent;
            parameters[2].Value = model.CTime;
            parameters[3].Value = model.CApprove;
            parameters[4].Value = model.CancelName;
            parameters[5].Value = model.CancelItem;
            parameters[6].Value = model.CancelSake;
            parameters[7].Value = model.Other;
            parameters[8].Value = model.approveTime;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int CancelID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Market_CancelIndent ");
            strSql.Append(" where CancelID=@CancelID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CancelID", SqlDbType.Int,4)};
            parameters[0].Value = CancelID;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.Market_CancelIndent GetModel(int CancelID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 CancelID,CancelIndent,CTime,CApprove,CancelName,CancelItem,CancelSake,Other,approveTime from Market_CancelIndent ");
            strSql.Append(" where CancelID=@CancelID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CancelID", SqlDbType.Int,4)};
            parameters[0].Value = CancelID;

            Pbzx.Model.Market_CancelIndent model = new Pbzx.Model.Market_CancelIndent();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["CancelID"].ToString() != "")
                {
                    model.CancelID = int.Parse(ds.Tables[0].Rows[0]["CancelID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CancelIndent"].ToString() != "")
                {
                    model.CancelIndent = int.Parse(ds.Tables[0].Rows[0]["CancelIndent"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CTime"].ToString() != "")
                {
                    model.CTime = DateTime.Parse(ds.Tables[0].Rows[0]["CTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CApprove"].ToString() != "")
                {
                    model.CApprove = int.Parse(ds.Tables[0].Rows[0]["CApprove"].ToString());
                }
                model.CancelName = ds.Tables[0].Rows[0]["CancelName"].ToString();
                if (ds.Tables[0].Rows[0]["CancelItem"].ToString() != "")
                {
                    model.CancelItem = int.Parse(ds.Tables[0].Rows[0]["CancelItem"].ToString());
                }
                model.CancelSake = ds.Tables[0].Rows[0]["CancelSake"].ToString();
                model.Other = ds.Tables[0].Rows[0]["Other"].ToString();
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
            strSql.Append("select CancelID,CancelIndent,CTime,CApprove,CancelName,CancelItem,CancelSake,Other,approveTime ");
            strSql.Append(" FROM Market_CancelIndent ");
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
            strSql.Append(" CancelID,CancelIndent,CTime,CApprove,CancelName,CancelItem,CancelSake,Other,approveTime ");
            strSql.Append(" FROM Market_CancelIndent ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  成员方法
    }
}
