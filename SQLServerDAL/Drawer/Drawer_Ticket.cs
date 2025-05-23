using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;//Please add references

namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类:Drawer_Ticket
    /// </summary>
    public partial class Drawer_Ticket : IDrawer_Ticket
    {
        public Drawer_Ticket()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Tic_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Drawer_Ticket");
            strSql.Append(" where Tic_id=@Tic_id");
            SqlParameter[] parameters = {
					new SqlParameter("@Tic_id", SqlDbType.Int,4)
};
            parameters[0].Value = Tic_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.Drawer_Ticket model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Drawer_Ticket(");
            strSql.Append("Tic_DName,Tic_mark,Tic_Condition,Tic_state)");
            strSql.Append(" values (");
            strSql.Append("@Tic_DName,@Tic_mark,@Tic_Condition,@Tic_state)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Tic_DName", SqlDbType.NVarChar,50),
					new SqlParameter("@Tic_mark", SqlDbType.NVarChar,50),
					new SqlParameter("@Tic_Condition", SqlDbType.NVarChar,50),
					new SqlParameter("@Tic_state", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.Tic_DName;
            parameters[1].Value = model.Tic_mark;
            parameters[2].Value = model.Tic_Condition;
            parameters[3].Value = model.Tic_state;

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
        public bool Update(Pbzx.Model.Drawer_Ticket model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Drawer_Ticket set ");
            strSql.Append("Tic_DName=@Tic_DName,");
            strSql.Append("Tic_mark=@Tic_mark,");
            strSql.Append("Tic_Condition=@Tic_Condition,");
            strSql.Append("Tic_state=@Tic_state");
            strSql.Append(" where Tic_id=@Tic_id");
            SqlParameter[] parameters = {
					new SqlParameter("@Tic_DName", SqlDbType.NVarChar,50),
					new SqlParameter("@Tic_mark", SqlDbType.NVarChar,50),
					new SqlParameter("@Tic_Condition", SqlDbType.NVarChar,50),
					new SqlParameter("@Tic_state", SqlDbType.NVarChar,50),
					new SqlParameter("@Tic_id", SqlDbType.Int,4)};
            parameters[0].Value = model.Tic_DName;
            parameters[1].Value = model.Tic_mark;
            parameters[2].Value = model.Tic_Condition;
            parameters[3].Value = model.Tic_state;
            parameters[4].Value = model.Tic_id;

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
        public bool Delete(int Tic_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Drawer_Ticket ");
            strSql.Append(" where Tic_id=@Tic_id");
            SqlParameter[] parameters = {
					new SqlParameter("@Tic_id", SqlDbType.Int,4)
};
            parameters[0].Value = Tic_id;

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
        public bool DeleteList(string Tic_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Drawer_Ticket ");
            strSql.Append(" where Tic_id in (" + Tic_idlist + ")  ");
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
        public Pbzx.Model.Drawer_Ticket GetModel(int Tic_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Tic_id,Tic_DName,Tic_mark,Tic_Condition,Tic_state from Drawer_Ticket ");
            strSql.Append(" where Tic_id=@Tic_id");
            SqlParameter[] parameters = {
					new SqlParameter("@Tic_id", SqlDbType.Int,4)
};
            parameters[0].Value = Tic_id;

            Pbzx.Model.Drawer_Ticket model = new Pbzx.Model.Drawer_Ticket();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Tic_id"].ToString() != "")
                {
                    model.Tic_id = int.Parse(ds.Tables[0].Rows[0]["Tic_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Tic_DName"] != null)
                {
                    model.Tic_DName = ds.Tables[0].Rows[0]["Tic_DName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Tic_mark"] != null)
                {
                    model.Tic_mark = ds.Tables[0].Rows[0]["Tic_mark"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Tic_Condition"] != null)
                {
                    model.Tic_Condition = ds.Tables[0].Rows[0]["Tic_Condition"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Tic_state"] != null)
                {
                    model.Tic_state = ds.Tables[0].Rows[0]["Tic_state"].ToString();
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
            strSql.Append("select Tic_id,Tic_DName,Tic_mark,Tic_Condition,Tic_state ");
            strSql.Append(" FROM Drawer_Ticket ");
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
            strSql.Append(" Tic_id,Tic_DName,Tic_mark,Tic_Condition,Tic_state ");
            strSql.Append(" FROM Drawer_Ticket ");
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
