using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Pbzx.IDAL;
using Pbzx.DALFactory;
using Pbzx.Model;

namespace Pbzx.BLL
{
    /// <summary>
    /// 业务逻辑类Market_CollASAtten 的摘要说明。
    /// </summary>
    public class Market_CollASAtten
    {
        private readonly IMarket_CollASAtten dal = DataAccess.CreateIMarket_CollASAtten();
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("Market_CollASAtten", "intId");

        public Market_CollASAtten()
        { }

        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int intId)
        {
            return dal.Exists(intId);
        }
        public bool Exists(string Uname, string appName,int statc,int mark)
        {
            return dal.Exists(Uname,appName,statc,mark);
        }
        
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.Market_CollASAtten model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Pbzx.Model.Market_CollASAtten model)
        {
           return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int intId)
        {

           return dal.Delete(intId);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.Market_CollASAtten GetModel(int intId)
        {

            return dal.GetModel(intId);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中。
        /// </summary>
        public Pbzx.Model.Market_CollASAtten GetModelByCache(int intId)
        {

            string CacheKey = "Market_CollASAttenModel-" + intId;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(intId);
                    if (objModel != null)
                    {
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Pbzx.Model.Market_CollASAtten)objModel;
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
        public List<Pbzx.Model.Market_CollASAtten> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Pbzx.Model.Market_CollASAtten> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.Market_CollASAtten> modelList = new List<Pbzx.Model.Market_CollASAtten>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.Market_CollASAtten model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.Market_CollASAtten();
                    if (dt.Rows[n]["intId"].ToString() != "")
                    {
                        model.intId = int.Parse(dt.Rows[n]["intId"].ToString());
                    }
                    model.Uname = dt.Rows[n]["Uname"].ToString();
                    model.appName = dt.Rows[n]["appName"].ToString();
                    if (dt.Rows[n]["statc"].ToString() != "")
                    {
                        model.statc = int.Parse(dt.Rows[n]["statc"].ToString());
                    }
                    if (dt.Rows[n]["mark"].ToString() != "")
                    {
                        model.mark = int.Parse(dt.Rows[n]["mark"].ToString());
                    }
                    if (dt.Rows[n]["appTime"].ToString() != "")
                    {
                        model.appTime = DateTime.Parse(dt.Rows[n]["appTime"].ToString());
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

        public DataSet Num(string strWhere)
        {
            return dal.GetList(strWhere);
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
        /// 创建时间: 2010-10-27
        /// </summary>
        /// <param name="SearchStr">查询字符串 </param>
        /// <param name="getFileds">获取列</param>
        /// <param name="OrderStr">排序字段</param>
        /// <param name="PageNum">获取的数据数</param>
        /// <param name="desc">升序还是降序</param>
        /// <param name="CurrentPage">当前的页数</param>
        /// <param name="Counts">返回记录集总数</param>
        /// <returns></returns>         

        public DataTable GuestGetBySearchCollasAttention(string SearchStr, string getFileds, string OrderStr, int PageNum, int orderType, int CurrentPage, out int Counts)
        {
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "Market_CollASAtten", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }


        #endregion  成员方法
    }
}
