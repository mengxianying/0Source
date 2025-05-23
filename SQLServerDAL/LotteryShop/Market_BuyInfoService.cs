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
    public class Market_BuyInfoService : IMarket_BuyInfo
    {
        /// <summary>
        /// 数据访问类Market_Num。
        /// </summary>
        //public Market_BuyInfo()
        //{}
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string buyuserid, int issueInfoId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Market_BuyInfo");
            strSql.Append(" where buyuserid=@buyuserid and issueInfoId=@issueInfoId ");
            SqlParameter[] parameters = {
					new SqlParameter("@buyuserid", SqlDbType.NVarChar,50),
					new SqlParameter("@issueInfoId", SqlDbType.Int,4)};
            parameters[0].Value = buyuserid;
            parameters[1].Value = issueInfoId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.Market_BuyInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Market_BuyInfo(");
            strSql.Append("buyuserid,issueInfoId,LotteryType,ShopUserID,Price,Term,BeginTime,EndTime,buyContinue,market)");
            strSql.Append(" values (");
            strSql.Append("@buyuserid,@issueInfoId,@LotteryType,@ShopUserID,@Price,@Term,@BeginTime,@EndTime,@buyContinue,@market)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@buyuserid", SqlDbType.NVarChar,50),
					new SqlParameter("@issueInfoId", SqlDbType.Int,4),
					new SqlParameter("@LotteryType", SqlDbType.NVarChar,10),
					new SqlParameter("@ShopUserID", SqlDbType.NVarChar,50),
					new SqlParameter("@Price", SqlDbType.Decimal,9),
					new SqlParameter("@Term", SqlDbType.Int,4),
					new SqlParameter("@BeginTime", SqlDbType.DateTime),
					new SqlParameter("@EndTime", SqlDbType.DateTime),
					new SqlParameter("@buyContinue", SqlDbType.Int,4),
					new SqlParameter("@market", SqlDbType.Int,4)};
            parameters[0].Value = model.buyuserid;
            parameters[1].Value = model.issueInfoId;
            parameters[2].Value = model.LotteryType;
            parameters[3].Value = model.ShopUserID;
            parameters[4].Value = model.Price;
            parameters[5].Value = model.Term;
            parameters[6].Value = model.BeginTime;
            parameters[7].Value = model.EndTime;
            parameters[8].Value = model.buyContinue;
            parameters[9].Value = model.market;

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
        public int Update(Pbzx.Model.Market_BuyInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Market_BuyInfo set ");
            strSql.Append("buyuserid=@buyuserid,");
            strSql.Append("LotteryType=@LotteryType,");
            strSql.Append("Price=@Price,");
            strSql.Append("Term=@Term,");
            strSql.Append("BeginTime=@BeginTime,");
            strSql.Append("EndTime=@EndTime,");
            strSql.Append("buyContinue=@buyContinue,");
            strSql.Append("market=@market");
            strSql.Append(" where buyid=@buyid and issueInfoId=@issueInfoId ");
            SqlParameter[] parameters = {
					new SqlParameter("@buyid", SqlDbType.Int,4),
					new SqlParameter("@buyuserid", SqlDbType.NVarChar,50),
					new SqlParameter("@issueInfoId", SqlDbType.Int,4),
					new SqlParameter("@LotteryType", SqlDbType.NVarChar,10),
					new SqlParameter("@ShopUserID", SqlDbType.NVarChar,50),
					new SqlParameter("@Price", SqlDbType.Decimal,9),
					new SqlParameter("@Term", SqlDbType.Int,4),
					new SqlParameter("@BeginTime", SqlDbType.DateTime),
					new SqlParameter("@EndTime", SqlDbType.DateTime),
					new SqlParameter("@buyContinue", SqlDbType.Int,4),
					new SqlParameter("@market", SqlDbType.Int,4)};
            parameters[0].Value = model.buyid;
            parameters[1].Value = model.buyuserid;
            parameters[2].Value = model.issueInfoId;
            parameters[3].Value = model.LotteryType;
            parameters[4].Value = model.ShopUserID;
            parameters[5].Value = model.Price;
            parameters[6].Value = model.Term;
            parameters[7].Value = model.BeginTime;
            parameters[8].Value = model.EndTime;
            parameters[9].Value = model.buyContinue;
            parameters[10].Value = model.market;

           return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);

        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int buyid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Market_BuyInfo ");
            strSql.Append(" where buyid=@buyid ");
            SqlParameter[] parameters = {
					new SqlParameter("@buyid", SqlDbType.Int,4)};
            parameters[0].Value = buyid;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.Market_BuyInfo GetModel(int issueInfoId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 buyid,buyuserid,issueInfoId,LotteryType,ShopUserID,Price,Term,BeginTime,EndTime,buyContinue,market from Market_BuyInfo ");
            strSql.Append(" where issueInfoId=@issueInfoId");
            SqlParameter[] parameters = {
					new SqlParameter("@issueInfoId", SqlDbType.Int,4)};
            parameters[0].Value = issueInfoId;

            Pbzx.Model.Market_BuyInfo model = new Pbzx.Model.Market_BuyInfo();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["buyid"].ToString() != "")
                {
                    model.buyid = int.Parse(ds.Tables[0].Rows[0]["buyid"].ToString());
                }
                model.buyuserid = ds.Tables[0].Rows[0]["buyuserid"].ToString();
                if (ds.Tables[0].Rows[0]["issueInfoId"].ToString() != "")
                {
                    model.issueInfoId = int.Parse(ds.Tables[0].Rows[0]["issueInfoId"].ToString());
                }
                model.LotteryType = ds.Tables[0].Rows[0]["LotteryType"].ToString();
                model.ShopUserID = ds.Tables[0].Rows[0]["ShopUserID"].ToString();
                if (ds.Tables[0].Rows[0]["Price"].ToString() != "")
                {
                    model.Price = decimal.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Term"].ToString() != "")
                {
                    model.Term = int.Parse(ds.Tables[0].Rows[0]["Term"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BeginTime"].ToString() != "")
                {
                    model.BeginTime = DateTime.Parse(ds.Tables[0].Rows[0]["BeginTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["EndTime"].ToString() != "")
                {
                    model.EndTime = DateTime.Parse(ds.Tables[0].Rows[0]["EndTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["buyContinue"].ToString() != "")
                {
                    model.buyContinue = int.Parse(ds.Tables[0].Rows[0]["buyContinue"].ToString());
                }
                if (ds.Tables[0].Rows[0]["market"].ToString() != "")
                {
                    model.market = int.Parse(ds.Tables[0].Rows[0]["market"].ToString());
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
            strSql.Append("select buyid,buyuserid,issueInfoId,LotteryType,ShopUserID,Price,Term,BeginTime,EndTime,buyContinue,market ");
            strSql.Append(" FROM Market_BuyInfo ");
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
            strSql.Append(" buyid,buyuserid,issueInfoId,LotteryType,ShopUserID,Price,Term,BeginTime,EndTime,buyContinue,market ");
            strSql.Append(" FROM Market_BuyInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }


        /// <summary>
        /// 返回DataTable类型
        /// 创建人: zhouwei
        /// 创建时间: 2010-10-27
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable Query(string sql)
        {
            DataSet ds = DbHelperSQL.Query(sql);
            if (ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 返回DataTable类型
        /// 创建人: zhouwei
        /// 创建时间: 2010-10-27 
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataSet QuerySet(string sql)
        {
            DataSet ds = DbHelperSQL.Query(sql);
            if (ds.Tables.Count > 0)
            {
                return ds;
            }
            else
            {
                return null;
            }
        }

        #endregion  成员方法

    }
}
