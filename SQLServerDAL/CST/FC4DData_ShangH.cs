using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类FC4DData_ShangH。
    /// </summary>
    public class FC4DData_ShangH : IFC4DData_ShangH
    {
        public FC4DData_ShangH()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string issue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from FC4DData_ShangH");
            strSql.Append(" where issue=@issue ");
            SqlParameter[] parameters = {
					new SqlParameter("@issue", SqlDbType.Char,10)};
            parameters[0].Value = issue;

            return DbHelperSQL1.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int  Add(Pbzx.Model.FC4DData_ShangH model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into FC4DData_ShangH(");
            strSql.Append(" date,issue,code,LastModifyTime,OpName,OpIp)");
            strSql.Append(" values (");
            strSql.Append("@date,@issue,@code,@LastModifyTime,@OpName,@OpIp)");
            SqlParameter[] parameters = {					
					new SqlParameter("@date", SqlDbType.SmallDateTime),
					new SqlParameter("@issue", SqlDbType.Char,7),
					new SqlParameter("@code", SqlDbType.NVarChar,4),
					new SqlParameter("@LastModifyTime", SqlDbType.DateTime),
					new SqlParameter("@OpName", SqlDbType.NVarChar,50),
					new SqlParameter("@OpIp", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.date;
            parameters[1].Value = model.issue;
            parameters[2].Value = model.code;
            parameters[3].Value = model.LastModifyTime;
            parameters[4].Value = model.OpName;
            parameters[5].Value = model.OpIp;

           return DbHelperSQL1.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Pbzx.Model.FC4DData_ShangH model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update FC4DData_ShangH set ");           
            strSql.Append("date=@date,");
            strSql.Append("issue=@issue,");
            strSql.Append("code=@code,");
            strSql.Append("LastModifyTime=@LastModifyTime,");
            strSql.Append("OpName=@OpName,");
            strSql.Append("OpIp=@OpIp ");
            strSql.Append(" where issue=@issue ");
            SqlParameter[] parameters = {					
					new SqlParameter("@date", SqlDbType.SmallDateTime),
					new SqlParameter("@issue", SqlDbType.Char,7),
					new SqlParameter("@code", SqlDbType.NVarChar,4),
					new SqlParameter("@LastModifyTime", SqlDbType.DateTime),
					new SqlParameter("@OpName", SqlDbType.NVarChar,50),
					new SqlParameter("@OpIp", SqlDbType.NVarChar,50)};           
            parameters[0].Value = model.date;
            parameters[1].Value = model.issue;
            parameters[2].Value = model.code;
            parameters[3].Value = model.LastModifyTime;
            parameters[4].Value = model.OpName;
            parameters[5].Value = model.OpIp;

           return  DbHelperSQL1.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(string issue)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from FC4DData_ShangH ");
            strSql.Append(" where issue=@issue ");
            SqlParameter[] parameters = {
					new SqlParameter("@issue", SqlDbType.Char,10)};
            parameters[0].Value = issue;

           return DbHelperSQL1.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.FC4DData_ShangH GetModel(string issue)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 date,issue,code,LastModifyTime,OpName,OpIp from FC4DData_ShangH ");
            strSql.Append(" where issue=@issue ");
            SqlParameter[] parameters = {
					new SqlParameter("@issue", SqlDbType.Char,10)};
            parameters[0].Value = issue;

            Pbzx.Model.FC4DData_ShangH model = new Pbzx.Model.FC4DData_ShangH();
            DataSet ds = DbHelperSQL1.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["date"].ToString() != "")
                {
                    model.date = DateTime.Parse(ds.Tables[0].Rows[0]["date"].ToString());
                }
                model.issue = ds.Tables[0].Rows[0]["issue"].ToString();
                model.code = ds.Tables[0].Rows[0]["code"].ToString();
                if (ds.Tables[0].Rows[0]["LastModifyTime"].ToString() != "")
                {
                    model.LastModifyTime = DateTime.Parse(ds.Tables[0].Rows[0]["LastModifyTime"].ToString());
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
            strSql.Append("select date,issue,code,LastModifyTime,OpName,OpIp ");
            strSql.Append(" FROM FC4DData_ShangH ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
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
            parameters[0].Value = "FC4DData_ShangH";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL1.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        /// <summary>
        /// 获得前几行数据
        /// </summary>

        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select");
            if (Top > 0)
            {
                strSql.Append("top" + Top.ToString());
            }
            strSql.Append(" date,issue,code,LastModifyTime,OpName,OpIp");
            strSql.Append("FROM FC4DData_ShangH");
            if (strWhere.Trim() != "")
            {
                strSql.Append("where" + strWhere.ToString());
            }
            strSql.Append("order by " + filedOrder);
            return DbHelperSQL1.Query(strSql.ToString());
        }
        #endregion  成员方法
    }
}

