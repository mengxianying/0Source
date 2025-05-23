using System;
using System.Data;
namespace Pbzx.IDAL
{
    /// <summary>
    /// 接口层ITC7XCData 的摘要说明。
    /// </summary>
    public interface ITC7XCData
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string issue);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        void Add(Pbzx.Model.TC7XCData model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void Update(Pbzx.Model.TC7XCData model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void Delete(string issue);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Pbzx.Model.TC7XCData GetModel(string issue);
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
