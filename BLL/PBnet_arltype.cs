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
	/// ҵ���߼���PBnet_arltype ��ժҪ˵����
	/// </summary>
	public class PBnet_arltype
	{
		private readonly IPBnet_arltype dal=DataAccess.CreatePBnet_arltype();
		public PBnet_arltype()
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
		public bool Exists(int Id)
		{
			return dal.Exists(Id);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(Pbzx.Model.PBnet_arltype model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(Pbzx.Model.PBnet_arltype model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int Id)
		{
			
			dal.Delete(Id);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Pbzx.Model.PBnet_arltype GetModel(int Id)
		{
			
			return dal.GetModel(Id);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public Pbzx.Model.PBnet_arltype GetModelByCache(int Id)
		{
			
			string CacheKey = "PBnet_arltypeModel-" + Id;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(Id);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Pbzx.Model.PBnet_arltype)objModel;
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
		public List<Pbzx.Model.PBnet_arltype> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<Pbzx.Model.PBnet_arltype> modelList = new List<Pbzx.Model.PBnet_arltype>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				Pbzx.Model.PBnet_arltype model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Pbzx.Model.PBnet_arltype();
					if(ds.Tables[0].Rows[n]["Id"].ToString()!="")
					{
						model.Id=int.Parse(ds.Tables[0].Rows[n]["Id"].ToString());
					}
					model.pb_Title=ds.Tables[0].Rows[n]["pb_Title"].ToString();
					model.pb_Code=ds.Tables[0].Rows[n]["pb_Code"].ToString();
					if(ds.Tables[0].Rows[n]["pb_Type"].ToString()!="")
					{
						model.pb_Type=int.Parse(ds.Tables[0].Rows[n]["pb_Type"].ToString());
					}
					model.pb_Info=ds.Tables[0].Rows[n]["pb_Info"].ToString();
					if(ds.Tables[0].Rows[n]["pb_ViewNum"].ToString()!="")
					{
						model.pb_ViewNum=int.Parse(ds.Tables[0].Rows[n]["pb_ViewNum"].ToString());
					}
					if(ds.Tables[0].Rows[n]["pb_CountNum"].ToString()!="")
					{
						model.pb_CountNum=int.Parse(ds.Tables[0].Rows[n]["pb_CountNum"].ToString());
					}
					if(ds.Tables[0].Rows[n]["pb_MangerNum"].ToString()!="")
					{
						model.pb_MangerNum=int.Parse(ds.Tables[0].Rows[n]["pb_MangerNum"].ToString());
					}
					if(ds.Tables[0].Rows[n]["pb_IsOut"].ToString()!="")
					{
						if((ds.Tables[0].Rows[n]["pb_IsOut"].ToString()=="1")||(ds.Tables[0].Rows[n]["pb_IsOut"].ToString().ToLower()=="true"))
						{
						model.pb_IsOut=true;
						}
						else
						{
							model.pb_IsOut=false;
						}
					}
					model.pb_OutURL=ds.Tables[0].Rows[n]["pb_OutURL"].ToString();
					if(ds.Tables[0].Rows[n]["pb_StyleId"].ToString()!="")
					{
						model.pb_StyleId=int.Parse(ds.Tables[0].Rows[n]["pb_StyleId"].ToString());
					}
					if(ds.Tables[0].Rows[n]["pb_IsReview"].ToString()!="")
					{
						if((ds.Tables[0].Rows[n]["pb_IsReview"].ToString()=="1")||(ds.Tables[0].Rows[n]["pb_IsReview"].ToString().ToLower()=="true"))
						{
						model.pb_IsReview=true;
						}
						else
						{
							model.pb_IsReview=false;
						}
					}
					if(ds.Tables[0].Rows[n]["pb_IsPost"].ToString()!="")
					{
						if((ds.Tables[0].Rows[n]["pb_IsPost"].ToString()=="1")||(ds.Tables[0].Rows[n]["pb_IsPost"].ToString().ToLower()=="true"))
						{
						model.pb_IsPost=true;
						}
						else
						{
							model.pb_IsPost=false;
						}
					}
					if(ds.Tables[0].Rows[n]["pb_IsTop"].ToString()!="")
					{
						if((ds.Tables[0].Rows[n]["pb_IsTop"].ToString()=="1")||(ds.Tables[0].Rows[n]["pb_IsTop"].ToString().ToLower()=="true"))
						{
						model.pb_IsTop=true;
						}
						else
						{
							model.pb_IsTop=false;
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

