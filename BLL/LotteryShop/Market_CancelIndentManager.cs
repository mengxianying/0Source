using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using Pbzx.Model;
using Pbzx.DALFactory;
using Pbzx.IDAL;

namespace Pbzx.BLL
{
    public class Market_CancelIndent
    {
        private readonly IMarket_CancelIndent dal = DataAccess.CreateIMarket_CancelIndent();
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("Market_CancelIndent", "CancelID");
        public Market_CancelIndent()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int CancelID)
        {
            return dal.Exists(CancelID);
        }
        public bool Exists(string name, int Item)
        {
            return dal.Exists(name,Item);
            
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.Market_CancelIndent model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Pbzx.Model.Market_CancelIndent model)
        {
           return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int CancelID)
        {

            return dal.Delete(CancelID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.Market_CancelIndent GetModel(int CancelID)
        {

            return dal.GetModel(CancelID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中。
        /// </summary>
        public Pbzx.Model.Market_CancelIndent GetModelByCache(int CancelID)
        {

            string CacheKey = "Market_CancelIndentModel-" + CancelID;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(CancelID);
                    if (objModel != null)
                    {
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Pbzx.Model.Market_CancelIndent)objModel;
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
        public List<Pbzx.Model.Market_CancelIndent> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Pbzx.Model.Market_CancelIndent> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.Market_CancelIndent> modelList = new List<Pbzx.Model.Market_CancelIndent>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.Market_CancelIndent model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.Market_CancelIndent();
                    if (dt.Rows[n]["CancelID"].ToString() != "")
                    {
                        model.CancelID = int.Parse(dt.Rows[n]["CancelID"].ToString());
                    }
                    if (dt.Rows[n]["CancelIndent"].ToString() != "")
                    {
                        model.CancelIndent = int.Parse(dt.Rows[n]["CancelIndent"].ToString());
                    }
                    if (dt.Rows[n]["CTime"].ToString() != "")
                    {
                        model.CTime = DateTime.Parse(dt.Rows[n]["CTime"].ToString());
                    }
                    if (dt.Rows[n]["CApprove"].ToString() != "")
                    {
                        model.CApprove = int.Parse(dt.Rows[n]["CApprove"].ToString());
                    }
                    model.CancelName = dt.Rows[n]["CancelName"].ToString();
                    if (dt.Rows[n]["CancelItem"].ToString() != "")
                    {
                        model.CancelItem = int.Parse(dt.Rows[n]["CancelItem"].ToString());
                    }
                    model.CancelSake = dt.Rows[n]["CancelSake"].ToString();
                    model.Other = dt.Rows[n]["Other"].ToString();
                    if (dt.Rows[n]["approveTime"].ToString() != "")
                    {
                        model.approveTime = DateTime.Parse(dt.Rows[n]["approveTime"].ToString());
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
        /// <summary>
        /// 根据查询字符串获取分页数据
        /// 创建人: zhouwei
        /// 创建时间: 2011-1-18
        /// </summary>
        /// <param name="SearchStr">查询字符串 </param>
        /// <param name="getFileds">获取列</param>
        /// <param name="OrderStr">排序字段</param>
        /// <param name="PageNum">获取的数据数</param>
        /// <param name="desc">升序还是降序</param>
        /// <param name="CurrentPage">当前的页数</param>
        /// <param name="Counts">返回记录集总数</param>
        /// <returns></returns>         

        public DataTable GuestGetBySearch(string SearchStr, string getFileds, string OrderStr, int PageNum, int orderType, int CurrentPage, out int Counts)
        {
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "Market_CancelIndent", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }
        #endregion  成员方法
    }
}
