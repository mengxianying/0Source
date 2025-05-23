using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//�����������
using Pbzx.Model;
using System.Collections.Generic;
using Pbzx.Common;
namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// ���ݷ�����PBnet_Orders��
    /// </summary>
    public class PBnet_Orders : DBAccess
    {
        public PBnet_Orders()
        { }
        #region  ��Ա����

        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(string OrderID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PBnet_Orders");
            strSql.Append(" where OrderID=@OrderID ");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.VarChar,50)};
            parameters[0].Value = OrderID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// ����һ������
        /// </summary>
        public void Add(Pbzx.Model.PBnet_Orders model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PBnet_Orders(");
            strSql.Append("OrderID,UserID,UserName,OrderDate,ReceiverName,ReceiverAddress,ReceiverPostalCode,ReceiverPhone,ReceiverEmail,TotalProductPrice,PortPrice,HasPayedPrice,PortTypeID,PortTypeName,PayTypeID,PayTypeName,TipID,TipName,UpdateStaticDate,c_memo1,c_memo2,Remark,Result,Type,IsPay,BrokerName,IsCancel,OrderClass,UserIP)");
            strSql.Append(" values (");
            strSql.Append("@OrderID,@UserID,@UserName,@OrderDate,@ReceiverName,@ReceiverAddress,@ReceiverPostalCode,@ReceiverPhone,@ReceiverEmail,@TotalProductPrice,@PortPrice,@HasPayedPrice,@PortTypeID,@PortTypeName,@PayTypeID,@PayTypeName,@TipID,@TipName,@UpdateStaticDate,@c_memo1,@c_memo2,@Remark,@Result,@Type,@IsPay,@BrokerName,@IsCancel,@OrderClass,@UserIP)");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.VarChar,50),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.NVarChar,100),
					new SqlParameter("@OrderDate", SqlDbType.SmallDateTime),
					new SqlParameter("@ReceiverName", SqlDbType.NVarChar,100),
					new SqlParameter("@ReceiverAddress", SqlDbType.NVarChar,200),
					new SqlParameter("@ReceiverPostalCode", SqlDbType.VarChar,10),
					new SqlParameter("@ReceiverPhone", SqlDbType.VarChar,50),
					new SqlParameter("@ReceiverEmail", SqlDbType.VarChar,50),
					new SqlParameter("@TotalProductPrice", SqlDbType.Money,8),
					new SqlParameter("@PortPrice", SqlDbType.Money,8),
					new SqlParameter("@HasPayedPrice", SqlDbType.Money,8),
					new SqlParameter("@PortTypeID", SqlDbType.SmallInt,2),
					new SqlParameter("@PortTypeName", SqlDbType.NVarChar,100),
					new SqlParameter("@PayTypeID", SqlDbType.SmallInt,2),
					new SqlParameter("@PayTypeName", SqlDbType.NVarChar,100),
					new SqlParameter("@TipID", SqlDbType.SmallInt,2),
					new SqlParameter("@TipName", SqlDbType.NVarChar,100),
					new SqlParameter("@UpdateStaticDate", SqlDbType.SmallDateTime),
					new SqlParameter("@c_memo1", SqlDbType.VarChar,200),
					new SqlParameter("@c_memo2", SqlDbType.VarChar,200),
					new SqlParameter("@Remark", SqlDbType.NVarChar,255),
					new SqlParameter("@Result", SqlDbType.NVarChar,255),
					new SqlParameter("@Type", SqlDbType.SmallInt,2),
					new SqlParameter("@IsPay", SqlDbType.SmallInt,2),
					new SqlParameter("@BrokerName", SqlDbType.VarChar,50),
					new SqlParameter("@IsCancel", SqlDbType.SmallInt,2),
					new SqlParameter("@OrderClass", SqlDbType.SmallInt,2),
					new SqlParameter("@UserIP", SqlDbType.VarChar,20)};
            parameters[0].Value = model.OrderID;
            parameters[1].Value = model.UserID;
            parameters[2].Value = model.UserName;
            parameters[3].Value = model.OrderDate;
            parameters[4].Value = model.ReceiverName;
            parameters[5].Value = model.ReceiverAddress;
            parameters[6].Value = model.ReceiverPostalCode;
            parameters[7].Value = model.ReceiverPhone;
            parameters[8].Value = model.ReceiverEmail;
            parameters[9].Value = model.TotalProductPrice;
            parameters[10].Value = model.PortPrice;
            parameters[11].Value = model.HasPayedPrice;
            parameters[12].Value = model.PortTypeID;
            parameters[13].Value = model.PortTypeName;
            parameters[14].Value = model.PayTypeID;
            parameters[15].Value = model.PayTypeName;
            parameters[16].Value = model.TipID;
            parameters[17].Value = model.TipName;
            parameters[18].Value = model.UpdateStaticDate;
            parameters[19].Value = model.c_memo1;
            parameters[20].Value = model.c_memo2;
            parameters[21].Value = model.Remark;
            parameters[22].Value = model.Result;
            parameters[23].Value = model.Type;
            parameters[24].Value = model.IsPay;
            parameters[25].Value = model.BrokerName;
            parameters[26].Value = model.IsCancel;
            parameters[27].Value = model.OrderClass;
            parameters[28].Value = model.UserIP;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// ����һ������
        /// </summary>
        public int Update(Pbzx.Model.PBnet_Orders model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PBnet_Orders set ");
            strSql.Append("UserID=@UserID,");
            strSql.Append("UserName=@UserName,");
            strSql.Append("ReceiverName=@ReceiverName,");
            strSql.Append("ReceiverAddress=@ReceiverAddress,");
            strSql.Append("ReceiverPostalCode=@ReceiverPostalCode,");
            strSql.Append("ReceiverPhone=@ReceiverPhone,");
            strSql.Append("ReceiverEmail=@ReceiverEmail,");
            strSql.Append("TotalProductPrice=@TotalProductPrice,");
            strSql.Append("PortPrice=@PortPrice,");
            strSql.Append("HasPayedPrice=@HasPayedPrice,");
            strSql.Append("PortTypeID=@PortTypeID,");
            strSql.Append("PortTypeName=@PortTypeName,");
            strSql.Append("PayTypeID=@PayTypeID,");
            strSql.Append("PayTypeName=@PayTypeName,");
            strSql.Append("TipID=@TipID,");
            strSql.Append("TipName=@TipName,");
            strSql.Append("UpdateStaticDate=@UpdateStaticDate,");
            strSql.Append("c_memo1=@c_memo1,");
            strSql.Append("c_memo2=@c_memo2,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("Result=@Result,");
            strSql.Append("Type=@Type,");
            strSql.Append("IsPay=@IsPay,");
            strSql.Append("BrokerName=@BrokerName,");
            strSql.Append("IsCancel=@IsCancel,");
            strSql.Append("OrderClass=@OrderClass,");
            strSql.Append("UserIP=@UserIP");
            strSql.Append(" where OrderID=@OrderID ");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.VarChar,50),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.NVarChar,100),
					new SqlParameter("@OrderDate", SqlDbType.SmallDateTime),
					new SqlParameter("@ReceiverName", SqlDbType.NVarChar,100),
					new SqlParameter("@ReceiverAddress", SqlDbType.NVarChar,200),
					new SqlParameter("@ReceiverPostalCode", SqlDbType.VarChar,10),
					new SqlParameter("@ReceiverPhone", SqlDbType.VarChar,50),
					new SqlParameter("@ReceiverEmail", SqlDbType.VarChar,50),
					new SqlParameter("@TotalProductPrice", SqlDbType.Money,8),
					new SqlParameter("@PortPrice", SqlDbType.Money,8),
					new SqlParameter("@HasPayedPrice", SqlDbType.Money,8),
					new SqlParameter("@PortTypeID", SqlDbType.SmallInt,2),
					new SqlParameter("@PortTypeName", SqlDbType.NVarChar,100),
					new SqlParameter("@PayTypeID", SqlDbType.SmallInt,2),
					new SqlParameter("@PayTypeName", SqlDbType.NVarChar,100),
					new SqlParameter("@TipID", SqlDbType.SmallInt,2),
					new SqlParameter("@TipName", SqlDbType.NVarChar,100),
					new SqlParameter("@UpdateStaticDate", SqlDbType.SmallDateTime),
					new SqlParameter("@c_memo1", SqlDbType.VarChar,200),
					new SqlParameter("@c_memo2", SqlDbType.VarChar,200),
					new SqlParameter("@Remark", SqlDbType.NVarChar,255),
					new SqlParameter("@Result", SqlDbType.NVarChar,255),
					new SqlParameter("@Type", SqlDbType.SmallInt,2),
					new SqlParameter("@IsPay", SqlDbType.SmallInt,2),
					new SqlParameter("@BrokerName", SqlDbType.VarChar,50),
					new SqlParameter("@IsCancel", SqlDbType.SmallInt,2),
					new SqlParameter("@OrderClass", SqlDbType.SmallInt,2),
					new SqlParameter("@UserIP", SqlDbType.VarChar,20)};
            parameters[0].Value = model.OrderID;
            parameters[1].Value = model.UserID;
            parameters[2].Value = model.UserName;
            parameters[3].Value = model.OrderDate;
            parameters[4].Value = model.ReceiverName;
            parameters[5].Value = model.ReceiverAddress;
            parameters[6].Value = model.ReceiverPostalCode;
            parameters[7].Value = model.ReceiverPhone;
            parameters[8].Value = model.ReceiverEmail;
            parameters[9].Value = model.TotalProductPrice;
            parameters[10].Value = model.PortPrice;
            parameters[11].Value = model.HasPayedPrice;
            parameters[12].Value = model.PortTypeID;
            parameters[13].Value = model.PortTypeName;
            parameters[14].Value = model.PayTypeID;
            parameters[15].Value = model.PayTypeName;
            parameters[16].Value = model.TipID;
            parameters[17].Value = model.TipName;
            parameters[18].Value = model.UpdateStaticDate;
            parameters[19].Value = model.c_memo1;
            parameters[20].Value = model.c_memo2;
            parameters[21].Value = model.Remark;
            parameters[22].Value = model.Result;
            parameters[23].Value = model.Type;
            parameters[24].Value = model.IsPay;
            parameters[25].Value = model.BrokerName;
            parameters[26].Value = model.IsCancel;
            parameters[27].Value = model.OrderClass;
            parameters[28].Value = model.UserIP;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(string OrderID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PBnet_Orders ");
            strSql.Append(" where OrderID=@OrderID ");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.VarChar,50)};
            parameters[0].Value = OrderID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Pbzx.Model.PBnet_Orders GetModel(string OrderID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 OrderID,UserID,UserName,OrderDate,ReceiverName,ReceiverAddress,ReceiverPostalCode,ReceiverPhone,ReceiverEmail,TotalProductPrice,PortPrice,HasPayedPrice,PortTypeID,PortTypeName,PayTypeID,PayTypeName,TipID,TipName,UpdateStaticDate,c_memo1,c_memo2,Remark,Result,Type,IsPay,BrokerName,IsCancel,OrderClass,UserIP from PBnet_Orders ");
            strSql.Append(" where OrderID=@OrderID ");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.VarChar,50)};
            parameters[0].Value = OrderID;

            Pbzx.Model.PBnet_Orders model = new Pbzx.Model.PBnet_Orders();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.OrderID = ds.Tables[0].Rows[0]["OrderID"].ToString();
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                if (ds.Tables[0].Rows[0]["OrderDate"].ToString() != "")
                {
                    model.OrderDate = DateTime.Parse(ds.Tables[0].Rows[0]["OrderDate"].ToString());
                }
                model.ReceiverName = ds.Tables[0].Rows[0]["ReceiverName"].ToString();
                model.ReceiverAddress = ds.Tables[0].Rows[0]["ReceiverAddress"].ToString();
                model.ReceiverPostalCode = ds.Tables[0].Rows[0]["ReceiverPostalCode"].ToString();
                model.ReceiverPhone = ds.Tables[0].Rows[0]["ReceiverPhone"].ToString();
                model.ReceiverEmail = ds.Tables[0].Rows[0]["ReceiverEmail"].ToString();
                if (ds.Tables[0].Rows[0]["TotalProductPrice"].ToString() != "")
                {
                    model.TotalProductPrice = decimal.Parse(ds.Tables[0].Rows[0]["TotalProductPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PortPrice"].ToString() != "")
                {
                    model.PortPrice = decimal.Parse(ds.Tables[0].Rows[0]["PortPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["HasPayedPrice"].ToString() != "")
                {
                    model.HasPayedPrice = decimal.Parse(ds.Tables[0].Rows[0]["HasPayedPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PortTypeID"].ToString() != "")
                {
                    model.PortTypeID = int.Parse(ds.Tables[0].Rows[0]["PortTypeID"].ToString());
                }
                model.PortTypeName = ds.Tables[0].Rows[0]["PortTypeName"].ToString();
                if (ds.Tables[0].Rows[0]["PayTypeID"].ToString() != "")
                {
                    model.PayTypeID = int.Parse(ds.Tables[0].Rows[0]["PayTypeID"].ToString());
                }
                model.PayTypeName = ds.Tables[0].Rows[0]["PayTypeName"].ToString();
                if (ds.Tables[0].Rows[0]["TipID"].ToString() != "")
                {
                    model.TipID = int.Parse(ds.Tables[0].Rows[0]["TipID"].ToString());
                }
                model.TipName = ds.Tables[0].Rows[0]["TipName"].ToString();
                if (ds.Tables[0].Rows[0]["UpdateStaticDate"].ToString() != "")
                {
                    model.UpdateStaticDate = DateTime.Parse(ds.Tables[0].Rows[0]["UpdateStaticDate"].ToString());
                }
                model.c_memo1 = ds.Tables[0].Rows[0]["c_memo1"].ToString();
                model.c_memo2 = ds.Tables[0].Rows[0]["c_memo2"].ToString();
                model.Remark = ds.Tables[0].Rows[0]["Remark"].ToString();
                model.Result = ds.Tables[0].Rows[0]["Result"].ToString();
                if (ds.Tables[0].Rows[0]["Type"].ToString() != "")
                {
                    model.Type = int.Parse(ds.Tables[0].Rows[0]["Type"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsPay"].ToString() != "")
                {
                    model.IsPay = int.Parse(ds.Tables[0].Rows[0]["IsPay"].ToString());
                }
                model.BrokerName = ds.Tables[0].Rows[0]["BrokerName"].ToString();
                if (ds.Tables[0].Rows[0]["IsCancel"].ToString() != "")
                {
                    model.IsCancel = int.Parse(ds.Tables[0].Rows[0]["IsCancel"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrderClass"].ToString() != "")
                {
                    model.OrderClass = int.Parse(ds.Tables[0].Rows[0]["OrderClass"].ToString());
                }
                model.UserIP = ds.Tables[0].Rows[0]["UserIP"].ToString();
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
            strSql.Append("select OrderID,UserID,UserName,OrderDate,ReceiverName,ReceiverAddress,ReceiverPostalCode,ReceiverPhone,ReceiverEmail,TotalProductPrice,PortPrice,HasPayedPrice,PortTypeID,PortTypeName,PayTypeID,PayTypeName,TipID,TipName,UpdateStaticDate,c_memo1,c_memo2,Remark,Result,Type,IsPay,BrokerName,IsCancel,OrderClass,UserIP ");
            strSql.Append(" FROM PBnet_Orders ");
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
            strSql.Append(" OrderID,UserID,UserName,OrderDate,ReceiverName,ReceiverAddress,ReceiverPostalCode,ReceiverPhone,ReceiverEmail,TotalProductPrice,PortPrice,HasPayedPrice,PortTypeID,PortTypeName,PayTypeID,PayTypeName,TipID,TipName,UpdateStaticDate,c_memo1,c_memo2,Remark,Result,Type,IsPay,BrokerName,IsCancel,OrderClass,UserIP ");
            strSql.Append(" FROM PBnet_Orders ");
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
            parameters[0].Value = "PBnet_Orders";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  ��Ա����




        #region �Զ��巽��
        private bool GetIsQueRen(int temp)
        {
            if (temp == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #region ���붩��
        //������̣����붩����Ϣ->��ʼ������״̬->���붩���嵥->ɾ�����ﳵ
        public string InsertOrders(Pbzx.Model.PBnet_Orders orders, DataSet shoppingCartList)
        {
            if (shoppingCartList == null || shoppingCartList.Tables[0].Rows.Count == 0)
                return null;
            //ʹ�����û���Ϊ�� ����汾
            if (Convert.ToInt32(shoppingCartList.Tables[0].Rows[0]["RegType"].ToString().Split('|')[0]) == 8 && shoppingCartList.Tables[0].Rows[0]["RegType"].ToString().Split('|')[2].ToString() == "")
            {
                return null;
            }
            string orderID = Method.CreateOrderID("ST", "PBnet_Orders");
            if (orders.OrderClass == 1)
            {
                orderID = Method.CreateOrderID("DL", "PBnet_Orders");
            }
            using (SqlConnection conn = new SqlConnection(DbHelperSQL.ConnectionString))
            {
                conn.Open();
                const string transName = "InsertOrders";
                SqlTransaction trans = conn.BeginTransaction(transName);
                try
                {
                    #region ���붩����Ϣ

                    decimal totalBookPrice = Method.CalShoppingCartPrice(shoppingCartList, false); ;

                    SqlParameter[] parmInsertOrders =
                    {
                        new SqlParameter("@OrderID",orderID),
                        new SqlParameter("@UserID",orders.UserID),
                        new SqlParameter("@UserName",orders.UserName),
                        new SqlParameter("@TipID",(int)Pbzx.Model.PBnet_OrderStaticTip.�ȴ�����),
                        new SqlParameter("@TipName",(int)Pbzx.Model.PBnet_OrderStaticTip.�ȴ�����),
                        new SqlParameter("@ReceiverName",orders.ReceiverName),
                        new SqlParameter("@ReceiverAddress",orders.ReceiverAddress),
                        new SqlParameter("@ReceiverPostalCode",orders.ReceiverPostalCode),
                        new SqlParameter("@ReceiverPhone",orders.ReceiverPhone),                        
                        new SqlParameter("@ReceiverEmail",orders.ReceiverEmail),
                        new SqlParameter("@TotalProductPrice",totalBookPrice),
                        new SqlParameter("@HasPayedPrice",new decimal(0)),
                        new SqlParameter("@PortTypeID",orders.PortTypeID),
                        new SqlParameter("@PayTypeID",orders.PayTypeID),
                        new SqlParameter("@Remark",orders.Remark),
                        new SqlParameter("@Result",orders.Result),
                        new SqlParameter("@Type",orders.Type),
                        new SqlParameter("@IsPay",orders.IsPay),
                        new SqlParameter("@BrokerName",orders.BrokerName),
                        new SqlParameter("@IsCancel",orders.IsCancel),
                        new SqlParameter("@OrderClass", orders.OrderClass),
                        new SqlParameter("@UserIP", orders.UserIP) 
                    };
                    SQLHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, StoredProcedureName.sp_InsertOrders.ToString(), parmInsertOrders);
                    #endregion

                    #region ��ʼ������״̬
                    //int[] staticIDList ={(int)Pbzx.Model.PBnet_OrderStatic.�Ƿ���ȷ��, (int)Pbzx.Model.PBnet_OrderStatic.�Ƿ��Ѹ���, (int)Pbzx.Model.PBnet_OrderStatic.�Ƿ��ѷ���, (int)Pbzx.Model.PBnet_OrderStatic.�Ƿ������, };
                    //foreach (int staticID in staticIDList)
                    //{                       
                    //  SqlParameter[] parmInsertOrder_OrderStatic =
                    //  {
                    //       new SqlParameter("@OrderID",orderID),
                    //       new SqlParameter("@StaticID",staticID),
                    //       new SqlParameter("@addedDate",DateTime.Now),                          
                    //       new SqlParameter("@YesOrNo",GetIsQueRen(staticID))
                    //  };
                    //    SQLHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, StoredProcedureName.sp_InsertOrder_OrderStatic.ToString(), parmInsertOrder_OrderStatic);
                    //}
                    #endregion


                    #region ���붩���嵥
                    foreach (DataRow shoppingCart in shoppingCartList.Tables[0].Rows)
                    {
                        SqlParameter[] parmInsertOrderDetail =
                      {
                           new SqlParameter("@OrderID",orderID),
                           new SqlParameter("@ProductID",shoppingCart["ProductID"]),
                           new SqlParameter("@Quatity",shoppingCart["Quatity"]),
                           new SqlParameter("@RegType",shoppingCart["RegType"]),
                          new SqlParameter("@UseTime",shoppingCart["UseTime"])
                       };
                        SQLHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, StoredProcedureName.sp_InsertOrderDetail.ToString(), parmInsertOrderDetail);
                    }
                    #endregion

                    #region ɾ�����ﳵ
                    SqlParameter parmDeleteShoppingCartByCartGuid = new SqlParameter("@CartGuid", shoppingCartList.Tables[0].Rows[0]["CartGuid"]);
                    SQLHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, StoredProcedureName.sp_DeleteShoppingCartByCartGuid.ToString(), parmDeleteShoppingCartByCartGuid);
                    #endregion

                    trans.Commit();
                }
                catch
                {
                    trans.Rollback(transName);
                    orderID = null;
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
            return orderID;
        }
        #endregion

        #region ��ȡһ��������Ϣ
        public DataSet SelectOrdersByOrderID(string orderID)
        {
            SqlParameter parm = new SqlParameter("@OrderID", orderID);
            return SQLHelper.GetDataSet(DbHelperSQL.ConnectionString, CommandType.StoredProcedure, StoredProcedureName.sp_SelectOrdersByOrderID.ToString(), parm);
        }
        #endregion

        #region ��ȡ���ж���
        public DataSet SelectAllOrders()
        {
            return SQLHelper.GetDataSet(DbHelperSQL.ConnectionString, CommandType.StoredProcedure, StoredProcedureName.sp_SelectAllOrders.ToString(), null);
        }
        #endregion

        #region ��ȡ����״̬
        public DataSet SelectOrderStaticByOrderID(string orderID)
        {
            SqlParameter parm = new SqlParameter("@OrderID", orderID);

            return SQLHelper.GetDataSet(DbHelperSQL.ConnectionString, CommandType.StoredProcedure, StoredProcedureName.sp_SelectOrderStaticByOrderID.ToString(), parm);
        }
        #endregion

        #region ��ȡ����״̬��ʾ
        public DataSet SelectOrderStaticTip()
        {
            return SQLHelper.GetDataSet(DbHelperSQL.ConnectionString, CommandType.StoredProcedure, StoredProcedureName.sp_SelectOrderStaticTip.ToString(), null);
        }
        #endregion

        #region ��ȡ�û��Ķ���
        public DataSet SelectOrdersByUserID(int userID)
        {
            SqlParameter parm = new SqlParameter("@UserID", userID);

            return SQLHelper.GetDataSet(DbHelperSQL.ConnectionString, CommandType.StoredProcedure, StoredProcedureName.sp_SelectOrdersByUserID.ToString(), parm);
        }
        #endregion

        #region ������ȡ����
        public DataSet SelectOrdersByOrderType(Pbzx.Model.OrderType orderType)
        {
            SqlParameter parm = new SqlParameter("@OrderType", orderType);

            return base.GetDataSet(StoredProcedureName.sp_SelectOrdersByOrderType, parm);
        }
        #endregion

        #region ��������
        public DataSet SelectOrdersBySearch(string orderID, string orderDate)
        {
            SqlParameter[] parms ={
                new SqlParameter("@OrderID",orderID),
                new SqlParameter("@OrderDate",orderDate)
            };

            return base.GetDataSet(StoredProcedureName.sp_SelectOrdersBySearch, parms);
        }
        #endregion

        #region �޸Ķ���״̬����ʾ
        public bool UpdateOrderStaicAndTip(string orderID, List<Pbzx.Model.PBnet_Order_OrderStatic> order_OrderStaticList, int tipID)
        {
            bool result = false;
            SqlConnection conn = new SqlConnection(DbHelperSQL.ConnectionString);

            conn.Open();
            string transName = "UpdateOrderStaicAndTip";
            SqlTransaction trans = conn.BeginTransaction(transName);
            try
            {
                //���¶���״̬
                foreach (Pbzx.Model.PBnet_Order_OrderStatic order_OrderStatic in order_OrderStaticList)
                {
                    SqlParameter[] parmsUpdateOrder_OrderStatic ={
                        new SqlParameter("@OrderID",orderID),
                        new SqlParameter("@StaticID",order_OrderStatic.StaticID),
                        new SqlParameter("@YesOrNo",order_OrderStatic.YesOrNo)
                    };

                    SQLHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, StoredProcedureName.sp_UpdateOrder_OrderStatic.ToString(), parmsUpdateOrder_OrderStatic);
                }

                //���¶���״̬��ʾ
                SqlParameter[] parmsUpdateOrderStaticTip ={
                    new SqlParameter("@OrderID",orderID),
                    new SqlParameter("@TipID",tipID)
                };

                SQLHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, StoredProcedureName.sp_UpdateOrderStaticTip.ToString(), parmsUpdateOrderStaticTip);

                trans.Commit();
                result = true;
            }
            catch
            {
                trans.Rollback(transName);
                result = false;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

            return result;
        }
        #endregion

        #region ����
        //������̣������Ѹ���Ľ��->���¶���״̬->���¶���״̬��ʾ
        public bool PayForOrders(int userID, string orderID, decimal payPrice)
        {
            bool result = false;

            using (SqlConnection conn = new SqlConnection(DbHelperSQL.ConnectionString))
            {
                conn.Open();
                string transName = "PayForOrders";
                SqlTransaction trans = conn.BeginTransaction(transName);
                try
                {
                    SqlParameter[] parmsPayForOrders ={
                        new SqlParameter("@UserID",userID),
                        new SqlParameter("@OrderID",orderID),
                        new SqlParameter("@PayPrice",payPrice),
                    };

                    SQLHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, StoredProcedureName.sp_PayForOrders.ToString(), parmsPayForOrders);

                    trans.Commit();
                    result = true;
                }
                catch
                {
                    trans.Rollback(transName);
                    result = false;
                }
                finally 
                { 
                    conn.Close(); 
                    conn.Dispose(); 
                }

                return result;
            }

        }
        #endregion

        #region �޸Ķ���
        public int UpdateOrders(Pbzx.Model.PBnet_Orders orders)
        {

            SqlParameter[] parms ={
                new SqlParameter("@UserID",orders.UserID),
                new SqlParameter("@UserName",orders.UserName),
                new SqlParameter("@OrderID",orders.OrderID),
                new SqlParameter("@ReceiverName",orders.ReceiverName),
                new SqlParameter("@ReceiverPostalCode",orders.ReceiverPostalCode),
                new SqlParameter("@ReceiverPhone",orders.ReceiverPhone),
                new SqlParameter("@ReceiverEmail",orders.ReceiverEmail),
                new SqlParameter("@ReceiverAddress",orders.ReceiverAddress),
                new SqlParameter("@PortTypeID",orders.PortTypeID),
                new SqlParameter("@PayTypeID",orders.PayTypeID),
                new SqlParameter("@Remark",orders.Remark),
                new SqlParameter("@Result",orders.Result),
                new SqlParameter("@Type",orders.Type),
                new SqlParameter("@IsPay",orders.IsPay),
                new SqlParameter("@BrokerName",orders.BrokerName),
                new SqlParameter("@IsCancel",orders.IsCancel),
                new SqlParameter("@OrderClass", orders.OrderClass),
                new SqlParameter("@UpdateStaticDate", orders.UpdateStaticDate)
            };

            return SQLHelper.ExecuteNonQuery(DbHelperSQL.ConnectionString, CommandType.StoredProcedure, StoredProcedureName.sp_UpdateOrders.ToString(), parms);
        }
        #endregion


        #endregion

        /// <summary>
        /// ����sql����ѯ����
        /// </summary>
        /// <returns></returns>
        public DataSet Query(string sql)
        {
            return DbHelperSQL.Query(sql);
        }
    }
}

