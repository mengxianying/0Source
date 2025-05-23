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
    /// 数据访问类DataRivalry_Contrast。
    /// </summary>
    public class DataRivalry_Contrast : IDataRivalry_Contrast
    {
        public DataRivalry_Contrast()
        { }
        #region  成员方法


        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("ct_id", "DataRivalry_Contrast");
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ct_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from DataRivalry_Contrast");
            strSql.Append(" where ct_id= @ct_id");
            SqlParameter[] parameters = {
					new SqlParameter("@ct_id", SqlDbType.Int,4)
				};
            parameters[0].Value = ct_id;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.DataRivalry_Contrast model)
        {
            model.ct_id = GetMaxId();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into DataRivalry_Contrast(");
            strSql.Append("ct_id,ct_drID,ct_Num)");
            strSql.Append(" values (");
            strSql.Append("@ct_id,@ct_drID,@ct_Num)");
            SqlParameter[] parameters = {
					new SqlParameter("@ct_id", SqlDbType.Int,4),
					new SqlParameter("@ct_drID", SqlDbType.Int,4),
					new SqlParameter("@ct_Num", SqlDbType.Text)};
            parameters[0].Value = model.ct_id;
            parameters[1].Value = model.ct_drID;
            parameters[2].Value = model.ct_Num;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            return model.ct_id;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Pbzx.Model.DataRivalry_Contrast model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update DataRivalry_Contrast set ");
            strSql.Append("ct_drID=@ct_drID,");
            strSql.Append("ct_Num=@ct_Num");
            strSql.Append(" where ct_id=@ct_id");
            SqlParameter[] parameters = {
					new SqlParameter("@ct_id", SqlDbType.Int,4),
					new SqlParameter("@ct_drID", SqlDbType.Int,4),
					new SqlParameter("@ct_Num", SqlDbType.Text)};
            parameters[0].Value = model.ct_id;
            parameters[1].Value = model.ct_drID;
            parameters[2].Value = model.ct_Num;

           return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int ct_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete DataRivalry_Contrast ");
            strSql.Append(" where ct_id=@ct_id");
            SqlParameter[] parameters = {
					new SqlParameter("@ct_id", SqlDbType.Int,4)
				};
            parameters[0].Value = ct_id;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 删除一条数据 根据信息表ID 
        /// </summary>
        public int DeleteJoint(int Ct_drID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete DataRivalry_Contrast ");
            strSql.Append(" where Ct_drID=@Ct_drID");
            SqlParameter[] parameters = {
					new SqlParameter("@Ct_drID", SqlDbType.Int,4)
				};
            parameters[0].Value = Ct_drID;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.DataRivalry_Contrast GetModel(int ct_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from DataRivalry_Contrast ");
            strSql.Append(" where ct_id=@ct_id");
            SqlParameter[] parameters = {
					new SqlParameter("@ct_id", SqlDbType.Int,4)};
            parameters[0].Value = ct_id;
            Pbzx.Model.DataRivalry_Contrast model = new Pbzx.Model.DataRivalry_Contrast();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            model.ct_id = ct_id;
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ct_drID"].ToString() != "")
                {
                    model.ct_drID = int.Parse(ds.Tables[0].Rows[0]["ct_drID"].ToString());
                }
                model.ct_Num = ds.Tables[0].Rows[0]["ct_Num"].ToString();
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
            strSql.Append("select * from DataRivalry_Contrast ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by ct_id ");
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion  成员方法
    }
}
