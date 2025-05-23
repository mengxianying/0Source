using System;
using System.Collections.Generic;
using System.Text;
using Pbzx.IDAL;
using Pbzx.DALFactory;
using System.Data;
using System.IO;


namespace Pbzx.BLL
{
    /// <summary>
    /// 业务逻辑类DataRivalry_downLoad 的摘要说明。
    /// </summary>
    public class DataRivalry_downLoad
    {
        private static readonly IDataRivalry_downLoad dal = DataAccess.CreateDataRivalry_downLoad();
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("v_DataRivalry_download", "F_drID");
        Pbzx.SQLServerDAL.Basic basicDALD = new Pbzx.SQLServerDAL.Basic("v_downloadNum", "F_drID");
        public DataRivalry_downLoad()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Dl_id)
        {
            return dal.Exists(Dl_id);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <param name="Dl_ufID">大底的ID</param>
        /// <param name="Dl_name">会员名称</param>
        /// <returns></returns>
        public bool Exists(int Dl_ufID, string Dl_name)
        {
            return dal.Exists(Dl_ufID, Dl_name);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.DataRivalry_downLoad model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Pbzx.Model.DataRivalry_downLoad model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int Dl_id)
        {
            return dal.Delete(Dl_id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.DataRivalry_downLoad GetModel(int Dl_id)
        {
            return dal.GetModel(Dl_id);
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

        public DataTable GuestGetBySearchdownLoad(string SearchStr, string getFileds, string OrderStr, int PageNum, int orderType, int CurrentPage, out int Counts)
        {
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "v_DataRivalry_download", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }

        /// <summary>
        /// 根据查询字符串获取分页数据
        /// 创建人: zhouwei
        /// 创建时间: 2012-08-20
        /// </summary>
        /// <param name="SearchStr">查询字符串 </param>
        /// <param name="getFileds">获取列</param>
        /// <param name="OrderStr">排序字段</param>
        /// <param name="PageNum">获取的数据数</param>
        /// <param name="desc">升序还是降序</param>
        /// <param name="CurrentPage">当前的页数</param>
        /// <param name="Counts">返回记录集总数</param>
        /// <returns></returns>         

        public DataTable GuestGetBySearchdownD(string SearchStr, string getFileds, string OrderStr, int PageNum, int orderType, int CurrentPage, out int Counts)
        {
            return basicDALD.GuestGetBySearch(basicDAL.strPKName, "v_downloadNum", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }

        #endregion  成员方法
    }
}
