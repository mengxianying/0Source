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
    /// 数据访问类Chipped_AcctPayCharge。
    /// </summary>
    public class Chipped_AcctPayCharge : IChipped_AcctPayCharge
    {
        public Chipped_AcctPayCharge()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("apcID", "Chipped_AcctPayCharge");
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int apcID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Chipped_AcctPayCharge");
            strSql.Append(" where apcID= @apcID");
            SqlParameter[] parameters = {
					new SqlParameter("@apcID", SqlDbType.Int,4)
				};
            parameters[0].Value = apcID;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.Chipped_AcctPayCharge model)
        {
            model.apcID = GetMaxId();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Chipped_AcctPayCharge(");
            strSql.Append("apcID,apcName,acctType,Payltem,specificItem,apcTime)");
            strSql.Append(" values (");
            strSql.Append("@apcID,@apcName,@acctType,@Payltem,@specificItem,@apcTime)");
            SqlParameter[] parameters = {
					new SqlParameter("@apcID", SqlDbType.Int,4),
					new SqlParameter("@apcName", SqlDbType.NVarChar),
					new SqlParameter("@acctType", SqlDbType.Int,4),
					new SqlParameter("@Payltem", SqlDbType.NVarChar),
					new SqlParameter("@specificItem", SqlDbType.NVarChar),
					new SqlParameter("@apcTime", SqlDbType.DateTime)};
            parameters[0].Value = model.apcID;
            parameters[1].Value = model.apcName;
            parameters[2].Value = model.acctType;
            parameters[3].Value = model.Payltem;
            parameters[4].Value = model.specificItem;
            parameters[5].Value = model.apcTime;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            return model.apcID;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(Pbzx.Model.Chipped_AcctPayCharge model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Chipped_AcctPayCharge set ");
            strSql.Append("apcName=@apcName,");
            strSql.Append("acctType=@acctType,");
            strSql.Append("Payltem=@Payltem,");
            strSql.Append("specificItem=@specificItem,");
            strSql.Append("apcTime=@apcTime");
            strSql.Append(" where apcID=@apcID");
            SqlParameter[] parameters = {
					new SqlParameter("@apcID", SqlDbType.Int,4),
					new SqlParameter("@apcName", SqlDbType.NVarChar),
					new SqlParameter("@acctType", SqlDbType.Int,4),
					new SqlParameter("@Payltem", SqlDbType.NVarChar),
					new SqlParameter("@specificItem", SqlDbType.NVarChar),
					new SqlParameter("@apcTime", SqlDbType.DateTime)};
            parameters[0].Value = model.apcID;
            parameters[1].Value = model.apcName;
            parameters[2].Value = model.acctType;
            parameters[3].Value = model.Payltem;
            parameters[4].Value = model.specificItem;
            parameters[5].Value = model.apcTime;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int apcID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete Chipped_AcctPayCharge ");
            strSql.Append(" where apcID=@apcID");
            SqlParameter[] parameters = {
					new SqlParameter("@apcID", SqlDbType.Int,4)
				};
            parameters[0].Value = apcID;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.Chipped_AcctPayCharge GetModel(int apcID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Chipped_AcctPayCharge ");
            strSql.Append(" where apcID=@apcID");
            SqlParameter[] parameters = {
					new SqlParameter("@apcID", SqlDbType.Int,4)};
            parameters[0].Value = apcID;
            Pbzx.Model.Chipped_AcctPayCharge model = new Pbzx.Model.Chipped_AcctPayCharge();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            model.apcID = apcID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.apcName = ds.Tables[0].Rows[0]["apcName"].ToString();
                if (ds.Tables[0].Rows[0]["acctType"].ToString() != "")
                {
                    model.acctType = int.Parse(ds.Tables[0].Rows[0]["acctType"].ToString());
                }
                model.Payltem = ds.Tables[0].Rows[0]["Payltem"].ToString();
                model.specificItem = ds.Tables[0].Rows[0]["specificItem"].ToString();
                if (ds.Tables[0].Rows[0]["apcTime"].ToString() != "")
                {
                    model.apcTime = DateTime.Parse(ds.Tables[0].Rows[0]["apcTime"].ToString());
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
            strSql.Append("select * from Chipped_AcctPayCharge ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by apcID ");
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion  成员方法
    }
}
