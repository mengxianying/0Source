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
	/// 业务逻辑类PBnet_smsfs 的摘要说明。
	/// </summary>
	public class PBnet_smsfs
	{
		private readonly IPBnet_smsfs dal=DataAccess.CreatePBnet_smsfs();
		public PBnet_smsfs()
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
		public bool Exists(int id)
		{
			return dal.Exists(id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Pbzx.Model.PBnet_smsfs model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Pbzx.Model.PBnet_smsfs model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			
			dal.Delete(id);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Pbzx.Model.PBnet_smsfs GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public Pbzx.Model.PBnet_smsfs GetModelByCache(int id)
		{
			
			string CacheKey = "PBnet_smsfsModel-" + id;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(id);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Pbzx.Model.PBnet_smsfs)objModel;
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
		public List<Pbzx.Model.PBnet_smsfs> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<Pbzx.Model.PBnet_smsfs> modelList = new List<Pbzx.Model.PBnet_smsfs>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				Pbzx.Model.PBnet_smsfs model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Pbzx.Model.PBnet_smsfs();
					if(ds.Tables[0].Rows[n]["id"].ToString()!="")
					{
						model.id=int.Parse(ds.Tables[0].Rows[n]["id"].ToString());
					}
					if(ds.Tables[0].Rows[n]["pb_smsid"].ToString()!="")
					{
						model.pb_smsid=int.Parse(ds.Tables[0].Rows[n]["pb_smsid"].ToString());
					}
					model.PBnet_smsfsmsg=ds.Tables[0].Rows[n]["PBnet_smsfsmsg"].ToString();
					if(ds.Tables[0].Rows[n]["pb_intime"].ToString()!="")
					{
						model.pb_intime=DateTime.Parse(ds.Tables[0].Rows[n]["pb_intime"].ToString());
					}
					model.pb_author=ds.Tables[0].Rows[n]["pb_author"].ToString();
					if(ds.Tables[0].Rows[n]["pb_isnew"].ToString()!="")
					{
						if((ds.Tables[0].Rows[n]["pb_isnew"].ToString()=="1")||(ds.Tables[0].Rows[n]["pb_isnew"].ToString().ToLower()=="true"))
						{
						model.pb_isnew=true;
						}
						else
						{
							model.pb_isnew=false;
						}
					}
					if(ds.Tables[0].Rows[n]["pb_cpnum"].ToString()!="")
					{
						model.pb_cpnum=int.Parse(ds.Tables[0].Rows[n]["pb_cpnum"].ToString());
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

