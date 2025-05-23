using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类PBnet_UserTradeInfo。
    /// </summary>
    public class PBnet_UserTradeInfo : IPBnet_UserTradeInfo
    {
        public PBnet_UserTradeInfo()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PBnet_UserTradeInfo");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.PBnet_UserTradeInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PBnet_UserTradeInfo(");
            strSql.Append("UserName,TradeMoney,TradeTime,TradeType,BankName,AccountNumber,Account_UserName,OperateManager,CurrentMoney,ForeignKey_id,Remark)");
            strSql.Append(" values (");
            strSql.Append("@UserName,@TradeMoney,@TradeTime,@TradeType,@BankName,@AccountNumber,@Account_UserName,@OperateManager,@CurrentMoney,@ForeignKey_id,@Remark)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@TradeMoney", SqlDbType.Money,8),
					new SqlParameter("@TradeTime", SqlDbType.DateTime),
					new SqlParameter("@TradeType", SqlDbType.SmallInt,2),
					new SqlParameter("@BankName", SqlDbType.NVarChar,20),
					new SqlParameter("@AccountNumber", SqlDbType.VarChar,50),
					new SqlParameter("@Account_UserName", SqlDbType.NVarChar,20),
					new SqlParameter("@OperateManager", SqlDbType.NVarChar,20),
					new SqlParameter("@CurrentMoney", SqlDbType.Money,8),
					new SqlParameter("@ForeignKey_id", SqlDbType.VarChar,50),
					new SqlParameter("@Remark", SqlDbType.NVarChar,1000)};
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.TradeMoney;
            parameters[2].Value = model.TradeTime;
            parameters[3].Value = model.TradeType;
            parameters[4].Value = model.BankName;
            parameters[5].Value = model.AccountNumber;
            parameters[6].Value = model.Account_UserName;
            parameters[7].Value = model.OperateManager;
            parameters[8].Value = model.CurrentMoney;
            parameters[9].Value = model.ForeignKey_id;
            parameters[10].Value = model.Remark;

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
        public int Update(Pbzx.Model.PBnet_UserTradeInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PBnet_UserTradeInfo set ");
            strSql.Append("UserName=@UserName,");
            strSql.Append("TradeMoney=@TradeMoney,");
            strSql.Append("TradeTime=@TradeTime,");
            strSql.Append("TradeType=@TradeType,");
            strSql.Append("BankName=@BankName,");
            strSql.Append("AccountNumber=@AccountNumber,");
            strSql.Append("Account_UserName=@Account_UserName,");
            strSql.Append("OperateManager=@OperateManager,");
            strSql.Append("CurrentMoney=@CurrentMoney,");
            strSql.Append("ForeignKey_id=@ForeignKey_id,");
            strSql.Append("Remark=@Remark");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@TradeMoney", SqlDbType.Money,8),
					new SqlParameter("@TradeTime", SqlDbType.DateTime),
					new SqlParameter("@TradeType", SqlDbType.SmallInt,2),
					new SqlParameter("@BankName", SqlDbType.NVarChar,20),
					new SqlParameter("@AccountNumber", SqlDbType.VarChar,50),
					new SqlParameter("@Account_UserName", SqlDbType.NVarChar,20),
					new SqlParameter("@OperateManager", SqlDbType.NVarChar,20),
					new SqlParameter("@CurrentMoney", SqlDbType.Money,8),
					new SqlParameter("@ForeignKey_id", SqlDbType.VarChar,50),
					new SqlParameter("@Remark", SqlDbType.NVarChar,1000)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.UserName;
            parameters[2].Value = model.TradeMoney;
            parameters[3].Value = model.TradeTime;
            parameters[4].Value = model.TradeType;
            parameters[5].Value = model.BankName;
            parameters[6].Value = model.AccountNumber;
            parameters[7].Value = model.Account_UserName;
            parameters[8].Value = model.OperateManager;
            parameters[9].Value = model.CurrentMoney;
            parameters[10].Value = model.ForeignKey_id;
            parameters[11].Value = model.Remark;

           return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PBnet_UserTradeInfo ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

           return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.PBnet_UserTradeInfo GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,UserName,TradeMoney,TradeTime,TradeType,BankName,AccountNumber,Account_UserName,OperateManager,CurrentMoney,ForeignKey_id,Remark from PBnet_UserTradeInfo ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            Pbzx.Model.PBnet_UserTradeInfo model = new Pbzx.Model.PBnet_UserTradeInfo();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                if (ds.Tables[0].Rows[0]["TradeMoney"].ToString() != "")
                {
                    model.TradeMoney = decimal.Parse(ds.Tables[0].Rows[0]["TradeMoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TradeTime"].ToString() != "")
                {
                    model.TradeTime = DateTime.Parse(ds.Tables[0].Rows[0]["TradeTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TradeType"].ToString() != "")
                {
                    model.TradeType = int.Parse(ds.Tables[0].Rows[0]["TradeType"].ToString());
                }
                model.BankName = ds.Tables[0].Rows[0]["BankName"].ToString();
                model.AccountNumber = ds.Tables[0].Rows[0]["AccountNumber"].ToString();
                model.Account_UserName = ds.Tables[0].Rows[0]["Account_UserName"].ToString();
                model.OperateManager = ds.Tables[0].Rows[0]["OperateManager"].ToString();
                if (ds.Tables[0].Rows[0]["CurrentMoney"].ToString() != "")
                {
                    model.CurrentMoney = decimal.Parse(ds.Tables[0].Rows[0]["CurrentMoney"].ToString());
                }
                model.ForeignKey_id = ds.Tables[0].Rows[0]["ForeignKey_id"].ToString();
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
            strSql.Append("select ID,UserName,TradeMoney,TradeTime,TradeType,BankName,AccountNumber,Account_UserName,OperateManager,CurrentMoney,ForeignKey_id,Remark ");
            strSql.Append(" FROM PBnet_UserTradeInfo ");
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
            strSql.Append(" ID,UserName,TradeMoney,TradeTime,TradeType,BankName,AccountNumber,Account_UserName,OperateManager,CurrentMoney,ForeignKey_id,Remark ");
            strSql.Append(" FROM PBnet_UserTradeInfo ");
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
            parameters[0].Value = "PBnet_UserTradeInfo";
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

