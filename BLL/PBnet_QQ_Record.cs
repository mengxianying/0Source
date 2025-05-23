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
    /// 业务逻辑类PBnet_QQ_Record 的摘要说明。
    /// </summary>
    public class PBnet_QQ_Record
    {
        private readonly IPBnet_QQ_Record dal = DataAccess.CreatePBnet_QQ_Record();
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("PBnet_QQ_Record", "ID");
        public PBnet_QQ_Record()
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
        public int Add(Pbzx.Model.PBnet_QQ_Record model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Pbzx.Model.PBnet_QQ_Record model)
        {
            return dal.Update(model) > 0 ? true : false ; 
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {

            return dal.Delete(ID) > 0 ? true : false; ;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.PBnet_QQ_Record GetModel(int ID)
        {

            return dal.GetModel(ID) ;
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中。
        /// </summary>
        public Pbzx.Model.PBnet_QQ_Record GetModelByCache(int ID)
        {

            string CacheKey = "PBnet_QQ_RecordModel-" + ID;
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
                catch { }
            }
            return (Pbzx.Model.PBnet_QQ_Record)objModel;
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
        public List<Pbzx.Model.PBnet_QQ_Record> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Pbzx.Model.PBnet_QQ_Record> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.PBnet_QQ_Record> modelList = new List<Pbzx.Model.PBnet_QQ_Record>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.PBnet_QQ_Record model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.PBnet_QQ_Record();
                    if (dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    if (dt.Rows[n]["QQ_GropID"].ToString() != "")
                    {
                        model.QQ_GropID = int.Parse(dt.Rows[n]["QQ_GropID"].ToString());
                    }
                    model.QQ_ID = dt.Rows[n]["QQ_ID"].ToString();
                    model.UserName = dt.Rows[n]["UserName"].ToString();
                    if (dt.Rows[n]["OnlineState"].ToString() != "")
                    {
                        model.OnlineState = int.Parse(dt.Rows[n]["OnlineState"].ToString());
                    }
                    model.QQ_Detail = dt.Rows[n]["QQ_Detail"].ToString();
                    model.AddManager = dt.Rows[n]["AddManager"].ToString();
                    if (dt.Rows[n]["AddTime"].ToString() != "")
                    {
                        model.AddTime = DateTime.Parse(dt.Rows[n]["AddTime"].ToString());
                    }
                    model.KickOffManager = dt.Rows[n]["KickOffManager"].ToString();
                    if (dt.Rows[n]["KickOffTime"].ToString() != "")
                    {
                        model.KickOffTime = DateTime.Parse(dt.Rows[n]["KickOffTime"].ToString());
                    }
                    if (dt.Rows[n]["IsLock"].ToString() != "")
                    {
                        if ((dt.Rows[n]["IsLock"].ToString() == "1") || (dt.Rows[n]["IsLock"].ToString().ToLower() == "true"))
                        {
                            model.IsLock = true;
                        }
                        else
                        {
                            model.IsLock = false;
                        }
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


        /// <summary>
        /// 根据查询字符串获取分页数据
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
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "PBnet_QQ_Record", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }

    }
}

