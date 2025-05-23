using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Pbzx.IDAL;
using Pbzx.DALFactory;

namespace Pbzx.BLL
{
    /// <summary>
    /// ҵ���߼���PBnet_Orders_Delegates ��ժҪ˵����
    /// </summary>
    public class PBnet_Orders_Delegates
    {
        private readonly Pbzx.SQLServerDAL.PBnet_Orders_Delegates dal = new Pbzx.SQLServerDAL.PBnet_Orders_Delegates();
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("PBnet_Orders_Delegates", "OrderID");
        public PBnet_Orders_Delegates()
        { }
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(string OrderID)
        {
            return dal.Exists(OrderID);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Add(Pbzx.Model.PBnet_Orders_Delegates model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Update(Pbzx.Model.PBnet_Orders_Delegates model)
        {
            return dal.Update(model) > 0 ? true : false;
          
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(string OrderID)
        {

            dal.Delete(OrderID);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Pbzx.Model.PBnet_Orders_Delegates GetModel(string OrderID)
        {

            return dal.GetModel(OrderID);
        }

        /// <summary>
        /// �õ�һ������ʵ�壬�ӻ����С�
        /// </summary>
        public Pbzx.Model.PBnet_Orders_Delegates GetModelByCache(string OrderID)
        {

            string CacheKey = "PBnet_Orders_DelegatesModel-" + OrderID;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(OrderID);
                    if (objModel != null)
                    {
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Pbzx.Model.PBnet_Orders_Delegates)objModel;
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// ���ǰ��������
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<Pbzx.Model.PBnet_Orders_Delegates> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<Pbzx.Model.PBnet_Orders_Delegates> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.PBnet_Orders_Delegates> modelList = new List<Pbzx.Model.PBnet_Orders_Delegates>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.PBnet_Orders_Delegates model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.PBnet_Orders_Delegates();
                    model.OrderID = dt.Rows[n]["OrderID"].ToString();
                    if (dt.Rows[n]["UserID"].ToString() != "")
                    {
                        model.UserID = int.Parse(dt.Rows[n]["UserID"].ToString());
                    }
                    model.UserName = dt.Rows[n]["UserName"].ToString();
                    if (dt.Rows[n]["OrderDate"].ToString() != "")
                    {
                        model.OrderDate = DateTime.Parse(dt.Rows[n]["OrderDate"].ToString());
                    }
                    model.ReceiverName = dt.Rows[n]["ReceiverName"].ToString();
                    model.ReceiverAddress = dt.Rows[n]["ReceiverAddress"].ToString();
                    model.ReceiverPostalCode = dt.Rows[n]["ReceiverPostalCode"].ToString();
                    model.ReceiverPhone = dt.Rows[n]["ReceiverPhone"].ToString();
                    model.ReceiverEmail = dt.Rows[n]["ReceiverEmail"].ToString();
                    if (dt.Rows[n]["TotalProductPrice"].ToString() != "")
                    {
                        model.TotalProductPrice = decimal.Parse(dt.Rows[n]["TotalProductPrice"].ToString());
                    }
                    if (dt.Rows[n]["PortPrice"].ToString() != "")
                    {
                        model.PortPrice = decimal.Parse(dt.Rows[n]["PortPrice"].ToString());
                    }
                    if (dt.Rows[n]["HasPayedPrice"].ToString() != "")
                    {
                        model.HasPayedPrice = decimal.Parse(dt.Rows[n]["HasPayedPrice"].ToString());
                    }
                    if (dt.Rows[n]["PortTypeID"].ToString() != "")
                    {
                        model.PortTypeID = int.Parse(dt.Rows[n]["PortTypeID"].ToString());
                    }
                    model.PortTypeName = dt.Rows[n]["PortTypeName"].ToString();
                    if (dt.Rows[n]["PayTypeID"].ToString() != "")
                    {
                        model.PayTypeID = int.Parse(dt.Rows[n]["PayTypeID"].ToString());
                    }
                    model.PayTypeName = dt.Rows[n]["PayTypeName"].ToString();
                    if (dt.Rows[n]["TipID"].ToString() != "")
                    {
                        model.TipID = int.Parse(dt.Rows[n]["TipID"].ToString());
                    }
                    model.TipName = dt.Rows[n]["TipName"].ToString();
                    if (dt.Rows[n]["UpdateStaticDate"].ToString() != "")
                    {
                        model.UpdateStaticDate = DateTime.Parse(dt.Rows[n]["UpdateStaticDate"].ToString());
                    }
                    model.c_memo1 = dt.Rows[n]["c_memo1"].ToString();
                    model.c_memo2 = dt.Rows[n]["c_memo2"].ToString();
                    model.Remark = dt.Rows[n]["Remark"].ToString();
                    model.Result = dt.Rows[n]["Result"].ToString();
                    if (dt.Rows[n]["Type"].ToString() != "")
                    {
                        model.Type = int.Parse(dt.Rows[n]["Type"].ToString());
                    }
                    if (dt.Rows[n]["IsPay"].ToString() != "")
                    {
                        model.IsPay = int.Parse(dt.Rows[n]["IsPay"].ToString());
                    }
                    if (dt.Rows[n]["IsCancel"].ToString() != "")
                    {
                        if ((dt.Rows[n]["IsCancel"].ToString() == "1") || (dt.Rows[n]["IsCancel"].ToString().ToLower() == "true"))
                        {
                            model.IsCancel = true;
                        }
                        else
                        {
                            model.IsCancel = false;
                        }
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  ��Ա����

        /// <summary>
        /// ���ݲ�ѯ�ַ�����ȡ��ҳ����
        /// </summary>
        /// <param name="SearchStr">��ѯ�ַ��� </param>
        /// <param name="getFileds">��ȡ��</param>
        /// <param name="OrderStr">�����ֶ�</param>
        /// <param name="PageNum">��ȡ��������</param>
        /// <param name="desc">�����ǽ���</param>
        /// <param name="CurrentPage">��ǰ��ҳ��</param>
        /// <param name="Counts">���ؼ�¼������</param>
        /// <returns></returns>         
        public DataTable GuestGetBySearch(string SearchStr, string getFileds, string OrderStr, int PageNum, int orderType, int CurrentPage, out int Counts)
        {
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "PBnet_Orders_Delegates", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }



        public string GetTotalMoney(string where)
        {
            string result = "";
            string sql = "select count(OrderID) as TotalID,sum(TotalProductPrice+PortPrice) as TotalMoney , sum(HasPayedPrice) as HasPay from PBnet_Orders_Delegates";
            if (!string.IsNullOrEmpty(where))
            {
                sql += " where " + where;
            }
            DataSet ds = dal.Query(sql);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                if (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["TotalMoney"].ToString()))
                {
                    result = "0&0";
                }
                else
                {
                    result = ds.Tables[0].Rows[0]["TotalID"] + "&" + ds.Tables[0].Rows[0]["TotalMoney"];
                }
            }
            else
            {
                result = "0&0";
            }
            return result;
        }

        public string InsertOrders(Pbzx.Model.PBnet_Orders_Delegates orders, DataSet shoppingCartList)
        {
            if (shoppingCartList == null || shoppingCartList.Tables[0].Rows.Count == 0)
                return null;
            return dal.InsertOrders(orders, shoppingCartList);
        }

        public DataSet SelectOrdersByOrderID(string orderID)
        {
            return dal.SelectOrdersByOrderID(orderID);
        }


        public int UpdateOrders(Pbzx.Model.PBnet_Orders_Delegates orders)
        {
            if (orders.UserID <= 0 || string.IsNullOrEmpty(orders.OrderID))
                return -1;

            return dal.UpdateOrders(orders);
        }

        public bool PayForOrders(int userID, string orderID, decimal payPrice)
        {
            if (payPrice <= 0 || string.IsNullOrEmpty(orderID))
                return false;
            return dal.PayForOrders(userID, orderID, payPrice);
        }

        public DataSet SelectOrderStaticByOrderID(string orderID)
        {
            if (string.IsNullOrEmpty(orderID))
                return null;
            return dal.SelectOrderStaticByOrderID(orderID);
        }


        public DataSet SelectOrderStaticTip()
        {
            return dal.SelectOrderStaticTip();
        }

        public bool UpdateOrderStaicAndTip(string orderID, List<Pbzx.Model.PBnet_Order_OrderStatic> order_OrderStaticList, int tipID)
        {
            if (string.IsNullOrEmpty(orderID))
                return false;

            return dal.UpdateOrderStaicAndTip(orderID, order_OrderStaticList, tipID);
        }



    }
}
