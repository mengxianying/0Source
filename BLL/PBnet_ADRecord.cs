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
	/// 业务逻辑类PBnet_ADRecord 的摘要说明。
	/// </summary>
	public class PBnet_ADRecord
	{
		private readonly IPBnet_ADRecord dal=DataAccess.CreatePBnet_ADRecord();
		public PBnet_ADRecord()
		{}
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long pb_ADid,DateTime pb_VsTime,string pb_VsIP,long id)
		{
			return dal.Exists(pb_ADid,pb_VsTime,pb_VsIP,id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Pbzx.Model.PBnet_ADRecord model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Pbzx.Model.PBnet_ADRecord model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(long pb_ADid,DateTime pb_VsTime,string pb_VsIP,long id)
		{
			
			dal.Delete(pb_ADid,pb_VsTime,pb_VsIP,id);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Pbzx.Model.PBnet_ADRecord GetModel(long pb_ADid,DateTime pb_VsTime,string pb_VsIP,long id)
		{
			
			return dal.GetModel(pb_ADid,pb_VsTime,pb_VsIP,id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public Pbzx.Model.PBnet_ADRecord GetModelByCache(long pb_ADid,DateTime pb_VsTime,string pb_VsIP,long id)
		{
			
			string CacheKey = "PBnet_ADRecordModel-" + pb_ADid+pb_VsTime+pb_VsIP+id;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(pb_ADid,pb_VsTime,pb_VsIP,id);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Pbzx.Model.PBnet_ADRecord)objModel;
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
		public List<Pbzx.Model.PBnet_ADRecord> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<Pbzx.Model.PBnet_ADRecord> modelList = new List<Pbzx.Model.PBnet_ADRecord>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				Pbzx.Model.PBnet_ADRecord model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Pbzx.Model.PBnet_ADRecord();
					//model.id=ds.Tables[0].Rows[n]["id"].ToString();
					//model.pb_ADid=ds.Tables[0].Rows[n]["pb_ADid"].ToString();
					if(ds.Tables[0].Rows[n]["pb_VsTime"].ToString()!="")
					{
						model.pb_VsTime=DateTime.Parse(ds.Tables[0].Rows[n]["pb_VsTime"].ToString());
					}
					model.pb_VsIP=ds.Tables[0].Rows[n]["pb_VsIP"].ToString();
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

