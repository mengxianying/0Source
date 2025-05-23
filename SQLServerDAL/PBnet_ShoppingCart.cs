using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using Pbzx.Model;
using System.Collections.Generic;//请先添加引用
namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类PBnet_ShoppingCart。
    /// </summary>
    public class PBnet_ShoppingCart
    {
        public PBnet_ShoppingCart()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long CartID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PBnet_ShoppingCart");
            strSql.Append(" where CartID=@CartID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CartID", SqlDbType.BigInt)};
            parameters[0].Value = CartID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.PBnet_ShoppingCart model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PBnet_ShoppingCart(");
            strSql.Append("CartGuid,ProductID,RegType,Quatity,DataAdded,UseTime)");
            strSql.Append(" values (");
            strSql.Append("@CartGuid,@ProductID,@RegType,@Quatity,@DataAdded,@UseTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@CartGuid", SqlDbType.VarChar,50),
					new SqlParameter("@ProductID", SqlDbType.Int,4),
					new SqlParameter("@RegType", SqlDbType.VarChar,100),
					new SqlParameter("@Quatity", SqlDbType.SmallInt,2),
					new SqlParameter("@DataAdded", SqlDbType.SmallDateTime),
					new SqlParameter("@UseTime", SqlDbType.VarChar,50)};
            parameters[0].Value = model.CartGuid;
            parameters[1].Value = model.ProductID;
            parameters[2].Value = model.RegType;
            parameters[3].Value = model.Quatity;
            parameters[4].Value = model.DataAdded;
            parameters[5].Value = model.UseTime;

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
        public void Update(Pbzx.Model.PBnet_ShoppingCart model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PBnet_ShoppingCart set ");
            strSql.Append("CartGuid=@CartGuid,");
            strSql.Append("ProductID=@ProductID,");
            strSql.Append("RegType=@RegType,");
            strSql.Append("Quatity=@Quatity,");
            strSql.Append("DataAdded=@DataAdded,");
            strSql.Append("UseTime=@UseTime");
            strSql.Append(" where CartID=@CartID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CartID", SqlDbType.BigInt,8),
					new SqlParameter("@CartGuid", SqlDbType.VarChar,50),
					new SqlParameter("@ProductID", SqlDbType.Int,4),
					new SqlParameter("@RegType", SqlDbType.VarChar,100),
					new SqlParameter("@Quatity", SqlDbType.SmallInt,2),
					new SqlParameter("@DataAdded", SqlDbType.SmallDateTime),
					new SqlParameter("@UseTime", SqlDbType.VarChar,50)};
            parameters[0].Value = model.CartID;
            parameters[1].Value = model.CartGuid;
            parameters[2].Value = model.ProductID;
            parameters[3].Value = model.RegType;
            parameters[4].Value = model.Quatity;
            parameters[5].Value = model.DataAdded;
            parameters[6].Value = model.UseTime;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(long CartID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PBnet_ShoppingCart ");
            strSql.Append(" where CartID=@CartID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CartID", SqlDbType.BigInt)};
            parameters[0].Value = CartID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.PBnet_ShoppingCart GetModel(long CartID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 CartID,CartGuid,ProductID,RegType,Quatity,DataAdded,UseTime from PBnet_ShoppingCart ");
            strSql.Append(" where CartID=@CartID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CartID", SqlDbType.BigInt)};
            parameters[0].Value = CartID;

            Pbzx.Model.PBnet_ShoppingCart model = new Pbzx.Model.PBnet_ShoppingCart();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["CartID"].ToString() != "")
                {
                    model.CartID = long.Parse(ds.Tables[0].Rows[0]["CartID"].ToString());
                }
                model.CartGuid = ds.Tables[0].Rows[0]["CartGuid"].ToString();
                if (ds.Tables[0].Rows[0]["ProductID"].ToString() != "")
                {
                    model.ProductID = int.Parse(ds.Tables[0].Rows[0]["ProductID"].ToString());
                }
                model.RegType = ds.Tables[0].Rows[0]["RegType"].ToString();
                if (ds.Tables[0].Rows[0]["Quatity"].ToString() != "")
                {
                    model.Quatity = int.Parse(ds.Tables[0].Rows[0]["Quatity"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DataAdded"].ToString() != "")
                {
                    model.DataAdded = DateTime.Parse(ds.Tables[0].Rows[0]["DataAdded"].ToString());
                }
                model.UseTime = ds.Tables[0].Rows[0]["UseTime"].ToString();
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
            strSql.Append("select CartID,CartGuid,ProductID,RegType,Quatity,DataAdded,UseTime ");
            strSql.Append(" FROM PBnet_ShoppingCart ");
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
            strSql.Append(" CartID,CartGuid,ProductID,RegType,Quatity,DataAdded,UseTime ");
            strSql.Append(" FROM PBnet_ShoppingCart ");
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
            parameters[0].Value = "PBnet_ShoppingCart";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  成员方法

        #region 添加购物车
        public int InsertShoppingCart(Pbzx.Model.PBnet_ShoppingCart shoppingCart)
        {

            int cartID = 0;

            SqlParameter[] parms ={
                new SqlParameter("@ProductID",shoppingCart.ProductID),
                new SqlParameter("@CartGuid",shoppingCart.CartGuid),                
                new SqlParameter("@RegType",shoppingCart.RegType),
                new SqlParameter("@Quatity",shoppingCart.Quatity)
            };

            using (SqlDataReader dr = SQLHelper.ExecuteReader(DbHelperSQL.ConnectionString, CommandType.StoredProcedure, StoredProcedureName.sp_InsertShoppingCart.ToString(), parms))
            {
                if (dr.Read())
                {
                    cartID = Convert.ToInt32(dr[0]);
                }
            }

            return cartID;
        }
        #endregion

        #region 通过CartGuid获取购物车
        public DataSet SelectShoppingCartByCartGuid(string cartGuid)
        {
            SqlParameter parm = new SqlParameter("@CartGuid", cartGuid);
            //   return SQLHelper.GetDataSet(DbHelperSQL.ConnectionString, CommandType.StoredProcedure, StoredProcedureName.sp_SelectShoppingCartByCartGuid.ToString(), parm);
            return DbHelperSQL.Query("select t1.*,t2.* from PBnet_ShoppingCart as t1 inner join PBnet_Product as t2 on t1.ProductID=t2.pb_SoftID where CartGuid='" + cartGuid + "'");
        }
        #endregion

        #region 更新购物车
        public int UpdateShoppingCart(Pbzx.Model.PBnet_ShoppingCart shoppingCart)
        {
            return 0;
        }

        public int UpdateShoppingCart(List<Pbzx.Model.PBnet_ShoppingCart> shoppingCartList)
        {
            int result = 0;
            using (SqlConnection conn = new SqlConnection(DbHelperSQL.ConnectionString))
            {
                foreach (Pbzx.Model.PBnet_ShoppingCart shoppingCart in shoppingCartList)
                {
                    SqlParameter[] parms =
                    {
                        new SqlParameter("@CartID",shoppingCart.CartID),
                        new SqlParameter("@Quatity",shoppingCart.Quatity)
                    };

                    result += SQLHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, StoredProcedureName.sp_UpdateShoppingCart.ToString(), parms);
                }

                return result;
            }
        }
        #endregion

        #region 按CartID删除购物车记录
        public int DeleteShoppingCartByCartID(int cartID)
        {
            SqlParameter parm = new SqlParameter("@CartID", cartID);

            return SQLHelper.ExecuteNonQuery(DbHelperSQL.ConnectionString, CommandType.StoredProcedure, StoredProcedureName.sp_DeleteShoppingCartByCartID.ToString(), parm);
        }
        #endregion

        #region 按CartGuid删除购物车记录
        public int DeleteShoppingCartByCartGuid(string cartGuid)
        {
            SqlParameter parm = new SqlParameter("@CartGuid", cartGuid);

            return SQLHelper.ExecuteNonQuery(DbHelperSQL.ConnectionString, CommandType.StoredProcedure, StoredProcedureName.sp_DeleteShoppingCartByCartGuid.ToString(), parm);
        }
        #endregion
    }
}

