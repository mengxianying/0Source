using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;

namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类Help_HelpName。
    /// </summary>
    public class Help_HelpName : IHelp_HelpName
    {
        public Help_HelpName()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Hn_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Help_HelpName");
            strSql.Append(" where Hn_ID= @Hn_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@Hn_ID", SqlDbType.Int,4)
				};
            parameters[0].Value = Hn_ID;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        public bool Exists(string name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Help_HelpName");
            strSql.Append(" where Hn_name= @name");
            SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.NVarChar,50)
				};
            parameters[0].Value = name;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.Help_HelpName model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Help_HelpName(");
            strSql.Append("Hn_name,Hn_Open,Hn_path)");
            strSql.Append(" values (");
            strSql.Append("@Hn_name,@Hn_Open,@Hn_path)");
            SqlParameter[] parameters = {
					new SqlParameter("@Hn_name", SqlDbType.NVarChar),
					new SqlParameter("@Hn_Open", SqlDbType.Int,4),
					new SqlParameter("@Hn_path", SqlDbType.NVarChar)};
            parameters[0].Value = model.Hn_name;
            parameters[1].Value = model.Hn_Open;
            parameters[2].Value = model.Hn_path;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Pbzx.Model.Help_HelpName model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Help_HelpName set ");
            strSql.Append("Hn_name=@Hn_name,");
            strSql.Append("Hn_Open=@Hn_Open,");
            strSql.Append("Hn_path=@Hn_path");
            strSql.Append(" where Hn_ID=@Hn_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@Hn_ID", SqlDbType.Int,4),
					new SqlParameter("@Hn_name", SqlDbType.NVarChar),
					new SqlParameter("@Hn_Open", SqlDbType.Int,4),
					new SqlParameter("@Hn_path", SqlDbType.NVarChar)};
            parameters[0].Value = model.Hn_ID;
            parameters[1].Value = model.Hn_name;
            parameters[2].Value = model.Hn_Open;
            parameters[3].Value = model.Hn_path;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int Hn_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete Help_HelpName ");
            strSql.Append(" where Hn_ID=@Hn_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@Hn_ID", SqlDbType.Int,4)
				};
            parameters[0].Value = Hn_ID;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.Help_HelpName GetModel(int Hn_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Help_HelpName ");
            strSql.Append(" where Hn_ID=@Hn_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@Hn_ID", SqlDbType.Int,4)};
            parameters[0].Value = Hn_ID;
            Pbzx.Model.Help_HelpName model = new Pbzx.Model.Help_HelpName();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            model.Hn_ID = Hn_ID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.Hn_name = ds.Tables[0].Rows[0]["Hn_name"].ToString();
                if (ds.Tables[0].Rows[0]["Hn_Open"].ToString() != "")
                {
                    model.Hn_Open = int.Parse(ds.Tables[0].Rows[0]["Hn_Open"].ToString());
                }
                model.Hn_path = ds.Tables[0].Rows[0]["Hn_path"].ToString();
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
            strSql.Append("select * from Help_HelpName ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by Hn_ID ");
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion  成员方法
    }
}

