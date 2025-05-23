using System;
using System.Data;
namespace Pbzx.IDAL
{
    /// <summary>
    /// 接口层IFC4DData_ShangH 的摘要说明。
    /// </summary>
    public interface IFC4DData_ShangH
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string issue);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Pbzx.Model.FC4DData_ShangH model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        int Update(Pbzx.Model.FC4DData_ShangH model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        int Delete(string issue);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataSet GetList(int Top, string strWhere, string filedOrder);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Pbzx.Model.FC4DData_ShangH GetModel(string issue);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetList(string strWhere);
        /// <summary>
        /// 根据分页获得数据列表
        /// </summary>
        //		DataSet GetList(int PageSize,int PageIndex,string strWhere);
        #endregion  成员方法
    }
}
