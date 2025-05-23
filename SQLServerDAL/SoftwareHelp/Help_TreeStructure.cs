using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;
namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类Help_TreeStructure。
    /// </summary>
    public class Help_TreeStructure : IHelp_TreeStructure
    {
        public Help_TreeStructure()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("Tree_id", "Help_TreeStructure");
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Tree_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Help_TreeStructure");
            strSql.Append(" where Tree_id= @Tree_id");
            SqlParameter[] parameters = {
					new SqlParameter("@Tree_id", SqlDbType.Int,4)
				};
            parameters[0].Value = Tree_id;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string name, string lottery,int TreeName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Help_TreeStructure");
            strSql.Append(" where Tree_RootNotd= @name and Tree_superiorNoet=@lottery and Tree_Name=@TreeName");
            SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.NVarChar,50),
                    new SqlParameter("@lottery",SqlDbType.NVarChar,50),
                    new SqlParameter("@TreeName",SqlDbType.Int,4)
				};
            parameters[0].Value = name;
            parameters[1].Value = lottery;
            parameters[2].Value = TreeName;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.Help_TreeStructure model)
        {
            model.Tree_id = GetMaxId();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Help_TreeStructure(");
            strSql.Append("Tree_name,Tree_superiorNoet,Tree_num,Tree_RootNotd,Tree_countent,Tree_Path,Tree_sort)");
            strSql.Append(" values (");
            strSql.Append("@Tree_name,@Tree_superiorNoet,@Tree_num,@Tree_RootNotd,@Tree_countent,@Tree_Path,@Tree_sort)");
            SqlParameter[] parameters = {
					new SqlParameter("@Tree_name", SqlDbType.NVarChar),
					new SqlParameter("@Tree_superiorNoet", SqlDbType.NVarChar),
					new SqlParameter("@Tree_num", SqlDbType.NVarChar),
					new SqlParameter("@Tree_RootNotd", SqlDbType.NVarChar),
					new SqlParameter("@Tree_countent", SqlDbType.Text),
					new SqlParameter("@Tree_Path", SqlDbType.NVarChar),
                    new SqlParameter("@Tree_sort", SqlDbType.Int,4)};
            parameters[0].Value = model.Tree_name;
            parameters[1].Value = model.Tree_superiorNoet;
            parameters[2].Value = model.Tree_num;
            parameters[3].Value = model.Tree_RootNotd;
            parameters[4].Value = model.Tree_countent;
            parameters[5].Value = model.Tree_Path;
            parameters[6].Value = model.Tree_sort;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            return model.Tree_id;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Pbzx.Model.Help_TreeStructure model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Help_TreeStructure set ");
            strSql.Append("Tree_name=@Tree_name,");
            strSql.Append("Tree_superiorNoet=@Tree_superiorNoet,");
            strSql.Append("Tree_num=@Tree_num,");
            strSql.Append("Tree_RootNotd=@Tree_RootNotd,");
            strSql.Append("Tree_countent=@Tree_countent,");
            strSql.Append("Tree_Path=@Tree_Path,");
            strSql.Append("Tree_sort=@Tree_sort");
            strSql.Append(" where Tree_id=@Tree_id");
            SqlParameter[] parameters = {
					new SqlParameter("@Tree_id", SqlDbType.Int,4),
					new SqlParameter("@Tree_name", SqlDbType.NVarChar,50),
					new SqlParameter("@Tree_superiorNoet", SqlDbType.NVarChar,50),
					new SqlParameter("@Tree_num", SqlDbType.NVarChar,150),
					new SqlParameter("@Tree_RootNotd", SqlDbType.NVarChar,50),
					new SqlParameter("@Tree_countent", SqlDbType.Text),
					new SqlParameter("@Tree_Path", SqlDbType.NVarChar,50),
					new SqlParameter("@Tree_sort", SqlDbType.Int,4)};
            parameters[0].Value = model.Tree_id;
            parameters[1].Value = model.Tree_name;
			parameters[2].Value = model.Tree_superiorNoet;
			parameters[3].Value = model.Tree_num;
			parameters[4].Value = model.Tree_RootNotd;
			parameters[5].Value = model.Tree_countent;
			parameters[6].Value = model.Tree_Path;
			parameters[7].Value = model.Tree_sort;


            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int Tree_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete Help_TreeStructure ");
            strSql.Append(" where Tree_id=@Tree_id");
            SqlParameter[] parameters = {
					new SqlParameter("@Tree_id", SqlDbType.Int,4)
				};
            parameters[0].Value = Tree_id;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        public int Delete(string Noet)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete Help_TreeStructure ");
            strSql.Append(" where Tree_superiorNoet=@Noet");
            SqlParameter[] parameters = {
					new SqlParameter("@Noet", SqlDbType.NVarChar,50)
				};
            parameters[0].Value = Noet;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.Help_TreeStructure GetModel(int Tree_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Help_TreeStructure ");
            strSql.Append(" where Tree_id=@Tree_id");
            SqlParameter[] parameters = {
					new SqlParameter("@Tree_id", SqlDbType.Int,4)};
            parameters[0].Value = Tree_id;
            Pbzx.Model.Help_TreeStructure model = new Pbzx.Model.Help_TreeStructure();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            model.Tree_id = Tree_id;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.Tree_name = ds.Tables[0].Rows[0]["Tree_name"].ToString();
                model.Tree_superiorNoet = ds.Tables[0].Rows[0]["Tree_superiorNoet"].ToString();
                model.Tree_num = ds.Tables[0].Rows[0]["Tree_num"].ToString();
                model.Tree_RootNotd = ds.Tables[0].Rows[0]["Tree_RootNotd"].ToString();
                model.Tree_countent = ds.Tables[0].Rows[0]["Tree_countent"].ToString();
                model.Tree_Path = ds.Tables[0].Rows[0]["Tree_Path"].ToString();
                if (ds.Tables[0].Rows[0]["Tree_sort"].ToString() != "")
                {
                    model.Tree_sort = int.Parse(ds.Tables[0].Rows[0]["Tree_sort"].ToString());
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
            strSql.Append("select * from Help_TreeStructure ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion  成员方法
    }
}

