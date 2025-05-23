using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类PBnet_PulbicContent。
    /// </summary>
    public class PBnet_PulbicContent : IPBnet_PulbicContent
    {
        public PBnet_PulbicContent()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int IntID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PBnet_PulbicContent");
            strSql.Append(" where IntID=@IntID ");
            SqlParameter[] parameters = {
					new SqlParameter("@IntID", SqlDbType.Int,4)};
            parameters[0].Value = IntID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.PBnet_PulbicContent model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PBnet_PulbicContent(");
            strSql.Append("NvarTitle,NteContent,BitState,NvarClass,HtmUrl,AspxUrl)");
            strSql.Append(" values (");
            strSql.Append("@NvarTitle,@NteContent,@BitState,@NvarClass,@HtmUrl,@AspxUrl)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@NvarTitle", SqlDbType.NVarChar,255),
					new SqlParameter("@NteContent", SqlDbType.NText),
					new SqlParameter("@BitState", SqlDbType.Bit,1),
					new SqlParameter("@NvarClass", SqlDbType.VarChar,100),
					new SqlParameter("@HtmUrl", SqlDbType.NVarChar,200),
					new SqlParameter("@AspxUrl", SqlDbType.NVarChar,200)};
            parameters[0].Value = model.NvarTitle;
            parameters[1].Value = model.NteContent;
            parameters[2].Value = model.BitState;
            parameters[3].Value = model.NvarClass;
            parameters[4].Value = model.HtmUrl;
            parameters[5].Value = model.AspxUrl;

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
        public int Update(Pbzx.Model.PBnet_PulbicContent model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PBnet_PulbicContent set ");
            strSql.Append("NvarTitle=@NvarTitle,");
            strSql.Append("NteContent=@NteContent,");
            strSql.Append("BitState=@BitState,");
            strSql.Append("NvarClass=@NvarClass,");
            strSql.Append("HtmUrl=@HtmUrl,");
            strSql.Append("AspxUrl=@AspxUrl");
            strSql.Append(" where IntID=@IntID ");
            SqlParameter[] parameters = {
					new SqlParameter("@IntID", SqlDbType.Int,4),
					new SqlParameter("@NvarTitle", SqlDbType.NVarChar,255),
					new SqlParameter("@NteContent", SqlDbType.NText),
					new SqlParameter("@BitState", SqlDbType.Bit,1),
					new SqlParameter("@NvarClass", SqlDbType.VarChar,100),
					new SqlParameter("@HtmUrl", SqlDbType.NVarChar,200),
					new SqlParameter("@AspxUrl", SqlDbType.NVarChar,200)};
            parameters[0].Value = model.IntID;
            parameters[1].Value = model.NvarTitle;
            parameters[2].Value = model.NteContent;
            parameters[3].Value = model.BitState;
            parameters[4].Value = model.NvarClass;
            parameters[5].Value = model.HtmUrl;
            parameters[6].Value = model.AspxUrl;

           return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int IntID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PBnet_PulbicContent ");
            strSql.Append(" where IntID=@IntID ");
            SqlParameter[] parameters = {
					new SqlParameter("@IntID", SqlDbType.Int,4)};
            parameters[0].Value = IntID;

          return  DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.PBnet_PulbicContent GetModel(int IntID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 IntID,NvarTitle,NteContent,BitState,NvarClass,HtmUrl,AspxUrl from PBnet_PulbicContent ");
            strSql.Append(" where IntID=@IntID ");
            SqlParameter[] parameters = {
					new SqlParameter("@IntID", SqlDbType.Int,4)};
            parameters[0].Value = IntID;

            Pbzx.Model.PBnet_PulbicContent model = new Pbzx.Model.PBnet_PulbicContent();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["IntID"].ToString() != "")
                {
                    model.IntID = int.Parse(ds.Tables[0].Rows[0]["IntID"].ToString());
                }
                model.NvarTitle = ds.Tables[0].Rows[0]["NvarTitle"].ToString();
                model.NteContent = ds.Tables[0].Rows[0]["NteContent"].ToString();
                if (ds.Tables[0].Rows[0]["BitState"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["BitState"].ToString() == "1") || (ds.Tables[0].Rows[0]["BitState"].ToString().ToLower() == "true"))
                    {
                        model.BitState = true;
                    }
                    else
                    {
                        model.BitState = false;
                    }
                }
                model.NvarClass = ds.Tables[0].Rows[0]["NvarClass"].ToString();
                model.HtmUrl = ds.Tables[0].Rows[0]["HtmUrl"].ToString();
                model.AspxUrl = ds.Tables[0].Rows[0]["AspxUrl"].ToString();
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
            strSql.Append("select IntID,NvarTitle,NteContent,BitState,NvarClass,HtmUrl,AspxUrl ");
            strSql.Append(" FROM PBnet_PulbicContent ");
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
            strSql.Append(" IntID,NvarTitle,NteContent,BitState,NvarClass,HtmUrl,AspxUrl ");
            strSql.Append(" FROM PBnet_PulbicContent ");
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
            parameters[0].Value = "PBnet_PulbicContent";
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

