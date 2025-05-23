using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类FCSSLData_SH。
    /// </summary>
    public class FCSSLData_SH : IFCSSLData_SH
    {
        public FCSSLData_SH()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL1.GetMaxID("Issue", "FCSSLData_SH");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Issue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from FCSSLData_SH");
            strSql.Append(" where Issue=@Issue ");
            SqlParameter[] parameters = {
					new SqlParameter("@Issue", SqlDbType.Int,4)};
            parameters[0].Value = Issue;

            return DbHelperSQL1.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.FCSSLData_SH model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into FCSSLData_SH(");
            strSql.Append("Issue,date,Code,LastModifytime,OpName,OpIp)");
            strSql.Append(" values (");
            strSql.Append("@Issue,@date,@Code,@LastModifytime,@OpName,@OpIp)");
            SqlParameter[] parameters = {
					new SqlParameter("@Issue", SqlDbType.Int,4),
					new SqlParameter("@date", SqlDbType.DateTime),
					new SqlParameter("@Code", SqlDbType.Char,3),
					new SqlParameter("@LastModifytime", SqlDbType.DateTime),
					new SqlParameter("@OpName", SqlDbType.NVarChar,16),
					new SqlParameter("@OpIp", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.Issue;
            parameters[1].Value = model.date;
            parameters[2].Value = model.Code;
            parameters[3].Value = model.LastModifytime;
            parameters[4].Value = model.OpName;
            parameters[5].Value = model.OpIp;

            return DbHelperSQL1.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int  Update(Pbzx.Model.FCSSLData_SH model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update FCSSLData_SH set ");
            strSql.Append("date=@date,");
            strSql.Append("Code=@Code,");
            strSql.Append("LastModifytime=@LastModifytime,");
            strSql.Append("OpIp=@OpIp");
            strSql.Append(" where Issue=@Issue ");
            SqlParameter[] parameters = {
					new SqlParameter("@Issue", SqlDbType.Int,4),
					new SqlParameter("@date", SqlDbType.DateTime),
					new SqlParameter("@Code", SqlDbType.Char,3),
					new SqlParameter("@LastModifytime", SqlDbType.DateTime),
					new SqlParameter("@OpName", SqlDbType.NVarChar,16),
					new SqlParameter("@OpIp", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.Issue;
            parameters[1].Value = model.date;
            parameters[2].Value = model.Code;
            parameters[3].Value = model.LastModifytime;
            parameters[4].Value = model.OpName;
            parameters[5].Value = model.OpIp;

            return DbHelperSQL1.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int Issue)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from FCSSLData_SH ");
            strSql.Append(" where Issue=@Issue ");
            SqlParameter[] parameters = {
					new SqlParameter("@Issue", SqlDbType.Int,4)};
            parameters[0].Value = Issue;

            return DbHelperSQL1.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.FCSSLData_SH GetModel(int Issue)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Issue,date,Code,LastModifytime,OpName,OpIp from FCSSLData_SH ");
            strSql.Append(" where Issue=@Issue ");
            SqlParameter[] parameters = {
					new SqlParameter("@Issue", SqlDbType.Int,4)};
            parameters[0].Value = Issue;

            Pbzx.Model.FCSSLData_SH model = new Pbzx.Model.FCSSLData_SH();
            DataSet ds = DbHelperSQL1.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Issue"].ToString() != "")
                {
                    model.Issue = int.Parse(ds.Tables[0].Rows[0]["Issue"].ToString());
                }
                if (ds.Tables[0].Rows[0]["date"].ToString() != "")
                {
                    model.date = DateTime.Parse(ds.Tables[0].Rows[0]["date"].ToString());
                }
                model.Code = ds.Tables[0].Rows[0]["Code"].ToString();
                if (ds.Tables[0].Rows[0]["LastModifytime"].ToString() != "")
                {
                    model.LastModifytime = DateTime.Parse(ds.Tables[0].Rows[0]["LastModifytime"].ToString());
                }
                model.OpName = ds.Tables[0].Rows[0]["OpName"].ToString();
                model.OpIp = ds.Tables[0].Rows[0]["OpIp"].ToString();
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
            strSql.Append("select Issue,date,Code,LastModifytime,OpName,OpIp ");
            strSql.Append(" FROM FCSSLData_SH ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL1.Query(strSql.ToString());
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
            strSql.Append(" Issue,date,Code,LastModifytime,OpName,OpIp ");
            strSql.Append(" FROM FCSSLData_SH ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL1.Query(strSql.ToString());
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
            parameters[0].Value = "FCSSLData_SH";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL1.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  成员方法
    }
}

