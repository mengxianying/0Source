using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using Pbzx.Model;
namespace Pbzx.BLL
{
	/// <summary>
	/// ҵ���߼���PBnet_PortType ��ժҪ˵����
	/// </summary>
	public class PBnet_PortType
	{
        private readonly Pbzx.SQLServerDAL.PBnet_PortType dal = new Pbzx.SQLServerDAL.PBnet_PortType();
		public PBnet_PortType()
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
		public bool Exists(int PortTypeID)
		{
			return dal.Exists(PortTypeID);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(Pbzx.Model.PBnet_PortType model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(Pbzx.Model.PBnet_PortType model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int PortTypeID)
		{
			
			dal.Delete(PortTypeID);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Pbzx.Model.PBnet_PortType GetModel(int PortTypeID)
		{
			
			return dal.GetModel(PortTypeID);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public Pbzx.Model.PBnet_PortType GetModelByCache(int PortTypeID)
		{
			
			string CacheKey = "PBnet_PortTypeModel-" + PortTypeID;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(PortTypeID);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Pbzx.Model.PBnet_PortType)objModel;
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// ���ǰ��������
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Pbzx.Model.PBnet_PortType> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Pbzx.Model.PBnet_PortType> DataTableToList(DataTable dt)
		{
			List<Pbzx.Model.PBnet_PortType> modelList = new List<Pbzx.Model.PBnet_PortType>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Pbzx.Model.PBnet_PortType model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Pbzx.Model.PBnet_PortType();
					if(dt.Rows[n]["PortTypeID"].ToString()!="")
					{
						model.PortTypeID=int.Parse(dt.Rows[n]["PortTypeID"].ToString());
					}
					model.PortTypeName=dt.Rows[n]["PortTypeName"].ToString();
					if(dt.Rows[n]["PortPrice"].ToString()!="")
					{
						model.PortPrice=decimal.Parse(dt.Rows[n]["PortPrice"].ToString());
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

