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
	/// 业务逻辑类PBnet_FreeReg 的摘要说明。
	/// </summary>
	public class PBnet_FreeReg
	{
		private readonly IPBnet_FreeReg dal=DataAccess.CreatePBnet_FreeReg();
		public PBnet_FreeReg()
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
		public bool Exists(string RN,int Status,int SoftwareType,int InstallType,int intFrID)
		{
			return dal.Exists(RN,Status,SoftwareType,InstallType,intFrID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Pbzx.Model.PBnet_FreeReg model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Pbzx.Model.PBnet_FreeReg model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string RN,int Status,int SoftwareType,int InstallType,int intFrID)
		{
			
			dal.Delete(RN,Status,SoftwareType,InstallType,intFrID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Pbzx.Model.PBnet_FreeReg GetModel(string RN,int Status,int SoftwareType,int InstallType,int intFrID)
		{
			
			return dal.GetModel(RN,Status,SoftwareType,InstallType,intFrID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public Pbzx.Model.PBnet_FreeReg GetModelByCache(string RN,int Status,int SoftwareType,int InstallType,int intFrID)
		{
			
			string CacheKey = "PBnet_FreeRegModel-" + RN+Status+SoftwareType+InstallType+intFrID;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(RN,Status,SoftwareType,InstallType,intFrID);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Pbzx.Model.PBnet_FreeReg)objModel;
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
		public List<Pbzx.Model.PBnet_FreeReg> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<Pbzx.Model.PBnet_FreeReg> modelList = new List<Pbzx.Model.PBnet_FreeReg>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				Pbzx.Model.PBnet_FreeReg model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Pbzx.Model.PBnet_FreeReg();
					if(ds.Tables[0].Rows[n]["intFrID"].ToString()!="")
					{
						model.intFrID=int.Parse(ds.Tables[0].Rows[n]["intFrID"].ToString());
					}
					model.RN=ds.Tables[0].Rows[n]["RN"].ToString();
					model.HDSN=ds.Tables[0].Rows[n]["HDSN"].ToString();
					if(ds.Tables[0].Rows[n]["Status"].ToString()!="")
					{
						model.Status=int.Parse(ds.Tables[0].Rows[n]["Status"].ToString());
					}
					if(ds.Tables[0].Rows[n]["SoftwareType"].ToString()!="")
					{
						model.SoftwareType=int.Parse(ds.Tables[0].Rows[n]["SoftwareType"].ToString());
					}
					if(ds.Tables[0].Rows[n]["InstallType"].ToString()!="")
					{
						model.InstallType=int.Parse(ds.Tables[0].Rows[n]["InstallType"].ToString());
					}
					if(ds.Tables[0].Rows[n]["RequestTime"].ToString()!="")
					{
						model.RequestTime=DateTime.Parse(ds.Tables[0].Rows[n]["RequestTime"].ToString());
					}
					if(ds.Tables[0].Rows[n]["RegisterTime"].ToString()!="")
					{
						model.RegisterTime=DateTime.Parse(ds.Tables[0].Rows[n]["RegisterTime"].ToString());
					}
					model.Username=ds.Tables[0].Rows[n]["Username"].ToString();
					model.UserTel=ds.Tables[0].Rows[n]["UserTel"].ToString();
					model.UserEmail=ds.Tables[0].Rows[n]["UserEmail"].ToString();
					model.UserAddress=ds.Tables[0].Rows[n]["UserAddress"].ToString();
					model.BbsID=ds.Tables[0].Rows[n]["BbsID"].ToString();
					if(ds.Tables[0].Rows[n]["NameError"].ToString()!="")
					{
						if((ds.Tables[0].Rows[n]["NameError"].ToString()=="1")||(ds.Tables[0].Rows[n]["NameError"].ToString().ToLower()=="true"))
						{
						model.NameError=true;
						}
						else
						{
							model.NameError=false;
						}
					}
					if(ds.Tables[0].Rows[n]["AddressError"].ToString()!="")
					{
						if((ds.Tables[0].Rows[n]["AddressError"].ToString()=="1")||(ds.Tables[0].Rows[n]["AddressError"].ToString().ToLower()=="true"))
						{
						model.AddressError=true;
						}
						else
						{
							model.AddressError=false;
						}
					}
					model.ErrorInfo=ds.Tables[0].Rows[n]["ErrorInfo"].ToString();
					model.Remarks=ds.Tables[0].Rows[n]["Remarks"].ToString();
					if(ds.Tables[0].Rows[n]["QueryCount"].ToString()!="")
					{
						model.QueryCount=int.Parse(ds.Tables[0].Rows[n]["QueryCount"].ToString());
					}
					if(ds.Tables[0].Rows[n]["QueryTime"].ToString()!="")
					{
						model.QueryTime=DateTime.Parse(ds.Tables[0].Rows[n]["QueryTime"].ToString());
					}
					model.QueryIP=ds.Tables[0].Rows[n]["QueryIP"].ToString();
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

