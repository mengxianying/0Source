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
	/// ҵ���߼���PBnet_broker_TradeInfo ��ժҪ˵����
	/// </summary>
	public class PBnet_broker_TradeInfo
	{
		private readonly IPBnet_broker_TradeInfo dal=DataAccess.CreatePBnet_broker_TradeInfo();
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("PBnet_broker_TradeInfo", "Id");
		public PBnet_broker_TradeInfo()
		{}
		#region  ��Ա����
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int Id)
		{
			return dal.Exists(Id);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public bool  Add(Pbzx.Model.PBnet_broker_TradeInfo model)
		{
            return dal.Add(model) > 0 ? true : false;
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Update(Pbzx.Model.PBnet_broker_TradeInfo model)
		{
            return dal.Update(model) > 0 ? true : false;
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool Delete(int Id)
		{

            return dal.Delete(Id) > 0 ? true : false;
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Pbzx.Model.PBnet_broker_TradeInfo GetModel(int Id)
		{
			
			return dal.GetModel(Id);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public Pbzx.Model.PBnet_broker_TradeInfo GetModelByCache(int Id)
		{
			
			string CacheKey = "PBnet_broker_TradeInfoModel-" + Id;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(Id);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Pbzx.Model.PBnet_broker_TradeInfo)objModel;
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
		public List<Pbzx.Model.PBnet_broker_TradeInfo> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<Pbzx.Model.PBnet_broker_TradeInfo> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.PBnet_broker_TradeInfo> modelList = new List<Pbzx.Model.PBnet_broker_TradeInfo>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.PBnet_broker_TradeInfo model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.PBnet_broker_TradeInfo();
                    if (dt.Rows[n]["Id"].ToString() != "")
                    {
                        model.Id = int.Parse(dt.Rows[n]["Id"].ToString());
                    }
                    model.BrokerName = dt.Rows[n]["BrokerName"].ToString();
                    model.OrderID = dt.Rows[n]["OrderID"].ToString();
                    model.CustomerName = dt.Rows[n]["CustomerName"].ToString();
                    if (dt.Rows[n]["CustomerPay"].ToString() != "")
                    {
                        model.CustomerPay = decimal.Parse(dt.Rows[n]["CustomerPay"].ToString());
                    }
                    if (dt.Rows[n]["BrokerIncome"].ToString() != "")
                    {
                        model.BrokerIncome = decimal.Parse(dt.Rows[n]["BrokerIncome"].ToString());
                    }
                    if (dt.Rows[n]["CreateTime"].ToString() != "")
                    {
                        model.CreateTime = DateTime.Parse(dt.Rows[n]["CreateTime"].ToString());
                    }
                    model.RegManager = dt.Rows[n]["RegManager"].ToString();
                    model.Remark = dt.Rows[n]["Remark"].ToString();
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

        //������ʾ

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
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "PBnet_broker_TradeInfo", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }
	}
}

