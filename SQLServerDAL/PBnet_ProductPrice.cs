using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;
using Pbzx.Model;//请先添加引用
namespace Pbzx.SQLServerDAL
{
	/// <summary>
	/// 数据访问类PBnet_ProductPrice。
	/// </summary>
	public class PBnet_ProductPrice:IPBnet_ProductPrice
	{
		public PBnet_ProductPrice()
		{}
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int IntPriceID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PBnet_ProductPrice");
            strSql.Append(" where IntPriceID=@IntPriceID ");
            SqlParameter[] parameters = {
					new SqlParameter("@IntPriceID", SqlDbType.Int,4)};
            parameters[0].Value = IntPriceID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.PBnet_ProductPrice model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PBnet_ProductPrice(");
            strSql.Append("VarVersionType,VarUseTime,VarPrice,DatUpdateTime,VarAdmin)");
            strSql.Append(" values (");
            strSql.Append("@VarVersionType,@VarUseTime,@VarPrice,@DatUpdateTime,@VarAdmin)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@VarVersionType", SqlDbType.VarChar,50),
					new SqlParameter("@VarUseTime", SqlDbType.VarChar,50),
					new SqlParameter("@VarPrice", SqlDbType.VarChar,50),
					new SqlParameter("@DatUpdateTime", SqlDbType.DateTime),
					new SqlParameter("@VarAdmin", SqlDbType.NVarChar,20)};
            parameters[0].Value = model.VarVersionType;
            parameters[1].Value = model.VarUseTime;
            parameters[2].Value = model.VarPrice;
            parameters[3].Value = model.DatUpdateTime;
            parameters[4].Value = model.VarAdmin;

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
        public int Update(Pbzx.Model.PBnet_ProductPrice model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PBnet_ProductPrice set ");
            strSql.Append("VarVersionType=@VarVersionType,");
            strSql.Append("VarUseTime=@VarUseTime,");
            strSql.Append("VarPrice=@VarPrice,");
            strSql.Append("DatUpdateTime=@DatUpdateTime,");
            strSql.Append("VarAdmin=@VarAdmin");
            strSql.Append(" where IntPriceID=@IntPriceID ");
            SqlParameter[] parameters = {
					new SqlParameter("@IntPriceID", SqlDbType.Int,4),
					new SqlParameter("@VarVersionType", SqlDbType.VarChar,50),
					new SqlParameter("@VarUseTime", SqlDbType.VarChar,50),
					new SqlParameter("@VarPrice", SqlDbType.VarChar,50),
					new SqlParameter("@DatUpdateTime", SqlDbType.DateTime),
					new SqlParameter("@VarAdmin", SqlDbType.NVarChar,20)};
            parameters[0].Value = model.IntPriceID;
            parameters[1].Value = model.VarVersionType;
            parameters[2].Value = model.VarUseTime;
            parameters[3].Value = model.VarPrice;
            parameters[4].Value = model.DatUpdateTime;
            parameters[5].Value = model.VarAdmin;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int IntPriceID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete PBnet_ProductPrice ");
            strSql.Append(" where IntPriceID=@IntPriceID ");
            SqlParameter[] parameters = {
					new SqlParameter("@IntPriceID", SqlDbType.Int,4)};
            parameters[0].Value = IntPriceID;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.PBnet_ProductPrice GetModel(int IntPriceID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 IntPriceID,VarVersionType,VarUseTime,VarPrice,DatUpdateTime,VarAdmin from PBnet_ProductPrice ");
            strSql.Append(" where IntPriceID=@IntPriceID ");
            SqlParameter[] parameters = {
					new SqlParameter("@IntPriceID", SqlDbType.Int,4)};
            parameters[0].Value = IntPriceID;

            Pbzx.Model.PBnet_ProductPrice model = new Pbzx.Model.PBnet_ProductPrice();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["IntPriceID"].ToString() != "")
                {
                    model.IntPriceID = int.Parse(ds.Tables[0].Rows[0]["IntPriceID"].ToString());
                }
                model.VarVersionType = ds.Tables[0].Rows[0]["VarVersionType"].ToString();
                model.VarUseTime = ds.Tables[0].Rows[0]["VarUseTime"].ToString();
                model.VarPrice = ds.Tables[0].Rows[0]["VarPrice"].ToString();
                if (ds.Tables[0].Rows[0]["DatUpdateTime"].ToString() != "")
                {
                    model.DatUpdateTime = DateTime.Parse(ds.Tables[0].Rows[0]["DatUpdateTime"].ToString());
                }
                model.VarAdmin = ds.Tables[0].Rows[0]["VarAdmin"].ToString();
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
            strSql.Append("select IntPriceID,VarVersionType,VarUseTime,VarPrice,DatUpdateTime,VarAdmin ");
            strSql.Append(" FROM PBnet_ProductPrice ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere,string orderbyStr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select VarVersionType,VarUseTime,VarPrice");
            strSql.Append(" FROM PBnet_ProductPrice ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by charindex(VarUseTime,'三个月六个月一年每天')");
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
            parameters[0].Value = "PBnet_ProductPrice";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/
        #region 获取网络方式的价格
        public DataSet SelectAllProductPrice()
        {
            return SQLHelper.GetDataSet(DbHelperSQL.ConnectionString, CommandType.StoredProcedure, StoredProcedureName.P_ProductPrice.ToString(), null);
        }


        #endregion
        #endregion  成员方法
	}
}

