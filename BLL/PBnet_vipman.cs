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
	/// ҵ���߼���PBnet_vipman ��ժҪ˵����
	/// </summary>
	public class PBnet_vipman
	{
		private readonly IPBnet_vipman dal=DataAccess.CreatePBnet_vipman();
		public PBnet_vipman()
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
		public bool Exists(int Master_Id)
		{
			return dal.Exists(Master_Id);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(Pbzx.Model.PBnet_vipman model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(Pbzx.Model.PBnet_vipman model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int Master_Id)
		{
			
			dal.Delete(Master_Id);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Pbzx.Model.PBnet_vipman GetModel(int Master_Id)
		{
			
			return dal.GetModel(Master_Id);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public Pbzx.Model.PBnet_vipman GetModelByCache(int Master_Id)
		{
			
			string CacheKey = "PBnet_vipmanModel-" + Master_Id;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(Master_Id);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Pbzx.Model.PBnet_vipman)objModel;
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
		public List<Pbzx.Model.PBnet_vipman> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<Pbzx.Model.PBnet_vipman> modelList = new List<Pbzx.Model.PBnet_vipman>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				Pbzx.Model.PBnet_vipman model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Pbzx.Model.PBnet_vipman();
					if(ds.Tables[0].Rows[n]["Master_Id"].ToString()!="")
					{
						model.Master_Id=int.Parse(ds.Tables[0].Rows[n]["Master_Id"].ToString());
					}
					model.Master_Name=ds.Tables[0].Rows[n]["Master_Name"].ToString();
					model.Master_Password=ds.Tables[0].Rows[n]["Master_Password"].ToString();
					model.Column_Setting=ds.Tables[0].Rows[n]["Column_Setting"].ToString();
					model.Setting=ds.Tables[0].Rows[n]["Setting"].ToString();
					if(ds.Tables[0].Rows[n]["LasTime"].ToString()!="")
					{
						model.LasTime=DateTime.Parse(ds.Tables[0].Rows[n]["LasTime"].ToString());
					}
					model.LastIP=ds.Tables[0].Rows[n]["LastIP"].ToString();
					model.Cookiess=ds.Tables[0].Rows[n]["Cookiess"].ToString();
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

