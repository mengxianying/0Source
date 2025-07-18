using System;
using System.Data;
namespace Pbzx.IDAL
{
    /// <summary>
    /// 接口层IPBnet_Bulletin 的摘要说明。
    /// </summary>
    public interface IPBnet_Bulletin
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(int IntID);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Pbzx.Model.PBnet_Bulletin model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        int Update(Pbzx.Model.PBnet_Bulletin model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        int Delete(int IntID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Pbzx.Model.PBnet_Bulletin GetModel(int IntID);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetList(string strWhere);
        /// <summary>
        /// 根据分页获得数据列表
        /// </summary>
        //		DataSet GetList(int PageSize,int PageIndex,string strWhere);
        #endregion  成员方法
        /// <summary>
        /// 执行sql语句,返回受影响行数
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        int ExecuteBySql(string sql);
        DataTable Query(string sql);
        DataSet GetList(int Top, string strWhere, string filedOrder);
    }
}
