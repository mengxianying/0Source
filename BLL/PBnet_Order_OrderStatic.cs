using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using Pbzx.Model;
namespace Pbzx.BLL
{
	/// <summary>
	/// ҵ���߼���PBnet_Order_OrderStatic ��ժҪ˵����
	/// </summary>
	public class PBnet_Order_OrderStatic
	{
		private readonly Pbzx.SQLServerDAL.PBnet_Order_OrderStatic dal=new Pbzx.SQLServerDAL.PBnet_Order_OrderStatic();
		public PBnet_Order_OrderStatic()
		{}
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
		public void Add(Pbzx.Model.PBnet_Order_OrderStatic model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(Pbzx.Model.PBnet_Order_OrderStatic model)
		{
			dal.Update(model);
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
		public Pbzx.Model.PBnet_Order_OrderStatic GetModel(string OrderID)
		{
			
			return dal.GetModel(OrderID);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public Pbzx.Model.PBnet_Order_OrderStatic GetModelByCache(string OrderID)
		{
			
			string CacheKey = "PBnet_Order_OrderStaticModel-" + OrderID;
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
				catch{}
			}
			return (Pbzx.Model.PBnet_Order_OrderStatic)objModel;
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
		public List<Pbzx.Model.PBnet_Order_OrderStatic> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Pbzx.Model.PBnet_Order_OrderStatic> DataTableToList(DataTable dt)
		{
			List<Pbzx.Model.PBnet_Order_OrderStatic> modelList = new List<Pbzx.Model.PBnet_Order_OrderStatic>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Pbzx.Model.PBnet_Order_OrderStatic model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Pbzx.Model.PBnet_Order_OrderStatic();
					model.OrderID=dt.Rows[n]["OrderID"].ToString();
					if(dt.Rows[n]["StaticID"].ToString()!="")
					{
						model.StaticID=int.Parse(dt.Rows[n]["StaticID"].ToString());
					}
					if(dt.Rows[n]["AddedDate"].ToString()!="")
					{
						model.AddedDate=DateTime.Parse(dt.Rows[n]["AddedDate"].ToString());
					}
					if(dt.Rows[n]["YesOrNo"].ToString()!="")
					{
						if((dt.Rows[n]["YesOrNo"].ToString()=="1")||(dt.Rows[n]["YesOrNo"].ToString().ToLower()=="true"))
						{
						model.YesOrNo=true;
						}
						else
						{
							model.YesOrNo=false;
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

        public Pbzx.Model.PBnet_Order_OrderStatic GetModelByOrderID(string orderID)
        {
           List<Pbzx.Model.PBnet_Order_OrderStatic> ls =  GetModelList("OrderID");
           if (ls.Count > 0)
           {
               return ls[0];
           }
           else
           {
               return null;
           }
        }


	}
}

