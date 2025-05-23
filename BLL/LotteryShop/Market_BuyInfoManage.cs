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
    /// 业务逻辑类Market_BuyInfo 的摘要说明。
    /// </summary>
    public class Market_BuyInfo
    {
        private readonly IMarket_BuyInfo dal = DataAccess.CreateIMarket_BuyInfo();
       
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("Market_BuyInfo", "buyid");
        public Market_BuyInfo()
        { }
#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool Exists(string buyuserid, int issueInfoId)
		{
			return dal.Exists(buyuserid,issueInfoId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Pbzx.Model.Market_BuyInfo model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public int Update(Pbzx.Model.Market_BuyInfo model)
		{
		    return	dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public int Delete(int buyid)
		{
			
			return dal.Delete(buyid);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Pbzx.Model.Market_BuyInfo GetModel(int issueInfoId)
		{
			
			return dal.GetModel(issueInfoId);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
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
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Pbzx.Model.Market_BuyInfo> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
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



        /// <summary>
        /// 根据查询字符串获取分页数据
        /// 创建人: zhouwei
        /// 创建时间: 2010-10-27
        /// </summary>
        /// <param name="SearchStr">查询字符串 </param>
        /// <param name="getFileds">获取列</param>
        /// <param name="OrderStr">排序字段</param>
        /// <param name="PageNum">获取的数据数</param>
        /// <param name="desc">升序还是降序</param>
        /// <param name="CurrentPage">当前的页数</param>
        /// <param name="Counts">返回记录集总数</param>
        /// <returns></returns>         

        public DataTable GuestGetBySearchBuyInfo(string SearchStr, string getFileds, string OrderStr, int PageNum, int orderType, int CurrentPage, out int Counts)
        {
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "Market_BuyInfo", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }


        #endregion  成员方法
    }
}
