using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;
using System.Data;

namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类PlatformPublic_integralPrize。
    /// </summary>
    public class PlatformPublic_integralPrize : IPlatformPublic_integralPrize
    {
        public PlatformPublic_integralPrize()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Pip_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PlatformPublic_integralPrize");
            strSql.Append(" where Pip_id= @Pip_id");
            SqlParameter[] parameters = {
					new SqlParameter("@Pip_id", SqlDbType.Int,4)
				};
            parameters[0].Value = Pip_id;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.PlatformPublic_integralPrize model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PlatformPublic_integralPrize(");
            strSql.Append("Pip_user,Pip_Interal,Pip_Prize,Pip_money,Pip_belongs,Pip_freeze)");
            strSql.Append(" values (");
            strSql.Append("@Pip_user,@Pip_Interal,@Pip_Prize,@Pip_money,@Pip_belongs,@Pip_freeze)");
            SqlParameter[] parameters = {
					new SqlParameter("@Pip_user", SqlDbType.NVarChar),
					new SqlParameter("@Pip_Interal", SqlDbType.Int,4),
					new SqlParameter("@Pip_Prize", SqlDbType.Int,4),
					new SqlParameter("@Pip_money", SqlDbType.Decimal,9),
					new SqlParameter("@Pip_belongs", SqlDbType.NVarChar),
					new SqlParameter("@Pip_freeze", SqlDbType.Int,4)};
            parameters[0].Value = model.Pip_user;
            parameters[1].Value = model.Pip_Interal;
            parameters[2].Value = model.Pip_Prize;
            parameters[3].Value = model.Pip_money;
            parameters[4].Value = model.Pip_belongs;
            parameters[5].Value = model.Pip_freeze;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Pbzx.Model.PlatformPublic_integralPrize model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PlatformPublic_integralPrize set ");
            strSql.Append("Pip_user=@Pip_user,");
            strSql.Append("Pip_Interal=@Pip_Interal,");
            strSql.Append("Pip_Prize=@Pip_Prize,");
            strSql.Append("Pip_money=@Pip_money,");
            strSql.Append("Pip_belongs=@Pip_belongs,");
            strSql.Append("Pip_freeze=@Pip_freeze");
            strSql.Append(" where Pip_id=@Pip_id");
            SqlParameter[] parameters = {
					new SqlParameter("@Pip_id", SqlDbType.Int,4),
					new SqlParameter("@Pip_user", SqlDbType.NVarChar),
					new SqlParameter("@Pip_Interal", SqlDbType.Int,4),
					new SqlParameter("@Pip_Prize", SqlDbType.Int,4),
					new SqlParameter("@Pip_money", SqlDbType.Decimal,9),
					new SqlParameter("@Pip_belongs", SqlDbType.NVarChar),
					new SqlParameter("@Pip_freeze", SqlDbType.Int,4)};
            parameters[0].Value = model.Pip_id;
            parameters[1].Value = model.Pip_user;
            parameters[2].Value = model.Pip_Interal;
            parameters[3].Value = model.Pip_Prize;
            parameters[4].Value = model.Pip_money;
            parameters[5].Value = model.Pip_belongs;
            parameters[6].Value = model.Pip_freeze;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int Pip_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete PlatformPublic_integralPrize ");
            strSql.Append(" where Pip_id=@Pip_id");
            SqlParameter[] parameters = {
					new SqlParameter("@Pip_id", SqlDbType.Int,4)
				};
            parameters[0].Value = Pip_id;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.PlatformPublic_integralPrize GetModel(int Pip_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from PlatformPublic_integralPrize ");
            strSql.Append(" where Pip_id=@Pip_id");
            SqlParameter[] parameters = {
					new SqlParameter("@Pip_id", SqlDbType.Int,4)};
            parameters[0].Value = Pip_id;
            Pbzx.Model.PlatformPublic_integralPrize model = new Pbzx.Model.PlatformPublic_integralPrize();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            model.Pip_id = Pip_id;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.Pip_user = ds.Tables[0].Rows[0]["Pip_user"].ToString();
                if (ds.Tables[0].Rows[0]["Pip_Interal"].ToString() != "")
                {
                    model.Pip_Interal = int.Parse(ds.Tables[0].Rows[0]["Pip_Interal"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Pip_Prize"].ToString() != "")
                {
                    model.Pip_Prize = int.Parse(ds.Tables[0].Rows[0]["Pip_Prize"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Pip_money"].ToString() != "")
                {
                    model.Pip_money = decimal.Parse(ds.Tables[0].Rows[0]["Pip_money"].ToString());
                }
                model.Pip_belongs = ds.Tables[0].Rows[0]["Pip_belongs"].ToString();
                if (ds.Tables[0].Rows[0]["Pip_freeze"].ToString() != "")
                {
                    model.Pip_freeze = int.Parse(ds.Tables[0].Rows[0]["Pip_freeze"].ToString());
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
            strSql.Append("select * from PlatformPublic_integralPrize ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by Pip_id ");
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion  成员方法
    }
}

