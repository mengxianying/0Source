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
	/// ҵ���߼���PBnet_smsfs ��ժҪ˵����
	/// </summary>
	public class PBnet_smsfs
	{
		private readonly IPBnet_smsfs dal=DataAccess.CreatePBnet_smsfs();
		public PBnet_smsfs()
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
		public int  Add(Pbzx.Model.PBnet_smsfs model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(Pbzx.Model.PBnet_smsfs model)
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
		public Pbzx.Model.PBnet_smsfs GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
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
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// ��������б�
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

