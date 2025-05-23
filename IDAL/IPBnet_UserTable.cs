using System;
using System.Data;
namespace Pbzx.IDAL
{
    /// <summary>
    /// 接口层IPBnet_UserTable 的摘要说明。
    /// </summary>
    public interface IPBnet_UserTable
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(int IntId);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Pbzx.Model.PBnet_UserTable model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        int Update(Pbzx.Model.PBnet_UserTable model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        int Delete(int IntId);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Pbzx.Model.PBnet_UserTable GetModel(int IntId);
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
    }
}
