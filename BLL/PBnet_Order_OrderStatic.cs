using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using Pbzx.Model;
namespace Pbzx.BLL
{
	/// <summary>
	/// 业务逻辑类PBnet_Order_OrderStatic 的摘要说明。
	/// </summary>
	public class PBnet_Order_OrderStatic
	{
		private readonly Pbzx.SQLServerDAL.PBnet_Order_OrderStatic dal=new Pbzx.SQLServerDAL.PBnet_Order_OrderStatic();
		public PBnet_Order_OrderStatic()
		{}
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string OrderID)
		{
			return dal.Exists(OrderID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(Pbzx.Model.PBnet_Order_OrderStatic model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Pbzx.Model.PBnet_Order_OrderStatic model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string OrderID)
		{
			
			dal.Delete(OrderID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Pbzx.Model.PBnet_Order_OrderStatic GetModel(string OrderID)
		{
			
			return dal.GetModel(OrderID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
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
		public List<Pbzx.Model.PBnet_Order_OrderStatic> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
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

