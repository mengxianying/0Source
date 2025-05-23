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
    /// 数据访问类Chipped_TrackingOrders。
    /// </summary>
    public class Chipped_TrackingOrders : IChipped_TrackingOrders
    {
        public Chipped_TrackingOrders()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int TrackingID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Chipped_TrackingOrders");
            strSql.Append(" where TrackingID=@TrackingID");
            SqlParameter[] parameters = {
					new SqlParameter("@TrackingID", SqlDbType.Int,4)
};
            parameters[0].Value = TrackingID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.Chipped_TrackingOrders model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Chipped_TrackingOrders(");
            strSql.Append("UserN,TrackingLNum,TrackingName,TrackingTime,SubscribeNum,BuyMoney,TrackingState,TrackingN)");
            strSql.Append(" values (");
            strSql.Append("@UserN,@TrackingLNum,@TrackingName,@TrackingTime,@SubscribeNum,@BuyMoney,@TrackingState,@TrackingN)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@UserN", SqlDbType.NVarChar,50),
					new SqlParameter("@TrackingLNum", SqlDbType.Int,4),
					new SqlParameter("@TrackingName", SqlDbType.NVarChar,50),
					new SqlParameter("@TrackingTime", SqlDbType.DateTime),
					new SqlParameter("@SubscribeNum", SqlDbType.Int,4),
					new SqlParameter("@BuyMoney", SqlDbType.Decimal,9),
					new SqlParameter("@TrackingState", SqlDbType.Int,4),
					new SqlParameter("@TrackingN", SqlDbType.Int,4)};
            parameters[0].Value = model.UserN;
            parameters[1].Value = model.TrackingLNum;
            parameters[2].Value = model.TrackingName;
            parameters[3].Value = model.TrackingTime;
            parameters[4].Value = model.SubscribeNum;
            parameters[5].Value = model.BuyMoney;
            parameters[6].Value = model.TrackingState;
            parameters[7].Value = model.TrackingN;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Pbzx.Model.Chipped_TrackingOrders model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Chipped_TrackingOrders set ");
            strSql.Append("UserN=@UserN,");
            strSql.Append("TrackingLNum=@TrackingLNum,");
            strSql.Append("TrackingName=@TrackingName,");
            strSql.Append("TrackingTime=@TrackingTime,");
            strSql.Append("SubscribeNum=@SubscribeNum,");
            strSql.Append("BuyMoney=@BuyMoney,");
            strSql.Append("TrackingState=@TrackingState,");
            strSql.Append("TrackingN=@TrackingN");
            strSql.Append(" where TrackingID=@TrackingID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserN", SqlDbType.NVarChar,50),
					new SqlParameter("@TrackingLNum", SqlDbType.Int,4),
					new SqlParameter("@TrackingName", SqlDbType.NVarChar,50),
					new SqlParameter("@TrackingTime", SqlDbType.DateTime),
					new SqlParameter("@SubscribeNum", SqlDbType.Int,4),
					new SqlParameter("@BuyMoney", SqlDbType.Decimal,9),
					new SqlParameter("@TrackingState", SqlDbType.Int,4),
					new SqlParameter("@TrackingN", SqlDbType.Int,4),
					new SqlParameter("@TrackingID", SqlDbType.Int,4)};
            parameters[0].Value = model.UserN;
            parameters[1].Value = model.TrackingLNum;
            parameters[2].Value = model.TrackingName;
            parameters[3].Value = model.TrackingTime;
            parameters[4].Value = model.SubscribeNum;
            parameters[5].Value = model.BuyMoney;
            parameters[6].Value = model.TrackingState;
            parameters[7].Value = model.TrackingN;
            parameters[8].Value = model.TrackingID;

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
        public bool Delete(int TrackingID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Chipped_TrackingOrders ");
            strSql.Append(" where TrackingID=@TrackingID");
            SqlParameter[] parameters = {
					new SqlParameter("@TrackingID", SqlDbType.Int,4)
};
            parameters[0].Value = TrackingID;

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
        public bool DeleteList(string TrackingIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Chipped_TrackingOrders ");
            strSql.Append(" where TrackingID in (" + TrackingIDlist + ")  ");
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
        public Pbzx.Model.Chipped_TrackingOrders GetModel(int TrackingID)
        {


            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 TrackingID,UserN,TrackingLNum,TrackingName,TrackingTime,SubscribeNum,BuyMoney,TrackingState,TrackingN from Chipped_TrackingOrders ");
            strSql.Append(" where TrackingID=@TrackingID");
            SqlParameter[] parameters = {
					new SqlParameter("@TrackingID", SqlDbType.Int,4)
};
            parameters[0].Value = TrackingID;

            Pbzx.Model.Chipped_TrackingOrders model = new Pbzx.Model.Chipped_TrackingOrders();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["TrackingID"].ToString() != "")
                {
                    model.TrackingID = int.Parse(ds.Tables[0].Rows[0]["TrackingID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserN"] != null)
                {
                    model.UserN = ds.Tables[0].Rows[0]["UserN"].ToString();
                }
                if (ds.Tables[0].Rows[0]["TrackingLNum"].ToString() != "")
                {
                    model.TrackingLNum = int.Parse(ds.Tables[0].Rows[0]["TrackingLNum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TrackingName"] != null)
                {
                    model.TrackingName = ds.Tables[0].Rows[0]["TrackingName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["TrackingTime"].ToString() != "")
                {
                    model.TrackingTime = DateTime.Parse(ds.Tables[0].Rows[0]["TrackingTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SubscribeNum"].ToString() != "")
                {
                    model.SubscribeNum = int.Parse(ds.Tables[0].Rows[0]["SubscribeNum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BuyMoney"].ToString() != "")
                {
                    model.BuyMoney = decimal.Parse(ds.Tables[0].Rows[0]["BuyMoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TrackingState"].ToString() != "")
                {
                    model.TrackingState = int.Parse(ds.Tables[0].Rows[0]["TrackingState"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TrackingN"].ToString() != "")
                {
                    model.TrackingN = int.Parse(ds.Tables[0].Rows[0]["TrackingN"].ToString());
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
            strSql.Append("select TrackingID,UserN,TrackingLNum,TrackingName,TrackingTime,SubscribeNum,BuyMoney,TrackingState,TrackingN ");
            strSql.Append(" FROM Chipped_TrackingOrders ");
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
            strSql.Append(" TrackingID,UserN,TrackingLNum,TrackingName,TrackingTime,SubscribeNum,BuyMoney,TrackingState,TrackingN ");
            strSql.Append(" FROM Chipped_TrackingOrders ");
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
            parameters[0].Value = "Chipped_TrackingOrders";
            parameters[1].Value = "TrackingID";
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


