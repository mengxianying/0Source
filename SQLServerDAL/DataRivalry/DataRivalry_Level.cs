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
    /// 数据访问类DataRivalry_Level。
    /// </summary>
    public class DataRivalry_Level : IDataRivalry_Level
    {
        public DataRivalry_Level()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Le_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from DataRivalry_Level");
            strSql.Append(" where Le_id= @Le_id");
            SqlParameter[] parameters = {
					new SqlParameter("@Le_id", SqlDbType.Int,4)
				};
            parameters[0].Value = Le_id;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.DataRivalry_Level model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into DataRivalry_Level(");
            strSql.Append("Le_level,Le_BRange,Le_ERange,Le_type,Le_rewards)");
            strSql.Append(" values (");
            strSql.Append("@Le_level,@Le_BRange,@Le_ERange,@Le_type,@Le_rewards)");
            SqlParameter[] parameters = {
					new SqlParameter("@Le_level", SqlDbType.Int,4),
					new SqlParameter("@Le_BRange", SqlDbType.Int,4),
					new SqlParameter("@Le_ERange", SqlDbType.Int,4),
					new SqlParameter("@Le_type", SqlDbType.Int,4),
					new SqlParameter("@Le_rewards", SqlDbType.Int,4)};
            parameters[0].Value = model.Le_level;
            parameters[1].Value = model.Le_BRange;
            parameters[2].Value = model.Le_ERange;
            parameters[3].Value = model.Le_type;
            parameters[4].Value = model.Le_rewards;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Pbzx.Model.DataRivalry_Level model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update DataRivalry_Level set ");
            strSql.Append("Le_level=@Le_level,");
            strSql.Append("Le_BRange=@Le_BRange,");
            strSql.Append("Le_ERange=@Le_ERange,");
            strSql.Append("Le_type=@Le_type,");
            strSql.Append("Le_rewards=@Le_rewards");
            strSql.Append(" where Le_id=@Le_id");
            SqlParameter[] parameters = {
					new SqlParameter("@Le_id", SqlDbType.Int,4),
					new SqlParameter("@Le_level", SqlDbType.Int,4),
					new SqlParameter("@Le_BRange", SqlDbType.Int,4),
					new SqlParameter("@Le_ERange", SqlDbType.Int,4),
					new SqlParameter("@Le_type", SqlDbType.Int,4),
					new SqlParameter("@Le_rewards", SqlDbType.Int,4)};
            parameters[0].Value = model.Le_id;
            parameters[1].Value = model.Le_level;
            parameters[2].Value = model.Le_BRange;
            parameters[3].Value = model.Le_ERange;
            parameters[4].Value = model.Le_type;
            parameters[5].Value = model.Le_rewards;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int Le_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete DataRivalry_Level ");
            strSql.Append(" where Le_id=@Le_id");
            SqlParameter[] parameters = {
					new SqlParameter("@Le_id", SqlDbType.Int,4)
				};
            parameters[0].Value = Le_id;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.DataRivalry_Level GetModel(int Le_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from DataRivalry_Level ");
            strSql.Append(" where Le_id=@Le_id");
            SqlParameter[] parameters = {
					new SqlParameter("@Le_id", SqlDbType.Int,4)};
            parameters[0].Value = Le_id;
            Pbzx.Model.DataRivalry_Level model = new Pbzx.Model.DataRivalry_Level();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            model.Le_id = Le_id;
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Le_level"].ToString() != "")
                {
                    model.Le_level = int.Parse(ds.Tables[0].Rows[0]["Le_level"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Le_BRange"].ToString() != "")
                {
                    model.Le_BRange = int.Parse(ds.Tables[0].Rows[0]["Le_BRange"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Le_ERange"].ToString() != "")
                {
                    model.Le_ERange = int.Parse(ds.Tables[0].Rows[0]["Le_ERange"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Le_type"].ToString() != "")
                {
                    model.Le_type = int.Parse(ds.Tables[0].Rows[0]["Le_type"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Le_rewards"].ToString() != "")
                {
                    model.Le_rewards = int.Parse(ds.Tables[0].Rows[0]["Le_rewards"].ToString());
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
            strSql.Append("select * from DataRivalry_Level ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by Le_id ");
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion  成员方法
    }
}
