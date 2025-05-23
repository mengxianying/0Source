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
    /// 业务逻辑类FCSSData 的摘要说明。
    /// </summary>
    public class FCSSData
    {
        private readonly IFCSSData dal = DataAccess.CreateFCSSData();
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("FCSSData", "issue");
        public FCSSData()
        {
            basicDAL.IsCst = true;
        }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string issue)
        {
            return dal.Exists(issue);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Pbzx.Model.FCSSData model)
        {
            return dal.Add(model) > 0 ? true : false; 
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Pbzx.Model.FCSSData model)
        {
            return dal.Update(model) > 0 ? true : false; 
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string issue)
        {

            return dal.Delete(issue) > 0 ? true : false; 
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.FCSSData GetModel(string issue)
        {

            return dal.GetModel(issue);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中。
        /// </summary>
        public Pbzx.Model.FCSSData GetModelByCache(string issue)
        {

            string CacheKey = "FCSSDataModel-" + issue;
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
            return (Pbzx.Model.FCSSData)objModel;
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
        public List<Pbzx.Model.FCSSData> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            List<Pbzx.Model.FCSSData> modelList = new List<Pbzx.Model.FCSSData>();
            int rowsCount = ds.Tables[0].Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.FCSSData model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.FCSSData();
                    if (ds.Tables[0].Rows[n]["date"].ToString() != "")
                    {
                        model.date = DateTime.Parse(ds.Tables[0].Rows[n]["date"].ToString());
                    }
                    model.issue = ds.Tables[0].Rows[n]["issue"].ToString();
                    model.redcode = ds.Tables[0].Rows[n]["redcode"].ToString();
                    model.bluecode = ds.Tables[0].Rows[n]["bluecode"].ToString();
                    model.bluecode2 = ds.Tables[0].Rows[n]["bluecode2"].ToString();
                    if (ds.Tables[0].Rows[n]["LastModifytime"].ToString() != "")
                    {
                        model.LastModifytime = DateTime.Parse(ds.Tables[0].Rows[n]["LastModifytime"].ToString());
                    }
                    model.OpName = ds.Tables[0].Rows[n]["OpName"].ToString();
                    model.OpIP = ds.Tables[0].Rows[n]["OpIP"].ToString();
                    if (ds.Tables[0].Rows[n]["MachineID"].ToString() != "")
                    {
                        model.MachineID = int.Parse(ds.Tables[0].Rows[n]["MachineID"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["Sales"].ToString() != "")
                    {
                        model.Sales = int.Parse(ds.Tables[0].Rows[n]["Sales"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["BonusPool"].ToString() != "")
                    {
                        model.BonusPool = int.Parse(ds.Tables[0].Rows[n]["BonusPool"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["Count1"].ToString() != "")
                    {
                        model.Count1 = int.Parse(ds.Tables[0].Rows[n]["Count1"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["Bonus1"].ToString() != "")
                    {
                        model.Bonus1 = int.Parse(ds.Tables[0].Rows[n]["Bonus1"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["Count2"].ToString() != "")
                    {
                        model.Count2 = int.Parse(ds.Tables[0].Rows[n]["Count2"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["Bonus2"].ToString() != "")
                    {
                        model.Bonus2 = int.Parse(ds.Tables[0].Rows[n]["Bonus2"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["Count3"].ToString() != "")
                    {
                        model.Count3 = int.Parse(ds.Tables[0].Rows[n]["Count3"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["Count4"].ToString() != "")
                    {
                        model.Count4 = int.Parse(ds.Tables[0].Rows[n]["Count4"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["Count5"].ToString() != "")
                    {
                        model.Count5 = int.Parse(ds.Tables[0].Rows[n]["Count5"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["Count6"].ToString() != "")
                    {
                        model.Count6 = int.Parse(ds.Tables[0].Rows[n]["Count6"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["Sunday"].ToString() != "")
                    {
                        model.Sunday = int.Parse(ds.Tables[0].Rows[n]["Sunday"].ToString());
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

