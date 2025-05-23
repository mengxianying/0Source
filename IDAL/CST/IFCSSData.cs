using System;
using System.Data;
namespace Pbzx.IDAL
{
    /// <summary>
    /// 接口层IFCSSData 的摘要说明。
    /// </summary>
    public interface IFCSSData
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string issue);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Pbzx.Model.FCSSData model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        int Update(Pbzx.Model.FCSSData model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        int Delete(string issue);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Pbzx.Model.FCSSData GetModel(string issue);
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
