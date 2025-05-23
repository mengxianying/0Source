using System;
using System.Data;
namespace Pbzx.IDAL
{
    /// <summary>
    /// 接口层ISoftDogInfo 的摘要说明。
    /// </summary>
    public interface ISoftDogInfo
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(int ID);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Pbzx.Model.SoftDogInfo model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        int Update(Pbzx.Model.SoftDogInfo model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        int Delete(int ID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Pbzx.Model.SoftDogInfo GetModel(int ID);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetList(string strWhere);
        /// <summary>
        /// 根据分页获得数据列表
        /// </summary>
        //		DataSet GetList(int PageSize,int PageIndex,string strWhere);
        #endregion  成员方法
        DataSet Query(string strSql);
    }
}
