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
    /// 业务逻辑类PBnet_About 的摘要说明。
    /// </summary>
    public class PBnet_About
    {
        private readonly IPBnet_About dal = DataAccess.CreatePBnet_About();
        public PBnet_About()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            return dal.Exists(ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Pbzx.Model.PBnet_About model)
        {
            return dal.Add(model) > 0 ? true : false;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Pbzx.Model.PBnet_About model)
        {
            return dal.Update(model) > 0 ? true : false;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {

            return dal.Delete(ID) > 0 ? true : false;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.PBnet_About GetModel(int ID)
        {

            return dal.GetModel(ID);
        }


        /// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public Pbzx.Model.PBnet_About GetModelByCache(int ID)
		{
			
			string CacheKey = "PBnet_AboutModel-" + ID;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ID);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Pbzx.Model.PBnet_About)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Pbzx.Model.PBnet_About> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Pbzx.Model.PBnet_About> DataTableToList(DataTable dt)
		{
			List<Pbzx.Model.PBnet_About> modelList = new List<Pbzx.Model.PBnet_About>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Pbzx.Model.PBnet_About model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Pbzx.Model.PBnet_About();
					if(dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					model.UsTitle=dt.Rows[n]["UsTitle"].ToString();
					model.UsContent=dt.Rows[n]["UsContent"].ToString();
					if(dt.Rows[n]["UsState"].ToString()!="")
					{
						if((dt.Rows[n]["UsState"].ToString()=="1")||(dt.Rows[n]["UsState"].ToString().ToLower()=="true"))
						{
						model.UsState=true;
						}
						else
						{
							model.UsState=false;
						}
					}
					if(dt.Rows[n]["UsAddTime"].ToString()!="")
					{
						model.UsAddTime=DateTime.Parse(dt.Rows[n]["UsAddTime"].ToString());
					}
					if(dt.Rows[n]["UsOrder"].ToString()!="")
					{
						model.UsOrder=int.Parse(dt.Rows[n]["UsOrder"].ToString());
					}
					if(dt.Rows[n]["UsIsBtommShow"].ToString()!="")
					{
						if((dt.Rows[n]["UsIsBtommShow"].ToString()=="1")||(dt.Rows[n]["UsIsBtommShow"].ToString().ToLower()=="true"))
						{
						model.UsIsBtommShow=true;
						}
						else
						{
							model.UsIsBtommShow=false;
						}
					}
					model.UsUrl=dt.Rows[n]["UsUrl"].ToString();
					model.HtmlUrl=dt.Rows[n]["HtmlUrl"].ToString();
					model.AspxUrl=dt.Rows[n]["AspxUrl"].ToString();
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
	

        /// <summary>
        /// 更改Bool类型字段状态
        /// </summary>
        /// <param name="id">编号</param>
        /// <param name="filed">字段名</param>
        public static void ChangeAudit(int id, string filed)
        {
            Pbzx.SQLServerDAL.Basic basicDAL1 = new Pbzx.SQLServerDAL.Basic("PBnet_About", "ID");
            basicDAL1.ChangeAudit(id, filed);
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Pbzx.Model.PBnet_About> GetTopList()
        {
            DataSet ds = dal.GetList(1, " ", "Id");
            return DataTableToList(ds.Tables[0]);
        }

  
        /// <summary>
        /// 自己定义根据用户名得到一个对象实体
        /// </summary>
        public Pbzx.Model.PBnet_About GetModelName()
        {
            List<Pbzx.Model.PBnet_About> ls = GetTopList();
            if (ls.Count > 0)
            {
                return ls[0];
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Pbzx.Model.PBnet_About> GetTopInt()
        {
            DataSet ds = dal.GetList(1, " ", "Id Desc");
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 自己定义根据用户名得到最大ID
        /// </summary>
        public Pbzx.Model.PBnet_About GetIntId()
        {
            List<Pbzx.Model.PBnet_About> ls = GetTopInt();
            if (ls.Count > 0)
            {
                return ls[0];
            }
            else
            {
                return null;
            }
        }
    }
}

