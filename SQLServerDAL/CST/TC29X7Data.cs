using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类TC29X7Data。
    /// </summary>
    public class TC29X7Data : ITC29X7Data
    {
        public TC29X7Data()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL1.GetMaxID("issue", "TC29X7Data");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int issue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TC29X7Data");
            strSql.Append(" where issue=@issue ");
            SqlParameter[] parameters = {
					new SqlParameter("@issue", SqlDbType.Int,4)};
            parameters[0].Value = issue;

            return DbHelperSQL1.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.TC29X7Data model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TC29X7Data(");
            strSql.Append("date,issue,code,tcode,LastModifytime,OpName,OpIp)");
            strSql.Append(" values (");
            strSql.Append("@date,@issue,@code,@tcode,@LastModifytime,@OpName,@OpIp)");
            SqlParameter[] parameters = {
					new SqlParameter("@date", SqlDbType.SmallDateTime),
					new SqlParameter("@issue", SqlDbType.Int,4),
					new SqlParameter("@code", SqlDbType.Char,14),
					new SqlParameter("@tcode", SqlDbType.Char,2),
					new SqlParameter("@LastModifytime", SqlDbType.DateTime),
					new SqlParameter("@OpName", SqlDbType.NVarChar,32),
					new SqlParameter("@OpIp", SqlDbType.NVarChar,32)};
            parameters[0].Value = model.date;
            parameters[1].Value = model.issue;
            parameters[2].Value = model.code;
            parameters[3].Value = model.tcode;
            parameters[4].Value = model.LastModifytime;
            parameters[5].Value = model.OpName;
            parameters[6].Value = model.OpIp;

            return DbHelperSQL1.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Pbzx.Model.TC29X7Data model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TC29X7Data set ");
            strSql.Append("date=@date,");
            strSql.Append("code=@code,");
            strSql.Append("tcode=@tcode,");
            strSql.Append("LastModifytime=@LastModifytime,");
            strSql.Append("OpName=@OpName,");
            strSql.Append("OpIp=@OpIp");
            strSql.Append(" where issue=@issue ");
            SqlParameter[] parameters = {
					new SqlParameter("@date", SqlDbType.SmallDateTime),
					new SqlParameter("@issue", SqlDbType.Int,4),
					new SqlParameter("@code", SqlDbType.Char,14),
					new SqlParameter("@tcode", SqlDbType.Char,2),
					new SqlParameter("@LastModifytime", SqlDbType.DateTime),
					new SqlParameter("@OpName", SqlDbType.NVarChar,32),
					new SqlParameter("@OpIp", SqlDbType.NVarChar,32)};
            parameters[0].Value = model.date;
            parameters[1].Value = model.issue;
            parameters[2].Value = model.code;
            parameters[3].Value = model.tcode;
            parameters[4].Value = model.LastModifytime;
            parameters[5].Value = model.OpName;
            parameters[6].Value = model.OpIp;

            return DbHelperSQL1.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int issue)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from TC29X7Data ");
            strSql.Append(" where issue=@issue ");
            SqlParameter[] parameters = {
					new SqlParameter("@issue", SqlDbType.Int,4)};
            parameters[0].Value = issue;

            return DbHelperSQL1.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.TC29X7Data GetModel(int issue)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 date,issue,code,tcode,LastModifytime,OpName,OpIp from TC29X7Data ");
            strSql.Append(" where issue=@issue ");
            SqlParameter[] parameters = {
					new SqlParameter("@issue", SqlDbType.Int,4)};
            parameters[0].Value = issue;

            Pbzx.Model.TC29X7Data model = new Pbzx.Model.TC29X7Data();
            DataSet ds = DbHelperSQL1.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["date"].ToString() != "")
                {
                    model.date = DateTime.Parse(ds.Tables[0].Rows[0]["date"].ToString());
                }
                if (ds.Tables[0].Rows[0]["issue"].ToString() != "")
                {
                    model.issue = int.Parse(ds.Tables[0].Rows[0]["issue"].ToString());
                }
                model.code = ds.Tables[0].Rows[0]["code"].ToString();
                model.tcode = ds.Tables[0].Rows[0]["tcode"].ToString();
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
            strSql.Append("select date,issue,code,tcode,LastModifytime,OpName,OpIp ");
            strSql.Append(" FROM TC29X7Data ");
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
            strSql.Append(" date,issue,code,tcode,LastModifytime,OpName,OpIp ");
            strSql.Append(" FROM TC29X7Data ");
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
            parameters[0].Value = "TC29X7Data";
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

