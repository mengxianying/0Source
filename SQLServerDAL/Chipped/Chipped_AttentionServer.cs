using System;
using System.Collections.Generic;
using System.Text;
using Pbzx.IDAL;
using System.Data;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using Pbzx.Model;

namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类Chipped_Attention。
    /// </summary>
    public class Chipped_Attention : IChipped_Attention
    {
        public Chipped_Attention()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("id", "Chipped_Attention");
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Chipped_Attention");
            strSql.Append(" where id= @id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
				};
            parameters[0].Value = id;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        public bool Exists(string AName,string AttentionName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Chipped_Attention");
            strSql.Append(" where AName= @AName and Attention=@AttentionName");
            SqlParameter[] parameters = {
					new SqlParameter("@AName", SqlDbType.NVarChar,50),
                    new SqlParameter("@AttentionName",SqlDbType.NVarChar,50)
				};
            parameters[0].Value = AName;
            parameters[1].Value = AttentionName;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.Chipped_Attention model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Chipped_Attention(");
            strSql.Append("AName,Attention,ATime)");
            strSql.Append(" values (");
            strSql.Append("@AName,@Attention,@ATime)");
            SqlParameter[] parameters = {
					new SqlParameter("@AName", SqlDbType.NVarChar),
					new SqlParameter("@Attention", SqlDbType.NVarChar),
					new SqlParameter("@ATime", SqlDbType.DateTime)};
            parameters[0].Value = model.AName;
            parameters[1].Value = model.Attention;
            parameters[2].Value = model.ATime;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
           
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(Pbzx.Model.Chipped_Attention model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Chipped_Attention set ");
            strSql.Append("AName=@AName,");
            strSql.Append("Attention=@Attention,");
            strSql.Append("ATime=@ATime");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@AName", SqlDbType.NVarChar),
					new SqlParameter("@Attention", SqlDbType.NVarChar),
					new SqlParameter("@ATime", SqlDbType.DateTime)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.AName;
            parameters[2].Value = model.Attention;
            parameters[3].Value = model.ATime;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(string name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete Chipped_Attention ");
            strSql.Append(" where Attention=@name");
            SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.NVarChar,50)
				};
            parameters[0].Value = name;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.Chipped_Attention GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Chipped_Attention ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;
            Pbzx.Model.Chipped_Attention model = new Pbzx.Model.Chipped_Attention();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            model.id = id;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.AName = ds.Tables[0].Rows[0]["AName"].ToString();
                model.Attention = ds.Tables[0].Rows[0]["Attention"].ToString();
                if (ds.Tables[0].Rows[0]["ATime"].ToString() != "")
                {
                    model.ATime = DateTime.Parse(ds.Tables[0].Rows[0]["ATime"].ToString());
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
            strSql.Append("select * from Chipped_Attention ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by id ");
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion  成员方法
    }
}
