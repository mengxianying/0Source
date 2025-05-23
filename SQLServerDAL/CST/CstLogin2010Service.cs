using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;
using System.Data;//请先添加引用

namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类CstLogin2010。
    /// 创建时间：2010-11-19
    /// 创建人：xiaowei
    /// </summary>
    public class CstLogin2010Service : ICstLogin2010
    {
        public CstLogin2010Service()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from CstLogin2010");
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
        public void Add(Pbzx.Model.CstLogin2010 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CstLogin2010(");
            strSql.Append("HDSN,RN,SoftwareType,InstallType,Version,OSName,TodayCount,TotalCount,Status,HDSNType,LastLoginIP,ExpireDate,FirstLoginTime,LastLoginTime,NormalMsgTime,WebMsgTime,NewsMsgTime,GlobalID)");
            strSql.Append(" values (");
            strSql.Append("@HDSN,@RN,@SoftwareType,@InstallType,@Version,@OSName,@TodayCount,@TotalCount,@Status,@HDSNType,@LastLoginIP,@ExpireDate,@FirstLoginTime,@LastLoginTime,@NormalMsgTime,@WebMsgTime,@NewsMsgTime,@GlobalID)");
            SqlParameter[] parameters = {
					new SqlParameter("@HDSN", SqlDbType.NVarChar),
					new SqlParameter("@RN", SqlDbType.NVarChar),
					new SqlParameter("@SoftwareType", SqlDbType.TinyInt,1),
					new SqlParameter("@InstallType", SqlDbType.TinyInt,1),
					new SqlParameter("@Version", SqlDbType.NVarChar),
					new SqlParameter("@OSName", SqlDbType.NVarChar),
					new SqlParameter("@TodayCount", SqlDbType.SmallInt,2),
					new SqlParameter("@TotalCount", SqlDbType.Int,4),
					new SqlParameter("@Status", SqlDbType.TinyInt,1),
					new SqlParameter("@HDSNType", SqlDbType.TinyInt,1),
					new SqlParameter("@LastLoginIP", SqlDbType.NVarChar),
					new SqlParameter("@ExpireDate", SqlDbType.SmallDateTime),
					new SqlParameter("@FirstLoginTime", SqlDbType.DateTime),
					new SqlParameter("@LastLoginTime", SqlDbType.DateTime),
					new SqlParameter("@NormalMsgTime", SqlDbType.DateTime),
					new SqlParameter("@WebMsgTime", SqlDbType.DateTime),
					new SqlParameter("@NewsMsgTime", SqlDbType.DateTime),
                     new SqlParameter("@GlobalID",SqlDbType.NVarChar)};
            parameters[0].Value = model.HDSN;
            parameters[1].Value = model.RN;
            parameters[2].Value = model.SoftwareType;
            parameters[3].Value = model.InstallType;
            parameters[4].Value = model.Version;
            parameters[5].Value = model.OSName;
            parameters[6].Value = model.TodayCount;
            parameters[7].Value = model.TotalCount;
            parameters[8].Value = model.Status;
            parameters[9].Value = model.HDSNType;
            parameters[10].Value = model.LastLoginIP;
            parameters[11].Value = model.ExpireDate;
            parameters[12].Value = model.FirstLoginTime;
            parameters[13].Value = model.LastLoginTime;
            parameters[14].Value = model.NormalMsgTime;
            parameters[15].Value = model.WebMsgTime;
            parameters[16].Value = model.NewsMsgTime;

            DbHelperSQL1.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(Pbzx.Model.CstLogin2010 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CstLogin2010 set ");
            strSql.Append("HDSN=@HDSN,");
            strSql.Append("RN=@RN,");
            strSql.Append("SoftwareType=@SoftwareType,");
            strSql.Append("InstallType=@InstallType,");
            strSql.Append("Version=@Version,");
            strSql.Append("OSName=@OSName,");
            strSql.Append("TodayCount=@TodayCount,");
            strSql.Append("TotalCount=@TotalCount,");
            strSql.Append("Status=@Status,");
            strSql.Append("HDSNType=@HDSNType,");
            strSql.Append("LastLoginIP=@LastLoginIP,");
            strSql.Append("ExpireDate=@ExpireDate,");
            strSql.Append("FirstLoginTime=@FirstLoginTime,");
            strSql.Append("LastLoginTime=@LastLoginTime,");
            strSql.Append("NormalMsgTime=@NormalMsgTime,");
            strSql.Append("WebMsgTime=@WebMsgTime,");
            strSql.Append("NewsMsgTime=@NewsMsgTime ,");
            strSql.Append("GlobalID=@GlobalID ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@HDSN", SqlDbType.NVarChar),
					new SqlParameter("@RN", SqlDbType.NVarChar),
					new SqlParameter("@SoftwareType", SqlDbType.TinyInt,1),
					new SqlParameter("@InstallType", SqlDbType.TinyInt,1),
					new SqlParameter("@Version", SqlDbType.NVarChar),
					new SqlParameter("@OSName", SqlDbType.NVarChar),
					new SqlParameter("@TodayCount", SqlDbType.SmallInt,2),
					new SqlParameter("@TotalCount", SqlDbType.Int,4),
					new SqlParameter("@Status", SqlDbType.TinyInt,1),
					new SqlParameter("@HDSNType", SqlDbType.TinyInt,1),
					new SqlParameter("@LastLoginIP", SqlDbType.NVarChar),
					new SqlParameter("@ExpireDate", SqlDbType.SmallDateTime),
					new SqlParameter("@FirstLoginTime", SqlDbType.DateTime),
					new SqlParameter("@LastLoginTime", SqlDbType.DateTime),
					new SqlParameter("@NormalMsgTime", SqlDbType.DateTime),
					new SqlParameter("@WebMsgTime", SqlDbType.DateTime),
					new SqlParameter("@NewsMsgTime", SqlDbType.DateTime),
                    new  SqlParameter("@GlobalID",SqlDbType.NVarChar)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.HDSN;
            parameters[2].Value = model.RN;
            parameters[3].Value = model.SoftwareType;
            parameters[4].Value = model.InstallType;
            parameters[5].Value = model.Version;
            parameters[6].Value = model.OSName;
            parameters[7].Value = model.TodayCount;
            parameters[8].Value = model.TotalCount;
            parameters[9].Value = model.Status;
            parameters[10].Value = model.HDSNType;
            parameters[11].Value = model.LastLoginIP;
            parameters[12].Value = model.ExpireDate;
            parameters[13].Value = model.FirstLoginTime;
            parameters[14].Value = model.LastLoginTime;
            parameters[15].Value = model.NormalMsgTime;
            parameters[16].Value = model.WebMsgTime;
            parameters[17].Value = model.NewsMsgTime;
            parameters[18].Value = model.GlobalID;

            DbHelperSQL1.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete CstLogin2010 ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
				};
            parameters[0].Value = ID;
            DbHelperSQL1.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.CstLogin2010 GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from CstLogin2010 ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;
            Pbzx.Model.CstLogin2010 model = new Pbzx.Model.CstLogin2010();
            DataSet ds = DbHelperSQL1.Query(strSql.ToString(), parameters);
            model.ID = ID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.HDSN = ds.Tables[0].Rows[0]["HDSN"].ToString();
                model.RN = ds.Tables[0].Rows[0]["RN"].ToString();
                if (ds.Tables[0].Rows[0]["SoftwareType"].ToString() != "")
                {
                    model.SoftwareType = int.Parse(ds.Tables[0].Rows[0]["SoftwareType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["InstallType"].ToString() != "")
                {
                    model.InstallType = int.Parse(ds.Tables[0].Rows[0]["InstallType"].ToString());
                }
                model.Version = ds.Tables[0].Rows[0]["Version"].ToString();
                model.OSName = ds.Tables[0].Rows[0]["OSName"].ToString();
                if (ds.Tables[0].Rows[0]["TodayCount"].ToString() != "")
                {
                    model.TodayCount = int.Parse(ds.Tables[0].Rows[0]["TodayCount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TotalCount"].ToString() != "")
                {
                    model.TotalCount = int.Parse(ds.Tables[0].Rows[0]["TotalCount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["HDSNType"].ToString() != "")
                {
                    model.HDSNType = int.Parse(ds.Tables[0].Rows[0]["HDSNType"].ToString());
                }
                model.LastLoginIP = ds.Tables[0].Rows[0]["LastLoginIP"].ToString();
                if (ds.Tables[0].Rows[0]["ExpireDate"].ToString() != "")
                {
                    model.ExpireDate = DateTime.Parse(ds.Tables[0].Rows[0]["ExpireDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["FirstLoginTime"].ToString() != "")
                {
                    model.FirstLoginTime = DateTime.Parse(ds.Tables[0].Rows[0]["FirstLoginTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LastLoginTime"].ToString() != "")
                {
                    model.LastLoginTime = DateTime.Parse(ds.Tables[0].Rows[0]["LastLoginTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["NormalMsgTime"].ToString() != "")
                {
                    model.NormalMsgTime = DateTime.Parse(ds.Tables[0].Rows[0]["NormalMsgTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["WebMsgTime"].ToString() != "")
                {
                    model.WebMsgTime = DateTime.Parse(ds.Tables[0].Rows[0]["WebMsgTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["NewsMsgTime"].ToString() != "")
                {
                    model.NewsMsgTime = DateTime.Parse(ds.Tables[0].Rows[0]["NewsMsgTime"].ToString());
                }

                model.GlobalID = ds.Tables[0].Rows[0]["GlobalID"].ToString();
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
            strSql.Append("select * from CstLogin2010 ");
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

