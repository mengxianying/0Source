using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类PBnet_OrderTradeInfo。
    /// </summary>
    public class PBnet_OrderTradeInfo : IPBnet_OrderTradeInfo
    {
        public PBnet_OrderTradeInfo()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int TradeID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PBnet_OrderTradeInfo");
            strSql.Append(" where TradeID=@TradeID ");
            SqlParameter[] parameters = {
					new SqlParameter("@TradeID", SqlDbType.Int,4)};
            parameters[0].Value = TradeID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.PBnet_OrderTradeInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PBnet_OrderTradeInfo(");
            strSql.Append("OrderID,c_orderamount,c_ymd,c_transnum,c_succmark,c_cause,c_moneytype,PayType,UserName,PayAndPortType,OrderType,OrderTypeName)");
            strSql.Append(" values (");
            strSql.Append("@OrderID,@c_orderamount,@c_ymd,@c_transnum,@c_succmark,@c_cause,@c_moneytype,@PayType,@UserName,@PayAndPortType,@OrderType,@OrderTypeName)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.VarChar,50),
					new SqlParameter("@c_orderamount", SqlDbType.Money,8),
					new SqlParameter("@c_ymd", SqlDbType.DateTime),
					new SqlParameter("@c_transnum", SqlDbType.VarChar,50),
					new SqlParameter("@c_succmark", SqlDbType.Bit,1),
					new SqlParameter("@c_cause", SqlDbType.VarChar,200),
					new SqlParameter("@c_moneytype", SqlDbType.SmallInt,2),
					new SqlParameter("@PayType", SqlDbType.SmallInt,2),
					new SqlParameter("@UserName", SqlDbType.VarChar,50),
					new SqlParameter("@PayAndPortType", SqlDbType.VarChar,100),
					new SqlParameter("@OrderType", SqlDbType.Int,4),
					new SqlParameter("@OrderTypeName", SqlDbType.VarChar,50)};
            parameters[0].Value = model.OrderID;
            parameters[1].Value = model.c_orderamount;
            parameters[2].Value = model.c_ymd;
            parameters[3].Value = model.c_transnum;
            parameters[4].Value = model.c_succmark;
            parameters[5].Value = model.c_cause;
            parameters[6].Value = model.c_moneytype;
            parameters[7].Value = model.PayType;
            parameters[8].Value = model.UserName;
            parameters[9].Value = model.PayAndPortType;
            parameters[10].Value = model.OrderType;
            parameters[11].Value = model.OrderTypeName;

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
        public void Update(Pbzx.Model.PBnet_OrderTradeInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PBnet_OrderTradeInfo set ");
            strSql.Append("OrderID=@OrderID,");
            strSql.Append("c_orderamount=@c_orderamount,");
            strSql.Append("c_ymd=@c_ymd,");
            strSql.Append("c_transnum=@c_transnum,");
            strSql.Append("c_succmark=@c_succmark,");
            strSql.Append("c_cause=@c_cause,");
            strSql.Append("c_moneytype=@c_moneytype,");
            strSql.Append("PayType=@PayType,");
            strSql.Append("UserName=@UserName,");
            strSql.Append("PayAndPortType=@PayAndPortType,");
            strSql.Append("OrderType=@OrderType,");
            strSql.Append("OrderTypeName=@OrderTypeName");
            strSql.Append(" where TradeID=@TradeID ");
            SqlParameter[] parameters = {
					new SqlParameter("@TradeID", SqlDbType.Int,4),
					new SqlParameter("@OrderID", SqlDbType.VarChar,50),
					new SqlParameter("@c_orderamount", SqlDbType.Money,8),
					new SqlParameter("@c_ymd", SqlDbType.DateTime),
					new SqlParameter("@c_transnum", SqlDbType.VarChar,50),
					new SqlParameter("@c_succmark", SqlDbType.Bit,1),
					new SqlParameter("@c_cause", SqlDbType.VarChar,200),
					new SqlParameter("@c_moneytype", SqlDbType.SmallInt,2),
					new SqlParameter("@PayType", SqlDbType.SmallInt,2),
					new SqlParameter("@UserName", SqlDbType.VarChar,50),
					new SqlParameter("@PayAndPortType", SqlDbType.VarChar,100),
					new SqlParameter("@OrderType", SqlDbType.Int,4),
					new SqlParameter("@OrderTypeName", SqlDbType.VarChar,50)};
            parameters[0].Value = model.TradeID;
            parameters[1].Value = model.OrderID;
            parameters[2].Value = model.c_orderamount;
            parameters[3].Value = model.c_ymd;
            parameters[4].Value = model.c_transnum;
            parameters[5].Value = model.c_succmark;
            parameters[6].Value = model.c_cause;
            parameters[7].Value = model.c_moneytype;
            parameters[8].Value = model.PayType;
            parameters[9].Value = model.UserName;
            parameters[10].Value = model.PayAndPortType;
            parameters[11].Value = model.OrderType;
            parameters[12].Value = model.OrderTypeName;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int TradeID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PBnet_OrderTradeInfo ");
            strSql.Append(" where TradeID=@TradeID ");
            SqlParameter[] parameters = {
					new SqlParameter("@TradeID", SqlDbType.Int,4)};
            parameters[0].Value = TradeID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.PBnet_OrderTradeInfo GetModel(int TradeID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 TradeID,OrderID,c_orderamount,c_ymd,c_transnum,c_succmark,c_cause,c_moneytype,PayType,UserName,PayAndPortType,OrderType,OrderTypeName from PBnet_OrderTradeInfo ");
            strSql.Append(" where TradeID=@TradeID ");
            SqlParameter[] parameters = {
					new SqlParameter("@TradeID", SqlDbType.Int,4)};
            parameters[0].Value = TradeID;

            Pbzx.Model.PBnet_OrderTradeInfo model = new Pbzx.Model.PBnet_OrderTradeInfo();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["TradeID"].ToString() != "")
                {
                    model.TradeID = int.Parse(ds.Tables[0].Rows[0]["TradeID"].ToString());
                }
                model.OrderID = ds.Tables[0].Rows[0]["OrderID"].ToString();
                if (ds.Tables[0].Rows[0]["c_orderamount"].ToString() != "")
                {
                    model.c_orderamount = decimal.Parse(ds.Tables[0].Rows[0]["c_orderamount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["c_ymd"].ToString() != "")
                {
                    model.c_ymd = DateTime.Parse(ds.Tables[0].Rows[0]["c_ymd"].ToString());
                }
                model.c_transnum = ds.Tables[0].Rows[0]["c_transnum"].ToString();
                if (ds.Tables[0].Rows[0]["c_succmark"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["c_succmark"].ToString() == "1") || (ds.Tables[0].Rows[0]["c_succmark"].ToString().ToLower() == "true"))
                    {
                        model.c_succmark = true;
                    }
                    else
                    {
                        model.c_succmark = false;
                    }
                }
                model.c_cause = ds.Tables[0].Rows[0]["c_cause"].ToString();
                if (ds.Tables[0].Rows[0]["c_moneytype"].ToString() != "")
                {
                    model.c_moneytype = int.Parse(ds.Tables[0].Rows[0]["c_moneytype"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PayType"].ToString() != "")
                {
                    model.PayType = int.Parse(ds.Tables[0].Rows[0]["PayType"].ToString());
                }
                model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                model.PayAndPortType = ds.Tables[0].Rows[0]["PayAndPortType"].ToString();
                if (ds.Tables[0].Rows[0]["OrderType"].ToString() != "")
                {
                    model.OrderType = int.Parse(ds.Tables[0].Rows[0]["OrderType"].ToString());
                }
                model.OrderTypeName = ds.Tables[0].Rows[0]["OrderTypeName"].ToString();
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
            strSql.Append("select TradeID,OrderID,c_orderamount,c_ymd,c_transnum,c_succmark,c_cause,c_moneytype,PayType,UserName,PayAndPortType,OrderType,OrderTypeName ");
            strSql.Append(" FROM PBnet_OrderTradeInfo ");
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
            strSql.Append(" TradeID,OrderID,c_orderamount,c_ymd,c_transnum,c_succmark,c_cause,c_moneytype,PayType,UserName,PayAndPortType,OrderType,OrderTypeName ");
            strSql.Append(" FROM PBnet_OrderTradeInfo ");
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
            parameters[0].Value = "PBnet_OrderTradeInfo";
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

