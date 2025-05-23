using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类PBnet_WebLog。
    /// </summary>
    public class PBnet_WebLog 
    {
        public PBnet_WebLog()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PBnet_WebLog");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.PBnet_WebLog model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PBnet_WebLog(");
            strSql.Append("ActionType,Detail,Operator,UserIP,ActionTime)");
            strSql.Append(" values (");
            strSql.Append("@ActionType,@Detail,@Operator,@UserIP,@ActionTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@ActionType", SqlDbType.VarChar,100),
					new SqlParameter("@Detail", SqlDbType.VarChar,500),
					new SqlParameter("@Operator", SqlDbType.VarChar,50),
					new SqlParameter("@UserIP", SqlDbType.VarChar,20),
					new SqlParameter("@ActionTime", SqlDbType.SmallDateTime)};
            parameters[0].Value = model.ActionType;
            parameters[1].Value = model.Detail;
            parameters[2].Value = model.Operator;
            parameters[3].Value = model.UserIP;
            parameters[4].Value = model.ActionTime;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        public int Update(Pbzx.Model.PBnet_WebLog model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PBnet_WebLog set ");
            strSql.Append("ActionType=@ActionType,");
            strSql.Append("Detail=@Detail,");
            strSql.Append("Operator=@Operator,");
            strSql.Append("UserIP=@UserIP,");
            strSql.Append("ActionTime=@ActionTime");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@ActionType", SqlDbType.VarChar,100),
					new SqlParameter("@Detail", SqlDbType.VarChar,500),
					new SqlParameter("@Operator", SqlDbType.VarChar,50),
					new SqlParameter("@UserIP", SqlDbType.VarChar,20),
					new SqlParameter("@ActionTime", SqlDbType.SmallDateTime)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.ActionType;
            parameters[2].Value = model.Detail;
            parameters[3].Value = model.Operator;
            parameters[4].Value = model.UserIP;
            parameters[5].Value = model.ActionTime;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete PBnet_WebLog ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.PBnet_WebLog GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,ActionType,Detail,Operator,UserIP,ActionTime from PBnet_WebLog ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            Pbzx.Model.PBnet_WebLog model = new Pbzx.Model.PBnet_WebLog();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.ActionType = ds.Tables[0].Rows[0]["ActionType"].ToString();
                model.Detail = ds.Tables[0].Rows[0]["Detail"].ToString();
                model.Operator = ds.Tables[0].Rows[0]["Operator"].ToString();
                model.UserIP = ds.Tables[0].Rows[0]["UserIP"].ToString();
                if (ds.Tables[0].Rows[0]["ActionTime"].ToString() != "")
                {
                    model.ActionTime = DateTime.Parse(ds.Tables[0].Rows[0]["ActionTime"].ToString());
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
            strSql.Append("select ID,ActionType,Detail,Operator,UserIP,ActionTime ");
            strSql.Append(" FROM PBnet_WebLog ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
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
            parameters[0].Value = "PBnet_WebLog";
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

