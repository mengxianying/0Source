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
	/// 业务逻辑类PBnet_qjqi 的摘要说明。
	/// </summary>
	public class PBnet_qjqi
	{
		private readonly IPBnet_qjqi dal=DataAccess.CreatePBnet_qjqi();
		public PBnet_qjqi()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int qiuid)
		{
			return dal.Exists(qiuid);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Pbzx.Model.PBnet_qjqi model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Pbzx.Model.PBnet_qjqi model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int qiuid)
		{
			
			dal.Delete(qiuid);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Pbzx.Model.PBnet_qjqi GetModel(int qiuid)
		{
			
			return dal.GetModel(qiuid);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public Pbzx.Model.PBnet_qjqi GetModelByCache(int qiuid)
		{
			
			string CacheKey = "PBnet_qjqiModel-" + qiuid;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(qiuid);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Pbzx.Model.PBnet_qjqi)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Pbzx.Model.PBnet_qjqi> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<Pbzx.Model.PBnet_qjqi> modelList = new List<Pbzx.Model.PBnet_qjqi>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				Pbzx.Model.PBnet_qjqi model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Pbzx.Model.PBnet_qjqi();
					if(ds.Tables[0].Rows[n]["qiuid"].ToString()!="")
					{
						model.qiuid=int.Parse(ds.Tables[0].Rows[n]["qiuid"].ToString());
					}
					if(ds.Tables[0].Rows[n]["qname"].ToString()!="")
					{
						model.qname=int.Parse(ds.Tables[0].Rows[n]["qname"].ToString());
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

