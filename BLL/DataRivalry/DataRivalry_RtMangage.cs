using System;
using System.Collections.Generic;
using System.Text;
using Pbzx.IDAL;
using Pbzx.DALFactory;
using System.Data;

namespace Pbzx.BLL
{
    /// <summary>
    /// 业务逻辑类DataRivalry_Rt 的摘要说明。
    /// </summary>
    public class DataRivalry_Rt
    {
        private static readonly IDataRivalry_Rt dal = DataAccess.CreateDataRivalry_Rt();
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("DataRivalry_Rt", "Rt_ID");
        public DataRivalry_Rt()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Rt_ID)
        {
            return dal.Exists(Rt_ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.DataRivalry_Rt model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Pbzx.Model.DataRivalry_Rt model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int Rt_ID)
        {
            return dal.Delete(Rt_ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int DeleteJoint(int Rt_AwardNum)
        {
            return dal.DeleteJoint(Rt_AwardNum);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.DataRivalry_Rt GetModel(int Rt_ID)
        {
            return dal.GetModel(Rt_ID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 根据查询字符串获取分页数据
        /// 创建人: zhouwei
        /// </summary>
        /// <param name="SearchStr">查询字符串 </param>
        /// <param name="getFileds">获取列</param>
        /// <param name="OrderStr">排序字段</param>
        /// <param name="PageNum">获取的数据数</param>
        /// <param name="desc">升序还是降序</param>
        /// <param name="CurrentPage">当前的页数</param>
        /// <param name="Counts">返回记录集总数</param>
        /// <returns></returns>         

        public DataTable GuestGetBySearchResult(string SearchStr, string getFileds, string OrderStr, int PageNum, int orderType, int CurrentPage, out int Counts)
        {
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "DataRivalry_Rt", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }
        #endregion  成员方法
    }
}
