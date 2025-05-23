using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using Pbzx.Model;
using Pbzx.DALFactory;
using Pbzx.IDAL;
namespace Pbzx.BLL
{
    /// <summary>
    /// ҵ���߼���PBnet_OrderDetail_Delegate ��ժҪ˵����
    /// </summary>
    public class PBnet_OrderDetail_Delegate
    {
        private readonly IPBnet_OrderDetail_Delegate dal = DataAccess.CreatePBnet_OrderDetail_Delegate();
        public PBnet_OrderDetail_Delegate()
        { }
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(long OrderDetailID)
        {
            return dal.Exists(OrderDetailID);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(Pbzx.Model.PBnet_OrderDetail_Delegate model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(Pbzx.Model.PBnet_OrderDetail_Delegate model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(long OrderDetailID)
        {

            dal.Delete(OrderDetailID);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Pbzx.Model.PBnet_OrderDetail_Delegate GetModel(long OrderDetailID)
        {

            return dal.GetModel(OrderDetailID);
        }

        /// <summary>
        /// �õ�һ������ʵ�壬�ӻ����С�
        /// </summary>
        public Pbzx.Model.PBnet_OrderDetail_Delegate GetModelByCache(long OrderDetailID)
        {

            string CacheKey = "PBnet_OrderDetail_DelegateModel-" + OrderDetailID;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(OrderDetailID);
                    if (objModel != null)
                    {
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Pbzx.Model.PBnet_OrderDetail_Delegate)objModel;
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
        public List<Pbzx.Model.PBnet_OrderDetail_Delegate> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<Pbzx.Model.PBnet_OrderDetail_Delegate> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.PBnet_OrderDetail_Delegate> modelList = new List<Pbzx.Model.PBnet_OrderDetail_Delegate>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.PBnet_OrderDetail_Delegate model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.PBnet_OrderDetail_Delegate();
                    //model.OrderDetailID=dt.Rows[n]["OrderDetailID"].ToString();
                    model.OrderID = dt.Rows[n]["OrderID"].ToString();
                    if (dt.Rows[n]["ProductID"].ToString() != "")
                    {
                        model.ProductID = int.Parse(dt.Rows[n]["ProductID"].ToString());
                    }
                    if (dt.Rows[n]["Quatity"].ToString() != "")
                    {
                        model.Quatity = int.Parse(dt.Rows[n]["Quatity"].ToString());
                    }
                    model.RegType = dt.Rows[n]["RegType"].ToString();
                    model.Serial = dt.Rows[n]["Serial"].ToString();
                    model.UseTime = dt.Rows[n]["UseTime"].ToString();
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

        public DataSet SelectOrderDetailDelegateByOrderID(string orderID)
        {
            if (string.IsNullOrEmpty(orderID))
                return null;

            return dal.SelectOrderDetailDelegateByOrderID(orderID);
        }
    }
}

