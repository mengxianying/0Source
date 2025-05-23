using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类PBnet_UserProtectPwd。
    /// </summary>
    public class PBnet_UserProtectPwd : IPBnet_UserProtectPwd
    {
        public PBnet_UserProtectPwd()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PBnet_UserProtectPwd");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.PBnet_UserProtectPwd model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PBnet_UserProtectPwd(");
            strSql.Append("UserName,SecurityQuestion,Answer,CardID,Mobile,Email,type)");
            strSql.Append(" values (");
            strSql.Append("@UserName,@SecurityQuestion,@Answer,@CardID,@Mobile,@Email,@type)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@SecurityQuestion", SqlDbType.NVarChar,128),
					new SqlParameter("@Answer", SqlDbType.NVarChar,128),
					new SqlParameter("@CardID", SqlDbType.VarChar,20),
					new SqlParameter("@Mobile", SqlDbType.VarChar,20),
					new SqlParameter("@Email", SqlDbType.VarChar,50),
					new SqlParameter("@type", SqlDbType.Int,4)};
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.SecurityQuestion;
            parameters[2].Value = model.Answer;
            parameters[3].Value = model.CardID;
            parameters[4].Value = model.Mobile;
            parameters[5].Value = model.Email;
            parameters[6].Value = model.type;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return -1;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Pbzx.Model.PBnet_UserProtectPwd model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PBnet_UserProtectPwd set ");
            strSql.Append("UserName=@UserName,");
            strSql.Append("SecurityQuestion=@SecurityQuestion,");
            strSql.Append("Answer=@Answer,");
            strSql.Append("CardID=@CardID,");
            strSql.Append("Mobile=@Mobile,");
            strSql.Append("Email=@Email,");
            strSql.Append("type=@type");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@SecurityQuestion", SqlDbType.NVarChar,128),
					new SqlParameter("@Answer", SqlDbType.NVarChar,128),
					new SqlParameter("@CardID", SqlDbType.VarChar,20),
					new SqlParameter("@Mobile", SqlDbType.VarChar,20),
					new SqlParameter("@Email", SqlDbType.VarChar,50),
					new SqlParameter("@type", SqlDbType.Int,4)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.UserName;
            parameters[2].Value = model.SecurityQuestion;
            parameters[3].Value = model.Answer;
            parameters[4].Value = model.CardID;
            parameters[5].Value = model.Mobile;
            parameters[6].Value = model.Email;
            parameters[7].Value = model.type;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PBnet_UserProtectPwd ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

          return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.PBnet_UserProtectPwd GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,UserName,SecurityQuestion,Answer,CardID,Mobile,Email,type from PBnet_UserProtectPwd ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            Pbzx.Model.PBnet_UserProtectPwd model = new Pbzx.Model.PBnet_UserProtectPwd();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                model.SecurityQuestion = ds.Tables[0].Rows[0]["SecurityQuestion"].ToString();
                model.Answer = ds.Tables[0].Rows[0]["Answer"].ToString();
                model.CardID = ds.Tables[0].Rows[0]["CardID"].ToString();
                model.Mobile = ds.Tables[0].Rows[0]["Mobile"].ToString();
                model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                if (ds.Tables[0].Rows[0]["type"].ToString() != "")
                {
                    model.type = int.Parse(ds.Tables[0].Rows[0]["type"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 根据用户名得到一个对象实体
        /// </summary>
        public Pbzx.Model.PBnet_UserProtectPwd GetModelName(string UserName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,UserName,SecurityQuestion,Answer,CardID,Mobile,Email,type from PBnet_UserProtectPwd ");
            strSql.Append(" where UserName=@UserName ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,50)};
            parameters[0].Value = UserName;

            Pbzx.Model.PBnet_UserProtectPwd model = new Pbzx.Model.PBnet_UserProtectPwd();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                model.SecurityQuestion = ds.Tables[0].Rows[0]["SecurityQuestion"].ToString();
                model.Answer = ds.Tables[0].Rows[0]["Answer"].ToString();
                model.CardID = ds.Tables[0].Rows[0]["CardID"].ToString();
                model.Mobile = ds.Tables[0].Rows[0]["Mobile"].ToString();
                model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                if (ds.Tables[0].Rows[0]["type"].ToString() != "")
                {
                    model.type = int.Parse(ds.Tables[0].Rows[0]["type"].ToString());
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
            strSql.Append("select ID,UserName,SecurityQuestion,Answer,CardID,Mobile,Email,type ");
            strSql.Append(" FROM PBnet_UserProtectPwd ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
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
            strSql.Append(" ID,UserName,SecurityQuestion,Answer,CardID,Mobile,Email,type ");
            strSql.Append(" FROM PBnet_UserProtectPwd ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
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
            parameters[0].Value = "PBnet_UserProtectPwd";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  成员方法

    }
}

