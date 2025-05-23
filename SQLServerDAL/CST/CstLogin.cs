using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类CstLogin。
    /// </summary>
    public class CstLogin : ICstLogin
    {
        public CstLogin()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from CstLogin");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            return DbHelperSQL1.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.CstLogin model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CstLogin(");
            strSql.Append("HDSN,RN,SoftwareType,InstallType,Version,OSVersion,LoginTime,IP,LoginCount,TotalCount,FirstLoginTime,AginTime,Status,HDSNType,ExpireDate)");
            strSql.Append(" values (");
            strSql.Append("@HDSN,@RN,@SoftwareType,@InstallType,@Version,@OSVersion,@LoginTime,@IP,@LoginCount,@TotalCount,@FirstLoginTime,@AginTime,@Status,@HDSNType,@ExpireDate)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@HDSN", SqlDbType.NVarChar,16),
					new SqlParameter("@RN", SqlDbType.NVarChar,27),
					new SqlParameter("@SoftwareType", SqlDbType.TinyInt,1),
					new SqlParameter("@InstallType", SqlDbType.TinyInt,1),
					new SqlParameter("@Version", SqlDbType.NVarChar,16),
					new SqlParameter("@OSVersion", SqlDbType.NVarChar,16),
					new SqlParameter("@LoginTime", SqlDbType.DateTime),
					new SqlParameter("@IP", SqlDbType.NVarChar,25),
					new SqlParameter("@LoginCount", SqlDbType.SmallInt,2),
					new SqlParameter("@TotalCount", SqlDbType.Int,4),
					new SqlParameter("@FirstLoginTime", SqlDbType.DateTime),
					new SqlParameter("@AginTime", SqlDbType.DateTime),
					new SqlParameter("@Status", SqlDbType.TinyInt,1),
					new SqlParameter("@HDSNType", SqlDbType.TinyInt,1),
					new SqlParameter("@ExpireDate", SqlDbType.SmallDateTime)};
            parameters[0].Value = model.HDSN;
            parameters[1].Value = model.RN;
            parameters[2].Value = model.SoftwareType;
            parameters[3].Value = model.InstallType;
            parameters[4].Value = model.Version;
            parameters[5].Value = model.OSVersion;
            parameters[6].Value = model.LoginTime;
            parameters[7].Value = model.IP;
            parameters[8].Value = model.LoginCount;
            parameters[9].Value = model.TotalCount;
            parameters[10].Value = model.FirstLoginTime;
            parameters[11].Value = model.AginTime;
            parameters[12].Value = model.Status;
            parameters[13].Value = model.HDSNType;
            parameters[14].Value = model.ExpireDate;

            object obj = DbHelperSQL1.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(Pbzx.Model.CstLogin model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CstLogin set ");
            strSql.Append("HDSN=@HDSN,");
            strSql.Append("RN=@RN,");
            strSql.Append("SoftwareType=@SoftwareType,");
            strSql.Append("InstallType=@InstallType,");
            strSql.Append("LoginTime=@LoginTime,");
            strSql.Append("IP=@IP,");
            strSql.Append("LoginCount=@LoginCount,");
            strSql.Append("TotalCount=@TotalCount,");
            strSql.Append("FirstLoginTime=@FirstLoginTime,");
            strSql.Append("Status=@Status,");
            strSql.Append("HDSNType=@HDSNType,");
            strSql.Append("ExpireDate=@ExpireDate");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@HDSN", SqlDbType.NVarChar,16),
					new SqlParameter("@RN", SqlDbType.NVarChar,27),
					new SqlParameter("@SoftwareType", SqlDbType.TinyInt,1),
					new SqlParameter("@InstallType", SqlDbType.TinyInt,1),
					new SqlParameter("@Version", SqlDbType.NVarChar,16),
					new SqlParameter("@OSVersion", SqlDbType.NVarChar,16),
					new SqlParameter("@LoginTime", SqlDbType.DateTime),
					new SqlParameter("@IP", SqlDbType.NVarChar,25),
					new SqlParameter("@LoginCount", SqlDbType.SmallInt,2),
					new SqlParameter("@TotalCount", SqlDbType.Int,4),
					new SqlParameter("@FirstLoginTime", SqlDbType.DateTime),
					new SqlParameter("@AginTime", SqlDbType.DateTime),
					new SqlParameter("@Status", SqlDbType.TinyInt,1),
					new SqlParameter("@HDSNType", SqlDbType.TinyInt,1),
					new SqlParameter("@ExpireDate", SqlDbType.SmallDateTime)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.HDSN;
            parameters[2].Value = model.RN;
            parameters[3].Value = model.SoftwareType;
            parameters[4].Value = model.InstallType;
            parameters[5].Value = model.Version;
            parameters[6].Value = model.OSVersion;
            parameters[7].Value = model.LoginTime;
            parameters[8].Value = model.IP;
            parameters[9].Value = model.LoginCount;
            parameters[10].Value = model.TotalCount;
            parameters[11].Value = model.FirstLoginTime;
            parameters[12].Value = model.AginTime;
            parameters[13].Value = model.Status;
            parameters[14].Value = model.HDSNType;
            parameters[15].Value = model.ExpireDate;

            DbHelperSQL1.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete CstLogin ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            DbHelperSQL1.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.CstLogin GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,HDSN,RN,SoftwareType,InstallType,Version,OSVersion,LoginTime,IP,LoginCount,TotalCount,FirstLoginTime,AginTime,Status,HDSNType,ExpireDate from CstLogin ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            Pbzx.Model.CstLogin model = new Pbzx.Model.CstLogin();
            DataSet ds = DbHelperSQL1.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
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
                model.OSVersion = ds.Tables[0].Rows[0]["OSVersion"].ToString();
                if (ds.Tables[0].Rows[0]["LoginTime"].ToString() != "")
                {
                    model.LoginTime = DateTime.Parse(ds.Tables[0].Rows[0]["LoginTime"].ToString());
                }
                model.IP = ds.Tables[0].Rows[0]["IP"].ToString();
                if (ds.Tables[0].Rows[0]["LoginCount"].ToString() != "")
                {
                    model.LoginCount = int.Parse(ds.Tables[0].Rows[0]["LoginCount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TotalCount"].ToString() != "")
                {
                    model.TotalCount = int.Parse(ds.Tables[0].Rows[0]["TotalCount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["FirstLoginTime"].ToString() != "")
                {
                    model.FirstLoginTime = DateTime.Parse(ds.Tables[0].Rows[0]["FirstLoginTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AginTime"].ToString() != "")
                {
                    model.AginTime = DateTime.Parse(ds.Tables[0].Rows[0]["AginTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["HDSNType"].ToString() != "")
                {
                    model.HDSNType = int.Parse(ds.Tables[0].Rows[0]["HDSNType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ExpireDate"].ToString() != "")
                {
                    model.ExpireDate = DateTime.Parse(ds.Tables[0].Rows[0]["ExpireDate"].ToString());
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
            strSql.Append("select ID,HDSN,RN,SoftwareType,InstallType,Version,OSVersion,LoginTime,IP,LoginCount,TotalCount,FirstLoginTime,AginTime,Status,HDSNType,ExpireDate ");
            strSql.Append(" FROM CstLogin ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL1.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "CstLogin";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL1.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  成员方法
    }
}

