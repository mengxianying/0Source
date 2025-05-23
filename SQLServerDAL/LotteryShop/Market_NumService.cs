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
    /// 数据访问类Market_Num。
    /// </summary>
    public class Market_NumService : IMarket_Num
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Market_Num");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 重载方法
        /// 创建人: zhouwei
        /// 创建时间: 2010-11-25
        /// </summary>
        /// <param name="id">项目ID</param>
        /// <param name="expctNum">期号</param>
        /// <returns></returns>
        public bool Exists(int id,string expctNum,string radio)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Market_Num");
            strSql.Append(" where ItemID=@id ");
            strSql.Append(" and ExpectNum=@expctNum and itemradio=@radio");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
                    new SqlParameter("@expctNum", SqlDbType.NVarChar,20),
                    new SqlParameter("@radio",SqlDbType.NVarChar,50)};
            parameters[0].Value = id;
            parameters[1].Value = expctNum;
            parameters[2].Value = radio;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.Market_Num model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Market_Num(");
            strSql.Append("ItemID,ExpectNum,appendName,IssueTime,Commend,Content,itemidentity,itemradio,itemcheck,itemnumber)");
            strSql.Append(" values (");
            strSql.Append("@ItemID,@ExpectNum,@appendName,@IssueTime,@Commend,@Content,@itemidentity,@itemradio,@itemcheck,@itemnumber)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@ItemID", SqlDbType.Int,4),
					new SqlParameter("@ExpectNum", SqlDbType.NVarChar,20),
					new SqlParameter("@appendName", SqlDbType.NVarChar,20),
					new SqlParameter("@IssueTime", SqlDbType.NVarChar,50),
					new SqlParameter("@Commend", SqlDbType.Int,4),
					new SqlParameter("@Content", SqlDbType.NVarChar,100),
					new SqlParameter("@itemidentity", SqlDbType.Int,4),
					new SqlParameter("@itemradio", SqlDbType.NVarChar,50),
					new SqlParameter("@itemcheck", SqlDbType.NVarChar,50),
					new SqlParameter("@itemnumber", SqlDbType.NVarChar,10)};
            parameters[0].Value = model.ItemID;
            parameters[1].Value = model.ExpectNum;
            parameters[2].Value = model.appendName;
            parameters[3].Value = model.IssueTime;
            parameters[4].Value = model.Commend;
            parameters[5].Value = model.Content;
            parameters[6].Value = model.itemidentity;
            parameters[7].Value = model.itemradio;
            parameters[8].Value = model.itemcheck;
            parameters[9].Value = model.itemnumber;
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
        public int Update(Pbzx.Model.Market_Num model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Market_Num set ");
            strSql.Append("ItemID=@ItemID,");
            strSql.Append("ExpectNum=@ExpectNum,");
            strSql.Append("appendName=@appendName,");
            strSql.Append("IssueTime=@IssueTime,");
            strSql.Append("Commend=@Commend,");
            strSql.Append("Content=@Content,");
            strSql.Append("itemidentity=@itemidentity,");
            strSql.Append("itemradio=@itemradio,");
            strSql.Append("itemcheck=@itemcheck,");
            strSql.Append("itemnumber=@itemnumber");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@ItemID", SqlDbType.Int,4),
					new SqlParameter("@ExpectNum", SqlDbType.NVarChar,20),
					new SqlParameter("@appendName", SqlDbType.NVarChar,20),
					new SqlParameter("@IssueTime", SqlDbType.NVarChar,50),
					new SqlParameter("@Commend", SqlDbType.Int,4),
					new SqlParameter("@Content", SqlDbType.NVarChar,100),
					new SqlParameter("@itemidentity", SqlDbType.Int,4),
					new SqlParameter("@itemradio", SqlDbType.NVarChar,50),
					new SqlParameter("@itemcheck", SqlDbType.NVarChar,50),
					new SqlParameter("@itemnumber", SqlDbType.NVarChar,10)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.ItemID;
            parameters[2].Value = model.ExpectNum;
            parameters[3].Value = model.appendName;
            parameters[4].Value = model.IssueTime;
            parameters[5].Value = model.Commend;
            parameters[6].Value = model.Content;
            parameters[7].Value = model.itemidentity;
            parameters[8].Value = model.itemradio;
            parameters[9].Value = model.itemcheck;
            parameters[10].Value = model.itemnumber;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Market_Num ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.Market_Num GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,ItemID,ExpectNum,appendName,IssueTime,Commend,Content,itemidentity,itemradio,itemcheck,itemnumber from Market_Num ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            Pbzx.Model.Market_Num model = new Pbzx.Model.Market_Num();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ItemID"].ToString() != "")
                {
                    model.ItemID = int.Parse(ds.Tables[0].Rows[0]["ItemID"].ToString());
                }
                model.ExpectNum = ds.Tables[0].Rows[0]["ExpectNum"].ToString();
                model.IssueTime = ds.Tables[0].Rows[0]["IssueTime"].ToString();
                if (ds.Tables[0].Rows[0]["Commend"].ToString() != "")
                {
                    model.Commend = int.Parse(ds.Tables[0].Rows[0]["Commend"].ToString());
                }
                model.Content = ds.Tables[0].Rows[0]["Content"].ToString();
                if (ds.Tables[0].Rows[0]["itemidentity"].ToString() != "")
                {
                    model.itemidentity = int.Parse(ds.Tables[0].Rows[0]["itemidentity"].ToString());
                }
                model.itemradio = ds.Tables[0].Rows[0]["itemradio"].ToString();
                model.itemcheck = ds.Tables[0].Rows[0]["itemcheck"].ToString();
                model.itemnumber = ds.Tables[0].Rows[0]["itemnumber"].ToString();
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
            strSql.Append("select * FROM Market_Num");
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
            strSql.Append(" * FROM Market_Num ");
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