using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Pbzx.IDAL
{
    /// <summary>
    /// 接口层IMarket_BuyInfo 的摘要说明。
    /// 创建人: zhouwei
    /// 创建时间: 2010-10-22
    /// </summary>
    public interface IMarket_BuyInfo
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string buyuserid, int issueInfoId);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Pbzx.Model.Market_BuyInfo buy);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        int Update(Pbzx.Model.Market_BuyInfo buy);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        int Delete(int ID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Pbzx.Model.Market_BuyInfo GetModel(int issueInfoId);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetList(string strWhere);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataSet GetList(int Top, string strWhere, string filedOrder);

        //返回一个datatable
        DataTable Query(string sql);
        //返回一个Dataset 类型
        DataSet QuerySet(string sql);
        #endregion
    }
}
