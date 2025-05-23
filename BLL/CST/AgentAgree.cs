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
    /// 业务逻辑类AgentAgree 的摘要说明。
    /// </summary>
    public class AgentAgree
    {
        private readonly IAgentAgree dal = DataAccess.CreateAgentAgree();
        public AgentAgree()
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
        public bool Add(Pbzx.Model.AgentAgree model)
        {
            return dal.Add(model) > 0 ? true : false;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Pbzx.Model.AgentAgree model)
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
        public Pbzx.Model.AgentAgree GetModel(int ID)
        {

            return dal.GetModel(ID);
        }
		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public Pbzx.Model.AgentAgree GetModelByCache(int ID)
		{
			
			string CacheKey = "AgentAgreeModel-" + ID;
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
			return (Pbzx.Model.AgentAgree)objModel;
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
		public List<Pbzx.Model.AgentAgree> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Pbzx.Model.AgentAgree> DataTableToList(DataTable dt)
		{
			List<Pbzx.Model.AgentAgree> modelList = new List<Pbzx.Model.AgentAgree>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Pbzx.Model.AgentAgree model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Pbzx.Model.AgentAgree();
					if(dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					model.Title=dt.Rows[n]["Title"].ToString();
					model.Content=dt.Rows[n]["Content"].ToString();
					model.AgreeUrl=dt.Rows[n]["AgreeUrl"].ToString();
					if(dt.Rows[n]["AddTime"].ToString()!="")
					{
						model.AddTime=DateTime.Parse(dt.Rows[n]["AddTime"].ToString());
					}
					if(dt.Rows[n]["State"].ToString()!="")
					{
						model.State=int.Parse(dt.Rows[n]["State"].ToString());
					}
					model.Purpose=dt.Rows[n]["Purpose"].ToString();
					if(dt.Rows[n]["IntChannelID"].ToString()!="")
					{
						model.IntChannelID=int.Parse(dt.Rows[n]["IntChannelID"].ToString());
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

        public Pbzx.Model.AgentAgree GetModelName(string Name)
        {

            List<Pbzx.Model.AgentAgree> ls = GetModelList(" Purpose='" + Name + "'and State=0");
            if (ls.Count > 0)
            {
                return ls[0];
            }
            else
            {
                return null;
            }
        }
        #endregion  成员方法

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Pbzx.Model.AgentAgree> GetTopList()
        {
            DataSet ds = dal.GetList(1, " ", "ID asc");
            return DataTableToList(ds.Tables[0]);
        }


        /// <summary>
        /// 自己定义根据用户名得到一个对象实体
        /// </summary>
        public Pbzx.Model.AgentAgree GetModelName()
        {
            List<Pbzx.Model.AgentAgree> ls = GetTopList();
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