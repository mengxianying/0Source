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
	/// 业务逻辑类PBnet_bocai 的摘要说明。
	/// </summary>
	public class PBnet_bocai
	{
		private readonly IPBnet_bocai dal=DataAccess.CreatePBnet_bocai();
		public PBnet_bocai()
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
		public bool Exists(int cid)
		{
			return dal.Exists(cid);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Pbzx.Model.PBnet_bocai model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Pbzx.Model.PBnet_bocai model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int cid)
		{
			
			dal.Delete(cid);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Pbzx.Model.PBnet_bocai GetModel(int cid)
		{
			
			return dal.GetModel(cid);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public Pbzx.Model.PBnet_bocai GetModelByCache(int cid)
		{
			
			string CacheKey = "PBnet_bocaiModel-" + cid;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(cid);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Pbzx.Model.PBnet_bocai)objModel;
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
		public List<Pbzx.Model.PBnet_bocai> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<Pbzx.Model.PBnet_bocai> modelList = new List<Pbzx.Model.PBnet_bocai>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				Pbzx.Model.PBnet_bocai model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Pbzx.Model.PBnet_bocai();
					if(ds.Tables[0].Rows[n]["cid"].ToString()!="")
					{
						model.cid=int.Parse(ds.Tables[0].Rows[n]["cid"].ToString());
					}
					model.cname=ds.Tables[0].Rows[n]["cname"].ToString();
					model.cren=ds.Tables[0].Rows[n]["cren"].ToString();
					model.ctime=ds.Tables[0].Rows[n]["ctime"].ToString();
					model.cneirong=ds.Tables[0].Rows[n]["cneirong"].ToString();
					model.cchuchu=ds.Tables[0].Rows[n]["cchuchu"].ToString();
					model.yntj=ds.Tables[0].Rows[n]["yntj"].ToString();
					if(ds.Tables[0].Rows[n]["gglbid"].ToString()!="")
					{
						model.gglbid=int.Parse(ds.Tables[0].Rows[n]["gglbid"].ToString());
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

