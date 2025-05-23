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
    /// 数据访问类DataRivalry_downLoad。
    /// </summary>
    public class DataRivalry_downLoad : IDataRivalry_downLoad
    {
        public DataRivalry_downLoad()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Dl_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from DataRivalry_downLoad");
            strSql.Append(" where Dl_id= @Dl_id");
            SqlParameter[] parameters = {
					new SqlParameter("@Dl_id", SqlDbType.Int,4)
				};
            parameters[0].Value = Dl_id;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <param name="Dl_ufID">大底的ID</param>
        /// <param name="Dl_name">会员名称</param>
        /// <returns></returns>
        public bool Exists(int Dl_ufID, string Dl_name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from DataRivalry_downLoad");
            strSql.Append(" where Dl_ufID= @Dl_ufID and Dl_name=@Dl_name");
            SqlParameter[] parameters = {
					new SqlParameter("@Dl_ufID", SqlDbType.Int,4),
                    new SqlParameter("@Dl_name",SqlDbType.NVarChar,50)
				};
            parameters[0].Value = Dl_ufID;
            parameters[1].Value = Dl_name;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.DataRivalry_downLoad model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into DataRivalry_downLoad(");
            strSql.Append("Dl_name,Dl_Time,Dl_ufID,Dl_dl,Dl_dlName)");
            strSql.Append(" values (");
            strSql.Append("@Dl_name,@Dl_Time,@Dl_ufID,@Dl_dl,@Dl_dlName)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Dl_name", SqlDbType.NVarChar,50),
					new SqlParameter("@Dl_Time", SqlDbType.DateTime),
					new SqlParameter("@Dl_ufID", SqlDbType.Int,4),
					new SqlParameter("@Dl_dl", SqlDbType.Int,4),
					new SqlParameter("@Dl_dlName", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.Dl_name;
            parameters[1].Value = model.Dl_Time;
            parameters[2].Value = model.Dl_ufID;
            parameters[3].Value = model.Dl_dl;
            parameters[4].Value = model.Dl_dlName;

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
        public int Update(Pbzx.Model.DataRivalry_downLoad model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update DataRivalry_downLoad set ");
            strSql.Append("Dl_name=@Dl_name,");
            strSql.Append("Dl_Time=@Dl_Time,");
            strSql.Append("Dl_ufID=@Dl_ufID,");
            strSql.Append("Dl_dl=@Dl_dl,");
            strSql.Append("Dl_dlName=@Dl_dlName");
            strSql.Append(" where Dl_id=@Dl_id");
            SqlParameter[] parameters = {
					new SqlParameter("@Dl_name", SqlDbType.NVarChar,50),
					new SqlParameter("@Dl_Time", SqlDbType.DateTime),
					new SqlParameter("@Dl_ufID", SqlDbType.Int,4),
					new SqlParameter("@Dl_dl", SqlDbType.Int,4),
					new SqlParameter("@Dl_dlName", SqlDbType.NVarChar,50),
					new SqlParameter("@Dl_id", SqlDbType.Int,4)};
            parameters[0].Value = model.Dl_name;
            parameters[1].Value = model.Dl_Time;
            parameters[2].Value = model.Dl_ufID;
            parameters[3].Value = model.Dl_dl;
            parameters[4].Value = model.Dl_dlName;
            parameters[5].Value = model.Dl_id;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int Dl_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete DataRivalry_downLoad ");
            strSql.Append(" where Dl_id=@Dl_id");
            SqlParameter[] parameters = {
					new SqlParameter("@Dl_id", SqlDbType.Int,4)
				};
            parameters[0].Value = Dl_id;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.DataRivalry_downLoad GetModel(int Dl_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Dl_id,Dl_name,Dl_Time,Dl_ufID,Dl_dl,Dl_dlName from DataRivalry_downLoad ");
            strSql.Append(" where Dl_id=@Dl_id");
            SqlParameter[] parameters = {
					new SqlParameter("@Dl_id", SqlDbType.Int,4)
};
            parameters[0].Value = Dl_id;

            Pbzx.Model.DataRivalry_downLoad model = new Pbzx.Model.DataRivalry_downLoad();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Dl_id"].ToString() != "")
                {
                    model.Dl_id = int.Parse(ds.Tables[0].Rows[0]["Dl_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Dl_name"] != null)
                {
                    model.Dl_name = ds.Tables[0].Rows[0]["Dl_name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Dl_Time"].ToString() != "")
                {
                    model.Dl_Time = DateTime.Parse(ds.Tables[0].Rows[0]["Dl_Time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Dl_ufID"].ToString() != "")
                {
                    model.Dl_ufID = int.Parse(ds.Tables[0].Rows[0]["Dl_ufID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Dl_dl"].ToString() != "")
                {
                    model.Dl_dl = int.Parse(ds.Tables[0].Rows[0]["Dl_dl"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Dl_dlName"] != null)
                {
                    model.Dl_dlName = ds.Tables[0].Rows[0]["Dl_dlName"].ToString();
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
            strSql.Append("select * from DataRivalry_downLoad ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by Dl_id ");
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
            strSql.Append(" Dl_id,Dl_name,Dl_Time,Dl_ufID,Dl_dl,Dl_dlName ");
            strSql.Append(" FROM DataRivalry_downLoad ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }


        #endregion  成员方法
    }
}
