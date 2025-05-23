using System;
using System.Data;
namespace Pbzx.IDAL
{
    /// <summary>
    /// 接口层ICN_Software 的摘要说明。
    /// </summary>
    public interface ICN_Software
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(int ID, int InstallType);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Pbzx.Model.CN_Software model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        int  Update(Pbzx.Model.CN_Software model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        int Delete(int ID, int InstallType);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Pbzx.Model.CN_Software GetModel(int ID, int InstallType);
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
