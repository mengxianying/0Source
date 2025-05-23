using System;
using System.Collections.Generic;
using System.Text;
using Pbzx.IDAL;
using Pbzx.DALFactory;
using System.Data;

namespace Pbzx.BLL
{
    public class Market_TypeConfigureManager
    {
        private readonly IMarket_TypeConfigure dal = DataAccess.CreateIMarket_TypeConfigure();

		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ConfigureID)
		{
			return dal.Exists(ConfigureID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Pbzx.Model.Market_TypeConfigure model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Pbzx.Model.Market_TypeConfigure model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ConfigureID)
		{
			
			dal.Delete(ConfigureID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Pbzx.Model.Market_TypeConfigure GetModel(int ConfigureID)
		{
			
			return dal.GetModel(ConfigureID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public Pbzx.Model.Market_TypeConfigure GetModelByCache(int ConfigureID)
		{
			
			string CacheKey = "Market_TypeConfigureModel-" + ConfigureID;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ConfigureID);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Pbzx.Model.Market_TypeConfigure)objModel;
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
		public List<Pbzx.Model.Market_TypeConfigure> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Pbzx.Model.Market_TypeConfigure> DataTableToList(DataTable dt)
		{
			List<Pbzx.Model.Market_TypeConfigure> modelList = new List<Pbzx.Model.Market_TypeConfigure>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Pbzx.Model.Market_TypeConfigure model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Pbzx.Model.Market_TypeConfigure();
					if(dt.Rows[n]["ConfigureID"].ToString()!="")
					{
						model.ConfigureID=int.Parse(dt.Rows[n]["ConfigureID"].ToString());
					}
					if(dt.Rows[n]["TypeId"].ToString()!="")
					{
						model.TypeId=int.Parse(dt.Rows[n]["TypeId"].ToString());
					}
					if(dt.Rows[n]["On_off"].ToString()!="")
					{
						model.On_off=int.Parse(dt.Rows[n]["On_off"].ToString());
					}
					if(dt.Rows[n]["Sign"].ToString()!="")
					{
						model.Sign=int.Parse(dt.Rows[n]["Sign"].ToString());
					}
					if(dt.Rows[n]["BeginTime"].ToString()!="")
					{
						model.BeginTime=DateTime.Parse(dt.Rows[n]["BeginTime"].ToString());
					}
					if(dt.Rows[n]["Endtime"].ToString()!="")
					{
						model.Endtime=DateTime.Parse(dt.Rows[n]["Endtime"].ToString());
					}
					if(dt.Rows[n]["Upload"].ToString()!="")
					{
						model.Upload=int.Parse(dt.Rows[n]["Upload"].ToString());
					}
					if(dt.Rows[n]["SmallMoney"].ToString()!="")
					{
						model.SmallMoney=decimal.Parse(dt.Rows[n]["SmallMoney"].ToString());
					}
					if(dt.Rows[n]["BigMoney"].ToString()!="")
					{
						model.BigMoney=decimal.Parse(dt.Rows[n]["BigMoney"].ToString());
					}
					model.Ticheng=dt.Rows[n]["Ticheng"].ToString();
					if(dt.Rows[n]["ManyIssue"].ToString()!="")
					{
						model.ManyIssue=int.Parse(dt.Rows[n]["ManyIssue"].ToString());
					}
					if(dt.Rows[n]["Recommend"].ToString()!="")
					{
						model.Recommend=int.Parse(dt.Rows[n]["Recommend"].ToString());
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
    }
}
