using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类CN_Log。
    /// </summary>
    public class CN_Log : ICN_Log
    {
        public CN_Log()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from CN_Log");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            return DbHelperSQL1.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int  Add(Pbzx.Model.CN_Log model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CN_Log(");
            strSql.Append("ID,Username,SoftwareType,InstallType,ProgramVer,HDSN,RN,IP,Port,StartTime,EndTime,LoginMutex,Status,ServiceID,UserIndex,UseType,UseValue)");
            strSql.Append(" values (");
            strSql.Append("@ID,@Username,@SoftwareType,@InstallType,@ProgramVer,@HDSN,@RN,@IP,@Port,@StartTime,@EndTime,@LoginMutex,@Status,@ServiceID,@UserIndex,@UseType,@UseValue)");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@Username", SqlDbType.VarChar,16),
					new SqlParameter("@SoftwareType", SqlDbType.TinyInt,1),
					new SqlParameter("@InstallType", SqlDbType.TinyInt,1),
					new SqlParameter("@ProgramVer", SqlDbType.VarChar,8),
					new SqlParameter("@HDSN", SqlDbType.Char,16),
					new SqlParameter("@RN", SqlDbType.Char,27),
					new SqlParameter("@IP", SqlDbType.VarChar,16),
					new SqlParameter("@Port", SqlDbType.Int,4),
					new SqlParameter("@StartTime", SqlDbType.DateTime),
					new SqlParameter("@EndTime", SqlDbType.DateTime),
					new SqlParameter("@LoginMutex", SqlDbType.Int,4),
					new SqlParameter("@Status", SqlDbType.TinyInt,1),
					new SqlParameter("@ServiceID", SqlDbType.Int,4),
					new SqlParameter("@UserIndex", SqlDbType.Int,4),
					new SqlParameter("@UseType", SqlDbType.TinyInt,1),
					new SqlParameter("@UseValue", SqlDbType.Int,4)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Username;
            parameters[2].Value = model.SoftwareType;
            parameters[3].Value = model.InstallType;
            parameters[4].Value = model.ProgramVer;
            parameters[5].Value = model.HDSN;
            parameters[6].Value = model.RN;
            parameters[7].Value = model.IP;
            parameters[8].Value = model.Port;
            parameters[9].Value = model.StartTime;
            parameters[10].Value = model.EndTime;
            parameters[11].Value = model.LoginMutex;
            parameters[12].Value = model.Status;
            parameters[13].Value = model.ServiceID;
            parameters[14].Value = model.UserIndex;
            parameters[15].Value = model.UseType;
            parameters[16].Value = model.UseValue;

         return  DbHelperSQL1.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int  Update(Pbzx.Model.CN_Log model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CN_Log set ");
            strSql.Append("Username=@Username,");
            strSql.Append("HDSN=@HDSN,");
            strSql.Append("RN=@RN,");
            strSql.Append("IP=@IP,");
            strSql.Append("Port=@Port,");
            strSql.Append("LoginMutex=@LoginMutex,");
            strSql.Append("Status=@Status,");
            strSql.Append("ServiceID=@ServiceID,");
            strSql.Append("UserIndex=@UserIndex,");
            strSql.Append("UseType=@UseType,");
            strSql.Append("UseValue=@UseValue");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@Username", SqlDbType.VarChar,16),
					new SqlParameter("@SoftwareType", SqlDbType.TinyInt,1),
					new SqlParameter("@InstallType", SqlDbType.TinyInt,1),
					new SqlParameter("@ProgramVer", SqlDbType.VarChar,8),
					new SqlParameter("@HDSN", SqlDbType.Char,16),
					new SqlParameter("@RN", SqlDbType.Char,27),
					new SqlParameter("@IP", SqlDbType.VarChar,16),
					new SqlParameter("@Port", SqlDbType.Int,4),
					new SqlParameter("@StartTime", SqlDbType.DateTime),
					new SqlParameter("@EndTime", SqlDbType.DateTime),
					new SqlParameter("@LoginMutex", SqlDbType.Int,4),
					new SqlParameter("@Status", SqlDbType.TinyInt,1),
					new SqlParameter("@ServiceID", SqlDbType.Int,4),
					new SqlParameter("@UserIndex", SqlDbType.Int,4),
					new SqlParameter("@UseType", SqlDbType.TinyInt,1),
					new SqlParameter("@UseValue", SqlDbType.Int,4)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Username;
            parameters[2].Value = model.SoftwareType;
            parameters[3].Value = model.InstallType;
            parameters[4].Value = model.ProgramVer;
            parameters[5].Value = model.HDSN;
            parameters[6].Value = model.RN;
            parameters[7].Value = model.IP;
            parameters[8].Value = model.Port;
            parameters[9].Value = model.StartTime;
            parameters[10].Value = model.EndTime;
            parameters[11].Value = model.LoginMutex;
            parameters[12].Value = model.Status;
            parameters[13].Value = model.ServiceID;
            parameters[14].Value = model.UserIndex;
            parameters[15].Value = model.UseType;
            parameters[16].Value = model.UseValue;

          return  DbHelperSQL1.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from CN_Log ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

           return DbHelperSQL1.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.CN_Log GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,Username,SoftwareType,InstallType,ProgramVer,HDSN,RN,IP,Port,StartTime,EndTime,LoginMutex,Status,ServiceID,UserIndex,UseType,UseValue from CN_Log ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            Pbzx.Model.CN_Log model = new Pbzx.Model.CN_Log();
            DataSet ds = DbHelperSQL1.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.Username = ds.Tables[0].Rows[0]["Username"].ToString();
                if (ds.Tables[0].Rows[0]["SoftwareType"].ToString() != "")
                {
                    model.SoftwareType = int.Parse(ds.Tables[0].Rows[0]["SoftwareType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["InstallType"].ToString() != "")
                {
                    model.InstallType = int.Parse(ds.Tables[0].Rows[0]["InstallType"].ToString());
                }
                model.ProgramVer = ds.Tables[0].Rows[0]["ProgramVer"].ToString();
                model.HDSN = ds.Tables[0].Rows[0]["HDSN"].ToString();
                model.RN = ds.Tables[0].Rows[0]["RN"].ToString();
                model.IP = ds.Tables[0].Rows[0]["IP"].ToString();
                if (ds.Tables[0].Rows[0]["Port"].ToString() != "")
                {
                    model.Port = int.Parse(ds.Tables[0].Rows[0]["Port"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StartTime"].ToString() != "")
                {
                    model.StartTime = DateTime.Parse(ds.Tables[0].Rows[0]["StartTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["EndTime"].ToString() != "")
                {
                    model.EndTime = DateTime.Parse(ds.Tables[0].Rows[0]["EndTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LoginMutex"].ToString() != "")
                {
                    model.LoginMutex = int.Parse(ds.Tables[0].Rows[0]["LoginMutex"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ServiceID"].ToString() != "")
                {
                    model.ServiceID = int.Parse(ds.Tables[0].Rows[0]["ServiceID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserIndex"].ToString() != "")
                {
                    model.UserIndex = int.Parse(ds.Tables[0].Rows[0]["UserIndex"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UseType"].ToString() != "")
                {
                    model.UseType = int.Parse(ds.Tables[0].Rows[0]["UseType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UseValue"].ToString() != "")
                {
                    model.UseValue = int.Parse(ds.Tables[0].Rows[0]["UseValue"].ToString());
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
            strSql.Append("select ID,Username,SoftwareType,InstallType,ProgramVer,HDSN,RN,IP,Port,StartTime,EndTime,LoginMutex,Status,ServiceID,UserIndex,UseType,UseValue ");
            strSql.Append(" FROM CN_Log ");
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
            parameters[0].Value = "CN_Log";
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

