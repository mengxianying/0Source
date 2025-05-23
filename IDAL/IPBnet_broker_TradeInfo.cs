using System;
using System.Data;
namespace Pbzx.IDAL
{
    /// <summary>
    /// 接口层IPBnet_broker_TradeInfo 的摘要说明。
    /// </summary>
    public interface IPBnet_broker_TradeInfo
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(int Id);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Pbzx.Model.PBnet_broker_TradeInfo model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        int Update(Pbzx.Model.PBnet_broker_TradeInfo model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        int Delete(int Id);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Pbzx.Model.PBnet_broker_TradeInfo GetModel(int Id);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetList(string strWhere);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataSet GetList(int Top, string strWhere, string filedOrder);
        /// <summary>
        /// 根据分页获得数据列表
        /// </summary>
        //		DataSet GetList(int PageSize,int PageIndex,string strWhere);
        #endregion  成员方法
    }
}
