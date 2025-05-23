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
    /// 添加项目信息数据访问类
    /// 创建人： 杨良伟
    /// 2010-10-20
    /// </summary>
    public class Market_appendItemService : IMarket_appendItem
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Market_appendItem");
            strSql.Append(" where appendID=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.Market_appendItem model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Market_appendItem(");
            strSql.Append("TypeID,UserId,Charge,On_off,Say,Time,Agio,Price,IssueTime,Commend,State,Confine)");
            strSql.Append(" values (");
            strSql.Append("@TypeID,@UserId,@Charge,@On_off,@Say,@Time,@Agio,@Price,@IssueTime,@Commend,@State,@Confine)");
            SqlParameter[] parameters = {
					new SqlParameter("@TypeID", SqlDbType.Int,4),
					new SqlParameter("@UserId", SqlDbType.NVarChar,50),
					new SqlParameter("@Charge", SqlDbType.Int,4),
					new SqlParameter("@On_off", SqlDbType.Int,4),
					new SqlParameter("@Say", SqlDbType.NVarChar),
					new SqlParameter("@Time", SqlDbType.DateTime),
					new SqlParameter("@Agio", SqlDbType.Decimal,9),
					new SqlParameter("@Price", SqlDbType.Decimal,9),
					new SqlParameter("@IssueTime", SqlDbType.NVarChar),
					new SqlParameter("@Commend", SqlDbType.Int,4),
					new SqlParameter("@State", SqlDbType.Int,4),
					new SqlParameter("@Confine", SqlDbType.Int,4)};
            parameters[0].Value = model.TypeID;
            parameters[1].Value = model.UserId;
            parameters[2].Value = model.Charge;
            parameters[3].Value = model.On_off;
            parameters[4].Value = model.Say;
            parameters[5].Value = model.Time;
            parameters[6].Value = model.Agio;
            parameters[7].Value = model.Price;
            parameters[8].Value = model.IssueTime;
            parameters[9].Value = model.Commend;
            parameters[10].Value = model.State;
            parameters[11].Value = model.Confine;

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
        public int Update(Pbzx.Model.Market_appendItem model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Market_appendItem set ");
            strSql.Append("TypeID=@TypeID,");
            strSql.Append("UserId=@UserId,");
            strSql.Append("Charge=@Charge,");
            strSql.Append("On_off=@On_off,");
            strSql.Append("Say=@Say,");
            strSql.Append("Time=@Time,");
            strSql.Append("Agio=@Agio,");
            strSql.Append("Price=@Price,");
            strSql.Append("IssueTime=@IssueTime,");
            strSql.Append("Commend=@Commend,");
            strSql.Append("State=@State,");
            strSql.Append("Confine=@Confine");
            strSql.Append(" where appendID=@appendID");
            SqlParameter[] parameters = {
					new SqlParameter("@appendID", SqlDbType.Int,4),
					new SqlParameter("@TypeID", SqlDbType.Int,4),
					new SqlParameter("@UserId", SqlDbType.NVarChar,50),
					new SqlParameter("@Charge", SqlDbType.Int,4),
					new SqlParameter("@On_off", SqlDbType.Int,4),
					new SqlParameter("@Say", SqlDbType.NVarChar),
					new SqlParameter("@Time", SqlDbType.DateTime),
					new SqlParameter("@Agio", SqlDbType.Decimal,9),
					new SqlParameter("@Price", SqlDbType.Decimal,9),
					new SqlParameter("@IssueTime", SqlDbType.NVarChar),
					new SqlParameter("@Commend", SqlDbType.Int,4),
					new SqlParameter("@State", SqlDbType.Int,4),
					new SqlParameter("@Confine", SqlDbType.Int,4)};
            parameters[0].Value = model.appendID;
            parameters[1].Value = model.TypeID;
            parameters[2].Value = model.UserId;
            parameters[3].Value = model.Charge;
            parameters[4].Value = model.On_off;
            parameters[5].Value = model.Say;
            parameters[6].Value = model.Time;
            parameters[7].Value = model.Agio;
            parameters[8].Value = model.Price;
            parameters[9].Value = model.IssueTime;
            parameters[10].Value = model.Commend;
            parameters[11].Value = model.State;
            parameters[12].Value = model.Confine;


            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Market_appendItem ");
            strSql.Append(" where appendID=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;
           return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.Market_appendItem GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 appendID,TypeID,UserId,Charge,On_off,Say,Time,Agio,Price,IssueTime,Commend,State,Confine from Market_appendItem ");
            strSql.Append(" where appendID=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;


            Pbzx.Model.Market_appendItem model = new Pbzx.Model.Market_appendItem();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["appendID"].ToString() != "")
                {
                    model.appendID = int.Parse(ds.Tables[0].Rows[0]["appendID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TypeID"].ToString() != "")
                {
                    model.TypeID = int.Parse(ds.Tables[0].Rows[0]["TypeID"].ToString());
                }
                model.UserId = ds.Tables[0].Rows[0]["UserId"].ToString();
                if (ds.Tables[0].Rows[0]["Charge"].ToString() != "")
                {
                    model.Charge = int.Parse(ds.Tables[0].Rows[0]["Charge"].ToString());
                }
                if (ds.Tables[0].Rows[0]["On_off"].ToString() != "")
                {
                    model.On_off = int.Parse(ds.Tables[0].Rows[0]["On_off"].ToString());
                }
                model.Say = ds.Tables[0].Rows[0]["Say"].ToString();
                if (ds.Tables[0].Rows[0]["Time"].ToString() != "")
                {
                    model.Time = DateTime.Parse(ds.Tables[0].Rows[0]["Time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Agio"].ToString() != "")
                {
                    model.Agio = decimal.Parse(ds.Tables[0].Rows[0]["Agio"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Price"].ToString() != "")
                {
                    model.Price = decimal.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
                }
                model.IssueTime = ds.Tables[0].Rows[0]["IssueTime"].ToString();
                if (ds.Tables[0].Rows[0]["Commend"].ToString() != "")
                {
                    model.Commend = int.Parse(ds.Tables[0].Rows[0]["Commend"].ToString());
                }
                if (ds.Tables[0].Rows[0]["State"].ToString() != "")
                {
                    model.State = int.Parse(ds.Tables[0].Rows[0]["State"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Confine"].ToString() != "")
                {
                    model.Confine = int.Parse(ds.Tables[0].Rows[0]["Confine"].ToString());
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
            strSql.Append("select * FROM Market_appendItem");
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
            strSql.Append(" * FROM Market_appendItem ");
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
