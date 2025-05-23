using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类PBnet_broker_TradeInfo。
    /// </summary>
    public class PBnet_broker_TradeInfo : IPBnet_broker_TradeInfo
    {
        public PBnet_broker_TradeInfo()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PBnet_broker_TradeInfo");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.PBnet_broker_TradeInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PBnet_broker_TradeInfo(");
            strSql.Append("BrokerName,OrderID,CustomerName,CustomerPay,BrokerIncome,CreateTime,RegManager,Remark)");
            strSql.Append(" values (");
            strSql.Append("@BrokerName,@OrderID,@CustomerName,@CustomerPay,@BrokerIncome,@CreateTime,@RegManager,@Remark)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@BrokerName", SqlDbType.VarChar,50),
					new SqlParameter("@OrderID", SqlDbType.VarChar,50),
					new SqlParameter("@CustomerName", SqlDbType.VarChar,50),
					new SqlParameter("@CustomerPay", SqlDbType.Money,8),
					new SqlParameter("@BrokerIncome", SqlDbType.Money,8),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@RegManager", SqlDbType.NVarChar,20),
					new SqlParameter("@Remark", SqlDbType.VarChar,512)};
            parameters[0].Value = model.BrokerName;
            parameters[1].Value = model.OrderID;
            parameters[2].Value = model.CustomerName;
            parameters[3].Value = model.CustomerPay;
            parameters[4].Value = model.BrokerIncome;
            parameters[5].Value = model.CreateTime;
            parameters[6].Value = model.RegManager;
            parameters[7].Value = model.Remark;

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
        public int Update(Pbzx.Model.PBnet_broker_TradeInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PBnet_broker_TradeInfo set ");
            strSql.Append("BrokerName=@BrokerName,");
            strSql.Append("OrderID=@OrderID,");
            strSql.Append("CustomerName=@CustomerName,");
            strSql.Append("CustomerPay=@CustomerPay,");
            strSql.Append("BrokerIncome=@BrokerIncome,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("RegManager=@RegManager,");
            strSql.Append("Remark=@Remark");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4),
					new SqlParameter("@BrokerName", SqlDbType.VarChar,50),
					new SqlParameter("@OrderID", SqlDbType.VarChar,50),
					new SqlParameter("@CustomerName", SqlDbType.VarChar,50),
					new SqlParameter("@CustomerPay", SqlDbType.Money,8),
					new SqlParameter("@BrokerIncome", SqlDbType.Money,8),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@RegManager", SqlDbType.NVarChar,20),
					new SqlParameter("@Remark", SqlDbType.VarChar,512)};
            parameters[0].Value = model.Id;
            parameters[1].Value = model.BrokerName;
            parameters[2].Value = model.OrderID;
            parameters[3].Value = model.CustomerName;
            parameters[4].Value = model.CustomerPay;
            parameters[5].Value = model.BrokerIncome;
            parameters[6].Value = model.CreateTime;
            parameters[7].Value = model.RegManager;
            parameters[8].Value = model.Remark;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PBnet_broker_TradeInfo ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.PBnet_broker_TradeInfo GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,BrokerName,OrderID,CustomerName,CustomerPay,BrokerIncome,CreateTime,RegManager,Remark from PBnet_broker_TradeInfo ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            Pbzx.Model.PBnet_broker_TradeInfo model = new Pbzx.Model.PBnet_broker_TradeInfo();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.BrokerName = ds.Tables[0].Rows[0]["BrokerName"].ToString();
                model.OrderID = ds.Tables[0].Rows[0]["OrderID"].ToString();
                model.CustomerName = ds.Tables[0].Rows[0]["CustomerName"].ToString();
                if (ds.Tables[0].Rows[0]["CustomerPay"].ToString() != "")
                {
                    model.CustomerPay = decimal.Parse(ds.Tables[0].Rows[0]["CustomerPay"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BrokerIncome"].ToString() != "")
                {
                    model.BrokerIncome = decimal.Parse(ds.Tables[0].Rows[0]["BrokerIncome"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(ds.Tables[0].Rows[0]["CreateTime"].ToString());
                }
                model.RegManager = ds.Tables[0].Rows[0]["RegManager"].ToString();
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
            strSql.Append("select Id,BrokerName,OrderID,CustomerName,CustomerPay,BrokerIncome,CreateTime,RegManager,Remark ");
            strSql.Append(" FROM PBnet_broker_TradeInfo ");
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
            strSql.Append(" Id,BrokerName,OrderID,CustomerName,CustomerPay,BrokerIncome,CreateTime,RegManager,Remark ");
            strSql.Append(" FROM PBnet_broker_TradeInfo ");
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
            parameters[0].Value = "PBnet_broker_TradeInfo";
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

