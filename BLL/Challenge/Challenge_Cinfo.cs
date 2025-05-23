using System;
using System.Data;
using System.Collections.Generic;
using Pbzx.Model;
using Pbzx.DALFactory;
using Pbzx.IDAL;
namespace Pbzx.BLL
{
    /// <summary>
    /// Challenge_Cinfo
    /// </summary>
    public partial class Challenge_Cinfo
    {
        private readonly IChallenge_Cinfo dal = DataAccess.CreateChallenge_Cinfo();
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("v_ReCon", "C_id");
        public Challenge_Cinfo()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int C_id)
        {
            return dal.Exists(C_id);
        }
        public bool Exists(string name, int issue, int tid)
        {
            return dal.Exists(name,issue,tid);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.Challenge_Cinfo model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Pbzx.Model.Challenge_Cinfo model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int C_id)
        {

            return dal.Delete(C_id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string C_idlist)
        {
            return dal.DeleteList(C_idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.Challenge_Cinfo GetModel(int C_id)
        {

            return dal.GetModel(C_id);
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
        public DataSet GetBankTransfer(string strWhere)
        {
            return dal.GetBankTransfer(strWhere);
        }
        public DataSet GetBankTransferD(string strWhere)
        {
            return dal.GetBankTransferD(strWhere);
        }


        public DataSet GetStitaSSq(int Top, string strWhere)
        {
            return dal.GetStitaSSq(Top,strWhere);
        }

        public DataSet GetStitaD(int Top, string strWhere)
        {
            return dal.GetStitaD(Top, strWhere);
        }

        public DataSet GetStatiUser(int Top,string strWhere)
        {
            return dal.GetStatiUser(Top,strWhere);
        }
        public DataSet GetStatiUserD(int Top,string strWhere)
        {
            return dal.GetStatiUserD(Top,strWhere);
        }
        /// <summary>
        /// 排列3 列转行
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetBankTransferP(string strWhere)
        {
            return dal.GetBankTransferP(strWhere);
        }

        /// <summary>
        /// 统计排列3 中奖次数---按条件的和（中奖次数相加）
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetStatiUserP(int Top, string strWhere)
        {
            return dal.GetStatiUserP(Top, strWhere);
        }




        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Pbzx.Model.Challenge_Cinfo> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Pbzx.Model.Challenge_Cinfo> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.Challenge_Cinfo> modelList = new List<Pbzx.Model.Challenge_Cinfo>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.Challenge_Cinfo model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.Challenge_Cinfo();
                    if (dt.Rows[n]["C_id"].ToString() != "")
                    {
                        model.C_id = int.Parse(dt.Rows[n]["C_id"].ToString());
                    }
                    model.C_name = dt.Rows[n]["C_name"].ToString();
                    if (dt.Rows[n]["C_lottID"].ToString() != "")
                    {
                        model.C_lottID = int.Parse(dt.Rows[n]["C_lottID"].ToString());
                    }
                    if (dt.Rows[n]["C_issue"].ToString() != "")
                    {
                        model.C_issue = int.Parse(dt.Rows[n]["C_issue"].ToString());
                    }
                    if (dt.Rows[n]["C_time"].ToString() != "")
                    {
                        model.C_time = DateTime.Parse(dt.Rows[n]["C_time"].ToString());
                    }
                    if (dt.Rows[n]["C_Tid"].ToString() != "")
                    {
                        model.C_Tid = int.Parse(dt.Rows[n]["C_Tid"].ToString());
                    }
                    model.C_num = dt.Rows[n]["C_num"].ToString();
                    if (dt.Rows[n]["C_win"].ToString() != "")
                    {
                        model.C_win = int.Parse(dt.Rows[n]["C_win"].ToString());
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
        /// 用户的中奖排行 3D 双色球
        /// </summary>
        /// <param name="steWhere">查询条件</param>
        public DataSet GetCompOFs(int Top,string strWhere)
        {
            return dal.GetCompOFs(Top,strWhere);
        }
        public DataSet GetCompOFs(int TopNum, int Top, string strWhere)
        {
            return dal.GetCompOFs(TopNum,Top, strWhere);
        }
        /// <summary>
        /// 用户的中奖排行 3D 双色球
        /// </summary>
        /// <param name="steWhere">查询条件</param>
        public DataSet GetCompOFs(string strWhere)
        {
            return dal.GetCompOFs(strWhere);
        }

        /// <summary>
        /// 用户的中奖排行 排列3
        /// </summary>
        /// <param name="steWhere">查询条件</param>
        public DataSet GetCompOFs_P(int Top, string strWhere)
        {
            return dal.GetCompOFs_P(Top, strWhere);
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

        public DataTable GuestGetBySearchCinfo(string SearchStr, string getFileds, string OrderStr, int PageNum, int orderType, int CurrentPage, out int Counts)
        {
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "v_ReCon", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }

        #endregion  Method
    }
}