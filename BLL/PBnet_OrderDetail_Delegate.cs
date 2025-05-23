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
    /// 业务逻辑类PBnet_OrderDetail_Delegate 的摘要说明。
    /// </summary>
    public class PBnet_OrderDetail_Delegate
    {
        private readonly IPBnet_OrderDetail_Delegate dal = DataAccess.CreatePBnet_OrderDetail_Delegate();
        public PBnet_OrderDetail_Delegate()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long OrderDetailID)
        {
            return dal.Exists(OrderDetailID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.PBnet_OrderDetail_Delegate model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(Pbzx.Model.PBnet_OrderDetail_Delegate model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(long OrderDetailID)
        {

            dal.Delete(OrderDetailID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.PBnet_OrderDetail_Delegate GetModel(long OrderDetailID)
        {

            return dal.GetModel(OrderDetailID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中。
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
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Pbzx.Model.PBnet_OrderDetail_Delegate> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
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
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  成员方法

        public DataSet SelectOrderDetailDelegateByOrderID(string orderID)
        {
            if (string.IsNullOrEmpty(orderID))
                return null;

            return dal.SelectOrderDetailDelegateByOrderID(orderID);
        }
    }
}

