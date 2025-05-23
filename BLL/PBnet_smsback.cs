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
	/// ҵ���߼���PBnet_smsback ��ժҪ˵����
	/// </summary>
	public class PBnet_smsback
	{
		private readonly IPBnet_smsback dal=DataAccess.CreatePBnet_smsback();
		public PBnet_smsback()
		{}
		#region  ��Ա����

		/// <summary>
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int id)
		{
			return dal.Exists(id);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(Pbzx.Model.PBnet_smsback model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(Pbzx.Model.PBnet_smsback model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int id)
		{
			
			dal.Delete(id);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Pbzx.Model.PBnet_smsback GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public Pbzx.Model.PBnet_smsback GetModelByCache(int id)
		{
			
			string CacheKey = "PBnet_smsbackModel-" + id;
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
			return (Pbzx.Model.PBnet_smsback)objModel;
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
		public List<Pbzx.Model.PBnet_smsback> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<Pbzx.Model.PBnet_smsback> modelList = new List<Pbzx.Model.PBnet_smsback>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				Pbzx.Model.PBnet_smsback model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Pbzx.Model.PBnet_smsback();
					if(ds.Tables[0].Rows[n]["id"].ToString()!="")
					{
						model.id=int.Parse(ds.Tables[0].Rows[n]["id"].ToString());
					}
					if(ds.Tables[0].Rows[n]["pbactionid"].ToString()!="")
					{
						model.pbactionid=int.Parse(ds.Tables[0].Rows[n]["pbactionid"].ToString());
					}
					if(ds.Tables[0].Rows[n]["pbresultid"].ToString()!="")
					{
						model.pbresultid=int.Parse(ds.Tables[0].Rows[n]["pbresultid"].ToString());
					}
					model.pbrestring=ds.Tables[0].Rows[n]["pbrestring"].ToString();
					if(ds.Tables[0].Rows[n]["pbserviceid"].ToString()!="")
					{
						model.pbserviceid=int.Parse(ds.Tables[0].Rows[n]["pbserviceid"].ToString());
					}
					model.pbmobileid=ds.Tables[0].Rows[n]["pbmobileid"].ToString();
					model.pbpassword=ds.Tables[0].Rows[n]["pbpassword"].ToString();
					model.vsurl=ds.Tables[0].Rows[n]["vsurl"].ToString();
					if(ds.Tables[0].Rows[n]["vstime"].ToString()!="")
					{
						model.vstime=DateTime.Parse(ds.Tables[0].Rows[n]["vstime"].ToString());
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
	}
}

