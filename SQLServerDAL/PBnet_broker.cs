using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类PBnet_broker。
    /// </summary>
    public class PBnet_broker : IPBnet_broker
    {
        public PBnet_broker()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PBnet_broker");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.PBnet_broker model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PBnet_broker(");
            strSql.Append("UserName,Pass_time,LastLogin_time,Apply_time,State,Discount_gradeName,Discount_rate,Year_tradeMoney,Year_incomeMoney,Total_tradeMoney,Total_incomeMoney,YearStart_time,LastTrade_time,Auditing_Manager,Remark)");
            strSql.Append(" values (");
            strSql.Append("@UserName,@Pass_time,@LastLogin_time,@Apply_time,@State,@Discount_gradeName,@Discount_rate,@Year_tradeMoney,@Year_incomeMoney,@Total_tradeMoney,@Total_incomeMoney,@YearStart_time,@LastTrade_time,@Auditing_Manager,@Remark)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,50),
					new SqlParameter("@Pass_time", SqlDbType.DateTime),
					new SqlParameter("@LastLogin_time", SqlDbType.DateTime),
					new SqlParameter("@Apply_time", SqlDbType.DateTime),
					new SqlParameter("@State", SqlDbType.Int,4),
					new SqlParameter("@Discount_gradeName", SqlDbType.VarChar,50),
					new SqlParameter("@Discount_rate", SqlDbType.TinyInt,1),
					new SqlParameter("@Year_tradeMoney", SqlDbType.Money,8),
					new SqlParameter("@Year_incomeMoney", SqlDbType.Money,8),
					new SqlParameter("@Total_tradeMoney", SqlDbType.Money,8),
					new SqlParameter("@Total_incomeMoney", SqlDbType.Money,8),
					new SqlParameter("@YearStart_time", SqlDbType.DateTime),
					new SqlParameter("@LastTrade_time", SqlDbType.DateTime),
					new SqlParameter("@Auditing_Manager", SqlDbType.NVarChar,20),
					new SqlParameter("@Remark", SqlDbType.VarChar,255)};
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.Pass_time;
            parameters[2].Value = model.LastLogin_time;
            parameters[3].Value = model.Apply_time;
            parameters[4].Value = model.State;
            parameters[5].Value = model.Discount_gradeName;
            parameters[6].Value = model.Discount_rate;
            parameters[7].Value = model.Year_tradeMoney;
            parameters[8].Value = model.Year_incomeMoney;
            parameters[9].Value = model.Total_tradeMoney;
            parameters[10].Value = model.Total_incomeMoney;
            parameters[11].Value = model.YearStart_time;
            parameters[12].Value = model.LastTrade_time;
            parameters[13].Value = model.Auditing_Manager;
            parameters[14].Value = model.Remark;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return -1;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Pbzx.Model.PBnet_broker model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PBnet_broker set ");
            strSql.Append("UserName=@UserName,");
            strSql.Append("Pass_time=@Pass_time,");
            strSql.Append("LastLogin_time=@LastLogin_time,");
            strSql.Append("Apply_time=@Apply_time,");
            strSql.Append("State=@State,");
            strSql.Append("Discount_gradeName=@Discount_gradeName,");
            strSql.Append("Discount_rate=@Discount_rate,");
            strSql.Append("Year_tradeMoney=@Year_tradeMoney,");
            strSql.Append("Year_incomeMoney=@Year_incomeMoney,");
            strSql.Append("Total_tradeMoney=@Total_tradeMoney,");
            strSql.Append("Total_incomeMoney=@Total_incomeMoney,");
            strSql.Append("YearStart_time=@YearStart_time,");
            strSql.Append("LastTrade_time=@LastTrade_time,");
            strSql.Append("Auditing_Manager=@Auditing_Manager,");
            strSql.Append("Remark=@Remark");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.VarChar,50),
					new SqlParameter("@Pass_time", SqlDbType.DateTime),
					new SqlParameter("@LastLogin_time", SqlDbType.DateTime),
					new SqlParameter("@Apply_time", SqlDbType.DateTime),
					new SqlParameter("@State", SqlDbType.Int,4),
					new SqlParameter("@Discount_gradeName", SqlDbType.VarChar,50),
					new SqlParameter("@Discount_rate", SqlDbType.TinyInt,1),
					new SqlParameter("@Year_tradeMoney", SqlDbType.Money,8),
					new SqlParameter("@Year_incomeMoney", SqlDbType.Money,8),
					new SqlParameter("@Total_tradeMoney", SqlDbType.Money,8),
					new SqlParameter("@Total_incomeMoney", SqlDbType.Money,8),
					new SqlParameter("@YearStart_time", SqlDbType.DateTime),
					new SqlParameter("@LastTrade_time", SqlDbType.DateTime),
					new SqlParameter("@Auditing_Manager", SqlDbType.NVarChar,20),
					new SqlParameter("@Remark", SqlDbType.VarChar,255)};
            parameters[0].Value = model.Id;
            parameters[1].Value = model.UserName;
            parameters[2].Value = model.Pass_time;
            parameters[3].Value = model.LastLogin_time;
            parameters[4].Value = model.Apply_time;
            parameters[5].Value = model.State;
            parameters[6].Value = model.Discount_gradeName;
            parameters[7].Value = model.Discount_rate;
            parameters[8].Value = model.Year_tradeMoney;
            parameters[9].Value = model.Year_incomeMoney;
            parameters[10].Value = model.Total_tradeMoney;
            parameters[11].Value = model.Total_incomeMoney;
            parameters[12].Value = model.YearStart_time;
            parameters[13].Value = model.LastTrade_time;
            parameters[14].Value = model.Auditing_Manager;
            parameters[15].Value = model.Remark;

          return  DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PBnet_broker ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

           return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.PBnet_broker GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,UserName,Pass_time,LastLogin_time,Apply_time,State,Discount_gradeName,Discount_rate,Year_tradeMoney,Year_incomeMoney,Total_tradeMoney,Total_incomeMoney,YearStart_time,LastTrade_time,Auditing_Manager,Remark from PBnet_broker ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            Pbzx.Model.PBnet_broker model = new Pbzx.Model.PBnet_broker();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                if (ds.Tables[0].Rows[0]["Pass_time"].ToString() != "")
                {
                    model.Pass_time = DateTime.Parse(ds.Tables[0].Rows[0]["Pass_time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LastLogin_time"].ToString() != "")
                {
                    model.LastLogin_time = DateTime.Parse(ds.Tables[0].Rows[0]["LastLogin_time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Apply_time"].ToString() != "")
                {
                    model.Apply_time = DateTime.Parse(ds.Tables[0].Rows[0]["Apply_time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["State"].ToString() != "")
                {
                    model.State = int.Parse(ds.Tables[0].Rows[0]["State"].ToString());
                }
                model.Discount_gradeName = ds.Tables[0].Rows[0]["Discount_gradeName"].ToString();
                if (ds.Tables[0].Rows[0]["Discount_rate"].ToString() != "")
                {
                    model.Discount_rate = int.Parse(ds.Tables[0].Rows[0]["Discount_rate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Year_tradeMoney"].ToString() != "")
                {
                    model.Year_tradeMoney = decimal.Parse(ds.Tables[0].Rows[0]["Year_tradeMoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Year_incomeMoney"].ToString() != "")
                {
                    model.Year_incomeMoney = decimal.Parse(ds.Tables[0].Rows[0]["Year_incomeMoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Total_tradeMoney"].ToString() != "")
                {
                    model.Total_tradeMoney = decimal.Parse(ds.Tables[0].Rows[0]["Total_tradeMoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Total_incomeMoney"].ToString() != "")
                {
                    model.Total_incomeMoney = decimal.Parse(ds.Tables[0].Rows[0]["Total_incomeMoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["YearStart_time"].ToString() != "")
                {
                    model.YearStart_time = DateTime.Parse(ds.Tables[0].Rows[0]["YearStart_time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LastTrade_time"].ToString() != "")
                {
                    model.LastTrade_time = DateTime.Parse(ds.Tables[0].Rows[0]["LastTrade_time"].ToString());
                }
                model.Auditing_Manager = ds.Tables[0].Rows[0]["Auditing_Manager"].ToString();
                model.Remark = ds.Tables[0].Rows[0]["Remark"].ToString();
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
            strSql.Append("select Id,UserName,Pass_time,LastLogin_time,Apply_time,State,Discount_gradeName,Discount_rate,Year_tradeMoney,Year_incomeMoney,Total_tradeMoney,Total_incomeMoney,YearStart_time,LastTrade_time,Auditing_Manager,Remark ");
            strSql.Append(" FROM PBnet_broker ");
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
            strSql.Append(" Id,UserName,Pass_time,LastLogin_time,Apply_time,State,Discount_gradeName,Discount_rate,Year_tradeMoney,Year_incomeMoney,Total_tradeMoney,Total_incomeMoney,YearStart_time,LastTrade_time,Auditing_Manager,Remark ");
            strSql.Append(" FROM PBnet_broker ");
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
            parameters[0].Value = "PBnet_broker";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  成员方法
    }
}

