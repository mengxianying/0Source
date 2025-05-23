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
	/// ҵ���߼���PBnet_adminloginlog ��ժҪ˵����
	/// </summary>
	public class PBnet_adminloginlog
	{
		private readonly IPBnet_adminloginlog dal=DataAccess.CreatePBnet_adminloginlog();
		public PBnet_adminloginlog()
		{}
		#region  ��Ա����
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(string log_username,DateTime log_time,long id)
		{
			return dal.Exists(log_username,log_time,id);
		} 

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(Pbzx.Model.PBnet_adminloginlog model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(Pbzx.Model.PBnet_adminloginlog model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(string log_username,DateTime log_time,long id)
		{
			
			dal.Delete(log_username,log_time,id);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Pbzx.Model.PBnet_adminloginlog GetModel(string log_username,DateTime log_time,long id)
		{
			
			return dal.GetModel(log_username,log_time,id);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public Pbzx.Model.PBnet_adminloginlog GetModelByCache(string log_username,DateTime log_time,long id)
		{
			
			string CacheKey = "PBnet_adminloginlogModel-" + log_username+log_time+id;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(log_username,log_time,id);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Pbzx.Model.PBnet_adminloginlog)objModel;
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Pbzx.Model.PBnet_adminloginlog> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<Pbzx.Model.PBnet_adminloginlog> modelList = new List<Pbzx.Model.PBnet_adminloginlog>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				Pbzx.Model.PBnet_adminloginlog model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Pbzx.Model.PBnet_adminloginlog();
					//model.id=ds.Tables[0].Rows[n]["id"].ToString();
					model.log_username=ds.Tables[0].Rows[n]["log_username"].ToString();
					model.log_password=ds.Tables[0].Rows[n]["log_password"].ToString();
					if(ds.Tables[0].Rows[n]["log_time"].ToString()!="")
					{
						model.log_time=DateTime.Parse(ds.Tables[0].Rows[n]["log_time"].ToString());
					}
					model.log_Ip=ds.Tables[0].Rows[n]["log_Ip"].ToString();
					model.log_state=ds.Tables[0].Rows[n]["log_state"].ToString();
					model.log_stepinto=ds.Tables[0].Rows[n]["log_stepinto"].ToString();
					model.log_urlname=ds.Tables[0].Rows[n]["log_urlname"].ToString();
					model.log_allhttp=ds.Tables[0].Rows[n]["log_allhttp"].ToString();
					model.log_country=ds.Tables[0].Rows[n]["log_country"].ToString();
					model.log_city=ds.Tables[0].Rows[n]["log_city"].ToString();
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
	}
}

