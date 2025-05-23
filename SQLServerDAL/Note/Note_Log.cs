using System;
using System.Collections.Generic;
using System.Text;
using Pbzx.IDAL;
using System.Data;
using System.Data.SqlClient;
using Maticsoft.DBUtility;

namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类Note_Log。
    /// </summary>
    public class Note_Log : INote_Log
    {
        public Note_Log()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Note_Log");
            strSql.Append(" where ID= @ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
				};
            parameters[0].Value = ID;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(Pbzx.Model.Note_Log model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Note_Log(");
            strSql.Append("Phone,Countent,BeginTime)");
            strSql.Append(" values (");
            strSql.Append("@Phone,@Countent,@BeginTime)");
            SqlParameter[] parameters = {
					new SqlParameter("@Phone", SqlDbType.VarChar,50),
					new SqlParameter("@Countent", SqlDbType.NVarChar),
					new SqlParameter("@BeginTime", SqlDbType.DateTime)};
            parameters[0].Value = model.Phone;
            parameters[1].Value = model.Countent;
            parameters[2].Value = model.BeginTime;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(Pbzx.Model.Note_Log model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Note_Log set ");
            strSql.Append("Phone=@Phone,");
            strSql.Append("Countent=@Countent,");
            strSql.Append("BeginTime=@BeginTime");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@Phone", SqlDbType.VarChar,50),
					new SqlParameter("@Countent", SqlDbType.NVarChar),
					new SqlParameter("@BeginTime", SqlDbType.DateTime)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Phone;
            parameters[2].Value = model.Countent;
            parameters[3].Value = model.BeginTime;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete Note_Log ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
				};
            parameters[0].Value = ID;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.Note_Log GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Note_Log ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;
            Pbzx.Model.Note_Log model = new Pbzx.Model.Note_Log();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            model.ID = ID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.Phone = ds.Tables[0].Rows[0]["Phone"].ToString();
                model.Countent = ds.Tables[0].Rows[0]["Countent"].ToString();
                if (ds.Tables[0].Rows[0]["BeginTime"].ToString() != "")
                {
                    model.BeginTime = DateTime.Parse(ds.Tables[0].Rows[0]["BeginTime"].ToString());
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
            strSql.Append("select * from Note_Log ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by ID ");
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion  成员方法
      
        
    }
}
