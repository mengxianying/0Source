using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类PBnet_UrlMaping。
    /// </summary>
    public class PBnet_UrlMaping : IPBnet_UrlMaping
    {
        public PBnet_UrlMaping()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int MapID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PBnet_UrlMaping");
            strSql.Append(" where MapID=@MapID ");
            SqlParameter[] parameters = {
					new SqlParameter("@MapID", SqlDbType.Int,4)};
            parameters[0].Value = MapID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.PBnet_UrlMaping model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PBnet_UrlMaping(");
            strSql.Append("FID,Html,Aspx,Depth,PageName,OrderID,RootID,TypeID)");
            strSql.Append(" values (");
            strSql.Append("@FID,@Html,@Aspx,@Depth,@PageName,@OrderID,@RootID,@TypeID)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@FID", SqlDbType.Int,4),
					new SqlParameter("@Html", SqlDbType.VarChar,200),
					new SqlParameter("@Aspx", SqlDbType.VarChar,200),
					new SqlParameter("@Depth", SqlDbType.Int,4),
					new SqlParameter("@PageName", SqlDbType.VarChar,200),
					new SqlParameter("@OrderID", SqlDbType.Int,4),
					new SqlParameter("@RootID", SqlDbType.Int,4),
					new SqlParameter("@TypeID", SqlDbType.Int,4)};
            parameters[0].Value = model.FID;
            parameters[1].Value = model.Html;
            parameters[2].Value = model.Aspx;
            parameters[3].Value = model.Depth;
            parameters[4].Value = model.PageName;
            parameters[5].Value = model.OrderID;
            parameters[6].Value = model.RootID;
            parameters[7].Value = model.TypeID;

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
        public int Update(Pbzx.Model.PBnet_UrlMaping model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PBnet_UrlMaping set ");
            strSql.Append("Aspx=@Aspx,");
            strSql.Append("Depth=@Depth,");
            strSql.Append("Html=@Html,");
            strSql.Append("PageName=@PageName,");
            strSql.Append("OrderID=@OrderID,");
            strSql.Append("RootID=@RootID,");
            strSql.Append("TypeID=@TypeID");
            strSql.Append(" where MapID=@MapID ");
            SqlParameter[] parameters = {
					new SqlParameter("@MapID", SqlDbType.Int,4),
					new SqlParameter("@FID", SqlDbType.Int,4),
					new SqlParameter("@Html", SqlDbType.VarChar,200),
					new SqlParameter("@Aspx", SqlDbType.VarChar,200),
					new SqlParameter("@Depth", SqlDbType.Int,4),
					new SqlParameter("@PageName", SqlDbType.VarChar,200),
					new SqlParameter("@OrderID", SqlDbType.Int,4),
					new SqlParameter("@RootID", SqlDbType.Int,4),
					new SqlParameter("@TypeID", SqlDbType.Int,4)};
            parameters[0].Value = model.MapID;
            parameters[1].Value = model.FID;
            parameters[2].Value = model.Html;
            parameters[3].Value = model.Aspx;
            parameters[4].Value = model.Depth;
            parameters[5].Value = model.PageName;
            parameters[6].Value = model.OrderID;
            parameters[7].Value = model.RootID;
            parameters[8].Value = model.TypeID;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int MapID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PBnet_UrlMaping ");
            strSql.Append(" where MapID=@MapID ");
            SqlParameter[] parameters = {
					new SqlParameter("@MapID", SqlDbType.Int,4)};
            parameters[0].Value = MapID;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.PBnet_UrlMaping GetModel(int MapID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 MapID,FID,Html,Aspx,Depth,PageName,OrderID,RootID,TypeID from PBnet_UrlMaping ");
            strSql.Append(" where MapID=@MapID ");
            SqlParameter[] parameters = {
					new SqlParameter("@MapID", SqlDbType.Int,4)};
            parameters[0].Value = MapID;

            Pbzx.Model.PBnet_UrlMaping model = new Pbzx.Model.PBnet_UrlMaping();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["MapID"].ToString() != "")
                {
                    model.MapID = int.Parse(ds.Tables[0].Rows[0]["MapID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["FID"].ToString() != "")
                {
                    model.FID = int.Parse(ds.Tables[0].Rows[0]["FID"].ToString());
                }
                model.Html = ds.Tables[0].Rows[0]["Html"].ToString();
                model.Aspx = ds.Tables[0].Rows[0]["Aspx"].ToString();
                if (ds.Tables[0].Rows[0]["Depth"].ToString() != "")
                {
                    model.Depth = int.Parse(ds.Tables[0].Rows[0]["Depth"].ToString());
                }
                model.PageName = ds.Tables[0].Rows[0]["PageName"].ToString();
                if (ds.Tables[0].Rows[0]["OrderID"].ToString() != "")
                {
                    model.OrderID = int.Parse(ds.Tables[0].Rows[0]["OrderID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RootID"].ToString() != "")
                {
                    model.RootID = int.Parse(ds.Tables[0].Rows[0]["RootID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TypeID"].ToString() != "")
                {
                    model.TypeID = int.Parse(ds.Tables[0].Rows[0]["TypeID"].ToString());
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
            strSql.Append("select MapID,FID,Html,Aspx,Depth,PageName,OrderID,RootID,TypeID ");
            strSql.Append(" FROM PBnet_UrlMaping ");
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
            strSql.Append(" MapID,FID,Html,Aspx,Depth,PageName,OrderID,RootID,TypeID ");
            strSql.Append(" FROM PBnet_UrlMaping ");
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
            parameters[0].Value = "PBnet_UrlMaping";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  成员方法

        public int ExecuteBySql(string sql)
        {
            return DbHelperSQL.ExecuteSql(sql);
        }
    }
}

