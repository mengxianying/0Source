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
    /// 业务逻辑类Market_Num 的摘要说明。
    /// </summary>
    public class Market_NumManager
    {
        private readonly IMarket_Num dal = DataAccess.CreateIMarket_Num();

        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("Market_Num", "id");

        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }
        /// <summary>
        /// 重载方法
        /// 创建人: zhouwei
        /// 创建时间: 2010-11-25
        /// </summary>
        /// <param name="id">项目ID</param>
        /// <param name="expctNum">期号</param>
        /// <returns></returns>
        public bool Exists(int id, string expctNum, string radio)
        {
            return dal.Exists(id, expctNum, radio);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.Market_Num model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Pbzx.Model.Market_Num model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int id)
        {

            return dal.Delete(id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.Market_Num GetModel(int id)
        {

            return dal.GetModel(id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中。
        /// </summary>
        public Pbzx.Model.Market_Num GetModelByCache(int id)
        {

            string CacheKey = "Market_NumModel-" + id;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(id);
                    if (objModel != null)
                    {
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Pbzx.Model.Market_Num)objModel;
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
        public List<Pbzx.Model.Market_Num> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Pbzx.Model.Market_Num> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.Market_Num> modelList = new List<Pbzx.Model.Market_Num>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.Market_Num model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.Market_Num();
                    if (dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["ItemID"].ToString() != "")
                    {
                        model.ItemID = int.Parse(dt.Rows[n]["ItemID"].ToString());
                    }
                    model.ExpectNum = dt.Rows[n]["ExpectNum"].ToString();
                    model.appendName = dt.Rows[n]["appendName"].ToString();
                    model.IssueTime = dt.Rows[n]["IssueTime"].ToString();
                    if (dt.Rows[n]["Commend"].ToString() != "")
                    {
                        model.Commend = int.Parse(dt.Rows[n]["Commend"].ToString());
                    }
                    model.Content = dt.Rows[n]["Content"].ToString();
                    if (dt.Rows[n]["itemidentity"].ToString() != "")
                    {
                        model.itemidentity = int.Parse(dt.Rows[n]["itemidentity"].ToString());
                    }
                    model.itemradio = dt.Rows[n]["itemradio"].ToString();
                    model.itemcheck = dt.Rows[n]["itemcheck"].ToString();
                    model.itemnumber = dt.Rows[n]["itemnumber"].ToString();
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
        /// 创建时间: 2010-11-10
        /// </summary>
        /// <param name="SearchStr">查询字符串 </param>
        /// <param name="getFileds">获取列</param>
        /// <param name="OrderStr">排序字段</param>
        /// <param name="PageNum">获取的数据数</param>
        /// <param name="desc">升序还是降序</param>
        /// <param name="CurrentPage">当前的页数</param>
        /// <param name="Counts">返回记录集总数</param>
        /// <returns></returns>         

        public DataTable GuestGetBySearchNum(string SearchStr, string getFileds, string OrderStr, int PageNum, int orderType, int CurrentPage, out int Counts)
        {
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "Market_Num", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }
        /// <summary>
        /// 中奖和预测中奖对比
        /// </summary>
        /// <param name="AwardIssue">中奖号码</param>
        /// <param name="ForeIssue">预测期号</param>
        /// 
        public void ExistsAward(string AwardNumber, string ForeIssue)
        {
            //根据期号，得到预测号码的所有信息

            //将预测号码和中奖号码对比
            //当存在相同条件的数时，给他标识为中奖
        }

        #endregion  成员方法
    }
}
