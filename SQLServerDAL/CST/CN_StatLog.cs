using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类CN_StatLog。
    /// </summary>
    public class CN_StatLog : ICN_StatLog
    {
        public CN_StatLog()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from CN_StatLog");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            return DbHelperSQL1.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.CN_StatLog model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CN_StatLog(");
            strSql.Append("StartTime,EndTime,Result,ErrorInfo,EndDate,Days,Flag,StatTableName)");
            strSql.Append(" values (");
            strSql.Append("@StartTime,@EndTime,@Result,@ErrorInfo,@EndDate,@Days,@Flag,@StatTableName)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@StartTime", SqlDbType.DateTime),
					new SqlParameter("@EndTime", SqlDbType.DateTime),
					new SqlParameter("@Result", SqlDbType.VarChar,16),
					new SqlParameter("@ErrorInfo", SqlDbType.VarChar,256),
					new SqlParameter("@EndDate", SqlDbType.SmallDateTime),
					new SqlParameter("@Days", SqlDbType.TinyInt,1),
					new SqlParameter("@Flag", SqlDbType.VarChar,16),
					new SqlParameter("@StatTableName", SqlDbType.VarChar,32)};
            parameters[0].Value = model.StartTime;
            parameters[1].Value = model.EndTime;
            parameters[2].Value = model.Result;
            parameters[3].Value = model.ErrorInfo;
            parameters[4].Value = model.EndDate;
            parameters[5].Value = model.Days;
            parameters[6].Value = model.Flag;
            parameters[7].Value = model.StatTableName;

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
        public int Update(Pbzx.Model.CN_StatLog model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CN_StatLog set ");
            strSql.Append("StartTime=@StartTime,");
            strSql.Append("EndTime=@EndTime,");
            strSql.Append("Result=@Result,");
            strSql.Append("ErrorInfo=@ErrorInfo,");
            strSql.Append("EndDate=@EndDate,");
            strSql.Append("Days=@Days,");
            strSql.Append("Flag=@Flag,");
            strSql.Append("StatTableName=@StatTableName");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@StartTime", SqlDbType.DateTime),
					new SqlParameter("@EndTime", SqlDbType.DateTime),
					new SqlParameter("@Result", SqlDbType.VarChar,16),
					new SqlParameter("@ErrorInfo", SqlDbType.VarChar,256),
					new SqlParameter("@EndDate", SqlDbType.SmallDateTime),
					new SqlParameter("@Days", SqlDbType.TinyInt,1),
					new SqlParameter("@Flag", SqlDbType.VarChar,16),
					new SqlParameter("@StatTableName", SqlDbType.VarChar,32)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.StartTime;
            parameters[2].Value = model.EndTime;
            parameters[3].Value = model.Result;
            parameters[4].Value = model.ErrorInfo;
            parameters[5].Value = model.EndDate;
            parameters[6].Value = model.Days;
            parameters[7].Value = model.Flag;
            parameters[8].Value = model.StatTableName;

           return DbHelperSQL1.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int  Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from CN_StatLog ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

           return DbHelperSQL1.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.CN_StatLog GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,StartTime,EndTime,Result,ErrorInfo,EndDate,Days,Flag,StatTableName from CN_StatLog ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            Pbzx.Model.CN_StatLog model = new Pbzx.Model.CN_StatLog();
            DataSet ds = DbHelperSQL1.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StartTime"].ToString() != "")
                {
                    model.StartTime = DateTime.Parse(ds.Tables[0].Rows[0]["StartTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["EndTime"].ToString() != "")
                {
                    model.EndTime = DateTime.Parse(ds.Tables[0].Rows[0]["EndTime"].ToString());
                }
                model.Result = ds.Tables[0].Rows[0]["Result"].ToString();
                model.ErrorInfo = ds.Tables[0].Rows[0]["ErrorInfo"].ToString();
                if (ds.Tables[0].Rows[0]["EndDate"].ToString() != "")
                {
                    model.EndDate = DateTime.Parse(ds.Tables[0].Rows[0]["EndDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Days"].ToString() != "")
                {
                    model.Days = int.Parse(ds.Tables[0].Rows[0]["Days"].ToString());
                }
                model.Flag = ds.Tables[0].Rows[0]["Flag"].ToString();
                model.StatTableName = ds.Tables[0].Rows[0]["StatTableName"].ToString();
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
            strSql.Append("select ID,StartTime,EndTime,Result,ErrorInfo,EndDate,Days,Flag,StatTableName ");
            strSql.Append(" FROM CN_StatLog ");
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
            parameters[0].Value = "CN_StatLog";
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

