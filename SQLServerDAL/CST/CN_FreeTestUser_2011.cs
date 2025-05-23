using System;
using System.Collections.Generic;
using System.Text;
using Maticsoft.DBUtility;
using System.Data;
using System.Data.SqlClient;
using Pbzx.IDAL;

namespace Pbzx.SQLServerDAL
{
    public class CN_FreeTestUser_2011 : ICN_FreeTestUser_2011
    {
        public CN_FreeTestUser_2011()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL1.GetMaxID("ID", "CN_FreeTestUser2011");
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from CN_FreeTestUser2011");
            strSql.Append(" where ID= @ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
				};
            parameters[0].Value = ID;
            return DbHelperSQL1.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.CN_FreeTestUser2011 model)
        {
            model.ID = GetMaxId();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CN_FreeTestUser2011(");
            strSql.Append("ID,HDSN,GlobalID,SoftwareType,InstallType,FirstLoginTime,LastLoginTime,UseCount,Status,LastLoginID,ServiceID,LastLoginIP)");
            strSql.Append(" values (");
            strSql.Append("@ID,@HDSN,@GlobalID,@SoftwareType,@InstallType,@FirstLoginTime,@LastLoginTime,@UseCount,@Status,@LastLoginID,@ServiceID,@LastLoginIP)");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@HDSN", SqlDbType.Char,16),
					new SqlParameter("@GlobalID", SqlDbType.VarChar,22),
					new SqlParameter("@SoftwareType", SqlDbType.TinyInt,1),
					new SqlParameter("@InstallType", SqlDbType.TinyInt,1),
					new SqlParameter("@FirstLoginTime", SqlDbType.DateTime),
					new SqlParameter("@LastLoginTime", SqlDbType.DateTime),
					new SqlParameter("@UseCount", SqlDbType.Int,4),
					new SqlParameter("@Status", SqlDbType.TinyInt,1),
					new SqlParameter("@LastLoginID", SqlDbType.Int,4),
					new SqlParameter("@ServiceID", SqlDbType.Int,4),
					new SqlParameter("@LastLoginIP", SqlDbType.NVarChar)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.HDSN;
            parameters[2].Value = model.GlobalID;
            parameters[3].Value = model.SoftwareType;
            parameters[4].Value = model.InstallType;
            parameters[5].Value = model.FirstLoginTime;
            parameters[6].Value = model.LastLoginTime;
            parameters[7].Value = model.UseCount;
            parameters[8].Value = model.Status;
            parameters[9].Value = model.LastLoginID;
            parameters[10].Value = model.ServiceID;
            parameters[11].Value = model.LastLoginIP;

            DbHelperSQL1.ExecuteSql(strSql.ToString(), parameters);
            return model.ID;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Pbzx.Model.CN_FreeTestUser2011 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CN_FreeTestUser2011 set ");
            strSql.Append("HDSN=@HDSN,");
            strSql.Append("GlobalID=@GlobalID,");
            strSql.Append("SoftwareType=@SoftwareType,");
            strSql.Append("InstallType=@InstallType,");
            strSql.Append("FirstLoginTime=@FirstLoginTime,");
            strSql.Append("LastLoginTime=@LastLoginTime,");
            strSql.Append("UseCount=@UseCount,");
            strSql.Append("Status=@Status,");
            strSql.Append("LastLoginID=@LastLoginID,");
            strSql.Append("ServiceID=@ServiceID,");
            strSql.Append("LastLoginIP=@LastLoginIP");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@HDSN", SqlDbType.Char,16),
					new SqlParameter("@GlobalID", SqlDbType.VarChar,22),
					new SqlParameter("@SoftwareType", SqlDbType.TinyInt,1),
					new SqlParameter("@InstallType", SqlDbType.TinyInt,1),
					new SqlParameter("@FirstLoginTime", SqlDbType.DateTime),
					new SqlParameter("@LastLoginTime", SqlDbType.DateTime),
					new SqlParameter("@UseCount", SqlDbType.Int,4),
					new SqlParameter("@Status", SqlDbType.TinyInt,1),
					new SqlParameter("@LastLoginID", SqlDbType.Int,4),
					new SqlParameter("@ServiceID", SqlDbType.Int,4),
					new SqlParameter("@LastLoginIP", SqlDbType.NVarChar)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.HDSN;
            parameters[2].Value = model.GlobalID;
            parameters[3].Value = model.SoftwareType;
            parameters[4].Value = model.InstallType;
            parameters[5].Value = model.FirstLoginTime;
            parameters[6].Value = model.LastLoginTime;
            parameters[7].Value = model.UseCount;
            parameters[8].Value = model.Status;
            parameters[9].Value = model.LastLoginID;
            parameters[10].Value = model.ServiceID;
            parameters[11].Value = model.LastLoginIP;

            return DbHelperSQL1.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete CN_FreeTestUser2011 ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
				};
            parameters[0].Value = ID;
            return DbHelperSQL1.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.CN_FreeTestUser2011 GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from CN_FreeTestUser2011 ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;
            Pbzx.Model.CN_FreeTestUser2011 model = new Pbzx.Model.CN_FreeTestUser2011();
            DataSet ds = DbHelperSQL1.Query(strSql.ToString(), parameters);
            model.ID = ID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.HDSN = ds.Tables[0].Rows[0]["HDSN"].ToString();
                model.GlobalID = ds.Tables[0].Rows[0]["GlobalID"].ToString();
                if (ds.Tables[0].Rows[0]["SoftwareType"].ToString() != "")
                {
                    model.SoftwareType = int.Parse(ds.Tables[0].Rows[0]["SoftwareType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["InstallType"].ToString() != "")
                {
                    model.InstallType = int.Parse(ds.Tables[0].Rows[0]["InstallType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["FirstLoginTime"].ToString() != "")
                {
                    model.FirstLoginTime = DateTime.Parse(ds.Tables[0].Rows[0]["FirstLoginTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LastLoginTime"].ToString() != "")
                {
                    model.LastLoginTime = DateTime.Parse(ds.Tables[0].Rows[0]["LastLoginTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UseCount"].ToString() != "")
                {
                    model.UseCount = int.Parse(ds.Tables[0].Rows[0]["UseCount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LastLoginID"].ToString() != "")
                {
                    model.LastLoginID = int.Parse(ds.Tables[0].Rows[0]["LastLoginID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ServiceID"].ToString() != "")
                {
                    model.ServiceID = int.Parse(ds.Tables[0].Rows[0]["ServiceID"].ToString());
                }
                model.LastLoginIP = ds.Tables[0].Rows[0]["LastLoginIP"].ToString();
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
            strSql.Append("select * from CN_FreeTestUser2011 ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by ID ");
            return DbHelperSQL1.Query(strSql.ToString());
        }
        #endregion  成员方法

    }
}

