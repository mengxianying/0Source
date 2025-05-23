using System;
using System.Collections.Generic;
using System.Text;
using Maticsoft.DBUtility;
using System.Data;
using Pbzx.IDAL;
using System.Data.SqlClient;

namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类PlatformPublic_payments。
    /// </summary>
    public class PlatformPublic_payments : IPlatformPublic_payments
    {
        public PlatformPublic_payments()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Pp_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PlatformPublic_payments");
            strSql.Append(" where Pp_id= @Pp_id");
            SqlParameter[] parameters = {
					new SqlParameter("@Pp_id", SqlDbType.Int,4)
				};
            parameters[0].Value = Pp_id;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.PlatformPublic_payments model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PlatformPublic_payments(");
            strSql.Append("Pp_name,Pp_num,Pp_Type,Pp_LotName,Pp_issue,Pp_Time,Pp_explain,Pp_data,Pp_belongs)");
            strSql.Append(" values (");
            strSql.Append("@Pp_name,@Pp_num,@Pp_Type,@Pp_LotName,@Pp_issue,@Pp_Time,@Pp_explain,@Pp_data,@Pp_belongs)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Pp_name", SqlDbType.NVarChar,50),
					new SqlParameter("@Pp_num", SqlDbType.NVarChar,100),
					new SqlParameter("@Pp_Type", SqlDbType.Int,4),
					new SqlParameter("@Pp_LotName", SqlDbType.Int,4),
					new SqlParameter("@Pp_issue", SqlDbType.Int,4),
					new SqlParameter("@Pp_Time", SqlDbType.DateTime),
					new SqlParameter("@Pp_explain", SqlDbType.NVarChar,100),
					new SqlParameter("@Pp_data", SqlDbType.Decimal,9),
					new SqlParameter("@Pp_belongs", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.Pp_name;
            parameters[1].Value = model.Pp_num;
            parameters[2].Value = model.Pp_Type;
            parameters[3].Value = model.Pp_LotName;
            parameters[4].Value = model.Pp_issue;
            parameters[5].Value = model.Pp_Time;
            parameters[6].Value = model.Pp_explain;
            parameters[7].Value = model.Pp_data;
            parameters[8].Value = model.Pp_belongs;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Pbzx.Model.PlatformPublic_payments model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PlatformPublic_payments set ");
            strSql.Append("Pp_name=@Pp_name,");
            strSql.Append("Pp_num=@Pp_num,");
            strSql.Append("Pp_Type=@Pp_Type,");
            strSql.Append("Pp_LotName=@Pp_LotName,");
            strSql.Append("Pp_issue=@Pp_issue,");
            strSql.Append("Pp_Time=@Pp_Time,");
            strSql.Append("Pp_explain=@Pp_explain,");
            strSql.Append("Pp_data=@Pp_data,");
            strSql.Append("Pp_belongs=@Pp_belongs");
            strSql.Append(" where Pp_id=@Pp_id");
            SqlParameter[] parameters = {
					new SqlParameter("@Pp_name", SqlDbType.NVarChar,50),
					new SqlParameter("@Pp_num", SqlDbType.NVarChar,100),
					new SqlParameter("@Pp_Type", SqlDbType.Int,4),
					new SqlParameter("@Pp_LotName", SqlDbType.Int,4),
					new SqlParameter("@Pp_issue", SqlDbType.Int,4),
					new SqlParameter("@Pp_Time", SqlDbType.DateTime),
					new SqlParameter("@Pp_explain", SqlDbType.NVarChar,100),
					new SqlParameter("@Pp_data", SqlDbType.Decimal,9),
					new SqlParameter("@Pp_belongs", SqlDbType.NVarChar,50),
					new SqlParameter("@Pp_id", SqlDbType.Int,4)};
            parameters[0].Value = model.Pp_name;
            parameters[1].Value = model.Pp_num;
            parameters[2].Value = model.Pp_Type;
            parameters[3].Value = model.Pp_LotName;
            parameters[4].Value = model.Pp_issue;
            parameters[5].Value = model.Pp_Time;
            parameters[6].Value = model.Pp_explain;
            parameters[7].Value = model.Pp_data;
            parameters[8].Value = model.Pp_belongs;
            parameters[9].Value = model.Pp_id;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int Pp_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete PlatformPublic_payments ");
            strSql.Append(" where Pp_id=@Pp_id");
            SqlParameter[] parameters = {
					new SqlParameter("@Pp_id", SqlDbType.Int,4)
				};
            parameters[0].Value = Pp_id;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.PlatformPublic_payments GetModel(int Pp_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Pp_id,Pp_name,Pp_num,Pp_Type,Pp_LotName,Pp_issue,Pp_Time,Pp_explain,Pp_data,Pp_belongs from PlatformPublic_payments ");
            strSql.Append(" where Pp_id=@Pp_id");
            SqlParameter[] parameters = {
					new SqlParameter("@Pp_id", SqlDbType.Int,4)
};
            parameters[0].Value = Pp_id;

            Pbzx.Model.PlatformPublic_payments model = new Pbzx.Model.PlatformPublic_payments();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Pp_id"].ToString() != "")
                {
                    model.Pp_id = int.Parse(ds.Tables[0].Rows[0]["Pp_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Pp_name"] != null)
                {
                    model.Pp_name = ds.Tables[0].Rows[0]["Pp_name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Pp_num"] != null)
                {
                    model.Pp_num = ds.Tables[0].Rows[0]["Pp_num"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Pp_Type"].ToString() != "")
                {
                    model.Pp_Type = int.Parse(ds.Tables[0].Rows[0]["Pp_Type"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Pp_LotName"].ToString() != "")
                {
                    model.Pp_LotName = int.Parse(ds.Tables[0].Rows[0]["Pp_LotName"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Pp_issue"].ToString() != "")
                {
                    model.Pp_issue = int.Parse(ds.Tables[0].Rows[0]["Pp_issue"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Pp_Time"].ToString() != "")
                {
                    model.Pp_Time = DateTime.Parse(ds.Tables[0].Rows[0]["Pp_Time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Pp_explain"] != null)
                {
                    model.Pp_explain = ds.Tables[0].Rows[0]["Pp_explain"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Pp_data"].ToString() != "")
                {
                    model.Pp_data = decimal.Parse(ds.Tables[0].Rows[0]["Pp_data"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Pp_belongs"] != null)
                {
                    model.Pp_belongs = ds.Tables[0].Rows[0]["Pp_belongs"].ToString();
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
            strSql.Append("select * from PlatformPublic_payments ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by Pp_id ");
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion  成员方法
    }
}
