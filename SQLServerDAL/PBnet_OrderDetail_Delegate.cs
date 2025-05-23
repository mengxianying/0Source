using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;//�����������
using Pbzx.Model;//�����������
namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// ���ݷ�����PBnet_OrderDetail_Delegate��
    /// </summary>
    public class PBnet_OrderDetail_Delegate : IPBnet_OrderDetail_Delegate
    {
        public PBnet_OrderDetail_Delegate()
        { }
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(long OrderDetailID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PBnet_OrderDetail_Delegate");
            strSql.Append(" where OrderDetailID=@OrderDetailID ");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderDetailID", SqlDbType.BigInt)};
            parameters[0].Value = OrderDetailID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(Pbzx.Model.PBnet_OrderDetail_Delegate model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PBnet_OrderDetail_Delegate(");
            strSql.Append("OrderID,ProductID,Quatity,RegType,Serial,UseTime)");
            strSql.Append(" values (");
            strSql.Append("@OrderID,@ProductID,@Quatity,@RegType,@Serial,@UseTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.VarChar,50),
					new SqlParameter("@ProductID", SqlDbType.Int,4),
					new SqlParameter("@Quatity", SqlDbType.SmallInt,2),
					new SqlParameter("@RegType", SqlDbType.VarChar,20),
					new SqlParameter("@Serial", SqlDbType.VarChar,27),
					new SqlParameter("@UseTime", SqlDbType.VarChar,50)};
            parameters[0].Value = model.OrderID;
            parameters[1].Value = model.ProductID;
            parameters[2].Value = model.Quatity;
            parameters[3].Value = model.RegType;
            parameters[4].Value = model.Serial;
            parameters[5].Value = model.UseTime;

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
        /// ����һ������
        /// </summary>
        public void Update(Pbzx.Model.PBnet_OrderDetail_Delegate model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PBnet_OrderDetail_Delegate set ");
            strSql.Append("OrderID=@OrderID,");
            strSql.Append("ProductID=@ProductID,");
            strSql.Append("Quatity=@Quatity,");
            strSql.Append("RegType=@RegType,");
            strSql.Append("Serial=@Serial,");
            strSql.Append("UseTime=@UseTime");
            strSql.Append(" where OrderDetailID=@OrderDetailID ");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderDetailID", SqlDbType.BigInt,8),
					new SqlParameter("@OrderID", SqlDbType.VarChar,50),
					new SqlParameter("@ProductID", SqlDbType.Int,4),
					new SqlParameter("@Quatity", SqlDbType.SmallInt,2),
					new SqlParameter("@RegType", SqlDbType.VarChar,20),
					new SqlParameter("@Serial", SqlDbType.VarChar,27),
					new SqlParameter("@UseTime", SqlDbType.VarChar,50)};
            parameters[0].Value = model.OrderDetailID;
            parameters[1].Value = model.OrderID;
            parameters[2].Value = model.ProductID;
            parameters[3].Value = model.Quatity;
            parameters[4].Value = model.RegType;
            parameters[5].Value = model.Serial;
            parameters[6].Value = model.UseTime;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(long OrderDetailID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PBnet_OrderDetail_Delegate ");
            strSql.Append(" where OrderDetailID=@OrderDetailID ");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderDetailID", SqlDbType.BigInt)};
            parameters[0].Value = OrderDetailID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Pbzx.Model.PBnet_OrderDetail_Delegate GetModel(long OrderDetailID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 OrderDetailID,OrderID,ProductID,Quatity,RegType,Serial,UseTime from PBnet_OrderDetail_Delegate ");
            strSql.Append(" where OrderDetailID=@OrderDetailID ");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderDetailID", SqlDbType.BigInt)};
            parameters[0].Value = OrderDetailID;

            Pbzx.Model.PBnet_OrderDetail_Delegate model = new Pbzx.Model.PBnet_OrderDetail_Delegate();
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
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select OrderDetailID,OrderID,ProductID,Quatity,RegType,Serial,UseTime ");
            strSql.Append(" FROM PBnet_OrderDetail_Delegate ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// ���ǰ��������
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" OrderDetailID,OrderID,ProductID,Quatity,RegType,Serial,UseTime ");
            strSql.Append(" FROM PBnet_OrderDetail_Delegate ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// ��ҳ��ȡ�����б�
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
            parameters[0].Value = "PBnet_OrderDetail_Delegate";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  ��Ա����

        public DataSet SelectOrderDetailDelegateByOrderID(string orderID)
        {
            SqlParameter parm = new SqlParameter("@OrderID", orderID);

            return SQLHelper.GetDataSet(DbHelperSQL.ConnectionString, CommandType.StoredProcedure, StoredProcedureName.sp_SelectOrderDetailDelegateByOrderID.ToString(), parm);
        }
    }
}

