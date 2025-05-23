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
    /// ҵ���߼���Market_BuyInfo ��ժҪ˵����
    /// </summary>
    public class Market_BuyInfo
    {
        private readonly IMarket_BuyInfo dal = DataAccess.CreateIMarket_BuyInfo();
       
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("Market_BuyInfo", "buyid");
        public Market_BuyInfo()
        { }
#region  ��Ա����
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
        public bool Exists(string buyuserid, int issueInfoId)
		{
			return dal.Exists(buyuserid,issueInfoId);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(Pbzx.Model.Market_BuyInfo model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int Update(Pbzx.Model.Market_BuyInfo model)
		{
		    return	dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public int Delete(int buyid)
		{
			
			return dal.Delete(buyid);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Pbzx.Model.Market_BuyInfo GetModel(int issueInfoId)
		{
			
			return dal.GetModel(issueInfoId);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public Pbzx.Model.Market_BuyInfo GetModelByCache(int issueInfoId)
		{
			
			string CacheKey = "Market_BuyInfoModel-" +issueInfoId;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(issueInfoId);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Pbzx.Model.Market_BuyInfo)objModel;
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
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Pbzx.Model.Market_BuyInfo> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Pbzx.Model.Market_BuyInfo> DataTableToList(DataTable dt)
		{
			List<Pbzx.Model.Market_BuyInfo> modelList = new List<Pbzx.Model.Market_BuyInfo>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Pbzx.Model.Market_BuyInfo model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Pbzx.Model.Market_BuyInfo();
                    if (dt.Rows[n]["buyid"].ToString() != "")
                    {
                        model.buyid = int.Parse(dt.Rows[n]["buyid"].ToString());
                    }
                    model.buyuserid = dt.Rows[n]["buyuserid"].ToString();
                    if (dt.Rows[n]["issueInfoId"].ToString() != "")
                    {
                        model.issueInfoId = int.Parse(dt.Rows[n]["issueInfoId"].ToString());
                    }
                    model.LotteryType = dt.Rows[n]["LotteryType"].ToString();
                    model.ShopUserID = dt.Rows[n]["ShopUserID"].ToString();
                    if (dt.Rows[n]["Price"].ToString() != "")
                    {
                        model.Price = decimal.Parse(dt.Rows[n]["Price"].ToString());
                    }
                    if (dt.Rows[n]["Term"].ToString() != "")
                    {
                        model.Term = int.Parse(dt.Rows[n]["Term"].ToString());
                    }
                    if (dt.Rows[n]["BeginTime"].ToString() != "")
                    {
                        model.BeginTime = DateTime.Parse(dt.Rows[n]["BeginTime"].ToString());
                    }
                    if (dt.Rows[n]["EndTime"].ToString() != "")
                    {
                        model.EndTime = DateTime.Parse(dt.Rows[n]["EndTime"].ToString());
                    }
                    if (dt.Rows[n]["buyContinue"].ToString() != "")
                    {
                        model.buyContinue = int.Parse(dt.Rows[n]["buyContinue"].ToString());
                    }
                    if (dt.Rows[n]["market"].ToString() != "")
                    {
                        model.market = int.Parse(dt.Rows[n]["market"].ToString());
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



        /// <summary>
        /// ���ݲ�ѯ�ַ�����ȡ��ҳ����
        /// ������: zhouwei
        /// ����ʱ��: 2010-10-27
        /// </summary>
        /// <param name="SearchStr">��ѯ�ַ��� </param>
        /// <param name="getFileds">��ȡ��</param>
        /// <param name="OrderStr">�����ֶ�</param>
        /// <param name="PageNum">��ȡ��������</param>
        /// <param name="desc">�����ǽ���</param>
        /// <param name="CurrentPage">��ǰ��ҳ��</param>
        /// <param name="Counts">���ؼ�¼������</param>
        /// <returns></returns>         

        public DataTable GuestGetBySearchBuyInfo(string SearchStr, string getFileds, string OrderStr, int PageNum, int orderType, int CurrentPage, out int Counts)
        {
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "Market_BuyInfo", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }


        #endregion  ��Ա����
    }
}
