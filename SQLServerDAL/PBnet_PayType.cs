using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace Pbzx.SQLServerDAL
{
	/// <summary>
	/// 数据访问类PBnet_PayType。
	/// </summary>
	public class PBnet_PayType
	{
		public PBnet_PayType()
		{}
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("PayTypeID", "PBnet_PayType");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int PayTypeID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PBnet_PayType");
            strSql.Append(" where PayTypeID=@PayTypeID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PayTypeID", SqlDbType.SmallInt)};
            parameters[0].Value = PayTypeID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(Pbzx.Model.PBnet_PayType model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PBnet_PayType(");
            strSql.Append("PayTypeID,PayTypeName,PayValue,OrderID,Url,FTypeID,Display,SelectAddress,LinkUrl)");
            strSql.Append(" values (");
            strSql.Append("@PayTypeID,@PayTypeName,@PayValue,@OrderID,@Url,@FTypeID,@Display,@SelectAddress,@LinkUrl)");
            SqlParameter[] parameters = {
					new SqlParameter("@PayTypeID", SqlDbType.SmallInt,2),
					new SqlParameter("@PayTypeName", SqlDbType.NVarChar,50),
					new SqlParameter("@PayValue", SqlDbType.Int,4),
					new SqlParameter("@OrderID", SqlDbType.Int,4),
					new SqlParameter("@Url", SqlDbType.VarChar,255),
					new SqlParameter("@FTypeID", SqlDbType.SmallInt,2),
					new SqlParameter("@Display", SqlDbType.Bit,1),
					new SqlParameter("@SelectAddress", SqlDbType.VarChar,255),
					new SqlParameter("@LinkUrl", SqlDbType.VarChar,255)};
            parameters[0].Value = model.PayTypeID;
            parameters[1].Value = model.PayTypeName;
            parameters[2].Value = model.PayValue;
            parameters[3].Value = model.OrderID;
            parameters[4].Value = model.Url;
            parameters[5].Value = model.FTypeID;
            parameters[6].Value = model.Display;
            parameters[7].Value = model.SelectAddress;
            parameters[8].Value = model.LinkUrl;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(Pbzx.Model.PBnet_PayType model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PBnet_PayType set ");
            strSql.Append("OrderID=@OrderID,");
            strSql.Append("Url=@Url,");
            strSql.Append("FTypeID=@FTypeID,");
            strSql.Append("Display=@Display,");
            strSql.Append("SelectAddress=@SelectAddress,");
            strSql.Append("LinkUrl=@LinkUrl");
            strSql.Append(" where PayTypeID=@PayTypeID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PayTypeID", SqlDbType.SmallInt,2),
					new SqlParameter("@PayTypeName", SqlDbType.NVarChar,50),
					new SqlParameter("@PayValue", SqlDbType.Int,4),
					new SqlParameter("@OrderID", SqlDbType.Int,4),
					new SqlParameter("@Url", SqlDbType.VarChar,255),
					new SqlParameter("@FTypeID", SqlDbType.SmallInt,2),
					new SqlParameter("@Display", SqlDbType.Bit,1),
					new SqlParameter("@SelectAddress", SqlDbType.VarChar,255),
					new SqlParameter("@LinkUrl", SqlDbType.VarChar,255)};
            parameters[0].Value = model.PayTypeID;
            parameters[1].Value = model.PayTypeName;
            parameters[2].Value = model.PayValue;
            parameters[3].Value = model.OrderID;
            parameters[4].Value = model.Url;
            parameters[5].Value = model.FTypeID;
            parameters[6].Value = model.Display;
            parameters[7].Value = model.SelectAddress;
            parameters[8].Value = model.LinkUrl;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int PayTypeID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PBnet_PayType ");
            strSql.Append(" where PayTypeID=@PayTypeID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PayTypeID", SqlDbType.SmallInt)};
            parameters[0].Value = PayTypeID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.PBnet_PayType GetModel(int PayTypeID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 PayTypeID,PayTypeName,PayValue,OrderID,Url,FTypeID,Display,SelectAddress,LinkUrl from PBnet_PayType ");
            strSql.Append(" where PayTypeID=@PayTypeID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PayTypeID", SqlDbType.SmallInt)};
            parameters[0].Value = PayTypeID;

            Pbzx.Model.PBnet_PayType model = new Pbzx.Model.PBnet_PayType();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["PayTypeID"].ToString() != "")
                {
                    model.PayTypeID = int.Parse(ds.Tables[0].Rows[0]["PayTypeID"].ToString());
                }
                model.PayTypeName = ds.Tables[0].Rows[0]["PayTypeName"].ToString();
                if (ds.Tables[0].Rows[0]["PayValue"].ToString() != "")
                {
                    model.PayValue = int.Parse(ds.Tables[0].Rows[0]["PayValue"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrderID"].ToString() != "")
                {
                    model.OrderID = int.Parse(ds.Tables[0].Rows[0]["OrderID"].ToString());
                }
                model.Url = ds.Tables[0].Rows[0]["Url"].ToString();
                if (ds.Tables[0].Rows[0]["FTypeID"].ToString() != "")
                {
                    model.FTypeID = int.Parse(ds.Tables[0].Rows[0]["FTypeID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Display"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["Display"].ToString() == "1") || (ds.Tables[0].Rows[0]["Display"].ToString().ToLower() == "true"))
                    {
                        model.Display = true;
                    }
                    else
                    {
                        model.Display = false;
                    }
                }
                model.SelectAddress = ds.Tables[0].Rows[0]["SelectAddress"].ToString();
                model.LinkUrl = ds.Tables[0].Rows[0]["LinkUrl"].ToString();
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
            strSql.Append("select PayTypeID,PayTypeName,PayValue,OrderID,Url,FTypeID,Display,SelectAddress,LinkUrl ");
            strSql.Append(" FROM PBnet_PayType ");
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
            strSql.Append(" PayTypeID,PayTypeName,PayValue,OrderID,Url,FTypeID,Display,SelectAddress,LinkUrl ");
            strSql.Append(" FROM PBnet_PayType ");
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
            parameters[0].Value = "PBnet_PayType";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  成员方法
        public DataSet SelectAllPayType()
        {
            return GetList("");
        }
	}
}

