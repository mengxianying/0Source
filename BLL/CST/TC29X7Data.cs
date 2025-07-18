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
    /// 业务逻辑类TC29X7Data 的摘要说明。
    /// </summary>
    public class TC29X7Data
    {
        private readonly ITC29X7Data dal = DataAccess.CreateTC29X7Data();
        public TC29X7Data()
        { }
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
        public bool Exists(int issue)
        {
            return dal.Exists(issue);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Pbzx.Model.TC29X7Data model)
        {
            return dal.Add(model) > 0 ? true : false; 
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Pbzx.Model.TC29X7Data model)
        {
            return dal.Update(model) > 0 ? true : false; 
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int issue)
        {

            return dal.Delete(issue) > 0 ? true : false; 
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.TC29X7Data GetModel(int issue)
        {

            return dal.GetModel(issue);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中。
        /// </summary>
        public Pbzx.Model.TC29X7Data GetModelByCache(int issue)
        {

            string CacheKey = "TC29X7DataModel-" + issue;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(issue);
                    if (objModel != null)
                    {
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Pbzx.Model.TC29X7Data)objModel;
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
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Pbzx.Model.TC29X7Data> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Pbzx.Model.TC29X7Data> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.TC29X7Data> modelList = new List<Pbzx.Model.TC29X7Data>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.TC29X7Data model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.TC29X7Data();
                    if (dt.Rows[n]["date"].ToString() != "")
                    {
                        model.date = DateTime.Parse(dt.Rows[n]["date"].ToString());
                    }
                    if (dt.Rows[n]["issue"].ToString() != "")
                    {
                        model.issue = int.Parse(dt.Rows[n]["issue"].ToString());
                    }
                    model.code = dt.Rows[n]["code"].ToString();
                    model.tcode = dt.Rows[n]["tcode"].ToString();
                    if (dt.Rows[n]["LastModifytime"].ToString() != "")
                    {
                        model.LastModifytime = DateTime.Parse(dt.Rows[n]["LastModifytime"].ToString());
                    }
                    model.OpName = dt.Rows[n]["OpName"].ToString();
                    model.OpIp = dt.Rows[n]["OpIp"].ToString();
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

