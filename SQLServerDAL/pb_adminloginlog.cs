using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类pb_adminloginlog。
    /// </summary>
    public class pb_adminloginlog : Ipb_adminloginlog
    {
        public pb_adminloginlog()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from pb_adminloginlog");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.BigInt)};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.pb_adminloginlog model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into pb_adminloginlog(");
            strSql.Append("log_username,log_password,log_time,log_Ip,log_state,log_stepinto,log_urlname,log_allhttp,log_country,log_city)");
            strSql.Append(" values (");
            strSql.Append("@log_username,@log_password,@log_time,@log_Ip,@log_state,@log_stepinto,@log_urlname,@log_allhttp,@log_country,@log_city)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@log_username", SqlDbType.NVarChar,30),
					new SqlParameter("@log_password", SqlDbType.NVarChar,255),
					new SqlParameter("@log_time", SqlDbType.DateTime),
					new SqlParameter("@log_Ip", SqlDbType.NVarChar,25),
					new SqlParameter("@log_state", SqlDbType.NVarChar,16),
					new SqlParameter("@log_stepinto", SqlDbType.NVarChar,20),
					new SqlParameter("@log_urlname", SqlDbType.NVarChar,50),
					new SqlParameter("@log_allhttp", SqlDbType.Text),
					new SqlParameter("@log_country", SqlDbType.VarChar,255),
					new SqlParameter("@log_city", SqlDbType.NVarChar,255)};
            parameters[0].Value = model.log_username;
            parameters[1].Value = model.log_password;
            parameters[2].Value = model.log_time;
            parameters[3].Value = model.log_Ip;
            parameters[4].Value = model.log_state;
            parameters[5].Value = model.log_stepinto;
            parameters[6].Value = model.log_urlname;
            parameters[7].Value = model.log_allhttp;
            parameters[8].Value = model.log_country;
            parameters[9].Value = model.log_city;

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
        public void Update(Pbzx.Model.pb_adminloginlog model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update pb_adminloginlog set ");
            strSql.Append("log_password=@log_password,");
            strSql.Append("log_Ip=@log_Ip,");
            strSql.Append("log_state=@log_state,");
            strSql.Append("log_stepinto=@log_stepinto,");
            strSql.Append("log_urlname=@log_urlname,");
            strSql.Append("log_allhttp=@log_allhttp,");
            strSql.Append("log_country=@log_country,");
            strSql.Append("log_city=@log_city");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.BigInt,8),
					new SqlParameter("@log_username", SqlDbType.NVarChar,30),
					new SqlParameter("@log_password", SqlDbType.NVarChar,255),
					new SqlParameter("@log_time", SqlDbType.DateTime),
					new SqlParameter("@log_Ip", SqlDbType.NVarChar,25),
					new SqlParameter("@log_state", SqlDbType.NVarChar,16),
					new SqlParameter("@log_stepinto", SqlDbType.NVarChar,20),
					new SqlParameter("@log_urlname", SqlDbType.NVarChar,50),
					new SqlParameter("@log_allhttp", SqlDbType.Text),
					new SqlParameter("@log_country", SqlDbType.VarChar,255),
					new SqlParameter("@log_city", SqlDbType.NVarChar,255)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.log_username;
            parameters[2].Value = model.log_password;
            parameters[3].Value = model.log_time;
            parameters[4].Value = model.log_Ip;
            parameters[5].Value = model.log_state;
            parameters[6].Value = model.log_stepinto;
            parameters[7].Value = model.log_urlname;
            parameters[8].Value = model.log_allhttp;
            parameters[9].Value = model.log_country;
            parameters[10].Value = model.log_city;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(long id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from pb_adminloginlog ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.BigInt)};
            parameters[0].Value = id;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.pb_adminloginlog GetModel(long id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,log_username,log_password,log_time,log_Ip,log_state,log_stepinto,log_urlname,log_allhttp,log_country,log_city from pb_adminloginlog ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.BigInt)};
            parameters[0].Value = id;

            Pbzx.Model.pb_adminloginlog model = new Pbzx.Model.pb_adminloginlog();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = long.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                model.log_username = ds.Tables[0].Rows[0]["log_username"].ToString();
                model.log_password = ds.Tables[0].Rows[0]["log_password"].ToString();
                if (ds.Tables[0].Rows[0]["log_time"].ToString() != "")
                {
                    model.log_time = DateTime.Parse(ds.Tables[0].Rows[0]["log_time"].ToString());
                }
                model.log_Ip = ds.Tables[0].Rows[0]["log_Ip"].ToString();
                model.log_state = ds.Tables[0].Rows[0]["log_state"].ToString();
                model.log_stepinto = ds.Tables[0].Rows[0]["log_stepinto"].ToString();
                model.log_urlname = ds.Tables[0].Rows[0]["log_urlname"].ToString();
                model.log_allhttp = ds.Tables[0].Rows[0]["log_allhttp"].ToString();
                model.log_country = ds.Tables[0].Rows[0]["log_country"].ToString();
                model.log_city = ds.Tables[0].Rows[0]["log_city"].ToString();
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
            strSql.Append("select id,log_username,log_password,log_time,log_Ip,log_state,log_stepinto,log_urlname,log_allhttp,log_country,log_city ");
            strSql.Append(" FROM pb_adminloginlog ");
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
            strSql.Append(" id,log_username,log_password,log_time,log_Ip,log_state,log_stepinto,log_urlname,log_allhttp,log_country,log_city ");
            strSql.Append(" FROM pb_adminloginlog ");
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
            parameters[0].Value = "pb_adminloginlog";
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

