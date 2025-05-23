using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类CN_UserDetails。
    /// </summary>
    public class CN_UserDetails : ICN_UserDetails
    {
        public CN_UserDetails()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from CN_UserDetails");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            return DbHelperSQL1.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.CN_UserDetails model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CN_UserDetails(");
            strSql.Append("BbsName,UserName,UserTel,UserEmail,UserAddress,Status,Remarks)");
            strSql.Append(" values (");
            strSql.Append("@BbsName,@UserName,@UserTel,@UserEmail,@UserAddress,@Status,@Remarks)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@BbsName", SqlDbType.NVarChar,16),
					new SqlParameter("@UserName", SqlDbType.NVarChar,16),
					new SqlParameter("@UserTel", SqlDbType.NVarChar,32),
					new SqlParameter("@UserEmail", SqlDbType.NVarChar,64),
					new SqlParameter("@UserAddress", SqlDbType.NVarChar,128),
					new SqlParameter("@Status", SqlDbType.TinyInt,1),
					new SqlParameter("@Remarks", SqlDbType.NVarChar,255)};
            parameters[0].Value = model.BbsName;
            parameters[1].Value = model.UserName;
            parameters[2].Value = model.UserTel;
            parameters[3].Value = model.UserEmail;
            parameters[4].Value = model.UserAddress;
            parameters[5].Value = model.Status;
            parameters[6].Value = model.Remarks;

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
        public int  Update(Pbzx.Model.CN_UserDetails model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CN_UserDetails set ");
            strSql.Append("BbsName=@BbsName,");
            strSql.Append("UserName=@UserName,");
            strSql.Append("UserTel=@UserTel,");
            strSql.Append("UserEmail=@UserEmail,");
            strSql.Append("UserAddress=@UserAddress,");
            strSql.Append("Status=@Status,");
            strSql.Append("Remarks=@Remarks");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@BbsName", SqlDbType.NVarChar,16),
					new SqlParameter("@UserName", SqlDbType.NVarChar,16),
					new SqlParameter("@UserTel", SqlDbType.NVarChar,32),
					new SqlParameter("@UserEmail", SqlDbType.NVarChar,64),
					new SqlParameter("@UserAddress", SqlDbType.NVarChar,128),
					new SqlParameter("@Status", SqlDbType.TinyInt,1),
					new SqlParameter("@Remarks", SqlDbType.NVarChar,255)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.BbsName;
            parameters[2].Value = model.UserName;
            parameters[3].Value = model.UserTel;
            parameters[4].Value = model.UserEmail;
            parameters[5].Value = model.UserAddress;
            parameters[6].Value = model.Status;
            parameters[7].Value = model.Remarks;

            return DbHelperSQL1.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from CN_UserDetails ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

           return DbHelperSQL1.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.CN_UserDetails GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,BbsName,UserName,UserTel,UserEmail,UserAddress,Status,Remarks from CN_UserDetails ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            Pbzx.Model.CN_UserDetails model = new Pbzx.Model.CN_UserDetails();
            DataSet ds = DbHelperSQL1.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.BbsName = ds.Tables[0].Rows[0]["BbsName"].ToString();
                model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                model.UserTel = ds.Tables[0].Rows[0]["UserTel"].ToString();
                model.UserEmail = ds.Tables[0].Rows[0]["UserEmail"].ToString();
                model.UserAddress = ds.Tables[0].Rows[0]["UserAddress"].ToString();
                if (ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
                }
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
            strSql.Append("select ID,BbsName,UserName,UserTel,UserEmail,UserAddress,Status,Remarks ");
            strSql.Append(" FROM CN_UserDetails ");
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
            parameters[0].Value = "CN_UserDetails";
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

