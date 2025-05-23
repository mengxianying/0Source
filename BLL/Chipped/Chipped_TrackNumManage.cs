using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Pbzx.DALFactory;
using Pbzx.IDAL;

namespace Pbzx.BLL
{
    /// <summary>
    /// Chipped_TrackNum
    /// </summary>
    public partial class Chipped_TrackNum
    {
        private readonly IChipped_TrackNum dal = DataAccess.CreateChipped_TrackNum();
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("Chipped_TrackNum", "tn_time");
        public Chipped_TrackNum()
        { }
        #region  Method

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
        public bool Exists(int tn_id)
        {
            return dal.Exists(tn_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.Chipped_TrackNum model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Pbzx.Model.Chipped_TrackNum model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int tn_id)
        {

            return dal.Delete(tn_id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string tn_idlist)
        {
            return dal.DeleteList(tn_idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.Chipped_TrackNum GetModel(int tn_id)
        {

            return dal.GetModel(tn_id);
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
        public List<Pbzx.Model.Chipped_TrackNum> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Pbzx.Model.Chipped_TrackNum> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.Chipped_TrackNum> modelList = new List<Pbzx.Model.Chipped_TrackNum>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.Chipped_TrackNum model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.Chipped_TrackNum();
                    if (dt.Rows[n]["tn_id"].ToString() != "")
                    {
                        model.tn_id = int.Parse(dt.Rows[n]["tn_id"].ToString());
                    }
                    model.tn_orderNum = dt.Rows[n]["tn_orderNum"].ToString();
                    model.tn_username = dt.Rows[n]["tn_username"].ToString();
                    if (dt.Rows[n]["tn_playname"].ToString() != "")
                    {
                        model.tn_playname = int.Parse(dt.Rows[n]["tn_playname"].ToString());
                    }
                    model.tn_stopCondition = dt.Rows[n]["tn_stopCondition"].ToString();
                    model.tn_issue = dt.Rows[n]["tn_issue"].ToString();
                    model.tn_num = dt.Rows[n]["tn_num"].ToString();
                    if (dt.Rows[n]["tn_multiple"].ToString() != "")
                    {
                        model.tn_multiple = int.Parse(dt.Rows[n]["tn_multiple"].ToString());
                    }
                    if (dt.Rows[n]["tn_money"].ToString() != "")
                    {
                        model.tn_money = decimal.Parse(dt.Rows[n]["tn_money"].ToString());
                    }
                    if (dt.Rows[n]["tn_message"].ToString() != "")
                    {
                        model.tn_message = int.Parse(dt.Rows[n]["tn_message"].ToString());
                    }
                    if (dt.Rows[n]["tn_time"].ToString() != "")
                    {
                        model.tn_time = DateTime.Parse(dt.Rows[n]["tn_time"].ToString());
                    }
                    if (dt.Rows[n]["tn_complete"].ToString() != "")
                    {
                        model.tn_complete = int.Parse(dt.Rows[n]["tn_complete"].ToString());
                    }
                    if (dt.Rows[n]["tn_Inward"].ToString() != "")
                    {
                        model.tn_Inward = decimal.Parse(dt.Rows[n]["tn_Inward"].ToString());
                    }
                    model.tn_order = dt.Rows[n]["tn_order"].ToString();
                    if (dt.Rows[n]["tn_open"].ToString() != "")
                    {
                        model.tn_open = int.Parse(dt.Rows[n]["tn_open"].ToString());
                    }
                    if (dt.Rows[n]["tn_dtbt"].ToString() != "")
                    {
                        model.tn_dtbt = int.Parse(dt.Rows[n]["tn_dtbt"].ToString());
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
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}
        /// <summary>
        /// 根据查询字符串获取分页数据
        /// 创建人: zhouwei
        /// 创建时间: 2011-12-13
        /// </summary>
        /// <param name="SearchStr">查询字符串 </param>
        /// <param name="getFileds">获取列</param>
        /// <param name="OrderStr">排序字段</param>
        /// <param name="PageNum">获取的数据数</param>
        /// <param name="desc">升序还是降序</param>
        /// <param name="CurrentPage">当前的页数</param>
        /// <param name="Counts">返回记录集总数</param>
        /// <returns></returns>         

        public DataTable GuestGetBySearchTrackNum(string SearchStr, string getFileds, string OrderStr, int PageNum, int orderType, int CurrentPage, out int Counts)
        {
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "Chipped_TrackNum", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }

        #endregion  Method
    }
}
