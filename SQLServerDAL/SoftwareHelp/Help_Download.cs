using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;

namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类:Help_Download
    /// </summary>
    public partial class Help_Download : IHelp_Download
    {
        public Help_Download()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int d_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Help_Download");
            strSql.Append(" where d_id=@d_id");
            SqlParameter[] parameters = {
					new SqlParameter("@d_id", SqlDbType.Int,4)
};
            parameters[0].Value = d_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists1(int d_type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Help_Download");
            strSql.Append(" where d_type=@d_type");
            SqlParameter[] parameters = {
					new SqlParameter("@d_type", SqlDbType.Int,4)
};
            parameters[0].Value = d_type;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.Help_Download model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Help_Download(");
            strSql.Append("d_type,d_download)");
            strSql.Append(" values (");
            strSql.Append("@d_type,@d_download)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@d_type", SqlDbType.Int,4),
					new SqlParameter("@d_download", SqlDbType.NVarChar,100)};
            parameters[0].Value = model.d_type;
            parameters[1].Value = model.d_download;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Pbzx.Model.Help_Download model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Help_Download set ");
            strSql.Append("d_type=@d_type,");
            strSql.Append("d_download=@d_download");
            strSql.Append(" where d_id=@d_id");
            SqlParameter[] parameters = {
					new SqlParameter("@d_type", SqlDbType.Int,4),
					new SqlParameter("@d_download", SqlDbType.NVarChar,100),
					new SqlParameter("@d_id", SqlDbType.Int,4)};
            parameters[0].Value = model.d_type;
            parameters[1].Value = model.d_download;
            parameters[2].Value = model.d_id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int d_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Help_Download ");
            strSql.Append(" where d_id=@d_id");
            SqlParameter[] parameters = {
					new SqlParameter("@d_id", SqlDbType.Int,4)
};
            parameters[0].Value = d_id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string d_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Help_Download ");
            strSql.Append(" where d_id in (" + d_idlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.Help_Download GetModel(int d_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 d_id,d_type,d_download from Help_Download ");
            strSql.Append(" where d_id=@d_id");
            SqlParameter[] parameters = {
					new SqlParameter("@d_id", SqlDbType.Int,4)
};
            parameters[0].Value = d_id;

            Pbzx.Model.Help_Download model = new Pbzx.Model.Help_Download();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["d_id"].ToString() != "")
                {
                    model.d_id = int.Parse(ds.Tables[0].Rows[0]["d_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["d_type"].ToString() != "")
                {
                    model.d_type = int.Parse(ds.Tables[0].Rows[0]["d_type"].ToString());
                }
                if (ds.Tables[0].Rows[0]["d_download"] != null)
                {
                    model.d_download = ds.Tables[0].Rows[0]["d_download"].ToString();
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
            strSql.Append("select d_id,d_type,d_download ");
            strSql.Append(" FROM Help_Download ");
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
            strSql.Append(" d_id,d_type,d_download ");
            strSql.Append(" FROM Help_Download ");
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
            parameters[0].Value = "Help_Download";
            parameters[1].Value = "d_id";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  Method
    }
}
