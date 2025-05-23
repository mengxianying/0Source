using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类PBnet_LyResume。
    /// </summary>
    public class PBnet_LyResume : IPBnet_LyResume
    {
        public PBnet_LyResume()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int SystemNumber)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PBnet_LyResume");
            strSql.Append(" where SystemNumber=@SystemNumber ");
            SqlParameter[] parameters = {
					new SqlParameter("@SystemNumber", SqlDbType.Int,4)};
            parameters[0].Value = SystemNumber;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.PBnet_LyResume model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PBnet_LyResume(");
            strSql.Append("SystemNumber,LyListID,ResumeTime,ResumeContent,ResumeAuthor)");
            strSql.Append(" values (");
            strSql.Append("@SystemNumber,@LyListID,@ResumeTime,@ResumeContent,@ResumeAuthor)");
            SqlParameter[] parameters = {
					new SqlParameter("@SystemNumber", SqlDbType.Int,4),
					new SqlParameter("@LyListID", SqlDbType.Int,4),
					new SqlParameter("@ResumeTime", SqlDbType.DateTime),
					new SqlParameter("@ResumeContent", SqlDbType.Text),
					new SqlParameter("@ResumeAuthor", SqlDbType.VarChar,50)};
            parameters[0].Value = model.SystemNumber;
            parameters[1].Value = model.LyListID;
            parameters[2].Value = model.ResumeTime;
            parameters[3].Value = model.ResumeContent;
            parameters[4].Value = model.ResumeAuthor;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Pbzx.Model.PBnet_LyResume model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PBnet_LyResume set ");
            strSql.Append("LyListID=@LyListID,");
            strSql.Append("ResumeTime=@ResumeTime,");
            strSql.Append("ResumeContent=@ResumeContent,");
            strSql.Append("ResumeAuthor=@ResumeAuthor");
            strSql.Append(" where SystemNumber=@SystemNumber ");
            SqlParameter[] parameters = {
					new SqlParameter("@SystemNumber", SqlDbType.Int,4),
					new SqlParameter("@LyListID", SqlDbType.Int,4),
					new SqlParameter("@ResumeTime", SqlDbType.DateTime),
					new SqlParameter("@ResumeContent", SqlDbType.Text),
					new SqlParameter("@ResumeAuthor", SqlDbType.VarChar,50)};
            parameters[0].Value = model.SystemNumber;
            parameters[1].Value = model.LyListID;
            parameters[2].Value = model.ResumeTime;
            parameters[3].Value = model.ResumeContent;
            parameters[4].Value = model.ResumeAuthor;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int SystemNumber)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PBnet_LyResume ");
            strSql.Append(" where SystemNumber=@SystemNumber ");
            SqlParameter[] parameters = {
					new SqlParameter("@SystemNumber", SqlDbType.Int,4)};
            parameters[0].Value = SystemNumber;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.PBnet_LyResume GetModel(int SystemNumber)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 SystemNumber,LyListID,ResumeTime,ResumeContent,ResumeAuthor from PBnet_LyResume ");
            strSql.Append(" where SystemNumber=@SystemNumber ");
            SqlParameter[] parameters = {
					new SqlParameter("@SystemNumber", SqlDbType.Int,4)};
            parameters[0].Value = SystemNumber;

            Pbzx.Model.PBnet_LyResume model = new Pbzx.Model.PBnet_LyResume();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["SystemNumber"].ToString() != "")
                {
                    model.SystemNumber = int.Parse(ds.Tables[0].Rows[0]["SystemNumber"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LyListID"].ToString() != "")
                {
                    model.LyListID = int.Parse(ds.Tables[0].Rows[0]["LyListID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ResumeTime"].ToString() != "")
                {
                    model.ResumeTime = DateTime.Parse(ds.Tables[0].Rows[0]["ResumeTime"].ToString());
                }
                model.ResumeContent = ds.Tables[0].Rows[0]["ResumeContent"].ToString();
                model.ResumeAuthor = ds.Tables[0].Rows[0]["ResumeAuthor"].ToString();
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
            strSql.Append("select SystemNumber,LyListID,ResumeTime,ResumeContent,ResumeAuthor ");
            strSql.Append(" FROM PBnet_LyResume ");
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
            strSql.Append(" SystemNumber,LyListID,ResumeTime,ResumeContent,ResumeAuthor ");
            strSql.Append(" FROM PBnet_LyResume ");
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
            parameters[0].Value = "PBnet_LyResume";
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

