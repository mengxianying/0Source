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
    /// ҵ���߼���PBnet_OrderTradeInfo ��ժҪ˵����
    /// </summary>
    public class PBnet_OrderTradeInfo
    {
        private readonly IPBnet_OrderTradeInfo dal = DataAccess.CreatePBnet_OrderTradeInfo();
        public PBnet_OrderTradeInfo()
        { }
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int TradeID)
        {
            return dal.Exists(TradeID);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(Pbzx.Model.PBnet_OrderTradeInfo model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(Pbzx.Model.PBnet_OrderTradeInfo model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(int TradeID)
        {

            dal.Delete(TradeID);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Pbzx.Model.PBnet_OrderTradeInfo GetModel(int TradeID)
        {

            return dal.GetModel(TradeID);
        }

        /// <summary>
        /// �õ�һ������ʵ�壬�ӻ����С�
        /// </summary>
        public Pbzx.Model.PBnet_OrderTradeInfo GetModelByCache(int TradeID)
        {

            string CacheKey = "PBnet_OrderTradeInfoModel-" + TradeID;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(TradeID);
                    if (objModel != null)
                    {
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Pbzx.Model.PBnet_OrderTradeInfo)objModel;
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
        public List<Pbzx.Model.PBnet_OrderTradeInfo> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<Pbzx.Model.PBnet_OrderTradeInfo> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.PBnet_OrderTradeInfo> modelList = new List<Pbzx.Model.PBnet_OrderTradeInfo>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.PBnet_OrderTradeInfo model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.PBnet_OrderTradeInfo();
                    if (dt.Rows[n]["TradeID"].ToString() != "")
                    {
                        model.TradeID = int.Parse(dt.Rows[n]["TradeID"].ToString());
                    }
                    model.OrderID = dt.Rows[n]["OrderID"].ToString();
                    if (dt.Rows[n]["c_orderamount"].ToString() != "")
                    {
                        model.c_orderamount = decimal.Parse(dt.Rows[n]["c_orderamount"].ToString());
                    }
                    if (dt.Rows[n]["c_ymd"].ToString() != "")
                    {
                        model.c_ymd = DateTime.Parse(dt.Rows[n]["c_ymd"].ToString());
                    }
                    model.c_transnum = dt.Rows[n]["c_transnum"].ToString();
                    if (dt.Rows[n]["c_succmark"].ToString() != "")
                    {
                        if ((dt.Rows[n]["c_succmark"].ToString() == "1") || (dt.Rows[n]["c_succmark"].ToString().ToLower() == "true"))
                        {
                            model.c_succmark = true;
                        }
                        else
                        {
                            model.c_succmark = false;
                        }
                    }
                    model.c_cause = dt.Rows[n]["c_cause"].ToString();
                    if (dt.Rows[n]["c_moneytype"].ToString() != "")
                    {
                        model.c_moneytype = int.Parse(dt.Rows[n]["c_moneytype"].ToString());
                    }
                    if (dt.Rows[n]["PayType"].ToString() != "")
                    {
                        model.PayType = int.Parse(dt.Rows[n]["PayType"].ToString());
                    }
                    model.UserName = dt.Rows[n]["UserName"].ToString();
                    model.PayAndPortType = dt.Rows[n]["PayAndPortType"].ToString();
                    if (dt.Rows[n]["OrderType"].ToString() != "")
                    {
                        model.OrderType = int.Parse(dt.Rows[n]["OrderType"].ToString());
                    }
                    model.OrderTypeName = dt.Rows[n]["OrderTypeName"].ToString();
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
    }
}

