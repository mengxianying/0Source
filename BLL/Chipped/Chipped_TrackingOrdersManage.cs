using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Pbzx.DALFactory;
using System.Collections.Generic;
namespace Pbzx.BLL
{
    /// <summary>
    /// 业务逻辑类Chipped_TrackingOrders 的摘要说明。
    /// </summary>
    public class Chipped_TrackingOrders
    {
        private static readonly IChipped_TrackingOrders dal = DataAccess.CreateChipped_TrackingOrders();
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("Chipped_TrackingOrders", "TrackingID");
        public Chipped_TrackingOrders()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int TrackingID)
        {
            return dal.Exists(TrackingID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.Chipped_TrackingOrders model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Pbzx.Model.Chipped_TrackingOrders model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int TrackingID)
        {

            return dal.Delete(TrackingID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string TrackingIDlist)
        {
            return dal.DeleteList(TrackingIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.Chipped_TrackingOrders GetModel(int TrackingID)
        {

            return dal.GetModel(TrackingID);
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
        public List<Pbzx.Model.Chipped_TrackingOrders> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Pbzx.Model.Chipped_TrackingOrders> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.Chipped_TrackingOrders> modelList = new List<Pbzx.Model.Chipped_TrackingOrders>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.Chipped_TrackingOrders model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.Chipped_TrackingOrders();
                    if (dt.Rows[n]["TrackingID"].ToString() != "")
                    {
                        model.TrackingID = int.Parse(dt.Rows[n]["TrackingID"].ToString());
                    }
                    model.UserN = dt.Rows[n]["UserN"].ToString();
                    if (dt.Rows[n]["TrackingLNum"].ToString() != "")
                    {
                        model.TrackingLNum = int.Parse(dt.Rows[n]["TrackingLNum"].ToString());
                    }
                    model.TrackingName = dt.Rows[n]["TrackingName"].ToString();
                    if (dt.Rows[n]["TrackingTime"].ToString() != "")
                    {
                        model.TrackingTime = DateTime.Parse(dt.Rows[n]["TrackingTime"].ToString());
                    }
                    if (dt.Rows[n]["SubscribeNum"].ToString() != "")
                    {
                        model.SubscribeNum = int.Parse(dt.Rows[n]["SubscribeNum"].ToString());
                    }
                    if (dt.Rows[n]["BuyMoney"].ToString() != "")
                    {
                        model.BuyMoney = decimal.Parse(dt.Rows[n]["BuyMoney"].ToString());
                    }
                    if (dt.Rows[n]["TrackingState"].ToString() != "")
                    {
                        model.TrackingState = int.Parse(dt.Rows[n]["TrackingState"].ToString());
                    }
                    if (dt.Rows[n]["TrackingN"].ToString() != "")
                    {
                        model.TrackingN = int.Parse(dt.Rows[n]["TrackingN"].ToString());
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
        /// 根据查询字符串获取分页数据
        /// 创建人: zhouwei
        /// 创建时间: 2011-03-21
        /// </summary>
        /// <param name="SearchStr">查询字符串 </param>
        /// <param name="getFileds">获取列</param>
        /// <param name="OrderStr">排序字段</param>
        /// <param name="PageNum">获取的数据数</param>
        /// <param name="desc">升序还是降序</param>
        /// <param name="CurrentPage">当前的页数</param>
        /// <param name="Counts">返回记录集总数</param>
        /// <returns></returns>         

        public DataTable GuestGetBySearchTracking(string SearchStr, string getFileds, string OrderStr, int PageNum, int orderType, int CurrentPage, out int Counts)
        {
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "Chipped_TrackingOrders", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }

        #endregion  成员方法
    }
}


