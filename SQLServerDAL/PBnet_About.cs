using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类PBnet_About。
    /// </summary>
    public class PBnet_About : IPBnet_About
    {
        public PBnet_About()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PBnet_About");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.PBnet_About model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PBnet_About(");
            strSql.Append("ID,UsTitle,UsContent,UsState,UsAddTime,UsOrder,UsIsBtommShow,UsUrl,HtmlUrl,AspxUrl)");
            strSql.Append(" values (");
            strSql.Append("@ID,@UsTitle,@UsContent,@UsState,@UsAddTime,@UsOrder,@UsIsBtommShow,@UsUrl,@HtmlUrl,@AspxUrl)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@UsTitle", SqlDbType.NVarChar,100),
					new SqlParameter("@UsContent", SqlDbType.NText),
					new SqlParameter("@UsState", SqlDbType.Bit,1),
					new SqlParameter("@UsAddTime", SqlDbType.DateTime),
					new SqlParameter("@UsOrder", SqlDbType.Int,4),
					new SqlParameter("@UsIsBtommShow", SqlDbType.Bit,1),
					new SqlParameter("@UsUrl", SqlDbType.NVarChar,150),
					new SqlParameter("@HtmlUrl", SqlDbType.NVarChar,150),
					new SqlParameter("@AspxUrl", SqlDbType.NVarChar,150)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.UsTitle;
            parameters[2].Value = model.UsContent;
            parameters[3].Value = model.UsState;
            parameters[4].Value = model.UsAddTime;
            parameters[5].Value = model.UsOrder;
            parameters[6].Value = model.UsIsBtommShow;
            parameters[7].Value = model.UsUrl;
            parameters[8].Value = model.HtmlUrl;
            parameters[9].Value = model.AspxUrl;

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
        public int Update(Pbzx.Model.PBnet_About model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PBnet_About set ");
            strSql.Append("UsTitle=@UsTitle,");
            strSql.Append("UsContent=@UsContent,");
            strSql.Append("UsAddTime=@UsAddTime,");
            strSql.Append("UsOrder=@UsOrder,");
            strSql.Append("UsUrl=@UsUrl,");
            strSql.Append("HtmlUrl=@HtmlUrl,");
            strSql.Append("AspxUrl=@AspxUrl");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@UsTitle", SqlDbType.NVarChar,100),
					new SqlParameter("@UsContent", SqlDbType.NText),
					new SqlParameter("@UsState", SqlDbType.Bit,1),
					new SqlParameter("@UsAddTime", SqlDbType.DateTime),
					new SqlParameter("@UsOrder", SqlDbType.Int,4),
					new SqlParameter("@UsIsBtommShow", SqlDbType.Bit,1),
					new SqlParameter("@UsUrl", SqlDbType.NVarChar,150),
					new SqlParameter("@HtmlUrl", SqlDbType.NVarChar,150),
					new SqlParameter("@AspxUrl", SqlDbType.NVarChar,150)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.UsTitle;
            parameters[2].Value = model.UsContent;
            parameters[3].Value = model.UsState;
            parameters[4].Value = model.UsAddTime;
            parameters[5].Value = model.UsOrder;
            parameters[6].Value = model.UsIsBtommShow;
            parameters[7].Value = model.UsUrl;
            parameters[8].Value = model.HtmlUrl;
            parameters[9].Value = model.AspxUrl;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PBnet_About ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.PBnet_About GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,UsTitle,UsContent,UsState,UsAddTime,UsOrder,UsIsBtommShow,UsUrl,HtmlUrl,AspxUrl from PBnet_About ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            Pbzx.Model.PBnet_About model = new Pbzx.Model.PBnet_About();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.UsTitle = ds.Tables[0].Rows[0]["UsTitle"].ToString();
                model.UsContent = ds.Tables[0].Rows[0]["UsContent"].ToString();
                if (ds.Tables[0].Rows[0]["UsState"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["UsState"].ToString() == "1") || (ds.Tables[0].Rows[0]["UsState"].ToString().ToLower() == "true"))
                    {
                        model.UsState = true;
                    }
                    else
                    {
                        model.UsState = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["UsAddTime"].ToString() != "")
                {
                    model.UsAddTime = DateTime.Parse(ds.Tables[0].Rows[0]["UsAddTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UsOrder"].ToString() != "")
                {
                    model.UsOrder = int.Parse(ds.Tables[0].Rows[0]["UsOrder"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UsIsBtommShow"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["UsIsBtommShow"].ToString() == "1") || (ds.Tables[0].Rows[0]["UsIsBtommShow"].ToString().ToLower() == "true"))
                    {
                        model.UsIsBtommShow = true;
                    }
                    else
                    {
                        model.UsIsBtommShow = false;
                    }
                }
                model.UsUrl = ds.Tables[0].Rows[0]["UsUrl"].ToString();
                model.HtmlUrl = ds.Tables[0].Rows[0]["HtmlUrl"].ToString();
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
            strSql.Append("select ID,UsTitle,UsContent,UsState,UsAddTime,UsOrder,UsIsBtommShow,UsUrl,HtmlUrl,AspxUrl ");
            strSql.Append(" FROM PBnet_About ");
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
            strSql.Append(" ID,UsTitle,UsContent,UsState,UsAddTime,UsOrder,UsIsBtommShow,UsUrl,HtmlUrl,AspxUrl ");
            strSql.Append(" FROM PBnet_About ");
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
            parameters[0].Value = "PBnet_About";
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

