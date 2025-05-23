using System;
using System.Collections.Generic;
using System.Text;
using Pbzx.IDAL;
using System.Data;
using Pbzx.DALFactory;

namespace Pbzx.BLL
{
    /// <summary>
    /// 业务逻辑类Challenge_integral 的摘要说明。
    /// </summary>
    public class Challenge_integral
    {
        private readonly IChallenge_integral dal = DataAccess.CreateChallenge_integral();
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("Challenge_integral", "I_id");
        public Challenge_integral()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int I_id)
        {
            return dal.Exists(I_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.Challenge_integral model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Pbzx.Model.Challenge_integral model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int I_id)
        {

            return dal.Delete(I_id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string I_idlist)
        {
            return dal.DeleteList(I_idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.Challenge_integral GetModel(int I_id)
        {

            return dal.GetModel(I_id);
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
        public List<Pbzx.Model.Challenge_integral> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Pbzx.Model.Challenge_integral> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.Challenge_integral> modelList = new List<Pbzx.Model.Challenge_integral>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.Challenge_integral model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.Challenge_integral();
                    if (dt.Rows[n]["I_id"].ToString() != "")
                    {
                        model.I_id = int.Parse(dt.Rows[n]["I_id"].ToString());
                    }
                    model.I_name = dt.Rows[n]["I_name"].ToString();
                    if (dt.Rows[n]["I_lottid"].ToString() != "")
                    {
                        model.I_lottid = int.Parse(dt.Rows[n]["I_lottid"].ToString());
                    }
                    model.I_condName = dt.Rows[n]["I_condName"].ToString();
                    if (dt.Rows[n]["I_integral"].ToString() != "")
                    {
                        model.I_integral = int.Parse(dt.Rows[n]["I_integral"].ToString());
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

        //public DataSet GetRank(string strWhere, string TempWhere)
        //{
        //    return dal.GetRank(strWhere,TempWhere);
        //}

        /// <summary>
        /// //积分 按条件同统计
        /// </summary>
        /// <param name="V_table">视图名称</param>
        /// <param name="strWhere">条件</param>
        /// <returns></returns>
        public DataSet RankSSq(string V_table, string strWhere)
        {
            return dal.RankSSq(V_table, strWhere);
        }

        /// <summary>
        /// 获得前几行 的 积分排名
        /// </summary>
        /// <param name="V_table">视图名称</param>
        /// <param name="strWhere">条件</param>
        /// <returns></returns>
        public DataSet RankSSq(int Top, string V_table, string strWhere)
        {
            return dal.RankSSq(Top,V_table, strWhere);
        }


        /// <summary>
        /// 双色球积分查询
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <returns></returns>
        public DataSet selectRankS(string strWhere)
        {
            return dal.selectRankS(strWhere);
        }

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

        public DataTable GuestGetBySearchIntegral(string SearchStr, string getFileds, string OrderStr, int PageNum, int orderType, int CurrentPage, out int Counts)
        {
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "Challenge_integral", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }

        #endregion  Method
    }
}

