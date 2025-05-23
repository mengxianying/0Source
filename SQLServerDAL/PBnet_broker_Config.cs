using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类PBnet_broker_Config。
    /// </summary>
    public class PBnet_broker_Config : IPBnet_broker_Config
    {
        public PBnet_broker_Config()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PBnet_broker_Config");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.PBnet_broker_Config model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PBnet_broker_Config(");
            strSql.Append("Discount_grade,Discount_gradeName,Discount_rate,Min_tradeMoney)");
            strSql.Append(" values (");
            strSql.Append("@Discount_grade,@Discount_gradeName,@Discount_rate,@Min_tradeMoney)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Discount_grade", SqlDbType.TinyInt,1),
					new SqlParameter("@Discount_gradeName", SqlDbType.VarChar,50),
					new SqlParameter("@Discount_rate", SqlDbType.TinyInt,1),
					new SqlParameter("@Min_tradeMoney", SqlDbType.Money,8)};
            parameters[0].Value = model.Discount_grade;
            parameters[1].Value = model.Discount_gradeName;
            parameters[2].Value = model.Discount_rate;
            parameters[3].Value = model.Min_tradeMoney;

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
        public int Update(Pbzx.Model.PBnet_broker_Config model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PBnet_broker_Config set ");
            strSql.Append("Discount_grade=@Discount_grade,");
            strSql.Append("Discount_gradeName=@Discount_gradeName,");
            strSql.Append("Discount_rate=@Discount_rate,");
            strSql.Append("Min_tradeMoney=@Min_tradeMoney");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4),
					new SqlParameter("@Discount_grade", SqlDbType.TinyInt,1),
					new SqlParameter("@Discount_gradeName", SqlDbType.VarChar,50),
					new SqlParameter("@Discount_rate", SqlDbType.TinyInt,1),
					new SqlParameter("@Min_tradeMoney", SqlDbType.Money,8)};
            parameters[0].Value = model.Id;
            parameters[1].Value = model.Discount_grade;
            parameters[2].Value = model.Discount_gradeName;
            parameters[3].Value = model.Discount_rate;
            parameters[4].Value = model.Min_tradeMoney;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PBnet_broker_Config ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.PBnet_broker_Config GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,Discount_grade,Discount_gradeName,Discount_rate,Min_tradeMoney from PBnet_broker_Config ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            Pbzx.Model.PBnet_broker_Config model = new Pbzx.Model.PBnet_broker_Config();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Discount_grade"].ToString() != "")
                {
                    model.Discount_grade = int.Parse(ds.Tables[0].Rows[0]["Discount_grade"].ToString());
                }
                model.Discount_gradeName = ds.Tables[0].Rows[0]["Discount_gradeName"].ToString();
                if (ds.Tables[0].Rows[0]["Discount_rate"].ToString() != "")
                {
                    model.Discount_rate = int.Parse(ds.Tables[0].Rows[0]["Discount_rate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Min_tradeMoney"].ToString() != "")
                {
                    model.Min_tradeMoney = decimal.Parse(ds.Tables[0].Rows[0]["Min_tradeMoney"].ToString());
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
            strSql.Append("select Id,Discount_grade,Discount_gradeName,Discount_rate,Min_tradeMoney ");
            strSql.Append(" FROM PBnet_broker_Config ");
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
            strSql.Append(" Id,Discount_grade,Discount_gradeName,Discount_rate,Min_tradeMoney ");
            strSql.Append(" FROM PBnet_broker_Config ");
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
            parameters[0].Value = "PBnet_broker_Config";
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

