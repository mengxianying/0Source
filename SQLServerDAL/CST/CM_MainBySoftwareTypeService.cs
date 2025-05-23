using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;

namespace Pbzx.SQLServerDAL
{
    public class CM_MainBySoftwareTypeService : ICM_MainBySoftwareType
    {

        #region ICM_MainBySoftwareType 成员

        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from CM_MainBySoftwareType");
            strSql.Append(" where ID= @ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
				};
            parameters[0].Value = ID;
            return DbHelperSQL1.Exists(strSql.ToString(), parameters);
        }

        public int Add(Pbzx.Model.CM_MainBySoftwareType model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CM_MainBySoftwareType(");
            strSql.Append("CMID,SoftInfo,BeginVersion,EndVersion,SoftwareName,InstallName)");
            strSql.Append(" values (");
            strSql.Append("@CMID,@SoftInfo,@BeginVersion,@EndVersion,@SoftwareName,@InstallName)");
            SqlParameter[] parameters = {
					new SqlParameter("@CMID", SqlDbType.Int,4),
					new SqlParameter("@SoftInfo", SqlDbType.Int,4),
					new SqlParameter("@BeginVersion", SqlDbType.Int,4),
					new SqlParameter("@EndVersion", SqlDbType.Int,4),
					new SqlParameter("@SoftwareName", SqlDbType.NVarChar),
					new SqlParameter("@InstallName", SqlDbType.NVarChar)};
            parameters[0].Value = model.CMID;
            parameters[1].Value = model.SoftInfo;
            parameters[2].Value = model.BeginVersion;
            parameters[3].Value = model.EndVersion;
            parameters[4].Value = model.SoftwareName;
            parameters[5].Value = model.InstallName;

            return DbHelperSQL1.ExecuteSql(strSql.ToString(), parameters);
        }

        public int Update(Pbzx.Model.CM_MainBySoftwareType model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CM_MainBySoftwareType set ");
            strSql.Append("CMID=@CMID,");
            strSql.Append("SoftInfo=@SoftInfo,");
            strSql.Append("BeginVersion=@BeginVersion,");
            strSql.Append("EndVersion=@EndVersion,");
            strSql.Append("SoftwareName=@SoftwareName,");
            strSql.Append("InstallName=@InstallName");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@CMID", SqlDbType.Int,4),
					new SqlParameter("@SoftInfo", SqlDbType.Int,4),
					new SqlParameter("@BeginVersion", SqlDbType.Int,4),
					new SqlParameter("@EndVersion", SqlDbType.Int,4),
					new SqlParameter("@SoftwareName", SqlDbType.NVarChar),
					new SqlParameter("@InstallName", SqlDbType.NVarChar)};
            parameters[0].Value = model.Id;
            parameters[1].Value = model.CMID;
            parameters[2].Value = model.SoftInfo;
            parameters[3].Value = model.BeginVersion;
            parameters[4].Value = model.EndVersion;
            parameters[5].Value = model.SoftwareName;
            parameters[6].Value = model.InstallName;

            return DbHelperSQL1.ExecuteSql(strSql.ToString(), parameters);
        }

        public int Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete CM_MainBySoftwareType ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
				};
            parameters[0].Value = ID;
            return DbHelperSQL1.ExecuteSql(strSql.ToString(), parameters);
        }

        public Pbzx.Model.CM_MainBySoftwareType GetMain(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from CM_MainBySoftwareType ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;
            Pbzx.Model.CM_MainBySoftwareType model = new Pbzx.Model.CM_MainBySoftwareType();
            DataSet ds = DbHelperSQL1.Query(strSql.ToString(), parameters);
            model.Id = ID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["CMID"].ToString() != "")
                {
                    model.CMID = int.Parse(ds.Tables[0].Rows[0]["CMID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SoftInfo"].ToString() != "")
                {
                    model.SoftInfo = int.Parse(ds.Tables[0].Rows[0]["SoftInfo"].ToString());
                }

                if (ds.Tables[0].Rows[0]["BeginVersion"].ToString() != "")
                {
                    model.BeginVersion = int.Parse(ds.Tables[0].Rows[0]["BeginVersion"].ToString());
                }
                if (ds.Tables[0].Rows[0]["EndVersion"].ToString() != "")
                {
                    model.EndVersion = int.Parse(ds.Tables[0].Rows[0]["EndVersion"].ToString());

                }
                model.SoftwareName = ds.Tables[0].Rows[0]["SoftwareName"].ToString();
                model.InstallName = ds.Tables[0].Rows[0]["InstallName"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from CM_MainBySoftwareType ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by ID ");
            return DbHelperSQL1.Query(strSql.ToString());
        }

        #endregion

        #region ICM_MainBySoftwareType 成员

        /// <summary>
        /// 根据cmid删除
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public int DeleteByCM_ID(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete CM_MainBySoftwareType ");
            strSql.Append(" where CMID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
				};
            parameters[0].Value = ID;
            return DbHelperSQL1.ExecuteSql(strSql.ToString(), parameters);
        }

        #endregion
    }
}
