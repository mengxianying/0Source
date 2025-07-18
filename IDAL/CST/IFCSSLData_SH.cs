using System;
using System.Data;
namespace Pbzx.IDAL
{
    /// <summary>
    /// 接口层IFCSSLData_SH 的摘要说明。
    /// </summary>
    public interface IFCSSLData_SH
    {
        #region  成员方法
        /// <summary>
        /// 得到最大ID
        /// </summary>
        int GetMaxId();
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(int Issue);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Pbzx.Model.FCSSLData_SH model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        int Update(Pbzx.Model.FCSSLData_SH model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        int Delete(int Issue);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Pbzx.Model.FCSSLData_SH GetModel(int Issue);
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
