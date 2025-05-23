using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;
namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类Help_Contrast。
    /// </summary>
    public class Help_Contrast : IHelp_Contrast
    {
        public Help_Contrast()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Ct_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Help_Contrast");
            strSql.Append(" where Ct_id= @Ct_id");
            SqlParameter[] parameters = {
					new SqlParameter("@Ct_id", SqlDbType.Int,4)
				};
            parameters[0].Value = Ct_id;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        public bool Exists(string Ct_TreeNum, string Ct_software)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Help_Contrast");
            strSql.Append(" where Ct_TreeNum= @Ct_TreeNum and Ct_software=@Ct_software");
            SqlParameter[] parameters = {
					new SqlParameter("@Ct_TreeNum", SqlDbType.NVarChar,50),
                    new SqlParameter("@Ct_software", SqlDbType.NVarChar,50)
                    
				};
            parameters[0].Value = Ct_TreeNum;
            parameters[1].Value = Ct_software;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.Help_Contrast model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Help_Contrast(");
            strSql.Append("Ct_TreeNum,Ct_software)");
            strSql.Append(" values (");
            strSql.Append("@Ct_TreeNum,@Ct_software)");
            SqlParameter[] parameters = {
					new SqlParameter("@Ct_TreeNum", SqlDbType.NVarChar),
					new SqlParameter("@Ct_software", SqlDbType.NVarChar)};
            parameters[0].Value = model.Ct_TreeNum;
            parameters[1].Value = model.Ct_software;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Pbzx.Model.Help_Contrast model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Help_Contrast set ");
            strSql.Append("Ct_TreeNum=@Ct_TreeNum,");
            strSql.Append("Ct_software=@Ct_software");
            strSql.Append(" where Ct_id=@Ct_id");
            SqlParameter[] parameters = {
					new SqlParameter("@Ct_id", SqlDbType.Int,4),
					new SqlParameter("@Ct_TreeNum", SqlDbType.NVarChar),
					new SqlParameter("@Ct_software", SqlDbType.NVarChar)};
            parameters[0].Value = model.Ct_id;
            parameters[1].Value = model.Ct_TreeNum;
            parameters[2].Value = model.Ct_software;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int Ct_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete Help_Contrast ");
            strSql.Append(" where Ct_id=@Ct_id");
            SqlParameter[] parameters = {
					new SqlParameter("@Ct_id", SqlDbType.Int,4)
				};
            parameters[0].Value = Ct_id;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        public int DeleteID(int Ct_TreeNum)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete Help_Contrast ");
            strSql.Append(" where Ct_TreeNum=@Ct_TreeNum");
            SqlParameter[] parameters = {
					new SqlParameter("@Ct_TreeNum", SqlDbType.Int,4)
				};
            parameters[0].Value = Ct_TreeNum;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.Help_Contrast GetModel(int Ct_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Help_Contrast ");
            strSql.Append(" where Ct_id=@Ct_id");
            SqlParameter[] parameters = {
					new SqlParameter("@Ct_id", SqlDbType.Int,4)};
            parameters[0].Value = Ct_id;
            Pbzx.Model.Help_Contrast model = new Pbzx.Model.Help_Contrast();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            model.Ct_id = Ct_id;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.Ct_TreeNum = ds.Tables[0].Rows[0]["Ct_TreeNum"].ToString();
                model.Ct_software = ds.Tables[0].Rows[0]["Ct_software"].ToString();
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
            strSql.Append("select * from Help_Contrast ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by Ct_id ");
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion  成员方法
    }
}

