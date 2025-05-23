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
	/// ҵ���߼���PBnet_pb_3d2005ord ��ժҪ˵����
	/// </summary>
	public class PBnet_pb_3d2005ord
	{
		private readonly IPBnet_pb_3d2005ord dal=DataAccess.CreatePBnet_pb_3d2005ord();
		public PBnet_pb_3d2005ord()
		{}
		#region  ��Ա����
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(long id)
		{
			return dal.Exists(id);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(Pbzx.Model.PBnet_pb_3d2005ord model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(Pbzx.Model.PBnet_pb_3d2005ord model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(long id)
		{
			
			dal.Delete(id);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Pbzx.Model.PBnet_pb_3d2005ord GetModel(long id)
		{
			
			return dal.GetModel(id);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public Pbzx.Model.PBnet_pb_3d2005ord GetModelByCache(long id)
		{
			
			string CacheKey = "PBnet_pb_3d2005ordModel-" + id;
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
			return (Pbzx.Model.PBnet_pb_3d2005ord)objModel;
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
		public List<Pbzx.Model.PBnet_pb_3d2005ord> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<Pbzx.Model.PBnet_pb_3d2005ord> modelList = new List<Pbzx.Model.PBnet_pb_3d2005ord>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				Pbzx.Model.PBnet_pb_3d2005ord model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Pbzx.Model.PBnet_pb_3d2005ord();
					//model.id=ds.Tables[0].Rows[n]["id"].ToString();
					model.username=ds.Tables[0].Rows[n]["username"].ToString();
					model.usertel=ds.Tables[0].Rows[n]["usertel"].ToString();
					model.usermail=ds.Tables[0].Rows[n]["usermail"].ToString();
					model.useraddress=ds.Tables[0].Rows[n]["useraddress"].ToString();
					model.ordfrom=ds.Tables[0].Rows[n]["ordfrom"].ToString();
					if(ds.Tables[0].Rows[n]["ordfromnum"].ToString()!="")
					{
						model.ordfromnum=int.Parse(ds.Tables[0].Rows[n]["ordfromnum"].ToString());
					}
					if(ds.Tables[0].Rows[n]["orddate"].ToString()!="")
					{
						model.orddate=DateTime.Parse(ds.Tables[0].Rows[n]["orddate"].ToString());
					}
					if(ds.Tables[0].Rows[n]["State"].ToString()!="")
					{
						if((ds.Tables[0].Rows[n]["State"].ToString()=="1")||(ds.Tables[0].Rows[n]["State"].ToString().ToLower()=="true"))
						{
						model.State=true;
						}
						else
						{
							model.State=false;
						}
					}
					model.userip=ds.Tables[0].Rows[n]["userip"].ToString();
					if(ds.Tables[0].Rows[n]["usedate"].ToString()!="")
					{
						model.usedate=DateTime.Parse(ds.Tables[0].Rows[n]["usedate"].ToString());
					}
					model.userlog=ds.Tables[0].Rows[n]["userlog"].ToString();
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

