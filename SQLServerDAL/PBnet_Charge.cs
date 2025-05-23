using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Pbzx.IDAL;
using System.Data.SqlClient;
using Maticsoft.DBUtility;

namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类PBnet_Charge。
    /// </summary>
    public class PBnet_Charge : IPBnet_Charge
    {
        public PBnet_Charge()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PBnet_Charge");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.PBnet_Charge model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PBnet_Charge(");
            strSql.Append("OrderID,UserID,UserName,RealName,OrderDate,PayMoney,PayTypeID,PayTypeName,HasPayedPrice,PayNum,c_memo1,c_memo2,Type,State,Remark,Result,IsPay,IsCancel,UpdateStaticDate,OnlineType,TipID,TipName,UserIP)");
            strSql.Append(" values (");
            strSql.Append("@OrderID,@UserID,@UserName,@RealName,@OrderDate,@PayMoney,@PayTypeID,@PayTypeName,@HasPayedPrice,@PayNum,@c_memo1,@c_memo2,@Type,@State,@Remark,@Result,@IsPay,@IsCancel,@UpdateStaticDate,@OnlineType,@TipID,@TipName,@UserIP)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.VarChar,50),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@RealName", SqlDbType.VarChar,50),
					new SqlParameter("@OrderDate", SqlDbType.SmallDateTime),
					new SqlParameter("@PayMoney", SqlDbType.Money,8),
					new SqlParameter("@PayTypeID", SqlDbType.SmallInt,2),
					new SqlParameter("@PayTypeName", SqlDbType.VarChar,100),
					new SqlParameter("@HasPayedPrice", SqlDbType.Money,8),
					new SqlParameter("@PayNum", SqlDbType.VarChar,30),
					new SqlParameter("@c_memo1", SqlDbType.VarChar,200),
					new SqlParameter("@c_memo2", SqlDbType.VarChar,200),
					new SqlParameter("@Type", SqlDbType.TinyInt,1),
					new SqlParameter("@State", SqlDbType.TinyInt,1),
					new SqlParameter("@Remark", SqlDbType.NVarChar,255),
					new SqlParameter("@Result", SqlDbType.NVarChar,255),
					new SqlParameter("@IsPay", SqlDbType.SmallInt,2),
					new SqlParameter("@IsCancel", SqlDbType.SmallInt,2),
					new SqlParameter("@UpdateStaticDate", SqlDbType.SmallDateTime),
					new SqlParameter("@OnlineType", SqlDbType.SmallInt,2),
					new SqlParameter("@TipID", SqlDbType.SmallInt,2),
					new SqlParameter("@TipName", SqlDbType.VarChar,100),
					new SqlParameter("@UserIP", SqlDbType.VarChar,20)};
            parameters[0].Value = model.OrderID;
            parameters[1].Value = model.UserID;
            parameters[2].Value = model.UserName;
            parameters[3].Value = model.RealName;
            parameters[4].Value = model.OrderDate;
            parameters[5].Value = model.PayMoney;
            parameters[6].Value = model.PayTypeID;
            parameters[7].Value = model.PayTypeName;
            parameters[8].Value = model.HasPayedPrice;
            parameters[9].Value = model.PayNum;
            parameters[10].Value = model.c_memo1;
            parameters[11].Value = model.c_memo2;
            parameters[12].Value = model.Type;
            parameters[13].Value = model.State;
            parameters[14].Value = model.Remark;
            parameters[15].Value = model.Result;
            parameters[16].Value = model.IsPay;
            parameters[17].Value = model.IsCancel;
            parameters[18].Value = model.UpdateStaticDate;
            parameters[19].Value = model.OnlineType;
            parameters[20].Value = model.TipID;
            parameters[21].Value = model.TipName;
            parameters[22].Value = model.UserIP;

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
        public int Update(Pbzx.Model.PBnet_Charge model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PBnet_Charge set ");
            strSql.Append("UserID=@UserID,");
            strSql.Append("RealName=@RealName,");
            strSql.Append("OrderDate=@OrderDate,");
            strSql.Append("PayMoney=@PayMoney,");
            strSql.Append("PayTypeID=@PayTypeID,");
            strSql.Append("PayTypeName=@PayTypeName,");
            strSql.Append("HasPayedPrice=@HasPayedPrice,");
            strSql.Append("PayNum=@PayNum,");
            strSql.Append("c_memo1=@c_memo1,");
            strSql.Append("c_memo2=@c_memo2,");
            strSql.Append("Type=@Type,");
            strSql.Append("State=@State,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("Result=@Result,");
            strSql.Append("IsPay=@IsPay,");
            strSql.Append("IsCancel=@IsCancel,");
            strSql.Append("UpdateStaticDate=@UpdateStaticDate,");
            strSql.Append("OnlineType=@OnlineType,");
            strSql.Append("TipID=@TipID,");
            strSql.Append("TipName=@TipName,");
            strSql.Append("UserIP=@UserIP");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4),
					new SqlParameter("@OrderID", SqlDbType.VarChar,50),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@RealName", SqlDbType.VarChar,50),
					new SqlParameter("@OrderDate", SqlDbType.SmallDateTime),
					new SqlParameter("@PayMoney", SqlDbType.Money,8),
					new SqlParameter("@PayTypeID", SqlDbType.SmallInt,2),
					new SqlParameter("@PayTypeName", SqlDbType.VarChar,100),
					new SqlParameter("@HasPayedPrice", SqlDbType.Money,8),
					new SqlParameter("@PayNum", SqlDbType.VarChar,30),
					new SqlParameter("@c_memo1", SqlDbType.VarChar,200),
					new SqlParameter("@c_memo2", SqlDbType.VarChar,200),
					new SqlParameter("@Type", SqlDbType.TinyInt,1),
					new SqlParameter("@State", SqlDbType.TinyInt,1),
					new SqlParameter("@Remark", SqlDbType.NVarChar,255),
					new SqlParameter("@Result", SqlDbType.NVarChar,255),
					new SqlParameter("@IsPay", SqlDbType.SmallInt,2),
					new SqlParameter("@IsCancel", SqlDbType.SmallInt,2),
					new SqlParameter("@UpdateStaticDate", SqlDbType.SmallDateTime),
					new SqlParameter("@OnlineType", SqlDbType.SmallInt,2),
					new SqlParameter("@TipID", SqlDbType.SmallInt,2),
					new SqlParameter("@TipName", SqlDbType.VarChar,100),
					new SqlParameter("@UserIP", SqlDbType.VarChar,20)};
            parameters[0].Value = model.Id;
            parameters[1].Value = model.OrderID;
            parameters[2].Value = model.UserID;
            parameters[3].Value = model.UserName;
            parameters[4].Value = model.RealName;
            parameters[5].Value = model.OrderDate;
            parameters[6].Value = model.PayMoney;
            parameters[7].Value = model.PayTypeID;
            parameters[8].Value = model.PayTypeName;
            parameters[9].Value = model.HasPayedPrice;
            parameters[10].Value = model.PayNum;
            parameters[11].Value = model.c_memo1;
            parameters[12].Value = model.c_memo2;
            parameters[13].Value = model.Type;
            parameters[14].Value = model.State;
            parameters[15].Value = model.Remark;
            parameters[16].Value = model.Result;
            parameters[17].Value = model.IsPay;
            parameters[18].Value = model.IsCancel;
            parameters[19].Value = model.UpdateStaticDate;
            parameters[20].Value = model.OnlineType;
            parameters[21].Value = model.TipID;
            parameters[22].Value = model.TipName;
            parameters[23].Value = model.UserIP;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PBnet_Charge ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.PBnet_Charge GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,OrderID,UserID,UserName,RealName,OrderDate,PayMoney,PayTypeID,PayTypeName,HasPayedPrice,PayNum,c_memo1,c_memo2,Type,State,Remark,Result,IsPay,IsCancel,UpdateStaticDate,OnlineType,TipID,TipName,UserIP from PBnet_Charge ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            Pbzx.Model.PBnet_Charge model = new Pbzx.Model.PBnet_Charge();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.OrderID = ds.Tables[0].Rows[0]["OrderID"].ToString();
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                model.RealName = ds.Tables[0].Rows[0]["RealName"].ToString();
                if (ds.Tables[0].Rows[0]["OrderDate"].ToString() != "")
                {
                    model.OrderDate = DateTime.Parse(ds.Tables[0].Rows[0]["OrderDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PayMoney"].ToString() != "")
                {
                    model.PayMoney = decimal.Parse(ds.Tables[0].Rows[0]["PayMoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PayTypeID"].ToString() != "")
                {
                    model.PayTypeID = int.Parse(ds.Tables[0].Rows[0]["PayTypeID"].ToString());
                }
                model.PayTypeName = ds.Tables[0].Rows[0]["PayTypeName"].ToString();
                if (ds.Tables[0].Rows[0]["HasPayedPrice"].ToString() != "")
                {
                    model.HasPayedPrice = decimal.Parse(ds.Tables[0].Rows[0]["HasPayedPrice"].ToString());
                }
                model.PayNum = ds.Tables[0].Rows[0]["PayNum"].ToString();
                model.c_memo1 = ds.Tables[0].Rows[0]["c_memo1"].ToString();
                model.c_memo2 = ds.Tables[0].Rows[0]["c_memo2"].ToString();
                if (ds.Tables[0].Rows[0]["Type"].ToString() != "")
                {
                    model.Type = int.Parse(ds.Tables[0].Rows[0]["Type"].ToString());
                }
                if (ds.Tables[0].Rows[0]["State"].ToString() != "")
                {
                    model.State = int.Parse(ds.Tables[0].Rows[0]["State"].ToString());
                }
                model.Remark = ds.Tables[0].Rows[0]["Remark"].ToString();
                model.Result = ds.Tables[0].Rows[0]["Result"].ToString();
                if (ds.Tables[0].Rows[0]["IsPay"].ToString() != "")
                {
                    model.IsPay = int.Parse(ds.Tables[0].Rows[0]["IsPay"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsCancel"].ToString() != "")
                {
                    model.IsCancel = int.Parse(ds.Tables[0].Rows[0]["IsCancel"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UpdateStaticDate"].ToString() != "")
                {
                    model.UpdateStaticDate = DateTime.Parse(ds.Tables[0].Rows[0]["UpdateStaticDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OnlineType"].ToString() != "")
                {
                    model.OnlineType = int.Parse(ds.Tables[0].Rows[0]["OnlineType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TipID"].ToString() != "")
                {
                    model.TipID = int.Parse(ds.Tables[0].Rows[0]["TipID"].ToString());
                }
                model.TipName = ds.Tables[0].Rows[0]["TipName"].ToString();
                model.UserIP = ds.Tables[0].Rows[0]["UserIP"].ToString();
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
            strSql.Append("select Id,OrderID,UserID,UserName,RealName,OrderDate,PayMoney,PayTypeID,PayTypeName,HasPayedPrice,PayNum,c_memo1,c_memo2,Type,State,Remark,Result,IsPay,IsCancel,UpdateStaticDate,OnlineType,TipID,TipName,UserIP ");
            strSql.Append(" FROM PBnet_Charge ");
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
            strSql.Append(" Id,OrderID,UserID,UserName,RealName,OrderDate,PayMoney,PayTypeID,PayTypeName,HasPayedPrice,PayNum,c_memo1,c_memo2,Type,State,Remark,Result,IsPay,IsCancel,UpdateStaticDate,OnlineType,TipID,TipName,UserIP ");
            strSql.Append(" FROM PBnet_Charge ");
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
            parameters[0].Value = "PBnet_Charge";
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
