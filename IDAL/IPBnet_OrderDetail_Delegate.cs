using System;
using System.Data;
namespace Pbzx.IDAL
{
    /// <summary>
    /// 接口层IPBnet_OrderDetail_Delegate 的摘要说明。
    /// </summary>
    public interface IPBnet_OrderDetail_Delegate
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(long OrderDetailID);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Pbzx.Model.PBnet_OrderDetail_Delegate model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void Update(Pbzx.Model.PBnet_OrderDetail_Delegate model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void Delete(long OrderDetailID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Pbzx.Model.PBnet_OrderDetail_Delegate GetModel(long OrderDetailID);
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
        //DataSet GetList(int PageSize,int PageIndex,string strWhere);

        DataSet SelectOrderDetailDelegateByOrderID(string orderID);
        #endregion  成员方法
    }
}
