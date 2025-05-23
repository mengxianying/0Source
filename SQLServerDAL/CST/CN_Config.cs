using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类CN_Config。
    /// </summary>
    public class CN_Config : ICN_Config
    {
        public CN_Config()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from CN_Config");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            return DbHelperSQL1.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.CN_Config model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CN_Config(");
            strSql.Append("ConfigName,ConfigValue,ConfigDetails,ConfigFlag,Status)");
            strSql.Append(" values (");
            strSql.Append("@ConfigName,@ConfigValue,@ConfigDetails,@ConfigFlag,@Status)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@ConfigName", SqlDbType.NVarChar,64),
					new SqlParameter("@ConfigValue", SqlDbType.NVarChar,1024),
					new SqlParameter("@ConfigDetails", SqlDbType.NVarChar,1024),
					new SqlParameter("@ConfigFlag", SqlDbType.TinyInt,1),
					new SqlParameter("@Status", SqlDbType.TinyInt,1)};
            parameters[0].Value = model.ConfigName;
            parameters[1].Value = model.ConfigValue;
            parameters[2].Value = model.ConfigDetails;
            parameters[3].Value = model.ConfigFlag;
            parameters[4].Value = model.Status;

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
        public int Update(Pbzx.Model.CN_Config model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CN_Config set ");
            strSql.Append("ConfigName=@ConfigName,");
            strSql.Append("ConfigValue=@ConfigValue,");
            strSql.Append("ConfigDetails=@ConfigDetails,");
            strSql.Append("ConfigFlag=@ConfigFlag,");
            strSql.Append("Status=@Status");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@ConfigName", SqlDbType.NVarChar,64),
					new SqlParameter("@ConfigValue", SqlDbType.NVarChar,1024),
					new SqlParameter("@ConfigDetails", SqlDbType.NVarChar,1024),
					new SqlParameter("@ConfigFlag", SqlDbType.TinyInt,1),
					new SqlParameter("@Status", SqlDbType.TinyInt,1)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.ConfigName;
            parameters[2].Value = model.ConfigValue;
            parameters[3].Value = model.ConfigDetails;
            parameters[4].Value = model.ConfigFlag;
            parameters[5].Value = model.Status;

           return  DbHelperSQL1.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from CN_Config ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

          return DbHelperSQL1.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.CN_Config GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,ConfigName,ConfigValue,ConfigDetails,ConfigFlag,Status from CN_Config ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            Pbzx.Model.CN_Config model = new Pbzx.Model.CN_Config();
            DataSet ds = DbHelperSQL1.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.ConfigName = ds.Tables[0].Rows[0]["ConfigName"].ToString();
                model.ConfigValue = ds.Tables[0].Rows[0]["ConfigValue"].ToString();
                model.ConfigDetails = ds.Tables[0].Rows[0]["ConfigDetails"].ToString();
                if (ds.Tables[0].Rows[0]["ConfigFlag"].ToString() != "")
                {
                    model.ConfigFlag = int.Parse(ds.Tables[0].Rows[0]["ConfigFlag"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
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
            strSql.Append("select ID,ConfigName,ConfigValue,ConfigDetails,ConfigFlag,Status ");
            strSql.Append(" FROM CN_Config ");
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
            parameters[0].Value = "CN_Config";
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

