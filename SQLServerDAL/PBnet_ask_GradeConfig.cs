using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类PBnet_ask_GradeConfig。
    /// </summary>
    public class PBnet_ask_GradeConfig : IPBnet_ask_GradeConfig
    {
        public PBnet_ask_GradeConfig()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PBnet_ask_GradeConfig");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.PBnet_ask_GradeConfig model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PBnet_ask_GradeConfig(");
            strSql.Append("GradeName,MinPoint,MaxPoint,GradeID)");
            strSql.Append(" values (");
            strSql.Append("@GradeName,@MinPoint,@MaxPoint,@GradeID)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@GradeName", SqlDbType.NVarChar,50),
					new SqlParameter("@MinPoint", SqlDbType.Int,4),
					new SqlParameter("@MaxPoint", SqlDbType.Int,4),
					new SqlParameter("@GradeID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.GradeName;
            parameters[1].Value = model.MinPoint;
            parameters[2].Value = model.MaxPoint;
            parameters[3].Value = model.GradeID;

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
        public int Update(Pbzx.Model.PBnet_ask_GradeConfig model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PBnet_ask_GradeConfig set ");
            strSql.Append("GradeName=@GradeName,");
            strSql.Append("MinPoint=@MinPoint,");            
            strSql.Append("MaxPoint=@MaxPoint,");
            strSql.Append("GradeID=@GradeID");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@GradeName", SqlDbType.NVarChar,50),
					new SqlParameter("@MinPoint", SqlDbType.Int,4),
					new SqlParameter("@MaxPoint", SqlDbType.Int,4),
					new SqlParameter("@GradeID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.GradeName;
            parameters[2].Value = model.MinPoint;
            parameters[3].Value = model.MaxPoint;
            parameters[4].Value = model.GradeID;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PBnet_ask_GradeConfig ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.PBnet_ask_GradeConfig GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,GradeName,MinPoint,MaxPoint,GradeID from PBnet_ask_GradeConfig ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            Pbzx.Model.PBnet_ask_GradeConfig model = new Pbzx.Model.PBnet_ask_GradeConfig();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.GradeName = ds.Tables[0].Rows[0]["GradeName"].ToString();
                if (ds.Tables[0].Rows[0]["MinPoint"].ToString() != "")
                {
                    model.MinPoint = int.Parse(ds.Tables[0].Rows[0]["MinPoint"].ToString());
                }
                if (ds.Tables[0].Rows[0]["MaxPoint"].ToString() != "")
                {
                    model.MaxPoint = int.Parse(ds.Tables[0].Rows[0]["MaxPoint"].ToString());
                }
                model.GradeID = ds.Tables[0].Rows[0]["GradeID"].ToString();
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
            strSql.Append("select ID,GradeName,MinPoint,MaxPoint,GradeID ");
            strSql.Append(" FROM PBnet_ask_GradeConfig ");
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
            strSql.Append(" ID,GradeName,MinPoint,MaxPoint,GradeID ");
            strSql.Append(" FROM PBnet_ask_GradeConfig ");
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
            parameters[0].Value = "PBnet_ask_GradeConfig";
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

