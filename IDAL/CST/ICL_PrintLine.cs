using System;
using System.Data;
namespace Pbzx.IDAL
{
    /// <summary>
    /// 接口层ICL_PrintLine 的摘要说明。
    /// </summary>
    public interface ICL_PrintLine
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(int ID);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Pbzx.Model.CL_PrintLine model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        int Update(Pbzx.Model.CL_PrintLine model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        int Delete(int ID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Pbzx.Model.CL_PrintLine GetModel(int ID);
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
        /// 根据sql语句查询
        /// </summary>
        /// <param name="strSql">sql语句</param>
        /// <returns>返回值</returns>
        DataSet Query(string strSql);
    }
}
