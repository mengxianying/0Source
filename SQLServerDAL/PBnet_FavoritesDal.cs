using System;
using System.Collections.Generic;
using System.Text;
using Pbzx.Model;
using System.Data;
using System.Data.SqlClient;
using Maticsoft.DBUtility;

namespace Pbzx.SQLServerDAL
{
    public class PBnet_FavoritesDal : DBAccess
    {

        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int FavoritesID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PBnet_Favorites");
            strSql.Append(" where FavoritesID=@FavoritesID ");
            SqlParameter[] parameters = {
					new SqlParameter("@FavoritesID", SqlDbType.Int,4)};
            parameters[0].Value = FavoritesID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.PBnet_Favorites model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PBnet_Favorites(");
            strSql.Append("UserID,UserName,ProductID,TableName,DateAdded)");
            strSql.Append(" values (");
            strSql.Append("@UserID,@UserName,@ProductID,@TableName,@DateAdded)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductID", SqlDbType.Int,4),
					new SqlParameter("@TableName", SqlDbType.VarChar,50),
					new SqlParameter("@DateAdded", SqlDbType.SmallDateTime)};
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.UserName;
            parameters[2].Value = model.ProductID;
            parameters[3].Value = model.TableName;
            parameters[4].Value = model.DateAdded;

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
        public void Update(Pbzx.Model.PBnet_Favorites model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PBnet_Favorites set ");
            strSql.Append("UserID=@UserID,");
            strSql.Append("UserName=@UserName,");
            strSql.Append("ProductID=@ProductID,");
            strSql.Append("TableName=@TableName,");
            strSql.Append("DateAdded=@DateAdded");
            strSql.Append(" where FavoritesID=@FavoritesID ");
            SqlParameter[] parameters = {
					new SqlParameter("@FavoritesID", SqlDbType.Int,4),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductID", SqlDbType.Int,4),
					new SqlParameter("@TableName", SqlDbType.VarChar,50),
					new SqlParameter("@DateAdded", SqlDbType.SmallDateTime)};
            parameters[0].Value = model.FavoritesID;
            parameters[1].Value = model.UserID;
            parameters[2].Value = model.UserName;
            parameters[3].Value = model.ProductID;
            parameters[4].Value = model.TableName;
            parameters[5].Value = model.DateAdded;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int FavoritesID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PBnet_Favorites ");
            strSql.Append(" where FavoritesID=@FavoritesID ");
            SqlParameter[] parameters = {
					new SqlParameter("@FavoritesID", SqlDbType.Int,4)};
            parameters[0].Value = FavoritesID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.PBnet_Favorites GetModel(int FavoritesID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 FavoritesID,UserID,UserName,ProductID,TableName,DateAdded from PBnet_Favorites ");
            strSql.Append(" where FavoritesID=@FavoritesID ");
            SqlParameter[] parameters = {
					new SqlParameter("@FavoritesID", SqlDbType.Int,4)};
            parameters[0].Value = FavoritesID;

            Pbzx.Model.PBnet_Favorites model = new Pbzx.Model.PBnet_Favorites();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["FavoritesID"].ToString() != "")
                {
                    model.FavoritesID = int.Parse(ds.Tables[0].Rows[0]["FavoritesID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                if (ds.Tables[0].Rows[0]["ProductID"].ToString() != "")
                {
                    model.ProductID = int.Parse(ds.Tables[0].Rows[0]["ProductID"].ToString());
                }
                model.TableName = ds.Tables[0].Rows[0]["TableName"].ToString();
                if (ds.Tables[0].Rows[0]["DateAdded"].ToString() != "")
                {
                    model.DateAdded = DateTime.Parse(ds.Tables[0].Rows[0]["DateAdded"].ToString());
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
            strSql.Append("select FavoritesID,UserID,UserName,ProductID,TableName,DateAdded ");
            strSql.Append(" FROM PBnet_Favorites ");
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
            strSql.Append(" FavoritesID,UserID,UserName,ProductID,TableName,DateAdded ");
            strSql.Append(" FROM PBnet_Favorites ");
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
            parameters[0].Value = "PBnet_Favorites";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  成员方法

        #region 添加收藏
        public int InsertFavorites(PBnet_Favorites favorites)
        {
            SqlParameter[] parms ={
                new SqlParameter("@UserID",favorites.UserID),
                new SqlParameter("@UserName",favorites.UserName),
                new SqlParameter("@ProductID",favorites.ProductID),
                new SqlParameter("@TableName",favorites.TableName)
            };
            return base.ExecuteNonQuery(StoredProcedureName.sp_InsertFavorites, parms);
        }
        #endregion 
        
        #region 获取用户的收藏
        public DataSet SelectFavoritesByUserID(int userID)
        {
            SqlParameter parm = new SqlParameter("@UserID", userID);

            return base.GetDataSet(StoredProcedureName.sp_SelectFavoritesByUserID, parm);
        }
        #endregion

        #region 删除某一条收藏记录
        public int DeleteFavoritesByID(int favoritesID)
        {
            SqlParameter parm = new SqlParameter("@FavoritesID", favoritesID);

            return base.ExecuteNonQuery(StoredProcedureName.sp_DeleteFavoritesByID, parm);
        }
        #endregion
    }
}
