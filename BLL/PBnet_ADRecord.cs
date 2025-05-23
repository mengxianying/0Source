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
	/// ҵ���߼���PBnet_ADRecord ��ժҪ˵����
	/// </summary>
	public class PBnet_ADRecord
	{
		private readonly IPBnet_ADRecord dal=DataAccess.CreatePBnet_ADRecord();
		public PBnet_ADRecord()
		{}
		#region  ��Ա����
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(long pb_ADid,DateTime pb_VsTime,string pb_VsIP,long id)
		{
			return dal.Exists(pb_ADid,pb_VsTime,pb_VsIP,id);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(Pbzx.Model.PBnet_ADRecord model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(Pbzx.Model.PBnet_ADRecord model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(long pb_ADid,DateTime pb_VsTime,string pb_VsIP,long id)
		{
			
			dal.Delete(pb_ADid,pb_VsTime,pb_VsIP,id);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Pbzx.Model.PBnet_ADRecord GetModel(long pb_ADid,DateTime pb_VsTime,string pb_VsIP,long id)
		{
			
			return dal.GetModel(pb_ADid,pb_VsTime,pb_VsIP,id);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
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
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// ��������б�
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

