using System;
using System.Data;
namespace Pbzx.IDAL
{
    /// <summary>
    /// 接口层PBnet_platfrom_icon
    /// </summary>
    public interface IPBnet_platfrom_icon
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(int p_id);
        bool Exists(string P_pfName);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Pbzx.Model.PBnet_platfrom_icon model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(Pbzx.Model.PBnet_platfrom_icon model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(int p_id);
        bool DeleteList(string p_idlist);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Pbzx.Model.PBnet_platfrom_icon GetModel(int p_id);
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
