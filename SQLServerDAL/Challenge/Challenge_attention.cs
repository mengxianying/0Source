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
    /// 数据访问类Challenge_attention。
    /// </summary>
    public class Challenge_attention : IChallenge_attention
    {
        public Challenge_attention()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("Att_id", "Challenge_attention");
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Att_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Challenge_attention");
            strSql.Append(" where Att_id= @Att_id");
            SqlParameter[] parameters = {
					new SqlParameter("@Att_id", SqlDbType.Int,4)
				};
            parameters[0].Value = Att_id;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        public bool Exists(string name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Challenge_attention");
            strSql.Append(" where Att_name= @name");
            SqlParameter[] parameters = {
					new SqlParameter("@Att_name", SqlDbType.NVarChar,50)
				};
            parameters[0].Value = name;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.Challenge_attention model)
        {
            model.Att_id = GetMaxId();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Challenge_attention(");
            strSql.Append("Att_id,Att_name,Att_attention,Att_Time)");
            strSql.Append(" values (");
            strSql.Append("@Att_id,@Att_name,@Att_attention,@Att_Time)");
            SqlParameter[] parameters = {
					new SqlParameter("@Att_id", SqlDbType.Int,4),
					new SqlParameter("@Att_name", SqlDbType.NVarChar),
					new SqlParameter("@Att_attention", SqlDbType.NVarChar),
					new SqlParameter("@Att_Time", SqlDbType.DateTime)};
            parameters[0].Value = model.Att_id;
            parameters[1].Value = model.Att_name;
            parameters[2].Value = model.Att_attention;
            parameters[3].Value = model.Att_Time;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            return model.Att_id;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Pbzx.Model.Challenge_attention model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Challenge_attention set ");
            strSql.Append("Att_name=@Att_name,");
            strSql.Append("Att_attention=@Att_attention,");
            strSql.Append("Att_Time=@Att_Time");
            strSql.Append(" where Att_id=@Att_id");
            SqlParameter[] parameters = {
					new SqlParameter("@Att_id", SqlDbType.Int,4),
					new SqlParameter("@Att_name", SqlDbType.NVarChar),
					new SqlParameter("@Att_attention", SqlDbType.NVarChar),
					new SqlParameter("@Att_Time", SqlDbType.DateTime)};
            parameters[0].Value = model.Att_id;
            parameters[1].Value = model.Att_name;
            parameters[2].Value = model.Att_attention;
            parameters[3].Value = model.Att_Time;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int Att_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete Challenge_attention ");
            strSql.Append(" where Att_id=@Att_id");
            SqlParameter[] parameters = {
					new SqlParameter("@Att_id", SqlDbType.Int,4)
				};
            parameters[0].Value = Att_id;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.Challenge_attention GetModel(int Att_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Challenge_attention ");
            strSql.Append(" where Att_id=@Att_id");
            SqlParameter[] parameters = {
					new SqlParameter("@Att_id", SqlDbType.Int,4)};
            parameters[0].Value = Att_id;
            Pbzx.Model.Challenge_attention model = new Pbzx.Model.Challenge_attention();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            model.Att_id = Att_id;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.Att_name = ds.Tables[0].Rows[0]["Att_name"].ToString();
                model.Att_attention = ds.Tables[0].Rows[0]["Att_attention"].ToString();
                if (ds.Tables[0].Rows[0]["Att_Time"].ToString() != "")
                {
                    model.Att_Time = DateTime.Parse(ds.Tables[0].Rows[0]["Att_Time"].ToString());
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
            strSql.Append("select * from Challenge_attention ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by Att_id ");
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion  成员方法
    }
}
