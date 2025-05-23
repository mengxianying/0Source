using System;
using System.Collections.Generic;
using System.Text;
using Maticsoft.DBUtility;
using System.Data.SqlClient;
using System.Data;
using Pbzx.IDAL;


namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类:Drawer_user
    /// </summary>
    public partial class Drawer_user : IDrawer_user
    {
        public Drawer_user()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int D_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Drawer_user");
            strSql.Append(" where D_id=@D_id");
            SqlParameter[] parameters = {
					new SqlParameter("@D_id", SqlDbType.Int,4)};  
            parameters[0].Value = D_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 查询是够存在记录
        /// </summary>
        /// <param name="Name">用户名</param>
        /// <param name="passWord">密码</param>
        /// <returns></returns>
        public bool Exists(string Name, string passWord)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select cpunt(1) feom Drawer_user");
            strSql.Append(" where D_userName=@Name and D_passsWord=@passWord");
            SqlParameter[] parameters = { 
                       new SqlParameter("@Name",SqlDbType.NVarChar,50),
                       new SqlParameter("@passWord",SqlDbType.NVarChar,50)};
            parameters[0].Value = Name;
            parameters[1].Value = passWord;

            return DbHelperSQL.Exists(strSql.ToString(),parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.Drawer_user model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Drawer_user(");
            strSql.Append("D_userName,D_passsWord,D_code)");
            strSql.Append(" values (");
            strSql.Append("@D_userName,@D_passsWord,@D_code)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@D_userName", SqlDbType.NVarChar,50),
					new SqlParameter("@D_passsWord", SqlDbType.NVarChar,50),
					new SqlParameter("@D_code", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.D_userName;
            parameters[1].Value = model.D_passsWord;
            parameters[2].Value = model.D_code;

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
        public bool Update(Pbzx.Model.Drawer_user model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Drawer_user set ");
            strSql.Append("D_userName=@D_userName,");
            strSql.Append("D_passsWord=@D_passsWord,");
            strSql.Append("D_code=@D_code");
            strSql.Append(" where D_id=@D_id");
            SqlParameter[] parameters = {
					new SqlParameter("@D_userName", SqlDbType.NVarChar,50),
					new SqlParameter("@D_passsWord", SqlDbType.NVarChar,50),
					new SqlParameter("@D_code", SqlDbType.NVarChar,50),
					new SqlParameter("@D_id", SqlDbType.Int,4)};
            parameters[0].Value = model.D_userName;
            parameters[1].Value = model.D_passsWord;
            parameters[2].Value = model.D_code;
            parameters[3].Value = model.D_id;

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
        public bool Delete(int D_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Drawer_user ");
            strSql.Append(" where D_id=@D_id");
            SqlParameter[] parameters = {
					new SqlParameter("@D_id", SqlDbType.Int,4)
};
            parameters[0].Value = D_id;

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
        public bool DeleteList(string D_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Drawer_user ");
            strSql.Append(" where D_id in (" + D_idlist + ")  ");
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
        public Pbzx.Model.Drawer_user GetModel(int D_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 D_id,D_userName,D_passsWord,D_code from Drawer_user ");
            strSql.Append(" where D_id=@D_id");
            SqlParameter[] parameters = {
					new SqlParameter("@D_id", SqlDbType.Int,4)
};
            parameters[0].Value = D_id;

            Pbzx.Model.Drawer_user model = new Pbzx.Model.Drawer_user();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["D_id"].ToString() != "")
                {
                    model.D_id = int.Parse(ds.Tables[0].Rows[0]["D_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["D_userName"] != null)
                {
                    model.D_userName = ds.Tables[0].Rows[0]["D_userName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["D_passsWord"] != null)
                {
                    model.D_passsWord = ds.Tables[0].Rows[0]["D_passsWord"].ToString();
                }
                if (ds.Tables[0].Rows[0]["D_code"] != null)
                {
                    model.D_code = ds.Tables[0].Rows[0]["D_code"].ToString();
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
            strSql.Append("select D_id,D_userName,D_passsWord,D_code ");
            strSql.Append(" FROM Drawer_user ");
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
            strSql.Append(" D_id,D_userName,D_passsWord,D_code ");
            strSql.Append(" FROM Drawer_user ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }


        #endregion  Method
    }
}
