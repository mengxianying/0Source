using System;
using System.Data;
namespace Pbzx.IDAL
{
    /// <summary>
    /// 接口层IPBnet_LyBook 的摘要说明。
    /// </summary>
    public interface IPBnet_LyBook
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(int SystemNumber);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Pbzx.Model.PBnet_LyBook model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        int Update(Pbzx.Model.PBnet_LyBook model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        int Delete(int SystemNumber);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Pbzx.Model.PBnet_LyBook GetModel(int SystemNumber);
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
