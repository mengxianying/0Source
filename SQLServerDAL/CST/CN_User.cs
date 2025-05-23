using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类CN_User。
    /// </summary>
    public class CN_User : ICN_User
    {
        public CN_User()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from CN_User");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            return DbHelperSQL1.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.CN_User model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CN_User(");
            strSql.Append("Username,SoftwareType,InstallType,UserType,ExpireDate,ValidDays,CreateTime,LastPayTime,UseCount,LastLoginID,ServiceID,HDSNList,StatResult,UserRemarks,Remarks)");
            strSql.Append(" values (");
            strSql.Append("@Username,@SoftwareType,@InstallType,@UserType,@ExpireDate,@ValidDays,@CreateTime,@LastPayTime,@UseCount,@LastLoginID,@ServiceID,@HDSNList,@StatResult,@UserRemarks,@Remarks)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Username", SqlDbType.NVarChar,16),
					new SqlParameter("@SoftwareType", SqlDbType.TinyInt,1),
					new SqlParameter("@InstallType", SqlDbType.TinyInt,1),
					new SqlParameter("@UserType", SqlDbType.TinyInt,1),
					new SqlParameter("@ExpireDate", SqlDbType.SmallDateTime),
					new SqlParameter("@ValidDays", SqlDbType.SmallInt,2),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@LastPayTime", SqlDbType.DateTime),
					new SqlParameter("@UseCount", SqlDbType.Int,4),
					new SqlParameter("@LastLoginID", SqlDbType.Int,4),
					new SqlParameter("@ServiceID", SqlDbType.Int,4),
					new SqlParameter("@HDSNList", SqlDbType.NVarChar,256),
					new SqlParameter("@StatResult", SqlDbType.Int,4),
					new SqlParameter("@UserRemarks", SqlDbType.NVarChar,128),
					new SqlParameter("@Remarks", SqlDbType.NVarChar,256)};
            parameters[0].Value = model.Username;
            parameters[1].Value = model.SoftwareType;
            parameters[2].Value = model.InstallType;
            parameters[3].Value = model.UserType;
            parameters[4].Value = model.ExpireDate;
            parameters[5].Value = model.ValidDays;
            parameters[6].Value = model.CreateTime;
            parameters[7].Value = model.LastPayTime;
            parameters[8].Value = model.UseCount;
            parameters[9].Value = model.LastLoginID;
            parameters[10].Value = model.ServiceID;
            parameters[11].Value = model.HDSNList;
            parameters[12].Value = model.StatResult;
            parameters[13].Value = model.UserRemarks;
            parameters[14].Value = model.Remarks;

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
        public int Update(Pbzx.Model.CN_User model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CN_User set ");
            strSql.Append("Username=@Username,");
            strSql.Append("SoftwareType=@SoftwareType,");
            strSql.Append("UserType=@UserType,");
            strSql.Append("ExpireDate=@ExpireDate,");
            strSql.Append("ValidDays=@ValidDays,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("LastPayTime=@LastPayTime,");
            strSql.Append("UseCount=@UseCount,");
            strSql.Append("LastLoginID=@LastLoginID,");
            strSql.Append("ServiceID=@ServiceID,");
            strSql.Append("HDSNList=@HDSNList,");
            strSql.Append("StatResult=@StatResult,");
            strSql.Append("UserRemarks=@UserRemarks,");
            strSql.Append("Remarks=@Remarks");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@Username", SqlDbType.NVarChar,16),
					new SqlParameter("@SoftwareType", SqlDbType.TinyInt,1),
					new SqlParameter("@InstallType", SqlDbType.TinyInt,1),
					new SqlParameter("@UserType", SqlDbType.TinyInt,1),
					new SqlParameter("@ExpireDate", SqlDbType.SmallDateTime),
					new SqlParameter("@ValidDays", SqlDbType.SmallInt,2),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@LastPayTime", SqlDbType.DateTime),
					new SqlParameter("@UseCount", SqlDbType.Int,4),
					new SqlParameter("@LastLoginID", SqlDbType.Int,4),
					new SqlParameter("@ServiceID", SqlDbType.Int,4),
					new SqlParameter("@HDSNList", SqlDbType.NVarChar,256),
					new SqlParameter("@StatResult", SqlDbType.Int,4),
					new SqlParameter("@UserRemarks", SqlDbType.NVarChar,128),
					new SqlParameter("@Remarks", SqlDbType.NVarChar,256)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Username;
            parameters[2].Value = model.SoftwareType;
            parameters[3].Value = model.InstallType;
            parameters[4].Value = model.UserType;
            parameters[5].Value = model.ExpireDate;
            parameters[6].Value = model.ValidDays;
            parameters[7].Value = model.CreateTime;
            parameters[8].Value = model.LastPayTime;
            parameters[9].Value = model.UseCount;
            parameters[10].Value = model.LastLoginID;
            parameters[11].Value = model.ServiceID;
            parameters[12].Value = model.HDSNList;
            parameters[13].Value = model.StatResult;
            parameters[14].Value = model.UserRemarks;
            parameters[15].Value = model.Remarks;

           return DbHelperSQL1.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from CN_User ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

           return  DbHelperSQL1.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.CN_User GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,Username,SoftwareType,InstallType,UserType,ExpireDate,ValidDays,CreateTime,LastPayTime,UseCount,LastLoginID,ServiceID,HDSNList,StatResult,UserRemarks,Remarks from CN_User ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            Pbzx.Model.CN_User model = new Pbzx.Model.CN_User();
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
                if (ds.Tables[0].Rows[0]["UserType"].ToString() != "")
                {
                    model.UserType = int.Parse(ds.Tables[0].Rows[0]["UserType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ExpireDate"].ToString() != "")
                {
                    model.ExpireDate = DateTime.Parse(ds.Tables[0].Rows[0]["ExpireDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ValidDays"].ToString() != "")
                {
                    model.ValidDays = int.Parse(ds.Tables[0].Rows[0]["ValidDays"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(ds.Tables[0].Rows[0]["CreateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LastPayTime"].ToString() != "")
                {
                    model.LastPayTime = DateTime.Parse(ds.Tables[0].Rows[0]["LastPayTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UseCount"].ToString() != "")
                {
                    model.UseCount = int.Parse(ds.Tables[0].Rows[0]["UseCount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LastLoginID"].ToString() != "")
                {
                    model.LastLoginID = int.Parse(ds.Tables[0].Rows[0]["LastLoginID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ServiceID"].ToString() != "")
                {
                    model.ServiceID = int.Parse(ds.Tables[0].Rows[0]["ServiceID"].ToString());
                }
                model.HDSNList = ds.Tables[0].Rows[0]["HDSNList"].ToString();
                if (ds.Tables[0].Rows[0]["StatResult"].ToString() != "")
                {
                    model.StatResult = int.Parse(ds.Tables[0].Rows[0]["StatResult"].ToString());
                }
                model.UserRemarks = ds.Tables[0].Rows[0]["UserRemarks"].ToString();
                model.Remarks = ds.Tables[0].Rows[0]["Remarks"].ToString();
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
            strSql.Append("select ID,Username,SoftwareType,InstallType,UserType,ExpireDate,ValidDays,CreateTime,LastPayTime,UseCount,LastLoginID,ServiceID,HDSNList,StatResult,UserRemarks,Remarks ");
            strSql.Append(" FROM CN_User ");
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
            parameters[0].Value = "CN_User";
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

