using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using Pbzx.Model;//请先添加引用
namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类PBnet_OrderDetail。
    /// </summary>
    public class PBnet_OrderDetail
    {
        public PBnet_OrderDetail()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long OrderDetailID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PBnet_OrderDetail");
            strSql.Append(" where OrderDetailID=@OrderDetailID ");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderDetailID", SqlDbType.BigInt)};
            parameters[0].Value = OrderDetailID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.PBnet_OrderDetail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PBnet_OrderDetail(");
            strSql.Append("OrderID,ProductID,Quatity,RegType,Serial,UseTime,State,TempOpen)");
            strSql.Append(" values (");
            strSql.Append("@OrderID,@ProductID,@Quatity,@RegType,@Serial,@UseTime,@State,@TempOpen)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.VarChar,50),
					new SqlParameter("@ProductID", SqlDbType.Int,4),
					new SqlParameter("@Quatity", SqlDbType.SmallInt,2),
					new SqlParameter("@RegType", SqlDbType.VarChar,100),
					new SqlParameter("@Serial", SqlDbType.VarChar,254),
					new SqlParameter("@UseTime", SqlDbType.VarChar,50),
					new SqlParameter("@State", SqlDbType.Int,4),
                    new SqlParameter("@TempOpen", SqlDbType.SmallInt,2)};
            parameters[0].Value = model.OrderID;
            parameters[1].Value = model.ProductID;
            parameters[2].Value = model.Quatity;
            parameters[3].Value = model.RegType;
            parameters[4].Value = model.Serial;
            parameters[5].Value = model.UseTime;
            parameters[6].Value = model.State;
            parameters[7].Value = model.TempOpen;
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
        public void Update(Pbzx.Model.PBnet_OrderDetail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PBnet_OrderDetail set ");
            strSql.Append("ProductID=@ProductID,");
            strSql.Append("Quatity=@Quatity,");
            strSql.Append("RegType=@RegType,");
            strSql.Append("Serial=@Serial,");
            strSql.Append("UseTime=@UseTime,");
            strSql.Append("State=@State,");
            strSql.Append("TempOpen=@TempOpen");
            strSql.Append(" where OrderDetailID=@OrderDetailID ");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderDetailID", SqlDbType.BigInt,8),
					new SqlParameter("@OrderID", SqlDbType.VarChar,50),
					new SqlParameter("@ProductID", SqlDbType.Int,4),
					new SqlParameter("@Quatity", SqlDbType.SmallInt,2),
					new SqlParameter("@RegType", SqlDbType.VarChar,100),
					new SqlParameter("@Serial", SqlDbType.VarChar,254),
					new SqlParameter("@UseTime", SqlDbType.VarChar,50),
					new SqlParameter("@State", SqlDbType.Int,4),
                    new SqlParameter("@TempOpen", SqlDbType.SmallInt,2)};
            parameters[0].Value = model.OrderDetailID;
            parameters[1].Value = model.OrderID;
            parameters[2].Value = model.ProductID;
            parameters[3].Value = model.Quatity;
            parameters[4].Value = model.RegType;
            parameters[5].Value = model.Serial;
            parameters[6].Value = model.UseTime;
            parameters[7].Value = model.State;
            parameters[8].Value = model.TempOpen;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(long OrderDetailID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PBnet_OrderDetail ");
            strSql.Append(" where OrderDetailID=@OrderDetailID ");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderDetailID", SqlDbType.BigInt)};
            parameters[0].Value = OrderDetailID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.PBnet_OrderDetail GetModel(long OrderDetailID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 OrderDetailID,OrderID,ProductID,Quatity,RegType,Serial,UseTime,State,TempOpen from PBnet_OrderDetail ");
            strSql.Append(" where OrderDetailID=@OrderDetailID ");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderDetailID", SqlDbType.BigInt)};
            parameters[0].Value = OrderDetailID;

            Pbzx.Model.PBnet_OrderDetail model = new Pbzx.Model.PBnet_OrderDetail();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["OrderDetailID"].ToString() != "")
                {
                    model.OrderDetailID = long.Parse(ds.Tables[0].Rows[0]["OrderDetailID"].ToString());
                }
                model.OrderID = ds.Tables[0].Rows[0]["OrderID"].ToString();
                if (ds.Tables[0].Rows[0]["ProductID"].ToString() != "")
                {
                    model.ProductID = int.Parse(ds.Tables[0].Rows[0]["ProductID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Quatity"].ToString() != "")
                {
                    model.Quatity = int.Parse(ds.Tables[0].Rows[0]["Quatity"].ToString());
                }
                model.RegType = ds.Tables[0].Rows[0]["RegType"].ToString();
                model.Serial = ds.Tables[0].Rows[0]["Serial"].ToString();
                model.UseTime = ds.Tables[0].Rows[0]["UseTime"].ToString();
                if (ds.Tables[0].Rows[0]["State"].ToString() != "")
                {
                    model.State = int.Parse(ds.Tables[0].Rows[0]["State"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TempOpen"].ToString() != "")
                {
                    model.TempOpen = int.Parse(ds.Tables[0].Rows[0]["TempOpen"].ToString());
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
            strSql.Append("select OrderDetailID,OrderID,ProductID,Quatity,RegType,Serial,UseTime,State,TempOpen ");
            strSql.Append(" FROM PBnet_OrderDetail ");
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
            strSql.Append(" OrderDetailID,OrderID,ProductID,Quatity,RegType,Serial,UseTime,State,TempOpen ");
            strSql.Append(" FROM PBnet_OrderDetail ");
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
            parameters[0].Value = "PBnet_OrderDetail";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  成员方法

        public DataSet SelectOrderDetailByOrderID(string orderID)
        {
            //修改，将存储过程替换成sql语句
            //SqlParameter parm = new SqlParameter("@OrderID", orderID);

            //return SQLHelper.GetDataSet(DbHelperSQL.ConnectionString, CommandType.StoredProcedure, StoredProcedureName.sp_SelectOrderDetailByOrderID.ToString(), parm);

            string sql = "SELECT t1.*, t2.* FROM PBnet_OrderDetail t1 INNER JOIN PBnet_Product t2 ON t1.ProductID = t2.pb_SoftID WHERE (t1.OrderID = '" + orderID + "')";
            return DbHelperSQL.Query(sql);
        }
    }
}

