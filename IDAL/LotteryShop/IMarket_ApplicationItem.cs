using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Pbzx.IDAL
{
    /// <summary>
    /// 数据接口层
    /// 创建人：杨良伟
    /// 创建时间：2010-10-25
    /// </summary>
   public interface IMarket_ApplicationItem
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(int ID);
        /// <summary>
        /// 增加一条数据
        /// </summary>
       int Add(Pbzx.Model.Market_ApplicationItem main);
        /// <summary>
        /// 更新一条数据
        /// </summary>
       int Update(Pbzx.Model.Market_ApplicationItem main);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        int Delete(int ID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
       Pbzx.Model.Market_ApplicationItem GetMain(int ID);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetList(string strWhere);
        #endregion
    }
}
