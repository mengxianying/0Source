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
    /// 业务逻辑类PBnet_LyResume 的摘要说明。
    /// </summary>
    public class PBnet_LyResume
    {
        private readonly IPBnet_LyResume dal = DataAccess.CreatePBnet_LyResume();
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("PBnet_LyResume", "SystemNumber");


        public PBnet_LyResume()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int SystemNumber)
        {
            return dal.Exists(SystemNumber);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Pbzx.Model.PBnet_LyResume model)
        {
            return dal.Add(model) > 0 ? true : false;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Pbzx.Model.PBnet_LyResume model)
        {
            return dal.Update(model) > 0 ? true : false;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int SystemNumber)
        {

            return dal.Delete(SystemNumber) > 0 ? true : false;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.PBnet_LyResume GetModel(int SystemNumber)
        {

            return dal.GetModel(SystemNumber);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中。
        /// </summary>
        public Pbzx.Model.PBnet_LyResume GetModelByCache(int SystemNumber)
        {

            string CacheKey = "PBnet_LyResumeModel-" + SystemNumber;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(SystemNumber);
                    if (objModel != null)
                    {
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Pbzx.Model.PBnet_LyResume)objModel;
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
        public List<Pbzx.Model.PBnet_LyResume> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Pbzx.Model.PBnet_LyResume> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.PBnet_LyResume> modelList = new List<Pbzx.Model.PBnet_LyResume>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.PBnet_LyResume model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.PBnet_LyResume();
                    if (dt.Rows[n]["SystemNumber"].ToString() != "")
                    {
                        model.SystemNumber = int.Parse(dt.Rows[n]["SystemNumber"].ToString());
                    }
                    if (dt.Rows[n]["LyListID"].ToString() != "")
                    {
                        model.LyListID = int.Parse(dt.Rows[n]["LyListID"].ToString());
                    }
                    if (dt.Rows[n]["ResumeTime"].ToString() != "")
                    {
                        model.ResumeTime = DateTime.Parse(dt.Rows[n]["ResumeTime"].ToString());
                    }
                    model.ResumeContent = dt.Rows[n]["ResumeContent"].ToString();
                    model.ResumeAuthor = dt.Rows[n]["ResumeAuthor"].ToString();
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

