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
	/// 业务逻辑类PBnet_SoftComment 的摘要说明。
	/// </summary>
	public class PBnet_SoftComment
	{
		private readonly IPBnet_SoftComment dal=DataAccess.CreatePBnet_SoftComment();
		public PBnet_SoftComment()
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
		public bool Exists(int pb_CommentID)
		{
			return dal.Exists(pb_CommentID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Pbzx.Model.PBnet_SoftComment model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Pbzx.Model.PBnet_SoftComment model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int pb_CommentID)
		{
			
			dal.Delete(pb_CommentID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Pbzx.Model.PBnet_SoftComment GetModel(int pb_CommentID)
		{
			
			return dal.GetModel(pb_CommentID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public Pbzx.Model.PBnet_SoftComment GetModelByCache(int pb_CommentID)
		{
			
			string CacheKey = "PBnet_SoftCommentModel-" + pb_CommentID;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(pb_CommentID);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Pbzx.Model.PBnet_SoftComment)objModel;
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
		public List<Pbzx.Model.PBnet_SoftComment> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<Pbzx.Model.PBnet_SoftComment> modelList = new List<Pbzx.Model.PBnet_SoftComment>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				Pbzx.Model.PBnet_SoftComment model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Pbzx.Model.PBnet_SoftComment();
					if(ds.Tables[0].Rows[n]["pb_CommentID"].ToString()!="")
					{
						model.pb_CommentID=int.Parse(ds.Tables[0].Rows[n]["pb_CommentID"].ToString());
					}
					if(ds.Tables[0].Rows[n]["pb_ClassID"].ToString()!="")
					{
						model.pb_ClassID=int.Parse(ds.Tables[0].Rows[n]["pb_ClassID"].ToString());
					}
					if(ds.Tables[0].Rows[n]["pb_SoftID"].ToString()!="")
					{
						model.pb_SoftID=int.Parse(ds.Tables[0].Rows[n]["pb_SoftID"].ToString());
					}
					if(ds.Tables[0].Rows[n]["pb_UserType"].ToString()!="")
					{
						model.pb_UserType=int.Parse(ds.Tables[0].Rows[n]["pb_UserType"].ToString());
					}
					model.pb_UserName=ds.Tables[0].Rows[n]["pb_UserName"].ToString();
					model.pb_Sex=ds.Tables[0].Rows[n]["pb_Sex"].ToString();
					model.pb_qq=ds.Tables[0].Rows[n]["pb_qq"].ToString();
					model.pb_Msn=ds.Tables[0].Rows[n]["pb_Msn"].ToString();
					model.pb_Email=ds.Tables[0].Rows[n]["pb_Email"].ToString();
					model.pb_Homepage=ds.Tables[0].Rows[n]["pb_Homepage"].ToString();
					model.pb_IP=ds.Tables[0].Rows[n]["pb_IP"].ToString();
					if(ds.Tables[0].Rows[n]["pb_WriteTime"].ToString()!="")
					{
						model.pb_WriteTime=DateTime.Parse(ds.Tables[0].Rows[n]["pb_WriteTime"].ToString());
					}
					if(ds.Tables[0].Rows[n]["pb_Score"].ToString()!="")
					{
						model.pb_Score=int.Parse(ds.Tables[0].Rows[n]["pb_Score"].ToString());
					}
					model.pb_Content=ds.Tables[0].Rows[n]["pb_Content"].ToString();
					model.pb_ReplyName=ds.Tables[0].Rows[n]["pb_ReplyName"].ToString();
					model.pb_ReplyContent=ds.Tables[0].Rows[n]["pb_ReplyContent"].ToString();
					if(ds.Tables[0].Rows[n]["pb_ReplyTime"].ToString()!="")
					{
						model.pb_ReplyTime=DateTime.Parse(ds.Tables[0].Rows[n]["pb_ReplyTime"].ToString());
					}
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

