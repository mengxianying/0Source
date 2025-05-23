using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Pbzx.IDAL
{
    /// <summary>
    /// 接口层IPBnet_Orders_Delegates 的摘要说明。
    /// </summary>
    public interface IPBnet_Orders_Delegates
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string OrderID);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        void Add(Pbzx.Model.PBnet_Orders_Delegates model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void Update(Pbzx.Model.PBnet_Orders_Delegates model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void Delete(string OrderID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Pbzx.Model.PBnet_Orders_Delegates GetModel(string OrderID);
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
        #endregion  成员方法
        /// <summary>
        /// 根据sql语句查询
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        DataSet Query(string sql);
    }
}
