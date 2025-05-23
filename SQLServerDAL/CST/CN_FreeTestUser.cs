using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类CN_FreeTestUser。
    /// </summary>
    public class CN_FreeTestUser : ICN_FreeTestUser
    {
        public CN_FreeTestUser()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from CN_FreeTestUser");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            return DbHelperSQL1.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.CN_FreeTestUser model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CN_FreeTestUser(");
            strSql.Append("HDSN,DiskCVol,SoftwareType,InstallType,FirstLoginTime,LastLoginTime,UseCount,Status,LastLoginID,ServiceID,LastLoginIP)");
            strSql.Append(" values (");
            strSql.Append("@HDSN,@DiskCVol,@SoftwareType,@InstallType,@FirstLoginTime,@LastLoginTime,@UseCount,@Status,@LastLoginID,@ServiceID,@LastLoginIP)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@HDSN", SqlDbType.Char,16),
					new SqlParameter("@DiskCVol", SqlDbType.NVarChar,16),
					new SqlParameter("@SoftwareType", SqlDbType.TinyInt,1),
					new SqlParameter("@InstallType", SqlDbType.TinyInt,1),
					new SqlParameter("@FirstLoginTime", SqlDbType.DateTime),
					new SqlParameter("@LastLoginTime", SqlDbType.DateTime),
					new SqlParameter("@UseCount", SqlDbType.Int,4),
					new SqlParameter("@Status", SqlDbType.TinyInt,1),
					new SqlParameter("@LastLoginID", SqlDbType.Int,4),
					new SqlParameter("@ServiceID", SqlDbType.Int,4),
					new SqlParameter("@LastLoginIP", SqlDbType.NVarChar,16)};
            parameters[0].Value = model.HDSN;
            parameters[1].Value = model.DiskCVol;
            parameters[2].Value = model.SoftwareType;
            parameters[3].Value = model.InstallType;
            parameters[4].Value = model.FirstLoginTime;
            parameters[5].Value = model.LastLoginTime;
            parameters[6].Value = model.UseCount;
            parameters[7].Value = model.Status;
            parameters[8].Value = model.LastLoginID;
            parameters[9].Value = model.ServiceID;
            parameters[10].Value = model.LastLoginIP;

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
        public int Update(Pbzx.Model.CN_FreeTestUser model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CN_FreeTestUser set ");
            strSql.Append("HDSN=@HDSN,");
            strSql.Append("SoftwareType=@SoftwareType,");
            strSql.Append("InstallType=@InstallType,");
            strSql.Append("FirstLoginTime=@FirstLoginTime,");
            strSql.Append("LastLoginTime=@LastLoginTime,");
            strSql.Append("UseCount=@UseCount,");
            strSql.Append("Status=@Status,");
            strSql.Append("ServiceID=@ServiceID,");
            strSql.Append("LastLoginIP=@LastLoginIP");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@HDSN", SqlDbType.Char,16),
					new SqlParameter("@DiskCVol", SqlDbType.NVarChar,16),
					new SqlParameter("@SoftwareType", SqlDbType.TinyInt,1),
					new SqlParameter("@InstallType", SqlDbType.TinyInt,1),
					new SqlParameter("@FirstLoginTime", SqlDbType.DateTime),
					new SqlParameter("@LastLoginTime", SqlDbType.DateTime),
					new SqlParameter("@UseCount", SqlDbType.Int,4),
					new SqlParameter("@Status", SqlDbType.TinyInt,1),
					new SqlParameter("@LastLoginID", SqlDbType.Int,4),
					new SqlParameter("@ServiceID", SqlDbType.Int,4),
					new SqlParameter("@LastLoginIP", SqlDbType.NVarChar,16)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.HDSN;
            parameters[2].Value = model.DiskCVol;
            parameters[3].Value = model.SoftwareType;
            parameters[4].Value = model.InstallType;
            parameters[5].Value = model.FirstLoginTime;
            parameters[6].Value = model.LastLoginTime;
            parameters[7].Value = model.UseCount;
            parameters[8].Value = model.Status;
            parameters[9].Value = model.LastLoginID;
            parameters[10].Value = model.ServiceID;
            parameters[11].Value = model.LastLoginIP;

          return  DbHelperSQL1.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from CN_FreeTestUser ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

         return DbHelperSQL1.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.CN_FreeTestUser GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,HDSN,DiskCVol,SoftwareType,InstallType,FirstLoginTime,LastLoginTime,UseCount,Status,LastLoginID,ServiceID,LastLoginIP from CN_FreeTestUser ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            Pbzx.Model.CN_FreeTestUser model = new Pbzx.Model.CN_FreeTestUser();
            DataSet ds = DbHelperSQL1.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.HDSN = ds.Tables[0].Rows[0]["HDSN"].ToString();
                model.DiskCVol = ds.Tables[0].Rows[0]["DiskCVol"].ToString();
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
            strSql.Append("select ID,HDSN,DiskCVol,SoftwareType,InstallType,FirstLoginTime,LastLoginTime,UseCount,Status,LastLoginID,ServiceID,LastLoginIP ");
            strSql.Append(" FROM CN_FreeTestUser ");
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
            parameters[0].Value = "CN_FreeTestUser";
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

