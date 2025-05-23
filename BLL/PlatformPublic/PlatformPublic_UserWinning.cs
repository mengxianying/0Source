using System;
using System.Collections.Generic;
using System.Text;
using Pbzx.DALFactory;
using Pbzx.IDAL;
using System.Data;


namespace Pbzx.BLL
{
    /// <summary>
    /// PlatformPublic_UserWinning
    /// </summary>
    public partial class PlatformPublic_UserWinning
    {
        private readonly IPlatformPublic_UserWinning dal = DataAccess.PlatformPublic_UserWinning();
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("PlatformPublic_UserWinning", "u_id");
        public PlatformPublic_UserWinning()
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
        public bool Exists(string Qnum, string platform)
        {
            return dal.Exists(Qnum,platform);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int u_id)
        {
            return dal.Exists(u_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(Pbzx.Model.PlatformPublic_UserWinning model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Pbzx.Model.PlatformPublic_UserWinning model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int u_id)
        {

            return dal.Delete(u_id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string u_idlist)
        {
            return dal.DeleteList(u_idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.PlatformPublic_UserWinning GetModel(int u_id)
        {

            return dal.GetModel(u_id);
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
        public DataSet GetList(string columnName, string strWhere)
        {
            return dal.GetList(columnName,strWhere); 
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
        public List<Pbzx.Model.PlatformPublic_UserWinning> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Pbzx.Model.PlatformPublic_UserWinning> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.PlatformPublic_UserWinning> modelList = new List<Pbzx.Model.PlatformPublic_UserWinning>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.PlatformPublic_UserWinning model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.PlatformPublic_UserWinning();
                    if (dt.Rows[n]["u_id"].ToString() != "")
                    {
                        model.u_id = int.Parse(dt.Rows[n]["u_id"].ToString());
                    }
                    model.u_name = dt.Rows[n]["u_name"].ToString();
                    if (dt.Rows[n]["u_issue"].ToString() != "")
                    {
                        model.u_issue = int.Parse(dt.Rows[n]["u_issue"].ToString());
                    }
                    if (dt.Rows[n]["u_time"].ToString() != "")
                    {
                        model.u_time = DateTime.Parse(dt.Rows[n]["u_time"].ToString());
                    }
                    if (dt.Rows[n]["u_lottId"].ToString() != "")
                    {
                        model.u_lottId = int.Parse(dt.Rows[n]["u_lottId"].ToString());
                    }
                    model.u_wItem = dt.Rows[n]["u_wItem"].ToString();
                    model.u_wContent = dt.Rows[n]["u_wContent"].ToString();
                    if (dt.Rows[n]["u_Monery"].ToString() != "")
                    {
                        model.u_Monery = decimal.Parse(dt.Rows[n]["u_Monery"].ToString());
                    }
                    if (dt.Rows[n]["u_coin"].ToString() != "")
                    {
                        model.u_coin = int.Parse(dt.Rows[n]["u_coin"].ToString());
                    }
                    model.u_platform = dt.Rows[n]["u_platform"].ToString();
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
        //return dal.GetList(PageSize,PageIndex,strWhere);GuestGetBySearchIntegral
        //}
        /// <summary>
        /// 根据查询字符串获取分页数据
        /// 创建人: zhouwei
        /// 创建时间: 2013-5-17
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
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "PlatformPublic_UserWinning", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
            
        }
        #endregion  Method
    }
}
