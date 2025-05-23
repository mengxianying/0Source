using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Pbzx.IDAL
{
    /// <summary>
    /// 接口层IChipped_Tracking 的摘要说明。
    /// </summary>
    public interface IChipped_Tracking
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(int TID);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Pbzx.Model.Chipped_Tracking model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(Pbzx.Model.Chipped_Tracking model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(int TID);
        bool DeleteList(string TIDlist);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Pbzx.Model.Chipped_Tracking GetModel(int TID);
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