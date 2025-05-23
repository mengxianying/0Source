using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Pbzx.IDAL
{
    /// <summary>
    /// 接口层PlatformPublic_UserWinning
    /// </summary>
    public interface IPlatformPublic_UserWinning
    {
        #region  成员方法
        /// <summary>
        /// 得到最大ID
        /// </summary>
        int GetMaxId();
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string Qnum, string platform);
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(int u_id);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        void Add(Pbzx.Model.PlatformPublic_UserWinning model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(Pbzx.Model.PlatformPublic_UserWinning model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(int u_id);
        bool DeleteList(string u_idlist);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Pbzx.Model.PlatformPublic_UserWinning GetModel(int u_id);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetList(string strWhere);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataSet GetList(string columnName, string strWhere);
        
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
